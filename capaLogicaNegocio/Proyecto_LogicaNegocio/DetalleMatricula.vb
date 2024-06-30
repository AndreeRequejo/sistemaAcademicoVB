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

    Public Function obtenerDetalleMatricula(ByVal idMatricula As Integer) As DataTable
        Dim sql As String
        sql = "SELECT DM.matricula_id, DM.grupo_id, CU.nombre_curso + ' - ' + GR.denominacion as curso, nota_promedio
                FROM detalle_matricula DM
                INNER JOIN matricula MA ON MA.matricula_id = DM.matricula_id
                INNER JOIN grupo GR ON GR.grupo_id = DM.grupo_id
                INNER JOIN curso CU ON CU.curso_id = GR.curso_id
                WHERE MA.matricula_id = " & idMatricula
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function agregar_detalle_matricula(ByVal matricula_id As Integer, ByVal grupo_id As Integer) As Integer
        Try
            Return objDetalle.pa_agregar_detalle_matricula(matricula_id, grupo_id)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message, "Clase")
            Return -1
        End Try
    End Function

    Public Function modificar_detalle_matricula(ByVal matricula_id As Integer, ByVal grupo_id As Integer, ByVal nota_promedio As Double) As Integer
        Try
            Return objDetalle.pa_modificar_detalle_metricula(matricula_id, grupo_id, nota_promedio)
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