﻿Imports CISData


Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub btndecrypprocess_Click(sender As Object, e As EventArgs) Handles btndecrypprocess.Click
        'Dim key() As Byte =
        '{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
        '15, 16, 17, 18, 19, 20, 21, 22, 23, 24}
        'Dim iv() As Byte = {8, 7, 6, 5, 4, 3, 2, 1}

        'Dim dataEnc As New CISData.CISEncryption(key, iv)

        'Me.txtresults.Text = dataEnc.Encrypt(Me.txtEncryptval.Text)
        ''datacom.EncryptValue(Me.txtEncryptval.Text)
        'dataEnc = Nothing

        Dim objweb As New CISModel.WebModel
        Me.txtresults.Text = objweb.MasterEncrypt(Me.txtEncryptval.Text)
        objweb = Nothing
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim key() As Byte =
        '{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
        '15, 16, 17, 18, 19, 20, 21, 22, 23, 24}
        'Dim iv() As Byte = {8, 7, 6, 5, 4, 3, 2, 1}

        'Dim dataDec As New CISData.CISEncryption(key, iv)
        'Me.txtresults.Text = dataDec.Decrypt(Me.TextBox1.Text)
        ''Me.txtresults.Text = datacom.DecryptValue(Me.TextBox1.Text)
        'dataDec = Nothing

        Dim objweb As New CISModel.WebModel
        Me.txtresults.Text = objweb.MasterDecrypt(Me.TextBox1.Text)
        objweb = Nothing
    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim objWebUtility As New CISData.WebUtility

        If Not IsNothing(Me.fileInput1.PostedFile) AndAlso fileInput1.PostedFile.ContentLength > 0 Then
            If Me.fileInput1.PostedFile.ContentLength < objWebUtility.GetUploadFileLimit Then

                Dim Fn As String = System.IO.Path.GetFileName(Me.fileInput1.PostedFile.FileName)

                Dim SaveLoc As String = objWebUtility.GetFTPLocalPath + Fn
                fileInput1.PostedFile.SaveAs(SaveLoc)

                Dim strErr1 As String = "SaveAs Complete"
                Dim objAlert1 As New DynamicClientScript
                objAlert1.ShowMessage(Me.Page, strErr1)
                objAlert1 = Nothing

            Else
                Dim strErr As String = "File to upload is too big. Limit filesize to 4mb."

                Dim objAlert As New DynamicClientScript
                objAlert.ShowMessage(Me.Page, strErr)
                objAlert = Nothing
            End If

        Else
            Dim strErr As String = "No file selected for upload."

            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, strErr)
            objAlert = Nothing

        End If

        objWebUtility = Nothing
    End Sub
End Class