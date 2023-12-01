using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Clinica.Dominio
{
    public class Medico
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
        public List<Especialidad> Especialidades { get; set; }
        public List<Turno> Turnos {  get; set; }
        public List<Jornada> Jornadas { get; set; }
        public String Imagen {  get; set; }
        public Medico()
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
            Imagen = "https://cdn-icons-png.flaticon.com/512/5987/5987424.png";
            Estado = false;
        }
    }
}