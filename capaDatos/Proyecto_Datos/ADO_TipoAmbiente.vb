Imports System.Data.SqlClient

Public Class ADO_TipoAmbiente
    Private objConexion As New clsConexionSQL

    Public Function pa_agregar_tipoAmbiente(ByVal tipoAmb As String, ByVal abrev As String) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_insert_tipoambiente"
        objComando.Parameters.Add("@tipoambiente", SqlDbType.VarChar, 100).Value = tipoAmb
        objComando.Parameters.Add("@abrev", SqlDbType.Char, 10).Value = abrev
        objComando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output

        Try
            objComando.Connection = objConexion.getConexion
            objConexion.abrirConexion()
            objComando.ExecuteNonQuery()
            Dim retorno As Integer = Convert.ToInt32(objComando.Parameters("@retorno").Value)
            objConexion.cerrarConexion()
            Return retorno
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function pa_modificar_tipoAmbiente(ByVal idAmb As String, ByVal tipoAmb As String, ByVal abrev As String, ByVal vigencia As Integer) As Integer
        Dim objComando As New SqlCommand()
        Dim retorno As Integer
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_modificar_tipoambiente"
        objComando.Parameters.Add("@id", SqlDbType.Int, 0).Value = idAmb
        objComando.Parameters.Add("@tipoambiente", SqlDbType.VarChar, 100).Value = tipoAmb
        objComando.Parameters.Add("@abrev", SqlDbType.Char, 10).Value = abrev
        objComando.Parameters.Add("@vigenc", SqlDbType.Bit).Value = vigencia
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

    Public Function pa_eliminar_tipoAmbiente(ByVal idAmb As Integer) As Integer
        Dim objComando As New SqlCommand()
        Dim retorno As Integer
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_eliminar_tipoambiente"
        objComando.Parameters.Add("@id", SqlDbType.Int, 0).Value = idAmb
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

    'Chisqui x Marlon'

End Class
