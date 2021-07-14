Imports System.Runtime.CompilerServices

Public Module funcaogeracodnfe
    Public Function zeroEsquerda(ByVal Numero As Long, ByVal Zeros As Byte) As String

        Dim i As Byte



        'verifica se o numero é maor que o padrão

        On Error GoTo zeroEsquerda_Error



        If Len(CStr(Numero)) > Zeros Then

            zeroEsquerda = Microsoft.VisualBasic.Right(CStr(Numero), 9)

        Else

            zeroEsquerda = Numero

        End If

        'coloca zeros a esquerda

        For i = Len(CStr(Numero)) To Zeros - 1

            zeroEsquerda = "0" & zeroEsquerda

        Next



        Exit Function

zeroEsquerda_Error:

        MsgBox("Erro: " & Err.Number & vbNewLine & "Procedure zeroEsquerda localizado em ChaveDV, na linha " & Erl(), vbCritical, Err.Source)

        'Fun.LogErro(Err.Number, Err.Description, Err.Source, "Procedure zeroEsquerda localizado em ChaveDV", Erl)

    End Function

    <Extension()>
    Public Function Left(ByVal sValue As String, ByVal iMaxLength As Integer) As String
        If String.IsNullOrEmpty(sValue) Then
            sValue = String.Empty
        ElseIf String.IsNullOrWhiteSpace(sValue) Then
            sValue = String.Empty
        ElseIf sValue.Length >= iMaxLength Then
            sValue = sValue.Substring(0, iMaxLength)
        End If

        Return sValue
    End Function

    <Extension()>
    Public Function Right(ByVal sValue As String, ByVal iMaxLength As Integer) As String
        If String.IsNullOrEmpty(sValue) Then
            sValue = String.Empty
        ElseIf sValue.Length > iMaxLength Then
            sValue = sValue.Substring(sValue.Length - iMaxLength, iMaxLength)
        End If

        Return sValue
    End Function

    Public Function ValidarEAN13(ByVal CodigoEAN13 As String) As Boolean
        Dim result As Boolean = (CodigoEAN13.Length = 13)

        If result Then
            Const checkSum As String = "131313131313"
            Dim digito As Integer = Integer.Parse(CodigoEAN13(CodigoEAN13.Length - 1).ToString())
            Dim ean As String = CodigoEAN13.Substring(0, CodigoEAN13.Length - 1)
            Dim sum As Integer = 0

            For i As Integer = 0 To ean.Length - 1
                sum += Integer.Parse(ean(i).ToString()) * Integer.Parse(checkSum(i).ToString())
            Next

            Dim calculo As Integer = 10 - (sum Mod 10)
            result = (digito = calculo)
        End If

        Return result
    End Function

    Public Function Moeda(ByVal Valor As Double, Optional ByVal Casas As Integer = 2) As Double
        Try
            Return Format(Valor, "###0.00")
            ' Return Convert.ToDouble(String.Format("{0:N" & CObj(Casas) & "}", CObj(Valor)))
        Catch ex As Exception
            Return 0.0
        End Try
    End Function
    Public Function FormatABNT(ByVal Valor As String) As Decimal
        Try
            If Valor = "" Then Valor = "0"

            If Valor.Substring(Valor.IndexOf(",") + 3, 1) = "5" Then
                Dim num As Double = Convert.ToDouble(Valor.Substring(Valor.IndexOf(",") + 2, 1))
                Valor = If(Not (num = 0.0 Or num = 2.0 Or num = 4.0 Or num = 6.0 Or num = 8.0), Moeda(Convert.ToDouble(Valor), 2).ToString(), (If(Convert.ToDouble(Valor.Substring(Valor.IndexOf(",") + 4, 1)) <> 0.0, Moeda(Convert.ToDouble(Valor), 2).ToString(), Moeda(Convert.ToDouble(Truncar(Valor)), 2).ToString())))
            Else
                Valor = Moeda(Convert.ToDouble(Valor), 2).ToString()
            End If

        Catch ex As Exception
        End Try

        Return Convert.ToDecimal(Valor)
    End Function

    Public Function gvgpt(ByVal sEntrada As String) As String
        If sEntrada = "" OrElse sEntrada = "0.00" Then Return "0"
        sEntrada = sEntrada.Replace(".", "")
        Return sEntrada.Replace(",", ".")
    End Function
    Public Function Truncar(ByVal valor2 As String) As String
        Dim d As Double = Convert.ToDouble(valor2)

        Try

            d *= 100.0
            d = Math.Truncate(d)
            d /= 100.0
        Catch ex As Exception
        End Try

        Return CSharpImpl.__Assign(valor2, d.ToString())
    End Function

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class

    Public Function gVgPt2(ByVal Entrada As Double, Optional ByVal Invert As Boolean = True) As Double
        Dim str As String = Convert.ToString(Entrada)

        If Invert Then
            str.Replace(","c, Chr(0))
            Entrada = Convert.ToDouble(str.Replace("."c, ","c))
            Return Entrada
        End If

        Entrada = Convert.ToDouble(str.Replace("."c, Chr(0)).Replace(","c, "."c))
        Return Entrada
    End Function

    Public Function GetIPv4Address() As String
        GetIPv4Address = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIPv4Address = ipheal.ToString()
            End If
        Next

    End Function
End Module
