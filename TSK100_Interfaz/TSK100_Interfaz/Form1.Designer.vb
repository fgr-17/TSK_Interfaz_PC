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
        Me.btn_Inicializar_Comunicacion = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btn_Inicializar_Comunicacion
        '
        Me.btn_Inicializar_Comunicacion.Location = New System.Drawing.Point(190, 232)
        Me.btn_Inicializar_Comunicacion.Name = "btn_Inicializar_Comunicacion"
        Me.btn_Inicializar_Comunicacion.Size = New System.Drawing.Size(138, 38)
        Me.btn_Inicializar_Comunicacion.TabIndex = 0
        Me.btn_Inicializar_Comunicacion.Text = "Inicializar Comunicación"
        Me.btn_Inicializar_Comunicacion.UseVisualStyleBackColor = True
        '
        'TSK100_Interfaz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 562)
        Me.Controls.Add(Me.btn_Inicializar_Comunicacion)
        Me.Name = "TSK100_Interfaz"
        Me.Text = "Interfaz de usuario - TSK100"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Inicializar_Comunicacion As System.Windows.Forms.Button

End Class
