<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Calibracion_Temperatura
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lbl_unidad_cuentas = New System.Windows.Forms.Label
        Me.lbl_ADC_Medido = New System.Windows.Forms.Label
        Me.lbl_Valor_del_ADC_Medido = New System.Windows.Forms.Label
        Me.lbl_Resistencia_Medida = New System.Windows.Forms.Label
        Me.lbl_unidad_ohm_0 = New System.Windows.Forms.Label
        Me.lbl_rotulo_Resistencia_Medida = New System.Windows.Forms.Label
        Me.btn_Cancelar = New System.Windows.Forms.Button
        Me.btn_Calibrar = New System.Windows.Forms.Button
        Me.lbl_Valor_Alto_Adquirido = New System.Windows.Forms.Label
        Me.btn_Valor_Alto_Ingresado = New System.Windows.Forms.Button
        Me.lbl_rotulo_res_valor_Alto = New System.Windows.Forms.Label
        Me.txt_Valor_Alto_Ingresado = New System.Windows.Forms.TextBox
        Me.lbl_Valor_Bajo_Adquirido = New System.Windows.Forms.Label
        Me.btn_Valor_Bajo_Ingresado = New System.Windows.Forms.Button
        Me.lbl_rotulo_res_valor_bajo = New System.Windows.Forms.Label
        Me.txt_Valor_Bajo_Ingresado = New System.Windows.Forms.TextBox
        Me.timer_temperatura = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_unidad_cuentas_1 = New System.Windows.Forms.Label
        Me.lbl_unidad_cuentas_2 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lbl_unidad_cuentas)
        Me.Panel1.Controls.Add(Me.lbl_ADC_Medido)
        Me.Panel1.Controls.Add(Me.lbl_Valor_del_ADC_Medido)
        Me.Panel1.Controls.Add(Me.lbl_Resistencia_Medida)
        Me.Panel1.Controls.Add(Me.lbl_unidad_ohm_0)
        Me.Panel1.Controls.Add(Me.lbl_rotulo_Resistencia_Medida)
        Me.Panel1.Location = New System.Drawing.Point(180, 189)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(397, 129)
        Me.Panel1.TabIndex = 28
        '
        'lbl_unidad_cuentas
        '
        Me.lbl_unidad_cuentas.AutoSize = True
        Me.lbl_unidad_cuentas.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_unidad_cuentas.Location = New System.Drawing.Point(306, 26)
        Me.lbl_unidad_cuentas.Name = "lbl_unidad_cuentas"
        Me.lbl_unidad_cuentas.Size = New System.Drawing.Size(74, 19)
        Me.lbl_unidad_cuentas.TabIndex = 5
        Me.lbl_unidad_cuentas.Text = "[cuentas]"
        '
        'lbl_ADC_Medido
        '
        Me.lbl_ADC_Medido.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ADC_Medido.Location = New System.Drawing.Point(195, 26)
        Me.lbl_ADC_Medido.Name = "lbl_ADC_Medido"
        Me.lbl_ADC_Medido.Size = New System.Drawing.Size(90, 19)
        Me.lbl_ADC_Medido.TabIndex = 4
        '
        'lbl_Valor_del_ADC_Medido
        '
        Me.lbl_Valor_del_ADC_Medido.AutoSize = True
        Me.lbl_Valor_del_ADC_Medido.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Valor_del_ADC_Medido.Location = New System.Drawing.Point(8, 26)
        Me.lbl_Valor_del_ADC_Medido.Name = "lbl_Valor_del_ADC_Medido"
        Me.lbl_Valor_del_ADC_Medido.Size = New System.Drawing.Size(165, 19)
        Me.lbl_Valor_del_ADC_Medido.TabIndex = 3
        Me.lbl_Valor_del_ADC_Medido.Text = "Valor del ADC Medido:"
        '
        'lbl_Resistencia_Medida
        '
        Me.lbl_Resistencia_Medida.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Resistencia_Medida.Location = New System.Drawing.Point(195, 83)
        Me.lbl_Resistencia_Medida.Name = "lbl_Resistencia_Medida"
        Me.lbl_Resistencia_Medida.Size = New System.Drawing.Size(90, 19)
        Me.lbl_Resistencia_Medida.TabIndex = 2
        '
        'lbl_unidad_ohm_0
        '
        Me.lbl_unidad_ohm_0.AutoSize = True
        Me.lbl_unidad_ohm_0.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_unidad_ohm_0.Location = New System.Drawing.Point(306, 83)
        Me.lbl_unidad_ohm_0.Name = "lbl_unidad_ohm_0"
        Me.lbl_unidad_ohm_0.Size = New System.Drawing.Size(53, 19)
        Me.lbl_unidad_ohm_0.TabIndex = 1
        Me.lbl_unidad_ohm_0.Text = "[Ohm]"
        '
        'lbl_rotulo_Resistencia_Medida
        '
        Me.lbl_rotulo_Resistencia_Medida.AutoSize = True
        Me.lbl_rotulo_Resistencia_Medida.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rotulo_Resistencia_Medida.Location = New System.Drawing.Point(8, 83)
        Me.lbl_rotulo_Resistencia_Medida.Name = "lbl_rotulo_Resistencia_Medida"
        Me.lbl_rotulo_Resistencia_Medida.Size = New System.Drawing.Size(145, 19)
        Me.lbl_rotulo_Resistencia_Medida.TabIndex = 0
        Me.lbl_rotulo_Resistencia_Medida.Text = "Resistencia Medida:"
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Cancelar.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancelar.Location = New System.Drawing.Point(398, 342)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(178, 29)
        Me.btn_Cancelar.TabIndex = 27
        Me.btn_Cancelar.Text = "<< Volver"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'btn_Calibrar
        '
        Me.btn_Calibrar.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Calibrar.Location = New System.Drawing.Point(192, 342)
        Me.btn_Calibrar.Name = "btn_Calibrar"
        Me.btn_Calibrar.Size = New System.Drawing.Size(178, 29)
        Me.btn_Calibrar.TabIndex = 26
        Me.btn_Calibrar.Text = "Calibrar"
        Me.btn_Calibrar.UseVisualStyleBackColor = True
        '
        'lbl_Valor_Alto_Adquirido
        '
        Me.lbl_Valor_Alto_Adquirido.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Valor_Alto_Adquirido.Location = New System.Drawing.Point(601, 111)
        Me.lbl_Valor_Alto_Adquirido.Name = "lbl_Valor_Alto_Adquirido"
        Me.lbl_Valor_Alto_Adquirido.Size = New System.Drawing.Size(83, 29)
        Me.lbl_Valor_Alto_Adquirido.TabIndex = 24
        '
        'btn_Valor_Alto_Ingresado
        '
        Me.btn_Valor_Alto_Ingresado.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Valor_Alto_Ingresado.Location = New System.Drawing.Point(399, 106)
        Me.btn_Valor_Alto_Ingresado.Name = "btn_Valor_Alto_Ingresado"
        Me.btn_Valor_Alto_Ingresado.Size = New System.Drawing.Size(178, 29)
        Me.btn_Valor_Alto_Ingresado.TabIndex = 23
        Me.btn_Valor_Alto_Ingresado.Text = "Adquirir Valor Alto"
        Me.btn_Valor_Alto_Ingresado.UseVisualStyleBackColor = True
        '
        'lbl_rotulo_res_valor_Alto
        '
        Me.lbl_rotulo_res_valor_Alto.AutoSize = True
        Me.lbl_rotulo_res_valor_Alto.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rotulo_res_valor_Alto.Location = New System.Drawing.Point(31, 111)
        Me.lbl_rotulo_res_valor_Alto.Name = "lbl_rotulo_res_valor_Alto"
        Me.lbl_rotulo_res_valor_Alto.Size = New System.Drawing.Size(218, 19)
        Me.lbl_rotulo_res_valor_Alto.TabIndex = 22
        Me.lbl_rotulo_res_valor_Alto.Text = "Resistencia Medida Valor Alto:"
        '
        'txt_Valor_Alto_Ingresado
        '
        Me.txt_Valor_Alto_Ingresado.Location = New System.Drawing.Point(265, 110)
        Me.txt_Valor_Alto_Ingresado.Name = "txt_Valor_Alto_Ingresado"
        Me.txt_Valor_Alto_Ingresado.Size = New System.Drawing.Size(105, 20)
        Me.txt_Valor_Alto_Ingresado.TabIndex = 21
        '
        'lbl_Valor_Bajo_Adquirido
        '
        Me.lbl_Valor_Bajo_Adquirido.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Valor_Bajo_Adquirido.Location = New System.Drawing.Point(601, 56)
        Me.lbl_Valor_Bajo_Adquirido.Name = "lbl_Valor_Bajo_Adquirido"
        Me.lbl_Valor_Bajo_Adquirido.Size = New System.Drawing.Size(56, 21)
        Me.lbl_Valor_Bajo_Adquirido.TabIndex = 19
        '
        'btn_Valor_Bajo_Ingresado
        '
        Me.btn_Valor_Bajo_Ingresado.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Valor_Bajo_Ingresado.Location = New System.Drawing.Point(400, 48)
        Me.btn_Valor_Bajo_Ingresado.Name = "btn_Valor_Bajo_Ingresado"
        Me.btn_Valor_Bajo_Ingresado.Size = New System.Drawing.Size(178, 29)
        Me.btn_Valor_Bajo_Ingresado.TabIndex = 18
        Me.btn_Valor_Bajo_Ingresado.Text = "Adquirir Valor Bajo"
        Me.btn_Valor_Bajo_Ingresado.UseVisualStyleBackColor = True
        '
        'lbl_rotulo_res_valor_bajo
        '
        Me.lbl_rotulo_res_valor_bajo.AutoSize = True
        Me.lbl_rotulo_res_valor_bajo.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rotulo_res_valor_bajo.Location = New System.Drawing.Point(31, 53)
        Me.lbl_rotulo_res_valor_bajo.Name = "lbl_rotulo_res_valor_bajo"
        Me.lbl_rotulo_res_valor_bajo.Size = New System.Drawing.Size(221, 19)
        Me.lbl_rotulo_res_valor_bajo.TabIndex = 17
        Me.lbl_rotulo_res_valor_bajo.Text = "Resistencia Medida Valor Bajo:"
        '
        'txt_Valor_Bajo_Ingresado
        '
        Me.txt_Valor_Bajo_Ingresado.Location = New System.Drawing.Point(265, 54)
        Me.txt_Valor_Bajo_Ingresado.Name = "txt_Valor_Bajo_Ingresado"
        Me.txt_Valor_Bajo_Ingresado.Size = New System.Drawing.Size(105, 20)
        Me.txt_Valor_Bajo_Ingresado.TabIndex = 16
        '
        'timer_temperatura
        '
        Me.timer_temperatura.Interval = 500
        '
        'lbl_unidad_cuentas_1
        '
        Me.lbl_unidad_cuentas_1.AutoSize = True
        Me.lbl_unidad_cuentas_1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_unidad_cuentas_1.Location = New System.Drawing.Point(663, 53)
        Me.lbl_unidad_cuentas_1.Name = "lbl_unidad_cuentas_1"
        Me.lbl_unidad_cuentas_1.Size = New System.Drawing.Size(74, 19)
        Me.lbl_unidad_cuentas_1.TabIndex = 6
        Me.lbl_unidad_cuentas_1.Text = "[cuentas]"
        '
        'lbl_unidad_cuentas_2
        '
        Me.lbl_unidad_cuentas_2.AutoSize = True
        Me.lbl_unidad_cuentas_2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_unidad_cuentas_2.Location = New System.Drawing.Point(663, 111)
        Me.lbl_unidad_cuentas_2.Name = "lbl_unidad_cuentas_2"
        Me.lbl_unidad_cuentas_2.Size = New System.Drawing.Size(74, 19)
        Me.lbl_unidad_cuentas_2.TabIndex = 29
        Me.lbl_unidad_cuentas_2.Text = "[cuentas]"
        '
        'frm_Calibracion_Temperatura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn_Cancelar
        Me.ClientSize = New System.Drawing.Size(780, 396)
        Me.Controls.Add(Me.lbl_unidad_cuentas_2)
        Me.Controls.Add(Me.lbl_unidad_cuentas_1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btn_Cancelar)
        Me.Controls.Add(Me.btn_Calibrar)
        Me.Controls.Add(Me.lbl_Valor_Alto_Adquirido)
        Me.Controls.Add(Me.btn_Valor_Alto_Ingresado)
        Me.Controls.Add(Me.lbl_rotulo_res_valor_Alto)
        Me.Controls.Add(Me.txt_Valor_Alto_Ingresado)
        Me.Controls.Add(Me.lbl_Valor_Bajo_Adquirido)
        Me.Controls.Add(Me.btn_Valor_Bajo_Ingresado)
        Me.Controls.Add(Me.lbl_rotulo_res_valor_bajo)
        Me.Controls.Add(Me.txt_Valor_Bajo_Ingresado)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Calibracion_Temperatura"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Calibración de Temperatura"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_Resistencia_Medida As System.Windows.Forms.Label
    Friend WithEvents lbl_unidad_ohm_0 As System.Windows.Forms.Label
    Friend WithEvents lbl_rotulo_Resistencia_Medida As System.Windows.Forms.Label
    Public WithEvents btn_Cancelar As System.Windows.Forms.Button
    Public WithEvents btn_Calibrar As System.Windows.Forms.Button
    Friend WithEvents lbl_Valor_Alto_Adquirido As System.Windows.Forms.Label
    Public WithEvents btn_Valor_Alto_Ingresado As System.Windows.Forms.Button
    Friend WithEvents lbl_rotulo_res_valor_Alto As System.Windows.Forms.Label
    Friend WithEvents txt_Valor_Alto_Ingresado As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Valor_Bajo_Adquirido As System.Windows.Forms.Label
    Public WithEvents btn_Valor_Bajo_Ingresado As System.Windows.Forms.Button
    Friend WithEvents lbl_rotulo_res_valor_bajo As System.Windows.Forms.Label
    Friend WithEvents txt_Valor_Bajo_Ingresado As System.Windows.Forms.TextBox
    Friend WithEvents timer_temperatura As System.Windows.Forms.Timer
    Friend WithEvents lbl_Valor_del_ADC_Medido As System.Windows.Forms.Label
    Friend WithEvents lbl_ADC_Medido As System.Windows.Forms.Label
    Friend WithEvents lbl_unidad_cuentas As System.Windows.Forms.Label
    Friend WithEvents lbl_unidad_cuentas_1 As System.Windows.Forms.Label
    Friend WithEvents lbl_unidad_cuentas_2 As System.Windows.Forms.Label
End Class
