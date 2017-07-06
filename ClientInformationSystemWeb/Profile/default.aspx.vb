
Imports CISEntity
Imports CISModel
Imports CISData
Imports System.Data.SqlClient
Public Class _default4
    Inherits System.Web.UI.Page

    Private currentProfileID As Long

    Private Sub PopulateDepartment()
        Dim cModel As New CISModel.MasterModel
        ddDepartment.DataSource = cModel.GetDepartmentList
        ddDepartment.DataTextField = "DEPARTMENTNAME"
        ddDepartment.DataValueField = "DEPARTMENTNAME"
        ddDepartment.DataBind()
    End Sub
    Private Sub PopulateFacultyGroup()
        Dim cModel As New CISModel.MasterModel
        ddFacultyGroup.DataSource = cModel.GetFacultyGroupList
        ddFacultyGroup.DataTextField = "FACULTYGROUP"
        ddFacultyGroup.DataValueField = "FACULTYGROUP"
        ddFacultyGroup.DataBind()
    End Sub

    Private Sub PopulateStatus()
        Dim cModel As New CISModel.MasterModel
        ddStatus.DataSource = cModel.GetProfileStatusList
        ddStatus.DataTextField = "STATUS"
        ddStatus.DataValueField = "STATUS"
        ddStatus.DataBind()
    End Sub
    Private Sub PopulateBranch()
        Dim cModel As New CISModel.MasterModel
        ddBranch.DataSource = cModel.GetBranchList
        ddBranch.DataTextField = "BRANCHNAME"
        ddBranch.DataValueField = "BRANCHNAME"
        ddBranch.DataBind()
    End Sub

    Private Sub PopulateDesignation()
        Dim cModel As New CISModel.MasterModel
        ddDesignation.DataSource = cModel.GetDesignationList
        ddDesignation.DataTextField = "DESIGNATION"
        ddDesignation.DataValueField = "DESIGNATION"
        ddDesignation.DataBind()
    End Sub

    Private Sub PopulatePersonalInfo(ByVal prflID As Long)
        Dim entProfile As New CISEntity.ProfileEntity
        Dim modelProfile As New CISModel.ProfileModel

        entProfile = modelProfile.GetProfile(prflID)

        If Not IsNothing(entProfile) AndAlso prflID > 0 Then
            Me.txtProfileID.Text = entProfile.ProfileID.ToString
            Me.txtEmployeeCode.Text = entProfile.EmployeeCode
            Me.txtName.Text = entProfile.Name
            Me.txtADDRESS.Text = entProfile.Address
            Me.ddFacultyGroup.SelectedValue = entProfile.FacultyGroup
            Me.ddDepartment.SelectedValue = entProfile.Department
            Me.ddStatus.SelectedValue = entProfile.Status
            Me.txtWorkEmail.Text = entProfile.WorkEmail
            Me.txtMobilePhone.Text = entProfile.MobilePhone
            Me.txtExtension.Text = entProfile.Extension
            Me.ddBranch.SelectedValue = entProfile.Branch
            Me.chkIsAffiliated.Checked = entProfile.IsAffiliateFlag
            Me.chkIsActive.Checked = entProfile.IsActiveFlag
            Me.lblCreatedBy.Text = "Created By:" + modelProfile.GetProfileName(entProfile.CreatedBy)
            Me.lblCreatedDt.Text = "Create Date:" + entProfile.CreateDate.ToString
            Me.lblUpdatedBy.Text = "Last Updated by:" + modelProfile.GetProfileName(entProfile.UpdatedBy)
            Me.lblUpdateDt.Text = "Last Updated:" + entProfile.UpdateDate.ToString

            If entProfile.IsAffiliateFlag Then
                Me.imgPhoto.Visible = True
                Me.txtUsername.Visible = True
                Me.txtPassword.Visible = True

                Me.imgPhoto.ImageUrl = entProfile.PhotoUrlPath
                Me.txtUsername.Text = entProfile.UserName
                Me.txtPassword.Text = entProfile.Password
            Else
                Me.imgPhoto.Visible = False
                Me.txtUsername.Visible = False
                Me.txtPassword.Visible = False
            End If

        ElseIf IsNothing(entProfile) AndAlso prflID = 0 Then
                Me.txtProfileID.Text = "0"
                Me.txtEmployeeCode.Text = ""
                Me.txtName.Text = "NEW PROFILE"
                Me.txtADDRESS.Text = ""
                Me.ddFacultyGroup.SelectedValue = ""
                Me.ddDepartment.SelectedValue = ""
                Me.ddStatus.SelectedValue = ""
                Me.txtWorkEmail.Text = ""
                Me.txtMobilePhone.Text = ""
                Me.txtExtension.Text = ""
                Me.ddBranch.SelectedValue = ""
                Me.chkIsAffiliated.Checked = True
                Me.chkIsActive.Checked = True
                Me.lblCreatedBy.Text = "Created By:"
                Me.lblCreatedDt.Text = "Create Date:"
                Me.lblUpdatedBy.Text = "Last Updated by:"
                Me.lblUpdateDt.Text = "Last Updated:"


                Me.imgPhoto.ImageUrl = ""
                Me.txtUsername.Text = ""
                Me.txtPassword.Text = ""
            Else
                Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, "The Profile Does not exist!")
            objAlert = Nothing
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        currentProfileID = CType(Request.QueryString("ID"), Long)

        If Not Page.IsPostBack Then
            PopulateBranch()
            PopulateDepartment()
            PopulateDesignation()
            PopulateFacultyGroup()
            PopulateStatus()

            PopulatePersonalInfo(currentProfileID)


        End If
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Response.Redirect("~/Profile/?id=0")
    End Sub

    Private Sub btnSearchID_Click(sender As Object, e As EventArgs) Handles btnSearchID.Click
        Dim modelProfile As New CISModel.ProfileModel
        Dim entProfile As New List(Of CISEntity.ProfileEntity)
        Dim ID As Long


        If IsNumeric(Me.txtIDSearch.Text) Then
            ID = CType(Me.txtIDSearch.Text, Long)
            entProfile = modelProfile.GetProfileListByID(ID)
            dgEmpResults.DataSource = entProfile
            dgEmpResults.DataBind()
        Else
            'ALERT FOR SUCCESSFUL SAVE
            dgEmpResults.DataSource = Nothing
            dgEmpResults.DataBind()
            Dim strAlert As String = "Invalid ProfileID, Numeric Input only!"

            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, strAlert)

        End If
    End Sub

    Private Sub btnCodeSearch_Click(sender As Object, e As EventArgs) Handles btnCodeSearch.Click
        Dim modProfile As New CISModel.ProfileModel
        Dim entProfile As New List(Of CISEntity.ProfileEntity)

        entProfile = modProfile.GetProfileListByCode(Me.txtCodeSearch.Text, True)
        dgEmpResults.DataSource = entProfile
        dgEmpResults.DataBind()
    End Sub

    Private Sub btnNameSearch_Click(sender As Object, e As EventArgs) Handles btnNameSearch.Click
        Dim modProfile As New CISModel.ProfileModel
        Dim entProfile As New List(Of CISEntity.ProfileEntity)

        entProfile = modProfile.GetProfileListByName(Me.txtNameSearch.Text, True)
        dgEmpResults.DataSource = entProfile
        dgEmpResults.DataBind()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Me.txtIDSearch.Text = ""
        Me.txtCodeSearch.Text = ""
        Me.txtNameSearch.Text = ""
        Me.dgEmpResults.DataSource = Nothing
        Me.dgEmpResults.DataBind()
        Me.txtIDSearch.Focus()
    End Sub

    Private Function SetFormProfileEntity() As CISEntity.ProfileEntity
        Dim entProfile As New CISEntity.ProfileEntity

        With entProfile
            .ProfileID = CType(Me.txtProfileID.Text, Long)
            .EmployeeCode = Me.txtEmployeeCode.Text
            .Name = Me.txtName.Text
            .Address = Me.txtADDRESS.Text
            .FacultyGroup = Me.ddFacultyGroup.SelectedValue
            .Department = Me.ddDepartment.SelectedValue
            .Status = Me.ddStatus.SelectedValue
            .WorkEmail = Me.txtWorkEmail.Text
            .MobilePhone = Me.txtMobilePhone.Text
            .Extension = Me.txtExtension.Text
            .Branch = Me.ddBranch.SelectedValue
            .Designation = Me.ddDesignation.SelectedValue
            .IsAffiliateFlag = Me.chkIsAffiliated.Checked
            .IsActiveFlag = Me.chkIsActive.Checked
            .PhotoUrlPath = Me.imgPhoto.ImageUrl
            .UserName = Me.txtUsername.Text
            .Password = Me.txtPassword.Text

        End With

        Return entProfile

    End Function

    Private Function GetUserProfile() As CISEntity.ProfileEntity
        Return Session("usrProfileEntity")
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim entProfile As CISEntity.ProfileEntity = SetFormProfileEntity()
        Dim modProfile As New CISModel.ProfileModel

        modProfile.Save(entProfile, GetUserProfile.ProfileID)

        PopulatePersonalInfo(entProfile.ProfileID)

        'ALERT FOR SUCCESSFUL SAVE
        Dim strAlert As String = "Profile Information Saved"

        Dim objAlert As New DynamicClientScript
        objAlert.ShowMessage(Me.Page, strAlert)

        objAlert = Nothing
        modProfile = Nothing
        entProfile = Nothing
    End Sub



    Private Sub dgEmpResults_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dgEmpResults.UpdateCommand
        'Dim stritem As String = Me.dgEmpResults.SelectedItem.Cells(0).Controls(0).ClientID
        Dim prflID As Long = CType(e.Item.Cells(0).Text, Long)
        PopulatePersonalInfo(prflID)

        ''ALERT FOR SUCCESSFUL SAVE
        'Dim strAlert As String = "TEST RECORD BEING TESTED: dgEmpResults_UpdateCommand"

        'Dim objAlert As New DynamicClientScript
        'objAlert.ShowMessage(Me.Page, strAlert)

        'objAlert = Nothing

    End Sub

    Private Function VerifyFileAsImage(ByVal strContentType As String) As Boolean
        If strContentType.ToLower <> "image/jpg" And strContentType.ToLower <> "image/jpeg" _
            And strContentType.ToLower <> "image/pjpeg" And strContentType.ToLower <> "image/gif" _
             And strContentType.ToLower <> "image/x-png" And strContentType.ToLower <> "image/png" Then
            Return False
        End If

        Return True
    End Function

    Private Sub btnUploadSavePhoto_Click(sender As Object, e As EventArgs) Handles btnUploadSavePhoto.Click
        Dim objWebUtility As New CISData.WebUtility
        If Not IsNothing(Me.fileInput1.PostedFile) AndAlso fileInput1.PostedFile.ContentLength > 0 Then
            If Me.fileInput1.PostedFile.ContentLength < objWebUtility.GetPictureFileLimit Then

                If VerifyFileAsImage(Me.fileInput1.PostedFile.ContentType) Then
                    Dim Fn As String = System.IO.Path.GetFileName(Me.fileInput1.PostedFile.FileName)
                    Dim strFileName As String = "ID-" + Me.txtEmployeeCode.Text + "-" + Now.ToString("yyyyMMddhhmmss") + "-" + Fn
                    Dim strFilePath As String = objWebUtility.GetIDPicSavePath + strFileName
                    Dim strFTPFilePath As String = objWebUtility.GetWebAppURLPicPath + strFileName

                    Dim SaveLoc As String = strFilePath
                    fileInput1.PostedFile.SaveAs(SaveLoc)

                    Dim mdlProfile As New CISModel.ProfileModel
                    mdlProfile.SaveProfilePhoto(CType(Me.txtProfileID.Text, Long), strFTPFilePath, GetUserProfile.ProfileID)
                    mdlProfile = Nothing

                    Me.mpeUploadPhoto.Hide()
                    Me.imgPhoto.ImageUrl = strFTPFilePath
                Else
                    Dim strErr As String = "File is not a valid image, please select a file again."

                    Dim objAlert As New DynamicClientScript
                    objAlert.ShowMessage(Me.Page, strErr)
                    objAlert = Nothing
                End If

            Else
                Dim strErr As String = "File to upload is too big. Limit filesize to less than 4mb."

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

    Private Function ValidateUsernameIsUnique(ByVal ProfileID As Long, ByVal Username As String) As Boolean
        Dim mdlprofile As New CISModel.ProfileModel
        Return mdlprofile.ValidateUsernameIsUnique(ProfileID, Username)
        mdlprofile = Nothing
    End Function

    Private Sub btnSaveUsrPwd_Click(sender As Object, e As EventArgs) Handles btnSaveUsrPwd.Click
        Dim mdlprofile As New CISModel.ProfileModel
        'verify username and password is not blank
        If Me.txtUsername.Text.Length > 0 AndAlso Me.txtPassword.Text.Length > 0 Then

            If ValidateUsernameIsUnique(CType(Me.txtProfileID.Text, Long), Me.txtUsername.Text) Then
                Dim isSaved As Boolean
                isSaved = mdlprofile.SaveProfileUsrnamePwd(CType(Me.txtProfileID.Text, Long), Me.txtUsername.Text, Me.txtPassword.Text, GetUserProfile.ProfileID)

                Dim strErr As String = "Username and Password has been saved."

                Dim objAlert As New DynamicClientScript
                objAlert.ShowMessage(Me.Page, strErr)
                objAlert = Nothing

                mpeProfileAccess.Hide()
                Me.txtPassword.Text = ""
            Else
                Dim strErr As String = "Username already exist, please change the username."

                Dim objAlert As New DynamicClientScript
                objAlert.ShowMessage(Me.Page, strErr)
                objAlert = Nothing
            End If
        Else
            Dim strErr As String = "Please input a valid Username and Password"

            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, strErr)
            objAlert = Nothing
        End If
    End Sub
End Class