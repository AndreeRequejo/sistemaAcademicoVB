Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class ADO_Grupo
    Private objConexion As New clsConexionSQL

    Public Function pa_insertarGrupo(ByVal denominacion As Char, ByVal numero_vacantes As Integer, ByVal estado_grupo As Integer, ByVal curso_id As Integer, ByVal docente_id As Integer, ByVal semestre_id As String) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_insertarGrupo"

        objComando.Parameters.Add("@denominacion", SqlDbType.VarChar, 1).Value = denominacion
        objComando.Parameters.Add("@numero_vacantes", SqlDbType.Int).Value = numero_vacantes
        objComando.Parameters.Add("@estado_grupo", SqlDbType.Int).Value = estado_grupo
        objComando.Parameters.Add("@curso_id", SqlDbType.Int).Value = curso_id
        objComando.Parameters.Add("@docente_id", SqlDbType.Int).Value = docente_id
        objComando.Parameters.Add("@semestre_id", SqlDbType.VarChar, 6).Value = semestre_id
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

    Public Function pa_modificarGrupo(ByVal grupo_id As Integer, ByVal denominacion As String, ByVal numero_vacantes As Integer, ByVal estado_grupo As Integer, ByVal curso_id As Integer, ByVal docente_id As Integer, ByVal semestre_id As String) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_modificarGrupo"

        objComando.Parameters.Add("@grupo_id", SqlDbType.Int).Value = grupo_id
        objComando.Parameters.Add("@denominacion", SqlDbType.VarChar, 1).Value = denominacion
        objComando.Parameters.Add("@numero_vacantes", SqlDbType.Int).Value = numero_vacantes
        objComando.Parameters.Add("@estado_grupo", SqlDbType.Int).Value = estado_grupo
        objComando.Parameters.Add("@curso_id", SqlDbType.Int).Value = curso_id
        objComando.Parameters.Add("@docente_id", SqlDbType.Int).Value = docente_id
        objComando.Parameters.Add("@semestre_id", SqlDbType.VarChar, 6).Value = semestre_id
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

    Public Function pa_eliminarGrupo(ByVal grupo_id As Integer) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_eliminarGrupo"
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


End Class
