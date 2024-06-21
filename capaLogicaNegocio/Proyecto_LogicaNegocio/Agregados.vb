Imports System.Windows.Forms
Imports Proyecto_Datos

Public Class Agregados
    Private objConexion As New clsConexionSQL
    Public Function listar_ciclos_escuela(ByVal ID As Integer) As DataTable
        Dim sql As String
        sql = " select numero_ciclo, escuela_id
                from ciclo
                where escuela_id = " & ID
        Return objConexion.consultaSQL(sql)
    End Function
    Public Function listar_tipo_documento() As DataTable
        Dim sql As String
        sql = "select tipo_documento_id,descripcion from tipo_documento"
        Return objConexion.consultaSQL(sql)
    End Function
    Public Function listar_tipo_docente() As DataTable
        Dim sql As String
        sql = "select tipo_docente_id, descripcion from tipo_docente"
        Return objConexion.consultaSQL(sql)
    End Function
    Public Function listar_grado_academico() As DataTable
        Dim sql As String
        sql = "select grado_academico_id,descripcion from grado_academico"
        Return objConexion.consultaSQL(sql)
    End Function
    Public Function listar_estado_alumno() As DataTable
        Dim sql As String
        sql = "select estado_alumno_id,descripcion from estado_alumno"
        Return objConexion.consultaSQL(sql)
    End Function
    Public Function buscarIdGrado(ByVal desc As String) As String
        Dim idFacultad As String = 0
        Try
            Dim sql As String
            sql = "select grado_academico_id from grado_academico where descripcion = '" & desc & "'"
            Dim result As DataTable = objConexion.consultaSQL(sql)

            If result.Rows.Count > 0 Then
                idFacultad = Convert.ToChar(result.Rows(0)(0))
            End If
            Return idFacultad
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function
    Public Function buscarIdTipoDocumento(ByVal tipo As String) As String
        Dim idFacultad As String = 0
        Try
            Dim sql As String
            sql = "select tipo_documento_id from tipo_documento where descripcion = '" & tipo & "'"
            Dim result As DataTable = objConexion.consultaSQL(sql)

            If result.Rows.Count > 0 Then
                idFacultad = Convert.ToChar(result.Rows(0)(0))
            End If
            Return idFacultad
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function
    Public Function buscarIdEstado(ByVal estado As String) As String
        Dim idFacultad As String = 0
        Try
            Dim sql As String
            sql = "select estado_alumno_id from estado_alumno where descripcion = '" & estado & "'"
            Dim result As DataTable = objConexion.consultaSQL(sql)

            If result.Rows.Count > 0 Then
                idFacultad = Convert.ToChar(result.Rows(0)(0))
            End If
            Return idFacultad
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function
End Class
