Imports CISEntity
Imports CISModel
Imports CISData
Imports System.Data.SqlClient

Public Class _default11
    Inherits System.Web.UI.Page

    Private Function GetUserProfile() As CISEntity.ProfileEntity
        Return Session("usrProfileEntity")
    End Function

    Private Sub PopulateRoleDD()
        Dim mdlProfile As New CISModel.ProfileModel
        Me.ddRoleList.DataSource = mdlProfile.GetAllRoleList
        Me.ddRoleList.DataTextField = "Name"
        Me.ddRoleList.DataValueField = "RoleID"
        Me.ddRoleList.DataBind()
        mdlProfile = Nothing
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PopulateRoleDD()
        End If
    End Sub

    Private Sub PopulateRoleInfo(ByVal roleID As Long)
        Dim mdlProfile As New CISModel.ProfileModel
        Dim entRole As New CISEntity.RoleEntity
        entRole = mdlProfile.GetRole(roleID)

        Me.txtRoleID.Text = entRole.RoleID.ToString
        Me.txtRoleName.Text = entRole.Name
        Me.txtRemarks.Text = entRole.Remarks

        Me.dgRoleUsers.DataSource = mdlProfile.GetRoleUsers(roleID)
        Me.dgRoleUsers.DataBind()

        Me.dgAddUserModal.DataSource = mdlProfile.GetProfileNotEnrolledtoRole(roleID)
        Me.dgAddUserModal.DataBind()

        entRole = Nothing
        mdlProfile = Nothing

    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        PopulateRoleInfo(Me.ddRoleList.SelectedValue)
    End Sub

    Private Sub dgAddUserModal_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dgAddUserModal.UpdateCommand
        Dim entPrflAccess As New CISEntity.ProfileObjectAccessEntity
        With entPrflAccess
            .ProfileObjectAccessID = 0
            .ProfileID = CType(e.Item.Cells(1).Text, Long)
            .ObjectAccessID = 1
            .RoleID = CType(ddRoleList.SelectedValue, Long)
            .PurgeFlag = False
        End With

        Dim mdlProfile As New CISModel.ProfileModel
        mdlProfile.SaveNewProfileAccess(entPrflAccess, GetUserProfile.ProfileID)
        mdlProfile = Nothing

        PopulateRoleInfo(entPrflAccess.RoleID)
        entPrflAccess = Nothing
    End Sub

    Private Sub dgRoleUsers_DeleteCommand(source As Object, e As DataGridCommandEventArgs) Handles dgRoleUsers.DeleteCommand
        Dim mdlProfile As New CISModel.ProfileModel
        mdlProfile.DeleteRoleAccess(CType(e.Item.Cells(0).Text, Long))
        PopulateRoleInfo(CType(ddRoleList.SelectedValue, Long))
        mdlProfile = Nothing
    End Sub

    Private Sub dgRoleUsers_ItemDataBound(sender As Object, e As DataGridItemEventArgs) Handles dgRoleUsers.ItemDataBound
        If e.Item.Cells.Count > 0 AndAlso e.Item.Cells(4).Controls.Count > 0 Then
            CType(e.Item.Cells(4).Controls(0), Button).OnClientClick = "return confirm('Remove this from Role?');"
        End If
    End Sub
End Class