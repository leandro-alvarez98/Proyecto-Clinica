<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Proyecto_Clinica.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container-fluid">
        <div class="row">
            <div class="d-flex flex-column-justify-content-between col-auto bg-dark min-vh-100">
                <div class="mt-4">
                    <a class="text-white d-none d-sm-inline text-decoration-none d-flex aling-items-center ms-4" role="button">
                        <span class="fs-5">Menu</span>
                    </a>
                    <hr class="text-white d-none d-sm-block"/>
                    <ul class="nav nav-pills flex-column mt-2 mt-sm-0" id="menu">
                        <li class="nav-item my-sm-1 my-2">
                            <a href="" class="nav-link text-white " aria-current="page">
                                <i class='bx bx-user'></i>
                                <span class="ms-2 d-none d-sm-inline">Usuario</span>
                            </a>
                        </li>
                        <li class="nav-item my-1 disabled">
                            <a href="#sidemenu"  data-bs-toggle ="collapse" class="nav-link text-white" >
                                <i class='bx bx-notepad'></i>
                                <span class="ms-2 d-none d-sm-inline">Turnos</span>
                               <i class='bx bx-chevron-down'></i>
                            </a>
                            <ul class="nav collapse ms-1 flex-column" id="sidemenu" data-bs-parent="#menu">
                                <li class="nav-item">
                                    <a href="#" class="nav-link text-white" aria-current="page">Reservar Turno</a>
                                </li>
                                <li class="nav-item">
                                    <a href="#" class="nav-link text-white">Historial de turnos</a>
                                </li>
                            </ul>
                        </li>
                        <li class="nav-item my-1">
                            <a href="#" class="nav-link text-white " aria-current="page">
                                <i class='bx bxs-bar-chart-alt-2'></i>
                                <span class="ms-2 d-none d-sm-inline">Estadisticas</span>
                            </a>
                        </li>
                    </ul>
                </div>              
            </div>
        </div>
    </div>


    <div id="turnos">
        <asp:Label ID="Label1" runat="server" Text="especialidad"></asp:Label>
        <asp:DropDownList ID="DdlEspecialidad" runat="server"></asp:DropDownList>
    </div>




</asp:Content>
