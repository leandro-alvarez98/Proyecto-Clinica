<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="Proyecto_Clinica.Medicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Repeater ID="repeaterMedicos" runat="server">
        <ItemTemplate>
            <div class="card" style="width: 18rem;">
                <img src="..." class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%# Eval("Nombre") %>, <%# Eval("Apellido") %></h5>
                    <p class="card-text">Jornada/s</p>
                    <p class="card-text">Especialidad/es</p>
                    <a href="#" class="btn btn-primary">Editar</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>


</asp:Content>
