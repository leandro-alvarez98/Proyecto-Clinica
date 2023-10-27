using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Clinica.Dominio
{
    public class Medico
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string mail { get; set; }
        public bool estado { get; set; } // 0 = Inactivo, 1 = Activo
        public List<Especialidad> Especialidades { get; set; }
        public List<Turno> Turnos { get; set; }
    }
}