using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Clinica.Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string Tipo { get; set; }

        public Usuario()
        {
            Id = -1;
            Nombre = "No especificado";
            Contraseña = "No especificado";
            Tipo = "No especificado";
        }
    }
}