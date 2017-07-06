
Imports CISEntity
Imports CISModel
Imports CISData
Imports System.Data.SqlClient
Public Class _default5
    Inherits System.Web.UI.Page

    Private currentDeviceID As Long

    Private Sub populateDeviceClientInfo(ByVal DeviceID As Long)
        Dim modDevice As New CISModel.DeviceModel
        Dim entDeviceClient As New CISEntity.ClientEntity

        Me.dgClientServices.DataSource = modDevice.GetDeviceClientInfo(DeviceID)
        Me.dgClientServices.DataBind()
    End Sub

    Private Sub PopulateDeviceTechReportGrid(ByVal devID As Long)
        Dim mdlDevice As New CISModel.DeviceModel
        Me.dgTechReportHistory.DataSource = mdlDevice.GetDeviceTechReportList(devID)
        Me.dgTechReportHistory.DataBind()
        mdlDevice = Nothing
    End Sub

    Private Sub PopulateDeviceNoteGrid(ByVal DeviceID As Long)
        Dim modDevice As New CISModel.DeviceModel
        Dim dt As DataTable = modDevice.GetDeviceNoteList(DeviceID)
        dgNotes.DataSource = dt
        dgNotes.DataBind()

        If DeviceID > 0 Then
            Me.btnNewNote.Enabled = True
        Else
            Me.btnNewNote.Enabled = False
        End If

    End Sub

    Private Sub PopulateDeviceInfo(ByVal DeviceID As Long)
        Dim entDevice As New CISEntity.DeviceEntity
        Dim modDevice As New CISModel.DeviceModel

        entDevice = modDevice.GetDevice(DeviceID)

        If Not IsNothing(entDevice) AndAlso DeviceID > 0 Then

            Me.txtDEVID.Text = entDevice.DeviceID.ToString
            Me.txtITEMCODE.Text = entDevice.ItemCode
            Me.txtDeviceName.Text = entDevice.DeviceName
            Me.txtDEVICETYPE.Text = entDevice.DeviceType
            Me.txtSERIALNUMBER.Text = entDevice.SerialNumber
            Me.txtDEVICESPECS.Text = entDevice.DeviceSpecifications
            Me.ddStatus.SelectedValue = entDevice.Status
            Me.txtMANUFACTUREDATE.Text = entDevice.ManufactureDate.ToString
            Me.txtRECEIVEDATE.Text = entDevice.ReceiveDate.ToString
            Me.chkIsAvailable.Checked = entDevice.IsAvailable
            Me.chkIsActive.Checked = entDevice.IsActiveFlag
            Me.chkPurge.Checked = entDevice.PurgeFlag

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
            Me.txtREMARKS.Text = entDevice.Remarks

            Me.lblCreatedBy.Text = "Created By:" + modDevice.GetProfileName(entDevice.CreatedBy)
            Me.lblCreatedDt.Text = "Create Date:" + entDevice.CreateDate.ToString
            Me.lblUpdatedBy.Text = "Last Updated by:" + modDevice.GetProfileName(entDevice.UpdatedBy)
            Me.lblUpdateDt.Text = "Last Updated:" + entDevice.UpdateDate.ToString

            populateDeviceClientInfo(DeviceID)
            PopulateDeviceNoteGrid(DeviceID)
            PopulateDeviceTechReportGrid(DeviceID)
        ElseIf IsNothing(entDevice) AndAlso DeviceID = 0 Then
            Me.txtDEVID.Text = "0"
            Me.txtITEMCODE.Text = ""
            Me.txtDeviceName.Text = "New Device"
            Me.txtDEVICETYPE.Text = ""
            Me.txtSERIALNUMBER.Text = ""
            Me.txtDEVICESPECS.Text = ""
            Me.txtMANUFACTUREDATE.Text = Now.ToString
            Me.ddStatus.SelectedValue = ""
            Me.txtRECEIVEDATE.Text = Now.ToString
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
            Me.txtREMARKS.Text = ""

            Me.lblCreatedBy.Text = "Created By:"
            Me.lblCreatedDt.Text = "Create Date:"
            Me.lblUpdatedBy.Text = "Last Updated by:"
            Me.lblUpdateDt.Text = "Last Updated:"

            Me.chkIsActive.Checked = True
            Me.chkPurge.Checked = False

            populateDeviceClientInfo(DeviceID)
            PopulateDeviceNoteGrid(DeviceID)
            PopulateDeviceTechReportGrid(DeviceID)
        Else
            Dim objAlert As New DynamicClientScript
            objAlert.ShowMessage(Me.Page, "The Device Information Does not exist!")
            objAlert = Nothing

        End If


    End Sub

    Private Function SetFormDeviceEntity() As CISEntity.DeviceEntity
        Dim entDevice As New CISEntity.DeviceEntity

        With entDevice
            entDevice.DeviceID = CType(Me.txtDEVID.Text, Long)
            entDevice.ItemCode = Me.txtITEMCODE.Text
            entDevice.DeviceName = Me.txtDeviceName.Text
            entDevice.DeviceType = Me.txtDEVICETYPE.Text
            entDevice.SerialNumber = Me.txtSERIALNUMBER.Text
            entDevice.DeviceSpecifications = Me.txtDEVICESPECS.Text
            entDevice.Status = Me.ddStatus.SelectedValue
            If IsDate(Me.txtMANUFACTUREDATE.Text) Then
                entDevice.ManufactureDate = CType(Me.txtMANUFACTUREDATE.Text, DateTime)
            Else
                entDevice.ManufactureDate = Date.Parse(Me.txtMANUFACTUREDATE.Text, System.Globalization.CultureInfo.GetCultureInfo("us-au").DateTimeFormat) 'CType(Me.txtMANUFACTUREDATE.Text, Date)
            End If

            If IsDate(Me.txtRECEIVEDATE.Text) Then
                entDevice.ReceiveDate = CType(Me.txtRECEIVEDATE.Text, DateTime)
            Else
                entDevice.ReceiveDate = Date.Parse(Me.txtRECEIVEDATE.Text, System.Globalization.CultureInfo.GetCultureInfo("us-au").DateTimeFormat)
            End If

            'CType(Me.txtRECEIVEDATE.Text, Date)
            entDevice.IsAvailable = Me.chkIsAvailable.Checked
            entDevice.IPAddress = Me.txtIPADDRESS.Text
            entDevice.BrandType = Me.txtBRANDTYPE.Text
            entDevice.Model = Me.txtModel.Text
            entDevice.HostName = Me.txtHOSTNAME.Text
            entDevice.UserName = Me.txtUSERNAME.Text
            entDevice.Password = Me.txtPASSWORD.Text
            entDevice.MACAddress = Me.txtMAC.Text
            entDevice.FirmwareVersion = Me.txtFIRMWAREVERSION.Text
            entDevice.DefaultIPAddress = Me.txtDEFAULTIPADDRESS.Text
            entDevice.Stream1Resolution = Me.txtSTREAM1RESOLUTION.Text
            entDevice.Stream1FPS = Me.txtSTREAM1FPS.Text
            entDevice.Remarks = Me.txtREMARKS.Text
            .IsActiveFlag = chkIsActive.Checked
            .PurgeFlag = chkPurge.Checked
        End With

        Return entDevice
    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        currentDeviceID = CType(Request.QueryString("ID"), Long)

        If Not Page.IsPostBack Then
            PopulateStatus()

            PopulateDeviceInfo(currentDeviceID)
        End If
    End Sub

    Private Sub PopulateStatus()
        Dim cModel As New CISModel.MasterModel
        ddStatus.DataSource = cModel.GetDeviceStatusList
        ddStatus.DataTextField = "STATUS"
        ddStatus.DataValueField = "STATUS"
        ddStatus.DataBind()
    End Sub



    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Me.txtItemCodeSearch.Text = ""
        Me.txtSNSearch.Text = ""
        Me.txtNameSearch.Text = ""
        Me.chkInstalledatclient.Checked = False
        Me.dgResults.DataSource = Nothing
        Me.dgResults.DataBind()

        Me.txtSNSearch.Focus()

    End Sub

    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Response.Redirect("~/Device/?ID=0")
    End Sub

    Protected Sub btnSearchSN_Click(sender As Object, e As EventArgs) Handles btnSearchSN.Click
        Dim modDevice As New CISModel.DeviceModel
        dgResults.DataSource = modDevice.GetDeviceListBySN(Me.txtSNSearch.Text, True, Me.chkInstalledatclient.Checked)
        dgResults.DataBind()
    End Sub

    Private Sub btnItemCodeSearch_Click(sender As Object, e As EventArgs) Handles btnItemCodeSearch.Click
        Dim modDevice As New CISModel.DeviceModel
        dgResults.DataSource = modDevice.GetDeviceListByItemCode(Me.txtItemCodeSearch.Text, True, Me.chkInstalledatclient.Checked)
        dgResults.DataBind()
    End Sub

    Private Sub btnNameSearch_Click(sender As Object, e As EventArgs) Handles btnNameSearch.Click
        Dim modDevice As New CISModel.DeviceModel
        dgResults.DataSource = modDevice.GetDeviceListByName(Me.txtNameSearch.Text, True, Me.chkInstalledatclient.Checked)
        dgResults.DataBind()
    End Sub

    Private Sub dgResults_UpdateCommand(source As Object, e As DataGridCommandEventArgs) Handles dgResults.UpdateCommand
        Dim devID As Long = CType(e.Item.Cells(1).Text, Long)
        PopulateDeviceInfo(devID)
    End Sub
    Private Function GetUserProfile() As CISEntity.ProfileEntity
        Return Session("usrProfileEntity")
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim entDevice As CISEntity.DeviceEntity = SetFormDeviceEntity()
        Dim modDevice As New CISModel.DeviceModel

        modDevice.Save(entDevice, GetUserProfile.ProfileID)

        'ALERT FOR SUCCESSFUL SAVE
        Dim strAlert As String = "Device Information Saved"

        Dim objAlert As New DynamicClientScript
        objAlert.ShowMessage(Me.Page, strAlert)

        objAlert = Nothing
        modDevice = Nothing
        entDevice = Nothing
    End Sub

#Region "Note"
    Private Sub ClearModalNote()
        Me.txtNoteID.Text = "0"
        Me.txtNoteDate.Text = Nothing
        Me.txtNoteText.Text = Nothing
    End Sub

    Private Sub btnSaveNote_Click(sender As Object, e As EventArgs) Handles btnSaveNote.Click
        Dim mdlDevice As New CISModel.DeviceModel
        Dim entNote As New CISEntity.NotesEntity
        With entNote
            If Not IsNumeric(Me.txtNoteID.Text) Then
                Me.txtNoteID.Text = 0
            End If
            .NoteID = CType(Me.txtNoteID.Text, Long)
            .ParentType = "DEV"
            .ParentID = CType(Me.txtDEVID.Text, Long)
            .NoteDate = Now()
            .NoteText = Me.txtNoteText.Text
            .IsActiveFlag = True
            .PurgeFlag = False
        End With
        mdlDevice.SaveNote(entNote, GetUserProfile.ProfileID)
        'PopulateNoteGrid(CType(Me.txtCLIENTID.Text, Long))
        PopulateDeviceNoteGrid(CType(Me.txtDEVID.Text, Long))
        Me.txtNoteID.Text = entNote.NoteID.ToString
        Me.txtNoteDate.Text = entNote.NoteDate.ToShortDateString

        Dim strErr As String = "Note Successfully Saved!"
        Dim objAlert As New DynamicClientScript
        objAlert.ShowMessage(Me.Page, strErr)
        objAlert = Nothing
        mdlDevice = Nothing
    End Sub

    Private Sub btnDeleteNote_Click(sender As Object, e As EventArgs) Handles btnDeleteNote.Click

        'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "return confirm('Are You sure');", True)

        Dim mdlDevice As New CISModel.DeviceModel
        mdlDevice.DeleteNote(CType(Me.txtNoteID.Text, Long), GetUserProfile.ProfileID)

        PopulateDeviceNoteGrid(CType(Me.txtDEVID.Text, Long))

        ClearModalNote()

        Me.mpeNotes.Hide()

        Dim strErr As String = "Note Successfully Deleted!"
        Dim objAlert As New DynamicClientScript
        objAlert.ShowMessage(Me.Page, strErr)
        objAlert = Nothing
    End Sub

    Private Sub btnClearNote_Click(sender As Object, e As EventArgs) Handles btnClearNote.Click
        ClearModalNote()
        mpeNotes.Show()
        Me.txtNoteText.Focus()
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



#End Region

End Class