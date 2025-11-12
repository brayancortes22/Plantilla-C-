
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Web.ServiceExtension;
using FluentValidation;
using FluentValidation.AspNetCore;
using Entity.Context;

using Utilities.Mappers.Profiles.Security;
using Utilities.Mappers.Profiles.Anime;

using Data.Implements.BaseData;
using Data.Interfaces.BaseData;
using Data.Interfaces.Security;
using Data.Implements.Security;
using Data.Interfaces.Anime;
using Data.Implements.Anime;

using Business.Interfaces.Base;
using Business.Implements.Base;
using Business.Implements.Security;
using Business.Interfaces.Security;
using Business.Interfaces.Anime;
using Business.Implements.Anime;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));
builder.Services.AddSingleton<IValidatorFactory>(sp =>
    new ServiceProviderValidatorFactory(sp));

// Swagger
builder.Services.AddSwaggerDocumentation();

// DbContext
var dbProvider = builder.Configuration["DatabaseProvider"] ?? "SqlServer";
var connStrings = builder.Configuration.GetSection("ConnectionStrings");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    switch (dbProvider)
    {
        case "MySql":
            options.UseMySql(
                connStrings["MySql"],
                ServerVersion.AutoDetect(connStrings["MySql"]) // Requiere Pomelo.EntityFrameworkCore.MySql
            );
            break;
        case "Postgres":
            options.UseNpgsql(connStrings["Postgres"]); // Requiere Npgsql.EntityFrameworkCore.PostgreSQL
            break;
        default:
            options.UseSqlServer(connStrings["SqlServer"]);
            break;
    }
});

// Register generic repositories and business logic
builder.Services.AddScoped(typeof(IBaseModelData<>), typeof(BaseModelData<>));
builder.Services.AddScoped(typeof(IBaseBusiness<,>), typeof(BaseBusiness<,>));

// Registrar servicios para entidades security
builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<IUserBusiness, UserBusiness>();

builder.Services.AddScoped<IRolUserData, RolUserData>();
builder.Services.AddScoped<IRolUserBusiness, RolUserBusiness>();

builder.Services.AddScoped<IRolData, RolData>();
builder.Services.AddScoped<IRolBusiness, RolBusiness>();

builder.Services.AddScoped<IPermissionData, PermissionData>();
builder.Services.AddScoped<IPermissionBusiness, PermissionBusiness>();

builder.Services.AddScoped<IFormData, FormData>();
builder.Services.AddScoped<IFormBusiness, FormBusiness>();

builder.Services.AddScoped<IFormModuleData, FormModuleData>();
builder.Services.AddScoped<IFormModuleBusiness, FormModuleBusiness>();

builder.Services.AddScoped<IModuleData, ModuleData>();
builder.Services.AddScoped<IModuleBusiness, ModuleBusiness>();

builder.Services.AddScoped<IRolFormPermissionData, RolFormPermissionData>();
builder.Services.AddScoped<IRolFormPermissionBusiness, RolFormPermissionBusiness>();


// registrar servicios para entidades de anime

builder.Services.AddScoped<IEstudioData, EstudioData>();
builder.Services.AddScoped<IEstudioBusiness, EstudioBusiness>();

builder.Services.AddScoped<IAnimeData, AnimeData>();
builder.Services.AddScoped<IAnimeBusiness, AnimeBusiness>();

builder.Services.AddScoped<IGeneroData, GeneroData>();
builder.Services.AddScoped<IGeneroBusiness, GeneroBusiness>();

builder.Services.AddScoped<IAnimeGeneroData, AnimeGeneroData>();
builder.Services.AddScoped<IAnimeGeneroBusiness, AnimeGeneroBusiness>();

builder.Services.AddScoped<IPersonajeData, PersonajeData>();
builder.Services.AddScoped<IPersonajeBusiness, PersonajeBusiness>();

builder.Services.AddScoped<IAnimePersonajeData, AnimePersonajeData>();
builder.Services.AddScoped<IAnimePersonajeBusiness, AnimePersonajeBusiness>();

builder.Services.AddScoped<IActorVozData, ActorVozData>();
builder.Services.AddScoped<IActorVozBusiness, ActorVozBusiness>();

builder.Services.AddScoped<IPersonajeVozData, PersonajeVozData>();
builder.Services.AddScoped<IPersonajeVozBusiness, PersonajeVozBusiness>();

builder.Services.AddScoped<IUsuarioAnimeData, UsuarioAnimeData>();
builder.Services.AddScoped<IUsuarioAnimeBusiness, UsuarioAnimeBusiness>();



// Registrar perfiles de AutoMapper
builder.Services.AddAutoMapper(cfg => {
    // Perfiles de security
    cfg.AddProfile<UserProfile>();
    cfg.AddProfile<RolUserProfile>();
    cfg.AddProfile<RolProfile>();
    cfg.AddProfile<PermissionProfile>();
    cfg.AddProfile<FormProfile>();
    cfg.AddProfile<FormModuleProfile>();
    cfg.AddProfile<ModuleProfile>();
    cfg.AddProfile<RolFormPermissionProfile>();

    // Perfiles de anime
    cfg.AddProfile<EstudioProfile>();
    cfg.AddProfile<AnimeProfile>();
    cfg.AddProfile<GeneroProfile>();
    cfg.AddProfile<AnimeGeneroProfile>();
    cfg.AddProfile<PersonajeProfile>();
    cfg.AddProfile<AnimePersonajeProfile>();
    cfg.AddProfile<ActorVozProfile>();
    cfg.AddProfile<PersonajeVozProfile>();
    cfg.AddProfile<UsuarioAnimeProfile>();
});

var app = builder.Build();

// Swagger (solo en desarrollo)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Sistema de Gestión v1");
        c.RoutePrefix = string.Empty;
    });
}

// Usa la política de CORS registrada en ApplicationServiceExtensions
app.UseCors("AllowSpecificOrigins");

app.UseHttpsRedirection();

// Autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Inicializar base de datos y aplicar migraciones
await InitializeDatabaseAsync(app.Services);

app.Run();

/// <summary>
/// Inicializa la base de datos de manera segura, eliminando y recreando si hay conflictos
/// </summary>
static async Task InitializeDatabaseAsync(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    
    try
    {
        var dbContext = services.GetRequiredService<ApplicationDbContext>();
        
        // Verificar si existen migraciones pendientes
        var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
        var appliedMigrations = await dbContext.Database.GetAppliedMigrationsAsync();
        
        logger.LogInformation($"Migraciones aplicadas: {appliedMigrations.Count()}");
        logger.LogInformation($"Migraciones pendientes: {pendingMigrations.Count()}");
        
        if (pendingMigrations.Any())
        {
            logger.LogInformation("Hay migraciones pendientes. Verificando estado de la base de datos...");
            
            try
            {
                // Intentar aplicar migraciones normalmente
                await dbContext.Database.MigrateAsync();
                logger.LogInformation("Migraciones aplicadas exitosamente.");
            }
            catch (Exception migrationEx)
            {
                logger.LogWarning($"Error al aplicar migraciones: {migrationEx.Message}");
                logger.LogInformation("Eliminando y recreando la base de datos...");
                
                // Si hay error, eliminar y recrear la base de datos
                await dbContext.Database.EnsureDeletedAsync();
                logger.LogInformation("Base de datos eliminada.");
                
                await dbContext.Database.MigrateAsync();
                logger.LogInformation("Base de datos recreada con éxito.");
            }
        }
        else
        {
            logger.LogInformation("No hay migraciones pendientes. Base de datos actualizada.");
        }
        
        // Verificar conectividad
        if (await dbContext.Database.CanConnectAsync())
        {
            logger.LogInformation("Conexión a la base de datos verificada exitosamente.");
        }
        else
        {
            logger.LogError("No se pudo conectar a la base de datos.");
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error crítico durante la inicialización de la base de datos.");
        throw; // Re-lanzar para detener la aplicación si no se puede inicializar la BD
    }
}
