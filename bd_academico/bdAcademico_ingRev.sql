CREATE SEQUENCE [PUBLIC].ALUMNO_ALUMNO_ID_SEQ;
GO
CREATE SEQUENCE [PUBLIC].AMBIENTE_AMBIENTE_ID_SEQ;
GO
CREATE SEQUENCE [PUBLIC].CURSO_CURSO_ID_SEQ;
GO
CREATE SEQUENCE [PUBLIC].DOCENTE_DOCENTE_ID_SEQ;
GO
CREATE SEQUENCE [PUBLIC].GRUPO_GRUPO_ID_SEQ;
GO
CREATE SEQUENCE [PUBLIC].HORARIO_HORARIO_ID_SEQ;
GO
CREATE SEQUENCE [PUBLIC].MATRICULA_MATRICULA_ID_SEQ;
GO
CREATE TABLE [public].alumno (
  alumno_id            int NOT NULL , 
  tipo_documento       char(1) NOT NULL, 
  numero_documento     varchar(50) NOT NULL, 
  ape_paterno          varchar(50) NOT NULL, 
  ape_materno          varchar(20) NOT NULL, 
  nombres              varchar(50) NOT NULL, 
  sexo                 bit NOT NULL, 
  f_nacimiento         date NULL, 
  f_registro           date DEFAULT CURRENT_DATE NOT NULL, 
  direccion_residencia varchar(200) NULL, 
  estado_alumno        char(1) NOT NULL, 
  escuela_id           int NOT NULL, 
  ubigeo_id            char(6) NULL, 
  semestre_ingreso     char(6) NOT NULL, 
  semestre_egreso      char(6) NULL, 
  CONSTRAINT alumno_pkey 
    PRIMARY KEY (alumno_id), 
  CONSTRAINT alumno_alumno_id_key 
    UNIQUE (alumno_id));
CREATE TABLE [public].ambiente (
  ambiente_id          int NOT NULL, 
  tipo_ambiente        char(1) NOT NULL, 
  descripcion_ambiente varchar(100) NOT NULL, 
  capacidad            int NOT NULL, 
  CONSTRAINT pk_ambiente_ambiente_id 
    PRIMARY KEY (ambiente_id));
CREATE TABLE [public].curso (
  curso_id     int NOT NULL, 
  codigo_curso varchar(20) NOT NULL, 
  nombre_curso varchar(100) NOT NULL, 
  creditos     int NOT NULL, 
  h_teoria     int NOT NULL, 
  h_practica   int NOT NULL, 
  ciclo        int NOT NULL, 
  tipo_curso   bit NOT NULL, 
  plan_id      int NOT NULL, 
  escuela_id   int NULL, 
  CONSTRAINT curso_pkey 
    PRIMARY KEY (curso_id));
CREATE TABLE [public].curso_curso (
  curso_id     int NOT NULL, 
  curso_id_pre int NOT NULL, 
  CONSTRAINT curso_curso_pkey 
    PRIMARY KEY (curso_id, 
  curso_id_pre));
CREATE TABLE [public].detalle_matricula (
  matricula_id  int NOT NULL, 
  grupo_id      int NOT NULL, 
  estado        char(1) NOT NULL, 
  nota_promedio decimal(4, 2) NULL, 
  CONSTRAINT detalle_matricula_pkey 
    PRIMARY KEY (matricula_id, 
  grupo_id));
CREATE TABLE [public].docente (
  docente_id               int NOT NULL, 
  tipo_documento           char(1) NOT NULL, 
  numero_documento_docente varchar(20) NULL, 
  tipo_docente             char(2) NOT NULL, 
  ape_paterno              varchar(50) NOT NULL, 
  ape_materno              varchar(50) NOT NULL, 
  nombres                  varchar(50) NOT NULL, 
  ultimo_grado_academico   char(1) NOT NULL, 
  fecha_registro           date DEFAULT CURRENT_DATE NOT NULL, 
  estado_docente           bit NOT NULL, 
  ubigeo_id                char(6) NULL, 
  CONSTRAINT docente_pkey 
    PRIMARY KEY (docente_id), 
  CONSTRAINT docente_numero_documento_docente_key 
    UNIQUE (numero_documento_docente));
CREATE TABLE [public].escuela (
  escuela_id     int IDENTITY NOT NULL, 
  nombre_escuela varchar(100) NOT NULL, 
  facultad_id    int NOT NULL, 
  CONSTRAINT escuela_pkey 
    PRIMARY KEY (escuela_id));
CREATE TABLE [public].facultad (
  facultad_id     int IDENTITY NOT NULL, 
  nombre_facultad varchar(100) NOT NULL, 
  CONSTRAINT facultad_pkey 
    PRIMARY KEY (facultad_id));
CREATE TABLE [public].grupo (
  grupo_id        int NOT NULL, 
  denominacion    varchar(1) NOT NULL, 
  numero_vacantes int NOT NULL, 
  estado_grupo    bit NOT NULL, 
  curso_id        int NOT NULL, 
  docente_id      int NULL, 
  semestre_id     char(6) NOT NULL, 
  CONSTRAINT grupo_pkey 
    PRIMARY KEY (grupo_id), 
  CONSTRAINT grupo_curso_id_semestre_id_denominacion_key 
    UNIQUE (curso_id, semestre_id, denominacion));
CREATE TABLE [public].horario (
  horario_id  int NOT NULL, 
  dia         char(1) NOT NULL, 
  h_inicio    time(6) NOT NULL, 
  h_final     time(6) NOT NULL, 
  ambiente_id int NOT NULL, 
  grupo_id    int NOT NULL, 
  CONSTRAINT horario_pkey 
    PRIMARY KEY (horario_id));
CREATE TABLE [public].matricula (
  matricula_id    int NOT NULL, 
  fecha_matricula date DEFAULT CURRENT_DATE NOT NULL, 
  h_matricula     time(6) DEFAULT CURRENT_TIME NOT NULL, 
  tipo_matricula  bit NOT NULL, 
  alumno_id       int NOT NULL, 
  codigo_semestre char(6) NOT NULL, 
  CONSTRAINT matricula_pkey 
    PRIMARY KEY (matricula_id), 
  CONSTRAINT matricula_alumno_id_codigo_semestre_key 
    UNIQUE (alumno_id, codigo_semestre));
CREATE TABLE [public].plan_estudio (
  plan_id     int IDENTITY NOT NULL, 
  descripcion varchar(150) NOT NULL, 
  estado      bit NOT NULL, 
  CONSTRAINT pk_plan_estudio_plan_id 
    PRIMARY KEY (plan_id));
CREATE TABLE [public].semestre (
  codigo_semestre char(6) NOT NULL, 
  f_inicio        date NOT NULL, 
  f_culminacion   date NOT NULL, 
  estado_semestre bit NOT NULL, 
  CONSTRAINT pk_semestre_semestre_id 
    PRIMARY KEY (codigo_semestre));
CREATE TABLE [public].ubigeo (
  ubigeo_id    char(6) NOT NULL, 
  distrito     varchar(100) NOT NULL, 
  provincia    varchar(100) NOT NULL, 
  departamento varchar(100) NOT NULL, 
  CONSTRAINT pk_ubigeo_ubigeo_id 
    PRIMARY KEY (ubigeo_id));
ALTER TABLE [public].alumno ADD CONSTRAINT FKalumno697537 FOREIGN KEY (escuela_id) REFERENCES [public].escuela (escuela_id) ON UPDATE No action ON DELETE No action;
ALTER TABLE [public].alumno ADD CONSTRAINT FKalumno805795 FOREIGN KEY (ubigeo_id) REFERENCES [public].ubigeo (ubigeo_id) ON UPDATE No action ON DELETE No action;
ALTER TABLE [public].alumno ADD CONSTRAINT FKalumno443459 FOREIGN KEY (semestre_ingreso) REFERENCES [public].semestre (codigo_semestre) ON UPDATE No action ON DELETE No action;
ALTER TABLE [public].alumno ADD CONSTRAINT FKalumno321854 FOREIGN KEY (semestre_egreso) REFERENCES [public].semestre (codigo_semestre) ON UPDATE No action ON DELETE No action;
ALTER TABLE [public].curso ADD CONSTRAINT FKcurso783684 FOREIGN KEY (plan_id) REFERENCES [public].plan_estudio (plan_id) ON UPDATE No action ON DELETE No action;
ALTER TABLE [public].curso ADD CONSTRAINT FKcurso639623 FOREIGN KEY (escuela_id) REFERENCES [public].escuela (escuela_id) ON UPDATE No action ON DELETE No action;
ALTER TABLE [public].curso_curso ADD CONSTRAINT FKcurso_curs719628 FOREIGN KEY (curso_id) REFERENCES [public].curso (curso_id) ON UPDATE No action ON DELETE No action;
ALTER TABLE [public].curso_curso ADD CONSTRAINT FKcurso_curs758048 FOREIGN KEY (curso_id_pre) REFERENCES [public].curso (curso_id) ON UPDATE No action ON DELETE No action;
ALTER TABLE [public].detalle_matricula ADD CONSTRAINT FKdetalle_ma549250 FOREIGN KEY (matricula_id) REFERENCES [public].matricula (matricula_id) ON UPDATE No action ON DELETE No action;
ALTER TABLE [public].detalle_matricula ADD CONSTRAINT FKdetalle_ma201709 FOREIGN KEY (grupo_id) REFERENCES [public].grupo (grupo_id) ON UPDATE No action ON DELETE No action;
ALTER TABLE [public].docente ADD CONSTRAINT FKdocente880533 FOREIGN KEY (ubigeo_id) REFERENCES [public].ubigeo (ubigeo_id) ON UPDATE No action ON DELETE No action;
ALTER TABLE [public].escuela ADD CONSTRAINT FKescuela964951 FOREIGN KEY (facultad_id) REFERENCES [public].facultad (facultad_id) ON UPDATE No action ON DELETE No action;
ALTER TABLE [public].grupo ADD CONSTRAINT FKgrupo881923 FOREIGN KEY (curso_id) REFERENCES [public].curso (curso_id) ON UPDATE No action ON DELETE No action;
ALTER TABLE [public].grupo ADD CONSTRAINT FKgrupo236489 FOREIGN KEY (docente_id) REFERENCES [public].docente (docente_id) ON UPDATE No action ON DELETE No action;
ALTER TABLE [public].grupo ADD CONSTRAINT FKgrupo795015 FOREIGN KEY (semestre_id) REFERENCES [public].semestre (codigo_semestre) ON UPDATE No action ON DELETE No action;
ALTER TABLE [public].horario ADD CONSTRAINT FKhorario733527 FOREIGN KEY (ambiente_id) REFERENCES [public].ambiente (ambiente_id) ON UPDATE No action ON DELETE No action;
ALTER TABLE [public].horario ADD CONSTRAINT FKhorario133931 FOREIGN KEY (grupo_id) REFERENCES [public].grupo (grupo_id) ON UPDATE No action ON DELETE No action;
ALTER TABLE [public].matricula ADD CONSTRAINT FKmatricula74962 FOREIGN KEY (alumno_id) REFERENCES [public].alumno (alumno_id) ON UPDATE No action ON DELETE No action;
ALTER TABLE [public].matricula ADD CONSTRAINT FKmatricula984878 FOREIGN KEY (codigo_semestre) REFERENCES [public].semestre (codigo_semestre) ON UPDATE No action ON DELETE No action;
