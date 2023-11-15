-- ELIMINAR BASE DE DATOS
	DROP DATABASE CLINICA

	---
	select * from USUARIOS
	---


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
)
GO
CREATE TABLE HORARIOS (
    ID_HORARIO INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_JORNADA INT NOT NULL FOREIGN KEY REFERENCES JORNADA(ID_JORNADA),
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
    TIPO VARCHAR(20) NOT NULL CHECK (TIPO IN ('Administrador', 'Recepcionista', 'M�dico', 'Paciente')),
	ID_IMAGEN INT NULL,
	FOREIGN KEY (ID_IMAGEN) REFERENCES IMAGENES(ID_IMAGEN)
)
GO
CREATE TABLE PACIENTES (
    ID_PACIENTE INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_USUARIO INT NOT NULL,
	DNI INT NOT NULL,
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
	DNI INT NOT NULL,
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
    ID_ADMINISTRADOR INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_USUARIO INT NOT NULL,
	DNI INT NOT NULL,
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
	DNI INT NOT NULL,
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
    ESTADO VARCHAR(30) CHECK (ESTADO IN ('Reservado', 'Reprogramado', 'Cancelado', 'No asisti�', 'Finalizado')),
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
-- INSERTS CON INFORMACI�N PARA CADA TABLA
INSERT INTO ESPECIALIDADES (TIPO) VALUES ('Cardiolog�a');
INSERT INTO ESPECIALIDADES (TIPO) VALUES ('Dermatolog�a');
INSERT INTO ESPECIALIDADES (TIPO) VALUES ('Gastroenterolog�a');
INSERT INTO ESPECIALIDADES (TIPO) VALUES ('Neurolog�a');
INSERT INTO ESPECIALIDADES (TIPO) VALUES ('Oftalmolog�a');
INSERT INTO ESPECIALIDADES (TIPO) VALUES ('Ortopedia');

INSERT INTO JORNADA (TIPO_JORNADA)
VALUES(1), (2), (3)

INSERT INTO Horarios (ID_JORNADA, HORA, DISPONIBILIDAD)
VALUES (1,'08:00', 1),
	(1,'09:00', 1),
	(1,'10:00', 1),
	(1,'11:00', 1),
	(2,'12:00', 1),
	(2,'13:00', 1),
	(2,'14:00', 1),
	(2,'15:00', 1),
	(3,'16:00', 1),
	(3,'17:00', 1),
	(3,'18:00', 1),
	(3,'19:00', 1)

INSERT INTO USUARIOS (NOMBRE_USUARIO, CONTRASENA, TIPO) 
VALUES ('paciente1', '123', 'Paciente'), -- Usuarios de los pacientes
       ('paciente2', '123', 'Paciente'),
       ('paciente3', '123', 'Paciente'),
       ('paciente4', '123', 'Paciente'),
	   ('Alejandro', '123', 'M�dico'), -- Usuarios de los m�dicos
       ('Sofia', '123', 'M�dico'),
       ('Gabriel', '123', 'M�dico'),
       ('Laura', '123', 'M�dico'),
	   ('Martin', '123', 'M�dico'),
       ('Carla', '123', 'M�dico'),
       ('Javier', '123', 'M�dico'),
       ('Valeria', '123', 'M�dico'),
       ('Lucas', '123', 'M�dico'),
       ('Maria', '123', 'M�dico'),
	   ('Admin1', '123', 'Administrador'), -- Administrador
	   ('Admin2', '123', 'Administrador'), -- Administrador
	   ('Admin3', '123', 'Administrador'), -- Administrador
	   ('Recepcionista1', '123', 'Recepcionista'), -- Recepcionista
	   ('Recepcionista2', '123', 'Recepcionista'), -- Recepcionista
   	   ('Recepcionista3', '123', 'Recepcionista'), -- Recepcionista
	   ('Recepcionista4', '123', 'Recepcionista'), -- Recepcionista
	   ('Recepcionista5', '123', 'Recepcionista'), -- Recepcionista
	   ('Recepcionista6', '123', 'Recepcionista') -- Recepcionista



INSERT INTO PACIENTES (ID_USUARIO, DNI, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO)
VALUES (1, 11111111, 'Paciente1', 'Apellido1', '1234567891', 'Direcci�n1', '1990-01-01', 'paciente1@mail.com', 1),
       (2, 11222222,'Paciente2', 'Apellido2', '1234567892', 'Direcci�n2', '1990-02-02', 'paciente2@mail.com', 1),
       (3, 11333333,'Paciente3', 'Apellido3', '1234567893', 'Direcci�n3', '1990-03-03', 'paciente3@mail.com', 1),
       (4, 11444444,'Paciente4', 'Apellido4', '1234567894', 'Direcci�n4', '1990-04-04', 'paciente4@mail.com', 1)

INSERT INTO MEDICOS (ID_USUARIO, DNI, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO)
VALUES (5, 22111111,'Alejandro', 'G�mez', '9876543211', 'Calle 123, Ciudad A', '1980-01-01', 'alejandro.gomez@mail.com', 1),
       (6, 22111133,'Sof�a', 'Mart�nez', '9876543212', 'Avenida Principal, Ciudad B', '1980-02-02', 'sofia.martinez@mail.com', 1),
       (7, 22155144,'Gabriel', 'L�pez', '9876543213', 'Carrera 45, Ciudad C', '1980-03-03', 'gabriel.lopez@mail.com', 1),
       (8, 22331155,'Laura', 'Hern�ndez', '9876543214', 'Calle Principal, Ciudad D', '1980-04-04', 'laura.hernandez@mail.com', 1),
	   (9, 2115566,'Mart�n', 'D�az', '9876543215', 'Avenida 56, Ciudad E', '1980-05-05', 'martin.diaz@mail.com', 1),
       (10, 22188177,'Carla', 'Ram�rez', '9876543216', 'Calle 78, Ciudad F', '1980-06-06', 'carla.ramirez@mail.com', 1),
       (11, 22166188,'Javier', 'P�rez', '9876543217', 'Carrera 89, Ciudad G', '1980-07-07', 'javier.perez@mail.com', 1),
       (12, 22156199,'Valeria', 'S�nchez', '9876543218', 'Avenida 10, Ciudad H', '1980-08-08', 'valeria.sanchez@mail.com', 1),
       (13, 22123456,'Lucas', 'Guti�rrez', '9876543219', 'Calle 34, Ciudad I', '1980-09-09', 'lucas.gutierrez@mail.com', 1),
       (14, 22789654,'Mar�a', 'Ortega', '9876543220', 'Avenida 22, Ciudad J', '1980-10-10', 'maria.ortega@mail.com', 1)


	   ----------------------------
INSERT INTO RECEPCIONISTA (ID_USUARIO, DNI, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO)
VALUES  (15, 123456789, 'Laura', 'G�mez', '7755599994', 'Calle Principal 123', '1988-05-20', 'laura.gomez@email.com', 1),
		(16, 987654321, 'Carlos', 'Rodr�guez', '6549876210', 'Calle Secundaria 456', '1992-08-15', 'carlos.rodriguez@email.com', 1),
		(17, 555555555, 'Mar�a', 'Hern�ndez', '3571594674', 'Calle Nueva 789', '1985-12-10', 'maria.hernandez@email.com', 1),
		(18, 444444444, 'Javier', 'L�pez', '9632587415', 'Calle Antigua 567', '1990-03-25', 'javier.lopez@email.com', 1),
		(19, 666666666, 'Ana', 'Mart�nez', '7412568437', 'Calle Vieja 234', '1982-06-05', 'ana.martinez@email.com', 1),
		(20, 777777777, 'Pablo', 'S�nchez', '9453215684', 'Calle Moderna 789', '1995-01-15', 'pablo.sanchez@email.com', 1)


INSERT INTO ADMINISTRADOR (ID_USUARIO, DNI, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO)
VALUES  (21, 122222789, 'Carlos', 'Gonz�lez', '1541234567', 'Av. Principal 123', '1980-04-12', 'carlos.gonzalez@email.com', 1),
		(22, 987654321, 'Ana', 'L�pez', '1567890123', 'Calle Secundaria 456', '1975-09-22', 'ana.lopez@email.com', 1),
		(23, 555544555, 'Mart�n', 'Mart�nez', '1554567890', 'Av. Nueva 789', '1991-12-05', 'martin.martinez@email.com', 1)

	   ------------------------------

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
    (10, 4, 11, '2023-11-21', 'Reservado')


INSERT INTO OBSERVACIONES (ID_TURNO, OBSERVACION) -- 1 x cada turno 
VALUES
    (1, 'El paciente present� mejoras significativas.'),
    (2, 'Se recomienda realizar pruebas adicionales para evaluar la condici�n del paciente.'),
    (3, 'El tratamiento actual est� mostrando resultados positivos.'),
    (4, 'El paciente necesita seguir con el tratamiento seg�n lo indicado.'),
    (5, 'Se observaron s�ntomas preocupantes durante la consulta.'),
    (6, 'El m�dico sugiere ajustar la medicaci�n del paciente.'),
    (7, 'Se discutieron posibles cambios en el plan de tratamiento.'),
    (8, 'El paciente inform� de efectos secundarios leves, se monitorear�.'),
    (9, 'Es necesario programar un seguimiento para evaluar progresos.'),
    (10, 'El m�dico proporcion� recomendaciones para mejorar la salud general del paciente.')

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
VALUES (1, 1), -- Trabajan de ma�ana
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