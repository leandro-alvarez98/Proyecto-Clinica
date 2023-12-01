<%@ Page Title="" Language="C#" MasterPageFile="~/Page_master_default.Master" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="Proyecto_Clinica.AltaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <%-- REGISTRO DEL USUARIO --%>
    <div class="container form_top containerbott" id="form_usuario">

        <h1>CREA TU CUENTA</h1>
        <hr />

        <div class="row align-items-center">
                <ul class="list-group list-group-flush">

                    <li class="list-group-item">
                        <asp:Label ID="lblRegistrarUsuario" CssClass="lbl fw-semibold" runat="server" Text="Usuario"></asp:Label>
                        <asp:TextBox ID="txtRegistrarUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                    </li>
                    <li class="list-group-item">

                        <asp:Label ID="lblRegistrarContrasena" CssClass="lbl fw-semibold" runat="server" Text="Contraseña"></asp:Label>
                        <asp:TextBox ID="txtRegistrarContrasena" runat="server" CssClass="form-control"></asp:TextBox>
                    </li>
                    <li class="list-group-item">

                        <asp:Label ID="lblRegistrarContrasena2" CssClass="lbl fw-semibold" runat="server" Text="Repita su contraseña"></asp:Label>
                        <asp:TextBox ID="txtRegistrarContrasena2" runat="server" CssClass="form-control"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Nombres: "></asp:Label>
                        <asp:TextBox ID="txtNombreEdit" runat="server" CssClass="form-control"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Apellidos: "></asp:Label>
                        <asp:TextBox ID="txtApellidoEdit" CssClass="form-control" runat="server"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="DNI: "></asp:Label>
                        <asp:TextBox ID="txtDniEdit" CssClass="form-control" runat="server"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Email: "></asp:Label>
                        <asp:TextBox ID="txtMailEdit" CssClass="form-control" runat="server"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Telefono: "></asp:Label>
                        <asp:TextBox ID="txtTelefonoEdit" CssClass="form-control" runat="server"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Dirección: "></asp:Label>
                        <asp:TextBox ID="txtDireccionEdit" CssClass="form-control" runat="server"></asp:TextBox>
                    </li>
                    <li class="list-group-item">
                        <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Fecha de Nacimiento: "></asp:Label>
                        <asp:TextBox ID="txtFechaNacimientoEdit" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                    </li>
                </ul>
            </div>
        <br />
        <asp:Button ID="btnAceptarAltaUsuario" runat="server" Text="Aceptar" CssClass="Boton" OnClick="btn_AceptarAltaUsuario_Click" />
        <asp:Label ID="lbl_Error_Registro" runat="server" CssClass="lbl" Text="Error al registrar el usuario" Visible="false"></asp:Label>
    </div>

</asp:Content>