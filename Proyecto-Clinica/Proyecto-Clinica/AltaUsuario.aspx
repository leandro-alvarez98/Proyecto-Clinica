<%@ Page Title="" Language="C#" MasterPageFile="~/Page_master_default.Master" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="Proyecto_Clinica.AltaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <%-- REGISTRO DEL USUARIO --%>
    <div class="container form_top containerbott" id="form_usuario">
        <h1>CREA TU CUENTA</h1>
        <hr />

        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label ID="lblRegistrarUsuario" CssClass="lbl fw-semibold" runat="server" Text="Usuario"></asp:Label>
                    <asp:TextBox ID="txtRegistrarUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="lblRegistrarContrasena" CssClass="lbl fw-semibold" runat="server" Text="Contraseña"></asp:Label>
                    <asp:TextBox ID="txtRegistrarContrasena" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="lblRegistrarContrasena2" CssClass="lbl fw-semibold" runat="server" Text="Repita su contraseña"></asp:Label>
                    <asp:TextBox ID="txtRegistrarContrasena2" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />
        <asp:Button ID="btnAceptarAltaUsuario" runat="server" Text="Aceptar" CssClass="Boton" OnClick="btn_AceptarAltaUsuario_Click" />
        <asp:Label ID="lbl_Error_Registro" runat="server" CssClass="lbl" Text="Error al registrar el usuario" Visible="false"></asp:Label>
    </div>

</asp:Content>