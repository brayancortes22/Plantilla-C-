using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Data;

using Entity.Model.Security;
using Entity.Model.Anime;

using System.Reflection;

namespace Entity.Context
{
    /// <summary>
    /// Representa el contexto de la base de datos de la aplicación, proporcionando configuraciones y métodos
    /// para la gestión de entidades y consultas personalizadas con Dapper.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Configuración de la aplicación.
        /// </summary>
        protected readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor del contexto de la base de datos.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto de base de datos.</param>
        /// <param name="configuration">Instancia de IConfiguration para acceder a la configuración de la aplicación.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
        {
            _configuration = configuration;
        }

        ///
        /// DB SETS
        ///

    // Dbset para entidades de security
    public DbSet<User> Users { get; set; }
    public DbSet<RolUser> RolUsers { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Form> Forms { get; set; }
    public DbSet<FormModule> FormModules { get; set; }
    public DbSet<Modules> Modules { get; set; }
    public DbSet<RolFormPermission> RolFormPermissions { get; set; }
    // DbSet para entidades de Anime
    public DbSet<Estudio> Estudios { get; set; }
    public DbSet<Anime> Animes { get; set; }
    public DbSet<Genero> Generos { get; set; }
    public DbSet<AnimeGenero> AnimeGeneros { get; set; }
    public DbSet<Personaje> Personajes { get; set; }
    public DbSet<AnimePersonaje> AnimePersonajes { get; set; }
    public DbSet<ActorVoz> ActoresVoz { get; set; }
    public DbSet<PersonajeVoz> PersonajeVoces { get; set; }
    public DbSet<UsuarioAnime> UsuarioAnimes { get; set; }

        /// <summary>
        /// Configura los modelos de la base de datos aplicando configuraciones desde ensamblados.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo de base de datos.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relaciones Anime
            // AnimeGenero: clave compuesta
            modelBuilder.Entity<AnimeGenero>()
                .HasKey(ag => new { ag.IdAnime, ag.IdGenero });
            modelBuilder.Entity<AnimeGenero>()
                .HasOne(ag => ag.Anime)
                .WithMany(a => a.AnimeGeneros)
                .HasForeignKey(ag => ag.IdAnime);
            modelBuilder.Entity<AnimeGenero>()
                .HasOne(ag => ag.Genero)
                .WithMany(g => g.AnimeGeneros)
                .HasForeignKey(ag => ag.IdGenero);

            // AnimePersonaje: clave compuesta
            modelBuilder.Entity<AnimePersonaje>()
                .HasKey(ap => new { ap.IdAnime, ap.IdPersonaje });
            modelBuilder.Entity<AnimePersonaje>()
                .HasOne(ap => ap.Anime)
                .WithMany(a => a.AnimePersonajes)
                .HasForeignKey(ap => ap.IdAnime);
            modelBuilder.Entity<AnimePersonaje>()
                .HasOne(ap => ap.Personaje)
                .WithMany(p => p.AnimePersonajes)
                .HasForeignKey(ap => ap.IdPersonaje);

            // PersonajeVoz: clave compuesta
            modelBuilder.Entity<PersonajeVoz>()
                .HasKey(pv => new { pv.Personaje.Id, pv.IdActorVoz });
            modelBuilder.Entity<PersonajeVoz>()
                .HasOne(pv => pv.Personaje)
                .WithMany(p => p.PersonajeVoces)
                .HasForeignKey("IdPersonaje");
            modelBuilder.Entity<PersonajeVoz>()
                .HasOne(pv => pv.ActorVoz)
                .WithMany(av => av.PersonajeVoces)
                .HasForeignKey(pv => pv.IdActorVoz);

            // UsuarioAnime: clave compuesta
            modelBuilder.Entity<UsuarioAnime>()
                .HasKey(ua => new { ua.IdUser, ua.IdAnime });
            modelBuilder.Entity<UsuarioAnime>()
                .HasOne(ua => ua.User)
                .WithMany()
                .HasForeignKey(ua => ua.IdUser);
            modelBuilder.Entity<UsuarioAnime>()
                .HasOne(ua => ua.Anime)
                .WithMany(a => a.UsuarioAnimes)
                .HasForeignKey(ua => ua.IdAnime);

            // Estudio-Anime: 1-N
            modelBuilder.Entity<Anime>()
                .HasOne(a => a.Estudio)
                .WithMany(e => e.Animes)
                .HasForeignKey(a => a.IdEstudio);

            // Relaciones y configuraciones para nuevas entidades
            // User - RolUser (1:N)
            modelBuilder.Entity<RolUser>()
                .HasOne(ru => ru.User)
                .WithMany(u => u.RolUsers)
                .HasForeignKey(ru => ru.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Rol - RolUser (1:N)
            modelBuilder.Entity<RolUser>()
                .HasOne(ru => ru.Rol)
                .WithMany(r => r.RolUsers)
                .HasForeignKey(ru => ru.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            // Rol - RolFormPermission (1:N)
            modelBuilder.Entity<RolFormPermission>()
                .HasOne(rfp => rfp.Rol)
                .WithMany(r => r.RolFormPermissions)
                .HasForeignKey(rfp => rfp.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            // Form - RolFormPermission (1:N)
            modelBuilder.Entity<RolFormPermission>()
                .HasOne(rfp => rfp.Form)
                .WithMany(f => f.RolFormPermissions)
                .HasForeignKey(rfp => rfp.FormId)
                .OnDelete(DeleteBehavior.Restrict);

            // Permission - RolFormPermission (1:N)
            modelBuilder.Entity<RolFormPermission>()
                .HasOne(rfp => rfp.Permission)
                .WithMany(p => p.RolFormPermissions)
                .HasForeignKey(rfp => rfp.PermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Form - FormModule (1:N)
            modelBuilder.Entity<FormModule>()
                .HasOne(fm => fm.Form)
                .WithMany(f => f.FormModules)
                .HasForeignKey(fm => fm.FormId)
                .OnDelete(DeleteBehavior.Restrict);

            // Module - FormModule (1:N)
            modelBuilder.Entity<FormModule>()
                .HasOne(fm => fm.Module)
                .WithMany(m => m.FormModules)
                .HasForeignKey(fm => fm.ModuleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de propiedades requeridas y longitudes
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Modules>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Configura opciones adicionales del contexto, como el registro de datos sensibles.
        /// </summary>
        /// <param name="optionsBuilder">Constructor de opciones de configuración del contexto.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            // Otras configuraciones adicionales pueden ir aquí
        }

        /// <summary>
        /// Configura convenciones de tipos de datos, estableciendo la precisión por defecto de los valores decimales.
        /// </summary>
        /// <param name="configurationBuilder">Constructor de configuración de modelos.</param>
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }

        /// <summary>
        /// Guarda los cambios en la base de datos, asegurando la auditoría antes de persistir los datos.
        /// </summary>
        /// <returns>Número de filas afectadas.</returns>
        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }

        /// <summary>
        /// Guarda los cambios en la base de datos de manera asíncrona, asegurando la auditoría antes de la persistencia.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">Indica si se deben aceptar todos los cambios en caso de éxito.</param>
        /// <param name="cancellationToken">Token de cancelación para abortar la operación.</param>
        /// <returns>Número de filas afectadas de forma asíncrona.</returns>
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            EnsureAudit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        /// Ejecuta una consulta SQL utilizando Dapper y devuelve una colección de resultados de tipo genérico.
        /// </summary>
        /// <typeparam name="T">Tipo de los datos de retorno.</typeparam>
        /// <param name="text">Consulta SQL a ejecutar.</param>
        /// <param name="parameters">Parámetros opcionales de la consulta.</param>
        /// <param name="timeout">Tiempo de espera opcional para la consulta.</param>
        /// <param name="type">Tipo opcional de comando SQL.</param>
        /// <returns>Una colección de objetos del tipo especificado.</returns>
        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }

        /// <summary>
        /// Ejecuta una consulta SQL utilizando Dapper y devuelve un solo resultado o el valor predeterminado si no hay resultados.
        /// </summary>
        /// <typeparam name="T">Tipo de los datos de retorno.</typeparam>
        /// <param name="text">Consulta SQL a ejecutar.</param>
        /// <param name="parameters">Parámetros opcionales de la consulta.</param>
        /// <param name="timeout">Tiempo de espera opcional para la consulta.</param>
        /// <param name="type">Tipo opcional de comando SQL.</param>
        /// <returns>Un objeto del tipo especificado o su valor predeterminado.</returns>
        public async Task<T> QueryFirstOrDefaultAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }

        public async Task<int> ExecuteAsync(String text, object parametres = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parametres, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.ExecuteAsync(command.Definition);
        }

        //Devolver Objeto
        public async Task<T> ExecuteScalarAsync<T>(string query, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, query, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.ExecuteScalarAsync<T>(command.Definition);
        }

        /// <summary>
        /// Método interno para garantizar la auditoría de los cambios en las entidades.
        /// </summary>
        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
        }

        /// <summary>
        /// Estructura para ejecutar comandos SQL con Dapper en Entity Framework Core.
        /// </summary>
        public readonly struct DapperEFCoreCommand : IDisposable
        {
            /// <summary>
            /// Constructor del comando Dapper.
            /// </summary>
            /// <param name="context">Contexto de la base de datos.</param>
            /// <param name="text">Consulta SQL.</param>
            /// <param name="parameters">Parámetros opcionales.</param>
            /// <param name="timeout">Tiempo de espera opcional.</param>
            /// <param name="type">Tipo de comando SQL opcional.</param>
            /// <param name="ct">Token de cancelación.</param>
            public DapperEFCoreCommand(DbContext context, string text, object parameters, int? timeout, CommandType? type, CancellationToken ct)
            {
                var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
                var commandType = type ?? CommandType.Text;
                var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

                Definition = new CommandDefinition(
                    text,
                    parameters,
                    transaction,
                    commandTimeout,
                    commandType,
                    cancellationToken: ct
                );
            }

            /// <summary>
            /// Define los parámetros del comando SQL.
            /// </summary>
            public CommandDefinition Definition { get; }

            /// <summary>
            /// Método para liberar los recursos.
            /// </summary>
            public void Dispose()
            {
            }
        }
    }
}