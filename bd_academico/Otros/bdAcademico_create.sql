CREATE DATABASE bd_academico;
GO

USE bd_academico;
GO

CREATE TABLE facultad (
  facultad_id     int NOT NULL, 
  nombre_facultad varchar(100) NOT NULL, 
  PRIMARY KEY (facultad_id)
);
GO

CREATE TABLE escuela (
  escuela_id     int NOT NULL, 
  nombre_escuela varchar(100) NOT NULL, 
  facultad_id    int NOT NULL, 
  numero_ciclos int not null,
  PRIMARY KEY (escuela_id),
  FOREIGN KEY (facultad_id) REFERENCES facultad (facultad_id)
);
GO

CREATE TABLE ciclo (
	ciclo_id int identity not null,
	escuela_id int not null,
	numero_ciclo int,
	PRIMARY KEY (ciclo_id),
	FOREIGN KEY (escuela_id) REFERENCES escuela(escuela_id)
);
GO
use bd_academico
select * from escuela
select * from ciclo
alter table escuela add numero_ciclos int
--insert into ciclo(escuela_id,numero_ciclo)values (10,1)
--insert into ciclo(escuela_id,numero_ciclo)values (10,2)
--insert into ciclo(escuela_id,numero_ciclo)values (10,3)
--insert into ciclo(escuela_id,numero_ciclo)values (10,4)
--insert into ciclo(escuela_id,numero_ciclo)values (10,5)
--insert into ciclo(escuela_id,numero_ciclo)values (10,6)
--insert into ciclo(escuela_id,numero_ciclo)values (10,7)
--insert into ciclo(escuela_id,numero_ciclo)values (10,8)
--insert into ciclo(escuela_id,numero_ciclo)values (10,9)
--insert into ciclo(escuela_id,numero_ciclo)values (10,10)
use bd_academico


CREATE TABLE plan_estudio (
  plan_id     int NOT NULL, 
  descripcion varchar(150) NOT NULL, 
  estado      bit NOT NULL, 
  PRIMARY KEY (plan_id)
);
GO

CREATE TABLE semestre (
  codigo_semestre char(6) NOT NULL, 
  f_inicio        date NOT NULL, 
  f_culminacion   date NOT NULL, 
  estado_semestre bit NOT NULL, 
  PRIMARY KEY (codigo_semestre)
);
GO

CREATE TABLE ubigeo (
  ubigeo_id    char(6) NOT NULL, 
  distrito     varchar(100) NOT NULL, 
  provincia    varchar(100) NOT NULL, 
  departamento varchar(100) NOT NULL, 
  PRIMARY KEY (ubigeo_id)
);
GO

CREATE TABLE curso (
  curso_id     int IDENTITY NOT NULL, 
  codigo_curso varchar(20) NOT NULL, 
  nombre_curso varchar(100) NOT NULL, 
  creditos     int NOT NULL, 
  h_teoria     int NOT NULL, 
  h_practica   int NOT NULL, 
  ciclo        int NOT NULL, 
  tipo_curso   bit NOT NULL, 
  plan_id      int NOT NULL, 
  escuela_id   int NULL, 
  PRIMARY KEY (curso_id),
  FOREIGN KEY (plan_id) REFERENCES plan_estudio (plan_id),
  FOREIGN KEY (escuela_id) REFERENCES escuela (escuela_id),
);
GO
select* from horario

CREATE TABLE curso_curso (
  curso_id     int NOT NULL, 
  curso_id_pre int NOT NULL, 
  PRIMARY KEY (curso_id, curso_id_pre),
  FOREIGN KEY (curso_id) REFERENCES curso (curso_id),
  FOREIGN KEY (curso_id_pre) REFERENCES curso (curso_id)
);
GO

CREATE TABLE docente (
  docente_id               int IDENTITY NOT NULL, 
  tipo_documento           char(1) NOT NULL, 
  numero_documento_docente varchar(20) NULL, 
  tipo_docente             char(2) NOT NULL, 
  ape_paterno              varchar(50) NOT NULL, 
  ape_materno              varchar(50) NOT NULL, 
  nombres                  varchar(50) NOT NULL, 
  grado_academico_id	   char(1) NOT NULL, 
  fecha_registro           date DEFAULT CAST(GETDATE() AS DATE) NOT NULL, 
  estado_docente           bit NOT NULL, 
  ubigeo_id                char(6) NULL, 
  PRIMARY KEY (docente_id),
  UNIQUE (numero_documento_docente),
  FOREIGN KEY (ubigeo_id) REFERENCES ubigeo (ubigeo_id)
);
GO
--EXEC sp_rename 'docente.grado_academico_id', 'ultimo_grado_academico', 'COLUMN';

CREATE TABLE tipo_documento(
tipo_documento_id char(1) primary key,
descripcion varchar(20)
);
select * from tipo_documento
insert into tipo_documento values ('1', 'DNI');
insert into tipo_documento values ('2', 'Pasaporte');
insert into tipo_documento values ('3', 'Carnet de extranjer�a');

CREATE TABLE tipo_docente(
tipo_docente_id char(2) primary key,
descripcion varchar(20)
);
insert into tipo_docente values ('TH', 'Tiempo h�brido'), ('TC','Tiempo completo'),('TP', 'Tiempo parcial');

CREATE TABLE grado_academico(
grado_academico_id char(1) primary key,
descripcion varchar(20)
);
insert into grado_academico values ('1','Bachiller'), ('2','Magister'), ('3','Doctorado');

ALTER TABLE docente
ADD CONSTRAINT tipo_documento_docente
FOREIGN KEY (tipo_documento)
REFERENCES tipo_documento(tipo_documento_id);

ALTER TABLE docente
ADD CONSTRAINT tipo_docente_docente
FOREIGN KEY (tipo_docente)
REFERENCES tipo_docente(tipo_docente_id);

ALTER TABLE docente
ADD CONSTRAINT grado_academico_docente
FOREIGN KEY (ultimo_grado_academico)
REFERENCES grado_academico(grado_academico_id);

CREATE TABLE grupo (
  grupo_id        int IDENTITY NOT NULL, 
  denominacion    varchar(1) NOT NULL, 
  numero_vacantes int NOT NULL, 
  estado_grupo    bit NOT NULL, 
  curso_id        int NOT NULL, 
  docente_id      int NULL, 
  semestre_id     char(6) NOT NULL, 
  PRIMARY KEY (grupo_id),
  UNIQUE (curso_id, semestre_id, denominacion),
  FOREIGN KEY (curso_id) REFERENCES curso (curso_id),
  FOREIGN KEY (docente_id) REFERENCES docente (docente_id),
  FOREIGN KEY (semestre_id) REFERENCES semestre (codigo_semestre)
);
GO

CREATE TABLE alumno (
  alumno_id            int IDENTITY NOT NULL, 
  tipo_documento       char(1) NOT NULL, 
  numero_documento     varchar(50) NOT NULL, 
  ape_paterno          varchar(50) NOT NULL, 
  ape_materno          varchar(20) NOT NULL, 
  nombres              varchar(50) NOT NULL, 
  sexo                 bit NOT NULL, 
  f_nacimiento         date NULL, 
  f_registro           date DEFAULT CAST(GETDATE() AS DATE) NOT NULL, 
  direccion_residencia varchar(200) NULL, 
  estado_alumno        char(1) NOT NULL, 
  escuela_id           int NOT NULL, 
  ubigeo_id            char(6) NULL, 
  semestre_ingreso     char(6) NOT NULL, 
  semestre_egreso      char(6) NULL, 
  PRIMARY KEY (alumno_id),
  FOREIGN KEY (escuela_id) REFERENCES escuela (escuela_id),
  FOREIGN KEY (ubigeo_id) REFERENCES ubigeo (ubigeo_id),
  FOREIGN KEY (semestre_ingreso) REFERENCES semestre (codigo_semestre),
  FOREIGN KEY (semestre_egreso) REFERENCES semestre (codigo_semestre)
);
GO

ALTER TABLE alumno
ADD CONSTRAINT fk_tipo_documento
FOREIGN KEY (tipo_documento)
REFERENCES tipo_documento(tipo_documento_id);

create table estado_alumno(
estado_alumno_id char(1) primary key,
descripcion varchar(20)
)
insert into estado_alumno values('A','Activo'),('T','Traspaso')
insert into estado_alumno values('E','Egresado'),('B','Bachiller'),('R','Retirado')

CREATE TABLE ambiente (
  ambiente_id          int IDENTITY NOT NULL, 
  tipo_ambiente        char(1) NOT NULL, 
  descripcion_ambiente varchar(100) NOT NULL, 
  capacidad            int NOT NULL,
  tipoambiente_id      int NOT NULL REFERENCES tipo_ambiente(tipoambiente_id), 
  PRIMARY KEY (ambiente_id)
);
GO

CREATE TABLE tipo_ambiente (
  tipoambiente_id          int IDENTITY NOT NULL, 
  descripcion_tipoambiente varchar(100) NOT NULL,
  abreviatura              char(10) NOT NULL,
  PRIMARY KEY (tipoambiente_id)
);
GO

CREATE TABLE matricula (
  matricula_id    int IDENTITY NOT NULL, 
  fecha_matricula date DEFAULT CAST(GETDATE() AS DATE) NOT NULL, 
  h_matricula     time(6) DEFAULT CAST(GETDATE() AS TIME) NOT NULL, 
  tipo_matricula  bit NOT NULL, 
  alumno_id       int NOT NULL, 
  codigo_semestre char(6) NOT NULL, 
  PRIMARY KEY (matricula_id),
  UNIQUE (alumno_id, codigo_semestre),
  FOREIGN KEY (alumno_id) REFERENCES alumno (alumno_id),
  FOREIGN KEY (codigo_semestre) REFERENCES semestre (codigo_semestre)
);
GO

CREATE TABLE detalle_matricula (
  matricula_id  int NOT NULL, 
  grupo_id      int NOT NULL, 
  estado        char(1) NOT NULL, 
  nota_promedio decimal(4, 2) NULL, 
  PRIMARY KEY (matricula_id, grupo_id),
  FOREIGN KEY (matricula_id) REFERENCES matricula (matricula_id),
  FOREIGN KEY (grupo_id) REFERENCES grupo (grupo_id)
);
GO

CREATE TABLE horario (
  horario_id  int IDENTITY NOT NULL, 
  dia         char(1) NOT NULL, 
  h_inicio    time(6) NOT NULL, 
  h_final     time(6) NOT NULL, 
  ambiente_id int NOT NULL, 
  grupo_id    int NOT NULL, 
  PRIMARY KEY (horario_id),
  FOREIGN KEY (ambiente_id) REFERENCES ambiente (ambiente_id),
  FOREIGN KEY (grupo_id) REFERENCES grupo (grupo_id)
);
GO
