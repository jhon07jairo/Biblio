

USE DB_BIBLIOTECA
go

insert into TIPO_PERSONA(IdTipoPersona, Descripcion) values
(1,'Administrador'),
(2,'Empleado'),
(3,'Lector')

GO
insert into PERSONA(nombre,apellido,correo,clave,IdTipoPersona) values
('Admin','Admin','Admin@gmail.com','123',1)




