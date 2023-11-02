<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="Proyecto_Clinica.Default"
 %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card">
        <div class="card-body">
            <h1 class="card-title">Perfil de Usuario</h1>
            <p><strong>Nombre:</strong>
                <asp:Label ID="lblNombre" runat="server"></asp:Label></p>

            <p><strong>Apellido:</strong>
                <asp:Label ID="apellidoLabel" runat="server"></asp:Label></p>
            <p><strong>Correo Electrónico:</strong>
                <asp:Label ID="emailLabel" runat="server"></asp:Label></p>
            <p><strong>Teléfono:</strong>
                <asp:Label ID="telefonoLabel" runat="server"></asp:Label></p>
            <p><strong>Dirección:</strong>
                <asp:Label ID="direccionLabel" runat="server"></asp:Label></p>
            <p><strong>Fecha de Nacimiento:</strong>
                <asp:Label ID="fechaNacimientoLabel" runat="server"></asp:Label></p>
        </div>
    </div>
    <div class="mb-2">
    <asp:Button ID="btnEditarDatos" class="btn btn-primary" runat="server" Text="Editar Datos"  />
    </div>
    <div class="mb-2">
    <asp:Button ID="btnCambioContraseña" class="btn btn-primary" runat="server" Text="Cambiar Contraseña"  />
    </div>



</asp:Content>
