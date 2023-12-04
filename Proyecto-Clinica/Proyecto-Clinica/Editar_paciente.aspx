<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Editar_paciente.aspx.cs" Inherits="Proyecto_Clinica.Editar_paciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%-- referencia a la carpeta JS que contiene los script --%>
 <script type="text/javascript" src="JS/JavaScript.js"></script>

    <div class="container form_top containerbott">

        <div class="row">

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
                            <asp:TextBox ID="txtDniEdit" CssClass="form-control" runat="server" Visible="false" onkeypress="return soloNumeros(event);" maxlength="8"></asp:TextBox>
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
                            <asp:TextBox ID="txtFechaNacimientoEdit" CssClass="form-control" runat="server" Visible="false" TextMode="Date"></asp:TextBox>

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
