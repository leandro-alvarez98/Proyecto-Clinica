<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Editar_medicos.aspx.cs" Inherits="Proyecto_Clinica.Editar_medicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container form_top containerbott ">
        <%--MODAL AGREGAR ESPECIALIDAD A MEDICO--%>
        <div class="modal fade" id="mod_ElegirEspecialidad" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5">Agregar Especialidad</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <%--PROBANDO EL POSTBACK--%>
                        <asp:RadioButtonList ID="rbl_Especialidades" runat="server" AutoPostBack="False">
                        </asp:RadioButtonList>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btn_ActualizarEspecialidad" CssClass="btn btn-primary" runat="server" Text="Guardar selección" OnClick="btn_ActualizarEspecialidad_Click" />
                    </div>
                </div>
            </div>
        </div>
        <%-- </div>--%>
        <%--MODAL AGREGAR JORNADA A MEDICO--%>
        <div class="modal fade" id="mod_ElegirJornada" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5">Agregar Jornada</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <asp:RadioButtonList ID="rbl_Jornada" runat="server" AutoPostBack="False">
                        </asp:RadioButtonList>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btn_ActualizarJornada" CssClass="btn btn-primary" runat="server" Text="Guardar selección" OnClick="btn_ActualizarJornada_Click" />
                    </div>
                </div>
            </div>


        </div>

        <%--MODAL ELIMINAR ESPECIALIDAD A MEDICO--%>
        <div class="modal fade" id="mod_eliminarEspecialidad" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5">Eliminar Especialidad</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <asp:RadioButtonList ID="rbl_Elimina_Especialidad" runat="server" AutoPostBack="False">
                        </asp:RadioButtonList>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btn_Seleccionar_Especialidad_a_Eliminar" CssClass="btn btn-primary" runat="server" Text="Guardar selección" OnClick="btn_Seleccionar_Especialidad_a_Eliminar_Click" />
                    </div>
                </div>
            </div>
        </div>

        <%--MODAL ELIMINAR JORNADA A MEDICO--%>
        <div class="modal fade" id="mod_eliminarJornada" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5">Eliminar Jornada</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <asp:RadioButtonList ID="rbl_Eliminar_Jornada" runat="server" AutoPostBack="False">
                        </asp:RadioButtonList>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btn_Eliminar_Jornada" CssClass="btn btn-primary" runat="server" Text="Guardar selección" OnClick="btn_Eliminar_Jornada_Click" />
                    </div>
                </div>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col-md-5 mb-5">

                <%--CARD MEDICO--%>

                <div class="card" style="width: 30rem;">
                    <img src="  <% = Medico_actual.Imagen %>" class="card-img-top" alt="...">
                    <div class="card-body">

                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">
                                <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Nombres: "></asp:Label>
                                <asp:Label ID="nombrelbl" CssClass="lbl" runat="server"></asp:Label>
                                <asp:TextBox ID="txtNombreEdit" runat="server" CssClass="form-control" Visible="false" MaxLength="100"></asp:TextBox>
                                <asp:Label ID="lblErrorNombre" CssClass="lbl lbl_error" Text="El nombre solo debe contener letras" runat="server" Visible="false"></asp:Label>

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
                                <asp:TextBox ID="txtDniEdit" CssClass="form-control" runat="server" Visible="false" onkeypress="return soloPermitirNumeros(event)" minLength="7" MaxLength="8"></asp:TextBox>
                                <asp:Label ID="lblErrorDni" CssClass="lbl lbl_error" Text="El dni solo debe contener números" runat="server" Visible="false"></asp:Label>

                            </li>
                            <li class="list-group-item">
                                <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Email: "></asp:Label>
                                <asp:Label ID="emailLbl" CssClass="lbl" runat="server"></asp:Label>
                                <asp:TextBox ID="txtMailEdit" CssClass="form-control" runat="server" Visible="false" MaxLength="70"></asp:TextBox>
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


                        <p class="card-text">
                            <strong>Jornada/s: </strong>

                            <%-- dinamico --%>
                            <asp:Repeater ID="repeaterJornadas" runat="server">
                                <ItemTemplate>
                                    <br />
                                    <%# Eval("Tipo") %><br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </p>
                        <p class="card-text">
                            <strong>Especialidad/es: </strong>
                            <asp:Repeater ID="repeaterEspecialidades" runat="server">
                                <ItemTemplate>
                                    <br />
                                    <%# Eval("Tipo") %><br />
                                </ItemTemplate>

                            </asp:Repeater>
                        </p>



                        <%--agregar especialidades o jornadas--%>

                        <div class="row">
                            <div class="col-md-4 dropdown ">
                                <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class='bx bxs-edit'></i>Agregar
                                </button>
                                <ul class="dropdown-menu text-center">
                                    <li>
                                        <asp:Button ID="btn_SeleccionarMedicoJornada" runat="server" Text="Agregar jornada" CssClass="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#mod_ElegirJornada" OnClick="btn_SeleccionarMedicoJornada_Click" />
                                    </li>
                                    <li>
                                        <asp:Button ID="btn_SeleccionarMedicoEspecialidad" runat="server" Text="Agregar especialidad" CssClass="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#mod_ElegirEspecialidad" OnClick="btn_SeleccionarMedicoEspecialidad_Click" />
                                    </li>
                                </ul>
                            </div>

                            <div class="col-md-4">

                                <%-- Editar y guardar datos del médi co--%>

                                <asp:Button ID="btnEditarMedico" runat="server" Text="Editar Médico" CssClass="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#mod_EditarMedico" OnClick="bntEditarMedico_Click" />
                                <asp:Button ID="btnGuardar" CssClass="Boton" Style="margin-left: 10px" runat="server" Text="Guardar Cambios" OnClick="btnGuardar_Click" Visible="false" />
                                <asp:Button ID="btnCancelar" Style="margin-left: 110px" CssClass="Boton" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Visible="false" />
                                <asp:Label ID="lbl_sin_datos" runat="server" Text="Por favor seleccione una Jornada" Visible="false"></asp:Label>

                            </div>


                            <%-- Eliminar especialidades o jornadas--%>
                            <div class="col-md-4 offset-md-4 dropdown">
                                <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class='bx bx-trash'></i>Eliminar
                                </button>
                                <ul class="dropdown-menu text-center">
                                    <li>
                                        <asp:Button ID="btn_EliminarEspecialidad" runat="server" Text="Eliminar especialidad" CssClass="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#mod_EliminarEspecialidad" OnClick="btn_EliminarEspecialidad_Click" />
                                    </li>




                                    <li>
                                        <asp:Button ID="Button1" runat="server" Text="Eliminar jornada" CssClass="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#mod_eliminarJornada" OnClick="btn_EliminarJornada_Click" />
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


        </div>
  </div>

</asp:Content>
