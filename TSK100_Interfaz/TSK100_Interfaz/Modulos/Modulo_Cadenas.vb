Module Modulo_Cadenas

    ' Public Const CANT_BYTES_BUFFER = 5
    ' Public Const CANT_BYTES_CRC = 2
    Public Const CANT_BYTES_BUFFER = 3                                                          ' [CMD][D1][D0]
    Public Const CANT_BYTES_CHK = 1                                                             ' [CHK] 

    ' Public Const LARGO_FRAME = CANT_BYTES_BUFFER + CANT_BYTES_CRC                               ' Cuando recibo comandos comunes
    Public Const LARGO_FRAME = CANT_BYTES_BUFFER + CANT_BYTES_CHK                               ' Cuando recibo comandos comunes

    Public Const LARGO_NOMBRE_ARCHIVO = 10                                                      ' Cuando recibo nombres de archivo
    Public Const LARGO_BUFFER_FRAME = 30                                                        ' Largo del frame entero
    Public Const LARGO_FRAME_ARCHIVO = 12                                                       ' 11 bytes de datos mas tag

    Public Structure cadena

        Dim terminal As Byte
        Dim funcion As Byte
        Dim dato As Byte
        Dim crc As Integer

        Dim frame() As Byte
        Dim ind As Short

    End Structure

    Public Const CMD_OFFSET = &H7&                                              ' Valor inicial del comando con valor mínimo

    Public Const ESTAS As Byte = CMD_OFFSET                                             ' Inicio de la comunicación

    Public Const CONFI As Byte = CMD_OFFSET + 1                                         ' Modo de configuración														

    Public Const INIMA As Byte = CMD_OFFSET + 2                                         ' Inicializo el equipo como master
    Public Const INIMS_MINUS As Byte = CMD_OFFSET + 3                                   ' Inicializo la medición del master --> ES LA RESPUESTA OK DEL SLAVE A "inims"
    Public Const FINMM As Byte = CMD_OFFSET + 4                                         ' Finalizo la medición del master

    Public Const INIMS As Byte = CMD_OFFSET + 5                                         ' Inicializo la medición del slave
    Public Const FINMS As Byte = CMD_OFFSET + 6                                         ' Finalizo la medición del slave

    Public Const INICK As Byte = CMD_OFFSET + 7                                         ' Inicio la calibración de conductividad
    Public Const FINCK As Byte = CMD_OFFSET + 8                                         ' Finalizo la calibración de conductividad
    Public Const CANCK As Byte = CMD_OFFSET + 9                                         ' Cancelo la calibración de conductividad
    Public Const OKACK As Byte = CMD_OFFSET + 10                                        ' La calibración de conductividad está OK
    Public Const FAICK As Byte = CMD_OFFSET + 11                                        ' La calibración de conductividad falló

    Public Const INICT As Byte = CMD_OFFSET + 12                                        ' Inicio la calibración de temperatura
    Public Const FINCT As Byte = CMD_OFFSET + 13                                        ' Finalizo la calibración de temperatura
    Public Const CANCT As Byte = CMD_OFFSET + 14                                        ' Cancelo la calibración de temperatura
    Public Const OKACT As Byte = CMD_OFFSET + 15                                        ' La calibración de temperatura está OK 
    Public Const FAICT As Byte = CMD_OFFSET + 16                                        ' La calibración de temperatura falló

    Public Const ARCOK As Byte = CMD_OFFSET + 17                                        ' La PC confirmó haber recibido un dato

    Public Const INIDE As Byte = CMD_OFFSET + 18                                        ' Inicio la descarga de datos de archivo (logger) 
    Public Const SEFYH As Byte = CMD_OFFSET + 19                                        ' Seteo fecha y hora al equipo

    Public Const REUMB As Byte = CMD_OFFSET + 20                                        ' Recibo nivel de alarma 
    Public Const REALA As Byte = CMD_OFFSET + 21                                        ' Recibo nivel de umbral

    Public Const INIRE As Byte = CMD_OFFSET + 22                                        ' Inicializo al Master como repetidor
    Public Const FINRE As Byte = CMD_OFFSET + 23                                        ' Finalizo al Master como repetidor

    Public Const DATOK As Byte = CMD_OFFSET + 24
    Public Const DATOT As Byte = CMD_OFFSET + 25

    Public Const DUMMY As Byte = CMD_OFFSET + 26

    Public Const CANT_COMANDOS As Byte = 26                                             ' Cantidad total de comandos

    Public lista_de_comandos(,) As Byte = _
                                        {{ESTAS, 0, 0, 0}, _
                                         {CONFI, 0, 0, 0}, _
                                         {INIMA, 0, 0, 0}, _
                                         {INIMS_MINUS, 0, 0, 0}, _
                                         {FINMM, 0, 0, 0}, _
                                         {INIMS, 0, 0, 0}, _
                                         {FINMS, 0, 0, 0}, _
                                         {INICK, 0, 0, 0}, _
                                         {FINCK, 0, 0, 0}, _
                                         {CANCK, 0, 0, 0}, _
                                         {OKACK, 0, 0, 0}, _
                                         {FAICK, 0, 0, 0}, _
                                         {INICT, 0, 0, 0}, _
                                         {FINCT, 0, 0, 0}, _
                                         {CANCT, 0, 0, 0}, _
                                         {OKACT, 0, 0, 0}, _
                                         {FAICT, 0, 0, 0}, _
                                         {ARCOK, 0, 0, 0}, _
                                         {INIDE, 0, 0, 0}, _
                                         {SEFYH, 0, 0, 0}, _
                                         {REUMB, 0, 0, 0}, _
                                         {REALA, 0, 0, 0}, _
                                         {INIRE, 0, 0, 0}, _
                                         {FINRE, 0, 0, 0}, _
                                         {DATOK, 0, 0, 0}, _
                                         {DATOT, 0, 0, 0}, _
                                         {DUMMY, 0, 0, 0}}

    'Public pregunta_vivo() As Byte = {Asc("e"), Asc("s"), Asc("t"), Asc("a"), Asc("s"), Asc(" "), Asc(" ")}
    'Public respuesta_vivo() As Byte = {Asc("e"), Asc("s"), Asc("t"), Asc("o"), Asc("y"), Asc(" "), Asc(" ")}

    'Public cadena_error_crc() As Byte = {Asc("e"), Asc("r"), Asc("c"), Asc("r"), Asc("c"), Asc(" "), Asc(" ")}
    'Public cadena_error_cmd() As Byte = {Asc("e"), Asc("r"), Asc("c"), Asc("m"), Asc("d"), Asc(" "), Asc(" ")}
    'Public cadena_error_ubq() As Byte = {Asc("e"), Asc("r"), Asc("u"), Asc("b"), Asc("q"), Asc(" "), Asc(" ")}
    'Public cadena_error_noi() As Byte = {Asc("e"), Asc("r"), Asc("n"), Asc("o"), Asc("i"), Asc(" "), Asc(" ")}
    'Public cadena_error_con() As Byte = {Asc("e"), Asc("r"), Asc("c"), Asc("o"), Asc("n"), Asc(" "), Asc(" ")}
    'Public cadena_error_unk() As Byte = {Asc("e"), Asc("r"), Asc("u"), Asc("n"), Asc("k"), Asc(" "), Asc(" ")}

    'Public lista_de_comandos(,) As Byte = _
    '                                       {{Asc("e"), Asc("s"), Asc("t"), Asc("a"), Asc("s"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("c"), Asc("o"), Asc("n"), Asc("f"), Asc("i"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("i"), Asc("n"), Asc("i"), Asc("m"), Asc("a"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("i"), Asc("n"), Asc("i"), Asc("m"), Asc("m"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("f"), Asc("i"), Asc("n"), Asc("m"), Asc("m"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("i"), Asc("n"), Asc("i"), Asc("s"), Asc("v"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("i"), Asc("n"), Asc("i"), Asc("m"), Asc("s"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("f"), Asc("i"), Asc("n"), Asc("m"), Asc("s"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("i"), Asc("n"), Asc("i"), Asc("c"), Asc("k"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("f"), Asc("i"), Asc("n"), Asc("c"), Asc("k"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("c"), Asc("a"), Asc("n"), Asc("c"), Asc("k"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("o"), Asc("k"), Asc("a"), Asc("c"), Asc("k"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("f"), Asc("a"), Asc("i"), Asc("c"), Asc("k"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("i"), Asc("n"), Asc("i"), Asc("c"), Asc("t"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("f"), Asc("i"), Asc("n"), Asc("c"), Asc("t"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("c"), Asc("a"), Asc("n"), Asc("c"), Asc("t"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("o"), Asc("k"), Asc("a"), Asc("c"), Asc("t"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("f"), Asc("a"), Asc("i"), Asc("c"), Asc("t"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("a"), Asc("r"), Asc("c"), Asc("o"), Asc("k"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("i"), Asc("n"), Asc("i"), Asc("d"), Asc("e"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("s"), Asc("e"), Asc("f"), Asc("y"), Asc("h"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("r"), Asc("e"), Asc("u"), Asc("m"), Asc("b"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("r"), Asc("e"), Asc("a"), Asc("l"), Asc("a"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("i"), Asc("n"), Asc("i"), Asc("r"), Asc("e"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("f"), Asc("i"), Asc("n"), Asc("r"), Asc("e"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("d"), Asc("u"), Asc("m"), Asc("m"), Asc("y"), Asc(" "), Asc(" ")}, _
    '                                        {Asc("r"), Asc("u"), Asc("m"), Asc("m"), Asc("y"), Asc(" "), Asc(" ")}}

    Public Const CMD_ESTAS = 0
    Public Const CMD_CONFI = 1
    Public Const CMD_INIMA = 2
    Public Const CMD_INIMM = 3
    Public Const CMD_FINMM = 4
    Public Const CMD_INISV = 5
    Public Const CMD_INIMS = 6
    Public Const CMD_FINMS = 7
    Public Const CMD_INICK = 8
    Public Const CMD_FINCK = 9
    Public Const CMD_CANCK = 10
    Public Const CMD_OKACK = 11
    Public Const CMD_FAICK = 12
    Public Const CMD_INICT = 13
    Public Const CMD_FINCT = 14
    Public Const CMD_CANCT = 15
    Public Const CMD_OKACT = 16
    Public Const CMD_FAICT = 17
    Public Const CMD_ARCOK = 18
    Public Const CMD_INIDE = 19
    Public Const CMD_SEFYH = 20
    Public Const CMD_REUMB = 21
    Public Const CMD_REALA = 22
    Public Const CMD_INIRE = 23
    Public Const CMD_FINRE = 24


    Public Const DAT_VAR_TEMPERATURA = "T"              ' Constante para indicar que el dato enviado está asociado a la variable temperatura
    Public Const DAT_PAR_PENDIENTE = "P"                ' Indica que el dato enviado corresponde a una pendiente
    Public Const DAT_PAR_OFFSET = "O"                   ' Indica que el dato enviado corresponde a un offset

    ' ---------------------------------------------------------------------------------------------
    '
    ' @function Seleccionar_Comando
    '
    ' @brief    A partir de un comando, selecciono el frame que voy a enviar
    '
    ' @paramin  n_comando   número de comando que necesito
    '
    ' @paramout Byte() cadena de salida
    ' 
    ' @author   Roux, Federico G.
    ' @mail     rouxfederico@gmail.com
    ' @company  Nerox
    '
    ' ---------------------------------------------------------------------------------------------

    Public Function Seleccionar_Comando(ByVal n_comando As Integer) As Byte()

        Dim comando_ret(0 To LARGO_FRAME - 1) As Byte
        Dim i As Integer

        For i = 0 To LARGO_FRAME - 1
            comando_ret(i) = lista_de_comandos(n_comando, i)
        Next
        Return comando_ret

    End Function

    ' ---------------------------------------------------------------------------------------------
    '
    ' @function Comando_Esperado
    '
    ' @brief    Especifico el comando enviado y preparo la respuesta esperada
    '
    ' @paramin  comando()   frame del comando recibido
    '
    ' @paramout Byte() cadena que se espera como respuesta del comando elegido
    ' 
    ' @author   Roux, Federico G.
    ' @mail     rouxfederico@gmail.com
    ' @company  Nerox
    '
    ' ---------------------------------------------------------------------------------------------
    Public Const DATO_ENVIO = &H0                              ' Valor del dato al enviar un comando
    Public Const DATO_RECEPCION_OK = &HAA                      ' Valor del dato al confirmar recepción correcta
    Public Const DATO_ERROR_CHK = &HFF                      ' Valor del dato para señalar error de checksum
    Public Const DATO_ERROR_CTX = &H55                  ' Valor del dato para señalar error de contexto
    Public Const DATO_ERROR_DES = &H11                      ' Error desconocido

    ' Public Function Dato_Esperado(ByVal comando() As Byte) As Byte()

    ' Dim dato_esperado() As Byte

    '    cmd_esperado = comando
    '    If cmd_esperado(0) > (Asc("a") - Asc("A")) Then
    '        cmd_esperado(0) = cmd_esperado(0) - (Asc("a") - Asc("A"))
    '    End If

    '    Return cmd_esperado
    ' End Function

    'Public Function Comando_Esperado(ByVal comando() As Byte) As Byte()
    '    Dim cmd_esperado() As Byte

    '    cmd_esperado = comando
    '    If cmd_esperado(0) > (Asc("a") - Asc("A")) Then
    '        cmd_esperado(0) = cmd_esperado(0) - (Asc("a") - Asc("A"))
    '    End If

    '    Return cmd_esperado
    'End Function

    ' ---------------------------------------------------------------------------------------------
    '
    ' @function Armar_Cadena_Dato
    '
    ' @brief    Recibe un dato y arma la cadena para enviarlo
    '
    ' @paramin  dato    Dato a enviar          
    '
    ' @paramout Byte()  Cadena a enviar
    ' 
    ' @author   Roux, Federico G.
    ' @mail     rouxfederico@gmail.com
    ' @company  Nerox
    '
    ' ---------------------------------------------------------------------------------------------

    Public Function Armar_Cadena_Dato(ByVal dato As Double) As Byte()

        ' Máscaras para obtener cada byte por separado
        Const NIBBLE_BYTE0_MASK = &HFF
        Const NIBBLE_BYTE1_MASK = &HFF00
        'Const NIBBLE_BYTE2_MASK = &HFF0000
        'Const NIBBLE_BYTE3_MASK = &HFF000000

        ' Desplazamiento en bits de cada nibble
        Const NIBBLE_BYTE0_BIT = 0
        Const NIBBLE_BYTE1_BIT = 8
        'Const NIBBLE_BYTE2_BIT = 16
        'Const NIBBLE_BYTE3_BIT = 24

        ' Dato separado en 4 bytes
        Dim dato_byte0 As Byte
        Dim dato_byte1 As Byte
        'Dim dato_byte2 As Byte
        'Dim dato_byte3 As Byte
        Dim long_aux As Integer

        ' Cadena de salida
        ' Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0, &H0, &H0, &H0}
        Dim cmd_out() As Byte = {&H0, &H0, &H0, &H0}

        ' Dato entero
        Dim dato_int As Integer

        dato_int = CInt(Int(dato))                                              ' Convierto el dato a entero

        long_aux = (dato_int And NIBBLE_BYTE0_MASK)
        dato_byte0 = CByte(long_aux >> NIBBLE_BYTE0_BIT)                        ' Primer byte del número a enviar
        long_aux = (dato_int And NIBBLE_BYTE1_MASK)
        dato_byte1 = CByte(long_aux >> NIBBLE_BYTE1_BIT)                        ' segundo byte del número a enviar
        'long_aux = (dato_int And NIBBLE_BYTE2_MASK)
        'dato_byte2 = CByte(long_aux >> NIBBLE_BYTE2_BIT)                        ' tercer byte del número a enviar
        'long_aux = (dato_int And NIBBLE_BYTE3_MASK)

        'If (long_aux = NIBBLE_BYTE3_MASK) Then
        'dato_byte3 = &HFF
        'Else
        'dato_byte3 = CByte(long_aux >> NIBBLE_BYTE3_BIT)                    ' cuarto byte del número a enviar
        'End If

        cmd_out(0) = Asc("d")                                                   ' Identificador de que la cadena es un dato
        'cmd_out(1) = dato_byte3                                                 ' primer
        'cmd_out(2) = dato_byte2                                                 ' Parte alta del dato (byte alto, se transmiten 2 bytes)
        'cmd_out(3) = dato_byte1                                                 ' Parte baja del dato a enviar
        'cmd_out(4) = dato_byte0                                                 ' Parámetro que estoy enviando

        cmd_out(1) = dato_byte1                                                 ' Parte baja del dato a enviar
        cmd_out(2) = dato_byte0                                                 ' Parámetro que estoy enviando
        Return cmd_out

    End Function

    ' ---------------------------------------------------------------------------------------------
    '
    ' @function Byte_a_BCD
    '
    ' @brief    Convierto un byte a BCD
    '
    ' @paramin  valor                  
    '
    ' @paramout Byte
    ' 
    ' @author   Roux, Federico G.
    ' @mail     rouxfederico@gmail.com
    ' @company  Nerox
    '
    ' ---------------------------------------------------------------------------------------------

    Public Function Byte_a_BCD(ByVal valor As Byte) As Byte

        Const NIBBLE_BAJO_MAS = &H10F

        Dim nibble_bajo As Byte
        Dim nibble_alto As Byte

        Dim valor_bcd As Byte

        nibble_bajo = (valor Mod 10) And NIBBLE_BAJO_MAS
        nibble_alto = valor \ 10
        nibble_alto = nibble_alto And NIBBLE_BAJO_MAS
        nibble_alto <<= 4

        valor_bcd = nibble_bajo + nibble_alto
        Return valor_bcd

    End Function

    ' ---------------------------------------------------------------------------------------------
    '
    ' @function Armar_Cadena_Dato
    '
    ' @brief    Recibe un dato y arma la cadena para enviarlo
    '
    ' @paramin  dato            
    '
    ' @paramout Byte cadena de salida
    ' 
    ' @author   Roux, Federico G.
    ' @mail     rouxfederico@gmail.com
    ' @company  Nerox
    '
    ' ---------------------------------------------------------------------------------------------

    Public Function Word_a_BCD(ByVal valor As Integer) As Byte()

        Const NIBBLE_BAJO_MAS = &H10F
        Const NIBBLE_ALTO_MAS = &H1F0

        Dim word_BCD(2) As Byte

        Dim digito_0 As Byte
        Dim digito_1 As Byte
        Dim digito_2 As Byte
        Dim digito_3 As Byte

        Dim nibble_0 As Byte
        Dim nibble_1 As Byte
        Dim nibble_2 As Byte
        Dim nibble_3 As Byte

        digito_3 = valor Mod 10
        digito_2 = (valor \ 10) Mod 10
        digito_1 = (valor \ 100) Mod 10
        digito_0 = (valor \ 1000)

        nibble_0 = (digito_0 << 4) And NIBBLE_ALTO_MAS
        nibble_1 = (digito_1) And NIBBLE_BAJO_MAS
        nibble_2 = (digito_2 << 4) And NIBBLE_ALTO_MAS
        nibble_3 = (digito_3) And NIBBLE_BAJO_MAS

        word_BCD(0) = nibble_0 + nibble_1
        word_BCD(1) = nibble_2 + nibble_3

        Return word_BCD
    End Function

End Module
