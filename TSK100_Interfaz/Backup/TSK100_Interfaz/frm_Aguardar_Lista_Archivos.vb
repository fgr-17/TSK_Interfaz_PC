Public Class frm_Aguardar_Lista_Archivos

    Private Sub frm_Aguardar_Lista_Archivos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        timer.Enabled = True
    End Sub

    Private Sub timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer.Tick

        Const LARGO_NOMBRE_ARCHIVO = 10
        Dim tag_ini As Char
        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}
        Dim cadena_in(100) As Char

        Dim leyo_dato As Boolean = False
        Dim leyo_cadena_fin As Boolean = False
        ' Dim tag_ini As Char
        Dim insistir As Boolean = True

        SP.TSK_Conectado = False                                                                        ' Desconecto para manejar la comunicación localmente
        SP.Indice_Archivo = 0                                                                           ' Inicializo el contador de archivos
        SP.Enviando_Nombres = True                                                                      ' Señalizo para el timer

        While (leyo_cadena_fin = False)

            leyo_dato = False

            If (SP._serialPort.BytesToRead = LARGO_NOMBRE_ARCHIVO) Then
                Try
                    SP._serialPort.Read(cadena_in, 0, LARGO_NOMBRE_ARCHIVO)
                    leyo_dato = True                                                                            ' Si no pudo leer, bajo el flag
                Catch
                    leyo_dato = False                                                                           ' Si no pudo leer, bajo el flag
                End Try
            End If

            If leyo_dato = True Then

                tag_ini = cadena_in(0)                                                                          ' Tag de inicio de la cadena

                If tag_ini = "*" Then

                    SP.Lista_Archivos(SP.Indice_Archivo) = CStr(cadena_in).Substring(1)                         ' recibo el nombre de un archivo
                    SP.Indice_Archivo += 1

                    insistir = True
                    While (insistir)
                        cmd_out = Seleccionar_Comando(CMD_ARCOK)
                        If (SP.Enviar_Comando(cmd_out, False, True) = True) Then
                            insistir = False
                        Else
                            Sleep(50)
                        End If
                    End While

                ElseIf tag_ini = "!" Then

                    leyo_cadena_fin = True
                    SP.TSK_Conectado = True
                    Me.Close()

                    frm_Obtener_Datos.Show()
                    frm_Obtener_Datos.timer_lista_archivo.Enabled = True
                Else
                    ' si no tiene el tag, es un error
                End If
            End If

        End While
    End Sub

End Class