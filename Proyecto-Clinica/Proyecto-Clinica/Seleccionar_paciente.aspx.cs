using Conexion_Clinica;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class Seleccionar_paciente : System.Web.UI.Page
    {
        Paciente paciente_seleccionado;
        ClinicaConexion clinicaConexion;
        Clinica clinica;
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_componentes();
        }
        public void Cargar_componentes()
        {
            clinicaConexion = new ClinicaConexion();
            clinica = new Clinica();
            clinica = clinicaConexion.Listar();
           
            string Dni = txtDni.Text;
            DGV_Paciente.DataSource = clinica.Pacientes;
            DGV_Paciente.DataBind();

            // paciente_seleccionado = Buscar_Paciente(Dni);
            //if (paciente_seleccionado != null)
            //{
            //    DGV_Paciente.DataSource = clinica.Pacientes;
            //    DGV_Paciente.DataBind();
            //    lblnoseencuentra.Text = "";
            //}
            //else
            //{
            //    lblnoseencuentra.Text = "No se encontro ningun usuario con el dni : " + Dni;
            //}



        }
        //public Paciente Buscar_Paciente(string Dni)
        //{
        //    try
        //    {
        //        foreach (Paciente paciente in clinica.Pacientes)
        //        {
        //            if (paciente.dni == Dni)
        //            {
        //                return paciente;
        //            }
        //        }
        //        return new Paciente();
        //    }
        //    catch (Exception)
        //    {
        //        // si no hay un usuario con ese dni ...
        //        throw;
        //    }
        //}

        public void SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = DGV_Paciente.SelectedRow.Cells[0].Text;
            string nombre = DGV_Paciente.SelectedRow.Cells[1].Text;
            string apellido = DGV_Paciente.SelectedRow.Cells[2].Text;
            string direccion = DGV_Paciente.SelectedRow.Cells[3].Text;
            string mail = DGV_Paciente.SelectedRow.Cells[4].Text;
            string estado = DGV_Paciente.SelectedRow.Cells[5].Text;
            string id_usuario = DGV_Paciente.SelectedRow.Cells[6].Text;

            paciente_seleccionado.Id = int.Parse(id);
            paciente_seleccionado.Nombre = nombre;
            paciente_seleccionado.Apellido = apellido;
            paciente_seleccionado.Direccion = direccion;
            paciente_seleccionado.Mail = mail;
           // paciente_seleccionado.Estado = (bool)estado; no se porque da error estoy quemado
            paciente_seleccionado.Id_Usuario = int.Parse(id_usuario);


            Session["Paciente"] = paciente_seleccionado;
            Response.Redirect("Confirmar_turno.aspx");
        }


    }
}