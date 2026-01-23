# Plantilla C# - Sistema de Gestión de Seguridad

## 📋 Descripción del Proyecto

Este es un proyecto plantilla desarrollado en **.NET 9.0** que implementa un sistema completo de gestión de seguridad y permisos. El proyecto sigue una arquitectura en capas (Clean Architecture) y proporciona una base sólida para aplicaciones empresariales que requieren autenticación, autorización y gestión de usuarios, roles y permisos.

### Características Principales

-  **Arquitectura en capas** (Data, Business, Entity, Web)
-  **Autenticación y Autorización** con JWT
-  **Multi-base de datos** (SQL Server, MySQL, PostgreSQL)
-  **Entity Framework Core** con migraciones
-  **AutoMapper** para mapeo de objetos
-  **FluentValidation** para validaciones
-  **Dapper** para consultas optimizadas
-  **Swagger/OpenAPI** para documentación de la API
-  **Soporte Docker** incluido
-  **Repositorio Genérico** implementado

## 🏗️ Arquitectura del Proyecto

```
PlantillaC#/
│
├── Web/                          # Capa de presentación (API REST)
│   ├── Controllers/              # Controladores de la API
│   ├── ServiceExtension/         # Extensiones de servicios
│   └── Program.cs                # Punto de entrada de la aplicación
│
├── Business/                     # Capa de lógica de negocio
│   ├── Implements/               # Implementaciones de lógica de negocio
│   └── Interfaces/               # Interfaces de servicios de negocio
│
├── Data/                         # Capa de acceso a datos
│   ├── Implements/               # Implementación de repositorios
│   └── Interfaces/               # Interfaces de repositorios
│
├── Entity/                       # Capa de entidades
│   ├── Model/                    # Modelos de dominio
│   ├── Dtos/                     # Data Transfer Objects
│   ├── Context/                  # Contexto de base de datos
│   └── Migrations/               # Migraciones de EF Core
│
└── Utilities/                    # Utilidades y helpers
    ├── Mappers/                  # Perfiles de AutoMapper
    └── Exceptions/               # Excepciones personalizadas
```

## 🔑 Módulos del Sistema

El sistema incluye los siguientes módulos principales:

- **Users (Usuarios)**: Gestión de usuarios del sistema
- **Roles**: Definición de roles
- **RolUser**: Asignación de roles a usuarios
- **Permissions (Permisos)**: Definición de permisos
- **Forms (Formularios)**: Gestión de formularios/vistas
- **Modules (Módulos)**: Organización de módulos del sistema
- **FormModule**: Relación entre formularios y módulos
- **RolFormPermission**: Asignación de permisos sobre formularios a roles

## 🛠️ Tecnologías Utilizadas

- **.NET 9.0**
- **Entity Framework Core 9.0**
- **ASP.NET Core Web API**
- **AutoMapper**
- **FluentValidation**
- **Dapper**
- **JWT Authentication**
- **Swagger/OpenAPI**
- **Docker**

### Bases de Datos Soportadas

- SQL Server
- MySQL (Pomelo)
- PostgreSQL (Npgsql)

## 📋 Requisitos Previos

Antes de ejecutar el proyecto, asegúrate de tener instalado:

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Una de las siguientes bases de datos:
  - SQL Server 2019 o superior
  - MySQL 8.0 o superior
  - PostgreSQL 13 o superior
- [Docker](https://www.docker.com/) (opcional, para contenedores)
- Un IDE como Visual Studio 2022, Visual Studio Code o JetBrains Rider

## ⚙️ Configuración

### 1. Configurar la Cadena de Conexión

Edita el archivo [Web/appsettings.json](Web/appsettings.json) y configura las cadenas de conexión según tu base de datos:

```json
{
  "ConnectionStrings": {
    "SqlServer": "Server=localhost;Database=ModelSecurity;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True",
    "MySql": "Server=localhost;Database=ModelSecurity;User=root;Password=TU_PASSWORD;",
    "Postgres": "Host=localhost;Database=ModelSecurity;Username=postgres;Password=TU_PASSWORD"
  },
  "DatabaseProvider": "MySql"
}
```

**Cambiar el proveedor de base de datos:**

Modifica el valor de `"DatabaseProvider"` a uno de los siguientes:
- `"SqlServer"` para SQL Server
- `"MySql"` para MySQL
- `"Postgres"` para PostgreSQL

### 2. Restaurar Dependencias

Abre una terminal en la raíz del proyecto y ejecuta:

```bash
dotnet restore
```

### 3. Aplicar Migraciones

Navega a la carpeta del proyecto Web y ejecuta:

```bash
cd Web
dotnet ef database update --project ../Entity
```

O desde la raíz del proyecto:

```bash
dotnet ef database update --project Entity --startup-project Web
```

## 🚀 Cómo Ejecutar el Proyecto

### Opción 1: Usando la CLI de .NET

1. Navega a la carpeta Web:
   ```bash
   cd Web
   ```

2. Ejecuta el proyecto:
   ```bash
   dotnet run
   ```

3. La API estará disponible en:
   - HTTPS: `https://localhost:7xxx`
   - HTTP: `http://localhost:5xxx`

4. Accede a Swagger en:
   ```
   https://localhost:7xxx/swagger
   ```

### Opción 2: Usando Visual Studio

1. Abre el archivo `PlantillaC#.sln` en Visual Studio
2. Establece el proyecto **Web** como proyecto de inicio (clic derecho > Establecer como proyecto de inicio)
3. Presiona `F5` o haz clic en el botón "Ejecutar"

### Opción 3: Usando Docker

1. Construye la imagen Docker:
   ```bash
   docker build -t plantilla-csharp -f Web/Dockerfile .
   ```

2. Ejecuta el contenedor:
   ```bash
   docker run -p 8080:8080 -p 8081:8081 plantilla-csharp
   ```

3. Accede a la API en: `http://localhost:8080`

## 📝 Uso de la API

### Endpoints Disponibles

La API expone los siguientes controladores:

- `/api/User` - Gestión de usuarios
- `/api/Rol` - Gestión de roles
- `/api/RolUser` - Asignación de roles a usuarios
- `/api/Permission` - Gestión de permisos
- `/api/Form` - Gestión de formularios
- `/api/Module` - Gestión de módulos
- `/api/FormModule` - Relación formulario-módulo
- `/api/RolFormPermission` - Asignación de permisos

### Documentación Interactiva

Una vez que el proyecto esté ejecutándose, accede a Swagger UI para explorar y probar los endpoints:

```
https://localhost:7xxx/swagger
```

## 🗄️ Migraciones de Base de Datos

### Crear una Nueva Migración

```bash
dotnet ef migrations add NombreDeLaMigracion --project Entity --startup-project Web
```

### Aplicar Migraciones

```bash
dotnet ef database update --project Entity --startup-project Web
```

### Revertir Migración

```bash
dotnet ef database update MigracionAnterior --project Entity --startup-project Web
```

### Eliminar Última Migración

```bash
dotnet ef migrations remove --project Entity --startup-project Web
```

## 🔧 Desarrollo

### Agregar una Nueva Entidad

1. **Crear el modelo** en `Entity/Model/`
2. **Crear el DTO** en `Entity/Dtos/`
3. **Agregar DbSet** en `Entity/Context/ApplicationDbContext.cs`
4. **Crear interfaz de datos** en `Data/Interfaces/`
5. **Implementar repositorio** en `Data/Implements/`
6. **Crear interfaz de negocio** en `Business/Interfaces/`
7. **Implementar lógica de negocio** en `Business/Implements/`
8. **Crear el controlador** en `Web/Controllers/`
9. **Registrar servicios** en `Web/Program.cs`
10. **Crear perfil de AutoMapper** en `Utilities/Mappers/Profiles/`
11. **Crear y aplicar migración**

### Estructura de una Entidad Genérica

Este proyecto implementa un patrón de repositorio genérico que reduce el código repetitivo. Puedes heredar de `BaseModelData<T>` y `BaseBusiness<TDto, TEntity>` para operaciones CRUD básicas.

## 🧪 Pruebas

*(Sección para agregar instrucciones de testing cuando se implementen)*

## 📦 Compilación para Producción

Para compilar el proyecto en modo Release:

```bash
dotnet build --configuration Release
```

Para publicar la aplicación:

```bash
dotnet publish --configuration Release --output ./publish
```

## 🤝 Contribuir

1. Fork el proyecto
2. Crea una rama para tu característica (`git checkout -b feature/NuevaCaracteristica`)
3. Commit tus cambios (`git commit -m 'Agregar nueva característica'`)
4. Push a la rama (`git push origin feature/NuevaCaracteristica`)
5. Abre un Pull Request

## 📄 Licencia

Este proyecto es una plantilla de código abierto. Puedes usarlo libremente para tus proyectos.

## 👤 Autor

**Brayan Cortes**
- GitHub: [@brayancortes22](https://github.com/brayancortes22)

