<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="MisTurnos.aspx.cs" Inherits="Proyecto_Clinica.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- Esta página maneja los turnos del usuario sólo si el mismo es un Médico --%>
    <div class="container">
        <hr />
        <asp:GridView ID="dgv_Turnos" CssClass="table table-dark table-hover" runat="server">
        </asp:GridView>
    </div>

   

</asp:Content>
