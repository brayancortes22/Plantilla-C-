-- ==============================
-- 📦 BLOQUE DE SEGURIDAD
-- ==============================

CREATE TABLE Person (
    id_person INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100),
    correo VARCHAR(150) UNIQUE NOT NULL
);

CREATE TABLE User (
    id_user INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(50) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    estado BOOLEAN DEFAULT TRUE,
    id_person INT,
    FOREIGN KEY (id_person) REFERENCES Person(id_person)
);

CREATE TABLE Rol (
    id_rol INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(50) NOT NULL,
    descripcion VARCHAR(150)
);

CREATE TABLE RolUser (
    id_user INT,
    id_rol INT,
    PRIMARY KEY (id_user, id_rol),
    FOREIGN KEY (id_user) REFERENCES User(id_user),
    FOREIGN KEY (id_rol) REFERENCES Rol(id_rol)
);

CREATE TABLE Permission (
    id_permission INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(50) NOT NULL, -- Ej: CREATE, READ, UPDATE, DELETE
    descripcion VARCHAR(100)
);

CREATE TABLE Module (
    id_module INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    descripcion VARCHAR(200)
);

CREATE TABLE Form (
    id_form INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    ruta VARCHAR(150),
    descripcion VARCHAR(200)
);

CREATE TABLE FormModule (
    id_form INT,
    id_module INT,
    PRIMARY KEY (id_form, id_module),
    FOREIGN KEY (id_form) REFERENCES Form(id_form),
    FOREIGN KEY (id_module) REFERENCES Module(id_module)
);

CREATE TABLE RolFormPermission (
    id_rol INT,
    id_form INT,
    id_permission INT,
    PRIMARY KEY (id_rol, id_form, id_permission),
    FOREIGN KEY (id_rol) REFERENCES Rol(id_rol),
    FOREIGN KEY (id_form) REFERENCES Form(id_form),
    FOREIGN KEY (id_permission) REFERENCES Permission(id_permission)
);

CREATE TABLE ChangeLog (
    id_log INT PRIMARY KEY AUTO_INCREMENT,
    id_user INT,
    accion VARCHAR(200),
    fecha DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (id_user) REFERENCES User(id_user)
);

-- ==============================
-- 🎌 BLOQUE DE GESTIÓN DE ANIME
-- ==============================

CREATE TABLE Estudio (
    id_estudio INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    pais VARCHAR(50),
    fundacion YEAR
);

CREATE TABLE Anime (
    id_anime INT PRIMARY KEY AUTO_INCREMENT,
    titulo VARCHAR(150) NOT NULL,
    sinopsis TEXT,
    fecha_emision DATE,
    estado VARCHAR(50),
    id_estudio INT,
    FOREIGN KEY (id_estudio) REFERENCES Estudio(id_estudio)
);

CREATE TABLE Genero (
    id_genero INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(50) NOT NULL
);

CREATE TABLE AnimeGenero (
    id_anime INT,
    id_genero INT,
    PRIMARY KEY (id_anime, id_genero),
    FOREIGN KEY (id_anime) REFERENCES Anime(id_anime),
    FOREIGN KEY (id_genero) REFERENCES Genero(id_genero)
);

CREATE TABLE Personaje (
    id_personaje INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    rol VARCHAR(50),
    descripcion TEXT
);

CREATE TABLE AnimePersonaje (
    id_anime INT,
    id_personaje INT,
    papel VARCHAR(50),
    PRIMARY KEY (id_anime, id_personaje),
    FOREIGN KEY (id_anime) REFERENCES Anime(id_anime),
    FOREIGN KEY (id_personaje) REFERENCES Personaje(id_personaje)
);

CREATE TABLE ActorVoz (
    id_actor_voz INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100),
    nacionalidad VARCHAR(50)
);

CREATE TABLE PersonajeVoz (
    id_personaje INT,
    id_actor_voz INT,
    idioma VARCHAR(50),
    PRIMARY KEY (id_personaje, id_actor_voz),
    FOREIGN KEY (id_personaje) REFERENCES Personaje(id_personaje),
    FOREIGN KEY (id_actor_voz) REFERENCES ActorVoz(id_actor_voz)
);

CREATE TABLE UsuarioAnime (
    id_user INT,
    id_anime INT,
    calificacion INT,
    estado_visualizacion VARCHAR(50),
    PRIMARY KEY (id_user, id_anime),
    FOREIGN KEY (id_user) REFERENCES User(id_user),
    FOREIGN KEY (id_anime) REFERENCES Anime(id_anime)
);
