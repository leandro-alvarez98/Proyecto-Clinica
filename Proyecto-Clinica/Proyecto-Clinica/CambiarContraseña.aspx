<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="CambiarContraseña.aspx.cs" Inherits="Proyecto_Clinica.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblNuevaContraseña" runat="server" Class="form-label" Text="Nueva Contraseña"></asp:Label>
    <asp:TextBox ID="txtNuevaContraseña" runat="server" CssClass="form-control" placeholder="Ingrese su nueva contraseña"></asp:TextBox>
    <asp:Label ID="lblConfirmarContraseña" runat="server" Class="form-label" Text="Vuelva a escribir su contraseña"></asp:Label>
    <asp:TextBox ID="txtConfirmarContraseña" runat="server" CssClass="form-control" placeholder="Repita su contraseña"></asp:TextBox>
    <asp:Button ID="btnEnviar" runat="server" Text="Enviar Contraseña" CssClass="btn btn-primary"  />

    





    <%--<asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btn_ingresar_Click" />
    <asp:Button ID="btnOlvidoContraseña" runat="server" Text="Olvide mi Contraseña" OnClick="btn_OlvidoContraseña_Click" />--%>
</asp:Content>
