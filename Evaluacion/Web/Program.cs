using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Data.Interfaces;
using Business.Interfaces;
using Business.Implements;
using Web.ServiceExtension;
using FluentValidation;
using FluentValidation.AspNetCore;
using Data.Implements;
using Data.Implements.BaseData;
using Entity.Context;
using Entity.Dtos;
using Utilities.Mappers.Profiles;

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
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register generic repositories and business logic
builder.Services.AddScoped(typeof(IBaseModelData<>), typeof(BaseModelData<>));
builder.Services.AddScoped(typeof(IBaseBusiness<,>), typeof(BaseBusiness<,>));

// Register Cliente-specific services
builder.Services.AddScoped<IClienteData, ClienteData>();
builder.Services.AddScoped<IClienteBusiness, ClienteBusiness>();


// Registrar perfiles de AutoMapper
builder.Services.AddAutoMapper(typeof(ClienteProfile));

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
