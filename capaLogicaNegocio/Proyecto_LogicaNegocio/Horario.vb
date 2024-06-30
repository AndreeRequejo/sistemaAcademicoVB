Imports System.Windows.Forms
Imports Proyecto_Datos

Public Class Horario
    Private objConexion As New clsConexionSQL
    Private objHorario As New ADO_Horario


    Public Function agregar_horario(ByVal dia As String, ByVal h_inicio As String, ByVal h_final As String, ByVal ambiente_id As Integer, ByVal grupo_id As String) As Integer
        Try
            Return objHorario.pa_agregar_horario(dia, h_inicio, h_final, ambiente_id, grupo_id)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message, "Clase")
            Return -1
        End Try
    End Function

    Public Function modificar_horario(ByVal horario_id As Integer, ByVal dia As String, ByVal h_inicio As String, ByVal h_final As String, ByVal ambiente_id As Integer, ByVal grupo_id As String) As Integer
        Try
            Return objHorario.pa_modificarHorario(horario_id, dia, h_inicio, h_final, ambiente_id, grupo_id)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message, "Clase")
            Return -1
        End Try
    End Function

    Public Function eliminar_horario(ByVal horario_id) As Integer
        Try
            Return objHorario.pa_eliminarHorario(horario_id)
        Catch ex As Exception
            MessageBox.Show("Error al procesar solicitud " & ex.Message, "Clase")
            Return -1
        End Try
    End Function

    Public Function listar_horario()
        Dim sql As String
        sql = "Select
                horario_id,
	            case dia
		            when '1' then 'Lunes'
		            when '2' then 'Martes'
		            when '3' then 'Miércoles'
		            when '4' then 'Jueves'
		            when '5' then 'Viernes'
		            when '6' then 'Sábado'
	            end as dia, 
	            h_inicio, h_final, nombre_curso, denominacion,
                            nombres+ ' ' +ape_materno+ ' ' +ape_paterno as nombre_docente,
                            descripcion_ambiente from horario h
                            inner join grupo g on g.grupo_id = h.grupo_id
                            inner join curso c on c.curso_id = g.curso_id
                            inner join docente d on d.docente_id = g.docente_id
				            inner join ambiente a on h.ambiente_id = a.ambiente_id"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function listar_cursoH(ByVal nomEsc As String) As DataTable
        Dim sql As String
        sql = "select f.facultad_id,e.escuela_id,c.ciclo,c.curso_id,g.grupo_id 
                from curso c inner join escuela e on c.escuela_id = e.escuela_id 
                inner join facultad f on f.facultad_id=e.facultad_id inner join grupo g on g.curso_id=c.curso_id
                where c.nombre_curso= '" & nomEsc & "'"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function listar_H(ByVal nomEsc As String, ByVal nomDem As String) As DataTable
        Dim sql As String
        sql = "select h.horario_id,g.grupo_id,f.facultad_id, e.escuela_id, c.ciclo, g.denominacion, g.numero_vacantes, g.estado_grupo, c.curso_id, " &
          "d.docente_id, tp.tipoambiente_id, a.ambiente_id, " &
          "h.dia, CONVERT(VARCHAR(5), h.h_inicio, 108) as hora_inicio, CONVERT(VARCHAR(5), h.h_final, 108) as hora_final " &
          "from grupo g " &
          "INNER JOIN curso c ON c.curso_id = g.curso_id " &
          "INNER JOIN docente d ON d.docente_id = g.docente_id " &
          "INNER JOIN horario h ON h.grupo_id = g.grupo_id " &
          "INNER JOIN ambiente a ON a.ambiente_id = h.ambiente_id " &
          "INNER JOIN escuela e on e.escuela_id = c.escuela_id " &
          "INNER JOIN facultad f on f.facultad_id = e.facultad_id " &
          "INNER JOIN tipo_ambiente tp on tp.tipoambiente_id = a.tipoambiente_id " &
          "where c.nombre_curso = '" & nomEsc & "' and g.denominacion = '" & nomDem & "' order by g.semestre_id desc"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function listar_Hor(ByVal nomEsc As String, ByVal nomDem As String) As DataTable
        Dim sql As String
        sql = "select count(*) as conteo " &
          "from grupo g " &
          "INNER JOIN curso c ON c.curso_id = g.curso_id " &
          "INNER JOIN docente d ON d.docente_id = g.docente_id " &
          "INNER JOIN horario h ON h.grupo_id = g.grupo_id " &
          "INNER JOIN ambiente a ON a.ambiente_id = h.ambiente_id " &
          "INNER JOIN escuela e on e.escuela_id = c.escuela_id " &
          "INNER JOIN facultad f on f.facultad_id = e.facultad_id " &
          "INNER JOIN tipo_ambiente tp on tp.tipoambiente_id = a.tipoambiente_id " &
          "where c.nombre_curso = '" & nomEsc & "' and g.denominacion = '" & nomDem & "'"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function listar_H1_1(ByVal nomEsc As String, ByVal nomDem As String) As DataTable
        Dim sql As String
        sql = "select g.grupo_id,f.facultad_id, e.escuela_id, c.ciclo, g.denominacion, g.numero_vacantes, g.estado_grupo, c.curso_id, " &
          "d.docente_id " &
          "from grupo g " &
          "INNER JOIN curso c ON c.curso_id = g.curso_id " &
          "INNER JOIN docente d ON d.docente_id = g.docente_id " &
          "INNER JOIN escuela e on e.escuela_id = c.escuela_id " &
          "INNER JOIN facultad f on f.facultad_id = e.facultad_id " &
          "where c.nombre_curso = '" & nomEsc & "' and g.denominacion = '" & nomDem & "' order by g.semestre_id desc"
        Return objConexion.consultaSQL(sql)
    End Function

    Public Function listar_H1(ByVal nomEsc As Integer, ByVal nomDem As String) As DataTable
        Dim sql As String
        sql = "select h.horario_id,g.grupo_id,f.facultad_id, e.escuela_id, c.ciclo, g.denominacion, g.numero_vacantes, g.estado_grupo, c.curso_id, " &
          "d.docente_id, tp.tipoambiente_id, a.ambiente_id, " &
          "h.dia, CONVERT(VARCHAR(5), h.h_inicio, 108) as hora_inicio, CONVERT(VARCHAR(5), h.h_final, 108) as hora_final " &
          "from grupo g " &
          "INNER JOIN curso c ON c.curso_id = g.curso_id " &
          "INNER JOIN docente d ON d.docente_id = g.docente_id " &
          "INNER JOIN horario h ON h.grupo_id = g.grupo_id " &
          "INNER JOIN ambiente a ON a.ambiente_id = h.ambiente_id " &
          "INNER JOIN escuela e on e.escuela_id = c.escuela_id " &
          "INNER JOIN facultad f on f.facultad_id = e.facultad_id " &
          "INNER JOIN tipo_ambiente tp on tp.tipoambiente_id = a.tipoambiente_id " &
          "where h.horario_id = " & nomEsc & " and g.denominacion = '" & nomDem & "' order by g.semestre_id desc"
        Return objConexion.consultaSQL(sql)
    End Function
    Public Function listar_grupo_horario(ByVal nomEsc As String, ByVal nomDem As String) As DataTable
        Dim sql As String
        sql = "SELECT 
    h.horario_id,
    g.denominacion,
    COALESCE(
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
    COALESCE(a.descripcion_ambiente, 'Ambiente no especificado') AS horario_formato
FROM 
    grupo g
INNER JOIN 
    curso c ON c.curso_id = g.curso_id
INNER JOIN 
    docente d ON d.docente_id = g.docente_id
INNER JOIN 
    horario h ON h.grupo_id = g.grupo_id
INNER JOIN 
    ambiente a ON a.ambiente_id = h.ambiente_id
where c.nombre_curso = '" & nomEsc & "' and g.denominacion = '" & nomDem & "' order by g.semestre_id desc"
        Return objConexion.consultaSQL(sql)
    End Function
End Class
