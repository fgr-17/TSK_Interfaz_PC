<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TSK100_Interfaz
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
        Me.components = New System.ComponentModel.Container
        Me.btn_Inicializar_Comunicacion = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbl_horario = New System.Windows.Forms.Label
        Me.lbl_fecha = New System.Windows.Forms.Label
        Me.lbl_rot_horario = New System.Windows.Forms.Label
        Me.lbl_rot_fecha = New System.Windows.Forms.Label
        Me.lbl_conexion = New System.Windows.Forms.Label
        Me.lbl_rot_conexion = New System.Windows.Forms.Label
        Me.btn_Configuracion = New System.Windows.Forms.Button
        Me.btn_Iniciar_Adquisicion = New System.Windows.Forms.Button
        Me.btn_Obtener_Datos = New System.Windows.Forms.Button
        Me.timer_horario = New System.Windows.Forms.Timer(Me.components)
        Me.btn_Reiniciar_Equipo = New System.Windows.Forms.Button
        Me.btn_Conectar_Slave = New System.Windows.Forms.Button
        Me.Img_Estado = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.Img_Estado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Inicializar_Comunicacion
        '
        Me.btn_Inicializar_Comunicacion.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Inicializar_Comunicacion.Location = New System.Drawing.Point(38, 17)
        Me.btn_Inicializar_Comunicacion.Name = "btn_Inicializar_Comunicacion"
        Me.btn_Inicializar_Comunicacion.Size = New System.Drawing.Size(185, 42)
        Me.btn_Inicializar_Comunicacion.TabIndex = 0
        Me.btn_Inicializar_Comunicacion.Text = "Inicializar Comunicación"
        Me.btn_Inicializar_Comunicacion.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_horario)
        Me.GroupBox1.Controls.Add(Me.lbl_fecha)
        Me.GroupBox1.Controls.Add(Me.lbl_rot_horario)
        Me.GroupBox1.Controls.Add(Me.lbl_rot_fecha)
        Me.GroupBox1.Controls.Add(Me.lbl_conexion)
        Me.GroupBox1.Controls.Add(Me.lbl_rot_conexion)
        Me.GroupBox1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(267, 130)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(369, 137)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estado del Equipo"
        '
        'lbl_horario
        '
        Me.lbl_horario.AutoSize = True
        Me.lbl_horario.Location = New System.Drawing.Point(130, 98)
        Me.lbl_horario.Name = "lbl_horario"
        Me.lbl_horario.Size = New System.Drawing.Size(0, 19)
        Me.lbl_horario.TabIndex = 7
        '
        'lbl_fecha
        '
        Me.lbl_fecha.AutoSize = True
        Me.lbl_fecha.Location = New System.Drawing.Point(130, 69)
        Me.lbl_fecha.Name = "lbl_fecha"
        Me.lbl_fecha.Size = New System.Drawing.Size(0, 19)
        Me.lbl_fecha.TabIndex = 6
        '
        'lbl_rot_horario
        '
        Me.lbl_rot_horario.AutoSize = True
        Me.lbl_rot_horario.Location = New System.Drawing.Point(11, 98)
        Me.lbl_rot_horario.Name = "lbl_rot_horario"
        Me.lbl_rot_horario.Size = New System.Drawing.Size(48, 19)
        Me.lbl_rot_horario.TabIndex = 5
        Me.lbl_rot_horario.Text = "Hora:"
        '
        'lbl_rot_fecha
        '
        Me.lbl_rot_fecha.AutoSize = True
        Me.lbl_rot_fecha.Location = New System.Drawing.Point(11, 69)
        Me.lbl_rot_fecha.Name = "lbl_rot_fecha"
        Me.lbl_rot_fecha.Size = New System.Drawing.Size(57, 19)
        Me.lbl_rot_fecha.TabIndex = 4
        Me.lbl_rot_fecha.Text = "Fecha :"
        '
        'lbl_conexion
        '
        Me.lbl_conexion.AutoSize = True
        Me.lbl_conexion.Location = New System.Drawing.Point(130, 37)
        Me.lbl_conexion.Name = "lbl_conexion"
        Me.lbl_conexion.Size = New System.Drawing.Size(124, 19)
        Me.lbl_conexion.TabIndex = 2
        Me.lbl_conexion.Text = "DESCONECTADO"
        '
        'lbl_rot_conexion
        '
        Me.lbl_rot_conexion.AutoSize = True
        Me.lbl_rot_conexion.Location = New System.Drawing.Point(11, 37)
        Me.lbl_rot_conexion.Name = "lbl_rot_conexion"
        Me.lbl_rot_conexion.Size = New System.Drawing.Size(78, 19)
        Me.lbl_rot_conexion.TabIndex = 0
        Me.lbl_rot_conexion.Text = "Conexión:"
        '
        'btn_Configuracion
        '
        Me.btn_Configuracion.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Configuracion.Location = New System.Drawing.Point(38, 176)
        Me.btn_Configuracion.Name = "btn_Configuracion"
        Me.btn_Configuracion.Size = New System.Drawing.Size(160, 42)
        Me.btn_Configuracion.TabIndex = 4
        Me.btn_Configuracion.Text = "Configuración"
        Me.btn_Configuracion.UseVisualStyleBackColor = True
        '
        'btn_Iniciar_Adquisicion
        '
        Me.btn_Iniciar_Adquisicion.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Iniciar_Adquisicion.Location = New System.Drawing.Point(38, 272)
        Me.btn_Iniciar_Adquisicion.Name = "btn_Iniciar_Adquisicion"
        Me.btn_Iniciar_Adquisicion.Size = New System.Drawing.Size(160, 42)
        Me.btn_Iniciar_Adquisicion.TabIndex = 9
        Me.btn_Iniciar_Adquisicion.Text = "Iniciar adquisición"
        Me.btn_Iniciar_Adquisicion.UseVisualStyleBackColor = True
        '
        'btn_Obtener_Datos
        '
        Me.btn_Obtener_Datos.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Obtener_Datos.Location = New System.Drawing.Point(38, 224)
        Me.btn_Obtener_Datos.Name = "btn_Obtener_Datos"
        Me.btn_Obtener_Datos.Size = New System.Drawing.Size(160, 42)
        Me.btn_Obtener_Datos.TabIndex = 7
        Me.btn_Obtener_Datos.Text = "Obtener Datos"
        Me.btn_Obtener_Datos.UseVisualStyleBackColor = True
        '
        'timer_horario
        '
        Me.timer_horario.Interval = 500
        '
        'btn_Reiniciar_Equipo
        '
        Me.btn_Reiniciar_Equipo.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Reiniciar_Equipo.Location = New System.Drawing.Point(38, 128)
        Me.btn_Reiniciar_Equipo.Name = "btn_Reiniciar_Equipo"
        Me.btn_Reiniciar_Equipo.Size = New System.Drawing.Size(160, 42)
        Me.btn_Reiniciar_Equipo.TabIndex = 10
        Me.btn_Reiniciar_Equipo.Text = "Reiniciar equipo"
        Me.btn_Reiniciar_Equipo.UseVisualStyleBackColor = True
        '
        'btn_Conectar_Slave
        '
        Me.btn_Conectar_Slave.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Conectar_Slave.Location = New System.Drawing.Point(38, 65)
        Me.btn_Conectar_Slave.Name = "btn_Conectar_Slave"
        Me.btn_Conectar_Slave.Size = New System.Drawing.Size(185, 42)
        Me.btn_Conectar_Slave.TabIndex = 11
        Me.btn_Conectar_Slave.Text = "Conectar Slave"
        Me.btn_Conectar_Slave.UseVisualStyleBackColor = True
        '
        'Img_Estado
        '
        Me.Img_Estado.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Img_Estado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Img_Estado.Image = Global.WindowsApplication1.My.Resources.Resources.TSK100_CONFIGURACION_DESCONECTADO
        Me.Img_Estado.InitialImage = Global.WindowsApplication1.My.Resources.Resources.TSK100_CONFIGURACION_DESCONECTADO
        Me.Img_Estado.Location = New System.Drawing.Point(267, 17)
        Me.Img_Estado.Name = "Img_Estado"
        Me.Img_Estado.Size = New System.Drawing.Size(369, 96)
        Me.Img_Estado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Img_Estado.TabIndex = 1
        Me.Img_Estado.TabStop = False
        '
        'TSK100_Interfaz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 326)
        Me.Controls.Add(Me.btn_Conectar_Slave)
        Me.Controls.Add(Me.btn_Reiniciar_Equipo)
        Me.Controls.Add(Me.btn_Iniciar_Adquisicion)
        Me.Controls.Add(Me.btn_Obtener_Datos)
        Me.Controls.Add(Me.btn_Configuracion)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Img_Estado)
        Me.Controls.Add(Me.btn_Inicializar_Comunicacion)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TSK100_Interfaz"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Interfaz de usuario - TSK100"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Img_Estado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Img_Estado As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_rot_conexion As System.Windows.Forms.Label
    Friend WithEvents lbl_conexion As System.Windows.Forms.Label
    Friend WithEvents lbl_rot_fecha As System.Windows.Forms.Label
    Friend WithEvents lbl_rot_horario As System.Windows.Forms.Label
    Public WithEvents lbl_fecha As System.Windows.Forms.Label
    Public WithEvents lbl_horario As System.Windows.Forms.Label
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents btn_Inicializar_Comunicacion As System.Windows.Forms.Button
    Friend WithEvents btn_Configuracion As System.Windows.Forms.Button
    Friend WithEvents btn_Iniciar_Adquisicion As System.Windows.Forms.Button
    Friend WithEvents btn_Obtener_Datos As System.Windows.Forms.Button
    Friend WithEvents timer_horario As System.Windows.Forms.Timer
    Friend WithEvents btn_Reiniciar_Equipo As System.Windows.Forms.Button
    Public WithEvents btn_Conectar_Slave As System.Windows.Forms.Button

End Class
