<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="AltaPaciente.aspx.cs" Inherits="Proyecto_Clinica.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblId" runat="server" Class="form-label" Text="Id"></asp:Label>
    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" placeholder="Ejemplo: E001"></asp:TextBox>
    <asp:Label ID="lblNombres" runat="server" Class="form-label" Text="Nombres"></asp:Label>
    <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:Label ID="lblApellidos" runat="server" Class="form-label" Text="Apellidos"></asp:Label>
    <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:Label ID="lblDireccion" runat="server" Class="form-label" Text="Direccion"></asp:Label>
    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:Label ID="lblTelefono" runat="server" Class="form-label" Text="Telefono"></asp:Label>
    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
    <asp:Label ID="LblEmail" runat="server" Class="form-label" Text="Email"></asp:Label>
    <asp:TextBox ID="TextEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
    
    <asp:Label ID="lblFechaNacimiento" runat="server" Class="form-label" Text="Fecha Nacimiento"></asp:Label>
    <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    <asp:Label ID="lblSexo" runat="server" Class="form-label" Text="Sexo"></asp:Label>
    <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control"></asp:DropDownList>

</asp:Content>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container w-50 p-3">
        <div class="form-group">
            <asp:Label ID="lblId" runat="server" Text="Id"></asp:Label>
            <asp:TextBox ID="txtId" runat="server" CssClass="form-control" placeholder="Ejemplo: E001"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblNombres" runat="server" Text="Nombres"></asp:Label>
            <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblApellidos" runat="server" Text="Apellidos"></asp:Label>
            <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblDireccion" runat="server" Text="Direccion"></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblTelefono" runat="server" Text="Telefono"></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TextEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha Nacimiento"></asp:Label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblSexo" runat="server" Text="Sexo"></asp:Label>
            <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>
</asp:Content>
