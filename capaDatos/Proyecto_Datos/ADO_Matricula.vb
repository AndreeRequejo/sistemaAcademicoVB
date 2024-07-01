Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class ADO_matricula
    Private obj_conexion As New clsConexionSQL

    Public Function agregar_matricula(ByVal fecha_matricula As String,
                                      ByVal alumno_id As Integer,
                                      ByVal codigo_semestre As String,
                                      ByVal estado_matricula As Integer) As Integer
        Dim retorno As Integer
        Dim obj_comando As New SqlCommand
        obj_comando.CommandType = CommandType.StoredProcedure
        obj_comando.CommandText = "pa_insert_matricula"
        obj_comando.Parameters.Add("@fecha_matricula", SqlDbType.Date).Value = fecha_matricula
        obj_comando.Parameters.Add("@codigo_semestre", SqlDbType.Char, 6).Value = codigo_semestre
        obj_comando.Parameters.Add("@estado_matricula", SqlDbType.Int).Value = estado_matricula
        obj_comando.Parameters.Add("@alumno_id", SqlDbType.Int).Value = alumno_id
        obj_comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output

        Try
            obj_comando.Connection = obj_conexion.getConexion()
            obj_conexion.abrirConexion()
            obj_comando.ExecuteNonQuery()
            retorno = Convert.ToInt32(obj_comando.Parameters("@retorno").Value)
            obj_conexion.cerrarConexion()
            Return retorno
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function modificar_matricula(ByVal idMatricula As Integer,
                                    ByVal estado_matricula As Integer,
                                    ByVal fecha_baja As String,
                                    ByVal nroCreditos As Integer) As Integer
        Dim retorno As Integer
        Dim obj_comando As New SqlCommand
        obj_comando.CommandType = CommandType.StoredProcedure
        obj_comando.CommandText = "pa_modificar_matricula"
        obj_comando.Parameters.Add("@matricula_id", SqlDbType.Int).Value = idMatricula
        obj_comando.Parameters.Add("@estado_matricula", SqlDbType.Int).Value = estado_matricula
        obj_comando.Parameters.Add("@nro_creditos_matriculados", SqlDbType.Int).Value = nroCreditos
        obj_comando.Parameters.Add("@retorno", SqlDbType.Int).Direction = ParameterDirection.Output

        ' Manejar el parámetro fecha_baja para que sea opcional
        If String.IsNullOrEmpty(fecha_baja) Then
            obj_comando.Parameters.Add("@fecha_baja", SqlDbType.Date).Value = DBNull.Value
        Else
            obj_comando.Parameters.Add("@fecha_baja", SqlDbType.Date).Value = Convert.ToDateTime(fecha_baja)
        End If

        Try
            obj_comando.Connection = obj_conexion.getConexion()
            obj_conexion.abrirConexion()
            obj_comando.ExecuteNonQuery()
            retorno = Convert.ToInt32(obj_comando.Parameters("@retorno").Value)
            obj_conexion.cerrarConexion()
            Return retorno
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function eliminar_matricula(ByVal matricula_id As Integer) As Integer
        Dim retorno As Integer
        Dim obj_comando As New SqlCommand
        obj_comando.CommandType = CommandType.StoredProcedure
        obj_comando.CommandText = "pa_eliminar_matricula"
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
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

End Class