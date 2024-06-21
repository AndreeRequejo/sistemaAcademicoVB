Imports System.Data.SqlClient

Public Class ADO_Escuela
    Private objConexion As New clsConexionSQL
    Public Function pa_agregar_escuela(ByVal idEsc As Integer, ByVal nomEsc As String, ByVal idFac As Integer) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_insert_escuela"
        objComando.Parameters.Add("@idEsc", SqlDbType.Int, 0).Value = idEsc
        objComando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nomEsc
        objComando.Parameters.Add("@idFac", SqlDbType.Int, 0).Value = idFac
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
    Public Function pa_modificar_escuela(ByVal idEsc As Integer, ByVal nomEsc As String, ByVal idFac As Integer) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_update_escuela"
        objComando.Parameters.Add("@idEsc", SqlDbType.Int, 0).Value = idEsc
        objComando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nomEsc
        objComando.Parameters.Add("@idFac", SqlDbType.Int, 0).Value = idFac
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

    Public Function pa_eliminar_escuela(ByVal idEsc As Integer) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_delete_escuela"
        objComando.Parameters.Add("@idEsc", SqlDbType.Int, 0).Value = idEsc
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
End Class
