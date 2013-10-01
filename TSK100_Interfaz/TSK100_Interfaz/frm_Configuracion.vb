Public Class frm_Configuracion

    Private Sub btn_Calibracion_Temperatura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Calibracion_Temperatura.Click

        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}

        cmd_out = Seleccionar_Comando(CMD_INICT)

        If (SP.Enviar_Comando(cmd_out, False) = True) Then

            SP.Estado_Recepcion = SP.Estados_Recibir_Datos.RECIBO_TEMPERATURA

            frm_Calibracion_Temperatura.Show()
            Me.Hide()
            frm_Calibracion_Temperatura.timer_temperatura.Enabled = True

        Else
            MsgBox("Error al intentar conectarse con el equipo", MsgBoxStyle.Critical, "Error de Comunicación")
        End If

    End Sub

    Private Sub btn_Volver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Volver.Click

        SP.Estado_Recepcion = SP.Estados_Recibir_Datos.RECIBO_HORA
        Me.Hide()

    End Sub

    Private Sub btn_Calibracion_Conductividad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Calibracion_Conductividad.Click

        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}

        cmd_out = Seleccionar_Comando(CMD_INICK)

        If (SP.Enviar_Comando(cmd_out, False) = True) Then
            SP.Estado_Recepcion = SP.Estados_Recibir_Datos.RECIBO_CONDUCTIVIDAD
            frm_Calibracion_Conductividad.Show()
            frm_Aguardar_Conductividad.Show()

            Me.Hide()
            frm_Calibracion_Conductividad.timer_conductividad.Enabled = True
            frm_Aguardar_Conductividad.Focus()

        Else
            MsgBox("Error al intentar conectarse con el equipo", MsgBoxStyle.Critical, "Error de Comunicación")
        End If

    End Sub

    Private Sub btn_Setear_FyH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Setear_FyH.Click

        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}

        cmd_out = Seleccionar_Comando(CMD_SEFYH)

        If (SP.Enviar_Comando(cmd_out, False) = True) Then

            SP.Estado_Recepcion = SP.Estados_Recibir_Datos.RECIBO_CONDUCTIVIDAD
            frm_Fecha_y_Hora.Show()
            Me.Hide()

        Else

            MsgBox("Error al intentar conectarse con el equipo. Intente nuevamente.", MsgBoxStyle.Critical, "Error de Comunicación")

        End If


    End Sub

    Private Sub btn_Ajustar_Parametros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Ajustar_Parametros.Click
        frm_Parametros.Show()
        Me.Hide()
    End Sub

End Class