<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SistemaAcademico.Master" CodeBehind="frm_horario.aspx.vb" Inherits="AplicacionWeb.frm_horario" %>

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
        }
        td {
            padding-right: 3rem;
            padding-bottom: 1rem;
        }
        .title {
            text-align: center;
            font-weight: bold;
            font-size: 3rem;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">
        <table class="auto-style16">
            <tr>
                <td colspan="4" Class="title">Mantenimiento de Horarios</td>
            </tr>
            <tr>
                <td class="auto-style7">Codigo:</td>
                <td class="auto-style9">
                    <asp:Label ID="lblCodigo" CssClass="form-control" runat="server" Height="40px" Width="144px" Style="margin-bottom: 0px"></asp:Label>
                </td>
                <td class="auto-style3">Semestre:</td>
                <td class="auto-style26">
                    <asp:DropDownList ID="cboSemestre" CssClass="form-select" runat="server" Height="40px" Width="146px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style13">Facultad:</td>
                <td class="auto-style9">
                    <asp:DropDownList ID="cboFacultad" CssClass="form-select" runat="server" AutoPostBack="true" Width="300px" Height="40px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style3">Escuela:</td>
                <td class="auto-style26">
                    <asp:DropDownList ID="cboEscuela" CssClass="form-select" runat="server" AutoPostBack="true" Width="300px" Height="40px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style13">Ciclo:</td>
                <td class="auto-style9">
                    <asp:DropDownList ID="cboCiclo" CssClass="form-select" runat="server" AutoPostBack="true" Width="100px" Height="40px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style3">Curso:</td>
                <td class="auto-style5">
                    <asp:DropDownList ID="cboCurso" CssClass="form-select" runat="server" AutoPostBack="true" Width="300px" Height="40px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Grupo:</td>
                <td class="auto-style9">
                    <asp:DropDownList ID="cboGrupo" CssClass="form-select" runat="server" Width="100px" Height="40px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style3">Docente:</td>
                <td class="auto-style26">
                    <asp:Label ID="lblDoc" CssClass="form-control align-items-center" runat="server" Height="40px" disabled></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Ambiente:</td>
                <td class="auto-style9">
                    <asp:DropDownList ID="cboAmbiente" CssClass="form-select" runat="server" Width="300px" Height="40px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style3">Día:</td>
                <td class="auto-style26">
                    <asp:DropDownList ID="cboDias" CssClass="form-select" runat="server" Width="300px" Height="40px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Hora Inicio:</td>
                <td class="auto-style10">
                    <asp:TextBox ID="horaIni" runat="server" CssClass="form-control" TextMode="Time" Height="39px" Width="300px"></asp:TextBox>
                </td>
                <td class="auto-style8">Hora Final:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="horaFin" runat="server" CssClass="form-control" TextMode="Time" Height="40px" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4" Class="btn-content">&nbsp;
                    <asp:Button CssClass="btn btn-primary" ID="btnNuevo" runat="server" Text="Nuevo" />&nbsp;
                    <asp:Button CssClass="btn btn-success" ID="btnGrabar" runat="server" Text="Grabar" />&nbsp;
                    <asp:Button CssClass="btn btn-warning" ID="btnModificar" runat="server" Text="Modificar" />&nbsp;
                    <asp:Button CssClass="btn btn-danger" ID="btnEliminar" runat="server" Text="Eliminar" />&nbsp;
                    <asp:Button CssClass="btn btn-secondary" ID="btnCancelar" runat="server" Text="Cancelar" />&nbsp;
                </td>
            </tr>

        </table>

        <asp:GridView ID="gvHorarios" runat="server" AutoGenerateColumns="False" CssClass="auto-style6 table table-bordered" Width="1073px" Style="margin-bottom: 258px">
            <Columns>
                <asp:BoundField DataField="horario_id" HeaderText="Codigo">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="dia" HeaderText="Dia" />
                <asp:BoundField DataField="h_inicio" HeaderText="Hora Inicio" />
                <asp:BoundField DataField="h_final" HeaderText="Hora Fin" />
                <asp:BoundField DataField="nombre_curso" HeaderText="Curso" />
                <asp:BoundField DataField="denominacion" HeaderText="Grupo">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nombre_docente" HeaderText="Docente" />
                <asp:BoundField DataField="descripcion_ambiente" HeaderText="Ambiente" />
                <asp:TemplateField HeaderText="Seleccionar" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Seleccionar"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
