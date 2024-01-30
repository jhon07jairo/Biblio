

USE DB_BIBLIOTECA

GO


--PROCEDIMIENTO PARA GUARDAR AUTOR
CREATE PROC sp_RegistrarAutor(
@Descripcion varchar(50),
@Resultado bit output
)as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM AUTOR WHERE Descripcion = @Descripcion)

		insert into AUTOR(Descripcion) values (
		@Descripcion
		)
	ELSE
		SET @Resultado = 0
	
end


go

--PROCEDIMIENTO PARA MODIFICAR AUTOR
create procedure sp_ModificarAutor(
@IdAutor int,
@Descripcion varchar(60),
@Resultado bit output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM AUTOR WHERE Descripcion =@Descripcion and IdAutor != @IdAutor)
		
		update AUTOR set 
		Descripcion = @Descripcion		
		where IdAutor = @IdAutor
	ELSE
		SET @Resultado = 0

end


go

create proc sp_registrarLibro(
@Titulo varchar(100),
@IdAutor int,
@Resultado int output
)
as
begin
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM LIBRO WHERE Titulo = @Titulo)
	begin
		insert into LIBRO(Titulo,IdAutor) values (
		@Titulo,@IdAutor)

		SET @Resultado = scope_identity()
	end
end

go

create proc sp_modificarLibro(
@IdLibro int,
@Titulo varchar(100),
@IdAutor int,
@Resultado bit output
)
as
begin
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM LIBRO WHERE Titulo = @Titulo and IdLibro != @IdLibro)
	begin

		update LIBRO set 
		Titulo = @Titulo,
		IdAutor = @IdAutor
		where IdLibro = @IdLibro

		SET @Resultado = 1
	end
end





