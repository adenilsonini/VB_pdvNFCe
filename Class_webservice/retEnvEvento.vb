
'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe"), _
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe", IsNullable:=False)> _
Partial Public Class retEnvEvento

    Private idLoteField As String

    Private tpAmbField As String

    Private verAplicField As String

    Private cOrgaoField As String

    Private cStatField As String

    Private xMotivoField As String

    Private retEventoField() As retEnvEventoRetEvento

    Private versaoField As String

    Public xml_ret As New List(Of String)

    '''<remarks/>
    Public Property idLote() As String
        Get
            Return Me.idLoteField
        End Get
        Set(value As String)
            Me.idLoteField = value
        End Set
    End Property

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
    Public Property cOrgao() As String
        Get
            Return Me.cOrgaoField
        End Get
        Set(value As String)
            Me.cOrgaoField = value
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
    <System.Xml.Serialization.XmlElementAttribute("retEvento")> _
    Public Property retEvento() As retEnvEventoRetEvento()
        Get
            Return Me.retEventoField
        End Get
        Set(value As retEnvEventoRetEvento())
            Me.retEventoField = Value
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
Partial Public Class retEnvEventoRetEvento

    Private infEventoField As retEnvEventoRetEventoInfEvento

    Private versaoField As Decimal

    '''<remarks/>
    Public Property infEvento() As retEnvEventoRetEventoInfEvento
        Get
            Return Me.infEventoField
        End Get
        Set(value As retEnvEventoRetEventoInfEvento)
            Me.infEventoField = Value
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
Partial Public Class retEnvEventoRetEventoInfEvento

    Private tpAmbField As String

    Private verAplicField As String

    Private cOrgaoField As String

    Private cStatField As String

    Private xMotivoField As String

    Private chNFeField As String

    Private tpEventoField As String

    Private xEventoField As String

    Private nSeqEventoField As String

    Private dhRegEventoField As Date

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
            Me.verAplicField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property cOrgao() As String
        Get
            Return Me.cOrgaoField
        End Get
        Set(value As String)
            Me.cOrgaoField = value
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
    Public Property tpEvento() As String
        Get
            Return Me.tpEventoField
        End Get
        Set(value As String)
            Me.tpEventoField = value
        End Set
    End Property

    '''<remarks/>
    Public Property xEvento() As String
        Get
            Return Me.xEventoField
        End Get
        Set(value As String)
            Me.xEventoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property nSeqEvento() As String
        Get
            Return Me.nSeqEventoField
        End Get
        Set(value As String)
            Me.nSeqEventoField = value
        End Set
    End Property

    '''<remarks/>
    Public Property dhRegEvento() As Date
        Get
            Return Me.dhRegEventoField
        End Get
        Set(value As Date)
            Me.dhRegEventoField = Value
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
End Class



