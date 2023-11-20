<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="ReservaTurno.aspx.cs" Inherits="Proyecto_Clinica.ReservaTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mb-3 container containerbott form_top ">
        <asp:Label  CssClass="fs-3 font-monospace fw-semibold" runat="server" Text="Seleccionar Fecha"></asp:Label>
        <%--<h3 CssClass="fs-4 font-monospace">Reservar Turno</h3>--%>
        <hr />

        <%-- Especialidades --%>
        <asp:DropDownList ID="DDL_especialidades" CssClass="form-select" runat="server"></asp:DropDownList>
        <br />

        <%-- Fecha --%>
        <div class="mb-3">
            <asp:Calendar ID="Calendario" runat="server"></asp:Calendar>
        </div>

        <asp:Button ID="Buscar_Turno" runat="server" OnClick="Buscar_Turno_Click" CssClass="Boton" Text="Buscar Turnos" />
        <br />
        <asp:Label ID="lblturnos" runat="server" CssClass="fs-4 font-monospace" Text=""></asp:Label>
        <asp:Label ID="Lbl_fecha_valida" runat="server" CssClass="fs-4 font-monospace" Text="Por Favor Ingrese una fecha valida" Visible="false"></asp:Label>
        <br />
        <%-- Grilla con todos los turnos disponibles --%>       
                <div>
                    <asp:GridView ID="Grilla_turnos_disponibles" runat="server" OnSelectedIndexChanged="Grilla_turnos_disponibles_SelectedIndexChanged" AutoGenerateColumns="false" CssClass="table table-dark table-hover ">
                        <Columns>
                            <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:BoundField HeaderText="Hora" DataField="Horario" />
                            <asp:BoundField HeaderText="Apellido Médico" DataField="Apellido_Medico" />
                            <asp:BoundField HeaderText="Nombre Médico" DataField="Nombre_Medico" />
                            <asp:BoundField HeaderText="Estado" DataField="Estado" />
                            <asp:BoundField HeaderText="Id medico" DataField="Id_Medico" />
                            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />
                        </Columns>
                    </asp:GridView>                   
                </div>
    </div>
</asp:Content>
