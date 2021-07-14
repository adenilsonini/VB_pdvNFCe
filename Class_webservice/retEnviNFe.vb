
'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe"), _
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe", IsNullable:=False)> _
Partial Public Class retEnviNFe

    Private tpAmbField As Byte

    Private verAplicField As String

    Private cStatField As Byte

    Private xMotivoField As String

    Private cUFField As Byte

    Private dhRecbtoField As Date

    Private infRecField As retEnviNFeInfRec

    Private versaoField As Decimal

    '''<remarks/>
    Public Property tpAmb() As Byte
        Get
            Return Me.tpAmbField
        End Get
        Set(value As Byte)
            Me.tpAmbField = Value
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
    Public Property cUF() As Byte
        Get
            Return Me.cUFField
        End Get
        Set(value As Byte)
            Me.cUFField = Value
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
    Public Property infRec() As retEnviNFeInfRec
        Get
            Return Me.infRecField
        End Get
        Set(value As retEnviNFeInfRec)
            Me.infRecField = Value
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
Partial Public Class retEnviNFeInfRec

    Private nRecField As ULong

    Private tMedField As Byte

    '''<remarks/>
    Public Property nRec() As ULong
        Get
            Return Me.nRecField
        End Get
        Set(value As ULong)
            Me.nRecField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property tMed() As Byte
        Get
            Return Me.tMedField
        End Get
        Set(value As Byte)
            Me.tMedField = Value
        End Set
    End Property
End Class


