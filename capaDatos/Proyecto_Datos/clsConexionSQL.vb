Imports System.Data
Imports System.Data.SqlClient


Public Class clsConexionSQL
    Private objCadena As New SqlConnectionStringBuilder
    Private objConexion As New SqlConnection

    'Constructor:'
    Sub New()
        objCadena.DataSource = "localhost"
        objCadena.InitialCatalog = "bd_academico"
        objCadena.UserID = "sa"
        objCadena.Password = "1234"
        objCadena.IntegratedSecurity = True 'True:windows False:SQL Server'
        objConexion.ConnectionString = objCadena.ToString()
    End Sub

    Public Function getConexion() As SqlConnection
        Return objConexion
    End Function

    Public Function abrirConexion() As Boolean
        Try
            objConexion.Open()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub cerrarConexion()
        Try
            If objConexion.State = Data.ConnectionState.Open Then
                objConexion.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function ejecutarSQL(ByVal sentencia As String) As Boolean
        Try
            Dim obj_comando As New SqlCommand
            obj_comando.CommandType = Data.CommandType.Text
            obj_comando.Connection = objConexion
            obj_comando.CommandText = sentencia
            abrirConexion()
            'Ejecutar conexion'
            obj_comando.ExecuteNonQuery()
            cerrarConexion()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function consultaSQL(ByVal sentencia As String) As DataTable
        Dim obj_adapter As New SqlDataAdapter(sentencia, objConexion)
        Dim obj_tabla As New DataTable
        obj_adapter.Fill(obj_tabla)
        Return obj_tabla
    End Function

End Class
