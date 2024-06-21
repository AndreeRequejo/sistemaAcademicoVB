<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SistemaAcademico.Master" CodeBehind="frm_matricula.aspx.vb" Inherits="AplicacionWeb.frm_matricula1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .container {
        margin-top: 20px;
    }
    .form-group {
        margin-bottom: 15px;
    }
    .button-row {
        display: flex;
        justify-content: center;
        gap: 1rem;
    }
    .button-row button {
        margin: 1rem;
    }
    .table-container {
        margin-top: 20px;
        height: 300px;
        overflow-y: auto;
        background-color: #ccc;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <h1 class="text-center">Transacción Matrícula</h1>
    <div class="form-group row">
        <label for="matriculaID" class="col-sm-2 col-form-label">Matrícula ID:</label>
        <div class="col-sm-10">
            <asp:TextBox ID="matriculaID" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label for="fechaMatricula" class="col-sm-2 col-form-label">Fecha matrícula:</label>
        <div class="col-sm-4">
            <asp:TextBox ID="fechaMatricula" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
        <label for="horaMatricula" class="col-sm-2 col-form-label">Hora matrícula:</label>
        <div class="col-sm-4">
            <asp:TextBox ID="horaMatricula" runat="server" CssClass="form-control" TextMode="Time"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label for="alumnoID" class="col-sm-2 col-form-label">Alumno ID:</label>
        <div class="col-sm-4">
            <asp:DropDownList ID="alumnoID" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <label for="codigoSemestre" class="col-sm-2 col-form-label">Código semestre:</label>
        <div class="col-sm-4">
            <asp:DropDownList ID="codigoSemestre" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>
    <div class="form-group row">
        <label for="tipoMatricula" class="col-sm-2 col-form-label">Tipo matrícula:</label>
        <div class="col-sm-10">
            <asp:CheckBox ID="tipoMatricula" runat="server" CssClass="form-check-input" />
            <label for="tipoMatricula" class="form-check-label">Activo</label>
        </div>
    </div>
    <div class="button-row">
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary" />
        <asp:Button ID="btnGrabar" runat="server" Text="Grabar" CssClass="btn btn-success" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" />
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" />
    </div>
    <div class="table-container">
        
    </div>
</div>
</asp:Content>
