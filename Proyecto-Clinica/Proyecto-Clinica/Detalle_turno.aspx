<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Detalle_turno.aspx.cs" Inherits="Proyecto_Clinica.Detalle_turno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container form_top containerbott">


        <div class="card" style="width: 18rem;">

            <ul class="list-group list-group-flush">
                <li class="list-group-item">Paciente: 
                    <asp:Label ID="Lbl_nombre_paciente" runat="server" Text=""></asp:Label>
                </li>
                <li class="list-group-item">Medico:   
                    <asp:Label ID="Lbl_nombre_medico" runat="server" Text=""></asp:Label>
                </li>
                <li class="list-group-item">Fecha:   
                    <asp:Label ID="Lbl_Fecha" runat="server" Text=""></asp:Label>
                </li>
                <li class="list-group-item">Horario:  
                    <asp:Label ID="Lbl_Horario" runat="server" Text=""></asp:Label>
                </li>
                <li class="list-group-item">Id turno: 
                    <asp:Label ID="Lbl_Id_Turno" runat="server" Text=""></asp:Label>
                </li>
                <li class="list-group-item">Motivo de consulta:
                    <asp:Label ID="Lbl_motivo_consulta" runat="server" Text=""></asp:Label>
                </li>
            </ul>

            <div class="card-body">
                <h5 class="card-title">Observacion</h5>
                <p id="observacion" runat="server" class="card-text"></p>
                <textarea class="form-control" runat="server" id="Txt_Observacion" rows="3" Visible="false"></textarea>
            </div>             
        </div>

        <br />  

        <asp:Button ID="Btn_agregar_obs" CssClass="Boton" OnClick="Btn_agregar_obs_Click" runat="server" Text="Agregar Observacion" />
        <asp:Button ID="Btn_aceptar" CssClass="Boton" Onclick="Btn_aceptar_Click" runat="server" Text="Aceptar" Visible="false" />
        

    </div>
</asp:Content>
