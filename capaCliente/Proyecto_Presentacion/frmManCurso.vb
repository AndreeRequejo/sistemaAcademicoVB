Imports System.Windows.Forms
Imports Proyecto_LogicaNegocio

Public Class frmManCurso
    Dim objCurso As New Curso
    Dim objPlanEstudio As New PlanEstudio
    Dim objEscuela As New Escuela
    Dim objCiclo As New Agregados
    Private bandera As Boolean

    Private Sub frmManCurso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCbxTipoCurso()
        llenarCbxPlanEstudio()
        llenarCbxEscuela()
        llenarCbxCiclo()
        confInicio()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        bandera = True
        limpiar()
        cbxPlanEstudio.Enabled = True
        cbxEscuela.Enabled = True
        txtCodCurso.Focus()
        txtNomCurso.Enabled = True
        cbxCiclo.Enabled = True
        rdbObligatorio.Enabled = True
        spTeoria.Enabled = True
        spPractica.Enabled = True
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
    End Sub
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            Dim retorno As Integer
            Dim mensaje As String = String.Empty
            If bandera Then
                '#Insertar'
                retorno = objCurso.agregar_curso(txtCodCurso.Text, txtNomCurso.Text, spTeoria.Value, spPractica.Value, cbxCiclo.SelectedValue, rdbObligatorio.Checked, cbxPlanEstudio.SelectedValue, cbxEscuela.SelectedValue)

            Else
                '#Modificar'
                retorno = objCurso.modificar_curso(txtCodCurso.Text, txtNomCurso.Text, spTeoria.Value, spPractica.Value, cbxCiclo.SelectedValue, rdbObligatorio.Checked, cbxPlanEstudio.SelectedValue, cbxEscuela.SelectedValue)

            End If
            Select Case retorno
                Case 0
                    mensaje = If(bandera, "Registro completo", "Actualización completa")
                Case 1
                    mensaje = "Duplicado"
            End Select
            MessageBox.Show(mensaje)
            llenar_grilla()
            cbxPlanEstudio.Enabled = False
            cbxEscuela.Enabled = False
            txtNomCurso.Enabled = False
            cbxCiclo.Enabled = False
            rdbObligatorio.Enabled = False
            spTeoria.Enabled = False
            spPractica.Enabled = False
            btnNuevo.Enabled = True
            btnGrabar.Enabled = False
            btnCancelar.Enabled = False
            btnEliminar.Enabled = False
            btnModificar.Enabled = False
            btnSalir.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        bandera = False
        cbxPlanEstudio.Enabled = True
        cbxEscuela.Enabled = True
        txtCodCurso.Focus()
        txtNomCurso.Enabled = True
        cbxCiclo.Enabled = True
        rdbObligatorio.Enabled = True
        spTeoria.Enabled = True
        spPractica.Enabled = True
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            Dim retorno As Integer
            Dim mensaje As String = String.Empty
            retorno = objCurso.eliminar_curso(txtCodCurso.Text)
            Select Case retorno
                Case 0
                    mensaje = "Escuela eliminada correctamente"
                Case -1
                    mensaje = "Error al procesar eliminación."
            End Select
            MessageBox.Show(mensaje)
            llenar_grilla()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvCurso_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCurso.SelectionChanged
        Try
            txtCodCurso.Text = dgvCurso.CurrentRow.Cells(1).Value
            txtNomCurso.Text = dgvCurso.CurrentRow.Cells(2).Value
            lblCreditos.Text = dgvCurso.CurrentRow.Cells(3).Value
            spTeoria.Value = dgvCurso.CurrentRow.Cells(4).Value
            spPractica.Value = dgvCurso.CurrentRow.Cells(5).Value
            cbxCiclo.SelectedValue = dgvCurso.CurrentRow.Cells(6).Value
            If dgvCurso.CurrentRow.Cells(7).Value.Equals("Obligatorio") Then
                rdbObligatorio.Checked = True
            Else
                rdbObligatorio.Checked = False
            End If
            cbxPlanEstudio.SelectedValue = objPlanEstudio.buscarIdPlan(dgvCurso.CurrentRow.Cells(8).Value.ToString)
            cbxEscuela.SelectedValue = objEscuela.buscarIdEscuela(dgvCurso.CurrentRow.Cells(9).Value.ToString)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub dgvCurso_Click(sender As Object, e As EventArgs) Handles dgvCurso.Click
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = True
        btnModificar.Enabled = True
        btnSalir.Enabled = True
    End Sub
    Sub llenar_grilla()
        With Me.dgvCurso
            .DataSource = objCurso.listar_cursos()
            .Columns(1).Width = 90
            .Columns(1).HeaderText = "Cod. Curso"
            .Columns(2).Width = 250
            .Columns(2).HeaderText = "Nombre de curso"
            .Columns(3).Width = 50
            .Columns(3).HeaderText = "Creditos"
            .Columns(4).Width = 50
            .Columns(4).HeaderText = "H. teoría"
            .Columns(5).Width = 50
            .Columns(5).HeaderText = "H. practica"
            .Columns(6).Width = 40
            .Columns(6).HeaderText = "Ciclo"
            .Columns(7).Width = 70
            .Columns(7).HeaderText = "Tipo curso"
            .Columns(8).Width = 60
            .Columns(8).HeaderText = "Plan de estudios"
            .Columns(9).Width = 150
            .Columns(9).HeaderText = "Escuela"
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub
    Public Sub llenarCbxEscuela()
        Try
            cbxEscuela.DataSource = objEscuela.listar_escuelas()
            cbxEscuela.DisplayMember = "nombre_escuela"
            cbxEscuela.ValueMember = "escuela_id"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub llenarCbxPlanEstudio()
        Try
            cbxPlanEstudio.DataSource = objPlanEstudio.listar_planes()
            cbxPlanEstudio.DisplayMember = "plan_id"
            cbxPlanEstudio.ValueMember = "plan_id"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub llenarCbxCiclo()
        Try
            cbxCiclo.DataSource = objCiclo.listar_ciclos_escuela(cbxEscuela.SelectedValue)
            cbxCiclo.DisplayMember = "numero_ciclo"
            cbxCiclo.ValueMember = "numero_ciclo"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub llenarCbxTipoCurso()
        Try
            cbxCiclo.DataSource = objCurso.listar_tipo_cursos()
            cbxCiclo.DisplayMember = "tipo_curso"
            cbxCiclo.ValueMember = "tipo_curso"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub limpiar()
        txtNomCurso.Clear()
        txtCodCurso.Clear()
        lblCreditos.Text = ""
        rdbObligatorio.Checked = False
        spTeoria.Value = 0
        spPractica.Value = 0
    End Sub
    Sub confInicio()
        cbxPlanEstudio.Enabled = False
        cbxEscuela.Enabled = False
        txtNomCurso.Enabled = False
        cbxCiclo.Enabled = False
        rdbObligatorio.Enabled = False
        spTeoria.Enabled = False
        spPractica.Enabled = False
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
        llenar_grilla()
    End Sub

    Private Sub spPractica_ValueChanged(sender As Object, e As EventArgs) Handles spPractica.ValueChanged
        Dim teoria As Integer = spTeoria.Value
        Dim practica As Integer = spPractica.Value
        Dim creditos As Integer = teoria + practica / 2

        lblCreditos.Text = creditos
    End Sub

    Private Sub spTeoria_ValueChanged(sender As Object, e As EventArgs) Handles spTeoria.ValueChanged
        Dim teoria As Integer = spTeoria.Value
        Dim practica As Integer = spPractica.Value
        Dim creditos As Integer = teoria + practica / 2

        lblCreditos.Text = creditos
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        confInicio()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim formulario As New frmManCurso_Curso
        formulario.Show()

    End Sub
End Class