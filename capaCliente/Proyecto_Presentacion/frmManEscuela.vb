Imports System.Reflection
Imports System.Windows.Forms
Imports Proyecto_LogicaNegocio

Public Class frmManEscuela
    Dim objEscuela As New Escuela
    Dim objFacultad As New Facultad
    Private bandera As Boolean
    Private Sub frmManEscuela_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grilla()
        llenarCbxFacultades()
        confInicio()
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        bandera = True
        cbxFacultad.Enabled = True
        txtEscuela.Enabled = True
        txtEscuela.Text = ""
        txtEscuela.Focus()
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        lblCodigo.Text = CStr(objEscuela.obtenerIdEsc)
    End Sub
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            Dim retorno As Integer
            Dim mensaje As String = String.Empty
            If bandera Then
                '#Insertar'
                If (txtEscuela.Text <> String.Empty) AndAlso (cbxFacultad.SelectedValue <> String.Empty) Then
                    retorno = objEscuela.agregar_escuela(lblCodigo.Text, txtEscuela.Text, cbxFacultad.SelectedValue)
                Else
                    retorno = -1
                End If
            Else
                '#Modificar'
                retorno = objEscuela.modificar_escuela(lblCodigo.Text, txtEscuela.Text, cbxFacultad.SelectedValue)
            End If
            Select Case retorno
                Case 0
                    mensaje = If(bandera, "Registro completo", "Actualización completa")
                Case 1
                    mensaje = "Duplicado"
                Case -1
                    mensaje = "Error al realizar la operación"
            End Select
            MessageBox.Show(mensaje)
            llenar_grilla()
            cbxFacultad.Enabled = False
            txtEscuela.Enabled = False
            btnNuevo.Enabled = True
            btnGrabar.Enabled = False
            btnCancelar.Enabled = False
            btnEliminar.Enabled = False
            btnModificar.Enabled = False
            btnSalir.Enabled = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        bandera = False
        cbxFacultad.Enabled = True
        txtEscuela.Enabled = True
        txtEscuela.Focus()
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
            retorno = objEscuela.eliminar_escuela(lblCodigo.Text)
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

    Private Sub dgvEscuela_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEscuela.SelectionChanged
        Try
            lblCodigo.Text = dgvEscuela.CurrentRow.Cells(0).Value
            txtEscuela.Text = dgvEscuela.CurrentRow.Cells(1).Value
            cbxFacultad.SelectedValue = objFacultad.buscarIdFacultad(dgvEscuela.CurrentRow.Cells(2).Value.ToString)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dgvEscuela_Click(sender As Object, e As EventArgs) Handles dgvEscuela.Click
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = True
        btnModificar.Enabled = True
        btnSalir.Enabled = True
    End Sub

    Public Sub llenarCbxFacultades()
        Try
            cbxFacultad.DataSource = objFacultad.listar_facultades()
            cbxFacultad.DisplayMember = "nombre_facultad"
            cbxFacultad.ValueMember = "facultad_id"
        Catch ex As Exception

        End Try
    End Sub
    Sub llenar_grilla()
        With Me.dgvEscuela
            .DataSource = objEscuela.listar_escuelas()
            .Columns(0).Width = 70
            .Columns(0).HeaderText = "Codigo"
            .Columns(1).Width = 200
            .Columns(1).HeaderText = "Nombre de escuela"
            .Columns(2).Width = 100
            .Columns(2).HeaderText = "Facultad"
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub

    Sub confInicio()
        cbxFacultad.Enabled = False
        txtEscuela.Enabled = False
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
        llenar_grilla()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        confInicio()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

End Class