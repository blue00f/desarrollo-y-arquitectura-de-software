create database bd_autos;
use bd_autos;

create table autos(
	patente char(8) not null,
	fechaIngreso datetime not null,
	fechaBaja datetime not null,
	anio int not null,
	enUso bit not null,
	valor decimal(12,2) not null,
	constraint pk_auto primary key(patente)
);

select * from autos;