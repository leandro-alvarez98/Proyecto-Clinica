<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="Proyecto_Clinica.AltaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container form_usuario" id="form_usuario">
        <%-- REGISTRO DEL USUARIO --%>
        <h1>CREE UNA CUENTA</h1>
        <hr />
        <div class="form-group">
            <asp:Label ID="lblRegistrarUsuario" CssClass="lbl" runat="server" Text="Usuario"></asp:Label>
            <asp:TextBox ID="txtRegistrarUsuario"  runat="server" CssClass="form-control "></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblRegistrarContrasena" CssClass="lbl" runat="server" Text="Contraseña"></asp:Label>
            <asp:TextBox ID="txtRegistrarContrasena" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblRegistrarContrasena2" CssClass="lbl" runat="server" Text="Repita su contraseña"></asp:Label>
            <asp:TextBox ID="txtRegistrarContrasena2" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblRegistrarTipo" CssClass="lbl" runat="server" Text="Tipo de usuario"></asp:Label>
            <asp:DropDownList ID="ddlRegistrarTipo" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lblRegistrarNombre" CssClass="lbl" runat="server" Text="Su nombre"></asp:Label>
            <asp:TextBox ID="txtRegistrarNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <br />
        <asp:Button ID="Button1" runat="server" Text="Aceptar" CssClass="d-grid gap-2 col-6 mx-auto btnyo" OnClick="Button1_Click" />
    </div>

</asp:Content>