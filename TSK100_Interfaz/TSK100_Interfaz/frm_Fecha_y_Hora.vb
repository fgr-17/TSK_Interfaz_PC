Public Class frm_Fecha_y_Hora

    Private Sub btn_Establecer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Establecer.Click

        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}

        cmd_out = Armar_Paquete_Hora_BCD(Val(txt_Hora.Text), Val(txt_Minuto.Text), Val(txt_Segundo.Text))               ' armo la cadena del dato a enviar
        If (SP.Enviar_Comando(cmd_out, False) = True) Then                                                              ' Envío el dato y chequeo si se mando con exito
            Sleep(1000)                                                                                                 ' Espero antes de enviar otra vez el dato
            cmd_out = Armar_Paquete_Fecha_BCD(Val(txt_Dia.Text), Val(txt_Mes.Text), Val(txt_Anio.Text))                 ' armo la cadena del dato a enviar
            If (SP.Enviar_Comando(cmd_out, False) = True) Then                                                          ' pregunto si el comando llegó bien
                MsgBox("Se modificó la hora y fecha con éxito.", MsgBoxStyle.Information, "Configuración del Equipo")   ' Muestro éxito
                Me.Hide()
                SP.Estado_Recepcion = SP.Estados_Recibir_Datos.RECIBO_HORA

            End If
        End If

    End Sub

    Private Function Armar_Paquete_Hora_BCD(ByVal hora As Integer, ByVal min As Integer, ByVal seg As Integer) As Byte()

        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}
        Dim hora_BCD, min_BCD, seg_BCD As Byte

        If ((hora > 0) And (hora < 24)) Then hora_BCD = Byte_a_BCD(hora)
        If ((min > 0) And (min < 60)) Then min_BCD = Byte_a_BCD(min)
        If ((seg > 0) And (seg < 60)) Then seg_BCD = Byte_a_BCD(seg)

        cmd_out(0) = Asc("d")
        cmd_out(1) = hora_BCD
        cmd_out(2) = min_BCD
        cmd_out(3) = seg_bcd
        cmd_out(4) = 0

        Return cmd_out

    End Function

    Private Function Armar_Paquete_Fecha_BCD(ByVal dia As Integer, ByVal mes As Integer, ByVal anio As Integer) As Byte()

        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}
        Dim anio_BCD(2) As Byte
        Dim dia_BCD, mes_BCD As Byte

        If ((dia > 0) And (dia < 32)) Then dia_BCD = Byte_a_BCD(dia)
        If ((mes > 0) And (mes < 60)) Then mes_BCD = Byte_a_BCD(mes)
        If (anio > 0) Then anio_BCD = Word_a_BCD(anio)

        cmd_out(0) = Asc("d")
        cmd_out(1) = dia_BCD
        cmd_out(2) = mes_BCD
        cmd_out(3) = anio_BCD(0)
        cmd_out(4) = anio_BCD(1)

        Return cmd_out

    End Function

    Private Sub btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancelar.Click

        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}

        cmd_out = Seleccionar_Comando(CMD_CONFI)                                                        ' Selecciono CMD_CONFIGURACION

        If (SP.Enviar_Comando(cmd_out, False) = True) Then                                              ' Envío comando para volver a configuracion
            SP.Estado_Recepcion = SP.Estados_Recibir_Datos.RECIBO_HORA                                  ' Vuelvo a recibir hora            
            Me.Hide()                                                                                   ' Oculto el formulario
            frm_Configuracion.Show()
        Else
            MsgBox("El equipo perdió la sincronización con la PC. Vuelva a intentarlo o reinicie el equipo.", MsgBoxStyle.Exclamation, "Error de Comunicación")
        End If

    End Sub

    Private Sub frm_Fecha_y_Hora_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txt_Hora.Text = Date.Now.Hour
        txt_Minuto.Text = Date.Now.Minute
        txt_Segundo.Text = Date.Now.Second

        txt_Dia.Text = Date.Now.Day
        txt_Mes.Text = Date.Now.Month
        txt_Anio.Text = Date.Now.Year

        btn_Establecer.Focus()
    End Sub

End Class