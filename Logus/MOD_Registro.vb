Imports Microsoft.Win32
Imports System.Configuration

Module MOD_Registro

    Public Sub DisableBeep()
        Dim regKey As RegistryKey = Nothing

        regKey = Registry.CurrentUser.OpenSubKey("Control Panel\Sound", True)
        regKey.SetValue("Beep", "no")
        regKey.SetValue("ExtendedSounds", "no")
        regKey.Close()

    End Sub

    Public Function Registro_Create() As Boolean
        Dim regKey As RegistryKey = Nothing
        Dim retorno As Boolean
        retorno = True
        Try
            regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", True)
            regKey.CreateSubKey(Sis_CampoRegistro)
        Catch ex As Exception
            retorno = False
        Finally
            regKey.Close()
        End Try

        Return retorno
    End Function

    Public Function Registro_Write_String(ByVal Campo As String, ByVal Valor As String) As Boolean
        Dim regKey As RegistryKey = Nothing
        Dim retorno As Boolean
        retorno = True
        Try
            regKey = Registry.CurrentUser.OpenSubKey("Software\" & Sis_CampoRegistro, True)
            regKey.SetValue(Campo, Valor)
            regKey.Close()
        Catch ex As Exception
            retorno = False
        Finally

        End Try
        Return retorno
    End Function

    Public Function Registro_Read_String(ByVal Campo As String) As String
        Dim regKey As RegistryKey = Nothing
        Dim ver As String
        Try
            regKey = Registry.CurrentUser.OpenSubKey("Software\" & Sis_CampoRegistro, True)
            ver = regKey.GetValue(Campo, "")
            regKey.Close()
        Catch ex As Exception
            Registro_Create()
            ver = ""
        Finally

        End Try
        Return ver
    End Function
End Module
