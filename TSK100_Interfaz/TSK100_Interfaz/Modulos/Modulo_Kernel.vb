Module Modulo_Kernel

    Public delay_recepcion As Integer = 1500                                         ' delay de recepci�n [ms] 

    Declare Sub Sleep Lib "kernel32" Alias "Sleep" (ByVal dwMilliseconds As Long)   ' Funci�n de delay

End Module
