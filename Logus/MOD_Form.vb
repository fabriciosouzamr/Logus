'>>> Largura 855 - Altura 615
Imports System.Windows.Forms

Module Formulario
    Private Declare Function SetSysColors Lib "user32" _
            (ByVal cElements As Integer, ByRef lpaElements As Integer, _
            ByRef lpaRgbValues As Integer) As Integer

    Public Sub CorWindows()
        Dim CB As Integer = 2
        Call SetSysColors(1, CB, RGB(9, 166, 225))
    End Sub

    Public Sub Form_Show(ByVal oFormMDI As Form, ByVal oForm As Form, _
                         Optional ByVal bModal As Boolean = False, _
                         Optional ByVal bCentralizado As Boolean = True, _
                         Optional ByVal ValidarTituloTela As Boolean = False, _
                         Optional ByVal NovaInstancia As Boolean = False)
        If Not oFormMDI Is Nothing And Not bModal Then
            If NovaInstancia = False Then
                If ValidarTituloTela Then
                    If Form_Existe(oFormMDI, oForm.Name, True, oForm.Text) Then Exit Sub
                Else
                    If Form_Existe(oFormMDI, oForm.Name) Then Exit Sub
                End If
            End If
        End If

        Form_IdentificarControles(oForm)
        Form_Cor(oForm)

        If bCentralizado Then
            oForm.StartPosition = FormStartPosition.CenterScreen
        End If
        
        If bModal Then
            oForm.ShowDialog()
        Else
            oForm.Show()
        End If
        oForm.BringToFront()
    End Sub

    Public Sub Form_Close(ByRef oForm As Form, Optional ByVal NomeTela As String = "")
        If NomeTela = "" Then
            NomeTela = oForm.Name
        End If
        Form_Close_Grid(oForm.Controls, NomeTela)

        oForm.Dispose()
        System.GC.Collect()
        System.GC.WaitForPendingFinalizers()
    End Sub

    Public Sub Form_Close_Grid(ByRef oControls As Windows.Forms.Control.ControlCollection, _
                               ByVal Form_Name As String)
        Dim iCont As Integer

        For iCont = 0 To oControls.Count - 1
            If TypeOf oControls(iCont) Is Infragistics.Win.UltraWinGrid.UltraGrid Then
                objGrid_Gravar_Configuracao(oControls(iCont), Form_Name)
            End If
        Next
    End Sub

    Public Sub Form_Carrega_Grid(ByRef oForm As Form, Optional ByVal NomeTela As String = "")
        If NomeTela = "" Then
            NomeTela = oForm.Name
        End If
        Form_Carrega_Grid_All(oForm.Controls, NomeTela)
    End Sub

    Public Sub Form_Carrega_Grid_All(ByRef oControls As Windows.Forms.Control.ControlCollection, _
                                     ByVal Form_Name As String)
        Dim iCont As Integer

        For iCont = 0 To oControls.Count - 1
            If TypeOf oControls(iCont) Is Infragistics.Win.UltraWinGrid.UltraGrid Then
                objGrid_Carrega_Configuracao(oControls(iCont), Form_Name)
            End If
        Next
    End Sub

    Public Sub Form_Show_MDI(ByVal oFormMDI As Form, ByVal oForm As Form, _
                             Optional ByVal bModal As Boolean = False, _
                             Optional ByVal bCentralizado As Boolean = True, _
                             Optional ByVal ValidarTituloTela As Boolean = False, _
                             Optional ByVal NovaInstancia As Boolean = False)
        If Not oFormMDI Is Nothing And Not bModal Then
            If oFormMDI.IsMdiContainer Then
                If NovaInstancia = False Then
                    If ValidarTituloTela Then
                        If Form_Existe(oFormMDI, oForm.Name, True, oForm.Text) Then Exit Sub
                    Else
                        If Form_Existe(oFormMDI, oForm.Name) Then Exit Sub
                    End If
                End If

                oForm.MdiParent = oFormMDI
            End If
        End If

        Form_IdentificarControles(oForm)
        Form_Cor(oForm)
  
 

        If bCentralizado Then
            If oFormMDI Is Nothing Then
                oForm.StartPosition = FormStartPosition.CenterScreen
            Else
                oForm.StartPosition = FormStartPosition.CenterParent
            End If
        End If

        If bModal Then
            oForm.ShowDialog()
        Else
            oForm.Show()
        End If

        If Not oFormMDI Is Nothing And Not bCentralizado Then
            oForm.MinimumSize = oForm.Size
            oFormMDI.LayoutMdi(MdiLayout.Cascade)
        End If
    End Sub

    Private Function Form_Existe(ByVal oFormMDI As Form, ByVal sForm As String, _
                                 Optional ByVal ValidarTituloTela As Boolean = False, _
                                 Optional ByVal sTitulo As String = "") As Boolean
        Dim iCont As Integer

        For iCont = 0 To UBound(oFormMDI.MdiChildren)
            If UCase(oFormMDI.MdiChildren(iCont).Name) = UCase(sForm) Then
                If ValidarTituloTela Then
                    If UCase(oFormMDI.MdiChildren(iCont).Text) = UCase(sTitulo) Then
                        oFormMDI.MdiChildren(iCont).BringToFront()

                        Return True
                        Exit For
                    End If
                Else
                    oFormMDI.MdiChildren(iCont).BringToFront()

                    Return True
                    Exit For
                End If
            End If
        Next
    End Function

    Public Sub Form_IdentificarControles(ByVal oForm As Form)
        Dim iCont As Integer

        'Identifica os controles do form
        Form_Container_IdentificarControles(oForm.Controls)

        For iCont = 0 To oForm.Controls.Count - 1
            'Identifica os controles container do form 
            If oForm.Controls(iCont).Controls.Count > 0 Then
                Form_Container_IdentificarControles(oForm.Controls(iCont).Controls)
            End If
        Next

        If oForm.Controls.Count > 0 Then
            If oForm.Controls(0).Controls.Count > 0 Then
                If oForm.Controls(0).Controls(0).Controls.Count > 0 Then
                    Form_Container_IdentificarControles(oForm.Controls(0).Controls(0).Controls)
                End If
            End If
        End If
    End Sub

    Public Sub Form_Container_IdentificarControles(ByVal oControls As Control.ControlCollection)
        Dim aControles(oControls.Count - 1) As String
        Dim iCont_01 As Integer
        Dim iCont_02 As Integer
        Dim oBotao As Infragistics.Win.Misc.UltraButton
        Dim oLabel As System.Windows.Forms.Label
        Dim Indice As Integer
        Dim sIdentificadorBotao As String
        Dim oToolTip As New System.Windows.Forms.ToolTip
        Dim bAceitarFocus As Boolean = True

        For iCont_01 = 0 To oControls.Count - 1
            aControles(iCont_01) = oControls(iCont_01).Name
        Next

        For iCont_01 = LBound(aControles) To UBound(aControles)
            iCont_02 = oControls.IndexOfKey(aControles(iCont_01))

            Indice = -1

            If iCont_02 > -1 Then
                If TypeOf oControls(iCont_02) Is Infragistics.Win.Misc.UltraButton Then
                    oBotao = oControls(iCont_02)

                    If InStr(oBotao.Name, "_") = 0 Then
                        sIdentificadorBotao = oBotao.Name
                    Else
                        sIdentificadorBotao = Left(oBotao.Name, InStr(oBotao.Name, "_") - 1)
                    End If

                    bAceitarFocus = True
                    Indice = Form_Container_IdentificarControles_Item(oControls(iCont_02), oToolTip, UCase(sIdentificadorBotao), bAceitarFocus)

                    Form_Botao_Formatar(oBotao, Indice, bAceitarFocus)
                Else
                    'se for windows label defino a cor de fundo como transparente
                    If TypeOf oControls(iCont_02) Is System.Windows.Forms.Label Then
                        oLabel = oControls(iCont_02)
                        oLabel.BackColor = Color.Transparent
                        oLabel.SendToBack()
                    End If
                End If
            End If
        Next
    End Sub

    Public Sub Form_Botao_Formatar(ByVal oBotao As Infragistics.Win.Misc.UltraButton, ByVal sTipoBotao As String)
        Dim Indice As Integer
        Dim oToolTip As New System.Windows.Forms.ToolTip
        Dim bAceitarFocus As Boolean

        Indice = Form_Container_IdentificarControles_Item(oBotao, oToolTip, sTipoBotao, bAceitarFocus)

        Form_Botao_Formatar(oBotao, Indice, bAceitarFocus)
    End Sub

    Private Sub Form_Botao_Formatar(ByVal oBotao As Infragistics.Win.Misc.UltraButton, _
                                    ByVal Indice As Integer, _
                                    ByVal bAceitarFocus As Boolean)
        With oBotao
            If Indice > -1 Then
                If Not oImagemList Is Nothing Then
                    .ImageList = oImagemList
                    .Appearance.Image = oImagemList.Images(Indice)
                End If

                If .Width <> 28 And .Height <> 28 Then
                    .Height = 45
                    .Width = 45
                End If

                If bAceitarFocus Then
                    .AcceptsFocus = True
                    .TabStop = True
                    .ShowFocusRect = True
                    .ShowOutline = True
                End If

                .Text = ""
            End If

            .ShowFocusRect = False
        End With
    End Sub

    Public Sub Form_Controles_Limpa(ByVal oForm As Form)
        Dim oControl As System.Windows.Forms.Control

        For Each oControl In oForm.Controls
            Select Case UCase(TypeName(oControl.Name))
                Case "Label", "TextBox", "UltraTextEditor"
                    oControl.Text = ""
                Case "ComboBox"

                Case "CheckBox", "RadioButton"
            End Select
        Next
    End Sub

    Public Sub Form_Ajustar_Tamanho(ByVal oForm As Form, Optional ByVal width As Integer = 85, Optional ByVal height As Integer = 75)
        Dim ScreenWidth As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width
        Dim ScreenHeight As Integer = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height

        If oForm.Width < (ScreenWidth * width / 100) Then
            oForm.Width = ScreenWidth * width / 100
        End If
        oForm.Height = ScreenHeight * height / 100
        oForm.Left = (ScreenWidth / 2) - (oForm.Width / 2)
        oForm.Top = (ScreenHeight / 2) - (oForm.Height / 2)
    End Sub

    Public Function Form_ParentForm(ByVal oParent As Windows.Forms.Control) As Windows.Forms.Control
        Dim oForm As Windows.Forms.Control

        oForm = oParent.Parent

        Do While True
            If TypeOf oForm Is Form Then
                Exit Do
            Else
                If oForm.Parent Is Nothing Then
                    Exit Do
                Else
                    oForm = oForm.Parent
                End If
            End If
        Loop

        Return oForm
    End Function
End Module