<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManAlumno
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNacimiento = New System.Windows.Forms.TextBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbxSexo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtApellidoMaterno = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbxUbigeo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtApellidoPaterno = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbxEgreso = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbxSemEgreso = New System.Windows.Forms.ComboBox()
        Me.cbxEstado = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbxSemestre = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbxEscuelaProfesiona = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.dgvAlumno = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.cbxEgreso.SuspendLayout()
        CType(Me.dgvAlumno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNacimiento)
        Me.GroupBox1.Controls.Add(Me.txtDireccion)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dtNacimiento)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbxSexo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtNombres)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtApellidoMaterno)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cbxUbigeo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbxTipoDocumento)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtDocumento)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtApellidoPaterno)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(1285, 148)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos personales:"
        '
        'txtNacimiento
        '
        Me.txtNacimiento.Location = New System.Drawing.Point(336, 108)
        Me.txtNacimiento.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNacimiento.Name = "txtNacimiento"
        Me.txtNacimiento.Size = New System.Drawing.Size(161, 22)
        Me.txtNacimiento.TabIndex = 25
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(695, 106)
        Me.txtDireccion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(324, 22)
        Me.txtDireccion.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(517, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 16)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Direccion de residencia:"
        '
        'dtNacimiento
        '
        Me.dtNacimiento.Location = New System.Drawing.Point(336, 108)
        Me.dtNacimiento.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtNacimiento.Name = "dtNacimiento"
        Me.dtNacimiento.Size = New System.Drawing.Size(161, 22)
        Me.dtNacimiento.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(181, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 16)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Fecha de nacimiento:"
        '
        'cbxSexo
        '
        Me.cbxSexo.FormattingEnabled = True
        Me.cbxSexo.Location = New System.Drawing.Point(67, 108)
        Me.cbxSexo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbxSexo.Name = "cbxSexo"
        Me.cbxSexo.Size = New System.Drawing.Size(87, 24)
        Me.cbxSexo.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 16)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Sexo:"
        '
        'txtNombres
        '
        Me.txtNombres.Location = New System.Drawing.Point(785, 65)
        Me.txtNombres.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(233, 22)
        Me.txtNombres.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(713, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 16)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Nombres:"
        '
        'txtApellidoMaterno
        '
        Me.txtApellidoMaterno.Location = New System.Drawing.Point(499, 65)
        Me.txtApellidoMaterno.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtApellidoMaterno.Name = "txtApellidoMaterno"
        Me.txtApellidoMaterno.Size = New System.Drawing.Size(187, 22)
        Me.txtApellidoMaterno.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(355, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 16)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Apellido Materno:"
        '
        'cbxUbigeo
        '
        Me.cbxUbigeo.FormattingEnabled = True
        Me.cbxUbigeo.Location = New System.Drawing.Point(784, 28)
        Me.cbxUbigeo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbxUbigeo.Name = "cbxUbigeo"
        Me.cbxUbigeo.Size = New System.Drawing.Size(235, 24)
        Me.cbxUbigeo.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo documento:"
        '
        'cbxTipoDocumento
        '
        Me.cbxTipoDocumento.FormattingEnabled = True
        Me.cbxTipoDocumento.Location = New System.Drawing.Point(152, 25)
        Me.cbxTipoDocumento.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbxTipoDocumento.Name = "cbxTipoDocumento"
        Me.cbxTipoDocumento.Size = New System.Drawing.Size(191, 24)
        Me.cbxTipoDocumento.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(355, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "N° de documento:"
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(499, 25)
        Me.txtDocumento.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDocumento.MaxLength = 8
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(187, 22)
        Me.txtDocumento.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(723, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Ubigeo:"
        '
        'txtApellidoPaterno
        '
        Me.txtApellidoPaterno.Location = New System.Drawing.Point(152, 65)
        Me.txtApellidoPaterno.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtApellidoPaterno.Name = "txtApellidoPaterno"
        Me.txtApellidoPaterno.Size = New System.Drawing.Size(191, 22)
        Me.txtApellidoPaterno.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Apellido Paterno:"
        '
        'cbxEgreso
        '
        Me.cbxEgreso.Controls.Add(Me.Label13)
        Me.cbxEgreso.Controls.Add(Me.cbxSemEgreso)
        Me.cbxEgreso.Controls.Add(Me.cbxEstado)
        Me.cbxEgreso.Controls.Add(Me.Label10)
        Me.cbxEgreso.Controls.Add(Me.cbxSemestre)
        Me.cbxEgreso.Controls.Add(Me.Label11)
        Me.cbxEgreso.Controls.Add(Me.cbxEscuelaProfesiona)
        Me.cbxEgreso.Controls.Add(Me.Label12)
        Me.cbxEgreso.Location = New System.Drawing.Point(12, 171)
        Me.cbxEgreso.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbxEgreso.Name = "cbxEgreso"
        Me.cbxEgreso.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbxEgreso.Size = New System.Drawing.Size(1285, 74)
        Me.cbxEgreso.TabIndex = 23
        Me.cbxEgreso.TabStop = False
        Me.cbxEgreso.Text = "Datos del alumno:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(979, 33)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 16)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Semestre egreso:"
        '
        'cbxSemEgreso
        '
        Me.cbxSemEgreso.FormattingEnabled = True
        Me.cbxSemEgreso.Location = New System.Drawing.Point(1108, 27)
        Me.cbxSemEgreso.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbxSemEgreso.Name = "cbxSemEgreso"
        Me.cbxSemEgreso.Size = New System.Drawing.Size(172, 24)
        Me.cbxSemEgreso.TabIndex = 13
        '
        'cbxEstado
        '
        Me.cbxEstado.FormattingEnabled = True
        Me.cbxEstado.Location = New System.Drawing.Point(785, 30)
        Me.cbxEstado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbxEstado.Name = "cbxEstado"
        Me.cbxEstado.Size = New System.Drawing.Size(187, 24)
        Me.cbxEstado.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(20, 36)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 16)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Semestre ingreso:"
        '
        'cbxSemestre
        '
        Me.cbxSemestre.FormattingEnabled = True
        Me.cbxSemestre.Location = New System.Drawing.Point(149, 30)
        Me.cbxSemestre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbxSemestre.Name = "cbxSemestre"
        Me.cbxSemestre.Size = New System.Drawing.Size(191, 24)
        Me.cbxSemestre.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(355, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(129, 16)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Escuela profesional:"
        '
        'cbxEscuelaProfesiona
        '
        Me.cbxEscuelaProfesiona.FormattingEnabled = True
        Me.cbxEscuelaProfesiona.Location = New System.Drawing.Point(499, 30)
        Me.cbxEscuelaProfesiona.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbxEscuelaProfesiona.Name = "cbxEscuelaProfesiona"
        Me.cbxEscuelaProfesiona.Size = New System.Drawing.Size(187, 24)
        Me.cbxEscuelaProfesiona.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(725, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 16)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Estado:"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(1219, 258)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 34)
        Me.btnSalir.TabIndex = 29
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(371, 258)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(83, 34)
        Me.btnCancelar.TabIndex = 28
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(277, 258)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(88, 34)
        Me.btnEliminar.TabIndex = 27
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(181, 258)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(89, 34)
        Me.btnModificar.TabIndex = 26
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(12, 258)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 34)
        Me.btnNuevo.TabIndex = 25
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(93, 258)
        Me.btnGrabar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(83, 34)
        Me.btnGrabar.TabIndex = 24
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'dgvAlumno
        '
        Me.dgvAlumno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAlumno.Location = New System.Drawing.Point(12, 308)
        Me.dgvAlumno.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvAlumno.Name = "dgvAlumno"
        Me.dgvAlumno.RowHeadersWidth = 51
        Me.dgvAlumno.RowTemplate.Height = 24
        Me.dgvAlumno.Size = New System.Drawing.Size(1285, 313)
        Me.dgvAlumno.TabIndex = 30
        '
        'frmManAlumno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1309, 633)
        Me.Controls.Add(Me.dgvAlumno)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.cbxEgreso)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmManAlumno"
        Me.Text = "frmManAlumno"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.cbxEgreso.ResumeLayout(False)
        Me.cbxEgreso.PerformLayout()
        CType(Me.dgvAlumno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents txtNombres As Windows.Forms.TextBox
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents txtApellidoMaterno As Windows.Forms.TextBox
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents cbxUbigeo As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents cbxTipoDocumento As Windows.Forms.ComboBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtDocumento As Windows.Forms.TextBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents txtApellidoPaterno As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents cbxSexo As Windows.Forms.ComboBox
    Friend WithEvents dtNacimiento As Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents txtDireccion As Windows.Forms.TextBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents cbxEgreso As Windows.Forms.GroupBox
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents cbxSemestre As Windows.Forms.ComboBox
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents cbxEscuelaProfesiona As Windows.Forms.ComboBox
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents btnSalir As Windows.Forms.Button
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents btnEliminar As Windows.Forms.Button
    Friend WithEvents btnModificar As Windows.Forms.Button
    Friend WithEvents btnNuevo As Windows.Forms.Button
    Friend WithEvents btnGrabar As Windows.Forms.Button
    Friend WithEvents dgvAlumno As Windows.Forms.DataGridView
    Friend WithEvents cbxEstado As Windows.Forms.ComboBox
    Friend WithEvents txtNacimiento As Windows.Forms.TextBox
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents cbxSemEgreso As Windows.Forms.ComboBox
End Class
