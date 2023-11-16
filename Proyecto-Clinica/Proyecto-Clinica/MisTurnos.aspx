<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="MisTurnos.aspx.cs" Inherits="Proyecto_Clinica.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- Esta página maneja los turnos del usuario sólo si el mismo es un Médico --%>
    <div class="container form_top containerbott">        
        <asp:GridView ID="dgv_Turnos" CssClass="table table-dark table-hover" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Turno #" DataField="Id" />
                <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField HeaderText="Hora" DataField="Horario" />
                <asp:BoundField HeaderText="Paciente" DataField="Apellido_Paciente" />
                <asp:BoundField HeaderText="DNI Paciente" DataField="Dni_Paciente" />
                <asp:BoundField HeaderText="Estado" DataField="Estado" />
                <asp:CommandField ShowSelectButton="true" SelectText="seleccionar" HeaderText="Accion" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
