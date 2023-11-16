﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="MisTurnos.aspx.cs" Inherits="Proyecto_Clinica.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- Esta página maneja los turnos del usuario sólo si el mismo es un Médico --%>
    <%if (usuarioActual.Tipo == "Recepcionista" || usuarioActual.Tipo == "Administrador")%>
    <%{ %>
    <div class="container form_top containerbott">
        <asp:GridView ID="DGV_Turnos_totales" CssClass="table table-dark table-hover" OnSelectedIndexChanged="dgv_Turnos_SelectedIndexChanged" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Turno #" DataField="Id" />
                <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField HeaderText="Hora" DataField="Horario" />
                <asp:BoundField HeaderText="Nombre paciente" DataField="Nombre_Paciente" />
                <asp:BoundField HeaderText="Apellido paciente" DataField="Apellido_Paciente" />
                <asp:BoundField HeaderText="Nombre medico" DataField="Nombre_Medico" />
                <asp:BoundField HeaderText="Apellido medico" DataField="Apellido_Medico" />
                <asp:BoundField HeaderText="DNI Paciente" DataField="Dni_Paciente" />
                <asp:BoundField HeaderText="Estado" DataField="Estado" />
                <asp:CommandField ShowSelectButton="true" SelectText="Cancelar" HeaderText="Accion" />
                <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderText="Accion" />
            </Columns>
        </asp:GridView>
    </div>
    <% }else%>
    <% {%>
    <div class="container form_top containerbott">
        <asp:GridView ID="dgv_Turnos" CssClass="table table-dark table-hover" OnSelectedIndexChanged="dgv_Turnos_SelectedIndexChanged" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Turno #" DataField="Id" />
                <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField HeaderText="Hora" DataField="Horario" />
                <asp:BoundField HeaderText="Nombre paciente" DataField="Nombre_Paciente" />
                <asp:BoundField HeaderText="Apellido paciente" DataField="Apellido_Paciente" />
                <asp:BoundField HeaderText="Nombre medico" DataField="Nombre_Medico" />
                <asp:BoundField HeaderText="Apellido medico" DataField="Apellido_Medico" />
                <asp:BoundField HeaderText="DNI Paciente" DataField="Dni_Paciente" />
                <asp:BoundField HeaderText="Estado" DataField="Estado" />
                <asp:CommandField ShowSelectButton="true" SelectText="Cancelar" HeaderText="Accion" />
            </Columns>
        </asp:GridView>
    </div>
     <%}%>
   

   
</asp:Content>
