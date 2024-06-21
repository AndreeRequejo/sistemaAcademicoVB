Imports System.Windows.Forms
Imports Proyecto_LogicaNegocio

Public Class frmManTipoAmbiente
    Private objTipoAmbiente As New TipoAmbiente
    Private bandera As Boolean

    Private Sub frmManTipoAmbiente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        confInicio()
        AddHandler txtTipoAmb.KeyPress, AddressOf txtTipoAmb_KeyPress
        AddHandler txtAbrev.KeyPress, AddressOf txtAbrev_KeyPress

    End Sub

    Private Sub dgvTipoAmbiente_Click(sender As Object, e As EventArgs) Handles dgvTipoAmbiente.Click
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = True
        btnModificar.Enabled = True
        btnSalir.Enabled = True
    End Sub

    Private Sub dgvTipoAmbiente_SelectionChanged(sender As Object, e As EventArgs) Handles dgvTipoAmbiente.SelectionChanged
        Try
            txtTipoAmb.Text = dgvTipoAmbiente.CurrentRow.Cells(0).Value
            txtAbrev.Text = dgvTipoAmbiente.CurrentRow.Cells(1).Value
            chkVigencia.Checked = dgvTipoAmbiente.CurrentRow.Cells(2).Value

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        bandera = True
        txtTipoAmb.Enabled = True
        txtAbrev.Enabled = True
        chkVigencia.Enabled = False
        txtTipoAmb.Focus()
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
            Dim idTipoAmb As Integer
            Dim valorCheck As Boolean
            If bandera Then
                '#Insertar'
                If (txtTipoAmb.Text <> String.Empty) AndAlso (txtAbrev.Text <> String.Empty) Then
                    retorno = objTipoAmbiente.agregar_tipoAmbiente(txtTipoAmb.Text, txtTipoAmb.Text)
                Else
                    retorno = -1
                End If

            Else
                '#Modificar'
                idTipoAmb = objTipoAmbiente.buscarIdTipoAmb(txtTipoAmb.Text)
                If chkVigencia.Checked = True Then
                    valorCheck = 1
                Else
                    valorCheck = 0
                End If
                retorno = objTipoAmbiente.modificar_tipoAmbiente(idTipoAmb, txtTipoAmb.Text, txtAbrev.Text, valorCheck)
            End If
            Select Case retorno
                Case 0
                    mensaje = If(bandera, "Registro completo", "Actualización completa")
                Case -1
                    mensaje = "Error al procesar la solicitud"
            End Select
            MessageBox.Show(mensaje)
            llenar_grilla()
            txtTipoAmb.Enabled = False
            txtAbrev.Enabled = False
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
        txtTipoAmb.Enabled = True
        txtAbrev.Enabled = True
        txtTipoAmb.Focus()
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
            Dim idTipoAmb As Integer
            idTipoAmb = objTipoAmbiente.buscarIdTipoAmb(txtTipoAmb.Text)
            retorno = objTipoAmbiente.eliminar_tipoAmbiente(idTipoAmb)
            Select Case retorno
                Case 0
                    mensaje = "Tipo de Ambiente eliminado correctamente"
                Case -1
                    mensaje = "Error al procesar eliminación."
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

    Sub llenar_grilla()
        With Me.dgvTipoAmbiente
            .DataSource = objTipoAmbiente.listar_tipoAmbientes()
            .Columns(0).Width = 190
            .Columns(0).HeaderText = "Tipo de Ambiente"
            .Columns(1).Width = 100
            .Columns(1).HeaderText = "Abreviatura"
            .Columns(2).Width = 70
            .Columns(2).HeaderText = "Vigencia"
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub

    Sub confInicio()
        txtAbrev.Enabled = False
        txtTipoAmb.Enabled = False
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
        llenar_grilla()
    End Sub

    'VALIDACION QUE SOLO TE PERMITA INGRESAR TEXTO'

    Private Sub txtTipoAmb_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTipoAmb.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtAbrev_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAbrev.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Sub limpiar()
        txtTipoAmb.Text = ""
        txtAbrev.Text = ""
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub


End Class