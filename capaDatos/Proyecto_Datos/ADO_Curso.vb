Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Windows.Forms

Public Class ADO_Curso
    Private objConexion As New clsConexionSQL
    Public Function pa_agregar_curso(ByVal codCur As String, ByVal nomCur As String, ByVal hT As Integer, ByVal hP As Integer, ByVal ci As Integer, ByVal tipCur As Boolean, ByVal planId As Integer, ByVal escId As Integer) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_insert_curso"
        objComando.Parameters.Add("@codCur", SqlDbType.VarChar, 20).Value = codCur
        objComando.Parameters.Add("@nomCur", SqlDbType.VarChar, 100).Value = nomCur
        objComando.Parameters.Add("@hTeo", SqlDbType.Int, 0).Value = hT
        objComando.Parameters.Add("@hPra", SqlDbType.Int, 0).Value = hP
        objComando.Parameters.Add("@ciclo", SqlDbType.Int, 0).Value = ci
        If tipCur Then
            objComando.Parameters.Add("@tipoCurso", SqlDbType.Bit).Value = 1
        Else
            objComando.Parameters.Add("@tipoCurso", SqlDbType.Bit).Value = 0
        End If
        objComando.Parameters.Add("@planID", SqlDbType.Int, 0).Value = planId
        objComando.Parameters.Add("@escID", SqlDbType.Int, 0).Value = escId
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

    Public Function pa_modificar_curso(ByVal codCur As String, ByVal nomCur As String, ByVal hT As Integer, ByVal hP As Integer, ByVal ci As Integer, ByVal tipCur As Boolean, ByVal planId As Integer, ByVal escId As Integer) As Integer
        Dim objComando As New SqlCommand()
        Dim retorno As Integer
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_update_curso"
        objComando.Parameters.Add("@codCur", SqlDbType.VarChar, 20).Value = codCur
        objComando.Parameters.Add("@nomCur", SqlDbType.VarChar, 100).Value = nomCur
        objComando.Parameters.Add("@hTeo", SqlDbType.Int, 0).Value = hT
        objComando.Parameters.Add("@hPra", SqlDbType.Int, 0).Value = hP
        objComando.Parameters.Add("@ciclo", SqlDbType.Int, 0).Value = ci
        objComando.Parameters.Add("@tipoCurso", SqlDbType.Bit).Value = tipCur
        objComando.Parameters.Add("@planID", SqlDbType.Int, 0).Value = planId
        objComando.Parameters.Add("@escID", SqlDbType.Int, 0).Value = escId
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

    Public Function pa_eliminar_curso(ByVal codCur As String) As Integer
        Dim objComando As New SqlCommand()
        Dim retorno As Integer
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_delete_curso"
        objComando.Parameters.Add("@codCur", SqlDbType.VarChar, 20).Value = codCur
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
