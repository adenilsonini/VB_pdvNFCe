
Imports System.IO
Imports System.Xml
Imports System.Security.Cryptography.X509Certificates
Imports System.Runtime.CompilerServices
Imports System.Data.SQLite


Module GerarXML_nfce
    Public cAux As String
    Public xml_processar As New XmlDocument()
    Public xmldoc2 As New XmlDocument()
    Public xmldoc_PROC As New XmlDocument()
    Public xmldoc3 As New XmlDocument()

    Dim xmlAssinado As XmlDocument

    Public Function GerarEndQRCodeXML(ByVal strXML As String, Optional ByVal DigestValueHash As String = "", Optional ByVal sVersaoLayout As String = "4.00", Optional ByVal sCSC As String = "", Optional ByVal sIdtoken As String = "") As String
        Return GerarEndQRCode(strXML, DigestValueHash, sVersaoLayout, empresa.sCSC, empresa.Idtoken, empresa.sSiglaUF)
    End Function

    Public Function GerarEndQRCode(ByVal strXML As String, ByVal DigestValueHash As String, ByVal sVersaoLayout As String, ByVal sCSC As String, ByVal sIdtoken As String, ByVal NFCe_UF As String) As String
        Dim str1 As String
        sVersaoLayout = "4.00"

        Try
            Dim xmlDocument As XmlDocument = New XmlDocument()

            xmlDocument.LoadXml(strXML)
            Dim str2 As String

            If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(DigestValueHash, "", False) <> 0 Then
                str2 = DigestValueHash
            Else

                Try

                    For Each obj1 As Object In xmlDocument.GetElementsByTagName("Reference")
                        Dim objectValue1 As Object = RuntimeHelpers.GetObjectValue(obj1)

                        Try

                            For Each obj2 As Object In CType(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue1, CType(Nothing, Type), "ChildNodes", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), IEnumerable)
                                Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(obj2)

                                If Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "Name", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), CObj("DigestValue"), False) Then
                                    str2 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "innertext", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                                    Exit For
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

                If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str2, "", False) = 0 Then str2 = xmlDocument("NFe")("Signature")("SignedInfo")("Reference")("DigestValue").InnerText
            End If

            '  If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(sCSC, "", False) = 0 Then sCSC = mdlGeral.NFCe_CSC
            '  If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(sIdtoken, "", False) = 0 Then sIdtoken = mdlGeral.NFCe_ID_Token
            '  If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(sCSC, "", False) = 0 Then sCSC = mdlGeral.AppPathCSC
            '  If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(sIdtoken, "", False) = 0 Then sIdtoken = mdlGeral.AppPathIdToken
            Dim nfCeUf As String

            If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(NFCe_UF, "", False) = 0 Then

                Try

                    For Each obj1 As Object In xmlDocument.GetElementsByTagName("enderEmit")
                        Dim objectValue1 As Object = RuntimeHelpers.GetObjectValue(obj1)

                        Try

                            For Each obj2 As Object In CType(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue1, CType(Nothing, Type), "childnodes", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), IEnumerable)
                                Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(obj2)

                                If Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "name", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), CObj("UF"), False) Then
                                    nfCeUf = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "innertext", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                                    Exit For
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
            Else
                nfCeUf = NFCe_UF
            End If

            Dim str3 As String

            Try

                For Each obj1 As Object In xmlDocument.GetElementsByTagName("NFe")
                    Dim objectValue1 As Object = RuntimeHelpers.GetObjectValue(obj1)

                    Try

                        For Each obj2 As Object In CType(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue1, CType(Nothing, Type), "ChildNodes", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), IEnumerable)
                            Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(obj2)

                            If Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "Name", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), CObj("infNFe"), False) Then
                                str3 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "GetAttribute", New Object(0) {CObj("Id")}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                                sVersaoLayout = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "GetAttribute", New Object(0) {CObj("versao")}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                                Exit For
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

            Dim str4 As String
            Dim str5 As String
            Dim str6 As String

            Try

                For Each obj1 As Object In xmlDocument.GetElementsByTagName("ide")
                    Dim objectValue1 As Object = RuntimeHelpers.GetObjectValue(obj1)

                    Try

                        For Each obj2 As Object In CType(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue1, CType(Nothing, Type), "childnodes", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), IEnumerable)
                            Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(obj2)
                            Dim Left As Object = Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "name", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean()))

                            If Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, CObj("dhEmi"), False) Then
                                str4 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "innertext", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                            ElseIf Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, CObj("tpAmb"), False) Then
                                str5 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "innertext", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                            ElseIf Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, CObj("tpEmis"), False) Then
                                str6 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "innertext", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
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

            Dim str7 As String
            Dim str8 As String

            Try

                For Each obj1 As Object In xmlDocument.GetElementsByTagName("ICMSTot")
                    Dim objectValue1 As Object = RuntimeHelpers.GetObjectValue(obj1)

                    Try

                        For Each obj2 As Object In CType(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue1, CType(Nothing, Type), "childnodes", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), IEnumerable)
                            Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(obj2)
                            Dim Left As Object = Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "name", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean()))

                            If Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, CObj("vNF"), False) Then
                                str7 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "innertext", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                            ElseIf Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, CObj("vICMS"), False) Then
                                str8 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "innertext", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
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

            Dim Left1 As String

            If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(sVersaoLayout, "3.10", False) = 0 And xmlDocument.GetElementsByTagName("dest").Count > 0 Then

                Try

                    For Each obj1 As Object In xmlDocument.GetElementsByTagName("dest")
                        Dim objectValue1 As Object = RuntimeHelpers.GetObjectValue(obj1)

                        Try
                            '  Microsoft.VisualBasic.CompilerServices.LateBinding.LateGet
                            For Each obj2 As Object In CType(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue1, CType(Nothing, Type), "childnodes", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())), IEnumerable)
                                Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(obj2)
                                Dim Left2 As Object = Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "name", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean()))

                                If Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left2, CObj("CPF"), False) Then
                                    Left1 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "innertext", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
                                ElseIf Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left2, CObj("CNPJ"), False) Then
                                    Left1 = Convert.ToString(Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(objectValue2, CType(Nothing, Type), "innertext", New Object(-1) {}, CType(Nothing, String()), CType(Nothing, Type()), CType(Nothing, Boolean())))
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

            Dim str9 As String

            If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(sVersaoLayout, "4.00", False) = 0 Then
                Dim str10 As String = Strings.Mid(str4, (Strings.InStr(str4, "T", CompareMethod.Binary) - 2), 2)
                cAux = Strings.Mid(str3, 4) & "|2|" & str5 & "|"

                If Convert.ToDouble(str6) = 1.0 Then
                    cAux += Convert.ToString(Conversion.Val(sIdtoken))
                Else
                    Dim hex As String = StringToHex(str2)
                    cAux = cAux & str10 & "|" & str7 & "|" & hex & "|" + Convert.ToString(Conversion.Val(sIdtoken))
                End If

                Dim shA1Hash As String = getSHA1Hash(cAux & sCSC)
                str9 = "https://nfce.fazenda.mg.gov.br/portalnfce/sistema/qrcode.xhtml?" & "p=" + cAux & "|" + Strings.UCase(shA1Hash)
            Else
                Dim hex1 As String = StringToHex(str4)
                cAux = "chNFe=" & Strings.Mid(str3, 4) & "&nVersao=100&tpAmb=" & str5
                If Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "", False) <> 0 Then cAux = cAux & "&cDest=" & Left1
                cAux = cAux & "&dhEmi=" & hex1
                Dim hex2 As String = StringToHex(str2)
                cAux = cAux & "&vNF=" & str7
                cAux = cAux & "&vICMS=" & str8
                cAux = cAux & "&digVal=" & hex2
                cAux = cAux & "&cIdToken=" + Strings.Format(CObj(Conversion.Val(sIdtoken)), "000000")
                Dim shA1Hash As String = getSHA1Hash(cAux & sCSC)
                str9 = "https://nfce.fazenda.mg.gov.br/portalnfce/sistema/qrcode.xhtml?" & "&cHashQRCode=" + Strings.UCase(shA1Hash)
            End If

            CriarLog("QRCode CSC: " & sCSC & " / IdToken: " & sIdtoken & " / tpAmb: " & str5, "", "", False, False, False)
            CriarLog("QRCode Layout: " & sVersaoLayout & " / CodeQR: " & str9, "", "", False, False, False)
            str1 = str9
        Catch ex As Exception

            Dim exception As Exception = ex
            CriarLog("Erro(GerarEndQRCode) Layout: " & sVersaoLayout & " / Mensagem: " & exception.Message & " - " + exception.StackTrace, "", "", False, False, False)
            str1 = ""
            MsgBox(exception.Message)
        End Try

        Return str1
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
    Public Function gerar_xmlNFCe_envio(ByVal xml As String, ByVal ambiente As String) As String
        Dim txtqrcodenfce As String
        Dim xmlAssinado12 As XmlDocument()
        ''''''''''''Rotina abaixo assinar o xml com certificado digital'''''''''''''''''''''''''
        xmldoc2.LoadXml(xml)

        xmldoc3.LoadXml(SepararNota3(xmldoc2.OuterXml))
        xmldoc2.LoadXml(SepararNota3(xmldoc2.OuterXml))

        Dim cert As New X509Certificate2
        cert = busca_cert()

        xmlAssinado = CertificadoDigital.Assinar(GerarNotaProcessada2(xmldoc2.OuterXml), "infNFe", cert)


        'If mskchave.Text.Substring(20, 2) = "65" Then

        ''''''''''''Rotina abaixo gera o QRCode da NFC-e'''''''''''''''''''''''''
        If txtqrcodenfce = "" Then

            txtqrcodenfce = GerarEndQRCodeXML(xmlAssinado.OuterXml)


            xmldoc2.LoadXml(xmlAssinado.OuterXml)


            xmlAssinado = Gerar_qrcode(xmldoc3.OuterXml, txtqrcodenfce, SepararNota_assinatura(xmlAssinado.OuterXml), empresa.ambiente_nfe)

            xml_processar.LoadXml(xmlAssinado.OuterXml)

        End If

        '   End If


        ''''''''''''Rotina abaixo gera O Lote para envio'''''''''''''''''''''''''


        ' xmlAssinado = GerarLoteNfe(xmlAssinado)

        '  MsgBox("XML assinado e salvo em," & vbCrLf & dest & nome_arq)

        Return xmlAssinado.OuterXml
    End Function

    Public Function SepararNota3(ByVal vNfeDadosMsg As String) As String

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<infNFe")
        Dim nPosf As Int32 = vNfeDadosMsg.IndexOf("</infNFe")
        Dim vStringNfe2 As String
        Try
            vStringNfe2 = vNfeDadosMsg.Substring(nPosI, nPosf + 4)
        Catch ex As Exception
            vStringNfe2 = vNfeDadosMsg.Substring(nPosI, nPosf + 9 - nPosI)
        End Try


        Return vStringNfe2

    End Function

    Public Function GerarNotaProcessada2(ByVal vStringNfe As String) As XmlDocument
        Dim cVersaoDados As String = "4.00"

        'Montar a parte do XML referente ao Lote e acrescentar a Nota Fiscal
        Dim vStringLoteNfe As String = String.Empty
        ' vStringLoteNfe += "<?xml version=""1.0"" encoding=""utf-8""?>"
        vStringLoteNfe += "<NFe xmlns=""http://www.portalfiscal.inf.br/nfe"">"
        vStringLoteNfe += vStringNfe
        vStringLoteNfe += "</NFe>"

        Dim PastaNota As String = ""
        PastaNota = "C:\Users\adeni\Desktop\Nova_pasta" & "\"



        Dim NDoc = New XmlDocument()

        NDoc.LoadXml(vStringLoteNfe)



        '  Using xmltw As New XmlTextWriter(PastaNota & chavenfe + ".xml", New UTF8Encoding(False))
        'NDoc.WriteTo(xmltw)
        '   xmltw.Close()
        '  End Using

        Return NDoc
    End Function

    Public Function SepararNota_assinatura(ByVal vNfeDadosMsg As String) As String

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>

        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<Signature")
        Dim nPosF As Int32 = vNfeDadosMsg.Length - nPosI
        Dim vStringNfe As String = vNfeDadosMsg.Substring(nPosI, nPosF - 6)

        Return vStringNfe

    End Function


    Public Function Gerar_qrcode(ByVal vStringNfe As String, ByVal QRCODE As String, ByVal assinatura As String, ByVal ambiente As String) As XmlDocument
        Dim cVersaoDados As String = "4.00"

        'Montar a parte do XML referente ao Lote e acrescentar a Nota Fiscal
        Dim vStringLoteNfe As String = String.Empty
        ' vStringLoteNfe += "<?xml version=""1.0"" encoding=""utf-8""?>"
        vStringLoteNfe += "<NFe xmlns=""http://www.portalfiscal.inf.br/nfe"">"
        vStringLoteNfe += vStringNfe

        If QRCODE <> "" Then
            vStringLoteNfe += "<infNFeSupl>"
            vStringLoteNfe += "<qrCode>"
            vStringLoteNfe += "<![CDATA[" & QRCODE & "]]>"
            vStringLoteNfe += "</qrCode>"
            If ambiente = "2" Then
                vStringLoteNfe += "<urlChave>http://hnfce.fazenda.mg.gov.br/portalnfce</urlChave>"
            Else
                vStringLoteNfe += "<urlChave>http://nfce.fazenda.mg.gov.br/portalnfce</urlChave>"
            End If

            vStringLoteNfe += "</infNFeSupl>"
        End If
        vStringLoteNfe += assinatura
        vStringLoteNfe += "</NFe>"


        Dim NDoc = New XmlDocument()

        NDoc.LoadXml(vStringLoteNfe)

        Return NDoc
    End Function


    Public Function SepararNota_prot(ByVal vNfeDadosMsg As String) As String

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<NFe")
        Dim nPosf As Int32 = vNfeDadosMsg.IndexOf("</NFe")

        Dim vStringNfe2 As String = vNfeDadosMsg.Substring(nPosI, nPosf - 150)

        Return vStringNfe2

    End Function

    Public Function GerarNotaProcessadanfce(ByVal vStringNfe As String, ByVal VStringRecibo As String) As XmlDocument
        Dim cVersaoDados As String = "4.00"

        'Montar a parte do XML referente ao Lote e acrescentar a Nota Fiscal
        Dim vStringLoteNfe As String = String.Empty
        vStringLoteNfe += "<?xml version=""1.0"" encoding=""utf-8""?>"
        vStringLoteNfe += "<nfeProc versao=""" & cVersaoDados & """ xmlns=""http://www.portalfiscal.inf.br/nfe"">"
        vStringLoteNfe += vStringNfe
        '  vStringLoteNfe += "<protNFe versao=""" & cVersaoDados & """>"
        vStringLoteNfe += VStringRecibo
        ' vStringLoteNfe += "</protNFe>"
        vStringLoteNfe += "</nfeProc>"


        Dim NDoc = New XmlDocument()

        NDoc.LoadXml(vStringLoteNfe)


        Return NDoc
    End Function

    Public Function busca_cert() As X509Certificate2
        Dim venc As Date
        Dim caminho As String

        caminho = Application.StartupPath & "\cert\" & empresa.sCNPJ & ".pfx"


        Dim ret As New X509Certificate2(caminho, empresa.senha_cert, X509KeyStorageFlags.MachineKeySet)

        If Convert.ToDateTime(ret.NotAfter).ToString("dd/MM/yyyy") > Now.Date Then

            cnpj = cnpj_cert(ret)

            If empresa.sCNPJ = cnpj Then
                Return ret
            End If

        End If

    End Function

    Public Function gerar_xmlNFCe_envio2(ByVal xml As String, ByVal ambiente As String) As String

        Dim txtqrcodenfce As String
        Dim xmlAssinado12 As XmlDocument()
        ''''''''''''Rotina abaixo assinar o xml com certificado digital'''''''''''''''''''''''''
        xmldoc2.LoadXml(xml)

        xmldoc3.LoadXml(SepararNota3(xmldoc2.OuterXml))
        xmldoc2.LoadXml(SepararNota3(xmldoc2.OuterXml))


        xmlAssinado = CertificadoDigital.Assinar(GerarNotaProcessada2(xmldoc2.OuterXml), "infNFe", certificado)


        'If mskchave.Text.Substring(20, 2) = "65" Then

        ''''''''''''Rotina abaixo gera o QRCode da NFC-e'''''''''''''''''''''''''
        If txtqrcodenfce = "" Then

            txtqrcodenfce = GerarEndQRCodeXML(xmlAssinado.OuterXml)


            xmldoc2.LoadXml(xmlAssinado.OuterXml)


            xmlAssinado = Gerar_qrcode(xmldoc3.OuterXml, txtqrcodenfce, SepararNota_assinatura(xmlAssinado.OuterXml), ambiente)

            xml_processar.LoadXml(xmlAssinado.OuterXml)

        End If

        '   End If



        '  MsgBox("XML assinado e salvo em," & vbCrLf & dest & nome_arq)

        Return xmlAssinado.OuterXml
    End Function

 Public Function ProximoCodigo(ByVal tabela As String, ByVal campo As String) As Long
        Dim num As Long = 1
        Dim mySqlDataReader As SQLiteDataReader = CType(Nothing, SQLiteDataReader)

        Try

            Dim cmdText As String = String.Format("select max({0}) as codigo from {1}", CObj(campo), CObj(tabela))

            conectar_sqlite()
            Using mySqlCommand As SQLiteCommand = New SQLiteCommand(cmdText, Conn)
                mySqlDataReader = mySqlCommand.ExecuteReader()

                If mySqlDataReader.Read() Then
                    If Not mySqlDataReader.IsDBNull(mySqlDataReader.GetOrdinal("codigo")) Then num += Convert.ToInt64(mySqlDataReader.GetValue(mySqlDataReader.GetOrdinal("codigo")))
                End If
            End Using
            Conn.Close()

        Catch ex As Exception
            Throw
        Finally
            mySqlDataReader.Dispose()
        End Try

        Return num
    End Function

End Module
