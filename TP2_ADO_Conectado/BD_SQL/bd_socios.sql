-- Ejercicio 1
create database bd_socios;
use bd_socios;

create table pais(
	id_pais int identity(1,1) not null,
	nombre nvarchar(30) not null,
	constraint pk_pais primary key (id_pais),
);

create table provincia(
	id_provincia int identity(1,1) not null,
	nombre nvarchar(30) not null,
	constraint pk_provincia primary key (id_provincia)
);

create table socio(
	id_socio int identity(1,1) not null,
	nombre nvarchar(30) not null,
	apellido nvarchar(30) not null,
	email nvarchar(50),
	id_pais int not null,
	id_provincia int not null,
	constraint pk_socio primary key (id_socio),
	constraint fk_pais foreign key (id_pais) references pais(id_pais),
	constraint fk_provincia foreign key (id_provincia) references provincia(id_provincia),
);

-- Ejercicio 2
insert into pais(nombre) values ('Argentina'), ('Uruguay'), ('Nigeria');
insert into provincia(nombre) values ('Provincia de Buenos Aires'), ('CABA'), ('Córdoba'), ('Montevideo');
insert into socio(nombre, apellido, email, id_pais, id_provincia) values
('Ignacio','Rodriguez','ignarod@gmail.com',1,1),
('Juan','Pérez','juanp@gmail.com',1,2),
('Federico','Peralta','fedeperalta@gmail.com',2,4),
('Adolfo','Fernández','adolfer@gmail.com',1,3),
('Julian','Rodriguez','julian@gmail.com',1,3),
('Manuela','Gonzalez','manuela@hotmail.com',2,4),
('Nicole','Díaz','nicole@hotmail.com',4,1),
('Sandro','Sánchez','ignarod@hotmail.com',4,2),
('Pablo','Pérez','pablin@gmail.com',4,1);

-- Realizar la consulta de traer todos los datos de la tabla socios, otra de la tabla país y provincia
select * from pais;
select * from provincia;
select * from socio;

-- Realizar una consulta que traiga solos los registros Id_socio, nombre, email de los socios de la provincia de Bs AS
select id_socio, nombre, email from socio
where id_provincia = (select id_provincia from provincia where nombre = 'Provincia de Buenos Aires');

-- Realizar una consulta que traiga solos los registros Id_socio, nombre, email de los socios llamados Pablo
select id_socio, nombre, email from socio
where nombre = 'Pablo';

-- Sacar la cuenta del total de socios, otra para provincias
select count(id_socio) as [Total de socios] from socio;
select count(id_provincia) as [Total de provincias] from provincia;

-- Borrar los registros de Id_Socio=2
delete from socio where id_socio = 2;

-- Cambiar el email del socio llamado X
update socio set email = 'nicoleeee@gmail.com' where nombre = 'Nicole';

-- Inserte un nuevo país
insert into pais(nombre) values ('Chilee');

-- Inserte un nuevo socio
insert into socio(nombre, apellido, email, id_pais, id_provincia)
values ('Antonio','Hernández','antonio@gmail.com',4,2);

-- Modifique el nombre de un Pais
update pais set nombre = 'Chile' where id_pais = 3;

-- Modifique el país de los socios de Nigeria
update socio set id_pais = (select id_pais from pais where nombre = 'Argentina')
where id_pais = (select id_pais from pais where nombre = 'Nigeria'); 

-- Saque el promedio de los socios de Argentina
select cast(count(*) as FLOAT) / (select count(*) from socio) as [Promedio de socios argentinos] from socio
where id_pais = (select id_pais from pais where nombre = 'Argentina');

-- Muestre un listado de socios agrupados por país en forma ascendente
select p.nombre, count(*) as [Cantidad de socios] from socio s
join pais p on s.id_pais = p.id_pais
group by p.nombre
order by p.nombre asc;
