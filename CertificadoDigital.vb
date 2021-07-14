Imports System.Security.Cryptography.Xml
Imports System.Xml
Imports System.Collections
Imports System.Security
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Pkcs
Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Text

Public Module CertificadoDigital
    Public nfecer As String
    Public certificado As X509Certificate2

    ''' <summary>
    ''' Função retirada do UNINFE - http://www.unimake.com.br/uninfe/
    ''' Modificada por Giovanni - Try Ideas - www.tryideas.com.br para exemplo no Blog www.entendendo.net
    '''
    ''' O método assina digitalmente o arquivo XML passado por parâmetro e
    ''' grava o XML assinado com o mesmo nome, sobreponto o XML informado por parâmetro.
    ''' Disponibiliza também uma propriedade com uma string do xml assinado (this.vXmlStringAssinado)
    ''' </summary>
    ''' <param name="pArqXMLAssinar">Nome do arquivo XML a ser assinado</param>
    ''' <param name="pUri">URI (TAG) a ser assinada</param>
    ''' <param name="pCertificado">Certificado a ser utilizado na assinatura</param>
    ''' <remarks>
    ''' Podemos pegar como retorno do método as seguintes propriedades:
    '''
    ''' - Atualiza a propriedade this.vXMLStringAssinado com a string de
    ''' xml já assinada
    '''
    ''' - Grava o XML sobreponto o informado para o método com o conteúdo
    ''' já assinado
    '''
    ''' - Atualiza as propriedades this.vResultado e
    ''' this.vResultadoString com os seguintes valores:
    '''
    ''' 0 - Assinatura realizada com sucesso
    ''' 1 - Erro: Problema ao acessar o certificado digital - %exceção%
    ''' 2 - Problemas no certificado digital
    ''' 3 - XML mal formado + %exceção%
    ''' 4 - A tag de assinatura %pUri% não existe
    ''' 5 - A tag de assinatura %pUri% não é unica
    ''' 6 - Erro ao assinar o documento - %exceção%
    ''' 7 - Falha ao tentar abrir o arquivo XML - %exceção%
    ''' </remarks>
    Public Function Assinar(ByVal docXML As XmlDocument, ByVal pUri As String, ByVal pCertificado As X509Certificate2) As XmlDocument
        Try
            ' Load the certificate from the certificate store.
            Dim cert As X509Certificate2 = pCertificado

            ' Create a new XML document.
            Dim doc As New XmlDocument()

            ' Format the document to ignore white spaces.
            doc.PreserveWhitespace = False

            ' Load the passed XML file using it's name.
            doc = docXML

            ' Create a SignedXml object.
            Dim signedXml As New SignedXml(doc)

            ' Add the key to the SignedXml document.
            signedXml.SigningKey = cert.PrivateKey

            ' Create a reference to be signed.
            Dim reference As New Reference()
            ' pega o uri que deve ser assinada
            Dim _Uri As XmlAttributeCollection = doc.GetElementsByTagName(pUri).Item(0).Attributes
            For Each _atributo As XmlAttribute In _Uri
                If _atributo.Name = "Id" Then
                    reference.Uri = "#" & _atributo.InnerText
                End If
            Next

            ' Add an enveloped transformation to the reference.
            Dim env As New XmlDsigEnvelopedSignatureTransform()
            reference.AddTransform(env)

            Dim c14 As New XmlDsigC14NTransform()
            reference.AddTransform(c14)

            ' Add the reference to the SignedXml object.
            signedXml.AddReference(reference)

            ' Create a new KeyInfo object.
            Dim keyInfo As New KeyInfo()

            ' Load the certificate into a KeyInfoX509Data object
            ' and add it to the KeyInfo object.
            keyInfo.AddClause(New KeyInfoX509Data(cert))

            ' Add the KeyInfo object to the SignedXml object.
            signedXml.KeyInfo = keyInfo

            ' Compute the signature.
            signedXml.ComputeSignature()

            ' Get the XML representation of the signature and save
            ' it to an XmlElement object.
            Dim xmlDigitalSignature As XmlElement = signedXml.GetXml()

            ' Append the element to the XML document.
            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, True))


            If TypeOf doc.FirstChild Is XmlDeclaration Then
                doc.RemoveChild(doc.FirstChild)
            End If

            Return doc
        Catch ex As Exception
            Throw New Exception("Erro ao efetuar assinatura digital, detalhes: " & ex.Message)
        End Try
    End Function

    'BUSCA CERTIFICADOS INSTALADOS SE INFORMADO UMA SERIE BUSCA A MESMA
    'SE NÃO ABRE CAIXA DE DIALOGOS DE CERTIFICADO
    Public Function SelecionarCertificado(ByVal CerSerie As String) As X509Certificate2
        Dim certificate As New X509Certificate2
        Try
            Dim certificatesSel As X509Certificate2Collection
            Dim store As New X509Store("MY", StoreLocation.CurrentUser)
            store.Open(OpenFlags.OpenExistingOnly)
            Dim certificates As X509Certificate2Collection = store.Certificates.Find(X509FindType.FindByTimeValid, DateTime.Now, True).Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, True)
            If (CerSerie = "") Then
                certificatesSel = X509Certificate2UI.SelectFromCollection(certificates, "Certificados Digitais", "Selecione o Certificado Digital para uso no aplicativo", X509SelectionFlag.SingleSelection)
                If (certificatesSel.Count = 0) Then
                    certificate.Reset()
                    Throw New Exception("Nenhum certificado digital foi selecionado ou o certificado selecionado está com problemas.")
                Else
                    certificate = certificatesSel.Item(0)
                    nfecer = certificatesSel.Item(0).SerialNumber.ToString
                End If
            Else
                certificatesSel = certificates.Find(X509FindType.FindBySerialNumber, CerSerie, True)
                If (certificatesSel.Count = 0) Then
                    certificate.Reset()
                    Throw New Exception("Certificado digital não encontrado")
                Else
                    certificate = certificatesSel.Item(0)
                    nfecer = certificatesSel.Item(0).SerialNumber.ToString
                End If
            End If
            store.Close()
            Return certificate
        Catch exception As Exception

            MsgBox(exception.Message, MsgBoxStyle.Critical, "Aviso !")
            Return certificate
        End Try
    End Function

    Public Function cnpj_cert(ByVal x509Certificate2 As X509Certificate2) As String
        Dim cnpj As String


        For Each extension As AsnEncodedData In x509Certificate2.Extensions
            Dim strArray1 As String() = extension.Format(True).Split(New Char(1) {vbLf, vbCr}, StringSplitOptions.RemoveEmptyEntries)
            Dim num1 As Integer = (strArray1.Length - 1)
            Dim index1 As Integer = 0

            While index1 <= num1

                '''''''''''''''''''''''''''''''''Pegar cnpj''''''''''''''
                If strArray1(index1).Trim().StartsWith("2.16.76.1.3.3") Then

                    Dim strArray2 As String() = strArray1(index1).Substring((strArray1(index1).IndexOf("="c) + 1)).Split(" "c)
                    Dim bytes As Byte() = New Byte(strArray2.Length - 3) {}
                    Dim num2 As Integer = (bytes.Length - 1)
                    Dim index2 As Integer = 0

                    While index2 <= num2
                        bytes(index2) = Convert.ToByte(strArray2((index2 + 2)), 16)
                        index2 += 1
                    End While
                    cnpj = Encoding.UTF8.GetString(bytes)
                End If


                index1 += 1

            End While

        Next

        Return cnpj
    End Function

    Public Function dados_cert_Dictionary(ByVal x509Certificate2 As X509Certificate2) As Dictionary(Of String, String)
        Dim ret As String, razao As String
        Dim dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)

        For Each extension As AsnEncodedData In x509Certificate2.Extensions
            Dim strArray1 As String() = extension.Format(True).Split(New Char(1) {vbLf, vbCr}, StringSplitOptions.RemoveEmptyEntries)
            Dim num1 As Integer = (strArray1.Length - 1)
            Dim index1 As Integer = 0

            While index1 <= num1

                '''''''''''''''''''''''''''''''''Pegar nome''''''''''''''

                If strArray1(index1).Trim().StartsWith("Nome RFC822") Then
                    dictionary.Add("e-mail", strArray1(index1).Substring(12, strArray1(index1).Length - 12))
                End If

                If strArray1(index1).Trim().StartsWith("2.16.76.1.3.2") Then
                    Dim strArray2 As String() = strArray1(index1).Substring((strArray1(index1).IndexOf("="c) + 1)).Split(" "c)
                    Dim bytes As Byte() = New Byte(strArray2.Length - 3) {}
                    Dim num2 As Integer = (bytes.Length - 1)
                    Dim index2 As Integer = 0

                    While index2 <= num2
                        bytes(index2) = Convert.ToByte(strArray2((index2 + 2)), 16)
                        index2 += 1
                    End While
                    '  MsgBox(Encoding.UTF8.GetString(bytes))
                    dictionary.Add("nome", Encoding.UTF8.GetString(bytes))
                End If


                '''''''''''''''''''''''''''''''''Pegar cnpj''''''''''''''
                If strArray1(index1).Trim().StartsWith("2.16.76.1.3.3") Then

                    Dim strArray2 As String() = strArray1(index1).Substring((strArray1(index1).IndexOf("="c) + 1)).Split(" "c)
                    Dim bytes As Byte() = New Byte(strArray2.Length - 3) {}
                    Dim num2 As Integer = (bytes.Length - 1)
                    Dim index2 As Integer = 0

                    While index2 <= num2
                        bytes(index2) = Convert.ToByte(strArray2((index2 + 2)), 16)
                        index2 += 1
                    End While
                    dictionary.Add("cnpj", Encoding.UTF8.GetString(bytes))
                End If

                '''''''''''''''''''''''''''''''''Pegar data,cpf,rg''''''''''''''
                If strArray1(index1).Trim().StartsWith("2.16.76.1.3.4") Then
                    Dim strArray2 As String() = strArray1(index1).Substring((strArray1(index1).IndexOf("="c) + 1)).Split(" "c)
                    Dim bytes As Byte() = New Byte(strArray2.Length - 3) {}
                    Dim num2 As Integer = (bytes.Length - 1)
                    Dim index2 As Integer = 0

                    While index2 <= num2
                        bytes(index2) = Convert.ToByte(strArray2((index2 + 2)), 16)
                        index2 += 1
                    End While
                    ' MsgBox(Encoding.UTF8.GetString(bytes).Length)
                    dictionary.Add("data_nascimento", Encoding.UTF8.GetString(bytes).Substring(0, 8)) '''data nac.
                    dictionary.Add("cpf", Encoding.UTF8.GetString(bytes).Substring(8, 11)) '''cpf
                    dictionary.Add("pis", Encoding.UTF8.GetString(bytes).Substring(19, 11)) '''pis
                    dictionary.Add("rg", Encoding.UTF8.GetString(bytes).Substring(30, 15)) ''''Rg

                End If



                index1 += 1

            End While

        Next

        dictionary.Add("data_Venc", x509Certificate2.NotAfter)


        ''''''''''''Rotina para pegar Razao Social abaixo

        razao = x509Certificate2.SubjectName.Name
        razao = razao.Remove(0, 3)
        For i As Integer = 0 To razao.Length - 1

            If razao.Substring(i, 1) = "," Then
                razao = razao.Remove(i, razao.Length - i)
                Exit For
            End If
        Next
        dictionary.Add("razao", razao)

        dictionary.Add("serial_cert", x509Certificate2.SerialNumber)


        Return dictionary
    End Function
    Public Function carregar_cert(ByVal caminho As String, password As String) As X509Certificate2

        Try


            Dim ret As New X509Certificate2(caminho, password, X509KeyStorageFlags.MachineKeySet)

            If Convert.ToDateTime(ret.NotAfter).ToString("dd/MM/yyyy") < Now.Date Then

                MsgBox("O Certificado Digital Selecionado esta Vencido !" & vbCrLf & "Operação Cancelada !", MsgBoxStyle.Exclamation, "Aviso !")

            Else

                cnpj = cnpj_cert(ret)

                If Directory.Exists(AppDomain.CurrentDomain.BaseDirectory & "\cert") = False Then
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory & "\cert")
                End If

                '' FileCopy(caminho, AppDomain.CurrentDomain.BaseDirectory & "\cert\" & cnpj & Convert.ToDateTime(ret.NotAfter).ToString("yyyy") & ".pfx")

                '  MsgBox("Certificado foi salvo No sistema !", MsgBoxStyle.Information, "Aviso !")

                Return ret
            End If



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Aviso !")
            Return Nothing
        End Try

    End Function
End Module
