<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManCurso
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.cbxPlanEstudio = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdbObligatorio = New System.Windows.Forms.RadioButton()
        Me.cbxCiclo = New System.Windows.Forms.ComboBox()
        Me.lblCreditos = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.spPractica = New System.Windows.Forms.NumericUpDown()
        Me.txtNomCurso = New System.Windows.Forms.TextBox()
        Me.spTeoria = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCodCurso = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbxEscuela = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvCurso = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.spPractica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spTeoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCurso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(1053, 196)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(100, 34)
        Me.btnSalir.TabIndex = 21
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(444, 196)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(100, 34)
        Me.btnEliminar.TabIndex = 20
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(336, 196)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(100, 34)
        Me.btnModificar.TabIndex = 19
        Me.btnModificar.Text = "Modiifcar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(228, 196)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 34)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(121, 196)
        Me.btnGrabar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(100, 34)
        Me.btnGrabar.TabIndex = 17
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(13, 196)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(100, 34)
        Me.btnNuevo.TabIndex = 16
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'cbxPlanEstudio
        '
        Me.cbxPlanEstudio.FormattingEnabled = True
        Me.cbxPlanEstudio.Location = New System.Drawing.Point(156, 18)
        Me.cbxPlanEstudio.Margin = New System.Windows.Forms.Padding(4)
        Me.cbxPlanEstudio.Name = "cbxPlanEstudio"
        Me.cbxPlanEstudio.Size = New System.Drawing.Size(124, 24)
        Me.cbxPlanEstudio.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(19, 18)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(167, 25)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Plan de Estudios"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbObligatorio)
        Me.GroupBox1.Controls.Add(Me.cbxCiclo)
        Me.GroupBox1.Controls.Add(Me.lblCreditos)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.spPractica)
        Me.GroupBox1.Controls.Add(Me.txtNomCurso)
        Me.GroupBox1.Controls.Add(Me.spTeoria)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtCodCurso)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 63)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1141, 113)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Informacion general del curso"
        '
        'rdbObligatorio
        '
        Me.rdbObligatorio.AutoSize = True
        Me.rdbObligatorio.Location = New System.Drawing.Point(143, 70)
        Me.rdbObligatorio.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdbObligatorio.Name = "rdbObligatorio"
        Me.rdbObligatorio.Size = New System.Drawing.Size(102, 20)
        Me.rdbObligatorio.TabIndex = 17
        Me.rdbObligatorio.TabStop = True
        Me.rdbObligatorio.Text = "Obligatorio *"
        Me.rdbObligatorio.UseVisualStyleBackColor = True
        '
        'cbxCiclo
        '
        Me.cbxCiclo.FormattingEnabled = True
        Me.cbxCiclo.Location = New System.Drawing.Point(1008, 27)
        Me.cbxCiclo.Margin = New System.Windows.Forms.Padding(4)
        Me.cbxCiclo.Name = "cbxCiclo"
        Me.cbxCiclo.Size = New System.Drawing.Size(91, 24)
        Me.cbxCiclo.TabIndex = 16
        '
        'lblCreditos
        '
        Me.lblCreditos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCreditos.Location = New System.Drawing.Point(1008, 68)
        Me.lblCreditos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCreditos.Name = "lblCreditos"
        Me.lblCreditos.Size = New System.Drawing.Size(91, 25)
        Me.lblCreditos.TabIndex = 14
        Me.lblCreditos.Text = "0"
        Me.lblCreditos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(24, 66)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(157, 25)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Tipo Curso:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(951, 28)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 25)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Ciclo:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'spPractica
        '
        Me.spPractica.Location = New System.Drawing.Point(733, 71)
        Me.spPractica.Margin = New System.Windows.Forms.Padding(4)
        Me.spPractica.Name = "spPractica"
        Me.spPractica.Size = New System.Drawing.Size(109, 22)
        Me.spPractica.TabIndex = 12
        '
        'txtNomCurso
        '
        Me.txtNomCurso.Location = New System.Drawing.Point(436, 30)
        Me.txtNomCurso.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNomCurso.Name = "txtNomCurso"
        Me.txtNomCurso.Size = New System.Drawing.Size(408, 22)
        Me.txtNomCurso.TabIndex = 4
        '
        'spTeoria
        '
        Me.spTeoria.Location = New System.Drawing.Point(436, 70)
        Me.spTeoria.Margin = New System.Windows.Forms.Padding(4)
        Me.spTeoria.Name = "spTeoria"
        Me.spTeoria.Size = New System.Drawing.Size(109, 22)
        Me.spTeoria.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(295, 26)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 28)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Nombre Curso"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(880, 68)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 25)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Numero Créditos"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodCurso
        '
        Me.txtCodCurso.Location = New System.Drawing.Point(143, 30)
        Me.txtCodCurso.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodCurso.Name = "txtCodCurso"
        Me.txtCodCurso.Size = New System.Drawing.Size(124, 22)
        Me.txtCodCurso.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(24, 27)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 26)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Codigo Curso"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(295, 66)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 25)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Horas Teoría:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(605, 69)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 25)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Horas Prácticas:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxEscuela
        '
        Me.cbxEscuela.FormattingEnabled = True
        Me.cbxEscuela.Location = New System.Drawing.Point(449, 18)
        Me.cbxEscuela.Margin = New System.Windows.Forms.Padding(4)
        Me.cbxEscuela.Name = "cbxEscuela"
        Me.cbxEscuela.Size = New System.Drawing.Size(408, 24)
        Me.cbxEscuela.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(308, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 25)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Escuela Profesional"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvCurso
        '
        Me.dgvCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCurso.Location = New System.Drawing.Point(11, 238)
        Me.dgvCurso.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvCurso.Name = "dgvCurso"
        Me.dgvCurso.RowHeadersWidth = 51
        Me.dgvCurso.RowTemplate.Height = 24
        Me.dgvCurso.Size = New System.Drawing.Size(1143, 373)
        Me.dgvCurso.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(771, 178)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(341, 16)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "* Si el curso no se marca como obligatorio será electivo."
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(930, 197)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(116, 33)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "Prerequisitos"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmManCurso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1165, 617)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgvCurso)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.cbxPlanEstudio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cbxEscuela)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmManCurso"
        Me.Text = "Mantenimiento Curso"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.spPractica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spTeoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCurso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSalir As Windows.Forms.Button
    Friend WithEvents btnEliminar As Windows.Forms.Button
    Friend WithEvents btnModificar As Windows.Forms.Button
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents btnGrabar As Windows.Forms.Button
    Friend WithEvents btnNuevo As Windows.Forms.Button
    Friend WithEvents cbxPlanEstudio As Windows.Forms.ComboBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents cbxCiclo As Windows.Forms.ComboBox
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents lblCreditos As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents spPractica As Windows.Forms.NumericUpDown
    Friend WithEvents spTeoria As Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents txtNomCurso As Windows.Forms.TextBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents txtCodCurso As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents cbxEscuela As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents dgvCurso As Windows.Forms.DataGridView
    Friend WithEvents rdbObligatorio As Windows.Forms.RadioButton
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
End Class
