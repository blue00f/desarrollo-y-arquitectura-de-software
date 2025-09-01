create database bd_empresa;
use bd_empresa;

create table categoria(
	id_categoria int identity(1,1) not null,
	nombre nvarchar(30) not null,
	constraint pk_categoria primary key (id_categoria)
);

create table producto(
	id_producto int identity(1,1) not null,
	nombre nvarchar(50) not null,
	precio decimal not null,
	id_categoria int not null,
	constraint pk_producto primary key(id_producto),
	constraint fk_categoria foreign key (id_categoria) references categoria(id_categoria)
);

create table usuario(
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

create table logs(
	id_log int identity(1,1) not null,
	fecha datetime default getdate(),
	operacion nvarchar(100),
	id_usuario int not null,
	constraint pk_logs primary key(id_log),
	constraint fk_usuario foreign key(id_usuario) references usuario(id_usuario)
);

insert into usuario (nombre,clave,rol) values('juan','juanperez','Administrador');
insert into usuario(nombre,clave,rol,bloqueado) values ('rodolfo','rodolfo123','Usuario',1);
insert into usuario(nombre,clave,rol) values ('manuel','manuel123','Usuario');
select * from logs;
select * from usuario;
select * from producto;