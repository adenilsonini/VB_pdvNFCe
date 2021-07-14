Imports System.Data.SQLite

Public Class frmoperador

    Private Sub frmoperador_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmoperador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txttroco_GotFocus(sender As Object, e As EventArgs) Handles txttroco.GotFocus
        If txtsenha.Text = "" Then
            txtsenha.Focus()
        End If
    End Sub

    Private Sub txttroco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttroco.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            If txttroco.Text = "0,00" Then
                MsgBox("Informe o troco ?", MsgBoxStyle.Exclamation, "Aviso !")
                Exit Sub
            End If
            Dim sql2 As String = "INSERT INTO venda_pdv (codigo_op, fundo_troco,  data_abertura, Status, vlr_dinheiro, vlr_prazo, vlr_cartao, vlr_cheque, vlr_vale, vlr_outros,  vlr_total) VALUES (@codigo_op, @fundo_troco, @data_abertura, @Status, @vlr_dinheiro, @vlr_prazo, @vlr_cartao, @vlr_cheque, @vlr_vale, @vlr_outros, @vlr_total)"

            conectar_sqlite()
            Dim insertSQL2 As SQLiteCommand = New SQLiteCommand(sql2, Conn)
            insertSQL2.Parameters.Add(New SQLiteParameter("codigo_op", frmpdv.cod_op))
            insertSQL2.Parameters.Add(New SQLiteParameter("fundo_troco", format_val_mysql_ent(txttroco.Text)))
            insertSQL2.Parameters.Add(New SQLiteParameter("data_abertura", Now))
            insertSQL2.Parameters.Add(New SQLiteParameter("Status", "Aberto"))

            insertSQL2.Parameters.Add(New SQLiteParameter("vlr_dinheiro", "0"))
            insertSQL2.Parameters.Add(New SQLiteParameter("vlr_prazo", "0"))
            insertSQL2.Parameters.Add(New SQLiteParameter("vlr_cartao", "0"))
            insertSQL2.Parameters.Add(New SQLiteParameter("vlr_cheque", "0"))
            insertSQL2.Parameters.Add(New SQLiteParameter("vlr_vale", "0"))
            insertSQL2.Parameters.Add(New SQLiteParameter("vlr_outros", "0"))
            insertSQL2.Parameters.Add(New SQLiteParameter("vlr_total", "0"))

            insertSQL2.ExecuteNonQuery()
            Conn.Close()

            frm_inicial.Button1.Text = "Saida Operador"
            Me.Close()
        End If
    End Sub

    Private Sub txttroco_LostFocus(sender As Object, e As EventArgs) Handles txttroco.LostFocus
        If txttroco.Text = "" Then
            txttroco.Text = "0,00"
        Else
            txttroco.Text = Format(CDec(txttroco.Text), "#,##0.00")
        End If
    End Sub

    Private Sub txtsenha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsenha.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            carrega_op()
        End If
    End Sub

    Private Sub carrega_op()
        Dim RET As Integer = 0
        Dim senha As String = Crypto.Crip_licenca(txtsenha.Text)
        Dim dr As SQLiteDataReader

        conectar_sqlite()
        Dim SQLcommand As SQLiteCommand
        SQLcommand = Conn.CreateCommand
        SQLcommand.CommandText = "select * from operador where senha_op = '" & senha & "'"
        dr = SQLcommand.ExecuteReader()


        While (dr.Read())

            frmpdv.operador = dr("nome_op")
            frmpdv.cod_op = dr("codigo_op")
            txttroco.Focus()
            RET += 1
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()

        If RET = 0 Then

            MsgBox("Operador não cadastrado !!!", MsgBoxStyle.Exclamation, "Aviso !")
            txtsenha.Clear()
            txtsenha.Focus()

        End If

    End Sub

   
    Private Sub txtsenha_TextChanged(sender As Object, e As EventArgs) Handles txtsenha.TextChanged

    End Sub

    Private Sub txttroco_TextChanged(sender As Object, e As EventArgs) Handles txttroco.TextChanged

    End Sub
End Class