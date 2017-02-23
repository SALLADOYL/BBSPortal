Imports CISEntity
Imports CISModel
Imports CISData
Imports System.Data.SqlClient


Public Class _default3
    Inherits System.Web.UI.Page

    Private currentClientID As Long

    Private Sub SetEnablePageSaves(ByVal value As Boolean)
        Me.btnSave.Enabled = value
        Me.btnNew.Enabled = value

        btnAddService.Enabled = value
        btnNewFile.Enabled = value
        btnNewNote.Enabled = value

        dgClientServices.Enabled = value
        dgFiles.Enabled = value
        dgNotes.Enabled = value

        If value Then
            pnlInput.Disabled = False
        Else
            pnlInput.Disabled = True
        End If

        pnlServiceInfo.Enabled = value
        pnlFileAttachments.Enabled = value
        pnlNotes.Enabled = value

        btnShareURL.Enabled = value

    End Sub

    Private Sub LoadReadOnly()
        Me.pnlSearch.Visible = False
        Me.PageMain.Disabled = True
        SetEnablePageSaves(False)


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.cpeSearch.Collapsed = True
        Me.cpeSearch.ClientState = True

        'SetEnablePageSaves(False)

        If Not Page.IsPostBack Then
            Dim qrystr As String = ""

            If Request.QueryString("enc") = "1" Then
                Dim objWeb As New WebModel
                qrystr = objWeb.MasterDecrypt(Request.QueryString("ID").Replace(" ", "+"))
                'objWeb.MasterDecrypt(HttpUtility.UrlDecode(Request.QueryString("ID")))

                currentClientID = CType(qrystr, Long)
                objWeb = Nothing
                Me.pnlSearch.Visible = False
                Me.PageMain.Disabled = True
                SetEnablePageSaves(False)
            ElseIf Not IsNothing(GetUserProfile) Then

                If IsNumeric(Request.QueryString("ID")) Then
                    currentClientID = CType(Request.QueryString("ID"), Long)
                End If

                SetEnablePageSaves(True)

            ElseIf IsNothing(GetUserProfile) Then
                Response.Redirect("~/Login/")

            End If

            PopulateDDIndustryList()
            PopulateClientPage(currentClientID)

            'ScriptManager.RegisterStartupScript(btnDeleteNote, btnDeleteNote.GetType(), "confirm", "return confirm('Are You sure');", True)

        End If
    End Sub

    Private Sub PopulateDDIndustryList()
        Dim cModel As New CISModel.MasterModel
        ddINDUSTRY.DataSource = cModel.GetIndustryList
        ddINDUSTRY.DataTextField = "INDUSTRYNAME"
        ddINDUSTRY.DataValueField = "INDUSTRYNAME"
        ddINDUSTRY.DataBind()
    End Sub

    Private Sub PopulateServiceGrid(ByVal id As Long)
        Dim oclModel As New CISModel.ClientModel
        If id > 0 Then
            Dim dt As DataTable = oclModel.GetCurrentSubscribedServices(id)

            dgClientServices.DataSource = dt
            dgClientServices.DataBind()
        Else
            dgClientServices.DataSource = Nothing
            dgClientServices.DataBind()
        End If

    End Sub

    Private Sub PopulateAttachmentGrid(ByVal id As Long)
        Dim oclModel As New CISModel.ClientModel
        If id > 0 Then
            Dim dt As DataTable = oclModel.GetClientAttachmentsList(id)

            dgFiles.DataSource = dt
            dgFiles.DataBind()
            Me.btnNewFile.Enabled = True
        Else
            dgFiles.DataSource = Nothing
            dgFiles.DataBind()
            Me.btnNewFile.Enabled = False

        End If


    End Sub

    Private Sub PopulateNoteGrid(ByVal id As Long)
        Dim oclModel As New CISModel.ClientModel
        If id > 0 Then
            Dim dt As DataTable = oclModel.GetClientNoteList(id)

            dgNotes.DataSource = dt
            dgNotes.DataBind()
            Me.btnNewNote.Enabled = True
        Else
            dgNotes.DataSource = Nothing
            dgNotes.DataBind()
            Me.btnNewNote.Enabled = False
        End If

    End Sub


    Private Sub PopulateClientPage(ByVal id As Long)
        Dim cisEnt As New CISEntity.ClientEntity
        Dim cisModel As New CISModel.ClientModel

        cisEnt = cisModel.GetClient(id)

        ClearModalNote()

        If Not IsNothing(cisEnt) AndAlso id > 0 Then
            Me.txtCLIENTID.Text = cisEnt.ClientID.ToString
            Me.txtCLIENTCODE.Text = cisEnt.ClientCode
            Me.txtName.Text = cisEnt.Name
            Me.txtADDRESS.Text = cisEnt.Address
            Me.ddINDUSTRY.SelectedValue = cisEnt.Industry
            Me.txtContactNumber.Text = cisEnt.ContactNumber
            Me.txtFax.Text = cisEnt.Fax
            Me.txtWebsite.Text = cisEnt.Website
            Me.txtEmail.Text = cisEnt.EmailAddress
            Me.txtRemarks.Text = cisEnt.Remarks
            Me.chkActive.Checked = cisEnt.IsActiveFlg
            Me.lblCreatedBy.Text = "Created By:" + cisModel.GetProfileName(cisEnt.CreatedBy)
            'cisEnt.CreatedBy.ToString
            Me.lblCreatedDt.Text = "Create Date:" + cisEnt.CreateDate.ToString
            Me.lblUpdatedBy.Text = "Last Updated by:" + cisModel.GetProfileName(cisEnt.UpdatedBy)
            'cisEnt.UpdatedBy.ToString
            Me.lblUpdateDt.Text = "Last Updated:" + cisEnt.UpdateDate.ToString

            Dim objweb As New CISModel.WebModel
            Me.txtURL.Enabled = True
            Me.txtURL.Text = objweb.GetWebAppURL + "Client/?id=" + Me.txtCLIENTID.Text
            objweb = Nothing

            PopulateServiceGrid(id)
            PopulateAttachmentGrid(id)
            PopulateNoteGrid(id)
            PopulateDDService()

            Me.btnAddService.Enabled = True

        ElseIf IsNothing(cisEnt) AndAlso id = 0 Then

            SetNewClient()
        Else
            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, "Client Does not exist!")
            objAlert = Nothing
            Me.txtURL.Enabled = False
        End If

    End Sub

    Private Function SetFormClientEntity() As CISEntity.ClientEntity
        Dim clntEntity As New CISEntity.ClientEntity

        clntEntity.ClientID = Me.txtCLIENTID.Text
        clntEntity.ClientCode = Me.txtCLIENTCODE.Text
        clntEntity.Name = Me.txtName.Text
        clntEntity.Address = Me.txtADDRESS.Text
        clntEntity.Industry = Me.ddINDUSTRY.SelectedValue
        clntEntity.ContactNumber = Me.txtContactNumber.Text
        clntEntity.Fax = Me.txtFax.Text
        clntEntity.Website = Me.txtWebsite.Text
        clntEntity.EmailAddress = Me.txtEmail.Text
        clntEntity.Remarks = Me.txtRemarks.Text
        clntEntity.IsActiveFlg = Me.chkActive.Checked

        Return clntEntity
    End Function

    Private Function GetUserProfile() As CISEntity.ProfileEntity
        Return Session("usrProfileEntity")
    End Function


    Private Function ValidateClientPageForSave(ByRef ErrorMsg As String) As Boolean
        ErrorMsg = ""
        If Trim(Me.txtCLIENTCODE.Text) = "" Then
            ErrorMsg &= "Client Code Is invalid!\n"
        End If

        If Trim(Me.txtName.Text) = "" Then
            ErrorMsg &= "Client Name Is invalid!\n"
        End If

        If Trim(Me.txtContactNumber.Text) = "" Then
            ErrorMsg &= "Client Contact Number Is invalid!\n"
        End If

        If ErrorMsg.Length > 0 Then
            Return False
        Else
            Return True
        End If

        Return False
    End Function

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim errMsg As String = ""

        If ValidateClientPageForSave(errMsg) Then
            Dim clntEntity As CISEntity.ClientEntity = SetFormClientEntity()
            Dim modelClient As New CISModel.ClientModel

            modelClient.SaveClient(clntEntity, GetUserProfile.ProfileID)
            SetEnablePageSaves(True)

            If Me.txtCLIENTID.Text = 0 Then
                Me.txtCLIENTID.Text = clntEntity.ClientID.ToString
            End If

            'ALERT FOR SUCCESSFUL SAVE
            Dim strAlert As String = "Client Information Saved, Additional Information can now be added."

            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, strAlert)

            objAlert = Nothing
            modelClient = Nothing
            clntEntity = Nothing
        Else

            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, errMsg)

            objAlert = Nothing
        End If



    End Sub

    Private Sub SetNewClient()

        Dim id As Long = 0
        Me.txtCLIENTID.Text = 0
        Me.txtCLIENTCODE.Text = ""
        Me.txtName.Text = "NEW CLIENT"
        Me.txtADDRESS.Text = ""
        Me.ddINDUSTRY.SelectedValue = Nothing
        Me.txtContactNumber.Text = ""
        Me.txtFax.Text = ""
        Me.txtWebsite.Text = ""
        Me.txtEmail.Text = ""
        Me.txtRemarks.Text = "NEW CLIENT REMARKS"
        Me.chkActive.Checked = True
        Me.lblCreatedBy.Text = "Created By:"
        'cisEnt.CreatedBy.ToString
        Me.lblCreatedDt.Text = "Create Date:"
        Me.lblUpdatedBy.Text = "Last Updated by:"
        'cisEnt.UpdatedBy.ToString
        Me.lblUpdateDt.Text = "Last Updated:"

        PopulateServiceGrid(ID)
        PopulateAttachmentGrid(ID)
        PopulateNoteGrid(ID)
        PopulateDDService()
        Me.txtURL.Enabled = False

        'DISABLE ADD-ON BUTTONS
        Me.btnAddService.Enabled = False
        Me.btnNewFile.Enabled = False
        Me.btnNewNote.Enabled = False

        Me.txtCLIENTCODE.Focus()

        'Dim strAlert As String = ""
        'Dim objAlert As New DynamicClientScript
        'objAlert.ShowMessage(Me.Page, strAlert)
        'objAlert = Nothing

    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        'Response.Redirect("~/Client/?id=0")
        SetNewClient()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Me.txtIDSearch.Text = ""
        Me.txtCodeSearch.Text = ""
        Me.txtNameSearch.Text = ""
        Dim modelClient As New CISModel.ClientModel
        Me.dgClientResults.DataSource = modelClient.GetClientList(0)
        Me.dgClientResults.DataBind()
        Me.txtIDSearch.Focus()
        SetResultCount(0)
        modelClient = Nothing

        'keep expanded
        Me.cpeSearch.Collapsed = False
        Me.cpeSearch.ClientState = False
    End Sub

    Protected Sub btnCodeSearch_Click(sender As Object, e As EventArgs) Handles btnCodeSearch.Click
        Dim modelClient As New CISModel.ClientModel
        Dim entClient As New List(Of CISEntity.ClientEntity)

        entClient = modelClient.GetClientEntityListByCode(Me.txtCodeSearch.Text, True)
        dgClientResults.DataSource = entClient
        dgClientResults.DataBind()

        If Not IsNothing(entClient) Then
            SetResultCount(entClient.Count)
        End If

        Me.cpeSearch.Collapsed = False
        Me.cpeSearch.ClientState = False

        modelClient = Nothing
        entClient = Nothing
    End Sub

    Private Sub btnNameSearch_Click(sender As Object, e As EventArgs) Handles btnNameSearch.Click
        Dim modelClient As New CISModel.ClientModel
        Dim entClient As New List(Of CISEntity.ClientEntity)

        entClient = modelClient.GetClientEntityListByName(Me.txtNameSearch.Text, True)
        dgClientResults.DataSource = entClient
        dgClientResults.DataBind()
        If Not IsNothing(entClient) Then
            SetResultCount(entClient.Count)
        End If

        Me.cpeSearch.Collapsed = False
        Me.cpeSearch.ClientState = False

    End Sub

    Private Sub SetResultCount(ByVal value As Long)
        Me.lblResults.InnerText = "Results (" + value.ToString + ")"

    End Sub

    Private Sub btnSearchID_Click(sender As Object, e As EventArgs) Handles btnSearchID.Click
        Dim modelClient As New CISModel.ClientModel
        Dim entClient As New List(Of CISEntity.ClientEntity)
        Dim ID As Long


        If IsNumeric(Me.txtIDSearch.Text) Then
            ID = CType(Me.txtIDSearch.Text, Long)
            entClient = modelClient.GetClientList(ID)
            dgClientResults.DataSource = entClient
            dgClientResults.DataBind()

            If Not IsNothing(entClient) Then
                SetResultCount(entClient.Count)
            End If

            Me.cpeSearch.Collapsed = False
            Me.cpeSearch.ClientState = False
        Else
            'ALERT FOR SUCCESSFUL SAVE
            dgClientResults.DataSource = Nothing
            dgClientResults.DataBind()
            Dim strAlert As String = "Invalid ClientID, Numeric Inputs only!"

            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, strAlert)
            objAlert = Nothing
        End If


    End Sub

    Private Sub dgClientResults_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dgClientResults.UpdateCommand
        Dim ID As Long = CType(e.Item.Cells(0).Text, Long)
        PopulateClientPage(ID)
        Me.cpeSearch.Collapsed = False
        Me.cpeSearch.ClientState = False
    End Sub

    Private Function InsertAttachmentRecord(ByVal FilePath As String, ByVal FTPFilePath As String) As Long
        Dim modClient As New CISModel.ClientModel

        Dim entFile As New CISEntity.FileAttachEntity
        With entFile
            .FilePath = FTPFilePath
            .Remarks = txtAttachmentRemarks.Text
            .ParentID = CType(Me.txtCLIENTID.Text, Long)
            .AttachmentType = "CL"
            .IsActiveFlag = True
            .PurgeFlag = False
            ' objWebUtility.GetFTPLocalPath + "CL-" + InserAttachmentRecord() + "-" + Fn

        End With

        Return modClient.UploadSaveNewAttachment(entFile, GetUserProfile.ProfileID)
    End Function

    Private Sub ClearModalFileAttachment()
        Me.txtFILEID.Text = "0"
        'Me.fileInput1.Value = Nothing
        Me.txtAttachmentRemarks.Text = Nothing

    End Sub

    Private Sub ClearModalClService()
        Me.txtCLServiceID.Text = 0
        Me.ddServiceName.Items.Clear()
        Me.ddServiceName.SelectedValue = Nothing
    End Sub


    Private Sub btnUploadSaveAttachment_Click(sender As Object, e As EventArgs) Handles btnUploadSaveAttachment.Click
        Dim objWebUtility As New CISData.WebUtility
        If Not IsNothing(Me.fileInput1.PostedFile) AndAlso fileInput1.PostedFile.ContentLength > 0 Then
            If Me.fileInput1.PostedFile.ContentLength < objWebUtility.GetUploadFileLimit Then

                Dim Fn As String = System.IO.Path.GetFileName(Me.fileInput1.PostedFile.FileName)
                Dim strFileName As String = "CL-" + Now.ToString("yyyyMMddhhmmss") + "-" + Fn
                Dim strFilePath As String = objWebUtility.GetFTPLocalPath + strFileName
                Dim strFTPFilePath As String = objWebUtility.GetFTPPathRoot + strFileName
                Dim lngFileID As Long = InsertAttachmentRecord(strFilePath, strFTPFilePath)

                Dim SaveLoc As String = strFilePath
                fileInput1.PostedFile.SaveAs(SaveLoc)

                Dim strErr1 As String = "SaveAs Complete"
                Dim objAlert1 As New DynamicClientScript
                objAlert1.ShowMessage(Me.Page, strErr1)
                objAlert1 = Nothing

                PopulateAttachmentGrid(CType(Me.txtCLIENTID.Text, Long))

                ClearModalFileAttachment()

                Me.mpeAttachment.Hide()

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
    End Sub

    Private Sub dgFiles_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dgFiles.UpdateCommand
        Dim strDownload As String = CType(e.Item.Cells(2).Text, String)
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "');</script>")

    End Sub

    Private Sub btnNewFile_Click(sender As Object, e As EventArgs) Handles btnNewFile.Click
        ClearModalFileAttachment()
        Me.mpeAttachment.Show()
    End Sub



    Private Sub PopulateDDService()
        Dim mocCLSvc As New CISModel.ClientModel
        Me.txtCLServiceID.Text = "0"

        Me.ddServiceName.DataSource = mocCLSvc.GetUnsubscribedServices(CType(Me.txtCLIENTID.Text, Long))
        Me.ddServiceName.DataTextField = "ServiceName"
        Me.ddServiceName.DataValueField = "ServiceID"
        Me.ddServiceName.DataBind()
        mocCLSvc = Nothing
    End Sub

    Private Sub btnNewService_Click(sender As Object, e As EventArgs) Handles btnNewService.Click
        Dim CLServiceID As Long = CType(Me.txtCLServiceID.Text, Long)
        Dim strErr As String = ""

        If Me.ddServiceName.SelectedValue > 0 Then
            Dim dataClientModel As New CISModel.ClientModel
            Dim saveClientService As New CISEntity.ClientServiceEntity
            With saveClientService
                .ClientServiceID = CLServiceID
                .ClientID = CType(Me.txtCLIENTID.Text, Long)
                .ServiceID = Me.ddServiceName.SelectedValue
                .IsActiveFlag = True
                .PurgeFlag = False

            End With

            dataClientModel.SaveClientService(saveClientService, GetUserProfile.ProfileID)

            strErr = "New Service Successfully Subscribed!"

            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, strErr)
            objAlert = Nothing

            PopulateServiceGrid(CType(Me.txtCLIENTID.Text, Long))
            PopulateDDService()
        Else
            strErr = "Please Select a valid Service to Subscribe."

            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, strErr)
            objAlert = Nothing

            Me.mpeClServices.Show()

        End If

    End Sub

    Private Sub dgClientServices_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dgClientServices.UpdateCommand
        Response.Redirect("~/ClientService/?ID=" + CType(e.Item.Cells(1).Text, String))
    End Sub

    Private Sub btnDeleteNote_Click(sender As Object, e As EventArgs) Handles btnDeleteNote.Click

        Dim dmClient As New CISModel.ClientModel
        dmClient.DeleteNote(CType(Me.txtNoteID.Text, Long), GetUserProfile.ProfileID)

        PopulateNoteGrid(CType(Me.txtCLIENTID.Text, Long))

        ClearModalNote()

        Me.mpeNotes.Hide()

        Dim strErr As String = "Note Successfully Deleted!"
        Dim objAlert As New DynamicClientScript
        objAlert.ShowMessage(Me.Page, strErr)
        objAlert = Nothing
    End Sub

    Private Sub btnSaveNote_Click(sender As Object, e As EventArgs) Handles btnSaveNote.Click
        Dim dmClient As New CISModel.ClientModel
        Dim entNote As New CISEntity.NotesEntity
        With entNote
            If Not IsNumeric(Me.txtNoteID.Text) Then
                Me.txtNoteID.Text = 0
            End If
            .NoteID = CType(Me.txtNoteID.Text, Long)
            .ParentType = "CL"
            .ParentID = CType(Me.txtCLIENTID.Text, Long)
            .NoteDate = Now()
            .NoteText = Me.txtNoteText.Text
            .IsActiveFlag = True
            .PurgeFlag = False
        End With
        dmClient.SaveNote(entNote, GetUserProfile.ProfileID)
        PopulateNoteGrid(CType(Me.txtCLIENTID.Text, Long))
        Me.txtNoteID.Text = entNote.NoteID.ToString
        Me.txtNoteDate.Text = entNote.NoteDate.ToShortDateString

        Dim strErr As String = "Note Successfully Saved!"
        Dim objAlert As New DynamicClientScript
        objAlert.ShowMessage(Me.Page, strErr)
        objAlert = Nothing
    End Sub



    Private Sub dgNotes_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dgNotes.UpdateCommand
        'Response.Redirect("~/ClientService/?ID=" + CType(e.Item.Cells(1).Text, String))
        Dim dataNote As New CISData.NotesData
        Dim entNote As New CISEntity.NotesEntity
        entNote = dataNote.GetNote(CType(e.Item.Cells(1).Text, Long))

        Me.mpeNotes.Show()

        Me.txtNoteID.Text = entNote.NoteID.ToString
        Me.txtNoteDate.Text = entNote.NoteDate.ToString
        Me.txtNoteText.Text = entNote.NoteText

        entNote = Nothing
        dataNote = Nothing

    End Sub

    Private Sub btnCancelNoteModal_Click(sender As Object, e As EventArgs) Handles btnCancelNoteModal.Click
        Me.mpeNotes.Hide()
        ClearModalNote()
    End Sub

    Private Sub ClearModalNote()
        Me.txtNoteID.Text = "0"
        Me.txtNoteDate.Text = Nothing
        Me.txtNoteText.Text = Nothing
    End Sub

    Private Sub btnClearNote_Click(sender As Object, e As EventArgs) Handles btnClearNote.Click
        ClearModalNote()
        mpeNotes.Show()
        Me.txtNoteText.Focus()
    End Sub

    Private Sub dgFiles_ItemDataBound(sender As Object, e As DataGridItemEventArgs) Handles dgFiles.ItemDataBound
        If e.Item.Cells.Count > 0 AndAlso e.Item.Cells(4).Controls.Count > 0 Then
            CType(e.Item.Cells(4).Controls(0), LinkButton).OnClientClick = "return confirm('Are you certain you want to delete?');"
        End If

    End Sub

    Private Sub dgFiles_DeleteCommand(source As Object, e As DataGridCommandEventArgs) Handles dgFiles.DeleteCommand
        Dim modFiles As New CISModel.ClientModel
        modFiles.FilePurge(CType(e.Item.Cells(1).Text, Long), GetUserProfile.ProfileID)
        'modFiles.DeleteNote(CType(e.Item.Cells(1).Text, Long), GetUserProfile.ProfileID)
        'modFiles = Nothing

        Dim strErr As String = "File Attachment  Deleted!"
        Dim objAlert As New DynamicClientScript
        objAlert.ShowMessage(Me.Page, strErr)
        objAlert = Nothing

        PopulateAttachmentGrid(CType(Me.txtCLIENTID.Text, Long))
    End Sub


    Private Sub btnEncryptURL_Click(sender As Object, e As EventArgs) Handles btnEncryptURL.Click
        Dim objweb As New CISModel.WebModel

        Me.txtURL.Text = objweb.GetWebAppURL + "Client/?enc=1&id=" + objweb.MasterEncrypt(Me.txtCLIENTID.Text)
        objweb = Nothing
        Me.mpeShareURL.Show()
    End Sub


End Class