Imports System.Xml.Serialization


<XmlRoot(DataType:="string", ElementName:="retConsStatServ", [Namespace]:="http://www.portalfiscal.inf.br/nfe")>
Public Class retConsStatServ
    Private m_versao As String
    Private m_tpAmb As String
    Private m_verAplic As String
    Private m_cStat As Integer
    Private m_xMotivo As String
    Private m_cUF As String

    <XmlAttribute>
    Public Property versao As String
        Get
            Return Me.m_versao
        End Get
        Set(ByVal value As String)
            Me.m_versao = value
        End Set
    End Property

    Public Property tpAmb As String
        Get
            Return Me.m_tpAmb
        End Get
        Set(ByVal value As String)
            Me.m_tpAmb = value
        End Set
    End Property

    Public Property verAplic As String
        Get
            Return Me.m_verAplic
        End Get
        Set(ByVal value As String)
            Me.m_verAplic = value
        End Set
    End Property

    Public Property cStat As Integer
        Get
            Return Me.m_cStat
        End Get
        Set(ByVal value As Integer)
            Me.m_cStat = value
        End Set
    End Property

    Public Property xMotivo As String
        Get
            Return Me.m_xMotivo
        End Get
        Set(ByVal value As String)
            Me.m_xMotivo = value
        End Set
    End Property

    Public Property cUF As String
        Get
            Return Me.m_cUF
        End Get
        Set(ByVal value As String)
            Me.m_cUF = value
        End Set
    End Property
End Class

