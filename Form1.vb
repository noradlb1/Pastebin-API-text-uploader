Imports System.IO
Imports System.Net.Http
Imports System.Text
Imports System.Web

Public Class Form1
    Private apiKey As String
    Private username As String
    Private password As String
    Private apiUserKey As String
    Private Const settingsFile As String = "settings.txt" ' مسار ملف الإعدادات

    ' تحميل إعدادات المستخدم وتسجيل الدخول
    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettings() ' تحميل الإعدادات من الملف

        ' إذا كانت الإعدادات فارغة، اطلبها من المستخدم
        If String.IsNullOrEmpty(apiKey) OrElse String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            apiKey = InputBox("Enter your API Key:", "API Key")
            username = InputBox("Enter your Username:", "Username")
            password = InputBox("Enter your Password:", "Password")

            ' حفظ الإعدادات في الملف
            SaveSettings(apiKey, username, password)
        End If

        ' الحصول على api_user_key
        apiUserKey = Await GetUserKey(apiKey, username, password)
        If String.IsNullOrEmpty(apiUserKey) Then
            MessageBox.Show("Failed to retrieve api_user_key. Please check your credentials.")
            Close()
        End If
    End Sub

    ' رفع النص وإنشاء روابط
    Private Async Sub ButtonUpdatePaste_Click(sender As Object, e As EventArgs) Handles ButtonUpdatePaste.Click
        If String.IsNullOrEmpty(TextBoxContent.Text) Then
            MessageBox.Show("Paste content is empty. Please add some text before updating.")
            Return
        End If

        Dim pasteTitle As String = GenerateRandomTitle() ' توليد عنوان عشوائي
        Dim pastePrivate As String = "1"
        Dim pasteExpire As String = "10M"
        Dim pasteFormat As String = "text"
        Dim pasteContent As String = TextBoxContent.Text

        Dim apiUrl As String = "https://pastebin.com/api/api_post.php"

        Using client As New HttpClient()
            Dim postData As String = $"api_option=paste" &
                                     $"&api_dev_key={apiKey}" &
                                     $"&api_user_key={apiUserKey}" &
                                     $"&api_paste_code={HttpUtility.UrlEncode(pasteContent)}" &
                                     $"&api_paste_private={pastePrivate}" &
                                     $"&api_paste_name={HttpUtility.UrlEncode(pasteTitle)}" &
                                     $"&api_paste_expire_date={pasteExpire}" &
                                     $"&api_paste_format={pasteFormat}"

            Dim content As New StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded")

            Try
                Dim response As HttpResponseMessage = Await client.PostAsync(apiUrl, content)
                Dim responseBody As String = Await response.Content.ReadAsStringAsync()

                If response.IsSuccessStatusCode AndAlso Not responseBody.Contains("Bad API request") Then
                    ' استخراج معرف النص (Paste ID)
                    Dim pasteID As String = responseBody.Substring(responseBody.LastIndexOf("/") + 1)
                    Dim directLink As String = $"https://pastebin.com/raw/{pasteID}"
                    Dim normalLink As String = responseBody.Trim()

                    TextBox1.Text = normalLink
                    TextBox2.Text = directLink
                Else
                    MessageBox.Show($"Error creating paste: {responseBody}")
                End If
            Catch ex As Exception
                MessageBox.Show($"Error creating paste: {ex.Message}")
            End Try
        End Using
    End Sub

    ' دالة توليد عنوان عشوائي
    Private Function GenerateRandomTitle() As String
        Dim rnd As New Random()
        Dim chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim titleLength As Integer = 12 ' طول العنوان
        Dim sb As New StringBuilder()

        For i As Integer = 1 To titleLength
            Dim idx As Integer = rnd.Next(0, chars.Length)
            sb.Append(chars(idx))
        Next

        Return "Paste_" & sb.ToString() ' إضافة بادئة
    End Function

    ' دالة تسجيل الدخول للحصول على api_user_key
    Private Async Function GetUserKey(apiKey As String, username As String, password As String) As Task(Of String)
        Dim loginUrl As String = "https://pastebin.com/api/api_login.php"

        Using client As New HttpClient()
            Dim postData As String = $"api_dev_key={apiKey}&api_user_name={username}&api_user_password={password}"
            Dim content As New StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded")

            Try
                Dim response As HttpResponseMessage = Await client.PostAsync(loginUrl, content)
                Dim responseBody As String = Await response.Content.ReadAsStringAsync()

                If response.IsSuccessStatusCode AndAlso Not responseBody.Contains("Bad API request") Then
                    Return responseBody.Trim()
                Else
                    MessageBox.Show($"Error logging in: {responseBody}")
                    Return String.Empty
                End If
            Catch ex As Exception
                MessageBox.Show($"An error occurred during login: {ex.Message}")
                Return String.Empty
            End Try
        End Using
    End Function

    ' حفظ الإعدادات في ملف نصي
    Private Sub SaveSettings(apiKey As String, username As String, password As String)
        Dim lines As String() = {$"apiKey={apiKey}", $"username={username}", $"password={password}"}
        File.WriteAllLines(settingsFile, lines)
    End Sub

    ' تحميل الإعدادات من ملف نصي
    Private Sub LoadSettings()
        If File.Exists(settingsFile) Then
            Dim lines = File.ReadAllLines(settingsFile)
            For Each line In lines
                If line.StartsWith("apiKey=") Then apiKey = line.Substring(7)
                If line.StartsWith("username=") Then username = line.Substring(9)
                If line.StartsWith("password=") Then password = line.Substring(9)
            Next
        End If
    End Sub
End Class
