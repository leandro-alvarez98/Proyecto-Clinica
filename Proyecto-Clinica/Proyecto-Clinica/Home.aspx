<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Proyecto_Clinica.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="sidebar"> 
        <div class="logo_details">
            <div class="logo_name">code effect</div>
            <i class="bx bx-menu"></i>
        </div>
        <ul class="nav-list">
            <li>
                <a href="#">
                    <i class='bx bx-user'></i>
                    <span class="link_name">usuario</span>
                </a>
                <%--  <span class="tooltip">usuario</span>--%>
            </li>
            <li>
                <a href="#">
                    <i class='bx bx-notepad'></i>
                    <span class="link_name">Turnos</span>
                </a>
              <%--  <span class="tooltip">turnos</span>--%>
            </li>
            <li>
                <a href="#">
                    <i class='bx bxs-bar-chart-alt-2'></i>
                    <span class="link_name">Estadisticas</span>
                </a>
                <%--  <span class="tooltip">Estadisticas</span>--%>
            </li>
            <li class="profile">
                <div class="profile-details">
                    <asp:Image ImageUrl="imageurl" runat="server" />
                    <div class="profile_content"> 
                        <div class="name">Anna Jhon</div>
                        <div class="designation">Admin</div>
                    </div>
                </div>
            </li>
        </ul>
    </div>

    <div id="turnos">
        <asp:Label ID="Label1" runat="server" Text="especialidad"></asp:Label>
        <asp:DropDownList ID="DdlEspecialidad" runat="server"></asp:DropDownList>
    </div>




</asp:Content>
