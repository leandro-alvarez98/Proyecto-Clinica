using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexion_Clinica
{
    public class ClinicaConexion
    {
        public Clinica listar()
        {
            Clinica objetoClinica = new Clinica();
            try
            {
                objetoClinica.usuarios = new List<Usuario>();
                objetoClinica.pacientes = new List<Paciente>();
                objetoClinica.turnos = new List<Turno>();
                objetoClinica.medicos = new List<Medico>();
                objetoClinica.especialidades = new List<Especialidad>();

                // Primero hay que hacer los Listar() de todos los demás
                //Despues llenar las listas de Clinica con esas funciones
                UsuarioConexion usuarioConexion = new UsuarioConexion();
                objetoClinica.usuarios = usuarioConexion.listar();

                PacienteConexion pacienteConexion = new PacienteConexion();
                objetoClinica.pacientes = pacienteConexion.listar();

                TurnoConexion turnoConexion = new TurnoConexion();
                objetoClinica.turnos = turnoConexion.listar();

                MedicoConexion medicoConexion = new MedicoConexion();
                objetoClinica.medicos = medicoConexion.listar();

                EspecialidadesConexion especialidadConexion = new EspecialidadesConexion();
                objetoClinica.especialidades = especialidadConexion.Listar(); 

                return objetoClinica;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
        }
    }
}
