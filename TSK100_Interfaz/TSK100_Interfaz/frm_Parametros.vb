Public Class frm_Parametros

    Private Sub chk_Alarma_Activa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Alarma_Activa.CheckedChanged

        If (chk_Alarma_Activa.Checked = True) Then
            txt_Nivel_Alarma.Enabled = True
        ElseIf (chk_Alarma_Activa.Checked = False) Then
            txt_Nivel_Alarma.Enabled = False
        End If

    End Sub

    Private Sub chk_Modo_Diferencial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Modo_Diferencial.CheckedChanged

        If (chk_Modo_Diferencial.Checked = True) Then
            txt_Nivel_Umbral.Enabled = True
        ElseIf (chk_Modo_Diferencial.Checked = False) Then
            txt_Nivel_Umbral.Enabled = False
        End If

    End Sub

    Private Sub btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Volver.Click
        frm_Configuracion.Show()
        Me.Hide()
    End Sub

    Private Sub btn_Actualizar_Alarma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Actualizar_Alarma.Click

        Const ALARMA_MIN As Integer = 1
        Const ALARMA_MAX As Integer = 1000

        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}
        Dim nivel_alarma As Integer

        If ((Val(txt_Nivel_Alarma.Text) < ALARMA_MIN) Or (Val(txt_Nivel_Alarma.Text) > ALARMA_MAX)) And (chk_Alarma_Activa.Checked = True) Then
            MsgBox("El valor de la alarma debe estar comprendido entre 1uS y 1000uS", MsgBoxStyle.Exclamation, "Nivel de alarma no válida")
            Return
        End If


        cmd_out = Seleccionar_Comando(CMD_REALA)

        If (SP.Enviar_Comando(cmd_out, False) = True) Then

            If chk_Alarma_Activa.Checked = True Then
                nivel_alarma = Val(txt_Nivel_Alarma.Text)
            Else
                nivel_alarma = 0
            End If
            Sleep(1000)
            cmd_out = Armar_Cadena_Dato(nivel_alarma)                                                               ' armo la cadena del dato a enviar

            If (SP.Enviar_Comando(cmd_out, False) = True) Then

                MsgBox("El parámetro se actualizó correctamente", MsgBoxStyle.Information, "Actualización de parámetros")

            End If

        Else
            MsgBox("Error al intentar conectarse con el equipo", MsgBoxStyle.Critical, "Error de Comunicación")
        End If


    End Sub

    Private Sub btn_Actualizar_Modo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Actualizar_Modo.Click

        Const UMBRAL_MIN As Integer = 2
        Const UMBRAL_MAX As Integer = 10

        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}
        Dim nivel_umbral As Integer


        If ((Val(txt_Nivel_Alarma.Text) < UMBRAL_MIN) Or (Val(txt_Nivel_Alarma.Text) > UMBRAL_MAX)) And (chk_Modo_Diferencial.Checked = True) Then
            MsgBox("El valor tiempo de refresco debe estar entre 2 seg y 10 seg", MsgBoxStyle.Exclamation, "Tiempo de refresco no válido")
            Return
        End If

        cmd_out = Seleccionar_Comando(CMD_REUMB)

        If (SP.Enviar_Comando(cmd_out, False) = True) Then

            If (chk_Modo_Diferencial.Checked = True) Then
                nivel_umbral = Val(txt_Nivel_Umbral.Text)
            Else
                nivel_umbral = 0
            End If
            Sleep(1000)
            cmd_out = Armar_Cadena_Dato(nivel_umbral)                                                               ' armo la cadena del dato a enviar

            If (SP.Enviar_Comando(cmd_out, False) = True) Then
                MsgBox("El parámetro se actualizó correctamente", MsgBoxStyle.Information, "Actualización de parámetros")
            End If

        Else
            MsgBox("Error al intentar conectarse con el equipo", MsgBoxStyle.Critical, "Error de Comunicación")
        End If

    End Sub

    
End Class