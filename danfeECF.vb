Imports System.Xml
Imports MessagingToolkit.QRCode.Codec
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports System.Drawing.Printing
Imports System.Security.Cryptography
Imports System.Data.SQLite
Imports System.Text

Module danfeECF
    Dim cnpj_dest As String, rv_cli As String, vlr_compra_cli As String, nrnfc As String
    Public NFCe_CSC As String = empresa.sCSC
    Public NFCe_ID_Token As String = empresa.Idtoken
    Public cAux As String
    Private iRet As Integer
    Private strXml As String
    Private strTextoVias As String
    Private cPortaImp As String
    Private TPAmbiente As Integer
    Private versao_layout As String
    Private TipoCod_CProd As String
    Private linhasPorPagina As Integer
    Private posicaoDaLinha As Decimal
    Private linhaAtual As Integer
    Private paginaAtual As Integer
    Private margemEsq As Single
    Private margemSup As Single
    Private margemDir As Single
    Private margemInf As Single
    Private caneta As Pen
    Private fonteTitulo As Font
    Private fonteRodape As Font
    Private fonteNormal As Font
    Private fonteColuna As Font
    Private tipoFonte As String
    Private ArquivoFonte As StreamReader
    Private mCaminhoLogo As String
    Private mReduzido As Boolean

    Private Sub rptDanfeNFCe(ByVal sender As Object, ByVal Relatorio As PrintPageEventArgs)
        'Try
        Dim hashtable As Hashtable = New Hashtable()
        Dim TamLetra As Integer = 6
        Dim num1 As Integer = 0
        Dim chv As String
        ' Dim clsPlugin As clsPlugin = New clsPlugin()
        Dim Left1 As String = ""
        margemEsq = 5.0F
        margemSup = 5.0F
        margemDir = 5.0F
        margemInf = 5.0F
        posicaoDaLinha = New Decimal()
        linhaAtual = 1
        fonteTitulo = New Font(tipoFonte, CSng(TamLetra), FontStyle.Bold)
        fonteRodape = New Font(tipoFonte, CSng(TamLetra))
        fonteNormal = New Font(tipoFonte, CSng(TamLetra))
        fonteColuna = New Font(tipoFonte, CSng(TamLetra))
        '  caneta.Width = 2.0F

        '  caneta.LineJoin = LineJoin.Bevel
        Dim num2 As Integer = 64
        Dim xmlDocument As XmlDocument = New XmlDocument()
        xmlDocument.Load(strXml)
        Dim Data As String

        Try

            For Each xmlElement As XmlElement In xmlDocument.GetElementsByTagName("Reference")

                Try

                    For Each childNode As XmlElement In xmlElement.ChildNodes
                        If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(childNode.Name, "DigestValue", False) = 0 Then Data = childNode.InnerText
                    Next

                Finally
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try
            Next

        Finally
            Dim enumerator As IEnumerator
            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
        End Try

        Dim attribute As String
        Dim str1 As String

        Try

            For Each xmlElement As XmlElement In xmlDocument.GetElementsByTagName("NFe")

                Try

                    For Each childNode As XmlElement In xmlElement.ChildNodes

                        If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(childNode.Name, "infNFe", False) = 0 Then
                            attribute = childNode.GetAttribute("Id")
                            str1 = childNode.GetAttribute("versao")

                            chv = childNode.Attributes.ItemOf("Id").InnerText.Substring(3, 44)
                        End If
                    Next

                Finally
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try
            Next

        Finally
            Dim enumerator As IEnumerator
            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
        End Try

        If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "", False) = 0 Then str1 = "4.00"

        Try

            For Each xmlElement As XmlElement In xmlDocument.GetElementsByTagName("ide")

                Try

                    For Each childNode As XmlElement In xmlElement.ChildNodes
                        hashtable.Add(CObj(childNode.Name), CObj(childNode.InnerText))
                    Next

                Finally
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try
            Next

        Finally
            Dim enumerator As IEnumerator
            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
        End Try

        Dim hex As String = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("dhEmi")))
        Dim str2 As String = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("tpAmb")))
        Dim Left2 As String = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("tpEmis")))
        Dim InputStr As String = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("serie")))
        Dim str3 As String = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("nNF")))
        Dim num3 As Long = Microsoft.VisualBasic.CompilerServices.Conversions.ToLong(hashtable(CObj("cNF")))

        Dim num4 As Integer = (CInt(Math.Round(Conversion.Val("001"))))


        hashtable.Clear()
        Dim innerText1 As String

        Try

            For Each xmlElement As XmlElement In xmlDocument.GetElementsByTagName("dest")

                Try

                    For Each childNode As XmlElement In xmlElement.ChildNodes
                        If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(childNode.Name, "CNPJ", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(childNode.Name, "CPF", False) = 0 Then innerText1 = childNode.InnerText
                    Next

                Finally
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try
            Next

        Finally
            Dim enumerator As IEnumerator
            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
        End Try

        Dim str4 As String = ""

        Try

            For Each xmlElement1 As XmlElement In xmlDocument.GetElementsByTagName("emit")

                Try
                    For Each childNode As XmlElement In xmlElement1.ChildNodes
                        If CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(childNode.Name, "enderEmit", False)) > 0UI Then hashtable.Add(CObj(childNode.Name), CObj(childNode.InnerText))
                    Next
                Catch ex As Exception
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try


                Try

                    For Each xmlElement2 As XmlElement In xmlElement1.GetElementsByTagName("enderEmit")

                        Try

                            For Each childNode As XmlElement In xmlElement2.ChildNodes
                                hashtable.Add(CObj(childNode.Name), CObj(childNode.InnerText))
                            Next

                        Finally
                            Dim enumerator As IEnumerator
                            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                        End Try
                    Next

                Finally
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try
            Next

        Finally
            Dim enumerator As IEnumerator
            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
        End Try

        Relatorio.PageSettings.Margins.Left = 200
        Dim num5 As Integer

        If File.Exists(mCaminhoLogo) Then
            Relatorio.Graphics.DrawImage(Image.FromFile(mCaminhoLogo), 2, 2, 40, 40)
            num5 = 36
        Else
            num5 = 0
        End If

        Dim xmllist As System.Xml.XmlNodeList
        Dim cnpj As String, nome As String
        xmllist = xmlDocument.GetElementsByTagName("emit")
        For Each xmlnode In xmllist
            If Not xmlnode("CNPJ") Is Nothing Then
                cnpj = xmlnode("CNPJ").InnerText
            End If
            If Not xmlnode("xNome") Is Nothing Then
                nome = xmlnode("xNome").InnerText
            End If
        Next

        cnpj = MascSTR(cnpj, "##.###.###/####-##")
        ' cnpj = "154665545886525885555554888676676"
        '  num2 = cnpj.Length + nome.Length



        Dim str5 As String = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("UF")))


        Dim s1 As String = fFormata("CNPJ: " & cnpj & " " & nome, " ", "C", num2, True, False)
        iRet = FormataTX(Relatorio, s1, TamLetra, 1, 1, True, "CNPJ: " & cnpj & " " & nome)

        Dim local1 As Integer
        Dim num6 As Integer = linhaAtual + 1
        local1 = num6

        Dim s33 As String = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(hashtable(CObj("xLgr")), CObj(", ")), hashtable(CObj("nro"))), CObj(", ")), hashtable(CObj("xBairro"))), CObj(" - ")), hashtable(CObj("xMun")) & "/" & hashtable(CObj("UF"))))
        Dim s3 As String = fFormata(Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(hashtable(CObj("xLgr")), CObj(", ")), hashtable(CObj("nro"))), CObj(", ")), hashtable(CObj("xBairro"))), CObj(" - ")), hashtable(CObj("xMun")) & "/" & hashtable(CObj("UF")))), " ", "C", num2, True, False)
        '  iRet = FormataTX(Relatorio, s3, TamLetra, 0, 1)
        iRet = FormataTX(Relatorio, s3, TamLetra, 0, 1, True, s33)



        iRet = FormataTX(Relatorio, "-----------------------------------------------------------------------------------------------------------", 5, 1, 1)
        Dim s4 As String = fFormata("Documento Auxiliar de Nota Fiscal de Consumidor", " ", "C", 70, True, False)
        iRet = FormataTX(Relatorio, s4, 7, 0, 1)
        iRet = FormataTX(Relatorio, "-----------------------------------------------------------------------------------------------------------", 5, 1, 1)

        Dim local3 As Integer
        Dim num8 As Integer = linhaAtual + 1
        local1 = num8



        If chv.Substring(34, 1) = "9" Then

            Dim tex As String = "EMITIDA EM CONTINGENCIA"
            Dim strTexto1 As String = fFormata("EMITIDA EM CONTINGENCIA", " ", "C", 95, True, False)
            iRet = FormataTX(Relatorio, strTexto1, TamLetra, 1, 1, False, tex)
            Dim strTexto2 As String = fFormata("Pendente de autoruzação", " ", "C", 105, True, False)
            iRet = FormataTX(Relatorio, strTexto2, TamLetra, 1, 1)


        End If

        Dim cont As Integer = 0
        '  iRet = FormataTX(Relatorio, "-----------------------------------------------------------------------------", TamLetra, 1, 1)
        If Not mReduzido Then
            Dim strTexto As String = "Código  Descrição                                          Qtde UN  Vl Unit    Vl Total"
            iRet = FormataTX(Relatorio, strTexto, TamLetra, 1, 1)
        End If

        Try

            For Each obj1 As Object In xmlDocument.GetElementsByTagName("det")
                Dim objectValue As Object = RuntimeHelpers.GetObjectValue(obj1)

                Try

                    For Each xmlElement As XmlElement In CType(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue, CType(Nothing, System.Type), "childNodes", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, System.Type()), CType(Nothing, Boolean())), IEnumerable)

                        If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlElement.Name, "prod", False) = 0 Then

                            Try

                                For Each childNode As XmlElement In xmlElement.ChildNodes
                                    hashtable.Add(CObj(childNode.Name), CObj(childNode.InnerText))
                                Next

                            Finally
                                Dim enumerator As IEnumerator
                                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                            End Try

                            Dim num9 As Integer

                            If Not mReduzido Then
                                Dim str6 As String = ""
                                If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "", False) = 0 Then Left1 = "0"

                                If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "1", False) = 0 Then
                                    Dim obj2 As Object = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(CObj(("nrv = " & Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Conversion.Val(CObj(num3))) & " and serie = " + Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Conversion.Val(InputStr)) & " and caixa = " + Microsoft.VisualBasic.CompilerServices.Conversions.ToString(num4) & " and ")), CObj(("data = '" & Strings.Format(CObj(Microsoft.VisualBasic.CompilerServices.Conversions.ToDate(Strings.Left(hex, 10))), "yyyy-MM-dd") & "' and cod_red = " + Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(hashtable(CObj("cProd"))))) & " and "))), Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(CObj("quantidade = "), hashtable(CObj("qCom"))), CObj(" and vlrunitario = ")), hashtable(CObj("vUnCom"))), CObj(" and cancelado = 0")))
                                    str6 = Microsoft.VisualBasic.CompilerServices.Conversions.ToString("00001")
                                End If

                                If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "0", False) = 0 Or Conversion.Val(str6) = 0.0 Then str6 = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("cProd")))
                                Dim strTexto As String = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(CObj((fFormata(str6, "0", "E", 8, True, False) & " " + fFormata(Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("xProd"))), " ", "D", 30, 0, True, False) & "" + fFormata(Strings.FormatCurrency(CObj(Strings.Replace(Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("qCom"))), ".", ",", 1, -1, CompareMethod.Binary)), 3, Microsoft.VisualBasic.TriState.[False], Microsoft.VisualBasic.TriState.[True], Microsoft.VisualBasic.TriState.UseDefault), " ", "E", 7, True, False).Replace("$", ""))), hashtable(CObj("uCom"))), CObj(fFormata(Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("vUnCom"))), " ", "E", 7, True, False)))) & " " + fFormata(Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("vProd"))), " ", "E", 7, True, False)
                                Dim q As String = Format(CDec(hashtable(CObj("qCom")).Replace(".", ",")), "###0.000")
                                cont += 1
                                iRet = FormataTX(Relatorio, strTexto, TamLetra, 0, 1, False, "prod", hashtable(CObj("cProd")), hashtable(CObj("xProd")), q & " " & hashtable(CObj("uCom")), hashtable(CObj("vUnCom")), hashtable(CObj("vProd")))

                                If Not Microsoft.VisualBasic.CompilerServices.Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(hashtable(CObj("vDesc")))) Then
                                End If

                                If Not Microsoft.VisualBasic.CompilerServices.Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(hashtable(CObj("vOutro")))) Then
                                End If
                            End If

                            hashtable.Clear()
                            str4 = ""
                        ElseIf Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlElement.Name, "infAdProd", False) = 0 Then
                            Dim strTexto As String = Strings.Trim(Strings.Replace(xmlElement.InnerText, ",", ".", 1, -1, CompareMethod.Binary)) & vbCrLf
                            iRet = FormataTX(Relatorio, strTexto, TamLetra, 1, 1)
                        End If
                    Next

                Finally
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try
            Next

        Finally
            Dim enumerator As IEnumerator
            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
        End Try

        ' iRet = FormataTX(Relatorio, "------------------------------------------", TamLetra, 1, 1)

        Dim strTexto3 As String = Strings.Format(CObj(cont), "000")
        iRet = FormataTX(Relatorio, "", TamLetra, 0, 1, False, "pag", "Qtde. Total de Itens", strTexto3)

        Dim texto1 As String
        Dim str7 As String
        Dim str8 As String

        Try

            For Each xmlElement1 As XmlElement In xmlDocument.GetElementsByTagName("total")

                Try

                    For Each xmlElement2 As XmlElement In xmlElement1.GetElementsByTagName("ICMSTot")

                        Try

                            For Each childNode As XmlElement In xmlElement2.ChildNodes
                                hashtable.Add(CObj(childNode.Name), CObj(childNode.InnerText))
                            Next

                        Finally
                            Dim enumerator As IEnumerator
                            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                        End Try
                    Next

                Finally
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try

                texto1 = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("vTotTrib")))
                str7 = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("vNF")))
                str8 = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("vICMS")))
                Dim texto2 As String = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("vOutro")))
                Dim texto3 As String = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("vDesc")))
                Dim s5 As String = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("vProd")))
                str4 = strTexto3 & New String("-"c, num2) & vbCrLf

               
                xmllist = xmlDocument.GetElementsByTagName("ICMSTot")
                Dim vpag As String, vdesc As String
                For Each xmlnode In xmllist
                    vpag = Format(CDec(xmlnode("vNF").InnerText.ToString.Replace(".", ",")), "#,##0.00")
                    vdesc = Format(CDec(xmlnode("vDesc").InnerText.ToString.Replace(".", ",")), "#,##0.00")
                Next

                iRet = FormataTX(Relatorio, "", TamLetra, 0, 1, False, "pag", "Desconto R$", vdesc)

                iRet = FormataTX(Relatorio, "", TamLetra, 0, 1, False, "pag", "Valor a Pagar R$", vpag)

                strTexto3 = "FORMA DE PAGAMENTO                                         VALOR PAGO(R$)"
                iRet = FormataTX(Relatorio, strTexto3, TamLetra, 0, 1)
                hashtable.Clear()
            Next

        Finally
            Dim enumerator As IEnumerator
            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
        End Try

        Dim xmlElement3 As XmlElement

        If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "3.10", False) <> 0 Then

            If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "4.00", False) = 0 Then

                Try

                    For Each xmlElement1 As XmlElement In xmlDocument.GetElementsByTagName("pag")

                        Try

                            For Each childNode1 As XmlElement In xmlElement1.ChildNodes

                                If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(childNode1.Name, "detPag", False) = 0 Then

                                    Try

                                        For Each childNode2 As XmlElement In childNode1.ChildNodes
                                            hashtable.Add(CObj(childNode2.Name), CObj(childNode2.InnerText))

                                            If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(childNode2.Name, "card", False) = 0 Then

                                                Try

                                                    For Each xmlElement2 As XmlElement In xmlElement1.GetElementsByTagName("card")
                                                        xmlElement3 = xmlElement2
                                                    Next

                                                Finally
                                                    Dim enumerator As IEnumerator
                                                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                                                End Try
                                            End If
                                        Next

                                    Finally
                                        Dim enumerator As IEnumerator
                                        If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                                    End Try

                                    Dim texto2 As String = RetMPDesc(Microsoft.VisualBasic.CompilerServices.Conversions.ToInteger(hashtable(CObj("tPag"))))
                                    Dim strTexto1 As String = texto2 & fFormata(Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("vPag"))), ".", "E", 86, texto2.Length, True, False)


                                    iRet = FormataTX(Relatorio, texto2, TamLetra, 0, 1, False, "pag", texto2, hashtable(CObj("vPag")))
                                    hashtable.Clear()
                                End If
                            Next

                        Finally
                            Dim enumerator As IEnumerator
                            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                        End Try
                    Next

                Finally
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try
            End If
        Else

            Try

                For Each xmlElement1 As XmlElement In xmlDocument.GetElementsByTagName("pag")

                    Try

                        For Each childNode As XmlElement In xmlElement1.ChildNodes
                            hashtable.Add(CObj(childNode.Name), CObj(childNode.InnerText))

                            If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(childNode.Name, "card", False) = 0 Then

                                Try

                                    For Each xmlElement2 As XmlElement In xmlElement1.GetElementsByTagName("card")
                                        xmlElement3 = xmlElement2
                                    Next

                                Finally
                                    Dim enumerator As IEnumerator
                                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                                End Try
                            End If
                        Next

                    Finally
                        Dim enumerator As IEnumerator
                        If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                    End Try


                    Dim texto2 As String = RetMPDesc(Microsoft.VisualBasic.CompilerServices.Conversions.ToInteger(hashtable(CObj("tPag"))))
                    Dim strTexto1 As String = texto2 & fFormata(Microsoft.VisualBasic.CompilerServices.Conversions.ToString(hashtable(CObj("vPag"))), ".", "E", 86, texto2.Length, True, False)

                    iRet = FormataTX(Relatorio, texto2, TamLetra, 0, 1, False, "pag", texto2, hashtable(CObj("vPag")))
                    hashtable.Clear()
                Next

            Finally
                Dim enumerator As IEnumerator
                If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
            End Try
        End If

        If Microsoft.VisualBasic.CompilerServices.Conversions.ToDouble(str2) = 2.0 Then
            Dim strTexto1 As String = fFormata("EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL ", " ", "C", num2, True, False)
            iRet = FormataTX(Relatorio, strTexto1, TamLetra, 1, 1)
            str4 = ""
        End If


        iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
        Dim strTexto6 As String = fFormata("        Consulte pela Chave de Acesso em", " ", "C", num2, True, False)
        iRet = FormataTX(Relatorio, strTexto6, 7, 1, 1)
        Dim strTexto7 As String = fFormata("        http://nfce.fazenda.mg.gov.br/portalnfce", " ", "C", num2, True, False)
        iRet = FormataTX(Relatorio, strTexto7, 7, 1, 1)
        Dim str9 As String = fFormata("http://nfce.fazenda.mg.gov.br/portalnfce", " ", "C", num2, True, False)
        str4 = ""
        Dim strTexto8 As String = fFormata("      " & MascSTR(Strings.Mid(attribute, 4), "#### #### #### #### #### #### #### #### #### #### ####"), " ", "C", num2, True, False) & vbCrLf
        iRet = FormataTX(Relatorio, strTexto8, TamLetra, 0, 1)
        Dim Instance As Object = CObj(Strings.Split(hex, "T", -1, CompareMethod.Binary))
        cAux = Convert.ToDateTime(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateIndexGet(Instance, New Object(0) {CObj(0)}, CType(Nothing, String())))).ToString("dd/MM/yyyy")

        '   iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
        Dim serie As String
        Dim NOMEDEST As String, cnpjdest As String, endereco As String
        xmllist = xmlDocument.GetElementsByTagName("infNFe")
        Dim dataemi As Date

        For Each xmlnode In xmllist
            serie = xmlnode("ide")("serie").InnerText
            dataemi = xmlnode("ide")("dhEmi").InnerText

            If Not xmlnode("dest") Is Nothing Then

                If Not xmlnode("dest")("xNome") Is Nothing Then
                    NOMEDEST = xmlnode("dest")("xNome").InnerText
                End If
                If Not xmlnode("dest")("CNPJ") Is Nothing Then
                    cnpjdest = MascSTR(xmlnode("dest")("CNPJ").InnerText, "##.###.###/####-##")
                End If

                If Not xmlnode("dest")("CPF") Is Nothing Then
                    cnpjdest = MascSTR(xmlnode("dest")("CPF").InnerText, "###.###.###-##")
                End If

                If Not xmlnode("dest")("enderDest")("xLgr") Is Nothing Then
                    endereco = xmlnode("dest")("enderDest")("xLgr").InnerText & ", " & xmlnode("dest")("enderDest")("nro").InnerText & ", " & xmlnode("dest")("enderDest")("xBairro").InnerText & ", " & xmlnode("dest")("enderDest")("xMun").InnerText & "/" & xmlnode("dest")("enderDest")("UF").InnerText
                End If
            End If
        Next


        If cnpjdest <> "" Then
            iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
            Dim strTexto As String = fFormata("DADOS DO CONSUMIDOR", " ", "C", 50, True, False)
            iRet = FormataTX(Relatorio, strTexto, TamLetra, 1, 1, True, strTexto)

            Dim s11 As String = fFormata("CNPJ/CPF: " & cnpjdest & " " & NOMEDEST, " ", "C", num2, True, False)
            iRet = FormataTX(Relatorio, s11, TamLetra, 1, 1, True, "CNPJ/CPF: " & cnpjdest & " " & NOMEDEST)
            ' MsgBox(endereco)
            Dim s44 As String = fFormata(endereco, " ", "C", 80, True, False)
            iRet = FormataTX(Relatorio, s44, TamLetra, 0, 1, True, s44)
        End If

        iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)

        serie = serie.PadLeft(3, "0")

        Dim s7 As String = "Emissao: " & Convert.ToDateTime(dataemi).ToString("dd/MM/yyyy HH:mm:ss") & vbCrLf
        Dim s6 As String = "Numero: " & Strings.Format(CObj(Microsoft.VisualBasic.CompilerServices.Conversions.ToLong(str3)), "000000000") & "    Serie: " & serie & "   " & s7

        iRet = FormataTX(Relatorio, "", TamLetra, 1, 1)
        Relatorio.Graphics.DrawString(s6, fonteTitulo, Brushes.Black, margemEsq, Convert.ToSingle(posicaoDaLinha), New StringFormat())

        Dim innerText2 As String
        Dim innerText3 As String

        Try

            For Each xmlElement1 As XmlElement In xmlDocument.GetElementsByTagName("infProt")

                Try

                    For Each childNode As XmlElement In xmlElement1.ChildNodes
                        If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(childNode.Name, "dhRecbto", False) = 0 Then innerText2 = childNode.InnerText
                        If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(childNode.Name, "nProt", False) = 0 Then innerText3 = childNode.InnerText
                    Next

                Finally
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try
            Next

        Finally
            Dim enumerator As IEnumerator
            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
        End Try

        If chv.Substring(34, 1) <> "9" Then
            Dim s100 As String = fFormata("              Protocolo de Autorização: " & innerText3, " ", "C", num2, True, False)
            iRet = FormataTX(Relatorio, s100, TamLetra, 1, 1)
            s100 = fFormata("              Data de autorização: " & Convert.ToDateTime(innerText2).ToString("dd/MM/yyyy HH:mm:ss"), " ", "C", num2, True, False)
            iRet = FormataTX(Relatorio, s100, TamLetra, 1, 1)
        End If

        ' s100 = fFormata("Data de autorização: " & Convert.ToDateTime(innerText2).ToString("dd/MM/yyyy HH:mm:ss"), "C", num2, True, False)
        ' iRet = FormataTX(Relatorio, "", TamLetra, 1, 1)

        '  Relatorio.Graphics.DrawString(s7, fonteTitulo, Brushes.Black, margemEsq + 102.0F, Convert.ToSingle(posicaoDaLinha), New StringFormat())
        hex = StrToHex(hex)
        Data = If(Data IsNot Nothing, StrToHex(Data), CalculaDigestValueXML_MDL(strXml, True))
        cAux = "chNFe=" & Strings.Mid(attribute, 4) & "&nVersao=100&tpAmb=" & str2
        If CUInt(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(innerText1, "", False)) > 0UI Then cAux = cAux & "&cDest=" & innerText1
        cAux = cAux & "&dhEmi=" & hex
        cAux = cAux & "&vNF=" & str7
        cAux = cAux & "&vICMS=" & str8
        cAux = cAux & "&digVal=" & Data
        cAux = cAux & "&cIdToken=" + Strings.Format(CObj(Conversion.Val(NFCe_ID_Token)), "000000")

        Dim shA1Hash As String
        ' Dim xmllist As System.Xml.XmlNodeList

        xmllist = xmlDocument.GetElementsByTagName("infNFe")

        For Each xmlnode In xmllist
            If Not xmlnode("infNFeSupl") Is Nothing Then
                shA1Hash = xmlnode("infNFeSupl")("qrCode").InnerText
            End If

        Next

        ' Dim shA1Hash As String = getSHA1Hash(cAux + Strings.UCase(NFCe_CSC))
        Dim content As String = str9 & cAux & "&cHashQRCode=" & shA1Hash


        Relatorio.Graphics.DrawImage(New PictureBox() With {
            .Image = (CType(New QRCodeEncoder() With {
                .QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE,
                .QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M,
                .QRCodeVersion = 0,
                .QRCodeScale = 3
            }.Encode(content), Image))
        }.Image, margemEsq + 90, Convert.ToSingle(posicaoDaLinha) - 2.0F + 3 * fonteNormal.GetHeight(Relatorio.Graphics), 100.0F, 100.0F)
        iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
        iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)

        If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "1", False) = 0 Then
            iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
            iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
            iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
            iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
        Else
            iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
            iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
            iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
        End If

        iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
        iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)
        iRet = FormataTX(Relatorio, "", TamLetra, 0, 1)

        Dim strTexto9 As String = " Trib. Totais Incidentes (lei Federal 12.741/2012) R$ " & fFormata(texto1, " ", "C", (num2 - 40), True, False) & vbCrLf


        iRet = FormataTX(Relatorio, strTexto9, TamLetra, 1, 1)
        iRet = FormataTX(Relatorio, "---------------------------------------------------------------------------------------------------------", 5, 1, 1)
        Try

            For Each xmlElement1 As XmlElement In xmlDocument.GetElementsByTagName("infAdic")

                Try

                    For Each childNode As XmlElement In xmlElement1.ChildNodes

                        If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(childNode.Name, "infCpl", False) = 0 Then
                            Dim strTexto1 As String = fFormata("   INFORMACOES ADICIONAIS DE INTERESSE DO CONTRIBUINTE", " ", "C", num2, True, False) & vbCrLf
                            iRet = FormataTX(Relatorio, strTexto1, 5, 1, 1)
                            Dim strTexto2 As String = Strings.Replace(childNode.InnerText, "|", vbCrLf, 1, -1, CompareMethod.Binary)
                            iRet = FormataTX(Relatorio, strTexto2, TamLetra, 0, 1)
                        ElseIf Microsoft.VisualBasic.CompilerServices.Operators.CompareString(childNode.Name, "infAdFisco", False) = 0 Then
                            Dim strTexto1 As String = fFormata("Informacoes de Interesse do Fisco", " ", "C", num2, True, False) & vbCrLf
                            iRet = FormataTX(Relatorio, strTexto1, TamLetra, 1, 1)
                            Dim strTexto2 As String = Strings.Replace("" & childNode.InnerText & vbCrLf, "|", vbCrLf, 1, -1, CompareMethod.Binary)
                            iRet = FormataTX(Relatorio, strTexto2, TamLetra, 0, 1)
                            str4 = ""
                        End If
                    Next

                Finally
                    Dim enumerator As IEnumerator
                    If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
                End Try
            Next

        Finally
            Dim enumerator As IEnumerator
            If TypeOf enumerator Is IDisposable Then TryCast(enumerator, IDisposable).Dispose()
        End Try

        str4 = ""
        ' iRetTrImp = 1

    End Sub

    Private Function FormataTX(ByRef Relatorio As PrintPageEventArgs, ByVal strTexto As String, ByVal TamLetra As Integer, ByVal Bold As Integer, ByVal NewLine As Integer, Optional ByVal par As Boolean = False, Optional ByVal tex As String = "", Optional ByVal codigo As String = "", Optional ByVal desc As String = "", Optional ByVal qtde As String = "", Optional ByVal vlrunit As String = "", Optional ByVal vlrtotal As String = "") As Integer
        linhasPorPagina += (CInt(Math.Round((CDbl(Relatorio.MarginBounds.Height) / CDbl(fonteNormal.GetHeight(Relatorio.Graphics)) - 10.0))))
        posicaoDaLinha += New Decimal(margemSup + CSng(linhaAtual) * fonteNormal.GetHeight(Relatorio.Graphics))
        fonteNormal = If(Bold <> 1, New Font(tipoFonte, CSng(TamLetra)), New Font(tipoFonte, CSng(TamLetra), FontStyle.Bold))


        If tex = "EMITIDA EM CONTINGENCIA" Then
            Relatorio.Graphics.FillRectangle(Brushes.LightGray, 0, posicaoDaLinha - 5, 788, 30)

        End If

        If tex <> "prod" Then

            If tex <> "pag" Then
                If par = False Then
                    Relatorio.Graphics.DrawString(strTexto, fonteNormal, Brushes.Black, margemEsq, Convert.ToSingle(posicaoDaLinha), New StringFormat())
                Else

                    If CDec(tex.Length) < 48 Then
                        Relatorio.Graphics.DrawString(strTexto, fonteNormal, Brushes.Black, margemEsq, Convert.ToSingle(posicaoDaLinha), New StringFormat())
                    Else

                        fonteNormal = New Font(tipoFonte, CSng(8))
                        Dim Alinhamento2 As New StringFormat()
                        Alinhamento2.Alignment = StringAlignment.Center
                        Relatorio.Graphics.DrawString(strTexto, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento2)
                        posicaoDaLinha += 5
                    End If

                End If

            Else

                Dim Alinhamento3 As New StringFormat()
                Alinhamento3.Alignment = StringAlignment.Far
                Dim Alinhamento As New StringFormat()
                Alinhamento.Alignment = StringAlignment.Near
                Dim Font As New Font("Times New Roman", 7, FontStyle.Bold)

                Relatorio.Graphics.DrawString(codigo, Font, Brushes.Black, New RectangleF(6, posicaoDaLinha, 190, 30), Alinhamento)
                Relatorio.Graphics.DrawString(desc, Font, Brushes.Black, New RectangleF(91, posicaoDaLinha, 188, 30), Alinhamento3)
            End If

        End If

        If tex = "prod" Then
            Dim Alinhamento3 As New StringFormat()
            Alinhamento3.Alignment = StringAlignment.Far
            Dim Alinhamento As New StringFormat()
            Alinhamento.Alignment = StringAlignment.Near
            vlrunit = Format(CDec(vlrunit.Replace(".", ",")), "#,##0.000")
            vlrtotal = Format(CDec(vlrtotal.Replace(".", ",")), "#,##0.00")

            Relatorio.Graphics.DrawString(codigo, fonteNormal, Brushes.Black, New RectangleF(4, posicaoDaLinha, 45, 30), Alinhamento)

            Relatorio.Graphics.DrawString(desc, fonteNormal, Brushes.Black, New RectangleF(40, posicaoDaLinha, 140, 30), Alinhamento)
            Relatorio.Graphics.DrawString(qtde, fonteNormal, Brushes.Black, New RectangleF(175, posicaoDaLinha, 190, 30), Alinhamento)
            Relatorio.Graphics.DrawString(vlrunit, fonteNormal, Brushes.Black, New RectangleF(54, posicaoDaLinha, 190, 30), Alinhamento3)
            Relatorio.Graphics.DrawString(vlrtotal, fonteNormal, Brushes.Black, New RectangleF(91, posicaoDaLinha, 190, 30), Alinhamento3)

            If desc.Length > 26 Then
                posicaoDaLinha += 10
            End If
        End If



        Return posicaoDaLinha
    End Function

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class


    Public Function RetMPDesc(ByVal CodMP As Integer) As String
        Select Case CodMP
            Case 1
                Return "Dinheiro"
            Case 2
                Return "Cheque"
            Case 3
                Return "Cartão de Crédito"
            Case 4
                Return "Cartão de Débito"
            Case 5
                Return "Crédito Loja"
            Case 10
                Return "Vale Alimentação"
            Case 11
                Return "Vale Refeição"
            Case 12
                Return "Vale Presente"
            Case 13
                Return "Vale Combustível"
            Case 99
                Return "Outros"
            Case Else
                Return "Outros"
        End Select
    End Function


    Public Function MascSTR(ByVal Txt As String, ByVal Mask As String) As String
        Dim num1 As Integer
        Dim str As String
        Dim num2 As Integer



        num1 = 2
        Dim CounterResult As Object = CObj(1)
        Dim Left As Object = CObj(1)

        If Strings.Len(Txt) = Strings.Len(Mask) Then
            str = ""

        ElseIf Not Microsoft.VisualBasic.CompilerServices.Versioned.IsNumeric(CObj(Txt)) Then
            str = ""

        Else
            Dim obj As Object = CObj(Txt)
            Txt = ""
            Dim LoopForResult As Object

            If Microsoft.VisualBasic.CompilerServices.ObjectFlowControl.ForLoopControl.ForLoopInitObj(CounterResult, CObj(1), CObj(Strings.Len(Mask)), CObj(1), LoopForResult, CounterResult) Then

                Do

                    If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Mid(Mask, Microsoft.VisualBasic.CompilerServices.Conversions.ToInteger(CounterResult), 1), "#", False) <> 0 Then
                        Txt += Strings.Mid(Mask, Microsoft.VisualBasic.CompilerServices.Conversions.ToInteger(CounterResult), 1)
                    Else
                        Txt += Strings.Mid(Microsoft.VisualBasic.CompilerServices.Conversions.ToString(obj), Microsoft.VisualBasic.CompilerServices.Conversions.ToInteger(Left), 1)
                        Left = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Left, CObj(1))
                    End If
                Loop While Microsoft.VisualBasic.CompilerServices.ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult, LoopForResult, CounterResult)
            End If

            str = Txt

        End If


        num2 = -1

        Select Case num1
            Case 2

        End Select
        Try


        Catch ex As Exception
            Dim num3 As Integer

            If TypeOf ex Is Exception And CUInt(num1) > 0UI And num3 = 0 Then
                'SuccessfulFiltering()
            Else
                Throw
            End If
        End Try

        If True Then
            ' ProjectData.SetProjectError(ex)
            ' GoTo label_10
        End If

        ' Throw ProjectData.CreateProjectError(-2146828237)

        '  If num2 <> 0 Then ProjectData.ClearProjectError()
        Return str
    End Function

    Public Function StrToHex(ByRef Data As String) As String
        Dim str1 As String = ""

        While Data.Length > 0
            Dim str2 As String = Conversion.Hex(Strings.Asc(Data.Substring(0, 1).ToString()))
            Data = Data.Substring(1, (Data.Length - 1))
            str1 += str2
        End While

        Return str1
    End Function


    Public Sub ImprimirDANFeNFCeSpool(ByVal pstrXml As String, ByVal nome_print As String, ByVal iTipoImpViz As Integer)
        ' Try
        strXml = pstrXml
        linhaAtual = 1
        posicaoDaLinha = New Decimal()
        Dim printDocument As PrintDocument = New PrintDocument()
        Dim standardPrintController As StandardPrintController = New StandardPrintController()
        Dim num As Integer = CentimetrosParaCentesimasPolegada(0.05)
        printDocument.DefaultPageSettings.Margins = New Margins(num, num, num, num)
        printDocument.PrintController = CType(standardPrintController, PrintController)

        If nome_print <> "" Then
            printDocument.PrinterSettings.PrinterName = nome_print
        End If

        AddHandler printDocument.PrintPage, New Printing.PrintPageEventHandler(AddressOf rptDanfeNFCe)
        Dim objPrintPreview As New PrintPreviewDialog

        '  printDocument.Print()



        'define o formulário como maximizado e com Zoom

        ' With objPrintPreview

        '.Document = printDocument

        ' .WindowState = FormWindowState.Maximized

        ' .PrintPreviewControl.Zoom = 1

        ' .Text = "Relacao de Clientes"

        ' .ShowDialog()


        ' End With


        '   printDocument.PrintPage += New PrintPageEventHandler(AddressOf rptDanfeNFCe)
        Dim obj As Object = CObj(New PrintPreviewDialog())

        If iTipoImpViz = 2 Then
            printDocument.Print()
            printDocument.Print()
        Else
            printDocument.Print()
        End If


    End Sub

    Public Sub Imprimir_operador(ByVal nome_print As String)
        ' Try

        posicaoDaLinha = New Decimal()
        Dim printDocument As PrintDocument = New PrintDocument()
        Dim standardPrintController As StandardPrintController = New StandardPrintController()
        Dim num As Integer = CentimetrosParaCentesimasPolegada(0.05)
        printDocument.DefaultPageSettings.Margins = New Margins(num, num, num, num)
        printDocument.PrintController = CType(standardPrintController, PrintController)



        AddHandler printDocument.PrintPage, New Printing.PrintPageEventHandler(AddressOf rptoperador)
        Dim objPrintPreview As New PrintPreviewDialog

        If nome_print <> "" Then
            printDocument.PrinterSettings.PrinterName = nome_print
        End If

        printDocument.Print()

        Exit Sub

        'define o formulário como maximizado e com Zoom

        With objPrintPreview

            .Document = printDocument

            .WindowState = FormWindowState.Maximized

            .PrintPreviewControl.Zoom = 1

            .Text = "Relacao de Clientes"

            .ShowDialog()


        End With






        '   printDocument.PrintPage += New PrintPageEventHandler(AddressOf rptDanfeNFCe)
        ' Dim obj As Object = CObj(New PrintPreviewDialog())

        '  If iTipoImpViz = 2 Then
        '  Dim Instance As Object = obj
        'Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateSet(Instance, CType(Nothing, System.Type), "Document", New Object(0) {CObj(printDocument)}, CType(Nothing, String()), CType(Nothing, System.Type()))
        '  Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateSet(Instance, CType(Nothing, System.Type), "WindowState", New Object(0) {CObj(FormWindowState.Maximized)}, CType(Nothing, String()), CType(Nothing, System.Type()))
        '  Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateSetComplex(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(Instance, CType(Nothing, System.Type), "PrintPreviewControl", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, System.Type()), CType(Nothing, Boolean())), CType(Nothing, System.Type), "Zoom", New Object(0) {CObj(1)}, CType(Nothing, String()), CType(Nothing, System.Type()), False, True)
        '  Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateSet(Instance, CType(Nothing, System.Type), "Text", New Object(0) {CObj("PDVLinear - DANFe NFCe")}, CType(Nothing, String()), CType(Nothing, System.Type()))
        '  Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateCall(Instance, CType(Nothing, System.Type), "ShowDialog", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, System.Type()), CType(Nothing, Boolean()), True)
        '  Else
        '  printDocument.Print()
        ' End If


    End Sub

    Public Sub Imprimir_prazo(ByVal cnpj_cli As String, ByVal rv As String, ByVal vlr_compra As String, nr As String, ByVal nome_print As String)
        ' Try

        cnpj_dest = cnpj_cli
        rv_cli = rv
        vlr_compra_cli = vlr_compra
        nrnfc = nr
        posicaoDaLinha = New Decimal()
        Dim printDocument As PrintDocument = New PrintDocument()
        Dim standardPrintController As StandardPrintController = New StandardPrintController()
        Dim num As Integer = CentimetrosParaCentesimasPolegada(0.05)
        printDocument.DefaultPageSettings.Margins = New Margins(num, num, num, num)
        printDocument.PrintController = CType(standardPrintController, PrintController)



        AddHandler printDocument.PrintPage, New Printing.PrintPageEventHandler(AddressOf rptaprazo)
        Dim objPrintPreview As New PrintPreviewDialog

        If nome_print <> "" Then
            printDocument.PrinterSettings.PrinterName = nome_print
        End If

        printDocument.Print()

        Exit Sub


        'define o formulário como maximizado e com Zoom

        With objPrintPreview

            .Document = printDocument

            .WindowState = FormWindowState.Maximized

            .PrintPreviewControl.Zoom = 1

            .Text = "Relacao de Clientes"

            .ShowDialog()


        End With






        '   printDocument.PrintPage += New PrintPageEventHandler(AddressOf rptDanfeNFCe)
        ' Dim obj As Object = CObj(New PrintPreviewDialog())

        '  If iTipoImpViz = 2 Then
        '  Dim Instance As Object = obj
        'Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateSet(Instance, CType(Nothing, System.Type), "Document", New Object(0) {CObj(printDocument)}, CType(Nothing, String()), CType(Nothing, System.Type()))
        '  Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateSet(Instance, CType(Nothing, System.Type), "WindowState", New Object(0) {CObj(FormWindowState.Maximized)}, CType(Nothing, String()), CType(Nothing, System.Type()))
        '  Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateSetComplex(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(Instance, CType(Nothing, System.Type), "PrintPreviewControl", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, System.Type()), CType(Nothing, Boolean())), CType(Nothing, System.Type), "Zoom", New Object(0) {CObj(1)}, CType(Nothing, String()), CType(Nothing, System.Type()), False, True)
        '  Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateSet(Instance, CType(Nothing, System.Type), "Text", New Object(0) {CObj("PDVLinear - DANFe NFCe")}, CType(Nothing, String()), CType(Nothing, System.Type()))
        '  Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateCall(Instance, CType(Nothing, System.Type), "ShowDialog", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, System.Type()), CType(Nothing, Boolean()), True)
        '  Else
        '  printDocument.Print()
        ' End If


    End Sub
    Public Sub rptoperador(ByVal sender As Object, ByVal Relatorio As PrintPageEventArgs)
        Dim TamLetra As Integer = 6
        Dim num1 As Integer = 0
        Dim Font As Font
        ' Dim clsPlugin As clsPlugin = New clsPlugin()
        Dim Left1 As String = ""
        margemEsq = 5.0F
        margemSup = 5.0F
        margemDir = 5.0F
        margemInf = 5.0F
        posicaoDaLinha = New Decimal()
        linhaAtual = 1
        fonteTitulo = New Font(tipoFonte, CSng(TamLetra), FontStyle.Bold)
        fonteRodape = New Font(tipoFonte, CSng(TamLetra))
        fonteNormal = New Font(tipoFonte, CSng(TamLetra))
        fonteColuna = New Font(tipoFonte, CSng(TamLetra))

        Font = New Font("Times New Roman", 8, FontStyle.Bold)
        Dim Alinhamento As New StringFormat()
        Dim tex As String = empresa.sNomeRazao
        Dim desc As String = ""
        Dim valor As String = ""
        Dim qtde As String = ""

        If CDec(tex.Length) < 48 Then
            posicaoDaLinha += 20
            Alinhamento.Alignment = StringAlignment.Center
            Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)
        Else

            fonteNormal = New Font(tipoFonte, CSng(8))
            Alinhamento.Alignment = StringAlignment.Center
            Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)
            posicaoDaLinha += 5
        End If

        tex = "RELATÓRIO OPERADOR DE CAIXA"
        posicaoDaLinha += 20
        Alinhamento.Alignment = StringAlignment.Center
        Relatorio.Graphics.DrawString(tex, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)


        conectar_sqlite()
        Dim SQLcommand As SQLiteCommand
        SQLcommand = Conn.CreateCommand
        SQLcommand.CommandText = "select * from venda_pdv where Status = 'Aberto'"

        Using reader As SQLiteDataReader = SQLcommand.ExecuteReader

            While reader.Read

                tex = "Operador: " & frmpdv.operador
                posicaoDaLinha += 20
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString(tex, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)

                '   tex = "Impresso: " & Now
                '   Alinhamento.Alignment = StringAlignment.Far
                '   Relatorio.Graphics.DrawString(tex, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)

                tex = "Abertura: " & reader("data_abertura")
                Alinhamento.Alignment = StringAlignment.Far
                Relatorio.Graphics.DrawString(tex, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)


                tex = "---------------------------------------------------------------------------------------------"
                posicaoDaLinha += 10
                Relatorio.Graphics.DrawString(tex, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)

                tex = "Dinheiro"
                Font = New Font("Times New Roman", 7, FontStyle.Bold)
                posicaoDaLinha += 15
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)

                qtde = "Qtde: " & "0"
                valor = format_val_mysql_ret(reader("vlr_dinheiro"))
                posicaoDaLinha += 15
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString(qtde, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)
                Alinhamento.Alignment = StringAlignment.Far
                Relatorio.Graphics.DrawString(valor, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)


                tex = "Cartão de Crédito"
                Font = New Font("Times New Roman", 7, FontStyle.Bold)
                posicaoDaLinha += 15
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)

                qtde = "Qtde: " & reader("qtde_cartao")
                valor = format_val_mysql_ret(reader("vlr_cartao"))
                posicaoDaLinha += 15
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString(qtde, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)
                Alinhamento.Alignment = StringAlignment.Far
                Relatorio.Graphics.DrawString(valor, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)


                tex = "Cheques"
                Font = New Font("Times New Roman", 7, FontStyle.Bold)
                posicaoDaLinha += 15
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)

                qtde = "Qtde: " & reader("qtde_cheque")
                valor = format_val_mysql_ret(reader("vlr_cheque"))
                posicaoDaLinha += 15
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString(qtde, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)
                Alinhamento.Alignment = StringAlignment.Far
                Relatorio.Graphics.DrawString(valor, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)

                tex = "Vale alimentação"
                Font = New Font("Times New Roman", 7, FontStyle.Bold)
                posicaoDaLinha += 15
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)

                qtde = "Qtde: " & reader("qtde_vale")
                valor = format_val_mysql_ret(reader("vlr_vale"))
                posicaoDaLinha += 15
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString(qtde, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)
                Alinhamento.Alignment = StringAlignment.Far
                Relatorio.Graphics.DrawString(valor, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)

                tex = "Venda à Prazo"
                Font = New Font("Times New Roman", 7, FontStyle.Bold)
                posicaoDaLinha += 15
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)

                qtde = "Qtde: " & reader("qtde_aprazo")
                valor = format_val_mysql_ret(reader("vlr_prazo"))
                posicaoDaLinha += 15
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString(qtde, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)
                Alinhamento.Alignment = StringAlignment.Far
                Relatorio.Graphics.DrawString(valor, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)


                tex = "Outros valores"
                Font = New Font("Times New Roman", 7, FontStyle.Bold)
                posicaoDaLinha += 15
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)

                qtde = "Qtde: " & reader("qtde_outros")
                valor = format_val_mysql_ret(reader("vlr_outros"))
                posicaoDaLinha += 15
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString(qtde, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)
                Alinhamento.Alignment = StringAlignment.Far
                Relatorio.Graphics.DrawString(valor, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)


                tex = "---------------------------------------------------------------------------------------------"
                posicaoDaLinha += 15
                Relatorio.Graphics.DrawString(tex, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)

                Font = New Font("Times New Roman", 7, FontStyle.Bold)
                valor = format_val_mysql_ret(reader("fundo_troco"))
                posicaoDaLinha += 15
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString("Fundo de Troco", Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)
                Alinhamento.Alignment = StringAlignment.Far
                Relatorio.Graphics.DrawString(valor, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)


                Font = New Font("Times New Roman", 7, FontStyle.Bold)
                valor = format_val_mysql_ret(reader("vlr_total"))
                posicaoDaLinha += 15
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString("Valor Total Vendido", Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)
                Alinhamento.Alignment = StringAlignment.Far
                Relatorio.Graphics.DrawString(valor, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)


            End While

        End Using

    End Sub


    Public Sub rptaprazo(ByVal sender As Object, ByVal Relatorio As PrintPageEventArgs)
        Dim TamLetra As Integer = 6
        Dim num1 As Integer = 0
        Dim Font As Font
        ' Dim clsPlugin As clsPlugin = New clsPlugin()
        Dim Left1 As String = ""
        margemEsq = 5.0F
        margemSup = 5.0F
        margemDir = 5.0F
        margemInf = 5.0F
        posicaoDaLinha = New Decimal()
        linhaAtual = 1
        fonteTitulo = New Font(tipoFonte, CSng(TamLetra), FontStyle.Bold)
        fonteRodape = New Font(tipoFonte, CSng(TamLetra))
        fonteNormal = New Font(tipoFonte, CSng(TamLetra))
        fonteColuna = New Font(tipoFonte, CSng(TamLetra))

        Font = New Font("Times New Roman", 8, FontStyle.Bold)
        Dim Alinhamento As New StringFormat()
        Dim tex As String = empresa.sNomeRazao
        Dim desc As String = ""
        Dim valor As String = "512,00"
        Dim qtde As String = "1"

        If CDec(tex.Length) < 48 Then
            posicaoDaLinha += 20
            Alinhamento.Alignment = StringAlignment.Center
            Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)
        Else

            fonteNormal = New Font(tipoFonte, CSng(8))
            Alinhamento.Alignment = StringAlignment.Center
            Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)
            posicaoDaLinha += 5
        End If


        tex = "Data da Compra: " & Now
        posicaoDaLinha += 30
        Alinhamento.Alignment = StringAlignment.Near
        Relatorio.Graphics.DrawString(tex, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)

        rv_cli = rv_cli.PadLeft(9, "0")
        tex = "Cupom: " & rv_cli
        Alinhamento.Alignment = StringAlignment.Far
        Relatorio.Graphics.DrawString(tex, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)


        conectar_sqlite()
        Dim SQLcommand As SQLiteCommand
        SQLcommand = Conn.CreateCommand
        SQLcommand.CommandText = "select * from cliente where cnpj_cli = '" & cnpj_dest & "'"

        Using reader As SQLiteDataReader = SQLcommand.ExecuteReader

            While reader.Read

                Font = New Font("Times New Roman", 8, FontStyle.Bold)
                tex = "Nome Cliente: " & reader("nome_cli")
                posicaoDaLinha += 15
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)


                Font = New Font("Times New Roman", 8, FontStyle.Regular)
                tex = "CPF/CNPJ: " & reader("cnpj_cli")
                posicaoDaLinha += 20
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)


                tex = reader("end_cli") & ", " & reader("numero") & ", " & reader("bairro") & ", " & reader("cidade") & "/" & reader("uf")
                If CDec(tex.Length) < 48 Then
                    posicaoDaLinha += 15
                    Alinhamento.Alignment = StringAlignment.Near
                    Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)
                Else
                    posicaoDaLinha += 15
                    fonteNormal = New Font(tipoFonte, CSng(8))
                    Alinhamento.Alignment = StringAlignment.Near
                    Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)
                    posicaoDaLinha += 5
                End If

                tex = "Valor Compra: " & vlr_compra_cli
                fonteNormal = New Font(tipoFonte, CSng(7))
                posicaoDaLinha += 30
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)


                tex = "Limite Restante: " & Format(CDec(reader("credito")) - CDec(reader("vlr_usado")), "#,##0.00")
                fonteNormal = New Font(tipoFonte, CSng(7))
                Alinhamento.Alignment = StringAlignment.Far
                Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)

                Dim data As Date
                data = Now.Date
                Font = New Font("Times New Roman", 8, FontStyle.Regular)
                tex = "Data de Vencimento: " & data.AddDays(reader("prazo"))
                posicaoDaLinha += 20
                Alinhamento.Alignment = StringAlignment.Near
                Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)


            End While

        End Using






        Font = New Font("Times New Roman", 8, FontStyle.Regular)
        tex = "PAGAREI A IMPORTANCIA ACIMA."
        posicaoDaLinha += 70
        Alinhamento.Alignment = StringAlignment.Near
        Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)



        Font = New Font("Times New Roman", 8, FontStyle.Regular)
        tex = "ASS.:________________________________________"
        posicaoDaLinha += 70
        Alinhamento.Alignment = StringAlignment.Near
        Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)
        '  tex = "---------------------------------------------------------------------------------------------"
        ' posicaoDaLinha += 10
        ' Relatorio.Graphics.DrawString(tex, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)

        tex = "---------------------------------------------------------------------"
        posicaoDaLinha += 50
        Alinhamento.Alignment = StringAlignment.Near
        Relatorio.Graphics.DrawString(tex, Font, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)

        tex = "Data Impressão: " & Now
        fonteNormal = New Font(tipoFonte, CSng(6))
        posicaoDaLinha += 10
        Alinhamento.Alignment = StringAlignment.Near
        Relatorio.Graphics.DrawString(tex, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)

        nrnfc = nrnfc.PadLeft(9, "0")
        tex = "NFC-e: " & nrnfc
        fonteNormal = New Font(tipoFonte, CSng(6))
        Alinhamento.Alignment = StringAlignment.Far
        Relatorio.Graphics.DrawString(tex, fonteNormal, Brushes.Black, New RectangleF(margemEsq, posicaoDaLinha, 270, 50), Alinhamento)
    End Sub

    Public Function fFormata(ByVal texto As String, ByVal Caracter As String, ByVal Posicao As String, ByVal tamanho As Integer, ByVal tamanho2 As Integer, Optional ByVal Maiusculo As Boolean = True, Optional ByVal RemoveCaracter As Boolean = False) As String



        Dim str1 As String

        Dim CharCode As Integer = 0
        Do
            texto = Strings.Replace(texto, Convert.ToString(Strings.Chr(CharCode)), " ", 1, -1, CompareMethod.Binary)
            CharCode += 1
        Loop While CharCode <= 31

        If RemoveCaracter Then
            texto = Strings.Replace(texto, ",", "", 1, -1, CompareMethod.Binary)
            texto = Strings.Replace(texto, ".", "", 1, -1, CompareMethod.Binary)
        End If

        If Maiusculo Then texto = Strings.UCase(texto)
        Dim str2 As String = If(Strings.Trim(texto), "")
        Posicao = Strings.UCase(Posicao)

        If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Posicao, "D", False) = 0 Then
            Dim str3 As String = If(Strings.Len(texto) >= tamanho, New String(Strings.ChrW(Strings.AscW(Caracter)), tamanho), New String(Strings.ChrW(Strings.AscW(Caracter)), (tamanho - Strings.Len(texto))))
            If tamanho > Strings.Len(str2) Then str2 = Strings.Trim(texto) & str3
            str2 = Strings.Left(str2, tamanho)
        End If

        If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Posicao, "E", False) = 0 Then
            Dim str3 As String = If(Strings.Len(texto) >= tamanho, New String(Strings.ChrW(Strings.AscW(Caracter)), tamanho), New String(Strings.ChrW(Strings.AscW(Caracter)), (tamanho - Strings.Len(texto))))
            If tamanho > Strings.Len(str2) Then str2 = str3 & texto
            str2 = Strings.Right(str2, tamanho)
        End If

        If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Posicao, "C", False) = 0 Then
            Dim count As Integer = (CInt(Math.Round((CDbl((tamanho - Strings.Len(texto))) / 2.0))))
            If tamanho > Strings.Len(str2) Then
                Dim Expression As String = New String(Strings.ChrW(Strings.AscW(Caracter)), count) & texto
                str2 = Expression & New String(Strings.ChrW(Strings.AscW(Caracter)), (tamanho - Strings.Len(Expression)))
            End If
        End If


        str1 = str2

        Return str1
    End Function

    Public Function gVgPt(ByVal sEntrada As Object, Optional ByVal bInvert As Boolean = False) As String
        Return If(Not Microsoft.VisualBasic.CompilerServices.Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(sEntrada, CObj(""), False), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(sEntrada, CObj("0.00"), False)), CObj(Not Microsoft.VisualBasic.CompilerServices.Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(sEntrada))))), (If(bInvert, Strings.Replace(Strings.Replace(Microsoft.VisualBasic.CompilerServices.Conversions.ToString(sEntrada), ",", "", 1, -1, CompareMethod.Binary), ".", ",", 1, -1, CompareMethod.Binary), Strings.Replace(Strings.Replace(Microsoft.VisualBasic.CompilerServices.Conversions.ToString(sEntrada), ".", "", 1, -1, CompareMethod.Binary), ",", ".", 1, -1, CompareMethod.Binary))), "0")
    End Function

    Public Function CentimetrosParaCentesimasPolegada(ByVal cm As Double) As Integer
        Return (CInt(Math.Round(Math.Round((cm / 0.393701 * 100.0), MidpointRounding.AwayFromZero))))
    End Function

    Public Function CalculaDigestValueXML_MDL(ByVal strXML As String, Optional ByVal bNFCe As Boolean = False) As String
        If bNFCe Then
            Dim xmlDocument1 As XmlDocument = New XmlDocument()
            xmlDocument1.LoadXml(strXML)
            xmlDocument1.Save(Application.StartupPath & "\xmlcorrigido.xml")
            Dim xmlDocument2 As XmlDocument = New XmlDocument()
            xmlDocument2.Load(Application.StartupPath & "\xmlcorrigido.xml")
            strXML = "<infNFe>" & xmlDocument2.GetElementsByTagName("NFe").Item(0).FirstChild.InnerXml & "</infNFe>"
        End If

        Return Convert.ToString(GerarDigestValueXML(strXML))

    End Function

    Public Function GerarDigestValueXML(ByVal strXML As String) As Object
        Dim base64String As Object

        Try
            Dim xmlDocument As XmlDocument = New XmlDocument()
            xmlDocument.LoadXml(strXML)
            CriarLog("xmlHAsh => " & strXML, "", "", False, False, False)
            Dim dsigC14Ntransform As Xml.XmlDsigC14NTransform = New Xml.XmlDsigC14NTransform()
            dsigC14Ntransform.LoadInput(CObj(xmlDocument))
            base64String = CObj(Convert.ToBase64String(SHA1.Create().ComputeHash(CType(dsigC14Ntransform.GetOutput(GetType(Stream)), Stream))))
        Catch ex As Exception

        End Try

        Return base64String
    End Function
End Module
