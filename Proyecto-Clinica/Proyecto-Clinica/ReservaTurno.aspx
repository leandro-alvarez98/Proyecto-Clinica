<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="ReservaTurno.aspx.cs" Inherits="Proyecto_Clinica.ReservaTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mb-3 container containerbott form_top ">

        <h3>Reservar Turno</h3>
        <hr />

        <%-- Especialidades --%>
        <asp:DropDownList ID="DDL_especialidades" CssClass="form-select" runat="server"></asp:DropDownList>
        <hr />

        <%-- Fecha --%>
        <div class="mb-3">
            <asp:Calendar ID="Calendario" runat="server"></asp:Calendar>
        </div>

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="btn btn-secondary " Text="Buscar Turnos" />

        <%-- Grilla con todos los turnos disponibles --%>
        <div>
            <asp:GridView ID="Grilla_turnos_disponibles" runat="server"></asp:GridView>
        </div>
    </div>

</asp:Content>
