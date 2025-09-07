create database bd_transito;
use bd_transito;

create table propietarios(
	id_propietario int identity(1,1) not null,
	nombre nvarchar(30) not null,
	apellido nvarchar(30) not null,
	dni char(8) not null,
	domicilio nvarchar(100) not null,
	estado bit not null default 1,
	constraint pk_propietario primary key (id_propietario),
	constraint uq_dni unique (dni)
);

create table vehiculos(
	id_vehiculo int identity(1,1) not null,
	propietario int not null,
	patente char(7) not null,
	marca nvarchar(30) not null,
	modelo nvarchar(50) not null,
	anio int not null,
	estado bit not null default 1,
	constraint pk_vehiculo primary key (id_vehiculo),
	constraint fk_propietario foreign key (propietario) references propietarios(id_propietario)
);

create table multas(
	id_multa int identity(1,1) not null,
	vehiculo int not null,
	fecha_hora datetime not null,
	monto decimal(10,2) not null,
	situacion nvarchar(30) not null,
	estado bit not null default 1,
	constraint pk_multa primary key (id_multa),
	constraint fk_vehiculo foreign key (vehiculo) references vehiculos(id_vehiculo)
);


--
-- STORED PROCEDURES
--


-- Stored procedures - Propietarios
create procedure sp_alta_propietario
	@nombre nvarchar(30),
	@apellido nvarchar(30),
	@dni char(8),
	@domicilio nvarchar(100)
as
begin
	insert into propietarios(nombre,apellido,dni,domicilio)
	values(@nombre,@apellido,@dni,@domicilio)
end;

create procedure sp_baja_propietario
	@id_propietario int
as
begin
	update propietarios set estado=0 where id_propietario=@id_propietario
end;

create procedure sp_modificar_propietario
	@id_propietario int,
	@nombre nvarchar(30),
	@apellido nvarchar(30),
	@domicilio nvarchar(100)
as
begin
	update propietarios
	set nombre=@nombre,apellido=@apellido,domicilio=@domicilio
	where id_propietario=@id_propietario
end;

create procedure sp_consultar_propietarios
as
begin
	select id_propietario, nombre, apellido, dni, domicilio from propietarios where estado=1
end;

create procedure sp_consultar_dni
	@dni char(8)
as
begin
	select count(*) from propietarios where dni=@dni
end;

-- Stored procedures - Vehiculos
create procedure sp_alta_vehiculo
	@propietario int,
	@patente char(7),
	@marca nvarchar(30),
	@modelo nvarchar(50),
	@anio int
as
begin
	insert into vehiculos(propietario,patente,marca,modelo,anio)
	values(@propietario,@patente,@marca,@modelo,@anio)
end;

create procedure sp_baja_vehiculo
	@id_vehiculo int
as
begin
	update vehiculos set estado=0 where id_vehiculo=@id_vehiculo
end;

create procedure sp_modificar_vehiculo
	@id_vehiculo int,
	@patente char(7),
	@marca nvarchar(30),
	@modelo nvarchar(50),
	@anio int
as
begin
	update vehiculos
	set patente=@patente,marca=@marca,modelo=@modelo,anio=@anio
	where id_vehiculo=@id_vehiculo
end;

create procedure sp_consultar_vehiculos
as
begin
	select id_vehiculo, propietario, patente, marca, modelo, anio from vehiculos where estado=1
end;

-- Stored procedures - Multas
create procedure sp_alta_multa
	@vehiculo int,
	@fecha_hora datetime,
	@monto decimal(10,2),
	@situacion nvarchar(30)
as
begin
	insert into multas(vehiculo,fecha_hora,monto,situacion)
	values(@vehiculo,@fecha_hora,@monto,@situacion)
end;

create procedure sp_baja_multa
	@id_multa int
as
begin
	update multas set estado=0 where id_multa=@id_multa
end;

create procedure sp_modificar_multa
	@id_multa int,
	@monto decimal(10,2),
	@situacion nvarchar(30)
as
begin
	update multas set monto=@monto,situacion=@situacion
	where id_multa=@id_multa
end;

create procedure sp_consultar_multas
as
begin
	select id_multa, vehiculo, fecha_hora, monto, situacion from multas where estado=1
end;

create procedure sp_consultar_vehiculo_propietario
as
begin
	select v.id_vehiculo, v.marca, v.modelo, p.nombre, p.apellido from vehiculos v
	join propietarios p on p.id_propietario=v.propietario
	where v.estado=1 and p.estado=1
end;