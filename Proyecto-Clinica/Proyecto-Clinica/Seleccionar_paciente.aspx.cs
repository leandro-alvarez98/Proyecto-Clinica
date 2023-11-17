using Conexion_Clinica;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class Seleccionar_paciente : System.Web.UI.Page
    {
        Clinica clinica;
        Paciente paciente_buscado;
        List<Paciente> ps;
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_componentes();
        }
        public void Cargar_componentes()
        {
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            clinica = new Clinica();
            clinica = clinicaConexion.Listar();
        }
        public Paciente Buscar_Paciente(string Dni)
        {
              foreach (Paciente paciente in clinica.Pacientes)              {
                  if (paciente.Dni == Dni)
                  {
                      return paciente;
                  }
              }
              return new Paciente();       
        }
        public Paciente Buscar_Paciente(int ID)
        {
            foreach (Paciente paciente in clinica.Pacientes)
            {
                if (paciente.Id == ID)
                {
                    return paciente;
                }
            }
            return new Paciente();
        }
        protected void buscar_paciente_Click(object sender, EventArgs e)
        {
            ps = new List<Paciente>();
            paciente_buscado = new Paciente();

            string Dni = txtDni.Text;
            paciente_buscado = Buscar_Paciente(Dni);
            ps.Add(paciente_buscado);
            DGV_Paciente.DataSource = ps;
            DGV_Paciente.DataBind();          
        }
        protected void DGV_Paciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = DGV_Paciente.SelectedRow.Cells[0].Text;
            Paciente paciente = Buscar_Paciente(int.Parse(id));

            Turno Turno_Seleccionado = (Turno)Session["Turno"];
            Turno_Seleccionado.Id_Paciente = int.Parse(id);
            Turno_Seleccionado.Nombre_Paciente = paciente.Nombre;
            Turno_Seleccionado.Apellido_Paciente = paciente.Apellido;
            Turno_Seleccionado.Dni_paciente = paciente.Dni;

            Session["Turno"] = Turno_Seleccionado;
            Response.Redirect("Confirmar_turno.aspx");
        }
    }
}