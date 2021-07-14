
Imports MessagingToolkit.QRCode.Codec
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Windows.Forms
Imports System.Xml

Imports System.Net
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports Newtonsoft.Json

Module seft_host
    Public Function SendRequest(ByVal uri As Uri, ByVal jsonDataBytes As Byte(), Optional ByVal Str_Authorization As String = "") As String
        Try
            Dim webRequest As WebRequest = webRequest.Create(uri)
            webRequest.ContentType = "application/json"
            webRequest.Method = "POST"

            If Operators.CompareString(Str_Authorization.Trim(), "", False) <> 0 Then
                webRequest.PreAuthenticate = True
                webRequest.Headers.Add("Authorization", Str_Authorization)
            End If

            '   Dim num As Integer = Conversions.ToInteger(mdlGeral.LeINI("WSLINEAR", "TIMEOUTWSLINEAR", "10000", ""))
            Dim num As Integer = 15000
            If num < 6000 Then num = 6000
            webRequest.Timeout = num

            Dim Left As String = "POST"

            If Operators.CompareString(Left, "POST", False) <> 0 AndAlso Operators.CompareString(Left, "DELETE", False) <> 0 Then

                If Operators.CompareString(Left, "GET", False) = 0 Then
                End If
            Else
                webRequest.ContentLength = CLng(jsonDataBytes.Length)
                Dim requestStream As Stream = webRequest.GetRequestStream()
                requestStream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
                requestStream.Close()
            End If


            Dim response As Net.HttpWebResponse = webRequest.GetResponse()
            Dim ret As String
            If response.StatusCode = Net.HttpStatusCode.OK Then
                Dim responseStream As IO.StreamReader = New IO.StreamReader(response.GetResponseStream())
                ret = responseStream.ReadToEnd()

                ret = JsonConvert.DeserializeObject(ret)

            End If
            response.Close()

            Return ret


        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim exception As Exception = ex
            ' mdlGeral.CriarLog("Erro: " & exception.Message & " // " + exception.StackTrace, NameOf(mdlGeral), NameOf(SendRequest), True, False, False)
            Return exception.Message
        End Try
    End Function

    Public Function SendRequest_list(ByVal uri As Uri, ByVal jsonDataBytes As Byte(), Optional ByVal Str_Authorization As String = "") As Dictionary(Of String, String)
        Dim json As Dictionary(Of String, String) = New Dictionary(Of String, String)

        Try

            Dim webRequest As WebRequest = webRequest.Create(uri)
            webRequest.ContentType = "application/json"
            webRequest.Method = "POST"

            If Operators.CompareString(Str_Authorization.Trim(), "", False) <> 0 Then
                webRequest.PreAuthenticate = True
                webRequest.Headers.Add("Authorization", Str_Authorization)
            End If

            '   Dim num As Integer = Conversions.ToInteger(mdlGeral.LeINI("WSLINEAR", "TIMEOUTWSLINEAR", "10000", ""))
            Dim num As Integer = 15000
            If num < 6000 Then num = 6000
            webRequest.Timeout = num

            Dim Left As String = "POST"

            If Operators.CompareString(Left, "POST", False) <> 0 AndAlso Operators.CompareString(Left, "DELETE", False) <> 0 Then

                If Operators.CompareString(Left, "GET", False) = 0 Then
                End If
            Else
                webRequest.ContentLength = CLng(jsonDataBytes.Length)
                Dim requestStream As Stream = webRequest.GetRequestStream()
                requestStream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
                requestStream.Close()
            End If


            Dim response As Net.HttpWebResponse = webRequest.GetResponse()
            Dim ret As String
            If response.StatusCode = Net.HttpStatusCode.OK Then
                Dim responseStream As IO.StreamReader = New IO.StreamReader(response.GetResponseStream())
                ret = responseStream.ReadToEnd()

                json = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(ret)

            End If
            response.Close()

            Return json


        Catch ex As Exception
            json.Add("status", "Erro rotina SendRequest_list: " & ex.Message)
            ' mdlGeral.CriarLog("Erro: " & exception.Message & " // " + exception.StackTrace, NameOf(mdlGeral), NameOf(SendRequest), True, False, False)
            Return json
        End Try
    End Function


    Public Function Enviar_Requisicao(ByVal data As Dictionary(Of String, String), ByRef Retorno As String, ByVal urlCompleta As String, Optional ByVal objPost As Object = Nothing) As Boolean
        Dim flag As Boolean

        Try
            Dim cookieContainer As CookieContainer = New CookieContainer()
            Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(urlCompleta), HttpWebRequest)
            httpWebRequest.Method = data("Method").ToString()
            httpWebRequest.ContentType = data("ContentType").ToString()
            If Operators.CompareString(data("token"), "", False) <> 0 Then httpWebRequest.Headers.Add("Authorization", data("token"))
            httpWebRequest.CookieContainer = cookieContainer
            httpWebRequest.Timeout = 8000
            Dim Left As String = data("Method")

            If Operators.CompareString(Left, "POST", False) <> 0 AndAlso Operators.CompareString(Left, "PUT", False) <> 0 Then

                If Operators.CompareString(Left, "DELETE", False) = 0 OrElse Operators.CompareString(Left, "GET", False) = 0 Then
                End If
            Else
                Dim s As String = JsonConvert.SerializeObject(RuntimeHelpers.GetObjectValue(objPost))
                Dim bytes As Byte() = Encoding.UTF8.GetBytes(s)
                ' mdlGeral.CriarLog("Json: " & s, "", "", False, False, False)
                httpWebRequest.ContentLength = CLng(bytes.Length)
                Dim requestStream As Stream = httpWebRequest.GetRequestStream()
                requestStream.Write(bytes, 0, bytes.Length)
                requestStream.Close()
            End If

            Using response As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
                Dim responseStream As Stream = response.GetResponseStream()
                Dim [end] As Object = CObj(New StreamReader(responseStream).ReadToEnd())
                responseStream.Close()
                Retorno = [end].ToString()

                Try
                    '  mdlGeral.CriarLog("Retorno Requisição Logs: " & Conversions.ToString(CInt(response.StatusCode)) & " - " + response.StatusDescription, "", "", False, False, False)
                Catch ex As Exception
                    ProjectData.SetProjectError(ex)
                    ' mdlGeral.CriarLog("Não foi possível gravar o status de retorno.", NameOf(mdlGeral), NameOf(Enviar_Requisicao), False, True, False)
                    ProjectData.ClearProjectError()
                End Try

                flag = True
            End Using

        Catch ex As WebException
            ProjectData.SetProjectError(CType(ex, Exception))
            Dim webException As WebException = ex

            If webException.Response.ContentLength <> 0L Then

                Using responseStream As Stream = webException.Response.GetResponseStream()

                    Using streamReader As StreamReader = New StreamReader(responseStream)
                        ''  mdlGeral.CriarLog("Erro: " & webException.Message & " - " + streamReader.ReadToEnd(), NameOf(mdlGeral), NameOf(Enviar_Requisicao), False, False, False)
                        Retorno = ""
                        flag = False
                        ProjectData.ClearProjectError()
                    End Using
                End Using
            Else
                ' mdlGeral.CriarLog("Erro: " & webException.Message, NameOf(mdlGeral), NameOf(Enviar_Requisicao), False, False, False)
                Retorno = ""
                flag = False
                ProjectData.ClearProjectError()
            End If

        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim exception As Exception = ex
            '  mdlGeral.CriarLog("Erro: " & exception.Message & vbCrLf + exception.StackTrace, NameOf(mdlGeral), NameOf(Enviar_Requisicao), False, False, False)
            Retorno = ""
            flag = False
            ProjectData.ClearProjectError()
        End Try

        Return flag
    End Function


    Public Function processarWS_host(ByVal data As Dictionary(Of String, String), ByVal url As String) As String


        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\WS_Cofing.ini")

        If arquivoIni.KeyExists("HOSTADDRESS", "Settings") = False Then
            arquivoIni.Write("HOSTADDRESS", "http://192.168.254.2:8900", "Settings")
        End If

        Dim str As String = arquivoIni.Read("HOSTADDRESS", "Settings")
        '  Dim str As String = "http://localhost:8900"
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(CObj(data)))
        Dim uriString As String = String.Format("{0}/api/" & url & "", CObj(str))
        Dim uri As Uri = New Uri(uriString)
        '   mdlGeral.CriarArquivoLog("Enviar arquivo para URL: " & uriString, "", "", False, False, False)
        Dim jsonDataBytes As Byte() = bytes
        Dim ret As String = SendRequest(uri, jsonDataBytes, "")
        '  mdlGeral.CriarLog("Retorno WSLinear: " & Left1, NameOf(clsNFCe), NameOf(processarWS), False, False, False)

        If ret Is Nothing Then
            ret = "Sem retorno do Host local !"
        Else
            Return ret
        End If

    End Function

    Public Function processarWS_nfe4_list(ByVal data As Dictionary(Of String, String), ByVal url As String) As Dictionary(Of String, String)
        Dim Retarquivo As Dictionary(Of String, String) = New Dictionary(Of String, String)

        Dim arquivoIni As ArquivoIni = New ArquivoIni(Application.StartupPath & "\WS_Cofing.ini")

        If arquivoIni.KeyExists("HOSTADDRESS", "Settings") = False Then
            arquivoIni.Write("HOSTADDRESS", "http://192.168.254.2:8900", "Settings")
        End If

        Dim str As String = arquivoIni.Read("HOSTADDRESS", "Settings")
        ' Dim str As String = "http://localhost:8900"
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(CObj(data)))
        Dim uriString As String = String.Format("{0}/api/" & url & "", CObj(str))
        Dim uri As Uri = New Uri(uriString)
        '   mdlGeral.CriarArquivoLog("Enviar arquivo para URL: " & uriString, "", "", False, False, False)
        Dim jsonDataBytes As Byte() = bytes
        Retarquivo = SendRequest_list(uri, jsonDataBytes, "")
        '  mdlGeral.CriarLog("Retorno WSLinear: " & Left1, NameOf(clsNFCe), NameOf(processarWS), False, False, False)

        If Retarquivo Is Nothing Then
            Retarquivo.Add("status", "Sem retorno do Host local !")
            Return Retarquivo
        Else
            Return Retarquivo
        End If

    End Function

End Module
