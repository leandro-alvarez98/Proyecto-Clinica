<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Editar_medicos.aspx.cs" Inherits="Proyecto_Clinica.Editar_medicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container form_top containerbott">
        <%--MODAL ESPECIALIDAD--%>
        <div class="modal fade" id="mod_ElegirEspecialidad" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5">Cambiar Especialidad</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
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
                <%--MODAL JORNADA--%>

        <div class="modal fade" id="mod_ElegirJornada" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5">Cambiar Jornada</h1>
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


        <div class="row">



            <div class="col-md-4 mb-4">
                        <%--CARD MEDICO--%>

                <div class="card">
                    <img src="  <% = Medico_actual.Imagen %>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><% = Medico_actual.Nombre %>, <% = Medico_actual.Apellido %></h5>
                        <p class="card-text"><strong>Telefono: </strong><% = Medico_actual.Telefono %></p>
                        <p class="card-text"><strong>Direccion: </strong><% = Medico_actual.Direccion %></p>
                        <p class="card-text"><strong>Fecha de Nacimiento:</strong> <% = Medico_actual.Fecha_Nacimiento %> </p>
                        <p class="card-text"><strong>Mail: </strong><% = Medico_actual.Mail %></p>
                        <p class="card-text">
                            <strong>Jornada/s: </strong>
                            
                            <%-- dinamico --%>
                            <asp:Repeater ID="repeaterJornadas" runat="server" >
                                <ItemTemplate>
                                    <br />
                                    <%# Eval("Tipo") %><br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </p>
                        <p class="card-text">
                            <strong>Especialidad/es: </strong>
                            <asp:Repeater ID="repeaterEspecialidades" runat="server" >
                                <ItemTemplate>
                                    <br />
                                    <%# Eval("Tipo") %><br />
                                </ItemTemplate>

                            </asp:Repeater>
                        </p>
                        <%--botones para actualizar datos--%>
                        <asp:Button ID="btn_SeleccionarMedicoJornada" runat="server" Text="Agregar jornada" CssClass="btn btn-primary" data-bs-toggle="modal" data-bs-target="#mod_ElegirJornada" OnClick="btn_SeleccionarMedicoJornada_Click"   />
                        <asp:Button ID="btn_SeleccionarMedicoEspecialidad" runat="server" Text="Agregar especialidad" CssClass="btn btn-primary" data-bs-toggle="modal" data-bs-target="#mod_ElegirEspecialidad" OnClick="btn_SeleccionarMedicoEspecialidad_Click"  />

                        <asp:Button ID="btn_EliminarEspecialidad" runat="server" Text="Eliminar especialidad" CssClass="btn btn-primary" data-bs-toggle="modal" data-bs-target="#mod_ElegirEspecialidad" OnClick="btn_EliminarEspecialidad_Click" />
                        <asp:Button ID="btn_EliminarJornada" runat="server" Text="Eliminar especialidad" CssClass="btn btn-primary" data-bs-toggle="modal" data-bs-target="#mod_ElegirEspecialidad" OnClick="btn_EliminarJornada_Click"  />
                    </div>
                </div>
            </div>
        </div>


    </div>



</asp:Content>
