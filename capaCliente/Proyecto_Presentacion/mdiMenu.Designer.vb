<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mdiMenu
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mdiMenu))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintPreviewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MantenimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantenimientoDeSemestreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CursoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantenimientoDePrerequisitosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantenimientoDeAmbienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacultadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EscuelaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantenimientoDeDocenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantenimientoDeAlumnoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantenimientoDePlanDeEstudioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantenimientoDeUbigeoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantenimientoDeTipoAmbienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransaccionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDeGrupoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDeHorariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ProcesoDeMatriculaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasYReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.OpenToolStripButton, Me.SaveToolStripButton, Me.ToolStripSeparator1, Me.PrintToolStripButton, Me.PrintPreviewToolStripButton, Me.ToolStripSeparator2, Me.HelpToolStripButton})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(632, 27)
        Me.ToolStrip.TabIndex = 6
        Me.ToolStrip.Text = "ToolStrip"
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.NewToolStripButton.Text = "Nuevo"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.OpenToolStripButton.Text = "Abrir"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.SaveToolStripButton.Text = "Guardar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.PrintToolStripButton.Text = "Imprimir"
        '
        'PrintPreviewToolStripButton
        '
        Me.PrintPreviewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintPreviewToolStripButton.Image = CType(resources.GetObject("PrintPreviewToolStripButton.Image"), System.Drawing.Image)
        Me.PrintPreviewToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.PrintPreviewToolStripButton.Name = "PrintPreviewToolStripButton"
        Me.PrintPreviewToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.PrintPreviewToolStripButton.Text = "Vista previa de impresión"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"), System.Drawing.Image)
        Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        Me.HelpToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.HelpToolStripButton.Text = "Ayuda"
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 431)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(632, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(42, 17)
        Me.ToolStripStatusLabel.Text = "Estado"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MantenimientoToolStripMenuItem, Me.TransaccionesToolStripMenuItem, Me.ConsultasYReportesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(632, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MantenimientoToolStripMenuItem
        '
        Me.MantenimientoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MantenimientoDeSemestreToolStripMenuItem, Me.CursoToolStripMenuItem, Me.MantenimientoDePrerequisitosToolStripMenuItem, Me.MantenimientoDeAmbienteToolStripMenuItem, Me.FacultadToolStripMenuItem, Me.EscuelaToolStripMenuItem, Me.MantenimientoDeDocenteToolStripMenuItem, Me.MantenimientoDeAlumnoToolStripMenuItem, Me.MantenimientoDePlanDeEstudioToolStripMenuItem, Me.MantenimientoDeUbigeoToolStripMenuItem, Me.MantenimientoDeTipoAmbienteToolStripMenuItem})
        Me.MantenimientoToolStripMenuItem.Name = "MantenimientoToolStripMenuItem"
        Me.MantenimientoToolStripMenuItem.Size = New System.Drawing.Size(101, 20)
        Me.MantenimientoToolStripMenuItem.Text = "Mantenimiento"
        '
        'MantenimientoDeSemestreToolStripMenuItem
        '
        Me.MantenimientoDeSemestreToolStripMenuItem.Name = "MantenimientoDeSemestreToolStripMenuItem"
        Me.MantenimientoDeSemestreToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.MantenimientoDeSemestreToolStripMenuItem.Text = "Mantenimiento de Semestre"
        '
        'CursoToolStripMenuItem
        '
        Me.CursoToolStripMenuItem.Name = "CursoToolStripMenuItem"
        Me.CursoToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.CursoToolStripMenuItem.Text = "Mantenimiento de Curso"
        '
        'MantenimientoDePrerequisitosToolStripMenuItem
        '
        Me.MantenimientoDePrerequisitosToolStripMenuItem.Name = "MantenimientoDePrerequisitosToolStripMenuItem"
        Me.MantenimientoDePrerequisitosToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.MantenimientoDePrerequisitosToolStripMenuItem.Text = "Mantenimiento de Prerequisitos"
        '
        'MantenimientoDeAmbienteToolStripMenuItem
        '
        Me.MantenimientoDeAmbienteToolStripMenuItem.Name = "MantenimientoDeAmbienteToolStripMenuItem"
        Me.MantenimientoDeAmbienteToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.MantenimientoDeAmbienteToolStripMenuItem.Text = "Mantenimiento de Ambiente"
        '
        'FacultadToolStripMenuItem
        '
        Me.FacultadToolStripMenuItem.Name = "FacultadToolStripMenuItem"
        Me.FacultadToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.FacultadToolStripMenuItem.Text = "Mantenimiento de Facultad"
        '
        'EscuelaToolStripMenuItem
        '
        Me.EscuelaToolStripMenuItem.Name = "EscuelaToolStripMenuItem"
        Me.EscuelaToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.EscuelaToolStripMenuItem.Text = "Mantenimiento de Escuela"
        '
        'MantenimientoDeDocenteToolStripMenuItem
        '
        Me.MantenimientoDeDocenteToolStripMenuItem.Name = "MantenimientoDeDocenteToolStripMenuItem"
        Me.MantenimientoDeDocenteToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.MantenimientoDeDocenteToolStripMenuItem.Text = "Mantenimiento de Docente"
        '
        'MantenimientoDeAlumnoToolStripMenuItem
        '
        Me.MantenimientoDeAlumnoToolStripMenuItem.Name = "MantenimientoDeAlumnoToolStripMenuItem"
        Me.MantenimientoDeAlumnoToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.MantenimientoDeAlumnoToolStripMenuItem.Text = "Mantenimiento de Alumno"
        '
        'MantenimientoDePlanDeEstudioToolStripMenuItem
        '
        Me.MantenimientoDePlanDeEstudioToolStripMenuItem.Name = "MantenimientoDePlanDeEstudioToolStripMenuItem"
        Me.MantenimientoDePlanDeEstudioToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.MantenimientoDePlanDeEstudioToolStripMenuItem.Text = "Mantenimiento de Plan de estudio"
        '
        'MantenimientoDeUbigeoToolStripMenuItem
        '
        Me.MantenimientoDeUbigeoToolStripMenuItem.Name = "MantenimientoDeUbigeoToolStripMenuItem"
        Me.MantenimientoDeUbigeoToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.MantenimientoDeUbigeoToolStripMenuItem.Text = "Mantenimiento de Ubigeo"
        '
        'MantenimientoDeTipoAmbienteToolStripMenuItem
        '
        Me.MantenimientoDeTipoAmbienteToolStripMenuItem.Name = "MantenimientoDeTipoAmbienteToolStripMenuItem"
        Me.MantenimientoDeTipoAmbienteToolStripMenuItem.Size = New System.Drawing.Size(256, 22)
        Me.MantenimientoDeTipoAmbienteToolStripMenuItem.Text = "Mantenimiento de Tipo Ambiente"
        '
        'TransaccionesToolStripMenuItem
        '
        Me.TransaccionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistroDeGrupoToolStripMenuItem, Me.RegistroDeHorariosToolStripMenuItem, Me.ToolStripMenuItem1, Me.ProcesoDeMatriculaToolStripMenuItem})
        Me.TransaccionesToolStripMenuItem.Name = "TransaccionesToolStripMenuItem"
        Me.TransaccionesToolStripMenuItem.Size = New System.Drawing.Size(92, 20)
        Me.TransaccionesToolStripMenuItem.Text = "Transacciones"
        '
        'RegistroDeGrupoToolStripMenuItem
        '
        Me.RegistroDeGrupoToolStripMenuItem.Name = "RegistroDeGrupoToolStripMenuItem"
        Me.RegistroDeGrupoToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.RegistroDeGrupoToolStripMenuItem.Text = "Registro de grupo"
        '
        'RegistroDeHorariosToolStripMenuItem
        '
        Me.RegistroDeHorariosToolStripMenuItem.Name = "RegistroDeHorariosToolStripMenuItem"
        Me.RegistroDeHorariosToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.RegistroDeHorariosToolStripMenuItem.Text = "Registro de horarios"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(182, 6)
        '
        'ProcesoDeMatriculaToolStripMenuItem
        '
        Me.ProcesoDeMatriculaToolStripMenuItem.Name = "ProcesoDeMatriculaToolStripMenuItem"
        Me.ProcesoDeMatriculaToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ProcesoDeMatriculaToolStripMenuItem.Text = "Proceso de Matricula"
        '
        'ConsultasYReportesToolStripMenuItem
        '
        Me.ConsultasYReportesToolStripMenuItem.Name = "ConsultasYReportesToolStripMenuItem"
        Me.ConsultasYReportesToolStripMenuItem.Size = New System.Drawing.Size(126, 20)
        Me.ConsultasYReportesToolStripMenuItem.Text = "Consultas y reportes"
        '
        'mdiMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.Name = "mdiMenu"
        Me.Text = "MDIParent1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HelpToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintPreviewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuStrip1 As Windows.Forms.MenuStrip
    Friend WithEvents MantenimientoToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacultadToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents EscuelaToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents CursoToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransaccionesToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistroDeGrupoToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistroDeHorariosToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ProcesoDeMatriculaToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasYReportesToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MantenimientoDeAlumnoToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MantenimientoDeSemestreToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MantenimientoDePrerequisitosToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MantenimientoDeAmbienteToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MantenimientoDeDocenteToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MantenimientoDePlanDeEstudioToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MantenimientoDeUbigeoToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MantenimientoDeTipoAmbienteToolStripMenuItem As Windows.Forms.ToolStripMenuItem
End Class
