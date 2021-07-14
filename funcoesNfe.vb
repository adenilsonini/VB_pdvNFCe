Imports System.Xml
Imports System.IO
Imports System.Globalization
Imports System.Reflection
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Net
Imports System.Security.Cryptography
Imports System.ComponentModel
Imports System.Data.SQLite


Public Module funcoesNfe
    Public nsufalta As Boolean, email As Boolean
    Public reterro As String, urlcad As String, coduf As String
    Public nfecancelada As Boolean
    Public urldest As String
    Public urlevento As String
    Public scansvc As Boolean
    Public scan As Boolean
    Public webservice_download As Boolean
    Public cnpj_emp As String, vnome_emp As String, csc As String, idtoken As String, codmunic As String, uf As String, cidade As String
    Public regimetrib As Integer

    Public empresa As clsDadosempresa = New clsDadosempresa()

    Public ct As Integer


    Public Function formata_valor_campo(ByVal valor As String) As String
        Dim valor_ret As String
        valor = valor.Replace(".", ",")
        valor_ret = Format(Convert.ToDouble(valor), "#,##0.00")

        Return valor_ret

    End Function


    Public Function formata_valor_campo_4c(ByVal valor As String) As String
        Dim valor_ret As String
        valor = valor.Replace(".", ",")
        valor_ret = Format(Convert.ToDouble(valor), "#,##0.0000")

        Return valor_ret

    End Function

    Public Function FormatarCpfCnpj(strCpfCnpj As String) As String

        If strCpfCnpj.Length <= 8 Then

            Dim mtpCpf As New MaskedTextProvider("00,000-000")

            mtpCpf.[Set](ZerosEsquerda(strCpfCnpj, 8))


            Return mtpCpf.ToString()
        End If

        If strCpfCnpj.Length <= 10 Then

            Dim mtpCpf As New MaskedTextProvider("(00) 0000-0000")

            mtpCpf.[Set](ZerosEsquerda(strCpfCnpj, 10))


            Return mtpCpf.ToString()
        End If

        If strCpfCnpj.Length <= 11 Then


            Dim mtpCpf As New MaskedTextProvider("000\.000\.000-00")

            mtpCpf.[Set](ZerosEsquerda(strCpfCnpj, 11))


            Return mtpCpf.ToString()
        Else



            Dim mtpCnpj As New MaskedTextProvider("00\.000\.000/0000-00")

            mtpCnpj.[Set](ZerosEsquerda(strCpfCnpj, 11))


            Return mtpCnpj.ToString()
        End If

    End Function

    Public Function ZerosEsquerda(strString As String, intTamanho As Integer) As String


        Dim strResult As String = ""

        For intCont As Integer = 1 To (intTamanho - strString.Length)



            strResult += "0"
        Next

        Return strResult & strString

    End Function
    Public Function casasdecimal2(ByRef txt As TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs) As Integer
        'so aceita dois casas a pos a virgula'
        Dim texto As String
        Dim posição As Integer
        Dim cursorpos As Integer
        Dim depois As String

        If e.Handled <> 8 Then
            texto = txt.Text
            cursorpos = txt.SelectionStart
            posição = InStr(1, texto, ",")

            If e.KeyChar = "." Then
                e.Handled = True
            End If

            If cursorpos >= posição Then
                If posição > 0 Then
                    depois = Microsoft.VisualBasic.Right(texto, Len(texto) - posição)
                    If e.KeyChar = "," Then
                        e.Handled = True
                    End If
                    If Len(depois) > 1 Then
                        If Not e.KeyChar = vbBack Then
                            e.Handled = True
                        End If
                    End If
                End If
            End If
        End If
        casasdecimal2 = e.Handled
    End Function

    Public Function casasdecimal4(ByRef txt As TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs) As Integer
        'so aceita dois casas a pos a virgula'
        Dim texto As String
        Dim posição As Integer
        Dim cursorpos As Integer
        Dim depois As String

        If e.Handled <> 8 Then
            texto = txt.Text
            cursorpos = txt.SelectionStart
            posição = InStr(1, texto, ",")

            If e.KeyChar = "." Then
                e.Handled = True
            End If

            If cursorpos >= posição Then
                If posição > 0 Then
                    depois = Microsoft.VisualBasic.Right(texto, Len(texto) - posição)
                    If e.KeyChar = "," Then
                        e.Handled = True
                    End If
                    If Len(depois) > 3 Then
                        If Not e.KeyChar = vbBack Then
                            e.Handled = True
                        End If
                    End If
                End If
            End If
        End If
        casasdecimal4 = e.Handled
    End Function
    Public Function RemoverAcentos(ByVal Texto As String) As String
        Dim replacement As String = ""
        Dim str As String = New Regex("(?i)[^0-9a-z\s]").Replace(Texto, replacement)
        Dim stringBuilder As StringBuilder = New StringBuilder()

        For Each ch As Char In str.Normalize(NormalizationForm.FormD).ToCharArray()
            If CharUnicodeInfo.GetUnicodeCategory(ch) <> UnicodeCategory.NonSpacingMark Then stringBuilder.Append(ch)
        Next

        Return stringBuilder.ToString()
    End Function
    Public Function RemoveTelefone(ByVal texto As String) As String
        texto = texto.Replace(",", "")
        texto = texto.Replace(".", "")
        texto = texto.Replace("-", "")
        texto = texto.Replace(" ", "")
        texto = texto.Replace(")", "")
        texto = texto.Replace("(", "")
        texto = texto.Replace("'", "")
        texto = texto.Replace(":", "")
        texto = texto.Replace("_", "")
        Return texto
    End Function
    Public Function formatar_valor(ByVal texto As String) As String
        If texto <> "" Then

            Dim txt As String = ""

            Try
                txt = Format(Convert.ToDouble(texto.Replace(".", ",")), "###0.00")
            Catch ex As Exception

                Try
                    txt = Format(Convert.ToDouble(texto), "###0.00")

                Catch ex1 As Exception

                End Try

            End Try

            Return txt.Replace(",", ".")
        End If
    End Function
    Public Function removeFormatacao(ByVal texto As String) As String

        Dim txt As String = ""

        txt = texto.Replace(".", "")
        txt = txt.Replace("-", "")
        txt = txt.Replace("/", "")
        txt = txt.Replace("(", "")
        txt = txt.Replace(")", "")
        txt = txt.Replace(" ", "")

        Return txt
    End Function

    Public Function removezerodireita(ByVal txt As String) As String
        If txt.Substring(txt.Length - 1, 1) = "0" Then
            txt = txt.Remove(txt.Length - 1, 1)
        End If
        If txt.Substring(txt.Length - 1, 1) = "0" Then
            txt = txt.Remove(txt.Length - 2, 2)
        End If
        Return txt
    End Function

    Public Sub retornaAtributos(ByVal obj As Object(), ByRef cultura As CultureInfo, ByRef formato As String, ByRef obrigatorio As Boolean)
        cultura = CultureInfo.CreateSpecificCulture("en-US")
        formato = "###0.00"
        obrigatorio = False
        For Each objeto As Object In obj
            '   If TypeOf objeto Is Formato Then
            'Dim culturaStr As String = DirectCast(objeto, Formato).cultura
            '  formato = DirectCast(objeto, Formato).formato
            ' cultura = CultureInfo.CreateSpecificCulture(culturaStr)
            '  ElseIf TypeOf objeto Is Obrigatorio Then
            ' obrigatorio = DirectCast(objeto, Obrigatorio).propriedadeObrigatoria

            ' End If

            'cultura.NumberFormat.NumberDecimalSeparator = ",";
            'cultura.NumberFormat.NumberGroupSeparator = ".";
        Next
    End Sub

    Public Function TirarAcento(ByVal palavra As String) As String
        Dim palavraSemAcento As String = ""
        Dim caracterComAcento As String = "áàãâäéèêëíìîïóòõôöúùûüçÁÀÃÂÄÉÈÊËÍÌÎÏÓÒÕÖÔÚÙÛÜÇ"
        Dim caracterSemAcento As String = "aaaaaeeeeiiiiooooouuuucAAAAAEEEEIIIIOOOOOUUUUC"

        For i As Integer = 0 To palavra.Length - 1
            If caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1))) >= 0 Then
                Dim car As Integer = caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1)))
                palavraSemAcento += caracterSemAcento.Substring(car, 1)
            Else
                palavraSemAcento += palavra.Substring(i, 1)
            End If
        Next

        Return palavraSemAcento
    End Function

    ''' <summary>
    ''' Função que utilizo para saber se é uma propriedade simples (String, Int) ou uma nova classe, que deve gerar
    ''' uma nova tag xml
    ''' </summary>
    ''' <param name="propriedade"></param>
    ''' <returns></returns>
    Public Function novaTag(ByVal propriedade As PropertyInfo) As Boolean
        'TODO: Buscar uma forma melhor de identificar as subclasses.

        Select Case propriedade.PropertyType.ToString()
            'Propriedades que podem ser nulas (com ?)...
            Case "System.DateTime", "System.Int32", "System.String", "System.Double", "System.Nullable", "System.Decimal", _
            "System.Nullable`1[System.Int32]", "System.Nullable`1[System.DateTime]", "System.Nullable`1[System.Decimal]", "System.Nullable`1[System.Double]"
                Return False
            Case Else
                Return True
        End Select
    End Function

    Public Sub gravarElemento(ByVal writer As XmlWriter, ByVal nomeTag As String, ByVal valorTag As Object, ByVal atributos As Object())
        'CultureInfo cultBR = new CultureInfo("pt-BR");
        ' CultureInfo cultUS = new CultureInfo("en-US");

        Dim cult As CultureInfo
        Dim formato As String
        Dim obrigatorio As Boolean
        retornaAtributos(atributos, cult, formato, obrigatorio)

        If valorTag IsNot Nothing Then
            Dim valor As String = ""
            Select Case valorTag.[GetType]().ToString()
                Case "System.DateTime"
                    valor = DirectCast((valorTag), DateTime).ToString("yyyy-MM-dd")
                    'formata no padrão necessário para a NFe
                    Exit Select
                Case "System.Int32"
                    valor = valorTag.ToString()
                    If valor.Trim() = "0" Then
                        'campos do tipo inteiro com valor 0 serão ignorados
                        valor = ""
                    End If
                    Exit Select
                Case "System.String"
                    valor = TirarAcento(valorTag.ToString().Replace(vbCr & vbLf, " - ")).Trim()
                    'remove linhas... e tira acentos
                    Exit Select
                Case "System.Double"
                    valor = CDbl(valorTag).ToString(formato, cult.NumberFormat)
                    'formata de acordo com o atributo
                    Exit Select
                Case "System.Decimal"
                    valor = CDec(valorTag).ToString(formato, cult.NumberFormat)
                    'formata de acordo com o atributo
                    Exit Select

            End Select
            If (valor.Trim().Length > 0) OrElse (obrigatorio) Then
                writer.WriteElementString(nomeTag, valor)
            End If
        End If
    End Sub

    Public Function tamanhoXML(ByVal documento As XmlDocument) As Long
        Dim nomeArquivo As String = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "")

        Try
            documento.Save(nomeArquivo)
            Dim info As New FileInfo(nomeArquivo)
            Dim tamanhoArquivo As Long = info.Length

            info.Delete()

            Return tamanhoArquivo
        Catch
            Return 0

        End Try
    End Function

    Public Function RandomNumber(ByVal MaxNumber As Integer, _
   Optional ByVal MinNumber As Integer = 0) As Integer

        'initialize random number generator
        Dim r As New Random(System.DateTime.Now.Millisecond)

        'if passed incorrect arguments, swap them
        'can also throw exception or return 0

        If MinNumber > MaxNumber Then
            Dim t As Integer = MinNumber
            MinNumber = MaxNumber
            MaxNumber = t
        End If

        Return r.Next(MinNumber, MaxNumber)

    End Function
    Public Function GerarLoteNfeGeral(ByVal vStringNfe As String) As String
        Dim cVersaoDados As String = "2.00"

        'Pegar o último número de lote de NFe utilizado e acrescentar + 1 para novo envio
        Dim vArqXmlLote As String = "TryNfeLote.xml"
        Dim nNumeroLote As Int32 = 1

        If File.Exists(vArqXmlLote) Then
            Dim oLerXml As New XmlTextReader(vArqXmlLote)

            While oLerXml.Read()
                If oLerXml.NodeType = XmlNodeType.Element Then
                    If oLerXml.Name = "UltimoLoteEnviado" Then
                        oLerXml.Read()
                        nNumeroLote = Convert.ToInt32(oLerXml.Value) + 1
                        Exit While
                    End If
                End If
            End While
            oLerXml.Close()
        End If

        'Salvar o número de lote de NFe utilizado
        Dim oSettings As New XmlWriterSettings()
        oSettings.Indent = True
        oSettings.IndentChars = ""
        oSettings.NewLineOnAttributes = False
        oSettings.OmitXmlDeclaration = False

        Dim oXmlGravar As XmlWriter = XmlWriter.Create("TryNfeLote.xml", oSettings)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("DadosLoteNfe")
        oXmlGravar.WriteElementString("UltimoLoteEnviado", nNumeroLote.ToString())
        oXmlGravar.WriteEndElement()
        'DadosLoteNfe
        oXmlGravar.WriteEndDocument()
        oXmlGravar.Flush()
        oXmlGravar.Close()


        'Montar a parte do XML referente ao Lote e acrescentar a Nota Fiscal
        Dim vStringLoteNfe As String = String.Empty
        vStringLoteNfe += "<?xml version=""1.0"" encoding=""utf-8""?>"
        vStringLoteNfe += "<enviNFe xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""" & cVersaoDados & """>"
        vStringLoteNfe += "<idLote>" & nNumeroLote.ToString("000000000000000") & "</idLote>"
        vStringLoteNfe += vStringNfe
        vStringLoteNfe += "</enviNFe>"

        Dim PastaNota As String = ""
        PastaNota = My.Application.Info.DirectoryPath & "\NFE\" & Date.Today.ToString("dd-MM-yyyy") & "\"
        If Directory.Exists(PastaNota) = False Then
            Directory.CreateDirectory(PastaNota)
        End If

        Dim NDoc As New XmlDocument
        NDoc.LoadXml(vStringLoteNfe)
        Using xmltw As New XmlTextWriter(PastaNota & nNumeroLote.ToString("000000000000000") & ".xml", New UTF8Encoding(False))
            NDoc.WriteTo(xmltw)
            xmltw.Close()
        End Using
        Return nNumeroLote.ToString("000000000000000")
    End Function

    Public Function SepararNota(ByVal vNfeDadosMsg As String) As String

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<NFe")
        Dim nPosF As Int32 = vNfeDadosMsg.Length - nPosI
        Dim vStringNfe As String = vNfeDadosMsg.Substring(nPosI, nPosF - 10)

        Return vStringNfe

    End Function

    Public Function GerarNotaProcessada(ByVal vStringNfe As String, ByVal VStringRecibo As String, ByVal EmissaoNota As Date, ByVal chavenfe As String) As String
        Dim cVersaoDados As String = "3.10"

        'Montar a parte do XML referente ao Lote e acrescentar a Nota Fiscal
        Dim vStringLoteNfe As String = String.Empty
        vStringLoteNfe += "<?xml version=""1.0"" encoding=""utf-8""?>"
        vStringLoteNfe += "<nfeProc versao=""" & cVersaoDados & """ xmlns=""http://www.portalfiscal.inf.br/nfe"">"
        vStringLoteNfe += vStringNfe
        '  vStringLoteNfe += "<protNFe versao=""" & cVersaoDados & """>"
        vStringLoteNfe += VStringRecibo
        ' vStringLoteNfe += "</protNFe>"
        vStringLoteNfe += "</nfeProc>"

        Dim PastaNota As String = ""
        PastaNota = Application.StartupPath & "\NFE_XML\" & Date.Parse(EmissaoNota).ToString("dd-MM-yyyy") & "\"
        If Directory.Exists(PastaNota) = False Then
            Directory.CreateDirectory(PastaNota)
        End If


        Dim NDoc = New XmlDocument()

        NDoc.LoadXml(vStringLoteNfe)

        Using xmltw As New XmlTextWriter(PastaNota & chavenfe.Replace(" ", "") + ".xml", New UTF8Encoding(False))
            NDoc.WriteTo(xmltw)
            xmltw.Close()
        End Using

        Return PastaNota & chavenfe + ".xml"
    End Function

    Public Function SepararNotaxml(ByVal vNfeDadosMsg As String) As String

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<NFe")
        Dim n5t As Int32 = vNfeDadosMsg.IndexOf("<protNFe")
        Dim total As Int32 = vNfeDadosMsg.Length - n5t
        Dim nPosF As Int32 = vNfeDadosMsg.Length - nPosI
        Dim vStringNfe As String = vNfeDadosMsg.Substring(nPosI, nPosF - total)
        Return vStringNfe

    End Function


    Public Function validacnpj(ByVal cnpj As String)

        Dim Numero(13) As Integer

        Dim soma As Integer

        Dim i As Integer

        Dim valida As Boolean

        Dim resultado1 As Integer

        Dim resultado2 As Integer

        For i = 0 To Numero.Length - 1

            Numero(i) = CInt(cnpj.Substring(i, 1))

        Next

        soma = Numero(0) * 5 + Numero(1) * 4 + Numero(2) * 3 + Numero(3) * 2 + Numero(4) * 9 + Numero(5) * 8 + Numero(6) * 7 + _
                   Numero(7) * 6 + Numero(8) * 5 + Numero(9) * 4 + Numero(10) * 3 + Numero(11) * 2

        soma = soma - (11 * (Int(soma / 11)))

        If soma = 0 Or soma = 1 Then

            resultado1 = 0

        Else

            resultado1 = 11 - soma

        End If

        If resultado1 = Numero(12) Then

            soma = Numero(0) * 6 + Numero(1) * 5 + Numero(2) * 4 + Numero(3) * 3 + Numero(4) * 2 + Numero(5) * 9 + Numero(6) * 8 + _
                         Numero(7) * 7 + Numero(8) * 6 + Numero(9) * 5 + Numero(10) * 4 + Numero(11) * 3 + Numero(12) * 2

            soma = soma - (11 * (Int(soma / 11)))

            If soma = 0 Or soma = 1 Then

                resultado2 = 0

            Else

                resultado2 = 11 - soma

            End If

            If resultado2 = Numero(13) Then

                Return True

            Else

                Return False

            End If

        Else

            Return False

        End If

    End Function

    Function SoLETRAS(ByVal KeyAscii As Integer) As Integer

        'Transformar letras minusculas em Maiúsculas

        KeyAscii = Asc(UCase(Chr(KeyAscii)))

        ' Intercepta um código ASCII recebido e admite somente letras

        If InStr("AÃÁBCÇDEÉÊFGHIÍJKLMNOPQRSTUÚVWXYZ", Chr(KeyAscii)) = 0 Then

            SoLETRAS = 0

        Else

            SoLETRAS = KeyAscii

        End If



        ' teclas adicionais permitidas

        If KeyAscii = 8 Then SoLETRAS = KeyAscii ' Backspace

        If KeyAscii = 13 Then SoLETRAS = KeyAscii ' Enter

        If KeyAscii = 32 Then SoLETRAS = KeyAscii ' Espace
    End Function

    Function SoNumeros(ByVal Keyascii As Short) As Short

        If InStr("1234567890", Chr(Keyascii)) = 0 Then

            SoNumeros = 0

        Else

            SoNumeros = Keyascii

        End If



        Select Case Keyascii

            Case 8

                SoNumeros = Keyascii

            Case 56

                SoNumeros = Keyascii

            Case 120

                SoNumeros = Keyascii

            Case 13

                SoNumeros = Keyascii

            Case 32

                SoNumeros = Keyascii

        End Select

    End Function

    Public Function validaGTIN(code As String) As Boolean
        If code <> (New Regex("[^0-9]")).Replace(code, "") Then
            ' is not numeric
            Return False
        End If
        ' pad with zeros to lengthen to 14 digits
        Select Case code.Length
            Case 8
                code = Convert.ToString("000000") & code
                Exit Select
            Case 12
                code = Convert.ToString("00") & code
                Exit Select
            Case 13
                code = Convert.ToString("0") & code
                Exit Select
            Case 14
                Exit Select
            Case Else
                ' wrong number of digits
                Return False
        End Select
        ' calculate check digit
        Dim a As Integer() = New Integer(12) {}
        a(0) = Integer.Parse(code(0).ToString()) * 3
        a(1) = Integer.Parse(code(1).ToString())
        a(2) = Integer.Parse(code(2).ToString()) * 3
        a(3) = Integer.Parse(code(3).ToString())
        a(4) = Integer.Parse(code(4).ToString()) * 3
        a(5) = Integer.Parse(code(5).ToString())
        a(6) = Integer.Parse(code(6).ToString()) * 3
        a(7) = Integer.Parse(code(7).ToString())
        a(8) = Integer.Parse(code(8).ToString()) * 3
        a(9) = Integer.Parse(code(9).ToString())
        a(10) = Integer.Parse(code(10).ToString()) * 3
        a(11) = Integer.Parse(code(11).ToString())
        a(12) = Integer.Parse(code(12).ToString()) * 3
        Dim sum As Integer = a(0) + a(1) + a(2) + a(3) + a(4) + a(5) + a(6) + a(7) + a(8) + a(9) + a(10) + a(11) + a(12)
        Dim check As Integer = (10 - (sum Mod 10)) Mod 10
        ' evaluate check digit
        Dim last As Integer = Integer.Parse(code(13).ToString())
        Return check = last
    End Function

    Public Function VerificaConectividade_net() As Boolean
        Dim vRetorno As Boolean = False

        Try
            If My.Computer.Network.Ping("www.google.com", 10000) = True Then
                vRetorno = True
            End If
        Catch ex As Exception

        End Try


        Return vRetorno
    End Function

    Public Function IsConectedToHost(ByVal uri As Uri) As Boolean
        Try
            Dns.GetHostEntry(uri.Host)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function StringToHex(ByVal StrToHex As String) As String
        Dim str As String = ""
        Dim num1 As Long = CLng(Strings.Len(StrToHex))
        Dim num2 As Long = 1

        While num2 <= num1
            Dim Expression As String = Conversion.Hex(Strings.Asc(Strings.Mid(StrToHex, (CInt(num2)), 1)))
            If Strings.Len(Expression) = 1 Then Expression = "0" & Expression
            str += Expression
            num2 += 1
        End While

        Return Strings.LCase(str)
    End Function

    Function HexToString(ByVal hex As String) As String
        Dim text As New System.Text.StringBuilder(hex.Length \ 2)
        For i As Integer = 0 To hex.Length - 2 Step 2
            text.Append(Chr(Convert.ToByte(hex.Substring(i, 2), 16)))
        Next
        Return text.ToString
    End Function

    Public Function CalculateSHA1(ByVal text As String, ByVal enc As Encoding) As String
        Try
            Return BitConverter.ToString(New SHA1CryptoServiceProvider().ComputeHash(enc.GetBytes(text))).Replace("-", "")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub CriarLog(ByVal texto As String, Optional ByVal Modulo As String = "", Optional ByVal Rotina As String = "", Optional ByVal Principal As Boolean = False, Optional ByVal TrataErro As Boolean = False, Optional ByVal Rejeicao As Boolean = False)
        Try

            If CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(texto, "", False)) > 0UI And Not TrataErro Then

                If Principal Then

                    If CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Modulo, "", False)) > 0UI And CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Rotina, "", False)) > 0UI Then
                        texto = vbCrLf & vbCrLf & Strings.Space(24) & vbTab & ">>> " & Modulo & " " & Rotina & " - " + Strings.UCase(texto) & vbCrLf
                    ElseIf CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Modulo, "", False)) > 0UI And Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Rotina, "", False) = 0 Then
                        texto = vbCrLf & vbCrLf & Strings.Space(24) & vbTab & ">>> " & Modulo & " - " + Strings.UCase(texto) & vbCrLf
                    ElseIf Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Modulo, "", False) = 0 And CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Rotina, "", False)) > 0UI Then
                        texto = vbCrLf & vbCrLf & Strings.Space(24) & vbTab & ">>> " & Rotina & " - " + Strings.UCase(texto) & vbCrLf
                    Else
                        texto = vbCrLf & vbCrLf & Strings.Space(24) & vbTab & ">>> " + Strings.UCase(texto) & vbCrLf
                    End If
                ElseIf CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Modulo, "", False)) > 0UI And CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Rotina, "", False)) > 0UI Then
                    texto = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(DateTime.Now) + Strings.Space(3) & vbTab + Strings.Space(3) & "< " & Modulo & " " & Rotina & " - " & texto & " >"
                ElseIf CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Modulo, "", False)) > 0UI And Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Rotina, "", False) = 0 Then
                    texto = Convert.ToString(DateTime.Now) + Strings.Space(3) & vbTab + Strings.Space(3) & "< " & Modulo & " - " & texto & " >"
                ElseIf Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Modulo, "", False) = 0 And CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Rotina, "", False)) > 0UI Then
                    texto = Convert.ToString(DateTime.Now) + Strings.Space(3) & vbTab + Strings.Space(3) & "< " & Rotina & " - " & texto & " >"
                Else
                    texto = Convert.ToString(DateTime.Now) + Strings.Space(3) & vbTab + Strings.Space(3) & "< " & texto & " >"
                End If
            End If

            If Rejeicao Then
                Dim str As String = texto
                texto = vbCrLf & Strings.Space(24) & vbTab & "-----------------------***  REJEICAO ***---------------------------" & vbCrLf & texto
                texto = Convert.ToString(DateTime.Now) + Strings.Space(3) & vbTab + Strings.Space(3) & str
                texto = texto & vbCrLf & Strings.Space(24) & vbTab & "--------------------------------------------------------------------" & vbCrLf
            End If

            If TrataErro Then
                Dim str As String = texto
                texto = vbCrLf & Strings.Space(24) & vbTab & "-----------------------***  ERRO ***---------------------------" & vbCrLf
                texto = Convert.ToString(DateTime.Now) + Strings.Space(3) & vbTab + Strings.Space(3) & str
                texto = texto & vbCrLf & Strings.Space(24) & vbTab & "--------------------------------------------------------------------" & vbCrLf
            End If

            Dim path As String
            Dim str1 As String

            If System.IO.File.Exists(Application.StartupPath & "\LOGS") Then
                path = Application.StartupPath & "\LOGS"
                str1 = "LinearNFCe.log"
            Else
                str1 = "LinearNFCe" & Strings.Format(CObj(DateTime.Now), "dd-MM-yyyy") & ".log"
                path = AppDomain.CurrentDomain.BaseDirectory & "Logs\" + Strings.Format(CObj(DateTime.Now.Year), "0000") & "\" + Strings.Format(CObj(DateTime.Now.Month), "00")
            End If

            If Not Directory.Exists(path) Then Directory.CreateDirectory(path)
            If Not System.IO.File.Exists(path & "\" & str1) Then System.IO.File.CreateText(path & "\" & str1).Close()
            Dim streamWriter As StreamWriter = New StreamWriter(path & "\" & str1, True)
            streamWriter.WriteLine(texto)
            streamWriter.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Function getSHA1Hash(ByVal strToHash As String) As String
        Dim hash As Byte() = New SHA1CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(strToHash))
        Dim str As String = ""
        Dim numArray As Byte() = hash
        Dim index As Integer = 0

        While index < numArray.Length
            Dim num As Byte = numArray(index)
            str += num.ToString("x2")
            index += 1
        End While

        Return str
    End Function

    Public Function ValidaCEP(ByRef cep As String) As Boolean
        cep = RemoveTelefone(cep)
        If cep.Length <> 8 OrElse cep = "00000000" Then Return False
        Return Regex.IsMatch(cep, "[0-9]{5}[0-9]{3}")
    End Function

    Public Function ValidaEmail(ByVal email As String) As Boolean
        Return Regex.IsMatch(email, "(?<user>[^@]+)@(?<host>.+)")
    End Function

    Public Function modulo11(ByVal chaveNFE As String) As Integer
        If chaveNFE.Length <> 43 Then
            Throw New Exception("Chave inválida, não é possível calcular o digito verificador")
        End If


        Dim baseCalculo As String = "4329876543298765432987654329876543298765432"
        Dim somaResultados As Integer = 0

        For i As Integer = 0 To chaveNFE.Length - 1
            Dim numNF As Integer = Convert.ToInt32(chaveNFE(i).ToString())
            Dim numBaseCalculo As Integer = Convert.ToInt32(baseCalculo(i).ToString())

            somaResultados += (numBaseCalculo * numNF)
        Next

        Dim restoDivisao As Integer = (somaResultados Mod 11)
        Dim dv As Integer = 11 - restoDivisao
        If (dv = 0) OrElse (dv > 9) Then
            Return 0
        Else
            Return dv
        End If
    End Function

    Public Function verificar_regexiste(ByVal sql As String)
        Dim ret As Integer = 0
        Dim dr As SQLiteDataReader
        conectar_sqlite()

        Dim SQLcommand As SQLiteCommand
        SQLcommand = Conn.CreateCommand
        SQLcommand.CommandText = sql
        dr = SQLcommand.ExecuteReader()

        While (dr.Read())
            ret += 1
        End While

        dr.Close()
        SQLcommand.Dispose()
        Conn.Close()

        Return ret
    End Function

    Public Function ret_valor_banco_sql(ByVal sql As String, ByVal campo_ret As String)
        Dim ret As String
        Dim dr As SQLiteDataReader

        conectar_sqlite()

        Dim SQLcommand As SQLiteCommand

        SQLcommand = Conn.CreateCommand

        SQLcommand.CommandText = sql

        dr = SQLcommand.ExecuteReader()


        While dr.Read()


            ret = dr("" & campo_ret & "")

        End While



        dr.Close()
        SQLcommand.Dispose()
        Conn.Close()

        Return ret
    End Function
    Public Function ret_valor_banco(ByVal tabela As String, ByVal campo_pesq As String, ByVal valor As String, ByVal campo_ret As String)
        Dim ret As String
        Dim dr As SQLiteDataReader

        conectar_sqlite()

        Dim SQLcommand As SQLiteCommand

        SQLcommand = Conn.CreateCommand

        SQLcommand.CommandText = "select * from " & tabela & " where " & campo_pesq & " = '" & valor & "'"

        dr = SQLcommand.ExecuteReader()


        While dr.Read()


            ret = dr("" & campo_ret & "").ToString

        End While



        dr.Close()
        SQLcommand.Dispose()
        Conn.Close()

        Return ret
    End Function

    Public Function executa_query(ByVal sql As String) As Boolean
        Dim ret As Boolean

        Try
            conectar_sqlite()
            Dim insertSQL2 As SQLiteCommand = New SQLiteCommand(sql, Conn)
            insertSQL2.ExecuteNonQuery()
            Conn.Close()
            ret = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "erro execute query")
        End Try


        Return ret
    End Function

    Public Function format_val_mysql_ret(ByVal valor As String) As String
        If valor <> "" Then
            valor = valor.Replace(".", ",")

            valor = Format(CDec(valor), "#,##0.00")

            Return valor
        Else
            valor = "0,00"
        End If
    End Function

    Public Function format_val_mysql_ent(ByVal valor As String) As String
        If valor <> "" Then
            valor = valor.Replace(".", "")
            valor = valor.Replace(",", ".")
            Return valor
        Else
            valor = "0.00"
        End If
    End Function
End Module