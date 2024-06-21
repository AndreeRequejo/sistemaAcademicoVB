<%@ Page Title="Inicio" Language="vb" AutoEventWireup="false" MasterPageFile="~/SistemaAcademico.Master" CodeBehind="indexSA.aspx.vb" Inherits="AplicacionWeb.indexSA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body, html {
            margin: 0;
            padding: 0;
            width: 100%;
            height: 100%;
            overflow: hidden;
        }

        .container-fluid {
            padding: 0;
        }

        .full-page-image {
            width: 100%;
            height: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid w-100">
        <img class="full-page-image" src="https://www.sunedu.gob.pe/wp-content/uploads/2018/03/Post-enlace-UDEP.jpg" alt="imgUsat">
    </div>
</asp:Content>
