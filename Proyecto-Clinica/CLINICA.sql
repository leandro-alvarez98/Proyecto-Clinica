-- ELIMINAR BASE DE DATOS
	DROP DATABASE CLINICA
-- CREACION DE LA BASE DE DATOS
	CREATE DATABASE CLINICA
	GO
	USE CLINICA
	GO
-- CREACION DE TABLAS
CREATE TABLE ESPECIALIDADES (
    ID_ESPECIALIDAD TINYINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    TIPO VARCHAR(20) NOT NULL
)
GO
CREATE TABLE JORNADA(
    ID_JORNADA INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    TIPO_JORNADA TINYINT CHECK(TIPO_JORNADA > 0 AND TIPO_JORNADA <= 3),
    HORA_INICIO TIME NOT NULL,
    HORA_FIN TIME NOT NULL,
    CONSTRAINT CK_TIPO_HORAS
        CHECK (
            (TIPO_JORNADA = 1 AND HORA_INICIO = '08:00' AND HORA_FIN = '12:00') OR
            (TIPO_JORNADA = 2 AND HORA_INICIO = '12:00' AND HORA_FIN = '16:00') OR
            (TIPO_JORNADA = 3 AND HORA_INICIO = '16:00' AND HORA_FIN = '20:00')
        )
)
GO
CREATE TABLE HORARIOS (
    ID_HORARIO INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	HORA TIME NOT NULL,
	DISPONIBILIDAD bit not null default(1)
)
GO
CREATE TABLE IMAGENES(
	ID_IMAGEN INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	URL_IMAGEN VARCHAR(200) NULL
)
GO
CREATE TABLE USUARIOS (
    ID_USUARIO INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    NOMBRE_USUARIO VARCHAR(50) UNIQUE NOT NULL,
    CONTRASENA VARCHAR(30) NOT NULL,
    TIPO VARCHAR(20) NOT NULL CHECK (TIPO IN ('Administrador', 'Recepcionista', 'Médico', 'Paciente')),
	ID_IMAGEN INT NULL,
	FOREIGN KEY (ID_IMAGEN) REFERENCES IMAGENES(ID_IMAGEN)
)
GO
CREATE TABLE PACIENTES (
    ID_PACIENTE INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_USUARIO INT NOT NULL,
    NOMBRE VARCHAR(50) NOT NULL,
    APELLIDO VARCHAR(50) NOT NULL,
    TELEFONO VARCHAR(15) NOT NULL,
    DIRECCION VARCHAR(100) NOT NULL,
    FECHA_NACIMIENTO DATE NOT NULL CHECK(FECHA_NACIMIENTO <= GETDATE()),
    MAIL VARCHAR(100) UNIQUE NOT NULL,
    ESTADO BIT DEFAULT(1) NOT NULL,
	FOREIGN KEY (ID_USUARIO) REFERENCES USUARIOS(ID_USUARIO)
)
GO
CREATE TABLE MEDICOS (
    ID_MEDICO INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_USUARIO INT NOT NULL,
    NOMBRE VARCHAR(50) NOT NULL,
	APELLIDO VARCHAR(50) NOT NULL,
    TELEFONO VARCHAR(15) NOT NULL,
    DIRECCION VARCHAR(100) NOT NULL,
    FECHA_NACIMIENTO DATE NOT NULL CHECK(FECHA_NACIMIENTO <= GETDATE()),
    MAIL VARCHAR(100) UNIQUE NOT NULL,
    ESTADO BIT DEFAULT(1),
	FOREIGN KEY (ID_USUARIO) REFERENCES USUARIOS(ID_USUARIO),
)
GO
CREATE TABLE ADMINISTRADOR (
    ID_ADMIN INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_USUARIO INT NOT NULL,
    NOMBRE VARCHAR(50) NOT NULL,
    APELLIDO VARCHAR(50) NOT NULL,
    TELEFONO VARCHAR(15) NOT NULL,
    DIRECCION VARCHAR(100) NOT NULL,
    FECHA_NACIMIENTO DATE NOT NULL CHECK(FECHA_NACIMIENTO <= GETDATE()),
    MAIL VARCHAR(100) UNIQUE NOT NULL,
    ESTADO BIT DEFAULT(1) NOT NULL,
	FOREIGN KEY (ID_USUARIO) REFERENCES USUARIOS(ID_USUARIO)
)
GO
CREATE TABLE RECEPCIONISTA (
    ID_RECEPCIONISTA INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_USUARIO INT NOT NULL,
    NOMBRE VARCHAR(50) NOT NULL,
    APELLIDO VARCHAR(50) NOT NULL,
    TELEFONO VARCHAR(15) NOT NULL,
    DIRECCION VARCHAR(100) NOT NULL,
    FECHA_NACIMIENTO DATE NOT NULL CHECK(FECHA_NACIMIENTO <= GETDATE()),
    MAIL VARCHAR(100) UNIQUE NOT NULL,
    ESTADO BIT DEFAULT(1) NOT NULL,
	FOREIGN KEY (ID_USUARIO) REFERENCES USUARIOS(ID_USUARIO)
)
GO
CREATE TABLE TURNOS (
    ID_TURNO INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_MEDICO INT NOT NULL,
	ID_PACIENTE INT NOT NULL,
	ID_HORARIO int not null,
	FECHA DATE not null,
    ESTADO VARCHAR(30) CHECK (ESTADO IN ('Reservado', 'Reprogramado', 'Cancelado', 'No asistió', 'Finalizado')),
	FOREIGN KEY (ID_MEDICO) REFERENCES MEDICOS(ID_MEDICO),
	FOREIGN KEY (ID_PACIENTE) REFERENCES PACIENTES(ID_PACIENTE),
	FOREIGN KEY (ID_HORARIO) REFERENCES HORARIOS(ID_HORARIO)
)
GO
CREATE TABLE OBSERVACIONES (
    ID_OBSERVACION INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_TURNO INT NOT NULL,
    OBSERVACION VARCHAR(1500) NOT NULL,
	FOREIGN KEY (ID_TURNO) REFERENCES TURNOS(ID_TURNO)
)
CREATE TABLE MEDICOXJORNADA (
    ID_MEDICO INT NOT NULL,
    ID_JORNADA INT NOT NULL,
    FOREIGN KEY (ID_MEDICO) REFERENCES Medicos(ID_MEDICO),
    FOREIGN KEY (ID_JORNADA) REFERENCES JORNADA(ID_JORNADA)
)
GO
CREATE TABLE MEDICOSXESPECIALIDAD(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_MEDICO INT NOT NULL,
	ID_ESPECIALIDAD TINYINT NOT NULL,
	FOREIGN KEY (ID_MEDICO) REFERENCES MEDICOS(ID_MEDICO),
	FOREIGN KEY (ID_ESPECIALIDAD) REFERENCES ESPECIALIDADES(ID_ESPECIALIDAD)
)
GO
-- INSERTS CON INFORMACIÓN PARA CADA TABLA
INSERT INTO ESPECIALIDADES (TIPO) VALUES ('Cardiología');
INSERT INTO ESPECIALIDADES (TIPO) VALUES ('Dermatología');
INSERT INTO ESPECIALIDADES (TIPO) VALUES ('Gastroenterología');
INSERT INTO ESPECIALIDADES (TIPO) VALUES ('Neurología');
INSERT INTO ESPECIALIDADES (TIPO) VALUES ('Oftalmología');
INSERT INTO ESPECIALIDADES (TIPO) VALUES ('Ortopedia');

INSERT INTO JORNADA (TIPO_JORNADA, HORA_INICIO, HORA_FIN)
VALUES(1, '08:00', '12:00'),
	(2, '12:00', '16:00'),
	(3, '16:00', '20:00')

INSERT INTO Horarios (HORA, DISPONIBILIDAD)
VALUES ('08:00', 1),
	('09:00', 1),
	('10:00', 1),
	('11:00', 1),
	('12:00', 1),
	('13:00', 1),
	('14:00', 1),
	('15:00', 1),
	('16:00', 1),
	('17:00', 1),
	('18:00', 1),
	('19:00', 1),
	('20:00', 1)

INSERT INTO USUARIOS (NOMBRE_USUARIO, CONTRASENA, TIPO) 
VALUES ('paciente1', '123', 'Paciente'), -- Usuarios de los pacientes
       ('paciente2', '123', 'Paciente'),
       ('paciente3', '123', 'Paciente'),
       ('paciente4', '123', 'Paciente'),
	   ('Alejandro', '123', 'Médico'), -- Usuarios de los médicos
       ('Sofia', '123', 'Médico'),
       ('Gabriel', '123', 'Médico'),
       ('Laura', '123', 'Médico'),
	   ('Martin', '123', 'Médico'),
       ('Carla', '123', 'Médico'),
       ('Javier', '123', 'Médico'),
       ('Valeria', '123', 'Médico'),
       ('Lucas', '123', 'Médico'),
       ('Maria', '123', 'Médico'),
	   ('Admin', '123', 'Administrador'), -- Administrador
	   ('Recepcionista', '123', 'Recepcionista') -- Recepcionista

INSERT INTO PACIENTES (ID_USUARIO, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO)
VALUES (1, 'Paciente1', 'Apellido1', '1234567891', 'Dirección1', '1990-01-01', 'paciente1@mail.com', 1),
       (2, 'Paciente2', 'Apellido2', '1234567892', 'Dirección2', '1990-02-02', 'paciente2@mail.com', 1),
       (3, 'Paciente3', 'Apellido3', '1234567893', 'Dirección3', '1990-03-03', 'paciente3@mail.com', 1),
       (4, 'Paciente4', 'Apellido4', '1234567894', 'Dirección4', '1990-04-04', 'paciente4@mail.com', 1)

INSERT INTO MEDICOS (ID_USUARIO, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO)
VALUES (5, 'Alejandro', 'Gómez', '9876543211', 'Calle 123, Ciudad A', '1980-01-01', 'alejandro.gomez@mail.com', 1),
       (6, 'Sofía', 'Martínez', '9876543212', 'Avenida Principal, Ciudad B', '1980-02-02', 'sofia.martinez@mail.com', 1),
       (7, 'Gabriel', 'López', '9876543213', 'Carrera 45, Ciudad C', '1980-03-03', 'gabriel.lopez@mail.com', 1),
       (8, 'Laura', 'Hernández', '9876543214', 'Calle Principal, Ciudad D', '1980-04-04', 'laura.hernandez@mail.com', 1),
	   (9, 'Martín', 'Díaz', '9876543215', 'Avenida 56, Ciudad E', '1980-05-05', 'martin.diaz@mail.com', 1),
       (10, 'Carla', 'Ramírez', '9876543216', 'Calle 78, Ciudad F', '1980-06-06', 'carla.ramirez@mail.com', 1),
       (11, 'Javier', 'Pérez', '9876543217', 'Carrera 89, Ciudad G', '1980-07-07', 'javier.perez@mail.com', 1),
       (12, 'Valeria', 'Sánchez', '9876543218', 'Avenida 10, Ciudad H', '1980-08-08', 'valeria.sanchez@mail.com', 1),
       (13, 'Lucas', 'Gutiérrez', '9876543219', 'Calle 34, Ciudad I', '1980-09-09', 'lucas.gutierrez@mail.com', 1),
       (14, 'María', 'Ortega', '9876543220', 'Avenida 22, Ciudad J', '1980-10-10', 'maria.ortega@mail.com', 1);

INSERT INTO TURNOS (ID_MEDICO, ID_PACIENTE, ID_HORARIO, FECHA, ESTADO) 
VALUES 
    (1, 1, 1, '2023-11-11', 'Reservado'),
    (2, 1, 2, '2023-11-12', 'Reservado'),
    (3, 1, 3, '2023-11-13', 'Reservado'),
    (3, 2, 4, '2023-11-14', 'Reservado'),
    (4, 2, 5, '2023-11-15', 'Reservado'),
    (5, 3, 6, '2023-11-16', 'Reservado'),
    (6, 1, 7, '2023-11-17', 'Reservado'),
    (7, 2, 8, '2023-11-18', 'Reservado'),
    (8, 4, 9, '2023-11-19', 'Reservado'),
    (9, 4, 10, '2023-11-20', 'Reservado'),
    (10, 4, 11, '2023-11-21', 'Reservado');


INSERT INTO OBSERVACIONES (ID_TURNO, OBSERVACION) -- 1 x cada turno 
VALUES
    (1, 'El paciente presentó mejoras significativas.'),
    (2, 'Se recomienda realizar pruebas adicionales para evaluar la condición del paciente.'),
    (3, 'El tratamiento actual está mostrando resultados positivos.'),
    (4, 'El paciente necesita seguir con el tratamiento según lo indicado.'),
    (5, 'Se observaron síntomas preocupantes durante la consulta.'),
    (6, 'El médico sugiere ajustar la medicación del paciente.'),
    (7, 'Se discutieron posibles cambios en el plan de tratamiento.'),
    (8, 'El paciente informó de efectos secundarios leves, se monitoreará.'),
    (9, 'Es necesario programar un seguimiento para evaluar progresos.'),
    (10, 'El médico proporcionó recomendaciones para mejorar la salud general del paciente.')

INSERT INTO MEDICOSXESPECIALIDAD (ID_MEDICO, ID_ESPECIALIDAD)
VALUES (1, 1), -- Especialidad 1
  	   (2, 1),
       (3, 1),
       (4, 2), -- Especialidad 2
       (5, 2),
	   (6, 2),
	   (7, 3), -- Especialidad 3
	   (8, 3),
	   (9, 3),
	   (10, 4), -- Especialidad 4
	   (1, 4),
  	   (2, 4),
       (3, 5), -- Especialidad 5
       (4, 5),
       (5, 5),
	   (1, 6) -- Especialidad 6

INSERT INTO MEDICOXJORNADA(ID_MEDICO, ID_JORNADA)
VALUES (1, 1), -- Trabajan de mañana
       (2, 1),
       (3, 1), 
       (4, 1),
	   (5, 1),
	   (6, 1),
	   (7, 2), -- Trabajan de tarde
	   (8, 2),
	   (9, 2),
	   (10,2),
	   (1, 2), -- Trabajan de noche
       (2, 3),
       (3, 3), 
       (4, 3),
	   (5, 3)