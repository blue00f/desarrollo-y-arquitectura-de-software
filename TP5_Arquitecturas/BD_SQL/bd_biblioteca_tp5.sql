create database bd_biblioteca_tp5;
use bd_biblioteca_tp5;

create table libro(
	libro_id nvarchar(20) not null,
	libro_titulo nvarchar(100) not null,
	libro_autor nvarchar(100) not null,
	constraint pk_libro primary key (libro_id)
);

create table socio(
	socio_id nvarchar(20) not null,
	socio_nombre nvarchar(30) not null,
	socio_apellido nvarchar(30) not null,
	socio_fechaNacimiento date,
	socio_localidad nvarchar(100) not null,
	constraint pk_socio primary key (socio_id)
);

create table prestamo(
	prestamo_id nvarchar(20) not null,
	prestamo_socio nvarchar(20) not null,
	prestamo_libro nvarchar(20) not null,
	prestamo_estado nvarchar(20) not null,
	prestamo_fechaPrestamo date not null,
	prestamo_fechaDevolucion date not null,
	constraint pk_prestamo primary key (prestamo_id),
	constraint fk_socio foreign key (prestamo_socio) references socio(socio_id),
	constraint fk_libro foreign key (prestamo_libro) references libro(libro_id)
);

insert into socio values
('S001', 'Lucía', 'Martínez', '1995-04-12', 'Dolores'),
('S002', 'Joaquín', 'Pérez', '1990-07-23', 'Mar del Plata'),
('S003', 'Camila', 'Fernández', '2001-03-08', 'La Plata'),
('S004', 'Mateo', 'Gómez', '1988-12-01', 'Bahía Blanca'),
('S005', 'Valentina', 'Rodríguez', '1993-09-19', 'Tandil'),
('S006', 'Sofía', 'Moreno', '1999-02-15', 'Dolores'),
('S007', 'Benjamín', 'Sánchez', '1985-10-07', 'Mar del Plata'),
('S008', 'Martina', 'López', '1997-06-11', 'Necochea'),
('S009', 'Tomás', 'Ruiz', '1992-08-24', 'Ayacucho'),
('S010', 'Mía', 'Castro', '1998-01-30', 'Dolores'),
('S011', 'Lucas', 'Romero', '1989-11-09', 'La Plata'),
('S012', 'Emma', 'Silva', '2000-05-21', 'Mar del Plata'),
('S013', 'Juan', 'Navarro', '1991-02-10', 'Tandil'),
('S014', 'Catalina', 'Ortiz', '1996-04-25', 'Dolores'),
('S015', 'Franco', 'Blanco', '1987-07-15', 'Bahía Blanca'),
('S016', 'Julia', 'Herrera', '1994-09-03', 'Necochea'),
('S017', 'Agustín', 'Molina', '2002-12-28', 'Dolores'),
('S018', 'Valeria', 'Ríos', '1990-10-19', 'Mar del Plata'),
('S019', 'Lautaro', 'Peralta', '1995-06-08', 'Tandil'),
('S020', 'Brenda', 'Vega', '1999-03-27', 'Dolores');

insert into libro values
('L001', 'Cien años de soledad', 'Gabriel García Márquez'),
('L002', 'Rayuela', 'Julio Cortázar'),
('L003', 'El amor en los tiempos del cólera', 'Gabriel García Márquez'),
('L004', 'Don Quijote de la Mancha', 'Miguel de Cervantes'),
('L005', '1984', 'George Orwell'),
('L006', 'Fahrenheit 451', 'Ray Bradbury'),
('L007', 'Crónica de una muerte anunciada', 'Gabriel García Márquez'),
('L008', 'La sombra del viento', 'Carlos Ruiz Zafón'),
('L009', 'Los pilares de la tierra', 'Ken Follett'),
('L010', 'El principito', 'Antoine de Saint-Exupéry'),
('L011', 'Harry Potter y la piedra filosofal', 'J.K. Rowling'),
('L012', 'Harry Potter y la cámara secreta', 'J.K. Rowling'),
('L013', 'Harry Potter y el prisionero de Azkaban', 'J.K. Rowling'),
('L014', 'El señor de los anillos: La comunidad del anillo', 'J.R.R. Tolkien'),
('L015', 'El señor de los anillos: Las dos torres', 'J.R.R. Tolkien'),
('L016', 'El señor de los anillos: El retorno del rey', 'J.R.R. Tolkien'),
('L017', 'Orgullo y prejuicio', 'Jane Austen'),
('L018', 'Mujercitas', 'Louisa May Alcott'),
('L019', 'El alquimista', 'Paulo Coelho'),
('L020', 'La casa de los espíritus', 'Isabel Allende'),
('L021', 'El código Da Vinci', 'Dan Brown'),
('L022', 'Ángeles y demonios', 'Dan Brown'),
('L023', 'Inferno', 'Dan Brown'),
('L024', 'El nombre del viento', 'Patrick Rothfuss'),
('L025', 'El temor de un hombre sabio', 'Patrick Rothfuss'),
('L026', 'Los juegos del hambre', 'Suzanne Collins'),
('L027', 'En llamas', 'Suzanne Collins'),
('L028', 'Sinsajo', 'Suzanne Collins'),
('L029', 'It', 'Stephen King'),
('L030', 'Cementerio de animales', 'Stephen King');

insert into prestamo values
('P001', 'S001', 'L001', 'En curso', '2025-01-10', '2025-01-25'),
('P002', 'S002', 'L002', 'Devuelto', '2025-02-05', '2025-02-20'),
('P003', 'S003', 'L003', 'En curso', '2025-03-12', '2025-03-28'),
('P004', 'S004', 'L004', 'Devuelto', '2025-04-02', '2025-04-18'),
('P005', 'S005', 'L005', 'En curso', '2025-05-06', '2025-05-22'),
('P006', 'S006', 'L006', 'Devuelto', '2025-06-10', '2025-06-24'),
('P007', 'S007', 'L007', 'Devuelto', '2025-07-03', '2025-07-18'),
('P008', 'S008', 'L008', 'En curso', '2025-08-12', '2025-08-26'),
('P009', 'S009', 'L009', 'Devuelto', '2025-09-01', '2025-09-16'),
('P010', 'S010', 'L010', 'En curso', '2025-10-05', '2025-10-19'),
('P011', 'S011', 'L011', 'Devuelto', '2025-02-14', '2025-02-28'),
('P012', 'S012', 'L012', 'En curso', '2025-03-21', '2025-04-04'),
('P013', 'S013', 'L013', 'Devuelto', '2025-05-09', '2025-05-25'),
('P014', 'S014', 'L014', 'En curso', '2025-06-15', '2025-06-30'),
('P015', 'S015', 'L015', 'Devuelto', '2025-07-07', '2025-07-21'),
('P016', 'S016', 'L016', 'En curso', '2025-08-01', '2025-08-15'),
('P017', 'S017', 'L017', 'Devuelto', '2025-09-11', '2025-09-26'),
('P018', 'S018', 'L018', 'En curso', '2025-10-02', '2025-10-18'),
('P019', 'S019', 'L019', 'En curso', '2025-11-05', '2025-11-20'),
('P020', 'S020', 'L020', 'Devuelto', '2025-12-10', '2025-12-27'),
('P021', 'S001', 'L021', 'Devuelto', '2025-02-01', '2025-02-16'),
('P022', 'S002', 'L022', 'En curso', '2025-03-10', '2025-03-25'),
('P023', 'S003', 'L023', 'Devuelto', '2025-04-14', '2025-04-30'),
('P024', 'S004', 'L024', 'En curso', '2025-05-20', '2025-06-05'),
('P025', 'S005', 'L025', 'Devuelto', '2025-06-22', '2025-07-07');
select * from libro;
select * from socio;
select * from prestamo;

truncate table prestamo;