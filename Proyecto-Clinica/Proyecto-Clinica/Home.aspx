<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Proyecto_Clinica.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <asp:GridView ID="Grilla_Usuarios" runat="server"></asp:GridView>
        <hr />
        <asp:GridView ID="Grilla_Pacientes" runat="server"></asp:GridView>
        <hr />
        <asp:GridView ID="Grilla_Medicos" runat="server"></asp:GridView>
        <hr />
        <asp:GridView ID="Grilla_Especialidades" runat="server"></asp:GridView>
        <hr />
        <asp:GridView ID="Grilla_Turnos" runat="server"></asp:GridView>
        <hr />
        <asp:GridView ID="Grilla_Observaciones" runat="server"></asp:GridView>
        <hr />
    </div>

</asp:Content>
