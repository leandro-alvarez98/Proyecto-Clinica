<%@ Page Title="" Language="C#" MasterPageFile="~/Page_master_default.Master" AutoEventWireup="true" CodeBehind="MailCambioContraseña.aspx.cs" Inherits="Proyecto_Clinica.MailCambioContraseña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container containerbott form_top">
        <h1 style="text-align: center;">Recupera tu cuenta</h1>
        <div class="row justify-content-center containerbott">
            <div class="col-6">
                <div class="mb-2">
                    <asp:Label ID="lblIngreseMail" runat="server" Class="form-label" Text="Ingrese su mail:"></asp:Label>
                    <asp:TextBox ID="txtIngresarMail" type="mail" runat="server" CssClass="form-control" placeholder="Ingrese su mail"></asp:TextBox>
                </div>
                <div class="mb-2">
                    <asp:Button ID="btnEnviarMail" runat="server" Text="Enviar Mail" CssClass="btn btn-primary" OnClick="btnEnviarMail_Click" />
                </div>
                <div class="mb-2">
                    <asp:Label ID="lblBuscarMail" runat="server" Class="form-label" Text="No recuerda su mail o usuario?"></asp:Label>
                    <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="Escriba su DNI"></asp:TextBox>
                </div>
                <div class="mb-2">
                    <asp:Button ID="btnBuscarMailUsuario" runat="server" Text="Enviar DNI" CssClass="btn btn-primary" OnClick="btnBuscarMailUsuario_Click" />
                </div>
                <div class="mb-2">
                    <asp:Label ID="lblMostrarMailUsuario" runat="server" Class="form-label" ></asp:Label>
                </div>
                <div class="mb-2">
                    <asp:Label ID="lblMostrarNombreUsuario" runat="server" Class="form-label" ></asp:Label>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
