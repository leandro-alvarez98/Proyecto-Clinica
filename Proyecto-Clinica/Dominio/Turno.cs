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
        public int Id_Horario { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }
        public String Estado { get; set; }
        public string Nombre_Medico { get; set; }
        public string Apellido_Medico { get; set; }
        public string Nombre_Paciente { get; set; }
        public string Apellido_Paciente { get; set; }
        public string Dni_paciente {  get; set; }   
        public string Obs_paciente { get; set; }
        public string Obs_medico { get; set; }
        public string Mail_Medico { get; set; }  
        public string Mail_Paciente { get; set; }
    }
}