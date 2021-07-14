Imports System.Xml.Serialization

'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe"), _
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe", IsNullable:=False)> _
Partial Public Class retDistDFeInt

    Private tpAmbField As Byte

    Private verAplicField As String

    Private cStatField As String

    Private xMotivoField As String

    Private dhRespField As Date

    Private ultNSUField As String

    Private maxNSUField As String

    Private loteDistDFeIntField() As retDistDFeIntDocZip

    Private versaoField As Decimal

    '''<remarks/>
    Public Property tpAmb() As Byte
        Get
            Return Me.tpAmbField
        End Get
        Set(value As Byte)
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
    Public Property dhResp() As Date
        Get
            Return Me.dhRespField
        End Get
        Set(value As Date)
            Me.dhRespField = value
        End Set
    End Property

    '''<remarks/>
    Public Property ultNSU() As String
        Get
            Return Me.ultNSUField
        End Get
        Set(value As String)
            Me.ultNSUField = value
        End Set
    End Property

    '''<remarks/>
    Public Property maxNSU() As String
        Get
            Return Me.maxNSUField
        End Get
        Set(value As String)
            Me.maxNSUField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlArrayItemAttribute("docZip", IsNullable:=False)> _
    Public Property loteDistDFeInt() As retDistDFeIntDocZip()
        Get
            Return Me.loteDistDFeIntField
        End Get
        Set(value As retDistDFeIntDocZip())
            Me.loteDistDFeIntField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property versao() As Decimal
        Get
            Return Me.versaoField
        End Get
        Set(value As Decimal)
            Me.versaoField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
Partial Public Class retDistDFeIntDocZip

    Private nSUField As UShort

    Private schemaField As String

    Private valueField As Byte()

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property NSU() As UShort
        Get
            Return Me.nSUField
        End Get
        Set(value As UShort)
            Me.nSUField = value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()> _
    Public Property schema() As String
        Get
            Return Me.schemaField
        End Get
        Set(value As String)
            Me.schemaField = value
        End Set
    End Property


    <XmlText(DataType:="base64Binary")>
    Public Property Value As Byte()
        Get
            Return Me.valueField
        End Get
        Set(ByVal value As Byte())
            Me.valueField = value
        End Set
    End Property
End Class

