<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="MisTurnos.aspx.cs" Inherits="Proyecto_Clinica.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                <%-- Esta página maneja los turnos del usuario sólo si el mismo es un Médico --%>
                <%if (usuarioActual.Tipo == "Recepcionista" || usuarioActual.Tipo == "Administrador")%>
                <%{ %>
                    <div class="container form_top containerbott">

                        <asp:Label ID="Lbl_Busqueda1" runat="server" CssClass="form-label" Text="Buscar Turno por Dni del paciente/Doctor"></asp:Label>
                        <asp:TextBox ID="Txt_Busqueda1"  CssClass="form-control"  runat="server"></asp:TextBox>

                        <asp:Button ID="Btn_busqueda" runat="server" CssClass="margin_TOP_bot btn btn-secondary" Text="Buscar" />

                    <asp:GridView ID="DGV_Turnos_totales" CssClass="table table-dark table-hover PAD_TOP"  OnSelectedIndexChanged="DGV_Turnos_totales_SelectedIndexChanged"  runat="server" AutoGenerateColumns="false" AutoPostBack="true" EnableViewState="true">
                            <Columns>
                                <asp:BoundField HeaderText="Turno #" DataField="Id" />
                                <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                                <asp:BoundField HeaderText="Hora" DataField="Horario" />
                                <asp:BoundField HeaderText="Nombre paciente" DataField="Nombre_Paciente" />
                                <asp:BoundField HeaderText="Apellido paciente" DataField="Apellido_Paciente" />
                                <asp:BoundField HeaderText="Nombre medico" DataField="Nombre_Medico" />
                                <asp:BoundField HeaderText="Apellido medico" DataField="Apellido_Medico" />
                                <asp:BoundField HeaderText="DNI Paciente" DataField="Dni_Paciente" />
                                <asp:BoundField HeaderText="Estado" DataField="Estado" />
                                <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderText="Modificar" />
                                <asp:CommandField ShowSelectButton="true" SelectText="Cancelar" HeaderText="Cancelar" />
                            </Columns>
                        </asp:GridView>
                    </div>
                <%}else if (usuarioActual.Tipo == "Médico")%>
                <%{%>
                    <div class="container form_top containerbott">
                        <asp:GridView ID="dgv_Turnos_Medicos" CssClass="table table-dark table-hover PAD_TOP" runat="server" OnSelectedIndexChanged="dgv_Turnos_Medicos_SelectedIndexChanged" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField HeaderText="Turno #" DataField="Id" />
                                <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                                <asp:BoundField HeaderText="Hora" DataField="Horario" />
                                <asp:BoundField HeaderText="Nombre paciente" DataField="Nombre_Paciente" />
                                <asp:BoundField HeaderText="Apellido paciente" DataField="Apellido_Paciente" />
                                <asp:BoundField HeaderText="Nombre medico" DataField="Nombre_Medico" />
                                <asp:BoundField HeaderText="Apellido medico" DataField="Apellido_Medico" />
                                <asp:BoundField HeaderText="DNI Paciente" DataField="Dni_Paciente" />
                                <asp:BoundField HeaderText="Estado" DataField="Estado" />
                                <asp:CommandField ShowSelectButton="true" SelectText="Agregar Observacion" HeaderText="Observaciones" />
                            </Columns>
                        </asp:GridView>
                    </div>
                 <%}else%>
                <%{%>
                    <div class="container form_top containerbott">
                        <asp:GridView ID="Dgv_Turnos_Paciente" CssClass="table table-dark table-hover PAD_TOP" OnSelectedIndexChanged="dgv_Turnos_Pacientes_SelectedIndexChanged" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField HeaderText="Turno #" DataField="Id" />
                                <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                                <asp:BoundField HeaderText="Hora" DataField="Horario" />
                                <asp:BoundField HeaderText="Nombre paciente" DataField="Nombre_Paciente" />
                                <asp:BoundField HeaderText="Apellido paciente" DataField="Apellido_Paciente" />
                                <asp:BoundField HeaderText="Nombre medico" DataField="Nombre_Medico" />
                                <asp:BoundField HeaderText="Apellido medico" DataField="Apellido_Medico" />
                                <asp:BoundField HeaderText="DNI Paciente" DataField="Dni_Paciente" />
                                <asp:BoundField HeaderText="Estado" DataField="Estado" />
                                <asp:CommandField ShowSelectButton="true" SelectText="Cancelar" HeaderText="Accion" />
                            </Columns>
                        </asp:GridView>
                    </div>
                 <%}%>
   

   
</asp:Content>
