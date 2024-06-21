Imports System.Windows.Forms
Imports Proyecto_LogicaNegocio

Public Class frmManSemestre
    Private objSemestre As New Semestre
    Private bandera As Boolean
    Private Sub frmManSemestre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        confInicio()
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        bandera = True
        txtCodSem.Enabled = True
        dtInicio.Enabled = True
        chboxEstado.Enabled = True
        dtFin.Enabled = True
        txtCodSem.Focus()
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
                retorno = objSemestre.agregar_semestre(txtCodSem.Text, dtInicio.Value.Date, dtFin.Value.Date, chboxEstado.Checked)
            Else
                '#Modificar'
                retorno = objSemestre.modificar_semestre(txtCodSem.Text, dtInicio.Value.Date, dtFin.Value.Date, chboxEstado.Checked)
            End If
            Select Case retorno
                Case 0
                    mensaje = If(bandera, "Registro completo", "Actualización completa")
                Case 1
                    mensaje = "Duplicado"
            End Select
            MessageBox.Show(mensaje)
            llenar_grilla()
            txtCodSem.Enabled = False
            dtInicio.Enabled = False
            dtFin.Enabled = False
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
        txtCodSem.Enabled = False
        dtInicio.Enabled = True
        dtFin.Enabled = True
        txtCodSem.Focus()
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
        chboxEstado.Enabled = True
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            Dim retorno As Integer
            Dim mensaje As String = String.Empty
            retorno = objSemestre.eliminar_semestre(txtCodSem.Text)
            Select Case retorno
                Case 0
                    mensaje = "Semestre eliminada correctamente"
                Case 1
                    mensaje = "Semestre eliminada físicamente."
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

    Private Sub dgvSemestre_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSemestre.SelectionChanged
        Try
            txtCodSem.Text = dgvSemestre.CurrentRow.Cells(0).Value
            dtInicio.Text = dgvSemestre.CurrentRow.Cells(1).Value
            dtFin.Text = dgvSemestre.CurrentRow.Cells(2).Value

            If dgvSemestre.CurrentRow.Cells(3).Value.ToString.Equals("Vigente") Then
                chboxEstado.Checked = True
            Else
                chboxEstado.Checked = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Semestre_Click(sender As Object, e As EventArgs) Handles dgvSemestre.Click
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = True
        btnModificar.Enabled = True
        btnSalir.Enabled = True
    End Sub

    Sub confInicio()
        chboxEstado.Enabled = False
        txtCodSem.Enabled = False
        dtInicio.Enabled = False
        dtFin.Enabled = False
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
        dtInicio.Format = DateTimePickerFormat.Custom
        dtInicio.CustomFormat = "dd/MM/yyyy"
        dtFin.Format = DateTimePickerFormat.Custom
        dtFin.CustomFormat = "dd/MM/yyyy"
        llenar_grilla()
    End Sub

    Sub llenar_grilla()
        With Me.dgvSemestre
            .DataSource = objSemestre.listar_semestres()
            .Columns(0).Width = 70
            .Columns(0).HeaderText = "Codigo"
            .Columns(1).Width = 90
            .Columns(1).HeaderText = "Fecha inicio"
            .Columns(2).Width = 90
            .Columns(2).HeaderText = "Fecha fin"
            .Columns(3).Width = 90
            .Columns(3).HeaderText = "Estado"
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub
    Sub limpiar()
        txtCodSem.Clear()
        chboxEstado.Checked = False
    End Sub

    Private Sub dtInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtInicio.ValueChanged

    End Sub
End Class