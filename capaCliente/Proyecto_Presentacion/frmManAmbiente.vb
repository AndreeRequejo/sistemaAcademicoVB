Imports System.Windows.Forms
Imports Proyecto_LogicaNegocio
Public Class frmManAmbiente
    Dim objAmbiente As New Ambiente
    Private bandera As Boolean
    Private Sub frmManAmbiente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxEstado.Items.Add("Habilitado")
        cbxEstado.Items.Add("Deshabilitado")
        cbxEstado.Items.Add("Mantenimiento")
        llenar_grilla()
        llenarCbxTipo()
        confInicio()
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtDesc.Enabled = True
        txtDesc.Focus()
        bandera = True
        cbxAmbiente.Enabled = True
        cbxEstado.Enabled = True
        txtCapacidad.Enabled = True
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
    End Sub
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            Dim retorno As Integer
            Dim idAm As Integer
            Dim mensaje As String = String.Empty

            If bandera Then
                '#Insertar'
                Dim capacidad As Integer = Convert.ToInt32(txtCapacidad.Text.ToString)
                retorno = objAmbiente.agregar_ambiente(cbxAmbiente.SelectedValue, txtDesc.Text.ToString, capacidad, cbxEstado.SelectedItem)
                limpiar()
            Else
                    '#Modificar'
                    idAm = objAmbiente.buscarIdAmbiente(dgvAmbiente.CurrentRow.Cells(2).Value)
                Dim capacidad As Integer = Convert.ToInt32(txtCapacidad.Text.ToString)
                retorno = objAmbiente.modificar_ambiente(idAm, cbxAmbiente.SelectedValue, txtDesc.Text.ToString, capacidad, cbxEstado.SelectedItem)
            End If

            Select Case retorno
                Case 0
                    mensaje = If(bandera, "Registro completo", "Actualización completa")
                Case 1
                    mensaje = "Duplicado"
            End Select
            MessageBox.Show(mensaje)
            llenar_grilla()
            cbxAmbiente.Enabled = False
            cbxEstado.Enabled = False
            txtCapacidad.Enabled = False
            txtDesc.Enabled = False
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
        cbxAmbiente.Enabled = True
        cbxEstado.Enabled = True
        txtCapacidad.Enabled = True
        txtDesc.Enabled = True
        txtDesc.Focus()
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
            Dim idAm As Integer
            Dim mensaje As String = String.Empty

            idAm = objAmbiente.buscarIdAmbiente(txtDesc.Text.ToString)
            retorno = objAmbiente.eliminar_ambiente(idAm)

            Select Case retorno
                Case 0
                    mensaje = "Ambiente eliminada correctamente"
                Case -1
                    mensaje = "Error al procesar eliminación."
            End Select
            MessageBox.Show(mensaje)
            llenar_grilla()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvAmbiente_SelectionChanged(sender As Object, e As EventArgs) Handles dgvAmbiente.SelectionChanged
        Try
            txtDesc.Text = dgvAmbiente.CurrentRow.Cells(2).Value
            txtCapacidad.Text = dgvAmbiente.CurrentRow.Cells(3).Value
            cbxAmbiente.SelectedValue = dgvAmbiente.CurrentRow.Cells(1).Value
            cbxEstado.SelectedItem = dgvAmbiente.CurrentRow.Cells(4).Value
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dgvAAmbiente_Click(sender As Object, e As EventArgs) Handles dgvAmbiente.Click
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = True
        btnModificar.Enabled = True
        btnSalir.Enabled = True
    End Sub

    Public Sub llenarCbxTipo()

        Try
            cbxAmbiente.DataSource = objAmbiente.listar_tipo_ambiente()
            cbxAmbiente.DisplayMember = "descripcion_tipoambiente"
            cbxAmbiente.ValueMember = "tipoambiente_id"
        Catch ex As Exception

        End Try
    End Sub
    Sub llenar_grilla()
        With Me.dgvAmbiente
            .DataSource = objAmbiente.listar_ambiente()
            .Columns(0).Width = 60
            .Columns(0).HeaderText = "Codigo"
            .Columns(1).Width = 60
            .Columns(1).HeaderText = "Tipo de ambiente"
            .Columns(2).Width = 110
            .Columns(2).HeaderText = "Descripción"
            .Columns(3).Width = 60
            .Columns(3).HeaderText = "Capacidad"
            .Columns(4).Width = 80
            .Columns(4).HeaderText = "Estado"
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub

    Sub confInicio()
        cbxAmbiente.Enabled = False
        cbxEstado.Enabled = False
        txtCapacidad.Enabled = False
        txtDesc.Enabled = False
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
        llenar_grilla()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub txtCapacidad_TextChanged(sender As Object, e As EventArgs) Handles txtCapacidad.TextChanged
        If txtCapacidad.Text = "" Then
            btnGrabar.Enabled = False
        End If
    End Sub

    Private Sub cbxAmbiente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAmbiente.SelectedIndexChanged

    End Sub
    Sub limpiar()
        cbxAmbiente.SelectedIndex = 0
        txtDesc.Text = " "
        txtCapacidad.Text = " "
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        limpiar()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub txtCapacidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCapacidad.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDesc.KeyPress
        If Not (e.KeyChar Like "[!@#$%^&*/=¿?;:_]") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDesc_TextChanged(sender As Object, e As EventArgs) Handles txtDesc.TextChanged
        If txtDesc.Text = "" Then
            btnGrabar.Enabled = False
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class