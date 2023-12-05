<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Editar_paciente.aspx.cs" Inherits="Proyecto_Clinica.Editar_paciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- referencia a la carpeta JS que contiene los script --%>
    <script type="text/javascript" src="JS/JavaScript.js"></script>

    <style>
        .lbl_error {
            color: red;
        }
    </style>

    <div class="container form_top containerbott">

        <div class="row justify-content-center">

            <div class="col-md-4 mb-4">
                <div class="card">
                    <img src="  <% = Paciente_actual.Imagen %>" class="card-img-top" alt="...">

                    <div style="text-align: center;">

                        <h5 class="card-title"><strong>Edite los datos</strong></h5>
                    </div>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Nombres: "></asp:Label>
                            <asp:Label ID="nombrelbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtNombreEdit" runat="server" CssClass="form-control" Visible="false" maxLength="100"></asp:TextBox>
                            <asp:Label ID="lblErrorNombre" CssClass="lbl lbl_error" Text="El nombre solo debe contener letras" runat="server" Visible="false"></asp:Label>

                        </li>
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Apellidos: "></asp:Label>
                            <asp:Label ID="apellidoLbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtApellidoEdit" CssClass="form-control" runat="server" Visible="false" maxLength="100"></asp:TextBox>
                            <asp:Label ID="lblErrorApellido" CssClass="lbl lbl_error" Text="El apellido solo debe contener letras" runat="server" Visible="false"></asp:Label>

                        </li>
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="DNI: "></asp:Label>
                            <asp:Label ID="dniLbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtDniEdit" CssClass="form-control" runat="server" Visible="false" onkeypress="return soloPermitirNumeros(event)" minLength="7" MaxLength="8"></asp:TextBox>
                            <asp:Label ID="lblErrorDni" CssClass="lbl lbl_error" Text="El dni solo debe contener números" runat="server" Visible="false"></asp:Label>

                        </li>
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Email: "></asp:Label>
                            <asp:Label ID="emailLbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtMailEdit" CssClass="form-control" runat="server" Visible="false" maxLength="70"></asp:TextBox>
                            <asp:Label ID="lblErrorMail" CssClass="lbl lbl_error" Text="Ingrese un formato de Email correcto" runat="server" Visible="false"></asp:Label>

                        </li>
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Telefono: "></asp:Label>
                            <asp:Label ID="telefonoLbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtTelefonoEdit" CssClass="form-control" runat="server" Visible="false" MaxLength="15"></asp:TextBox>
                            <asp:Label ID="lblErrorTelefono" CssClass="lbl lbl_error" Text="El telefono solo debe contener numero" runat="server" Visible="false"></asp:Label>

                        </li>
                        <li class="list-group-item">
                            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Dirección: "></asp:Label>
                            <asp:Label ID="direccionLbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtDireccionEdit" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
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
                        <asp:Button ID="btnEditarDatos" CssClass="Boton" Style="margin-left: 10px" runat="server" Text="Editar Datos" OnClick="btnEditar_Click" />
                        <asp:Button ID="btnGuardar" CssClass="Boton" Style="margin-left: 10px" runat="server" Text="Guardar Cambios" OnClick="btnGuardar_Click" Visible="false" />
                        <asp:Button ID="btnCancelar" Style="margin-left: 110px" CssClass="Boton" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Visible="false" />
                        <asp:Button ID="btnCambioContraseña" Style="margin-left: 70px" CssClass="Boton" runat="server" Text="Cambiar Contraseña" PostBackUrl="CambiarContraseña.aspx" />
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
