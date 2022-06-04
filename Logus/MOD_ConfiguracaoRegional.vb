Module MOD_ConfiguracaoRegional
    Private Declare Function GetLocaleInfo Lib "kernel32" Alias "GetLocaleInfoA" (ByVal Locale As Integer, ByVal LCTYPE As Integer, ByVal lpLCData As String, ByVal cchData As Integer) As Integer
    Private Declare Function SetLocaleInfo Lib "kernel32" Alias "SetLocaleInfoA" (ByVal Locale As Integer, ByVal LCTYPE As Integer, ByVal lpLCData As String) As Integer
    Private Declare Function GetUserDefaultLCID Lib "kernel32" () As Integer

    Const LOCALE_SDECIMAL As Long = &HE   'constante para o Decimal Symbol
    Const LOCALE_STHOUSAND = &HF  'constante para o Digit group Symbol
    Const LOCALE_SSHORTDATE = &H1F 'constante para o short date
    Const LOCALE_SMONDECIMALSEP = &H16 ' 'constante para o Decimal Symbol do currency
    Const LOCALE_SMONTHOUSANDSEP = &H17 'constante para o Digit group Symbol do currency

    Public Property DecimalSymbol() As String
        Get
            Dim nLength As Integer
            Dim nLocale As Integer

            nLocale = GetUserDefaultLCID()
            nLength = GetLocaleInfo(nLocale, LOCALE_SDECIMAL, vbNullString, 0) - 1
            DecimalSymbol = Space$(nLength)
            GetLocaleInfo(nLocale, LOCALE_SDECIMAL, DecimalSymbol, nLength)
        End Get

        Set(ByVal value As String)
            Dim nLocale As Integer
            If value <> DecimalSymbol Then
                If value = "." Or value = "," Then
                    nLocale = GetUserDefaultLCID()
                    SetLocaleInfo(nLocale, LOCALE_SDECIMAL, value)
                End If
            End If
        End Set
    End Property

    Public Property DecimalSymbolCurrency() As String
        Get
            Dim nLength As Integer
            Dim nLocale As Integer

            nLocale = GetUserDefaultLCID()
            nLength = GetLocaleInfo(nLocale, LOCALE_SMONDECIMALSEP, vbNullString, 0) - 1
            DecimalSymbolCurrency = Space$(nLength)
            GetLocaleInfo(nLocale, LOCALE_SMONDECIMALSEP, DecimalSymbolCurrency, nLength)
        End Get

        Set(ByVal value As String)
            Dim nLocale As Integer
            If value <> DecimalSymbolCurrency Then
                If value = "." Or value = "," Then
                    nLocale = GetUserDefaultLCID()
                    SetLocaleInfo(nLocale, LOCALE_SMONDECIMALSEP, value)
                End If
            End If
        End Set
    End Property

    Public Property DigitGroupSymbol() As String
        Get
            Dim nLength As Integer
            Dim nLocale As Integer

            nLocale = GetUserDefaultLCID()
            nLength = GetLocaleInfo(nLocale, LOCALE_STHOUSAND, vbNullString, 0) - 1
            DigitGroupSymbol = Space$(nLength)
            GetLocaleInfo(nLocale, LOCALE_STHOUSAND, DigitGroupSymbol, nLength)
        End Get

        Set(ByVal value As String)
            Dim nLocale As Integer
            If value <> DigitGroupSymbol Then
                If value = "." Or value = "," Then
                    nLocale = GetUserDefaultLCID()
                    SetLocaleInfo(nLocale, LOCALE_STHOUSAND, value)
                End If
            End If
        End Set
    End Property
    Public Property DigitGroupSymbolCurrency() As String
        Get
            Dim nLength As Integer
            Dim nLocale As Integer

            nLocale = GetUserDefaultLCID()
            nLength = GetLocaleInfo(nLocale, LOCALE_SMONTHOUSANDSEP, vbNullString, 0) - 1
            DigitGroupSymbolCurrency = Space$(nLength)
            GetLocaleInfo(nLocale, LOCALE_SMONTHOUSANDSEP, DigitGroupSymbolCurrency, nLength)
        End Get

        Set(ByVal value As String)
            Dim nLocale As Integer
            If value <> DigitGroupSymbolCurrency Then
                If value = "." Or value = "," Then
                    nLocale = GetUserDefaultLCID()
                    SetLocaleInfo(nLocale, LOCALE_SMONTHOUSANDSEP, value)
                End If
            End If
        End Set
    End Property

    Public Property ShortDate() As String
        Get
            Dim nLength As Integer
            Dim nLocale As Integer

            nLocale = GetUserDefaultLCID()
            nLength = GetLocaleInfo(nLocale, LOCALE_SSHORTDATE, vbNullString, 0) - 1
            ShortDate = Space$(nLength)
            GetLocaleInfo(nLocale, LOCALE_SSHORTDATE, ShortDate, nLength)
        End Get

        Set(ByVal value As String)
            Dim nLocale As Integer
            If value <> ShortDate Then
                nLocale = GetUserDefaultLCID()
                SetLocaleInfo(nLocale, LOCALE_SSHORTDATE, value)
            End If
        End Set
    End Property

    Public Sub AtualizaConfiguracao()
        DecimalSymbol = "."
        DigitGroupSymbol = ","
        DecimalSymbolCurrency = "."
        DigitGroupSymbolCurrency = ","
        ShortDate = "dd/MM/yyyy"
    End Sub
End Module
