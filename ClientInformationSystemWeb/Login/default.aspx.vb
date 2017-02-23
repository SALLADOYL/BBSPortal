Option Strict On
Imports CISModel.AccessModel
Imports CISEntity
Imports CISData
Public Class _default1
    Inherits System.Web.UI.Page

    'Public Structure UserProfileInfo
    '    Public usrProfileEntity As CISEntity.ProfileEntity
    '    Public usrProfileObjectAccessEntity As List(Of CISEntity.ProfileObjectAccessEntity)
    'End Structure


    Private Sub CreateUsrSession(ByVal prflId As Long)
        Dim oProfileEntity As New CISEntity.ProfileEntity
        Dim lstProfileObjectAccessEntity As New List(Of CISEntity.ProfileObjectAccessEntity)
        Dim oAccessModel As New CISModel.AccessModel

        'CREATE PROFILE ENTITY SESSION FOR SUCCESSFUL USER
        oAccessModel.GetUserProfileObjects(prflId, oProfileEntity, lstProfileObjectAccessEntity)

        Session("usrProfileEntity") = oProfileEntity
        Session("lstProfileObjectAccessEntity") = lstProfileObjectAccessEntity

        oProfileEntity = Nothing
        lstProfileObjectAccessEntity = Nothing
        oAccessModel = Nothing

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub bnLogin_Click(sender As Object, e As EventArgs) Handles bnLogin.Click
        'INIT
        Dim objAccessModel As New CISModel.AccessModel

        'CHECK AUTH USR + PWD
        Dim prflID As Long = objAccessModel.AuthLoginUsernamePassword(Me.txtUsername.Text, Me.txtPassword.Text)

        If Not IsNothing(prflID) AndAlso prflID > 0 Then
            'IF OKAY, CREATE SESSION OBJECT, REDIRECT TO MAIN/DASHBOARD
            CreateUsrSession(prflID)
            Response.Write("Login Successful")
            Response.Redirect("~/Dashboard/")
        Else
            'ELSE DISPLAY ERROR MESSAGE, AND TRY AGAIN
            Dim strErr As String = "User not found! Incorrect Username and Password!"

            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, strErr)
            objAlert = Nothing

            Me.txtUsername.Text = ""
            Me.txtPassword.Text = ""
            Me.txtUsername.Focus()

            Response.Write("Login failed")
        End If




    End Sub

End Class