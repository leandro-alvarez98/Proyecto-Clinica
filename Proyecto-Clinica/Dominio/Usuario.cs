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
            Nombre = "Sin nombre";
            Contraseña = "Sin contraseña";
            Tipo = "Administrador";
        }

        public Usuario(int id, string nombre, string contraseña, string tipo)
        {
            Id = id;
            Nombre = nombre;
            Contraseña = contraseña;
            Tipo = tipo;
        }
    }

}