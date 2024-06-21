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

    Public Function agregar_matricula(ByVal fechaMatricula As Date, ByVal horaMatricula As TimeSpan, ByVal tipoMatricula As Boolean, ByVal alumnoId As Integer, ByVal codigoSemestre As String, ByVal estado As Boolean) As Integer
        Try
            ' Llamar a la función agregar_matricula de la clase ADO_Matricula
            Return objMatricula.agregar_matricula(fechaMatricula, horaMatricula, tipoMatricula, alumnoId, codigoSemestre, estado)
        Catch ex As Exception
            ' Manejo de excepciones
            Console.WriteLine("Error: " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function eliminar_matricula(ByVal idMatricula As Integer) As Integer
        Try
            ' Llamar a la función eliminar_matricula de la clase ADO_Matricula
            Return objMatricula.eliminar_matricula(idMatricula)
        Catch ex As Exception
            ' Manejo de excepciones
            Console.WriteLine("Error: " & ex.Message)
            Return -1
        End Try
    End Function
End Class
