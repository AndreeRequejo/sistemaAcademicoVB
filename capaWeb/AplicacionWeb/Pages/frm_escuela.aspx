<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SistemaAcademico.Master" CodeBehind="frm_escuela.aspx.vb" Inherits="AplicacionWeb.frm_escuela" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table style="width:100%;">
            <tr>
                <td colspan="2">Mantenimiento de Escuelas</td>
            </tr>
            <tr>
                <td class="auto-style4">Codigo</td>
                <td class="auto-style5">
                    <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Nombre de Escuela</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtNomEscuela" runat="server" Height="22px" Width="437px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Facultad</td>
                <td class="auto-style5">
                    <asp:DropDownList ID="cboFacultad" runat="server" Height="30px" Width="443px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" />
                &nbsp;<asp:Button ID="btnGrabar" runat="server" Text="Grabar" />
                &nbsp;<asp:Button ID="btnModificar" runat="server" Text="Modificar" />
                &nbsp;<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />
                &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
                </td>
            </tr>            

        </table>
        
    &nbsp;

        <asp:GridView ID="gvEscuelas" runat="server" AutoGenerateColumns="False" CssClass="auto-style6" Width="629px">
            <Columns>
                <asp:BoundField DataField="escuela_id" HeaderText="Codigo" />
                <asp:BoundField DataField="nombre_escuela" HeaderText="Escuela" />
                <asp:BoundField DataField="nombre_facultad" HeaderText="Facultad" />
                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
</asp:Content>
