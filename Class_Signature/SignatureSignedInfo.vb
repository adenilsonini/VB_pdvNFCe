<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
Public Class SignatureSignedInfo

    Private canonicalizationMethodField As SignatureSignedInfoCanonicalizationMethod

    Private signatureMethodField As SignatureSignedInfoSignatureMethod

    Private referenceField As SignatureSignedInfoReference

    '''<remarks/>
    Public Property CanonicalizationMethod() As SignatureSignedInfoCanonicalizationMethod
        Get
            Return Me.canonicalizationMethodField
        End Get
        Set(value As SignatureSignedInfoCanonicalizationMethod)
            Me.canonicalizationMethodField = value
        End Set
    End Property

    '''<remarks/>
    Public Property SignatureMethod() As SignatureSignedInfoSignatureMethod
        Get
            Return Me.signatureMethodField
        End Get
        Set(value As SignatureSignedInfoSignatureMethod)
            Me.signatureMethodField = value
        End Set
    End Property

    '''<remarks/>
    Public Property Reference() As SignatureSignedInfoReference
        Get
            Return Me.referenceField
        End Get
        Set(value As SignatureSignedInfoReference)
            Me.referenceField = value
        End Set
    End Property
End Class