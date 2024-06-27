<%@ Page Title="Grupos Horarios" ResponseEncoding="utf-8" ContentType="text/html; charset=utf-8" Debug="True" Language="vb" AutoEventWireup="false" MasterPageFile="~/SistemaAcademico.Master" CodeBehind="frm_grupo.aspx.vb" Inherits="AplicacionWeb.frm_grupo1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .contenedor {
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: row;
            gap: 2rem;
            margin: 2rem;
        }

        .form-group {
            display: flex;
            flex-direction: column;
            gap: 1rem;
        }

        .form-group input,
        .form-group select {
            height: 40px;
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
            width: 60%
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
            margin-top: 1rem;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Transacción Grupos Horarios</h2>
    <div class="contenedor">
        <fieldset>
            <legend>Grupo</legend>
            <div class="form-group">
                <div class="row">
                    <div class="col">
                        <label for="txtSemestre" class="for">Semestre:</label>
                        <asp:TextBox ID="txtSemestre" CssClass="form-control" runat="server" Height="40px" Width="30%" Enabled="false"></asp:TextBox>
                        <asp:TextBox ID="txtIdGrupo" runat="server" Height="40px" Visible="False"></asp:TextBox>
                    </div>
                    <div class="col" style="flex-basis:30%">
                        <label for="cboFacultad" class="for">Facultad:</label>
                        <asp:DropDownList ID="cboFacultad" CssClass="form-select" runat="server" Height="40px" Width="100%" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col" style="flex-basis:30%">
                        <label for="cboEscuela" class="for">Escuela:</label>
                        <asp:DropDownList ID="cboEscuela" CssClass="form-select" runat="server" Height="40px" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                    <div class="col">
                        <label for="cboCiclo" class="for">Ciclo:</label>
                        <asp:DropDownList ID="cboCiclo" CssClass="form-select" runat="server" Height="40px" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                    <div class="col">
                        <label for="txtVacantes" class="for">Vacantes:</label>
                        <asp:TextBox ID="txtVacantes" CssClass="form-control" runat="server" Height="40px"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <label for="cboCurso" class="for">Curso:</label>
                        <asp:DropDownList ID="cboCurso" CssClass="form-select" runat="server" Height="40px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <label for="txtDenominacion" class="for">Denominación:</label>
                        <asp:TextBox ID="txtDenominacion" CssClass="form-control" runat="server" Height="40px"></asp:TextBox>
                    </div>
                    <div class="col" style="flex-basis:40%">
                        <label for="cboDocente" class="for">Docente:</label>
                        <asp:DropDownList ID="cboDocente" CssClass="form-select" runat="server" Height="40px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col" style="flex: 2">
                        <label for="chkEstado" class="for">Estado:</label>
                        <asp:CheckBox ID="chkEstado" CssClass="form-check-input" runat="server" Text="Activo" />
                    </div>
                    <div class="col btn-content" style="flex-grow:5">
                        <asp:Button ID="btnNuevo" CssClass="btn btn-primary" runat="server" Text="Nuevo"/>&nbsp;
                        <asp:Button ID="btnGrabar" CssClass="btn btn-success" runat="server" Text="Grabar"/>&nbsp;
                        <asp:Button ID="btnModificar" CssClass="btn btn-warning" runat="server" Text="Modificar"/>&nbsp;
                        <asp:Button ID="btnEliminar" CssClass="btn btn-danger" runat="server" Text="Eliminar"/>&nbsp;
                        <asp:Button ID="btnCancelar" CssClass="btn btn-secondary" runat="server" Text="Cancelar"/>
                    </div>
                </div>
            </div>
        </fieldset>
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
   <div class="contenedor">
       <fieldset>
           <legend>Horario</legend>
           <div class="form-group">
               <div class="row">
                   <div class="col">
                       <label for="cboTipoAmb" class="for">Tipo Amb.:</label>
                       <asp:DropDownList ID="cboTipoAmb" CssClass="form-select" runat="server" Height="40px" Width="100%" AutoPostBack="true">
                       </asp:DropDownList>
                   </div>
                   <div class="col" style="flex-basis:30%">
                       <label for="cboAmbiente" class="for">Ambiente:</label>
                       <asp:DropDownList ID="cboAmbiente" CssClass="form-select" runat="server" Height="40px" Width="100%">
                       </asp:DropDownList>
                   </div>
               </div>
               <div class="row">
                   <div class="col" style="flex-basis:20%">
                       <label for="cboDia" class="for">Día:</label>
                       <asp:DropDownList ID="cboDias" CssClass="form-select" runat="server" Height="40px">
                       </asp:DropDownList>
                   </div>
                   <div class="col">
                       <label for="horaIni" class="for">Hora Inicio:</label>
                    <asp:TextBox ID="horaIni" runat="server" CssClass="form-control" TextMode="Time" Height="39px"></asp:TextBox>
                   </div>
                   <div class="col">
                       <label for="horaFin" class="for">Hora Fin:</label>
                    <asp:TextBox ID="horaFin" runat="server" CssClass="form-control" TextMode="Time" Height="39px"></asp:TextBox>
                   </div>
               </div>
               <div class="row">
                    <div class="col">
                        <asp:TextBox ID="txtGrupo" runat="server" Height="40px" Visible="False"></asp:TextBox>
                    </div>
                    <div class="col btn-content" style="flex-grow:5">
                        &nbsp;
                       <asp:Button ID="btnGrabarH" CssClass="btn btn-success" runat="server" Text="Grabar"/>&nbsp;
                       <asp:Button ID="btnModificarH" CssClass="btn btn-warning" runat="server" Text="Modificar"/>&nbsp;
                       <asp:Button ID="btnEliminarH" CssClass="btn btn-danger" runat="server" Text="Eliminar"/>&nbsp;
                       <asp:Button ID="btnCancelarH" CssClass="btn btn-secondary" runat="server" Text="Cancelar"/>
                   </div>
               </div>
           </div>
       </fieldset>
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
</asp:Content>
