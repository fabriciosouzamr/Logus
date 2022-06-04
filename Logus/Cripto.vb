Option Strict Off
Option Explicit On

<System.Runtime.InteropServices.ProgId("Cripto_NET.Cripto")> Public Class Cripto
    'UPGRADE_NOTE: char was upgraded to char_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    Private Function LPad(ByRef text As String, ByRef size As Short, ByRef char_Renamed As String) As String
        While Len(text) < size
            text = char_Renamed & text
        End While
        LPad = text
    End Function

    Public Function numericPlainText(ByRef plainText As String) As String
        Dim vCont As Integer
        Dim vNumericPlainText As String
        vNumericPlainText = ""
        For vCont = 1 To Len(plainText)
            vNumericPlainText = vNumericPlainText & LPad(CStr(Asc(Mid(plainText, vCont, 1))), 3, "0")
        Next
        numericPlainText = vNumericPlainText
    End Function

    Private Function FMod(ByRef p1 As Double, ByRef p2 As Double) As Double
        FMod = p1 - p2 * Int(p1 / p2)
    End Function

    Public Function Cypher(ByRef text As String, ByRef P_N As Double, ByRef P_E As Double, Optional ByRef keySize As Double = 4) As String
        Dim vNumericPlainText, vNumericCypherText As Double
        Dim vCont As Integer
        If text = "" Then
            Cypher = ""
        ElseIf Len(text) <= keySize Then
            vNumericPlainText = CDbl(numericPlainText(text))
            vNumericCypherText = 1

            For vCont = 1 To P_E
                vNumericCypherText = FMod(vNumericCypherText * vNumericPlainText, P_N)
            Next
            Cypher = CStr(vNumericCypherText)
        Else
            Cypher = Cypher(Mid(text, 1, keySize), P_N, P_E, keySize) & Cypher(Mid(text, keySize + 1), P_N, P_E, keySize)
        End If

    End Function
End Class