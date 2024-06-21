Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class ADO_matricula
    Private obj_conexion As New clsConexionSQL

    Public Function agregar_matricula(ByVal fecha_matricula As Date,
                                      ByVal h_matricula As TimeSpan,
                                      ByVal tipo_matricula As Boolean,
                                      ByVal alumno_id As Integer,
                                      ByVal codigo_semestre As String,
                                      ByVal estado_matricula As String) As Integer
        Dim retorno As Integer
        Dim obj_comando As New SqlCommand
        obj_comando.CommandType = CommandType.StoredProcedure
        obj_comando.CommandText = "pa_insert_matricula"
        obj_comando.Parameters.Add("@fecha_matricula", SqlDbType.Date).Value = fecha_matricula
        obj_comando.Parameters.Add("@h_matricula", SqlDbType.Time, 7).Value = h_matricula
        obj_comando.Parameters.Add("@tipo_matricula", SqlDbType.Bit).Value = tipo_matricula
        obj_comando.Parameters.Add("@alumno_id", SqlDbType.Int).Value = alumno_id
        obj_comando.Parameters.Add("@codigo_semestre", SqlDbType.Char, 6).Value = codigo_semestre
        If estado_matricula Then
            obj_comando.Parameters.Add("@estado", SqlDbType.Int).Value = 1
        Else
            obj_comando.Parameters.Add("@estado", SqlDbType.Int).Value = 0
        End If
        obj_comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output

        Try
            obj_comando.Connection = obj_conexion.getConexion()
            obj_conexion.abrirConexion()
            obj_comando.ExecuteNonQuery()
            retorno = Convert.ToInt32(obj_comando.Parameters("@retorno").Value)
            obj_conexion.cerrarConexion()
            Return retorno
        Catch ex As Exception
            MessageBox.Show(ex.Message, "InsertarMatricula_CapaDatos")
        End Try
    End Function

    Public Function eliminar_matricula(ByVal matricula_id As Integer) As Integer
        Dim retorno As Integer
        Dim obj_comando As New SqlCommand
        obj_comando.CommandType = CommandType.StoredProcedure
        obj_comando.CommandText = "pa_delete_matricula"
        obj_comando.Parameters.Add("@matricula_id", SqlDbType.Int).Value = matricula_id
        obj_comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output

        Try
            obj_comando.Connection = obj_conexion.getConexion()
            obj_conexion.abrirConexion()
            obj_comando.ExecuteNonQuery()
            retorno = Convert.ToInt32(obj_comando.Parameters("@retorno").Value)
            obj_conexion.cerrarConexion()
            Return retorno
        Catch ex As Exception
            MessageBox.Show(ex.Message, "EliminarMatricula_CapaDatos")
        End Try
    End Function

End Class