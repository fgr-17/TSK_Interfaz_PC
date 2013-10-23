Public Class frm_Inicializar_Comunicacion

    Private Sub btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancelar.Click

        Me.Hide()
        'TSK100_Interfaz.Show()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim COM_Seleccionado As String
        Dim cadena_leida() As Byte = {&H0&, &H0&, &H0&, &H0&, &H0&, &H0&, &H0&}
        ' Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}
        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0}
        COM_Seleccionado = C_Puertos.Text                                                       ' Guardo el puerto COM seleccionad

        If COM_Seleccionado = "" Then                                                           ' Pregunto si se seleccionó algún item

            MsgBox("Debe seleccionar un puerto de comunicación serie válido en la PC", _
                    MsgBoxStyle.Critical, "Error de configuración")

        Else

            SP.Crear_Puerto(COM_Seleccionado)

            If (SP._serialPort.IsOpen) Then

                SP.TSK_Conectado = False
                TSK100_Interfaz.Img_Estado.Image = WindowsApplication1.My.Resources.TSK100_CONFIGURACION_DESCONECTADO
                cmd_out = Seleccionar_Comando(CMD_ESTAS)

                If (SP.Enviar_Comando(cmd_out, False, True) = True) Then

                    MsgBox("La comunicación fue establecida correctamente", MsgBoxStyle.Information, "Comunicación Establecida")
                    TSK100_Interfaz.Img_Estado.Image = WindowsApplication1.My.Resources.TSK100_CONFIGURACION_CONECTADO
                    TSK100_Interfaz.lbl_conexion.Text = "CONECTADO"
                    TSK100_Interfaz.timer_horario.Enabled = True
                    SP.Estado_Recepcion = SP.Estados_Recibir_Datos.RECIBO_HORA
                    SP.TSK_Conectado = True

                Else

                    MsgBox("El puerto está configurado correctamente pero hubo un error en la cadena recibida. Vuelva a intentarlo", _
                    MsgBoxStyle.Exclamation, "Error de Comunicación")

                End If

                Me.Hide()

        End If
        End If
    End Sub

    Private Sub frm_Inicializar_Comunicacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim j As Integer

        For j = 0 To My.Computer.Ports.SerialPortNames.Count - 1

            C_Puertos.Items.Add(My.Computer.Ports.SerialPortNames(j))

        Next

    End Sub

End Class