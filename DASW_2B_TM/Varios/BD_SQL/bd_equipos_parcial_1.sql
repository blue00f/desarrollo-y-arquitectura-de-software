create database bd_equipos;
use bd_equipos;
create table equipos(
	codigo char(9) not null,
	fechaIngreso datetime not null,
	fechaBaja datetime not null,
	anioCompra int not null,
	enUso bit not null,
	valorCompra decimal(12,2) not null,
	constraint pk_equipo primary key(codigo)
);

select * from equipos;