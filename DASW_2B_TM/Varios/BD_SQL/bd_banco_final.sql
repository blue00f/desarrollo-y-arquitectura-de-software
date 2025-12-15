create database bd_banco;
use bd_banco;

create table cuentacorriente(
	codigo char(6) not null,
	saldo decimal(10,2) not null,
	descubierto decimal(10,2) not null,
	constraint pk_cuentacorriente primary key(codigo)
);
create table cajaahorro(
	codigo char(6) not null,
	saldo decimal(10,2) not null,
	constraint pk_cajaahorro primary key(codigo)
);
create table titular(
	dni char(8) not null,
	nombre nvarchar(50) not null,
	apellido nvarchar(50) not null,
	constraint pk_titular primary key(dni)
);
create table cuentacorrientextitular(
	dni char(8) not null,
	codigo char(6) not null,
	constraint pk_cuentacorrientextitular primary key(dni,codigo),
	constraint fk_titular foreign key(dni) references titular(dni),
	constraint fk_cuentacorriente foreign key(codigo) references cuentacorriente(codigo)
);

create table cajaahorroxtitular(
	dni char(8) not null,
	codigo char(6) not null,
	constraint pk_cajaahorroxtitular primary key(dni,codigo),
	constraint fk_titularcuenta foreign key(dni) references titular(dni),
	constraint fk_cajaahorro foreign key(codigo) references cajaahorro(codigo)
);

select * from cuentacorriente;
select * from cajaahorro;
select * from titular;
select * from cajaahorroxtitular;
select * from cuentacorrientextitular;