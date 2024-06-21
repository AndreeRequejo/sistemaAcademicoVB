Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class ADO_Horario
    Private objConexion As New clsConexionSQL

    Public Function pa_agregar_horario(ByVal dia As String, ByVal h_inicio As String, ByVal h_final As String, ByVal ambiente_id As Integer, ByVal grupo_id As Integer) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_insert_horario"

        objComando.Parameters.Add("@dia", SqlDbType.VarChar, 50).Value = dia
        objComando.Parameters.Add("@h_inicio", SqlDbType.VarChar, 50).Value = h_inicio
        objComando.Parameters.Add("@h_final", SqlDbType.VarChar, 50).Value = h_final
        objComando.Parameters.Add("@ambiente_id", SqlDbType.Int).Value = ambiente_id
        objComando.Parameters.Add("@grupo_id", SqlDbType.Int).Value = grupo_id
        objComando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output

        Try
            objComando.Connection = objConexion.getConexion
            objConexion.abrirConexion()
            objComando.ExecuteNonQuery()
            Dim retorno As Integer = Convert.ToInt32(objComando.Parameters("@retorno").Value)
            objConexion.cerrarConexion()
            MessageBox.Show(retorno.ToString(), "Resultado de la Operación")
            Return retorno
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud: " & ex.Message, "ADO")
            Return -1
        End Try
    End Function

    Public Function pa_modificarHorario(ByVal horario_id As Integer, ByVal dia As String, ByVal h_inicio As String, ByVal h_final As String, ByVal ambiente_id As Integer, ByVal grupo_id As String) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_update_horario"

        objComando.Parameters.Add("@cod", SqlDbType.Int).Value = horario_id
        objComando.Parameters.Add("@dia", SqlDbType.VarChar, 50).Value = dia
        objComando.Parameters.Add("@h_inicio", SqlDbType.VarChar, 50).Value = h_inicio
        objComando.Parameters.Add("@h_final", SqlDbType.VarChar, 50).Value = h_final
        objComando.Parameters.Add("@ambiente_id", SqlDbType.Int).Value = ambiente_id
        objComando.Parameters.Add("@grupo_id", SqlDbType.Int).Value = grupo_id
        objComando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output

        Try
            objComando.Connection = objConexion.getConexion()
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

    Public Function pa_eliminarHorario(ByVal horario_id As Integer) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_delete_horario"

        objComando.Parameters.Add("@cod", SqlDbType.Int).Value = horario_id
        objComando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output

        Try
            objComando.Connection = objConexion.getConexion()
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

End Class
