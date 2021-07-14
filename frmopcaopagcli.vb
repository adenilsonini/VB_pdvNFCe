Imports System.Data.SQLite

Public Class frmopcaopagcli
    Private paginaAtual As Integer = 1
    Dim lbltimer As Integer
    Dim rs As New ADODB.Recordset

    Private Sub frmopcaopagcli_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frm_optcli.par = True
        Button1.Visible = False
        Panelpesquisa.Visible = True
        Me.Dispose()
    End Sub

    Private Sub txtnomep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnomep.KeyPress
        If (e.KeyChar = Chr(13)) Then
            If dgvpesquisa.RowCount = 1 Then
                carrega()
            End If
        End If
    End Sub


    Private Sub pesquisar()
        dgvpesquisa.Rows.Clear()


        conectar_sqlite()
        Dim SQLcommand As SQLiteCommand
        SQLcommand = Conn.CreateCommand
        SQLcommand.CommandText = "select * from cliente where nome_cli like '%" + txtnomep.Text + "%'"

        Using reader As SQLiteDataReader = SQLcommand.ExecuteReader

            While reader.Read
                dgvpesquisa.Rows.Add(reader("codigo_cli"), reader("nome_cli"), reader("cnpj_cli"), reader("liberado").ToString)
            End While

        End Using

       
        If dgvpesquisa.RowCount = 0 Then
            MsgBox("Cliente não cadastrado !", MsgBoxStyle.Exclamation, "aviso !")
        End If

        
    End Sub

    Private Sub dgvpesquisa_Click(sender As Object, e As EventArgs) Handles dgvpesquisa.Click
        carrega()
    End Sub

    Private Sub dgvpesquisa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvpesquisa.KeyPress
        If (e.KeyChar = Chr(13)) Then

            carrega()

        End If
    End Sub

    Private Sub carrega()
        frm_optcli.par = True


        conectar_sqlite()
        Dim SQLcommand As SQLiteCommand
        SQLcommand = Conn.CreateCommand
        SQLcommand.CommandText = "select * from cliente where cnpj_cli = '" & dgvpesquisa.CurrentRow.Cells("cnpj_dest").Value & "'"

        Using reader As SQLiteDataReader = SQLcommand.ExecuteReader

            While reader.Read
                frm_optcli.txtcpf.Text = dgvpesquisa.CurrentRow.Cells("cnpj_dest").Value

                frm_optcli.txtnome.Text = reader("nome_cli")

               
                frm_optcli.txtend.Text = reader("end_cli") & ", " & reader("numero") & ", " & reader("bairro") & ", " & reader("cep_cli") & ", " & reader("cidade") & "-" & reader("uf")
                frm_optcli.txtprazo.Text = reader("prazo").ToString
                frm_optcli.txtcredito.Text = reader("credito").ToString
                frm_optcli.txtcre_usa.Text = reader("vlr_usado").ToString
            End While

        End Using

        Me.Close()
    End Sub



    Private Sub frmopcaopagcli_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtnomep.Focus()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbltimer += 1

        If lbltimer = 1 Then
            txtnomep.Focus()
            Timer1.Dispose()
        End If
    End Sub

    Private Sub dgvpesquisa_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpesquisa.CellContentClick

    End Sub

    Private Sub txtnomep_TextChanged(sender As Object, e As EventArgs) Handles txtnomep.TextChanged
        pesquisar()
    End Sub
End Class