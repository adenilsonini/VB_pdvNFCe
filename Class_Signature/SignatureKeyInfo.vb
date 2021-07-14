<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
Public Class SignatureKeyInfo

    Private x509DataField As SignatureKeyInfoX509Data

    '''<remarks/>
    Public Property X509Data() As SignatureKeyInfoX509Data
        Get
            Return Me.x509DataField
        End Get
        Set(value As SignatureKeyInfoX509Data)
            Me.x509DataField = value
        End Set
    End Property
End Class