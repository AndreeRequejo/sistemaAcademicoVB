Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class ADO_DetalleMatricula
    Private objConexion As New clsConexionSQL
    Public Function pa_agregar_detalle_matricula(ByVal matricula_id As Integer, ByVal grupo_id As Integer) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_insert_detalle_matricula"
        objComando.Parameters.Add("@matricula_id", SqlDbType.Int).Value = matricula_id
        objComando.Parameters.Add("@grupo_id", SqlDbType.Int).Value = grupo_id
        objComando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output

        Try
            objComando.Connection = objConexion.getConexion
            objConexion.abrirConexion()
            objComando.ExecuteNonQuery()
            Dim retorno As Integer = Convert.ToInt32(objComando.Parameters("@retorno").Value)
            objConexion.cerrarConexion()
            MessageBox.Show(retorno)
            Return retorno
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message, "ADO")
            Return -1
        End Try
    End Function

    Public Function pa_modificar_detalle_metricula(ByVal matricula_id As Integer, ByVal grupo_id As Integer, ByVal nota_promedio As Double) As Integer
        Dim objComando As New SqlCommand()
        Dim retorno As Integer
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_modificar_detalle_matricula"
        objComando.Parameters.Add("@matricula_id", SqlDbType.Int).Value = matricula_id
        objComando.Parameters.Add("@grupo_id", SqlDbType.Int).Value = grupo_id
        objComando.Parameters.Add("@nota_promedio", SqlDbType.Float).Value = nota_promedio
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

    Public Function pa_eliminar_detalle_matricula(ByVal matricula_id As Integer, ByVal grupo_id As Integer) As Integer
        Dim objComando As New SqlCommand()
        Dim retorno As Integer
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_eliminar_detalle_matricula"
        objComando.Parameters.Add("@matricula_id", SqlDbType.Int).Value = matricula_id
        objComando.Parameters.Add("@grupo_id", SqlDbType.Int).Value = grupo_id
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