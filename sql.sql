
-- ==============================
-- 📦 BLOQUE DE SEGURIDAD
-- ==============================

CREATE TABLE User (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    UserName VARCHAR(100) NOT NULL,
    Email VARCHAR(150) NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    IsActive BOOLEAN DEFAULT TRUE,
    Description VARCHAR(255),
    Active BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL
);

CREATE TABLE Rol (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL,
    Description VARCHAR(255),
    IsSystem BOOLEAN DEFAULT FALSE,
    Active BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL
);

CREATE TABLE RolUser (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    UserId INT NOT NULL,
    RolId INT NOT NULL,
    Active BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (UserId) REFERENCES User(Id),
    FOREIGN KEY (RolId) REFERENCES Rol(Id)
);

CREATE TABLE Permission (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL,
    Description VARCHAR(255),
    Active BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL
);

CREATE TABLE Modules (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL,
    Description VARCHAR(255),
    `Order` INT,
    Active BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL
);

CREATE TABLE Form (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL,
    Url VARCHAR(150),
    Icon VARCHAR(100),
    Description VARCHAR(255),
    Active BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL
);

CREATE TABLE FormModule (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    FormId INT NOT NULL,
    ModuleId INT NOT NULL,
    Active BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (FormId) REFERENCES Form(Id),
    FOREIGN KEY (ModuleId) REFERENCES Modules(Id)
);

CREATE TABLE RolFormPermission (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    RolId INT NOT NULL,
    FormId INT NOT NULL,
    PermissionId INT NOT NULL,
    Active BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (RolId) REFERENCES Rol(Id),
    FOREIGN KEY (FormId) REFERENCES Form(Id),
    FOREIGN KEY (PermissionId) REFERENCES Permission(Id)
);

-- ==============================
-- 🎌 BLOQUE DE GESTIÓN DE ANIME
-- ==============================

CREATE TABLE Estudio (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(100) NOT NULL,
    Pais VARCHAR(50),
    Fundacion INT,
    Description VARCHAR(255),
    Active BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL
);

CREATE TABLE Animes (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Titulo VARCHAR(150) NOT NULL,
    Sinopsis TEXT,
    FechaEmision DATE,
    Estado VARCHAR(50),
    IdEstudio INT,
    Description VARCHAR(255),
    Active BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (IdEstudio) REFERENCES Estudio(Id)
);

CREATE TABLE Genero (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(50) NOT NULL,
    Description VARCHAR(255),
    Active BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL
);

CREATE TABLE AnimeGenero (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    IdAnime INT NOT NULL,
    IdGenero INT NOT NULL,
    Active BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (IdAnime) REFERENCES Animes(Id),
    FOREIGN KEY (IdGenero) REFERENCES Genero(Id)
);

CREATE TABLE Personaje (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(100) NOT NULL,
    Rol VARCHAR(50),
    Descripcion TEXT,
    Description VARCHAR(255),
    Active BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL
);

CREATE TABLE AnimePersonaje (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    IdAnime INT NOT NULL,
    IdPersonaje INT NOT NULL,
    Papel VARCHAR(50),
    Active BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (IdAnime) REFERENCES Animes(Id),
    FOREIGN KEY (IdPersonaje) REFERENCES Personaje(Id)
);

CREATE TABLE ActorVoz (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(100),
    Nacionalidad VARCHAR(50),
    Description VARCHAR(255),
    Active BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL
);

CREATE TABLE PersonajeVoz (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    IdPersonaje INT NOT NULL,
    IdActorVoz INT NOT NULL,
    Idioma VARCHAR(50),
    Active BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (IdPersonaje) REFERENCES Personaje(Id),
    FOREIGN KEY (IdActorVoz) REFERENCES ActorVoz(Id)
);

CREATE TABLE UsuarioAnime (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    IdUser INT NOT NULL,
    IdAnime INT NOT NULL,
    Calificacion INT,
    EstadoVisualizacion VARCHAR(50),
    Active BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (IdUser) REFERENCES User(Id),
    FOREIGN KEY (IdAnime) REFERENCES Animes(Id)
);
