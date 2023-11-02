<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="Proyecto_Clinica.AltaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-container w-50 p-3">
        <%-- REGISTRO DEL USUARIO --%>
        <div class="form-group">
            <asp:Label ID="lblRegistrarUsuario" runat="server" Text="Usuario"></asp:Label>
            <asp:TextBox ID="txtRegistrarUsuario" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblRegistrarContrasena" runat="server" Text="Contraseña"></asp:Label>
            <asp:TextBox ID="txtRegistrarContrasena" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblRegistrarContrasena2" runat="server" Text="Repita su contraseña"></asp:Label>
            <asp:TextBox ID="txtRegistrarContrasena2" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblRegistrarTipo" runat="server" Text="Tipo de usuario"></asp:Label>
            <asp:DropDownList ID="ddlRegistrarTipo" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lblRegistrarNombre" runat="server" Text="Su nombre"></asp:Label>
            <asp:TextBox ID="txtRegistrarNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>

</asp:Content>