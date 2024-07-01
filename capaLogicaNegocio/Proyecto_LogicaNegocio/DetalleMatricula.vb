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

    Public Function obtenerGruposCurso(ByVal semestre As String, ByVal cursoId As Integer) As DataTable
        Dim sql As String
        sql = "SELECT g.grupo_id, denominacion, COALESCE(
        CASE 
            WHEN h.dia = 1 THEN 'Lunes'
            WHEN h.dia = 2 THEN 'Martes'
            WHEN h.dia = 3 THEN 'Miércoles'
            WHEN h.dia = 4 THEN 'Jueves'
            WHEN h.dia = 5 THEN 'Viernes'
            WHEN h.dia = 6 THEN 'Sábado'
            WHEN h.dia = 7 THEN 'Domingo'
            ELSE 'Día no especificado'
			END, 'Día no especificado') + ' ' + 
			COALESCE(CONVERT(VARCHAR(5), h.h_inicio, 108), 'Hora no especificada') + ' - ' + 
			COALESCE(CONVERT(VARCHAR(5), h.h_final, 108), 'Hora no especificada') + ' ' + 
			COALESCE(a.descripcion_ambiente, 'Ambiente no especificado') AS horario_formato,
			d.ape_paterno + ' ' + d.ape_materno + ' ' + d.nombres as docente
                FROM grupo g
                INNER JOIN horario h ON h.grupo_id = g.grupo_id
				INNER JOIN ambiente a ON a.ambiente_id = h.ambiente_id
                INNER JOIN docente d ON d.docente_id = g.docente_id
                INNER JOIN curso c ON c.curso_id = g.curso_id
                WHERE g.semestre_id = '" & semestre & "' AND c.curso_id = " & cursoId
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function obtenerCreditosCurso(ByVal grupoId As Integer) As Integer
        Dim creditos As Integer = 0
        Try
            Dim sql As String
            sql = "SELECT creditos FROM CURSO C
                    INNER JOIN GRUPO G ON G.curso_id = C.curso_id
                    WHERE G.grupo_id = " & grupoId
            Dim result As DataTable = objConexion.consultaSQL(sql)

            If result.Rows.Count > 0 Then
                creditos = Convert.ToInt32(result.Rows(0)(0))
            End If
            Return creditos
        Catch ex As Exception

        End Try
    End Function

    Public Function obtenerHorarioGrupo(ByVal grupoId As Integer) As DataTable
        Dim sql As String
        sql = "SELECT g.grupo_id, denominacion, COALESCE(
        CASE 
            WHEN h.dia = 1 THEN 'Lunes'
            WHEN h.dia = 2 THEN 'Martes'
            WHEN h.dia = 3 THEN 'Miércoles'
            WHEN h.dia = 4 THEN 'Jueves'
            WHEN h.dia = 5 THEN 'Viernes'
            WHEN h.dia = 6 THEN 'Sábado'
            WHEN h.dia = 7 THEN 'Domingo'
            ELSE 'Día no especificado'
			END, 'Día no especificado') + ' ' + 
			COALESCE(CONVERT(VARCHAR(5), h.h_inicio, 108), 'Hora no especificada') + ' - ' + 
			COALESCE(CONVERT(VARCHAR(5), h.h_final, 108), 'Hora no especificada') + ' ' + 
			COALESCE(a.descripcion_ambiente, 'Ambiente no especificado') AS horario_formato,
			d.ape_paterno + ' ' + d.ape_materno + ' ' + d.nombres as docente
                FROM grupo g
                LEFT JOIN horario h ON h.grupo_id = g.grupo_id
				LEFT JOIN ambiente a ON a.ambiente_id = h.ambiente_id
                LEFT JOIN docente d ON d.docente_id = g.docente_id
                LEFT JOIN curso c ON c.curso_id = g.curso_id
                WHERE g.grupo_id = " & grupoId
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