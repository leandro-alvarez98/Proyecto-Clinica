using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Clinica.Dominio
{
    public class Observacion
    {
        public int id_Paciente { get; set; }
        public int id_Medico { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
    }
}