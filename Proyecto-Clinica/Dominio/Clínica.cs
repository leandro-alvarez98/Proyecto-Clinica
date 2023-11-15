using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Clinica.Dominio
{
    public class Clinica
    {
        /*
            Esta clase representa la entidad principal que gestiona todo el sistema. 
            Contiene listas de usuarios, pacientes, médicos y turnos. 
            Además, proporciona métodos para agregar usuarios, pacientes, médicos y turnos al sistema.
         */

        public List<Usuario> Usuarios { get; set; }
        public List<Paciente> Pacientes { get; set; }
        public List<Medico> Medicos { get; set; }
        public List<Recepcionista> Recepcionistas { get; set; }
        public List<Administrador> Administracion { get; set; }             
        public List<Turno> Turnos { get; set; }
        public List<Especialidad> Especialidades { get; set; }
        public List<Observacion> Observaciones {  get; set; }
        public List <Horario> Horarios { get; set; }
    }
}