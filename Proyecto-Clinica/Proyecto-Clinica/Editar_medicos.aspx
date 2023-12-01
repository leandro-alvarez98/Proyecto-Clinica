<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Editar_medicos.aspx.cs" Inherits="Proyecto_Clinica.Editar_medicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container form_top containerbott">
        <div class="modal fade" id="mod_ElegirEspecialidad" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5">Cambiar Especialidad</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <asp:RadioButtonList ID="rbl_Especialidades" runat="server" AutoPostBack="False">
                            
                        </asp:RadioButtonList>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btn_ActualizarEspecialidad" CssClass="btn btn-primary" runat="server" Text="Guardar selección" OnClick="btn_ActualizarEspecialidad_Click" />
                    </div>
                </div>
            </div>
        </div>

         <div class="modal fade" id="mod_ElegirJornada" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
     <div class="modal-dialog">
         <div class="modal-content">
             <div class="modal-header">
                 <h1 class="modal-title fs-5">Cambiar Jornada</h1>
                 <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
             </div>
             <div class="modal-body">
                 <asp:RadioButtonList ID="rbl_Jornada" runat="server" AutoPostBack="False">
                     
                 </asp:RadioButtonList>
             </div>
             <div class="modal-footer">
                 <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                 <asp:Button ID="btn_ActualizarJornada" CssClass="btn btn-primary" runat="server" Text="Guardar selección" OnClick="btn_ActualizarJornada_Click" />
             </div>
         </div>
     </div>


 </div>


        <div class="row">


    <asp:Repeater ID="repeaterMedicos" runat="server">
        <ItemTemplate>
            <div class="col-md-4 mb-4">
                <div class="card">
                    <img src="  <%# Eval("Imagen") %>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Nombre") %>, <%# Eval("Apellido") %></h5>
                        <p class="card-text"><strong>Telefono: </strong><%# Eval("Telefono") %></p>
                        <p class="card-text"><strong>Direccion: </strong><%# Eval("Direccion") %></p>
                        <p class="card-text"><strong>Fecha de Nacimiento:</strong> <%# Eval("Fecha_Nacimiento") %> </p>
                        <p class="card-text"><strong>Mail: </strong><%# Eval("Mail") %></p>
                        <p class="card-text">
                            <strong>Jornada/s: </strong>
                            <asp:Repeater ID="repeaterJornadas" runat="server" DataSource='<%# Eval("Jornadas") %>'>
                                <ItemTemplate>
                                    <br />
                                    <%# Eval("Tipo") %><br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </p>
                        <p class="card-text">
                            <strong>Especialidad/es: </strong>
                            <asp:Repeater ID="repeaterEspecialidades" runat="server" DataSource='<%# Eval("Especialidades") %>'>
                                <ItemTemplate>
                                    <br />
                                    <%# Eval("Tipo") %><br />
                                </ItemTemplate>

                            </asp:Repeater>
                        </p>
                        <asp:Button ID="btn_SeleccionarMedicoJornada" runat="server" Text="Cambiar jornada" CssClass="btn btn-primary" data-bs-toggle="modal" data-bs-target="#mod_ElegirJornada" OnClick="btn_SeleccionarMedicoJornada_Click" CommandName="SeleccionarJornada" CommandArgument='<%# Eval("Id") %>' />
                        <asp:Button ID="btn_SeleccionarMedicoEspecialidad" runat="server" Text="Cambiar especialidad" CssClass="btn btn-primary" data-bs-toggle="modal" data-bs-target="#mod_ElegirEspecialidad" OnClick="btn_SeleccionarMedicoEspecialidad_Click" CommandName="SeleccionarEspecialidad" CommandArgument='<%# Eval("Id") %>' />

                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>


    </div>



</asp:Content>
