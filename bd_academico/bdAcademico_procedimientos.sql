 USE bd_academico;
GO

-- PA Facultad
CREATE PROCEDURE pa_insert_facultad
@idFac INT,
@nombre VARCHAR(100),
@retorno INT OUTPUT
AS
	BEGIN TRY
		IF EXISTS (SELECT nombre_facultad FROM facultad WHERE nombre_facultad = @nombre)
			SET @retorno = 1; -- Indica un error de duplicado
		ELSE
			BEGIN
				INSERT INTO facultad VALUES (@idFac, @nombre);
				SET @retorno = 0; -- Indica éxito
			END
	END TRY
	BEGIN CATCH
		SET @retorno = -1; -- Indica un error de base de datos
	END CATCH

CREATE PROCEDURE pa_update_facultad
@idFac INT,
@nombre VARCHAR(100),
@retorno INT OUTPUT
AS
	BEGIN TRY
		IF EXISTS (SELECT nombre_facultad FROM facultad WHERE nombre_facultad = @nombre)
			SET @retorno = 1; -- Indica un error de duplicado
		ELSE
			BEGIN
				UPDATE facultad SET nombre_facultad = @nombre WHERE facultad_id = @idFac;
				SET @retorno = 0; -- Indica éxito
			END
	END TRY
	BEGIN CATCH
		SET @retorno = -1; -- Indica un error de base de datos
	END CATCH

CREATE PROCEDURE pa_delete_facultad
@idFac INT,
@retorno INT OUTPUT
AS
	BEGIN TRY
		DELETE FROM facultad WHERE facultad_id = @idFac;
		SET @retorno = 0; -- Indica éxito
	END TRY
	BEGIN CATCH
		SET @retorno = -1; -- Indica un error de base de datos
	END CATCH

-- PA Escuela
CREATE PROCEDURE pa_insert_escuela
@idEsc INT,
@nombre VARCHAR(100),
@idFac INT,
@retorno INT OUTPUT
AS
    BEGIN TRY
        IF EXISTS (SELECT nombre_escuela FROM escuela WHERE nombre_escuela = @nombre AND facultad_id = @idFac)
            SET @retorno = 1; -- Indica un error de duplicado
        ELSE
            BEGIN
                INSERT INTO escuela (escuela_id, nombre_escuela, facultad_id) VALUES (@idEsc, @nombre, @idFac);
                SET @retorno = 0; -- Indica éxito
            END
    END TRY
    BEGIN CATCH
        SET @retorno = -1; -- Indica un error de base de datos
    END CATCH

CREATE PROCEDURE pa_update_escuela
@idEsc INT,
@nombre VARCHAR(100),
@idFac INT,
@retorno INT OUTPUT
AS
	BEGIN TRY
		IF EXISTS (SELECT nombre_escuela FROM escuela WHERE nombre_escuela = @nombre and facultad_id = @idFac)
			SET @retorno = 1; -- Indica un error de duplicado
		ELSE
			BEGIN
				UPDATE escuela SET nombre_escuela = @nombre, facultad_id = @idFac WHERE escuela_id = @idEsc;
				SET @retorno = 0; -- Indica éxito
			END
	END TRY
	BEGIN CATCH
		SET @retorno = -1; -- Indica un error de base de datos
	END CATCH

CREATE PROCEDURE pa_delete_escuela
@idEsc INT,
@retorno INT OUTPUT
AS
	BEGIN TRY
		DELETE FROM escuela WHERE escuela_id = @idEsc;
		SET @retorno = 0; -- Indica éxito
	END TRY
	BEGIN CATCH
		SET @retorno = -1; -- Indica un error de base de datos
	END CATCH

-- PA Plan Estudio
CREATE PROCEDURE pa_insert_planEstudio
@idPlan INT,
@desc VARCHAR(150),
@est BIT,
@retorno INT OUTPUT
AS
	BEGIN TRY
		IF EXISTS (SELECT plan_id FROM plan_estudio WHERE plan_id = @idPlan)
			SET @retorno = 1; -- Indica un error de duplicado
		ELSE
			BEGIN
				INSERT INTO plan_estudio VALUES (@idPlan, @desc, @est);
				SET @retorno = 0; -- Indica éxito
			END
	END TRY
	BEGIN CATCH
		SET @retorno = -1; -- Indica un error de base de datos
	END CATCH

CREATE PROCEDURE pa_update_planEstudio
@idPlan INT,
@desc VARCHAR(150),
@est BIT,
@retorno INT OUTPUT
AS
	BEGIN TRY
			BEGIN
				UPDATE plan_estudio SET estado = @est, descripcion = @desc WHERE plan_id = @idPlan;
				SET @retorno = 0; -- Indica éxito
			END
	END TRY
	BEGIN CATCH
		SET @retorno = -1; -- Indica un error de base de datos
	END CATCH

CREATE PROCEDURE pa_delete_planEstudio
    @idPlan INT,
    @retorno INT OUTPUT
AS
BEGIN
    DECLARE @total INT;

    BEGIN TRY
        BEGIN TRANSACTION;
        SELECT @total = COUNT(*) FROM curso WHERE plan_id = @idPlan;
        IF @total > 0
			BEGIN
			-- Eliminación lógica
				UPDATE plan_estudio SET estado = 0 WHERE plan_id = @idPlan;
				SET @retorno = 1;
			END
        ELSE
			BEGIN
			-- Eliminación física
				DELETE FROM plan_estudio WHERE plan_id = @idPlan;
				SET @retorno = 0;
			END
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @retorno = -1;
    END CATCH
END;
-- PA Semestre
CREATE PROCEDURE pa_insert_semestre
@codSem char(6),
@fIni DATE,
@fFin DATE,
@est BIT,
@retorno INT OUTPUT
AS
	BEGIN TRY
		IF EXISTS (SELECT codigo_semestre FROM semestre WHERE codigo_semestre = @codSem)
			SET @retorno = 1; -- Indica un error de duplicado
		ELSE
			BEGIN
				INSERT INTO semestre VALUES (@codSem, @fIni,@fFin, @est);
				SET @retorno = 0; -- Indica éxito
			END
	END TRY
	BEGIN CATCH
		SET @retorno = -1; -- Indica un error de base de datos
	END CATCH

CREATE PROCEDURE pa_update_semestre
@codSem char(6),
@fIni DATE,
@fFin DATE,
@est BIT,
@retorno INT OUTPUT
AS
	BEGIN TRY
			BEGIN
				UPDATE semestre SET f_inicio=@fIni, f_culminacion = @fFin, estado_semestre= @est WHERE codigo_semestre = @codSem;
				SET @retorno = 0; -- Indica éxito
			END
	END TRY
	BEGIN CATCH
		SET @retorno = -1; -- Indica un error de base de datos
	END CATCH

CREATE PROCEDURE pa_delete_semestre
@codSem char(6),
@retorno INT OUTPUT
AS
BEGIN
    DECLARE @total INT;

    BEGIN TRY
        BEGIN TRANSACTION;
        SELECT @total = COUNT(*) FROM grupo WHERE semestre_id = @codSem;
        IF @total > 0
			BEGIN
			-- Eliminación lógica
				UPDATE grupo SET estado_grupo = 0 WHERE semestre_id = @codSem;
				SET @retorno = 1;
			END
        ELSE
			BEGIN
			-- Eliminación física
				DELETE FROM semestre WHERE codigo_semestre = @codSem;
				SET @retorno = 0;
			END
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @retorno = -1;
    END CATCH
END;

-- PA Curso
select * from curso
CREATE PROCEDURE pa_insert_curso
@codCur		varchar(20),
@nomCur		varchar(100),
@hTeo		int,
@hPra		int,
@ciclo		int,
@tipoCurso	BIT,
@planID		int,
@escID		int,
@retorno	INT OUTPUT
AS
	BEGIN TRY
		IF EXISTS (	SELECT nombre_curso FROM curso 
					WHERE codigo_curso = @codCur OR nombre_curso = @nomCur) --Cuando ya existe un curso con el mismo código y nombre
			SET @retorno = 1; -- Indica un error de código duplicado
		ELSE
			BEGIN
				DECLARE @creditos int
				set @creditos = (@hTeo + @hPra/2)
				INSERT INTO curso (codigo_curso, nombre_curso, creditos, h_teoria, h_practica, ciclo, tipo_curso, plan_id, escuela_id)
				VALUES (@codCur, @nomCur, @creditos, @hTeo, @hPra, @ciclo, @tipoCurso, @planID, @escID);
				SET @retorno = 0; -- Indica éxito
			END
	END TRY
	BEGIN CATCH
		SET @retorno = -1; -- Indica un error de base de datos
	END CATCH

CREATE PROCEDURE pa_update_curso
@codCur		varchar(20),
@nomCur		varchar(100),
@hTeo		int,
@hPra		int,
@ciclo		int,
@tipoCurso	BIT,
@planID		int,
@escID		int,
@retorno	INT OUTPUT
AS
	BEGIN TRY
		IF EXISTS (	SELECT nombre_curso FROM curso 
					WHERE nombre_curso = @nomCur) --Cuando ya existe un curso con el mismo código y nombre
			SET @retorno = 1; -- Indica un error de código duplicado
		ELSE
			BEGIN
				DECLARE @creditos int
				set @creditos = (@hTeo + @hPra/2)
				UPDATE curso SET codigo_curso =  @codCur, nombre_curso = @nomCur,creditos = @creditos,h_teoria=@hTeo,
									h_practica=@hPra,ciclo=@ciclo, tipo_curso=@tipoCurso,plan_id=@planID,escuela_id=@escID 
				where codigo_curso =  @codCur
				SET @retorno = 0; -- Indica éxito
			END
	END TRY
	BEGIN CATCH
		SET @retorno = -1; -- Indica un error de base de datos
	END CATCH

CREATE PROCEDURE pa_delete_curso
@codCur	 varchar(20),
@retorno INT OUTPUT
AS
BEGIN
    DECLARE @total INT;
	DECLARE @idCur INT;
    BEGIN TRY
        BEGIN TRANSACTION;
		SELECT @idCur = curso_id from curso where codigo_curso = @codCur
        SELECT @total = COUNT(*) FROM grupo WHERE curso_id = @idCur;
        IF @total > 0
			BEGIN
			-- Eliminación lógica
				UPDATE grupo SET estado_grupo = 1 WHERE curso_id = @idCur;
				SET @retorno = 1;
			END
        ELSE
			BEGIN
			-- Eliminación física
				DELETE FROM curso WHERE codigo_curso = @codCur;
				SET @retorno = 0;
			END
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @retorno = -1;
    END CATCH
END;
select * from docente
-- PA Docente 
CREATE PROCEDURE pa_insert_docente
@tipoDoc	char(1),
@numDoc		varchar(20),
@tipoDocente char(2),
@apePat		varchar(50),
@apeMat		varchar(50),
@nombre		varchar(50),
@grado		char(1),
@estado		bit,
@ubigeo		char(6),
@retorno	INT OUTPUT
AS
	BEGIN TRY
		IF EXISTS (	SELECT 1 FROM docente 
					WHERE numero_documento_docente = @numDoc) --Cuando ya existe un curso con el mismo código y nombre
			SET @retorno = 1; -- Indica un error de código duplicado
		ELSE
			BEGIN
				INSERT INTO docente(tipo_documento, numero_documento_docente, tipo_docente, ape_paterno, ape_materno, nombres, ultimo_grado_academico,
				estado_docente, ubigeo_id)
				VALUES (@tipoDoc, @numDoc, @tipoDocente, @apePat, @apeMat, @nombre, @grado,@estado, @ubigeo);
				SET @retorno = 0; -- Indica éxito
			END
	END TRY
	BEGIN CATCH
		SET @retorno = -1; -- Indica un error de base de datos
	END CATCH

CREATE PROCEDURE pa_update_docente
@idDocente	int,
@tipoDoc	char(1),
@numDoc		varchar(20),
@tipoDocente char(2),
@apePat		varchar(50),
@apeMat		varchar(50),
@nombre		varchar(50),
@grado		char(1),
@estado		bit,
@ubigeo		char(6),
@retorno	INT OUTPUT
AS
	BEGIN TRY
			BEGIN
				update docente set tipo_documento = @tipoDoc, numero_documento_docente = @numDoc, tipo_docente= @tipoDocente, 
				ape_paterno = @apePat, ape_materno = @apeMat, nombres= @nombre, ultimo_grado_academico = @grado, estado_docente = @estado, 
				ubigeo_id = @ubigeo where docente_id = @idDocente;
				SET @retorno = 0; -- Indica éxito
			END
	END TRY
	BEGIN CATCH
		SET @retorno = -1; -- Indica un error de base de datos
	END CATCH

CREATE PROCEDURE pa_delete_docente
@idDocente int,
@retorno INT OUTPUT
AS
BEGIN
    DECLARE @total INT;
    BEGIN TRY
        BEGIN TRANSACTION;
        SELECT @total = COUNT(*) FROM grupo WHERE docente_id = @idDocente;
        IF @total > 0
			BEGIN
			-- Eliminación lógica
				UPDATE docente SET estado_docente = 0 WHERE docente_id = @idDocente;
				SET @retorno = 1;
			END
        ELSE
			BEGIN
			-- Eliminación física
				DELETE FROM docente WHERE docente_id = @idDocente;
				SET @retorno = 0;
			END
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SET @retorno = -1;
    END CATCH
END;

-- PA Alumno
CREATE PROCEDURE pa_insert_alumno
@tipoDoc	char(1),
@numDoc		varchar(20),
@apePat		varchar(50),
@apeMat		varchar(50),
@nombre		varchar(50),
@sexo		bit,
@fecNac		date,
@direccion	varchar(100),
@estado		char(1),
@escuelaId	int,
@ubigeo		char(6),
@semIngreso	char(6),
@retorno	INT OUTPUT
AS
	BEGIN TRY
		IF EXISTS (	SELECT 1 FROM alumno 
					WHERE numero_documento = @numDoc) --Cuando ya existe alumno con el mismo DNI
			BEGIN
				SET @retorno = 1; -- Indica un error de código duplicado
				RETURN; -- Importante para detener la ejecución aquí
			END
		ELSE
			BEGIN
				INSERT INTO alumno(tipo_documento, numero_documento, ape_paterno, ape_materno, nombres, sexo, f_nacimiento,
				direccion_residencia, estado_alumno,escuela_id,ubigeo_id,semestre_ingreso,semestre_egreso)
				VALUES (@tipoDoc, @numDoc, @apePat, @apeMat, @nombre, @sexo,@fecNac,@direccion,@estado, @escuelaId,@ubigeo,@semIngreso,null);
			END
			SET @retorno = 0; -- Indica éxito
	END TRY
	BEGIN CATCH
		SET @retorno = -1; -- Indica un error de base de datos
	END CATCH

--CREATE PROCEDURE pa_update_alumno
--@idDocente	int,
--@tipoDoc	char(1),
--@numDoc		varchar(20),
--@apePat		varchar(50),
--@apeMat		varchar(50),
--@nombre		varchar(50),
--@sexo		bit,
--@fecNac		date,
--@direccion	varchar(100),
--@estado		char(1),
--@escuelaId	int,
--@ubigeo		char(6),
--@semIngreso	char(6),
--@retorno	INT OUTPUT
--AS
--	BEGIN TRY
--			BEGIN
--				update alumno set 
--				tipo_documento = @tipoDoc, numero_documento = @numDoc,
--				ape_paterno = @apePat, ape_materno = @apeMat, nombres= @nombre, sexo = @sexo , f_nacimiento = @fecNac,direccion_residencia = @direccion,
--				estado_alumno = @estado, escuela_id = @escuelaId, ubigeo =
--				where docente_id = @idDocente;
--				SET @retorno = 0; -- Indica éxito
--			END
--	END TRY
--	BEGIN CATCH
--		SET @retorno = -1; -- Indica un error de base de datos
--	END CATCH

-- PA DELETE ALUMNO
CREATE PROCEDURE pa_eliminar_alumno
	@alumno_id INT,
	@retorno INT OUTPUT
AS
	BEGIN TRY
		UPDATE alumno
		set estado_alumno = 'R'
		where alumno_id = @alumno_id

		SET @retorno = 0
	END TRY

	BEGIN CATCH
		SET @retorno = -1
	END CATCH


-- PA Curso_Curso
create proc pa_insert_curso_curso
@id int, @id_pre int, @retorno int output
as
	Begin try
		insert into curso_curso(curso_id, curso_id_pre) 
			values(@id, @id_pre)
		set @retorno=0
	end try
	Begin Catch
		set @retorno=-1
	end catch
go

create proc pa_eliminar_curso_curso
@id int,@id_pre int, @retorno int output
as
	Begin try
		delete from curso_curso where curso_id = @id and curso_id_pre = @id_pre
		set @retorno = 0
	end try
	Begin catch
		set @retorno = -1
	end catch

create proc pa_modificar_curso_curso
@id int, @id_pre int, @retorno int output
as
	Begin try
		update curso_curso set curso_id_pre = @id_pre
		where curso_id = @id and curso_id_pre = @id_pre
		set @retorno=0
	end try
	Begin Catch
		set @retorno=-1
	end catch
go
-- PA Ubigeo
CREATE PROCEDURE pa_insert_ubigeo
	@ubigeo_id CHAR(6),
	@distrito VARCHAR(100),
	@provincia VARCHAR(100),
	@departamento VARCHAR(100),
	@retorno INT OUTPUT
AS
	BEGIN TRY
		INSERT INTO ubigeo
		(ubigeo_id,
		distrito,
		provincia,
		departamento)
		VALUES
		(@ubigeo_id,
		@distrito,
		@provincia,
		@departamento)
		SET @retorno = 0
	END TRY
	
	BEGIN CATCH
		SET @retorno = -1
	END CATCH
CREATE PROCEDURE pa_update_ubigeo
	@ubigeo_id CHAR(6),
	@distrito VARCHAR(100),
	@provincia VARCHAR(100),
	@departamento VARCHAR(100),
	@retorno INT OUTPUT
AS
	BEGIN TRY
		UPDATE ubigeo SET
		distrito = @distrito,
		provincia = @provincia,
		departamento = @departamento
		WHERE ubigeo_id = @ubigeo_id
		SET @retorno = 0
	END TRY
	BEGIN CATCH
		SET @retorno = -1
	END CATCH
CREATE PROCEDURE pa_delete_ubigeo
	 @ubigeo_id CHAR(6),
	 @retorno INT OUTPUT
AS
	BEGIN TRY
		DELETE FROM ubigeo 
		WHERE ubigeo_id = @ubigeo_id
		SET @retorno = 0
	END TRY

	BEGIN CATCH
		SET @retorno = -1
	END CATCH

-- PA Ambiente
select * from ambiente;
create PROCEDURE [dbo].[pa_insert_ambiente]
@tp_amb char(1),
@desc VARCHAR(100),
@cap INT,
@retorno INT OUTPUT
AS
	BEGIN TRY
		IF EXISTS (SELECT descripcion_ambiente FROM ambiente WHERE descripcion_ambiente = @desc and tipo_ambiente = @tp_amb)
			SET @retorno = 1; -- Indica un error de duplicado
		ELSE
			BEGIN
				INSERT INTO ambiente VALUES (@tp_amb, @desc,@cap);

				SET @retorno = 0; -- Indica �xito
			END
	END TRY
	BEGIN CATCH
		SET @retorno = -1; -- Indica un error de base de datos
	END CATCH

create PROCEDURE [dbo].[pa_update_ambiente]
@idAmb INT,
@tp_amb char(1),
@desc VARCHAR(100),
@cap INT,
@retorno INT OUTPUT
AS
	BEGIN TRY
		IF EXISTS (SELECT descripcion_ambiente FROM ambiente WHERE descripcion_ambiente = @desc and tipo_ambiente = @tp_amb and capacidad=@cap)
			SET @retorno = 1; -- Indica un error de duplicado
		ELSE
			BEGIN
				UPDATE ambiente SET descripcion_ambiente = @desc, tipo_ambiente = @tp_amb, capacidad = @cap WHERE ambiente_id = @idAmb;
				SET @retorno = 0; -- Indica �xito
			END
	END TRY
	BEGIN CATCH
		SET @retorno = -1; -- Indica un error de base de datos
	END CATCH

create PROCEDURE [dbo].[pa_delete_ambiente]
@idAmb INT,
@retorno INT OUTPUT
AS
	BEGIN TRY
		DELETE FROM ambiente WHERE ambiente_id = @idAmb;
		SET @retorno = 0; -- Indica �xito
	END TRY
	BEGIN CATCH
		SET @retorno = -1; -- Indica un error de base de datos
	END CATCH
-- PA Grupo
select * from grupo;


-- PA TIPO AMBIENTE

-- INSERTAR TIPO AMBIENTE
CREATE PROCEDURE pa_insert_tipoambiente
	@tipoambiente varchar(100),
	@abrev char(10),
	@retorno INT OUTPUT
AS
	BEGIN TRY
		INSERT INTO tipo_ambiente(descripcion_tipoambiente,abreviatura)
		VALUES (@tipoambiente, @abrev)
		SET @retorno = 0
	END TRY
	
	BEGIN CATCH
		SET @retorno = -1
	END CATCH

	GO
--- PRUEBA ---
	DECLARE @retorno INT
	EXECUTE pa_insert_tipoambiente 'Auditorio', 'AD', @retorno OUTPUT
	SELECT @retorno

-- MODIFICAR TIPO AMBIENTE
CREATE PROCEDURE pa_modificar_tipoambiente
	@id int,
	@tipoambiente varchar(100),
	@abrev char(10),
	@vigenc bit,
	@retorno INT OUTPUT
AS
	BEGIN TRY
		UPDATE tipo_ambiente
		SET descripcion_tipoambiente = @tipoambiente, abreviatura = @abrev, vigencia = @vigenc
		WHERE tipoambiente_id = @id
		SET @retorno = 0
	END TRY
	
	BEGIN CATCH
		SET @retorno = -1
	END CATCH

	GO
	--- PRUEBA ---
	DECLARE @retorno INT
	EXECUTE pa_modificar_tipoambiente 2,'Laboratorios', 'LAB', @retorno OUTPUT
	SELECT @retorno


-- ELIMINAR TIPO AMBIENTE
CREATE PROCEDURE pa_eliminar_tipoambiente
	@id int,
	@retorno INT OUTPUT
AS
	BEGIN TRY
		UPDATE tipo_ambiente
		SET vigencia = 0
		WHERE tipoambiente_id = @id
		SET @retorno = 0
	END TRY
	
	BEGIN CATCH
		SET @retorno = -1
	END CATCH