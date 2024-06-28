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
        #btnNuevo {
            width: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 class="text-center mt-3 mb-3">Transacción Matrícula</h1>
        <div class="row">
            <div class="col-6">
                <div class="mb-3 d-flex justify-content-between">
                    <div class="col-7">
                        <input type="text" class="form-control" placeholder="Estudiante" aria-label="City">
                    </div>
                    <div class="col-2">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-secondary" />
                    </div>
                    <div class="col-3">
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary" />
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
                            <asp:TextBox ID="txtSemestre" runat="server" CssClass="form-control" Style="width: 65%"></asp:TextBox>
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
                        <label for="estado" class="col-auto col-form-label" style="margin-left: 2rem">Fecha Baja:</label>
                        <div class="col-3">
                            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                </fieldset>
                <fieldset class="p-3 mb-3">
                    <legend>Detalle Matrícula</legend>
                    <div class="row mb-3 align-items-center">
                        <label for="txtSemestre" class="col-auto col-form-label">Ciclo:</label>
                        <div class="col-auto">
                            <asp:TextBox ID="ciclo" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <label for="estado" class="col-2 col-form-label">Estado:</label>
                        <div class="col-auto">
                            <asp:CheckBox ID="CheckBox1" CssClass="form-check-input" runat="server" Text="Activo" />
                        </div>
                        <asp:GridView ID="gvHorarios" CssClass="table table-bordered" runat="server" Width="1199px" AutoGenerateColumns="False" Height="170px">
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
                </fieldset>
            </div>

            <div class="col-6">
                Wawita
            </div>
        </div>
        <div class="button-row">
            <asp:Button ID="btnGrabar" runat="server" Text="Grabar" CssClass="btn btn-success" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" />
        </div>
        <div class="table-container">
        </div>
    </div>
</asp:Content>
