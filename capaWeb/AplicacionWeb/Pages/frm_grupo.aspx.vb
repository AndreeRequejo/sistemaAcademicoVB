Imports System.Security.Cryptography
Imports Microsoft.SqlServer.Server
Imports Proyecto_LogicaNegocio
Public Class frm_grupo1
    Inherits System.Web.UI.Page
    Private objDocente As New Docente
    Private objCurso As New Curso
    Private objSemestre As New Semestre
    Private objGrupo As New Grupo
    Private objFacultad As New Facultad
    Private objEscuela As New Escuela
    Private objTipoAmbiente As New TipoAmbiente
    Private objAmbiente As New Ambiente
    Private objHorario As New Horario

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            controles_iniciales()
            cboCurso.Items.Insert(0, New ListItem("Seleccione una opcion", "0"))
            cboAmbiente.Items.Insert(0, New ListItem("Seleccione una opción", "0"))
            llenarCboFacultad()
            llenarCboDocente()
            llenarTxtSemestre()
            llenarCboDias()
            llenarCboTipoAmbiente()
            refrescar_grilla()
        End If
    End Sub

    Public Sub controles_iniciales()
        HabilitarBoton(btnNuevo, True)
        HabilitarBoton(btnGrabar, False)
        HabilitarBoton(btnModificar, False)
        HabilitarBoton(btnEliminar, False)
        HabilitarBoton(btnCancelar, False)
        HabilitarBoton(btnNuevoH, True)
        HabilitarBoton(btnGrabarH, False)
        HabilitarBoton(btnModificarH, False)
        HabilitarBoton(btnEliminarH, False)
        HabilitarBoton(btnCancelarH, False)
        HabilitarBoton(btnBuscar1, False)
    End Sub

    Private Sub HabilitarBoton(btn As LinkButton, habilitar As Boolean)
        btn.Enabled = habilitar
        If habilitar Then
            btn.CssClass = btn.CssClass.Replace("linkbutton-disabled", "")
        Else
            If Not btn.CssClass.Contains("linkbutton-disabled") Then
                btn.CssClass &= " linkbutton-disabled"
            End If
        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs)
        refrescar_grilla()
    End Sub

    Protected Sub btnBuscar1_Click(sender As Object, e As EventArgs)
        If Not btnNuevo.Enabled Then
            MsgBox("btnNuevo está deshabilitado.")
            Try
                ' Llamar a la función para obtener la próxima denominación
                Dim Dem As DataTable = objGrupo.denominacion_grupos(Integer.Parse(cboCurso.SelectedValue))
                If Dem.Rows.Count > 0 Then
                    Dim row As DataRow = Dem.Rows(0)
                    txtDenominacion.Text = row("ProximaDenominacion").ToString()
                Else
                    txtDenominacion.Text = "A" ' En caso de que no haya denominación previa
                End If
            Catch ex As Exception
            End Try
        Else
        End If
    End Sub

    Private Sub gvGrupos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvGrupos.SelectedIndexChanged
        Try
            HabilitarBoton(btnNuevo, False)
            HabilitarBoton(btnGrabar, False)
            HabilitarBoton(btnModificar, True)
            HabilitarBoton(btnEliminar, True)
            HabilitarBoton(btnCancelar, True)
            HabilitarBoton(btnBuscar1, False)

            Dim name_curso As String = gvGrupos.SelectedRow.Cells(1).Text.ToString()
            Dim dem_grupo As String = gvGrupos.SelectedRow.Cells(2).Text.ToString()
            Dim ver As DataTable
            Dim formato As DataTable = Nothing

            ver = objHorario.listar_Hor(name_curso, dem_grupo)
            Dim row_0 As DataRow = ver.Rows(0)
            Dim ver_1 As String = row_0("conteo").ToString()
            ' Llamar a la función listar_H y obtener el DataTable
            If (ver_1 = "1") Then
                formato = objHorario.listar_H(name_curso, dem_grupo)
            ElseIf (ver_1 = "0") Then
                formato = objHorario.listar_H1_1(name_curso, dem_grupo)
            End If

            ' Obtener la primera fila de la DataTable
            Dim row As DataRow = formato.Rows(0)

            ' Acceder a los valores individuales de la fila
            Dim facultadId As String = row("facultad_id").ToString()
            If String.IsNullOrEmpty(facultadId) Then
                MsgBox("El ID de la facultad está vacío.")
                Return
            End If
            cboFacultad.SelectedValue = Integer.Parse(facultadId)
            llenarCboEscuela()


            If (ver_1 = "1") Then

                ' Asignar los demás valores
                Dim nombre_escuela As String = row("escuela_id").ToString()
                Dim ciclo As String = row("ciclo").ToString()
                Dim denominacion As String = row("denominacion").ToString()
                Dim numero_vacantes As String = row("numero_vacantes").ToString()
                Dim estado_grupo As String = row("estado_grupo").ToString()
                Dim cursoId As String = row("curso_id").ToString()
                Dim nombre_docente As String = row("docente_id").ToString()
                Dim tipoAmbienteId As String = row("tipoambiente_id").ToString()
                Dim ambienteId As String = row("ambiente_id").ToString()
                Dim dia As String = row("dia").ToString()
                Dim hora_inicio As String = row("hora_inicio").ToString()
                Dim hora_final As String = row("hora_final").ToString()
                Dim grupo_id As String = row("grupo_id").ToString()
                Dim horario_id As String = row("horario_id").ToString()

                cboEscuela.SelectedValue = Integer.Parse(nombre_escuela)
                llenarCboCiclo()
                llenarCboCurso()
                cboCiclo.SelectedValue = Integer.Parse(ciclo)
                llenarCboCurso()
                txtDenominacion.Text = denominacion
                txtVacantes.Text = numero_vacantes
                chkEstado.Checked = If(estado_grupo = "True", True, False)
                cboCurso.SelectedValue = Integer.Parse(cursoId)
                cboDocente.SelectedValue = nombre_docente
                cboTipoAmb.SelectedValue = Integer.Parse(tipoAmbienteId)
                llenarCboAmbiente()
                cboAmbiente.SelectedValue = Integer.Parse(ambienteId)
                cboDias.SelectedValue = Integer.Parse(dia)
                horaIni.Text = hora_inicio
                horaFin.Text = hora_final
                txtGrupo.Text = grupo_id
                txtIdGrupo.Text = grupo_id
                txtHorario.Text = horario_id

                Dim horarios As DataTable = objHorario.listar_grupo_horario(name_curso, dem_grupo)
                gvHorarios.DataSource = horarios
                gvHorarios.DataBind()
            ElseIf (ver_1 = "0") Then

                ' Asignar los demás valores
                Dim nombre_escuela As String = row("escuela_id").ToString()
                Dim ciclo As String = row("ciclo").ToString()
                Dim denominacion As String = row("denominacion").ToString()
                Dim numero_vacantes As String = row("numero_vacantes").ToString()
                Dim estado_grupo As String = row("estado_grupo").ToString()
                Dim cursoId As String = row("curso_id").ToString()
                Dim nombre_docente As String = row("docente_id").ToString()
                Dim grupo_id As String = row("grupo_id").ToString()
                cboEscuela.SelectedValue = Integer.Parse(nombre_escuela)
                llenarCboCiclo()
                llenarCboCurso()
                cboCiclo.SelectedValue = Integer.Parse(ciclo)
                llenarCboCurso()
                txtDenominacion.Text = denominacion
                txtVacantes.Text = numero_vacantes
                chkEstado.Checked = If(estado_grupo = "True", True, False)
                cboCurso.SelectedValue = Integer.Parse(cursoId)
                cboDocente.SelectedValue = nombre_docente
                txtGrupo.Text = grupo_id
                txtIdGrupo.Text = grupo_id
            End If

        Catch ex As Exception
            ' Manejar cualquier excepción que ocurra
            MsgBox("Ocurrió un error: " & ex.Message)
        End Try
    End Sub

    Private Sub gvHorarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvHorarios.SelectedIndexChanged
        HabilitarBoton(btnNuevoH, False)
        HabilitarBoton(btnGrabarH, False)
        HabilitarBoton(btnModificarH, True)
        HabilitarBoton(btnEliminarH, True)
        HabilitarBoton(btnCancelarH, True)

        Dim name_curso As String = gvHorarios.SelectedRow.Cells(0).Text.ToString()
        Dim horario_id As Integer = Integer.Parse(name_curso)
        Dim dem_grupo As String = gvHorarios.SelectedRow.Cells(1).Text.ToString()

        Dim formato As DataTable = objHorario.listar_H1(horario_id, dem_grupo)
        If formato Is Nothing OrElse formato.Rows.Count = 0 Then
            MsgBox("No se encontraron resultados para el horario seleccionado.")
            limpiar_datos()
            Return
        End If

        Dim row As DataRow = formato.Rows(0)

        Dim tipoAmbienteId As String = row("tipoambiente_id").ToString()
        Dim ambienteId As String = row("ambiente_id").ToString()
        Dim dia As String = row("dia").ToString()
        Dim hora_inicio As String = row("hora_inicio").ToString()
        Dim hora_final As String = row("hora_final").ToString()
        Dim grupo_id As String = row("grupo_id").ToString()

        cboTipoAmb.SelectedValue = Integer.Parse(tipoAmbienteId)
        llenarCboAmbiente()
        cboAmbiente.SelectedValue = Integer.Parse(ambienteId)
        cboDias.SelectedValue = Integer.Parse(dia)
        horaIni.Text = hora_inicio
        horaFin.Text = hora_final
        txtGrupo.Text = grupo_id
        txtIdGrupo.Text = grupo_id
        txtHorario.Text = horario_id

    End Sub



    Public Sub llenarCboFacultad()
        Try
            cboFacultad.DataSource = objFacultad.listar_facultades()
            cboFacultad.DataTextField = "nombre_facultad"
            cboFacultad.DataValueField = "facultad_id"
            cboFacultad.DataBind()
            cboFacultad.Items.Insert(0, New ListItem("Seleccione una opción", "0"))
        Catch ex As Exception
            MsgBox("Error al listar facultades")
        End Try
    End Sub

    Public Sub llenarCboEscuela()
        Try
            cboEscuela.DataSource = objEscuela.listar_escuelas_1(Convert.ToInt32(cboFacultad.SelectedValue))
            cboEscuela.DataTextField = "nombre_escuela"
            cboEscuela.DataValueField = "escuela_id"
            cboEscuela.DataBind()
            cboEscuela.Items.Insert(0, New ListItem("Seleccione una opción", "0"))
        Catch ex As Exception
            MsgBox("Error al listar escuelas")
        End Try
    End Sub

    Public Sub llenarCboCiclo()
        Try
            cboCiclo.DataSource = objEscuela.listar_ciclos(cboEscuela.SelectedValue)
            cboCiclo.DataTextField = "numero_ciclo"
            cboCiclo.DataValueField = "ciclo_id"
            cboCiclo.DataBind()
        Catch ex As Exception
            MsgBox("Error al listar ciclos")
        End Try
    End Sub

    Public Sub llenarCboCurso()
        Try
            cboCurso.DataSource = objCurso.listar_cursos_ciclo(cboCiclo.SelectedValue)
            cboCurso.DataTextField = "nombre_curso"
            cboCurso.DataValueField = "curso_id"
            cboCurso.DataBind()
            cboCurso.Items.Insert(0, New ListItem("Seleccione una opción", "0"))
        Catch ex As Exception
            MsgBox("Error al listar cursos")
        End Try
    End Sub

    Public Sub llenarCboDocente()
        Try
            cboDocente.DataSource = objDocente.listar_docentesNombre()
            cboDocente.DataTextField = "nombre_docente"
            cboDocente.DataValueField = "docente_id"
            cboDocente.DataBind()
            cboDocente.Items.Insert(0, New ListItem("Seleccione una opcion", "0"))
        Catch ex As Exception
            MsgBox("Error al listar docentes")
        End Try
    End Sub

    Public Sub llenarTxtSemestre()
        Try
            ' Supongamos que solo hay un semestre que queremos mostrar, se puede obtener de la base de datos
            txtSemestre.Text = objSemestre.mostrar_semestre_actual()
            txtSemestre.Enabled = False ' Asegurándose de que el campo esté deshabilitado
        Catch ex As Exception
            MsgBox("Error al listar el semestre")
        End Try
    End Sub

    Public Sub llenarCboDias()
        Try
            cboDias.Items.Add(New ListItem("Seleccione un dia", "0"))
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

    Public Sub llenarCboTipoAmbiente()
        Try
            cboTipoAmb.DataSource = objTipoAmbiente.listar_tipoAmbientes()
            cboTipoAmb.DataTextField = "descripcion_tipoambiente"
            cboTipoAmb.DataValueField = "tipoambiente_id"
            cboTipoAmb.DataBind()
            cboTipoAmb.Items.Insert(0, New ListItem("Seleccione una opción", "0"))
        Catch ex As Exception
            MsgBox("Error al listar tipos de ambiente")
        End Try
    End Sub

    Public Sub llenarCboAmbiente()
        Try
            cboAmbiente.DataSource = objAmbiente.listar_ambiente(Convert.ToInt32(cboTipoAmb.SelectedValue))
            cboAmbiente.DataTextField = "descripcion_ambiente"
            cboAmbiente.DataValueField = "ambiente_id"
            cboAmbiente.DataBind()
        Catch ex As Exception
            MsgBox("Error al listar ambientes")
        End Try
    End Sub

    Public Sub refrescar_grilla()
        Try
            Dim grupos As DataTable = objGrupo.listar_grupos(Convert.ToInt32(cboCurso.SelectedValue), txtSemestre.Text)
            gvGrupos.DataSource = grupos
            gvGrupos.DataBind()

            Dim horarios As DataTable = objHorario.listar_grupo_horario(Convert.ToInt32(cboCurso.SelectedValue), txtDenominacion.Text)
            gvHorarios.DataSource = horarios
            gvHorarios.DataBind()
        Catch ex As Exception
            MsgBox("Error al cargar los datos: " & ex.Message)
        End Try
    End Sub

    Private Sub cboFacultad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFacultad.SelectedIndexChanged
        llenarCboEscuela()
    End Sub

    Private Sub cboEscuela_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEscuela.SelectedIndexChanged
        llenarCboCiclo()
        llenarCboCurso()
    End Sub

    Private Sub cboCiclo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCiclo.SelectedIndexChanged
        llenarCboCurso()
    End Sub

    Private Sub cboCurso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCurso.SelectedIndexChanged
        refrescar_grilla()
    End Sub

    Private Sub cboTipoAmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoAmb.SelectedIndexChanged
        llenarCboAmbiente()
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtDenominacion.Text = ""
        txtVacantes.Text = ""
        cboFacultad.ClearSelection()
        cboEscuela.ClearSelection()
        cboCiclo.ClearSelection()
        cboDocente.ClearSelection()
        cboCurso.ClearSelection()
        chkEstado.Checked = True
        HabilitarBoton(btnNuevo, False)
        HabilitarBoton(btnGrabar, True)
        HabilitarBoton(btnModificar, False)
        HabilitarBoton(btnEliminar, False)
        HabilitarBoton(btnCancelar, False)
        HabilitarBoton(btnBuscar1, True)
    End Sub

    Protected Sub btnNuevoH_Click(sender As Object, e As EventArgs) Handles btnNuevoH.Click
        txtGrupo.Text = ""
        cboTipoAmb.ClearSelection()
        cboAmbiente.ClearSelection()
        horaIni.Text = ""
        horaFin.Text = ""
        cboDias.ClearSelection()
        HabilitarBoton(btnNuevoH, False)
        HabilitarBoton(btnGrabarH, True)
        HabilitarBoton(btnModificarH, False)
        HabilitarBoton(btnEliminarH, False)
        HabilitarBoton(btnCancelarH, True)
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            Dim idCurso As Integer = Integer.Parse(cboCurso.SelectedValue)
            Dim idDocente As Integer = Integer.Parse(cboDocente.SelectedValue)
            Dim idSemestre As String = txtSemestre.Text ' Cambiado para usar el TextBox del semestre
            Dim estadoGrupo As Boolean = chkEstado.Checked
            Dim estado As Integer = If(estadoGrupo = "True", 1, 0)
            Dim denominacion As String = txtDenominacion.Text
            Dim vacantes As Integer = txtVacantes.Text

            Dim retorno As Integer = objGrupo.agregar_grupo(denominacion, Convert.ToInt32(vacantes), estado, idCurso, idDocente, idSemestre)

            If retorno = 0 Then
                MsgBox("Grupo registrado")
            Else
                MsgBox("Grupo no registrado")
            End If

            refrescar_grilla()
            controles_iniciales()
        Catch ex As Exception
            MsgBox("Ocurrio un error al procesar la solicitud")
        End Try
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            Dim idCurso As Integer = Integer.Parse(cboCurso.SelectedValue)
            Dim idDocente As Integer = Integer.Parse(cboDocente.SelectedValue)
            Dim idSemestre As String = txtSemestre.Text ' Cambiado para usar el TextBox del semestre
            Dim estadoGrupo As Boolean = chkEstado.Checked
            Dim estado As Integer = If(estadoGrupo = "True", 1, 0)
            Dim denominacion As String = txtDenominacion.Text
            Dim vacantes As Integer = txtVacantes.Text
            Dim grupo_id As Integer = txtGrupo.Text

            Dim retorno As Integer = objGrupo.modificar_grupo(Convert.ToInt32(grupo_id), denominacion, Convert.ToInt32(vacantes), estado, idCurso, idDocente, idSemestre)

            If retorno = 0 Then
                MsgBox("Grupo modificado")
            Else
                MsgBox("Grupo no modificado")
            End If
            refrescar_grilla()
            controles_iniciales()
        Catch ex As Exception
            MsgBox("Ocurrio un error al procesar la solicitud")
        End Try
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            Dim grupo_id As Integer = txtIdGrupo.Text
            Dim retorno As Integer = objGrupo.eliminar_grupo(Integer.Parse(grupo_id))
            If retorno = 0 Then
                MsgBox("Grupo Eliminado")
            Else
                MsgBox("Grupo no Eliminado")
            End If
            refrescar_grilla()
            controles_iniciales()
        Catch ex As Exception
            MsgBox("Ocurrio un error al procesar la solicitud")
        End Try
    End Sub


    Protected Sub btnGrabarH_Click(sender As Object, e As EventArgs) Handles btnGrabarH.Click
        Try

            Dim idGrupo As Integer = txtGrupo.Text
            Dim ambiente As Integer = cboAmbiente.SelectedValue
            Dim h_ini As String = horaIni.Text
            Dim h_fin As String = horaFin.Text
            Dim dia As String = cboDias.SelectedValue


            Dim retorno As Integer = objHorario.agregar_horario(Convert.ToInt32(dia), h_ini, h_fin, Convert.ToInt32(ambiente), Convert.ToInt32(idGrupo))

            If retorno = 0 Then
                MsgBox("Horario registrado")
            Else
                MsgBox("Horario no registrado")
            End If
            refrescar_grilla()
            controles_iniciales()
        Catch ex As Exception
            MsgBox("Ocurrio un error al procesar la solicitud")
        End Try
    End Sub

    Protected Sub btnModificarH_Click(sender As Object, e As EventArgs) Handles btnModificarH.Click
        Try

            Dim idGrupo As Integer = txtGrupo.Text
            Dim ambiente As Integer = cboAmbiente.SelectedValue
            Dim h_ini As String = horaIni.Text
            Dim h_fin As String = horaFin.Text
            Dim dia As String = cboDias.SelectedValue
            Dim horario As Integer = txtHorario.Text


            Dim retorno As Integer = objHorario.modificar_horario(Convert.ToInt32(horario), Convert.ToInt32(dia), h_ini, h_fin, Convert.ToInt32(ambiente), Convert.ToInt32(idGrupo))

            If retorno = 0 Then
                MsgBox("Horario modificado")
            Else
                MsgBox("Horario no modificado")
            End If
            refrescar_grilla()
            controles_iniciales()
        Catch ex As Exception
            MsgBox("Ocurrio un error al procesar la solicitud")
        End Try
    End Sub

    Protected Sub btnEliminarH_Click(sender As Object, e As EventArgs) Handles btnEliminarH.Click
        Try
            Dim horario_id As Integer = txtHorario.Text
            Dim retorno As Integer = objHorario.eliminar_horario(Integer.Parse(horario_id))
            If retorno = 0 Then
                MsgBox("Horario no Eliminado")
            Else
                MsgBox("Horario Eliminado")
            End If
            refrescar_grilla()
            controles_iniciales()
        Catch ex As Exception
            MsgBox("Ocurrio un error al procesar la solicitud")
        End Try
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        txtDenominacion.Text = ""
        txtVacantes.Text = ""
        cboFacultad.ClearSelection()
        cboEscuela.ClearSelection()
        cboCiclo.ClearSelection()
        cboDocente.ClearSelection()
        cboCurso.ClearSelection()
        chkEstado.Checked = True
        HabilitarBoton(btnNuevo, True)
        HabilitarBoton(btnGrabar, False)
        HabilitarBoton(btnModificar, False)
        HabilitarBoton(btnEliminar, False)
        HabilitarBoton(btnCancelar, False)
        HabilitarBoton(btnBuscar1, False)
    End Sub

    Public Sub limpiar_datos()
        txtDenominacion.Text = ""
        txtVacantes.Text = ""
        cboFacultad.ClearSelection()
        cboEscuela.ClearSelection()
        cboCiclo.ClearSelection()
        cboDocente.ClearSelection()
        cboCurso.ClearSelection()
        chkEstado.Checked = False
        txtGrupo.Text = ""
        cboTipoAmb.ClearSelection()
        cboAmbiente.ClearSelection()
        horaIni.Text = ""
        horaFin.Text = ""
        cboDias.ClearSelection()
    End Sub

    Protected Sub btnCancelarH_Click(sender As Object, e As EventArgs) Handles btnCancelarH.Click
        txtGrupo.Text = ""
        cboTipoAmb.ClearSelection()
        cboAmbiente.ClearSelection()
        horaIni.Text = ""
        horaFin.Text = ""
        cboDias.ClearSelection()
        HabilitarBoton(btnNuevoH, True)
        HabilitarBoton(btnGrabarH, False)
        HabilitarBoton(btnModificarH, False)
        HabilitarBoton(btnEliminarH, False)
        HabilitarBoton(btnCancelarH, False)
    End Sub
End Class