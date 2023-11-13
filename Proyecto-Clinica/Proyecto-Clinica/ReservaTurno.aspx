<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="ReservaTurno.aspx.cs" Inherits="Proyecto_Clinica.ReservaTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="mb-3 container containerbott form_top ">

     <h3>Reservar Turno</h3>
     <hr />
     <asp:DropDownList ID="DDL_especialidades" CssClass="form-select" runat="server"></asp:DropDownList> 
     <hr />
     <div class="mb-3">
         <asp:GridView ID="Grilla_Especialidades" runat="server"></asp:GridView>
     </div>

     <div class="mb-3">
         <asp:Label ID="Fecha" runat="server" Text="Fecha"></asp:Label>
         <asp:Label ID="Desde" runat="server" Text="Desde"></asp:Label>
         <asp:TextBox ID="txtDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>

         <asp:Label ID="Hasta" runat="server" Text="Hasta"></asp:Label>
         <asp:TextBox ID="txtHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
     </div>

     <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="btn btn-secondary " Text="Buscar Turnos" />



        <%-- grilla con todos los turnos disponibles para --%>
     <div>
         <asp:GridView ID="Grilla_turnos_disponibles"  runat="server"></asp:GridView>
     </div>

  </div>

</asp:Content>
