Option Strict On

Imports CISEntity
Imports CISData
Imports System.Web
Imports System.Data.SqlClient

Public Class WebModel

    Public Function GetWebAppURL() As String
        Dim objweb As New WebUtility
        Return objweb.GetWebAppURL
    End Function

    Public Function GetCISTechReportPath() As String
        Dim objweb As New WebUtility

    End Function


    Public Function MasterEncrypt(ByVal text As String) As String

        'Dim enc3des As String = ThreeDESEncrypt(text)
        'Return AESEncryption(enc3des)

        Return ThreeDESEncrypt(text)
    End Function

    Public Function MasterDecrypt(ByVal text As String) As String
        'Dim decAES As String = AESDecryption(text)
        Return ThreeDESDecrypt(text)
    End Function
    Public Function ThreeDESEncrypt(ByVal text As String) As String
        Dim key() As Byte = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
        15, 16, 17, 18, 19, 20, 21, 22, 23, 35}
        Dim iv() As Byte = {8, 7, 6, 5, 4, 3, 2, 1}

        Dim dataEnc As New CISData.CISEncryption(key, iv)

        Return dataEnc.Encrypt(text)
        'datacom.EncryptValue(Me.txtEncryptval.Text)
        dataEnc = Nothing
    End Function

    Public Function ThreeDESDecrypt(ByVal text As String) As String
        Dim key() As Byte = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
        15, 16, 17, 18, 19, 20, 21, 22, 23, 35}
        Dim iv() As Byte = {8, 7, 6, 5, 4, 3, 2, 1}

        Dim dataDec As New CISData.CISEncryption(key, iv)
        Return dataDec.Decrypt(text)
        'Me.txtresults.Text = datacom.DecryptValue(Me.TextBox1.Text)
        dataDec = Nothing
    End Function

    Public Function AESEncryption(ByVal input As String) As String
        Dim key() As Byte =
        {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
        15, 16, 17, 18, 19, 20, 21, 22, 23, 35}
        Dim iv() As Byte = {8, 7, 6, 5, 4, 3, 2, 1}

        Dim dataEnc As New CISData.CISEncryption(key, iv)
        Return dataEnc.AESEncryption(input, dataEnc.GetAESPassValue)
    End Function

    Public Function AESDecryption(ByVal input As String) As String
        Dim key() As Byte = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
        15, 16, 17, 18, 19, 20, 21, 22, 23, 35}
        Dim iv() As Byte = {8, 7, 6, 5, 4, 3, 2, 1}

        Dim dataEnc As New CISData.CISEncryption(key, iv)
        Return dataEnc.AESDecryption(input, dataEnc.GetAESPassValue)

    End Function




End Class
