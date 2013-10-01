Imports System
Imports System.Text
Imports System.IO
Imports System.IO.Ports
Imports System.Collections


Public Class SP

    Public Shared valor As Integer = 1
    ' Variables globales:
    Public Shared TSK_Conectado As Boolean = False
    Public Shared horario As String = "--:--:--"
    Public Shared fecha As String = "--/--/----"

    Public Shared Temperatura As Single = 0

    Public Shared adc_medido As Single = 0
    Public Shared Pendiente_Resistencia As Single = 0
    Public Shared Offset_Resistencia As Single = 0

    Public Shared adc_medido_numerador As Single
    Public Shared adc_medido_denominador As Single
    Public Shared Pendiente_Conductividad As Single = 0
    Public Shared Offset_Conductividad As Single = 0

    Public Shared Lista_Archivos(50) As String
    Public Shared Indice_Archivo As Integer = 0
    Public Shared Enviando_Nombres As Boolean = False

    Public Shared Buffer_Externo() As Byte = {&H0, &H0, &H0, &H0, &H0}
    Public Shared Buffer_Externo_Listo As Boolean = False

    ' Definiciones de constantes para la configuración del puerto serie
    Const BAUD_RATE_DEFAULT = 9600                                      ' Velocidad de transmisión por default
    Const PARITY_DEFAULT = Parity.None                                  ' Sin paridad
    Const DATA_BITS_DEFAULT = 8                                         ' 8 bits de datos
    Const STOP_BITS_DEFAULT = StopBits.One                              ' Sin bits de stop
    Const HANDSHAKE_DEFAULT = Handshake.None                            ' Sin handshake       
    Const RECIEVED_BYTES_THRESHOLD = LARGO_FRAME                        ' Cantidad de bytes del buffer antes de un evento
    Const RECIEVED_BYTES_ARCHIVOS_THRESHOLD = 10                        ' Cantidad de bytes del buffer antes de un evento, para recibir nombres de archivo
    Const READ_TIMEOUT_DEFAULT = 1000                                   ' Timeout de lectura [ms]
    Const WRITE_TIMEOUT_DEFAULT = 1000                                  ' Timeout de escritura [ms]

    ' Definición del puerto serie
    Public Shared WithEvents _serialPort As New SerialPort

    ' Estados de procesamiento de los datos recibidos
    Public Enum Estados_Recibir_Datos

        RECIBO_NADA = 0                                                 ' Estado Inicial
        RECIBO_HORA = 1                                                 ' Recibo un valor de hora "-hms-"
        RECIBO_TEMPERATURA = 2                                          ' Recibo un valor de temperatura "T...T"
        RECIBO_CONDUCTIVIDAD = 3                                        ' Recibo un valor de conductividad "K...."
        RECIBO_LECTURA_EXTERNA = 4                                      ' Recibo el dato en un buffer público para ser leído externamente
        RECIBO_ARCHIVO = 5                                              ' Recibo el contenido de un archivo

    End Enum

    Public Shared Estado_Recepcion As Estados_Recibir_Datos = Estados_Recibir_Datos.RECIBO_NADA

    Private Shared Function Bytes_a_Word(ByVal cadena_prueba() As Byte, ByVal indice_ini As Short) As Single

        Dim dato_b0, dato_b1 As Byte
        Dim dato_entero_b As Integer
        Dim dato_entero As Single

        dato_b1 = cadena_prueba(indice_ini)
        dato_b0 = cadena_prueba(indice_ini + 1)

        If (dato_b1 And &H80) Then                                          ' Me fijo si el número recibido es negativo

            dato_b1 = Not dato_b1
            dato_b0 = Not dato_b0

            dato_entero_b += dato_b1
            dato_entero_b <<= 8
            dato_entero_b += dato_b0

            dato_entero_b += 1                                              ' Sumo uno porque hice el complemento a 2
            dato_entero_b *= -1                                             ' El número era negativo
        Else

            dato_entero_b += dato_b1
            dato_entero_b <<= 8
            dato_entero_b += dato_b0

        End If

        dato_entero = (dato_entero_b)

        Return dato_entero


    End Function

    Private Shared Function Bytes_a_DWord(ByVal cadena_prueba() As Byte, ByVal indice_ini As Short) As Single

        Dim dato_b0, dato_b1, dato_b2, dato_b3 As Byte

        Dim dato_b1_desplazado As Integer
        Dim dato_b2_desplazado As Integer
        Dim dato_b3_desplazado As Integer

        Dim dato_entero_b As Integer
        Dim dato_entero As Single

        dato_b3 = cadena_prueba(indice_ini)                                 ' Copio el Byte más significativo y los demás
        dato_b2 = cadena_prueba(indice_ini + 1)
        dato_b1 = cadena_prueba(indice_ini + 2)
        dato_b0 = cadena_prueba(indice_ini + 3)

        If (dato_b3 And &H80) Then                                          ' Me fijo si el número recibido es negativo

            dato_b3 = Not dato_b3
            dato_b2 = Not dato_b2
            dato_b1 = Not dato_b1
            dato_b0 = Not dato_b0

            dato_b3_desplazado = dato_b3
            dato_b3_desplazado <<= 24

            dato_b2_desplazado += dato_b2
            dato_b2_desplazado <<= 16

            dato_b1_desplazado += dato_b1
            dato_b1_desplazado <<= 8

            dato_entero_b += dato_b0 + dato_b1_desplazado + dato_b2_desplazado + dato_b3_desplazado

            dato_entero_b += 1                                              ' Sumo uno porque hice el complemento a 2
            dato_entero_b *= -1                                             ' El número era negativo
        Else

            dato_b3_desplazado = dato_b3
            dato_b3_desplazado <<= 24

            dato_b2_desplazado += dato_b2
            dato_b2_desplazado <<= 16

            dato_b1_desplazado += dato_b1
            dato_b1_desplazado <<= 8

            dato_entero_b += dato_b0 + dato_b1_desplazado + dato_b2_desplazado + dato_b3_desplazado

        End If

        dato_entero = (dato_entero_b)

        Return dato_entero

    End Function

    Public Shared Sub Crear_Puerto(ByVal PortName_Ingresado)

        Try
            If _serialPort.IsOpen Then
                _serialPort.Close()
            End If

            _serialPort.Parity = PARITY_DEFAULT
            _serialPort.PortName = PortName_Ingresado
            _serialPort.BaudRate = BAUD_RATE_DEFAULT
            _serialPort.DataBits = DATA_BITS_DEFAULT
            _serialPort.StopBits = STOP_BITS_DEFAULT
            _serialPort.Handshake = HANDSHAKE_DEFAULT
            _serialPort.ReadTimeout = READ_TIMEOUT_DEFAULT
            _serialPort.WriteTimeout = WRITE_TIMEOUT_DEFAULT
            _serialPort.ReceivedBytesThreshold = RECIEVED_BYTES_THRESHOLD

            _serialPort.Open()

        Catch validez As System.IO.IOException

            MsgBox("El puerto seleccionado no es válido", MsgBoxStyle.Critical, "Error de Configuración")

        Catch acceso As System.UnauthorizedAccessException

            MsgBox("El sistema operativo no provee acceso al puerto seleccionado", MsgBoxStyle.Critical, "Error de Configuración")

        End Try

    End Sub

    Shared Sub DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) _
    Handles _serialPort.DataReceived

        ' Variables asociadas al horario
        Const TAG_INI_INDICE = 0

        Dim hour(1), min(1), sec(1) As Char
        Dim day(1), mon(1), year(1) As Char
        Dim hour_BCD, min_BCD, sec_BCD As Byte
        Dim day_BCD, mon_BCD, year_BCD_h, year_BCD_l As Byte

        ' Variables asociadas a la temperatura
        Dim dato_entero As Single

        ' Tag de inicio y fin de cadena para validación
        Dim tag_ini As Char

        ' Variables asociadas a la transmisión de strings
        Dim cadena_prueba() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, _
                                       &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, _
                                       &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0}
        Dim CRC_Recibido As Integer
        Dim largo_recepcion As Integer

        Dim refrescar As Boolean = True                                                         ' Supongo que voy a refrescar los datos

        Dim enc As Encoding = Encoding.UTF8
        Dim path_actual As String


        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}

        If TSK_Conectado = True Then                                                            ' Chequeo si el equipo ya está conectado

            largo_recepcion = _serialPort.ReceivedBytesThreshold

            Try
                _serialPort.Read(cadena_prueba, 0, largo_recepcion)                             ' Pruebo leer
                _serialPort.DiscardInBuffer()                                                   ' elimino el resto de los bytes
            Catch tout As System.TimeoutException                                               ' Si hubo una excepción por timeout
                refrescar = False                                                               ' No refresco nada y salgo
            End Try

            If (refrescar) Then                                                                 ' En caso que el dato esté listo

                If Estado_Recepcion <> Estados_Recibir_Datos.RECIBO_ARCHIVO Then         ' Los nombres de archivos vienen sin CRC
                    CRC_Recibido = CRC16(cadena_prueba, largo_recepcion)                        ' Chequeo 
                End If

                If (CRC_Recibido = 0) Then

                    Select Case Estado_Recepcion

                        Case Estados_Recibir_Datos.RECIBO_HORA

                            tag_ini = Chr(cadena_prueba(TAG_INI_INDICE))

                            If tag_ini = "-" Then

                                hour_BCD = cadena_prueba(1)
                                min_BCD = cadena_prueba(2)
                                sec_BCD = cadena_prueba(3)

                                hour(1) = Chr(Asc("0") + (hour_BCD And &H10F))
                                hour(0) = Chr(Asc("0") + ((hour_BCD >> 4) And &H10F))
                                min(1) = Chr(Asc("0") + (min_BCD And &H10F))
                                min(0) = Chr(Asc("0") + ((min_BCD >> 4) And &H10F))
                                sec(1) = Chr(Asc("0") + (sec_BCD And &H10F))
                                sec(0) = Chr(Asc("0") + ((sec_BCD >> 4) And &H10F))

                                horario = hour & ":" & min & ":" & sec

                            ElseIf tag_ini = "/" Then

                                day_BCD = cadena_prueba(1)
                                mon_BCD = cadena_prueba(2)
                                year_BCD_h = cadena_prueba(3)
                                year_BCD_l = cadena_prueba(4)

                                day(1) = Chr(Asc("0") + (day_BCD And &H10F))
                                day(0) = Chr(Asc("0") + ((day_BCD >> 4) And &H10F))
                                mon(1) = Chr(Asc("0") + (mon_BCD And &H10F))
                                mon(0) = Chr(Asc("0") + ((mon_BCD >> 4) And &H10F))
                                year(1) = Chr(Asc("0") + (year_BCD_h And &H10F))
                                year(0) = Chr(Asc("0") + ((year_BCD_h >> 4) And &H10F))

                                fecha = day & "/" & mon & "/" & year

                            End If

                        Case Estados_Recibir_Datos.RECIBO_TEMPERATURA

                            tag_ini = Chr(cadena_prueba(0))                                     ' Copio el primer caracter de la cadena

                            dato_entero = Bytes_a_DWord(cadena_prueba, 1)

                            If (tag_ini = "d") Then
                                adc_medido = dato_entero
                            ElseIf (tag_ini = "p") Then
                                Pendiente_Resistencia = dato_entero
                            ElseIf (tag_ini = "o") Then
                                Offset_Resistencia = dato_entero
                            End If

                        Case Estados_Recibir_Datos.RECIBO_CONDUCTIVIDAD

                            tag_ini = Chr(cadena_prueba(0))                                     ' Copio el primer caracter de la cadena

                            If (tag_ini = "d") Then
                                adc_medido_numerador = Bytes_a_Word(cadena_prueba, 1)           ' Recibo las 2 conversiones
                                adc_medido_denominador = Bytes_a_Word(cadena_prueba, 3)         ' empaquetadas en una cadena. 2 datos de 16 bits c/u
                                frm_Aguardar_Conductividad.Close()
                            ElseIf (tag_ini = "i") Then
                                frm_Aguardar_Conductividad.Close()
                                adc_medido_numerador = Bytes_a_DWord(cadena_prueba, 1)
                            ElseIf (tag_ini = "v") Then
                                frm_Aguardar_Conductividad.Close()
                                adc_medido_denominador = Bytes_a_DWord(cadena_prueba, 1)
                            ElseIf (tag_ini = "t") Then
                                frm_Aguardar_Conductividad.Close()
                                Temperatura = Bytes_a_DWord(cadena_prueba, 1)
                            ElseIf (tag_ini = "p") Then
                                Pendiente_Conductividad = Bytes_a_DWord(cadena_prueba, 1)                       ' Recibo la pendiente de calibración                                
                            ElseIf (tag_ini = "o") Then
                                Offset_Conductividad = Bytes_a_DWord(cadena_prueba, 1)                          ' Recibo el offset de calibración                                
                            End If

                        Case Estados_Recibir_Datos.RECIBO_NADA

                        Case Estados_Recibir_Datos.RECIBO_ARCHIVO

                            tag_ini = ChrW(cadena_prueba(0))                                                    ' Tag de inicio de la cadena

                            If tag_ini = "a" Then
                                ' cls_archivo.stream_in = cls_archivo.stream_in & (enc.GetString(cadena_prueba)).Substring(1)    ' recibo el nombre de un archivo
                                frm_Obtener_Datos.Extraer_Datos_Stream_Archivo(cadena_prueba, cls_archivo.stream_in)
                            ElseIf tag_ini = "f" Then
                                path_actual = System.AppDomain.CurrentDomain.BaseDirectory

                                cls_archivo.obj_FSO = CreateObject("Scripting.FileSystemObject")
                                cls_archivo.archivo = cls_archivo.obj_FSO.CreateTextFile(path_actual & cls_archivo.nombre_archivo, True)
                                cls_archivo.archivo.write(cls_archivo.stream_in)
                                cls_archivo.archivo.close()

                                MsgBox("El archivo fue descargado correctamente", MsgBoxStyle.Information, "Descarga de datos")

                                ' frm_Aguardar_Descarga.Close()

                                SP._serialPort.ReceivedBytesThreshold = LARGO_FRAME
                                Estado_Recepcion = Estados_Recibir_Datos.RECIBO_HORA

                            Else
                                SP._serialPort.ReceivedBytesThreshold = LARGO_FRAME
                                Estado_Recepcion = Estados_Recibir_Datos.RECIBO_HORA                                        ' si no tiene el tag, es un error, vuelvo al estado inicial
                            End If

                        Case Estados_Recibir_Datos.RECIBO_LECTURA_EXTERNA

                            Buffer_Externo = Extraer_Comando(cadena_prueba)
                            Buffer_Externo_Listo = True

                    End Select

                Else
                    ' Error en el CRC
                End If
            Else
                ' Timeout
            End If

        Else
            ' Desconectado
        End If

    End Sub

    Public Shared Function Enviar_Comando(ByVal cmd_out() As Byte, ByVal Insistir As Boolean, Optional ByVal Forzar_Conexion As Boolean = False) As Boolean

        Const CONTADOR_INSISTIR = 3

        Dim cuenta_insistir As Integer = 0

        Dim cadena_leida() As Byte = {&H0&, &H0&, &H0&, &H0&, &H0&, &H0&, &H0&}
        Dim cmd_leido() As Byte = {&H0&, &H0&, &H0&, &H0&, &H0&}
        Dim cmd_esperado() As Byte = {&H0&, &H0&, &H0&, &H0&, &H0&}

        Dim CRC_Recibido As Integer

        Dim Exito_Envio As Boolean = False
        Dim Timeout_TX As Boolean = False


        If TSK_Conectado = True Or Forzar_Conexion = True Then

            Concatenar_CRC(cmd_out, LARGO_FRAME)                                            ' agrego el CRC

            For cuenta_insistir = 0 To CONTADOR_INSISTIR                                    ' Repito la escritura N veces o hasta que salga bien

                TSK_Conectado = False
                _serialPort.DiscardOutBuffer()                                              ' Limpio el buffer de salida
                _serialPort.DiscardInBuffer()                                               ' Limpio el buffer de entrada
                _serialPort.Write(cmd_out, 0, cmd_out.Length)                               ' Escribo la cadena en el puerto activo

                Sleep(delay_recepcion)                                                      ' Espero para completar el buffer

                Try
                    _serialPort.Read(cadena_leida, 0, cadena_leida.Length)                  ' Leo los datos recibidos
                Catch ex As System.TimeoutException
                    ' MsgBox("El equipo remoto tardó demasiado en respoder", MsgBoxStyle.Critical, "Error de Comunicación")
                    Timeout_TX = True
                End Try

                If Forzar_Conexion = False Then TSK_Conectado = True

                If Not Timeout_TX Then                                                      ' Pregunto si no hubo un timeout de transmisión

                    CRC_Recibido = CRC16(cadena_leida, LARGO_FRAME)                         ' Hago el CRC de la cadena recibida

                    If (CRC_Recibido = 0) Then                                              ' si no hay error de CRC

                        cmd_esperado = Comando_Esperado(cmd_out)                            ' genero el comando que tendría que recibir si esta todo OK
                        cmd_leido = Extraer_Comando(cadena_leida)                           ' extraigo el comando de la cadena leída

                        If (Decodificar_Comando(cmd_esperado, cmd_leido) = 0) Then          ' si es igual al comando leido
                            Insistir = False                                                ' si está todo OK, no insisto
                            Exito_Envio = True

                            Return Exito_Envio
                        Else
                            ' MsgBox("El comando no fue validado", MsgBoxStyle.Exclamation, "Error de Comunicación")
                        End If
                    Else
                        ' MsgBox("Los datos recibidos no son coherentes", MsgBoxStyle.Exclamation, "Error de Comunicación")
                    End If
                End If

                If Not Insistir Then Exit For ' Si no hace falta insistir, salgo del for     
            Next cuenta_insistir

        Else
            ' si no está conectado no hago nada
        End If

    End Function

End Class

Module Modulo_Comunicacion

    Public Function CRC16(ByRef nData() As Byte, ByVal wLength As Integer) As Integer


        Dim wCRCTable() As Integer = New Integer() _
                            {&H0, &HC0C1, &HC181, &H140, &HC301, &H3C0, &H280, &HC241, _
                            &HC601, &H6C0, &H780, &HC741, &H500, &HC5C1, &HC481, &H440, _
                            &HCC01, &HCC0, &HD80, &HCD41, &HF00, &HCFC1, &HCE81, &HE40, _
                            &HA00, &HCAC1, &HCB81, &HB40, &HC901, &H9C0, &H880, &HC841, _
                            &HD801, &H18C0, &H1980, &HD941, &H1B00, &HDBC1, &HDA81, &H1A40, _
                            &H1E00, &HDEC1, &HDF81, &H1F40, &HDD01, &H1DC0, &H1C80, &HDC41, _
                            &H1400, &HD4C1, &HD581, &H1540, &HD701, &H17C0, &H1680, &HD641, _
                            &HD201, &H12C0, &H1380, &HD341, &H1100, &HD1C1, &HD081, &H1040, _
                            &HF001, &H30C0, &H3180, &HF141, &H3300, &HF3C1, &HF281, &H3240, _
                            &H3600, &HF6C1, &HF781, &H3740, &HF501, &H35C0, &H3480, &HF441, _
                            &H3C00, &HFCC1, &HFD81, &H3D40, &HFF01, &H3FC0, &H3E80, &HFE41, _
                            &HFA01, &H3AC0, &H3B80, &HFB41, &H3900, &HF9C1, &HF881, &H3840, _
                            &H2800, &HE8C1, &HE981, &H2940, &HEB01, &H2BC0, &H2A80, &HEA41, _
                            &HEE01, &H2EC0, &H2F80, &HEF41, &H2D00, &HEDC1, &HEC81, &H2C40, _
                            &HE401, &H24C0, &H2580, &HE541, &H2700, &HE7C1, &HE681, &H2640, _
                            &H2200, &HE2C1, &HE381, &H2340, &HE101, &H21C0, &H2080, &HE041, _
                            &HA001, &H60C0, &H6180, &HA141, &H6300, &HA3C1, &HA281, &H6240, _
                            &H6600, &HA6C1, &HA781, &H6740, &HA501, &H65C0, &H6480, &HA441, _
                            &H6C00, &HACC1, &HAD81, &H6D40, &HAF01, &H6FC0, &H6E80, &HAE41, _
                            &HAA01, &H6AC0, &H6B80, &HAB41, &H6900, &HA9C1, &HA881, &H6840, _
                            &H7800, &HB8C1, &HB981, &H7940, &HBB01, &H7BC0, &H7A80, &HBA41, _
                            &HBE01, &H7EC0, &H7F80, &HBF41, &H7D00, &HBDC1, &HBC81, &H7C40, _
                            &HB401, &H74C0, &H7580, &HB541, &H7700, &HB7C1, &HB681, &H7640, _
                            &H7200, &HB2C1, &HB381, &H7340, &HB101, &H71C0, &H7080, &HB041, _
                            &H5000, &H90C1, &H9181, &H5140, &H9301, &H53C0, &H5280, &H9241, _
                            &H9601, &H56C0, &H5780, &H9741, &H5500, &H95C1, &H9481, &H5440, _
                            &H9C01, &H5CC0, &H5D80, &H9D41, &H5F00, &H9FC1, &H9E81, &H5E40, _
                            &H5A00, &H9AC1, &H9B81, &H5B40, &H9901, &H59C0, &H5880, &H9841, _
                            &H8801, &H48C0, &H4980, &H8941, &H4B00, &H8BC1, &H8A81, &H4A40, _
                            &H4E00, &H8EC1, &H8F81, &H4F40, &H8D01, &H4DC0, &H4C80, &H8C41, _
                            &H4400, &H84C1, &H8581, &H4540, &H8701, &H47C0, &H4680, &H8641, _
                            &H8201, &H42C0, &H4380, &H8341, &H4100, &H81C1, &H8081, &H4040}

        Dim nTemp As Byte
        Dim wCRCWord As Integer = &HFFFF
        Dim nData_index As Integer = 0



        While (wLength > 0)

            nTemp = (nData(nData_index) Xor wCRCWord) And &HFF&

            nData_index = nData_index + 1
            wCRCWord = wCRCWord >> 8
            wCRCWord = wCRCWord Xor wCRCTable(nTemp)

            wLength = wLength - 1

        End While

        Return wCRCWord

    End Function

    Public Function Concatenar_CRC(ByRef frame() As Byte, ByVal l_frame As Integer) As Integer

        Dim CRC As Integer = 0
        Dim CRC_Alto As Byte
        Dim CRC_Bajo As Byte

        CRC = CRC16(frame, l_frame - 2)                 ' Calculo el CRC del frame a transmitir

        CRC_Bajo = CRC And &HFF&                        ' Extraigo la parte baja del CRC de 16bits
        CRC_Alto = (CRC And &HFF00&) >> 8               ' Extraigo la parte alta del CRC de 16bits

        frame(l_frame - 2) = CRC_Bajo                   ' Modifico los valores para agregar el CRC
        frame(l_frame - 1) = CRC_Alto                   ' Parte alta del CRC

        Return 0

    End Function

    Public Function Decodificar_Comando(ByVal cadena_1() As Byte, ByVal cadena_2() As Byte) As Integer

        Dim i As Integer

        For i = 0 To CANT_BYTES_BUFFER - 1

            If cadena_1(i) <> cadena_2(i) Then
                Return 1
            End If

        Next

        Return 0

    End Function

    Public Function Extraer_Comando(ByVal cadena() As Byte) As Byte()

        Dim cmd() As Byte = {&H0&, &H0&, &H0&, &H0&, &H0&}
        Dim i As Integer

        For i = 0 To CANT_BYTES_BUFFER - 1
            cmd(i) = cadena(i)
        Next

        Return cmd

    End Function

End Module
