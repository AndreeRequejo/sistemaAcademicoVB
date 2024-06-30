Imports Proyecto_Datos
Imports System.Windows.Forms

Public Class DetalleMatricula
    Private objConexion As New clsConexionSQL
    Private objDetalle As New ADO_DetalleMatricula

    Public Function listar_detalle_matricula() As DataTable
        Dim sql As String
        sql = "select matricula_id,grupo_id,estado,nota_promedio from detalle_matricula"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function obtenerDetalleMatricula(ByVal idMatricula As Integer) As DataTable
        Dim sql As String
        sql = "SELECT DM.matricula_id, DM.grupo_id, CU.nombre_curso + ' - ' + GR.denominacion as curso, nota_promedio
                FROM detalle_matricula DM
                INNER JOIN matricula MA ON MA.matricula_id = DM.matricula_id
                INNER JOIN grupo GR ON GR.grupo_id = DM.grupo_id
                INNER JOIN curso CU ON CU.curso_id = GR.curso_id
                WHERE MA.matricula_id = " & idMatricula
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function obtenerAsignaturasPorCursar(ByVal dniEstud As Integer) As DataTable
        Dim sql As String
        sql = "SELECT * FROM fn_cursos_proximos ('" & dniEstud & "')"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function obtenerGruposCurso(ByVal cursoId As Integer) As DataTable
        Dim sql As String
        sql = "SELECT g.grupo_id, denominacion, CONVERT(VARCHAR(5), h.h_inicio, 108) as hora_inicio, CONVERT(VARCHAR(5), h.h_final, 108) as hora_fin, 
                CASE 
                   WHEN dia = 1 THEN 'Lunes'
                   WHEN dia = 2 THEN 'Martes'
                   WHEN dia = 3 THEN 'Miércoles'
                   WHEN dia = 4 THEN 'Jueves'
                   WHEN dia = 5 THEN 'Viernes'
                   WHEN dia = 6 THEN 'Sábado'
                   WHEN dia = 7 THEN 'Domingo'
                END AS dia
                FROM grupo g
                INNER JOIN horario h ON h.grupo_id = g.grupo_id
                INNER JOIN docente d ON d.docente_id = g.docente_id
                INNER JOIN curso c ON c.curso_id = g.curso_id
                WHERE g.semestre_id = '2024-1' AND c.curso_id = " & cursoId
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function agregar_detalle_matricula(ByVal matricula_id As Integer, ByVal grupo_id As Integer) As Integer
        Try
            Return objDetalle.pa_agregar_detalle_matricula(matricula_id, grupo_id)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message, "Clase")
            Return -1
        End Try
    End Function

    Public Function modificar_detalle_matricula(ByVal matricula_id As Integer, ByVal grupo_id As Integer, ByVal nota_promedio As Double) As Integer
        Try
            Return objDetalle.pa_modificar_detalle_metricula(matricula_id, grupo_id, nota_promedio)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function eliminar_detalle_matricula(ByVal matricula_id As Integer, ByVal grupo_id As Integer) As Integer
        Try
            Return objDetalle.pa_eliminar_detalle_matricula(matricula_id, grupo_id)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message)
            Return -1
        End Try
    End Function

End Class