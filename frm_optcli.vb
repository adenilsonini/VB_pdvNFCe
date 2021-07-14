Public Class frm_optcli
    Public par As Boolean
    Private paginaAtual As Integer = 1
    Dim nome As String = "razao_social"
    Dim rs As New ADODB.Recordset

    Private Sub frm_optcli_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If par = False Then
            frmopcaopagcli.ShowDialog()
        End If

        txtend.Focus()
    End Sub

    Private Sub frm_optcli_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then

            frmopcaopagcli.ShowDialog()

        End If
    End Sub
    Private Sub frm_optcli_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub verifica()

        consulta_cli_host(txtcpf.Text, frmpdv.caixa, txtnome.Text)


        txtsaldo.Text = CDec(txtcredito.Text) - CDec(txtcre_usa.Text)
        txtsaldo.Text = Convert.ToDouble(txtsaldo.Text).ToString("N2")
        txtlimeteret.Text = CDec(txtsaldo.Text) - CDec(frmpdv.txtvlrtotal.Text)
        txtlimeteret.Text = Convert.ToDouble(txtlimeteret.Text).ToString("N2")


        If CDec(txtsaldo.Text) < CDec(frmpdv.txtvlrtotal.Text) Then
            txtinfo.Text = "O cliente Não Possui crédito Disponível para essa venda. Saldo Atual Disponível: " + txtsaldo.Text

            If MessageBox.Show("O cliente Não tem Saldo Suficiente para essa venda: " + vbCrLf + "Deseja Continuar ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                frmpdv.vd_aprazo = "ok"
                frmpdv.cnpj_dest = txtcpf.Text
                txtinfo.BackColor = Color.Red
                frmpdv.prazodia = txtprazo.Text
                frmpdv.cnpj_dest = txtcpf.Text
                Me.Close()
            Else
                frmpdv.vd_aprazo = "n"
                frmpdv.cnpj_dest = txtcpf.Text
                Me.Close()
            End If
        Else
            frmpdv.prazodia = txtprazo.Text
            frmpdv.vd_aprazo = "ok"
            frmpdv.cnpj_dest = txtcpf.Text
            txtinfo.Text = "O cliente possui crédito Disponível No valor de: " + txtsaldo.Text
            Me.Close()
        End If
    End Sub



    Private Sub txtend_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtend.KeyPress

        If (e.KeyChar = Chr(13)) Then
            verifica()
        End If

    End Sub

    Private Sub consulta_cli_host(ByVal cnpj_dest As String, ByVal caixa As String, ByVal nome_cli As String)

        Dim arquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim ret As Dictionary(Of String, String) = New Dictionary(Of String, String)

        arquivo.Add("caixa", caixa)
        arquivo.Add("cnpj_dest", cnpj_dest)
        arquivo.Add("nome_cli", nome_cli)



        Try

            txtinfo.Text = "Enviado Solicitacao de cliente para sevidor..."
            txtinfo.Refresh()

            '  Dim thread As Thread = New Thread(AddressOf processarWS)
            '  thread.Start(CObj(arquivo))
            ret = processarWS_nfe4_list(arquivo, "consultacli/Consulta")

            If ret("status") = "ok" Then


                txtcre_usa.Text = ret("vlrusado_cli")

                txtcredito.Text = ret("credito_dest")

                txtprazo.Text = ret("diapag_dest")

                txtinfo.Text = "Consulta realizada com sucesso"

            Else

            txtinfo.Text = ret("status")
            End If




        Catch ex As Exception

            txtinfo.Text = ret("status") & "Aviso erro Rotina: consulta_statusNF_host_list !"

            '  Invoke(Sub() frminfo.Close())
        End Try
    End Sub
End Class