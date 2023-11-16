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
        Paciente paciente_buscado;
        List<Paciente> ps;
        Clinica clinica;
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
            string nombre = DGV_Paciente.SelectedRow.Cells[1].Text;
            string apellido = DGV_Paciente.SelectedRow.Cells[2].Text;
            string dni = DGV_Paciente.SelectedRow.Cells[3].Text;
            
            
            Turno turno = (Turno)Session["Turno"];

            turno.Id_Paciente = int.Parse(id);
            turno.Nombre_Paciente = nombre;
            turno.Apellido_Paciente = apellido;
            turno.Dni_paciente = dni;

            Session["Turno"] = turno;
            Response.Redirect("Confirmar_turno.aspx");
        }
    }
}