Module MOD_Form_Local
    Public Function Form_Container_IdentificarControles_Item(ByVal oControl As System.Windows.Forms.Control, _
                                                             ByVal oToolTip As System.Windows.Forms.ToolTip, _
                                                             ByVal sIdentificadorBotao As String, _
                                                             Optional ByRef bAceitarFocus As Boolean = True) As Integer
        Dim Indice As Integer

        Select Case UCase(sIdentificadorBotao)
            Case "CMDNOVO"
                Indice = cnt_ImagemIcone_Novo
                oToolTip.SetToolTip(oControl, "Incluir novo registro")
            Case "CMDGRAVAR"
                Indice = cnt_ImagemIcone_Gravar
                oToolTip.SetToolTip(oControl, "Gravar registro")
            Case "CMDFECHAR"
                Indice = cnt_ImagemIcone_Fechar
                oToolTip.SetToolTip(oControl, "Fechar Tela")
                bAceitarFocus = False
            Case "CMDEXCLUIR"
                Indice = cnt_ImagemIcone_Excluir
                oToolTip.SetToolTip(oControl, "Excluir registro selecionado")
            Case "CMDEXCELL"
                Dim oMenu As New MOD_Exportar_Grid

                Indice = cnt_ImagemIcone_Excell
                oToolTip.SetToolTip(oControl, "Exportar dados da planilha para o Excell")

                oMenu.Botao(oControl)
            Case "CMDIMPRIMIR"
                Indice = cnt_ImagemIcone_Imprimir
                oToolTip.SetToolTip(oControl, "Imprimir relatório")
            Case "CMDCARREGARRELATORIO"
                Indice = cnt_ImagemIcone_Pesquisar
                oToolTip.SetToolTip(oControl, "Visualizar relatório")
            Case "CMDPESQUISAR"
                Indice = cnt_ImagemIcone_Pesquisar
                oToolTip.SetToolTip(oControl, "Pesquisar registros")
            Case "CMDALTERAR"
                Indice = cnt_ImagemIcone_Alterar
                oToolTip.SetToolTip(oControl, "Alterar registro selecionado")
            Case "CMDAMARRACAO"
                Indice = cnt_ImagemIcone_Amarracao
                oToolTip.SetToolTip(oControl, "--")
            Case "CMDPESQUISAR"
                Indice = cnt_ImagemIcone_Pesquisar
                oToolTip.SetToolTip(oControl, "Pesquisar registros")
            Case "CMDUSUARIO"
                Indice = cnt_ImagemIcone_Usuario
                oToolTip.SetToolTip(oControl, "Usuário que criou ou alterou registro")
            Case "CMDPARAMETRO"
                Indice = cnt_ImagemIcone_Parametro
                oToolTip.SetToolTip(oControl, "Parametros")
            Case "CMDCOPIAR"
                Indice = cnt_ImagemIcone_Copiar
                oToolTip.SetToolTip(oControl, "Processar")
            Case "CMDEQUIPAMENTO"
                Indice = cnt_ImagemIcone_Equipamento
                oToolTip.SetToolTip(oControl, "Equipamento")
            Case "CMDRETORNAR"
                Indice = cnt_ImagemIcone_Retornar
                oToolTip.SetToolTip(oControl, "Retornar")
            Case "CMDLERMENSAGEM"
                Indice = cnt_ImagemIcone_LerMensagem
                oToolTip.SetToolTip(oControl, "Ler mensagem")
            Case "CMDATUALIZAR"
                Indice = cnt_ImagemIcone_Atualizar
                oToolTip.SetToolTip(oControl, "Atualizar planilha")
            Case "CMDCANCELAR"
                Indice = cnt_ImagemIcone_Cancelar
                oToolTip.SetToolTip(oControl, "Cancelar")
            Case "CMDACESSO"
                Indice = cnt_ImagemIcone_Acesso
                oToolTip.SetToolTip(oControl, "Acesso usuários")
            Case "CMDGRUPOUSUARIO"
                Indice = cnt_ImagemIcone_GrupoUsuario
                oToolTip.SetToolTip(oControl, "Grupos de Usuários")
            Case "CMDLINKARUSUARIO"
                Indice = cnt_ImagemIcone_LinkarUsuario
                oToolTip.SetToolTip(oControl, "Linkar Usuários")
            Case "CMDSOBE"
                Indice = cnt_ImagemIcone_Sobe
                oToolTip.SetToolTip(oControl, "Anterior")
            Case "CMDDESCE"
                Indice = cnt_ImagemIcone_Desce
                oToolTip.SetToolTip(oControl, "Proximo")
            Case "CMDADENDO"
                Indice = cnt_ImagemIcone_Adendo
                oToolTip.SetToolTip(oControl, "Adendos do contrato")
            Case "CMDMANUTENCAO"
                Indice = cnt_ImagemIcone_Manutencao
                oToolTip.SetToolTip(oControl, "Acesso para o setor de manutenção")
            Case "CMDEXECUTADA"
                Indice = cnt_ImagemIcone_Executada
                oToolTip.SetToolTip(oControl, "Item executado")
            Case "CMDENVIAREMAIL"
                Indice = cnt_ImagemIcone_EnviarEMail
                oToolTip.SetToolTip(oControl, "Enviar para o E-Mail")
            Case "CMDPROVISAO"
                Indice = cnt_ImagemIcone_Provisao
                oToolTip.SetToolTip(oControl, "Provisão")
            Case "CMDAJUSTE"
                Indice = cnt_ImagemIcone_Ajuste
                oToolTip.SetToolTip(oControl, "Realiza Ajuste")
            Case "CMDAGREGADOS"
                Indice = cnt_ImagemIcone_Agregados
                oToolTip.SetToolTip(oControl, "Agregados")
            Case "CMDSELECIONAR"
                Indice = cnt_ImagemIcone_Selecionar
                oToolTip.SetToolTip(oControl, "Selecionar Registro")
            Case "CMDNFREFERENCIA"
                Indice = cnt_ImagemIcone_NFReferencia
                oToolTip.SetToolTip(oControl, "NF de Referência")
            Case "CMDAPAGARPARCIAL"
                Indice = cnt_ImagemIcone_NFReferencia
                oToolTip.SetToolTip(oControl, "Exclui o pagamento e deixa o cheque")
            Case "CMDOBSACERTO"
                Indice = cnt_ImagemIcone_ObsAcerto
                oToolTip.SetToolTip(oControl, "Observação do Acerto")
            Case "CMDSTATUSFECHAABRE"
                oToolTip.SetToolTip(oControl, "Abre ou Fecha Contrato.")
                Indice = -1
            Case "CMDMOTIVOELIMINACAO"
                Indice = cnt_ImagemIcone_MotivoEliminacao
                oToolTip.SetToolTip(oControl, "Motivo da eliminação")
            Case "CMDFIXARDOLAR"
                Indice = cnt_ImagemIcone_FixacaoDolar
                oToolTip.SetToolTip(oControl, "Fixa dolar em contratos fixo com dolar variavel")
            Case "CMDAPROVACAO"
                Indice = cnt_ImagemIcone_Aprovar
                oToolTip.SetToolTip(oControl, "Aprovação")
            Case "CMDREPROVAR"
                Indice = cnt_ImagemIcone_Reprovar
                oToolTip.SetToolTip(oControl, "Reprovação")
            Case "CMDHISTORICO"
                Indice = cnt_ImagemIcone_Historico
                oToolTip.SetToolTip(oControl, "Exibe Histórico")
            Case "CMDCHEQUE"
                Indice = cnt_ImagemIcone_Cheque
                oToolTip.SetToolTip(oControl, "Emite Cheque")
            Case "CMDVOUCHER"
                Indice = cnt_ImagemIcone_Imprimir
                oToolTip.SetToolTip(oControl, "Imprime Vouche")
            Case "CMDITEM"
                Indice = cnt_ImagemIcone_Item
                oToolTip.SetToolTip(oControl, "Exibe Itens")
            Case "CMDLIMPAIMPRESSORA"
                Indice = cnt_ImagemIcone_Limpa
                oToolTip.SetToolTip(oControl, "Limpa impressora de cheque")
            Case "CMDLISTANEGRA"
                Indice = -1
                oToolTip.SetToolTip(oControl, "Lista Negra")
            Case "CMDFICHA"
                Indice = -1
                oToolTip.SetToolTip(oControl, "Ficha Cadastral")
            Case "CMDICMS"
                Indice = cnt_ImagemIcone_ICMS
                oToolTip.SetToolTip(oControl, "Libera para cobrança de ICMS")
            Case "CMDEXPORTARELATORIO"
                Dim oMenu As New MOD_Exportar_Relatorio

                Indice = cnt_ImagemIcone_ExportacaoEmail
                oToolTip.SetToolTip(oControl, "Enviar relatório por e-mail.")

                oMenu.Form(oControl.Parent)
            Case Else
                Indice = -1
        End Select

        Return Indice
    End Function

    Public Sub Form_Cor(ByVal oForm As System.Windows.Forms.Form)
        oForm.BackColor = System.Drawing.Color.FromArgb(CType(230, Byte), CType(238, Byte), CType(249, Byte))
    End Sub
End Module
