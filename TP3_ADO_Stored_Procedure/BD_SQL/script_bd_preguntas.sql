go
create database bd_preguntas;
go
go
use bd_preguntas;
go
go
create table jugadores(
	id_jugador int identity(1,1) not null,
	nombre nvarchar(30) not null,
	constraint pk_jugador primary key(id_jugador)
);
go
go
create table categorias(
	id_categoria int identity(1,1) not null,
	nombre nvarchar(30) not null,
	constraint pk_categoria primary key(id_categoria)
);
go
go
create table preguntas(
	id_pregunta int identity(1,1) not null,
	texto nvarchar(100) not null,
	nivel int not null,
	valor int not null,
	categoria int not null,
	constraint pk_pregunta primary key(id_pregunta),
	constraint fk_categoria foreign key(categoria) references categorias(id_categoria)
);
go
go
create table opciones(
	id_opcion int identity(1,1) not null,
	texto nvarchar(100) not null,
	es_correcta bit not null,
	pregunta int not null,
	constraint pk_opcion primary key(id_opcion),
	constraint fk_pregunta_opciones foreign key(pregunta) references preguntas(id_pregunta)
);
go
go
create table respuestas(
	id_respuesta int identity(1,1) not null,
	puntos int not null,
	jugador int not null,
	pregunta int not null,
	opcion int not null,
	constraint pk_respuesta primary key(id_respuesta),
	constraint fk_jugador foreign key(jugador) references jugadores(id_jugador),
	constraint fk_pregunta_respuestas foreign key(pregunta) references preguntas(id_pregunta),
	constraint fk_opcion foreign key(opcion) references opciones(id_opcion)
);
go

--
-- STORED PROCEDURES
--

-- Jugadores
go
create procedure sp_alta_jugador
	@nombre nvarchar(30)
as
begin
	insert into jugadores(nombre) values(@nombre)
end;
go

go
create procedure sp_baja_jugador
	@id_jugador int
as
begin
	delete from jugadores where id_jugador=@id_jugador
end;
go

go
create procedure sp_modificar_jugador
	@id_jugador int,
	@nombre nvarchar(30)
as
begin
	update jugadores set nombre=@nombre where id_jugador=@id_jugador
end;
go

go
create procedure sp_consultar_jugadores
as
begin
	select * from jugadores
end;
go

-- Categorias
go
create procedure sp_alta_categoria
	@nombre nvarchar(30)
as
begin
	insert into categorias(nombre) values(@nombre)
end;
go

go
create procedure sp_baja_categoria
	@id_categoria int
as
begin
	delete from categorias where id_categoria=@id_categoria
end;
go

go
create procedure sp_modificar_categoria
	@id_categoria int,
	@nombre nvarchar(30)
as
begin
	update categorias set nombre=@nombre where id_categoria=@id_categoria
end;
go

go
create procedure sp_consultar_categorias
as
begin
	select * from categorias
end;
go

-- Preguntas
go
create procedure sp_alta_pregunta
	@texto nvarchar(100),
	@nivel int,
	@valor int,
	@categoria int
as
begin
	insert into preguntas(texto,nivel,valor,categoria)
	values(@texto,@nivel,@valor,@categoria)
end;
go

go
create procedure sp_baja_pregunta
	@id_pregunta int
as
begin
	delete from preguntas where id_pregunta=@id_pregunta
end;
go

go
create procedure sp_modificar_pregunta
	@id_pregunta int,
	@texto nvarchar(100),
	@nivel int,
	@valor int,
	@categoria int
as
begin
	update preguntas
	set texto=@texto,nivel=@nivel,valor=@valor,categoria=@categoria
	where id_pregunta=@id_pregunta
end;
go

go
create procedure sp_consultar_preguntas
as
begin
	select * from preguntas
end;
go

-- Opciones
go
create procedure sp_alta_opcion
	@texto nvarchar(100),
	@es_correcta bit,
	@pregunta int
as
begin
	insert into opciones(texto,es_correcta,pregunta)
	values(@texto,@es_correcta,@pregunta)
end;
go

go
create procedure sp_baja_opcion
	@id_opcion int
as
begin
	delete from opciones where id_opcion=@id_opcion
end;
go

go
create procedure sp_modificar_opcion
	@id_opcion int,
	@texto nvarchar(100),
	@es_correcta bit
as
begin
	update opciones
	set texto=@texto,es_correcta=@es_correcta
	where id_opcion=@id_opcion
end;
go

go
create procedure sp_consultar_opciones
	@pregunta int
as
begin
	select * from opciones where pregunta = @pregunta
end;
go

-- Respuestas
go
create procedure sp_alta_respuesta
    @jugador int,
    @pregunta int,
    @opcion int
as
begin
    declare @es_correcta bit;
    declare @valor int;
    declare @puntos int;
    select @es_correcta = es_correcta from opciones where id_opcion = @opcion;
    select @valor = valor from preguntas where id_pregunta = @pregunta;
    if @es_correcta = 1 set @puntos = @valor;
    else set @puntos = 0;
    insert into respuestas(puntos,jugador,pregunta,opcion)
    values (@puntos,@jugador,@pregunta,@opcion);
end;
go

go
create procedure sp_consultar_respuestas
	@jugador int
as
begin
    select r.id_respuesta, j.nombre as jugador, p.texto as pregunta, o.texto as opcion, r.puntos from respuestas r
    join jugadores j on r.jugador = j.id_jugador
    join preguntas p on r.pregunta = p.id_pregunta
    join opciones o on r.opcion = o.id_opcion
	where j.id_jugador=@jugador
end;
go

-- SP de servicio
go
create procedure sp_recuperar_id_por_nombre_categoria
	@nombre nvarchar(30)
as
begin
	select id_categoria from categorias
	where nombre = @nombre
end;
go

go
create procedure sp_recuperar_id_por_nombre_pregunta
	@texto nvarchar(100)
as
begin
	select id_pregunta from preguntas
	where texto=@texto
end;
go

go
create procedure sp_recuperar_id_por_nombre_jugador
	@nombre nvarchar(30)
as
begin
	select id_jugador from jugadores
	where nombre=@nombre
end;
go

go
create procedure sp_consultar_pregunta_y_opciones
    @nivel int
as
begin
    declare @id_pregunta int;

    select top 1 @id_pregunta = id_pregunta from preguntas
    where nivel = @nivel
    order by newid();

    if @id_pregunta is null
    return;

    select id_pregunta, texto, nivel from preguntas
    where id_pregunta = @id_pregunta;

    select id_opcion, texto, es_correcta, pregunta from opciones
    where pregunta = @id_pregunta;
end
go