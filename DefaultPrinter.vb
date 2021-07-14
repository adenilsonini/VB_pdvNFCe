Imports System.Runtime.InteropServices

Public Class DefaultPrinter


#Region "GetDefaultPrinter"
    <DllImport("winspool.drv", EntryPoint:="GetDefaultPrinter", _
         SetLastError:=True, CharSet:=CharSet.Auto, _
         ExactSpelling:=False, _
         CallingConvention:=CallingConvention.StdCall)> _
    Private Shared Function GetDefaultPrinter(ByVal pszBuffer As System.Text.StringBuilder, _
                                              ByRef BufferSize As Int32) As Boolean

    End Function
#End Region

#Region "SetDefaultPrinter"
    <DllImport("winspool.drv", EntryPoint:="SetDefaultPrinter", _
         SetLastError:=True, CharSet:=CharSet.Auto, _
         ExactSpelling:=False, _
         CallingConvention:=CallingConvention.StdCall)> _
    Private Shared Function SetDefaultPrinter(ByVal PrinterName As String) As Boolean

    End Function
#End Region

    Public Shared Property DefaultPrinterName() As String
        Get
            '\\ Go through the list of printers and return the default one
            Dim lpsRet As New System.Text.StringBuilder(256), chars As Integer = 256
            If GetDefaultPrinter(lpsRet, chars) Then

            End If
            Return lpsRet.ToString
        End Get
        Set(ByVal value As String)
            '\\ Go through the list of printers and if you find the one named as above make it the default
            If Not SetDefaultPrinter(value) Then
                Trace.WriteLine("Ocorreu um falha no Procedimento : " & value)
            End If
        End Set
    End Property

End Class