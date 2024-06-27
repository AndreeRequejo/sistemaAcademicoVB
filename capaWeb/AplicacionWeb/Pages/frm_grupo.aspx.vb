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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            controles_iniciales()
            llenarCboFacultad()
            llenarCboDocente()
            llenarTxtSemestre() ' Cambiado para llenar el TextBox del semestre
            llenarCboDias()
            llenarCboTipoAmbiente()
            refrescar_grilla()
        End If
    End Sub

    Public Sub controles_iniciales()
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnCancelar.Enabled = False
    End Sub

    Public Sub refrescar_grilla()
        'gvGrupos.DataSource = objGrupo.listar_grupos()
        'gvGrupos.DataBind()
    End Sub

    Private Sub gvGrupos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvGrupos.SelectedIndexChanged
        btnNuevo.Enabled = False
        btnGrabar.Enabled = False
        btnModificar.Enabled = True
        btnEliminar.Enabled = True
        btnCancelar.Enabled = True
        Try
            txtIdGrupo.Text = gvGrupos.SelectedRow.Cells(0).Text.ToString
            txtDenominacion.Text = gvGrupos.SelectedRow.Cells(1).Text.ToString
            txtVacantes.Text = gvGrupos.SelectedRow.Cells(2).Text.ToString
            If gvGrupos.SelectedRow.Cells(3).Text.ToString = "False" Then
                chkEstado.Checked = False
            Else
                chkEstado.Checked = True
            End If
            txtSemestre.Text = gvGrupos.SelectedRow.Cells(6).Text.ToString ' Cambiado para usar el TextBox del semestre
            cboDocente.SelectedValue = objDocente.obtener_idDocente(gvGrupos.SelectedRow.Cells(5).Text.ToString)
            cboCurso.SelectedValue = objCurso.obtener_idCurso(gvGrupos.SelectedRow.Cells(4).Text.ToString)

        Catch ex As Exception

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
            cboCurso.Items.Insert(0, New ListItem("Seleccione una opcion", "0"))
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

    Private Sub cboTipoAmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoAmb.SelectedIndexChanged
        llenarCboAmbiente()
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtDenominacion.Text = ""
        txtVacantes.Text = ""
        cboDocente.ClearSelection()
        cboCurso.ClearSelection()
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnModificar.Enabled = True
        btnEliminar.Enabled = True
        btnCancelar.Enabled = True
        chkEstado.Checked = True
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            Dim idCurso As Integer = cboCurso.SelectedValue
            Dim idDocente As Integer = cboDocente.SelectedValue
            Dim idSemestre As String = txtSemestre.Text ' Cambiado para usar el TextBox del semestre
            Dim estadoGrupo As Integer = chkEstado.Checked

            Dim retorno As Integer = objGrupo.agregar_grupo(txtDenominacion.Text, Convert.ToInt32(txtVacantes.Text), estadoGrupo, idCurso, idDocente, idSemestre)

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
            Dim idCurso As Integer = cboCurso.SelectedValue
            Dim idDocente As Integer = cboDocente.SelectedValue
            Dim idSemestre As String = txtSemestre.Text ' Cambiado para usar el TextBox del semestre
            Dim estadoGrupo As Integer = chkEstado.Checked

            Dim retorno As Integer = objGrupo.modificar_grupo(Integer.Parse(txtIdGrupo.Text), txtDenominacion.Text, Convert.ToInt32(txtVacantes.Text), estadoGrupo, idCurso, idDocente, idSemestre)

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
            Dim retorno As Integer = objGrupo.eliminar_grupo(Integer.Parse(txtIdGrupo.Text))
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

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        txtDenominacion.Text = ""
        txtVacantes.Text = ""
        chkEstado.Checked = True
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnCancelar.Enabled = False
    End Sub
End Class