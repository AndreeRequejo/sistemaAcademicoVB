Imports Proyecto_LogicaNegocio
Public Class frm_matricula1
    Inherits System.Web.UI.Page
    Private objSemestre As New Semestre

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            obtenerFechaActual()
            llenarTxtSemestre()
            grillaCursosVacia()
        End If
    End Sub

    Public Sub grillaCursosVacia()
        Dim dt As New DataTable()
        dt.Columns.Add("detalle_id")
        dt.Columns.Add("denominacion")
        dt.Columns.Add("hora_inicio")
        dt.Columns.Add("hora_fin")
        dt.Columns.Add("dia")

        If gvDetalle.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If

        gvDetalle.DataSource = dt
        gvDetalle.DataBind()
    End Sub

    Public Sub grillaMatriculaVacia()
        Dim dt As New DataTable()
        dt.Columns.Add("detalle_id")
        dt.Columns.Add("denominacion")
        dt.Columns.Add("hora_inicio")
        dt.Columns.Add("hora_fin")
        dt.Columns.Add("dia")

        If gvMatricula.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If

        gvDetalle.DataSource = dt
        gvDetalle.DataBind()
    End Sub

    Public Sub obtenerFechaActual()
        Dim fechaActual = DateTime.Now.ToString("yyyy-MM-dd")
        fechaMatricula.Text = fechaActual
        fechaMatricula.Enabled = False
    End Sub

    Public Sub llenarTxtSemestre()
        Try
            txtSemestre.Text = objSemestre.mostrar_semestre_actual()
            txtSemestre.Enabled = False
        Catch ex As Exception
            MsgBox("Error al listar el semestre")
        End Try
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click

    End Sub
End Class