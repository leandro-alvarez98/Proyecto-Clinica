﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Confirmar_turno.aspx.cs" Inherits="Proyecto_Clinica.Confirmar_turno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mb-3 container containerbott form_top ">
        <asp:Label CssClass="fs-3 font-monospace fw-semibold" runat="server" Text="Confirmar Turno"></asp:Label>
        <hr />
        <asp:GridView ID="DGVTurno_a_confirmar" runat="server" CssClass="table table-dark table-hover " AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:BoundField HeaderText="Hora" DataField="Horario" />
                <asp:BoundField HeaderText="Nombre paciente" DataField="Nombre_Paciente" />
                <asp:BoundField HeaderText="Apellido paciente" DataField="Apellido_Paciente" />
                <asp:BoundField HeaderText="Dni paciente" DataField="Dni_paciente" />
                <asp:BoundField HeaderText="Nombre medico" DataField="Nombre_Medico" />
                <asp:BoundField HeaderText="Apellido medico" DataField="Apellido_Medico" />
            </Columns>
        </asp:GridView>

        <asp:Label ID="Lbl_anadir_obs_paciente" runat="server" Text="AÑADIR TEMA DE CONSULTA"></asp:Label>
        <asp:TextBox ID="Txt_observacion_paciente" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Button ID="btn_Confirmar_Turno" runat="server" OnClick="Confirmar_turno_Click" CssClass="Boton" Text="Confirmar turno" Visible="true" />
        <br />
        <asp:Label ID="lbl_TurnoIngresado" runat="server" Text="Turno reservado correctamente!" Visible="false" ></asp:Label>
        <br />
        <asp:Label ID="lbl_TurnoMailEnviado" runat="server" Text="El mismo fue enviado a su correo electronico!" Visible="false" ></asp:Label>
        <br />
        <asp:Button ID="btn_Aceptar" runat="server" OnClick="Aceptar_Click" CssClass="Boton" Text="Aceptar" Visible="false" />
    </div>

</asp:Content>
