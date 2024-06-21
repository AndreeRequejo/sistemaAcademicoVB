Imports System.Data.SqlClient

Public Class ADO_PlanEstudio
    Private objConexion As New clsConexionSQL

    Public Function pa_agregar_planEstudio(ByVal idPlan As Integer, ByVal desc As String, ByVal estado As Boolean) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_insert_planEstudio"
        objComando.Parameters.Add("@idPlan", SqlDbType.Int, 0).Value = idPlan
        objComando.Parameters.Add("@desc", SqlDbType.VarChar, 150).Value = desc
        If estado Then
            objComando.Parameters.Add("@est", SqlDbType.Bit).Value = 1
        Else
            objComando.Parameters.Add("@est", SqlDbType.Bit).Value = 0
        End If
        objComando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output

        Try
            objComando.Connection = objConexion.getConexion
            objConexion.abrirConexion()
            objComando.ExecuteNonQuery()
            Dim retorno As Integer = Convert.ToInt32(objComando.Parameters("@retorno").Value)
            objConexion.cerrarConexion()
            Return retorno
        Catch ex As Exception

        End Try
    End Function

    Public Function pa_modificar_planEstudio(ByVal idPlan As Integer, ByVal desc As String, ByVal estado As Boolean) As Integer
        Dim objComando As New SqlCommand()
        Dim retorno As Integer
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_update_planEstudio"
        objComando.Parameters.Add("@idPlan", SqlDbType.Int, 0).Value = idPlan
        objComando.Parameters.Add("@desc", SqlDbType.VarChar, 150).Value = desc
        objComando.Parameters.Add("@est", SqlDbType.Bit).Value = estado
        objComando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output

        Try
            objComando.Connection = objConexion.getConexion
            objConexion.abrirConexion()
            objComando.ExecuteNonQuery()
            retorno = Convert.ToInt32(objComando.Parameters("@retorno").Value)
            objConexion.cerrarConexion()
            Return retorno
        Catch ex As Exception
            Return retorno
        End Try
    End Function

    Public Function pa_eliminar_planEstudio(ByVal idPlan As Integer) As Integer
        Dim objComando As New SqlCommand()
        Dim retorno As Integer
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_delete_planEstudio"
        objComando.Parameters.Add("@idPlan", SqlDbType.Int, 0).Value = idPlan
        objComando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output

        Try
            objComando.Connection = objConexion.getConexion
            objConexion.abrirConexion()
            objComando.ExecuteNonQuery()
            retorno = Convert.ToInt32(objComando.Parameters("@retorno").Value)
            objConexion.cerrarConexion()
            Return retorno
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

End Class
