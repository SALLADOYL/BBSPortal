Option Strict On
Imports System.Configuration
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Net
Imports System.Web


Public Class CommonClass

#Region "MembershipCode Generator"
    Private rNum As New Random(100)
    Private rLowerCase As New Random(500)
    Private rUpperCase As New Random(50)
    Private psw As String
    Private RandomSelect As New Random(50)
    Private TripleDes As New TripleDESCryptoServiceProvider

    Public Function GenerateRandomCode(ByVal codeLength As Integer, Optional ByVal Reset As Boolean = False) As String
        Dim i As Integer
        Dim CNT(2) As Integer
        Dim Char_Sel(2) As String
        Dim iSel As Integer

        'clear old passwords
        If Reset = True Then
            psw = ""
        End If
        For i = 1 To codeLength
            'create random numbers that will represent
            'each : upercase,lowercase,numbers

            CNT(0) = rNum.Next(48, 57) 'Numbers  1 to 9 
            CNT(1) = rLowerCase.Next(65, 90) ' Lowercase Characters
            CNT(2) = rUpperCase.Next(97, 122) ' Uppercase Characters

            'put characters in strings
            Char_Sel(0) = System.Convert.ToChar(CNT(0)).ToString
            Char_Sel(1) = System.Convert.ToChar(CNT(1)).ToString
            Char_Sel(2) = System.Convert.ToChar(CNT(2)).ToString

            'pick one of the three above for a character At Random
            iSel = RandomSelect.Next(0, 3)
            'colect all characters generated through the loop
            psw &= Char_Sel(iSel)

            ' reset  with new password
            If Reset = True Then
                psw.Replace(psw, Char_Sel(iSel))
            End If

        Next
        Return psw

    End Function
#End Region

#Region "GetConfig AppSettings Values"
    Public Function GetAppsettings(ByVal StringName As String) As String
        Return System.Configuration.ConfigurationManager.AppSettings(StringName)
    End Function


#End Region

#Region "GetDatabase Connection String"
    Const devCISConnString = "Data Source=SL-ITSYSAD-LT; Initial Catalog=BBSClientInformationDB; User ID=BBSCISAdmin; Password='P@$$w0rd';"
    Const prodConnString = ""

    Const devWebConnString = "Data Source=SL-ITSYSAD-LT; Initial Catalog=BBSClientInformationDB; User ID=BBSCISAdmin; Password='P@$$w0rd';"
    Const prodWebConnString = ""

    Const binConnString = "Data Source=SL-ITSYSAD-LT; Initial Catalog=BBSClientInformationDB; User ID=BBSCISAdmin; Password='P@$$w0rd';"

    Public Function GetConnString() As String
        Return devCISConnString
    End Function

    Public Function GetWebConnString() As String
        Return devWebConnString
    End Function




#End Region




End Class

Public Class CISEncryption
#Region "Encryption/Decryption"
    ' define the triple des provider
    Private m_des As New TripleDESCryptoServiceProvider

    ' define the string handler
    Private m_utf8 As New UTF8Encoding

    ' define the local property arrays
    Private m_key() As Byte
    Private m_iv() As Byte

    Public Sub New(ByVal key() As Byte, ByVal iv() As Byte)
        Me.m_key = key
        Me.m_iv = iv
    End Sub

    'Public Function Encrypt(ByVal input() As Byte) As Byte()
    '    Return Transform(input, m_des.CreateEncryptor(m_key, m_iv))
    'End Function

    'Public Function Decrypt(ByVal input() As Byte) As Byte()
    '    Return Transform(input, m_des.CreateDecryptor(m_key, m_iv))
    'End Function

    Public Function Encrypt(ByVal text As String) As String
        'put salt in string
        text = GetSalt() & text

        Dim input() As Byte = m_utf8.GetBytes(text)
        Dim output() As Byte = Transform(input,
                        m_des.CreateEncryptor(m_key, m_iv))
        Return Convert.ToBase64String(output)
    End Function

    Public Function Decrypt(ByVal text As String) As String
        Dim input() As Byte = Convert.FromBase64String(text)
        Dim output() As Byte = Transform(input,
                         m_des.CreateDecryptor(m_key, m_iv))
        Dim textReturn As String
        textReturn = m_utf8.GetString(output).Replace(GetSalt, "")

        Return textReturn
    End Function

    Private Function Transform(ByVal input() As Byte,
        ByVal CryptoTransform As ICryptoTransform) As Byte()
        ' create the necessary streams
        Dim memStream As MemoryStream = New MemoryStream
        Dim cryptStream As CryptoStream = New _
            CryptoStream(memStream, CryptoTransform,
            CryptoStreamMode.Write)
        ' transform the bytes as requested
        cryptStream.Write(input, 0, input.Length)
        cryptStream.FlushFinalBlock()
        ' Read the memory stream and convert it back into byte array
        memStream.Position = 0
        Dim result(CType(memStream.Length - 1, System.Int32)) As Byte
        memStream.Read(result, 0, CType(result.Length, System.Int32))
        ' close and release the streams
        memStream.Close()
        cryptStream.Close()
        ' hand back the encrypted buffer
        Return result
    End Function

    Private Function GetSalt() As String
        Return System.Configuration.ConfigurationManager.AppSettings("AsinValue")
    End Function

    Public Function GetAESPassValue() As String
        Return System.Configuration.ConfigurationManager.AppSettings("PassVal")
    End Function

    'Public Function EncryptValue(ByVal plaintext As String) As String
    '    'put salt in string
    '    Dim saltedPlaintext As String
    '    saltedPlaintext = GetSalt() & plaintext

    '    ' Convert the plaintext string to a byte array.
    '    Dim plaintextBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(plaintext)

    '    ' Create the stream.
    '    Dim ms As New System.IO.MemoryStream
    '    ' Create the encoder to write to the stream.
    '    Dim encStream As New CryptoStream(ms, TripleDes.CreateEncryptor(),
    '            System.Security.Cryptography.CryptoStreamMode.Write)

    '    ' Use the crypto stream to write the byte array to the stream.
    '    encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
    '    encStream.FlushFinalBlock()

    '    ' Convert the encrypted stream to a printable string.
    '    Return Convert.ToBase64String(ms.ToArray)
    'End Function

    'Public Function DecryptValue(ByVal encryptedtext As String) As String

    '    ' Convert the encrypted text string to a byte array.
    '    Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

    '    ' Create the stream.
    '    Dim ms As New System.IO.MemoryStream
    '    ' Create the decoder to write to the stream.
    '    Dim decStream As New CryptoStream(ms,
    '        TripleDes.CreateDecryptor(),
    '        System.Security.Cryptography.CryptoStreamMode.Write)

    '    ' Use the crypto stream to write the byte array to the stream.
    '    decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
    '    decStream.FlushFinalBlock()

    '    ' Convert the plaintext stream to a string.
    '    Dim strSaltedValue As String

    '    strSaltedValue = System.Text.Encoding.Unicode.GetString(ms.ToArray)

    '    Return strSaltedValue.Replace(GetSalt, "")

    'End Function

    Public Function AESEncryption(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function AESDecryption(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decrypted
        Catch ex As Exception
            Return Nothing
        End Try
    End Function



#End Region
End Class


Public Class WebUtility

    Public Function GetFTPPathRoot() As String
        Return System.Configuration.ConfigurationManager.AppSettings("FTPPath")
    End Function

    Public Function GetFTPLocalPath() As String
        Return System.Configuration.ConfigurationManager.AppSettings("FTPLocalPath")
    End Function

    Public Function GetUploadFileLimit() As Integer
        Return CType(System.Configuration.ConfigurationManager.AppSettings("UploadFileLimit"), Integer)
    End Function

    Public Function GetWebAppURL() As String
        Return System.Configuration.ConfigurationManager.AppSettings("WebAppURL")
    End Function

    Private Function GetFTPCredential() As System.Net.NetworkCredential
        Dim strUser As String = System.Configuration.ConfigurationManager.AppSettings("FTPCredUser")
        Dim strPassword As String = System.Configuration.ConfigurationManager.AppSettings("FTPCredPwd")

        Dim retCred As New NetworkCredential(strUser, strPassword)

        Return retCred
    End Function
    Public Function UploadToFTP(ByVal binFullFilename As String, ByVal NewFilename As String) As Boolean
        Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(GetFTPPathRoot() + NewFilename), System.Net.FtpWebRequest)
        request.Credentials = GetFTPCredential()
        request.Method = System.Net.WebRequestMethods.Ftp.UploadFile

        Dim file() As Byte = System.IO.File.ReadAllBytes(binFullFilename)

        Dim strz As System.IO.Stream = request.GetRequestStream()
        strz.Write(file, 0, file.Length)
        strz.Close()
        strz.Dispose()

        Return True

    End Function

    'Public Sub DownloadFTP(ByVal strPath As String)
    '    Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(strPath), System.Net.FtpWebRequest)
    '    request.Method = WebRequestMethods.Ftp.DownloadFile
    '    request.Credentials = GetFTPCredential()

    '    Dim response As System.Net.FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
    '    Dim responseStream As Stream = response.GetResponseStream()
    '    Dim reader As StreamReader = New StreamReader(responseStream)

    '    reader.Close()
    '    response.Close()


    'End Sub

    Public Sub DownloadFTP(ByVal strPath As String)
        'Create a WebClient.
        Dim request As New WebClient()

        ' Confirm the Network credentials based on the user name and password passed in.
        Dim strUser As String = System.Configuration.ConfigurationManager.AppSettings("FTPCredUser")
        Dim strPassword As String = System.Configuration.ConfigurationManager.AppSettings("FTPCredPwd")
        request.Credentials = New NetworkCredential(strUser, strPassword) 'GetFTPCredential()

        'Read the file data into a Byte array
        Dim bytes() As Byte = request.DownloadData(strPath)

        Try
            Dim DownloadStream As FileStream = IO.File.Create("c:\")
            '  Stream this data into the file
            DownloadStream.Write(bytes, 0, bytes.Length)
            '  Close the FileStream
            DownloadStream.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Function CheckFileExistLocal(ByVal FulpathFilename As String) As Boolean
        Return System.IO.File.Exists(FulpathFilename)
    End Function


End Class
