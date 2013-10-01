<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Configuracion
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
        Me.btn_Setear_FyH = New System.Windows.Forms.Button
        Me.btn_Calibracion_Temperatura = New System.Windows.Forms.Button
        Me.btn_Calibracion_Conductividad = New System.Windows.Forms.Button
        Me.btn_Ajustar_Parametros = New System.Windows.Forms.Button
        Me.grp_Calibracion = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_Volver = New System.Windows.Forms.Button
        Me.grp_Calibracion.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Setear_FyH
        '
        Me.btn_Setear_FyH.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Setear_FyH.Location = New System.Drawing.Point(24, 79)
        Me.btn_Setear_FyH.Name = "btn_Setear_FyH"
        Me.btn_Setear_FyH.Size = New System.Drawing.Size(163, 48)
        Me.btn_Setear_FyH.TabIndex = 11
        Me.btn_Setear_FyH.Text = "Ajustar Fecha y Hora"
        Me.btn_Setear_FyH.UseVisualStyleBackColor = True
        '
        'btn_Calibracion_Temperatura
        '
        Me.btn_Calibracion_Temperatura.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Calibracion_Temperatura.Location = New System.Drawing.Point(20, 79)
        Me.btn_Calibracion_Temperatura.Name = "btn_Calibracion_Temperatura"
        Me.btn_Calibracion_Temperatura.Size = New System.Drawing.Size(163, 48)
        Me.btn_Calibracion_Temperatura.TabIndex = 10
        Me.btn_Calibracion_Temperatura.Text = "Calibración Temperatura"
        Me.btn_Calibracion_Temperatura.UseVisualStyleBackColor = True
        '
        'btn_Calibracion_Conductividad
        '
        Me.btn_Calibracion_Conductividad.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Calibracion_Conductividad.Location = New System.Drawing.Point(20, 25)
        Me.btn_Calibracion_Conductividad.Name = "btn_Calibracion_Conductividad"
        Me.btn_Calibracion_Conductividad.Size = New System.Drawing.Size(163, 48)
        Me.btn_Calibracion_Conductividad.TabIndex = 9
        Me.btn_Calibracion_Conductividad.Text = "Calibración Conductividad"
        Me.btn_Calibracion_Conductividad.UseVisualStyleBackColor = True
        '
        'btn_Ajustar_Parametros
        '
        Me.btn_Ajustar_Parametros.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Ajustar_Parametros.Location = New System.Drawing.Point(24, 25)
        Me.btn_Ajustar_Parametros.Name = "btn_Ajustar_Parametros"
        Me.btn_Ajustar_Parametros.Size = New System.Drawing.Size(163, 48)
        Me.btn_Ajustar_Parametros.TabIndex = 12
        Me.btn_Ajustar_Parametros.Text = "Ajustar Parámetros"
        Me.btn_Ajustar_Parametros.UseVisualStyleBackColor = True
        '
        'grp_Calibracion
        '
        Me.grp_Calibracion.Controls.Add(Me.btn_Calibracion_Temperatura)
        Me.grp_Calibracion.Controls.Add(Me.btn_Calibracion_Conductividad)
        Me.grp_Calibracion.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_Calibracion.Location = New System.Drawing.Point(25, 26)
        Me.grp_Calibracion.Name = "grp_Calibracion"
        Me.grp_Calibracion.Size = New System.Drawing.Size(206, 137)
        Me.grp_Calibracion.TabIndex = 13
        Me.grp_Calibracion.TabStop = False
        Me.grp_Calibracion.Text = "Calibración"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_Ajustar_Parametros)
        Me.GroupBox1.Controls.Add(Me.btn_Setear_FyH)
        Me.GroupBox1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(270, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(206, 137)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ajuste de Parámetros"
        '
        'btn_Volver
        '
        Me.btn_Volver.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Volver.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Volver.Location = New System.Drawing.Point(201, 186)
        Me.btn_Volver.Name = "btn_Volver"
        Me.btn_Volver.Size = New System.Drawing.Size(97, 32)
        Me.btn_Volver.TabIndex = 16
        Me.btn_Volver.Text = "<< Volver"
        Me.btn_Volver.UseVisualStyleBackColor = True
        '
        'frm_Configuracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn_Volver
        Me.ClientSize = New System.Drawing.Size(488, 230)
        Me.Controls.Add(Me.btn_Volver)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grp_Calibracion)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Configuracion"
        Me.Text = "Configuracion del Equipo TSK100"
        Me.grp_Calibracion.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Setear_FyH As System.Windows.Forms.Button
    Friend WithEvents btn_Calibracion_Temperatura As System.Windows.Forms.Button
    Friend WithEvents btn_Calibracion_Conductividad As System.Windows.Forms.Button
    Friend WithEvents btn_Ajustar_Parametros As System.Windows.Forms.Button
    Friend WithEvents grp_Calibracion As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Volver As System.Windows.Forms.Button
End Class
