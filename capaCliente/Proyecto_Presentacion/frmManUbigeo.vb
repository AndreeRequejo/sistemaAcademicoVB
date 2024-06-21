Imports System.Reflection
Imports System.Windows.Forms
Imports Proyecto_LogicaNegocio

Public Class frmManUbigeo
    Private obj_ubigeo As New Ubigeo
    Dim bandera As Boolean
    Private Sub frmManUbigeo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
        AddHandler txt_ubigeo_id.KeyPress, AddressOf txt_ubigeo_id_KeyPress
        AddHandler txt_distrito.KeyPress, AddressOf txt_distrito_KeyPress
        AddHandler txt_provincia.KeyPress, AddressOf txt_provincia_KeyPress
        AddHandler txt_departamento.KeyPress, AddressOf txt_departamento_KeyPress

        llenar_grilla()
    End Sub
    Sub llenar_grilla()
        With Me.dgv_ubigeo
            .DataSource = obj_ubigeo.listar_ubigeos()
            .Columns(0).Width = 70
            .Columns(0).HeaderText = "Código"
            .Columns(1).Width = 130
            .Columns(1).HeaderText = "Distrito"
            .Columns(2).Width = 130
            .Columns(2).HeaderText = "Provincia"
            .Columns(3).Width = 130
            .Columns(3).HeaderText = "Departamento"
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub
    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        bandera = True
        txt_ubigeo_id.Enabled = True
        txt_ubigeo_id.Focus()
        limpiar()
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
    End Sub
    Sub limpiar()
        txt_ubigeo_id.Clear()
        txt_distrito.Clear()
        txt_provincia.Clear()
        txt_departamento.Clear()
    End Sub
    Private Sub btn_grabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            If bandera Then
                obj_ubigeo.agregar_ubigeo(txt_ubigeo_id.Text, txt_distrito.Text, txt_provincia.Text, txt_departamento.Text)
            Else
                obj_ubigeo.modificar_ubigeo(txt_ubigeo_id.Text, txt_distrito.Text, txt_provincia.Text, txt_departamento.Text)
            End If
            llenar_grilla()
            btnNuevo.Enabled = True
            btnGrabar.Enabled = False
            btnCancelar.Enabled = False
            btnEliminar.Enabled = False
            btnModificar.Enabled = False
            btnSalir.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgv_ubigeo_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_ubigeo.SelectionChanged
        Try
            limpiar()
            txt_ubigeo_id.Text = dgv_ubigeo.CurrentRow.Cells(0).Value
            txt_distrito.Text = dgv_ubigeo.CurrentRow.Cells(1).Value
            txt_provincia.Text = dgv_ubigeo.CurrentRow.Cells(2).Value
            txt_departamento.Text = dgv_ubigeo.CurrentRow.Cells(3).Value
        Catch ex As Exception

        End Try
    End Sub

    'VALIDACION QUE SOLO TE PERMITA INGRESAR TEXTO'

    Private Sub txt_ubigeo_id_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_ubigeo_id.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txt_distrito_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_distrito.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_provincia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_provincia.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_departamento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_departamento.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgv_ubigeo_Click(sender As Object, e As EventArgs) Handles dgv_ubigeo.Click
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = True
        btnModificar.Enabled = True
        btnSalir.Enabled = True
    End Sub
    Private Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        bandera = False
        txt_ubigeo_id.Enabled = True
        txt_ubigeo_id.Focus()
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
    End Sub
    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If MessageBox.Show("Desea Eliminar el ubigeo?", "Mantenimiento de Ubigeos", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                obj_ubigeo.eliminar_ubigeo(txt_ubigeo_id.Text)
                btnNuevo.Enabled = True
                btnGrabar.Enabled = False
                btnCancelar.Enabled = False
                btnEliminar.Enabled = False
                btnModificar.Enabled = False
                btnSalir.Enabled = True
                limpiar()
                llenar_grilla()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub
    Sub confInicio()
        txt_ubigeo_id.Enabled = False
        txt_departamento.Enabled = False
        txt_provincia.Enabled = False
        txt_distrito.Enabled = False
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
        llenar_grilla()
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        confInicio()
    End Sub
End Class