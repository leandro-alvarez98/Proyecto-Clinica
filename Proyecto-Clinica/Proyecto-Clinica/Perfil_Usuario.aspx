﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Perfil_Usuario.aspx.cs" Inherits="Proyecto_Clinica.Perfil_Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container form_top containerbott ">
        <div class="row">
            <%--comienzo de la card--%>
            <div class="card">
                <div class="card-body">
                    <h1 class="card-title text-center">Perfil de Usuario</h1>
                    <hr />
                   <%-- foto del perfil--%>
                    <div class="col-md-9">
                        <asp:Image ID="imgPerfil" runat="server" CssClass="img-fluid mb-3" ImageUrl="img/user.png" Style="width: 400px; height: 400px;" IsPostBack="true" />
                        <input type="file" id="txtImagen" class="form-control" runat="server" />
                        <br />
                        <asp:Button ID="btn_CambiarImagen" CssClass="Boton" runat="server" Text="Confirmar Imagen" OnClick="btn_CambiarImagen_Click" Visible="true" />
                        <asp:Label ID="lbl_Error_Imagen" runat="server" Text="Hubo un error al cargar la imagen, asegurese que sea .jpg de tamaño menor a 5 mb" Visible="false"></asp:Label>
                    </div>
                    <hr />
                    <%--listado de datos del perfil--%>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Nombres: "></asp:Label>
                            <asp:Label ID="nombrelbl" CssClass="lbl" runat="server"></asp:Label>
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

                    <div class="mb-2 ">
                        <br />
                        <asp:Button ID="btnEditarDatos" CssClass="Boton" runat="server" Text="Editar Datos" OnClick="btnEditar_Click" />
                        <asp:Button ID="btnGuardar" CssClass="Boton" runat="server" Text="Guardar Cambios" OnClick="btnGuardar_Click" Visible="false" />
                        <asp:Button ID="btnCancelar" CssClass="Boton" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Visible="false" />
                        <asp:Button ID="btnCambioContraseña" CssClass="Boton" runat="server" Text="Cambiar Contraseña" PostBackUrl="CambiarContraseña.aspx" />
                        <br />
                    </div>
                </div>
            </div>
          
        </div>
    </div>

</asp:Content>
