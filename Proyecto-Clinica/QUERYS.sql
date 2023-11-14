USE CLINICA
GO
-- QUERY DE LAS ESPECIALIDADES
	SELECT ID_ESPECIALIDAD, TIPO FROM ESPECIALIDADES
-- QUERY DE LOS USUARIOS
	SELECT ID_USUARIO, NOMBRE_USUARIO, CONTRASENA, TIPO FROM USUARIOS
-- QUERY DE LOS TURNOS
	SELECT T.ID_TURNO AS IDTURNO, T.ID_MEDICO AS IDMEDICO, T.ID_PACIENTE AS IDPACIENTE, T.ID_HORARIO, T.FECHA AS FECHA, ID_HORARIO AS IDHORARIO, T.ESTADO AS ESTADO, M.NOMBRE AS MNOMBRE, M.APELLIDO AS MAPELLIDO, P.NOMBRE AS PNOMBRE, P.APELLIDO AS PAPELLIDO FROM TURNOS T INNER JOIN MEDICOS M ON M.ID_MEDICO = T.ID_MEDICO INNER JOIN PACIENTES P ON P.ID_PACIENTE = T.ID_PACIENTE
-- QUERY DE LOS PACIENTES
	SELECT ID_PACIENTE, ID_USUARIO, NOMBRE, APELLIDO, TELEFONO, DIRECCION, FECHA_NACIMIENTO, MAIL, ESTADO FROM PACIENTES
-- QUERY DE LOS MEDICOS
	SELECT M.ID_MEDICO AS ID, U.ID_USUARIO AS IDUSUARIO, M.NOMBRE AS NOMBRE, M.APELLIDO AS APELLIDO, M.TELEFONO AS TELEFONO, M.DIRECCION AS DIRECCION, M.FECHA_NACIMIENTO AS FECHANACIMIENTO, MAIL, M.ESTADO AS ESTADO,E.ID_ESPECIALIDAD AS IDESPECIALIDAD, E.TIPO AS ESPECIALIDAD FROM MEDICOS M INNER JOIN USUARIOS U ON U.ID_USUARIO = M.ID_USUARIO INNER JOIN MEDICOSXESPECIALIDAD ME ON ME.ID_MEDICO = M.ID_MEDICO INNER JOIN ESPECIALIDADES E ON E.ID_ESPECIALIDAD = ME.ID_ESPECIALIDAD
-- QUERY DE LOS HORARIOS
	SELECT ID_HORARIO, HORA, DISPONIBILIDAD FROM HORARIOS
-- QUERY DE LAS OBSERVACIONES
	SELECT ID_OBSERVACION, ID_TURNO, OBSERVACION FROM OBSERVACIONES

-- QUERY DE LOS TURNOS EN CADA Horario x M�dico En una Fecha
-- TRAE TODOS LOS HORARIOS DESOCUPADOS
DECLARE @IDMedico INT = 1
DECLARE @FechaConsulta DATE = '2023-11-11'
SELECT 
	H.ID_HORARIO AS IDHORARIO,
	H.HORA AS HORA, 
	ISNULL(T.ID_TURN, ), 
	T.ID_MEDICO AS IDMEDICO, 
	T.ESTADO AS ESTADO 
FROM HORARIOS H 
JOIN 
	MEDICOXJORNADA MJ ON H.ID_JORNADA = MJ.ID_JORNADA 
CROSS JOIN 
	(SELECT DISTINCT FECHA FROM TURNOS WHERE ID_MEDICO = @IDMedico AND FECHA = @FechaConsulta) D 
LEFT JOIN  
	TURNOS T ON H.ID_HORARIO = T.ID_HORARIO AND T.FECHA = D.FECHA AND T.ID_MEDICO = @IDMedico 
WHERE 
	MJ.ID_MEDICO = @IDMedico 
ORDER BY 
	H.HORA

-- MISMA QUERY EN UNA LINEA 
SELECT H.ID_HORARIO AS IDHORARIO, H.HORA AS HORA, T.ID_TURNO AS IDTURNO, T.ID_MEDICO AS IDMEDICO, T.ESTADO AS ESTADO FROM HORARIOS H JOIN MEDICOXJORNADA MJ ON H.ID_JORNADA = MJ.ID_JORNADA CROSS JOIN (SELECT DISTINCT FECHA FROM TURNOS WHERE ID_MEDICO = @IDMedico AND FECHA = @FechaConsulta) D LEFT JOIN  TURNOS T ON H.ID_HORARIO = T.ID_HORARIO AND T.FECHA = D.FECHA AND T.ID_MEDICO = @IDMedico WHERE MJ.ID_MEDICO = @IDMedico ORDER BY H.HORA
