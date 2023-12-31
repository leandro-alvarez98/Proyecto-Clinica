﻿using Conexion_Clinica;
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
    public partial class Medicos : System.Web.UI.Page
    {
        public Clinica clinica;
        public List<Medico> lista_Medicos_x_dni;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClinicaConexion clinicaConexion = new ClinicaConexion();
            clinica = new Clinica();
            clinica = clinicaConexion.Listar();

            if (!IsPostBack)
            { // solo se puede cargar una vez sino tira error
                repeaterMedicos.DataSource = clinica.Medicos;
                repeaterMedicos.DataBind();
            }

        }


        protected void btnEditarDatos_Click(object sender, EventArgs e)
        {
            //guardo el id del medico para asi poder utilizarlo en la proxima pagina
            string id_medico = ((System.Web.UI.WebControls.Button)sender).CommandArgument;
            int Id_Medico = int.Parse(id_medico);
            

            Session["Medico"] = Cargar_Médico_Clinica(Id_Medico);
            Response.Redirect("Editar_medicos.aspx");
        }
     
        private Medico Cargar_Médico_Clinica(int medico_id)
        {
            foreach (Medico medico in clinica.Medicos)
            {
                if (medico.Id == medico_id)
                {
                    return medico;
                }
            }
            return new Medico();
        }

        protected void Btn_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                lista_Medicos_x_dni = new List<Medico>();
                string dni_medico = txt_dni.Text;
                Cargar_Medicos_x_Dni(dni_medico);

                //limpia la grilla actual
                repeaterMedicos.DataSource = null;
                repeaterMedicos.DataBind();
                //cargar la nueva grilla de datos 
                repeaterMedicos.DataSource = lista_Medicos_x_dni;
                repeaterMedicos.DataBind();
                if (lista_Medicos_x_dni.Count() == 0)
                {
                    Lbl_sin_medicos.Visible = true;
                }
                else
                {
                    Lbl_sin_medicos.Visible = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Cargar_Medicos_x_Dni(string dni)
        {
            foreach (Medico medico in clinica.Medicos)
            {
                if(medico.Dni == dni)
                {
                    lista_Medicos_x_dni.Add(medico);
                }
            }
        }
        protected void Btn_limpiar_Click(object sender, EventArgs e)
        {
            //limpia la grilla actual
            repeaterMedicos.DataSource = null;
            repeaterMedicos.DataBind();
            //cargar la nueva grilla de datos 
            repeaterMedicos.DataSource = clinica.Medicos;
            repeaterMedicos.DataBind();
            if (clinica.Medicos.Count() != 0)
            {
                Lbl_sin_medicos.Visible = false;
            }
        }

    }
}