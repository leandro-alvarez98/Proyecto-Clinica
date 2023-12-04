<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="ReservaTurno.aspx.cs" Inherits="Proyecto_Clinica.ReservaTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mb-3 container containerbott form_top ">
        <h1 class="fs-1 font-monospace ">Reservar Turno</h1>
<%--        <asp:Label CssClass="fs-3 font-monospace " runat="server" Text="Seleccionar Fecha"></asp:Label>--%>
        <hr />

        <%-- Especialidades --%>
        <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Seleccione la especialidad: "></asp:Label>
        <asp:DropDownList ID="DDL_especialidades" CssClass="form-select" runat="server"></asp:DropDownList>
        <asp:Label ID="LbL_falta_especialidad" runat="server" Text="Por favor ingrese una especialidad" Visible="false"></asp:Label>

        <br />

        <%-- Fecha --%>
        <div class="mb-3">
            <asp:Label CssClass="fs-4 font-monospace" runat="server" Text="Seleccione la fecha: "></asp:Label>
            <asp:TextBox ID="txtFechaSeleccionada" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>

            <asp:Label ID="lbl_FechaInvalida" runat="server" Text="Por Favor Ingrese una fecha valida" Visible="false"></asp:Label>

            <asp:Label ID="lbl_Hora" runat="server" Text="Hora: "></asp:Label>
            <asp:TextBox ID="txt_HoraSeleccionada" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
            <asp:Label ID="lbl_HoraInvalida" runat="server" Text="Por Favor Ingrese una Hora valida" Visible="false"></asp:Label>

        </div>

        <br />
                <%-- btn BUSCAR TURNO --%>

        <asp:Button ID="Buscar_Turno" runat="server" OnClick="Buscar_Turno_Click" CssClass="Boton" Text="Buscar Turnos" />
        <br />
        <asp:Label ID="lblturnos" runat="server" CssClass="fs-4 font-monospace" Text=""></asp:Label>
        <br />
        <%-- Grilla con todos los turnos disponibles --%>
        <div>
            <asp:GridView ID="Grilla_turnos_disponibles" runat="server" OnSelectedIndexChanged="Grilla_turnos_disponibles_SelectedIndexChanged" AutoGenerateColumns="false" CssClass="table table-dark table-hover ">
                <Columns>
                    <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:dd-MM-yyyy}" />
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
