Imports CISData
Imports Microsoft.Reporting.WebForms
Imports System.Net

Public Class _default10
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not IsNothing(Session("usrProfileEntity")) Then

                With CType(Session("usrProfileEntity"), CISEntity.ProfileEntity)
                    Me.lblSessionContent.Text = "Session: usrProfileEntity/n"
                    Me.lblSessionContent.Text &= "Name ='" + .Name + "/n'"
                    Me.lblSessionContent.Text &= "Address ='" + .Address + "/n'"
                End With

            Else
                Me.lblSessionContent.Text = "Session is blank!"
            End If
        End If
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

    Private Sub btnPopupURL_Click(sender As Object, e As EventArgs) Handles btnPopupURL.Click
        Dim modWeb As New CISModel.WebModel
        Dim strDownload As String = modWeb.GetWebAppURL() + "myUtilities/"
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "', 'popup_window', 'directories=0,titlebar=0,width=900,height=1000,left=100,top=100,resizable=yes');</script>")
        modWeb = Nothing
    End Sub

    Private Sub btnRedirSSRS_Click(sender As Object, e As EventArgs) Handles btnRedirSSRS.Click
        Dim modWeb As New CISModel.WebModel
        Dim strDownload As String = Me.txtssrspath.Text
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "', 'popup_window', 'directories=0,titlebar=0,width=900,height=1000,left=100,top=100,resizable=yes');</script>")
        modWeb = Nothing
    End Sub

    Private Sub btnProgramRSViewer_Click(sender As Object, e As EventArgs) Handles btnProgramRSViewer.Click
        'Me.ReportViewer1.ShowParameterPrompts = False
        'Dim irepCred As IReportServerCredentials = New CustomReportCredentials("sl.it.sysad", "Ll0yd123", "BBS")
        'ReportViewer1.ServerReport.ReportServerCredentials = irepCred
        'Me.ReportViewer1.ServerReport.ReportPath = "/Client Information System/Technical Reports/Technical-Report (Single)"
        'Me.ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://10.1.1.18/ReportServer/")
        'ReportViewer1.ServerReport.Refresh()
        'Dim rptParamTRID As New ReportParameter
        'rptParamTRID.Name = "paramTRID"
        'rptParamTRID.Values.Add(1)
        'Me.ReportViewer1.ServerReport.SetParameters(rptParamTRID)
        'Me.ReportViewer1.Visible = True
        'ReportViewer1.DataBind()
        ''ReportViewer1.

        Dim modWeb As New CISModel.WebModel
        Dim strDownload As String = modWeb.GetWebAppURL() + "cisReportViewer/"
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "', 'popup_window', 'directories=0,titlebar=0,width=900,height=1000,left=100,top=100,resizable=yes');</script>")
        modWeb = Nothing
    End Sub
End Class

