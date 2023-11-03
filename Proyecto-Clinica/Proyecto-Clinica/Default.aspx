<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Proyecto_Clinica.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <%-- Labels y TextBoxs --%>
    <div class="container containerbott form_top">
        <h1 style="text-align: center;">Ingreso al Portal de Salud</h1>
        <div class="row justify-content-center">
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
                    <asp:Button ID="btnIngresar" class="btn btn-primary" runat="server" OnClick="btnIngresar_Click" Text="Ingresar"  />
                </div>
                <a href="MailCambioContraseña.aspx">¿Olvidaste tu contraseña?</a>
                <div class="mb-2">
                    <asp:Label ID="lblRegistrar" runat="server" Class="form-label" Text="¿No poseé una cuenta? Registrese."></asp:Label>
                </div>
                <div>
                    <asp:Button ID="btnRegistrar" class="btn btn-primary" runat="server" Text="Registrarme" PostBackUrl="AltaUsuario.aspx"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>