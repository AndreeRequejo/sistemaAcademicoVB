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

End Class
