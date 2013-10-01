<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Obtener_Datos
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
        Me.lst_Lista_Archivos = New System.Windows.Forms.ListBox
        Me.btn_Seleccionar = New System.Windows.Forms.Button
        Me.btn_Cancelar = New System.Windows.Forms.Button
        Me.lbl_Lista_Archivos = New System.Windows.Forms.Label
        Me.timer_lista_archivo = New System.Windows.Forms.Timer(Me.components)
        Me.btn_Eliminar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lst_Lista_Archivos
        '
        Me.lst_Lista_Archivos.FormattingEnabled = True
        Me.lst_Lista_Archivos.Location = New System.Drawing.Point(27, 64)
        Me.lst_Lista_Archivos.Name = "lst_Lista_Archivos"
        Me.lst_Lista_Archivos.Size = New System.Drawing.Size(427, 238)
        Me.lst_Lista_Archivos.TabIndex = 0
        '
        'btn_Seleccionar
        '
        Me.btn_Seleccionar.Location = New System.Drawing.Point(27, 326)
        Me.btn_Seleccionar.Name = "btn_Seleccionar"
        Me.btn_Seleccionar.Size = New System.Drawing.Size(115, 30)
        Me.btn_Seleccionar.TabIndex = 1
        Me.btn_Seleccionar.Text = "Descargar Archivo"
        Me.btn_Seleccionar.UseVisualStyleBackColor = True
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Cancelar.Location = New System.Drawing.Point(339, 326)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(115, 30)
        Me.btn_Cancelar.TabIndex = 2
        Me.btn_Cancelar.Text = "<< Volver"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'lbl_Lista_Archivos
        '
        Me.lbl_Lista_Archivos.AutoSize = True
        Me.lbl_Lista_Archivos.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Lista_Archivos.Location = New System.Drawing.Point(112, 23)
        Me.lbl_Lista_Archivos.Name = "lbl_Lista_Archivos"
        Me.lbl_Lista_Archivos.Size = New System.Drawing.Size(253, 18)
        Me.lbl_Lista_Archivos.TabIndex = 3
        Me.lbl_Lista_Archivos.Text = "Lista de Archivos Almacenados:"
        '
        'timer_lista_archivo
        '
        '
        'btn_Eliminar
        '
        Me.btn_Eliminar.Location = New System.Drawing.Point(182, 326)
        Me.btn_Eliminar.Name = "btn_Eliminar"
        Me.btn_Eliminar.Size = New System.Drawing.Size(115, 30)
        Me.btn_Eliminar.TabIndex = 4
        Me.btn_Eliminar.Text = "Eliminar Archivo"
        Me.btn_Eliminar.UseVisualStyleBackColor = True
        '
        'frm_Obtener_Datos
        '
        Me.AcceptButton = Me.btn_Seleccionar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn_Cancelar
        Me.ClientSize = New System.Drawing.Size(486, 373)
        Me.Controls.Add(Me.btn_Eliminar)
        Me.Controls.Add(Me.lbl_Lista_Archivos)
        Me.Controls.Add(Me.btn_Cancelar)
        Me.Controls.Add(Me.btn_Seleccionar)
        Me.Controls.Add(Me.lst_Lista_Archivos)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Obtener_Datos"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Obtener Datos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lst_Lista_Archivos As System.Windows.Forms.ListBox
    Friend WithEvents btn_Seleccionar As System.Windows.Forms.Button
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents lbl_Lista_Archivos As System.Windows.Forms.Label
    Friend WithEvents timer_lista_archivo As System.Windows.Forms.Timer
    Friend WithEvents btn_Eliminar As System.Windows.Forms.Button
End Class
