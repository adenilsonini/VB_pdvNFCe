<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
Public Class SignatureKeyInfoX509Data

    Private x509CertificateField As String

    '''<remarks/>
    Public Property X509Certificate() As String
        Get
            Return Me.x509CertificateField
        End Get
        Set(value As String)
            Me.x509CertificateField = value
        End Set
    End Property
End Class