Imports System.Windows.Forms
Imports Proyecto_LogicaNegocio

Public Class frmManFacultad
    Private objFacultad As New Facultad
    Private bandera As Boolean

    Private Sub frmManFacultad_Load(sender As Object, e As EventArgs) Handles Me.Load
        confInicio()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        bandera = True
        txtFacultad.Enabled = True
        txtFacultad.Focus()
        limpiar()
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
        lblCodigo.Text = CStr(objFacultad.obtenerIdFac)
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            Dim retorno As Integer
            Dim mensaje As String = String.Empty
            If bandera Then
                If txtFacultad.Text <> String.Empty Then
                    '#Insertar'
                    retorno = objFacultad.agregar_facultad(lblCodigo.Text, txtFacultad.Text)
                Else
                    retorno = -1
                End If
            Else
                    '#Modificar'
                    retorno = objFacultad.modificar_facultad(lblCodigo.Text, txtFacultad.Text)
            End If
            Select Case retorno
                Case 0
                    mensaje = If(bandera, "Registro completo", "Actualización completa")
                Case 1
                    mensaje = "Duplicado"
                Case -1
                    mensaje = "Error al procesar la solicitud"
            End Select
            MessageBox.Show(mensaje)
            llenar_grilla()
            txtFacultad.Enabled = False
            btnNuevo.Enabled = True
            btnGrabar.Enabled = False
            btnCancelar.Enabled = False
            btnEliminar.Enabled = False
            btnModificar.Enabled = False
            btnSalir.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Hubo un error al procesar la solicitud.")
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        bandera = False
        txtFacultad.Enabled = True
        txtFacultad.Focus()
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
            retorno = objFacultad.eliminar_facultad(lblCodigo.Text)
            Select Case retorno
                Case 0
                    mensaje = "Facultad eliminada correctamente"
                Case -1
                    mensaje = "Error al procesar eliminación."
            End Select
            MessageBox.Show(mensaje)
            llenar_grilla()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvFacultad_SelectionChanged(sender As Object, e As EventArgs) Handles dgvFacultad.SelectionChanged
        Try
            lblCodigo.Text = dgvFacultad.CurrentRow.Cells(0).Value
            txtFacultad.Text = dgvFacultad.CurrentRow.Cells(1).Value
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dgvFacultad_Click(sender As Object, e As EventArgs) Handles dgvFacultad.Click
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = True
        btnModificar.Enabled = True
        btnSalir.Enabled = True
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        confInicio()
    End Sub
    Sub confInicio()
        txtFacultad.Enabled = False
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
        llenar_grilla()
    End Sub
    Sub llenar_grilla()
        With Me.dgvFacultad
            .DataSource = objFacultad.listar_facultades()
            .Columns(0).Width = 70
            .Columns(0).HeaderText = "Codigo"
            .Columns(1).Width = 370
            .Columns(1).HeaderText = "Nombre de Facultad"
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub
    Sub limpiar()
        lblCodigo.Text = ""
        txtFacultad.Clear()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub
End Class
