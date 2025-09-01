create database DASW_2025_2B_TM;
use DASW_2025_2B_TM;

create table alumno(
	legajo int not null,
	nombre nvarchar(50) not null,
	apellido nvarchar(50) not null,
	ingreso date not null,
	activo bit not null,
	constraint pk_alumno primary key (legajo),
);