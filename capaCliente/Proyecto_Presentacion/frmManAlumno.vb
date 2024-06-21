Imports System.Reflection
Imports System.Windows.Forms
Imports Proyecto_LogicaNegocio

Public Class frmManAlumno
    Dim objAlumno As New Alumno
    Dim objAgregado As New Agregados
    Dim objSemestre As New Semestre
    Dim objUbigeo As New Ubigeo
    Dim objEscuela As New Escuela
    Dim bandera As Boolean
    Private Sub frmManAlumno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        confInicio()
        llenarCbxEstadoAlumno()
        llenarCbxTipoDocumento()
        llenarCbxUbigeo()
        llenarCbxSemestre()
        llenarCbxEscuela()
        txtNacimiento.Enabled() = False
        AddHandler txtDocumento.KeyPress, AddressOf txtDocumento_KeyPress
        AddHandler txtApellidoPaterno.KeyPress, AddressOf txtApellidoPaterno_KeyPress
        AddHandler txtApellidoMaterno.KeyPress, AddressOf txtApellidoMaterno_KeyPress
        AddHandler txtNombres.KeyPress, AddressOf txtNombres_KeyPress

    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        bandera = True
        cbxTipoDocumento.Enabled = True
        txtDocumento.Enabled = True
        txtDocumento.Text = ""
        txtApellidoPaterno.Enabled = True
        txtApellidoPaterno.Text = ""
        txtApellidoMaterno.Enabled = True
        txtApellidoMaterno.Text = ""
        txtNombres.Enabled = True
        txtNombres.Text = ""
        txtDocumento.Focus()
        cbxSexo.Enabled = True
        dtNacimiento.Visible = True
        dtNacimiento.Enabled = True
        txtNacimiento.Visible = False
        txtDireccion.Enabled = True
        cbxSemestre.Enabled = True
        cbxSemEgreso.Enabled = False
        cbxEscuelaProfesiona.Enabled = True
        cbxEstado.Enabled = True
        cbxUbigeo.Enabled = True
        cbxSemEgreso.Enabled = True
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
            Dim sexo As Boolean
            If cbxSexo.SelectedItem.ToString.Equals("MASCULINO") Then
                sexo = True
            Else
                sexo = False
            End If
            If bandera Then
                '#Insertar'
                retorno = objAlumno.agregar_alumno(cbxTipoDocumento.SelectedValue, txtDocumento.Text,
                                                    txtApellidoPaterno.Text, txtApellidoMaterno.Text, txtNombres.Text,
                                                    sexo, dtNacimiento.Value.Date, txtDireccion.Text, cbxEstado.SelectedValue,
                                                    cbxEscuelaProfesiona.SelectedValue, cbxUbigeo.SelectedValue,
                                                    cbxSemestre.SelectedValue)
            Else
                'Modificar'
                Dim idAlu As Integer = objAlumno.buscarIdAlumno(txtDocumento.Text)
                retorno = objAlumno.modificar_alumno(idAlu, cbxTipoDocumento.SelectedValue, txtDocumento.Text,
                                                    txtApellidoPaterno.Text, txtApellidoMaterno.Text, txtNombres.Text,
                                                    sexo, dtNacimiento.Value.Date, txtDireccion.Text, cbxEstado.SelectedValue,
                                                    cbxEscuelaProfesiona.SelectedValue, cbxUbigeo.SelectedValue,
                                                    cbxSemestre.SelectedValue, cbxSemEgreso.SelectedValue)

            End If
            Select Case retorno
                Case 0
                    mensaje = If(bandera, "Registro completo", "Actualización completa")
                Case 1
                    mensaje = "Error al realizar la operación"
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
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        bandera = False
        cbxTipoDocumento.Enabled = True
        txtDocumento.Enabled = True
        txtApellidoPaterno.Enabled = True
        txtApellidoMaterno.Enabled = True
        txtNombres.Enabled = True
        txtDocumento.Focus()
        cbxSexo.Enabled = True
        dtNacimiento.Visible = True
        dtNacimiento.Enabled = True
        txtNacimiento.Visible = False
        txtDireccion.Enabled = True
        cbxSemestre.Enabled = True
        cbxSemEgreso.Enabled = False
        cbxEscuelaProfesiona.Enabled = True
        cbxEstado.Enabled = True
        cbxUbigeo.Enabled = True
        cbxSemEgreso.Enabled = True
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
        dtNacimiento.Visible = True
        txtNacimiento.Visible = False
        ' Si dtNacimiento no tiene una fecha válida, configúralo a la fecha actual o déjalo en blanco
        If dtNacimiento.Value = DateTime.MinValue Then
            dtNacimiento.Value = DateTime.Now
        End If
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            Dim retorno As Integer
            Dim mensaje As String = String.Empty
            Dim alumnoId As String = objAlumno.buscarIdAlumno(txtDocumento.Text)

            retorno = objAlumno.eliminar_alumno(alumnoId)
            Select Case retorno
                Case 0
                    mensaje = "Alumno eliminado correctamente"
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
    Private Sub dgvAlumno_SelectionChanged(sender As Object, e As EventArgs) Handles dgvAlumno.SelectionChanged
        Try
            cbxTipoDocumento.SelectedValue = objAgregado.buscarIdTipoDocumento(dgvAlumno.CurrentRow.Cells(0).Value)
            txtDocumento.Text = dgvAlumno.CurrentRow.Cells(1).Value
            txtApellidoPaterno.Text = dgvAlumno.CurrentRow.Cells(2).Value
            txtApellidoMaterno.Text = dgvAlumno.CurrentRow.Cells(3).Value
            txtNombres.Text = dgvAlumno.CurrentRow.Cells(4).Value
            Dim sexoActual As String = dgvAlumno.CurrentRow.Cells(5).Value.ToString()
            cbxSexo.SelectedItem = sexoActual
            Dim vFechaNac As Object = dgvAlumno.CurrentRow.Cells(6).Value
            If Not IsDBNull(vFechaNac) Then
                dtNacimiento.Visible = True
                txtNacimiento.Visible = False
                dtNacimiento.Value = Convert.ToDateTime(vFechaNac)
            Else
                dtNacimiento.Visible = False
                txtNacimiento.Visible = True
                txtNacimiento.Text = ""
            End If

            Dim vDireccion As Object = dgvAlumno.CurrentRow.Cells(8).Value
            If IsDBNull(vFechaNac) Then
                txtDireccion.Text = ""
            End If
            cbxUbigeo.SelectedValue = dgvAlumno.CurrentRow.Cells(9).Value
            cbxEstado.SelectedValue = objAgregado.buscarIdEstado(dgvAlumno.CurrentRow.Cells(10).Value)
            cbxEscuelaProfesiona.SelectedValue = objEscuela.buscarIdEscuela(dgvAlumno.CurrentRow.Cells(11).Value)
            cbxSemestre.SelectedValue = dgvAlumno.CurrentRow.Cells(12).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub dgvAlumno_Click(sender As Object, e As EventArgs) Handles dgvAlumno.Click
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = True
        btnModificar.Enabled = True
        btnSalir.Enabled = True
    End Sub
    Sub llenar_grilla()
        With Me.dgvAlumno
            .DataSource = objAlumno.listar_alumnos()
            .Columns(0).Width = 50
            .Columns(0).HeaderText = "Tipo documento"
            .Columns(1).Width = 70
            .Columns(1).HeaderText = "N° documento"
            .Columns(2).Width = 70
            .Columns(2).HeaderText = "Apellido Paterno"
            .Columns(3).Width = 70
            .Columns(3).HeaderText = "Apellido Materno"
            .Columns(4).Width = 70
            .Columns(4).HeaderText = "Nombre "
            .Columns(5).Width = 50
            .Columns(5).HeaderText = "Sexo"
            .Columns(6).Width = 70
            .Columns(6).HeaderText = "Fecha Nacimiento"
            .Columns(7).Width = 80
            .Columns(7).HeaderText = "Fecha Registro"
            .Columns(8).Width = 70
            .Columns(8).HeaderText = "Direccion"
            .Columns(9).Width = 50
            .Columns(9).HeaderText = "Ubigeo"
            .Columns(10).Width = 50
            .Columns(10).HeaderText = "Estado"
            .Columns(11).Width = 50
            .Columns(11).HeaderText = "Nombre Escuela"
            .Columns(12).Width = 70
            .Columns(12).HeaderText = "Semestre ingreso"
            .Columns(13).Width = 70
            .Columns(13).HeaderText = "Semestre egreso"
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
    Public Sub llenarCbxUbigeo()
        Try
            cbxUbigeo.DataSource = objUbigeo.listar_ubigeo()
            cbxUbigeo.DisplayMember = "ubigeo_id"
            cbxUbigeo.ValueMember = "ubigeo_id"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub llenarCbxSemestre()
        Try
            cbxSemestre.DataSource = objSemestre.listar_semestres()
            cbxSemestre.DisplayMember = "codigo_semestre"
            cbxSemestre.ValueMember = "codigo_semestre"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub llenarCbxEscuela()
        Try
            cbxEscuelaProfesiona.DataSource = objEscuela.listar_escuelas()
            cbxEscuelaProfesiona.DisplayMember = "nombre_escuela"
            cbxEscuelaProfesiona.ValueMember = "escuela_id"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub llenarCbxEstadoAlumno()
        Try
            cbxEstado.DataSource = objAgregado.listar_estado_alumno()
            cbxEstado.DisplayMember = "descripcion"
            cbxEstado.ValueMember = "estado_alumno_id"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub confInicio()
        cbxTipoDocumento.Enabled = False
        txtDocumento.Enabled = False
        txtApellidoPaterno.Enabled = False
        txtApellidoMaterno.Enabled = False
        txtNombres.Enabled = False
        txtDireccion.Enabled = False
        cbxSemestre.Enabled = False
        cbxEscuelaProfesiona.Enabled = False
        cbxEstado.Enabled = False
        cbxSexo.Enabled = False
        dtNacimiento.Enabled = False
        cbxUbigeo.Enabled = False
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
        'dtime
        dtNacimiento.Format = DateTimePickerFormat.Custom
        dtNacimiento.CustomFormat = "dd/MM/yyyy"
        'cbx sexo
        cbxSexo.Items.Clear()
        cbxSexo.Items.Add("FEMENINO")
        cbxSexo.Items.Add("MASCULINO")
        cbxSexo.SelectedIndex = 0
        llenar_grilla()
    End Sub
    Sub limpiar()
        txtDocumento.Text = ""
        txtApellidoMaterno.Text = ""
        txtNombres.Text = ""
        txtApellidoPaterno.Text = ""
        cbxEstado.Enabled = False
    End Sub

    Private Sub txtApellidoPaterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellidoPaterno.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtApellidoMaterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellidoMaterno.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNombres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombres.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDocumento.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        Dim tipoDocumento As String = cbxTipoDocumento.SelectedItem?.ToString()


        If tipoDocumento.Equals("Pasaporte", StringComparison.OrdinalIgnoreCase) Then
            If txtDocumento.Text.Length >= 12 AndAlso Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        End If

        If tipoDocumento.Equals("DNI", StringComparison.OrdinalIgnoreCase) Then
            If txtDocumento.Text.Length >= 8 AndAlso Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class