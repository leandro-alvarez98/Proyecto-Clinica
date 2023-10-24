using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Clinica.Dominio
{
    public class Paciente
    {
        public int Id { get; set; }
        public List<Observacion> Observaciones { get; set; }
    }
}