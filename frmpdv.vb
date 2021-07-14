Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Threading
Imports MessagingToolkit.QRCode.Codec
Imports System.Data.SQLite
Imports System.Diagnostics
Public Class frmpdv
    Public retp As Boolean = False
    Dim nome_prit As String, emp_red As Boolean
    Dim thread As Thread, thread2 As Thread, thread3 As Thread
    Dim excluir As Boolean
    Dim lbltimer As Integer = 0
    Private paginaAtual As Integer = 1
    Public indPag As String = "1"
    Public vPag As String = "0,00"
    Public vTroco As Decimal
    Public vlr_canc As Decimal
    Public vd_aprazo As String, prazodia As String
    Public ambiente As Integer
    Public cod_op As String, statusnfe2 As String
    Public SERIENFCE As String
    Public chv_nfce As String, chv_nfcecont As String, chave_n As String
    Public cnpj_dest As String = ""
    Public parametro_venda As Boolean = False
    Public foco As Boolean
    Public codigo_orc As String, operador As String, caixa As String
    Dim rsvenda As New ADODB.Recordset
    Dim rs As New ADODB.Recordset
    Dim rsconsulta As New ADODB.Recordset
    Public codigo_fin As String
    Dim sSerie As String
    Public xmldoc As New XmlDocument()


    Private Sub frmpdv_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Dim processos As Process
        For Each processos In Process.GetProcesses
            If processos.ProcessName = "SJP_transp" Then
                processos.Kill()
            End If
        Next

        Me.Dispose()
    End Sub

    Private Sub frmpdv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
        If e.KeyCode = Keys.Space Then
            If dgvproduto.Rows.Count <> "0" Then


                txtdescricao.Text = "Informe o tipo de pagamento..."
                txtdescricao.BackColor = Color.Gold
                txtcodbarra.Enabled = False
                txtqtde.Enabled = False
                txtvlrunit.Enabled = False
                txtdesconto.Enabled = False
                txtcodbarra.BackColor = Color.Silver
                txtqtde.BackColor = Color.Silver
                txtvlrunit.BackColor = Color.Silver
                txtdesconto.BackColor = Color.Silver

            End If
        End If

        If e.KeyCode = Keys.F4 Then
            If dgvproduto.Rows.Count <> 0 Then

                If ret_valor_banco("operador", "codigo_op", cod_op, "canc_item") = "0" Then
                    MsgBox("Você não tem permissão para esta operação ?", MsgBoxStyle.Exclamation, "Aviso !")
                    Exit Sub
                End If

                txtdescricao.Text = "Excluir item, Informe o Código de barras..."
                txtdescricao.BackColor = Color.Silver
            End If
        End If

        If e.KeyCode = Keys.F5 Then
            FrmConsultaProduto.par = "pdv"
            FrmConsultaProduto.ShowDialog()
            txtcodbarra.Focus()
        End If

        If e.KeyCode = Keys.F1 Then
            If txtdescricao.Text = "Informe o tipo de pagamento..." Then
                retp = False
                frmopcaopag.ShowDialog()

                If codigo_fin = "05" Then
                    frm_optcli.ShowDialog()
                    If vd_aprazo <> "ok" Then
                        Exit Sub
                    End If

                End If
                If codigo_fin <> "01" Then
                    vPag = txtvlrtotal.Text
                End If

                If retp = True Then
                    ret()
                    Exit Sub
                End If

                Directory.CreateDirectory(Application.StartupPath & "\XML_NFCe")
                Dim xmlDocument As XmlDocument = New XmlDocument()
                xmlDocument.LoadXml(gerar_xml(caixa, "1", codigo_orc, "4.00", empresa.ambiente_nfe))
                xmlDocument.Save(Application.StartupPath & "\XML_NFCe\" & chv_nfce & codigo_orc & "-env.xml")

                Dim r As String = envia_NF_host_list(chv_nfce)

                'gerar_cont()

                controle_op(codigo_fin, txtvlrtotal.Text)


                If codigo_fin = "05" Then
                    Dim nr As String

                    If chv_nfcecont = "" Then
                        nr = chv_nfce.Substring(25, 9)
                    Else
                        nr = chv_nfcecont.Substring(25, 9)
                    End If

                    If emp_red = True Then
                        danfeECF.Imprimir_prazo(cnpj_dest, codigo_orc, txtvlrtotal.Text, nr, nome_prit)
                    Else

                        If nome_prit <> "" Then
                            PrintDocument1.PrinterSettings.PrinterName = nome_prit
                        End If

                        PrintDocument1.Print()

                    End If


                End If

                '''''''''''''enviar contigencia'''''''''
                Dim t As Boolean = False
                Try
                    If thread3.IsAlive Then
                        t = True
                    End If
                Catch ex As Exception

                End Try

                If t = False Then
                    thread3 = New Thread(AddressOf envia_cont)
                    thread3.Start()
                End If

                salvar_venda()

                finalizar_venda()

                sjp_trasnp()

            End If
        End If

        If e.KeyCode = Keys.Escape Then
            ret()
        End If

    End Sub

    Private Sub ret()
        txtdescricao.Clear()
        txtcodbarra.Enabled = True
        txtvlrunit.Enabled = True
        txtcodbarra.BackColor = Color.White
        txtqtde.BackColor = Color.White
        txtvlrunit.BackColor = Color.White
        txtdescricao.BackColor = Color.White
        txtcodbarra.Focus()
        txtdescricao.ForeColor = Color.Blue
    End Sub
    Private Sub finalizar_venda()
        carregar_par()
        txtdescricao.Clear()
        txtcodbarra.Enabled = True
        txtcodbarra.BackColor = Color.White
        txtqtde.BackColor = Color.White
        txtvlrunit.BackColor = Color.White
        txtvlrunit.Enabled = True
        txtvlrunit.ReadOnly = False
        txtdesconto.BackColor = Color.White
        txtdescricao.BackColor = Color.White
        txtcodbarra.Focus()
        txtdescricao.ForeColor = Color.Blue
        dgvproduto.Rows.Clear()
        limpa_totalgrid()
        vlr_canc = "0,00"
        limpar()
    End Sub
    Private Sub frmpdv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbloperador.Text = "Operador: " + operador
        limpar()
        limpa_totalgrid()
        txtcodbarra.Focus()

        frm_inicial.ShowDialog()

        carregar_par()

        sjp_trasnp()
    End Sub

    Private Sub carregar_par()
        Dim arquivoIni_pdv As ArquivoIni = New ArquivoIni(Application.StartupPath & "\pdv.ini")


        ambiente = empresa.ambiente_nfe

        If ambiente = "2" Then
            lblambi.Visible = True
        End If

        If arquivoIni_pdv.KeyExists("Nome_print", "Settings") = False Then
            arquivoIni_pdv.Write("Nome_print", "", "Settings")
        End If
        nome_prit = arquivoIni_pdv.Read("Nome_print", "Settings")

        If arquivoIni_pdv.KeyExists("CAIXA", "Settings") = False Then
            arquivoIni_pdv.Write("CAIXA", "", "Settings")
        End If

        caixa = arquivoIni_pdv.Read("CAIXA", "Settings")
        ToolStripStatuscaixa.Text = "Caixa: " & caixa
        lbloperador.Text = "Operador: " & operador


        If arquivoIni_pdv.KeyExists("SERIE", "Settings") = False Then
            arquivoIni_pdv.Write("SERIE", "1", "Settings")
        End If
        sSerie = arquivoIni_pdv.Read("SERIE", "Settings")


        If arquivoIni_pdv.KeyExists("Impressao_Red", "Settings") = False Then
            arquivoIni_pdv.Write("Impressao_Red", "true", "Settings")
        End If
        emp_red = arquivoIni_pdv.Read("Impressao_Red", "Settings")


        If arquivoIni_pdv.KeyExists("Desconto", "Settings") = False Then
            arquivoIni_pdv.Write("Desconto", "true", "Settings")
        End If

        If arquivoIni_pdv.Read("Desconto", "Settings") = "true" Then
            txtdesconto.Visible = True
        Else
            txtdesconto.Visible = False
        End If

        If arquivoIni_pdv.KeyExists("venda_direta", "Settings") = False Then
            arquivoIni_pdv.Write("venda_direta", "true", "Settings")
        End If

        If arquivoIni_pdv.Read("venda_direta", "Settings") = "true" Then
            txtqtde.BackColor = Color.Silver
        Else
            txtqtde.Enabled = True
        End If

        Timercad_caixa.Enabled = True
    End Sub

    Public Sub limpar()
        txtcod.Clear()
        txtdescricao.Clear()
        txtdesconto.Text = "0,00"
        txtqtde.Clear()
        txtvlrunit.Clear()
        txtcodbarra.Clear()
        txtcodbarra.Focus()
        txtun.Clear()
        txtncm.Clear()
        txtcest.Clear()
        txtcst.Clear()
        txtaliqicms.Text = "0,00"
        txtvlricms.Text = "0,00"
    End Sub

    Public Sub limpa_totalgrid()
        txtvlrtotal.Text = "0,00"
        txttotaldesc.Text = "0,00"
        dgvproduto.Rows.Clear()
    End Sub

    Private Sub txtcodbarra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodbarra.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))

        KeyAscii = CShort(SoNumeros(KeyAscii))

        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If (e.KeyChar = Chr(13)) Then

            Dim nPosI As Int32 = txtcodbarra.Text.IndexOf("X")

            If nPosI <> "-1" Then
                txtqtde.Text = txtcodbarra.Text.Substring(0, nPosI)
                txtcodbarra.Text = txtcodbarra.Text.Substring(nPosI + 1, txtcodbarra.Text.Length - nPosI - 1)
            Else
                txtqtde.Text = "1,000"
            End If

            If txtdescricao.Text = "Excluir item, Informe o Código de barras..." Then
                excluir_item("2", txtqtde.Text)
            Else
                pesquisa_codbarra()
            End If

            If txtqtde.Enabled = False Then
                txtcodbarra.Focus()
            End If
        End If

    End Sub

    Private Sub pesquisa_codbarra()
        If txtcodbarra.Text <> "" Then

            Dim ret As Integer = verificar_regexiste("select * from codigo_barras where cod_barras = '" & txtcodbarra.Text & "'")

            If ret = 0 Then
                limpar()
                txtdescricao.Text = "Produto Não Cadastrado !"
                txtcodbarra.Focus()
                Exit Sub
            Else

                Dim campo As String = ret_valor_banco("codigo_barras", "cod_barras", txtcodbarra.Text, "codigo_prod")

                conectar_sqlite()
                Dim SQLcommand As SQLiteCommand
                SQLcommand = Conn.CreateCommand
                SQLcommand.CommandText = "select * from produto where codigo_prod ='" & campo & "'"

                Using reader As SQLiteDataReader = SQLcommand.ExecuteReader

                    While reader.Read

                        txtdesconto.Text = "0,00"
                        txtdescricao.Text = reader("descricao")
                        If parametro_venda = False Then
                            txtvlrunit.Text = Format(CDec(reader("vlr_venda")), "#,##0.00")
                        Else
                            txtvlrunit.Text = reader("vlr_promocao")
                        End If
                        txtcod.Text = campo

                        txtncm.Text = reader("ncm_prod")
                        txtcst.Text = reader("cst")
                        txtcest.Text = reader("cest").ToString.Replace(".", "")
                        txtaliqicms.Text = reader("aliq_icms").ToString

                        If reader("obs").ToString <> "" Then
                            MsgBox(reader("obs").ToString, MsgBoxStyle.Information, "Observação do Produto !")
                            txtqtde.Focus()
                        End If
                    End While

                End Using


                txtun.Text = ret_valor_banco("codigo_barras", "codigo_prod", campo, "un")

                txtqtde.Text = Format(CDec(ret_valor_banco("codigo_barras", "codigo_prod", campo, "qtde")), "###0.000")


            End If

        End If


        If txtqtde.Enabled = False Then
            iniciar_venda()
        End If

    End Sub

    Private Sub txtdesconto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdesconto.GotFocus
        If txtdesconto.Text = "0,00" Then
            txtdesconto.SelectAll()
        End If

        If txtdescricao.Text = "Produto Não Cadastrado !" Then
            txtcodbarra.Focus()
        End If

        If txtcodbarra.Text = "" Then
            txtcodbarra.Focus()
        End If
    End Sub

    Private Sub txtdesconto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdesconto.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = casasdecimal2(txtdesconto, e)

        If (e.KeyChar = Chr(13)) Then
            iniciar_venda()
        End If
    End Sub

    Private Sub iniciar_venda()
        Dim rsi As New ADODB.Recordset
        If txtcodbarra.Text = "" Then
            txtcodbarra.Focus()
            Exit Sub
        End If

        If txtcst.Text.Length = 3 Then
            If txtcst.Text.Substring(1, 2) = "10" Or txtcst.Text.Substring(1, 2) = "70" Or txtcst.Text.Substring(1, 2) = "30" Or txtcst.Text.Substring(1, 2) = "20" Or txtcst.Text.Substring(1, 2) = "51" Or txtcst.Text.Substring(1, 2) = "90" Then
                MsgBox("A CST " & txtcst.Text & " do Produto não pode ser Vendida ao Consumidor Final" & vbCrLf & "Altere no Cadastro de Produto esta CST para Vender este produto ?", MsgBoxStyle.Exclamation, "Aviso !")
                txtcod.Focus()
                Exit Sub
            End If
        End If

        If txtcst.Text.Length = 4 Then
            If txtcst.Text.Substring(2, 3) = "101" Or txtcst.Text.Substring(2, 3) = "103" Or txtcst.Text.Substring(2, 3) = "201" Or txtcst.Text.Substring(2, 3) = "202" Or txtcst.Text.Substring(2, 3) = "203" Or txtcst.Text.Substring(2, 3) = "900" Then
                MsgBox("A CST " & txtcst.Text & " do Produto não pode ser Vendida ao Consumidor Final" & vbCrLf & "Altere no Cadastro de Produto esta CST para Vender este produto ?", MsgBoxStyle.Exclamation, "Aviso !")
                txtcod.Focus()
                Exit Sub
            End If
        End If

        If txtdesconto.Text = "0,00" Then
            Try
                txtvlrtotal.Text = Format(CDec(txtvlrtotal.Text) + (CDec(txtqtde.Text) * CDec(txtvlrunit.Text)), "#,##0.00")
            Catch ex As Exception
                txtvlrtotal.Text = "0,00"
            End Try

        Else
            If txtdesconto.Text = "" Then
                txtdesconto.Text = "0,00"
            End If

            txtvlrtotal.Text = Format(CDec(txtvlrtotal.Text) + ((CDec(txtqtde.Text) * CDec(txtvlrunit.Text)) - CDec(txtdesconto.Text)), "#,##0.00")
        End If

        If dgvproduto.Rows.Count = "0" Then


            codigo_orc = ProximoCodigo("RV", "rv")
            codigo_orc = codigo_orc.ToString.PadLeft(9, "0")

        End If

        If txtaliqicms.Text <> "0,00" Then
            txtvlricms.Text = Format((CDec(txtaliqicms.Text) * CDec(txtvlrtotal.Text)) / 100, "#,##0.00")
            '  txtvlricms.Text = Convert.ToDouble(txtvlrtotal.Text).ToString("N2")
        End If



        lblorc.Text = "    Código da RV: " + codigo_orc
        dgvproduto.Rows.Add(dgvproduto.RowCount + 1, txtcodbarra.Text, RemoverAcentos(txtdescricao.Text), Format(CDec(txtqtde.Text), "##0.000"), Format(CDec(txtvlrunit.Text), "#,##0.00"), Format(CDec(txtdesconto.Text), "#,##0.00"), Format((CDec(txtqtde.Text) * CDec(txtvlrunit.Text)) - CDec(txtdesconto.Text), "#,##0.00"), codigo_orc, txtcod.Text, txtun.Text, txtncm.Text, txtcest.Text, txtcst.Text, txtaliqicms.Text, txtvlricms.Text)



        limpar()

    End Sub

    Private Sub txtdesconto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdesconto.LostFocus
        Try
            If txtdesconto.Text = "" Then
                txtdesconto.Text = "0,00"
            End If

            If txtdesconto.Text <> "" Then

                txtdesconto.Text = Convert.ToDouble(txtdesconto.Text).ToString("N2")
            End If
        Catch ex As Exception
            txtdesconto.Text = "0,00"
        End Try

    End Sub

    Private Sub txtqtde_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtqtde.GotFocus
        If txtdescricao.Text = "Produto Não Cadastrado !" Then
            txtcodbarra.Focus()
        End If
        If txtcodbarra.Text = "" Then
            txtcodbarra.Focus()
        End If

    End Sub

    Private Sub txtqtde_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqtde.KeyPress
        If txtun.Text = "KG" Then
            If Char.IsLetter(e.KeyChar) Then
                e.Handled = True
            End If
        Else
            Dim KeyAscii As Short = CShort(Asc(e.KeyChar))

            KeyAscii = CShort(SoNumeros(KeyAscii))

            If KeyAscii = 0 Then

                e.Handled = True

            End If
        End If

        If (e.KeyChar = Chr(13)) Then

            If txtdesconto.Enabled = False Then
                iniciar_venda()
                txtcodbarra.Focus()
            End If

        End If

    End Sub

    Private Sub txtvlrunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvlrunit.GotFocus
        If txtdescricao.Text = "Produto Não Cadastrado !" Then
            txtcodbarra.Focus()
        End If
        If txtcodbarra.Text = "" Then
            txtcodbarra.Focus()
        End If
    End Sub

    Private Sub txtvlrtotal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtvlrtotal.GotFocus
        If txtdescricao.Text = "Produto Não Cadastrado !" Then
            txtcodbarra.Focus()
        End If
        If txtcodbarra.Text = "" Then
            txtcodbarra.Focus()
        End If
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblinfo.Text = "Emissor de Venda  " + Now + "    "
    End Sub

    Public Sub salvar_venda()
        Dim status As String
        '  Try

        Dim sql As String = "INSERT INTO RV (caixa, rv, maquina_rv, forma_pag, valor_rv, vlrdesconto_rv, chave_nfe, chave_nfecont, vlr_canc, data, obs, cnpj_dest, status_rv, operador) VALUES (@caixa, @rv, @maquina_rv, @forma_pag, @valor_rv, @vlrdesconto_rv, @chave_nfe, @chave_nfecont, @vlr_canc, @data, @obs, @cnpj_dest, @status_rv, @operador)"


        If chv_nfcecont = "" Then
            status = "RV Autorizada"
        Else
            status = "Contigencia"
        End If

        soma_desconto()

        conectar_sqlite()
        Dim insertSQL As SQLiteCommand = New SQLiteCommand(sql, Conn)
        insertSQL.Parameters.Add(New SQLiteParameter("caixa", caixa))
        insertSQL.Parameters.Add(New SQLiteParameter("rv", codigo_orc))
        insertSQL.Parameters.Add(New SQLiteParameter("maquina_rv", Environment.MachineName))
        insertSQL.Parameters.Add(New SQLiteParameter("forma_pag", codigo_fin))
        insertSQL.Parameters.Add(New SQLiteParameter("valor_rv", format_val_mysql_ent(txtvlrtotal.Text)))

        insertSQL.Parameters.Add(New SQLiteParameter("vlrdesconto_rv", format_val_mysql_ent(txttotaldesc.Text)))
        insertSQL.Parameters.Add(New SQLiteParameter("chave_nfe", chave_n))
        insertSQL.Parameters.Add(New SQLiteParameter("chave_nfecont", chv_nfcecont))
        insertSQL.Parameters.Add(New SQLiteParameter("vlr_canc", format_val_mysql_ent(vlr_canc)))

        insertSQL.Parameters.Add(New SQLiteParameter("data", Now))
        insertSQL.Parameters.Add(New SQLiteParameter("obs", ""))
        insertSQL.Parameters.Add(New SQLiteParameter("cnpj_dest", cnpj_dest))
        insertSQL.Parameters.Add(New SQLiteParameter("status_rv", status))

        insertSQL.Parameters.Add(New SQLiteParameter("operador", cod_op))


        insertSQL.ExecuteNonQuery()
        Conn.Close()

        '''''''''''''''''Rotina para salvar RV em txt''''''''''''''''''''''''
        txt_rv(codigo_orc, caixa, txtvlrtotal.Text, codigo_fin, Now, "obs", cod_op, vlr_canc, Environment.MachineName, txttotaldesc.Text, _
              chave_n, chv_nfcecont, status, cnpj_dest)



        For Each row As DataGridViewRow In dgvproduto.Rows

            Dim cfop As String
            If row.Cells("aliqicms_grid").Value.ToString = "0,00" Then
                cfop = "5405"
            Else
                cfop = "5102"
            End If

            Dim sql2 As String = "INSERT INTO item_rv (RV, N_item, codigo_prod, codigo_barras, ncm_prod, cfop_item, cest_prod, cst_prod, aliq_icms, vlr_icms, un_item, qtde_item, vlrdesc_item, vlr_item, vlr_total, data) VALUES (@RV, @N_item, @codigo_prod, @codigo_barras, @ncm_prod, @cfop_item, @cest_prod, @cst_prod, @aliq_icms, @vlr_icms, @un_item, @qtde_item, @vlrdesc_item, @vlr_item, @vlr_total, @data)"

            conectar_sqlite()
            Dim insertSQL2 As SQLiteCommand = New SQLiteCommand(sql2, Conn)
            insertSQL2.Parameters.Add(New SQLiteParameter("RV", codigo_orc))
            insertSQL2.Parameters.Add(New SQLiteParameter("N_item", CDec(row.Index) + 1))
            insertSQL2.Parameters.Add(New SQLiteParameter("codigo_prod", row.Cells("codigo_prodgrid").Value))
            insertSQL2.Parameters.Add(New SQLiteParameter("codigo_barras", row.Cells("cod_barragrid").Value))
            insertSQL2.Parameters.Add(New SQLiteParameter("ncm_prod", row.Cells("ncm_grid").Value.ToString))

            insertSQL2.Parameters.Add(New SQLiteParameter("cfop_item", cfop))
            insertSQL2.Parameters.Add(New SQLiteParameter("cest_prod", row.Cells("cest_grid").Value.ToString))
            insertSQL2.Parameters.Add(New SQLiteParameter("cst_prod", row.Cells("cst_grid").Value.ToString))
            insertSQL2.Parameters.Add(New SQLiteParameter("aliq_icms", format_val_mysql_ent(row.Cells("aliqicms_grid").Value.ToString)))

            insertSQL2.Parameters.Add(New SQLiteParameter("vlr_icms", format_val_mysql_ent(row.Cells("vlricms_grid").Value.ToString)))
            insertSQL2.Parameters.Add(New SQLiteParameter("un_item", row.Cells("un_grid").Value))
            insertSQL2.Parameters.Add(New SQLiteParameter("qtde_item", row.Cells("qtde_grid").Value))
            insertSQL2.Parameters.Add(New SQLiteParameter("vlrdesc_item", format_val_mysql_ent(row.Cells("vlrdesc_grid").Value.ToString)))

            insertSQL2.Parameters.Add(New SQLiteParameter("vlr_item", format_val_mysql_ent(row.Cells("vlrunit_grid").Value)))
            insertSQL2.Parameters.Add(New SQLiteParameter("vlr_total", format_val_mysql_ent(row.Cells("vlrtotal_grid").Value)))
            insertSQL2.Parameters.Add(New SQLiteParameter("data", Now))

            insertSQL2.ExecuteNonQuery()
            Conn.Close()

            '''''''''''''''''Rotina para salvar RV Item em txt''''''''''''''''''''''''
            txt_rv_item(codigo_orc, CDec(row.Index) + 1, row.Cells("codigo_prodgrid").Value, row.Cells("cod_barragrid").Value, row.Cells("ncm_grid").Value.ToString, _
                        cfop, row.Cells("cest_grid").Value.ToString, row.Cells("cst_grid").Value.ToString, row.Cells("aliqicms_grid").Value.ToString, _
                        row.Cells("vlricms_grid").Value.ToString, row.Cells("un_grid").Value.ToString, row.Cells("qtde_grid").Value, row.Cells("vlrdesc_grid").Value.ToString, _
                        row.Cells("vlrunit_grid").Value, row.Cells("vlrtotal_grid").Value, Now)


        Next




        If empresa.ambiente_nfe = 1 Then

            For i As Integer = 0 To dgvproduto.Rows.Count - 1
                Dim qtde As String

                Dim ret As Integer = verificar_regexiste("select * from estoque where codigo_prod = '" & dgvproduto.Rows.Item(i).Cells("codigo_prodgrid").Value & "'")
                Dim sql3 As String

                If ret = 0 Then
                    sql3 = "INSERT INTO estoque (codigo_prod, Qtde_saida, datasaida_mov) VALUES (@codigo_prod, @Qtde_saida, @datasaida_mov)"
                    Dim insertSQL3 As SQLiteCommand = New SQLiteCommand(sql3, Conn)
                    insertSQL3.Parameters.Add(New SQLiteParameter("codigo_prod", dgvproduto.Rows.Item(i).Cells("codigo_prodgrid").Value))
                    insertSQL3.Parameters.Add(New SQLiteParameter("Qtde_saida", dgvproduto.Rows.Item(i).Cells("qtde_grid").Value))
                    insertSQL3.Parameters.Add(New SQLiteParameter("datasaida_mov", Now.Date))
                    insertSQL3.ExecuteNonQuery()
                    Conn.Close()
                Else
                    sql3 = "UPDATE estoque SET Qtde_saida = @Qtde_saida, datasaida_mov = @datasaida_mov where codigo_prod = '" & dgvproduto.Rows.Item(i).Cells("codigo_prodgrid").Value & "'"
                    Dim insertSQL4 As SQLiteCommand = New SQLiteCommand(sql3, Conn)

                    qtde = CDec(ret_valor_banco("estoque", "codigo_prod", dgvproduto.Rows.Item(i).Cells("codigo_prodgrid").Value, "Qtde_saida") + CDec(dgvproduto.Rows.Item(i).Cells("qtde_grid").Value))

                    insertSQL4.Parameters.Add(New SQLiteParameter("Qtde_saida", qtde))
                    insertSQL4.Parameters.Add(New SQLiteParameter("datasaida_mov", Now.Date))
                    insertSQL4.ExecuteNonQuery()
                    Conn.Close()
                End If

                '''''''''''''''''Rotina para salvar RV estoque em txt''''''''''''''''''''''''
                txt_rv_estq(codigo_orc, dgvproduto.Rows.Item(i).Cells("codigo_prodgrid").Value, qtde, Now.Date)
            Next
        End If

        If codigo_fin = "05" Then

            Dim data As Date
            data = Now.Date
            Dim vrl_use As String = Format(CDec(ret_valor_banco("cliente", "cnpj_cli", cnpj_dest, "vlr_usado")) + CDec(txtvlrtotal.Text), "#,##0.00")
            Dim sql4 As String = "INSERT INTO documento (codigo_rv, datahora_rv, chave_cli, valor_rv, tipo_doc, Status_doc, Vencimento_doc, vlr_usado) VALUES (@codigo_rv, @datahora_rv, @chave_cli, @valor_rv, @tipo_doc, @Status_doc, @Vencimento_doc, @vlr_usado)"

            conectar_sqlite()
            Dim insertSQL5 As SQLiteCommand = New SQLiteCommand(sql4, Conn)
            insertSQL5.Parameters.Add(New SQLiteParameter("codigo_rv", codigo_orc))
            insertSQL5.Parameters.Add(New SQLiteParameter("datahora_rv", Now))
            insertSQL5.Parameters.Add(New SQLiteParameter("chave_cli", cnpj_dest))
            insertSQL5.Parameters.Add(New SQLiteParameter("valor_rv", format_val_mysql_ent(txtvlrtotal.Text)))
            insertSQL5.Parameters.Add(New SQLiteParameter("tipo_doc", "C"))

            insertSQL5.Parameters.Add(New SQLiteParameter("Status_doc", "ABERTO"))
            insertSQL5.Parameters.Add(New SQLiteParameter("Vencimento_doc", data.AddDays(prazodia)))
            insertSQL5.Parameters.Add(New SQLiteParameter("vlr_usado", format_val_mysql_ent(vrl_use.ToString)))

            insertSQL5.ExecuteNonQuery()
            Conn.Close()

            executa_query("update cliente set vlr_usado = '" & format_val_mysql_ent(vrl_use) & "' where cnpj_cli = '" & cnpj_dest & "'")

            '''''''''''''''''Rotina para salvar RV documento em txt'''''''''''''''''''''
            txt_rv_doc(codigo_orc, Now.ToString("dd-MM-yyyy HH:mm:ss"), cnpj_dest, txtvlrtotal.Text, "C", "ABERTO", data.AddDays(prazodia), _
                    Format(CDec(vrl_use) + CDec(txtvlrtotal.Text), "#,##0.00"))

        End If


        Dim t As Boolean = False
        Try
            If thread2.IsAlive Then
                t = True
            End If
        Catch ex As Exception

        End Try

        If t = False Then
            thread2 = New Thread(AddressOf envia_rv)
            thread2.Start()
        End If

    End Sub

    Public Sub txt_rv(ByVal rv As String, ByVal caixa As String, ByVal valor As String, ByVal forma_pag As String, ByVal data As Date, _
                     ByVal obs As String, ByVal cod_op As String, ByVal vlr_canc As String, ByVal maquina As String, ByVal valor_desc As String, _
                     ByVal chave_nfe As String, ByVal chave_nfecont As String, status_rv As String, cnpj_dest As String)

        Dim arquivo As String = Application.StartupPath & "\RX\" & rv & ".rv"
        Dim sep As String = "|"

        If File.Exists(arquivo) Then
            File.Delete(arquivo)
        End If
        Directory.CreateDirectory(Application.StartupPath & "\RX")

        Using writer As StreamWriter = New StreamWriter(arquivo, True)

            writer.WriteLine("10" & sep & rv & sep & caixa & sep & valor & sep & forma_pag & sep & data.ToString("dd-MM-yyyy HH:mm:ss") & sep & _
                             obs & sep & cod_op & sep & vlr_canc & sep & maquina & sep & valor_desc & sep & _
                             chave_nfe & sep & chave_nfecont & sep & status_rv & sep & cnpj_dest)

        End Using
    End Sub

    Public Sub txt_rv_item(ByVal rv As String, ByVal N_item As String, ByVal cod_prod As String, ByVal cod_barras As String, ByVal ncm As String, _
                    ByVal cfop As String, ByVal cest As String, ByVal cst As String, ByVal aliq_icms As String, ByVal vlr_icms As String, _
                    ByVal un As String, ByVal qtde As String, ByVal vlrdesc As String, ByVal vlr_unit As String, ByVal vlr_total As String, ByVal data As Date)




        Dim arquivo As String = Application.StartupPath & "\RX\" & rv & ".rv"
        Dim sep As String = "|"



        Dim fluxoTexto As IO.StreamReader
        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
            While fluxoTexto.Peek() > -1
                myList.Add(fluxoTexto.ReadLine())
            End While
            fluxoTexto.Close()
        End If

        File.Delete(arquivo)

        Using writer As StreamWriter = New StreamWriter(arquivo, True)
            For Each l In myList
                writer.WriteLine(l)
            Next

            writer.WriteLine("11" & sep & rv & sep & N_item & sep & cod_prod & sep & cod_barras & sep & ncm & sep & _
                             cfop & sep & cest & sep & cst & sep & aliq_icms & sep & vlr_icms & sep & _
                             un & sep & qtde & sep & vlrdesc & sep & vlr_unit & sep & vlr_total & sep & data.ToString("dd-MM-yyyy HH:mm:ss"))



        End Using
    End Sub


    Public Sub txt_rv_estq(ByVal rv As String, ByVal cod_prod As String, ByVal qtde As String, ByVal data_mov As Date)




        Dim arquivo As String = Application.StartupPath & "\RX\" & rv & ".rv"
        Dim sep As String = "|"



        Dim fluxoTexto As IO.StreamReader
        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
            While fluxoTexto.Peek() > -1
                myList.Add(fluxoTexto.ReadLine())
            End While
            fluxoTexto.Close()
        End If

        File.Delete(arquivo)

        Using writer As StreamWriter = New StreamWriter(arquivo, True)
            For Each l In myList
                writer.WriteLine(l)
            Next

            writer.WriteLine("12" & sep & rv & sep & cod_prod & sep & qtde & sep & data_mov.ToString("dd-MM-yyyy HH:mm:ss"))



        End Using
    End Sub

    Public Sub txt_rv_doc(ByVal rv As String, ByVal data_rv As Date, ByVal chave_dest As String, _
                   ByVal valor_rv As String, ByVal tipo_doc As String, ByVal status_doc As String, ByVal venc As Date, ByVal vlrusado As String)

        Dim arquivo As String = Application.StartupPath & "\RX\" & rv & ".rv"
        Dim sep As String = "|"



        Dim fluxoTexto As IO.StreamReader
        Dim myList As New ArrayList


        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
            While fluxoTexto.Peek() > -1
                myList.Add(fluxoTexto.ReadLine())
            End While
            fluxoTexto.Close()
        End If

        File.Delete(arquivo)

        Using writer As StreamWriter = New StreamWriter(arquivo, True)
            For Each l In myList
                writer.WriteLine(l)
            Next

            writer.WriteLine("13" & sep & rv & sep & data_rv & sep & chave_dest & sep & valor_rv & sep & tipo_doc & sep & _
                             status_doc & sep & venc.ToString("dd-MM-yyyy") & sep & vlrusado)



        End Using
    End Sub

    Private Sub soma_desconto()
        For i As Integer = 0 To dgvproduto.Rows.Count - 1
            txttotaldesc.Text = CDec(txttotaldesc.Text) + CDec(dgvproduto.Rows.Item(i).Cells(5).Value)
            txttotaldesc.Text = Convert.ToDouble(txttotaldesc.Text).ToString("N2")
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FrmConsultaProduto.par = "pdv"
        FrmConsultaProduto.ShowDialog()
        txtcodbarra.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If dgvproduto.Rows.Count <> "0" Then
            If parametro_venda = True Then
                frmopcaopagcli.ShowDialog()
            Else
                frmopcaopag.ShowDialog()
            End If

        End If
    End Sub

    Private Function pesquisa_grid(ByVal id As String) As String

        Dim r As String = "R"

        For Each row As DataGridViewRow In Me.dgvproduto.Rows

            If Not row.IsNewRow Then
                If row.Cells("cod_barragrid").Value = id Then
                    Return row.Index
                End If
            End If

        Next

        Return r

    End Function
    Private Sub excluir_item(ByVal par As String, Optional ByVal qtde2 As String = "0")

        If dgvproduto.Rows.Count <> "0" Then


            If par = "1" Then
                If MessageBox.Show("Deseja Realmente Excluir o item da Venda: " & dgvproduto.CurrentRow.Cells(2).Value, "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                    txtvlrtotal.Text = Format(CDec(txtvlrtotal.Text) - (CDec(dgvproduto.CurrentRow.Cells("vlrtotal_grid").Value)), "#,##0.00")

                    vlr_canc = CDec(vlr_canc) - (CDec(dgvproduto.CurrentRow.Cells("vlrtotal_grid").Value))

                    dgvproduto.Rows.Remove(dgvproduto.CurrentRow)
                End If
            End If


            If par = "2" Then

                Dim resto As String, vlr As String, vlr3 As String
                Dim qtde As Integer = qtde2


                Dim r As String = pesquisa_grid(txtcodbarra.Text)
                If r = "R" Then
                    MsgBox("Este item não existe na venda !!!", MsgBoxStyle.Exclamation, "Aviso !")
                    Exit Sub
                End If

                resto = CDec(dgvproduto.Rows.Item(r).Cells("qtde_grid").Value) - CDec(qtde)

                If resto.Substring(0, 1) = "-" Then
                    MsgBox("Não existe esta quantidade para ser excluida na Venda ?" & vbCrLf & "Operação Cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
                    Exit Sub
                Else

                    If MessageBox.Show("Deseja Realmente Excluir o item Informado da Venda", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                        dgvproduto.Rows.Item(r).Cells("qtde_grid").Value = Format(CDec(resto), "##0.000")

                        vlr = Format(CDec(dgvproduto.Rows.Item(r).Cells("vlrunit_grid").Value) * CDec(resto), "#,##0.00")

                        vlr3 = Format(CDec(dgvproduto.Rows.Item(r).Cells("vlrunit_grid").Value) * CDec(qtde), "#,##0.00")

                        dgvproduto.Rows.Item(r).Cells("vlrtotal_grid").Value = vlr


                        txtvlrtotal.Text = Format(CDec(txtvlrtotal.Text) - CDec(vlr3), "#,##0.00")


                        vlr_canc = CDec(vlr_canc) - (CDec(dgvproduto.Rows.Item(r).Cells("qtde_grid").Value))

                        If dgvproduto.Rows.Item(r).Cells("qtde_grid").Value.ToString.Substring(0, 1) = "0" Then
                            dgvproduto.Rows.Remove(dgvproduto.Rows.Item(r))
                        End If

                        txtdescricao.Clear()
                        txtcodbarra.Clear()
                        txtqtde.Text = "1,000"
                        txtdescricao.BackColor = Color.MidnightBlue
                    End If

                End If


            End If

        End If
    End Sub

    Private Sub Button1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.GotFocus
        If foco = True Then
            txtqtde.Focus()
        End If
    End Sub


    Public Function gerar_xml(ByVal sCaixa As String, ByVal stipo As String, Optional ByVal sRV As String = "", Optional ByVal sVersaoLayout As String = "4.00", Optional ByVal iTPAmb As Integer = 2, Optional ByVal PathFile As String = "") As String
        Dim flag1 As Boolean = True
        Dim xmlDocument As XmlDocument = New XmlDocument()
        xmlDocument.PreserveWhitespace = False
        ' Dim empresa As String = "1"
        Me.chv_nfce = ""
        Dim dateTime1 As DateTime

        Dim sNF As String

        sNF = CDec(ret_valor_banco_sql("select * from N_nfce", "Numero")) + 1


        If PathFile <> "" Then
            Dim directoryName As String = Path.GetDirectoryName(PathFile)
            If Not Directory.Exists(directoryName) Then Directory.CreateDirectory(directoryName)
        End If


        If sCaixa <> "" Then sCaixa = sCaixa.PadLeft(3, "0"c)
        If sSerie <> "" Then sSerie = sSerie.PadLeft(3, "0"c)
        If sNF <> "" Then sNF = sNF.PadLeft(9, "0"c)
        If sRV <> "" Then sRV = sRV.PadLeft(8, "0"c)

        If Not flag1 Then Return False

        ' Try
        Dim str1 As String = Application.StartupPath & "\XML_NFCe"
        Directory.CreateDirectory(str1)
        Dim str2 As String = ""
        If sCaixa <> "" Then str2 = str2 & " and caixa = " & sCaixa
        If sSerie <> "" Then str2 = str2 & " and serie = " & sSerie
        If sNF <> "" Then str2 = str2 & " and num_nfce = " & sNF
        If sRV <> "" Then str2 = str2 & " and rv = " & sRV

        Dim Valor1 As Decimal = New Decimal()
        Dim Valor2 As Decimal = New Decimal()
        Dim Valor3 As Decimal = New Decimal()
        Dim num1 As Decimal = New Decimal()
        Dim Valor4 As Decimal = New Decimal()
        Dim Valor5 As Decimal = New Decimal()
        Dim Valor6 As Decimal = New Decimal()
        Dim num2 As Decimal = New Decimal()
        Dim Valor7 As Decimal = New Decimal()
        Dim Valor8 As Decimal = New Decimal()
        Dim Valor9 As Decimal = New Decimal()
        Dim Valor10 As Decimal = New Decimal()
        Dim num3 As Decimal = New Decimal()
        Dim Valor11 As Decimal = New Decimal()
        Dim Valor12 As Decimal = New Decimal()
        Dim num4 As Decimal = New Decimal()
        Dim num5 As Decimal = New Decimal()
        Dim num6 As Decimal = New Decimal()
        Dim num7 As Decimal = New Decimal()
        Dim num8 As Decimal = New Decimal()
        Dim str3 As String = ""
        Dim str4 As String = ""
        Dim str5 As String = ""
        Dim str6 As String = ""
        Dim num9 As Integer = 0
        Dim num10 As Integer = 0
        Dim num11 As Decimal = New Decimal()
        Dim num12 As Decimal = New Decimal()
        Dim num13 As Decimal = New Decimal()
        Dim cAliqInt As Decimal = New Decimal()
        Dim cRedBase As Decimal = New Decimal()



        If File.Exists(str1 & "\xmlrec.tmp") Then
            GC.Collect()
            GC.WaitForPendingFinalizers()
            File.Delete(str1 & "\xmlrec.tmp")
        End If

        Dim xmlTextWriter1 As XmlTextWriter = New XmlTextWriter(str1 & "\xmlrec.tmp", CType(Nothing, Encoding))
        xmlTextWriter1.WriteStartDocument()
        xmlTextWriter1.WriteStartElement("NFe", "http://www.portalfiscal.inf.br/nfe")
        xmlTextWriter1.WriteStartElement("infNFe")

        Dim dEmi As Date
        Try
            dEmi = busca_hora_servidor()
        Catch ex As Exception
            dEmi = Now.ToString("yyyy-MM-ddTHH:mm:ss")
        End Try




        Dim _codUF As String = "31"
        Dim _dEmi As String = dEmi.ToString("yyMM")
        Dim _cnpj As String = empresa.sCNPJ
        Dim _mod As String = "65"
        Dim cNF As String
        Dim _tpEmis As String
        If stipo = "1" Then
            _tpEmis = "1"
        Else
            _tpEmis = "9"
        End If


        Dim chars = "0123456789"
        Dim random = New Random()
        Dim AG1 = New String(Enumerable.Repeat(chars, 8).[Select](Function(s) s(random.[Next](s.Length))).ToArray())
        cNF = AG1



        Dim _serie As String = sSerie
        Dim _numNF As String = sNF
        Dim _codigo As String = String.Format("{0:00000000}", Int32.Parse(cNF))
        Me.chv_nfce = _codUF + _dEmi + _cnpj + _mod + _serie + _numNF + _tpEmis + _codigo

        Dim _dv As Integer = modulo11(chv_nfce)

        Me.chv_nfce = chv_nfce & _dv

        xmlTextWriter1.WriteAttributeString("Id", "NFe" & Me.chv_nfce)

        xmlTextWriter1.WriteAttributeString("versao", sVersaoLayout)
        xmlTextWriter1.WriteStartElement("ide")
        xmlTextWriter1.WriteElementString("cUF", _codUF.ToString())
        xmlTextWriter1.WriteElementString("cNF", cNF.ToString())
        xmlTextWriter1.WriteElementString("natOp", "VENDA AO CONSUMIDOR")
        xmlTextWriter1.WriteElementString("mod", "65")
        xmlTextWriter1.WriteElementString("serie", sSerie.ToString.TrimStart("0"))
        xmlTextWriter1.WriteElementString("nNF", sNF.ToString.TrimStart("0"))
        Dim xmlTextWriter2 As XmlTextWriter = xmlTextWriter1
        Dim str12 As String = dEmi.ToString("yyyy-MM-ddTHH:mm:ss") & "-03:00"
        xmlTextWriter2.WriteElementString("dhEmi", str12)
        xmlTextWriter1.WriteElementString("tpNF", "1")
        xmlTextWriter1.WriteElementString("idDest", "1")

        xmlTextWriter1.WriteElementString("cMunFG", empresa.sCodMunIBGE)

        fecha_baseNFe()

        xmlTextWriter1.WriteElementString("tpImp", "4")
        xmlTextWriter1.WriteElementString("tpEmis", String.Format("{0}", CObj(_tpEmis)))


        xmlTextWriter1.WriteElementString("cDV", Me.chv_nfce.Right(1))


        xmlTextWriter1.WriteElementString("tpAmb", String.Format("{0}", CObj(iTPAmb)))
        xmlTextWriter1.WriteElementString("finNFe", "1")
        xmlTextWriter1.WriteElementString("indFinal", "1")
        xmlTextWriter1.WriteElementString("indPres", "1")
        xmlTextWriter1.WriteElementString("procEmi", "0")
        xmlTextWriter1.WriteElementString("verProc", "11.0.0")

        If stipo = 9 Then
            Dim xmlTextWriter345 As XmlTextWriter = xmlTextWriter1
            Dim str100 As String = dEmi.ToString("yyyy-MM-ddTHH:mm:ss") & "-03:00"
            xmlTextWriter345.WriteElementString("dhCont", str100)
            xmlTextWriter1.WriteElementString("xJust", "falta de conexao com os servicos da sefaz")
        End If

        'sNF = rsvenda.Fields("Numero").Value

        xmlTextWriter1.WriteEndElement()
        xmlTextWriter1.WriteStartElement("emit")
        xmlTextWriter1.WriteElementString("CNPJ", empresa.sCNPJ.ToString())
        xmlTextWriter1.WriteElementString("xNome", empresa.sNomeRazao.ToString())
        xmlTextWriter1.WriteElementString("xFant", empresa.sNomefant.ToString())
        xmlTextWriter1.WriteStartElement("enderEmit")

        If empresa.send.ToString() <> "" Then
            xmlTextWriter1.WriteElementString("xLgr", empresa.send.ToString())
        Else
            xmlTextWriter1.WriteElementString("xLgr", "ENDERECO NAO INFORMADO")
        End If

        If empresa.sNumero.ToString() <> "" Then
            xmlTextWriter1.WriteElementString("nro", empresa.sNumero.ToString())
        Else
            xmlTextWriter1.WriteElementString("nro", "NUMERO NAO INFORMADO")
        End If

        If empresa.sBairro.ToString() <> "" Then
            xmlTextWriter1.WriteElementString("xBairro", empresa.sBairro.ToString())
        Else
            xmlTextWriter1.WriteElementString("xBairro", "BAIRRO NAO INFORMADO")
        End If

        xmlTextWriter1.WriteElementString("cMun", empresa.sCodMunIBGE)
        xmlTextWriter1.WriteElementString("xMun", empresa.sNomeMunic)
        xmlTextWriter1.WriteElementString("UF", empresa.sSiglaUF)


        xmlTextWriter1.WriteElementString("CEP", empresa.sCEP.ToString())
        xmlTextWriter1.WriteEndElement()
        xmlTextWriter1.WriteElementString("IE", empresa.sIe.ToString())
        xmlTextWriter1.WriteElementString("CRT", empresa.scod_trib.ToString())
        xmlTextWriter1.WriteEndElement()

        fecha_baseNFe()



        If cnpj_dest.ToString <> "" Then
            Dim clsDadosDest As clsDadosDest = New clsDadosDest()
            conectar_sqlite()
            Dim SQLcommand As SQLiteCommand
            SQLcommand = Conn.CreateCommand
            SQLcommand.CommandText = "select * from cliente where cnpj_cli = '" & cnpj_dest & "'"

            Using reader As SQLiteDataReader = SQLcommand.ExecuteReader

                While reader.Read

                    clsDadosDest.sCPFCNPJ = reader("cnpj_cli").ToString()
                    clsDadosDest.sNomeRazao = RemoverAcentos(reader("nome_cli").ToString().Trim())
                    If clsDadosDest.sNomeRazao = "" Then clsDadosDest.sNomeRazao = "NOME NAO INFORMADO"
                    clsDadosDest.sLogradouro = RemoverAcentos(reader("end_cli").ToString().Trim())
                    If clsDadosDest.sLogradouro = "" Then clsDadosDest.sLogradouro = "ENDERECO NAO INFORMADO"
                    clsDadosDest.sNumero = RemoverAcentos(reader("numero").ToString().Trim())
                    If clsDadosDest.sNumero = "" Then clsDadosDest.sNumero = "S/N"
                    clsDadosDest.sBairro = RemoverAcentos(reader("bairro").ToString().Trim())
                    If clsDadosDest.sBairro = "" Then clsDadosDest.sBairro = "BAIRRO NAO INFORMADO"
                    clsDadosDest.dCodMunIBGE = reader("cod_munic").ToString().Trim()
                    clsDadosDest.sNomeMunic = RemoverAcentos(reader("cidade").ToString().Trim())
                    If clsDadosDest.sNomeMunic = "" Then clsDadosDest.sNomeMunic = "NOME NAO INFORMADO"
                    clsDadosDest.sSiglaUF = reader("uf").ToString().Trim()
                    Dim cep As String = reader("cep_cli").ToString().Trim()
                    clsDadosDest.sCEP = If(Not ValidaCEP(cep), "", cep)
                    clsDadosDest.sCodPaisIBGE = "1058"
                    clsDadosDest.sNomePais = "BRASIL"
                    clsDadosDest.sTelefone = RemoverAcentos(reader("fone_cli").ToString.Replace(" ", ""))
                    If clsDadosDest.sTelefone.Length < 6 Then clsDadosDest.sTelefone = ""
                    clsDadosDest.sEmail = RemoverAcentos(reader("email").ToString().Trim().Replace(" ", ""))

                End While

            End Using


            xmlTextWriter1.WriteStartElement("dest")

            If iTPAmb = 2 Then
                xmlTextWriter1.WriteElementString("CNPJ", "99999999000191")
            Else
                If cnpj_dest.ToString().Length = 11 Then
                    xmlTextWriter1.WriteElementString("CPF", cnpj_dest.ToString())
                Else
                    xmlTextWriter1.WriteElementString("CNPJ", cnpj_dest.ToString())
                End If
            End If

            If iTPAmb = 2 Then
                xmlTextWriter1.WriteElementString("xNome", "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL")
            Else
                xmlTextWriter1.WriteElementString("xNome", RemoverAcentos(clsDadosDest.sNomeRazao.Trim().Left(60)))
            End If

            xmlTextWriter1.WriteStartElement("enderDest")
            xmlTextWriter1.WriteElementString("xLgr", clsDadosDest.sLogradouro.Left(60))
            xmlTextWriter1.WriteElementString("nro", clsDadosDest.sNumero.Left(60))
            If clsDadosDest.sComplemento.Left(60) <> "" Then xmlTextWriter1.WriteElementString("xCpl", clsDadosDest.sComplemento.Left(60))
            xmlTextWriter1.WriteElementString("xBairro", clsDadosDest.sBairro.Left(60))
            xmlTextWriter1.WriteElementString("cMun", clsDadosDest.dCodMunIBGE.ToString().Left(7))
            xmlTextWriter1.WriteElementString("xMun", clsDadosDest.sNomeMunic.Left(60))
            xmlTextWriter1.WriteElementString("UF", clsDadosDest.sSiglaUF.Left(2))
            If clsDadosDest.sCEP <> "" Then xmlTextWriter1.WriteElementString("CEP", clsDadosDest.sCEP.Left(8))
            xmlTextWriter1.WriteElementString("cPais", clsDadosDest.sCodPaisIBGE.Left(4))
            xmlTextWriter1.WriteElementString("xPais", clsDadosDest.sNomePais.Left(60))

            If clsDadosDest.sTelefone <> "" Then
                xmlTextWriter1.WriteElementString("fone", clsDadosDest.sTelefone.Left(14))
            ElseIf clsDadosDest.sCelular <> "" Then
                xmlTextWriter1.WriteElementString("fone", clsDadosDest.sCelular.Left(14))
            Else
                xmlTextWriter1.WriteElementString("fone", "999999")
            End If

            xmlTextWriter1.WriteEndElement()
            xmlTextWriter1.WriteElementString("indIEDest", "9")
            If clsDadosDest.sEmail <> "" Then xmlTextWriter1.WriteElementString("email", clsDadosDest.sEmail.Left(60))
            xmlTextWriter1.WriteEndElement()

        End If


        If dgvproduto.Rows.Count <> 0 Then

            For Each row As DataGridViewRow In dgvproduto.Rows
                xmlTextWriter1.WriteStartElement("det")
                xmlTextWriter1.WriteAttributeString("nItem", CDec(row.Index) + 1)

                xmlTextWriter1.WriteStartElement("prod")
                xmlTextWriter1.WriteElementString("cProd", row.Cells("codigo_prodgrid").Value.ToString())

                If validaGTIN(row.Cells("cod_barragrid").ToString().PadLeft(13, "0"c)) Then
                    xmlTextWriter1.WriteElementString("cEAN", row.Cells("cod_barragrid").ToString().PadLeft(13, "0"c))
                Else
                    xmlTextWriter1.WriteElementString("cEAN", "SEM GTIN")
                End If


                Dim sValue As String = ""

                If iTPAmb = 2 Then
                    xmlTextWriter1.WriteElementString("xProd", "NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL")
                Else
                    xmlTextWriter1.WriteElementString("xProd", row.Cells("desc_prodgrid").Value.ToString().Trim())
                End If

                xmlTextWriter1.WriteElementString("NCM", RemoveTelefone(row.Cells("ncm_grid").Value.ToString().PadLeft(8, "0"c)))
                If RemoveTelefone(row.Cells("cest_grid").Value.ToString.Trim()) <> "" Then
                    xmlTextWriter1.WriteElementString("CEST", RemoveTelefone(row.Cells("cest_grid").Value.ToString.Trim()))
                End If


                Dim cfop As String
                If row.Cells("aliqicms_grid").Value.ToString = "0,00" Or row.Cells("aliqicms_grid").Value.ToString = "0" Then
                    cfop = "5405"
                Else
                    cfop = "5102"
                End If
                xmlTextWriter1.WriteElementString("CFOP", cfop)
                xmlTextWriter1.WriteElementString("uCom", row.Cells("un_grid").Value.ToString())

                Dim Valor13 As Decimal
                Dim Valor14 As Decimal
                Dim Valor15 As Decimal
                Dim num15 As Decimal


                xmlTextWriter1.WriteElementString("qCom", row.Cells("qtde_grid").Value.ToString.Replace(",", "."))
                xmlTextWriter1.WriteElementString("vUnCom", formatar_valor(row.Cells("vlrunit_grid").Value.ToString()))
                xmlTextWriter1.WriteElementString("vProd", formatar_valor(FormatABNT(row.Cells("vlrtotal_grid").Value)))
                Valor15 = Moeda(FormatABNT(row.Cells("vlrtotal_grid").Value), 2)
                Dim num16 As Decimal = Valor15
                Valor1 += num16

                If ValidarEAN13(row.Cells("cod_barragrid").ToString().PadLeft(13, "0"c)) Then
                    xmlTextWriter1.WriteElementString("cEANTrib", row.Cells("cod_barragrid").ToString().PadLeft(13, "0"c))
                Else
                    xmlTextWriter1.WriteElementString("cEANTrib", "SEM GTIN")
                End If
                xmlTextWriter1.WriteElementString("uTrib", row.Cells("un_grid").Value.ToString().ToUpper())


                Dim xmlTextWriter333 As XmlTextWriter = xmlTextWriter1
                num15 = Moeda(Valor13, 4)


                xmlTextWriter333.WriteElementString("qTrib", row.Cells("qtde_grid").Value.ToString.Replace(",", "."))
                Dim xmlTextWriter4 As XmlTextWriter = xmlTextWriter1
                num15 = Moeda(Valor14, 3)
                Dim str17 As String = formatar_valor(row.Cells("vlrunit_grid").Value.ToString())
                xmlTextWriter4.WriteElementString("vUnTrib", str17)

                If Convert.ToDecimal(row.Cells("vlrdesc_grid").Value.ToString()) > Decimal.Zero Then
                    Dim xmlTextWriter5 As XmlTextWriter = xmlTextWriter1
                    num15 = formatar_valor(row.Cells("vlrdesc_grid").Value.ToString())
                    Dim str100 As String = funcaogeracodnfe.gvgpt(num15.ToString())
                    xmlTextWriter5.WriteElementString("vDesc", str100)
                    Valor2 += Convert.ToDecimal(row.Cells("vlrdesc_grid").Value)
                End If

                '   If Convert.ToDecimal(row2("acrescimo")) > Decimal.Zero Then
                'Dim xmlTextWriter5 As XmlTextWriter = xmlTextWriter1
                '   num15 = Moeda(Convert.ToDecimal(row2("acrescimo")), 2)
                '   Dim str10 As String = DBHelper.gvgpt(num15.ToString())
                '  xmlTextWriter5.WriteElementString("vOutro", str10)
                Valor3 += Convert.ToDecimal("0,00")
                '  End If
                Dim acres As String = "0,00"

                xmlTextWriter1.WriteElementString("indTot", "1")
                xmlTextWriter1.WriteEndElement()
                xmlTextWriter1.WriteStartElement("imposto")

                conectar_sqlite()
                Dim SQLcommand6 As SQLiteCommand
                SQLcommand6 = Conn.CreateCommand
                SQLcommand6.CommandText = "select * from ncm where codigo = '" & row.Cells("ncm_grid").Value & "'"

                Dim num177 As Decimal
                Dim num188 As Decimal
                Dim num199 As Decimal
                Using reader As SQLiteDataReader = SQLcommand6.ExecuteReader

                    While reader.Read
                        num177 = CDec(row.Cells("vlrtotal_grid").Value) * CDec(reader("nacional")) / New Decimal(100)
                        num188 = CDec(row.Cells("vlrtotal_grid").Value) * CDec(reader("estadual")) / New Decimal(100)
                        num199 = CDec(row.Cells("vlrtotal_grid").Value) * CDec(reader("municipal")) / New Decimal(100)
                    End While

                End Using



                If num177 < Decimal.Zero Then num177 = New Decimal()
                If num188 < Decimal.Zero Then num188 = New Decimal()
                If num199 < Decimal.Zero Then num199 = New Decimal()
                Dim Valor16 As Decimal = num177 + num188 + num199
                If Valor16 < Decimal.Zero Then Valor16 = New Decimal()
                Dim xmlTextWriter6 As XmlTextWriter = xmlTextWriter1
                num15 = Moeda(Valor16, 2)
                Dim str18 As String = formatar_valor(num15.ToString())
                xmlTextWriter6.WriteElementString("vTotTrib", str18)
                Valor4 += num177
                Valor5 += num188
                Valor6 += num199

                xmlTextWriter1.WriteStartElement("ICMS")


                num9 = row.Cells("cst_grid").Value.ToString.Substring(1, row.Cells("cst_grid").Value.ToString.Length - 1)





                Select Case num9
                    Case 0
                        Dim Valor17 As Decimal = Moeda(Moeda(Valor15, 2) - Convert.ToDecimal(row.Cells("vlrdesc_grid").Value.ToString()) + Convert.ToDecimal(acres), 2)
                        xmlTextWriter1.WriteStartElement("ICMS00")
                        xmlTextWriter1.WriteElementString("orig", row.Cells("cst_grid").Value.ToString.Substring(0, 1).ToString())
                        xmlTextWriter1.WriteElementString("CST", num9.ToString().PadLeft(2, "0"c))
                        xmlTextWriter1.WriteElementString("modBC", "3")
                        Dim xmlTextWriter7 As XmlTextWriter = xmlTextWriter1
                        num15 = Moeda(Valor17, 2)
                        Dim str19 As String = formatar_valor(num15.ToString())
                        xmlTextWriter7.WriteElementString("vBC", str19)
                        Valor7 += Valor17
                        Valor8 += Valor17 * CDec(row.Cells("aliqicms_grid").Value) / New Decimal(100)
                        Dim xmlTextWriter8 As XmlTextWriter = xmlTextWriter1
                        num15 = formatar_valor(row.Cells("aliqicms_grid").Value)
                        Dim str20 As String = formatar_valor(num15.ToString())
                        xmlTextWriter8.WriteElementString("pICMS", row.Cells("aliqicms_grid").Value.ToString.Replace(",", "."))
                        Dim xmlTextWriter9 As XmlTextWriter = xmlTextWriter1
                        num15 = Moeda(Valor17 * CDec(row.Cells("aliqicms_grid").Value) / New Decimal(100), 2)
                        Dim str21 As String = formatar_valor(num15.ToString())
                        xmlTextWriter9.WriteElementString("vICMS", str21)

                        If sVersaoLayout IsNot Nothing Then
                            Dim num20 As Integer = If(sVersaoLayout = "4.00", 1, 0)
                        End If

                        xmlTextWriter1.WriteEndElement()
                    Case 20
                        Dim num21 As Decimal = Moeda(Moeda(Valor15, 2) - Convert.ToDecimal(row.Cells("vlrdesc_grid").Value.ToString()) + Convert.ToDecimal(acres), 2)
                        xmlTextWriter1.WriteStartElement("ICMS20")
                        Dim Valor18 As Decimal = Moeda(Convert.ToDecimal(num21 * cRedBase / New Decimal(100)), 2)
                        xmlTextWriter1.WriteElementString("orig", row.Cells("cst_grid").Value.ToString.Substring(0, 1).ToString())
                        xmlTextWriter1.WriteElementString("CST", num9.ToString().PadLeft(2, "0"c))
                        xmlTextWriter1.WriteElementString("modBC", "3")
                        Dim xmlTextWriter10 As XmlTextWriter = xmlTextWriter1
                        num15 = Moeda(cRedBase, 2)
                        Dim str21 As String = formatar_valor(num15.ToString())
                        xmlTextWriter10.WriteElementString("pRedBC", str21)
                        Dim xmlTextWriter11 As XmlTextWriter = xmlTextWriter1
                        num15 = Moeda(Valor18, 2)
                        Dim str233 As String = formatar_valor(num15.ToString())
                        xmlTextWriter11.WriteElementString("vBC", str233)
                        Valor7 += Valor18

                        If cAliqInt <> Decimal.Zero Then
                            Valor8 += Moeda(Valor18 * cAliqInt / New Decimal(100), 2)
                            Dim xmlTextWriter5 As XmlTextWriter = xmlTextWriter1
                            num15 = Moeda(cAliqInt, 2)
                            Dim str100 As String = formatar_valor(num15.ToString())
                            xmlTextWriter5.WriteElementString("pICMS", row.Cells("aliqicms_grid").Value.ToString.Replace(",", "."))
                            Dim xmlTextWriter12 As XmlTextWriter = xmlTextWriter1
                            num15 = Moeda(Valor18 * cAliqInt / New Decimal(100), 2)
                            Dim str244 As String = formatar_valor(num15.ToString())
                            xmlTextWriter12.WriteElementString("vICMS", str244)
                        Else
                            Valor8 += Valor18 * CDec(row.Cells("aliqicms_grid").Value) / New Decimal(100)
                            Dim xmlTextWriter5 As XmlTextWriter = xmlTextWriter1
                            num15 = row.Cells("aliqicms_grid").Value.ToString
                            Dim str100 As String = formatar_valor(num15.ToString())
                            xmlTextWriter5.WriteElementString("pICMS", row.Cells("aliqicms_grid").Value.ToString.Replace(",", "."))
                            Dim xmlTextWriter12 As XmlTextWriter = xmlTextWriter1
                            num15 = Valor18 * CDec(row.Cells("aliqicms_grid").Value) / New Decimal(100)
                            Dim str244 As String = formatar_valor(num15.ToString())
                            xmlTextWriter12.WriteElementString("vICMS", str244)
                        End If

                        If sVersaoLayout IsNot Nothing Then
                            Dim num22 As Integer = If(sVersaoLayout = "4.00", 1, 0)
                        End If

                        xmlTextWriter1.WriteEndElement()
                    Case 40, 41, 50
                        xmlTextWriter1.WriteStartElement("ICMS40")
                        xmlTextWriter1.WriteElementString("orig", row.Cells("cst_grid").Value.ToString.Substring(0, 1).ToString())
                        xmlTextWriter1.WriteElementString("CST", num9.ToString().PadLeft(2, "0"c))
                        xmlTextWriter1.WriteEndElement()
                    Case 60
                        xmlTextWriter1.WriteStartElement("ICMS60")
                        xmlTextWriter1.WriteElementString("orig", row.Cells("cst_grid").Value.ToString.Substring(0, 1).ToString())
                        xmlTextWriter1.WriteElementString("CST", num9.ToString().PadLeft(2, "0"c))
                        xmlTextWriter1.WriteEndElement()
                    Case 102, 300
                        xmlTextWriter1.WriteStartElement("ICMSSN102")
                        xmlTextWriter1.WriteElementString("orig", row.Cells("cst_grid").Value.ToString.Substring(0, 1).ToString())
                        xmlTextWriter1.WriteElementString("CSOSN", num9.ToString().PadLeft(3, "0"c))
                        xmlTextWriter1.WriteEndElement()
                    Case 400
                        xmlTextWriter1.WriteStartElement("ICMSSN400")
                        xmlTextWriter1.WriteElementString("orig", row.Cells("cst_grid").Value.ToString.Substring(0, 1).ToString())
                        xmlTextWriter1.WriteElementString("CSOSN", num9.ToString().PadLeft(3, "0"c))
                        xmlTextWriter1.WriteEndElement()
                    Case 500
                        xmlTextWriter1.WriteStartElement("ICMSSN500")
                        xmlTextWriter1.WriteElementString("orig", row.Cells("cst_grid").Value.ToString.Substring(0, 1).ToString())
                        xmlTextWriter1.WriteElementString("CSOSN", num9.ToString().PadLeft(3, "0"c))
                        xmlTextWriter1.WriteEndElement()
                End Select

                xmlTextWriter1.WriteEndElement()


                If "" <> "" Then xmlTextWriter1.WriteElementString("infAdProd", "")
                xmlTextWriter1.WriteEndElement()
                xmlTextWriter1.WriteEndElement()

            Next

        End If

        Dim Valor23 As Decimal = Valor1 - Valor2 + Valor3
        xmlTextWriter1.WriteStartElement("total")
        xmlTextWriter1.WriteStartElement("ICMSTot")
        Dim xmlTextWriter27 As XmlTextWriter = xmlTextWriter1
        Dim num23 As Decimal = Moeda(Valor7, 2)
        Dim str39 As String = formatar_valor(num23.ToString())
        xmlTextWriter27.WriteElementString("vBC", str39)
        Dim xmlTextWriter28 As XmlTextWriter = xmlTextWriter1
        num23 = Moeda(Valor8, 2)
        Dim str40 As String = formatar_valor(num23.ToString())
        xmlTextWriter28.WriteElementString("vICMS", str40)
        xmlTextWriter1.WriteElementString("vICMSDeson", "0")

        If sVersaoLayout IsNot Nothing AndAlso sVersaoLayout = "4.00" Then
            Dim xmlTextWriter344 As XmlTextWriter = xmlTextWriter1
            num23 = Moeda(Valor11, 2)
            Dim str100 As String = formatar_valor(num23.ToString())
            xmlTextWriter344.WriteElementString("vFCP", str100)
        End If

        xmlTextWriter1.WriteElementString("vBCST", "0")
        xmlTextWriter1.WriteElementString("vST", "0")

        If sVersaoLayout IsNot Nothing AndAlso sVersaoLayout = "4.00" Then
            xmlTextWriter1.WriteElementString("vFCPST", "0")
            xmlTextWriter1.WriteElementString("vFCPSTRet", "0")
        End If

        Dim xmlTextWriter29 As XmlTextWriter = xmlTextWriter1
        num23 = Moeda(Valor1, 2)
        Dim str41 As String = formatar_valor(num23.ToString())
        xmlTextWriter29.WriteElementString("vProd", str41)
        xmlTextWriter1.WriteElementString("vFrete", "0.00")
        xmlTextWriter1.WriteElementString("vSeg", "0.00")
        Dim xmlTextWriter30 As XmlTextWriter = xmlTextWriter1
        num23 = Moeda(Valor2, 2)
        Dim str42 As String = formatar_valor(num23.ToString())
        xmlTextWriter30.WriteElementString("vDesc", str42)
        xmlTextWriter1.WriteElementString("vII", "0.00")
        xmlTextWriter1.WriteElementString("vIPI", "0.00")
        If sVersaoLayout IsNot Nothing AndAlso sVersaoLayout = "4.00" Then xmlTextWriter1.WriteElementString("vIPIDevol", "0")
        Dim xmlTextWriter31 As XmlTextWriter = xmlTextWriter1
        num23 = Moeda(Valor9, 2)
        Dim str43 As String = formatar_valor(num23.ToString())
        xmlTextWriter31.WriteElementString("vPIS", str43)
        Dim xmlTextWriter32 As XmlTextWriter = xmlTextWriter1
        num23 = Moeda(Valor10, 2)
        Dim str44 As String = formatar_valor(num23.ToString())
        xmlTextWriter32.WriteElementString("vCOFINS", str44)
        Dim xmlTextWriter33 As XmlTextWriter = xmlTextWriter1
        num23 = Moeda(Valor3, 2)
        Dim str45 As String = formatar_valor(num23.ToString())
        xmlTextWriter33.WriteElementString("vOutro", str45)
        Dim xmlTextWriter34 As XmlTextWriter = xmlTextWriter1
        num23 = Moeda(Valor23, 2)
        Dim str46 As String = formatar_valor(num23.ToString())
        xmlTextWriter34.WriteElementString("vNF", str46)
        Dim xmlTextWriter35 As XmlTextWriter = xmlTextWriter1
        num23 = Moeda(Valor4 + Valor5 + Valor6, 2)
        Dim str47 As String = formatar_valor(num23.ToString())
        xmlTextWriter35.WriteElementString("vTotTrib", str47)
        xmlTextWriter1.WriteEndElement()
        xmlTextWriter1.WriteEndElement()
        xmlTextWriter1.WriteStartElement("transp")
        xmlTextWriter1.WriteElementString("modFrete", "9")
        xmlTextWriter1.WriteEndElement()

        xmlTextWriter1.WriteStartElement("pag")
        xmlTextWriter1.WriteStartElement("detPag")
        xmlTextWriter1.WriteElementString("indPag", indPag)
        xmlTextWriter1.WriteElementString("tPag", codigo_fin.PadLeft(2, "0"c))
        Dim xmlTextWriter3 As XmlTextWriter = xmlTextWriter1
        num23 = vPag
        Dim str22 As String = formatar_valor(vPag)
        xmlTextWriter3.WriteElementString("vPag", str22)

        If codigo_fin = "03" Or codigo_fin = "04" Then
            xmlTextWriter1.WriteStartElement("card")
            xmlTextWriter1.WriteElementString("tpIntegra", "2")
            xmlTextWriter1.WriteEndElement()
        End If

        xmlTextWriter1.WriteEndElement()

        If codigo_fin = "01" Then
            If vPag > vTroco Then
                Valor12 = vTroco
                Dim str100 As String = formatar_valor(Valor12.ToString())
                xmlTextWriter1.WriteElementString("vTroco", str100)
            End If
        End If

        xmlTextWriter1.WriteEndElement()




        xmlTextWriter1.WriteStartElement("infAdic")

        If Valor11 <> Decimal.Zero Then
            ' Dim xmlTextWriter3 As XmlTextWriter = xmlTextWriter1
            '   num23 = Moeda(Valor11, 2)
            '  Dim str10 As String = "Fundo Combate a Pobreza(FCP): R$ " & DBHelper.gvgpt(num23.ToString())
            ' xmlTextWriter3.WriteElementString("infAdFisco", str10)
        End If

        Dim dateTime2 As DateTime
        Dim strArray6 As String() = New String(8) {}
        dateTime2 = Convert.ToDateTime(dEmi)
        strArray6(0) = dateTime2.ToString("dd/MM/yy")
        strArray6(1) = " "
        dateTime2 = Convert.ToDateTime(Now)
        strArray6(2) = dateTime2.ToString("HH:mm")
        strArray6(3) = " - RV: "
        strArray6(4) = String.Format("{0:D6}", CObj(sRV))
        strArray6(5) = " - PDV: "
        strArray6(6) = String.Format("{0:D3}", CObj(sCaixa))
        strArray6(7) = " - OPR: "
        strArray6(8) = operador
        Dim str23 As String = String.Concat(strArray6)

        If Valor12 <> Decimal.Zero Then
            Dim str100 As String = str23
            Dim str11 As String = formatar_valor(vPag.ToString())
            Dim str17 As String = str100 & " |Valor Recebimento: R$" & str11
            Dim str18 As String = formatar_valor(vTroco.ToString())
            str23 = str17 & " |Valor do Troco: R$" & str18
        End If

        ' If Valor24 > Decimal.Zero Then
        'Dim str10 As String = str23
        ' num23 = Moeda(Valor24, 2)
        ' Dim str11 As String = DBHelper.gvgpt(num23.ToString())
        ' str23 = str10 & " |Desconto Sub-Total: R$" & str11
        ' End If

        ' If clsDadosDest.sCPFCNPJ <> "" Then
        'Dim str10 As String = str23 & "|** Dados Identif. Cliente: **|NOME  : " & clsDadosDest.sNomeRazao
        '  str23 = (If(clsDadosDest.sCPFCNPJ.Length <> 11, str10 & "|CNPJ  : " & clsDadosDest.sCPFCNPJ, str10 & "|CPF  : " & clsDadosDest.sCPFCNPJ)) & "|ENDER.: " + clsDadosDest.sLogradouro & "|BAIRRO: " + clsDadosDest.sBairro & "|MUN: " + clsDadosDest.sNomeMunic & "|CEP: " + clsDadosDest.sCEP
        '  If clsDadosDest.sObservacao.ToString() <> "" Then str23 = str23 & "|OBSERVACAO NF: " & clsDadosDest.sObservacao
        '  End If

        If Valor4 + Valor5 + Valor6 > Decimal.Zero Then
            num23 = Moeda(Valor4 + Valor5 + Valor6, 2)
            Dim strArray9 As String() = New String(5) {str23, "|Valor Total Aprox. dos Tributos:R$ ", Nothing, Nothing, Nothing, Nothing}
            num23 = Moeda(Valor4 + Valor5 + Valor6, 2)
            strArray9(2) = formatar_valor(num23.ToString())
            strArray9(3) = "("
            num23 = Moeda(New Decimal(100) / Valor1 * (Valor4 + Valor5 + Valor6), 2)
            strArray9(4) = formatar_valor(num23.ToString())
            strArray9(5) = "%)"
            Dim str100 As String = String.Concat(strArray9)
            Dim strArray10 As String() = New String(7) {}
            strArray10(0) = str100
            strArray10(1) = "|Federais: R$ "
            num23 = Moeda(Valor4, 2)
            strArray10(2) = formatar_valor(num23.ToString())
            strArray10(3) = " Estaduais: R$ "
            num23 = Moeda(Valor5, 2)
            strArray10(4) = formatar_valor(num23.ToString())
            strArray10(5) = " Municipais: R$ "
            num23 = Moeda(Valor6, 2)
            strArray10(6) = formatar_valor(num23.ToString())
            strArray10(7) = "|Fonte: IBPT"
            str23 = String.Concat(strArray10)
        End If

        xmlTextWriter1.WriteStartElement("infCpl")
        xmlTextWriter1.WriteCData(str23.Trim().Replace(Environment.NewLine, " "))
        xmlTextWriter1.WriteEndElement()
        xmlTextWriter1.WriteEndElement()
        xmlTextWriter1.WriteEndElement()
        xmlTextWriter1.WriteEndElement()
        xmlTextWriter1.Close()
        Dim str24 As String = str1
        dateTime2 = DateTime.Now
        dateTime2 = Convert.ToDateTime(dateTime2.Date)
        Dim str25 As String = dateTime2.ToString("ddMMyy")




        xmlDocument.Load(str1 & "\xmlrec.tmp")


        Dim str10 As String = xmlDocument.OuterXml

        File.Delete(str1 & "\xmlrec.tmp")


        'assina o xml para enviar para SEFAZ
        '  Dim xmlAssinado As XmlDocument = CertificadoDigital.Assinar(xmlDocument, "infNFe", certificado)

        'Valida o XML assinado
        '  Dim resultado As String = ValidaXML.ValidarXML(xmlAssinado, Application.StartupPath & "\Esquemas_XML_NF-e\nfe_v4.00.xsd")


        '  If resultado.Trim().Length <> 0 Then

        'xmlDocument.Save(Application.StartupPath & "\XML_NFCe\teste.xml")
        '   MsgBox(resultado, MsgBoxStyle.Exclamation, "Aviso !")
        '   End If



        executa_query("update N_nfce set Numero = '" & sNF & "', Serie = '" & sSerie & "'")

        ' xmlDocument.LoadXml(str10)
        '   SalvarXML(xmlDocument.InnerXml, str1 & "\xmlrec.tmp")
        '  Thread.Sleep(2000)

        ' File.Move(str1 & "\xmlrec.tmp", PathFile)

        If chv_nfce.Substring(34, 1) = "9" Then

            Directory.CreateDirectory(Application.StartupPath & "\XML_NFCe\temp")
            xmlDocument.LoadXml(gerar_xmlNFCe_envio(str10, iTPAmb))
            xmlDocument.Save(Application.StartupPath & "\XML_NFCe\temp\" & chv_nfce & "contoff-env.xml")
            chv_nfcecont = chv_nfce

            danfe_NFCe(Application.StartupPath & "\XML_NFCe\temp\" & chv_nfce & "contoff-env.xml")

            File.Delete(Application.StartupPath & "\XML_NFCe\temp\" & chv_nfce & "contoff-env.xml")
        Else

            chave_n = chv_nfce
            chv_nfcecont = ""

        End If


        Return str10
        '   Catch ex As Exception
        'MsgBox("Erro ao recriar arquivo: " & ex.Message & vbCrLf + ex.StackTrace, MsgBoxStyle.Exclamation, "Aviso !bMSG")

        '  Return ""
        '  End Try
    End Function


    Private Function envia_NF_host_list(ByVal chave As String)
        Dim xmldoc As New XmlDocument()
        Dim arquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim ret As Dictionary(Of String, String) = New Dictionary(Of String, String)

        Invoke(Sub() lblaut.Visible = True)

        xmldoc.Load(Application.StartupPath & "\XML_NFCe\" & chave & codigo_orc & "-env.xml")

        arquivo.Add("ambiente", empresa.ambiente_nfe)
        arquivo.Add("tipo", chave.Substring(34, 1))
        arquivo.Add("xml", xmldoc.OuterXml)
        arquivo.Add("nChave", chave)
        arquivo.Add("nRec", "")
        arquivo.Add("caixa", caixa)
        arquivo.Add("RV", codigo_orc)


        Dim XmlRetornoSefaz As New XmlDocument()

        ' Try


        txtdescricao.Text = "Enviado NFCe para SEFAZ...."
        txtdescricao.Refresh()

        '  Dim thread As Thread = New Thread(AddressOf processarWS)
        '  thread.Start(CObj(arquivo))
        ret = processarWS_nfe4_list(arquivo, "Web4_EnviaNFe/enviaNFe")

        If ret("status") = "ok" Then


            If ret("cStat") = "100" Then
                Directory.CreateDirectory(Application.StartupPath & "\NFCe")
                xmldoc.LoadXml(ret("xml"))
                xmldoc.Save(Application.StartupPath & "\NFCe\NFCe-" & ret("chNFe") & ".xml")

                danfe_NFCe(Application.StartupPath & "\NFCe\NFCe-" & ret("chNFe") & ".xml")

                ' MsgBox("NF-e Autorizada !" & vbCrLf & "Status: " & ret("xMotivo") & vbCrLf & "Protocolo Aut.: " & ret("nProt"), MsgBoxStyle.Information, "Aviso ")
                txtdescricao.Text = "NF-e Autorizada !" & vbCrLf & "Chave acesso: " & ret("chNFe") & vbCrLf & "Protocolo Aut.: " & ret("nProt") & vbCrLf & "Status: " & ret("xMotivo")

                Invoke(Sub() lblaut.Text = "NFCe autorizada, nProt: " & ret("nProt"))

                File.Delete(Application.StartupPath & "\XML_NFCe\" & chave & codigo_orc & "-env.xml")

            Else

                txtdescricao.Text = ret("cStat") & " - " & ret("xMotivo")

                Invoke(Sub() lblaut.Text = ret("cStat") & " - " & ret("xMotivo") & vbCrLf & "Tente Consultar Novamente o Retorno.")

                If ret("cStat") = "105" Then

                    '''''''''''''''''''''''''''''''''''''''''''''''''''Rotina abaixo faz nova consulta de lote em processamento'''''''''''''''''
                    Dim arquivo2 As Dictionary(Of String, String) = New Dictionary(Of String, String)
                    Dim ret2 As Dictionary(Of String, String) = New Dictionary(Of String, String)

                    arquivo2.Add("ambiente", empresa.ambiente_nfe)
                    arquivo2.Add("tipo", chave.Substring(34, 1))
                    arquivo2.Add("xml", xmldoc.OuterXml)
                    arquivo2.Add("nChave", chave)
                    arquivo2.Add("nRec", ret("nRec"))

                    ret2 = processarWS_nfe4_list(arquivo2, "Web4_EnviaNFe/enviaNFe")

                    If ret2("status") = "ok" Then
                        If ret2("cStat") = "100" Then
                            Directory.CreateDirectory(Application.StartupPath & "\NFCe")
                            xmldoc.LoadXml(ret2("xml"))
                            xmldoc.Save(Application.StartupPath & "\NFCe\NFCe-" & ret2("chNFe") & ".xml")

                            danfe_NFCe(Application.StartupPath & "\NFCe\NFCe-" & ret2("chNFe") & ".xml")

                            ' MsgBox("NF-e Autorizada !" & vbCrLf & "Status: " & ret2("xMotivo") & vbCrLf & "Protocolo Aut.: " & re2t("nProt"), MsgBoxStyle.Information, "Aviso 2 !")
                            txtdescricao.Text = "NF-e Autorizada !" & vbCrLf & "Chave acesso: " & ret2("chNFe") & vbCrLf & "Protocolo Aut.: " & ret2("nProt") & vbCrLf & "Status: " & ret2("xMotivo")

                            Invoke(Sub() lblaut.Text = "NFCe autorizada, nProt: " & ret2("nProt"))

                            File.Delete(Application.StartupPath & "\XML_NFCe\" & chave & codigo_orc & "-env.xml")
                        Else


                            txtdescricao.Text = ret2("cStat") & " - " & ret2("xMotivo")

                            Invoke(Sub() lblaut.Text = ret("cStat") & " - " & ret2("xMotivo") & vbCrLf & "Consultar 2 Novamente o Retorno.")

                            gerar_cont()

                        End If

                    Else
                        gerar_cont()
                    End If
                    '''''''''''''''''''''''''''''''''''''''''#############################'''''''''''''''''''''''''''''''''''''''''''
                Else

                    gerar_cont()

                End If


            End If



        Else

            Invoke(Sub() lblaut.Text = ret("status"))

            gerar_cont()

        End If

        ' Invoke(Sub() lblaut.Visible = False)

        Return ret("status")

        '   Catch ex As Exception
        'Invoke(Sub() lblaut.Visible = False)
        ' statusnfe = ex.Message
        '   Return ret("status")
        '   End Try

    End Function

    Private Sub gerar_cont()

        Dim XmlDocument As New XmlDocument()
        txtdescricao.Text = "Gerando NFCe Contigencia...."

        Dim PATH As String = Application.StartupPath & "\CONTIGENCIA"
        If Not Directory.Exists(PATH) Then Directory.CreateDirectory(PATH)


        XmlDocument.LoadXml(gerar_xml(caixa, "9", codigo_orc, "4.00", empresa.ambiente_nfe))
        XmlDocument.Save(Application.StartupPath & "\CONTIGENCIA\" & chv_nfce & codigo_orc & "-env.xml")

        If chv_nfce.Substring(34, 1) = 9 Then
            chv_nfcecont = chv_nfce
        End If

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Variaveis das linhas
        Dim pen As New Pen(Brushes.Black, 0.5)
        Dim LinhasPorPagina As Single = 0

        Dim PosicaoDaLinha As Single = 0

        Dim LinhaAtual As Integer = 0


        'Variaveis das margens

        Dim MargemEsquerda As Single = e.MarginBounds.Left
        Dim MargemSuperior As Single = e.MarginBounds.Top + 100
        Dim MargemDireita As Single = e.MarginBounds.Right
        Dim MargemInferior As Single = e.MarginBounds.Bottom
        Dim CanetaDaImpressora As Pen = New Pen(Color.Black, 1)


        'Variaveis das fontes
        Dim FonteNegrito As Font
        Dim FonteRodape As Font
        Dim FonteNormal As Font
        'define efeitos em fontes
        FonteNegrito = New Font("Arial", 12, FontStyle.Bold)
        FonteRodape = New Font("Arial", 8)
        FonteNormal = New Font("Arial", 9)


        'define valores para linha atual e para linha da impressao

        LinhaAtual = 0

        Dim L As Integer = 0


        'Cabecalho produto''

        'Cabecalho produto''

        Dim ie As String = "Inscrição Estadual:" & empresa.sIe
        e.Graphics.DrawString(empresa.sNomeRazao, New Font("Arial", 18, FontStyle.Regular), Brushes.Black, 65, 65, New StringFormat())
        e.Graphics.DrawString("CNPJ:", New Font("Arial", 13, FontStyle.Regular), Brushes.Black, 65, 95, New StringFormat())
        e.Graphics.DrawString(empresa.sCNPJ, FonteNegrito, Brushes.Black, 120, 95, New StringFormat())
        fecha_baseNFe()




        e.Graphics.DrawString(ie, FonteNegrito, Brushes.Black, 722 - ie.Length * 8, 95, New StringFormat())





        LinhasPorPagina = CInt(e.MarginBounds.Height / FonteNormal.GetHeight(e.Graphics) - 9)



        'litas de produtos do grid''''''''''''''''''''''''''''''''''''''''''''''''''''




        PosicaoDaLinha = 88 + (LinhaAtual * FonteNormal.GetHeight(e.Graphics))


        conectar_sqlite()
        Dim SQLcommand As SQLiteCommand
        SQLcommand = Conn.CreateCommand
        SQLcommand.CommandText = "select * from cliente where cnpj_cli = '" & cnpj_dest & "'"

        Using reader As SQLiteDataReader = SQLcommand.ExecuteReader

            While reader.Read

                Dim rg As String = "RG: " & reader("ie")
                ''''''quadrado das bordas''' 
                e.Graphics.DrawRectangle(pen, 50, 50, 700, PosicaoDaLinha + 290)

                e.Graphics.DrawString(reader("nome_cli"), New Font("Arial", 14, FontStyle.Regular), Brushes.Black, 65, PosicaoDaLinha + 80, New StringFormat())
                e.Graphics.DrawString("CPF:", New Font("Arial", 13, FontStyle.Regular), Brushes.Black, 65, PosicaoDaLinha + 110, New StringFormat())
                e.Graphics.DrawString(cnpj_dest, New Font("Arial", 13, FontStyle.Regular), Brushes.Black, 120, PosicaoDaLinha + 110, New StringFormat())
                e.Graphics.DrawString(rg, FonteNegrito, Brushes.Black, 722 - rg.Length * 8, PosicaoDaLinha + 110, New StringFormat())


                e.Graphics.DrawString(reader("end_cli") + ", " + reader("numero") + ", " + reader("bairro") + ", " + reader("cidade").ToString() + ", " + reader("uf").ToString(), New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 65, PosicaoDaLinha + 135, New StringFormat())

                Dim data As Date
                data = Now.Date

                Dim lrestante As String = Format(CDec(reader("credito")) - CDec(reader("vlr_usado")), "#,##0.00")

                e.Graphics.DrawString(data.AddDays(prazodia), New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 190, PosicaoDaLinha + 180, New StringFormat())
                e.Graphics.DrawString("Data Vencimento:", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 65, PosicaoDaLinha + 180, New StringFormat())
                Dim limete As String = "Limite Restante: " & lrestante
                e.Graphics.DrawString(limete, FonteNegrito, Brushes.Black, 722 - limete.Length * 8, PosicaoDaLinha + 180, New StringFormat())

                e.Graphics.DrawString("Valor da compra: " & txtvlrtotal.Text, New Font("Arial", 13, FontStyle.Bold), Brushes.Black, 65, PosicaoDaLinha + 200, New StringFormat())

            End While

        End Using





        PosicaoDaLinha += 80

        e.Graphics.DrawString("PAGAREI A IMPORTANCIA ACIMA", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 65, PosicaoDaLinha + 200, New StringFormat())
        e.Graphics.DrawString("Ass:", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 65, PosicaoDaLinha + 237, New StringFormat())
        e.Graphics.DrawLine(CanetaDaImpressora, 105, PosicaoDaLinha + 250, 500, PosicaoDaLinha + 250)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''#########################"""""""""""""""""""""""""""""""""""""""""""'

        e.Graphics.DrawString(System.DateTime.Now.ToString(), FonteRodape, Brushes.Black, MargemEsquerda, MargemInferior, New StringFormat())

        LinhaAtual += CInt(FonteNormal.GetHeight(e.Graphics))

        LinhaAtual += 1

        e.Graphics.DrawString("P gina : " & paginaAtual, FonteRodape, Brushes.Black, MargemDireita - 50, MargemInferior, New StringFormat())

        'Incrementa o n£mero da pagina

        paginaAtual += 1

        'verifica se continua imprimindo

        If (LinhaAtual > LinhasPorPagina) Then

            e.HasMorePages = True

        Else

            e.HasMorePages = False

        End If
    End Sub
    Private Sub busca_caixaip()

        Dim arquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim ret As String


        arquivo.Add("caixa", caixa.ToString.PadLeft(3, "0"))
        arquivo.Add("ip", GetIPv4Address())
        arquivo.Add("serie", sSerie)
        '  Dim thread As Thread = New Thread(AddressOf processarWS)
        '  thread.Start(CObj(arquivo))
        ret = processarWS_host(arquivo, "IP_caixa/Consulta")

        If ret = "ok" Then
            ' MsgBox(ret)
        End If

        Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso !")
        End Try


    End Sub

    Private Function busca_hora_servidor()

        Dim arquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim ret As String

        Try

            arquivo.Add("caixa", caixa)

            '  Dim thread As Thread = New Thread(AddressOf processarWS)
            '  thread.Start(CObj(arquivo))
            ret = processarWS_host(arquivo, "datahora_servidor/Consulta")


            Return ret

        Catch ex As Exception
            Return ret
        End Try


    End Function

    Private Sub Timercad_caixa_Tick(sender As Object, e As EventArgs) Handles Timercad_caixa.Tick
        lbltimer += 1
        If lbltimer = "3" Then
            busca_caixaip()
            Timercad_caixa.Dispose()
        End If
    End Sub

    Public Sub carregar_dados_empresa(ByVal vcod As String)
        Dim data As String, senha_cert As String
        Dim rs As New ADODB.Recordset

        conectar_baseNFe()

        rs.Open("select * from empresa where cod_empresa = " & vcod & "", conexao.cn_nfe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        If rs.EOF = False Then
            If rs.Fields("Senha_cert").Value <> "" Then
                data = Convert.ToDateTime(rs.Fields("venc_cert").Value).ToString("yyyy")

                cnpj_emp = rs.Fields("cnpj_emp").Value

                vnome_emp = rs.Fields("razao_social").Value

                regimetrib = rs.Fields("reg_tributario").Value

                nfecer = rs.Fields("serial_cert").Value.ToString

                csc = rs.Fields("csc").Value.ToString

                idtoken = rs.Fields("idtoken").Value.ToString

                codmunic = rs.Fields("cod_municipio").Value.ToString()

                Dim rs2 As New ADODB.Recordset
                rs2.Open("select * from municipio where codigo_municipio = '" & rs.Fields("cod_municipio").Value.ToString() & "'", conexao.cn_nfe, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

                cidade = rs2.Fields("NomeMunic").Value.ToString()
                uf = rs2.Fields("UF").Value.ToString()

                If File.Exists(Application.StartupPath & "\cert\" & cnpj_emp & Convert.ToDateTime(rs.Fields("venc_cert").Value).ToString("yyyy") & ".pfx") = False Then
                    Directory.CreateDirectory(Application.StartupPath & "\cert\")
                    Dim bytes = TryCast(rs.Fields("cert").Value, Byte())
                    File.WriteAllBytes(Application.StartupPath & "\cert\" & cnpj_emp & Convert.ToDateTime(rs.Fields("venc_cert").Value).ToString("yyyy") & ".pfx", bytes)
                End If

                rs2.Close()

                senha_cert = Crypto.Descrip_licenca(rs.Fields("Senha_cert").Value)
                certificado = carregar_cert(Application.StartupPath & "\cert\" & cnpj_emp & data & ".pfx", senha_cert)


            End If
        End If



    End Sub

    Private Sub controle_op(ByVal fin As String, ByVal valor As String)

        Dim total As String = format_val_mysql_ret(ret_valor_banco("venda_pdv", "Status", "Aberto", "vlr_total"))



        If fin = "01" Then
            Dim total2 As String = format_val_mysql_ret(ret_valor_banco("venda_pdv", "Status", "Aberto", "vlr_dinheiro"))

            Dim sql2 As String = "update venda_pdv set vlr_dinheiro = '" & format_val_mysql_ent(CDec(valor) + CDec(total2)) & "', vlr_total = '" & format_val_mysql_ent(CDec(valor) + CDec(total)) & "' where Status = 'Aberto'"
            conectar_sqlite()
            Dim insertSQL2 As SQLiteCommand = New SQLiteCommand(sql2, Conn)
            insertSQL2.ExecuteNonQuery()
            Conn.Close()

        End If
        If fin = "05" Then
            Dim total2 As String = format_val_mysql_ret(ret_valor_banco("venda_pdv", "Status", "Aberto", "vlr_prazo"))

            Dim qtde As String = format_val_mysql_ret(ret_valor_banco("venda_pdv", "Status", "Aberto", "qtde_aprazo"))
            qtde = CDec(qtde) + 1
            Dim sql2 As String = "update venda_pdv set vlr_prazo = '" & format_val_mysql_ent(CDec(valor) + CDec(total2)) & "', vlr_total = '" & format_val_mysql_ent(CDec(valor) + CDec(total)) & "', qtde_aprazo = '" & qtde & "' where Status = 'Aberto'"
            conectar_sqlite()
            Dim insertSQL2 As SQLiteCommand = New SQLiteCommand(sql2, Conn)

            Try
                insertSQL2.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(sql2)
            End Try

            Conn.Close()

        End If
        If fin = "11" Or fin = "12" Then
            Dim total2 As String = format_val_mysql_ret(ret_valor_banco("venda_pdv", "Status", "Aberto", "vlr_vale"))
            Dim qtde As String = format_val_mysql_ret(ret_valor_banco("venda_pdv", "Status", "Aberto", "qtde_vale"))
            qtde = CDec(qtde) + 1
            Dim sql2 As String = "update venda_pdv set vlr_vale = '" & format_val_mysql_ent(CDec(valor) + CDec(total2)) & "', vlr_total = '" & format_val_mysql_ent(CDec(valor) + CDec(total)) & "', qtde_vale = '" & qtde & "' where Status = 'Aberto'"
            conectar_sqlite()
            Dim insertSQL2 As SQLiteCommand = New SQLiteCommand(sql2, Conn)
            insertSQL2.ExecuteNonQuery()
            Conn.Close()

        End If
        If fin = "02" Then
            Dim total2 As String = format_val_mysql_ret(ret_valor_banco("venda_pdv", "Status", "Aberto", "vlr_cheque"))
            Dim qtde As String = format_val_mysql_ret(ret_valor_banco("venda_pdv", "Status", "Aberto", "qtde_cheque"))
            qtde = CDec(qtde) + 1
            Dim sql2 As String = "update venda_pdv set vlr_cheque = '" & format_val_mysql_ent(CDec(valor) + CDec(total2)) & "', vlr_total = '" & format_val_mysql_ent(CDec(valor) + CDec(total)) & "', qtde_cheque = '" & qtde & "' where Status = 'Aberto'"
            conectar_sqlite()
            Dim insertSQL2 As SQLiteCommand = New SQLiteCommand(sql2, Conn)
            insertSQL2.ExecuteNonQuery()
            Conn.Close()

        End If
        If fin = "03" Or fin = "04" Then
            Dim total2 As String = format_val_mysql_ret(ret_valor_banco("venda_pdv", "Status", "Aberto", "vlr_cartao"))
            Dim qtde As String = format_val_mysql_ret(ret_valor_banco("venda_pdv", "Status", "Aberto", "qtde_cartao"))
            qtde = CDec(qtde) + 1
            Dim sql2 As String = "update venda_pdv set vlr_cartao = '" & format_val_mysql_ent(CDec(valor) + CDec(total2)) & "', vlr_total = '" & format_val_mysql_ent(CDec(valor) + CDec(total)) & "', qtde_cartao = '" & qtde & "' where Status = 'Aberto'"
            conectar_sqlite()
            Dim insertSQL2 As SQLiteCommand = New SQLiteCommand(sql2, Conn)
            insertSQL2.ExecuteNonQuery()
            Conn.Close()

        End If
        If fin = "99" Then
            Dim total2 As String = format_val_mysql_ret(ret_valor_banco("venda_pdv", "Status", "Aberto", "vlr_outros"))
            Dim qtde As String = format_val_mysql_ret(ret_valor_banco("venda_pdv", "Status", "Aberto", "qtde_outros"))
            qtde = CDec(qtde) + 1
            Dim sql2 As String = "update venda_pdv set vlr_outros = '" & format_val_mysql_ent(CDec(valor) + CDec(total2)) & "', vlr_total = '" & format_val_mysql_ent(CDec(valor) + CDec(total)) & "', qtde_outros = '" & qtde & "' where Status = 'Aberto'"
            conectar_sqlite()
            Dim insertSQL2 As SQLiteCommand = New SQLiteCommand(sql2, Conn)
            insertSQL2.ExecuteNonQuery()
            Conn.Close()

        End If



    End Sub


    Private Sub ExcluirItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExcluirItemToolStripMenuItem.Click

        If ret_valor_banco("operador", "codigo_op", cod_op, "canc_item") = "0" Then
            MsgBox("Você não tem permissão para esta operação ?", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If

        excluir_item("1")
    End Sub

    Public Sub danfe_NFCe(ByVal dados As String)

        If emp_red = True Then
            ImprimirDANFeNFCeSpool(dados, nome_prit, 1)
        Else
            danfe_normal(dados)
        End If

    End Sub
    Public Sub danfe_normal(ByVal dados As String)
        Dim xmllist As System.Xml.XmlNodeList
        Dim InnerNode2 As XmlNode
        Dim IDanfe As New Nfe_ImprimirDanfeRetratoNFCe

        Dim Coutros As New Nfe_ImprimirDanfeRetratoNFCe.Doutros
        Coutros.nameprint = nome_prit
        ' Coutros.nameprint = ""
        ' Coutros.emailfor = txtemailfor.Text
        '  Coutros.numero_epec = txtdepc.Text
        ' Coutros.protocolocanc = txtprotocolocanc.Text
        '  Path.GetExtension(TesteCaminho)

        Coutros.caminho_logo = Application.StartupPath & "\logonfe.png"

        xmldoc.Load(dados)

        ''''''''''''QRCode''''''''''''''''''''
        Dim picImagem As New PictureBox
        Dim qrencod As New QRCodeEncoder()

        xmllist = xmldoc.GetElementsByTagName("infNFeSupl")
        For Each InnerNode In xmllist
            Dim qrcode As Bitmap = qrencod.Encode(InnerNode("qrCode").InnerText)
            picImagem.Image = TryCast(qrcode, Image)
        Next

        picImagem.Image.Save(Application.StartupPath & "\logonfecod.bmp")

        Coutros.caminho_QRCode = Application.StartupPath & "\logonfecod.bmp"




        xmllist = xmldoc.GetElementsByTagName("emit")
        Dim CEmitente As Nfe_ImprimirDanfeRetratoNFCe.DEmitente_Retrato = Nothing
        For Each InnerNode2 In xmllist

            CEmitente.NOME = InnerNode2("xNome").InnerText
            CEmitente.MUNICIPIO = InnerNode2("enderEmit")("xMun").InnerText & "/" & InnerNode2("enderEmit")("UF").InnerText
            CEmitente.UF = InnerNode2("enderEmit")("UF").InnerText

            Dim comp As String
            If Not InnerNode2("enderEmit")("xCpl") Is Nothing Then
                comp = InnerNode2("enderEmit")("xCpl").InnerText
            End If
            CEmitente.ENDERECO_COMPLETO = InnerNode2("enderEmit")("xLgr").InnerText & ", " & InnerNode2("enderEmit")("nro").InnerText & " " & comp

            CEmitente.BAIRRO = InnerNode2("enderEmit")("xBairro").InnerText

            Dim cnpjd As String
            If Not InnerNode2("CNPJ") Is Nothing Then
                cnpjd = InnerNode2("CNPJ").InnerText
            End If
            If Not InnerNode2("CPF") Is Nothing Then
                cnpjd = InnerNode2("CPF").InnerText
            End If

            CEmitente.CNPJ = FormatarCpfCnpj(cnpjd)

            CEmitente.CEP = FormatarCpfCnpj(InnerNode2("enderEmit")("CEP").InnerText)

            If Not InnerNode2("enderEmit")("fone") Is Nothing Then
                CEmitente.TELEFONE = FormatarCpfCnpj(InnerNode2("enderEmit")("fone").InnerText)
            End If

            CEmitente.IE = InnerNode2("IE").InnerText
            If Not InnerNode2("IEST") Is Nothing Then
                CEmitente.IESUBS = InnerNode2("IEST").InnerText
            End If

        Next


        xmllist = xmldoc.GetElementsByTagName("dest")
        Dim CDestinatario As Nfe_ImprimirDanfeRetratoNFCe.DDestinatario_Retrato = Nothing
        For Each InnerNode2 In xmllist

            Dim cnpjd As String
            If Not InnerNode2("CNPJ") Is Nothing Then
                cnpjd = InnerNode2("CNPJ").InnerText
            End If
            If Not InnerNode2("CPF") Is Nothing Then
                cnpjd = InnerNode2("CPF").InnerText
            End If

            CDestinatario.NOME = InnerNode2("xNome").InnerText

            CDestinatario.CNPJ = FormatarCpfCnpj(cnpjd)

            If Not InnerNode2("enderDest")("CEP") Is Nothing Then
                CDestinatario.CEP = FormatarCpfCnpj(InnerNode2("enderDest")("CEP").InnerText)
            End If
            If Not InnerNode2("enderDest")("fone") Is Nothing Then
                CDestinatario.TELEFONE = FormatarCpfCnpj(InnerNode2("enderDest")("fone").InnerText)
            End If

            CDestinatario.ENDERECO = InnerNode2("enderDest")("xLgr").InnerText & " " & InnerNode2("enderDest")("nro").InnerText
            CDestinatario.BAIRRO = InnerNode2("enderDest")("xBairro").InnerText

            If Not InnerNode2("IE") Is Nothing Then
                CDestinatario.IE = InnerNode2("IE").InnerText
            End If


            If Not InnerNode2("indIEDest") Is Nothing Then
                CDestinatario.IE_IND = InnerNode2("indIEDest").InnerText
            End If
            CDestinatario.UF = InnerNode2("enderDest")("UF").InnerText
            CDestinatario.MUNICIPIO = InnerNode2("enderDest")("xMun").InnerText

        Next

        Dim CDataHora As Nfe_ImprimirDanfeRetratoNFCe.DDataeHora_Retrato = Nothing
        Dim CDadosNF As New Nfe_ImprimirDanfeRetratoNFCe.DDadosNfe_Retrato
        CDadosNF.IMP_DV = "SIM"

        xmllist = xmldoc.GetElementsByTagName("infNFe")
        ' Dim InnerNode2 As XmlNode
        For Each InnerNode2 In xmllist

            CDadosNF.CHAVEACESSO_NFE = InnerNode2.Attributes.ItemOf("Id").InnerText.Substring(3, 44)

        Next

        xmllist = xmldoc.GetElementsByTagName("infNFeSupl")
        For Each InnerNode In xmllist
            CDadosNF.QRcodevlr = InnerNode("qrCode").InnerText
        Next

        xmllist = xmldoc.GetElementsByTagName("ide")
        For Each InnerNode2 In xmllist
            CDadosNF.NUMERO_NFE = InnerNode2("cNF").InnerText
            CDadosNF.SERIE_NFE = InnerNode2("serie").InnerText
            CDadosNF.NATUREZA_NFE = InnerNode2("natOp").InnerText



            If Not InnerNode2("dEmi") Is Nothing Then
                CDataHora.DATA_EMISSAO = InnerNode2("dEmi").InnerText
            End If
            If Not InnerNode2("dhEmi") Is Nothing Then
                CDataHora.DATA_EMISSAO = InnerNode2("dhEmi").InnerText
            End If
            If Not InnerNode2("dSaiEnt") Is Nothing Then
                CDataHora.DATA_ENTRADA_SAIDA = InnerNode2("dSaiEnt").InnerText
            End If

            If Not InnerNode2("xJust") Is Nothing Then
                CDadosNF.xJust = InnerNode2("xJust").InnerText
            End If
            If Not InnerNode2("dhCont") Is Nothing Then
                CDadosNF.DHCONT = InnerNode2("dhCont").InnerText
            End If

            If InnerNode2("tpNF").InnerText = 1 Then
                CDadosNF.TIPONOTA_NFE = Nfe_ImprimirDanfeRetratoNFCe.TipoNota_Retrato.SAIDA
            Else
                CDadosNF.TIPONOTA_NFE = Nfe_ImprimirDanfeRetratoNFCe.TipoNota_Retrato.ENTRADA
            End If
        Next

        xmllist = xmldoc.GetElementsByTagName("infProt")
        For Each InnerNode2 In xmllist
            CDadosNF.PROTOCOLO_NFE = InnerNode2("nProt").InnerText
            CDadosNF.DHRECBTO_NFE = Convert.ToDateTime(InnerNode2("dhRecbto").InnerText).ToString("dd/MM/yyyy HH:mm:ss")
        Next


        Dim CTransportadora As Nfe_ImprimirDanfeRetratoNFCe.DTransportadora_Retrato = Nothing
        xmllist = xmldoc.GetElementsByTagName("transporta")
        For Each InnerNode2 In xmllist

            Dim cnpjp As String
            If Not InnerNode2("CNPJ") Is Nothing Then
                cnpjp = InnerNode2("CNPJ").InnerText
            End If
            If Not InnerNode2("CPF") Is Nothing Then
                cnpjp = InnerNode2("CPF").InnerText
            End If
            CTransportadora.CNPJ = cnpjp
            If Not InnerNode2("xNome") Is Nothing Then
                CTransportadora.NOME = InnerNode2("xNome").InnerText
            End If
            If Not InnerNode2("xEnder") Is Nothing Then
                CTransportadora.ENDERECO = InnerNode2("xEnder").InnerText
            End If
            If Not InnerNode2("xMun") Is Nothing Then
                CTransportadora.MUNICIPIO = InnerNode2("xMun").InnerText
            End If
            If Not InnerNode2("UF") Is Nothing Then
                CTransportadora.UF = InnerNode2("UF").InnerText
            End If
            If Not InnerNode2("IE") Is Nothing Then
                CTransportadora.MUNICIPIO = InnerNode2("IE").InnerText
            End If
        Next

        xmllist = xmldoc.GetElementsByTagName("VeicTransp")
        For Each InnerNode2 In xmllist
            If Not InnerNode2("RNTC") Is Nothing Then
                CTransportadora.CODIGO_ANTT = InnerNode2("RNTC").InnerText
            End If
            If Not InnerNode2("placa") Is Nothing Then
                CTransportadora.PLACA_VEICULO = InnerNode2("placa").InnerText
            End If
            If Not InnerNode2("UF") Is Nothing Then
                CTransportadora.UF_PLACA = InnerNode2("UF").InnerText
            End If
        Next

        xmllist = xmldoc.GetElementsByTagName("Vol")
        For Each InnerNode2 In xmllist
            If Not InnerNode2("esp") Is Nothing Then
                CTransportadora.ESPECIE = InnerNode2("esp").InnerText
            End If
            If Not InnerNode2("marca") Is Nothing Then
                CTransportadora.MARCA = InnerNode2("marca").InnerText
            End If
            If Not InnerNode2("nVol") Is Nothing Then
                CTransportadora.NUMERO = InnerNode2("nVol").InnerText
            End If

            If Not InnerNode2("pesoB") Is Nothing Then
                CTransportadora.PESOBRUTO = InnerNode2("pesoB").InnerText
            End If
            If Not InnerNode2("pesoB") Is Nothing Then
                CTransportadora.PESOLIQUIDO = InnerNode2("pesoB").InnerText
            End If
            If Not InnerNode2("qVol") Is Nothing Then
                CTransportadora.QUANTIDADE = InnerNode2("qVol").InnerText
            End If
        Next

        xmllist = xmldoc.GetElementsByTagName("transp")
        For Each InnerNode2 In xmllist
            If InnerNode2("modFrete").InnerText = 0 Then
                CTransportadora.modfrete = "(0) Emitente"
            ElseIf InnerNode2("modFrete").InnerText = 1 Then
                CTransportadora.modfrete = "(1) Dest/Rem"
            ElseIf InnerNode2("modFrete").InnerText = 2 Then
                CTransportadora.modfrete = "(2) Terseiros"
            ElseIf InnerNode2("modFrete").InnerText = 9 Then
                CTransportadora.modfrete = "(9) Sem frete"
            End If
        Next


        xmllist = xmldoc.GetElementsByTagName("ICMSTot")
        Dim CValores As Nfe_ImprimirDanfeRetratoNFCe.DValores_Retrato = Nothing
        For Each InnerNode2 In xmllist

            CValores.BASE_CALCULO_ICMS = formata_valor_campo(InnerNode2("vBC").InnerText)
            CValores.BASE_CALCULO_ICMS_SUBS = formata_valor_campo(InnerNode2("vBCST").InnerText)
            CValores.DESCONTO = formata_valor_campo(InnerNode2("vDesc").InnerText)
            CValores.OUTRAS_DESPESAS = formata_valor_campo(InnerNode2("vOutro").InnerText)
            CValores.VALOR_FRETE = formata_valor_campo(InnerNode2("vFrete").InnerText)
            CValores.VALOR_ICMS = formata_valor_campo(InnerNode2("vICMS").InnerText)
            CValores.VALOR_ICMS_SUBS = formata_valor_campo(InnerNode2("vST").InnerText)
            CValores.VALOR_IPI = formata_valor_campo(InnerNode2("vIPI").InnerText)
            CValores.VALOR_PIS = formata_valor_campo(InnerNode2("vPIS").InnerText)
            CValores.VALOR_COFINS = formata_valor_campo(InnerNode2("vCOFINS").InnerText)
            CValores.VALOR_SEGURO = formata_valor_campo(InnerNode2("vSeg").InnerText)
            CValores.VALOR_TOTAL_NOTA = formata_valor_campo(InnerNode2("vNF").InnerText)
            CValores.VALOR_TOTAL_PRODUTOS = formata_valor_campo(InnerNode2("vProd").InnerText)
            If Not InnerNode2("vTotTrib") Is Nothing Then
                CValores.VALOR_TOTALTRIB = formata_valor_campo(InnerNode2("vTotTrib").InnerText)
            End If

        Next



        Dim CISSQN As Nfe_ImprimirDanfeRetratoNFCe.DISSQN_Retrato = Nothing
        CISSQN.BASE_CALCULO_ISSQN = ""
        CISSQN.IM = ""
        CISSQN.VALOR_TOTAL_SERVICOS = ""
        CISSQN.VALOR_ISSQN = ""




        'PEGA CLASSE PARA PREENCHER OS PRODUTOS
        xmllist = xmldoc.GetElementsByTagName("det")
        Dim PROD As ProdutoDanfe_RetratoNFCe

        For Each InnerNode2 In xmllist
            PROD = New ProdutoDanfe_RetratoNFCe

            Try

                If InnerNode2("prod")("cProd").InnerText.Length > 13 Then
                    PROD.DCodigoProd = InnerNode2("prod")("cProd").InnerText.ToString.Substring(InnerNode2("prod")("cProd").InnerText.Length - 13, 13)
                Else
                    PROD.DCodigoProd = InnerNode2("prod")("cProd").InnerText
                End If

            Catch ex As Exception
                PROD.DCodigoProd = InnerNode2("prod")("cProd").InnerText
            End Try


            PROD.DCodigoBARRA = InnerNode2("prod")("cEANTrib").InnerText
            PROD.DDescricao = InnerNode2("prod")("xProd").InnerText
            If PROD.DNCM = InnerNode2("prod")("NCM").InnerText.Length < "8" Then
                PROD.DNCM = InnerNode2("prod")("NCM").InnerText.ToString.Substring(0, 8)
            Else
                PROD.DNCM = InnerNode2("prod")("NCM").InnerText
            End If


            PROD.DCFOP = InnerNode2("prod")("CFOP").InnerText

            PROD.DUNID = InnerNode2("prod")("uCom").InnerText
            PROD.DQT = Decimal.Parse(InnerNode2("prod")("qCom").InnerText.ToString.Replace(".", ",")).ToString("0.000")
            PROD.DVALORUNI = formata_valor_campo_4c(InnerNode2("prod")("vUnCom").InnerText)
            PROD.DVALORTOTAL = formata_valor_campo(InnerNode2("prod")("vProd").InnerText)



            If Not InnerNode2("imposto")("vTotTrib") Is Nothing Then
                PROD.DVALOR_TRIB_ITEM = formata_valor_campo(InnerNode2("imposto")("vTotTrib").InnerText)
            End If
            PROD.DCST = InnerNode2("imposto")("ICMS").ChildNodes(0)("orig").InnerText & InnerNode2("imposto")("ICMS").ChildNodes(0)("CST").InnerText

            Try

                If Not InnerNode2("imposto")("ICMS")("ICMS20") Is Nothing Then

                    PROD.DBCALC_ICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS20")("vBC").InnerText)
                    PROD.DVALORICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS20")("vICMS").InnerText)
                    PROD.DALIQUOTAICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS20")("pICMS").InnerText)

                End If

                If Not InnerNode2("imposto")("ICMS")("ICMS00") Is Nothing Then

                    PROD.DBCALC_ICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS00")("vBC").InnerText)
                    PROD.DVALORICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS00")("vICMS").InnerText)
                    PROD.DALIQUOTAICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS00")("pICMS").InnerText)

                End If

                If Not InnerNode2("imposto")("ICMS")("ICMS70") Is Nothing Then

                    PROD.DBCALC_ICMS_ST = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS70")("vBCST").InnerText)
                    PROD.DVALORICMS_ST = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS70")("vICMSST").InnerText)
                    PROD.DALIQUOTAICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS70")("pICMS").InnerText)
                End If

                If Not InnerNode2("imposto")("ICMS")("ICMS10") Is Nothing Then

                    PROD.DBCALC_ICMS_ST = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS10")("vBCST").InnerText)
                    PROD.DVALORICMS_ST = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS10")("vICMSST").InnerText)
                    PROD.DALIQUOTAICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMS10")("pICMS").InnerText)

                End If

                If Not InnerNode2("imposto")("ICMS")("ICMSSN201") Is Nothing Then

                    PROD.DBCALC_ICMS_ST = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMSSN201")("vBCST").InnerText)
                    PROD.DVALORICMS_ST = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMSSN201")("vICMSST").InnerText)
                    PROD.DALIQUOTAICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMSSN201")("pICMSST").InnerText)

                End If

                If Not InnerNode2("imposto")("ICMS")("ICMSSN202") Is Nothing Then

                    PROD.DBCALC_ICMS_ST = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMSSN202")("vBCST").InnerText)
                    PROD.DVALORICMS_ST = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMSSN202")("vICMSST").InnerText)
                    PROD.DALIQUOTAICMS = formata_valor_campo(InnerNode2("imposto")("ICMS")("ICMSSN202")("pICMSST").InnerText)

                End If



                If Not InnerNode2("imposto")("IPI") Is Nothing Then
                    If Not InnerNode2("imposto")("IPI")("IPITrib") Is Nothing Then
                        PROD.DVALORIPI = formata_valor_campo(InnerNode2("imposto")("IPI")("IPITrib")("vIPI").InnerText)
                        PROD.DALIQUOTAIPI = formata_valor_campo(InnerNode2("imposto")("IPI")("IPITrib")("pIPI").InnerText)
                    End If

                Else
                    PROD.DVALORIPI = ""
                    PROD.DALIQUOTAIPI = ""
                End If

            Catch ex As Exception

            End Try

            If Not InnerNode2("prod")("Med") Is Nothing Then
                PROD.DLOTE = InnerNode2("Prod")("Med")("nLote").InnerText
                PROD.LinhaProd.Add("Lote: " & InnerNode2("prod")("Med")("nLote").InnerText & " Qtd: " & Decimal.Parse(InnerNode2("prod")("Med")("qLote").InnerText).ToString("#.##"))
            End If
            If Not InnerNode2("prod")("rastro") Is Nothing Then
                PROD.DLOTE = InnerNode2("Prod")("rastro")("nLote").InnerText
                PROD.LinhaProd.Add("Lote: " & InnerNode2("prod")("rastro")("nLote").InnerText & " Qtd: " & Decimal.Parse(InnerNode2("prod")("rastro")("qLote").InnerText).ToString("#.##"))
            End If

            'ADICIONA PRODUTOS NA DANFE
            IDanfe.AddProdutosDanfe.Add(PROD)
        Next




        Try

            xmllist = xmldoc.GetElementsByTagName("dup")
            Dim fat As FaturaDanfe_RetratoNFce
            For Each InnerNode2 In xmllist
                fat = New FaturaDanfe_RetratoNFce
                fat.DNumero = InnerNode2("nDup").InnerText
                fat.Dvalor = InnerNode2("vDup").InnerText
                fat.Dvenc = InnerNode2("dVenc").InnerText

                IDanfe.AddfaturaDanfe.Add(fat)
            Next


        Catch ex As Exception

        End Try




        Dim CFaturamento_Retrato As Nfe_ImprimirDanfeRetratoNFCe.DFaturamento_Retrato = Nothing

        Dim CINFO As Nfe_ImprimirDanfeRetratoNFCe.DINFOCOMPLEMENTAR_Retrato = Nothing


        Dim vp As String, vb As String
        xmllist = xmldoc.GetElementsByTagName("infAdic")
        For Each InnerNode2 In xmllist

            If Not InnerNode2("infCpl") Is Nothing Then
                vp = InnerNode2("infCpl").InnerText
            End If
            If Not InnerNode2("infAdFisco") Is Nothing Then
                vb = InnerNode2("infAdFisco").InnerText
            End If
            CINFO.DADOSADIC = vp + vbCrLf + vb
        Next


        IDanfe.Faturamento = CFaturamento_Retrato
        IDanfe.Identificacao_Emitente = CEmitente
        IDanfe.Identificacao_Destinatario = CDestinatario
        IDanfe.Data_Hora = CDataHora
        IDanfe.Valores_Nota = CValores
        IDanfe.Identificacao_Transportadora = CTransportadora
        IDanfe.Valores_ISSQN = CISSQN
        IDanfe.InformacoesComplementares = CINFO
        IDanfe.Dados_Nfe = CDadosNF

        IDanfe.Dados_outros = Coutros


        IDanfe.VisualizarImpressao()



    End Sub

    Private Sub envia_cont()

        Try
            Invoke(Sub() lblcont.Visible = True)
            Dim dir As New System.IO.DirectoryInfo(Application.StartupPath & "\CONTIGENCIA")

            For Each fi As System.IO.FileInfo In dir.GetFiles

                Invoke(Sub() lblcont.Text = "Enviando a NFCe Contigencia Servidor: " & fi.Name.Substring(0, 44))


                xmldoc.Load(fi.FullName)

                Dim arquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)
                Dim ret As String

                arquivo.Add("ambiente", ambiente)
                arquivo.Add("caixa", caixa)
                arquivo.Add("RV", fi.Name.Substring(44, 9))
                arquivo.Add("nChave", fi.Name.Substring(0, 44))
                arquivo.Add("xml", xmldoc.OuterXml)


                ret = processarWS_host(arquivo, "Web4_EnviaNFe_cont/enviaNFe")

                If ret = "ok" Then
                    File.Delete(fi.FullName)
                End If

            Next

            Invoke(Sub() lblcont.Visible = False)
        Catch ex As Exception

            Try
                Invoke(Sub() lblcont.Visible = False)
            Catch ex2 As Exception

            End Try

            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Envio Contigencia !")
        End Try

    End Sub

    Private Sub envia_rv()
        Try

            Invoke(Sub() lblrv.Visible = True)

            Dim dir As New System.IO.DirectoryInfo(Application.StartupPath & "\RX")

            For Each fi As System.IO.FileInfo In dir.GetFiles

                Invoke(Sub() lblrv.Text = "Enviando a RV Servidor: " & fi.Name.Substring(0, 9))


                Dim arquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)
                Dim ret As String

                Using streamReader = New StreamReader(fi.FullName)
                    arquivo.Add("conteudo", streamReader.ReadToEnd)
                End Using

                arquivo.Add("caixa", caixa)
                arquivo.Add("RV", fi.Name.Substring(0, 9))


                ret = processarWS_host(arquivo, "Processar_vendasist/processar")


                If ret = "ok" Then
                    File.Delete(fi.FullName)
                End If

            Next

            ''''''''''''Envia de NFCe pendentes'''''''

            Dim dir2 As New System.IO.DirectoryInfo(Application.StartupPath & "\XML_NFCe")

            For Each fi As System.IO.FileInfo In dir2.GetFiles

                Invoke(Sub() lblrv.Text = "Enviando XML NFCe Pendente Servidor: " & fi.Name.Substring(0, 9))

                xmldoc.Load(fi.FullName)

                Dim arquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)
                Dim ret As String

                arquivo.Add("ambiente", ambiente)
                arquivo.Add("caixa", caixa)
                arquivo.Add("RV", fi.Name.Substring(44, 9))
                arquivo.Add("nChave", fi.Name.Substring(0, 44))
                arquivo.Add("xml", xmldoc.OuterXml)


                ret = processarWS_host(arquivo, "Web4_EnviaNFe_cont/enviaNFe")

                If ret = "ok" Then
                    File.Delete(fi.FullName)
                End If

            Next

            Invoke(Sub() lblrv.Visible = False)
        Catch ex As Exception
            Invoke(Sub() lblrv.Visible = False)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Envio RV servidor !")
        End Try
    End Sub


    Public Sub carrega_emp(ByVal cn As String)
        Dim dr As SQLiteDataReader
        Dim ret As Integer = 0
        conectar_sqlite()

        Dim SQLcommand As SQLiteCommand
        SQLcommand = Conn.CreateCommand
        SQLcommand.CommandText = "Select * from EMPRESA where codigo_emp = '" & cn & "'"
        dr = SQLcommand.ExecuteReader()


        While (dr.Read())

            empresa.sCNPJ = dr("cnpj_emp")
            empresa.sNomeRazao = dr("razao")
            empresa.sNomefant = dr("nome_fan")
            empresa.send = dr("endereco")
            empresa.sNumero = dr("numero")
            empresa.sBairro = dr("bairro")
            empresa.sCEP = dr("cep")
            empresa.sIe = dr("IE")
            empresa.sInscrMunic = dr("im")
            empresa.Sfone = dr("fone")
            empresa.sCodMunIBGE = dr("cod_munic")
            empresa.sCSC = dr("csc")
            empresa.Idtoken = dr("idtoken")
            empresa.sSiglaUF = dr("uf")
            empresa.sNomeMunic = dr("cidade")
            empresa.scod_trib = dr("regime").ToString
            empresa.saliq_simples = dr("aliq_simples").ToString
            empresa.Scnae = dr("cnae")
            empresa.ambiente_nfe = dr("ambiente")
            empresa.sEmail = dr("email")
            empresa.senha_cert = Crypto.Descrip_licenca(dr("pess"))
            empresa.cert = dr("cert")
            ret += 1


        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()


        If File.Exists(Application.StartupPath & "\cert\" & empresa.sCNPJ & ".pfx") Then
            File.Delete(Application.StartupPath & "\cert\" & empresa.sCNPJ & ".pfx")
        End If

        If File.Exists(Application.StartupPath & "\cert\" & empresa.sCNPJ & ".pfx") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\cert\")
            Dim bytes = TryCast(Convert.FromBase64String(empresa.cert), Byte())
            File.WriteAllBytes(Application.StartupPath & "\cert\" & empresa.sCNPJ & ".pfx", bytes)
        End If

        certificado = busca_cert()

        If ret = 0 Then
            MsgBox("Empresa não cadastrada no sistema," & vbCrLf & "Operação Cancelada !", MsgBoxStyle.Exclamation, "Aviso !")
            End
        End If
    End Sub

    Private Sub sjp_trasnp()

        Dim myprocesses As Process()
        myprocesses = Process.GetProcessesByName("SJP_transp") 'obter processos com o nome X

        If myprocesses.Length = 0 Then 'se for maior que 0 então existem processos com o nome X
            Dim startInfo As New ProcessStartInfo(Application.StartupPath & "\SPJ_tranp\SJP_transp.exe")
            startInfo.WindowStyle = ProcessWindowStyle.Hidden
            startInfo.Verb = "runas"
            Process.Start(startInfo)
        End If

    End Sub

    Private Sub txtcodbarra_TextChanged(sender As Object, e As EventArgs) Handles txtcodbarra.TextChanged

    End Sub
End Class