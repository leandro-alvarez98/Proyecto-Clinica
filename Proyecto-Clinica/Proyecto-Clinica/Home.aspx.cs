using Conexion_Clinica;
using Proyecto_Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class Home : System.Web.UI.Page
    {
        Clinica clinica;
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_Componentes();
        }
        public void Cargar_Componentes()
        {
            clinica = new Clinica();
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            clinica = clinicaConexion.Listar();
            Session["Clinica"] = clinica; //Esto contiene toda la información en caso de ser necesaria para checkear algo.


            // GRILLAS PARA VER INFORMACION
            Grilla_Usuarios.DataSource = clinica.Usuarios;
            Grilla_Pacientes.DataSource = clinica.Pacientes;
            Grilla_Medicos.DataSource = clinica.Medicos;
            Grilla_Especialidades.DataSource = clinica.Especialidades;
            Grilla_Turnos.DataSource = clinica.Turnos;
           

            Grilla_Usuarios.DataBind();
            Grilla_Pacientes.DataBind();
            Grilla_Medicos.DataBind();
            Grilla_Especialidades.DataBind();
            Grilla_Turnos.DataBind();
            
             

        }

        // ESTA FUNCION MUESTRA QUE LA LISTA DE MEDICOS ESTÉ CARGADA CORRECTAMENTE. LO ESTÁ ;) 
        //public void Prueba()
        //{
        //    foreach(Medico actual in clinica.Medicos)
        //    {
        //        foreach (Especialidad espactual in actual.Especialidades)
        //        {
        //            MessageBox.Show("Medico" + actual.Id +" Especialidad: "+  espactual.Tipo);
        //        }
        //    }
        //}
    }
}