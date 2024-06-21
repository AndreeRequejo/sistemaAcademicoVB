Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class ADO_Ubigeo
    Private objConexion As New clsConexionSQL

    Public Function agregar_ubigeo(ByVal ubigeo_id As String, ByVal distrito As String, ByVal provincia As String, ByVal departamento As String) As Integer
        Dim obj_Comando As New SqlCommand()
        obj_Comando.CommandType = CommandType.StoredProcedure
        obj_Comando.CommandText = "pa_insert_ubigeo"
        obj_Comando.Parameters.Add("@ubigeo_id", SqlDbType.Char, 6).Value = ubigeo_id
        obj_Comando.Parameters.Add("@distrito", SqlDbType.VarChar, 100).Value = distrito
        obj_Comando.Parameters.Add("@provincia", SqlDbType.VarChar, 100).Value = provincia
        obj_Comando.Parameters.Add("@departamento", SqlDbType.VarChar, 100).Value = departamento

        obj_Comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output
        Try
            obj_Comando.Connection = objConexion.getConexion
            objConexion.abrirConexion()
            obj_Comando.ExecuteNonQuery()
            Dim retorno As Integer = obj_Comando.Parameters.Item("@retorno").Value
            objConexion.cerrarConexion()
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message, "ADO")
            Return -1
        End Try
    End Function

    Public Function modificar_ubigeo(ByVal ubigeo_id As String, ByVal distrito As String, ByVal provincia As String, ByVal departamento As String) As Integer
        Dim obj_Comando As New SqlCommand()
        obj_Comando.CommandType = CommandType.StoredProcedure
        obj_Comando.CommandText = "pa_update_ubigeo"
        obj_Comando.Parameters.Add("@ubigeo_id", SqlDbType.Char, 6).Value = ubigeo_id
        obj_Comando.Parameters.Add("@distrito", SqlDbType.VarChar, 100).Value = distrito
        obj_Comando.Parameters.Add("@provincia", SqlDbType.VarChar, 100).Value = provincia
        obj_Comando.Parameters.Add("@departamento", SqlDbType.VarChar, 100).Value = departamento

        obj_Comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output
        Try
            obj_Comando.Connection = objConexion.getConexion
            objConexion.abrirConexion()
            obj_Comando.ExecuteNonQuery()
            Dim retorno As Integer = obj_Comando.Parameters.Item("@retorno").Value
            objConexion.cerrarConexion()
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message, "ADO")
            Return -1
        End Try
    End Function

    Public Function eliminar_ubigeo(ByVal ubigeo_id As String) As Integer
        Dim obj_Comando As New SqlCommand()
        obj_Comando.CommandType = CommandType.StoredProcedure
        obj_Comando.CommandText = "pa_delete_ubigeo"
        obj_Comando.Parameters.Add("@ubigeo_id", SqlDbType.Char, 6).Value = ubigeo_id

        obj_Comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output

        Try

            obj_Comando.Connection = objConexion.getConexion
            objConexion.abrirConexion()
            obj_Comando.ExecuteNonQuery()
            Dim retorno As Integer = obj_Comando.Parameters.Item("@retorno").Value
            objConexion.cerrarConexion()
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message, "ADO")
            Return -1
        End Try
    End Function

    'Hola'
End Class
