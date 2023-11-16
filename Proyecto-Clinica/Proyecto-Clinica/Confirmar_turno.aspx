<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Confirmar_turno.aspx.cs" Inherits="Proyecto_Clinica.Confirmar_turno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mb-3 container containerbott form_top ">
        <asp:GridView ID="DGVTurno_a_confirmar" runat="server" CssClass="table table-dark table-hover " AutoGenerateColumns="false">
            <Columns>
                  <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                 <asp:BoundField HeaderText="Hora" DataField="Horario" />
                 <asp:BoundField HeaderText="Nombre paciente" DataField="Nombre_Paciente" />
                 <asp:BoundField HeaderText="Apellido paciente" DataField="Apellido_Paciente" />
                 <asp:BoundField HeaderText="Dni paciente" DataField="Dni_paciente" />
                 <asp:BoundField HeaderText="Nombre medico" DataField="Nombre_Medico" />
                 <asp:BoundField HeaderText="Apellido medico" DataField="Apellido_Medico" />
            </Columns>
        </asp:GridView>

        <asp:Button ID="confir_turno" runat="server" OnClick="Confirmar_turno_Click" CssClass="btn btn-secondary" Text="Confirmar_turno" />
        









    </div>


</asp:Content>
