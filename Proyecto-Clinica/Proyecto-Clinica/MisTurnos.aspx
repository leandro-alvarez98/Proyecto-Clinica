<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="MisTurnos.aspx.cs" Inherits="Proyecto_Clinica.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="container form_top containerbott">
                
                <%--modal para cancelar--%>
                <div class="modal" tabindex="-1" id ="Modal_cancelar_turno">
                    <div class="modal-dialog modal-dialog-centered " >
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Cancelar Turno </h5>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <p>Estas seguro que queres cancelar el turno?</p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                                <asp:Button ID="Btn_aceptar_cancelar_turno" CssClass="btn btn-primary" runat="server" OnClick="Btn_aceptar_cancelar_turno_Click" Text="Aceptar" />
                            </div>
                        </div>
                    </div>
                </div>

                <%-- Esta página maneja los turnos del usuario sólo si el mismo es un Médico --%>
                <%if (usuarioActual.Tipo == "Recepcionista" || usuarioActual.Tipo == "Administrador")%>
                <%{ %>


                        <h1 class="fs-1 font-monospace">Turnos</h1>

                        <asp:Label ID="Lbl_Busqueda" runat="server" CssClass="form-label" Text="Buscar Turno por Dni del paciente"></asp:Label>
                        <asp:TextBox ID="Txt_Busqueda"  CssClass="form-control"  runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="Btn_busqueda" runat="server" OnClick="Btn_busqueda_Click" CssClass="Boton" Text="Buscar" />
                        <asp:Button ID="Btn_limpiar_busqueda" OnClick="Btn_limpiar_busqueda_Click" runat="server" CssClass="Boton" Text="Limpiar" />
                        <hr />
                    <asp:GridView ID="DGV_Turnos_totales" CssClass="table table-dark table-hover PAD_TOP"  OnSelectedIndexChanged="DGV_Turnos_totales_Cancelar_Modificar"  runat="server" AutoGenerateColumns="false" AutoPostBack="true" EnableViewState="true">
                            <Columns>
                                <asp:BoundField HeaderText="Turno #" DataField="Id" />
                                <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:dd-MM-yyyy}" />
                                <asp:BoundField HeaderText="Hora" DataField="Horario" />
                                <asp:BoundField HeaderText="Nombre paciente" DataField="Nombre_Paciente" />
                                <asp:BoundField HeaderText="Apellido paciente" DataField="Apellido_Paciente" />
                                <asp:BoundField HeaderText="Nombre medico" DataField="Nombre_Medico" />
                                <asp:BoundField HeaderText="Apellido medico" DataField="Apellido_Medico" />
                                <asp:BoundField HeaderText="DNI Paciente" DataField="Dni_Paciente" />
                                <asp:BoundField HeaderText="Motivo Consulta" DataField="Obs_paciente" />
                                <asp:BoundField HeaderText="Estado" DataField="Estado" />
                                <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderText="Cancelar" />
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="Lbl_sin_turnos" runat="server" Text="No hay Turnos asociados a este Dni" Visible="false"></asp:Label>
                    
                <%}else if (usuarioActual.Tipo == "Médico")%>
                <%{%>
                    
                        <h1 class="fs-1 font-monospace">Mis Turnos</h1>
                <asp:Label ID="lblTurnoNoFinalizado" runat="server" Text="No puede agregar observación a un turno no finalizado" Visible ="false"></asp:Label>

                        <asp:GridView ID="dgv_Turnos_Medicos" CssClass="table table-dark table-hover PAD_TOP" runat="server" OnSelectedIndexChanged="dgv_Turnos_Medicos_SelectedIndexChanged" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField HeaderText="Turno #" DataField="Id" />
                                <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:dd-MM-yyyy}" />
                                <asp:BoundField HeaderText="Hora" DataField="Horario" />
                                <asp:BoundField HeaderText="Nombre paciente" DataField="Nombre_Paciente" />
                                <asp:BoundField HeaderText="Apellido paciente" DataField="Apellido_Paciente" />
                                <asp:BoundField HeaderText="Nombre medico" DataField="Nombre_Medico" />
                                <asp:BoundField HeaderText="Apellido medico" DataField="Apellido_Medico" />
                                <asp:BoundField HeaderText="DNI Paciente" DataField="Dni_Paciente" />
                                <asp:BoundField HeaderText="Motivo Consulta" DataField="Obs_paciente" />
                                <asp:BoundField HeaderText="Estado" DataField="Estado" />
                                <asp:CommandField ShowSelectButton="true" SelectText="Agregar Observacion" HeaderText="Observaciones" />
                            </Columns>
                        </asp:GridView>
                   
                 <%}else%>
                <%{%>
                    
                        <h1 class="fs-1 font-monospace">Mis Turnos</h1>

                        <asp:GridView ID="Dgv_Turnos_Paciente" CssClass="table table-dark table-hover PAD_TOP" OnSelectedIndexChanged="DGV_Turnos_Pacientes_Cancelar" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField HeaderText="Turno #" DataField="Id" />
                                <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:dd-MM-yyyy}" />
                                <asp:BoundField HeaderText="Hora" DataField="Horario" />
                                <asp:BoundField HeaderText="Nombre paciente" DataField="Nombre_Paciente" />
                                <asp:BoundField HeaderText="Apellido paciente" DataField="Apellido_Paciente" />
                                <asp:BoundField HeaderText="Nombre medico" DataField="Nombre_Medico" />
                                <asp:BoundField HeaderText="Apellido medico" DataField="Apellido_Medico" />
                                <asp:BoundField HeaderText="DNI Paciente" DataField="Dni_Paciente" />
                                <asp:BoundField HeaderText="Motivo Consulta" DataField="Obs_paciente" />
                                <asp:BoundField HeaderText="Estado" DataField="Estado" />
                                <asp:CommandField ShowSelectButton="true" SelectText="Cancelar" HeaderText="Accion" />
                            </Columns>
                        </asp:GridView>               

                 <%}%>
     </div>
</asp:Content>
