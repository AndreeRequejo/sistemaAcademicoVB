Imports System.Windows.Forms
Imports Proyecto_Datos
Public Class Docente
    Private objConexion As New clsConexionSQL
    Private objDocente As New ADO_Docente
    Public Function listar_docentes() As DataTable
        Dim sql As String
        sql = "select	docente_id,td.descripcion, numero_documento_docente, ape_paterno, ape_materno, nombres,
						a.tipo_docente, a.ultimo_grado_academico,fecha_registro,
                        CASE a.estado_docente WHEN 1 THEN 'Vigente' ELSE 'No Vigente' END AS estado,
		                ubigeo_id
                from docente a 
                inner join tipo_documento td on td.tipo_documento_id = a.tipo_documento
				inner join tipo_docente tdoce on a.tipo_docente = tdoce.tipo_docente_id
				inner join grado_academico gac on a.ultimo_grado_academico = gac.grado_academico_id"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function listar_docentesNombre() As DataTable
        Dim sql As String
        sql = "select docente_id,
                nombres + ' ' + ape_paterno + ' ' + ape_materno as nombre_docente
                from docente"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function buscarIdDocente(ByVal docDoc As String) As Integer
        Dim idFacultad As Integer = 0
        Try
            Dim sql As String
            sql = "select docente_id from docente where numero_documento_docente = '" & docDoc & "'"
            Dim result As DataTable = objConexion.consultaSQL(sql)

            If result.Rows.Count > 0 Then
                idFacultad = Convert.ToInt32(result.Rows(0)(0))
            End If
            Return idFacultad
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Function obtener_idDocente(ByVal nombreDocente As String) As Integer
        Dim idDocente As Integer = 0
        Dim sql As String
        sql = "SELECT docente_id 
        FROM docente
        WHERE nombres + ' ' + ape_paterno + ' ' + ape_materno = '" & nombreDocente & "';"
        Dim result As DataTable = objConexion.consultaSQL(sql)
        If result.Rows.Count > 0 Then
            idDocente = result.Rows(0)("docente_id").ToString
        End If
        Return idDocente
    End Function

    Public Function agregar_docente(ByVal tipoCod As String, ByVal numDoc As String, ByVal tipDoc As String, ByVal apePat As String,
                                    ByVal apeMat As String, ByVal nom As String, ByVal grado As String, ByVal estado As Boolean,
                                    ByVal ubigeo As String) As Integer
        Try
            Return objDocente.pa_agregar_docente(tipoCod, numDoc, tipDoc, apePat, apeMat, nom, grado, estado, ubigeo)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message, "Clase")
            Return -1
        End Try
    End Function

    Public Function modificar_docente(ByVal idDoc As Integer, ByVal tipoCod As String, ByVal numDoc As String, ByVal tipDoc As String, ByVal apePat As String,
                                    ByVal apeMat As String, ByVal nom As String, ByVal grado As String, ByVal estado As Boolean,
                                    ByVal ubigeo As String) As Integer
        Try
            Return objDocente.pa_modificar_docente(idDoc, tipoCod, numDoc, tipDoc, apePat, apeMat, nom, grado, estado, ubigeo)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function eliminar_docente(ByVal codCur As String) As Integer
        Try
            Return objDocente.pa_eliminar_docente(codCur)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

End Class
