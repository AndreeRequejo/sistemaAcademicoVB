Imports System.Windows.Forms
Imports Proyecto_Datos

Public Class Semestre
    Private objConexion As New clsConexionSQL
    Private objSemestre As New ADO_Semestre
    Public Function listar_semestres() As DataTable
        Try
            Dim sql As String
            sql = " SELECT codigo_semestre, f_inicio, f_culminacion, 
                    CASE estado_semestre WHEN 1 THEN 'Vigente' ELSE 'No Vigente' END AS estado 
                    FROM semestre
                    ORDER BY estado_semestre DESC"
            Return objConexion.consultaSQL(sql)
        Catch ex As Exception

        End Try
    End Function

    Public Function agregar_semestre(ByVal codSem As String, ByVal fIni As Date, ByVal fFin As Date, ByVal estado As Boolean) As Integer
        Try
            Return objSemestre.pa_agregar_semestre(codSem, fIni, fFin, estado)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function modificar_semestre(ByVal codSem As String, ByVal fIni As Date, ByVal fFin As Date, ByVal estado As Boolean) As Integer
        Dim r As Integer
        Try
            r = objSemestre.pa_modificar_semestre(codSem, fIni, fFin, estado)
            Return r
        Catch ex As Exception
            Return r
        End Try
    End Function

    Public Function eliminar_semestre(ByVal codSem As String) As Integer
        Dim r As Integer
        Try
            r = objSemestre.pa_eliminar_semestre(codSem)
            Return r
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function mostrar_semestre_actual() As String
        Dim sql As String
        sql = "select codigo_semestre from semestre where estado_semestre = 1 order by codigo_semestre desc"
        Dim dt As DataTable = objConexion.consultaSQL(sql)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)("codigo_semestre").ToString()
        Else
            Return String.Empty
        End If
    End Function
End Class
