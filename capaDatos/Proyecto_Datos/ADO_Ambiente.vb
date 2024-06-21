Imports System.Data.SqlClient
Imports System.Security.Cryptography
Public Class ADO_Ambiente
    Private objConexion As New clsConexionSQL
    Public Function pa_agregar_ambiente(ByVal tp_amb As Integer, ByVal desc As String, ByVal cap As Integer, ByVal estado As String) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_insert_ambiente"
        objComando.Parameters.Add("@tp_amb", SqlDbType.Int, 0).Value = tp_amb
        objComando.Parameters.Add("@desc", SqlDbType.VarChar, 100).Value = desc
        objComando.Parameters.Add("@cap", SqlDbType.Int, 0).Value = cap
        objComando.Parameters.Add("@estado", SqlDbType.VarChar, 30).Value = estado
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
    Public Function pa_modificar_ambiente(ByVal idAmb As Integer, ByVal tp_amb As Integer, ByVal desc As String, ByVal cap As Integer, ByVal estado As String) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_update_ambiente"
        objComando.Parameters.Add("@idAmb", SqlDbType.Int).Value = idAmb
        objComando.Parameters.Add("@tp_amb", SqlDbType.Int).Value = tp_amb
        objComando.Parameters.Add("@desc", SqlDbType.VarChar, 100).Value = desc
        objComando.Parameters.Add("@cap", SqlDbType.Int).Value = cap
        objComando.Parameters.Add("@estado", SqlDbType.VarChar, 30).Value = estado
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

    Public Function pa_eliminar_ambiente(ByVal idAmb As Integer) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_delete_ambiente"
        objComando.Parameters.Add("@idAmb", SqlDbType.Int, 0).Value = idAmb
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
