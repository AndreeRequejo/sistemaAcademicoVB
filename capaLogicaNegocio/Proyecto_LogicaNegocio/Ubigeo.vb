Imports Proyecto_Datos
Public Class Ubigeo
    Private objConexion As New clsConexionSQL
    Private obj_ubigeo As New ADO_Ubigeo
    Private obj_conexion As New clsConexionSQL
    Public Function listar_ubigeo() As DataTable
        Try
            Dim sql As String
            sql = " SELECT ubigeo_id
                    from ubigeo"
            Return objConexion.consultaSQL(sql)
        Catch ex As Exception

        End Try
    End Function
    Public Function listar_ubigeos() As DataTable
        Dim sql As String
        sql = "SELECT ubigeo_id, distrito, provincia, departamento FROM ubigeo"
        Return obj_conexion.consultaSQL(sql)
    End Function
    Public Function listar_ubigeos(ByVal ubigeo_id As String) As DataTable
        Dim sql As String
        sql = "SELECT ubigeo_id, distrito, provincia, departamento FROM ubigeo where ubigeo_id = " & ubigeo_id
        Return obj_conexion.consultaSQL(sql)
    End Function
    Public Function agregar_ubigeo(ByVal ubigeo_id As String, ByVal distrito As String, ByVal provincia As String, ByVal departamento As String) As Integer
        Try
            Return obj_ubigeo.agregar_ubigeo(ubigeo_id, distrito, provincia, departamento)
        Catch ex As Exception

        End Try
    End Function
    Public Function modificar_ubigeo(ByVal ubigeo_id As String, ByVal distrito As String, ByVal provincia As String, ByVal departamento As String) As Integer
        Try
            Return obj_ubigeo.modificar_ubigeo(ubigeo_id, distrito, provincia, departamento)
        Catch ex As Exception

        End Try
    End Function
    Public Function eliminar_ubigeo(ByVal ubigeo_id As String) As Integer
        Try
            Return obj_ubigeo.eliminar_ubigeo(ubigeo_id)
        Catch ex As Exception

        End Try
    End Function
End Class
