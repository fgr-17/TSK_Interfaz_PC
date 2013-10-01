<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Aguardar_Lista_Archivos
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
        Me.lbl_Etiqueta = New System.Windows.Forms.Label
        Me.timer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lbl_Etiqueta
        '
        Me.lbl_Etiqueta.AutoSize = True
        Me.lbl_Etiqueta.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Etiqueta.Location = New System.Drawing.Point(52, 32)
        Me.lbl_Etiqueta.Name = "lbl_Etiqueta"
        Me.lbl_Etiqueta.Size = New System.Drawing.Size(262, 38)
        Me.lbl_Etiqueta.TabIndex = 17
        Me.lbl_Etiqueta.Text = "Espere mientras la PC obtiene " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "los archivos guardados en el equipo."
        '
        'timer
        '
        '
        'frm_Aguardar_Lista_Archivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 111)
        Me.Controls.Add(Me.lbl_Etiqueta)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Aguardar_Lista_Archivos"
        Me.Text = "Archivos disponibles"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_Etiqueta As System.Windows.Forms.Label
    Friend WithEvents timer As System.Windows.Forms.Timer
End Class
