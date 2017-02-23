
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

End Class