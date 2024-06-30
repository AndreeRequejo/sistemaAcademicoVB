Imports System.Windows.Forms
Imports Proyecto_Datos

Public Class Alumno
    Private objConexion As New clsConexionSQL
    Private objAlumno As New ADO_Alumno
    Public Function listar_alumnos() As DataTable
        Dim sql As String
        sql = " select	td.descripcion, numero_documento, ape_paterno, ape_materno, nombres,
		                CASE sexo WHEN 1 THEN 'MASCULINO' ELSE 'FEMENINO'END as sexo,
		                f_nacimiento ,f_registro, direccion_residencia,ubigeo_id, ea.descripcion, es.nombre_escuela,
		                 semestre_ingreso, semestre_egreso
                from alumno a 
                inner join tipo_documento td on td.tipo_documento_id = a.tipo_documento
                inner join estado_alumno ea on ea.estado_alumno_id = a.estado_alumno
                inner join escuela es on es.escuela_id = a.escuela_id;"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function agregar_alumno(ByVal tipoDoc As Integer, ByVal numDoc As String, ByVal apePat As String, ByVal apeMat As String, ByVal nom As String,
                                   ByVal sexo As Boolean, ByVal fNac As Date, ByVal direc As String, ByVal estado As String, ByVal escuela As Integer,
                                    ByVal ubigeo As Integer, ByVal semIng As String) As Integer
        Try
            Return objAlumno.pa_agregar_alumno(tipoDoc, numDoc, apePat, apeMat, nom, sexo, fNac, direc, estado, escuela, ubigeo, semIng)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message, "Clase")
            Return -1
        End Try
    End Function

    Public Function modificar_alumno(ByVal idAlu As Integer, ByVal tipoDoc As Integer, ByVal numDoc As String, ByVal apePat As String, ByVal apeMat As String, ByVal nom As String,
                                   ByVal sexo As Integer, ByVal fNac As Date, ByVal direc As String, ByVal estado As String, ByVal escuela As Integer,
                                    ByVal ubigeo As Integer, ByVal semIng As String, ByVal semEg As String) As Integer
        Try
            Return objAlumno.pa_modificar_alumno(idAlu, tipoDoc, numDoc, apePat, apeMat, nom, sexo, fNac, direc, estado, escuela, ubigeo, semIng, semEg)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function eliminar_alumno(ByVal idAlu As String) As Integer
        Try
            Return objAlumno.pa_eliminar_alumno(idAlu)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function buscarIdAlumno(ByVal dniAlumno As String) As Integer
        Dim idAlumno As Integer = 0
        Try
            Dim sql As String
            sql = "select alumno_id from alumno where numero_documento = '" & dniAlumno & "'"
            Dim result As DataTable = objConexion.consultaSQL(sql)

            If result.Rows.Count > 0 Then
                idAlumno = Convert.ToInt32(result.Rows(0)(0))
            End If
            Return idAlumno
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function buscarNomAlumno(ByVal dniAlumno As String) As String
        Dim nomAlumno As String = ""
        Try
            Dim sql As String
            sql = "select ape_paterno + ' ' + ape_materno + ' ' + nombres AS nombre_completo from alumno where numero_documento = '" & dniAlumno & "'"
            Dim result As DataTable = objConexion.consultaSQL(sql)

            If result.Rows.Count > 0 Then
                nomAlumno = result.Rows(0)(0)
            End If
            Return nomAlumno
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

End Class
