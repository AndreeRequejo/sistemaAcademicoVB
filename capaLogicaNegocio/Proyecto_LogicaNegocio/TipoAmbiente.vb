Imports Proyecto_Datos

Public Class TipoAmbiente
    Private objConexion As New clsConexionSQL
    Private objTipoAmbiente As New ADO_TipoAmbiente

    Public Function listar_tipoAmbientes() As DataTable
        Dim sql As String
        sql = "select descripcion_tipoambiente, abreviatura, vigencia from tipo_ambiente"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function buscarIdTipoAmb(ByVal nomTipoAmb As String) As Integer
        Dim idTipoAmb As Integer = 0
        Try
            Dim sql As String
            sql = "select tipoambiente_id from tipo_ambiente where descripcion_tipoambiente = '" & nomTipoAmb & "'"
            Dim result As DataTable = objConexion.consultaSQL(sql)

            If result.Rows.Count > 0 Then
                idTipoAmb = Convert.ToInt32(result.Rows(0)(0))
            End If
            Return idTipoAmb
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function agregar_tipoAmbiente(ByVal tipoAmb As String, ByVal abrev As String) As Integer
        Try
            Return objTipoAmbiente.pa_agregar_tipoAmbiente(tipoAmb, abrev)
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function modificar_tipoAmbiente(ByVal idTipoAmb As Integer, ByVal tipoAmb As String, ByVal abrev As String, ByVal vigencia As Integer) As Integer
        Dim r As Integer
        Try
            r = objTipoAmbiente.pa_modificar_tipoAmbiente(idTipoAmb, tipoAmb, abrev, vigencia)
            Return r
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function eliminar_tipoAmbiente(ByVal idTipoAmb As Integer) As Integer
        Try
            Return objTipoAmbiente.pa_eliminar_tipoAmbiente(idTipoAmb)
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

End Class
