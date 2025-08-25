-- Ejercicio 3
create database bd_juegos;
use bd_juegos;

create table bando(
	cod_bando int identity(1,1) not null,
	nombre nvarchar(30) not null,
	constraint pk_bando primary key (cod_bando),
);

create table jugador(
	cod_jugador int identity(1,1) not null,
	nombre nvarchar(30) not null,
	apellido nvarchar(30) not null,
	cod_bando int not null,
	constraint pk_jugador primary key (cod_jugador),
	constraint fk_cod_bando foreign key (cod_bando) references bando(cod_bando),
);

create table juego(
	cod_juego int identity(1,1) not null,
	nombre nvarchar(30) not null,
	descripcion nvarchar(100),
	cod_jugador int not null,
	constraint pk_juego primary key (cod_juego),
	constraint fk_jugador foreign key (cod_jugador) references jugador(cod_jugador), 
);

create table juego_jugadores(
	cod_juego int not null,
	cod_jugadores int not null,
	constraint pk_juego_jugadores primary key (cod_juego, cod_jugadores),
	constraint fk_juego foreign key (cod_juego) references juego(cod_juego),
	constraint fk_jugadores foreign key (cod_jugadores) references jugador(cod_jugador),
);

-- Ejercicio 4

insert into bando(nombre) values
('Alianza'),
('Rebeldes'),
('Imperio');

insert into jugador(nombre, apellido, cod_bando) values
('Ignacio','Rodriguez',1),
('Juan','Pérez',1),
('Federico','Peralta',2),
('Adolfo','Fernández',3),
('Julian','Rodriguez',2),
('Manuela', 'Gonzalez',1),
('Nicole','Díaz',3),
('Sandro','Sánchez',2);

insert into juego(nombre, descripcion, cod_jugador) values
('Batalla estelar','Juego de estrategia espacial',1),
('Defensa del reino','Juego de defensa medieval',2),
('Carrera loca','Carreras de vehículos futuristas',3),
('Aventura mágica','Exploración de mazmorras mágicas',4);

insert into juego_jugadores(cod_juego, cod_jugadores) values
(1,1),
(1,2),
(1,3),
(2,2),
(2,5),
(2,6),
(3,3),
(3,4),
(3,7),
(4,4),
(4,8);

-- Realizar la consulta de traer todos los datos de la tabla Juego, otra de la tabla Jugadores y Bando.
select * from juego;
select * from jugador;
select * from bando;

-- Realizar una consulta que traiga solos los jugadores de cada juego
select jug.nombre, jug.apellido, jue.nombre as [juego] from juego_jugadores jj
join juego jue on jj.cod_juego = jue.cod_juego
join jugador jug on jj.cod_jugadores = jug.cod_jugador
order by jue.nombre;

-- Realizar una consulta que traiga solo los registros de un determinado juego y bando
select jug.nombre, jug.apellido, jue.nombre as [juego] from jugador jug
join juego jue on jue.cod_jugador = jug.cod_jugador
join bando b on b.cod_bando = jug.cod_bando
where jue.nombre = 'Carrera loca' and b.nombre = 'Rebeldes';

-- Sacar la cuenta del total de jugadores, y bando de un determinado juego
select jue.nombre as juego, b.nombre as bando, count(jug.cod_jugador) as total_jugadores from juego_jugadores jj
join juego jue on jj.cod_juego = jue.cod_juego
join jugador jug on jj.cod_jugadores = jug.cod_jugador
join bando b on jug.cod_bando = b.cod_bando
where jue.cod_juego = 4
group by jue.nombre, b.nombre;

-- Borrar los registros de Id_juego=2
delete from juego_jugadores where cod_juego = 2;
delete from juego where cod_juego = 2;

-- Cambiar el nombre del bando código 3.
update bando set nombre = 'Huracan' where cod_bando = 3;

-- Inserte un nuevo jugador
insert into jugador(nombre,apellido,cod_bando) values ('Lionel','Messi',3);

-- Inserte un nuevo Juego
insert into juego(nombre,descripcion,cod_jugador) values ('La mancha','',9);

-- Modifique el nombre de un Juego
update juego set nombre = 'Carrera' where nombre = 'Carrera loca';

-- Modifique el Nombre de uno de los bandos
update bando set nombre = 'BOCA' where nombre = 'Alianza';

-- Saque el promedio de los jugadores por juego
select avg(jugadores_por_juego) as promedio_jugadores_por_juego
from (
    select cod_juego, count(cod_jugadores) as jugadores_por_juego
    from juego_jugadores
    group by cod_juego
) as sub;

-- Muestre un listado de jugadores agrupados por juego en forma ascendente.
select jug.nombre, jug.apellido, jue.nombre from juego_jugadores jj
join juego jue on jue.cod_juego = jj.cod_juego
join jugador jug on jug.cod_jugador = jj.cod_jugadores
order by jue.nombre;
