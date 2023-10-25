<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto_Clinica.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblUsuario" runat="server" Class="form-label" Text="Usuario"></asp:Label>
    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Nombre de Usuario"></asp:TextBox>
    <asp:Label ID="lblContraseña" runat="server" Class="form-label" Text="Contraseña"></asp:Label>
    <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" placeholder="Ingrese su Contraseña"></asp:TextBox>
    
    <%--<asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btn_ingresar_Click" />
    <asp:Button ID="btnOlvidoContraseña" runat="server" Text="Olvide mi Contraseña" OnClick="btn_OlvidoContraseña_Click" />--%>
</asp:Content>
