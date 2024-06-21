Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class ADO_Docente
    Private objConexion As New clsConexionSQL
    Public Function pa_agregar_docente(ByVal tipoCod As String, ByVal numDoc As String, ByVal tipDoc As String, ByVal apePat As String,
                                        ByVal apeMat As String, ByVal nom As String, ByVal grado As String, ByVal estado As Boolean,
                                        ByVal ubigeo As String) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_insert_docente"
        objComando.Parameters.Add("@tipoDoc", SqlDbType.Char, 1).Value = tipoCod
        objComando.Parameters.Add("@numDoc", SqlDbType.VarChar, 20).Value = numDoc
        objComando.Parameters.Add("@tipoDocente", SqlDbType.Char, 2).Value = tipDoc
        objComando.Parameters.Add("@apePat", SqlDbType.VarChar, 50).Value = apePat
        objComando.Parameters.Add("@apeMat", SqlDbType.VarChar, 50).Value = apeMat
        objComando.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nom
        objComando.Parameters.Add("@grado", SqlDbType.Char, 1).Value = grado
        If estado Then
            objComando.Parameters.Add("@estado", SqlDbType.Bit).Value = 1
        Else
            objComando.Parameters.Add("@estado", SqlDbType.Bit).Value = 0
        End If
        objComando.Parameters.Add("@ubigeo", SqlDbType.Char, 6).Value = ubigeo
        objComando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output

        Try
            objComando.Connection = objConexion.getConexion
            objConexion.abrirConexion()
            objComando.ExecuteNonQuery()
            Dim retorno As Integer = Convert.ToInt32(objComando.Parameters("@retorno").Value)
            objConexion.cerrarConexion()
            Return retorno
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message, "ADO")
            Return -1
        End Try
    End Function

    Public Function pa_modificar_docente(ByVal idDoc As Integer,ByVal tipoCod As String, ByVal numDoc As String, ByVal tipDoc As String, 
                                         ByVal apePat As String, ByVal apeMat As String, ByVal nom As String, ByVal grado As String, 
                                         ByVal estado As Boolean, ByVal ubigeo As String) As Integer
        Dim objComando As New SqlCommand()
        Dim retorno As Integer
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_update_docente"
        objComando.Parameters.Add("@idDocente", SqlDbType.Int).Value = idDoc
        objComando.Parameters.Add("@tipoDoc", SqlDbType.Char, 1).Value = tipoCod
        objComando.Parameters.Add("@numDoc", SqlDbType.VarChar, 20).Value = numDoc
        objComando.Parameters.Add("@tipoDocente", SqlDbType.Char, 2).Value = tipDoc
        objComando.Parameters.Add("@apePat", SqlDbType.VarChar, 50).Value = apePat
        objComando.Parameters.Add("@apeMat", SqlDbType.VarChar, 50).Value = apeMat
        objComando.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nom
        objComando.Parameters.Add("@grado", SqlDbType.Char, 1).Value = grado
        If estado Then
            objComando.Parameters.Add("@estado", SqlDbType.Bit).Value = 1
        Else
            objComando.Parameters.Add("@estado", SqlDbType.Bit).Value = 0
        End If
        objComando.Parameters.Add("@ubigeo", SqlDbType.Char, 6).Value = ubigeo
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

    Public Function pa_eliminar_docente(ByVal idDoc As Integer) As Integer
        Dim objComando As New SqlCommand()
        Dim retorno As Integer
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_delete_docente"
        objComando.Parameters.Add("@idDocente", SqlDbType.VarChar, 20).Value = idDoc
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
