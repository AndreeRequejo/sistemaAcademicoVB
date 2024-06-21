Imports Proyecto_LogicaNegocio

Public Class frm_facultad
    Inherits System.Web.UI.Page
    Private objFacultad As New Facultad

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        refrescar_grilla()
        controles_iniciales()
    End Sub

    Public Sub refrescar_grilla()
        gvFacultades.DataSource = objFacultad.listar_facultades()
        gvFacultades.DataBind()
    End Sub

    Public Sub controles_iniciales()
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnCancelar.Enabled = False
    End Sub

    Protected Sub gvFacultades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvFacultades.SelectedIndexChanged
        Try
            lblCodigo.Text = gvFacultades.SelectedRow().Cells(0).Text.ToString
            txtNomFacultad.Text = gvFacultades.SelectedRow().Cells(1).Text.ToString
            btnNuevo.Enabled = False
            btnGrabar.Enabled = False
            btnModificar.Enabled = True
            btnEliminar.Enabled = True
            btnCancelar.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtNomFacultad.Text = ""
        lblCodigo.Text = ""
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnModificar.Enabled = True
        btnEliminar.Enabled = True
        btnCancelar.Enabled = True
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            Dim codigo As Integer = objFacultad.obtenerIdFac()
            If objFacultad.agregar_facultad(codigo, txtNomFacultad.Text) Then
                MsgBox("Facultad registrada")
            End If
            refrescar_grilla()
            controles_iniciales()
        Catch ex As Exception
            MsgBox("Facultad no registrada")
        End Try
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If objFacultad.modificar_facultad(lblCodigo.Text, txtNomFacultad.Text) Then
                MsgBox("Facultad modificada")
            End If
            refrescar_grilla()
            controles_iniciales()
        Catch ex As Exception
            MsgBox("Facultad no modificada")
        End Try
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If objFacultad.eliminar_facultad(lblCodigo.Text) Then
                MsgBox("Facultad eliminada")
            End If
            refrescar_grilla()
            controles_iniciales()
        Catch ex As Exception
            MsgBox("Facultad no eliminada")
        End Try
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        txtNomFacultad.Text = ""
        lblCodigo.Text = ""
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnCancelar.Enabled = False
    End Sub

End Class
