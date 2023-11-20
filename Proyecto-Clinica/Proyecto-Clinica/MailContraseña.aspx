<%@ Page Title="" Language="C#" MasterPageFile="~/Page_master_default.Master" AutoEventWireup="true" CodeBehind="MailContraseña.aspx.cs" Inherits="Proyecto_Clinica.MailContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container containerbott">
    <div class="row justify-content-center">
        <div class="col-6">
            <div class="mb-2">
                <asp:Label ID="lblNuevaContraseña" runat="server" Class="form-label" Text="Nueva Contraseña"></asp:Label>
                <asp:TextBox ID="txtNuevaContraseña" type="password" runat="server" CssClass="form-control" placeholder="Ingrese su nueva contraseña"></asp:TextBox>
            </div>
            <div class="mb-2">
                <asp:Label ID="lblConfirmarContraseña" runat="server" Class="form-label" Text="Vuelva a escribir su contraseña"></asp:Label>
                <asp:TextBox ID="txtConfirmarContraseña" type="password" runat="server" CssClass="form-control" placeholder="Repita su contraseña"></asp:TextBox>
            </div>
            <div class="mb-2">
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar Contraseña" CssClass="Boton" OnClick="btnEnviar_Click" />
            </div>
        </div>
    </div>
</div>

</asp:Content>
