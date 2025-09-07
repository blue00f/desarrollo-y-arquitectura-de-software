create database bd_biblioteca
use bd_biblioteca;

create table alumnos(
	id_alumno int identity(1,1) not null,
	nombre nvarchar(30) not null,
	apellido nvarchar(30) not null,
	dni char(8) not null,
	correo nvarchar(50) not null,
	fecha_nacimiento date,
	constraint pk_alumno primary key(id_alumno),
	constraint uq_dni unique (dni)
);

create table obras(
	id_obra int identity(1,1) not null,
	titulo nvarchar(100) not null,
	autor nvarchar(30) not null,
	fecha_lanzamiento date,
	constraint pk_obra primary key(id_obra)
);

create table ejemplares(
	id_ejemplar int identity(1,1) not null,
	obra int not null,
	num_inventario int not null,
	precio decimal(9,2) not null,
	constraint pk_ejemplar primary key(id_ejemplar),
	constraint fk_obra foreign key(obra) references obras(id_obra)
);

create table prestamos(
	id_prestamo int identity(1,1) not null,
	alumno int not null,
	ejemplar int not null,
	fecha_prestamo date not null,
	fecha_devolucion date not null,
	constraint pk_prestamo primary key(id_prestamo),
	constraint fk_alumno foreign key(alumno) references alumnos(id_alumno),
	constraint fk_ejemplar foreign key(ejemplar) references ejemplares(id_ejemplar)
);

-- Stored procedures - Alumnos
create procedure sp_alta_alumno
	@nombre nvarchar(30),
	@apellido nvarchar(30),
	@dni char(8),
	@correo nvarchar(50),
	@fecha_nacimiento date = null
as
begin
	insert into alumnos(nombre,apellido,dni,correo,fecha_nacimiento)
	values (@nombre,@apellido,@dni,@correo,@fecha_nacimiento)
end;

create procedure sp_baja_alumno
	@id_alumno int
as
begin
	delete from alumnos where id_alumno=@id_alumno
end;

create procedure sp_modificar_alumno
	@id_alumno int,
	@nombre nvarchar(30),
	@apellido nvarchar(30),
	@correo nvarchar(50),
	@fecha_nacimiento date = null
as
begin
	update alumnos set nombre=@nombre,apellido=@apellido,correo=@correo,fecha_nacimiento=@fecha_nacimiento
	where id_alumno=@id_alumno
end;

create procedure sp_consultar_alumnos
as
begin
	select * from alumnos
end;

exec sp_alta_alumno "bruno","roca","12123123","bruno@gmail.com","2005-04-20";
exec sp_alta_alumno "juan","perez","32333222","juanp@gmail.com","2005-02-10";
exec sp_baja_alumno 19;
exec sp_modificar_alumno 20,"armesto","gutierrez","armesto@gmail.com","2002-02-21";
exec sp_consultar_alumnos;

-- Stored procedures - Obras
create procedure sp_alta_obra
	@titulo nvarchar(100),
	@autor nvarchar(30),
	@fecha_lanzamiento date = null
as
begin
	insert into obras(titulo,autor,fecha_lanzamiento)
	values(@titulo,@autor,@fecha_lanzamiento)
end;

create procedure sp_baja_obra
	@id_obra int
as
begin
	delete from obras where id_obra=@id_obra
end;

create procedure sp_modificar_obra
	@id_obra int,
	@titulo nvarchar(100),
	@autor nvarchar(30),
	@fecha_lanzamiento date = null
as
begin
	update obras set titulo=@titulo,autor=@autor,fecha_lanzamiento=@fecha_lanzamiento
	where id_obra=@id_obra
end;

create procedure sp_consultar_obras
as
begin
	select * from obras
end;

exec sp_alta_obra "aventuras de amor","steven spielberg","2001-12-29";
exec sp_alta_obra "comedia romantica de pablo","macgiver";
exec sp_baja_obra 2;
exec sp_modificar_obra 1,"locas aventuras de amor","steven spielberg","2001-12-29";
exec sp_consultar_obras;

-- Stored procedures - Ejemplares
create procedure sp_alta_ejemplar
	@obra int,
	@num_inventario int,
	@precio decimal(9,2)
as
begin
	insert into ejemplares(obra,num_inventario,precio)
	values(@obra,@num_inventario,@precio)
end;

create procedure sp_baja_ejemplar
	@id_ejemplar int
as
begin
	delete from ejemplares where id_ejemplar=@id_ejemplar
end;

create procedure sp_modificar_ejemplar
	@id_ejemplar int,
	@obra int,
	@num_inventario int,
	@precio decimal(9,2)
as
begin
	update ejemplares set obra=@obra,num_inventario=@num_inventario,precio=@precio
	where id_ejemplar=@id_ejemplar
end;

create procedure sp_consultar_ejemplares
as
begin
	select * from ejemplares
end;

exec sp_alta_ejemplar 1,3,500;
exec sp_alta_ejemplar 1,2,500;
exec sp_baja_ejemplar 2;
exec sp_modificar_ejemplar 1,1,4,500;
exec sp_consultar_ejemplares;

-- Stored procedures - Prestamos
create procedure sp_alta_prestamo
	@alumno int,
	@ejemplar int,
	@fecha_prestamo date
as
begin
	insert into prestamos(alumno,ejemplar,fecha_prestamo,fecha_devolucion)
	values(@alumno,@ejemplar,@fecha_prestamo,dateadd(day,7,@fecha_prestamo))
end;

create procedure sp_baja_prestamo
	@id_prestamo int
as
begin
	delete from prestamos where id_prestamo=@id_prestamo
end;

create procedure sp_modificar_prestamo
	@id_prestamo int,
	@alumno int,
	@ejemplar int,
	@fecha_prestamo date
as
begin
	update prestamos set alumno=@alumno,ejemplar=@ejemplar,fecha_prestamo=@fecha_prestamo,fecha_devolucion=dateadd(day,7,@fecha_prestamo)
	where id_prestamo=@id_prestamo
end;

create procedure sp_consultar_prestamos
as
begin
	select * from prestamos
end;

exec sp_alta_prestamo 18,1,"2025-09-04";
exec sp_baja_prestamo 1;
exec sp_modificar_prestamo 2,18,1,"2025-10-21";
exec sp_consultar_prestamos;

-- Validar DNI repetido
create procedure sp_consultar_dni
	@dni int
as
begin
	select count(*) from alumnos where dni=@dni
end;

-- Consulta de ejemplar y obra usando JOIN
create procedure sp_consultar_ejemplar_obra
as
begin
	select e.id_ejemplar, o.titulo, o.autor, e.precio from ejemplares e
	join obras o on e.obra = o.id_obra
end;

exec sp_consultar_ejemplar_obra;