Imports System.Data.SQLite

Public Class frmopcaopag
    Private paginaAtual As Integer = 1
    Private RelatorioTitulo As String
    Dim rs As New ADODB.Recordset

    Private Sub frmopcaopag_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.Dispose()
    End Sub

    Private Sub frmopcaopag_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmopcaopag_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
        If e.KeyCode = Keys.Escape Then
            frmpdv.retp = True
            Me.Close()
        End If
    End Sub

    Private Sub frmopcaopag_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub
    Private Sub frmopcaopag_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvpag.Rows.Clear()

        conectar_sqlite()
        Dim SQLcommand As SQLiteCommand
        SQLcommand = Conn.CreateCommand
        SQLcommand.CommandText = "select * from finalizadora"

        Using reader As SQLiteDataReader = SQLcommand.ExecuteReader

            While reader.Read
                dgvpag.Rows.Add(reader("desc_fin"), reader("codigo_fin"))
            End While

        End Using

    End Sub

    Private Sub txtdinheiro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdinheiro.KeyPress
        Try
            If (e.KeyChar = Chr(13)) Then
                txttroco.Enabled = True
                txtdinheiro.Text = Convert.ToDouble(txtdinheiro.Text).ToString("N2")
                txttroco.Text = CDec(txtdinheiro.Text) - CDec(frmpdv.txtvlrtotal.Text)
                txttroco.Text = Convert.ToDouble(txttroco.Text).ToString("N2")
                If txttroco.Text.Substring(0, 1) = "-" Then
                    MsgBox("Valor de Dinheiro Menor que Valor total da Compra ?", MsgBoxStyle.Exclamation, "Aviso !")
                    txttroco.Enabled = False
                    txtdinheiro.Focus()
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txttroco_GotFocus(sender As Object, e As EventArgs) Handles txttroco.GotFocus
        If txtdinheiro.Text = "" Then
            txtdinheiro.Focus()
        End If
    End Sub

    Private Sub txttroco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttroco.KeyPress
        If (e.KeyChar = Chr(13)) Then
            finalizar_venda()
        End If
    End Sub


    Private Sub finalizar_venda()
        If txtdinheiro.Text = "" Then
            MsgBox("Informe o valor do Dinheiro ?", MsgBoxStyle.Exclamation, "Aviso !")
            txtdinheiro.Focus()
            Exit Sub
        End If

        txttroco.Enabled = True
        txtdinheiro.Text = Convert.ToDouble(txtdinheiro.Text).ToString("N2")
        txttroco.Text = CDec(txtdinheiro.Text) - CDec(frmpdv.txtvlrtotal.Text)
        txttroco.Text = Convert.ToDouble(txttroco.Text).ToString("N2")

        frmpdv.codigo_fin = dgvpag.CurrentRow.Cells("cod_fingrid").Value
        frmpdv.vPag = txtdinheiro.Text
        frmpdv.vTroco = txttroco.Text

        If txttroco.Text.Substring(0, 1) = "-" Then
            MsgBox("Valor de Dinheiro Menor que Valor total da Compra ?", MsgBoxStyle.Exclamation, "Aviso !")
            txttroco.Enabled = False
            txtdinheiro.Focus()
        End If
        '
        '   If MessageBox.Show("Deseja Imprimir o Orçamento ?", "Aviso !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
        'PrintDocument1.Print()
        '   End If
        '   frmpdv.salvar_venda()
        '   frmpdv.limpar()
        '  frmpdv.limpa_totalgrid()
        Me.Close()

    End Sub

    Private Sub dgvpag_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpag.CellContentClick

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        finalizar_venda()
    End Sub

    Private Sub dgvpag_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvpag.KeyPress
        If (e.KeyChar = Chr(13)) Then

            If dgvpag.CurrentRow.Cells("cod_fingrid").Value = "01" Then
                frmpdv.indPag = "0"
                txtdinheiro.Focus()
            End If

            If dgvpag.CurrentRow.Cells("cod_fingrid").Value = "05" Then
                frmpdv.indPag = "1"
                frmpdv.codigo_fin = dgvpag.CurrentRow.Cells("cod_fingrid").Value
                Me.Close()
                frmopcaopagcli.ShowDialog()
            End If

            If dgvpag.CurrentRow.Cells("cod_fingrid").Value = "02" Then
                frmpdv.codigo_fin = dgvpag.CurrentRow.Cells("cod_fingrid").Value
                frmpdv.indPag = "0"
                Me.Close()
            End If

            If dgvpag.CurrentRow.Cells("cod_fingrid").Value = "03" Then
                frmpdv.indPag = "0"
                frmpdv.codigo_fin = dgvpag.CurrentRow.Cells("cod_fingrid").Value
                Me.Close()
            End If

            If dgvpag.CurrentRow.Cells("cod_fingrid").Value = "04" Then
                frmpdv.indPag = "0"
                frmpdv.codigo_fin = dgvpag.CurrentRow.Cells("cod_fingrid").Value
                Me.Close()
            End If

            If dgvpag.CurrentRow.Cells("cod_fingrid").Value = "05" Then
                frmpdv.indPag = "0"
                frmpdv.codigo_fin = dgvpag.CurrentRow.Cells("cod_fingrid").Value
                Me.Close()
            End If

            frmpdv.indPag = "0"
            frmpdv.codigo_fin = dgvpag.CurrentRow.Cells("cod_fingrid").Value
            ' Me.Close()
        End If
    End Sub

    Private Sub dgvpag_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvpag.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
        End If
    End Sub

    Private Sub txttroco_TextChanged(sender As Object, e As EventArgs) Handles txttroco.TextChanged

    End Sub

    Private Sub dgvpag_SelectionChanged(sender As Object, e As EventArgs) Handles dgvpag.SelectionChanged
        If dgvpag.CurrentRow.Cells("cod_fingrid").Value = "01" Then
            Me.Height = 470
            dgvpag.TabStop = True
            txtdinheiro.Focus()
            frmpdv.codigo_fin = "01"
        Else
            Me.Height = 388
        End If


    End Sub
End Class