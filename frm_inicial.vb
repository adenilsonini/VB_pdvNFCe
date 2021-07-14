Imports System.Data.SQLite
Imports System.Xml
Imports System.Drawing.Printing

Public Class frm_inicial
    Dim arquivoIni_pdv As ArquivoIni = New ArquivoIni(Application.StartupPath & "\pdv.ini")
    Private Sub frm_inicial_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub frm_inicial_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            End
        End If
    End Sub

    Private Sub frm_inicial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carrega_emp()
        cboempresa.SelectedIndex = 0

        verifica()
    End Sub
    Private Sub carrega_emp()

        Dim dr As SQLiteDataReader

        conectar_sqlite()
        Dim SQLcommand As SQLiteCommand
        SQLcommand = Conn.CreateCommand
        SQLcommand.CommandText = "Select * from EMPRESA"
        dr = SQLcommand.ExecuteReader()


        While (dr.Read())
            cboempresa.Items.Add(dr("codigo_emp") & "-" & dr("razao"))
        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()
    End Sub

    Private Sub cboempresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboempresa.SelectedIndexChanged

        If cboempresa.Text <> "" Then
            Dim nPosI As Int32 = cboempresa.Text.IndexOf("-")
            frmpdv.carrega_emp(cboempresa.Text.Substring(0, nPosI))
        End If

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Saida Operador" Then

            If ret_valor_banco("operador", "codigo_op", frmpdv.cod_op, "saida_op") = "0" Then
                MsgBox("Você não tem permissão para esta operação ?", MsgBoxStyle.Exclamation, "Aviso !")
                Exit Sub
            End If

            If arquivoIni_pdv.KeyExists("Nome_print", "Settings") = False Then
                arquivoIni_pdv.Write("Nome_print", "", "Settings")
            End If
            impre_rel(arquivoIni_pdv.Read("Nome_print", "Settings"))

            conectar_sqlite()
            Dim sql3 As String = "UPDATE venda_pdv SET Status = 'Fechado', data_fech = '" & Now & "' where Status = 'Aberto'"
            Dim insertSQL4 As SQLiteCommand = New SQLiteCommand(sql3, Conn)

            insertSQL4.ExecuteNonQuery()
            Conn.Close()

            Button1.Text = "Entrada Operador"

        Else

            If ret_valor_banco("operador", "codigo_op", frmpdv.cod_op, "entrada_op") = "0" Then
                MsgBox("Você não tem permissão para esta operação ?", MsgBoxStyle.Exclamation, "Aviso !")
                Exit Sub
            End If

            frmoperador.ShowDialog()
        End If

    End Sub

    Private Sub verifica()

        Dim dr As SQLiteDataReader

        conectar_sqlite()
        Dim SQLcommand As SQLiteCommand
        SQLcommand = Conn.CreateCommand
        SQLcommand.CommandText = "select * from venda_pdv where Status = 'Aberto'"
        dr = SQLcommand.ExecuteReader()


        While (dr.Read())

            Button1.Text = "Saida Operador"
            frmpdv.cod_op = dr("codigo_op")


        End While

        dr.Close()
        SQLcommand.Dispose()
        oConn.Close()

        frmpdv.operador = ret_valor_banco("operador", "codigo_op", frmpdv.cod_op, "nome_op")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If Button1.Text = "Entrada Operador" Then
            MsgBox("Entre com Operador para fazer vendas ?", MsgBoxStyle.Exclamation, "Aviso !")
            Exit Sub
        End If
        Me.Close()
    End Sub

    Private Sub impre_rel(ByVal nome_print As String)

        Dim printDocument As PrintDocument = New PrintDocument()
        Dim standardPrintController As StandardPrintController = New StandardPrintController()
        Dim num As Integer = CentimetrosParaCentesimasPolegada(0.05)
        printDocument.DefaultPageSettings.Margins = New Margins(num, num, num, num)
        printDocument.PrintController = CType(standardPrintController, PrintController)



        AddHandler printDocument.PrintPage, New Printing.PrintPageEventHandler(AddressOf danfeECF.rptoperador)
        Dim objPrintPreview As New PrintPreviewDialog

        If nome_print <> "" Then
            printDocument.PrinterSettings.PrinterName = nome_print
        End If

        printDocument.Print()
    End Sub
End Class