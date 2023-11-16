<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Confirmar_turno.aspx.cs" Inherits="Proyecto_Clinica.Confirmar_turno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mb-3 container containerbott form_top ">
        <asp:GridView ID="Turno_a_confirmar" runat="server" CssClass="table table-dark table-hover ">
            <Columns>

            </Columns>
        </asp:GridView>

        <asp:Button ID="confir_turno" runat="server" OnClick="Confirmar_turno_Click" Text="Confirmar_turno" />
        <asp:Label ID="lblpaciente" runat="server" Text="Label"></asp:Label>

        <asp:Label ID="lblturno" runat="server" Text="Label"></asp:Label>









    </div>


</asp:Content>
