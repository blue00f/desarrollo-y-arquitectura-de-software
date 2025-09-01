CREATE PROCEDURE sp_Alumno_Insertar
    @Legajo   INT,
    @Nombre   NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Ingreso  DATE,
    @Activo   BIT
AS
BEGIN
    INSERT INTO Alumno (legajo, Nombre, Apellido, Ingreso, Activo)
    VALUES (@Legajo, @Nombre, @Apellido, @Ingreso, @Activo);
END;
GO

--///////////////////////////////


CREATE PROCEDURE sp_Alumno_Eliminar
    @Legajo INT
AS
BEGIN
    DELETE FROM Alumno
    WHERE legajo = @Legajo;
END;
GO

--////////////////////////////////

CREATE PROCEDURE sp_Alumno_Actualizar
    @Legajo   INT,
    @Nombre   NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @Ingreso  DATE,
    @Activo   BIT
AS
BEGIN
    UPDATE Alumno
    SET Nombre   = @Nombre,
        Apellido = @Apellido,
        Ingreso  = @Ingreso,
        Activo   = @Activo
    WHERE legajo = @Legajo;
END;
GO


--///////////////////////////////////////////

CREATE PROCEDURE sp_Alumno_Listar
AS
BEGIN
    SELECT legajo, Nombre, Apellido, Ingreso, Activo
    FROM Alumno;
END;
GO


--//////////////////////////////////////////////

CREATE PROCEDURE sp_Alumno_BuscarPorLegajo
    @Legajo INT
AS
BEGIN
    SELECT legajo, Nombre, Apellido, Ingreso, Activo
    FROM Alumno
    WHERE legajo = @Legajo;
END;
GO
