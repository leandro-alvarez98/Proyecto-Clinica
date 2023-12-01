using Dominio;
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
        public Clinica Listar()
        {
            Clinica objetoClinica = new Clinica();
            try
            {
                objetoClinica.Usuarios = new List<Usuario>();
                objetoClinica.Pacientes = new List<Paciente>();
                objetoClinica.Turnos = new List<Turno>();
                objetoClinica.Medicos = new List<Medico>();
                objetoClinica.Especialidades = new List<Especialidad>();
                objetoClinica.Horarios = new List<Horario>();
                objetoClinica.Administracion = new List<Administrador>();
                objetoClinica.Recepcionistas = new List<Recepcionista>();
                objetoClinica.Jornadas = new List<Jornada>();

                UsuarioConexion usuarioConexion = new UsuarioConexion();
                objetoClinica.Usuarios = usuarioConexion.Listar();

                PacienteConexion pacienteConexion = new PacienteConexion();
                objetoClinica.Pacientes = pacienteConexion.Listar();

                TurnoConexion turnoConexion = new TurnoConexion();
                objetoClinica.Turnos = turnoConexion.Listar();

                MedicoConexion medicoConexion = new MedicoConexion();
                objetoClinica.Medicos = medicoConexion.Listar();
                Agrupar_Medicos(objetoClinica.Medicos);
                Eliminar_Medicos_Repetidos(objetoClinica.Medicos);

                EspecialidadesConexion especialidadConexion = new EspecialidadesConexion();
                objetoClinica.Especialidades = especialidadConexion.Listar(); 

                HorarioConexion horarioConexion = new HorarioConexion();
                objetoClinica.Horarios = horarioConexion.Listar();

                AdministradorConexion administradorConexion = new AdministradorConexion();
                objetoClinica.Administracion = administradorConexion.Listar();

                RecepcionistaConexion recepcionistaConexion = new RecepcionistaConexion();
                objetoClinica.Recepcionistas = recepcionistaConexion.Listar();

                JornadaConexion jornadaConexion = new JornadaConexion();
                objetoClinica.Jornadas = jornadaConexion.Listar();

                return objetoClinica;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
        }

        private List<Medico> Encontrar_Repetidos(List<Medico> lista)
        {
            var articulosAgregados = new HashSet<int>();
            List<Medico> repetidos = new List<Medico>();
            foreach (Medico actual in lista)
            {
                if (!articulosAgregados.Contains(actual.Id))
                {
                    articulosAgregados.Add(actual.Id);
                }
                else
                {
                    repetidos.Add(actual);
                }
            }
            return repetidos;
        }
        private List<Medico> Agrupar_Medicos(List<Medico> lista) // Agrupa especialidades y Jornadas de un médico
        {
            List<Medico> repetidos = Encontrar_Repetidos(lista);

            foreach (Medico actual in lista)
            {
                foreach (Medico repetido in repetidos)
                {
                    if (repetido.Id == actual.Id)
                    {
                        if (!actual.Especialidades.Any(e => e.Id == repetido.Especialidades[0].Id))
                            actual.Especialidades.Add(repetido.Especialidades[0]);
                        
                        if(!actual.Jornadas.Any(j => j.Id == repetido.Jornadas[0].Id))
                            actual.Jornadas.Add(repetido.Jornadas[0]);
                    }
                }
            }
            return lista;
        }
        private void Eliminar_Medicos_Repetidos(List<Medico> lista)
        {
            List<Medico> repetidos = Encontrar_Repetidos(lista);
            foreach (Medico repetido in repetidos)
            {
                lista.Remove(repetido);
            }
        }

    }
}
