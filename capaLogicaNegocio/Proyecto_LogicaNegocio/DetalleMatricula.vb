Imports Proyecto_Datos
Imports System.Windows.Forms

Public Class DetalleMatricula
    Private objConexion As New clsConexionSQL
    Private objDetalle As New ADO_DetalleMatricula
    Public Function listar_detalle_matricula() As DataTable
        Dim sql As String
        sql = "select matricula_id,grupo_id,estado,nota_promedio from detalle_matricula"
        Return objConexion.consultaSQL(sql)
    End Function


    Public Function agregar_detalle_matricula(ByVal matricula_id As Integer, ByVal grupo_id As Integer, ByVal estado As String, ByVal nota_promedio As Double) As Integer
        Try
            Return objDetalle.pa_agregar_detalle_matricula(matricula_id, grupo_id, estado, nota_promedio)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message, "Clase")
            Return -1
        End Try
    End Function

    Public Function modificar_detalle_matricula(ByVal matricula_id As Integer, ByVal grupo_id As Integer, ByVal estado As String, ByVal nota_promedio As Double) As Integer
        Try
            Return objDetalle.pa_modificar_detalle_metricula(matricula_id, grupo_id, estado, nota_promedio)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function eliminar_detalle_matricula(ByVal matricula_id As Integer, ByVal grupo_id As Integer) As Integer
        Try
            Return objDetalle.pa_eliminar_detalle_matricula(matricula_id, grupo_id)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

End Class