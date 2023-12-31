﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Seleccionar_paciente.aspx.cs" Inherits="Proyecto_Clinica.Seleccionar_paciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mb-3 container containerbott form_top ">
        <asp:Label CssClass="fs-1 font-monospacee" runat="server" Text="Seleccionar Paciente"></asp:Label>
        <hr />

        <div class="mb-3">
            <asp:Label ID="lblbuscar" runat="server" Class="form-label" Text="Ingrese el DNI del paciente :"></asp:Label>
            <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" placeholder="DNI del Usuario"></asp:TextBox>
            <br />
            <asp:Button ID="buscar_paciente" runat="server" OnClick="buscar_paciente_Click" CssClass="Boton" Text="Buscar Paciente" />
        </div>
        <hr />
        <asp:Label ID="lbl_no_existe_paciente" CssClass="fs-4 font-monospace" runat="server" Text="no se encontro ningun paciente con el Dni ingresado" Visible="false"></asp:Label>
        <br />
        <asp:GridView ID="DGV_Paciente" AutoGenerateColumns="false" OnSelectedIndexChanged="DGV_Paciente_SelectedIndexChanged" runat="server" CssClass="table table-dark table-hover PAD_TOP ">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="id" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Dni" DataField="Dni" />
                <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
                <asp:BoundField HeaderText="Mail" DataField="Mail" />
                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
