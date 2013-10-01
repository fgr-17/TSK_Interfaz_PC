Public Class frm_Obtener_Datos

    Private Sub btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancelar.Click
        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}

        cmd_out = Seleccionar_Comando(CMD_CONFI)                                                        ' Selecciono CMD_CONFIGURACION

        If (SP.Enviar_Comando(cmd_out, False) = True) Then                                              ' Envío comando para volver a configuracion
            SP.Estado_Recepcion = SP.Estados_Recibir_Datos.RECIBO_HORA                                  ' Vuelvo a recibir hora            
            Me.Hide()                                                                                   ' Oculto el formulario
            TSK100_Interfaz.Show()                                                                      ' Muestro el form ppal.
        Else
            MsgBox("El equipo perdió la sincronización con la PC. Vuelva a intentarlo o reinicie el equipo.", MsgBoxStyle.Exclamation, "Error de Comunicación")
        End If
    End Sub

    Private Sub btn_Seleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Seleccionar.Click

        Dim opcion_archivo As Integer
        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}

        opcion_archivo = lst_Lista_Archivos.SelectedIndex
        cls_archivo.nombre_archivo = lst_Lista_Archivos.Items(opcion_archivo)
        SP._serialPort.ReceivedBytesThreshold = LARGO_FRAME_ARCHIVO

        cmd_out = Armar_Cadena_Dato(opcion_archivo + 1)                                                     ' armo la cadena del dato a enviar

        If (SP.Enviar_Comando(cmd_out, False) = True) Then                                              ' envié el offset con éxito
            frm_Aguardar_Descarga.Show()
            cls_archivo.stream_in = ""                                                                  ' limpio el buffer de entrada
            Encabezado_Archivo_Datos(cls_archivo.stream_in)                                             ' Inicializo el archivo
            SP.Estado_Recepcion = SP.Estados_Recibir_Datos.RECIBO_ARCHIVO                               ' paso al modo de recibir archivo                       
        Else
            MsgBox("El equipo no responde", MsgBoxStyle.Critical, "Descargar datos")                    ' el handshaking salió bien
            SP._serialPort.ReceivedBytesThreshold = LARGO_NOMBRE_ARCHIVO
        End If
    End Sub

    ' Inicialización del archivo : Guardo el encabezado de la tabla
    Public Function Encabezado_Archivo_Datos(ByRef stream_out As String) As Integer

        stream_out = "Hora" & Chr(9) & Chr(9) & Chr(9) & "Cond.A" & Chr(9) & "Temp.A" & Chr(9)
        stream_out &= "Cond.B" & Chr(9) & "Temp.B" & Chr(13) & Chr(9) & Chr(9) & Chr(9) & Chr(9) & " [uS] "
        stream_out &= Chr(9) & " [°C] " & Chr(9) & " [uS] " & Chr(9) & " [°C] " & Chr(13) & Chr(13)

    End Function


    Public Function Extraer_Datos_Stream_Archivo(ByVal cadena() As Byte, ByRef stream_out As String) As Integer

        Const INDEX_HORA = 1
        Const INDEX_MIN = 2
        Const INDEX_SEG = 3
        Const INDEX_K1_0 = 4
        Const INDEX_K1_1 = 5
        Const INDEX_T1_0 = 6
        Const INDEX_T1_1 = 7
        Const INDEX_K2_0 = 8
        Const INDEX_K2_1 = 9
        Const INDEX_T2_0 = 10
        Const INDEX_T2_1 = 11

        Dim hora_char(1), min_char(1), seg_char(1) As Char
        Dim hour_BCD, min_BCD, sec_BCD As Integer
        Dim K1, K2 As Integer
        Dim T1, T2 As Single

        hour_BCD = CInt(cadena(INDEX_HORA))
        min_BCD = CInt(cadena(INDEX_MIN))
        sec_BCD = CInt(cadena(INDEX_SEG))

        hora_char(1) = Chr(Asc("0") + (hour_BCD And &H10F))
        hora_char(0) = Chr(Asc("0") + ((hour_BCD >> 4) And &H10F))

        min_char(1) = Chr(Asc("0") + (min_BCD And &H10F))
        min_char(0) = Chr(Asc("0") + ((min_BCD >> 4) And &H10F))

        seg_char(1) = Chr(Asc("0") + (sec_BCD And &H10F))
        seg_char(0) = Chr(Asc("0") + ((sec_BCD >> 4) And &H10F))

        K1 = CInt(cadena(INDEX_K1_0)) + (CInt(cadena(INDEX_K1_1)) << 8)
        T1 = (CInt(cadena(INDEX_T1_0)) + (CInt(cadena(INDEX_T1_1)) << 8)) / 10
        K2 = CInt(cadena(INDEX_K2_0)) + (CInt(cadena(INDEX_K2_1)) << 8)
        T2 = (CInt(cadena(INDEX_T2_0)) + (CInt(cadena(INDEX_T2_1)) << 8)) / 10

        stream_out &= hora_char & ":" & min_char & ":" & seg_char
        stream_out &= Chr(9) & Chr(9)

        ' Chequeo la longitud de caracteres de los datos para saber si incluyo uno o dos tabulaciones
        If (Str(K1).Length > 3) Then
            stream_out &= Str(K1) & Chr(9)
        Else
            stream_out &= Str(K1) & Chr(9) & Chr(9)
        End If

        If (Str(T1).Length > 3) Then
            stream_out &= Str(T1) & Chr(9)
        Else
            stream_out &= Str(T1) & Chr(9) & Chr(9)
        End If

        If (Str(K2).Length > 3) Then
            stream_out &= Str(K2) & Chr(9)
        Else
            stream_out &= Str(K2) & Chr(9) & Chr(9)
        End If

        stream_out &= Str(T2) & Chr(13)

    End Function

   

    Private Sub timer_lista_archivo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer_lista_archivo.Tick

        Dim i As Integer

        lst_Lista_Archivos.Items.Clear()                                            ' Limpio toda la tabla

        For i = 0 To SP.Indice_Archivo - 1
            lst_Lista_Archivos.Items.Add(SP.Lista_Archivos(i))
        Next

        timer_lista_archivo.Enabled = False

    End Sub

    Private Sub lst_Lista_Archivos_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_Lista_Archivos.TextChanged
        frm_Aguardar_Lista_Archivos.Close()
    End Sub

    Private Sub btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Eliminar.Click

        Dim opcion_archivo As Integer
        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}

        opcion_archivo = lst_Lista_Archivos.SelectedIndex
        cls_archivo.nombre_archivo = lst_Lista_Archivos.Items(opcion_archivo)
        SP._serialPort.ReceivedBytesThreshold = LARGO_FRAME_ARCHIVO

        cmd_out = Armar_Cadena_Dato(-(opcion_archivo + 1))                                              ' armo la cadena del dato a enviar

        If (SP.Enviar_Comando(cmd_out, False) = True) Then                                              ' envié el offset con éxito            
            cls_archivo.stream_in = ""                                                                  ' limpio el buffer de entrada

            MsgBox("El archivo fue eliminado", MsgBoxStyle.Information, "Eliminar Archivos")
            Me.Close()

            SP.Estado_Recepcion = SP.Estados_Recibir_Datos.RECIBO_HORA                                  ' Vuelvo a recibir hora                        
            TSK100_Interfaz.Show()                                                                      ' Muestro el form ppal.

        Else
            MsgBox("El equipo no responde", MsgBoxStyle.Critical, "Descargar datos")                    ' el handshaking salió bien
            SP._serialPort.ReceivedBytesThreshold = LARGO_NOMBRE_ARCHIVO
        End If

    End Sub
End Class

Public Class cls_archivo

    Public Shared obj_FSO As Object
    Public Shared archivo As Object
    Public Shared nombre_archivo As String
    Public Shared stream_in As String = ""
    Public Shared stream_in_char() As Char

End Class
