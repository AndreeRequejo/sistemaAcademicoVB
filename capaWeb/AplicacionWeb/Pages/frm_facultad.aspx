<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SistemaAcademico.Master" CodeBehind="frm_facultad.aspx.vb" Inherits="AplicacionWeb.frm_facultad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table class="auto-style5">
    <tr>
        <td colspan="2">Mantenimiento de Facultades</td>
    </tr>

	<tr>
        <td class="auto-style3">Código</td>
        <td id="lblCodigo" class="auto-style1">
            <asp:Label ID="lblCodigo" runat="server"></asp:Label>
        </td>
    </tr>

	<tr>
        <td class="auto-style3">Nombre de Facultad</td>
        <td class="auto-style1">
            <asp:TextBox ID="txtNomFacultad" runat="server" Width="429px"></asp:TextBox>
        </td>
    </tr>

	<tr>
        <td class="auto-style4" colspan="2">
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="button-style" />&nbsp;
			<asp:Button ID="btnGrabar" runat="server" Text="Grabar" CssClass="button-style" />&nbsp;
			<asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="button-style" />&nbsp;
			<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="button-style" />&nbsp;
		    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="button-style" />
		</td>
    </tr>
    
</table>
&nbsp;
<asp:GridView ID="gvFacultades" runat="server" AutoGenerateColumns="False" Height="38px" Width="596px">
    <Columns>
        <asp:BoundField DataField="facultad_id" HeaderText="Codigo" />
        <asp:BoundField DataField="nombre_facultad" HeaderText="Nombre Facultad" />
        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
    </Columns>
</asp:GridView>
</asp:Content>
