SELECT * from Alumno
SELECT Legajo,Activo from Alumno
SELECT * from Alumno where Legajo < 4
SELECT * from Alumno order by Nombre desc
SELECT * from Alumno where Legajo between 2 and 4
SELECT * from Alumno where nombre like 'Anas%'

Insert into dbo.Alumno 
(dbo.Alumno.Legajo,nombre,apellido,Ingreso,Activo) 
values 
(5,'Ariel','Martionez','5/15/2027','True')

Update dbo.Alumno
set Nombre='Ezequiel',Apellido='Martinez'
where legajo=5

Update dbo.Alumno
set Apellido='Peres'
where Apellido='Perez'

Delete Alumno where Legajo = 5

