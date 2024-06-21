Imports System.Windows.Forms

Public Class mdiMenu

    Private m_ChildFormNumber As Integer

    Private Sub FacultadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacultadToolStripMenuItem.Click
        Dim objFrmFacultad As New frmManFacultad
        objFrmFacultad.MdiParent = Me
        objFrmFacultad.Show()
    End Sub

    Private Sub MantenimientoDeAlumnoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeAlumnoToolStripMenuItem.Click
        Dim objFrmAlumno As New frmManAlumno
        objFrmAlumno.MdiParent = Me
        objFrmAlumno.Show()
    End Sub

    Private Sub MantenimientoDeSemestreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeSemestreToolStripMenuItem.Click
        Dim objFrmSemestre As New frmManSemestre
        objFrmSemestre.MdiParent = Me
        objFrmSemestre.Show()
    End Sub

    Private Sub CursoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CursoToolStripMenuItem.Click
        Dim objFrmCurso As New frmManCurso
        objFrmCurso.MdiParent = Me
        objFrmCurso.Show()
    End Sub

    Private Sub MantenimientoDePrerequisitosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDePrerequisitosToolStripMenuItem.Click
        Dim objFrmPre As New frmManCurso_Curso
        objFrmPre.MdiParent = Me
        objFrmPre.Show()
    End Sub

    Private Sub MantenimientoDeAmbienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeAmbienteToolStripMenuItem.Click
        Dim objFrmAmbiente As New frmManAmbiente
        objFrmAmbiente.MdiParent = Me
        objFrmAmbiente.Show()
    End Sub

    Private Sub EscuelaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EscuelaToolStripMenuItem.Click
        Dim objFrmEscuela As New frmManEscuela
        objFrmEscuela.MdiParent = Me
        objFrmEscuela.Show()
    End Sub

    Private Sub MantenimientoDeDocenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeDocenteToolStripMenuItem.Click
        Dim objFrmDocente As New frmManDocente
        objFrmDocente.MdiParent = Me
        objFrmDocente.Show()
    End Sub

    Private Sub MantenimientoDePlanDeEstudioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDePlanDeEstudioToolStripMenuItem.Click
        Dim objFrmPlan As New frmManPlanEstudio
        objFrmPlan.MdiParent = Me
        objFrmPlan.Show()
    End Sub

    Private Sub MantenimientoDeUbigeoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeUbigeoToolStripMenuItem.Click
        Dim objFrmUbigeo As New frmManUbigeo
        objFrmUbigeo.MdiParent = Me
        objFrmUbigeo.Show()
    End Sub

    Private Sub MantenimientoDeTipoAmbienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeTipoAmbienteToolStripMenuItem.Click
        Dim objFrmTipoAmbiente As New frmManTipoAmbiente
        objFrmTipoAmbiente.MdiParent = Me
        objFrmTipoAmbiente.Show()
    End Sub
End Class
