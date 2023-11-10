﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Perfil_Usuario.aspx.cs" Inherits="Proyecto_Clinica.Perfil_Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container form_top containerbott" >
        <div class="card">
            <div class="card-body ">
                <h1 class="card-title">Perfil de Usuario</h1>
                <hr />
                <div class="card " style="width: 40rem;">
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">
                            <asp:Label id="nombrelbl" CssClass="lbl" runat="server" ></asp:Label>
                            <asp:TextBox ID="txtNombreEdit" runat="server" Visible="false"></asp:TextBox>
                        </li>
                        <li class="list-group-item">
                            <asp:Label id="apellidoLbl" CssClass="lbl" runat="server" ></asp:Label>
                            <asp:TextBox ID="txtApellidoEdit" runat="server" Visible="false"></asp:TextBox>
                        </li>
                        <li class="list-group-item">
                            <asp:Label ID="emailLbl" CssClass="lbl" runat="server" ></asp:Label>
                            <asp:TextBox ID="txtMailEdit" runat="server" Visible="false"></asp:TextBox>
                        </li>
                        <li class="list-group-item">
                            <asp:Label ID="telefonoLbl" CssClass="lbl" runat="server" ></asp:Label>
                            <asp:TextBox ID="txtTelefonoEdit" runat="server" Visible="false"></asp:TextBox>
                        </li>
                        <li class="list-group-item">
                            <asp:Label ID="direccionLbl" CssClass="lbl" runat="server" ></asp:Label>
                            <asp:TextBox ID="txtDireccionEdit" runat="server" Visible="false"></asp:TextBox>
                        </li>
                        <li class="list-group-item">
                            <asp:Label ID="fechaNacimientoLbl" CssClass="lbl" runat="server"></asp:Label>
                            <asp:TextBox ID="txtFechaNacimientoEdit" runat="server" Visible="false"></asp:TextBox>
                        </li>
                    </ul>

                    <div class="mb-2">
                        <asp:Button ID="btnEditarDatos" class="btn btn-primary" runat="server" Text="Editar Datos" OnClick="btnEditar_Click"/>
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" OnClick="btnGuardar_Click" Visible="false" />

                    </div>

                    <div class="mb-2">
                        <asp:Button ID="btnCambioContraseña" class="btn btn-primary" runat="server" Text="Cambiar Contraseña" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
