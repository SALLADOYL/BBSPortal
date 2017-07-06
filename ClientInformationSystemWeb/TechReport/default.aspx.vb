Imports CISEntity
Imports CISModel
Imports CISData
Imports System.Data.SqlClient

Public Class _default6
    Inherits System.Web.UI.Page

    Private Sub PopulateDDPoNumber(ByVal ClSvcID As Long)
        Dim dt As New DataTable
        Dim dataTSWork As New CISData.TSWorkData

        dt = dataTSWork.GetPONumberListByWork(ClSvcID)


        Me.ddPONumber.SelectedIndex = -1
        'If Me.ddPONumber.Items.Count = 1 Then
        Me.ddPONumber.SelectedValue = 0
        'End If
        Me.ddPONumber.DataSource = dt
        Me.ddPONumber.DataTextField = "PONUMBER"
        Me.ddPONumber.DataValueField = "TSWORKID"
        Me.ddPONumber.DataBind()

        dataTSWork = Nothing
        dt = Nothing

    End Sub
    Private Sub PopulateTRInfoPage(ByVal TechRepID As Long)
        Dim entTR As New CISEntity.TechnicalReportEntity
        Dim modTR As New CISModel.TechReportModel

        entTR = modTR.GetTechnicalReportEntity(TechRepID)

        If Not IsNothing(entTR) AndAlso TechRepID > 0 Then
            Me.txtTRID.Text = entTR.TechnicalReportID.ToString
            Me.ddTRTeam.SelectedValue = entTR.Team
            Me.ddPerformedBy.SelectedValue = entTR.PerformedBy
            Me.ddStatus.SelectedValue = entTR.Status
            Me.txtStartDate.Text = entTR.StartDate.ToString
            Me.txtCompleteDate.Text = entTR.CompletionDate.ToString
            Me.txtSearchTags.Text = entTR.SearchTags
            Me.txtIssueCause.Text = entTR.IssueCause
            Me.txtResolutionDetails.Text = entTR.ResolutionDetails
            Me.txtRemarks.Text = entTR.Remarks

            Me.lblCreatedBy.Text = "Created By:" + modTR.GetProfileName(entTR.CreatedBy)
            Me.lblCreatedDt.Text = "Create Date:" + entTR.CreateDate.ToString
            Me.lblUpdatedBy.Text = "Last Updated by:" + modTR.GetProfileName(entTR.UpdatedBy)
            Me.lblUpdateDt.Text = "Last Updated:" + entTR.UpdateDate.ToString

            'PopulateDDPoNumber(entTR.ClientServiceID)
            PopulateClientServiceInfoParent(TechRepID)
            PopulateAffectedDevicesGrid(TechRepID)
            PopulateClientDevicesNotAddedinTR()
            PopulateAttachmentGrid(TechRepID)

        ElseIf IsNothing(entTR) AndAlso TechRepID = 0 Then
            Me.txtTRID.Text = "0"
            Me.ddTRTeam.SelectedValue = ""
            Me.ddPerformedBy.SelectedValue = ""
            Me.ddStatus.SelectedValue = ""
            Me.txtStartDate.Text = Now.ToShortDateString
            Me.txtCompleteDate.Text = Now.ToShortDateString
            Me.txtSearchTags.Text = ""
            Me.txtIssueCause.Text = ""
            Me.txtResolutionDetails.Text = ""
            Me.txtRemarks.Text = ""

            Me.lblCreatedBy.Text = "Created By:"
            Me.lblCreatedDt.Text = "Create Date:"
            Me.lblUpdatedBy.Text = "Last Updated by:"
            Me.lblUpdateDt.Text = "Last Updated:"

            PopulateClientServiceInfoParent(TechRepID)
            PopulateAffectedDevicesGrid(TechRepID)
            PopulateDDPoNumber(TechRepID)
            PopulateClientDevicesNotAddedinTR()
            PopulateAttachmentGrid(TechRepID)
        Else
            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, "The Technical Report Information does not exist!")
            objAlert = Nothing
        End If
    End Sub



    Private Sub PopulateDDAssignedTo()

        Dim modProfile As New CISModel.ProfileModel

        Me.ddPerformedBy.DataSource = modProfile.GetEmployeesListWithBlank
        Me.ddPerformedBy.DataTextField = "Name"
        Me.ddPerformedBy.DataValueField = "ProfileID"
        Me.ddPerformedBy.DataBind()
    End Sub

    Private Sub PopulateAffectedDevicesGrid(ByVal TechRepID As Long)
        Dim entListTSAffectedDevices As DataTable
        Dim dataDevice As New CISData.DeviceData

        entListTSAffectedDevices = dataDevice.GetTRAffectedDeviceList(TechRepID)
        Me.dgAffectedDevices.DataSource = entListTSAffectedDevices
        Me.dgAffectedDevices.DataBind()
    End Sub

    Private Sub PopulateDDTRStatusSearch()
        Dim modTR As New CISModel.TechReportModel
        Me.ddTRStatusSearchList.DataSource = modTR.GetTRStatusList
        Me.ddTRStatusSearchList.DataValueField = "Status"
        Me.ddTRStatusSearchList.DataTextField = "Status"
        Me.ddTRStatusSearchList.DataBind()

        Me.ddStatus.DataSource = modTR.GetTRStatusList
        Me.ddStatus.DataValueField = "Status"
        Me.ddStatus.DataTextField = "Status"
        Me.ddStatus.DataBind()


    End Sub
    Private Sub PopulateDDServiceSearch()
        Dim modTR As New CISModel.TechReportModel
        'Me.ddServiceListSearch.DataSource = modTR.GetServiceListForSearch
        Dim statusList As New List(Of CISEntity.ServiceEntity)
        Dim blankServiceEntity As New CISEntity.ServiceEntity
        blankServiceEntity.ServiceID = 0
        blankServiceEntity.ServiceName = ""

        statusList.Add(blankServiceEntity)
        statusList.AddRange(modTR.GetServiceListForSearch)

        Me.ddServiceListSearch.DataSource = statusList
        Me.ddServiceListSearch.DataTextField = "ServiceName"
        Me.ddServiceListSearch.DataValueField = "ServiceID"
        Me.ddServiceListSearch.DataBind()
    End Sub

    Private Sub PopulateDDClientSearch()
        Dim modTR As New CISModel.TechReportModel
        Dim clientList As New List(Of CISEntity.ClientEntity)
        Dim blankClientEntity As New CISEntity.ClientEntity
        blankClientEntity.ClientID = 0
        blankClientEntity.Name = ""

        clientList.Add(blankClientEntity)
        clientList.AddRange(modTR.GetClientListForSearch)

        Me.ddClientNameSearch.DataSource = clientList
        Me.ddClientNameSearch.DataTextField = "Name"
        Me.ddClientNameSearch.DataValueField = "ClientID"
        Me.ddClientNameSearch.DataBind()

        Me.ddClientList.DataSource = clientList
        Me.ddClientList.DataTextField = "Name"
        Me.ddClientList.DataValueField = "ClientID"
        Me.ddClientList.DataBind()

    End Sub

    Private currentTechRepID As Long

    Private Sub PopulateClientDevicesNotAddedinTR()
        Dim mdlTR As New CISModel.TechReportModel
        Me.dgAddAffectedDeviceModal.DataSource = mdlTR.GetTechReportAffectedDevices(CType(Me.txtTRID.Text, Long))
        Me.dgAddAffectedDeviceModal.DataBind()
        mdlTR = Nothing
    End Sub

    Private Sub PopulateClientServiceInfoParent(ByVal techRepID As Long)
        Dim modTR As New CISModel.TechReportModel
        Dim dt As New DataTable

        dt = modTR.GetClientServiceParent(techRepID)
        'TECHREPID, CLIENTID , CLIENTSVCID, TSWORKID
        If dt.Rows.Count > 0 Then

            Dim modClient As New CISModel.ClientModel
            Dim entClient As CISEntity.ClientEntity = modClient.GetClient(CType(dt.Rows(0)("CLIENTID"), Long))
            Me.ddClientList.SelectedValue = entClient.ClientID
            Me.txtClientCode.Text = entClient.ClientCode

            Dim entCLService As New CISEntity.ClientServiceEntity
            Dim dataCLService As New CISData.ClientServiceData
            entCLService = dataCLService.GetClientService(CType(dt.Rows(0)("CLIENTSVCID"), Long))
            PopulateServiceList(entClient.ClientID)
            Me.ddServiceList.SelectedValue = entCLService.ServiceID
            Me.txtCLSSVCID.Text = entCLService.ClientServiceID

            Dim entTSWork As New CISEntity.TSWorkEntity
            Dim dataTSWork As New CISData.TSWorkData
            entTSWork = dataTSWork.GetTSWork(CType(dt.Rows(0)("TSWORKID"), Long)) 'TSWORKID
            'dataTSWork.GetTSWork(CType(dt.Rows(0)("CLIENTSVCID"), Long))
            PopulateDDPoNumber(entTSWork.ClientServiceID)
            Me.ddPONumber.SelectedValue = entTSWork.TSWorkID
            Me.txtTSWorkID.Text = entTSWork.TSWorkID.ToString

            modClient = Nothing
            entClient = Nothing
            entCLService = Nothing
            dataCLService = Nothing
            entTSWork = Nothing
            dataTSWork = Nothing

        End If

        modTR = Nothing
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        currentTechRepID = CType(Request.QueryString("ID"), Long)

        If Not Page.IsPostBack Then
            PopulateDDClientSearch()
            PopulateDDServiceSearch()
            PopulateDDTRStatusSearch()
            PopulateDDAssignedTo()
            PopulateTRInfoPage(currentTechRepID)
        End If

    End Sub

    Private Sub btnStatusSearch_Click(sender As Object, e As EventArgs) Handles btnStatusSearch.Click
        Dim modTR As New CISModel.TechReportModel
        Me.dgResults.DataSource = modTR.SearchTRbyStatus(Me.ddTRStatusSearchList.SelectedValue)
        Me.dgResults.DataBind()
        modTR = Nothing
    End Sub

    Private Sub btnTeamSearch_Click(sender As Object, e As EventArgs) Handles btnTeamSearch.Click
        Dim modTR As New CISModel.TechReportModel
        Me.dgResults.DataSource = modTR.SearchTRbyTeam(Me.ddTeamSearchList.SelectedValue)
        Me.dgResults.DataBind()
        modTR = Nothing
    End Sub

    Private Sub btnStartDTSearch_Click(sender As Object, e As EventArgs) Handles btnStartDTSearch.Click


        If IsDate(Me.txtStartDateFrom.Text) And IsDate(Me.txtStartDateTo.Text) Then
            Dim modTR As New CISModel.TechReportModel
            Me.dgResults.DataSource = modTR.SearchTRbyStartDateRange(CType(Me.txtStartDateFrom.Text, Date), CType(Me.txtStartDateTo.Text, Date))
            Me.dgResults.DataBind()
            modTR = Nothing
        Else
            Dim strErr As String = "Cannot Perform this search. Invalid Start Date Range."

            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, strErr)
            objAlert = Nothing
        End If

    End Sub


    Private Sub btnCompleteDateSearch_Click(sender As Object, e As EventArgs) Handles btnCompleteDateSearch.Click
        Dim modTR As New CISModel.TechReportModel

        If IsDate(Me.txtCompleteDTFrom.Text) And IsDate(Me.txtCompleteDTTo.Text) Then
            Me.dgResults.DataSource = modTR.SearchTRbyCompletedDateRange(Me.txtCompleteDTFrom.Text, Me.txtCompleteDTTo.Text)
            Me.dgResults.DataBind()
        Else
            Dim strErr As String = "Cannot Perform this search. Invalid Completion Date Range."

            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, strErr)
            objAlert = Nothing
        End If

        modTR = Nothing
    End Sub

    Private Sub btnClientServiceSearch_Click(sender As Object, e As EventArgs) Handles btnClientServiceSearch.Click
        Dim modTR As New CISModel.TechReportModel

        If ddClientNameSearch.SelectedValue = 0 Then
        ElseIf ddServiceListSearch.SelectedValue = 0 Then
            Dim strErr As String = "Cannot Perform this search. Invalid Client-Service selection."

            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, strErr)
            objAlert = Nothing

        Else
            dgResults.DataSource = modTR.SearchTRbyClientService(CType(ddClientNameSearch.SelectedValue, Long), CType(ddServiceListSearch.SelectedValue, Long))
            dgResults.DataBind()
        End If

        modTR = Nothing

    End Sub
    Private Sub PopulateServiceList(ByVal clientID As Long)
        Dim modTR As New CISModel.TechReportModel
        Me.ddServiceList.SelectedIndex = -1
        Me.ddServiceList.DataSource = modTR.GetServiceListWithBlank(clientID) 'CType(ddClientList.SelectedValue, Long))
        Me.ddServiceList.DataTextField = "ServiceName"
        Me.ddServiceList.DataValueField = "ServiceID"
        Me.ddServiceList.DataBind()
        modTR = Nothing
    End Sub
    Private Sub ddClientList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddClientList.SelectedIndexChanged
        If ddClientList.SelectedValue <> "" Then
            Dim entClient As New CISEntity.ClientEntity
            Dim modClient As New CISModel.ClientModel
            entClient = modClient.GetClient(ddClientList.SelectedValue)

            Me.txtClientCode.Text = entClient.ClientCode
            entClient = Nothing
            modClient = Nothing
        Else
            Me.txtCLSSVCID.Text = "0"
        End If

        'POPULATE SERVICELIST; CLEAR SERVICE INFO, WORK INFO
        Me.ddServiceList.SelectedIndex = -1
        PopulateServiceList(CType(ddClientList.SelectedValue, Long))
        Me.ddPONumber.SelectedIndex = -1

        Me.txtTSWorkID.Text = "0"
        PopulateDDPoNumber(0)

    End Sub

    Private Function GetUserProfile() As CISEntity.ProfileEntity
        Return Session("usrProfileEntity")
    End Function

    Private Function SetFormTechReportEntity() As CISEntity.TechnicalReportEntity
        Dim entTechReport As New CISEntity.TechnicalReportEntity

        With entTechReport
            .TechnicalReportID = CType(Me.txtTRID.Text, Long)  '[TECHREPID]
            .ClientServiceID = CType(Me.txtCLSSVCID.Text, Long) ',[CLIENTSVCID]
            .TSWorkID = CType(Me.txtTSWorkID.Text, Long) ',[TSWORKID]
            .Team = Me.ddTRTeam.SelectedValue ',[TEAM]
            .PerformedBy = Me.ddPerformedBy.SelectedValue ',[PERFORMEDBY]
            .SearchTags = Me.txtSearchTags.Text ',[SEARCHTAGS]
            .InvestigationDetails = ""  ',[INVESTIGATIONDETAILS]
            .IssueCause = Me.txtIssueCause.Text ',[ISSUECAUSE]
            .ResolutionDetails = Me.txtResolutionDetails.Text ',[RESOLUTIONDETAILS]
            .ProposedDetails = "" ',[PROPOSEDDETAILS]
            .Status = Me.ddStatus.SelectedValue ',[STATUS]
            .StartDate = Date.Parse(Me.txtStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("us-au").DateTimeFormat) 'CType(Me.txtStartDate.Text, DateTime) ',[STARTDT]
            .CompletionDate = Date.Parse(Me.txtCompleteDate.Text, System.Globalization.CultureInfo.GetCultureInfo("us-au").DateTimeFormat) 'CType(Me.txtCompleteDate.Text, DateTime) ',[COMPLETEDT]
            .Remarks = txtRemarks.Text ',[REMARKS]
            .IsActiveFlag = True '[ISACTIVEFLG]
            .PurgeFlag = False ',[PURGEFLG]
            ',[CRTDT]
            .CreatedBy = GetUserProfile.ProfileID  ',[CRTBY]
            ',[UPDDT]
            ',[UPDBY]
            ',[TMPSTMP]
        End With

        Return entTechReport


    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim entTR As CISEntity.TechnicalReportEntity = SetFormTechReportEntity()
        Dim modTR As New CISModel.TechReportModel
        modTR.Save(entTR, GetUserProfile.ProfileID)

        'ALERT FOR SUCCESSFUL SAVE
        Dim strAlert As String = "Technical Report Information Saved"

        Dim objAlert As New DynamicClientScript
        objAlert.ShowMessage(Me.Page, strAlert)

        objAlert = Nothing
        modTR = Nothing
        entTR = Nothing
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Response.Redirect("~/TechReport/?ID=0")
    End Sub

    Private Sub ddPONumber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddPONumber.SelectedIndexChanged
        If ddPONumber.Text.Length > 0 Then
            Me.txtTSWorkID.Text = ddPONumber.SelectedValue
        Else
            Me.txtTSWorkID.Text = 0
        End If
    End Sub

    Private Sub ddServiceList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddServiceList.SelectedIndexChanged
        If ddServiceList.Text <> "" Then
            Dim entClientService As New CISEntity.ClientServiceEntity
            Dim modClSvc As New CISModel.ClientModel
            entClientService = modClSvc.GetClientServiceByClientIDSvcID(ddClientList.SelectedValue, ddServiceList.SelectedValue)

            txtCLSSVCID.Text = entClientService.ClientServiceID
            entClientService = Nothing
            modClSvc = Nothing
        Else
            txtCLSSVCID.Text = ""
        End If

        If Me.ddPONumber.Items.Count > 0 Then
            Me.ddPONumber.SelectedIndex = 0
            Me.txtTSWorkID.Text = "0"
        Else
            Me.ddPONumber.SelectedIndex = -1
            Me.txtTSWorkID.Text = "0"
        End If

        PopulateDDPoNumber(Me.ddServiceList.SelectedValue)
    End Sub

    Private Sub dgResults_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dgResults.UpdateCommand
        Dim TRID As Long = CType(e.Item.Cells(1).Text, Long)
        PopulateTRInfoPage(TRID)
    End Sub



    Private Sub dgAffectedDevices_ItemDataBound(sender As Object, e As DataGridItemEventArgs) Handles dgAffectedDevices.ItemDataBound
        If e.Item.Cells.Count > 0 AndAlso e.Item.Cells(6).Controls.Count > 0 Then
            CType(e.Item.Cells(6).Controls(0), Button).OnClientClick = "return confirm('Remove this Device?');"
        End If
    End Sub

    Private Sub dgAffectedDevices_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dgAffectedDevices.UpdateCommand
        Dim modWeb As New CISModel.WebModel

        Dim strDownload As String = modWeb.GetWebAppURL() + "Device/?id=" + e.Item.Cells(2).Text
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "', 'Device Update Window', 'width=1100,height=600,left=25,top=50,resizable=yes,scrollbars=yes');</script>")
        'Response.Write("<script type='text/javascript'>window.showModalDialog('" + strDownload + "', 'Device Update Window', 'dialogWidth:1100px;dialogHeight:600px;left:25;top:50;resizable:yes;scrollbars:yes;');</script>")
        modWeb = Nothing
    End Sub

    Private Sub dgAffectedDevices_DeleteCommand(source As Object, e As DataGridCommandEventArgs) Handles dgAffectedDevices.DeleteCommand
        Dim modTR As New CISModel.TechReportModel
        modTR.PurgeTechRepAffectedDevices(CType(e.Item.Cells(1).Text, Long))
        modTR = Nothing

        Dim strErr As String = "Device Removed from Report!"
        Dim objAlert As New DynamicClientScript
        objAlert.ShowMessage(Me.Page, strErr)
        objAlert = Nothing

        PopulateAffectedDevicesGrid(CType(Me.txtTRID.Text, Long))
        PopulateClientDevicesNotAddedinTR()

    End Sub


    Private Sub dgAddAffectedDeviceModal_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dgAddAffectedDeviceModal.UpdateCommand
        Dim modTR As New CISModel.TechReportModel
        modTR.AddTechRepAffectedDevices(CType(Me.txtTRID.Text, Long), CType(e.Item.Cells(1).Text, Long))
        modTR = Nothing

        PopulateClientDevicesNotAddedinTR()
        PopulateAffectedDevicesGrid(CType(Me.txtTRID.Text, Long))
        Me.mpeAffectedDeviceModal.Hide()

    End Sub

    Private Sub PopulateAttachmentGrid(ByVal id As Long)
        Dim mdlTR As New CISModel.TechReportModel
        If id > 0 Then
            Dim dt As DataTable = mdlTR.GetTechReportAttachmentsList(id)

            dgFiles.DataSource = dt
            dgFiles.DataBind()
            Me.btnNewFile.Enabled = True
        Else
            dgFiles.DataSource = Nothing
            dgFiles.DataBind()
            Me.btnNewFile.Enabled = False

        End If


    End Sub

    Private Sub ClearModalFileAttachment()
        Me.txtFILEID.Text = "0"
        'Me.fileInput1.Value = Nothing
        Me.txtAttachmentRemarks.Text = Nothing

    End Sub

    Private Function InsertAttachmentRecord(ByVal FilePath As String, ByVal FTPFilePath As String) As Long
        Dim mdlTR As New CISModel.TechReportModel

        Dim entFile As New CISEntity.FileAttachEntity
        With entFile
            .FilePath = FTPFilePath
            .Remarks = txtAttachmentRemarks.Text
            .ParentID = CType(Me.txtTRID.Text, Long)
            .AttachmentType = "TR"
            .IsActiveFlag = True
            .PurgeFlag = False
        End With

        Return mdlTR.UploadSaveNewAttachment(entFile, GetUserProfile.ProfileID)
    End Function


    Private Sub btnUploadSaveAttachment_Click(sender As Object, e As EventArgs) Handles btnUploadSaveAttachment.Click
        Dim objWebUtility As New CISData.WebUtility
        If Not IsNothing(Me.fileInput1.PostedFile) AndAlso fileInput1.PostedFile.ContentLength > 0 Then
            If Me.fileInput1.PostedFile.ContentLength < objWebUtility.GetUploadFileLimit Then

                Dim Fn As String = System.IO.Path.GetFileName(Me.fileInput1.PostedFile.FileName)
                Dim strFileName As String = "TR-" + Now.ToString("yyyyMMddhhmmss") + "-" + Fn
                Dim strFilePath As String = objWebUtility.GetFTPLocalPath + strFileName
                Dim strFTPFilePath As String = objWebUtility.GetFTPPathRoot + strFileName
                Dim lngFileID As Long = InsertAttachmentRecord(strFilePath, strFTPFilePath)

                Dim SaveLoc As String = strFilePath
                fileInput1.PostedFile.SaveAs(SaveLoc)

                Dim strErr1 As String = "SaveAs Complete"
                Dim objAlert1 As New DynamicClientScript
                objAlert1.ShowMessage(Me.Page, strErr1)
                objAlert1 = Nothing

                PopulateAttachmentGrid(CType(Me.txtTRID.Text, Long))
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

    Private Sub dgFiles_DeleteCommand(source As Object, e As DataGridCommandEventArgs) Handles dgFiles.DeleteCommand
        Dim modFiles As New CISModel.ClientModel
        modFiles.FilePurge(CType(e.Item.Cells(1).Text, Long), GetUserProfile.ProfileID)

        Dim strErr As String = "File Attachment  Deleted!"
        Dim objAlert As New DynamicClientScript
        objAlert.ShowMessage(Me.Page, strErr)
        objAlert = Nothing

        PopulateAttachmentGrid(CType(Me.txtTRID.Text, Long))
        modFiles = Nothing
    End Sub

    Private Sub dgFiles_ItemDataBound(sender As Object, e As DataGridItemEventArgs) Handles dgFiles.ItemDataBound
        If e.Item.Cells.Count > 0 AndAlso e.Item.Cells(4).Controls.Count > 0 Then
            CType(e.Item.Cells(4).Controls(0), LinkButton).OnClientClick = "return confirm('Are you certain you want to delete?');"
        End If
    End Sub

    Private Sub dgFiles_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dgFiles.UpdateCommand
        Dim strDownload As String = CType(e.Item.Cells(2).Text, String)
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "');</script>")
    End Sub

    Private Sub btnPrintTR_Click(sender As Object, e As EventArgs) Handles btnPrintTR.Click
        Dim modWeb As New CISModel.WebModel
        Dim strDownload As String = modWeb.GetWebAppURL() + "CISReportViewer/?RptType=TRSingle&id=" + Me.txtTRID.Text
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "');</script>")
    End Sub
End Class