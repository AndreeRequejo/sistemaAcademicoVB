use bd_academico

CREATE FUNCTION obtIdFacultad()
RETURNS INT
AS
BEGIN
    DECLARE @sigID INT;
    SELECT @sigID = ISNULL(MAX(facultad_id), 0) + 1 FROM facultad;
    RETURN @sigID;
END;
GO
select * from facultad
select * from escuela
SELECT dbo.obtIdEscuela() AS SiguienteFacultadID;

CREATE FUNCTION obtIdEscuela()
RETURNS INT
AS
BEGIN
    DECLARE @sigID INT;
    SELECT @sigID = ISNULL(MAX(escuela_id), 0) + 1 FROM escuela;
    RETURN @sigID;
END;
GO

select facultad_id from facultad where nombre_facultad = 'Facultad de Ingenierìa'
