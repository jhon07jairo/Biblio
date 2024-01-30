
create database DB_BIBLIOTECA

GO

USE DB_BIBLIOTECA


go


CREATE TABLE  AUTOR(
IdAutor int primary key identity,
Descripcion varchar(50),
FechaCreacion datetime default getdate()
)

go

CREATE TABLE LIBRO(
IdLibro int primary key identity,
Titulo varchar(100),
IdAutor int references AUTOR(IdAutor),
FechaCreacion datetime default getdate()
)

GO

CREATE TABLE TIPO_PERSONA(
IdTipoPersona  int primary key,
Descripcion varchar(50),
Estado bit default 1,
FechaCreacion datetime default getdate()
)

GO

CREATE TABLE PERSONA(
IdPersona int primary key identity,
Nombre varchar(50),
Apellido varchar(50),
Correo varchar(50),
Clave varchar(50),
Codigo varchar(50),
IdTipoPersona int references TIPO_PERSONA(IdTipoPersona),
Estado bit default 1,
FechaCreacion datetime default getdate()
)
