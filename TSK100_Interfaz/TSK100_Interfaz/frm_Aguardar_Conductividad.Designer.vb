<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Aguardar_Conductividad
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
        Me.lbl_Etiqueta = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lbl_Etiqueta
        '
        Me.lbl_Etiqueta.AutoSize = True
        Me.lbl_Etiqueta.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Etiqueta.Location = New System.Drawing.Point(50, 44)
        Me.lbl_Etiqueta.Name = "lbl_Etiqueta"
        Me.lbl_Etiqueta.Size = New System.Drawing.Size(268, 38)
        Me.lbl_Etiqueta.TabIndex = 19
        Me.lbl_Etiqueta.Text = "Espere mientras se reciben los " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "parámetros de calibración del equipo"
        '
        'frm_Aguardar_Conductividad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 146)
        Me.Controls.Add(Me.lbl_Etiqueta)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Aguardar_Conductividad"
        Me.Text = "Calibración de Conductividad"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_Etiqueta As System.Windows.Forms.Label
End Class
