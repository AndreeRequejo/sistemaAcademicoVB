Imports System.Reflection
Imports System.Windows.Forms
Imports Proyecto_LogicaNegocio
Public Class frmManCurso_Curso
    Dim objCurso_Curso As New Curso_Curso
    Dim prerrequisito As Integer
    Private bandera As Boolean

    Private Sub frmManCurso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        confInicio()
        cbxC1.Items.Add(0)
        cbxC1.Items.Add(1)
        cbxC1.Items.Add(2)
        cbxC1.Items.Add(3)
        cbxC1.Items.Add(4)
        cbxC1.Items.Add(5)
        cbxC1.Items.Add(6)
        cbxC1.Items.Add(7)
        cbxC1.Items.Add(8)
        cbxC1.Items.Add(9)
        cbxC1.Items.Add(10)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        bandera = True
        cbxPre.Enabled = True
        cbxCurso.Enabled = True
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
    End Sub
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            Dim retorno As Integer
            Dim mensaje As String = String.Empty
            Dim curso As Integer = Convert.ToInt32(cbxCurso.SelectedValue)
            Dim pre As Integer = Convert.ToInt32(cbxPre.SelectedValue)
            If bandera Then
                '#Insertar'
                retorno = objCurso_Curso.agregar_curso_curso(curso, pre)

            Else
                '#Modificar'
                retorno = objCurso_Curso.modificar_curso_curso(curso, prerrequisito, pre)

            End If
            Select Case retorno
                Case 0
                    mensaje = If(bandera, "Registro completo", "Actualización completa")
                Case 1
                    mensaje = "Duplicado"
            End Select
            MessageBox.Show(mensaje)
            llenar_grilla()
            cbxPre.Enabled = False
            cbxCurso.Enabled = False
            btnNuevo.Enabled = True
            btnGrabar.Enabled = False
            btnCancelar.Enabled = False
            btnEliminar.Enabled = False
            btnModificar.Enabled = False
            btnSalir.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        bandera = False
        cbxPre.Enabled = True
        cbxCurso.Enabled = True
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
        btnCancelar.Enabled = True
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            Dim retorno As Integer
            Dim mensaje As String = String.Empty
            Dim curso As Integer = Convert.ToInt32(cbxCurso.SelectedValue)
            Dim pre As Integer = Convert.ToInt32(cbxPre.SelectedValue)
            retorno = objCurso_Curso.eliminar_curso_curso(curso, pre)
            Select Case retorno
                Case 0
                    mensaje = "Curso eliminado correctamente"
                Case -1
                    mensaje = "Error al procesar eliminación."
            End Select
            MessageBox.Show(mensaje)
            llenar_grilla()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvCurso_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCurso.SelectionChanged
        Try
            Dim id As Integer = Convert.ToInt32(dgvCurso.CurrentRow.Cells(0).Value)
            Dim pre As Integer = Convert.ToInt32(dgvCurso.CurrentRow.Cells(3).Value)
            Dim resultado As DataTable = objCurso_Curso.listar_cursos_cursos_3(id, pre)
            Dim ciclo As Integer

            If resultado.Rows.Count > 0 Then
                ciclo = Convert.ToInt32(resultado.Rows(0)("ciclo"))
            End If

            If ciclo.GetType() = GetType(Integer) Then
                Console.WriteLine("Si es un número.")
                cbxC1.SelectedItem = ciclo
                cbxCurso.SelectedValue = resultado.Rows(0)("codigo_curso")
                cbxPre.SelectedValue = resultado.Rows(0)("codigo_curso_curso")
                prerrequisito = cbxPre.SelectedValue
            Else
                Console.WriteLine("No es un número.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub dgvCurso_Click(sender As Object, e As EventArgs) Handles dgvCurso.Click
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = True
        btnModificar.Enabled = True
        btnSalir.Enabled = True
    End Sub
    Sub llenar_grilla()
        With Me.dgvCurso
            .DataSource = objCurso_Curso.listar_cursos_cursos()
            .Columns(0).HeaderText = "Codigo Curso"
            .Columns(0).Width = 40
            .Columns(1).Width = 300
            .Columns(1).HeaderText = "Curso"
            .Columns(2).HeaderText = "Ciclo"
            .Columns(2).Width = 40
            .Columns(3).HeaderText = "Codigo Pre-requisito"
            .Columns(4).Width = 300
            .Columns(4).HeaderText = "Curso Pre-requisito"
            .Columns(4).HeaderText = "Ciclo Previo"
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
    End Sub

    Public Sub llenarCbxCurso()
        Try
            cbxCurso.DataSource = objCurso_Curso.listar_cursos_cursos_1(cbxC1.SelectedItem)
            cbxCurso.DisplayMember = "nombre_curso"
            cbxCurso.ValueMember = "codigo_curso"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub llenarCbxPre()
        Try
            cbxPre.DataSource = objCurso_Curso.listar_cursos_cursos_2(cbxC1.SelectedItem)
            cbxPre.DisplayMember = "nombre_prerrequisito"
            cbxPre.ValueMember = "codigo_curso_curso"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub confInicio()
        cbxCurso.Enabled = False
        cbxPre.Enabled = False
        btnNuevo.Enabled = True
        btnGrabar.Enabled = False
        btnCancelar.Enabled = False
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
        llenar_grilla()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub cbxC1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxC1.SelectedIndexChanged
        llenarCbxCurso()
        llenarCbxPre()
    End Sub

    Private Sub cbxPre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPre.SelectedIndexChanged

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        confInicio()
    End Sub
End Class