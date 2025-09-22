-- DDL_BD
create database bd_empleados_ej_transaction;
use bd_empleados_ej_transaction;

create table empleado(
	id_empleado int not null,
	nombre nvarchar(50),
	sueldo decimal(18,0),
	constraint pk_empleado primary key(id_empleado)
);

-- stored procedure
go
create proc sp_guardar_empleado(
	@id_empleado int,
	@nombre nvarchar(50),
	@sueldo decimal(18,0),
	@message nvarchar(500) output
)
as
begin try
	insert into empleado(id_empleado,nombre,sueldo)
	values(@id_empleado,@nombre,@sueldo)
	set @message='Registro guardado'
end try
begin catch
	set @message=ERROR_MESSAGE();
	throw
end catch
go

-- DML_BD
select * from empleado;