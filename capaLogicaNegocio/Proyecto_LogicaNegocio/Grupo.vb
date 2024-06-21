Imports System.Windows.Forms
Imports Proyecto_Datos

Public Class Grupo
    Private objConexion As New clsConexionSQL
    Private objGrupo As New ADO_Grupo

    Public Function listar_grupos() As DataTable
        Dim sql As String
        sql = "SELECT grupo_id, denominacion, numero_vacantes, estado_grupo, nombre_curso, 
               nombres+ ' ' +ape_paterno+ ' ' +ape_materno as nombre_docente, semestre_id 
               FROM grupo g
               INNER JOIN curso c ON c.curso_id = g.curso_id
               INNER JOIN docente d ON d.docente_id = g.docente_id
               ORDER BY semestre_id DESC"
        Return objConexion.consultaSQL(sql)
    End Function


    Public Function agregar_grupo(ByVal denominacion As String, ByVal numero_vacantes As Integer, ByVal estado_grupo As Integer, ByVal curso_id As Integer, ByVal docente_id As Integer, ByVal semestre_id As String) As Integer
        Try
            Return objGrupo.pa_insertarGrupo(denominacion, numero_vacantes, estado_grupo, curso_id, docente_id, semestre_id)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message, "Clase")
            Return -1
        End Try
    End Function

    Public Function modificar_grupo(ByVal grupo_id As Integer, ByVal denominacion As String, ByVal numero_vacantes As Integer, ByVal estado_grupo As Integer, ByVal curso_id As Integer, ByVal docente_id As Integer, ByVal semestre_id As String) As Integer
        Try
            Return objGrupo.pa_modificarGrupo(grupo_id, denominacion, numero_vacantes, estado_grupo, curso_id, docente_id, semestre_id)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message, "Clase")
            Return -1
        End Try
    End Function

    Public Function eliminar_grupo(ByVal grupo_id As Integer) As Integer
        Try
            Return objGrupo.pa_eliminarGrupo(grupo_id)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message, "Clase")
            Return -1
        End Try
    End Function

End Class
