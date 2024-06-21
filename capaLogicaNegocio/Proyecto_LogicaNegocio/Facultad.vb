Imports Proyecto_Datos

Public Class Facultad
    Private objConexion As New clsConexionSQL
    Private objFacultad As New ADO_Facultad

    Public Function listar_facultades() As DataTable
        Dim sql As String
        sql = "select facultad_id, nombre_facultad from facultad"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function obtenerIdFac() As Integer
        Dim nuevoId As Integer = 0
        Try
            Dim sql As String
            sql = "SELECT dbo.obtIdFacultad()"
            Dim result As DataTable = objConexion.consultaSQL(sql)

            If result.Rows.Count > 0 Then
                nuevoId = Convert.ToInt32(result.Rows(0)(0))
            End If
            Return nuevoId
        Catch ex As Exception

        End Try
    End Function

    Public Function buscarIdFacultad(ByVal nomEsc As String) As Integer
        Dim idFacultad As Integer = 0
        Try
            Dim sql As String
            sql = "select facultad_id from facultad where nombre_facultad = '" & nomEsc & "'"
            Dim result As DataTable = objConexion.consultaSQL(sql)

            If result.Rows.Count > 0 Then
                idFacultad = Convert.ToInt32(result.Rows(0)(0))
            End If
            Return idFacultad
        Catch ex As Exception

        End Try
    End Function

    Public Function agregar_facultad(ByVal idFac As Integer, ByVal nom As String) As Integer
        Try
            Return objFacultad.pa_agregar_facultad(idFac, nom)
        Catch ex As Exception

        End Try
    End Function

    Public Function modificar_facultad(ByVal idFac As Integer, ByVal nom As String) As Integer
        Dim r As Integer
        Try
            r = objFacultad.pa_modificar_facultad(idFac, nom)
            Return r
        Catch ex As Exception
            Return r
        End Try
    End Function


    Public Function eliminar_facultad(ByVal idFac As Integer) As Integer
        Dim r As Integer
        Try
            r = objFacultad.pa_eliminar_facultad(idFac)
            Return r
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
End Class
