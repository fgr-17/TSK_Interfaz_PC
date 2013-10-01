<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Calibracion_Conductividad
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
        Me.lbl_rotulo_Conductividad_Medida = New System.Windows.Forms.Label
        Me.lbl_unidad_uS_0 = New System.Windows.Forms.Label
        Me.lbl_Conductividad_Medida = New System.Windows.Forms.Label
        Me.txt_Valor_Bajo_Ingresado = New System.Windows.Forms.TextBox
        Me.lbl_rotulo_cond_valor_bajo = New System.Windows.Forms.Label
        Me.btn_Valor_Bajo_Ingresado = New System.Windows.Forms.Button
        Me.lbl_Valor_Bajo_Adquirido = New System.Windows.Forms.Label
        Me.lbl_unidad_uS_1 = New System.Windows.Forms.Label
        Me.lbl_unidad_uS_2 = New System.Windows.Forms.Label
        Me.lbl_Valor_Alto_Adquirido = New System.Windows.Forms.Label
        Me.btn_Valor_Alto_Ingresado = New System.Windows.Forms.Button
        Me.lbl_rotulo_cond_valor_Alto = New System.Windows.Forms.Label
        Me.txt_Valor_Alto_Ingresado = New System.Windows.Forms.TextBox
        Me.btn_Calibrar = New System.Windows.Forms.Button
        Me.btn_Cancelar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lbl_Temperatura_Medida = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbl_Medicion_Coef_De_Calibracion = New System.Windows.Forms.Label
        Me.lbl_Coef_de_Calibracion = New System.Windows.Forms.Label
        Me.lbl_unidad_Medicion_ADC_Tension = New System.Windows.Forms.Label
        Me.lbl_unidad_Medicion_ADC_Corriente = New System.Windows.Forms.Label
        Me.lbl_Medicion_ADC_Tension = New System.Windows.Forms.Label
        Me.lbl_Medicion_ADC_Corriente = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_rotulo_ADC_numerador = New System.Windows.Forms.Label
        Me.timer_conductividad = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_rotulo_Coeficiente_Temperatura = New System.Windows.Forms.Label
        Me.txt_Coeficiente_de_Temperatura = New System.Windows.Forms.TextBox
        Me.btn_Coeficiente_de_Temperatura = New System.Windows.Forms.Button
        Me.lbl_unidad_porcentaje = New System.Windows.Forms.Label
        Me.lbl_Coeficiente_de_Temperatura = New System.Windows.Forms.Label
        Me.lbl_Offset = New System.Windows.Forms.Label
        Me.lbl_Pendiente = New System.Windows.Forms.Label
        Me.lbl_Offset_Calculado = New System.Windows.Forms.Label
        Me.lbl_Pendiente_Calculada = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_rotulo_Conductividad_Medida
        '
        Me.lbl_rotulo_Conductividad_Medida.AutoSize = True
        Me.lbl_rotulo_Conductividad_Medida.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rotulo_Conductividad_Medida.Location = New System.Drawing.Point(23, 26)
        Me.lbl_rotulo_Conductividad_Medida.Name = "lbl_rotulo_Conductividad_Medida"
        Me.lbl_rotulo_Conductividad_Medida.Size = New System.Drawing.Size(167, 19)
        Me.lbl_rotulo_Conductividad_Medida.TabIndex = 0
        Me.lbl_rotulo_Conductividad_Medida.Text = "Conductividad Medida:"
        '
        'lbl_unidad_uS_0
        '
        Me.lbl_unidad_uS_0.AutoSize = True
        Me.lbl_unidad_uS_0.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_unidad_uS_0.Location = New System.Drawing.Point(360, 26)
        Me.lbl_unidad_uS_0.Name = "lbl_unidad_uS_0"
        Me.lbl_unidad_uS_0.Size = New System.Drawing.Size(38, 19)
        Me.lbl_unidad_uS_0.TabIndex = 1
        Me.lbl_unidad_uS_0.Text = "[uS]"
        '
        'lbl_Conductividad_Medida
        '
        Me.lbl_Conductividad_Medida.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Conductividad_Medida.Location = New System.Drawing.Point(254, 26)
        Me.lbl_Conductividad_Medida.Name = "lbl_Conductividad_Medida"
        Me.lbl_Conductividad_Medida.Size = New System.Drawing.Size(90, 19)
        Me.lbl_Conductividad_Medida.TabIndex = 2
        '
        'txt_Valor_Bajo_Ingresado
        '
        Me.txt_Valor_Bajo_Ingresado.Location = New System.Drawing.Point(232, 35)
        Me.txt_Valor_Bajo_Ingresado.Name = "txt_Valor_Bajo_Ingresado"
        Me.txt_Valor_Bajo_Ingresado.Size = New System.Drawing.Size(105, 20)
        Me.txt_Valor_Bajo_Ingresado.TabIndex = 3
        '
        'lbl_rotulo_cond_valor_bajo
        '
        Me.lbl_rotulo_cond_valor_bajo.AutoSize = True
        Me.lbl_rotulo_cond_valor_bajo.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rotulo_cond_valor_bajo.Location = New System.Drawing.Point(33, 34)
        Me.lbl_rotulo_cond_valor_bajo.Name = "lbl_rotulo_cond_valor_bajo"
        Me.lbl_rotulo_cond_valor_bajo.Size = New System.Drawing.Size(188, 19)
        Me.lbl_rotulo_cond_valor_bajo.TabIndex = 4
        Me.lbl_rotulo_cond_valor_bajo.Text = "Conductividad Valor Bajo:"
        '
        'btn_Valor_Bajo_Ingresado
        '
        Me.btn_Valor_Bajo_Ingresado.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Valor_Bajo_Ingresado.Location = New System.Drawing.Point(358, 29)
        Me.btn_Valor_Bajo_Ingresado.Name = "btn_Valor_Bajo_Ingresado"
        Me.btn_Valor_Bajo_Ingresado.Size = New System.Drawing.Size(178, 29)
        Me.btn_Valor_Bajo_Ingresado.TabIndex = 5
        Me.btn_Valor_Bajo_Ingresado.Text = "Adquirir Valor Bajo"
        Me.btn_Valor_Bajo_Ingresado.UseVisualStyleBackColor = True
        '
        'lbl_Valor_Bajo_Adquirido
        '
        Me.lbl_Valor_Bajo_Adquirido.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Valor_Bajo_Adquirido.Location = New System.Drawing.Point(551, 36)
        Me.lbl_Valor_Bajo_Adquirido.Name = "lbl_Valor_Bajo_Adquirido"
        Me.lbl_Valor_Bajo_Adquirido.Size = New System.Drawing.Size(112, 19)
        Me.lbl_Valor_Bajo_Adquirido.TabIndex = 6
        '
        'lbl_unidad_uS_1
        '
        Me.lbl_unidad_uS_1.AutoSize = True
        Me.lbl_unidad_uS_1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_unidad_uS_1.Location = New System.Drawing.Point(647, 34)
        Me.lbl_unidad_uS_1.Name = "lbl_unidad_uS_1"
        Me.lbl_unidad_uS_1.Size = New System.Drawing.Size(74, 19)
        Me.lbl_unidad_uS_1.TabIndex = 7
        Me.lbl_unidad_uS_1.Text = "[cuentas]"
        '
        'lbl_unidad_uS_2
        '
        Me.lbl_unidad_uS_2.AutoSize = True
        Me.lbl_unidad_uS_2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_unidad_uS_2.Location = New System.Drawing.Point(647, 88)
        Me.lbl_unidad_uS_2.Name = "lbl_unidad_uS_2"
        Me.lbl_unidad_uS_2.Size = New System.Drawing.Size(74, 19)
        Me.lbl_unidad_uS_2.TabIndex = 12
        Me.lbl_unidad_uS_2.Text = "[cuentas]"
        '
        'lbl_Valor_Alto_Adquirido
        '
        Me.lbl_Valor_Alto_Adquirido.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Valor_Alto_Adquirido.Location = New System.Drawing.Point(551, 88)
        Me.lbl_Valor_Alto_Adquirido.Name = "lbl_Valor_Alto_Adquirido"
        Me.lbl_Valor_Alto_Adquirido.Size = New System.Drawing.Size(112, 19)
        Me.lbl_Valor_Alto_Adquirido.TabIndex = 11
        '
        'btn_Valor_Alto_Ingresado
        '
        Me.btn_Valor_Alto_Ingresado.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Valor_Alto_Ingresado.Location = New System.Drawing.Point(358, 82)
        Me.btn_Valor_Alto_Ingresado.Name = "btn_Valor_Alto_Ingresado"
        Me.btn_Valor_Alto_Ingresado.Size = New System.Drawing.Size(178, 29)
        Me.btn_Valor_Alto_Ingresado.TabIndex = 10
        Me.btn_Valor_Alto_Ingresado.Text = "Adquirir Valor Alto"
        Me.btn_Valor_Alto_Ingresado.UseVisualStyleBackColor = True
        '
        'lbl_rotulo_cond_valor_Alto
        '
        Me.lbl_rotulo_cond_valor_Alto.AutoSize = True
        Me.lbl_rotulo_cond_valor_Alto.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rotulo_cond_valor_Alto.Location = New System.Drawing.Point(33, 87)
        Me.lbl_rotulo_cond_valor_Alto.Name = "lbl_rotulo_cond_valor_Alto"
        Me.lbl_rotulo_cond_valor_Alto.Size = New System.Drawing.Size(185, 19)
        Me.lbl_rotulo_cond_valor_Alto.TabIndex = 9
        Me.lbl_rotulo_cond_valor_Alto.Text = "Conductividad Valor Alto:"
        '
        'txt_Valor_Alto_Ingresado
        '
        Me.txt_Valor_Alto_Ingresado.Location = New System.Drawing.Point(232, 88)
        Me.txt_Valor_Alto_Ingresado.Name = "txt_Valor_Alto_Ingresado"
        Me.txt_Valor_Alto_Ingresado.Size = New System.Drawing.Size(105, 20)
        Me.txt_Valor_Alto_Ingresado.TabIndex = 8
        '
        'btn_Calibrar
        '
        Me.btn_Calibrar.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Calibrar.Location = New System.Drawing.Point(146, 381)
        Me.btn_Calibrar.Name = "btn_Calibrar"
        Me.btn_Calibrar.Size = New System.Drawing.Size(178, 29)
        Me.btn_Calibrar.TabIndex = 13
        Me.btn_Calibrar.Text = "Calibrar"
        Me.btn_Calibrar.UseVisualStyleBackColor = True
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Cancelar.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancelar.Location = New System.Drawing.Point(400, 381)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(178, 29)
        Me.btn_Cancelar.TabIndex = 14
        Me.btn_Cancelar.Text = "<< Volver"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lbl_Temperatura_Medida)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lbl_Medicion_Coef_De_Calibracion)
        Me.Panel1.Controls.Add(Me.lbl_Coef_de_Calibracion)
        Me.Panel1.Controls.Add(Me.lbl_Conductividad_Medida)
        Me.Panel1.Controls.Add(Me.lbl_unidad_uS_0)
        Me.Panel1.Controls.Add(Me.lbl_rotulo_Conductividad_Medida)
        Me.Panel1.Location = New System.Drawing.Point(134, 206)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(433, 153)
        Me.Panel1.TabIndex = 15
        '
        'lbl_Temperatura_Medida
        '
        Me.lbl_Temperatura_Medida.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Temperatura_Medida.Location = New System.Drawing.Point(254, 107)
        Me.lbl_Temperatura_Medida.Name = "lbl_Temperatura_Medida"
        Me.lbl_Temperatura_Medida.Size = New System.Drawing.Size(90, 19)
        Me.lbl_Temperatura_Medida.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(360, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 19)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "[°C]"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 19)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Temperatura:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(360, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 19)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "[%]"
        '
        'lbl_Medicion_Coef_De_Calibracion
        '
        Me.lbl_Medicion_Coef_De_Calibracion.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Medicion_Coef_De_Calibracion.Location = New System.Drawing.Point(254, 68)
        Me.lbl_Medicion_Coef_De_Calibracion.Name = "lbl_Medicion_Coef_De_Calibracion"
        Me.lbl_Medicion_Coef_De_Calibracion.Size = New System.Drawing.Size(90, 19)
        Me.lbl_Medicion_Coef_De_Calibracion.TabIndex = 19
        '
        'lbl_Coef_de_Calibracion
        '
        Me.lbl_Coef_de_Calibracion.AutoSize = True
        Me.lbl_Coef_de_Calibracion.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Coef_de_Calibracion.Location = New System.Drawing.Point(23, 68)
        Me.lbl_Coef_de_Calibracion.Name = "lbl_Coef_de_Calibracion"
        Me.lbl_Coef_de_Calibracion.Size = New System.Drawing.Size(192, 19)
        Me.lbl_Coef_de_Calibracion.TabIndex = 18
        Me.lbl_Coef_de_Calibracion.Text = "Coeficiente de Calibración:"
        '
        'lbl_unidad_Medicion_ADC_Tension
        '
        Me.lbl_unidad_Medicion_ADC_Tension.AutoSize = True
        Me.lbl_unidad_Medicion_ADC_Tension.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_unidad_Medicion_ADC_Tension.Location = New System.Drawing.Point(314, 625)
        Me.lbl_unidad_Medicion_ADC_Tension.Name = "lbl_unidad_Medicion_ADC_Tension"
        Me.lbl_unidad_Medicion_ADC_Tension.Size = New System.Drawing.Size(74, 19)
        Me.lbl_unidad_Medicion_ADC_Tension.TabIndex = 17
        Me.lbl_unidad_Medicion_ADC_Tension.Text = "[cuentas]"
        Me.lbl_unidad_Medicion_ADC_Tension.Visible = False
        '
        'lbl_unidad_Medicion_ADC_Corriente
        '
        Me.lbl_unidad_Medicion_ADC_Corriente.AutoSize = True
        Me.lbl_unidad_Medicion_ADC_Corriente.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_unidad_Medicion_ADC_Corriente.Location = New System.Drawing.Point(314, 581)
        Me.lbl_unidad_Medicion_ADC_Corriente.Name = "lbl_unidad_Medicion_ADC_Corriente"
        Me.lbl_unidad_Medicion_ADC_Corriente.Size = New System.Drawing.Size(74, 19)
        Me.lbl_unidad_Medicion_ADC_Corriente.TabIndex = 16
        Me.lbl_unidad_Medicion_ADC_Corriente.Text = "[cuentas]"
        Me.lbl_unidad_Medicion_ADC_Corriente.Visible = False
        '
        'lbl_Medicion_ADC_Tension
        '
        Me.lbl_Medicion_ADC_Tension.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Medicion_ADC_Tension.Location = New System.Drawing.Point(208, 625)
        Me.lbl_Medicion_ADC_Tension.Name = "lbl_Medicion_ADC_Tension"
        Me.lbl_Medicion_ADC_Tension.Size = New System.Drawing.Size(90, 19)
        Me.lbl_Medicion_ADC_Tension.TabIndex = 6
        Me.lbl_Medicion_ADC_Tension.Visible = False
        '
        'lbl_Medicion_ADC_Corriente
        '
        Me.lbl_Medicion_ADC_Corriente.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Medicion_ADC_Corriente.Location = New System.Drawing.Point(208, 581)
        Me.lbl_Medicion_ADC_Corriente.Name = "lbl_Medicion_ADC_Corriente"
        Me.lbl_Medicion_ADC_Corriente.Size = New System.Drawing.Size(90, 19)
        Me.lbl_Medicion_ADC_Corriente.TabIndex = 5
        Me.lbl_Medicion_ADC_Corriente.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 625)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Medición ADC Tensión:"
        Me.Label1.Visible = False
        '
        'lbl_rotulo_ADC_numerador
        '
        Me.lbl_rotulo_ADC_numerador.AutoSize = True
        Me.lbl_rotulo_ADC_numerador.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rotulo_ADC_numerador.Location = New System.Drawing.Point(17, 581)
        Me.lbl_rotulo_ADC_numerador.Name = "lbl_rotulo_ADC_numerador"
        Me.lbl_rotulo_ADC_numerador.Size = New System.Drawing.Size(180, 19)
        Me.lbl_rotulo_ADC_numerador.TabIndex = 3
        Me.lbl_rotulo_ADC_numerador.Text = "Medición ADC Corriente:"
        Me.lbl_rotulo_ADC_numerador.Visible = False
        '
        'timer_conductividad
        '
        Me.timer_conductividad.Interval = 1000
        '
        'lbl_rotulo_Coeficiente_Temperatura
        '
        Me.lbl_rotulo_Coeficiente_Temperatura.AutoSize = True
        Me.lbl_rotulo_Coeficiente_Temperatura.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rotulo_Coeficiente_Temperatura.Location = New System.Drawing.Point(33, 138)
        Me.lbl_rotulo_Coeficiente_Temperatura.Name = "lbl_rotulo_Coeficiente_Temperatura"
        Me.lbl_rotulo_Coeficiente_Temperatura.Size = New System.Drawing.Size(204, 19)
        Me.lbl_rotulo_Coeficiente_Temperatura.TabIndex = 16
        Me.lbl_rotulo_Coeficiente_Temperatura.Text = "Coeficiente de Temperatura:"
        '
        'txt_Coeficiente_de_Temperatura
        '
        Me.txt_Coeficiente_de_Temperatura.Location = New System.Drawing.Point(183, 497)
        Me.txt_Coeficiente_de_Temperatura.Name = "txt_Coeficiente_de_Temperatura"
        Me.txt_Coeficiente_de_Temperatura.Size = New System.Drawing.Size(105, 20)
        Me.txt_Coeficiente_de_Temperatura.TabIndex = 17
        Me.txt_Coeficiente_de_Temperatura.Visible = False
        '
        'btn_Coeficiente_de_Temperatura
        '
        Me.btn_Coeficiente_de_Temperatura.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Coeficiente_de_Temperatura.Location = New System.Drawing.Point(309, 493)
        Me.btn_Coeficiente_de_Temperatura.Name = "btn_Coeficiente_de_Temperatura"
        Me.btn_Coeficiente_de_Temperatura.Size = New System.Drawing.Size(178, 29)
        Me.btn_Coeficiente_de_Temperatura.TabIndex = 18
        Me.btn_Coeficiente_de_Temperatura.Text = "Guardar Coeficiente"
        Me.btn_Coeficiente_de_Temperatura.UseVisualStyleBackColor = True
        Me.btn_Coeficiente_de_Temperatura.Visible = False
        '
        'lbl_unidad_porcentaje
        '
        Me.lbl_unidad_porcentaje.AutoSize = True
        Me.lbl_unidad_porcentaje.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_unidad_porcentaje.Location = New System.Drawing.Point(339, 138)
        Me.lbl_unidad_porcentaje.Name = "lbl_unidad_porcentaje"
        Me.lbl_unidad_porcentaje.Size = New System.Drawing.Size(35, 19)
        Me.lbl_unidad_porcentaje.TabIndex = 19
        Me.lbl_unidad_porcentaje.Text = "[%]"
        '
        'lbl_Coeficiente_de_Temperatura
        '
        Me.lbl_Coeficiente_de_Temperatura.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Coeficiente_de_Temperatura.Location = New System.Drawing.Point(278, 138)
        Me.lbl_Coeficiente_de_Temperatura.Name = "lbl_Coeficiente_de_Temperatura"
        Me.lbl_Coeficiente_de_Temperatura.Size = New System.Drawing.Size(46, 19)
        Me.lbl_Coeficiente_de_Temperatura.TabIndex = 20
        Me.lbl_Coeficiente_de_Temperatura.Text = "2.1"
        '
        'lbl_Offset
        '
        Me.lbl_Offset.AutoSize = True
        Me.lbl_Offset.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Offset.Location = New System.Drawing.Point(418, 625)
        Me.lbl_Offset.Name = "lbl_Offset"
        Me.lbl_Offset.Size = New System.Drawing.Size(53, 19)
        Me.lbl_Offset.TabIndex = 22
        Me.lbl_Offset.Text = "Offset:"
        Me.lbl_Offset.Visible = False
        '
        'lbl_Pendiente
        '
        Me.lbl_Pendiente.AutoSize = True
        Me.lbl_Pendiente.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Pendiente.Location = New System.Drawing.Point(389, 581)
        Me.lbl_Pendiente.Name = "lbl_Pendiente"
        Me.lbl_Pendiente.Size = New System.Drawing.Size(82, 19)
        Me.lbl_Pendiente.TabIndex = 21
        Me.lbl_Pendiente.Text = "Pendiente:"
        Me.lbl_Pendiente.Visible = False
        '
        'lbl_Offset_Calculado
        '
        Me.lbl_Offset_Calculado.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Offset_Calculado.Location = New System.Drawing.Point(494, 625)
        Me.lbl_Offset_Calculado.Name = "lbl_Offset_Calculado"
        Me.lbl_Offset_Calculado.Size = New System.Drawing.Size(90, 19)
        Me.lbl_Offset_Calculado.TabIndex = 24
        Me.lbl_Offset_Calculado.Visible = False
        '
        'lbl_Pendiente_Calculada
        '
        Me.lbl_Pendiente_Calculada.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Pendiente_Calculada.Location = New System.Drawing.Point(494, 581)
        Me.lbl_Pendiente_Calculada.Name = "lbl_Pendiente_Calculada"
        Me.lbl_Pendiente_Calculada.Size = New System.Drawing.Size(90, 19)
        Me.lbl_Pendiente_Calculada.TabIndex = 23
        Me.lbl_Pendiente_Calculada.Visible = False
        '
        'frm_Calibracion_Conductividad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn_Cancelar
        Me.ClientSize = New System.Drawing.Size(750, 435)
        Me.Controls.Add(Me.lbl_Offset_Calculado)
        Me.Controls.Add(Me.lbl_Pendiente_Calculada)
        Me.Controls.Add(Me.lbl_Offset)
        Me.Controls.Add(Me.lbl_Pendiente)
        Me.Controls.Add(Me.lbl_unidad_porcentaje)
        Me.Controls.Add(Me.lbl_Coeficiente_de_Temperatura)
        Me.Controls.Add(Me.btn_Coeficiente_de_Temperatura)
        Me.Controls.Add(Me.txt_Coeficiente_de_Temperatura)
        Me.Controls.Add(Me.lbl_rotulo_Coeficiente_Temperatura)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbl_unidad_Medicion_ADC_Tension)
        Me.Controls.Add(Me.btn_Cancelar)
        Me.Controls.Add(Me.lbl_unidad_Medicion_ADC_Corriente)
        Me.Controls.Add(Me.btn_Calibrar)
        Me.Controls.Add(Me.lbl_Medicion_ADC_Tension)
        Me.Controls.Add(Me.lbl_unidad_uS_2)
        Me.Controls.Add(Me.lbl_Medicion_ADC_Corriente)
        Me.Controls.Add(Me.lbl_Valor_Alto_Adquirido)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Valor_Alto_Ingresado)
        Me.Controls.Add(Me.lbl_rotulo_ADC_numerador)
        Me.Controls.Add(Me.lbl_rotulo_cond_valor_Alto)
        Me.Controls.Add(Me.txt_Valor_Alto_Ingresado)
        Me.Controls.Add(Me.lbl_unidad_uS_1)
        Me.Controls.Add(Me.lbl_Valor_Bajo_Adquirido)
        Me.Controls.Add(Me.btn_Valor_Bajo_Ingresado)
        Me.Controls.Add(Me.lbl_rotulo_cond_valor_bajo)
        Me.Controls.Add(Me.txt_Valor_Bajo_Ingresado)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Calibracion_Conductividad"
        Me.Text = "Calibracion de Conductividad"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_rotulo_Conductividad_Medida As System.Windows.Forms.Label
    Friend WithEvents lbl_unidad_uS_0 As System.Windows.Forms.Label
    Friend WithEvents lbl_Conductividad_Medida As System.Windows.Forms.Label
    Friend WithEvents txt_Valor_Bajo_Ingresado As System.Windows.Forms.TextBox
    Friend WithEvents lbl_rotulo_cond_valor_bajo As System.Windows.Forms.Label
    Public WithEvents btn_Valor_Bajo_Ingresado As System.Windows.Forms.Button
    Friend WithEvents lbl_Valor_Bajo_Adquirido As System.Windows.Forms.Label
    Friend WithEvents lbl_unidad_uS_1 As System.Windows.Forms.Label
    Friend WithEvents lbl_unidad_uS_2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Valor_Alto_Adquirido As System.Windows.Forms.Label
    Public WithEvents btn_Valor_Alto_Ingresado As System.Windows.Forms.Button
    Friend WithEvents lbl_rotulo_cond_valor_Alto As System.Windows.Forms.Label
    Friend WithEvents txt_Valor_Alto_Ingresado As System.Windows.Forms.TextBox
    Public WithEvents btn_Calibrar As System.Windows.Forms.Button
    Public WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents timer_conductividad As System.Windows.Forms.Timer
    Friend WithEvents lbl_rotulo_ADC_numerador As System.Windows.Forms.Label
    Friend WithEvents lbl_unidad_Medicion_ADC_Tension As System.Windows.Forms.Label
    Friend WithEvents lbl_unidad_Medicion_ADC_Corriente As System.Windows.Forms.Label
    Friend WithEvents lbl_Medicion_ADC_Tension As System.Windows.Forms.Label
    Friend WithEvents lbl_Medicion_ADC_Corriente As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_Coef_de_Calibracion As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Medicion_Coef_De_Calibracion As System.Windows.Forms.Label
    Friend WithEvents lbl_Temperatura_Medida As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_rotulo_Coeficiente_Temperatura As System.Windows.Forms.Label
    Friend WithEvents txt_Coeficiente_de_Temperatura As System.Windows.Forms.TextBox
    Public WithEvents btn_Coeficiente_de_Temperatura As System.Windows.Forms.Button
    Friend WithEvents lbl_unidad_porcentaje As System.Windows.Forms.Label
    Friend WithEvents lbl_Coeficiente_de_Temperatura As System.Windows.Forms.Label
    Friend WithEvents lbl_Offset As System.Windows.Forms.Label
    Friend WithEvents lbl_Pendiente As System.Windows.Forms.Label
    Friend WithEvents lbl_Offset_Calculado As System.Windows.Forms.Label
    Friend WithEvents lbl_Pendiente_Calculada As System.Windows.Forms.Label
End Class
