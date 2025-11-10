create database bd_empresa_parcial2;
use bd_empresa_parcial2;

create table empleado(
	legajo nvarchar(10) not null,
	nombre nvarchar(30) not null,
	apellido nvarchar(30) not null,
	fecha_ingreso date not null,
	constraint pk_empleado primary key (legajo)
);

select * from empleado;