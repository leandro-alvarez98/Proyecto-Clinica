using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Clinica.Dominio
{
    public class Medico
    {
        public int Id { get; set; }
        public List<Especialidad> Especialidades { get; set; }
        public List<Turno> Turnos { get; set; }
    }
}