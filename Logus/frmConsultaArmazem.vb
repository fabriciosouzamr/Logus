Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmConsultaArmazem
    Const cnt_Tela As String = "Transacao_MovCacau_ConsultaArmazem"

    Const cnt_GridArmazem_Codigo As Integer = 0
    Const cnt_GridArmazem_CodigoFilial As Integer = 1
    Const cnt_GridArmazem_Filial As Integer = 2
    Const cnt_GridArmazem_Nome As Integer = 3
    Const cnt_GridArmazem_Quantidade As Integer = 4

    Const cnt_GridPilha_Codigo As Integer = 0
    Const cnt_GridPilha_Procedencia As Integer = 1
    Const cnt_GridPilha_Quantidade As Integer = 2
    Const cnt_GridPilha_Sacos As Integer = 3
    Const cnt_GridPilha_DataFormacao As Integer = 4
    Const cnt_GridPilha_Ajustar As Integer = 5

    Dim oDS_Armazem As New UltraWinDataSource.UltraDataSource
    Dim oDS_Pilha As New UltraWinDataSource.UltraDataSource


    Private Sub cmdFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFechar.Click
        Me.Close()
    End Sub

    Private Sub ExecutaConsultaArmazem()
        Dim SqlText As String

        SqlText = "SELECT M.CD_ARMAZEM," & _
                         "A.CD_FILIAL_ORIGEM," & _
                         "FIL.NO_FILIAL," & _
                         "A.NO_ARMAZEM," & _
                         "SUM(M.QT_VOLUME) QUANT" & _
                  " FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM M," & _
                        "SOF.ARMAZEM A," & _
                        "SOF.FILIAL FIL" & _
                  " WHERE A.CD_ARMAZEM = M.CD_ARMAZEM" & _
                    " AND A.CD_FILIAL_ORIGEM = FIL.CD_FILIAL" & _
                    " AND A.CD_FILIAL_ORIGEM IN (" & ListarIDFiliaisLiberadaUsuario() & ")" & _
                  " GROUP BY A.CD_FILIAL_ORIGEM," & _
                            "FIL.NO_FILIAL," & _
                            "M.CD_ARMAZEM," & _
                            "A.NO_ARMAZEM"
        objGrid_Carregar(grdArmazem, SqlText, New Integer() {cnt_GridArmazem_Codigo, _
                                                             cnt_GridArmazem_CodigoFilial, _
                                                             cnt_GridArmazem_Filial, _
                                                             cnt_GridArmazem_Nome, _
                                                             cnt_GridArmazem_Quantidade})
    End Sub

    Private Sub ExecutaConsultaPilha(ByVal CdArmazem As Integer)
        Dim SqlText As String

        SqlText = "SELECT MP.CD_PILHA_ARMAZEM," & _
                         "NVL(MP.CD_PROCEDENCIA_PILHA, '-') CD_PROCEDENCIA_PILHA," & _
                         "MP.QT_VOLUME QUANT," & _
                         "MP.QT_SACOS QT_SACOS_PILHA," & _
                         "MI.DT_MOVIMENTACAO" & _
                  " FROM (SELECT SUM(QT_VOLUME) QT_VOLUME," & _
                                "SUM(QT_SACOS) QT_SACOS," & _
                                "CD_PROCEDENCIA_PILHA," & _
                                "CD_ARMAZEM," & _
                                "CD_PILHA_ARMAZEM" & _
                         " FROM (SELECT D.CD_PROCEDENCIA CD_PROCEDENCIA_PILHA," & _
                                       "D.CD_ARMAZEM," & _
                                       "D.CD_PILHA_ARMAZEM," & _
                                       "B.QT_VOLUME," & _
                                       "NVL(A.QT_SACOS,0) QT_SACOS" & _
                                " FROM SOF.MOVIMENTACAO_PILHA_ARMAZEM B," & _
                                      "SOF.PILHA_ARMAZEM D," & _
                                      "(SELECT MS.CD_ARMAZEM," & _
                                              "MS.CD_PILHA_ARMAZEM," & _
                                              "MS.SQ_MOVIMENTACAO," & _
                                              "MS.SQ_MOVIMENTACAO_PILHA_ARMAZEM," & _
                                              "SUM(MS.QT_SACOS) QT_SACOS" & _
                                       " FROM SOF.MOV_PILHA_ARMAZEM_SACARIA MS" & _
                                       " GROUP BY MS.CD_ARMAZEM," & _
                                                 "MS.CD_PILHA_ARMAZEM," & _
                                                 "MS.SQ_MOVIMENTACAO," & _
                                                 "MS.SQ_MOVIMENTACAO_PILHA_ARMAZEM) A" & _
                         " WHERE D.CD_ARMAZEM = B.CD_ARMAZEM" & _
                           " AND D.CD_PILHA_ARMAZEM = B.CD_PILHA_ARMAZEM" & _
                           " AND B.CD_ARMAZEM = A.CD_ARMAZEM (+)" & _
                           " AND B.CD_PILHA_ARMAZEM = A.CD_PILHA_ARMAZEM (+)" & _
                           " AND B.SQ_MOVIMENTACAO = A.SQ_MOVIMENTACAO (+)" & _
                           " AND B.SQ_MOVIMENTACAO_PILHA_ARMAZEM = A.SQ_MOVIMENTACAO_PILHA_ARMAZEM (+)" & _
                           " AND B.CD_ARMAZEM = " & CdArmazem & ")" & _
                         " GROUP BY CD_PROCEDENCIA_PILHA, CD_ARMAZEM, CD_PILHA_ARMAZEM) MP," & _
                        "(SELECT SUM (QT_VOLUME) QT_VOLUME," & _
                                "SUM (QT_SACOS) QT_SACOS," & _
                                "CD_PROCEDENCIA," & _
                                "CD_ARMAZEM," & _
                                "CD_PILHA_ARMAZEM," & _
                                "MAX (DT_MOVIMENTACAO) DT_MOVIMENTACAO" & _
                         " FROM (SELECT A.CD_PROCEDENCIA," & _
                                       "B.QT_VOLUME," & _
                                       "NVL (C.QT_SACOS, 0) QT_SACOS," & _
                                       "B.CD_ARMAZEM," & _
                                       "B.CD_PILHA_ARMAZEM," & _
                                       "A.DT_MOVIMENTACAO" & _
                                " FROM SOF.MOVIMENTACAO A," & _
                                      "SOF.MOVIMENTACAO_PILHA_ARMAZEM B," & _
                                      "(SELECT MS.CD_ARMAZEM," & _
                                              "MS.CD_PILHA_ARMAZEM," & _
                                              "MS.SQ_MOVIMENTACAO," & _
                                              "MS.SQ_MOVIMENTACAO_PILHA_ARMAZEM," & _
                                              "SUM (MS.QT_SACOS) QT_SACOS" & _
                                       " FROM SOF.MOV_PILHA_ARMAZEM_SACARIA MS" & _
                                       " GROUP BY MS.CD_ARMAZEM," & _
                                                 "MS.CD_PILHA_ARMAZEM," & _
                                                 "MS.SQ_MOVIMENTACAO," & _
                                                 "MS.SQ_MOVIMENTACAO_PILHA_ARMAZEM) C" & _
                                " WHERE A.SQ_MOVIMENTACAO = B.SQ_MOVIMENTACAO" & _
                                  " AND B.CD_ARMAZEM = C.CD_ARMAZEM(+)" & _
                                  " AND B.CD_PILHA_ARMAZEM = C.CD_PILHA_ARMAZEM(+)" & _
                                  " AND B.SQ_MOVIMENTACAO = C.SQ_MOVIMENTACAO(+)" & _
                                  " AND B.SQ_MOVIMENTACAO_PILHA_ARMAZEM = C.SQ_MOVIMENTACAO_PILHA_ARMAZEM(+)" & _
                                  " AND B.CD_ARMAZEM = " & CdArmazem & ")" & _
                         " GROUP BY CD_PROCEDENCIA, CD_ARMAZEM, CD_PILHA_ARMAZEM) MI" & _
                  " WHERE MP.CD_ARMAZEM = MI.CD_ARMAZEM" & _
                    " AND MP.CD_PILHA_ARMAZEM = MI.CD_PILHA_ARMAZEM" & _
                  " ORDER BY NVL(MP.CD_PROCEDENCIA_PILHA, '-')," & _
                            "MP.CD_PILHA_ARMAZEM"

        objGrid_Carregar(grdPilha, SqlText, New Integer() {cnt_GridPilha_Codigo, _
                                                           cnt_GridPilha_Procedencia, _
                                                           cnt_GridPilha_Quantidade, _
                                                           cnt_GridPilha_Sacos, _
                                                           cnt_GridPilha_DataFormacao})
    End Sub

    Private Sub frmConsultaArmazem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objGrid_Inicializar(grdArmazem, , oDS_Armazem, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)

        objGrid_Coluna_Add(grdArmazem, "Código", 0)
        objGrid_Coluna_Add(grdArmazem, "Código", 40)
        objGrid_Coluna_Add(grdArmazem, "Filial", 110)
        objGrid_Coluna_Add(grdArmazem, "Armazem", 90)
        objGrid_Coluna_Add(grdArmazem, "Quantidade", 90, , , , , cnt_Formato_Kilos)


        objGrid_ExibirTotal(grdArmazem, New Integer() {cnt_GridArmazem_Quantidade})

        Dim oLista01 As New ValueList
        Dim SqlText As String

        SqlText = "SELECT CD_PROCEDENCIA," & _
                         "CD_PROCEDENCIA" & _
                  " FROM SOF.PROCEDENCIA" & _
                  " ORDER BY NO_PROCEDENCIA"
        oLista01 = ValueList_Carregar(SqlText)

        objGrid_Inicializar(grdPilha, , oDS_Pilha, UltraWinGrid.CellClickAction.RowSelect, , DefaultableBoolean.False)
        objGrid_Coluna_Add(grdPilha, "Pilha", 50)
        objGrid_Coluna_Add(grdPilha, "Proc.", 50, , SEC_ValidarAcessoPermisao(SEC_Permissao.SEC_P_Acesso_AlterarProcedenciaPilha), , oLista01)
        objGrid_Coluna_Add(grdPilha, "Qtde.", 60, , , , , cnt_Formato_Kilos)
        objGrid_Coluna_Add(grdPilha, "Sacos", 70, , , , , cnt_Formato_NumeroInteiro)
        objGrid_Coluna_Add(grdPilha, "Data Formação", 120)
        objGrid_Coluna_Add(grdPilha, "Ajustar", 65, , , ColumnStyle.Button).Hidden = (Not SEC_ValidarAcessoInterno(cnt_Tela, SEC_Validador.SEC_V_Inclusao))

        objGrid_ExibirTotal(grdPilha, New Integer() {cnt_GridPilha_Quantidade, _
                                                     cnt_GridPilha_Sacos})

        ExecutaConsultaArmazem()
    End Sub

    Private Sub grdArmazem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdArmazem.Click
        If objGrid_LinhaSelecionada(grdArmazem) = -1 Then
            Exit Sub
        End If

        lblPilha.Text = "Pilhas Armazem " & objGrid_Valor(grdArmazem, cnt_GridArmazem_Nome)
        ExecutaConsultaPilha(objGrid_Valor(grdArmazem, cnt_GridArmazem_Codigo))
    End Sub

    Private Sub cmdExcell_Armazem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell_Armazem.Click
        objGrid_ExportarExcell(grdArmazem, Me.Text & " - Armazém", cmdExcell_Armazem)
    End Sub

    Private Sub cmdItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlterar.Click
        If objGrid_LinhaSelecionada(grdArmazem) = -1 Then
            Msg_Mensagem("Favor selecionar um Armazem.")
            Exit Sub
        Else
            Filtro = objGrid_Valor(grdArmazem, cnt_GridArmazem_Codigo)
        End If

        If objGrid_LinhaSelecionada(grdPilha) <> -1 Then
            Filtro1 = objGrid_Valor(grdPilha, cnt_GridPilha_Codigo)
        End If

        Form_Show(Me.MdiParent, frmConsultaArmazemItem)
    End Sub

    Private Sub cmdExcell_Pilha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcell_Pilha.Click
        objGrid_ExportarExcell(grdPilha, Me.Text & " - Pilha", cmdExcell_Pilha)
    End Sub

    Private Sub grdPilha_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdPilha.AfterRowUpdate
        Dim SqlText As String

        SqlText = DBMontar_Update("PILHA_ARMAZEM", GerarArray("CD_PROCEDENCIA", ":CD_PROCEDENCIA"), _
                                                   GerarArray("CD_PILHA_ARMAZEM", ":CD_PILHA_ARMAZEM", " AND ", _
                                                              "CD_ARMAZEM", ":CD_ARMAZEM"))

        If Not DBExecutar(SqlText, DBParametro_Montar("CD_PROCEDENCIA", e.Row.Cells(cnt_GridPilha_Procedencia).Value), _
                                   DBParametro_Montar("CD_PILHA_ARMAZEM", e.Row.Cells(cnt_GridPilha_Codigo).Value), _
                                   DBParametro_Montar("CD_ARMAZEM", objGrid_Valor(grdArmazem, cnt_GridArmazem_Codigo))) Then GoTo Erro

        Exit Sub

Erro:
        TratarErro(, , "frmCadastroArmazem.grdPilha_AfterRowUpdate")
    End Sub

    Private Sub grdPilha_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdPilha.ClickCellButton
        Dim SqlText As String

        If Not Msg_Perguntar("Deseja realizar o ajuste de zeramento dessa pilha?") Then Exit Sub

        If e.Cell.Column.Index = cnt_GridPilha_Ajustar Then
            SqlText = "DECLARE" & _
                      "  p_CD_ARMAZEM NUMBER;" & _
                      "  p_CD_PILHA NUMBER;" & _
                      "" & _
                      "  CURSOR CST(p_CD_ARMAZEM NUMBER, p_CD_PILHA_ARMAZEM NUMBER) IS" & _
                      "    SELECT ME.QT_KG_LIQUIDO_NF, H.*" & _
                      "     FROM SOF.MOV_PILHA_ARMAZEM_HISTORICO H," & _
                      "     			(SELECT DISTINCT SQ_MOVIMENTACAO" & _
                      "     				FROM SOF.MOVIMENTACAO MV," & _
                      "     						 SOF.TIPO_MOVIMENTACAO TM" & _
                      "     				WHERE TM.CD_TIPO_MOVIMENTACAO = MV.CD_TIPO_MOVIMENTACAO" & _
                      "     				  AND NVL(TM.IC_TIPO_UTILIZACAO, 'N') IN ('T')) MT," & _
                      "     			(SELECT DISTINCT SQ_TRANSFERENCIA" & _
                      "     			  FROM SOF.TRANSFERENCIA TR," & _
                      "     			  		 SOF.TRANSFERENCIA_MODALIDADE TM" & _
                      "     			  WHERE TM.CD_TRANSFERENCIA_MODALIDADE = TR.CD_TRANSFERENCIA_MODALIDADE" & _
                      "     			    AND NVL(TM.IC_TIPO_UTILIZACAO, 'N') IN ('T')) TT," & _
                      "     		 SOF.TRANSFERENCIA TR," & _
                      "     		 SOF.MOVIMENTACAO ME" & _
                      "     WHERE H.CD_ARMAZEM = p_CD_ARMAZEM" & _
                      "       AND H.CD_PILHA_ARMAZEM = p_CD_PILHA_ARMAZEM" & _
                      "       AND MT.SQ_MOVIMENTACAO (+) = H.SQ_MOVIMENTACAO" & _
                      "       AND TT.SQ_TRANSFERENCIA (+) = H.SQ_TRANSFERENCIA" & _
                      "       AND ((H.IC_SAIDA = 'N' AND MT.SQ_MOVIMENTACAO IS NULL) OR" & _
                      "       		  (H.IC_SAIDA = 'S' AND TT.SQ_TRANSFERENCIA IS NULL) OR" & _
                      "						 H.CM_LANCAMENTO IS NOT NULL)" & _
                      "       AND TR.SQ_TRANSFERENCIA (+) = H.SQ_TRANSFERENCIA" & _
                      "       AND ME.SQ_MOVIMENTACAO (+) = TR.SQ_MOVIMENTACAO_ENTRADA" & _
                      "    ORDER BY H.DT_CRIACAO;" & _
                      "" & _
                      "  CURSOR PILHAS IS" & _
                      "   SELECT CD_ARMAZEM, CD_PILHA" & _
                      "    FROM SOF.ARMAZEM_PILHA_LASTRO" & _
                      "    WHERE CD_ARMAZEM = NVL(p_CD_ARMAZEM, CD_ARMAZEM)" & _
                      "		  AND CD_PILHA = NVL(p_CD_PILHA, CD_PILHA)" & _
                      "    ORDER BY CD_ARMAZEM, CD_PILHA;" & _
                      "" & _
                      "  v_DT_INICIO_CRIACAO DATE;" & _
                      "  v_DT_FIM_CRIACAO DATE;" & _
                      "  v_DT_INICIO_DESMANCHE DATE;" & _
                      "  v_DT_FIM_DESMANCHE DATE;" & _
                      "  v_SQ_MOVIMENTACAO_INICIAL NUMBER;" & _
                      "  v_SQ_MOVIMENTACAO_FINAL NUMBER;" & _
                      "  v_QT_ENTRADA NUMBER;" & _
                      "  v_QT_SAIDA NUMBER;" & _
                      "  v_QT_ENTRADA_SACO NUMBER;" & _
                      "  v_QT_SAIDA_SACO NUMBER;" & _
                      "  v_IC_PODE_GRAVAR CHAR(1);" & _
                      "" & _
                      "  AUX NUMBER;" & _
                      "  VOLUME_ESTOQUE NUMBER;" & _
                      "  v_CD_ARMAZEM NUMBER;" & _
                      "  v_CD_PILHA NUMBER;" & _
                      "  v_IC_USAR_CTRL_ZERA_PILHA CHAR(1);" & _
                      "  v_QT_PESO_MEDIO NUMBER;" & _
                      "  v_SQ_ARMAZEM_PILHA_DATA NUMBER;" & _
                      "" & _
                      "  MENS_ERRO VARCHAR(4000);" & _
                      "BEGIN" & _
                      "  p_CD_ARMAZEM:= " & objGrid_Valor(grdArmazem, cnt_GridArmazem_Codigo) & ";" & _
                      "  p_CD_PILHA:= " & e.Cell.Row.Cells(cnt_GridPilha_Codigo).Value & ";" & _
                      "" & _
                      "  SELECT NVL(IC_USAR_CTRL_ZERA_PILHA, 'N')" & _
                      "   INTO v_IC_USAR_CTRL_ZERA_PILHA" & _
                      "   FROM SOF.PARAMETRO_SUMMUS;" & _
                      "" & _
                      "  UPDATE SOF.PARAMETRO_SUMMUS" & _
                      "   SET IC_USAR_CTRL_ZERA_PILHA = 'N';" & _
                      "" & _
                      "  FOR X1 IN PILHAS" & _
                      "  LOOP" & _
                      "    BEGIN" & _
                      "		  DELETE FROM SOF.ARMAZEM_PILHA_DATA" & _
                      "		   WHERE CD_ARMAZEM = X1.CD_ARMAZEM" & _
                      "		  	 AND CD_PILHA = X1.CD_PILHA;" & _
                      "	" & _
                      "	    AUX:= 0;" & _
                      "	    VOLUME_ESTOQUE:= 0;" & _
                      "	    v_QT_ENTRADA:= 0;" & _
                      "	    v_QT_SAIDA:= 0;" & _
                      "	    v_IC_PODE_GRAVAR:= 'S';" & _
                      "	    v_DT_INICIO_CRIACAO:= NULL;" & _
                      "	    v_DT_FIM_CRIACAO:= NULL;" & _
                      "	    v_DT_INICIO_DESMANCHE:= NULL;" & _
                      "	    v_DT_FIM_DESMANCHE:= NULL;" & _
                      "	    v_SQ_MOVIMENTACAO_INICIAL:= NULL;" & _
                      "	" & _
                      "	    FOR X IN CST(X1.CD_ARMAZEM, X1.CD_PILHA)" & _
                      "	    LOOP" & _
                      "	      v_CD_ARMAZEM:= X.CD_ARMAZEM;" & _
                      "	      v_CD_PILHA:= X.CD_PILHA_ARMAZEM;" & _
                      "	" & _
                      "	      IF v_DT_INICIO_CRIACAO IS NULL THEN" & _
                      "	        v_DT_INICIO_CRIACAO:= X.DT_CRIACAO;" & _
                      "	        v_SQ_MOVIMENTACAO_INICIAL:= X.SQ_MOVIMENTACAO;" & _
                      "	      END IF;" & _
                      "	" & _
                      "	      IF X.IC_SAIDA = 'S' THEN" & _
                      "	      	IF v_DT_INICIO_DESMANCHE IS NULL THEN" & _
                      "			      v_DT_INICIO_DESMANCHE:= X.DT_CRIACAO;" & _
                      "	      	END IF;" & _
                      "	" & _
                      "	        AUX:= AUX - X.QT_VOLUME;" & _
                      "	        v_QT_SAIDA:= v_QT_SAIDA + NVL(X.QT_KG_LIQUIDO_NF, X.QT_VOLUME);" & _
                      "	        v_DT_FIM_DESMANCHE:= X.DT_CRIACAO;" & _
                      "	      ELSE" & _
                      "	        AUX:= AUX + X.QT_VOLUME;" & _
                      "	        v_QT_ENTRADA:= v_QT_ENTRADA + X.QT_VOLUME;" & _
                      "			    v_DT_FIM_CRIACAO:= X.DT_CRIACAO;" & _
                      "	      END IF;" & _
                      "	" & _
                      "	      v_SQ_MOVIMENTACAO_FINAL:= X.SQ_MOVIMENTACAO;" & _
                      "	" & _
                      "	      IF AUX = 0 THEN" & _
                      "	        v_IC_PODE_GRAVAR:= 'N';" & _
                      "	" & _
                      "	        SELECT SUM(QT_SACOS)" & _
                      "	         INTO v_QT_ENTRADA_SACO" & _
                      "	         FROM SOF.MOV_PILHA_ARMAZEM_HISTORICO M," & _
                      "	              SOF.MOV_PILHA_ARMAZEM_HIST_SACARIA S," & _
                      "	              SOF.MOVIMENTACAO MV," & _
                      "	              SOF.TIPO_MOVIMENTACAO TM" & _
                      "	         WHERE M.CD_ARMAZEM = v_CD_ARMAZEM" & _
                      "	           AND M.CD_PILHA_ARMAZEM = v_CD_PILHA" & _
                      "	           AND M.DT_CRIACAO >= v_DT_INICIO_CRIACAO" & _
                      "	           AND M.DT_CRIACAO <= DECODE(SIGN(v_DT_FIM_CRIACAO - NVL(v_DT_FIM_DESMANCHE, v_DT_FIM_CRIACAO)), 1, v_DT_FIM_CRIACAO, NVL(v_DT_FIM_DESMANCHE, v_DT_FIM_CRIACAO))" & _
                      "	           AND M.IC_SAIDA = 'N'" & _
                      "	           AND MV.SQ_MOVIMENTACAO = M.SQ_MOVIMENTACAO" & _
                      "	           AND TM.CD_TIPO_MOVIMENTACAO = MV.CD_TIPO_MOVIMENTACAO" & _
                      "	           AND (TM.IC_TIPO_UTILIZACAO NOT IN ('T') OR TM.IC_TIPO_UTILIZACAO IS NULL OR M.CM_LANCAMENTO IS NOT NULL)" & _
                      "	           AND S.CD_ARMAZEM = M.CD_ARMAZEM" & _
                      "	           AND S.CD_PILHA_ARMAZEM = M.CD_PILHA_ARMAZEM" & _
                      "	           AND S.SQ_MOVIMENTACAO = M.SQ_MOVIMENTACAO" & _
                      "	           AND S.SQ_MOV_PILHA_ARMAZEM_HISTORICO = M.SQ_MOV_PILHA_ARMAZEM_HISTORICO;" & _
                      "	" & _
                      "	        SELECT SUM(QT_SACOS)" & _
                      "	         INTO v_QT_SAIDA_SACO" & _
                      "	         FROM SOF.MOV_PILHA_ARMAZEM_HISTORICO M," & _
                      "	              SOF.MOV_PILHA_ARMAZEM_HIST_SACARIA S," & _
                      "	              SOF.MOVIMENTACAO MV," & _
                      "	              SOF.TRANSFERENCIA TR," & _
                      "	              SOF.TRANSFERENCIA_MODALIDADE TM" & _
                      "	         WHERE M.CD_ARMAZEM = v_CD_ARMAZEM" & _
                      "	           AND M.CD_PILHA_ARMAZEM = v_CD_PILHA" & _
                      "	           AND M.DT_CRIACAO >= v_DT_INICIO_CRIACAO" & _
                      "	           AND M.DT_CRIACAO <= DECODE(SIGN(v_DT_FIM_CRIACAO - NVL(v_DT_FIM_DESMANCHE, v_DT_FIM_CRIACAO)), 1, v_DT_FIM_CRIACAO, NVL(v_DT_FIM_DESMANCHE, v_DT_FIM_CRIACAO))" & _
                      "	           AND M.IC_SAIDA = 'S'" & _
                      "	           AND MV.SQ_MOVIMENTACAO = M.SQ_MOVIMENTACAO" & _
                      "	           AND TR.SQ_TRANSFERENCIA (+) = M.SQ_TRANSFERENCIA" & _
                      "	           AND TM.CD_TRANSFERENCIA_MODALIDADE (+) = TR.CD_TRANSFERENCIA_MODALIDADE" & _
                      "	           AND (TM.IC_TIPO_UTILIZACAO NOT IN ('T') OR TM.IC_TIPO_UTILIZACAO IS NULL OR M.CM_LANCAMENTO IS NOT NULL)" & _
                      "	           AND S.CD_ARMAZEM = M.CD_ARMAZEM" & _
                      "	           AND S.CD_PILHA_ARMAZEM = M.CD_PILHA_ARMAZEM" & _
                      "	           AND S.SQ_MOVIMENTACAO = M.SQ_MOVIMENTACAO" & _
                      "	           AND S.SQ_MOV_PILHA_ARMAZEM_HISTORICO = M.SQ_MOV_PILHA_ARMAZEM_HISTORICO;" & _
                      "	" & _
                      "	        IF NVL(v_QT_ENTRADA_SACO, 0) = 0 THEN" & _
                      "	          v_QT_PESO_MEDIO:= 0;" & _
                      "	        ELSE" & _
                      "	          v_QT_PESO_MEDIO:= v_QT_ENTRADA / NVL(v_QT_ENTRADA_SACO, 0);" & _
                      "	        END IF;" & _
                      "	" & _
                      "					/* Pega um novo ID */" & _
                      "					BEGIN" & _
                      "						SELECT MAX(SQ_ARMAZEM_PILHA_DATA) + 1" & _
                      "						 INTO v_SQ_ARMAZEM_PILHA_DATA" & _
                      "						 FROM SOF.ARMAZEM_PILHA_DATA;" & _
                      "					EXCEPTION" & _
                      "					  WHEN NO_DATA_FOUND THEN" & _
                      "					    v_SQ_ARMAZEM_PILHA_DATA:= 1;" & _
                      "				  END;" & _
                      "	" & _
                      "	        INSERT INTO SOF.ARMAZEM_PILHA_DATA" & _
                      "	        (SQ_ARMAZEM_PILHA_DATA, CD_ARMAZEM, CD_PILHA," & _
                      "	         DT_INICIO_CRIACAO, DT_FIM_CRIACAO," & _
                      "	         DT_INICIO_DESMANCHE, DT_FIM_DESMANCHE," & _
                      "	         QT_PESO_CRIACAO, QT_PESO_DESMANCHE," & _
                      "	         QT_SACO_MAXIMO, QT_SACO_ATUAL," & _
                      "	         QT_PESO_MEDIO, IC_CTRL_MEDIA_PESO," & _
                      "	    		 DT_CRIACAO, NO_USER_CRIACAO," & _
                      "	         DT_ALTERACAO, NO_USER_ALTERACAO, IC_ATUAL)" & _
                      "	    		VALUES" & _
                      "	    		(v_SQ_ARMAZEM_PILHA_DATA, v_CD_ARMAZEM, v_CD_PILHA," & _
                      "	         v_DT_INICIO_CRIACAO, v_DT_FIM_CRIACAO," & _
                      "	         v_DT_INICIO_DESMANCHE, v_DT_FIM_DESMANCHE," & _
                      "	         v_QT_ENTRADA, v_QT_SAIDA," & _
                      "	         NVL(v_QT_ENTRADA_SACO, 0), NVL(v_QT_ENTRADA_SACO, 0) - NVL(v_QT_SAIDA_SACO, 0)," & _
                      "	         v_QT_PESO_MEDIO, 'S', SYSDATE, 'SOF', SYSDATE, 'SOF', 'N');" & _
                      "	" & _
                      "	        v_DT_INICIO_CRIACAO:= NULL;" & _
                      "	        v_DT_FIM_CRIACAO:= NULL;" & _
                      "	        v_DT_INICIO_DESMANCHE:= NULL;" & _
                      "	        v_DT_FIM_DESMANCHE:= NULL;" & _
                      "	        v_QT_ENTRADA:= 0;" & _
                      "	        v_QT_SAIDA:= 0;        " & _
                      "	      END IF;" & _
                      "	    END LOOP;" & _
                      "" & _
                      "	    IF AUX <> 0 AND v_IC_PODE_GRAVAR = 'N' THEN" & _
                      "	      SELECT SUM(QT_SACOS)" & _
                      "	       INTO v_QT_ENTRADA_SACO" & _
                      "	       FROM SOF.MOV_PILHA_ARMAZEM_HISTORICO M," & _
                      "	            SOF.MOV_PILHA_ARMAZEM_HIST_SACARIA S," & _
                      "	            SOF.MOVIMENTACAO MV," & _
                      "	            SOF.TIPO_MOVIMENTACAO TM" & _
                      "	       WHERE M.CD_ARMAZEM = v_CD_ARMAZEM" & _
                      "	         AND M.CD_PILHA_ARMAZEM = v_CD_PILHA" & _
                      "	         AND M.DT_CRIACAO >= v_DT_INICIO_CRIACAO" & _
                      "	         AND M.DT_CRIACAO <= DECODE(SIGN(v_DT_FIM_CRIACAO - NVL(v_DT_FIM_DESMANCHE, v_DT_FIM_CRIACAO)), 1, v_DT_FIM_CRIACAO, NVL(v_DT_FIM_DESMANCHE, v_DT_FIM_CRIACAO))" & _
                      "	         AND M.IC_SAIDA = 'N'" & _
                      "	         AND MV.SQ_MOVIMENTACAO = M.SQ_MOVIMENTACAO" & _
                      "	         AND TM.CD_TIPO_MOVIMENTACAO = MV.CD_TIPO_MOVIMENTACAO" & _
                      "	         AND (TM.IC_TIPO_UTILIZACAO NOT IN ('T') OR TM.IC_TIPO_UTILIZACAO IS NULL OR M.CM_LANCAMENTO IS NOT NULL)" & _
                      "	         AND S.CD_ARMAZEM = M.CD_ARMAZEM" & _
                      "	         AND S.CD_PILHA_ARMAZEM = M.CD_PILHA_ARMAZEM" & _
                      "	         AND S.SQ_MOVIMENTACAO = M.SQ_MOVIMENTACAO" & _
                      "	         AND S.SQ_MOV_PILHA_ARMAZEM_HISTORICO = M.SQ_MOV_PILHA_ARMAZEM_HISTORICO;" & _
                      "" & _
                      "	      SELECT SUM(QT_SACOS)" & _
                      "	       INTO v_QT_SAIDA_SACO" & _
                      "	       FROM SOF.MOV_PILHA_ARMAZEM_HISTORICO M," & _
                      "	            SOF.MOV_PILHA_ARMAZEM_HIST_SACARIA S," & _
                      "	            SOF.MOVIMENTACAO MV," & _
                      "	            SOF.TRANSFERENCIA TR," & _
                      "	            SOF.TRANSFERENCIA_MODALIDADE TM" & _
                      "	       WHERE M.CD_ARMAZEM = v_CD_ARMAZEM" & _
                      "	         AND M.CD_PILHA_ARMAZEM = v_CD_PILHA" & _
                      "	         AND M.DT_CRIACAO >= v_DT_INICIO_CRIACAO" & _
                      "	         AND M.DT_CRIACAO <= DECODE(SIGN(v_DT_FIM_CRIACAO - NVL(v_DT_FIM_DESMANCHE, v_DT_FIM_CRIACAO)), 1, v_DT_FIM_CRIACAO, NVL(v_DT_FIM_DESMANCHE, v_DT_FIM_CRIACAO))" & _
                      "	         AND M.IC_SAIDA = 'S'" & _
                      "	         AND MV.SQ_MOVIMENTACAO = M.SQ_MOVIMENTACAO" & _
                      "	         AND TR.SQ_TRANSFERENCIA (+) = M.SQ_TRANSFERENCIA" & _
                      "	         AND TM.CD_TRANSFERENCIA_MODALIDADE (+) = TR.CD_TRANSFERENCIA_MODALIDADE" & _
                      "	         AND (TM.IC_TIPO_UTILIZACAO NOT IN ('T') OR TM.IC_TIPO_UTILIZACAO IS NULL OR M.CM_LANCAMENTO IS NOT NULL)" & _
                      "	         AND S.CD_ARMAZEM = M.CD_ARMAZEM" & _
                      "	         AND S.CD_PILHA_ARMAZEM = M.CD_PILHA_ARMAZEM" & _
                      "	         AND S.SQ_MOVIMENTACAO = M.SQ_MOVIMENTACAO" & _
                      "	         AND S.SQ_MOV_PILHA_ARMAZEM_HISTORICO = M.SQ_MOV_PILHA_ARMAZEM_HISTORICO;" & _
                      "" & _
                      "	      IF NVL(v_QT_ENTRADA_SACO, 0) = 0 THEN" & _
                      "	        v_QT_PESO_MEDIO:= 0;" & _
                      "	      ELSE" & _
                      "	        v_QT_PESO_MEDIO:= v_QT_ENTRADA / NVL(v_QT_ENTRADA_SACO, 0);" & _
                      "	      END IF;" & _
                      "" & _
                      "				/* Pega um novo ID */" & _
                      "				BEGIN" & _
                      "					SELECT MAX(SQ_ARMAZEM_PILHA_DATA) + 1" & _
                      "					 INTO v_SQ_ARMAZEM_PILHA_DATA" & _
                      "					 FROM SOF.ARMAZEM_PILHA_DATA;" & _
                      "				EXCEPTION" & _
                      "				  WHEN NO_DATA_FOUND THEN" & _
                      "				    v_SQ_ARMAZEM_PILHA_DATA:= 1;" & _
                      "			  END;" & _
                      "" & _
                      "	      INSERT INTO SOF.ARMAZEM_PILHA_DATA" & _
                      "	  	  (SQ_ARMAZEM_PILHA_DATA, CD_ARMAZEM, CD_PILHA," & _
                      "	       DT_INICIO_CRIACAO, DT_FIM_CRIACAO," & _
                      "	       DT_INICIO_DESMANCHE, DT_FIM_DESMANCHE," & _
                      "	       QT_PESO_CRIACAO, QT_PESO_DESMANCHE," & _
                      "	       QT_SACO_MAXIMO, QT_SACO_ATUAL," & _
                      "	       QT_PESO_MEDIO, IC_CTRL_MEDIA_PESO," & _
                      "	  	   DT_CRIACAO, NO_USER_CRIACAO," & _
                      "	       DT_ALTERACAO, NO_USER_ALTERACAO, IC_ATUAL)" & _
                      "	  	  VALUES" & _
                      "		    (v_SQ_ARMAZEM_PILHA_DATA, v_CD_ARMAZEM, v_CD_PILHA," & _
                      "	       v_DT_INICIO_CRIACAO, v_DT_FIM_CRIACAO," & _
                      "		     v_DT_INICIO_DESMANCHE, v_DT_FIM_DESMANCHE," & _
                      "	       v_QT_ENTRADA, v_QT_SAIDA," & _
                      "	       NVL(v_QT_ENTRADA_SACO, 0), NVL(v_QT_ENTRADA_SACO, 0) - NVL(v_QT_SAIDA_SACO, 0)," & _
                      "	       v_QT_PESO_MEDIO, 'S', SYSDATE, 'SOF', SYSDATE, 'SOF', 'S');" & _
                      "	    END IF;" & _
                      "	  EXCEPTION" & _
                      "	    WHEN OTHERS THEN" & _
                      "			  MENS_ERRO:= TRIM(SQLERRM);" & _
                      "" & _
                      "			  INSERT INTO SOF.PROCESSO_LOG (CD_PROCESSO, CD_STATUS, NR_LOG, DT_LOG, DS_LOG)" & _
                      "			   VALUES (18, 1, 0, SYSDATE, TO_CHAR(X1.CD_ARMAZEM) || '-' || TO_CHAR(X1.CD_PILHA) || ' >> '  || MENS_ERRO);" & _
                      "	  END;" & _
                      "" & _
                      "    COMMIT;	  " & _
                      "  END LOOP;" & _
                      "" & _
                      "  UPDATE SOF.PARAMETRO_SUMMUS" & _
                      "   SET IC_USAR_CTRL_ZERA_PILHA = v_IC_USAR_CTRL_ZERA_PILHA;" & _
                      "END;"

            If Not DBExecutar(SqlText) Then GoTo Erro
        End If

        Msg_Mensagem("Ajuste Realizado")

        Exit Sub

Erro:
        TratarErro(, , "frmConsultaArmazem_grdPilha_ClickCellButton")
    End Sub
End Class