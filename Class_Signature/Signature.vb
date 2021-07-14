<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2000/09/xmldsig#"), _
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#", IsNullable:=False)> _
Public Class Signature

    Private signedInfoField As SignatureSignedInfo

    Private signatureValueField As String

    Private keyInfoField As SignatureKeyInfo

    '''<remarks/>
    Public Property SignedInfo() As SignatureSignedInfo
        Get
            Return Me.signedInfoField
        End Get
        Set(value As SignatureSignedInfo)
            Me.signedInfoField = value
        End Set
    End Property

    '''<remarks/>
    Public Property SignatureValue() As String
        Get
            Return Me.signatureValueField
        End Get
        Set(value As String)
            Me.signatureValueField = value
        End Set
    End Property

    '''<remarks/>
    Public Property KeyInfo() As SignatureKeyInfo
        Get
            Return Me.keyInfoField
        End Get
        Set(value As SignatureKeyInfo)
            Me.keyInfoField = value
        End Set
    End Property
End Class
