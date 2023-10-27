<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Proyecto_Clinica.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--//labels y texbox--%>
    <div class="container">
        <h1>Ingreso al Portal de Salud</h1>
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <asp:Label ID="lblUsuario" runat="server" Class="form-label" Text="Usuario"></asp:Label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Nombre de Usuario"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblContraseña" runat="server" Class="form-label" Text="Contraseña"></asp:Label>
                    <asp:TextBox ID="txtContraseña" type="password" runat="server" CssClass="form-control" placeholder="Ingrese su Contraseña"></asp:TextBox>
                </div>
                <div class="mb-2">
                    <asp:Button ID="btnIngresar" class="btn btn-primary" runat="server" Text="Ingresar" />
                </div>
                
                <a href="CambiarContraseña.aspx">¿Olvidaste tu contraseña?</a>
                <div class="mb-2">
                    <asp:Label ID="lblRegistrar" runat="server" Class="form-label" Text="¿No poseé una cuenta? Registrese."></asp:Label>
                </div>
                <div>
                    <asp:Button ID="btnRegistrar" class="btn btn-primary" runat="server" Text="Registrarme" PostBackUrl="AltaPaciente.aspx"/>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
