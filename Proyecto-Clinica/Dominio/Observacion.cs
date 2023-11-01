using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Clinica.Dominio
{
    public class Observacion
    {
        public int Id { get; set; }
        public int Id_Turno { get; set; }
        public string Descripción { get; set; }

    }
}