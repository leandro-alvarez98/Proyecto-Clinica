<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Proyecto_Clinica.Usuarios" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <asp:Label ID="Label1" runat="server" ></asp:Label>
        <div class="modal fade" id="mod_ElegirTipo" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="staticBackdropLabel">Cambiar tipo de usuario</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <asp:RadioButtonList ID="rblTipos" runat="server" AutoPostBack="True">
                            <asp:ListItem Text=" Administrador/a" Value="Administrador"/>
                            <asp:ListItem Text=" Recepcionista" Value="Recepcionista" />
                            <asp:ListItem Text=" Médico/a" Value="Médico" />
                            <asp:ListItem Text=" Paciente" Value="Paciente" />
                        </asp:RadioButtonList>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btn_ActualizarTipo" CssClass="btn btn-primary" runat="server" Text="Guardar selección" OnClick="btn_ActualizarTipo_Click" />
                    </div>
                </div>
            </div>
        </div>

    <div class="row">
        <asp:Repeater ID="repeaterUsuarios" runat="server">
            <ItemTemplate>
                <div class="col-md-4 mb-4">
                    <div class="card">
                        <img src='<%# Eval("Imagen") %>' class="card-img-top">
                        <div class="card-body">
                            <h5 class="card-title">Username: <%# Eval("Username") %> </h5>
                            <p class="card-text"><strong>Tipo: </strong><%# Eval("Tipo") %></p>
                            <asp:Button ID="btn_SeleccionarUsuario" runat="server" Text="Cambiar tipo" CssClass="btn btn-primary" data-bs-toggle="modal" data-bs-target="#mod_ElegirTipo" OnClick="btn_SeleccionarUsuario_Click" CommandName="SeleccionarUsuario" CommandArgument='<%# Eval("Id") %>' />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>

</asp:Content>
