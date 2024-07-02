<%@ Page Title="Grupos Horarios" ResponseEncoding="utf-8" ContentType="text/html; charset=utf-8" Debug="True" Language="vb" AutoEventWireup="false" MasterPageFile="~/SistemaAcademico.Master" CodeBehind="frm_grupoHorario.aspx.vb" Inherits="AplicacionWeb.frm_grupo1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .contenedor {
            display: flex;
            align-items: flex-start;
            justify-content: center;
            flex-direction: row;
            gap: 2rem;
            margin: 2rem;
        }

        .form-group {
            display: flex;
            flex-direction: column;
            gap: 1rem;
            width: 100%;
        }

        .form-group input,
        .form-group select {
            height: 40px;
            width: 100%;
        }

        .title {
            text-align: center;
            font-weight: bold;
            font-size: 3rem;
            margin: 0;
            padding: 0;
        }

        fieldset {
            border: 1px solid #ccc;
            padding: 1rem;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 100%;
        }

        legend {
            font-size: 1.5rem;
            font-weight: bold;
        }

        .row {
            display: flex;
            flex-wrap: wrap;
            gap: 1rem;
        }

        .col {
            flex: 1;
            display: flex;
            align-items: center;
            gap: 0.5rem;
            min-width: 150px;
        }

        .btn-content {
            display: flex;
            align-items: center;
            gap: 0.5rem;
        }

        .btn-content button {
            flex: 1;
        }

        label.for {
            font-weight: bold;
        }

        .form-check-input {
            display: flex;
            align-items: center;
        }

        h2 {
            text-align: center;
            margin: 2rem;
        }

        .table {
            width: 100%;
            margin-bottom: 1rem;
            color: #212529;
            border-collapse: collapse;
        }
        .table th,
        .table td {
            padding: 0.75rem;
            vertical-align: top;
            border-top: 1px solid #dee2e6;
        }

        .table thead th {
            vertical-align: bottom;
            border-bottom: 2px solid #dee2e6;
        }

        .table tbody + tbody {
            border-top: 2px solid #dee2e6;
        }

        .table-sm th,
        .table-sm td {
            padding: 0.3rem;
        }

        .table-bordered {
            border: 1px solid #dee2e6;
        }

        .table-bordered th,
        .table-bordered td {
            border: 1px solid #dee2e6;
        }

        .table-bordered thead th,
        .table-bordered thead td {
            border-bottom-width: 2px;
        }

        .table-striped tbody tr:nth-of-type(odd) {
            background-color: rgba(0, 0, 0, 0.05);
        }

        .table-hover tbody tr:hover {
            color: #212529;
            background-color: rgba(0, 0, 0, 0.075);
        }

        .btn-icon i {
            margin-right: 2px;
        }

        .linkbutton-disabled {
            pointer-events: none;
            opacity: 0.6;
        }
        a {
            text-decoration: none;
        }
    </style>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Transacción Grupos Horarios</h2>
    <div class="contenedor">
        <fieldset style="flex: 1.7;">
            <legend>Grupo</legend>
            <div class="form-group">
                <div class="row">
                    <div class="col" style="flex-basis: 100%;">
                        <label for="txtSemestre" class="for">Semestre:</label>
                        <asp:TextBox ID="txtSemestre" CssClass="form-control" runat="server" Height="40px" Width="35%" Enabled="false"></asp:TextBox>
                        <asp:TextBox ID="txtIdGrupo" runat="server" Height="40px" hidden></asp:TextBox>
                        <label for="cboFacultad" class="for">Facultad:</label>
                        <asp:DropDownList ID="cboFacultad" CssClass="form-select" runat="server" Height="40px" Width="" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col" style="flex-basis: 100%;">
                        <label for="cboEscuela" class="for">Escuela:</label>
                        <asp:DropDownList ID="cboEscuela" CssClass="form-select" runat="server" Height="40px" Width="60%" AutoPostBack="true"></asp:DropDownList>
                        <label for="cboCiclo" class="for">Ciclo:</label>
                        <asp:DropDownList ID="cboCiclo" CssClass="form-select" runat="server" Height="40px" Width="15%" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col" style="flex-basis: 100%;">
                        <label for="txtDenominacion" class="for">Denominación:</label>
                        <asp:TextBox ID="txtDenominacion" CssClass="form-control" runat="server" Height="40px" Width="14%" ReadOnly="True"></asp:TextBox>
                        <label for="txtVacantes" class="for">Vacantes:</label>
                        <asp:TextBox ID="txtVacantes" CssClass="form-control" runat="server" Height="40px" Width="11%"></asp:TextBox>
                        <label for="chkEstado" class="for">Estado:</label>
                        <asp:CheckBox ID="chkEstado" CssClass="form-check-input" runat="server" Text="Activo" />
                    </div>
                </div>
                <div class="row">
                    <div class="col" style="flex-basis: 100%;">
                        <label for="cboCurso" class="for">Curso:</label>
                        <asp:DropDownList ID="cboCurso" CssClass="form-select" runat="server" Height="40px"></asp:DropDownList>
                        <asp:LinkButton ID="btnBuscar" CssClass="btn btn-primary btn-icon" runat="server" Text="<i class='fas fa-search'></i>" OnClick="btnBuscar_Click" />&nbsp;
                        <asp:LinkButton ID="btnBuscar1" CssClass="btn btn-secondary btn-icon" runat="server" Text="<i class='fa-solid fa-arrow-down-a-z'></i>" OnClick="btnBuscar1_Click" />&nbsp;
                    </div>
                </div>
                <div class="row">
                    <div class="col" style="flex-basis: 100%;">
                        <label for="cboDocente" class="for">Docente:</label>
                        <asp:DropDownList ID="cboDocente" CssClass="form-select" runat="server" Height="40px" Width="430px"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col" style="flex-basis: 100%;">
                    </div>
                </div>
                <div class="row">
                    <div class="col btn-content" style="flex-basis: 100%;">
                        <asp:LinkButton ID="btnNuevo" CssClass="btn btn-primary" runat="server" Text="<i class='fa-solid fa-plus'></i>" />&nbsp;
                       
                        <asp:LinkButton ID="btnGrabar" CssClass="btn btn-success" runat="server" Text="<i class='fa-solid fa-floppy-disk'></i>" />&nbsp;
                       
                        <asp:LinkButton ID="btnModificar" CssClass="btn btn-warning" runat="server" Text="<i class='fa-solid fa-pen-to-square'></i>" />&nbsp;
                       
                        <asp:LinkButton ID="btnEliminar" CssClass="btn btn-danger" runat="server" Text="<i class='bx bxs-no-entry' ></i>" />&nbsp;
                       
                        <asp:LinkButton ID="btnCancelar" CssClass="btn btn-secondary" runat="server" Text="<i class='bx bx-notification-off' ></i>" />
                    </div>
                </div>
            </div>
        </fieldset>
        <fieldset style="flex: 3;">
            <legend>Grupos</legend>
            <asp:GridView ID="gvGrupos" CssClass="table table-bordered table-striped table-hover text-center" runat="server" Width="100%" AutoGenerateColumns="False" Height="170px">
                <Columns>
                    <asp:BoundField DataField="grupo_id" HeaderText="ID" />
                    <asp:BoundField DataField="nombre_curso" HeaderText="Curso" />
                    <asp:BoundField DataField="denominacion" HeaderText="Denominacion" />
                    <asp:BoundField DataField="estado_grupo" HeaderText="Estado" />
                    <asp:CommandField HeaderText="Acción" ShowSelectButton="True" SelectText="➕" />
                </Columns>
            </asp:GridView>
        </fieldset>
    </div>
    <div class="contenedor">
        <fieldset style="flex: 1.7;">
            <legend>Horario</legend>
            <div class="form-group">
                <div class="row">
                    <div class="col" style="flex-basis: 45%;">
                        <label for="cboTipoAmb" class="for">Tipo Amb.:</label>
                        <asp:DropDownList ID="cboTipoAmb" CssClass="form-select" runat="server" Height="40px" Width="100%" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="col" style="flex-basis: 45%;">
                        <label for="cboAmbiente" class="for">Ambiente:</label>
                        <asp:DropDownList ID="cboAmbiente" CssClass="form-select" runat="server" Height="40px" Width="100%"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col" style="flex-basis: 45%;">
                        <label for="cboDias" class="for">Día:</label>
                        <asp:DropDownList ID="cboDias" CssClass="form-select" runat="server" Height="40px" Width="60%"></asp:DropDownList>
                        <label for="horaIni" class="for">Hora Inicio:</label>
                        <asp:TextBox ID="horaIni" runat="server" CssClass="form-control" TextMode="Time" Height="39px" Width="50%"></asp:TextBox>
                        <label for="horaFin" class="for">Hora Fin:</label>
                        <asp:TextBox ID="horaFin" runat="server" CssClass="form-control" TextMode="Time" Height="39px" Width="50%"></asp:TextBox>
                    </div>
                    <div class="row">
                        <div class="col" style="flex-basis: 45%;">
                            <label for="txtGrupo" class="for" hidden>Grupo_ID.:</label>
                            <asp:TextBox ID="txtGrupo" CssClass="form-control" runat="server" Height="40px" Width="14%" ReadOnly="True" hidden></asp:TextBox>
                            <asp:TextBox ID="txtHorario" runat="server" Height="40px" hidden></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col btn-content" style="flex-basis: 100%;">

                        <asp:LinkButton ID="btnNuevoH" CssClass="btn btn-primary" runat="server" Text="<i class='fa-solid fa-plus'></i>" />&nbsp;
                       
                        <asp:LinkButton ID="btnGrabarH" CssClass="btn btn-success" runat="server" Text="<i class='fa-solid fa-floppy-disk'></i>" />&nbsp;
                       
                        <asp:LinkButton ID="btnModificarH" CssClass="btn btn-warning" runat="server" Text="<i class='fa-solid fa-pen-to-square'></i>" />&nbsp;
                       
                        <asp:LinkButton ID="btnEliminarH" CssClass="btn btn-danger" runat="server" Text="<i class='bx bxs-no-entry' ></i>" />&nbsp;
                       
                        <asp:LinkButton ID="btnCancelarH" CssClass="btn btn-secondary" runat="server" Text="<i class='bx bx-notification-off' ></i>" />
                        </div>
                    </div>
                </div>
        </fieldset>
        <fieldset style="flex: 3;">
            <legend>Horario</legend>
            <asp:GridView ID="gvHorarios" CssClass="table table-bordered table-striped table-hover text-center" runat="server" Width="100%" AutoGenerateColumns="False" Height="170px">
                <Columns>
                    <asp:BoundField DataField="horario_id" HeaderText="ID" />
                    <asp:BoundField DataField="denominacion" HeaderText="Denominacion" />
                    <asp:BoundField DataField="horario_formato" HeaderText="Horario" />
                    <asp:CommandField HeaderText="Acción" ShowSelectButton="True" SelectText="✏️" />
                </Columns>
            </asp:GridView>
        </fieldset>
    </div>
</asp:Content>
