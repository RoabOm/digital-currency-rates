Imports System.Text.RegularExpressions

Module Module1
    Dim Coins As String
    Dim Coins_price As Double
    Dim Coins_price_now As Double
    Dim stoop As Boolean = True
    Dim Coins_price_ As New List(Of String)
    Dim num As Integer = 0
    Sub Main()
        Console.Write("[*] - Enter the currency name : ")
        Coins = Console.ReadLine
        Get_Coins(Coins)
        Dim th As Threading.Thread = New Threading.Thread(AddressOf price)
        th.Start(Coins)
        Console.ReadLine()
    End Sub
    Sub Get_Coins(Coins As String)
        Dim Request As System.Net.HttpWebRequest = DirectCast(System.Net.WebRequest.Create("http://artapi.cf/index.php?crypto=" + Coins + "&coins=USD"), System.Net.HttpWebRequest)
        Request.Method = "GET"
        Request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"
        Request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36"
        Request.Host = "artapi.cf"
        Request.Headers.Add("Accept-Language", "en-US,en;q=0.9")
        Request.Headers.Add("Cache-Control", "max-age=0")
        Request.Headers.Add("Cookie", "__test=7eb4955029dc70ea2c1075f4adb9e426")
        Request.Headers.Add("Upgrade-Insecure-Requests", "1")
        Dim Response As System.Net.HttpWebResponse
        Try
            Response = DirectCast(Request.GetResponse, System.Net.HttpWebResponse)
        Catch ex As System.Net.WebException
            Response = DirectCast(ex.Response, System.Net.HttpWebResponse)
        End Try
        Dim StreamReader As System.IO.StreamReader = New System.IO.StreamReader(Response.GetResponseStream())
        Dim Result As String = StreamReader.ReadToEnd().ToString
        StreamReader.Dispose()
        StreamReader.Close()
        num += 1
        If num > 1 Then
            Dim ss As String
            ss = Regex.Match(Result, "{""(.*?)"":{""USD"":(.*?)}}").Groups(2).Value
            Coins_price_now = ss
        Else
            Dim ss As String
            ss = Regex.Match(Result, "{""(.*?)"":{""USD"":(.*?)}}").Groups(2).Value
            ss = Regex.Match(Result, "{""(.*?)"":{""USD"":(.*?)}}").Groups(2).Value
            Coins_price = ss
            Coins_price_now = ss
        End If

    End Sub
    Sub price(Coins As String)
        While stoop
            Dim i As Double
            i = Coins_price_now - Coins_price
            i = i / Coins_price
            i = i * 100
            i = i
            Dim ii As String = i
            Dim bb As String
            For e As Integer = 0 To 100
                e += 10
                If Coins_price_.Count = Nothing Then
                    If ii.Contains("-") Then
                        ii = ii.Replace("-", "")
                        i = ii
                        If i >= e Then
                            Console.WriteLine(Coins + " ------> -" + e.ToString + "%")
                            Coins_price_.Add(i)
                            Exit For
                        End If
                    Else

                        If i >= e Then
                            Console.WriteLine(Coins + " ------> -" + e.ToString + "%")
                            Coins_price_.Add(i)
                            Exit For
                        End If

                    End If
                Else

                    For b As Integer = 0 To Coins_price_.Count - 1
                        bb = Coins_price_(b)

                        If bb = (i) Then

                        Else

                            If ii.Contains("-") Then
                                ii = ii.Replace("-", "")
                                i = ii
                                If i >= e Then
                                    Console.WriteLine(Coins + " ------> -" + e.ToString + "%")
                                    Coins_price_.Add(i)
                                    Exit For
                                End If
                            End If

                            If i >= e Then
                                Console.WriteLine(Coins + " ------> -" + e.ToString + "%")
                                Coins_price_.Add(i)
                                Exit For
                            End If
                        End If
                    Next
                End If
            Next
            Threading.Thread.Sleep(15 * 1000)
            Get_Coins(Coins)

        End While
    End Sub
End Module
