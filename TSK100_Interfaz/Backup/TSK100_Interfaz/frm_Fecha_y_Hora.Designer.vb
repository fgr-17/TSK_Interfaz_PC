<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Fecha_y_Hora
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
        Me.lbl_rotulo_res_valor_bajo = New System.Windows.Forms.Label
        Me.txt_Dia = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_Mes = New System.Windows.Forms.TextBox
        Me.txt_Anio = New System.Windows.Forms.TextBox
        Me.txt_Segundo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_Minuto = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_Hora = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btn_Cancelar = New System.Windows.Forms.Button
        Me.btn_Establecer = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_rotulo_res_valor_bajo
        '
        Me.lbl_rotulo_res_valor_bajo.AutoSize = True
        Me.lbl_rotulo_res_valor_bajo.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rotulo_res_valor_bajo.Location = New System.Drawing.Point(42, 80)
        Me.lbl_rotulo_res_valor_bajo.Name = "lbl_rotulo_res_valor_bajo"
        Me.lbl_rotulo_res_valor_bajo.Size = New System.Drawing.Size(52, 19)
        Me.lbl_rotulo_res_valor_bajo.TabIndex = 18
        Me.lbl_rotulo_res_valor_bajo.Text = "Hora :"
        '
        'txt_Dia
        '
        Me.txt_Dia.Location = New System.Drawing.Point(120, 38)
        Me.txt_Dia.Name = "txt_Dia"
        Me.txt_Dia.Size = New System.Drawing.Size(28, 25)
        Me.txt_Dia.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(154, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 19)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(207, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 19)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = ":"
        '
        'txt_Mes
        '
        Me.txt_Mes.Location = New System.Drawing.Point(173, 38)
        Me.txt_Mes.Name = "txt_Mes"
        Me.txt_Mes.Size = New System.Drawing.Size(28, 25)
        Me.txt_Mes.TabIndex = 21
        '
        'txt_Anio
        '
        Me.txt_Anio.Location = New System.Drawing.Point(226, 38)
        Me.txt_Anio.Name = "txt_Anio"
        Me.txt_Anio.Size = New System.Drawing.Size(56, 25)
        Me.txt_Anio.TabIndex = 23
        '
        'txt_Segundo
        '
        Me.txt_Segundo.Location = New System.Drawing.Point(226, 81)
        Me.txt_Segundo.Name = "txt_Segundo"
        Me.txt_Segundo.Size = New System.Drawing.Size(28, 25)
        Me.txt_Segundo.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(207, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 19)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "-"
        '
        'txt_Minuto
        '
        Me.txt_Minuto.Location = New System.Drawing.Point(173, 81)
        Me.txt_Minuto.Name = "txt_Minuto"
        Me.txt_Minuto.Size = New System.Drawing.Size(28, 25)
        Me.txt_Minuto.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(154, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 19)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "-"
        '
        'txt_Hora
        '
        Me.txt_Hora.Location = New System.Drawing.Point(120, 81)
        Me.txt_Hora.Name = "txt_Hora"
        Me.txt_Hora.Size = New System.Drawing.Size(28, 25)
        Me.txt_Hora.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(42, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 19)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Fecha : "
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Cancelar.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancelar.Location = New System.Drawing.Point(209, 161)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(109, 30)
        Me.btn_Cancelar.TabIndex = 32
        Me.btn_Cancelar.Text = "<< Volver"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'btn_Establecer
        '
        Me.btn_Establecer.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Establecer.Location = New System.Drawing.Point(66, 161)
        Me.btn_Establecer.Name = "btn_Establecer"
        Me.btn_Establecer.Size = New System.Drawing.Size(109, 30)
        Me.btn_Establecer.TabIndex = 31
        Me.btn_Establecer.Text = "Establecer"
        Me.btn_Establecer.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_Segundo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_Minuto)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_Hora)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_Anio)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_Mes)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_Dia)
        Me.GroupBox1.Controls.Add(Me.lbl_rotulo_res_valor_bajo)
        Me.GroupBox1.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(20, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(337, 126)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Hora y Fecha a Establecer"
        '
        'frm_Fecha_y_Hora
        '
        Me.AcceptButton = Me.btn_Establecer
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn_Cancelar
        Me.ClientSize = New System.Drawing.Size(389, 203)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_Cancelar)
        Me.Controls.Add(Me.btn_Establecer)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Fecha_y_Hora"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Modificar Fecha y Hora"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_rotulo_res_valor_bajo As System.Windows.Forms.Label
    Friend WithEvents txt_Dia As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Mes As System.Windows.Forms.TextBox
    Friend WithEvents txt_Anio As System.Windows.Forms.TextBox
    Friend WithEvents txt_Segundo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_Minuto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_Hora As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents btn_Cancelar As System.Windows.Forms.Button
    Public WithEvents btn_Establecer As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
