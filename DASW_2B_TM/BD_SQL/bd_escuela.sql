--
-- DDL
--

create database bd_escuela;
use bd_escuela;

create table alumnos(
	legajo int not null,
	nombre nvarchar(30) not null,
	apellido nvarchar(30) not null,
	constraint pk_alumno primary key (legajo)
);

create table materias(
	id_materia int not null,
	descripcion nvarchar(100),
	constraint pk_materia primary key(id_materia)
);

create table alumno_materia_cursando(
	legajo int not null,
	materia int not null,
	constraint pk_alumno_materia_cursando primary key(legajo,materia),
	constraint fk_alumno_cursando foreign key (legajo) references alumnos(legajo),
	constraint fk_materia_cursando foreign key (materia) references materias(id_materia)
);

create table alumno_materia_cursada(
	legajo int not null,
	materia int not null,
	nota decimal(4,2) not null,
	constraint pk_alumno_materia_cursada primary key(legajo,materia),
	constraint fk_alumno_cursada foreign key (legajo) references alumnos(legajo),
	constraint fk_materia_cursada foreign key (materia) references materias(id_materia)
);

--
-- DML
--

insert into alumnos(nombre,apellido)
values ('luis','suarez'),('diego','maradona'),('lionel','messi'),('sergio','busquets');

insert into materias(id_materia,descripcion) values
(1,'Problemática del Mundo Actual'),(2,'Cálculo Infinitesimal I'),(3,'Sistemas Operativos'),
(4,'POO'),(5,'Desarrollo y Arquitectura de Software'),(6,'Física I'),(7,'Análisis y Diseño de Sistemas I'),
(8,'Ingeniería de Requerimientos');

insert into alumno_materia_cursando(legajo,materia) values
(1,1),(1,2),(1,3),(2,2),(2,3),(2,4),(3,1),(4,6),(4,7);

insert into alumno_materia_cursada(legajo,materia,nota) values
(1,5,8),(1,6,4),(2,2,10),(2,1,9),(3,2,4),(4,5,8);

-- Las notas que tuvo el alumno que están desaprobados
insert into alumno_materia_cursada(legajo,materia,nota) values
(1,4,2),(2,5,1);