<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
Public Class SignatureSignedInfoReferenceDigestMethod

    Private algorithmField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property Algorithm() As String
        Get
            Return Me.algorithmField
        End Get
        Set(value As String)
            Me.algorithmField = value
        End Set
    End Property
End Class