<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
Public Class SignatureSignedInfoReference

    Private transformsField() As SignatureSignedInfoReferenceTransform

    Private digestMethodField As SignatureSignedInfoReferenceDigestMethod

    Private digestValueField As String

    Private uRIField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlArrayItemAttribute("Transform", IsNullable:=False)> _
    Public Property Transforms() As SignatureSignedInfoReferenceTransform()
        Get
            Return Me.transformsField
        End Get
        Set(value As SignatureSignedInfoReferenceTransform())
            Me.transformsField = value
        End Set
    End Property

    '''<remarks/>
    Public Property DigestMethod() As SignatureSignedInfoReferenceDigestMethod
        Get
            Return Me.digestMethodField
        End Get
        Set(value As SignatureSignedInfoReferenceDigestMethod)
            Me.digestMethodField = value
        End Set
    End Property

    '''<remarks/>
    Public Property DigestValue() As String
        Get
            Return Me.digestValueField
        End Get
        Set(value As String)
            Me.digestValueField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property URI() As String
        Get
            Return Me.uRIField
        End Get
        Set(value As String)
            Me.uRIField = value
        End Set
    End Property
End Class
