Imports Proyecto_LogicaNegocio
Public Class frm_grupo1
    Inherits System.Web.UI.Page
    Private objDocente As New Docente
    Private objCurso As New Curso
    Private objSemestre As New Semestre
    Private objGrupo As New Grupo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            controles_iniciales()
            llenarCboCurso()
            llenarCboDocente()
            llenarCboSemestre()
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
        gvGrupos.DataSource = objGrupo.listar_grupos()
        gvGrupos.DataBind()
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
            cboSemestre.SelectedValue = gvGrupos.SelectedRow.Cells(6).Text.ToString
            cboDocente.SelectedValue = objDocente.obtener_idDocente(gvGrupos.SelectedRow.Cells(5).Text.ToString)
            cboCurso.SelectedValue = objCurso.obtener_idCurso(gvGrupos.SelectedRow.Cells(4).Text.ToString)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub llenarCboCurso()
        Try
            cboCurso.DataSource = objCurso.listar_cursos()
            cboCurso.DataTextField = "nombre_curso"
            cboCurso.DataValueField = "curso_id"
            cboCurso.DataBind()
            cboCurso.Items.Insert(0, New ListItem("Seleccione una opcion", "0"))
        Catch ex As Exception
            MsgBox("Error")
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
            MsgBox("Error")
        End Try
    End Sub

    Public Sub llenarCboSemestre()
        Try
            cboSemestre.DataSource = objCurso.listar_semestre()
            cboSemestre.DataTextField = "codigo_semestre"
            cboSemestre.DataValueField = "codigo_semestre"
            cboSemestre.DataBind()
            cboSemestre.Items.Insert(0, New ListItem("Seleccione una opcion", "0"))
        Catch ex As Exception
            MsgBox("Error")
        End Try
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtDenominacion.Text = ""
        txtVacantes.Text = ""
        txtVacantes.Text = ""
        cboDocente.ClearSelection()
        cboSemestre.ClearSelection()
        cboCurso.ClearSelection()
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnModificar.Enabled = True
        btnEliminar.Enabled = True
        btnCancelar.Enabled = True
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try

            Dim idCurso As Integer = cboCurso.SelectedValue
            Dim idDocente As Integer = cboDocente.SelectedValue
            Dim idSemestre As String = cboSemestre.SelectedValue
            Dim estadoGrupo As Integer = chkEstado.Checked

            Dim retorno As Integer = objGrupo.agregar_grupo(txtDenominacion.Text, Convert.ToInt32(txtVacantes.Text), estadoGrupo,
                                     idCurso, idDocente, idSemestre)

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
            Dim idSemestre As String = cboSemestre.SelectedValue
            Dim estadoGrupo As Integer = chkEstado.Checked

            Dim retorno As Integer = objGrupo.modificar_grupo(Integer.Parse(txtIdGrupo.Text), txtDenominacion.Text, Convert.ToInt32(txtVacantes.Text), estadoGrupo,
                                     idCurso, idDocente, idSemestre)

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