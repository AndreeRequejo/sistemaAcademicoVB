Imports System.Data.SqlClient

Public Class ADO_Facultad
    Private objConexion As New clsConexionSQL


    Public Function pa_agregar_facultad(ByVal idFac As Integer, ByVal nomFac As String) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_insert_facultad"
        objComando.Parameters.Add("@idFac", SqlDbType.Int, 0).Value = idFac
        objComando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nomFac
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
    Public Function pa_modificar_facultad(ByVal idFac As Integer, ByVal nomFac As String) As Integer
        Dim objComando As New SqlCommand()
        Dim retorno As Integer
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_update_facultad"
        objComando.Parameters.Add("@idFac", SqlDbType.Int, 0).Value = idFac
        objComando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nomFac
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

    Public Function pa_eliminar_facultad(ByVal idFac As Integer) As Integer
        Dim objComando As New SqlCommand()
        Dim retorno As Integer
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_delete_facultad"
        objComando.Parameters.Add("@idFac", SqlDbType.Int, 0).Value = idFac
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
