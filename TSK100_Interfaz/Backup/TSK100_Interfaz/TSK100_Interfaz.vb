Imports System
Imports System.IO.Ports
Imports System.Text


Public Class TSK100_Interfaz

    Private Sub timer_horario_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer_horario.Tick

        If (SP.TSK_Conectado = False) Then

        End If

        lbl_horario.Text = SP.horario
        lbl_fecha.Text = SP.fecha

    End Sub

    Private Sub btn_Inicializar_Comunicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Inicializar_Comunicacion.Click

        frm_Inicializar_Comunicacion.Show()

    End Sub

    Private Sub btn_Iniciar_Adquisicion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Iniciar_Adquisicion.Click

        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}



        cmd_out = Seleccionar_Comando(CMD_INIMA)

        If (SP.Enviar_Comando(cmd_out, False) = True) Then
            SP.Estado_Recepcion = SP.Estados_Recibir_Datos.RECIBO_CONDUCTIVIDAD
            MsgBox("Adquisición Inicializada", MsgBoxStyle.Information, "Adquisición de Datos")

        Else
            MsgBox("Error al intentar conectarse con el equipo", MsgBoxStyle.Critical, "Error de Comunicación")
        End If


    End Sub

    Private Sub btn_Obtener_Datos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Obtener_Datos.Click

        '        Const LARGO_NOMBRE_ARCHIVO = 10

        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}
        Dim cadena_in(100) As Char

        Dim leyo_dato As Boolean = False
        Dim leyo_cadena_fin As Boolean = False
        ' Dim tag_ini As Char
        Dim insistir As Boolean = True
        ' Dim Indice_Archivo As Integer = 0

        cmd_out = Seleccionar_Comando(CMD_INIDE)

        If (SP.Enviar_Comando(cmd_out, False) = True) Then

            frm_Aguardar_Lista_Archivos.Show()


            'SP.TSK_Conectado = False                                                                        ' Desconecto para manejar la comunicación localmente
            'SP.Indice_Archivo = 0                                                                           ' Inicializo el contador de archivos
            'SP.Enviando_Nombres = True                                                                      ' Señalizo para el timer

            'While (leyo_cadena_fin = False)

            '    leyo_dato = False

            '    If (SP._serialPort.BytesToRead = LARGO_NOMBRE_ARCHIVO) Then
            '        Try
            '            SP._serialPort.Read(cadena_in, 0, LARGO_NOMBRE_ARCHIVO)                        
            '            leyo_dato = True                                                                            ' Si no pudo leer, bajo el flag
            '        Catch
            '            leyo_dato = False                                                                           ' Si no pudo leer, bajo el flag
            '        End Try
            '    End If

            '    If leyo_dato = True Then

            '        tag_ini = cadena_in(0)                                                                          ' Tag de inicio de la cadena

            '        If tag_ini = "*" Then

            '            SP.Lista_Archivos(SP.Indice_Archivo) = CStr(cadena_in).Substring(1)                         ' recibo el nombre de un archivo
            '            SP.Indice_Archivo += 1

            '            insistir = True
            '            While (insistir)
            '                cmd_out = Seleccionar_Comando(CMD_ARCOK)
            '                If (SP.Enviar_Comando(cmd_out, False, True) = True) Then
            '                    insistir = False
            '                Else
            '                    Sleep(50)
            '                End If
            '            End While

            '        ElseIf tag_ini = "!" Then

            '            leyo_cadena_fin = True
            '            SP.TSK_Conectado = True
            '            frm_Aguardar_Lista_Archivos.Hide()
            '            frm_Obtener_Datos.Show()

            '        Else
            '            ' si no tiene el tag, es un error
            '        End If
            '    End If

            'End While

        Else
            MsgBox("Error al intentar conectarse con el equipo", MsgBoxStyle.Critical, "Error de Comunicación")
        End If

    End Sub

    Private Sub btn_Configuracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Configuracion.Click
        frm_Configuracion.Show()
    End Sub

    Private Sub btn_Reiniciar_Equipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Reiniciar_Equipo.Click

        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}
        Dim cant_reenvios As Integer = 0
        Dim cmd_aceptado As Boolean = False

        Const CANT_REENVIOS_MAX = 5

        cmd_out = Seleccionar_Comando(CMD_CONFI)

        While (cant_reenvios < CANT_REENVIOS_MAX)

            If (SP.Enviar_Comando(cmd_out, False) = True) Then
                SP.Estado_Recepcion = SP.Estados_Recibir_Datos.RECIBO_HORA                                              ' Se recibió bien el reset
                cant_reenvios = CANT_REENVIOS_MAX                                                                       ' Termino el envío del comando
                cmd_aceptado = True
            Else
                cant_reenvios += 1
                Sleep(1000)
            End If

        End While

        If (cmd_aceptado = False) Then MsgBox("Error al intentar conectarse con el equipo", MsgBoxStyle.Critical, "Error de Comunicación")

    End Sub

    Private Sub btn_Conectar_Slave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Conectar_Slave.Click

        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}

        If (btn_Conectar_Slave.Text = "Conectar Slave") Then

            cmd_out = Seleccionar_Comando(CMD_INIRE)
            If (SP.Enviar_Comando(cmd_out, False) = True) Then
                btn_Conectar_Slave.Text = "Desconectar Slave"
                MsgBox("Equipo secundario conectado", MsgBoxStyle.Information, "Conexión de equipos")
                Img_Estado.Image = WindowsApplication1.My.Resources.TSK100_CONFIGURACION_REPETIDOR
                btn_Obtener_Datos.Enabled = False
                btn_Iniciar_Adquisicion.Enabled = False
            End If

        ElseIf (btn_Conectar_Slave.Text = "Desconectar Slave") Then

            cmd_out = Seleccionar_Comando(CMD_FINRE)
            If (SP.Enviar_Comando(cmd_out, False) = True) Then
                btn_Conectar_Slave.Text = "Conectar Slave"
                MsgBox("Equipo primario conectado", MsgBoxStyle.Information, "Conexión de equipos")
                Img_Estado.Image = WindowsApplication1.My.Resources.TSK100_CONFIGURACION_CONECTADO
                btn_Obtener_Datos.Enabled = True
                btn_Iniciar_Adquisicion.Enabled = True
            End If

        End If

    End Sub
End Class
