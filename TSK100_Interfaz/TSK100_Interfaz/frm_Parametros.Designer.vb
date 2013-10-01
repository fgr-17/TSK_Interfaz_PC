<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Parametros
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
        Me.lbl_Nivel_Alarma = New System.Windows.Forms.Label
        Me.lbl_Nivel_Umbral = New System.Windows.Forms.Label
        Me.chk_Alarma_Activa = New System.Windows.Forms.CheckBox
        Me.chk_Modo_Diferencial = New System.Windows.Forms.CheckBox
        Me.txt_Nivel_Alarma = New System.Windows.Forms.TextBox
        Me.txt_Nivel_Umbral = New System.Windows.Forms.TextBox
        Me.btn_Actualizar_Alarma = New System.Windows.Forms.Button
        Me.btn_Volver = New System.Windows.Forms.Button
        Me.btn_Actualizar_Modo = New System.Windows.Forms.Button
        Me.lbl_unidad_uS_1 = New System.Windows.Forms.Label
        Me.lbl_unidad_uS_2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lbl_Nivel_Alarma
        '
        Me.lbl_Nivel_Alarma.AutoSize = True
        Me.lbl_Nivel_Alarma.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Nivel_Alarma.Location = New System.Drawing.Point(229, 39)
        Me.lbl_Nivel_Alarma.Name = "lbl_Nivel_Alarma"
        Me.lbl_Nivel_Alarma.Size = New System.Drawing.Size(123, 19)
        Me.lbl_Nivel_Alarma.TabIndex = 0
        Me.lbl_Nivel_Alarma.Text = "Nivel de Alarma:"
        '
        'lbl_Nivel_Umbral
        '
        Me.lbl_Nivel_Umbral.AutoSize = True
        Me.lbl_Nivel_Umbral.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Nivel_Umbral.Location = New System.Drawing.Point(229, 84)
        Me.lbl_Nivel_Umbral.Name = "lbl_Nivel_Umbral"
        Me.lbl_Nivel_Umbral.Size = New System.Drawing.Size(149, 19)
        Me.lbl_Nivel_Umbral.TabIndex = 1
        Me.lbl_Nivel_Umbral.Text = "Tiempo de Sampleo:"
        '
        'chk_Alarma_Activa
        '
        Me.chk_Alarma_Activa.AutoSize = True
        Me.chk_Alarma_Activa.Checked = True
        Me.chk_Alarma_Activa.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_Alarma_Activa.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Alarma_Activa.Location = New System.Drawing.Point(46, 39)
        Me.chk_Alarma_Activa.Name = "chk_Alarma_Activa"
        Me.chk_Alarma_Activa.Size = New System.Drawing.Size(124, 23)
        Me.chk_Alarma_Activa.TabIndex = 4
        Me.chk_Alarma_Activa.Text = "Alarma Activa"
        Me.chk_Alarma_Activa.UseVisualStyleBackColor = True
        '
        'chk_Modo_Diferencial
        '
        Me.chk_Modo_Diferencial.AutoSize = True
        Me.chk_Modo_Diferencial.Checked = True
        Me.chk_Modo_Diferencial.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_Modo_Diferencial.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Modo_Diferencial.Location = New System.Drawing.Point(46, 83)
        Me.chk_Modo_Diferencial.Name = "chk_Modo_Diferencial"
        Me.chk_Modo_Diferencial.Size = New System.Drawing.Size(147, 23)
        Me.chk_Modo_Diferencial.TabIndex = 5
        Me.chk_Modo_Diferencial.Text = "Modo Diferencial"
        Me.chk_Modo_Diferencial.UseVisualStyleBackColor = True
        Me.chk_Modo_Diferencial.Visible = False
        '
        'txt_Nivel_Alarma
        '
        Me.txt_Nivel_Alarma.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Nivel_Alarma.Location = New System.Drawing.Point(375, 36)
        Me.txt_Nivel_Alarma.Name = "txt_Nivel_Alarma"
        Me.txt_Nivel_Alarma.Size = New System.Drawing.Size(112, 26)
        Me.txt_Nivel_Alarma.TabIndex = 6
        '
        'txt_Nivel_Umbral
        '
        Me.txt_Nivel_Umbral.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Nivel_Umbral.Location = New System.Drawing.Point(375, 81)
        Me.txt_Nivel_Umbral.Name = "txt_Nivel_Umbral"
        Me.txt_Nivel_Umbral.Size = New System.Drawing.Size(112, 26)
        Me.txt_Nivel_Umbral.TabIndex = 7
        '
        'btn_Actualizar_Alarma
        '
        Me.btn_Actualizar_Alarma.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Actualizar_Alarma.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Actualizar_Alarma.Location = New System.Drawing.Point(564, 32)
        Me.btn_Actualizar_Alarma.Name = "btn_Actualizar_Alarma"
        Me.btn_Actualizar_Alarma.Size = New System.Drawing.Size(197, 32)
        Me.btn_Actualizar_Alarma.TabIndex = 17
        Me.btn_Actualizar_Alarma.Text = "Actualizar Alarma"
        Me.btn_Actualizar_Alarma.UseVisualStyleBackColor = True
        '
        'btn_Volver
        '
        Me.btn_Volver.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Volver.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Volver.Location = New System.Drawing.Point(357, 147)
        Me.btn_Volver.Name = "btn_Volver"
        Me.btn_Volver.Size = New System.Drawing.Size(97, 32)
        Me.btn_Volver.TabIndex = 18
        Me.btn_Volver.Text = "<< Volver"
        Me.btn_Volver.UseVisualStyleBackColor = True
        '
        'btn_Actualizar_Modo
        '
        Me.btn_Actualizar_Modo.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Actualizar_Modo.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Actualizar_Modo.Location = New System.Drawing.Point(564, 77)
        Me.btn_Actualizar_Modo.Name = "btn_Actualizar_Modo"
        Me.btn_Actualizar_Modo.Size = New System.Drawing.Size(197, 51)
        Me.btn_Actualizar_Modo.TabIndex = 19
        Me.btn_Actualizar_Modo.Text = "Actualizar Tiempo de Refresco"
        Me.btn_Actualizar_Modo.UseVisualStyleBackColor = True
        '
        'lbl_unidad_uS_1
        '
        Me.lbl_unidad_uS_1.AutoSize = True
        Me.lbl_unidad_uS_1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_unidad_uS_1.Location = New System.Drawing.Point(504, 40)
        Me.lbl_unidad_uS_1.Name = "lbl_unidad_uS_1"
        Me.lbl_unidad_uS_1.Size = New System.Drawing.Size(38, 19)
        Me.lbl_unidad_uS_1.TabIndex = 20
        Me.lbl_unidad_uS_1.Text = "[uS]"
        '
        'lbl_unidad_uS_2
        '
        Me.lbl_unidad_uS_2.AutoSize = True
        Me.lbl_unidad_uS_2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_unidad_uS_2.Location = New System.Drawing.Point(504, 84)
        Me.lbl_unidad_uS_2.Name = "lbl_unidad_uS_2"
        Me.lbl_unidad_uS_2.Size = New System.Drawing.Size(44, 19)
        Me.lbl_unidad_uS_2.TabIndex = 21
        Me.lbl_unidad_uS_2.Text = "[seg]"
        '
        'frm_Parametros
        '
        Me.AcceptButton = Me.btn_Volver
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn_Volver
        Me.ClientSize = New System.Drawing.Size(810, 193)
        Me.Controls.Add(Me.lbl_unidad_uS_2)
        Me.Controls.Add(Me.lbl_unidad_uS_1)
        Me.Controls.Add(Me.btn_Actualizar_Modo)
        Me.Controls.Add(Me.btn_Volver)
        Me.Controls.Add(Me.btn_Actualizar_Alarma)
        Me.Controls.Add(Me.txt_Nivel_Umbral)
        Me.Controls.Add(Me.txt_Nivel_Alarma)
        Me.Controls.Add(Me.chk_Modo_Diferencial)
        Me.Controls.Add(Me.chk_Alarma_Activa)
        Me.Controls.Add(Me.lbl_Nivel_Umbral)
        Me.Controls.Add(Me.lbl_Nivel_Alarma)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Parametros"
        Me.Text = "Ajustar Parámetros"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_Nivel_Alarma As System.Windows.Forms.Label
    Friend WithEvents lbl_Nivel_Umbral As System.Windows.Forms.Label
    Friend WithEvents chk_Alarma_Activa As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Modo_Diferencial As System.Windows.Forms.CheckBox
    Friend WithEvents txt_Nivel_Alarma As System.Windows.Forms.TextBox
    Friend WithEvents txt_Nivel_Umbral As System.Windows.Forms.TextBox
    Friend WithEvents btn_Actualizar_Alarma As System.Windows.Forms.Button
    Friend WithEvents btn_Volver As System.Windows.Forms.Button
    Friend WithEvents btn_Actualizar_Modo As System.Windows.Forms.Button
    Friend WithEvents lbl_unidad_uS_1 As System.Windows.Forms.Label
    Friend WithEvents lbl_unidad_uS_2 As System.Windows.Forms.Label
End Class
