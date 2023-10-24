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

        public List<Usuario> usuarios = new List<Usuario>();
        public List<Paciente> pacientes = new List<Paciente>();
        public List<Medico> medicos = new List<Medico>();
        public List<Turno> turnos = new List<Turno>();

        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public void AgregarPaciente(Paciente paciente)
        {
            pacientes.Add(paciente);
        }

        public void AgregarMedico(Medico medico)
        {
            medicos.Add(medico);
        }

        public void AgregarTurno(Turno turno)
        {
            turnos.Add(turno);
        }
    }
}