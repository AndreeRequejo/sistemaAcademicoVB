Imports System.Windows.Forms
Imports Proyecto_LogicaNegocio

Public Class frmManPlanEstudio
    Private objPlanEstudio As New PlanEstudio
    Private bandera As Boolean
    Private Sub frmManPlanEstudio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        confInicio()
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        bandera = True
        txtCodigoPlan.Enabled = True
        txtDescPlan.Enabled = True
        txtDescPlan.Focus()
        limpiar()
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
    End Sub
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            Dim retorno As Integer
            Dim mensaje As String = String.Empty
            If bandera Then
                '#Insertar'
                retorno = objPlanEstudio.agregar_planEstudio(txtCodigoPlan.Text, txtDescPlan.Text, chboxEstado.Checked)
            Else
                '#Modificar'
                retorno = objPlanEstudio.modificar_planEstudio(txtCodigoPlan.Text, txtDescPlan.Text, chboxEstado.Checked)
            End If
            Select Case retorno
                Case 0
                    mensaje = If(bandera, "Registro completo", "Actualización completa")
                Case 1
                    mensaje = "Duplicado"
            End Select
            MessageBox.Show(mensaje)
            llenar_grilla()
            txtCodigoPlan.Enabled = False
            txtDescPlan.Enabled = False
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
        txtCodigoPlan.Enabled = False
        txtDescPlan.Enabled = True
        txtCodigoPlan.Focus()
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
            retorno = objPlanEstudio.eliminar_planEstudio(CInt(txtCodigoPlan.Text))
            Select Case retorno
                Case 0
                    mensaje = "Facultad eliminada correctamente"
                Case 1
                    mensaje = "Facultad eliminada físicamente."
            End Select
            MessageBox.Show(mensaje)
            llenar_grilla()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        confInicio()
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub
    Private Sub dgvPlanEstudio_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPlanEstudio.SelectionChanged
        Try
            txtCodigoPlan.Text = dgvPlanEstudio.CurrentRow.Cells(0).Value
            txtDescPlan.Text = dgvPlanEstudio.CurrentRow.Cells(1).Value
            If dgvPlanEstudio.CurrentRow.Cells(2).Value.ToString.Equals("Vigente") Then
                chboxEstado.Checked = True
            Else
                chboxEstado.Checked = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub dgvPlanEstudio_Click(sender As Object, e As EventArgs) Handles dgvPlanEstudio.Click
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = True
        btnModificar.Enabled = True
        btnSalir.Enabled = True
    End Sub
    Sub confInicio()
        chboxEstado.Checked = False
        txtCodigoPlan.Enabled = False
        txtDescPlan.Enabled = False
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
        llenar_grilla()
    End Sub
    Sub llenar_grilla()
        With Me.dgvPlanEstudio
            .DataSource = objPlanEstudio.listar_planes_tabla()
            .Columns(0).Width = 70
            .Columns(0).HeaderText = "Codigo"
            .Columns(1).Width = 150
            .Columns(1).HeaderText = "Nombre de Facultad"
            .Columns(2).Width = 100
            .Columns(2).HeaderText = "Estado"
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub
    Sub limpiar()
        txtCodigoPlan.Clear()
        txtDescPlan.Clear()
        chboxEstado.Checked = False
    End Sub

End Class