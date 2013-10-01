Public Class frm_Calibracion_Conductividad

    Public Const ESCALA_PENDIENTE_CONDUCTIVIDAD = 4                         ' Setear para que quede igual que en el programa del uC
    Public Const ESCALA_COEF_DE_CALIBRACION = 1000                          ' Para que el número sea más legible

    Public compensacion_por_temperatura As Boolean = True

    Public Function Calcular_Factor_de_Compensacion() As Single

        Dim offset_temperatura As Single
        Dim factor_correccion As Single

        offset_temperatura = SP.Temperatura - 250
        factor_correccion = offset_temperatura * (lbl_Coeficiente_de_Temperatura.Text)
        factor_correccion += 1000

        Return factor_correccion

    End Function

    Private Sub btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancelar.Click

        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}
        Dim i As Integer = 0

        cmd_out = Seleccionar_Comando(CMD_CONFI)                                                            ' Selecciono CMD_CONFIGURACION

        If (SP.Enviar_Comando(cmd_out, True) = True) Then                                                   ' Envío comando para volver a configuracion
            SP.Estado_Recepcion = SP.Estados_Recibir_Datos.RECIBO_HORA                                      ' Vuelvo a recibir hora   
            timer_conductividad.Enabled = False                                                             ' Deshabilito timer de conductividad
            Me.Hide()                                                                                       ' Oculto el form de calibración             
            frm_Configuracion.Show()
            Return
        Else
            MsgBox("El equipo perdió la sincronización con la PC. Vuelva a intentarlo o reinicie el equipo.", MsgBoxStyle.Exclamation, "Error de Comunicación")
        End If

    End Sub

    Private Sub timer_temperatura_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer_conductividad.Tick
        Dim conductividad As Single
        Dim coeficiente_calibracion As Single

        lbl_Medicion_ADC_Corriente.Text = SP.adc_medido_numerador
        lbl_Medicion_ADC_Tension.Text = SP.adc_medido_denominador
        lbl_Temperatura_Medida.Text = SP.Temperatura / 10

        If (SP.adc_medido_denominador > 0) Then
            coeficiente_calibracion = SP.adc_medido_numerador / SP.adc_medido_denominador
            conductividad = coeficiente_calibracion
            conductividad *= SP.Pendiente_Conductividad
            conductividad >>= ESCALA_PENDIENTE_CONDUCTIVIDAD
            conductividad += SP.Offset_Conductividad

            If (compensacion_por_temperatura = True) Then
                conductividad *= 1000
                conductividad /= Calcular_Factor_de_Compensacion()
            End If

            lbl_Pendiente_Calculada.Text = SP.Pendiente_Conductividad
            lbl_Offset_Calculado.Text = SP.Offset_Conductividad

            lbl_Conductividad_Medida.Text = conductividad
            lbl_Medicion_Coef_De_Calibracion.Text = coeficiente_calibracion * ESCALA_COEF_DE_CALIBRACION
        Else
            lbl_Conductividad_Medida.Text = "N/A"
        End If
    End Sub

    Private Sub btn_Calibrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Calibrar.Click

        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}

        Dim valor_bajo_ingresado As Single = 0
        Dim valor_alto_ingresado As Single = 0
        Dim valor_bajo_adquirido As Single = 0
        Dim valor_alto_adquirido As Single = 0

        Dim pendiente_f As Double = 0
        Dim offset_f As Double = 0

        Dim factor_correccion As Single

        valor_bajo_adquirido = lbl_Valor_Bajo_Adquirido.Text / ESCALA_COEF_DE_CALIBRACION
        valor_alto_adquirido = lbl_Valor_Alto_Adquirido.Text / ESCALA_COEF_DE_CALIBRACION

        valor_bajo_ingresado = txt_Valor_Bajo_Ingresado.Text
        valor_alto_ingresado = txt_Valor_Alto_Ingresado.Text

        If (valor_bajo_adquirido < 0) Or (valor_alto_ingresado < 0) Or (valor_bajo_adquirido < 0) Or (valor_alto_adquirido < 0) Then
            MsgBox("Los valores ingresados no pueden ser nunca negativos", MsgBoxStyle.Exclamation, "Error de Calibración")
        ElseIf ((valor_bajo_adquirido > valor_alto_adquirido) Or (valor_bajo_ingresado > valor_alto_ingresado)) Then
            MsgBox("Los valores bajos deben ser menores a los valores altos", MsgBoxStyle.Exclamation, "Error de Calibración")
        Else

            If (lbl_Coeficiente_de_Temperatura.Text > 0) Then

                factor_correccion = Calcular_Factor_de_Compensacion()

                valor_alto_ingresado *= factor_correccion
                valor_alto_ingresado /= 1000

                valor_bajo_ingresado *= factor_correccion
                valor_bajo_ingresado /= 1000

            End If

            pendiente_f = ((valor_alto_ingresado - valor_bajo_ingresado) / (valor_alto_adquirido - valor_bajo_adquirido))
            pendiente_f = pendiente_f * (2 ^ ESCALA_PENDIENTE_CONDUCTIVIDAD)

            offset_f = (pendiente_f * valor_bajo_adquirido) >> ESCALA_PENDIENTE_CONDUCTIVIDAD
            offset_f = valor_bajo_ingresado - offset_f

            cmd_out = Seleccionar_Comando(CMD_OKACK)

            If (SP.Enviar_Comando(cmd_out, False) = True) Then                                              ' Envío comando

                Sleep(1000)                                                                                 ' Espero antes de enviar otro dato
                cmd_out = Armar_Cadena_Dato(pendiente_f)                                                    ' armo la cadena del dato a enviar

                If (SP.Enviar_Comando(cmd_out, False) = True) Then                                          ' Envío el dato y chequeo si se mando con exito

                    Sleep(1000)                                                                             ' Espero antes de enviar otra vez el dato
                    cmd_out = Armar_Cadena_Dato(offset_f)                                                   ' armo la cadena del dato a enviar

                    If (SP.Enviar_Comando(cmd_out, False) = True) Then

                        SP.Pendiente_Conductividad = pendiente_f
                        SP.Offset_Conductividad = offset_f
                        MsgBox("La calibración se ha realizado con éxito.", MsgBoxStyle.Information, "Calibración de Conductividad")

                    End If

                End If

            Else
                ' No se recibió bien el OK_CALIBRACION_K, se supone que el equipo 
                ' remoto todavía está en el estado CALIBRACION_T
            End If
        End If

    End Sub

    Private Sub btn_Valor_Bajo_Ingresado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Valor_Bajo_Ingresado.Click
        Dim valor_bajo As Integer
        valor_bajo = Fix(lbl_Medicion_Coef_De_Calibracion.Text)
        lbl_Valor_Bajo_Adquirido.Text = valor_bajo
    End Sub

    Private Sub btn_Valor_Alto_Ingresado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Valor_Alto_Ingresado.Click
        Dim valor_alto As Integer
        valor_alto = Fix(lbl_Medicion_Coef_De_Calibracion.Text)
        lbl_Valor_Alto_Adquirido.Text = lbl_Medicion_Coef_De_Calibracion.Text
    End Sub

    Private Sub btn_Coeficiente_de_Temperatura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Coeficiente_de_Temperatura.Click

        Dim coeficiente_de_temperatura As Single

        If txt_Coeficiente_de_Temperatura.Text = "" Then
            compensacion_por_temperatura = False
        ElseIf Val(txt_Coeficiente_de_Temperatura.Text) = 0 Then
            compensacion_por_temperatura = False
        Else
            coeficiente_de_temperatura = (txt_Coeficiente_de_Temperatura.Text)
            lbl_Coeficiente_de_Temperatura.Text = coeficiente_de_temperatura
            compensacion_por_temperatura = True
        End If
        
    End Sub

    Private Sub lbl_Medicion_Coef_De_Calibracion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbl_Medicion_Coef_De_Calibracion.TextChanged

        frm_Aguardar_Conductividad.Close()

    End Sub

    
End Class