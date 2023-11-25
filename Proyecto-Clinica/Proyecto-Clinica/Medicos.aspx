<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="Proyecto_Clinica.Medicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
    <asp:Repeater ID="repeaterMedicos" runat="server">
        <ItemTemplate>
            <div class="col-md-4 mb-4">
                <div class="card">
                    <img src="..." class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Nombre") %>, <%# Eval("Apellido") %></h5>
                        <p class="card-text"><strong>Telefono: </strong>  <%# Eval("Telefono") %></p>
                        <p class="card-text"><strong>Direccion: </strong>  <%# Eval("Direccion") %></p>
                        <p class="card-text"><strong>Fecha de Nacimiento:</strong> <%# Eval("Fecha_Nacimiento") %> </p>
                        <p class="card-text"><strong>Mail: </strong><%# Eval("Mail") %></p>
                        <p class="card-text"><strong>Jornada/s: </strong> </p>
                        <p class="card-text">
                         <strong>Especialidad/es: </strong>
                            <asp:Repeater ID="repeaterEspecialidades" runat="server" DataSource='<%# Eval("Especialidades") %>'>
                                <ItemTemplate>
                                    <%# Eval("Tipo") %><br/>
                                </ItemTemplate>
                            </asp:Repeater>
                        </p>
                        <asp:Button ID="btnEditarDatos" CssClass="Boton" runat="server" Text="Editar Datos" Onclick="btnEditarDatos_Click" />
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>



</asp:Content>
