-- ELIMINAR BASE DE DATOS
	USE master
	DROP DATABASE CLINICA
	GO
	USE MASTER
	GO

-- CREACION DE LA BASE DE DATOS
	CREATE DATABASE CLINICA
	GO
	USE CLINICA
	GO
-- CREACION DE TABLAS
CREATE TABLE ESPECIALIDADES (
    ID_ESPECIALIDAD INT NOT NULL PRIMARY KEY IDENTITY(0,1),
    TIPO VARCHAR(50) NOT NULL
)
GO
CREATE TABLE JORNADAS(
    ID_JORNADA INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    TIPO_JORNADA varchar (60) not null
)
GO
CREATE TABLE HORARIOS (
    ID_HORARIO INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_JORNADA INT NOT NULL FOREIGN KEY REFERENCES JORNADAS(ID_JORNADA),
	HORA TIME NOT NULL,
	DISPONIBILIDAD BIT NOT NULL default(1)
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
	FOREIGN KEY (ID_IMAGEN) REFERENCES IMAGENES(ID_IMAGEN),
	ESTADO BIT NOT NULL DEFAULT(1)
)
GO
CREATE TABLE PACIENTES (
    ID_PACIENTE INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_USUARIO INT NULL,
	DNI VARCHAR(10) NOT NULL,
    NOMBRE VARCHAR(100) NOT NULL,
    APELLIDO VARCHAR(100) NOT NULL,
    TELEFONO VARCHAR(15) NOT NULL,
    DIRECCION VARCHAR(100) NOT NULL,
    FECHA_NACIMIENTO DATE NOT NULL CHECK(FECHA_NACIMIENTO <= GETDATE()),
    MAIL VARCHAR(50) UNIQUE NOT NULL,
    ESTADO BIT DEFAULT(1) NOT NULL,
	FOREIGN KEY (ID_USUARIO) REFERENCES USUARIOS(ID_USUARIO)
)
GO
CREATE TABLE MEDICOS (
    ID_MEDICO INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_USUARIO INT NULL,
	DNI VARCHAR(10) NOT NULL,
    NOMBRE VARCHAR(100) NOT NULL,
	APELLIDO VARCHAR(100) NOT NULL,
    TELEFONO VARCHAR(15) NOT NULL,
    DIRECCION VARCHAR(100) NOT NULL,
    FECHA_NACIMIENTO DATE NOT NULL CHECK(FECHA_NACIMIENTO <= GETDATE()),
    MAIL VARCHAR(50) UNIQUE NOT NULL,
    ESTADO BIT DEFAULT(1),
	FOREIGN KEY (ID_USUARIO) REFERENCES USUARIOS(ID_USUARIO),
)
GO
CREATE TABLE ADMINISTRADOR (
    ID_ADMINISTRADOR INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_USUARIO INT NOT NULL,
	DNI VARCHAR(10) NOT NULL,
    NOMBRE VARCHAR(100) NOT NULL,
    APELLIDO VARCHAR(100) NOT NULL,
    TELEFONO VARCHAR(15) NOT NULL,
    DIRECCION VARCHAR(100) NOT NULL,
    FECHA_NACIMIENTO DATE NOT NULL CHECK(FECHA_NACIMIENTO <= GETDATE()),
    MAIL VARCHAR(50) UNIQUE NOT NULL,
    ESTADO BIT DEFAULT(1) NOT NULL,
	FOREIGN KEY (ID_USUARIO) REFERENCES USUARIOS(ID_USUARIO)
)
GO
CREATE TABLE RECEPCIONISTA (
    ID_RECEPCIONISTA INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_USUARIO INT NOT NULL,
	DNI VARCHAR(10) NOT NULL,
    NOMBRE VARCHAR(100) NOT NULL,
    APELLIDO VARCHAR(100) NOT NULL,
    TELEFONO VARCHAR(15) NOT NULL,
    DIRECCION VARCHAR(100) NOT NULL,
    FECHA_NACIMIENTO DATE NOT NULL CHECK(FECHA_NACIMIENTO <= GETDATE()),
    MAIL VARCHAR(50) UNIQUE NOT NULL,
    ESTADO BIT DEFAULT(1) NOT NULL,
	FOREIGN KEY (ID_USUARIO) REFERENCES USUARIOS(ID_USUARIO)
)
GO
CREATE TABLE TURNOS (
    ID_TURNO INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_MEDICO INT NOT NULL,
	ID_PACIENTE INT NOT NULL,
	ID_HORARIO int not null,
	ID_ESPECIALIDAD INT NOT NULL,
	FECHA DATE not null,
	OBS_PACIENTE VARCHAR(1500) NOT NULL,
	OBS_MEDICO VARCHAR(1500) NOT NULL,
    ESTADO VARCHAR(30) CHECK (ESTADO IN ('Reservado', 'Reprogramado', 'Cancelado', 'No asisti�', 'Finalizado','Activo')),
	FOREIGN KEY (ID_MEDICO) REFERENCES MEDICOS(ID_MEDICO),
	FOREIGN KEY (ID_PACIENTE) REFERENCES PACIENTES(ID_PACIENTE),
	FOREIGN KEY (ID_HORARIO) REFERENCES HORARIOS(ID_HORARIO),
	FOREIGN KEY (ID_ESPECIALIDAD) REFERENCES ESPECIALIDADES(ID_ESPECIALIDAD)
)
GO

CREATE TABLE MEDICOXJORNADA (
    ID_MEDICO INT NOT NULL,
    ID_JORNADA INT NOT NULL,
	ESTADO BIT NOT NULL,
    FOREIGN KEY (ID_MEDICO) REFERENCES Medicos(ID_MEDICO),
    FOREIGN KEY (ID_JORNADA) REFERENCES JORNADAS(ID_JORNADA)
)
GO
CREATE TABLE MEDICOSXESPECIALIDAD(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ID_MEDICO INT NOT NULL,
	ID_ESPECIALIDAD INT NOT NULL,
	ESTADO BIT NOT NULL,
	FOREIGN KEY (ID_MEDICO) REFERENCES MEDICOS(ID_MEDICO),
	FOREIGN KEY (ID_ESPECIALIDAD) REFERENCES ESPECIALIDADES(ID_ESPECIALIDAD)
)
GO

-- INSERTS CON INFORMACI�N PARA CADA TABLA
INSERT INTO ESPECIALIDADES (TIPO) VALUES (' - Seleccione una categoria - ');
INSERT INTO ESPECIALIDADES (TIPO) VALUES ('Cardiolog�a');
INSERT INTO ESPECIALIDADES (TIPO) VALUES ('Dermatolog�a');
INSERT INTO ESPECIALIDADES (TIPO) VALUES ('Gastroenterolog�a');
INSERT INTO ESPECIALIDADES (TIPO) VALUES ('Neurolog�a');
INSERT INTO ESPECIALIDADES (TIPO) VALUES ('Oftalmolog�a');
INSERT INTO ESPECIALIDADES (TIPO) VALUES ('Ortopedia');
		------------------------------

INSERT INTO JORNADAS (TIPO_JORNADA)
VALUES('Ma�ana'), ('Tarde'), ('Noche')
		------------------------------

INSERT INTO Horarios (ID_JORNADA, HORA, DISPONIBILIDAD)
VALUES (1,'08:00', 1),
	(1,'09:00', 1),
	(1,'10:00', 1),
	(1,'11:00', 1),
	(2,'12:00', 1),
	(2,'13:00', 1),
	(2,'14:00', 1),
	(2,'15:00', 1),
	(2,'16:00', 1),
	(3,'17:00', 1),
	(3,'18:00', 1),
	(3,'19:00', 1),
	(3,'20:00', 1),
    (3,'20:30', 1),
    (3,'21:00', 1),
    (3,'22:00', 1)
		------------------------------

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
	   ('Recepcionista1', '123', 'Recepcionista') -- Recepcionista
	 
		------------------------------

INSERT INTO PACIENTES (ID_USUARIO, DNI, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO)
VALUES (1, '11111111', 'Paciente1', 'Apellido1', '1234567891', 'Direcci�n1', '1990-01-01', 'fancus4n@gmail.com', 1),
       (2, '11222222','Paciente2', 'Apellido2', '1234567892', 'Direcci�n2', '1990-02-02', 'paciente2@mail.com', 1),
       (3, '11333333','Paciente3', 'Apellido3', '1234567893', 'Direcci�n3', '1990-03-03', 'paciente3@mail.com', 1),
       (4, '11444444','Paciente4', 'Apellido4', '1234567894', 'Direcci�n4', '1990-04-04', 'paciente4@mail.com', 1)
		------------------------------


INSERT INTO MEDICOS (ID_USUARIO, DNI, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO)
VALUES (5, '22111111','Alejandro', 'G�mez', '9876543211', 'Calle 123, Ciudad A', '1980-01-01', 'alejandro.gomez@mail.com', 1),
       (6, '22111133','Sof�a', 'Mart�nez', '9876543212', 'Avenida Principal, Ciudad B', '1980-02-02', 'sofia.martinez@mail.com', 1),
       (7, '22155144','Gabriel', 'L�pez', '9876543213', 'Carrera 45, Ciudad C', '1980-03-03', 'gabriel.lopez@mail.com', 1),
       (8, '22331155','Laura', 'Hern�ndez', '9876543214', 'Calle Principal, Ciudad D', '1980-04-04', 'laura.hernandez@mail.com', 1),
	   (9, '2115566','Mart�n', 'D�az', '9876543215', 'Avenida 56, Ciudad E', '1980-05-05', 'martin.diaz@mail.com', 1),
       (10, '22188177','Carla', 'Ram�rez', '9876543216', 'Calle 78, Ciudad F', '1980-06-06', 'carla.ramirez@mail.com', 1),
       (11, '22166188','Javier', 'P�rez', '9876543217', 'Carrera 89, Ciudad G', '1980-07-07', 'javier.perez@mail.com', 1),
       (12, '22156199','Valeria', 'S�nchez', '9876543218', 'Avenida 10, Ciudad H', '1980-08-08', 'valeria.sanchez@mail.com', 1),
       (13, '22123456','Lucas', 'Guti�rrez', '9876543219', 'Calle 34, Ciudad I', '1980-09-09', 'lucas.gutierrez@mail.com', 1),
       (14, '22789654','Mar�a', 'Ortega', '9876543220', 'Avenida 22, Ciudad J', '1980-10-10', 'maria.ortega@mail.com', 1)
	   ----------------------------

INSERT INTO ADMINISTRADOR (ID_USUARIO, DNI, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO)
VALUES  (15, '122222789', 'Carlos', 'Gonz�lez', '1541234567', 'Av. Principal 123', '1980-04-12', 'carlos.gonzalez@email.com', 1)
		
	   ------------------------------

INSERT INTO RECEPCIONISTA (ID_USUARIO, DNI, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO)
VALUES  (16, '123456789', 'Laura', 'G�mez', '7755599994', 'Calle Principal 123', '1988-05-20', 'laura.gomez@email.com', 1)
		------------------------------

INSERT INTO TURNOS (ID_MEDICO, ID_PACIENTE, ID_HORARIO, ID_ESPECIALIDAD ,FECHA, OBS_PACIENTE, OBS_MEDICO, ESTADO) 
VALUES 
    (1, 1, 1, 1, '2023-11-11','Duele panza', 'El paciente present� mejoras significativas.','Reservado'),
    (2, 1, 2, 1, '2023-11-12', 'Duele cabeza', 'Se recomienda realizar pruebas adicionales para evaluar la condici�n del paciente.', 'Reservado'),
    (3, 1, 3, 1,'2023-11-13','Duele oreja','El tratamiento actual est� mostrando resultados positivos.', 'Reservado'),
    (3, 2, 4, 4,'2023-11-14','Duele ri�on','El paciente necesita seguir con el tratamiento seg�n lo indicado.' , 'Reservado'),
    (4, 2, 5, 2,'2023-11-15','Duele masticar' ,'Se observaron s�ntomas preocupantes durante la consulta.', 'Reservado'),
    (5, 3, 6, 2,'2023-11-16','Duele pensar' ,'El m�dico sugiere ajustar la medicaci�n del paciente.','Reservado'),
    (6, 1, 7, 2,'2023-11-17','Duele pesta�ear', 'Se discutieron posibles cambios en el plan de tratamiento.', 'Reservado'),
    (7, 2, 8, 3,'2023-11-18','Duele trabajar','El paciente inform� de efectos secundarios leves, se monitorear�.' , 'Reservado'),
    (8, 4, 9, 3,'2023-11-19','Duele jugar lol','Es necesario programar un seguimiento para evaluar progresos.' , 'Reservado'),
    (9, 4, 10, 3,'2023-11-20','Duele comer ensalada en navidad', 'El m�dico proporcion� recomendaciones para mejorar la salud general del paciente.','Reservado'),
    (10, 4, 11, 4,'2023-11-21', 'Duele la base de datos', 'Hay que ver la solucion', 'Reservado')
			------------------------------

INSERT INTO MEDICOSXESPECIALIDAD (ID_MEDICO, ID_ESPECIALIDAD, ESTADO)
VALUES (1, 1, 1), -- Especialidad 1
  	   (2, 1, 1),
       (3, 1, 1),
       (4, 2, 1), -- Especialidad 2
       (5, 2, 1),
	   (6, 2, 1),
	   (7, 3, 1), -- Especialidad 3
	   (8, 3, 1),
	   (9, 3, 1),
	   (10, 4, 1), -- Especialidad 4
	   (1, 4, 1),
  	   (2, 4, 1),
       (3, 5, 1), -- Especialidad 5
       (4, 5, 1),
       (5, 5, 1),
	   (1, 6, 1) -- Especialidad 6
	   		------------------------------

INSERT INTO MEDICOXJORNADA(ID_MEDICO, ID_JORNADA, ESTADO)
VALUES (1, 1, 1), -- Trabajan de ma�ana
       (2, 1, 1),
       (3, 1, 1), 
       (4, 1, 1),
	   (5, 1, 1),
	   (6, 1, 1),
	   (7, 2, 1), -- Trabajan de tarde
	   (8, 2, 1),
	   (9, 2, 1),
	   (10,2, 1),
	   (1, 2, 1), 
       (2, 3, 1), -- Trabajan de noche
       (3, 3, 1), 
       (4, 3, 1),
	   (5, 3, 1)
	   		------------------------------