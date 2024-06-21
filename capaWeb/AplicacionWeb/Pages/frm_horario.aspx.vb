Imports Proyecto_LogicaNegocio

Public Class frm_horario
    Inherits System.Web.UI.Page
    Private objFacultad As New Facultad
    Private objEscuela As New Escuela
    Private objAmbiente As New Ambiente
    Private objCurso As New Curso
    Private objHorario As New Horario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            llenarCboSemestre()
            llenarCboFacultad()
            llenarCboAmbiente()
            llenarCboDias()
            btnNuevo.Enabled = True
            btnGrabar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            btnCancelar.Enabled = False
        End If
        refrescar_grilla()
    End Sub

    Private Sub gvHorarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvHorarios.SelectedIndexChanged
        Try
            btnNuevo.Enabled = False
            btnGrabar.Enabled = False
            btnModificar.Enabled = True
            btnEliminar.Enabled = True
            btnCancelar.Enabled = True
            lblCodigo.Text = gvHorarios.SelectedRow.Cells(0).Text.ToString
            Dim ambiente As String = gvHorarios.SelectedRow.Cells(7).Text.ToString
            Dim amb As Integer = objAmbiente.buscarIdAmbiente(ambiente)
            cboAmbiente.SelectedValue = amb
            lblDoc.Text = gvHorarios.SelectedRow.Cells(6).Text.ToString
            horaIni.Text = gvHorarios.SelectedRow.Cells(2).Text.ToString
            horaFin.Text = gvHorarios.SelectedRow.Cells(3).Text.ToString
            Try
                ' Obtener el valor del curso seleccionado
                Dim nomEsc As String = gvHorarios.SelectedRow.Cells(4).Text.ToString()

                ' Verificar el valor obtenido
                If String.IsNullOrEmpty(nomEsc) Then
                    MsgBox("El nombre del curso está vacío.")
                    Return
                End If

                ' Llamar a la función listar_cursoH y obtener el DataTable
                Dim dt As DataTable = objHorario.listar_cursoH(nomEsc)

                ' Verificar que el DataTable no esté vacío
                If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                    MsgBox("No se encontraron resultados para el curso seleccionado.")
                    Return
                End If

                ' Obtener la única fila del DataTable
                Dim row As DataRow = dt.Rows(0)

                ' Verificar el valor de facultad_id
                ' Verificar y asignar el valor de facultad_id
                Dim facultadId As String = row("facultad_id").ToString()
                If String.IsNullOrEmpty(facultadId) Then
                    MsgBox("El ID de la facultad está vacío.")
                    Return
                End If
                cboFacultad.SelectedValue = Integer.Parse(facultadId)
                llenarCbxEscuela()

                ' Verificar y asignar el valor de escuela_id
                Dim escuelaId As String = row("escuela_id").ToString()
                If String.IsNullOrEmpty(escuelaId) Then
                    MsgBox("El ID de la escuela está vacío.")
                    Return
                End If
                cboEscuela.SelectedValue = Integer.Parse(escuelaId)
                llenarCboCiclo()

                ' Verificar y asignar el valor de ciclo
                Dim ciclo As String = row("ciclo").ToString()
                If String.IsNullOrEmpty(ciclo) Then
                    MsgBox("El ciclo está vacío.")
                    Return
                End If
                cboCiclo.SelectedValue = ciclo
                llenarCboCurso()

                ' Verificar y asignar el valor de curso_id
                Dim cursoId As String = row("curso_id").ToString()
                If String.IsNullOrEmpty(cursoId) Then
                    MsgBox("El ID del curso está vacío.")
                    Return
                End If
                cboCurso.SelectedValue = Integer.Parse(cursoId)
                llenarCboGrupo()

                ' Verificar y asignar el valor de grupo_id
                Dim grupoId As String = row("grupo_id").ToString()
                If String.IsNullOrEmpty(grupoId) Then
                    MsgBox("El ID del grupo está vacío.")
                    Return
                End If
                cboGrupo.SelectedValue = Integer.Parse(grupoId)


            Catch ex As Exception
                ' Manejar cualquier excepción que ocurra
                MsgBox("Ocurrió un error: " & ex.Message)
            End Try

        Catch ex As Exception

        End Try
    End Sub

    Public Sub refrescar_grilla()
        gvHorarios.DataSource = objHorario.listar_horario()
        gvHorarios.DataBind()
    End Sub

    Public Sub llenarCbxEscuela()
        Try
            cboEscuela.DataSource = objEscuela.listar_escuelas_1(Convert.ToInt32(cboFacultad.SelectedValue))
            cboEscuela.DataTextField = "nombre_escuela"
            cboEscuela.DataValueField = "escuela_id"
            cboEscuela.DataBind()
            cboEscuela.Items.Insert(0, New ListItem("Seleccione una opción", "0"))
        Catch ex As Exception
            MsgBox("Error")
        End Try
    End Sub


    Public Sub llenarCboSemestre()
        Try
            cboSemestre.DataSource = objCurso.listar_semestre()
            cboSemestre.DataTextField = "codigo_semestre"
            cboSemestre.DataValueField = "codigo_semestre"
            cboSemestre.DataBind()
        Catch ex As Exception
            MsgBox("Error")
        End Try
    End Sub

    Public Sub llenarCboFacultad()
        Try
            cboFacultad.DataSource = objFacultad.listar_facultades()
            cboFacultad.DataTextField = "nombre_facultad"
            cboFacultad.DataValueField = "facultad_id"
            cboFacultad.DataBind()
            cboFacultad.Items.Insert(0, New ListItem("Seleccione una opción", "0"))
        Catch ex As Exception
            MsgBox("Error")
        End Try
    End Sub

    Public Sub llenarCboCiclo()
        Try
            cboCiclo.DataSource = objEscuela.listar_ciclos(cboEscuela.SelectedValue)
            cboCiclo.DataTextField = "numero_ciclo"
            cboCiclo.DataValueField = "ciclo_id"
            cboCiclo.DataBind()
        Catch ex As Exception
            MsgBox("Error")
        End Try
    End Sub

    Public Sub llenarCboAmbiente()
        Try
            cboAmbiente.DataSource = objAmbiente.listar_ambiente()
            cboAmbiente.DataTextField = "descripcion_ambiente"
            cboAmbiente.DataValueField = "ambiente_id"
            cboAmbiente.DataBind()
            cboAmbiente.Items.Insert(0, New ListItem("Seleccione una opción", "0"))
        Catch ex As Exception
            MsgBox("Error")
        End Try
    End Sub

    Public Sub llenarCboCurso()
        Try
            cboCurso.DataSource = objCurso.listar_cursos_ciclo(cboCiclo.SelectedValue)
            cboCurso.DataTextField = "nombre_curso"
            cboCurso.DataValueField = "curso_id"
            cboCurso.DataBind()
        Catch ex As Exception
            MsgBox("Error")
        End Try
    End Sub

    Public Sub llenarCboGrupo()
        Try
            cboGrupo.DataSource = objCurso.listar_grupo(cboCurso.SelectedValue, cboSemestre.SelectedValue)
            cboGrupo.DataTextField = "denominacion"
            cboGrupo.DataValueField = "grupo_id"
            cboGrupo.DataBind()
            lblDoc.Text = objCurso.listar_docente(cboCurso.SelectedValue, cboSemestre.SelectedValue)
        Catch ex As Exception
            MsgBox("Error")
        End Try
    End Sub

    Public Sub llenarCboDias()
        Try
            cboDias.Items.Add(New ListItem("Lunes", "1"))
            cboDias.Items.Add(New ListItem("Martes", "2"))
            cboDias.Items.Add(New ListItem("Miércoles", "3"))
            cboDias.Items.Add(New ListItem("Jueves", "4"))
            cboDias.Items.Add(New ListItem("Viernes", "5"))
            cboDias.Items.Add(New ListItem("Sábado", "6"))
        Catch ex As Exception
            MsgBox("Error")
        End Try
    End Sub

    Private Sub cboFacultad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFacultad.SelectedIndexChanged
        llenarCbxEscuela()
    End Sub

    Private Sub cbxEscuela_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEscuela.SelectedIndexChanged
        llenarCboCiclo()
        llenarCboCurso()
        llenarCboGrupo()
    End Sub

    Private Sub cboCiclo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCiclo.SelectedIndexChanged
        llenarCboCurso()
        llenarCboGrupo()
    End Sub

    Private Sub cboCurso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCurso.SelectedIndexChanged
        llenarCboGrupo()
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnModificar.Enabled = True
        btnEliminar.Enabled = True
        btnCancelar.Enabled = True
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            Dim dia As String = cboDias.SelectedValue
            Dim h_inicio As String = horaIni.Text
            Dim h_final As String = horaFin.Text
            Dim ambiente_id As Integer = cboAmbiente.SelectedValue
            Dim grupo_id As Integer = cboGrupo.SelectedValue
            If objHorario.agregar_horario(dia, h_inicio, h_final, ambiente_id, grupo_id) Then
                MsgBox("Horario registrada")
            End If
            refrescar_grilla()
            btnNuevo.Enabled = True
            btnGrabar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            btnCancelar.Enabled = False
        Catch ex As Exception
            MsgBox("Horario no registrado")
        End Try
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            Dim idHorario As Integer = Convert.ToInt32(lblCodigo.Text)
            If objHorario.eliminar_horario(idHorario) Then
                MsgBox("Horario eliminado")
            End If
            refrescar_grilla()
            btnNuevo.Enabled = True
            btnGrabar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            btnCancelar.Enabled = False
        Catch ex As Exception
            MsgBox("Horario no eliminado")
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            Dim idHorario As Integer = Convert.ToInt32(lblCodigo.Text)
            Dim dia As String = cboDias.SelectedValue
            Dim h_inicio As String = horaIni.Text
            Dim h_final As String = horaFin.Text
            Dim ambiente_id As Integer = cboAmbiente.SelectedValue
            Dim grupo_id As Integer = cboGrupo.SelectedValue

            If objHorario.modificar_horario(idHorario, dia, h_inicio, h_final, ambiente_id, grupo_id) Then
                MsgBox("Horario modificado")
            End If
            refrescar_grilla()
            btnNuevo.Enabled = True
            btnGrabar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            btnCancelar.Enabled = False
        Catch ex As Exception
            MsgBox("Horario no modificado")
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnCancelar.Enabled = False
    End Sub
End Class