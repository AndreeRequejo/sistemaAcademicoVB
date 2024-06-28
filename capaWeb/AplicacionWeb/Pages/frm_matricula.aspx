<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SistemaAcademico.Master" CodeBehind="frm_matricula.aspx.vb" Inherits="AplicacionWeb.frm_matricula1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-group {
            margin-bottom: 15px;
        }

        .button-row {
            display: flex;
            justify-content: center;
            gap: 1rem;
        }

        .table-container {
            margin-top: 20px;
            height: 300px;
            overflow-y: auto;
            background-color: #ccc;
        }

        fieldset {
            border: 1px solid #ccc;
            padding: 1rem;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 100%
        }

        legend {
            font-size: 1.5rem;
            font-weight: bold;
        }

        label {
            font-weight: bold;
        }

        .btnBuscar, .btnNuevo {
            width: 7rem;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 class="text-center mt-3 mb-3">Transacción Matrícula</h1>
        <div class="row">
            <div class="col-6">
                <div class="row mb-3">
                    <div class="col-7">
                        <input type="text" class="form-control" placeholder="Estudiante" aria-label="City" id="txtEstudiante">
                    </div>
                    <div class="col-auto">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-secondary btnBuscar" />
                    </div>
                    <div class="col-auto">
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary btnNuevo" />
                    </div>
                </div>
                <fieldset class="p-3 mb-3">
                    <legend>Matrícula</legend>
                    <div class="row mb-3">
                        <label for="fechaMatricula" class="col-2 col-form-label">Fecha:</label>
                        <div class="col-10">
                            <asp:TextBox ID="fechaMatricula" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mb-3" style="align-items: center !important">
                        <label for="semestre" class="col-2 col-form-label">Semestre:</label>
                        <div class="col-4">
                            <asp:TextBox ID="txtSemestre" runat="server" CssClass="form-control" Style="width: 82%"></asp:TextBox>
                        </div>
                        <label for="estado" class="col-2 col-form-label">Estado:</label>
                        <div class="col-auto">
                            <asp:CheckBox ID="chkEstado" CssClass="form-check-input" runat="server" Text="Activo" />
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label for="creditos" class="col-auto col-form-label">Crdts. Matriculados:</label>
                        <div class="col-2">
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                        <label for="baja" class="col-auto col-form-label" style="margin-left: 2rem">Fecha Baja:</label>
                        <div class="col-3">
                            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" TextMode="Date" Style="width: 11.5rem !important"></asp:TextBox>
                        </div>
                    </div>
                </fieldset>
                <fieldset class="p-3 mb-3">
                    <legend>Detalle Matrícula</legend>
                    <div class="row mb-3 align-items-center">
                        <label for="txtCiclo" class="col-1 col-form-label">Ciclo:</label>
                        <div class="col-2">
                            <asp:TextBox ID="ciclo" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <label for="estado" class="col-2 col-form-label">Curso:</label>
                        <div class="col-7">
                            <asp:DropDownList ID="cboCurso" CssClass="form-select" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-12 mt-3">
                            <asp:GridView ID="gvDetalle" CssClass="table table-bordered" runat="server" Width="594px" AutoGenerateColumns="False" Height="170px">
                                <Columns>
                                    <asp:BoundField DataField="detalle_id" HeaderText="ID" />
                                    <asp:BoundField DataField="denominacion" HeaderText="Grupo" />
                                    <asp:BoundField DataField="hora_inicio" HeaderText="Hr. Inicio" />
                                    <asp:BoundField DataField="hora_fin" HeaderText="Hr. Fin" />
                                    <asp:BoundField DataField="dia" HeaderText="Dia" />
                                    <asp:CommandField HeaderText="✓" ShowSelectButton="True" SelectText="✓" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="button-row">
                            <asp:Button ID="btnGrabar" runat="server" Text="Agregar" CssClass="btn btn-success" />
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning" />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" />
                        </div>
                    </div>
                </fieldset>
            </div>

            <div class="col-6">
                <div class="p-3 mb-3">
                    <asp:GridView ID="gvGrupo" CssClass="table table-bordered" runat="server" Width="594px" AutoGenerateColumns="False" Height="170px">
                        <Columns>
                            <asp:BoundField DataField="grupo_id" HeaderText="ID" />
                            <asp:BoundField DataField="semestre" HeaderText="Semestre" />
                            <asp:BoundField DataField="fecha" HeaderText="Fecha Mat." />
                            <asp:BoundField DataField="creditos" HeaderText="Crdts. Matr." />
                            <asp:BoundField DataField="estado" HeaderText="Estado" />
                            <asp:CommandField HeaderText="✓" ShowSelectButton="True" SelectText="✓" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="p-3 mb-3">
                    <asp:GridView ID="gvDetalleMatricula" CssClass="table table-bordered" runat="server" Width="594px" AutoGenerateColumns="False" Height="170px">
                        <Columns>
                            <asp:BoundField DataField="detalle_id" HeaderText="ID" />
                            <asp:BoundField DataField="curso" HeaderText="Curso" />
                            <asp:BoundField DataField="grupo" HeaderText="Nota" />
                            <asp:CommandField HeaderText="✓" ShowSelectButton="True" SelectText="✓" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
