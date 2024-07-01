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
            width: 6.95rem;
        }
        a {
            text-decoration: none;
        }
    </style>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 class="text-center mt-3 mb-3">Transacción Matrícula</h1>
        <div class="row">
            <div class="col-6">
                <div class="row mb-3">
                    <div class="col-7">
                        <asp:TextBox id="txtEstudiante" runat="server" aria-label="DNI Estudiante" placeholder="DNI Estudiante" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-auto">
                        <asp:LinkButton ID="btnBuscar" runat="server" Text="<i class='fas fa-search'></i>" CssClass="btn btn-secondary btnBuscar" OnClick="btnBuscar_Click"/>
                    </div>
                    <div class="col-auto">
                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary btnNuevo" runat="server" Text="<i class='fa-solid fa-plus'></i>" OnClick="btnNuevo_Click" />&nbsp;
                    </div>
                </div>
                <fieldset class="p-3 mb-3">
                    <legend>Matrícula</legend>
                    <div class="row mb-3">
                        <label for="fechaMatricula" class="col-2 col-form-label">Fecha:</label>
                        <div class="col-10">
                            <asp:TextBox ID="txtFechaMatricula" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
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
                            <asp:TextBox ID="txtCreditosMat" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        </div>
                        <label for="baja" class="col-auto col-form-label" style="margin-left: 2rem">Fecha Baja:</label>
                        <div class="col-3">
                            <asp:TextBox ID="txtFechaBaja" runat="server" CssClass="form-control" TextMode="Date" Style="width: 11.5rem !important"></asp:TextBox>
                        </div>
                        <div class="col-12 mt-3 d-flex justify-content-between">
                            <asp:Button ID="btnGrabarMat" runat="server" Text="Grabar" CssClass="btn btn-success" />
                            <asp:Button ID="btnModificarMat" runat="server" Text="Modificar" CssClass="btn btn-warning" />
                            <asp:Button ID="btnEliminarMat" runat="server" Text="Eliminar" CssClass="btn btn-danger" />
                            <asp:Button ID="btnCancelarMat" runat="server" Text="Cancelar" CssClass="btn btn-secondary" />
                        </div>
                    </div>
                </fieldset>
                <fieldset class="p-3 mb-3">
                    <legend>Detalle Matrícula</legend>
                    <div class="row mb-3 align-items-center">
                        <label for="estado" class="col-2 col-form-label">Curso:</label>
                        <div class="col-10">
                            <asp:DropDownList ID="cboCurso" CssClass="form-select" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-12 mt-3">
                            <asp:GridView ID="gvGrupo" CssClass="table table-bordered table-striped table-hover text-center" runat="server" Width="600px" AutoGenerateColumns="False" Height="100px">
                                <Columns>
                                    <asp:BoundField DataField="grupo_id" HeaderText="ID" />
                                    <asp:BoundField DataField="denominacion" HeaderText="Grupo" />
                                    <asp:BoundField DataField="horario_formato" HeaderText="Horario" />
                                    <asp:BoundField DataField="docente" HeaderText="Docente" />
                                    <asp:CommandField HeaderText="Agr." ShowSelectButton="True" SelectText="➕" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="col-12 d-flex justify-content-between">
                            <div>
                                <asp:TextBox id="txtNota" runat="server" aria-label="Nota" placeholder="Nota" CssClass="form-control" TextMode="Number" min="0" max="20" Width="208px"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Button ID="btnModificarDetalle" runat="server" Text="Modificar" CssClass="btn btn-warning" />
                                <asp:Button ID="btnEliminarDetalle" runat="server" Text="Eliminar" CssClass="btn btn-danger" />
                                <asp:Button ID="btnCancelarDetalle" runat="server" Text="Cancelar" CssClass="btn btn-secondary" />
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>

            <div class="col-6">
                <asp:TextBox id="txtNomEstudiante" runat="server" aria-label="Estudiante" placeholder="Estudiante" CssClass="form-control mb-3" Width="685px" disabled></asp:TextBox>
                <fieldset class="mb-3" style="height:294px; width: 685px; overflow: auto">
                    <asp:GridView ID="gvMatricula" CssClass="table table-bordered table-striped table-hover" runat="server" Width="650px" AutoGenerateColumns="False" Height="100px">
                        <Columns>
                            <asp:BoundField DataField="matricula_id" HeaderText="ID" />
                            <asp:BoundField DataField="codigo_semestre" HeaderText="Semestre" />
                            <asp:BoundField DataField="fecha_matricula" HeaderText="Fecha Mat." />
                            <asp:BoundField DataField="nro_creditos_matriculados" HeaderText="Crdts. Matr." />
                            <asp:BoundField DataField="estado_matricula" HeaderText="Estado" />
                            <asp:BoundField DataField="fecha_baja" HeaderText="Fecha Baja" />
                            <asp:CommandField HeaderText="✓" ShowSelectButton="True" SelectText="✏️" />
                        </Columns>
                    </asp:GridView>
                </fieldset>
                <fieldset class="p-3 mb-3" style="width: 685px; overflow: auto">
                    <asp:GridView ID="gvDetalleMatricula" CssClass="table table-bordered table-striped table-hover text-center" runat="server" Width="650px" AutoGenerateColumns="False" Height="100px">
                        <Columns>
                            <asp:BoundField DataField="matricula_id" HeaderText="Matricula" />
                            <asp:BoundField DataField="grupo_id" HeaderText="Grupo" />
                            <asp:BoundField DataField="curso" HeaderText="Curso" />
                            <asp:BoundField DataField="nota_promedio" HeaderText="Nota" />
                            <asp:CommandField HeaderText="✓" ShowSelectButton="True" SelectText="✏️" />
                        </Columns>
                    </asp:GridView>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
