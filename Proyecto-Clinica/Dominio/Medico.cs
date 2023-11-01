using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Clinica.Dominio
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Mail { get; set; }
        public bool Estado { get; set; } // 0 = Inactivo, 1 = Activo
        public List<Especialidad> Especialidades { get; set; }
    }
}