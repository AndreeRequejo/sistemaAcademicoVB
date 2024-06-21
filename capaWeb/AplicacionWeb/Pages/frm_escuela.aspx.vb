Imports Proyecto_LogicaNegocio
Public Class frm_escuela
    Inherits System.Web.UI.Page
    Private objFacultad As New Facultad
    Private objEscuela As New Escuela

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cboFacultad.DataSource = objFacultad.listar_facultades()
            cboFacultad.DataTextField = "nombre_facultad"
            cboFacultad.DataValueField = "facultad_id"
            cboFacultad.DataBind()
            refrescar_grilla()
            controles_iniciales()
        End If
        'Dim x As Integer = cboFacultad.SelectedValue()
    End Sub

    Public Sub refrescar_grilla()
        gvEscuelas.DataSource = objEscuela.listar_escuelas()
        gvEscuelas.DataBind()
    End Sub
    Public Sub controles_iniciales()
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnCancelar.Enabled = False
        cboFacultad.SelectedIndex = -1
    End Sub

    Private Sub gvEscuelas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvEscuelas.SelectedIndexChanged
        Try
            lblCodigo.Text = gvEscuelas.SelectedRow.Cells(0).Text.ToString
            txtNomEscuela.Text = gvEscuelas.SelectedRow.Cells(1).Text.ToString
            cboFacultad.SelectedValue = gvEscuelas.SelectedRow.Cells(2).Text.ToString
            btnNuevo.Enabled = False
            btnGrabar.Enabled = False
            btnModificar.Enabled = True
            btnEliminar.Enabled = True
            btnCancelar.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtNomEscuela.Text = ""
        lblCodigo.Text = ""
        cboFacultad.ClearSelection()
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnModificar.Enabled = True
        btnEliminar.Enabled = True
        btnCancelar.Enabled = True
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            Dim codigo As Integer = objEscuela.obtenerIdEsc
            Dim idFacultad As Integer = Convert.ToInt32(cboFacultad.SelectedValue)
            If objEscuela.agregar_escuela(codigo, txtNomEscuela.Text, idFacultad) Then
                MsgBox("Escuela registrada")
            End If
            refrescar_grilla()
            controles_iniciales()
        Catch ex As Exception
            MsgBox("Escuela no registrada")
        End Try
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            Dim idFacultad As Integer = Convert.ToInt32(cboFacultad.SelectedValue)
            If objEscuela.modificar_escuela(lblCodigo.Text, txtNomEscuela.Text, idFacultad) Then
                MsgBox("Escuela modificada")
            End If
            refrescar_grilla()
            controles_iniciales()
        Catch ex As Exception
            MsgBox("Escuela no modificada")
        End Try
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If objEscuela.eliminar_escuela(lblCodigo.Text) Then
                MsgBox("Escuela eliminada")
            End If
            refrescar_grilla()
            controles_iniciales()
        Catch ex As Exception
            MsgBox("Escuela no eliminada")
        End Try
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        txtNomEscuela.Text = ""
        lblCodigo.Text = ""
        cboFacultad.ClearSelection()
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnCancelar.Enabled = False
    End Sub
End Class