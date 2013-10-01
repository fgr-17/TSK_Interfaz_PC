Public Class frm_Calibracion_Temperatura

    Public Const ESCALA_PENDIENTE_RESISTENCIA = 10
    Public Const DECIMALES_RESISTENCIA = 2

    Private Sub btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancelar.Click

        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}

        cmd_out = Seleccionar_Comando(CMD_CONFI)                                                        ' Selecciono CMD_CONFIGURACION

        If (SP.Enviar_Comando(cmd_out, False) = True) Then                                              ' Envío comando para volver a configuracion
            SP.Estado_Recepcion = SP.Estados_Recibir_Datos.RECIBO_HORA                                  ' Vuelvo a recibir hora
            timer_temperatura.Enabled = False                                                           ' Deshabilito el timer de Temperatura
            Me.Hide()                                                                                   ' Oculto el formulario
            frm_Configuracion.Show()
        Else
            MsgBox("El equipo perdió la sincronización con la PC. Vuelva a intentarlo o reinicie el equipo.", MsgBoxStyle.Exclamation, "Error de Comunicación")
        End If

    End Sub

    Private Sub timer_temperatura_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer_temperatura.Tick
        ' Actualizo la medición de temperatura recibida por puerto serie desde el timer porque en el evento de recepción de datos series
        ' no me permite modificar los valores de una propiedad de un objeto.
        Dim resistencia As Single

        resistencia = SP.adc_medido
        resistencia *= SP.Pendiente_Resistencia
        resistencia >>= ESCALA_PENDIENTE_RESISTENCIA
        resistencia += SP.Offset_Resistencia
        resistencia /= 10 ^ DECIMALES_RESISTENCIA

        lbl_ADC_Medido.Text = SP.adc_medido
        lbl_Resistencia_Medida.Text = resistencia

    End Sub


    Private Sub btn_Calibrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Calibrar.Click

        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}

        Dim valor_bajo_ingresado As Single = 0
        Dim valor_alto_ingresado As Single = 0
        Dim valor_bajo_adquirido As Single = 0
        Dim valor_alto_adquirido As Single = 0

        Dim pendiente_f As Double = 0
        Dim offset_f As Double = 0

        valor_bajo_adquirido = lbl_Valor_Bajo_Adquirido.Text
        valor_alto_adquirido = lbl_Valor_Alto_Adquirido.Text

        valor_bajo_ingresado = txt_Valor_Bajo_Ingresado.Text
        valor_alto_ingresado = txt_Valor_Alto_Ingresado.Text

        If (valor_bajo_adquirido < 0) Or (valor_alto_ingresado < 0) Or (valor_bajo_adquirido < 0) Or (valor_alto_adquirido < 0) Then

            MsgBox("Los valores ingresados no pueden ser nunca negativos", MsgBoxStyle.Exclamation, "Error de Calibración")

        ElseIf ((valor_bajo_adquirido > valor_alto_adquirido) Or (valor_bajo_ingresado > valor_alto_ingresado)) Then

            MsgBox("Los valores bajos deben ser menores a los valores altos", MsgBoxStyle.Exclamation, "Error de Calibración")

        Else

            pendiente_f = (((valor_alto_ingresado - valor_bajo_ingresado) * (10 ^ DECIMALES_RESISTENCIA)) / (valor_alto_adquirido - valor_bajo_adquirido))
            pendiente_f = pendiente_f * (2 ^ ESCALA_PENDIENTE_RESISTENCIA)

            offset_f = (pendiente_f * valor_bajo_adquirido) >> ESCALA_PENDIENTE_RESISTENCIA
            offset_f = (valor_bajo_ingresado * (10 ^ DECIMALES_RESISTENCIA)) - offset_f

            cmd_out = Seleccionar_Comando(CMD_OKACT)

            If (SP.Enviar_Comando(cmd_out, False) = True) Then                                              ' Envío comando

                Sleep(1000)                                                                                 ' Espero antes de enviar otro dato
                cmd_out = Armar_Cadena_Dato(pendiente_f)                                                    ' armo la cadena del dato a enviar

                If (SP.Enviar_Comando(cmd_out, False) = True) Then                                          ' Envío el dato y chequeo si se mando con exito

                    Sleep(1000)                                                                             ' Espero antes de enviar otra vez el dato
                    cmd_out = Armar_Cadena_Dato(offset_f)                                                   ' armo la cadena del dato a enviar

                    If (SP.Enviar_Comando(cmd_out, True) = True) Then                                       ' envié el offset con éxito

                        SP.Pendiente_Resistencia = pendiente_f                                              ' Actualizo los datos: pendiente
                        SP.Offset_Resistencia = offset_f                                                    ' actualizo el offset
                        MsgBox("La calibración se ha realizado con éxito.", MsgBoxStyle.Information, "Calibración de Temperatura")

                    Else

                        MsgBox("timeout offset", MsgBoxStyle.Exclamation)

                    End If
                Else

                    MsgBox("timeout pendiente", MsgBoxStyle.Exclamation)

                End If

            Else
                MsgBox("timeout comando 1", MsgBoxStyle.Exclamation)
                ' No se recibió bien el OK_CALIBRACION_T, se supone que el equipo 
                ' remoto todavía está en el estado CALIBRACION_T
            End If
        End If

    End Sub

    Private Sub btn_Valor_Bajo_Ingresado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Valor_Bajo_Ingresado.Click
        lbl_Valor_Bajo_Adquirido.Text = lbl_ADC_Medido.Text
    End Sub

    Private Sub btn_Valor_Alto_Ingresado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Valor_Alto_Ingresado.Click
        lbl_Valor_Alto_Adquirido.Text = lbl_ADC_Medido.Text
    End Sub


End Class