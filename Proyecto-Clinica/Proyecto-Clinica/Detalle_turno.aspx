<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Detalle_turno.aspx.cs" Inherits="Proyecto_Clinica.Detalle_turno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container form_top containerbott">

        <div class="row">
            <div class="col">

                <div class="card" style="width: 18rem;">

                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">Paciente: 
                    <asp:Label ID="Lbl_nombre_paciente" runat="server" Text=""></asp:Label>
                        </li>
                        <li class="list-group-item">Medico:   
                    <asp:Label ID="Lbl_nombre_medico" runat="server" Text=""></asp:Label>
                        </li>
                        <li class="list-group-item">Fecha:
                    <asp:Label ID="Lbl_Fecha" runat="server" Text=""></asp:Label>
                        </li>
                        <li class="list-group-item">Horario:  
                    <asp:Label ID="Lbl_Horario" runat="server" Text=""></asp:Label>
                        </li>
                        <li class="list-group-item">Id turno: 
                    <asp:Label ID="Lbl_Id_Turno" runat="server" Text=""></asp:Label>
                        </li>
                        <li class="list-group-item">Motivo de consulta:
                    <asp:Label ID="Lbl_motivo_consulta" runat="server" Text=""></asp:Label>
                        </li>
                    </ul>

                    <div class="card-body">
                        <h5 class="card-title">Observacion</h5>
                        <p id="P_observacion" runat="server" class="card-text"></p>
                        <textarea class="form-control" runat="server" id="Txt_Observacion" rows="3" visible="false"></textarea>
                    </div>
                </div>

                <br />

                <asp:Button ID="Btn_agregar_obs" CssClass="Boton" OnClick="Btn_agregar_obs_Click" runat="server" Text="Agregar Observacion" />
                <asp:Button ID="Btn_aceptar" CssClass="Boton" OnClick="Btn_aceptar_Click" runat="server" Text="Aceptar" Visible="false" />
                <asp:Button ID="Btn_cancelar" CssClass="Boton" runat="server" OnClick="Btn_cancelar_Click" Text="Cancelar" Visible="false" />
                <asp:Button ID="Btn_Modificar" CssClass="Boton" runat="server" OnClick="Btn_Modificar_Click" Text="Modificar" Visible="false" />
            </div>

            

            <div class="col">
                <asp:Label ID="Lbl" runat="server" Text="Fecha: "></asp:Label>
                <asp:TextBox ID="txt_FechaSeleccionada" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                <asp:Label ID="lbl_Hora" runat="server" Text="Hora: "></asp:Label>
                <asp:TextBox ID="txt_HoraSeleccionada" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                <asp:Button ID="Btn_BuscarTurnosDisponibles" CssClass="Boton" OnClick="Btn_BuscarTurnosDisponibles_Click" runat="server" Text="Buscar" />

                <br />
                <asp:Label ID="lblMensajeError" CssClass="lbl" runat="server"></asp:Label>
                <asp:Label ID="lblMensajeErrorHora" CssClass="lbl" runat="server"></asp:Label>
                <br />


                <asp:GridView ID="DGV_turnos_disponibles" runat="server"  AutoGenerateColumns="false" CssClass="table table-dark table-hover ">
                    <Columns>
                        <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:dd-MM-yyyy}" />
                        <asp:BoundField HeaderText="Hora" DataField="Horario" />
                        <asp:BoundField HeaderText="Apellido Médico" DataField="Apellido_Medico" />
                        <asp:BoundField HeaderText="Nombre Médico" DataField="Nombre_Medico" />
                        <asp:BoundField HeaderText="Estado" DataField="Estado" />
                        <asp:BoundField HeaderText="Id medico" DataField="Id_Medico" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />
                    </Columns>
                </asp:GridView>
            </div>

        </div>
    </div>
</asp:Content>
