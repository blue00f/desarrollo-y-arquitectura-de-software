create database bd_usuarios;
use bd_usuarios;
create table usuarios(
	id_usuario int identity(1,1) not null,
	nombre nvarchar(30) not null,
	clave nvarchar(30) not null,
	intentosFallidos int default 0,
	bloqueado bit default 0,
	rol nvarchar(20) default 'Usuario',
	constraint pk_usuario primary key (id_usuario),
	constraint u_nombre unique (nombre),
	constraint chk_rol check (rol in ('Usuario','Administrador'))
);

insert into usuarios (nombre,clave,rol) values('juan','juanperez','Administrador');
insert into usuarios(nombre,clave,rol,bloqueado) values ('rodolfo','rodolfo123','Usuario',1);
select * from usuarios;