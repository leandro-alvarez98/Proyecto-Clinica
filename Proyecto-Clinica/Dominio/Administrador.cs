using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Clinica.Dominio
{
    public class Administrador
    {
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Mail { get; set; }
        public bool Estado { get; set; }

        public Administrador()
        {
            Id = -1;
            Id_Usuario = -1;
            Nombre = "No especificado";
            Dni = "No especificado";
            Apellido = "No especificado";
            Telefono = "No especificado";
            Direccion = "No especificado";
            Fecha_Nacimiento = new DateTime();
            Mail = "No especificado";
            Estado = false;
        }
    }
}
