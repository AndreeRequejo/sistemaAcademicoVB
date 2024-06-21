Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class ADO_Semestre
    Private objConexion As New clsConexionSQL
    Public Function pa_agregar_semestre(ByVal codSem As String, ByVal fIni As Date, ByVal fFin As Date, ByVal estado As Boolean) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_insert_semestre"
        objComando.Parameters.Add("@codSem", SqlDbType.Char, 6).Value = codSem
        objComando.Parameters.Add("@fIni", SqlDbType.Date).Value = fIni
        objComando.Parameters.Add("@fFin", SqlDbType.Date).Value = fFin
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
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function pa_modificar_semestre(ByVal codSem As String, ByVal fIni As Date, ByVal fFin As Date, ByVal estado As Boolean) As Integer
        Dim objComando As New SqlCommand()
        Dim retorno As Integer
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_update_semestre"
        objComando.Parameters.Add("@codSem", SqlDbType.Char, 6).Value = codSem
        objComando.Parameters.Add("@fIni", SqlDbType.Date).Value = fIni
        objComando.Parameters.Add("@fFin", SqlDbType.Date).Value = fFin
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
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function pa_eliminar_semestre(ByVal codSem As String) As Integer
        Dim objComando As New SqlCommand()
        Dim retorno As Integer
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_delete_semestre"
        objComando.Parameters.Add("@codSem", SqlDbType.Char, 6).Value = codSem
        objComando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output

        Try
            objComando.Connection = objConexion.getConexion
            objConexion.abrirConexion()
            objComando.ExecuteNonQuery()
            retorno = Convert.ToInt32(objComando.Parameters("@retorno").Value)
            objConexion.cerrarConexion()
            Return retorno
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

End Class
