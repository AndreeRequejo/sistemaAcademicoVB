Imports Proyecto_Datos

Public Class Matricula
    Private objConexion As New clsConexionSQL
    Private objMatricula As New ADO_Matricula

    Public Function listar_matriculas() As DataTable
        Dim sql As String = "SELECT * FROM matricula ORDER BY matricula_id"
        Dim resultado As New DataTable

        Try
            ' Consultar la base de datos para obtener todas las matrículas
            resultado = objConexion.consultaSQL(sql)
        Catch ex As Exception
            ' Manejo de excepciones
            Throw New Exception("Error al listar matrículas: " & ex.Message)
        End Try

        Return resultado
    End Function

    Public Function agregar_matricula(ByVal fechaMatricula As String, ByVal codigoSemestre As String, ByVal estado As Integer, ByVal alumnoId As Integer) As Integer
        Try
            Return objMatricula.agregar_matricula(fechaMatricula, alumnoId, codigoSemestre, estado)
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function modificar_matricula(ByVal idMatricula As Integer, ByVal estado As Integer, ByVal fechaBaja As String, ByVal nroCreditos As Integer) As Integer
        Try
            Return objMatricula.modificar_matricula(idMatricula, estado, fechaBaja, nroCreditos)
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function eliminar_matricula(ByVal idMatricula As Integer) As Integer
        Try
            Return objMatricula.eliminar_matricula(idMatricula)
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function listar_matriculasEstudiante(ByVal dniEstudiante As String) As DataTable
        Dim sql As String
        sql = "SELECT matricula_id, codigo_semestre, CONVERT(varchar, fecha_matricula, 23) as fecha_matricula, COALESCE(nro_creditos_matriculados,0) as nro_creditos_matriculados, estado_matricula, CONVERT(varchar, fecha_baja, 23) as fecha_baja
                FROM MATRICULA MA
                INNER JOIN ALUMNO AL ON AL.alumno_id = MA.alumno_id
                WHERE numero_documento = '" & dniEstudiante & "' ORDER BY codigo_semestre DESC" '
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function listar_matriculasEstudianteActiva(ByVal dniEstudiante As String) As DataTable
        Dim sql As String
        sql = "SELECT matricula_id, MA.codigo_semestre, CONVERT(varchar, fecha_matricula, 23) as fecha_matricula, COALESCE(nro_creditos_matriculados,0) as nro_creditos_matriculados, estado_matricula, CONVERT(varchar, fecha_baja, 23) as fecha_baja
                FROM MATRICULA MA
                INNER JOIN ALUMNO AL ON AL.alumno_id = MA.alumno_id
                INNER JOIN SEMESTRE SE ON SE.codigo_semestre = MA.codigo_semestre
                WHERE numero_documento = '" & dniEstudiante & "' AND SE.estado_semestre = 1"
        Return objConexion.consultaSQL(sql)
    End Function
End Class
