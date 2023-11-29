<%@ Page Title="" Language="C#" MasterPageFile="~/Master-page.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Proyecto_Clinica.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@100;200;300;400;500;600&display=swap');
        :root{
            --green:#16a085;
            --black:#444;
            --light-color:#777;
            --box-shadow:.5rem .5rem 0 rgba(22,160,133,.2);
            --text-shadow:.4rem .4rem 0 rgba(0,0,0,.2);
            --border:.2rem solid var (--green);
        }
        section{
            padding:2rem 9%;
        }
        .botonRepositorio{
            display:inline-block;
            margin-top:1rem;
            padding:.5rem;
            padding-left:1rem;
            border:var(--border);
            border-radius:.5rem;
            box-shadow:var(--box-shadow);
            color:var(--green);
            cursor:pointer;
            font-size:1.7rem;
        }
        .botonRepositorio span{
            padding:.7rem 1rem;
            border-radius:.4rem;
            background:var(--green);
            color:#fff;
            margin-left:.5rem;
        }
        .botonRepositorio:hover{
            background: var(--green);
            color:#fff;
        }
        .botonRepositorio:hover span{
            color: var(--green);
            background:#fff;
            margin-left:1rem;
        }
        .home{
            display:flex;
            align-items:center;
            flex-wrap:wrap;
            gap:1.5rem;
            padding-top:10rem;
        }
        .home .image{
            flex:1 1 45rem;
        }
        .home .image img{
            width:25%;
        }
        .home .content{
            flex:1 1 45rem;
        }
        .home .content h3{
            font-size:4.5rem;
            color: var(--black);
            line-height:1.8;
            text-shadow:var(--text-shadow);
        }
        .home .content p{
            font-size:1.7rem;
            color: var(--light-color);
            line-height:1.8;
            padding:1rem 0;
        }
    </style>

    <section class="home" id="home">
        <div class="image">
            <img src="img/fondoDoctores.svg" alt="" />

        </div>
        <div class="content">
            <h3>Bienvenido a la Clínica del equipo 18</h3>
            <p>Espacio para poner descripcion / mensaje</p>
            <a href="#" class="botonRepositorio"><i class='bx bxl-github'></i> Repositorio <span><i class='bx bxs-arrow-to-right'></i></span></a>
        </div>
    </section>

</asp:Content>
