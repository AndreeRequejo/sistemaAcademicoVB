Imports System.Windows.Forms
Imports Proyecto_Datos
Public Class Curso_Curso
    Private objConexion As New clsConexionSQL
    Private objCurso_Curso As New ADO_Curso_Curso

    Public Function listar_cursos_cursos() As DataTable
        Dim sql As String
        sql = "SELECT c.curso_id As codigo_curso,
    c.nombre_curso AS nombre_curso,
	c.ciclo As ciclo,
	p.curso_id As codigo_curso_curso,
    p.nombre_curso AS nombre_prerrequisito,
    p.ciclo As ciclo_pre
FROM curso_curso cc
JOIN
    curso c ON cc.curso_id = c.curso_id
JOIN
    curso p ON cc.curso_id_pre = p.curso_id
order by c.ciclo;"
        Return objConexion.consultaSQL(sql)
    End Function
    Public Function listar_cursos_cursos_1(ByVal ciclo As Integer) As DataTable
        Dim sql As String
        sql = "SELECT DISTINCT curso_id As codigo_curso,
    nombre_curso AS nombre_curso
FROM
    curso
where ciclo = " & ciclo & ";"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function listar_cursos_cursos_2(ByVal ciclo As Integer) As DataTable
        Dim sql As String
        sql = "SELECT DISTINCT curso_id As codigo_curso_curso,
    nombre_curso AS nombre_prerrequisito,
ciclo
FROM
    curso
where ciclo < " & ciclo & "
order by ciclo;"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function listar_cursos_cursos_3(ByVal id As Integer, ByVal id_pre As Integer) As DataTable
        Dim sql As String
        sql = "SELECT c.curso_id As codigo_curso,
    c.nombre_curso AS nombre_curso,
	c.ciclo As ciclo,
	p.curso_id As codigo_curso_curso,
    p.nombre_curso AS nombre_prerrequisito,
    p.ciclo As ciclo_pre
FROM curso_curso cc
JOIN
    curso c ON cc.curso_id = c.curso_id
JOIN
    curso p ON cc.curso_id_pre = p.curso_id

where c.curso_id = " & id & " and cc.curso_id_pre = " & id_pre & ";"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function agregar_curso_curso(ByVal id As Integer, ByVal id_pre As Integer) As Integer
        Try
            Return objCurso_Curso.pa_agregar_curso_curso(id, id_pre)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function modificar_curso_curso(ByVal id As Integer, ByVal id_pre As Integer, ByVal id_pre_1 As Integer) As Integer
        Try
            Return objCurso_Curso.pa_modificar_curso_curso(id, id_pre, id_pre_1)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function eliminar_curso_curso(ByVal id As Integer, ByVal id_pre As Integer) As Integer
        Try
            Return objCurso_Curso.pa_eliminar_curso_curso(id, id_pre)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function
End Class
