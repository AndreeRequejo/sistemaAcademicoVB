Imports Proyecto_Datos

Public Class Escuela
    Private objConexion As New clsConexionSQL
    Private objEscuela As New ADO_Escuela

    Public Function listar_escuelas() As DataTable
        Dim sql As String
        sql = " select escuela_id, nombre_escuela, nombre_facultad 
                from escuela e 
                inner join facultad f on e.facultad_id = f.facultad_id;"
        Return objConexion.consultaSQL(sql)
    End Function


    Public Function listar_escuelas_1(ByVal fac As Integer) As DataTable
        Dim sql As String
        sql = " select escuela_id, nombre_escuela
                from escuela e 
                inner join facultad f on e.facultad_id = f.facultad_id where f.facultad_id=" & fac & ";"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function listar_ciclos(ByVal nomEsc As Integer) As DataTable
        Dim sql As String
        sql = " select ci.numero_ciclo,ci.ciclo_id from ciclo ci 
                inner join escuela e on e.escuela_id=ci.escuela_id 
                where e.escuela_id=" & nomEsc & ";"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function obtenerIdEsc() As Integer
        Dim nuevoId As Integer = 0
        Try
            Dim sql As String
            sql = "SELECT dbo.obtIdEscuela()"
            Dim result As DataTable = objConexion.consultaSQL(sql)

            If result.Rows.Count > 0 Then
                nuevoId = Convert.ToInt32(result.Rows(0)(0))
            End If
            Return nuevoId
        Catch ex As Exception

        End Try
    End Function

    Public Function buscarIdEscuela(ByVal nomEsc As String) As Integer
        Dim idEscRet As Integer = 0
        Try
            Dim sql As String
            sql = "select escuela_id from escuela where nombre_escuela = '" & nomEsc & "'"
            Dim result As DataTable = objConexion.consultaSQL(sql)

            If result.Rows.Count > 0 Then
                idEscRet = Convert.ToInt32(result.Rows(0)(0))
            End If
            Return idEscRet
        Catch ex As Exception

        End Try
    End Function

    Public Function agregar_escuela(ByVal idEsc As Integer, ByVal nom As String, ByVal idFac As Integer) As Integer
        Try
            Return objEscuela.pa_agregar_escuela(idEsc, nom, idFac)
        Catch ex As Exception

        End Try
    End Function

    Public Function modificar_escuela(ByVal idEsc As Integer, ByVal nom As String, ByVal idFac As Integer) As Integer
        Try
            Return objEscuela.pa_modificar_escuela(idEsc, nom, idFac)
        Catch ex As Exception

        End Try
    End Function

    Public Function eliminar_escuela(ByVal idEsc As Integer) As Integer
        Try
            Return objEscuela.pa_eliminar_escuela(idEsc)
        Catch ex As Exception

        End Try
    End Function
End Class
