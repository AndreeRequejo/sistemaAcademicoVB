Imports System.Windows.Forms
Imports Proyecto_Datos
Public Class Curso
    Private objConexion As New clsConexionSQL
    Private objCurso As New ADO_Curso
    Public Function listar_cursos() As DataTable
        Dim sql As String
        sql = " select curso_id, codigo_curso,nombre_curso,creditos,h_teoria,h_practica,ciclo,
                CASE tipo_curso WHEN 1 THEN 'Obligatorio' ELSE 'Electivo' END AS tipo_curso
                ,plan_id,nombre_escuela 
                from curso c
                inner join escuela e on c.escuela_id = e.escuela_id
                order by ciclo;"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function listar_semestre() As DataTable
        Dim sql As String
        sql = " select * from semestre order by codigo_semestre desc;"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function listar_cursos_ciclo(ByVal cic As Integer) As DataTable
        Dim sql As String
        sql = " select nombre_curso,curso_id from curso c where ciclo=" & cic & ";"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function listar_grupo(ByVal cur As Integer, ByVal sem As String) As DataTable
        Dim sql As String
        sql = " select g.denominacion, g.grupo_id, (d.nombres +' ' + d.ape_paterno +' ' +d.ape_materno) as docente, d.docente_id 
                from grupo g inner join docente d on d.docente_id=g.docente_id 
                where curso_id=" & cur & " and semestre_id='" & sem & "';"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function listar_docente(ByVal cur As Integer, ByVal sem As String) As String
        Dim idDocente As String = String.Empty
        Try
            Dim sql As String
            sql = " select (d.nombres + ' ' + d.ape_paterno + ' ' +d.ape_materno) as docente from grupo g 
                inner join docente d on d.docente_id=g.docente_id 
                where curso_id=" & cur & " and semestre_id='" & sem & "';"
            Dim result As DataTable = objConexion.consultaSQL(sql)

            If result.Rows.Count > 0 Then
                idDocente = result.Rows(0)("docente").ToString
            End If
            Return idDocente
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function


    Public Function listar_tipo_cursos() As DataTable
        Dim sql As String
        sql = " select 
                CASE tipo_curso WHEN 1 THEN 'Obligatorio' ELSE 'Electivo' END AS tipo_curso
                from curso;"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function agregar_curso(ByVal codCur As String, ByVal nomCur As String, ByVal hT As Integer, ByVal hP As Integer, ByVal ci As Integer, ByVal tipCur As Boolean, ByVal planId As Integer, ByVal escId As Integer) As Integer
        Try
            Return objCurso.pa_agregar_curso(codCur, nomCur, hT, hP, ci, tipCur, planId, escId)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function modificar_curso(ByVal codCur As String, ByVal nomCur As String, ByVal hT As Integer, ByVal hP As Integer, ByVal ci As Integer, ByVal tipCur As Boolean, ByVal planId As Integer, ByVal escId As Integer) As Integer
        Try
            Return objCurso.pa_modificar_curso(codCur, nomCur, hT, hP, ci, tipCur, planId, escId)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function eliminar_curso(ByVal codCur As String) As Integer
        Try
            Return objCurso.pa_eliminar_curso(codCur)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function obtener_idCurso(ByVal nombreCurso As String) As Integer
        Dim idCurso As Integer = 0
        Dim sql As String
        sql = "SELECT curso_id 
                FROM curso
                WHERE nombre_curso = '" & nombreCurso & "';"
        Dim result As DataTable = objConexion.consultaSQL(sql)
        If result.Rows.Count > 0 Then
            idCurso = result.Rows(0)("curso_id").ToString
        Else
            idCurso = -1
        End If
        Return idCurso
    End Function

End Class
