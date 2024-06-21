Imports System.Reflection
Imports System.Windows.Forms
Imports Proyecto_LogicaNegocio

Public Class frmManDocente
    Dim objDocente As New Docente
    Dim objAgregado As New Agregados
    Dim objUbigeo As New Ubigeo
    Dim bandera As Boolean

    Private Sub frmManDocente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grilla()
        llenarCbxGradoAcademico()
        llenarCbxTipoDocente()
        llenarCbxTipoDocumento()
        llenarCbxUbigeo()
        confInicio()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        bandera = True
        cbxTipoDocumento.Enabled = True
        txtDocumento.Enabled = True
        txtApellidoPaterno.Enabled = True
        txtDocumento.Focus()
        cbxTipoDocente.Enabled = True
        cbxUltimoGrado.Enabled = True
        chbxEstado.Enabled = True
        cbxUbigeo.Enabled = True
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        limpiar()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            Dim retorno As Integer
            Dim mensaje As String = String.Empty
            Dim gradoid As String = objAgregado.buscarIdGrado(cbxUltimoGrado.SelectedValue.ToString)

            Dim docenteid As String = objDocente.buscarIdDocente(txtDocumento.Text)
            If bandera Then
                '#Insertar'
                retorno = objDocente.agregar_docente(cbxTipoDocumento.SelectedValue, txtDocumento.Text, cbxTipoDocente.SelectedValue,
                                                     txtApellidoPaterno.Text, txtApellidoMaterno.Text, txtNombres.Text,
                                                     gradoid, chbxEstado.Checked, cbxUbigeo.SelectedValue)
            Else
                retorno = objDocente.modificar_docente(docenteid, cbxTipoDocumento.SelectedValue, txtDocumento.Text, cbxTipoDocente.SelectedValue,
                                                     txtApellidoPaterno.Text, txtApellidoMaterno.Text, txtNombres.Text,
                                                     gradoid, chbxEstado.Checked, cbxUbigeo.SelectedValue)
            End If
            Select Case retorno
                Case 0
                    mensaje = If(bandera, "Registro completo", "Actualización completa")
                Case 1
                    mensaje = "Duplicado"
            End Select
            MessageBox.Show(mensaje, "Formulario")
            llenar_grilla()
            btnNuevo.Enabled = True
            btnGrabar.Enabled = False
            btnCancelar.Enabled = False
            btnEliminar.Enabled = False
            btnModificar.Enabled = False
            btnSalir.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Catch form")
        End Try
    End Sub

    Private Sub dgvDocente_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDocente.SelectionChanged
        Try
            cbxTipoDocumento.SelectedValue = objAgregado.buscarIdTipoDocumento(dgvDocente.CurrentRow.Cells(1).Value)
            txtDocumento.Text = dgvDocente.CurrentRow.Cells(2).Value
            txtApellidoPaterno.Text = dgvDocente.CurrentRow.Cells(3).Value
            txtApellidoMaterno.Text = dgvDocente.CurrentRow.Cells(4).Value
            txtNombres.Text = dgvDocente.CurrentRow.Cells(5).Value
            cbxTipoDocente.SelectedValue = dgvDocente.CurrentRow.Cells(6).Value
            cbxUltimoGrado.SelectedValue = dgvDocente.CurrentRow.Cells(7).Value
            If dgvDocente.CurrentRow.Cells(9).Value.Equals("Vigente") Then
                chbxEstado.Checked = True
            Else
                chbxEstado.Checked = False
            End If
            cbxUbigeo.SelectedValue = dgvDocente.CurrentRow.Cells(10).Value

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub dgvDocente_Click(sender As Object, e As EventArgs) Handles dgvDocente.Click
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = True
        btnModificar.Enabled = True
        btnSalir.Enabled = True
    End Sub


    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        bandera = False
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
            Dim docenteid As String = objDocente.buscarIdDocente(txtDocumento.Text)

            retorno = objDocente.eliminar_docente(docenteid)
            Select Case retorno
                Case 0
                    mensaje = "Docente eliminado correctamente"
                Case 1
                    mensaje = "Docente eliminado fisicamente"
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Sub llenar_grilla()
        With Me.dgvDocente
            .DataSource = objDocente.listar_docentes()
            .Columns(1).Width = 50
            .Columns(1).HeaderText = "Tipo documento"
            .Columns(2).Width = 70
            .Columns(2).HeaderText = "N° documento"
            .Columns(3).Width = 70
            .Columns(3).HeaderText = "Apellido Paterno"
            .Columns(4).Width = 70
            .Columns(4).HeaderText = "Apellido Materno"
            .Columns(5).Width = 70
            .Columns(5).HeaderText = "Nombre "
            .Columns(6).Width = 50
            .Columns(6).HeaderText = "Tipo docente"
            .Columns(7).Width = 70
            .Columns(7).HeaderText = "Ultimo grado"
            .Columns(8).Width = 80
            .Columns(8).HeaderText = "Fecha de registro"
            .Columns(9).Width = 70
            .Columns(9).HeaderText = "Estado"
            .Columns(10).Width = 50
            .Columns(10).HeaderText = "Ubigeo"
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub
    Public Sub llenarCbxTipoDocumento()
        Try
            cbxTipoDocumento.DataSource = objAgregado.listar_tipo_documento()
            cbxTipoDocumento.DisplayMember = "descripcion"
            cbxTipoDocumento.ValueMember = "tipo_documento_id"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub llenarCbxTipoDocente()
        Try
            cbxTipoDocente.DataSource = objAgregado.listar_tipo_docente()
            cbxTipoDocente.DisplayMember = "descripcion"
            cbxTipoDocente.ValueMember = "tipo_docente_id"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub llenarCbxGradoAcademico()
        Try
            cbxUltimoGrado.DataSource = objAgregado.listar_grado_academico()
            cbxUltimoGrado.DisplayMember = "descripcion"
            cbxUltimoGrado.ValueMember = "grado_academico_id"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub llenarCbxUbigeo()
        Try
            cbxUbigeo.DataSource = objUbigeo.listar_ubigeo()
            cbxUbigeo.DisplayMember = "ubigeo_id"
            cbxUbigeo.ValueMember = "ubigeo_id"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub limpiar()
        txtDocumento.Text = ""
        txtApellidoPaterno.Text = ""
        txtApellidoMaterno.Text = ""
        txtNombres.Text = ""
        chbxEstado.Enabled = False
    End Sub
    Sub confInicio()
        cbxTipoDocumento.Enabled = False
        txtDocumento.Enabled = False
        txtApellidoPaterno.Enabled = False
        cbxTipoDocente.Enabled = False
        cbxUltimoGrado.Enabled = False
        chbxEstado.Enabled = False
        cbxUbigeo.Enabled = False
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
        llenar_grilla()
    End Sub

    Private Sub txtDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDocumento.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class