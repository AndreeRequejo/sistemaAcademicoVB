Imports Proyecto_LogicaNegocio
Public Class frm_matricula1
    Inherits System.Web.UI.Page
    Private objSemestre As New Semestre

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            obtenerFechaActual()
            llenarTxtSemestre()
        End If
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
End Class