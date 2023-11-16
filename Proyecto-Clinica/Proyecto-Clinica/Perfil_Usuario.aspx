<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Perfil_Usuario.aspx.cs" Inherits="Proyecto_Clinica.Perfil_Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container form_top containerbott">
        <div class="card">
            <div class="card-body ">
                <h1 class="card-title">Perfil de Usuario</h1>
                <hr />
                <div class="card " style="width: 40rem;">
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Nombres: "></asp:Label>
                            <asp:Label ID="nombrelbl" CssClass="lbl" runat="server"></asp:Label>
                            <%-- <asp:TextBox ID="txtNombreEdit" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>--%>
                            <asp:TextBox ID="txtNombreEdit" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                        </li>
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Apellidos: "></asp:Label>
                            <asp:Label ID="apellidoLbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtApellidoEdit" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                        </li>
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="DNI: "></asp:Label>
                            <asp:Label ID="dniLbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtDniEdit" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                        </li>
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Email: "></asp:Label>
                            <asp:Label ID="emailLbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtMailEdit" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                        </li>
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Telefono: "></asp:Label>
                            <asp:Label ID="telefonoLbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtTelefonoEdit" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                        </li>
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Dirección: "></asp:Label>
                            <asp:Label ID="direccionLbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtDireccionEdit" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                        </li>
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Fecha de Nacimiento: "></asp:Label>
                            <asp:Label ID="fechaNacimientoLbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtFechaNacimientoEdit" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                        </li>
                    </ul>

                    <div class="mb-2">
                        <asp:Button ID="btnEditarDatos" class="btn btn-primary" runat="server" Text="Editar Datos" OnClick="btnEditar_Click" />
                        <asp:Button ID="btnGuardar" class="btn btn-primary" runat="server" Text="Guardar Cambios" OnClick="btnGuardar_Click" Visible="false" />
                        <asp:Button ID="btnCancelar" class="btn btn-primary" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Visible="false" />


                    </div>

                    <div class="mb-2">
                        <asp:Button ID="btnCambioContraseña" class="btn btn-primary" runat="server" Text="Cambiar Contraseña" PostBackUrl="CambiarContraseña.aspx" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
