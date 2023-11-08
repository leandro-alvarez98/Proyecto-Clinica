<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="Proyecto_Clinica.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mb-3 container containerbott form_top ">
    <h3>Reservar Turno</h3>
        <hr />  
        <div class="form-group">
            <div class="form-label">
                <asp:Label ID="lblApellidoProfesional" runat="server" Text="Conoce el apellido del profesional?" AssociatedControlID="rbConoceApellido"></asp:Label>
            </div>
            <div class="form-control">
                <asp:RadioButtonList ID="rbConoceApellido" runat="server" RepeatDirection="Horizontal" CssClass="radio-list">
                    <asp:ListItem Text="Sí" Value="Si" />
                    <asp:ListItem Text="No" Value="No" />
                </asp:RadioButtonList>
            </div>
        </div>

        <div class="form-group">
            <div class="form-label">
                <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
            </div>
            <div class="form-control">
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Ingrese Apellido"></asp:TextBox>
            </div>
        </div>

        <!--filtros avanzados  -->


        <!-- linea divisoria-->
        <div id="filtrosAvanzados">

            <div class="mb-3 form-group ">
                <div class="d-flex justify-content-between align-items-center">
                    <div class="form-label">
                        <asp:Label ID="lblFiltrosAvanzados" runat="server" Text="Filtros Avanzados"></asp:Label>
                    </div>
                    <div class="form-check form-switch">
                        <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault">
                        <label class="form-check-label" for="flexSwitchCheckDefault">Habilitar filtros avanzados</label>
                    </div>
                </div>
            </div>
        </div>

        <div class="mb-3">
            <asp:Label ID="Fecha" runat="server" Text="Fecha"></asp:Label>
            <asp:Label ID="Desde" runat="server" Text="Desde"></asp:Label>
            <asp:TextBox ID="txtDesde" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>

            <asp:Label ID="Hasta" runat="server" Text="Hasta"></asp:Label>
            <asp:TextBox ID="txtHasta" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>


        </div>

        <div class="mb-3">
            <asp:Label ID="lblBandaHoraria" runat="server" Text="Banda Horaria"></asp:Label>

        </div>
        <div class="d-flex">
            <div class="mb-3">
            <div class="form-check">
                <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">
                <label class="form-check-label" for="flexCheckDefault">
                    Mañana
                </label>
            </div>
            <div class="form-check">
                <input class="form-check-input" type="checkbox" value="" id="flexCheckChecked" >
                <label class="form-check-label" for="flexCheckChecked">
                    Tarde
                </label>
            </div>
            <div class="form-check">
                <input class="form-check-input" type="checkbox" value="" id="flexCheckChecked1" >
                <label class="form-check-label" for="flexCheckChecked">
                    Noche
                </label>
            </div>
                </div>
        </div>

        <div class="mb-3">  
                        <asp:Label ID="lblDiaSemana" runat="server" Text="Dia de la semana"></asp:Label>


            </div>
        <div class="d-flex">
    <div class="form-check">
        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefaultLunes">
        <label class="form-check-label" for="flexCheckDefaultLunes">
            Lunes
        </label>
    </div>
    <div class="form-check">
        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefaultMartes">
        <label class="form-check-label" for="flexCheckDefaultMartes">
            Martes
        </label>
    </div>
    <div class="form-check">
        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefaultMiercoles">
        <label class="form-check-label" for="flexCheckDefaultMiercoles">
            Miércoles
        </label>
    </div>
    <div class="form-check">
        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefaultJueves">
        <label class="form-check-label" for="flexCheckDefaultJueves">
            Jueves
        </label>
    </div>
    <div class="form-check">
        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefaultViernes">
        <label class="form-check-label" for="flexCheckDefaultViernes">
            Viernes
        </label>
    </div>
    <div class="form-check">
        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefaultSabado">
        <label class="form-check-label" for="flexCheckDefaultSabado">
            Sábado
        </label>
    </div>
    <div class="form-check">
        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefaultDomingo">
        <label class="form-check-label" for="flexCheckDefaultDomingo">
            Domingo
        </label>
    </div>
</div>

    </div>
</asp:Content>
