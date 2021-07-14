Imports System.Security
Imports System.Security.Principal.WindowsIdentity
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports System.Data.SQLite

Module conexao
    Public cnado As New OleDb.OleDbConnection
    Public cnsql As New ADODB.Connection
    Public cn_nfe As New ADODB.Connection
    Public cnemail As New ADODB.Connection
    Public caminho_banco As String, caminho_nfe As String
    Public cnpj As String
    Public cncentral As New ADODB.Connection

    Public cn_p As New ADODB.Connection
    Public cn As New ADODB.Connection

    Public cn_ONE As New ADODB.Connection
    Public cn_DFe As New ADODB.Connection

    Public dr As MySqlDataReader
    Public oConn As New MySqlConnection
    Public ip As String
    Public sConnectionString As String
    Public Conn As New SQLiteConnection
    Public Sub conectar_sqlite()


        sConnectionString = "Data Source=" & AppDomain.CurrentDomain.BaseDirectory & "\SPJ_tranp\pdv.db3;Version=3;Password=R@enil2015#;"

        'abre a conexão
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = sConnectionString
            Conn.Open()
        End If
    End Sub
    Public Sub conectar_sqlite_cfe()


        ' sConnectionString = "Data Source=C:\Users\adeni\OneDrive\Área de Trabalho\teste\Cfe.db3;Version=3;New=True;"

        'abre a conexão
        If oConn.State = ConnectionState.Closed Then
            oConn.ConnectionString = "Data Source=C:\PdvLinx\Cfe.db3;Version=3;Password=R@enil2015#;"
            oConn.Open()
        End If
    End Sub
    Public Sub conectar_baseNFe()

        Try

            caminho_nfe = Application.StartupPath

            If cn_nfe.State = ConnectionState.Closed Then
                cn_nfe.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & caminho_nfe & "\BD_NFE.mdb")
            End If

        Catch ex As Exception
            MsgBox(ex.Message & "   |   " & "Arquivo confing_nfe.ini", MsgBoxStyle.Critical, "Aviso")

            End
        End Try
    End Sub

    Public Sub fecha_baseNFe()

        Try

           
            If cn_nfe.State = ConnectionState.Open Then
                cn_nfe.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso Rotina fecha_baseNFe")

        End Try
    End Sub

    Public Function GetConnection() As OleDbConnection

        Try

            caminho_nfe = Application.StartupPath

            Dim sql As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & caminho_nfe & "\BD_NFE.mdb"
            Return New OleDbConnection(sql)

        Catch ex As Exception
            MsgBox(ex.Message & "   |   " & "Arquivo confing_nfe.ini", MsgBoxStyle.Critical, "Aviso")
            End
        End Try

    End Function

    Public Sub conectar_base(ByVal nome_banco As String)
        Try

            If nome_banco = "sefaz" Then
                caminho_banco = lerINI(Application.StartupPath & "\config.ini", "DFe", "caminhobancotemp")

            ElseIf nome_banco = "Onedrive" Then
                caminho_banco = lerINI(Application.StartupPath & "\config.ini", "ONEDRIVE", "caminhobanco")

            ElseIf nome_banco = "formapreco" Then
                caminho_banco = lerINI(Application.StartupPath & "\config.ini", "FORMAPRECO", "caminhobasepreco")

            ElseIf nome_banco = "NFe_trans" Then
                caminho_banco = Application.StartupPath & "\NFe_trans.mdb"

            ElseIf nome_banco = "ibpt" Then
                caminho_banco = Application.StartupPath & "\IBPT.mdb"

            ElseIf nome_banco = "ibpt" Then
                caminho_banco = Application.StartupPath & "\IBPT.mdb"

            End If

            If cncentral.State = ConnectionState.Closed Then
                cncentral.Open("Provider=Microsoft.Jet.OLEDB.4.0;data source= " & caminho_banco)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso !")
        End Try


    End Sub

    Public Sub conectarsqlinx()
        Try


            If cnsql.State = ConnectionState.Closed Then
                cnsql.Open("DRIVER={MySQL ODBC 3.51 Driver};Database=sglinx;Server=192.168.254.1;Port=3306;uid=adminlinear;pwd=@2013linear;STMT=;Opt")
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Aviso !")
        End Try

    End Sub

    Public Sub conectar_ado()

        caminho_banco = lerINI(Application.StartupPath & "\config.ini", "DFe", "caminhobancotemp")

        If cnado.State = ConnectionState.Closed Then
            cnado.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;data source= " & caminho_banco
            cnado.Open()
        End If

    End Sub

    Public Sub conectar_email()

        If cnemail.State = ConnectionState.Closed Then
            cnemail.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath + "\Banco_email.mdb" & "")
        End If

    End Sub

End Module
