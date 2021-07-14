
'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe"), _
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe", IsNullable:=False)> _
Partial Public Class retConsSitNFe

    Private tpAmbField As String

    Private verAplicField As String

    Private cStatField As String

    Private xMotivoField As String

    Private cUFField As String

    Private dhRecbtoField As Date

    Private chNFeField As String

    Private protNFeField As retConsSitNFeProtNFe

    Private procEventoNFeField As retConsSitNFeProcEventoNFe

    Private versaoField As String

    Private xmlField As String

    Private xmlprotField As String

    Private xmlproceventField As String

    '''<remarks/>
    Public Property tpAmb() As String
        Get
            Return Me.tpAmbField
        End Get
        Set(value As String)
            Me.tpAmbField = value
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

    Public Property xmlprocevent() As String
        Get
            Return Me.xmlproceventField
        End Get
        Set(value As String)
            Me.xmlproceventField = value
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
    Public Property protNFe() As retConsSitNFeProtNFe
        Get
            Return Me.protNFeField
        End Get
        Set(value As retConsSitNFeProtNFe)
            Me.protNFeField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property procEventoNFe() As retConsSitNFeProcEventoNFe
        Get
            Return Me.procEventoNFeField
        End Get
        Set(value As retConsSitNFeProcEventoNFe)
            Me.procEventoNFeField = Value
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
Partial Public Class retConsSitNFeProtNFe

    Private infProtField As retConsSitNFeProtNFeInfProt

    Private versaoField As String

    '''<remarks/>
    Public Property infProt() As retConsSitNFeProtNFeInfProt
        Get
            Return Me.infProtField
        End Get
        Set(value As retConsSitNFeProtNFeInfProt)
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
Partial Public Class retConsSitNFeProtNFeInfProt

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

'''<remarks/>
<System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.portalfiscal.inf.br/nfe")> _
Partial Public Class retConsSitNFeProcEventoNFe

    Private eventoField As retConsSitNFeProcEventoNFeEvento

    Private retEventoField As retConsSitNFeProcEventoNFeRetEvento

    Private versaoField As String

    '''<remarks/>
    Public Property evento() As retConsSitNFeProcEventoNFeEvento
        Get
            Return Me.eventoField
        End Get
        Set(value As retConsSitNFeProcEventoNFeEvento)
            Me.eventoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property retEvento() As retConsSitNFeProcEventoNFeRetEvento
        Get
            Return Me.retEventoField
        End Get
        Set(value As retConsSitNFeProcEventoNFeRetEvento)
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
Partial Public Class retConsSitNFeProcEventoNFeEvento

    Private infEventoField As retConsSitNFeProcEventoNFeEventoInfEvento

    Private signatureField As Signature

    Private versaoField As String

    '''<remarks/>
    Public Property infEvento() As retConsSitNFeProcEventoNFeEventoInfEvento
        Get
            Return Me.infEventoField
        End Get
        Set(value As retConsSitNFeProcEventoNFeEventoInfEvento)
            Me.infEventoField = Value
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
Partial Public Class retConsSitNFeProcEventoNFeEventoInfEvento

    Private cOrgaoField As String

    Private tpAmbField As String

    Private cNPJField As String

    Private chNFeField As String

    Private dhEventoField As Date

    Private tpEventoField As String

    Private nSeqEventoField As String

    Private verEventoField As String

    Private detEventoField As retConsSitNFeProcEventoNFeEventoInfEventoDetEvento

    Private idField As String

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
    Public Property tpAmb() As String
        Get
            Return Me.tpAmbField
        End Get
        Set(value As String)
            Me.tpAmbField = value
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
    Public Property dhEvento() As Date
        Get
            Return Me.dhEventoField
        End Get
        Set(value As Date)
            Me.dhEventoField = Value
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
    Public Property nSeqEvento() As String
        Get
            Return Me.nSeqEventoField
        End Get
        Set(value As String)
            Me.nSeqEventoField = value
        End Set
    End Property

    '''<remarks/>
    Public Property verEvento() As String
        Get
            Return Me.verEventoField
        End Get
        Set(value As String)
            Me.verEventoField = value
        End Set
    End Property

    '''<remarks/>
    Public Property detEvento() As retConsSitNFeProcEventoNFeEventoInfEventoDetEvento
        Get
            Return Me.detEventoField
        End Get
        Set(value As retConsSitNFeProcEventoNFeEventoInfEventoDetEvento)
            Me.detEventoField = Value
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
Partial Public Class retConsSitNFeProcEventoNFeEventoInfEventoDetEvento

    Private descEventoField As String

    Private nProtField As String

    Private xJustField As String

    Private versaoField As String

    '''<remarks/>
    Public Property descEvento() As String
        Get
            Return Me.descEventoField
        End Get
        Set(value As String)
            Me.descEventoField = Value
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
Partial Public Class retConsSitNFeProcEventoNFeRetEvento

    Private infEventoField As retConsSitNFeProcEventoNFeRetEventoInfEvento

    Private versaoField As String

    '''<remarks/>
    Public Property infEvento() As retConsSitNFeProcEventoNFeRetEventoInfEvento
        Get
            Return Me.infEventoField
        End Get
        Set(value As retConsSitNFeProcEventoNFeRetEventoInfEvento)
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
Partial Public Class retConsSitNFeProcEventoNFeRetEventoInfEvento

    Private tpAmbField As String

    Private verAplicField As String

    Private cOrgaoField As String

    Private cStatField As String

    Private xMotivoField As String

    Private chNFeField As String

    Private tpEventoField As String

    Private xEventoField As String

    Private nSeqEventoField As String

    Private cNPJDestField As String

    Private dhRegEventoField As Date

    Private nProtField As String

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
    Public Property CNPJDest() As String
        Get
            Return Me.cNPJDestField
        End Get
        Set(value As String)
            Me.cNPJDestField = value
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


