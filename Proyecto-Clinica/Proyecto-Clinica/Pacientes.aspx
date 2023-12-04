<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="Proyecto_Clinica.Pacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container form_top containerbott">

        <%--MODAL ALTA PACIENTE--%>
        <div class="modal fade" id="mod_AltaPaciente" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="staticBackdropLabel">Alta paciente</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">

                        <ul class="list-group list-group-flush">

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
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="Btn_AltaPacienteConfirmar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="Btn_AltaPacienteConfirmar_Click" />
                    </div>
                </div>
            </div>
        </div>

        <h1 class="fs-1 font-monospace">Pacientes</h1>

        <%--  <%--Buscador de Pacientes--%>
        <br />
        <asp:Label ID="Label2" CssClass="form-label" runat="server" Text="Buscar pacientes por Dni"></asp:Label>
        <asp:TextBox ID="txt_dni" CssClass="form-control" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Btn_buscar_pacientes" runat="server" OnClick="Btn_buscar_pacientes_Click" CssClass="Boton" Text="Buscar" />
        <asp:Button ID="Btn_limpiar" runat="server" CssClass="Boton" OnClick="Btn_limpiar_Click" Text="limpiar" />

        <asp:Button ID="Btn_AltaPaciente" runat="server" CssClass="Boton" OnClick="Btn_AltaPaciente_Click" Text="Agregar un paciente" />

        <br />
        <asp:Label ID="Lbl_sin_pacientes" runat="server" CssClass="form-label" Text="No existe ningun paciente con ese Dni" Visible="false"></asp:Label>
        <hr />
        <%--card Pacientes--%>
        <div class="row">
            <asp:Repeater ID="repeaterPacientes" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <div class="card">

                            <img src="<%# Eval("Imagen") %>" class="card-img-top">

                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %>, <%# Eval("Apellido") %></h5>
                                <p class="card-text"><strong>Telefono: </strong><%# Eval("Telefono") %></p>
                                <p class="card-text"><strong>Direccion: </strong><%# Eval("Direccion") %></p>
                                <p class="card-text"><strong>Fecha de Nacimiento:</strong> <%# Eval("Fecha_Nacimiento") %> </p>
                                <p class="card-text"><strong>Mail: </strong><%# Eval("Mail") %></p>
                                <p class="card-text"><strong>Dni: </strong><%# Eval("Dni") %></p>
                                <asp:Button ID="btnEditarDatos" CssClass="Boton" runat="server" Text="Editar Datos" CommandArgument='<%# Eval("id") %>' OnClick="btnEditarDatos_Click" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>
