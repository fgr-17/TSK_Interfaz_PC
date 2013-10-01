Module Modulo_Kernel

    Public delay_recepcion As Integer = 1500                                         ' delay de recepción [ms] 

    Declare Sub Sleep Lib "kernel32" Alias "Sleep" (ByVal dwMilliseconds As Long)   ' Función de delay

End Module
