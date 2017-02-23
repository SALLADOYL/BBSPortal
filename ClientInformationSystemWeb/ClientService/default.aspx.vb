Imports CISEntity
Imports CISModel
Imports CISData
Imports System.Data.SqlClient
Public Class _default7
    Inherits System.Web.UI.Page
    Private currentID As Long
    Private lngClientID As Long
    Private lstCSDeviceInsert As List(Of CISEntity.ClientServiceDeviceEntity)
    Private lstCSDeviceRemove As List(Of CISEntity.ClientServiceDeviceEntity)
    Private entCurDeviceSave As CISEntity.DeviceEntity

    Private Sub PopulateClientInfoSection(ByVal ClientID As Long)
        Dim modClient As New CISModel.ClientModel
        Dim entClient As New CISEntity.ClientEntity

        entClient = modClient.GetClient(ClientID)
        If Not IsNothing(entClient) Then
            With entClient
                Me.txtClientID.Text = .ClientID
                Me.txtClientCode.Text = .ClientCode
                Me.txtClientName.Text = .Name
                Me.txtAddress.Text = .Address
                Me.txtRemarks.Text = .Remarks
            End With
        Else
            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, "The Client-Service Information does not exist!")
            objAlert = Nothing
        End If

        entClient = Nothing
        modClient = Nothing

    End Sub

    Private Sub PopulateServiceInfoSection(ByVal CLSvcID As Long)
        Dim entService As New CISEntity.ServiceEntity
        Dim entCLSvc As New CISEntity.ClientServiceEntity
        Dim modClient As New CISModel.ClientModel

        entCLSvc = modClient.GetClientServiceByClSvcID(CLSvcID)
        entService = modClient.GetServiceInfoByClSvcID(CLSvcID)
        Me.txtClSvcID.Text = CLSvcID.ToString
        If Not IsNothing(entService) AndAlso Not IsNothing(entCLSvc) Then
            With entService
                lngClientID = entCLSvc.ClientID
                Me.txtServiceID.Text = CLSvcID.ToString
                Me.txtServiceName.Text = .ServiceName
                Me.txtDescription.Text = .ServiceDescription
                Me.chkIsActiveFlg.Checked = .IsActiveFlag
                PopulateInstalledDevices(CLSvcID)
                PopulateServiceJobs(CLSvcID)
                PopulateTechReports(CLSvcID)
            End With
        Else
            PopulateInstalledDevices(0)
            PopulateServiceJobs(0)
            PopulateTechReports(0)
        End If
        entCLSvc = Nothing
        entService = Nothing
        modClient = Nothing

    End Sub

    Private Function GetUserProfile() As CISEntity.ProfileEntity
        Return Session("usrProfileEntity")
    End Function

    Private Sub PopulateServiceJobs(ByVal ClSvcId As Long)
        Dim modClient As New CISModel.ClientModel
        Me.dgWork.DataSource = modClient.GetClientServiceJobs(ClSvcId)
        Me.dgWork.DataBind()
        modClient = Nothing
        lblWorkSectionCollapse.InnerText = "Service Jobs" & "-(" & Me.dgWork.Items.Count.ToString & ")"
        'lblDeviceSectionCollapse.InnerText & "-(" & Me.dgClSvcDevices.Items.Count.ToString & ")"
    End Sub

    Private Sub PopulateInstalledDevices(ByVal ClSvcID As Long)
        Dim modDevice As New CISModel.DeviceModel
        Me.dgClSvcDevices.DataSource = modDevice.GetInstalledDevicesAtClientService(ClSvcID)
        Me.dgClSvcDevices.DataBind()
        modDevice = Nothing

        lblDeviceSectionCollapse.InnerText = "Installed Devices" & "-(" & Me.dgClSvcDevices.Items.Count.ToString & ")"
    End Sub

    Private Sub PopulateTechReports(ByVal ClSvcID As Long)
        Dim modClient As New CISModel.ClientModel
        Me.dgTechReports.DataSource = modClient.GetClientServiceTechReports(ClSvcID)
        Me.dgTechReports.DataBind()

        lblTRSectionCollapse.InnerText = "Technical Reports List" & "-(" & Me.dgTechReports.Items.Count.ToString & ")"
    End Sub

    Private Sub _default7_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            If Not IsNothing(Request.QueryString("ID")) AndAlso IsNumeric(Request.QueryString("ID")) Then
                currentID = CType(Request.QueryString("ID"), Long)
            End If

            If IsNumeric(currentID) AndAlso currentID > 0 Then
                PopulateServiceInfoSection(currentID)
                PopulateClientInfoSection(lngClientID)
            Else

            End If
        End If


    End Sub

    Private Sub btnReturnClient_Click(sender As Object, e As EventArgs) Handles btnReturnClient.Click
        Response.Redirect("~/Client/?ID=" & Me.txtClientID.Text)
    End Sub

    Private Sub btnSearchSN_Click(sender As Object, e As EventArgs) Handles btnSearchSN.Click
        Dim modDevice As New CISModel.DeviceModel
        dgResults.DataSource = modDevice.GetDeviceListBySN(Me.txtSNSearch.Text, True, False)
        dgResults.DataBind()
        mpDevice.Show()
    End Sub

    Private Sub btnItemCodeSearch_Click(sender As Object, e As EventArgs) Handles btnItemCodeSearch.Click
        Dim modDevice As New CISModel.DeviceModel
        dgResults.DataSource = modDevice.GetDeviceListByItemCode(Me.txtItemCodeSearch.Text, True, False)
        dgResults.DataBind()
        mpDevice.Show()
    End Sub

    Private Sub btnNameSearch_Click(sender As Object, e As EventArgs) Handles btnNameSearch.Click
        Dim modDevice As New CISModel.DeviceModel
        dgResults.DataSource = modDevice.GetDeviceListByName(Me.txtNameSearch.Text, True, False)
        dgResults.DataBind()
        mpDevice.Show()
    End Sub

    Private Sub dgResults_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dgResults.UpdateCommand
        Dim devID As Long = CType(e.Item.Cells(1).Text, Long)
        PopulateDeviceInfo(devID)
        mpDevice.Show()
    End Sub

    Private Sub PopulateDeviceInfo(ByVal DeviceID As Long)
        Dim entDevice As New CISEntity.DeviceEntity
        Dim modDevice As New CISModel.DeviceModel

        entDevice = modDevice.GetDevice(DeviceID)
        entCurDeviceSave = entDevice

        If Not IsNothing(entDevice) AndAlso DeviceID > 0 Then

            entCurDeviceSave = entDevice
            Me.txtCLSSVCDEVID.Text = 0
            Me.txtDEVID.Text = entDevice.DeviceID.ToString
            Me.txtITEMCODE.Text = entDevice.ItemCode
            Me.txtDeviceName.Text = entDevice.DeviceName
            Me.txtDEVICETYPE.Text = entDevice.DeviceType
            Me.txtSERIALNUMBER.Text = entDevice.SerialNumber

            Me.ddStatus.Text = entDevice.Status

            Me.chkIsAvailable.Checked = entDevice.IsAvailable
            Me.txtIPADDRESS.Text = entDevice.IPAddress
            Me.txtBRANDTYPE.Text = entDevice.BrandType
            Me.txtModel.Text = entDevice.Model
            Me.txtHOSTNAME.Text = entDevice.HostName
            Me.txtUSERNAME.Text = entDevice.UserName
            Me.txtPASSWORD.Text = entDevice.Password
            Me.txtMAC.Text = entDevice.MACAddress
            Me.txtFIRMWAREVERSION.Text = entDevice.FirmwareVersion
            Me.txtDEFAULTIPADDRESS.Text = entDevice.DefaultIPAddress
            Me.txtSTREAM1RESOLUTION.Text = entDevice.Stream1Resolution
            Me.txtSTREAM1FPS.Text = entDevice.Stream1FPS
            'Me.txtRemarks.Text = entDevice.Remarks

        ElseIf IsNothing(entDevice) AndAlso DeviceID = 0 Then
            entDevice = Nothing
            Me.txtCLSSVCDEVID.Text = 0
            Me.txtDEVID.Text = "0"
            Me.txtITEMCODE.Text = ""
            Me.txtDeviceName.Text = "New Device"
            Me.txtDEVICETYPE.Text = ""
            Me.txtSERIALNUMBER.Text = ""

            Me.chkIsAvailable.Checked = True
            Me.txtIPADDRESS.Text = ""
            Me.txtBRANDTYPE.Text = ""
            Me.txtModel.Text = ""
            Me.txtHOSTNAME.Text = ""
            Me.txtUSERNAME.Text = ""
            Me.txtPASSWORD.Text = ""
            Me.txtMAC.Text = ""
            Me.txtFIRMWAREVERSION.Text = ""
            Me.txtDEFAULTIPADDRESS.Text = ""
            Me.txtSTREAM1RESOLUTION.Text = ""
            Me.txtSTREAM1FPS.Text = ""

        End If


    End Sub

    Private Function GetPageClientServiceEntity() As CISEntity.ClientServiceEntity
        Dim oCSE As New ClientServiceEntity

        With oCSE
            .ClientServiceID = CType(txtClSvcID.Text, Long)
            .ClientID = CType(txtClientID.Text, Long)
            .ServiceID = CType(txtServiceID.Text, Long)
            .IsActiveFlag = chkIsActiveFlg.Checked
            Return oCSE
        End With

        Return Nothing
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'SAVE CLIENT-SERVICE
        Dim oCM As New CISModel.ClientModel
        Dim oCSE As New CISEntity.ClientServiceEntity
        oCSE = GetPageClientServiceEntity()
        oCM.SaveClientService(oCSE, GetUserProfile.ProfileID)

        '1. DEVICE SAVE
        '1.1 INSERT NEW DEVICES
        'oCM.InsertClientServiceDevice(GetUserProfile.ProfileID, lstCSDeviceInsert)
        '1.2 PURGE REMOVED DEVICES
        'oCM.PurgeClientServiceDevice(GetUserProfile.ProfileID, lstCSDeviceRemove)

        'ALERT FOR SUCCESSFUL SAVE
        Dim strAlert As String = "Client-Service Information Saved"

        Dim objAlert As New DynamicClientScript
        objAlert.ShowMessage(Me.Page, strAlert)

        oCM = Nothing

        lstCSDeviceInsert = Nothing
        lstCSDeviceRemove = Nothing

    End Sub

    Private Function GetClSvcDevicetoSave() As CISEntity.ClientServiceDeviceEntity
        Dim ClSvcDevicetoSave As New ClientServiceDeviceEntity
        With ClSvcDevicetoSave
            .ClientServiceDeviceID = CType(Me.txtCLSSVCDEVID.Text, Long)
            .ClientServiceID = CType(Me.txtClSvcID.Text, Long)
            .DeviceID = CType(Me.txtDEVID.Text, Long)
            Me.ddStatus.Text = "INSTALLED"
            .Status = Me.ddStatus.Text
            .Remarks = Me.txtRemarks.Text
            .IsActiveFlag = True
            .PurgeFlag = False
        End With

        Return ClSvcDevicetoSave
    End Function

    Private Sub btnSelectDevice_Click(sender As Object, e As EventArgs) Handles btnSelectDevice.Click
        'VERIFY CL-SVC-DEVICE IS NOT EXIST
        Dim modDevice As New CISModel.DeviceModel
        Dim lngtxtClSvcID As Long = 0

        If IsNumeric(Me.txtClSvcID.Text) Then
            lngtxtClSvcID = CType(Me.txtClSvcID.Text, Long)
        Else
            Me.txtClSvcID.Text = "0"
        End If

        Dim verifyDeviceAvailable As Boolean = modDevice.VerifyDeviceAndClientServiceAvailable(CType(Me.txtDEVID.Text, Long), lngtxtClSvcID)

        If verifyDeviceAvailable Then
            'add entry to cl-svc-device table
            modDevice.SaveClientServiceDevice(GetClSvcDevicetoSave, GetUserProfile.ProfileID)

            'set deviceTBL status to working; is available = false
            entCurDeviceSave = modDevice.GetDevice(CType(Me.txtDEVID.Text, Long))
            entCurDeviceSave.Status = "INSTALLED"
            entCurDeviceSave.IsAvailable = False
            modDevice.Save(entCurDeviceSave, GetUserProfile.ProfileID)

            'REPOPULATE DEVICE GRID
            PopulateDeviceInfo(lngtxtClSvcID)
            PopulateInstalledDevices(lngtxtClSvcID)

            'ALERT FOR SUCCESSFUL SAVE
            Dim strAlert As String = "Device Successfully Added."
            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, strAlert)
        Else
            'alert device not ready
            Dim strAlert As String = "Device is not available."
            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, strAlert)
        End If
        modDevice = Nothing
    End Sub

    Private Sub DefautDeviceResults()
        PopulateDeviceInfo(0)

        Dim modDevice As New CISModel.DeviceModel
        dgResults.DataSource = modDevice.GetDeviceListBySN("0", False, True)
        dgResults.DataBind()
        mpDevice.Show()
        modDevice = Nothing
    End Sub

    Private Sub btnClearDeviceResults_Click(sender As Object, e As EventArgs) Handles btnClearDeviceResults.Click
        DefautDeviceResults()
    End Sub

    Private Sub dgClSvcDevices_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dgClSvcDevices.UpdateCommand
        Dim modWeb As New CISModel.WebModel

        Dim strDownload As String = modWeb.GetWebAppURL() + "Device/?id=" + e.Item.Cells(2).Text
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "', 'Device Update Window', 'width=1100,height=600,left=25,top=50,resizable=yes,scrollbars=yes');</script>")
        'Response.Write("<script type='text/javascript'>window.showModalDialog('" + strDownload + "', 'Device Update Window', 'dialogWidth:1100px;dialogHeight:600px;left:25;top:50;resizable:yes;scrollbars:yes;');</script>")
        modWeb = Nothing
    End Sub

    Private Sub btnUnAssignedDevice_Click(sender As Object, e As EventArgs) Handles btnUnAssignedDevice.Click
        Dim modWeb As New CISModel.WebModel

        Dim strDownload As String = modWeb.GetWebAppURL() + "Device/?id=0"
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "', 'New Device Window', 'width=1100,height=600,left=25,top=50,resizable=yes,scrollbars=yes');</script>")
        'Response.Write("<script type='text/javascript'>window.showModalDialog('" + strDownload + "', 'New Device Window', 'dialogWidth:1100px;dialogHeight:600px;left:25;top:50;resizable:yes;scrollbars:yes;');</script>")
        modWeb = Nothing
    End Sub

    Private Sub btnNewJob_Click(sender As Object, e As EventArgs) Handles btnNewJob.Click
        Dim modWeb As New CISModel.WebModel

        Dim strDownload As String = modWeb.GetWebAppURL() + "ServiceJob/?id=0&csid=" + Me.txtClSvcID.Text
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "', 'New Job Window', 'width=1100,height=600,left=25,top=50,resizable=yes,scrollbars=yes');</script>")
        modWeb = Nothing
    End Sub

    Private Sub btnNewTechReport_Click(sender As Object, e As EventArgs) Handles btnNewTechReport.Click
        Dim modWeb As New CISModel.WebModel

        Dim strDownload As String = modWeb.GetWebAppURL() + "TechReport/?id=0&csid=" + Me.txtClSvcID.Text
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "', 'New Tech Report Window', 'width=1100,height=600,left=25,top=50,resizable=yes,scrollbars=yes');</script>")
        modWeb = Nothing
    End Sub



    Private Sub dgWork_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dgWork.UpdateCommand
        Dim modWeb As New CISModel.WebModel

        Dim strDownload As String = modWeb.GetWebAppURL() + "ServiceJob/?id=" + e.Item.Cells(1).Text
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "', 'Update Service-Job Window', 'width=1100,height=600,left=25,top=50,resizable=yes,scrollbars=yes');</script>")
        'Response.Write("<script type='text/javascript'>window.showModalDialog('" + strDownload + "', 'Update Service-Job Window', 'dialogWidth:1100px;dialogHeight:600px;left:25;top:50;resizable:yes;scrollbars:yes;');</script>")
        modWeb = Nothing
    End Sub


    Private Sub dgTechReports_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dgTechReports.UpdateCommand
        Dim modWeb As New CISModel.WebModel

        Dim strDownload As String = modWeb.GetWebAppURL() + "TechReport/?id=" + e.Item.Cells(1).Text
        Response.Write("<script type='text/javascript'>window.open('" + strDownload + "', 'Update Technical-Report Window', 'width=1100,height=600,left=25,top=50,resizable=yes,scrollbars=yes');</script>")
        'Response.Write("<script type='text/javascript'>window.showModalDialog('" + strDownload + "', 'Update Technical-Report Window', 'dialogWidth:1100px;dialogHeight:600px;left:25;top:50;resizable:yes;scrollbars:yes;');</script>")
        modWeb = Nothing
    End Sub



    Private Sub dgClSvcDevices_DeleteCommand(source As Object, e As DataGridCommandEventArgs) Handles dgClSvcDevices.DeleteCommand
        'VERIFY CL-SVC-DEVICE EXIST
        Dim modDevice As New CISModel.DeviceModel

        Dim lngtxtClSvcID As Long = 0

        If IsNumeric(Me.txtClSvcID.Text) Then
            lngtxtClSvcID = CType(Me.txtClSvcID.Text, Long)
        Else
            Me.txtClSvcID.Text = "0"
        End If

        Dim verifyDeviceAvailable As Boolean = modDevice.VerifyDeviceAndClientServiceAvailable(CType(e.Item.Cells(2).Text, Long), lngtxtClSvcID)

        If Not verifyDeviceAvailable Then
            'PURGE to cl-svc-device table
            Dim purgeClSvcDev As New CISEntity.ClientServiceDeviceEntity
            purgeClSvcDev.IsActiveFlag = False
            ' purgeClSvcDev.PurgeFlag = True
            'purgeClSvcDev.Status = "DECOMISSIONED"
            'modDevice.SaveClientServiceDevice(purgeClSvcDev, GetUserProfile.ProfileID)
            modDevice.PurgeClientServiceDevice(CType(e.Item.Cells(1).Text, Long), GetUserProfile.ProfileID)

            'set deviceTBL status to ON-STOCK; is available = true
            entCurDeviceSave = modDevice.GetDevice(CType(e.Item.Cells(2).Text, Long))
            If entCurDeviceSave.Status = "DEFECTIVE" Then
                'entCurDeviceSave.Status = "DEFECTIVE"
                entCurDeviceSave.IsAvailable = False
                entCurDeviceSave.IsActiveFlag = True
                entCurDeviceSave.PurgeFlag = False
            Else
                entCurDeviceSave.Status = "ON-STOCK"
                entCurDeviceSave.IsAvailable = True
                entCurDeviceSave.IsActiveFlag = True
                entCurDeviceSave.PurgeFlag = False
            End If

            modDevice.Save(entCurDeviceSave, GetUserProfile.ProfileID)

                'REPOPULATE DEVICE GRID
                PopulateDeviceInfo(lngtxtClSvcID)
                PopulateInstalledDevices(lngtxtClSvcID)

                'ALERT FOR SUCCESSFUL SAVE
                Dim strAlert As String = "Device Successfully Removed."
                Dim objAlert As New DynamicClientScript
                objAlert.ShowMessage(Me.Page, strAlert)
                'Else
                '    'alert device not ready
                '    Dim strAlert As String = "Device is not available."
                '    Dim objAlert As New DynamicClientScript
                '    objAlert.ShowMessage(Me.Page, strAlert)
            End If
            modDevice = Nothing
    End Sub

    Private Sub dgClSvcDevices_ItemDataBound(sender As Object, e As DataGridItemEventArgs) Handles dgClSvcDevices.ItemDataBound
        If e.Item.Cells.Count > 0 AndAlso e.Item.Cells(7).Controls.Count > 0 Then
            CType(e.Item.Cells(7).Controls(0), Button).OnClientClick = "return confirm('Proceed with Removal of this device?');"
        End If
    End Sub

    '    Protected Sub OpenWindow(sender As Object, url As String, e As EventArgs)

    '        'Dim url As String = "Popup.aspx"
    '        Dim s As String = "window.open('" & url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');"
    'ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)

    '    End Sub

End Class