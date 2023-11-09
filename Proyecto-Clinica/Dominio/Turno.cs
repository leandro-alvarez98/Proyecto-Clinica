using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Proyecto_Clinica.Dominio
{
    public class Turno
    {
        public int Id { get; set; }
        public int Id_Medico { get; set; }
        public int Id_Paciente { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }  
        public TimeSpan HoraFin { get; set; }
        public String Estado { get; set; }
        public string Nombre_Medico { get; set; }
        public string Apellido_Medico { get; set; }
        public string Nombre_Paciente { get; set; }
        public string Apellido_Paciente { get; set; }

    }
}