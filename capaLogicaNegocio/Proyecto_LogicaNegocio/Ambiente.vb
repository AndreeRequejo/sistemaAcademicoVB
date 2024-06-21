Imports Proyecto_Datos
Public Class Ambiente
    Private objConexion As New clsConexionSQL
    Private objAmbiente As New ADO_Ambiente

    Public Function listar_ambiente() As DataTable
        Dim sql As String
        sql = " select ambiente_id, tipoambiente_id ,descripcion_ambiente, capacidad, estado
                from ambiente;"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function listar_tipo_ambiente() As DataTable
        Dim sql As String
        sql = " select tipoambiente_id ,descripcion_tipoambiente
                from tipo_ambiente;"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function obtenerIdAmb() As Integer
        Dim nuevoId As Integer = 0
        Try
            Dim sql As String
            sql = "SELECT dbo.obtIdAmbiente()"
            Dim result As DataTable = objConexion.consultaSQL(sql)

            If result.Rows.Count > 0 Then
                nuevoId = Convert.ToInt32(result.Rows(0)(0))
            End If
            Return nuevoId
        Catch ex As Exception

        End Try
    End Function

    Public Function buscarIdAmbiente(ByVal desc As String) As Integer
        Dim idAmbRet As Integer = 0
        Try
            Dim sql As String
            sql = "select ambiente_id from ambiente where descripcion_ambiente = '" & desc & "'"
            Dim result As DataTable = objConexion.consultaSQL(sql)

            If result.Rows.Count > 0 Then
                idAmbRet = Convert.ToInt32(result.Rows(0)(0))
            End If
            Return idAmbRet
        Catch ex As Exception

        End Try
    End Function

    Public Function buscarTipoAmbiente(ByVal id As Integer) As String
        Dim idAmbRet As String = ""
        Try
            Dim sql As String
            sql = "select descripcion_tipoambiente from tipo_ambiente where tipoambiente_id = " & id & ""
            Dim result As DataTable = objConexion.consultaSQL(sql)

            If result.Rows.Count > 0 Then
                idAmbRet = Convert.ToString(result.Rows(0)(0))
            End If
            Return idAmbRet
        Catch ex As Exception

        End Try
    End Function

    Public Function agregar_ambiente(ByVal tp_amb As Integer, ByVal desc As String, ByVal cap As Integer, ByVal estado As String) As Integer
        Try
            Return objAmbiente.pa_agregar_ambiente(tp_amb, desc, cap, estado)
        Catch ex As Exception

        End Try
    End Function

    Public Function modificar_ambiente(ByVal idAmb As Integer, ByVal tp_amb As Integer, ByVal desc As String, ByVal cap As Integer, ByVal estado As String) As Integer
        Try
            Return objAmbiente.pa_modificar_ambiente(idAmb, tp_amb, desc, cap, estado)
        Catch ex As Exception

        End Try
    End Function

    Public Function eliminar_ambiente(ByVal idAmb As Integer) As Integer
        Try
            Return objAmbiente.pa_eliminar_ambiente(idAmb)
        Catch ex As Exception

        End Try
    End Function
End Class
