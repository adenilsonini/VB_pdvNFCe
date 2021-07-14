
'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe"), _
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe", IsNullable:=False)> _
Partial Public Class retConsReciNFe

    Private tpAmbField As String

    Private verAplicField As String

    Private nRecField As String

    Private cStatField As String

    Private xMotivoField As String

    Private cUFField As String

    Private dhRecbtoField As Date

    Private protNFeField As retConsReciNFeProtNFe

    Private versaoField As String

    Private xmlprotField As String

    '''<remarks/>
    Public Property tpAmb() As String
        Get
            Return Me.tpAmbField
        End Get
        Set(value As String)
            Me.tpAmbField = value
        End Set
    End Property

    '''<remarks/>
    Public Property verAplic() As String
        Get
            Return Me.verAplicField
        End Get
        Set(value As String)
            Me.verAplicField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property nRec() As String
        Get
            Return Me.nRecField
        End Get
        Set(value As String)
            Me.nRecField = value
        End Set
    End Property

    '''<remarks/>
    Public Property cStat() As String
        Get
            Return Me.cStatField
        End Get
        Set(value As String)
            Me.cStatField = value
        End Set
    End Property

    '''<remarks/>
    Public Property xMotivo() As String
        Get
            Return Me.xMotivoField
        End Get
        Set(value As String)
            Me.xMotivoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property cUF() As String
        Get
            Return Me.cUFField
        End Get
        Set(value As String)
            Me.cUFField = value
        End Set
    End Property

    '''<remarks/>
    Public Property dhRecbto() As Date
        Get
            Return Me.dhRecbtoField
        End Get
        Set(value As Date)
            Me.dhRecbtoField = Value
        End Set
    End Property


    Public Property xmlprot() As String
        Get
            Return Me.xmlprotField
        End Get
        Set(value As String)
            Me.xmlprotField = value
        End Set
    End Property
    '''<remarks/>
    Public Property protNFe() As retConsReciNFeProtNFe
        Get
            Return Me.protNFeField
        End Get
        Set(value As retConsReciNFeProtNFe)
            Me.protNFeField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
        Get
            Return Me.versaoField
        End Get
        Set(value As String)
            Me.versaoField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
Partial Public Class retConsReciNFeProtNFe

    Private infProtField As retConsReciNFeProtNFeInfProt

    Private versaoField As String

    '''<remarks/>
    Public Property infProt() As retConsReciNFeProtNFeInfProt
        Get
            Return Me.infProtField
        End Get
        Set(value As retConsReciNFeProtNFeInfProt)
            Me.infProtField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As String
        Get
            Return Me.versaoField
        End Get
        Set(value As String)
            Me.versaoField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
Partial Public Class retConsReciNFeProtNFeInfProt

    Private tpAmbField As String

    Private verAplicField As String

    Private chNFeField As String

    Private dhRecbtoField As Date

    Private nProtField As String

    Private digValField As String

    Private cStatField As String

    Private xMotivoField As String

    Private idField As String

    '''<remarks/>
    Public Property tpAmb() As String
        Get
            Return Me.tpAmbField
        End Get
        Set(value As String)
            Me.tpAmbField = value
        End Set
    End Property

    '''<remarks/>
    Public Property verAplic() As String
        Get
            Return Me.verAplicField
        End Get
        Set(value As String)
            Me.verAplicField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")> _
    Public Property chNFe() As String
        Get
            Return Me.chNFeField
        End Get
        Set(value As String)
            Me.chNFeField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property dhRecbto() As Date
        Get
            Return Me.dhRecbtoField
        End Get
        Set(value As Date)
            Me.dhRecbtoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property nProt() As String
        Get
            Return Me.nProtField
        End Get
        Set(value As String)
            Me.nProtField = value
        End Set
    End Property

    '''<remarks/>
    Public Property digVal() As String
        Get
            Return Me.digValField
        End Get
        Set(value As String)
            Me.digValField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property cStat() As String
        Get
            Return Me.cStatField
        End Get
        Set(value As String)
            Me.cStatField = value
        End Set
    End Property

    '''<remarks/>
    Public Property xMotivo() As String
        Get
            Return Me.xMotivoField
        End Get
        Set(value As String)
            Me.xMotivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property Id() As String
        Get
            Return Me.idField
        End Get
        Set(value As String)
            Me.idField = Value
        End Set
    End Property
End Class

