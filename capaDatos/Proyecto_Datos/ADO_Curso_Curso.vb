Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Windows.Forms
Public Class ADO_Curso_Curso
    Private objConexion As New clsConexionSQL
    Public Function pa_agregar_curso_curso(ByVal id As Integer, ByVal id_pre As Integer) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_insert_curso_curso"
        objComando.Parameters.Add("@id", SqlDbType.Int).Value = id
        objComando.Parameters.Add("@id_pre", SqlDbType.Int).Value = id_pre
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

    Public Function pa_modificar_curso_curso(ByVal id As Integer, ByVal id_pre As Integer, ByVal id_pre_1 As Integer) As Integer
        Dim objComando As New SqlCommand()
        Dim retorno As Integer
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_modificar_curso_curso"
        objComando.Parameters.Add("@id", SqlDbType.Int).Value = id
        objComando.Parameters.Add("@id_pre", SqlDbType.Int).Value = id_pre
        objComando.Parameters.Add("@id_pre_1", SqlDbType.Int).Value = id_pre_1
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

    Public Function pa_eliminar_curso_curso(ByVal id As Integer, ByVal id_pre As Integer) As Integer
        Dim objComando As New SqlCommand()
        Dim retorno As Integer
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_eliminar_curso_curso"
        objComando.Parameters.Add("@id", SqlDbType.Int).Value = id
        objComando.Parameters.Add("@id_pre", SqlDbType.Int).Value = id_pre
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
