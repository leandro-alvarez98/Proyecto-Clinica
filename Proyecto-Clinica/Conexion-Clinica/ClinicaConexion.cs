﻿using Proyecto_Clinica.Dominio;
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
                objetoClinica.Observaciones = new List<Observacion>();

                UsuarioConexion usuarioConexion = new UsuarioConexion();
                objetoClinica.Usuarios = usuarioConexion.Listar();

                PacienteConexion pacienteConexion = new PacienteConexion();
                objetoClinica.Pacientes = pacienteConexion.Listar();

                TurnoConexion turnoConexion = new TurnoConexion();
                objetoClinica.Turnos = turnoConexion.Listar();

                MedicoConexion medicoConexion = new MedicoConexion();
                objetoClinica.Medicos = medicoConexion.Listar();
                Agrupar_Especialidades_Medicos(objetoClinica.Medicos);
                Eliminar_Medicos_Repetidos(objetoClinica.Medicos);

                EspecialidadesConexion especialidadConexion = new EspecialidadesConexion();
                objetoClinica.Especialidades = especialidadConexion.Listar(); 

                ObservacionConexion observacionConexion = new ObservacionConexion();
                objetoClinica.Observaciones = observacionConexion.Listar();

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
        private List<Medico> Agrupar_Especialidades_Medicos(List<Medico> lista)
        {
            List<Medico> repetidos = Encontrar_Repetidos(lista);

            foreach (Medico actual in lista)
            {
                foreach (Medico repetido in repetidos)
                {
                    if (repetido.Id == actual.Id)
                    {
                        actual.Especialidades.Add(repetido.Especialidades[0]);
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
