create database gestorDeIndicaciones;
use gestorDeIndicaciones;

create table pacientes(
	idPaciente int auto_increment not null,
    nombre varchar(60) not null,
    apellido varchar(60) not null,
    fechaNacimiento date not null,
    constraint pk_paciente primary key (idPaciente)
);

create table hospitales(
	idHospital int auto_increment not null,
    nombre varchar(120) not null,
    direccion varchar(120) not null,
    constraint pk_hospital primary key (idHospital)
);

create table indicaciones(
	idIndicacion int auto_increment not null,
    paciente int not null,
    hospital int not null,
    descripcion varchar(255) not null,
    constraint pk_indicacion primary key (idIndicacion),
    constraint fk_paciente foreign key (paciente) references pacientes(idPaciente),
    constraint fk_hospital foreign key (hospital) references hospitales(idHospital)
);

insert into pacientes(nombre,apellido,fechaNacimiento) values
("Franco","Colapinto","2003-05-27"),
("Homero","Simpsons","1956-05-12"),
("Bart", "Simpsons","1979-04-01");

insert into hospitales(nombre,direccion) values
("Hospital Italiano de Buenos Aires", "Tte. Gral. Juan Domingo Perón 4190"),
("Hospital Alemán","Av. Pueyrredón 1640"),
("Hospital Garrahan", "Pichincha 1890"),
("Hospital Fernández", "Av. Cerviño 3356"),
("Hospital Posadas", "Avenida Presidente Arturo U. Illia s/n y Marconi Morón 386"),
("Hospital Británico", "Perdriel 74");

insert into indicaciones(paciente, hospital, descripcion) values
(2,6,"El paciente necesita moderar su ingesta de alimentos ricos en azúcares y grasas para evitar futuras molestias gastrointestinales. Se sugiere realizar una consulta con un nutricionista para una posible orientación alimentaria."),
(1,1,"El paciente presenta signos de fatiga muscular y deshidratación leve por esfuerzo prolongado en pista. Se recomienda optimizar el descanso entre carreras y mantener una hidratación constante. Evaluar con fisioterapeuta previo a la próxima competencia."),
(3,4,"El paciente muestra señales de hiperactividad y falta de concentración en el aula. Se sugiere fomentar actividades deportivas y limitar el consumo de azúcar. Considerar una evaluación con psicopedagogo si los síntomas persisten.");

insert into indicaciones(paciente,hospital,descripcion) values
(2,4,"El paciente presenta síntomas de estrés y fatiga acumulada. Se recomienda limitar el tiempo de trabajo y realizar actividades recreativas diarias. Programar una revisión psicológica si la situación persiste. Mantener una buena higiene del sueño.");

insert into indicaciones(paciente,hospital,descripcion) values
(2,3,"El paciente muestra un leve aumento de peso. Se aconseja seguir una dieta balanceada y realizar ejercicio moderado al menos tres veces por semana. Considerar consulta con un nutricionista para ajustar la alimentación.");

insert into indicaciones(paciente,hospital,descripcion) values
(2,1,"El paciente ha experimentado episodios frecuentes de acidez estomacal. Se sugiere evitar alimentos picantes y grasosos, así como reducir el consumo de cafeína. Recomendar una evaluación gastroenterológica si los síntomas no mejoran.");

select * from pacientes;
select * from hospitales;
select * from indicaciones;

SELECT i.descripcion 
FROM hospitales h
JOIN indicaciones i ON h.idHospital = i.hospital
JOIN pacientes p ON i.paciente = p.idPaciente
WHERE p.nombre = 'Homero' AND p.apellido = 'Simpsons';
