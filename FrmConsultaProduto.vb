Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SQLite

Public Class FrmConsultaProduto
    Public par As String
    Dim rs As New ADODB.Recordset
    Dim rs2 As New ADODB.Recordset

    Private Sub listaProduto()
        dgvprodutos.Rows.Clear()
        Dim sql As String

        Try


            If txtfiltrodesc.Text <> "" Then
                sql = "SELECT * FROM produto INNER JOIN Codigo_barras ON produto.codigo_prod = Codigo_barras.codigo_prod WHERE produto.descricao LIKE '%" & txtfiltrodesc.Text & "%'"
            ElseIf txtfiltrobarras.Text <> "" Then
                sql = "SELECT * FROM produto INNER JOIN Codigo_barras ON produto.codigo_prod = Codigo_barras.codigo_prod where Codigo_barras.cod_barras ='" & txtfiltrobarras.Text & "'"
            Else
                sql = "SELECT * FROM produto Codigo_barras ON produto.codigo_prod = Codigo_barras.codigo_prod"
            End If

            Dim dr As SQLiteDataReader

            conectar_sqlite()

            Dim SQLcommand As SQLiteCommand

            SQLcommand = Conn.CreateCommand

            SQLcommand.CommandText = sql

            dr = SQLcommand.ExecuteReader()


            While dr.Read()

                If getDataGridViewIndex(dr("codigo_prod")) = "R" Then
                    dgvprodutos.Rows.Add(dr("codigo_prod"), dr("descricao"), dr("cod_barras"), dr("ncm_prod"), Format(CDec(dr("vlr_venda")), "#,##0.00"))
                End If

            End While

            dr.Close()
            SQLcommand.Dispose()
            Conn.Close()

            'lbltotalregistro.Text = dgvncm.RowCount
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conn.Close()
        End Try

    End Sub

    Private Sub FrmConsultaProduto_Activated(sender As Object, e As EventArgs) Handles Me.Activated
      
        txtfiltrodesc.Focus()

    End Sub

    Private Sub FrmConsultaProduto_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmConsultaProduto_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'listaProduto()
    End Sub

    Private Sub txtfiltrodesc_GotFocus(sender As Object, e As EventArgs) Handles txtfiltrodesc.GotFocus
        txtfiltrobarras.Clear()
    End Sub

    Private Sub txtfiltrodesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtfiltrodesc.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            If txtfiltrodesc.Text = "" Then
                txtfiltrodesc.Text = "%"
            End If
            listaProduto()
            If dgvprodutos.RowCount = 1 Then
                dgvprodutos.Focus()
            End If
        End If
    End Sub

    Private Sub txtfiltrobarras_GotFocus(sender As Object, e As EventArgs) Handles txtfiltrobarras.GotFocus
        txtfiltrodesc.Clear()
    End Sub

    Private Sub txtfiltrobarras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtfiltrobarras.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then


            If txtfiltrobarras.Text = "" Then
                MsgBox("Informe um Código de Barra para COnsulta ?", MsgBoxStyle.Exclamation, "Aviso !")
                Exit Sub
            End If

            listaProduto()
            If dgvprodutos.RowCount = 1 Then
                dgvprodutos.Focus()
            End If
        End If
    End Sub

    Private Sub dgvprodutos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvprodutos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
        End If

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Dispose()
        End Select
    End Sub

    Private Sub dgvprodutos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvprodutos.KeyPress
        If (e.KeyChar = Chr(13)) Then

            If par = "pdv" Then

                conectar_sqlite()
                Dim SQLcommand As SQLiteCommand
                SQLcommand = Conn.CreateCommand
                SQLcommand.CommandText = "select * from produto where codigo_prod ='" & dgvprodutos.CurrentRow.Cells("codigo_prod").Value & "'"

                Using reader As SQLiteDataReader = SQLcommand.ExecuteReader

                    While reader.Read

                        frmpdv.txtdesconto.Text = "0,00"
                        frmpdv.txtdescricao.Text = reader("descricao")
                        If reader("vlr_promocao") = "0.00" Then
                            frmpdv.txtvlrunit.Text = Format(CDec(reader("vlr_venda")), "#,##0.00")
                        Else
                            frmpdv.txtvlrunit.Text = reader("vlr_promocao")
                        End If
                        frmpdv.txtcod.Text = dgvprodutos.CurrentRow.Cells("codigo_prod").Value

                        frmpdv.txtncm.Text = reader("ncm_prod")
                        frmpdv.txtcst.Text = reader("cst")
                        frmpdv.txtcest.Text = reader("cest").ToString.Replace(".", "")
                        frmpdv.txtaliqicms.Text = reader("aliq_icms").ToString

                        If reader("obs").ToString <> "" Then
                            MsgBox(reader("obs").ToString, MsgBoxStyle.Information, "Observação do Produto !")
                            frmpdv.txtqtde.Focus()
                        End If
                    End While

                End Using


                frmpdv.txtun.Text = ret_valor_banco("codigo_barras", "codigo_prod", dgvprodutos.CurrentRow.Cells("codigo_prod").Value, "un")

                frmpdv.txtcodbarra.Text = ret_valor_banco("codigo_barras", "codigo_prod", dgvprodutos.CurrentRow.Cells("codigo_prod").Value, "cod_barras")

                frmpdv.txtqtde.Text = Format(CDec(ret_valor_banco("codigo_barras", "codigo_prod", dgvprodutos.CurrentRow.Cells("codigo_prod").Value, "qtde")), "###0.000")

                Me.Close()
            End If
        End If
    End Sub

    Private Function getDataGridViewIndex(ByVal id As String) As String

        Dim r As String = "R"

        For Each row As DataGridViewRow In Me.dgvprodutos.Rows

            If Not row.IsNewRow Then
                If row.Cells("codigo_prod").Value = id Then
                    Return row.Index
                End If
            End If

        Next

        Return r

    End Function

End Class