
'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe"), _
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe", IsNullable:=False)> _
Partial Public Class procInutNFe

    Private inutNFeField As procInutNFeInutNFe

    Private retInutNFeField As procInutNFeRetInutNFe

    Private versaoField As Decimal

    Private xmlField As String

    '''<remarks/>
    Public Property inutNFe() As procInutNFeInutNFe
        Get
            Return Me.inutNFeField
        End Get
        Set(value As procInutNFeInutNFe)
            Me.inutNFeField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property retInutNFe() As procInutNFeRetInutNFe
        Get
            Return Me.retInutNFeField
        End Get
        Set(value As procInutNFeRetInutNFe)
            Me.retInutNFeField = Value
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
Partial Public Class procInutNFeInutNFe

    Private infInutField As procInutNFeInutNFeInfInut

    Private signatureField As Signature

    Private versaoField As Decimal

    '''<remarks/>
    Public Property infInut() As procInutNFeInutNFeInfInut
        Get
            Return Me.infInutField
        End Get
        Set(value As procInutNFeInutNFeInfInut)
            Me.infInutField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.w3.org/2000/09/xmldsig#")> _
    Public Property Signature() As Signature
        Get
            Return Me.signatureField
        End Get
        Set(value As Signature)
            Me.signatureField = Value
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
Partial Public Class procInutNFeInutNFeInfInut

    Private tpAmbField As Byte

    Private xServField As String

    Private cUFField As Byte

    Private anoField As Byte

    Private cNPJField As ULong

    Private modField As Byte

    Private serieField As Byte

    Private nNFIniField As UShort

    Private nNFFinField As UShort

    Private xJustField As String

    Private idField As String

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
    Public Property xServ() As String
        Get
            Return Me.xServField
        End Get
        Set(value As String)
            Me.xServField = Value
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
    Public Property ano() As Byte
        Get
            Return Me.anoField
        End Get
        Set(value As Byte)
            Me.anoField = Value
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
    Public Property [mod]() As Byte
        Get
            Return Me.modField
        End Get
        Set(value As Byte)
            Me.modField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property serie() As Byte
        Get
            Return Me.serieField
        End Get
        Set(value As Byte)
            Me.serieField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property nNFIni() As UShort
        Get
            Return Me.nNFIniField
        End Get
        Set(value As UShort)
            Me.nNFIniField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property nNFFin() As UShort
        Get
            Return Me.nNFFinField
        End Get
        Set(value As UShort)
            Me.nNFFinField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property xJust() As String
        Get
            Return Me.xJustField
        End Get
        Set(value As String)
            Me.xJustField = Value
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

'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
Partial Public Class procInutNFeRetInutNFe

    Private infInutField As procInutNFeRetInutNFeInfInut

    Private versaoField As Decimal

    '''<remarks/>
    Public Property infInut() As procInutNFeRetInutNFeInfInut
        Get
            Return Me.infInutField
        End Get
        Set(value As procInutNFeRetInutNFeInfInut)
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
End Class

'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
Partial Public Class procInutNFeRetInutNFeInfInut

    Private tpAmbField As Byte

    Private verAplicField As String

    Private cStatField As Byte

    Private xMotivoField As String

    Private cUFField As Byte

    Private anoField As Byte

    Private cNPJField As ULong

    Private modField As Byte

    Private serieField As Byte

    Private nNFIniField As UShort

    Private nNFFinField As UShort

    Private dhRecbtoField As Date

    Private nProtField As ULong

    Private idField As String

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
    Public Property ano() As Byte
        Get
            Return Me.anoField
        End Get
        Set(value As Byte)
            Me.anoField = Value
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
    Public Property [mod]() As Byte
        Get
            Return Me.modField
        End Get
        Set(value As Byte)
            Me.modField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property serie() As Byte
        Get
            Return Me.serieField
        End Get
        Set(value As Byte)
            Me.serieField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property nNFIni() As UShort
        Get
            Return Me.nNFIniField
        End Get
        Set(value As UShort)
            Me.nNFIniField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property nNFFin() As UShort
        Get
            Return Me.nNFFinField
        End Get
        Set(value As UShort)
            Me.nNFFinField = Value
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
    Public Property nProt() As ULong
        Get
            Return Me.nProtField
        End Get
        Set(value As ULong)
            Me.nProtField = Value
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

