
'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe"), _
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe", IsNullable:=False)> _
Partial Public Class retConsCad

    Private infConsField As retConsCadInfCons

    Private versaoField As Decimal

    '''<remarks/>
    Public Property infCons() As retConsCadInfCons
        Get
            Return Me.infConsField
        End Get
        Set(value As retConsCadInfCons)
            Me.infConsField = Value
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
End Class

'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
Partial Public Class retConsCadInfCons

    Private verAplicField As String

    Private cStatField As Byte

    Private xMotivoField As String

    Private ufField As String

    Private cNPJField As ULong

    Private dhConsField As Date

    Private cUFField As Byte

    Private infCadField As retConsCadInfConsInfCad

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
    Public Property cStat() As Byte
        Get
            Return Me.cStatField
        End Get
        Set(value As Byte)
            Me.cStatField = Value
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
    Public Property UF() As String
        Get
            Return Me.ufField
        End Get
        Set(value As String)
            Me.ufField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CNPJ() As ULong
        Get
            Return Me.cNPJField
        End Get
        Set(value As ULong)
            Me.cNPJField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property dhCons() As Date
        Get
            Return Me.dhConsField
        End Get
        Set(value As Date)
            Me.dhConsField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property cUF() As Byte
        Get
            Return Me.cUFField
        End Get
        Set(value As Byte)
            Me.cUFField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property infCad() As retConsCadInfConsInfCad
        Get
            Return Me.infCadField
        End Get
        Set(value As retConsCadInfConsInfCad)
            Me.infCadField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
Partial Public Class retConsCadInfConsInfCad

    Private ieField As ULong

    Private cNPJField As ULong

    Private ufField As String

    Private cSitField As Byte

    Private indCredNFeField As Byte

    Private indCredCTeField As Byte

    Private xNomeField As String

    Private xRegApurField As String

    Private cNAEField As UInteger

    Private dIniAtivField As Date

    Private dUltSitField As Date

    Private iEAtualField As ULong

    Private enderField As retConsCadInfConsInfCadEnder

    '''<remarks/>
    Public Property IE() As ULong
        Get
            Return Me.ieField
        End Get
        Set(value As ULong)
            Me.ieField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CNPJ() As ULong
        Get
            Return Me.cNPJField
        End Get
        Set(value As ULong)
            Me.cNPJField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property UF() As String
        Get
            Return Me.ufField
        End Get
        Set(value As String)
            Me.ufField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property cSit() As Byte
        Get
            Return Me.cSitField
        End Get
        Set(value As Byte)
            Me.cSitField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property indCredNFe() As Byte
        Get
            Return Me.indCredNFeField
        End Get
        Set(value As Byte)
            Me.indCredNFeField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property indCredCTe() As Byte
        Get
            Return Me.indCredCTeField
        End Get
        Set(value As Byte)
            Me.indCredCTeField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property xNome() As String
        Get
            Return Me.xNomeField
        End Get
        Set(value As String)
            Me.xNomeField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property xRegApur() As String
        Get
            Return Me.xRegApurField
        End Get
        Set(value As String)
            Me.xRegApurField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CNAE() As UInteger
        Get
            Return Me.cNAEField
        End Get
        Set(value As UInteger)
            Me.cNAEField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="date")> _
    Public Property dIniAtiv() As Date
        Get
            Return Me.dIniAtivField
        End Get
        Set(value As Date)
            Me.dIniAtivField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="date")> _
    Public Property dUltSit() As Date
        Get
            Return Me.dUltSitField
        End Get
        Set(value As Date)
            Me.dUltSitField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property IEAtual() As ULong
        Get
            Return Me.iEAtualField
        End Get
        Set(value As ULong)
            Me.iEAtualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ender() As retConsCadInfConsInfCadEnder
        Get
            Return Me.enderField
        End Get
        Set(value As retConsCadInfConsInfCadEnder)
            Me.enderField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
Partial Public Class retConsCadInfConsInfCadEnder

    Private xLgrField As String

    Private nroField As Byte

    Private xBairroField As String

    Private cMunField As UInteger

    Private xMunField As String

    Private cEPField As UInteger

    '''<remarks/>
    Public Property xLgr() As String
        Get
            Return Me.xLgrField
        End Get
        Set(value As String)
            Me.xLgrField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property nro() As Byte
        Get
            Return Me.nroField
        End Get
        Set(value As Byte)
            Me.nroField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property xBairro() As String
        Get
            Return Me.xBairroField
        End Get
        Set(value As String)
            Me.xBairroField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property cMun() As UInteger
        Get
            Return Me.cMunField
        End Get
        Set(value As UInteger)
            Me.cMunField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property xMun() As String
        Get
            Return Me.xMunField
        End Get
        Set(value As String)
            Me.xMunField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CEP() As UInteger
        Get
            Return Me.cEPField
        End Get
        Set(value As UInteger)
            Me.cEPField = Value
        End Set
    End Property
End Class

