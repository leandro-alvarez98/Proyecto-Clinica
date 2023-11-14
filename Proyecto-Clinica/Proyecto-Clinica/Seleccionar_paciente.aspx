<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Seleccionar_paciente.aspx.cs" Inherits="Proyecto_Clinica.Seleccionar_paciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="mb-3 container containerbott form_top ">

         
       
         <div class="mb-3">
             <asp:Label ID="lblbuscar" runat="server" Class="form-label" Text="Ingrese el DNI del paciente :"></asp:Label>
             <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" placeholder="DNI del Usuario"></asp:TextBox>
             <asp:Button id="buscar_paciente" runat="server" CssClass="btn btn-secondary" Text="Buscar Paciente" />
         </div>
         <asp:Label ID="lblnoseencuentra" runat="server" CssClass="fs-4 font-monospace" Text=""></asp:Label>


         <asp:GridView id="DGV_Paciente" runat="server"  AutoGenerateColumns="false" OnSelectedIndex="DGV_Paciente_SelectedIndexChanged" CssClass="table table-dark table-hover ">
             <columns>
                 <asp:BoundField HeaderText="id" DataField="id" />
                 <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                 <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                 <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
                 <asp:BoundField HeaderText="Mail" DataField="Mail" />
                 <asp:BoundField HeaderText="Estado" DataField="Estado" />
                 <asp:BoundField HeaderText="id usuario" DataField="Id_Usuario" />
                 <asp:CommandField ShowSelectButton="true" SelectText="seleccionar paciente"  HeaderText="Accion" />
             </columns>
         </asp:GridView>

     </div>



</asp:Content>
