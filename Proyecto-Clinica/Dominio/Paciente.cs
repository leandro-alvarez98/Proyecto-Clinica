using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Clinica.Dominio
{
    public class Paciente
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string direccion {  get; set; }
        public DateTime fecha_nacimiento {  get; set; }
        public string mail {  get; set; }
        public bool estado { get; set; }
        public List<Observacion> Observaciones { get; set; }
    }
}