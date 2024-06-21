Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class ADO_Alumno
    Private objConexion As New clsConexionSQL
    Public Function pa_agregar_alumno(ByVal tipoDoc As Integer, ByVal numDoc As String, ByVal apePat As String, ByVal apeMat As String, ByVal nom As String,
                                   ByVal sexo As Boolean, ByVal fNac As Date, ByVal direc As String, ByVal estado As String, ByVal escuela As Integer,
                                    ByVal ubigeo As Integer, ByVal semIng As String) As Integer
        Dim objComando As New SqlCommand()
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_insert_alumno"
        objComando.Parameters.Add("@tipoDoc", SqlDbType.Char, 1).Value = tipoDoc
        objComando.Parameters.Add("@numDoc", SqlDbType.VarChar, 20).Value = numDoc
        objComando.Parameters.Add("@apePat", SqlDbType.VarChar, 50).Value = apePat
        objComando.Parameters.Add("@apeMat", SqlDbType.VarChar, 50).Value = apeMat
        objComando.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nom
        If sexo Then
            objComando.Parameters.Add("@sexo", SqlDbType.Bit).Value = 1
        Else
            objComando.Parameters.Add("@sexo", SqlDbType.Bit).Value = 0
        End If
        objComando.Parameters.Add("@fecNac", SqlDbType.Date).Value = fNac
        objComando.Parameters.Add("@direccion", SqlDbType.VarChar, 100).Value = direc
        objComando.Parameters.Add("@estado", SqlDbType.Char, 1).Value = estado
        objComando.Parameters.Add("@escuelaId", SqlDbType.Int, 0).Value = escuela
        objComando.Parameters.Add("@ubigeo", SqlDbType.Char, 6).Value = ubigeo
        objComando.Parameters.Add("@semIngreso", SqlDbType.Char, 6).Value = semIng
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

    Public Function pa_modificar_alumno(ByVal idAlu As Integer, ByVal tipoDoc As Integer, ByVal numDoc As String, ByVal apePat As String, ByVal apeMat As String, ByVal nom As String,
                                   ByVal sexo As Integer, ByVal fNac As Date, ByVal direc As String, ByVal estado As String, ByVal escuela As Integer,
                                    ByVal ubigeo As Integer, ByVal semIng As String, ByVal semEg As String) As Integer
        Dim objComando As New SqlCommand()
        Dim retorno As Integer
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_update_alumno"
        objComando.Parameters.Add("@alumno_id", SqlDbType.Int).Value = idAlu
        objComando.Parameters.Add("@tipo_documento", SqlDbType.Char, 1).Value = tipoDoc
        objComando.Parameters.Add("@numero_documento", SqlDbType.VarChar, 20).Value = numDoc
        objComando.Parameters.Add("@ape_paterno", SqlDbType.VarChar, 50).Value = apePat
        objComando.Parameters.Add("@ape_materno", SqlDbType.VarChar, 50).Value = apeMat
        objComando.Parameters.Add("@nombres", SqlDbType.VarChar, 50).Value = nom
        objComando.Parameters.Add("@sexo", SqlDbType.Bit).Value = sexo
        objComando.Parameters.Add("@f_nacimiento", SqlDbType.Date).Value = fNac
        objComando.Parameters.Add("@direccion_residencia", SqlDbType.VarChar, 100).Value = direc
        objComando.Parameters.Add("@estado_alumno", SqlDbType.Char, 1).Value = estado
        objComando.Parameters.Add("@escuela_id", SqlDbType.Int, 0).Value = escuela
        objComando.Parameters.Add("@ubigeo_id", SqlDbType.Char, 6).Value = ubigeo
        objComando.Parameters.Add("@semestre_ingreso", SqlDbType.Char, 10).Value = semIng
        objComando.Parameters.Add("@semestre_egreso", SqlDbType.Char, 10).Value = semEg

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

    Public Function pa_eliminar_alumno(ByVal idAlu As Integer) As Integer
        Dim objComando As New SqlCommand()
        Dim retorno As Integer
        objComando.CommandType = CommandType.StoredProcedure
        objComando.CommandText = "pa_eliminar_alumno"
        objComando.Parameters.Add("@alumno_id", SqlDbType.Int, 10).Value = idAlu
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
