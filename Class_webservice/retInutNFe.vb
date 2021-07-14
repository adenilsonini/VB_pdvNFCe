
'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe"), _
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe", IsNullable:=False)> _
Partial Public Class retInutNFe

    Private infInutField As retInutNFeInfInut

    Private versaoField As Decimal

    Private xmlField As String

    '''<remarks/>
    Public Property infInut() As retInutNFeInfInut
        Get
            Return Me.infInutField
        End Get
        Set(value As retInutNFeInfInut)
            Me.infInutField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As Decimal
        Get
            Return Me.versaoField
        End Get
        Set(value As Decimal)
            Me.versaoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property xml() As String
        Get
            Return Me.xmlField
        End Get
        Set(value As String)
            Me.xmlField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
Partial Public Class retInutNFeInfInut

    Private tpAmbField As String

    Private verAplicField As String

    Private cStatField As String

    Private xMotivoField As String

    Private cUFField As String

    Private anoField As String

    Private cNPJField As String

    Private modField As String

    Private serieField As String

    Private nNFIniField As String

    Private nNFFinField As String

    Private dhRecbtoField As Date

    Private idField As String

    Private nProtField As String


  
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
            Me.verAplicField = value
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
            Me.xMotivoField = value
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
    Public Property ano() As String
        Get
            Return Me.anoField
        End Get
        Set(value As String)
            Me.anoField = value
        End Set
    End Property

    '''<remarks/>
    Public Property CNPJ() As String
        Get
            Return Me.cNPJField
        End Get
        Set(value As String)
            Me.cNPJField = value
        End Set
    End Property

    '''<remarks/>
    Public Property [mod]() As String
        Get
            Return Me.modField
        End Get
        Set(value As String)
            Me.modField = value
        End Set
    End Property

    '''<remarks/>
    Public Property serie() As String
        Get
            Return Me.serieField
        End Get
        Set(value As String)
            Me.serieField = value
        End Set
    End Property

    '''<remarks/>
    Public Property nNFIni() As String
        Get
            Return Me.nNFIniField
        End Get
        Set(value As String)
            Me.nNFIniField = value
        End Set
    End Property

    '''<remarks/>
    Public Property nNFFin() As String
        Get
            Return Me.nNFFinField
        End Get
        Set(value As String)
            Me.nNFFinField = value
        End Set
    End Property

    '''<remarks/>
    Public Property dhRecbto() As Date
        Get
            Return Me.dhRecbtoField
        End Get
        Set(value As Date)
            Me.dhRecbtoField = value
        End Set
    End Property

    Public Property nProt() As String
        Get
            Return Me.nProtField
        End Get
        Set(value As String)
            Me.nProtField = value
        End Set
    End Property
    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property Id() As String
        Get
            Return Me.idField
        End Get
        Set(value As String)
            Me.idField = value
        End Set
    End Property
End Class

