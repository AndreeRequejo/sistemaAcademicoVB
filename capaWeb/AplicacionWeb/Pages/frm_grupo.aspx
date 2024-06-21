<%@ Page Title="Grupos Horarios" ResponseEncoding="utf-8" ContentType="text/html; charset=utf-8" Debug="True" Language="vb" AutoEventWireup="false" MasterPageFile="~/SistemaAcademico.Master" CodeBehind="frm_grupo.aspx.vb" Inherits="AplicacionWeb.frm_grupo1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .contenedor {
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: column;
        }

        .btn-content {
            text-align: center !important;
            margin: 0;
        }

        td {
            padding-right: 3rem;
            padding-bottom: 0.5rem;
        }

        .title {
            text-align: center;
            font-weight: bold;
            font-size: 3rem;
            margin: 0;
            padding: 0;
        }

        .auto-style5 {
            text-align: right;
            padding: 1.5rem;
        }
        .auto-style6 {
            width: 123px;
        }
        .auto-style7 {
            text-align: right;
            height: 29px;
        }
        .auto-style8 {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">
        <table class="auto-style1">
            <tr>
                <td colspan="4" class="title">Transacción Horarios</td>
            </tr>
            <tr>
                <td class="auto-style5">Denominación:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtDenominacion" CssClass="form-control" runat="server" Height="40px"></asp:TextBox>
                    <asp:TextBox ID="txtIdGrupo" runat="server" Height="40px" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">N° vacantes:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtVacantes" CssClass="form-control" runat="server" Height="40px" Width="117px"></asp:TextBox>
                </td>
                <td class="auto-style6">Estado:</td>
                <td class="auto-style6">
                    <asp:CheckBox ID="chkEstado" CssClass="form-check-input" runat="server" Text="Activo" />
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Curso:</td>
                <td class="auto-style4">
                    <asp:DropDownList ID="cboCurso" CssClass="form-select" runat="server" Height="40px" Width="422px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Docente:</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="cboDocente" CssClass="form-select" runat="server" Height="40px" Width="422px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Semestre:</td>
                <td class="auto-style4">
                    <asp:DropDownList ID="cboSemestre" CssClass="form-select" runat="server" Height="40px" Width="422px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td Class="btn-content" colspan="4">
                    <asp:Button ID="btnNuevo" CssClass="btn btn-primary" runat="server" Text="Nuevo"/>&nbsp;
                    <asp:Button ID="btnGrabar" CssClass="btn btn-success" runat="server" Text="Grabar"/>&nbsp;
                    <asp:Button ID="btnModificar" CssClass="btn btn-warning" runat="server" Text="Modificar"/>&nbsp;
                    <asp:Button ID="btnEliminar" CssClass="btn btn-danger" runat="server" Text="Eliminar"/>&nbsp;
                    <asp:Button ID="btnCancelar" CssClass="btn btn-secondary" runat="server" Text="Cancelar"/></td>&nbsp;
            </tr>
        </table>
        <asp:GridView ID="gvGrupos" CssClass="table table-bordered" runat="server" Width="1199px" AutoGenerateColumns="False" Height="170px">
            <Columns>
                <asp:BoundField DataField="grupo_id" HeaderText="ID" />
                <asp:BoundField DataField="denominacion" HeaderText="Denominacion" />
                <asp:BoundField DataField="numero_vacantes" HeaderText="Vacantes" />
                <asp:BoundField DataField="estado_grupo" HeaderText="Estado" />
                <asp:BoundField DataField="nombre_curso" HeaderText="Curso" />
                <asp:BoundField DataField="nombre_docente" HeaderText="Docente" />
                <asp:BoundField DataField="semestre_id" HeaderText="Semestre" />
                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
