Imports Proyecto_LogicaNegocio
Public Class frm_matricula1
    Inherits System.Web.UI.Page
    Private objSemestre As New Semestre
    Private objAlumno As New Alumno
    Private objMatricula As New Matricula
    Private objDetMatricula As New DetalleMatricula

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            iniciarControles()
            grillaCursosVacia()
            grillaMatriculaVacia()
            grillaDetalleMatriculaVacia()
        End If
    End Sub

    Public Sub grillaMatriculaUno()
        Dim estudiante As String = txtEstudiante.Text
        gvMatricula.DataSource = objMatricula.listar_matriculasEstudianteActiva(estudiante)
        gvMatricula.DataBind()
    End Sub

    Public Sub grillaMatricula()
        Dim estudiante As String = txtEstudiante.Text
        gvMatricula.DataSource = objMatricula.listar_matriculasEstudiante(estudiante)
        gvMatricula.DataBind()
    End Sub

    Public Sub grillaDetalleMatricula(idMatricula)
        Dim dtDetalleMatricula As DataTable = objDetMatricula.obtenerDetalleMatricula(idMatricula)

        If dtDetalleMatricula IsNot Nothing AndAlso dtDetalleMatricula.Rows.Count > 0 Then
            gvDetalleMatricula.DataSource = dtDetalleMatricula
            gvDetalleMatricula.DataBind()
        Else
            gvDetalleMatricula.DataSource = Nothing
            gvDetalleMatricula.DataBind()
        End If
    End Sub

    Private Sub gvMatricula_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvMatricula.SelectedIndexChanged
        txtNomEstudiante.Text = objAlumno.buscarNomAlumno(txtEstudiante.Text)
        btnGrabarMat.Enabled = False
        btnModificarMat.Enabled = True
        btnEliminarMat.Enabled = True
        txtCreditosMat.Enabled = True
        txtFechaBaja.Enabled = True
        Try
            Session("matriculaSeleccionada") = Convert.ToInt32(gvMatricula.SelectedRow.Cells(0).Text)
            txtSemestre.Text = gvMatricula.SelectedRow.Cells(1).Text.ToString
            txtFechaMatricula.Text = formatearFecha(gvMatricula.SelectedRow.Cells(2).Text)
            txtCreditosMat.Text = gvMatricula.SelectedRow.Cells(3).Text.ToString
            If gvMatricula.SelectedRow.Cells(4).Text.ToString = "True" Then
                chkEstado.Checked = True
            Else
                chkEstado.Checked = False
            End If
            txtFechaBaja.Text = formatearFecha(gvMatricula.SelectedRow.Cells(5).Text.ToString)

            'Lógica para iniciar el Detalle de Matrícula'
            grillaDetalleMatricula(Session("matriculaSeleccionada"))
            cboCurso.Enabled = True
            txtNota.Enabled = False
            btnCancelarDetalle.Enabled = True

            'Lógica para obtener los cursos a llevar por el estudiante'
            cboCurso.DataSource = objDetMatricula.obtenerAsignaturasPorCursar(txtEstudiante.Text)
            cboCurso.DataTextField = "nombre_curso"
            cboCurso.DataValueField = "curso_id"
            cboCurso.DataBind()
            cboCurso.Items.Insert(0, New ListItem("Seleccione una opción", "0"))

            If Session("bandera") = 0 Then
                btnModificarMat.Enabled = False
                btnEliminarMat.Enabled = False
                txtFechaBaja.Enabled = False
                txtFechaMatricula.Enabled = False
                txtCreditosMat.Enabled = False
                txtSemestre.Enabled = False
                cboCurso.Enabled = False
            End If

        Catch ex As Exception
            MsgBox("Ocurrio un Error al procesar la solicitud")
        End Try
    End Sub

    Private Sub gvGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvGrupo.SelectedIndexChanged
        Try
            Dim idMatricula As Integer = Session("matriculaSeleccionada")
            Dim idGrupo As Integer = Convert.ToInt32(gvGrupo.SelectedRow.Cells(0).Text.ToString)
            Dim creditos As Integer = Convert.ToInt32(txtCreditosMat.Text)
            creditos += objDetMatricula.obtenerCreditosCurso(idGrupo)
            txtCreditosMat.Text = creditos.ToString()
            objMatricula.modificar_matricula(Session("matriculaSeleccionada"), 1, txtFechaBaja.Text, creditos)
            grillaMatriculaUno()

            Dim retorno As Integer = objDetMatricula.agregar_detalle_matricula(idMatricula, idGrupo)

            If retorno = 0 Then
                MsgBox("Detalle de Matrícula registrado")
                grillaDetalleMatricula(idMatricula)
            Else
                MsgBox("Detalle de Matrícula no registrado")
            End If

        Catch ex As Exception
            MsgBox("Ocurrio un Error al procesar la solicitud")
        End Try
    End Sub

    Private Sub gvDetalleMatricula_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvDetalleMatricula.SelectedIndexChanged
        Try
            txtNota.Enabled = True
            Session("matriculaSeleccionada") = Convert.ToInt32(gvDetalleMatricula.SelectedRow.Cells(0).Text)
            Session("grupoSeleccionado") = Convert.ToInt32(gvDetalleMatricula.SelectedRow.Cells(1).Text)
            btnModificarDetalle.Enabled = True
            btnEliminarDetalle.Enabled = True
            txtNota.Text = gvDetalleMatricula.SelectedRow.Cells(3).Text
            gvGrupo.DataSource = objDetMatricula.obtenerHorarioGrupo(Session("grupoSeleccionado"))
            gvGrupo.DataBind()

            If Session("bandera") = 0 Then
                btnModificarDetalle.Enabled = False
                btnEliminarDetalle.Enabled = False
                txtNota.Enabled = False
            End If

        Catch ex As Exception
            MsgBox("Ocurrio un Error al procesar la solicitud")
        End Try
    End Sub

    Private Sub cboCurso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCurso.SelectedIndexChanged
        Dim cursoId As Integer = cboCurso.SelectedValue
        Dim semestre As String = txtSemestre.Text
        gvGrupo.DataSource = objDetMatricula.obtenerGruposCurso(semestre, cursoId)
        gvGrupo.DataBind()
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Session("bandera") = 0
        grillaMatricula()
        iniciarControles()
        txtNomEstudiante.Text = objAlumno.buscarNomAlumno(txtEstudiante.Text)
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Session("bandera") = 1
        obtenerFechaActual()
        llenarTxtSemestre()
        chkEstado.Enabled = True
        chkEstado.Checked = True
        btnGrabarMat.Enabled = True
        btnCancelarMat.Enabled = True
        txtNomEstudiante.Text = objAlumno.buscarNomAlumno(txtEstudiante.Text)
        grillaMatriculaUno()
        gvDetalleMatricula.DataSource = Nothing
        grillaDetalleMatriculaVacia()
    End Sub

    Protected Sub btnCancelarMat_Click(sender As Object, e As EventArgs) Handles btnCancelarMat.Click
        iniciarControles()
        txtFechaBaja.Text = ""
        txtFechaMatricula.Text = ""
        txtSemestre.Text = ""
        txtCreditosMat.Text = ""
        chkEstado.Checked = False
        txtEstudiante.Text = ""
        txtNomEstudiante.Text = ""
        gvMatricula.DataSource = Nothing
        gvDetalleMatricula.DataSource = Nothing
        gvMatricula.DataBind()
        gvDetalleMatricula.DataBind()
        grillaDetalleMatriculaVacia()
        grillaMatriculaVacia()
    End Sub

    Protected Sub btnGrabarMat_Click(sender As Object, e As EventArgs) Handles btnGrabarMat.Click
        Dim fechaMat As String = txtFechaMatricula.Text
        Dim codSemestre As String = txtSemestre.Text
        Dim estadoMat As Integer
        If chkEstado.Checked Then
            estadoMat = 1
        Else
            estadoMat = 0
        End If
        Dim codEstudiante As Integer = objAlumno.buscarIdAlumno(txtEstudiante.Text)

        Dim retorno As Integer = objMatricula.agregar_matricula(fechaMat, codSemestre, estadoMat, codEstudiante)
        If retorno = 0 Then
            MsgBox("Matrícula registrada")
        Else
            MsgBox("Matrícula no registrada")
        End If
        grillaMatriculaUno()
    End Sub

    Protected Sub btnModificarMat_Click(sender As Object, e As EventArgs) Handles btnModificarMat.Click
        Dim idMatricula As Integer = Convert.ToInt32(Session("matriculaSeleccionada"))
        Dim estado As Integer = IIf(chkEstado.Checked, 1, 0)
        Dim fechaBaja As String = txtFechaBaja.Text
        Dim nroCreditos As Integer = Convert.ToInt32(txtCreditosMat.Text)

        Dim retorno As Integer = objMatricula.modificar_matricula(idMatricula, estado, fechaBaja, nroCreditos)
        If retorno = 0 Then
            MsgBox("Matrícula modificada")
        Else
            MsgBox("Matrícula no modificada")
        End If

        grillaMatriculaUno()
    End Sub

    Protected Sub btnEliminarMat_Click(sender As Object, e As EventArgs) Handles btnEliminarMat.Click
        Dim idMatricula As Integer = Convert.ToInt32(Session("matriculaSeleccionada"))
        Dim retorno As Integer = objMatricula.eliminar_matricula(idMatricula)
        If retorno = 0 Then
            MsgBox("Matrícula actualizada")
        ElseIf retorno = 1 Then
            MsgBox("Matrícula eliminada")
        Else
            MsgBox("Matrícula no modificada")
        End If

        grillaMatriculaUno()
    End Sub

    Protected Sub btnModificarDetalle_Click(sender As Object, e As EventArgs) Handles btnModificarDetalle.Click
        Dim idMatricula As Integer = Convert.ToInt32(Session("matriculaSeleccionada"))
        Dim idGrupo As Integer = Convert.ToInt32(Session("grupoSeleccionado"))
        Dim nota As Double = Convert.ToDouble(txtNota.Text)

        Dim retorno As Integer = objDetMatricula.modificar_detalle_matricula(idMatricula, idGrupo, nota)
        If retorno = 0 Then
            MsgBox("Detalle Matrícula actualizada")
            grillaDetalleMatricula(idMatricula)
        Else
            MsgBox("Detalle Matrícula no actualizada")
        End If

        btnModificarDetalle.Enabled = False
        btnEliminarDetalle.Enabled = False
        txtNota.Text = ""
        txtNota.Enabled = False
        cboCurso.SelectedIndex() = 0
        gvGrupo.DataSource = Nothing
        gvGrupo.DataBind()
    End Sub

    Protected Sub btnEliminarDetalle_Click(sender As Object, e As EventArgs) Handles btnEliminarDetalle.Click
        Dim idMatricula As Integer = Convert.ToInt32(Session("matriculaSeleccionada"))
        Dim idGrupo As Integer = Convert.ToInt32(Session("grupoSeleccionado"))

        Dim creditos As Integer = Convert.ToInt32(txtCreditosMat.Text)
        creditos -= objDetMatricula.obtenerCreditosCurso(idGrupo)
        txtCreditosMat.Text = creditos.ToString()
        objMatricula.modificar_matricula(Session("matriculaSeleccionada"), 1, txtFechaBaja.Text, creditos)
        grillaMatriculaUno()

        Dim retorno As Integer = objDetMatricula.eliminar_detalle_matricula(idMatricula, idGrupo)
        If retorno = 0 Then
            MsgBox("Detalle Matrícula eliminada")
            grillaDetalleMatricula(idMatricula)
        Else
            MsgBox("Detalle Matrícula no eliminada")
        End If

        btnModificarDetalle.Enabled = False
        btnEliminarDetalle.Enabled = False
        txtNota.Enabled = False
        txtNota.Text = ""
        cboCurso.SelectedIndex() = 0
        gvGrupo.DataSource = Nothing
        gvGrupo.DataBind()

    End Sub

    Protected Sub btnCancelarDetalle_Click(sender As Object, e As EventArgs) Handles btnCancelarDetalle.Click
        btnEliminarDetalle.Enabled = False
        btnModificarDetalle.Enabled = False
        txtNota.Text = ""
        cboCurso.SelectedIndex() = 0
        txtNota.Enabled = False
        gvGrupo.DataSource = Nothing
        gvGrupo.DataBind()
    End Sub

    Public Sub iniciarControles()
        'Datos de Matricula'
        txtCreditosMat.Enabled = False
        txtFechaBaja.Enabled = False
        chkEstado.Enabled = False
        btnGrabarMat.Enabled = False
        btnModificarMat.Enabled = False
        btnEliminarMat.Enabled = False
        btnCancelarMat.Enabled = False
        'Datos de Detalle'
        cboCurso.Enabled = False
        btnModificarDetalle.Enabled = False
        btnEliminarDetalle.Enabled = False
        btnCancelarDetalle.Enabled = False
    End Sub

    Public Sub grillaCursosVacia()
        Dim dt As New DataTable()
        dt.Columns.Add("grupo_id")
        dt.Columns.Add("denominacion")
        dt.Columns.Add("horario_formato")
        dt.Columns.Add("docente")

        If gvGrupo.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If

        gvGrupo.DataSource = dt
        gvGrupo.DataBind()
    End Sub

    Public Sub grillaMatriculaVacia()
        Dim d As New DataTable()
        d.Columns.Add("matricula_id")
        d.Columns.Add("codigo_semestre")
        d.Columns.Add("fecha_matricula")
        d.Columns.Add("nro_creditos_matriculados")
        d.Columns.Add("estado_matricula")
        d.Columns.Add("fecha_baja")

        If gvMatricula.Rows.Count = 0 Then
            d.Rows.Add(d.NewRow())
        End If

        gvMatricula.DataSource = d
        gvMatricula.DataBind()
    End Sub

    Public Sub grillaDetalleMatriculaVacia()
        Dim dat As New DataTable()
        dat.Columns.Add("matricula_id")
        dat.Columns.Add("grupo_id")
        dat.Columns.Add("curso")
        dat.Columns.Add("nota_promedio")

        If gvDetalleMatricula.Rows.Count = 0 Then
            dat.Rows.Add(dat.NewRow())
        End If

        gvDetalleMatricula.DataSource = dat
        gvDetalleMatricula.DataBind()
    End Sub

    Public Sub obtenerFechaActual()
        Dim fechaActual = DateTime.Now.ToString("yyyy-MM-dd")
        txtFechaMatricula.Text = fechaActual
        txtFechaMatricula.Enabled = False
    End Sub

    Public Sub llenarTxtSemestre()
        Try
            txtSemestre.Text = objSemestre.mostrar_semestre_actual()
            txtSemestre.Enabled = False
        Catch ex As Exception
            MsgBox("Error al listar el semestre")
        End Try
    End Sub

    Public Function formatearFecha(fecha As String) As String
        If String.IsNullOrEmpty(fecha) Then
            Return ""
        End If

        Try
            Dim fechaMatricula As DateTime = DateTime.ParseExact(fecha, "yyyy-MM-dd", Nothing)
            Return fechaMatricula.ToString("yyyy-MM-dd")
        Catch ex As FormatException
            ' Manejar la excepción si el formato es incorrecto
            Return ""
        End Try
    End Function

End Class