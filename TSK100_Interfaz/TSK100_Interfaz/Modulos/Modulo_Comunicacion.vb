Imports System
Imports System.Text
Imports System.IO
Imports System.IO.Ports
Imports System.Collections

' ---------------------------------------------------------------------------------------------
'
' @class    SP
'
' @brief    Clase utilizada para definir todas las variables globales
'
' @var      valor
' @var      TSK_Conectado       flag para determinar conexión o no
' @var      horario             string para guardar la hora a mostrar
' @var      fecha               string para mostrar la fecha
' @var      Temperatura         valor de temperatura guardado
' @var      adc_medido          valor de lectura del ADC recibido desde el micro
' @var      Pendiente_Resistencia   valor recibido/enviado de pendiente de la conversión cuentas/resistencia guardada en el micro
' @var      Offset_Resistencia      valor recibido/enviado de offset de la conversión cuentas/resistencia guardada en el micro
' @var      adc_medido_numerador    valor recibido de cuentas de ADC correspondiente a la corriente (numerador en el calculo de división de conductividad)
' @var      adc_medido_denominador  valor recibido de cuentas de ADC correspondiente a la tensión(denominador en el calculo de división de conductividad)
' @var      Pendiente_Conductividad valor rx/tx de pendiente en la conversión cuentas_corriente/cuentas_tension
' @var      Offset_Conductividad    valor rx/tx de offset en la conversión cuentas_corriente/cuentas_tension
' @var      Lista_Archivo           lista que se muestra con los archivos almacenados en la SD del TSK
' @var      Indice_Archivo          Archivo a seleccionar (están ordenados por núemro)
' @var      Enviando_Nombres        Flag para señalizar si estoy enviando nombres de archivo desde el TSK a la PC
' @var      Buffer_Externo()        ??
' @var      Buffer_Externo_Listo    Flag ???
' 
' @author   Roux, Federico G.
' @mail     rouxfederico@gmail.com
' @company  Nerox
'
' --------------------------------------------------------------------------------------------- 

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


    ' ---------------------------------------------------------------------------------------------
    '
    ' @function Bytes_a_Word
    '
    ' @brief    Recibe una cadena y el índice donde comienza un dato de 2 bytes, y lo convierte a Word
    '
    ' @paramin  cadena_prueba() cadena completa (frame recibido)
    ' @paramin  indice_ini      indice donde comienza el primer byte del word a leer
    '
    ' @paramout Single  Valor del word extraído
    ' 
    ' @author   Roux, Federico G.
    ' @mail     rouxfederico@gmail.com
    ' @company  Nerox
    '
    ' --------------------------------------------------------------------------------------------- 

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

    ' ---------------------------------------------------------------------------------------------
    '
    ' @function Bytes_a_DWord   
    '
    ' @brief    Recibe una cadena y el índice donde comienza un dato de 4 bytes, y lo convierte a Word
    '
    ' @paramin  cadena_prueba() cadena completa (frame recibido)
    ' @paramin  indice_ini      indice donde comienza el primer byte del dword a leer
    '
    ' @paramout Single  Valor del word extraído
    ' 
    ' @author   Roux, Federico G.
    ' @mail     rouxfederico@gmail.com
    ' @company  Nerox
    '
    ' --------------------------------------------------------------------------------------------- 


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

    ' ---------------------------------------------------------------------------------------------
    '
    ' @function Crear_Puerto       
    '
    ' @brief    Recibe el número del COM a configurar y abre el puerto creando el objeto
    '
    ' @paramin  PortName_Ingresado  Número del COM a abrir
    '
    ' @paramout none
    ' 
    ' @author   Roux, Federico G.
    ' @mail     rouxfederico@gmail.com
    ' @company  Nerox
    '
    ' --------------------------------------------------------------------------------------------- 

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

    ' ---------------------------------------------------------------------------------------------
    '
    ' @function DataReceived       
    '
    ' @brief    Handler de la interrupción de la recepción de puerto serie  
    '
    ' @paramin  PortName_Ingresado  Número del COM a abrir
    '
    ' @paramout none
    ' 
    ' @author   Roux, Federico G.
    ' @mail     rouxfederico@gmail.com
    ' @company  Nerox
    '
    ' --------------------------------------------------------------------------------------------- 

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
        Dim tag_bin As Byte

        ' Variables asociadas a la transmisión de strings
        Dim cadena_prueba() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, _
                                       &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, _
                                       &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0}
        ' Dim CRC_Recibido As Integer
        Dim chk_recibido As Integer
        Dim largo_recepcion As Integer

        Dim refrescar As Boolean = True                                                         ' Supongo que voy a refrescar los datos

        Dim enc As Encoding = Encoding.UTF8
        Dim path_actual As String


        ' Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}
        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0}                                       ' 

        If TSK_Conectado = True Then                                                            ' Chequeo si el equipo ya está conectado

            largo_recepcion = _serialPort.ReceivedBytesThreshold                                ' guardo la cantidad de bytes recibidos

            Try
                _serialPort.Read(cadena_prueba, 0, largo_recepcion)                             ' Pruebo leer
                _serialPort.DiscardInBuffer()                                                   ' elimino el resto de los bytes
            Catch tout As System.TimeoutException                                               ' Si hubo una excepción por timeout
                refrescar = False                                                               ' No refresco nada y salgo
            End Try

            If (refrescar) Then                                                                 ' En caso que el dato esté listo

                If Estado_Recepcion <> Estados_Recibir_Datos.RECIBO_ARCHIVO Then                ' Los nombres de archivos vienen sin CRC
                    ' CRC_Recibido = CRC16(cadena_prueba, largo_recepcion)                        ' Chequeo 
                    chk_recibido = Checksum(cadena_prueba, LARGO_FRAME)                         ' Recibo esperando la cantidad fija de bytes

                End If

                If (chk_recibido = 0) Then

                    Select Case Estado_Recepcion

                        Case Estados_Recibir_Datos.RECIBO_HORA                              ' Primer estado : RECIBO_HORA

                            ' tag_ini = Chr(cadena_prueba(TAG_INI_INDICE))                  ' Extraigo byte de tag
                            tag_bin = (cadena_prueba(TAG_INI_INDICE) And &HD0) >> 5          ' Extraigo bits de tag t2t1t0x-xxxx

                            If tag_bin = &H100 Then                                           ' Si el tag es "-", recibí la hora

                                hour_BCD = cadena_prueba(0) And &H1F                        ' Extraigo byte de hora en BCD enmascarando bits de tag
                                min_BCD = cadena_prueba(1)                                  ' Extraigo byte de minuto en BCD
                                sec_BCD = cadena_prueba(2)                                  ' Extraigo byte de segundo en BCD
                                ' ---- Convierto dos digitos para hora, min y seg -----
                                hour(1) = Chr(Asc("0") + (hour_BCD And &H10F))
                                hour(0) = Chr(Asc("0") + ((hour_BCD >> 4) And &H10F))
                                min(1) = Chr(Asc("0") + (min_BCD And &H10F))
                                min(0) = Chr(Asc("0") + ((min_BCD >> 4) And &H10F))
                                sec(1) = Chr(Asc("0") + (sec_BCD And &H10F))
                                sec(0) = Chr(Asc("0") + ((sec_BCD >> 4) And &H10F))

                                horario = hour & ":" & min & ":" & sec                      ' Armo el string que voy a mostrar en pantalla 

                            ElseIf tag_bin = &H10 Then                                       ' Si el tag es "/", recibo la fecha

                                day_BCD = cadena_prueba(1) And &H1F                        ' Extraigo byte de día en BCD
                                mon_BCD = cadena_prueba(2)                                  ' Extraigo byte de mes en BCD
                                ' year_BCD_h = cadena_prueba(3)                               ' Extraigo byte alto de año en BCD
                                year_BCD_l = cadena_prueba(3)                               ' Extraigo byte bajo del año en BCD

                                ' ---- Convierto los 6 digitos a ASCII : ddmmyyyy ----
                                day(1) = Chr(Asc("0") + (day_BCD And &H10F))
                                day(0) = Chr(Asc("0") + ((day_BCD >> 4) And &H10F))
                                mon(1) = Chr(Asc("0") + (mon_BCD And &H10F))
                                mon(0) = Chr(Asc("0") + ((mon_BCD >> 4) And &H10F))
                                year(1) = Chr(Asc("0") + (year_BCD_h And &H10F))
                                year(0) = Chr(Asc("0") + ((year_BCD_h >> 4) And &H10F))

                                fecha = day & "/" & mon & "/" & year                        ' Armo string para mostrar en pantalla

                            End If

                        Case Estados_Recibir_Datos.RECIBO_TEMPERATURA                       ' Segundo estado : RECIBO_TEMPERATURA

                            tag_ini = Chr(cadena_prueba(0))                                 ' Copio el primer caracter de la cadena

                            dato_entero = Bytes_a_DWord(cadena_prueba, 1)                   ' Convierto 4 bytes a dword

                            If (tag_ini = "d") Then                                         ' Extraigo tag "d"
                                adc_medido = dato_entero                                    ' el dword recibido es una medición de ADC
                            ElseIf (tag_ini = "p") Then                                     ' Extraje el tag "p" ?
                                Pendiente_Resistencia = dato_entero                         ' Lo que recibí es una pendiente de resistencia
                            ElseIf (tag_ini = "o") Then                                     ' Extraje el tag "o" ?
                                Offset_Resistencia = dato_entero                            ' Lo que recibí es offset de resistencia
                            End If

                        Case Estados_Recibir_Datos.RECIBO_CONDUCTIVIDAD                     ' Tercer estado : RECIBO_CONDUCTIVIDAD

                            tag_ini = Chr(cadena_prueba(0))                                     ' Copio el primer caracter de la cadena

                            If (tag_ini = "d") Then                                             ' tag = "d" ?
                                adc_medido_numerador = Bytes_a_Word(cadena_prueba, 1)           ' Recibo las 2 conversiones
                                adc_medido_denominador = Bytes_a_Word(cadena_prueba, 3)         ' empaquetadas en una cadena. 2 datos de 16 bits c/u
                                frm_Aguardar_Conductividad.Close()                              ' Cierro formulario "Espere mientras
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


    ' ---------------------------------------------------------------------------------------------
    '
    ' @function Enviar_Comando       
    '
    ' @brief    Transmisión por     puerto serie  
    '
    ' @paramin  cmd_out             comando a escribir a la salida
    ' @paramin  Insistir            Flag para indicar si el comando debe escribirse hasta recibir una respuesta (confirmatoria o no)
    ' @paramin  Forzar_Conexion     ??
    '
    ' @paramout none
    ' 
    ' @author   Roux, Federico G.
    ' @mail     rouxfederico@gmail.com
    ' @company  Nerox
    '
    ' --------------------------------------------------------------------------------------------- 

    Public Shared Function Enviar_Comando(ByVal cmd_out() As Byte, ByVal Insistir As Boolean, Optional ByVal Forzar_Conexion As Boolean = False) As Boolean

        Const CONTADOR_INSISTIR = 3

        Dim cuenta_insistir As Integer = 0

        ' Dim cadena_leida() As Byte = {&H0&, &H0&, &H0&, &H0&, &H0&, &H0&, &H0&}
        Dim cadena_leida() As Byte = {&H0&, &H0&, &H0&, &H0&}
        ' Dim cmd_leido() As Byte = {&H0&, &H0&, &H0&, &H0&, &H0&}
        Dim cmd_leido As Byte
        Dim cmd_esperado() As Byte = {&H0&, &H0&, &H0&, &H0&, &H0&}

        ' Dim CRC_Recibido As Integer
        Dim Chk_Recibido As Integer

        Dim Exito_Envio As Boolean = False
        Dim Timeout_TX As Boolean = False


        If TSK_Conectado = True Or Forzar_Conexion = True Then

            ' Concatenar_CRC(cmd_out, LARGO_FRAME)                                            ' agrego el CRC
            Concatenar_CHK(cmd_out, LARGO_FRAME)                                            ' Agrego el CHK


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

                    ' CRC_Recibido = CRC16(cadena_leida, LARGO_FRAME)                           ' Hago el CRC de la cadena recibida
                    Chk_Recibido = Checksum(cadena_leida, LARGO_FRAME)                      ' Hago el CHK de la cadena recibida

                    If (Chk_Recibido = 0) Then                                              ' si no hay error de CRC

                        ' cmd_esperado = Comando_Esperado(cmd_out)                          ' genero el comando que tendría que recibir si esta todo OK
                        ' cmd_leido = Extraer_Comando(cadena_leida)                           ' extraigo el comando de la cadena leída
                        cmd_leido = cadena_leida(0)
                        If (Decodificar_Byte_Comando(cadena_leida) = 0) Then                ' si es igual al comando leido
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

    ' ---------------------------------------------------------------------------------------------
    '
    ' @function Checksum       
    '
    ' @brief    Calculo el checksum de una cadena  
    '
    ' @paramin  nData()             Cadena a calcular el checksum
    ' @paramin  wLength             Largo de la cadena    
    '
    ' @paramout none
    ' 
    ' @author   Roux, Federico G.
    ' @mail     rouxfederico@gmail.com
    ' @company  Nerox
    '
    ' --------------------------------------------------------------------------------------------- 

    Public Function Checksum(ByRef nData() As Byte, ByVal wLength As Integer) As Integer

        Dim chk_byte As Byte = 0                                            ' Calculo del checksum
        Dim i As Integer = 0                                                ' Índice del array que recorro

        Dim aux As Byte

        ' wLength = wLength - 1                                               ' Decremento la cantidad

        While (i < wLength)                                                ' Llegué al final?

            aux = nData(i)
            chk_byte = (CLng(chk_byte) - CLng(aux)) And &HFF                                  ' resto el valor del dato
            i = i + 1                                                       ' Incremento al siguiente ítem
        End While


        Return chk_byte

    End Function

    ' ---------------------------------------------------------------------------------------------
    '
    ' @function Concatenar_CHK       
    '
    ' @brief    Agrego el checksum a una cadena 
    '
    ' @paramin  frame()             Cadena sobre la que calculo el checksum
    ' @paramin  l_frame             largo de la cadena
    '
    ' @paramout 0                   OK
    ' 
    ' @author   Roux, Federico G.
    ' @mail     rouxfederico@gmail.com
    ' @company  Nerox
    '
    ' --------------------------------------------------------------------------------------------- 

    Public Function Concatenar_CHK(ByRef frame() As Byte, ByVal l_frame As Integer) As Integer
        Dim chk As Integer = 0

        chk = Checksum(frame, l_frame - 1)
        frame(l_frame - 1) = chk                        ' Agrego el byte de checksum

        Return 0
    End Function

    
    ' ---------------------------------------------------------------------------------------------
    '
    ' @function Decodificar_Byte_Comando       
    '
    ' @brief    Chequea que el comando sea válido
    '
    ' @paramin  frame()             Cadena sobre la que calculo el checksum
    ' @paramin  l_frame             largo de la cadena
    '
    ' @paramout 0                   OK
    ' 
    ' @author   Roux, Federico G.
    ' @mail     rouxfederico@gmail.com
    ' @company  Nerox
    '
    ' --------------------------------------------------------------------------------------------- 

    Public Const DEC_FRAME_OK = 0

    Public Const DEC_COMANDO_NO_VALIDO = -1
    Public Const DEC_DATOS_DESIGUALES = -2
    Public Const DEC_ERROR_CHK = -3
    Public Const DEC_ERROR_CTX = -4
    Public Const DAT_ERROR_DES = -5

    Public Function Decodificar_Byte_Comando(ByVal Frame() As Byte) As Integer

        Dim cmd, d1, d0, chk As Byte

        cmd = Frame(0)                                                              ' Extraigo comando
        d1 = Frame(1)                                                               ' Extraigo dato parte alta
        d0 = Frame(2)                                                               ' Extraigo parte baja del dato
        chk = Frame(3)                                                              ' Extraigo checksum

        If (cmd < CMD_OFFSET) Or (cmd > (CMD_OFFSET + CANT_COMANDOS)) Then          ' Pregunto si el comando está en rango
            Return DEC_COMANDO_NO_VALIDO                                            ' Sino, retorno comando no válido
        End If

        If (d1 <> d0) Then                                                          ' Pregunto si los datos son diferentes
            Return DEC_DATOS_DESIGUALES                                             ' Devuelvo datos desiguales
        End If

        Select Case d0                                                              ' Analizo el byte de dato
            Case DATO_RECEPCION_OK                                                  ' Pregunto si recibí dato OK
                Return DEC_FRAME_OK
            Case DATO_ERROR_CHK                                                     ' El micro recibió con checksum erroneo
                Return DEC_ERROR_CHK
            Case DATO_ERROR_CTX                                                     ' El micro recibió comando fuera de contexto
                Return DEC_ERROR_CTX
            Case DATO_ERROR_DES                                                     ' El micro recibió error desconocido
                Return DAT_ERROR_DES

        End Select








    End Function

    ' ---------------------------------------------------------------------------------------------
    '
    ' @function Decodificar_Comando       
    '
    ' @brief    Chequea que el comando sea válido
    '
    ' @paramin  frame()             Cadena sobre la que calculo el checksum
    ' @paramin  l_frame             largo de la cadena
    '
    ' @paramout 0                   OK
    ' 
    ' @author   Roux, Federico G.
    ' @mail     rouxfederico@gmail.com
    ' @company  Nerox
    '
    ' --------------------------------------------------------------------------------------------- 

    Public Function Decodificar_Comando(ByVal cadena_1() As Byte, ByVal cadena_2() As Byte) As Integer

        Dim i As Integer

        For i = 0 To CANT_BYTES_BUFFER - 1

            If cadena_1(i) <> cadena_2(i) Then
                Return 1
            End If

        Next

        Return 0

    End Function

    ' ---------------------------------------------------------------------------------------------
    '
    ' @function Estado_Dato_Frame   
    '
    ' @brief    Chequeo el estado de un frame comprobando que los datos sean iguales y los interpreto
    '
    ' @paramin  frame()             Cadena a analizar
    '
    ' @paramout 0                   OK
    ' 
    ' @author   Roux, Federico G.
    ' @mail     rouxfederico@gmail.com
    ' @company  Nerox
    '
    ' --------------------------------------------------------------------------------------------- 


    Public Function Estado_Dato_Frame(ByVal frame() As Byte) As Integer

        'Select Case (


        Return 0
    End Function


    ' ---------------------------------------------------------------------------------------------
    '
    ' @function Extraer_Comando       
    '
    ' @brief    Extraigo el comando de una cadena
    '
    ' @paramin  frame()         Cadena sobre la que calculo el checksum
    ' @paramin  l_frame         largo de la cadena
    '
    ' @paramout 0               OK
    ' 
    ' @author   Roux, Federico G.
    ' @mail     rouxfederico@gmail.com
    ' @company  Nerox
    '
    ' --------------------------------------------------------------------------------------------- 

    Public Function Extraer_Comando(ByVal cadena() As Byte) As Byte()

        Dim cmd() As Byte = {&H0&, &H0&, &H0&, &H0&, &H0&}
        Dim i As Integer

        For i = 0 To CANT_BYTES_BUFFER - 1
            cmd(i) = cadena(i)
        Next

        Return cmd

    End Function

End Module
