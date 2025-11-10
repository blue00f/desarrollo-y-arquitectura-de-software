create database bd_equipos_segundoparcial;
use bd_equipos_segundoparcial;

create table equipo(
	EqCodigo char(11) not null,
	EqFechaIngreso date not null,
	EqFechaBaja date not null,
	EqAxoCompra int not null,
	EqEnUso bit not null,
	EqValorCompra decimal(10,2) not null
	constraint pk_equipo primary key (EqCodigo)
);

create table proveedor(
	PrCodigo nvarchar(10) not null,
	PrNombre nvarchar(30) not null,
	PrDireccion nvarchar(50) not null,
	constraint pk_proveedor primary key (PrCodigo)
);

create table equipoxproveedor(
	EqCodigo char(11) not null,
	PrCodigo nvarchar(10) not null,
	NombreTecnico nvarchar(20) not null,
	ApellidoTecnico nvarchar(20) not null,
	constraint pk_equipoxproveedor primary key (EqCodigo,PrCodigo),
	constraint fk_eqcodigo foreign key (EqCodigo) references equipo(EqCodigo),
	constraint fk_prcodigo foreign key (PrCodigo) references proveedor(PrCodigo)
);


select * from equipo;
select * from proveedor;
select * from equipoxproveedor;