Imports Proyecto_Datos

Public Class PlanEstudio
    Private objConexion As New clsConexionSQL
    Private objPlanEstudio As New ADO_PlanEstudio
    Public Function listar_planes_tabla() As DataTable
        Try
            Dim sql As String
            sql = " select plan_id,descripcion,
                    CASE estado WHEN 1 THEN 'Vigente' ELSE 'No Vigente' END AS estado 
                    from plan_estudio"
            Return objConexion.consultaSQL(sql)
        Catch ex As Exception

        End Try
    End Function
    Public Function listar_planes() As DataTable
        Try
            Dim sql As String
            sql = " select plan_id
                    from plan_estudio"
            Return objConexion.consultaSQL(sql)
        Catch ex As Exception

        End Try

    End Function

    Public Function buscarIdPlan(ByVal idPlan As Integer) As Integer
        Dim idPlanRet As Integer = 0
        Try
            Dim sql As String
            sql = "select plan_id from plan_estudio where plan_id = " & idPlan
            Dim result As DataTable = objConexion.consultaSQL(sql)

            If result.Rows.Count > 0 Then
                idPlanRet = Convert.ToInt32(result.Rows(0)(0))
            End If
            Return idPlanRet
        Catch ex As Exception

        End Try
    End Function
    Public Function agregar_planEstudio(ByVal idPlan As Integer, ByVal desc As String, ByVal estado As Boolean) As Integer
        Try
            Return objPlanEstudio.pa_agregar_planEstudio(idPlan, desc, estado)
        Catch ex As Exception

        End Try
    End Function

    Public Function modificar_planEstudio(ByVal idPlan As Integer, ByVal desc As String, ByVal estado As Boolean) As Integer
        Dim r As Integer
        Try
            r = objPlanEstudio.pa_modificar_planEstudio(idPlan, desc, estado)
            Return r
        Catch ex As Exception
            Return r
        End Try
    End Function

    Public Function eliminar_planEstudio(ByVal idPlan As Integer) As Integer
        Dim r As Integer
        Try
            r = objPlanEstudio.pa_eliminar_planEstudio(idPlan)
            Return r
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
End Class
