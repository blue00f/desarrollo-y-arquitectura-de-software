create database bd_equipos_primerparcial;
use bd_equipos_primerparcial;

create table Equipo(
  EqCodigo nvarchar(11) not null,
  EqFechaIngreso date,
  EqFechaBaja date,
  EqAxoCompra int,
  EqEnUso bit,
  EqValorCompra decimal(18,2),
  proveedor int,
  constraint PK_Equipo primary key (EqCodigo)
);
create table Proveedor(
  PrId nvarchar(50) not null,
  PrNombre nvarchar(50),
  PrDireccion nvarchar(50),
  constraint PK_Proveedor primary key (PrId)
);
create table EquipoProveedor(
  EpEqCodigo nvarchar(11) not null,
  EpPrId nvarchar(50) not null,
  EpNombreTecnico nvarchar(50),
  constraint PK_EquipoProveedor primary key (EpEqCodigo, EpPrId),
  constraint FK_Equipo foreign key (EpEqCodigo) references Equipo(EqCodigo),
  constraint FK_Proveedor foreign key (EpPrId) references Proveedor(PrId)
);