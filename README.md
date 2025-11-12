
## Diagrama entidad-relación (ERD)

```mermaid
erDiagram
	Person {
		int id_person PK
		varchar nombre
		varchar apellido
		varchar correo
	}
	User {
		int id_user PK
		varchar username
		varchar password_hash
		boolean estado
		int id_person FK
	}
	Rol {
		int id_rol PK
		varchar nombre
		varchar descripcion
	}
	RolUser {
		int id_user FK
		int id_rol FK
	}
	Permission {
		int id_permission PK
		varchar nombre
		varchar descripcion
	}
	Module {
		int id_module PK
		varchar nombre
		varchar descripcion
	}
	Form {
		int id_form PK
		varchar nombre
		varchar ruta
		varchar descripcion
	}
	FormModule {
		int id_form FK
		int id_module FK
	}
	RolFormPermission {
		int id_rol FK
		int id_form FK
		int id_permission FK
	}
	ChangeLog {
		int id_log PK
		int id_user FK
		varchar accion
		datetime fecha
	}
	Estudio {
		int id_estudio PK
		varchar nombre
		varchar pais
		year fundacion
	}
	Anime {
		int id_anime PK
		varchar titulo
		text sinopsis
		date fecha_emision
		varchar estado
		int id_estudio FK
	}
	Genero {
		int id_genero PK
		varchar nombre
	}
	AnimeGenero {
		int id_anime FK
		int id_genero FK
	}
	Personaje {
		int id_personaje PK
		varchar nombre
		varchar rol
		text descripcion
	}
	AnimePersonaje {
		int id_anime FK
		int id_personaje FK
		varchar papel
	}
	ActorVoz {
		int id_actor_voz PK
		varchar nombre
		varchar nacionalidad
	}
	PersonajeVoz {
		int id_personaje FK
		int id_actor_voz FK
		varchar idioma
	}
	UsuarioAnime {
		int id_user FK
		int id_anime FK
		int calificacion
		varchar estado_visualizacion
	}

	User ||--o{ Person : "id_person"
	User ||--o{ RolUser : "id_user"
	Rol ||--o{ RolUser : "id_rol"
	Rol ||--o{ RolFormPermission : "id_rol"
	Form ||--o{ FormModule : "id_form"
	Module ||--o{ FormModule : "id_module"
	Form ||--o{ RolFormPermission : "id_form"
	Permission ||--o{ RolFormPermission : "id_permission"
	Anime ||--o{ AnimeGenero : "id_anime"
	Genero ||--o{ AnimeGenero : "id_genero"
	Anime ||--o{ AnimePersonaje : "id_anime"
	Personaje ||--o{ AnimePersonaje : "id_personaje"
	Personaje ||--o{ PersonajeVoz : "id_personaje"
	ActorVoz ||--o{ PersonajeVoz : "id_actor_voz"
	Anime ||--o{ UsuarioAnime : "id_anime"
	User ||--o{ UsuarioAnime : "id_user"
	Estudio ||--o{ Anime : "id_estudio"
	User ||--o{ ChangeLog : "id_user"
```

## Esquema de base de datos (DBML)

A continuación está el esquema proporcionado (formato DBML):

```dbml
Table Person {
	 # Esquema de base de datos (DBML)

	A continuación está el esquema proporcionado (formato DBML):

	```dbml
	Table Person {
	  id_person int [pk]
	  nombre varchar
	  apellido varchar
	  correo varchar
	}

	Table User {
	  id_user int [pk]
	  username varchar
	  password_hash varchar
	 # Esquema de base de datos (DBML)

	A continuación está el esquema proporcionado (formato DBML):

	```dbml
	Table Person {
	  id_person int [pk]
	  nombre varchar
	  apellido varchar
	  correo varchar
	}

	Table User {
	  id_user int [pk]
	  username varchar
	  password_hash varchar
	  estado boolean
	  id_person int [ref: > Person.id_person]
	}

	Table Rol {
	  id_rol int [pk]
	  nombre varchar
	  descripcion varchar
	}

	Table RolUser {
	  id_user int [ref: > User.id_user]
	  id_rol int [ref: > Rol.id_rol]
	  primary key (id_user, id_rol)
	}

	Table Permission {
	  id_permission int [pk]
	  nombre varchar
	  descripcion varchar
	}

	Table Module {
	  id_module int [pk]
	  nombre varchar
	  descripcion varchar
	}

	Table Form {
	  id_form int [pk]
	  nombre varchar
	  ruta varchar
	  descripcion varchar
	}

	Table FormModule {
	  id_form int [ref: > Form.id_form]
	  id_module int [ref: > Module.id_module]
	  primary key (id_form, id_module)
	}

	Table RolFormPermission {
	  id_rol int [ref: > Rol.id_rol]
	  id_form int [ref: > Form.id_form]
	  id_permission int [ref: > Permission.id_permission]
	  primary key (id_rol, id_form, id_permission)
	}

	Table ChangeLog {
	  id_log int [pk]
	  id_user int [ref: > User.id_user]
	  accion varchar
	  fecha datetime
	}

	Table Estudio {
	  id_estudio int [pk]
	  nombre varchar
	  pais varchar
	  fundacion year
	}

	Table Anime {
	  id_anime int [pk]
	  titulo varchar
	  sinopsis text
	  fecha_emision date
	  estado varchar
	  id_estudio int [ref: > Estudio.id_estudio]
	}

	Table Genero {
	  id_genero int [pk]
	  nombre varchar
	}

	Table AnimeGenero {
	  id_anime int [ref: > Anime.id_anime]
	  id_genero int [ref: > Genero.id_genero]
	  primary key (id_anime, id_genero)
	}

	Table Personaje {
	  id_personaje int [pk]
	  nombre varchar
	  rol varchar
	  descripcion text
	}

	Table AnimePersonaje {
	  id_anime int [ref: > Anime.id_anime]
	  id_personaje int [ref: > Personaje.id_personaje]
	  papel varchar
	  primary key (id_anime, id_personaje)
	}

	Table ActorVoz {
	  id_actor_voz int [pk]
	  nombre varchar
	  nacionalidad varchar
	}

	Table PersonajeVoz {
	  id_personaje int [ref: > Personaje.id_personaje]
	  id_actor_voz int [ref: > ActorVoz.id_actor_voz]
	  idioma varchar
	  primary key (id_personaje, id_actor_voz)
	}

	Table UsuarioAnime {
	  id_user int [ref: > User.id_user]
	  id_anime int [ref: > Anime.id_anime]
	  calificacion int
	  estado_visualizacion varchar
	  primary key (id_user, id_anime)
	}
	```

