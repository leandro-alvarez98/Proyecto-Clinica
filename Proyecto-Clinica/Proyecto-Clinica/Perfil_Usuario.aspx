<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Perfil_Usuario.aspx.cs" Inherits="Proyecto_Clinica.Perfil_Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    .lbl_error {
        color: red;
    }
</style>

    <%-- referencia a la carpeta JS que contiene los script --%>
    <script type="text/javascript" src="JS/JavaScript.js"></script>

    <div class="container form_top containerbott ">
        <div class="row">
            <div class="card">
                <div class="card-body">
                    <h1 class="card-title text-center fs-1 font-monospace">Perfil de Usuario</h1>
                    <hr />
                   <%-- Imagen del perfil--%>
                    <div class="col-md-9">
                        <asp:Image ID="imgPerfil" runat="server" CssClass="img-fluid mb-3" Style="width: 400px; height: 400px;" IsPostBack="true" />
                        <li class="list-group-item">

                            <asp:Label ID="lblnombreUsuario" CssClass="fs-4 font-monospace" runat="server" Text="Username: " Visible="false"></asp:Label>
                            <asp:Label ID="lblUsername"  CssClass="lbl " runat="server" Font-Bold="True" Visible="true" ></asp:Label>
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Visible="false" MaxLength="100"></asp:TextBox>
                            <asp:Label ID="errorUsername" CssClass="lbl lbl_error" Text="El username ya existe" runat="server" Visible="false"></asp:Label>
                        </li>
                        <br />
                        <input type="file" id="txtImagen" class="form-control" runat="server" visible="true"/>
                        <br />
                        <asp:Button ID="btn_CambiarImagen" CssClass="Boton" runat="server" Text="Confirmar Imagen" OnClick="btn_CambiarImagen_Click" Visible="true" />
                        <asp:Label ID="lbl_Error_Imagen" runat="server" Text="Hubo un error al cargar la imagen, asegurese que sea .jpg de tamaño menor a 5 mb" Visible="false"></asp:Label>
                    </div>
                    <hr />

                    <%-- Datos del perfil--%>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Nombres: "></asp:Label>
                            <asp:Label ID="nombrelbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtNombreEdit" runat="server" CssClass="form-control" Visible="false" MaxLength="100"></asp:TextBox>
                            <asp:Label ID="lblErrorNombre" CssClass="lbl lbl_error" Text="El nombre solo debe contener letras" runat="server" Visible="false" ></asp:Label>
                        </li>
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Apellidos: "></asp:Label>
                            <asp:Label ID="apellidoLbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtApellidoEdit" CssClass="form-control" runat="server" Visible="false" MaxLength="100"></asp:TextBox>
                            <asp:Label ID="lblErrorApellido" CssClass="lbl lbl_error" Text="El apellido solo debe contener letras" runat="server" Visible="false"></asp:Label>
                        </li>
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="DNI: "></asp:Label>
                            <asp:Label ID="dniLbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtDniEdit" CssClass="form-control" runat="server" Visible="false" onkeypress="return soloNumeros(event);" minLength="7" maxlength="8"></asp:TextBox>
                        <asp:Label ID="lblErrorDni" CssClass="lbl lbl_error" Text="El dni solo debe contener números" runat="server" Visible="false"></asp:Label>
                        </li>
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Email: "></asp:Label>
                            <asp:Label ID="emailLbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtMailEdit" CssClass="form-control" runat="server" Visible="false" maxlength="50"></asp:TextBox>
                            <asp:Label ID="lblErrorMail" CssClass="lbl lbl_error" Text="Ingrese un formato de Email correcto" runat="server" Visible="false"></asp:Label>
                        </li>
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Telefono: "></asp:Label>
                            <asp:Label ID="telefonoLbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtTelefonoEdit" CssClass="form-control" runat="server" Visible="false" maxlength="15"></asp:TextBox>
                            <asp:Label ID="lblErrorTelefono" CssClass="lbl lbl_error" Text="El telefono solo debe contener numero" runat="server" Visible="false"></asp:Label>
                        </li>
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Dirección: "></asp:Label>
                            <asp:Label ID="direccionLbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtDireccionEdit" CssClass="form-control" runat="server" Visible="false" maxlength="100"></asp:TextBox>
                            <asp:Label ID="lblErrorDireccion" CssClass="lbl lbl_error" Text="La dirección debe contener letras y números" runat="server" Visible="false"></asp:Label>
                        </li>
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Fecha de Nacimiento: "></asp:Label>
                            <asp:Label ID="fechaNacimientoLbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtFechaNacimientoEdit" CssClass="form-control" runat="server" Visible="false" TextMode="Date"></asp:TextBox>
                            <asp:Label ID="lblErrorFechaNacimiento" CssClass="lbl lbl_error" Text="La fecha es invalida" runat="server" Visible="false"></asp:Label>

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
