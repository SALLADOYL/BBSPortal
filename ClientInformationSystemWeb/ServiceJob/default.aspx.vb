Public Class _default8
    Inherits System.Web.UI.Page

    Private Sub PopulateClientSection(ByVal ClSvcID As Long)
        Dim mdlSJ As New CISModel.ServiceJobModel

    End Sub

    Private Sub PopulateDDClientSearch()
        Dim mdlSJ As New CISModel.ServiceJobModel
        Dim clientList As New List(Of CISEntity.ClientEntity)
        Dim blankClientEntity As New CISEntity.ClientEntity
        blankClientEntity.ClientID = 0
        blankClientEntity.Name = ""

        clientList.Add(blankClientEntity)
        clientList.AddRange(mdlSJ.GetClientListForSearch)

        Me.ddClientNameSearch.DataSource = clientList
        Me.ddClientNameSearch.DataTextField = "Name"
        Me.ddClientNameSearch.DataValueField = "ClientID"
        Me.ddClientNameSearch.DataBind()

        Me.ddClientList.DataSource = clientList
        Me.ddClientList.DataTextField = "Name"
        Me.ddClientList.DataValueField = "ClientID"
        Me.ddClientList.DataBind()

        mdlSJ = Nothing
        clientList = Nothing
        blankClientEntity = Nothing



    End Sub

    Private Sub PopulateDDServiceSearch()
        Dim mdlSJ As New CISModel.ServiceJobModel
        'Me.ddServiceListSearch.DataSource = modTR.GetServiceListForSearch
        Dim statusList As New List(Of CISEntity.ServiceEntity)
        Dim blankServiceEntity As New CISEntity.ServiceEntity
        blankServiceEntity.ServiceID = 0
        blankServiceEntity.ServiceName = ""

        statusList.Add(blankServiceEntity)
        statusList.AddRange(mdlSJ.GetServiceListForSearch)

        Me.ddServiceListSearch.DataSource = statusList
        Me.ddServiceListSearch.DataTextField = "ServiceName"
        Me.ddServiceListSearch.DataValueField = "ServiceID"
        Me.ddServiceListSearch.DataBind()
    End Sub

    Private currentServiceJobID As Long
    Private Function GetUserProfile() As CISEntity.ProfileEntity
        Return Session("usrProfileEntity")
    End Function

    Private Sub PopulateDDCreatedBy()
        Dim mdlSJ As New CISModel.ServiceJobModel
        Me.ddJobCreatedBy.DataSource = mdlSJ.GetSJCreatorListProfileIDName
        Me.ddJobCreatedBy.DataTextField = "NAME"
        Me.ddJobCreatedBy.DataValueField = "PROFILEID"
        Me.ddJobCreatedBy.DataBind()
    End Sub

    Private Sub PopulateDDApproveBy()
        Dim mdlSJ As New CISModel.ServiceJobModel
        Me.ddApprovedBy.DataSource = mdlSJ.GetSJApproverListProfileIDName
        Me.ddApprovedBy.DataTextField = "NAME"
        Me.ddApprovedBy.DataValueField = "PROFILEID"
        Me.ddApprovedBy.DataBind()
    End Sub

    Private Sub PopulateDDStatus()
        Dim mdlSJ As New CISModel.ServiceJobModel
        Me.ddWorkStatus.DataSource = mdlSJ.GetServiceJobStatusList
        Me.ddWorkStatus.DataTextField = "STATUS"
        Me.ddWorkStatus.DataValueField = "STATUS"
        Me.ddWorkStatus.DataBind()
    End Sub


    Private Sub PopulateClientServiceInfoParent(ByVal SJID As Long)
        Dim mdlSJ As New CISModel.ServiceJobModel
        Dim dt As New DataTable

        dt = mdlSJ.GetClientServiceParent(SJID)
        'CLIENTID , CLIENTSVCID
        If dt.Rows.Count > 0 Then

            Dim modClient As New CISModel.ClientModel
            Dim entClient As CISEntity.ClientEntity = modClient.GetClient(CType(dt.Rows(0)("CLIENTID"), Long))
            Me.ddClientList.SelectedValue = entClient.ClientID
            Me.txtClientCode.Text = entClient.ClientCode
            Me.txtClientName.Text = entClient.Name
            Me.txtClientAddress.Text = entClient.Address

            Dim entCLService As New CISEntity.ClientServiceEntity
            Dim dataCLService As New CISData.ClientServiceData
            entCLService = dataCLService.GetClientService(CType(dt.Rows(0)("CLIENTSVCID"), Long))
            PopulateServiceList(entClient.ClientID)
            Me.ddServiceList.SelectedValue = entCLService.ServiceID
            Me.txtCLSSVCID.Text = entCLService.ClientServiceID

            modClient = Nothing
            entClient = Nothing
            entCLService = Nothing
            dataCLService = Nothing

        End If

        mdlSJ = Nothing
    End Sub

    Private Sub PopulateServiceJobInfo(ByVal ServiceJobID As Long)
        Dim entSvcJob As New CISEntity.TSWorkEntity
        Dim modSvcJob As New CISModel.ServiceJobModel

        entSvcJob = modSvcJob.GetServiceJob(ServiceJobID)

        If Not IsNothing(entSvcJob) AndAlso ServiceJobID > 0 Then
            With entSvcJob
                Me.txtTSWORKID.Text = .TSWorkID.ToString
                Me.txtServiceJobNo.Text = .ServiceJobNumber
                Me.txtQuotationNumber.Text = .QuotationNumber
                Me.txtPONumber.Text = .PONumber
                Me.txtQuoteDate.Text = .QuoteDate.ToString
                Me.extcal2.SelectedDate = .QuoteDate
                Me.txtDeliverTo.Text = .DeliverTo
                Me.ddJobCreatedBy.SelectedValue = .JobCreatedBy
                Me.ddWorkStatus.SelectedValue = .Status
                Me.txtSignedBy.Text = .ClientSignedBy
                Me.ddApprovedBy.SelectedValue = .JobApprovedBy
                Me.txtSJStartDate.Text = .StartDate.ToString
                Me.ceStartDate.SelectedDate = .StartDate
                Me.txtSJEndDate.Text = .EndDate.ToString
                Me.ceSJEndDate.SelectedDate = .EndDate
                Me.txtRemarks.Text = .Remarks

                Me.lblCreatedBy.Text = "Created By:" + modSvcJob.GetProfileName(.CreatedBy)
                Me.lblCreatedDt.Text = "Create Date:" + .CreateDate.ToString
                Me.lblUpdatedBy.Text = "Last Updated by:" + modSvcJob.GetProfileName(.UpdatedBy)
                Me.lblUpdateDt.Text = "Last Updated:" + .UpdateDate.ToString

                PopulateClientServiceInfoParent(.TSWorkID)
                'PopulateClientSection(.ClientServiceID)
                PopulateAttachmentGrid(.TSWorkID)
            End With
        ElseIf IsNothing(entSvcJob) AndAlso ServiceJobID = 0 Then
            Dim dtnow As DateTime = Now
            Me.txtTSWORKID.Text = 0
            Me.txtServiceJobNo.Text = ""
            Me.txtQuotationNumber.Text = ""
            Me.txtPONumber.Text = ""
            Me.txtQuoteDate.Text = dtnow.ToShortDateString
            Me.extcal2.SelectedDate = dtnow
            Me.txtDeliverTo.Text = ""
            Me.ddJobCreatedBy.SelectedValue = Nothing
            Me.ddWorkStatus.SelectedValue = Nothing
            Me.txtSignedBy.Text = ""
            Me.ddApprovedBy.SelectedValue = Nothing
            Me.txtSJStartDate.Text = dtnow.ToString
            Me.ceStartDate.SelectedDate = dtnow
            Me.txtSJEndDate.Text = dtnow.ToString
            Me.ceSJEndDate.SelectedDate = dtnow
            Me.txtRemarks.Text = ""
            Me.lblCreatedBy.Text = "Created By:"
            Me.lblCreatedDt.Text = "Create Date:"
            Me.lblUpdatedBy.Text = "Last Updated by:"
            Me.lblUpdateDt.Text = "Last Updated:"

            PopulateClientServiceInfoParent(0)
            PopulateAttachmentGrid(0)
            'PopulateClientSection(0)

        Else
            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, "The Service-Job Information does not exist!")
            objAlert = Nothing
        End If

        entSvcJob = Nothing
        modSvcJob = Nothing
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        currentServiceJobID = CType(Request.QueryString("ID"), Long)

        If Not Page.IsPostBack Then
            PopulateDDStatus()
            PopulateDDClientSearch()
            PopulateDDServiceSearch()
            PopulateDDCreatedBy()
            PopulateDDApproveBy()
            PopulateServiceJobInfo(currentServiceJobID)
        End If
    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Response.Redirect("~/ServiceJob/?ID=0")
    End Sub

    Private Function InsertAttachmentRecord(ByVal FilePath As String, ByVal FTPFilePath As String) As Long
        Dim mdlTR As New CISModel.TechReportModel

        Dim entFile As New CISEntity.FileAttachEntity
        With entFile
            .FilePath = FTPFilePath
            .Remarks = txtAttachmentRemarks.Text
            .ParentID = CType(Me.txtTSWORKID.Text, Long)
            .AttachmentType = "SJ"
            .IsActiveFlag = True
            .PurgeFlag = False
        End With

        Return mdlTR.UploadSaveNewAttachment(entFile, GetUserProfile.ProfileID)
    End Function

    Private Sub PopulateAttachmentGrid(ByVal SJID As Long)
        Dim mdlSJ As New CISModel.ServiceJobModel
        If SJID > 0 Then
            Dim dt As DataTable = mdlSJ.GetServiceJobAttachmentsList(SJID)

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

    Private Sub btnUploadSaveAttachment_Click(sender As Object, e As EventArgs) Handles btnUploadSaveAttachment.Click
        Dim objWebUtility As New CISData.WebUtility
        If Not IsNothing(Me.fileInput1.PostedFile) AndAlso fileInput1.PostedFile.ContentLength > 0 Then
            If Me.fileInput1.PostedFile.ContentLength < objWebUtility.GetUploadFileLimit Then

                Dim Fn As String = System.IO.Path.GetFileName(Me.fileInput1.PostedFile.FileName)
                Dim strFileName As String = "SJ-" + Now.ToString("yyyyMMddhhmmss") + "-" + Fn
                Dim strFilePath As String = objWebUtility.GetFTPLocalPath + strFileName
                Dim strFTPFilePath As String = objWebUtility.GetFTPPathRoot + strFileName
                Dim lngFileID As Long = InsertAttachmentRecord(strFilePath, strFTPFilePath)

                Dim SaveLoc As String = strFilePath
                fileInput1.PostedFile.SaveAs(SaveLoc)

                Dim strErr1 As String = "SaveAs Complete"
                Dim objAlert1 As New DynamicClientScript
                objAlert1.ShowMessage(Me.Page, strErr1)
                objAlert1 = Nothing

                PopulateAttachmentGrid(CType(Me.txtTSWORKID.Text, Long))
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

    Private Sub btnClientServiceSearch_Click(sender As Object, e As EventArgs) Handles btnClientServiceSearch.Click
        Dim mdlSJ As New CISModel.ServiceJobModel

        If ddClientNameSearch.SelectedValue = 0 OrElse ddServiceListSearch.SelectedValue = 0 Then
            Dim strErr As String = "Cannot Perform this search. Invalid Client-Service selection."

            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, strErr)
            objAlert = Nothing

        Else
            dgResults.DataSource = mdlSJ.SearchServiceJobbyClientService(CType(ddClientNameSearch.SelectedValue, Long), CType(ddServiceListSearch.SelectedValue, Long))
            dgResults.DataBind()
        End If

        mdlSJ = Nothing

    End Sub

    Protected Sub btnPONumberSearch_Click(sender As Object, e As EventArgs) Handles btnPONumberSearch.Click
        Dim mdlSJ As New CISModel.ServiceJobModel
        dgResults.DataSource = mdlSJ.SearchServiceJobbyPOnumber(Me.txtPONumberSearch.Text)
        dgResults.DataBind()
        mdlSJ = Nothing
    End Sub

    Protected Sub btnQuotationNumberSearch_Click(sender As Object, e As EventArgs) Handles btnQuotationNumberSearch.Click
        Dim mdlSJ As New CISModel.ServiceJobModel
        dgResults.DataSource = mdlSJ.SearchServiceJobbyQuotationNumber(Me.txtQuotationNumberSearch.Text)
        dgResults.DataBind()
        mdlSJ = Nothing
    End Sub

    Protected Sub btnQuoteDateSearch_Click(sender As Object, e As EventArgs) Handles btnQuoteDateSearch.Click


        If IsDate(Me.txtQuoteDateFrom.Text) AndAlso IsDate(Me.txtQouteDateTo.Text) Then
            Dim mdlSJ As New CISModel.ServiceJobModel
            dgResults.DataSource = mdlSJ.SearchServiceJobbyQuotationDates(CType(Me.txtQuoteDateFrom.Text, Date), CType(Me.txtQouteDateTo.Text, Date))
            dgResults.DataBind()
            mdlSJ = Nothing
        Else
            Dim strErr As String = "Cannot Perform this search. Invalid Start Date Range."

            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, strErr)
            objAlert = Nothing
        End If


    End Sub

    Protected Sub ddClientList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddClientList.SelectedIndexChanged
        If ddClientList.SelectedValue <> "" Then
            Dim entClient As New CISEntity.ClientEntity
            Dim modClient As New CISModel.ClientModel
            entClient = modClient.GetClient(ddClientList.SelectedValue)

            Me.txtClientCode.Text = entClient.ClientCode
            Me.txtClientName.Text = entClient.Name
            Me.txtClientAddress.Text = entClient.Address
            entClient = Nothing
            modClient = Nothing
        Else
            Me.txtCLSSVCID.Text = "0"
        End If

        'POPULATE SERVICELIST; CLEAR SERVICE INFO
        Me.ddServiceList.SelectedIndex = -1
        PopulateServiceList(CType(ddClientList.SelectedValue, Long))

    End Sub

    Private Sub PopulateServiceList(ByVal clientID As Long)
        Dim mdlSJ As New CISModel.ServiceJobModel
        Me.ddServiceList.SelectedIndex = -1
        Me.ddServiceList.DataSource = mdlSJ.GetServiceListWithBlank(clientID) 'CType(ddClientList.SelectedValue, Long))
        Me.ddServiceList.DataTextField = "ServiceName"
        Me.ddServiceList.DataValueField = "ServiceID"
        Me.ddServiceList.DataBind()
        mdlSJ = Nothing
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

    End Sub

    Private Sub dgResults_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dgResults.UpdateCommand
        Dim sjid As Long = CType(e.Item.Cells(1).Text, Long)
        PopulateServiceJobInfo(sjid)
        cpeSearch.Collapsed = True
        cpeSearch.ClientState = True

        cpeClientService.Collapsed = False
        cpeClientService.ClientState = False
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

    Private Sub dgFiles_DeleteCommand(source As Object, e As DataGridCommandEventArgs) Handles dgFiles.DeleteCommand
        Dim modFiles As New CISModel.ClientModel
        modFiles.FilePurge(CType(e.Item.Cells(1).Text, Long), GetUserProfile.ProfileID)

        Dim strErr As String = "File Attachment  Deleted!"
        Dim objAlert As New DynamicClientScript
        objAlert.ShowMessage(Me.Page, strErr)
        objAlert = Nothing

        PopulateAttachmentGrid(CType(Me.txtTSWORKID.Text, Long))
        modFiles = Nothing
    End Sub

    Private Function setFormSJEntity() As CISEntity.TSWorkEntity
        Dim entSJ As New CISEntity.TSWorkEntity
        With entSJ
            .TSWorkID = CType(Me.txtTSWORKID.Text, Long)
            .ClientServiceID = CType(Me.txtCLSSVCID.Text, Long)
            .ServiceJobNumber = Me.txtServiceJobNo.Text
            .PONumber = Me.txtPONumber.Text
            .QuotationNumber = Me.txtQuotationNumber.Text

            If IsDate(Me.txtQuoteDate.Text) Then
                .QuoteDate = CType(Me.txtQuoteDate.Text, DateTime)
            Else
                .QuoteDate = Date.Parse(Me.txtQuoteDate.Text, System.Globalization.CultureInfo.GetCultureInfo("us-au").DateTimeFormat)

            End If
            .DeliverTo = Me.txtDeliverTo.Text
            .JobCreatedBy = Me.ddJobCreatedBy.SelectedValue
            .Status = Me.ddWorkStatus.SelectedValue
            .ClientSignedBy = Me.txtSignedBy.Text
            .JobApprovedBy = Me.ddApprovedBy.SelectedValue

            If IsDate(Me.txtSJStartDate.Text) Then
                .StartDate = CType(Me.txtSJStartDate.Text, DateTime)
            Else
                .StartDate = Date.Parse(Me.txtSJStartDate.Text, System.Globalization.CultureInfo.GetCultureInfo("us-au").DateTimeFormat)

            End If

            If IsDate(Me.txtSJEndDate.Text) Then
                .EndDate = CType(Me.txtSJEndDate.Text, DateTime)
            Else
                .EndDate = Date.Parse(Me.txtSJEndDate.Text, System.Globalization.CultureInfo.GetCultureInfo("us-au").DateTimeFormat)

            End If
            .Remarks = txtRemarks.Text
            .IsActiveFlag = True
            .PurgeFlag = False

        End With

        Return entSJ
    End Function

    Private Function ValidateSJEntry(ByRef strRet As String) As Boolean
        strRet = ""

        If ddClientList.SelectedValue < 0 Then
            strRet &= "Select a valid Client /n"
        End If

        If ddServiceList.SelectedValue < 0 Then
            strRet &= "Select a valid Service /n"
        End If

        If txtServiceJobNo.Text.Length = 0 Then
            strRet &= "Please Input a valid Service-Job No. /n"
        End If

        Return IIf(strRet.Length > 0, False, True)
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim strAlert As String = ""
        Dim objAlert As New DynamicClientScript
        If ValidateSJEntry(strAlert) Then
            Dim entSJ As CISEntity.TSWorkEntity = setFormSJEntity()
            Dim mdlSJ As New CISModel.ServiceJobModel
            mdlSJ.Save(entSJ, GetUserProfile.ProfileID)

            'ALERT SAVE SUCCESS
            strAlert = "Technical Report Information Saved"
            objAlert.ShowMessage(Me.Page, strAlert)

            PopulateServiceJobInfo(entSJ.TSWorkID)
            mdlSJ = Nothing
            entSJ = Nothing
        Else
            'display validation alert
            objAlert.ShowMessage(Me.Page, strAlert)
        End If

        objAlert = Nothing

    End Sub

    Private Sub btnServiceJobNumberSearch_Click(sender As Object, e As EventArgs) Handles btnServiceJobNumberSearch.Click
        Dim mdlSJ As New CISModel.ServiceJobModel
        dgResults.DataSource = mdlSJ.SearchServiceJobbySJnumber(Me.txtServiceJobNumberSearch.Text)
        dgResults.DataBind()
        mdlSJ = Nothing
    End Sub

    Private Sub btnPrintSJ_Click(sender As Object, e As EventArgs) Handles btnPrintSJ.Click
        Dim modWeb As New CISModel.WebModel
        Dim strDownload As String = modWeb.GetWebAppURL() + "CISReportViewer/?RptType=SJSingle&id=" + Me.txtTSWORKID.Text
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "');</script>")
    End Sub

    'Private Sub btnDeleteSJ_Click(sender As Object, e As EventArgs) Handles btnDeleteSJ.Click
    '    Dim mdlSJ As New CISModel.ServiceJobModel
    '    mdlSJ.PurgeTSWork(CType(Me.txtTSWORKID.Text, Long), GetUserProfile.ProfileID)

    '    Dim strErr As String = "Service Job Deleted!"
    '    Dim objAlert As New DynamicClientScript
    '    objAlert.ShowMessage(Me.Page, strErr)
    '    objAlert = Nothing

    '    Response.Redirect("~/ServiceJob/?ID=0")
    'End Sub
End Class