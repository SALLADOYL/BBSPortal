Imports CISEntity
Imports CISData

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim oclient As New ClientEntity
        With oclient
            .ClientCode = "0000-0000" ' [CLIENTCODE]
            .Name = "Client Company 001" ',[NAME]
            .Address = "PObox 9999, LAE, MOROBE PROVINCE, PAPUA NEW GUINEA" ',[ADDRESS]
            .Industry = "SECURITY INDUSTRY" ',[INDUSTRY]
            .ContactNumber = "9152601325" ',[CONTACTNUMBER]
            .Fax = "95260312584" ',[FAX]
            .Website = "WWW.WATCH8X.COM" ',[WEBSITE]
            .EmailAddress = "ITSYSTEMSADMIN@BBSPNGGROUPS.COM" ',[EMAILADDRESS]
            .Remarks = "THIS IS A TEST DATA" ',[REMARKS]
            .IsActiveFlg = True ',[ISACTIVEFLG]
            .PurgeFlg = False ',[PURGEFLG]
            .CreateDate = Now() ',[CRTDT]
            .CreatedBy = -1 ',[CRTBY]
            .UpdateDate = Now ',[UPDDT]
            .UpdatedBy = -1 ',[UPDBY]
        End With

        Dim oclientdata As New ClientData
        If oclientdata.SaveNewClient(oclient, 0) Then
            MessageBox.Show("success")
        Else
            MessageBox.Show("failed")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim oclient As New ClientEntity
        With oclient
            .ClientID = 4
            .ClientCode = "9900-0000" ' [CLIENTCODE]
            .Name = "Client Company XX99" ',[NAME]
            .Address = "PObox 9999, LAE, MOROBE PROVINCE, PAPUA NEW GUINEA" ',[ADDRESS]
            .Industry = "SECURITY INDUSTRY" ',[INDUSTRY]
            .ContactNumber = "9152601325" ',[CONTACTNUMBER]
            .Fax = "95260312584" ',[FAX]
            .Website = "WWW.WATCH8X.COM" ',[WEBSITE]
            .EmailAddress = "ITSYSTEMSADMIN@BBSPNGGROUPS.COM" ',[EMAILADDRESS]
            .Remarks = "THIS IS A TEST DATA" ',[REMARKS]
            .IsActiveFlg = True ',[ISACTIVEFLG]
            .PurgeFlg = False ',[PURGEFLG]
            .CreateDate = Now() ',[CRTDT]
            .CreatedBy = -1 ',[CRTBY]
            .UpdateDate = Now ',[UPDDT]
            .UpdatedBy = -1 ',[UPDBY]
        End With

        Dim oclientdata As New ClientData
        If oclientdata.SaveClient(oclient, 0) Then
            MessageBox.Show("success")
        Else
            MessageBox.Show("failed")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim oclientdata As New ClientData
        If oclientdata.PurgeClient(4, 0) Then
            MessageBox.Show("success")
        Else
            MessageBox.Show("failed")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim oclientdata As New ClientData
        Dim objClientEntity As New CISEntity.ClientEntity

        objClientEntity = oclientdata.GetClient(4)

        MessageBox.Show(objClientEntity.ToString)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim oclientdata As New ClientData
        Dim objClientEntities As New List(Of CISEntity.ClientEntity)

        objClientEntities = oclientdata.GetClientList("contactnumber = '9152601325'")

        MessageBox.Show(objClientEntities.Count)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim oclientdata As New ClientData
        Dim objClientEntities As New List(Of CISEntity.ClientEntity)

        objClientEntities = oclientdata.GetClientListByName(TextBox1.Text, CheckBox1.Checked)

        If Not IsNothing(objClientEntities) Then
            MessageBox.Show(objClientEntities.Count)
        Else
            MessageBox.Show("no results")
        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim oclientService As New ClientServiceEntity
        With oclientService
            .ClientID = 4
            .ServiceID = 1
            .IsActiveFlag = 1
            .PurgeFlag = 0
        End With

        Dim oclientSrvicedata As New ClientServiceData
        If oclientSrvicedata.SaveNewClientService(oclientService, 0) Then
            MessageBox.Show("success")
        Else
            MessageBox.Show("failed")
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim oclientService As New ClientServiceEntity
        With oclientService
            .ClientServiceID = 1
            .ClientID = 99
            .ServiceID = 99
            .IsActiveFlag = 1
            .PurgeFlag = 0
        End With

        Dim oclientSrvicedata As New ClientServiceData
        If oclientSrvicedata.SaveClientService(oclientService, 0) Then
            MessageBox.Show("success")
        Else
            MessageBox.Show("failed")
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim oClientServiceData As New ClientServiceData
        Dim objClientServiceEntity As New CISEntity.ClientServiceEntity

        objClientServiceEntity = oClientServiceData.GetClientService(1)

        MessageBox.Show(objClientServiceEntity.ToString)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim oClientServiceData As New ClientServiceData
        Dim objClientServiceEntitylist As New List(Of CISEntity.ClientServiceEntity)

        objClientServiceEntitylist = oClientServiceData.GetClientServiceList("CLIENTID = 99")

        MessageBox.Show(objClientServiceEntitylist.ToString)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim odata As New ClientServiceData
        If odata.PurgeClientService(1, 0) Then
            MessageBox.Show("success")
        Else
            MessageBox.Show("failed")
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim odata As New CISData.ServiceData
        Dim oservice As New CISEntity.ServiceEntity
        With oservice
            .ServiceName = "CCTV"
            .ServicePermalink = "WWW.TESTPERMALINK\SERVICE\CCTV"
            .ServiceDescription = "THIS IS A TEST SERVICE DESCRIPTION"
            .IsActiveFlag = True
            .PurgeFlag = False
            .CreateDate = Now
            .CreatedBy = 0
            .UpdateDate = Now
            .UpdatedBy = 0
        End With

        If odata.SaveNewService(oservice, 0) Then
            MessageBox.Show("success")
        Else
            MessageBox.Show("failed")
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim odata As New CISData.ServiceData
        Dim oService As New CISEntity.ServiceEntity
        With oService
            .ServiceID = 1
            .ServiceName = "new test service name"
            .ServicePermalink = "test vallue"
            .ServiceDescription = "text description"
            .IsActiveFlag = True
            .PurgeFlag = False
            .CreateDate = Now
            .CreatedBy = 9
            .UpdateDate = Nothing
            .UpdatedBy = Nothing

        End With

        If odata.SaveService(oService, 0) Then
            MessageBox.Show("successful service save! id=" + oService.ServiceID.ToString)
        Else
            MessageBox.Show("failed")
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim oServiceData As New ServiceData
        Dim objServiceEntity As New CISEntity.ServiceEntity

        objServiceEntity = oServiceData.GetService(1)

        MessageBox.Show("Successful! id=" + objServiceEntity.ServiceID.ToString)
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim oServiceData As New ServiceData
        oServiceData.PurgeService(1, 0)
        MessageBox.Show("service successfully purged")
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim oServiceData As New ServiceData
        Dim oServiceEntityList As New List(Of CISEntity.ServiceEntity)

        oServiceEntityList = oServiceData.GetServiceList("SERVIENAME = 'CCTV'")

        MessageBox.Show(oServiceEntityList.ToString)
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim odata As New CISData.ClientServiceDeviceData
        Dim oClientServiceDeviceEntity As New ClientServiceDeviceEntity
        With oClientServiceDeviceEntity
            .ClientServiceDeviceID = 999
            .DeviceID = 1
            .Status = "Good"
            .Remarks = "this is a test remark"
            .IsActiveFlag = True
            .PurgeFlag = False
            .CreateDate = Now
            .CreatedBy = 9999
            .UpdateDate = Now
            .UpdatedBy = 9999
        End With

        odata.SaveNewClientServiceDevice(oClientServiceDeviceEntity, 0)

        MessageBox.Show("successful!! id=" + oClientServiceDeviceEntity.ClientServiceDeviceID.ToString)

    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim odata As New CISData.ClientServiceDeviceData
        Dim oClientServiceDeviceEntity As New ClientServiceDeviceEntity
        With oClientServiceDeviceEntity
            .ClientServiceDeviceID = 1
            .DeviceID = 2
            .Status = "Good"
            .Remarks = "this is a test remark-updated"
            .IsActiveFlag = True
            .PurgeFlag = False
            .CreateDate = Now
            .CreatedBy = 9999
            .UpdateDate = Now
            .UpdatedBy = 9999
        End With

        odata.SaveClientServiceDevice(oClientServiceDeviceEntity, 0)

        MessageBox.Show("successful!! updated by=" + oClientServiceDeviceEntity.UpdatedBy.ToString)
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Dim odata As New ClientServiceDeviceData
        odata.PurgeClientServiceDevice(1, 0)
        MessageBox.Show("ClientServiceDevice successfully purged")
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Dim odata As New ClientServiceDeviceData
        Dim oClientServiceDeviceEntity As New ClientServiceDeviceEntity
        oClientServiceDeviceEntity = odata.GetClientServiceDevice(1)

        MessageBox.Show("get Successful! id=" + oClientServiceDeviceEntity.ClientServiceDeviceID.ToString)
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Dim odata As New ClientServiceDeviceData
        Dim oClientServiceDeviceEntityList As New List(Of ClientServiceDeviceEntity)
        oClientServiceDeviceEntityList = odata.GetClientServiceDeviceList("status = 'Good'")

        MessageBox.Show("get Successful! id=" + oClientServiceDeviceEntityList.ToString)
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim odata As New CISData.DeviceData
        Dim oDeviceEntity As New DeviceEntity

        With oDeviceEntity
            .DeviceID = 0
            .ItemCode = "88888"
            .DeviceName = "Lenovo Phone"
            .DeviceType = "Mobile Phone"
            .SerialNumber = "99999999-99"
            .DeviceSpecifications = "china phone\r\nMobilePhone"
            .Status = "Good"
            .ManufactureDate = Now
            .ReceiveDate = Now
            .IsAvailable = True
            .Remarks = "tis test data"
            .IsActiveFlag = True
            .PurgeFlag = False
            .CreateDate = Now
            .CreatedBy = 0
            .UpdateDate = Now
            .UpdatedBy = 0
        End With

        odata.SaveNewDevice(oDeviceEntity, 0)

        MessageBox.Show("success id=" + oDeviceEntity.DeviceID.ToString)

    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Dim odata As New CISData.DeviceData
        Dim oDeviceEntity As New DeviceEntity

        With oDeviceEntity
            .DeviceID = 1
            .ItemCode = "88888"
            .DeviceName = "Lenovo Phone"
            .DeviceType = "Mobile Phone"
            .SerialNumber = "99999999-99"
            .DeviceSpecifications = "china phone\r\nMobilePhone"
            .Status = "Good"
            .ManufactureDate = Now
            .ReceiveDate = Now
            .IsAvailable = True
            .Remarks = "tis test data"
            .IsActiveFlag = True
            .PurgeFlag = False
            .CreateDate = Now
            .CreatedBy = 0
            .UpdateDate = Now
            .UpdatedBy = 0
        End With

        odata.SaveDevice(oDeviceEntity, 0)

        MessageBox.Show("success id=" + oDeviceEntity.DeviceID.ToString)

    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Dim odata As New CISData.DeviceData
        odata.PurgeDevice(1, 0)
        MessageBox.Show("successful")
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Dim odata As New CISData.DeviceData
        Dim oDeviceEntity As New CISEntity.DeviceEntity

        oDeviceEntity = odata.GetDevice(1)

        MessageBox.Show("success id=" + oDeviceEntity.DeviceName)
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        Dim odata As New CISData.DeviceData
        Dim oDeviceEntityList As New List(Of CISEntity.DeviceEntity)

        oDeviceEntityList = odata.GetDeviceList("status = 'Good'")

        MessageBox.Show("success id=" + oDeviceEntityList.ToString)
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        Dim odata As New CISData.TSWorkData
        Dim oTSWorkEntity As New CISEntity.TSWorkEntity

        With oTSWorkEntity
            .TSWorkID = 0
            .ClientServiceID = 1
            .PONumber = "12121212"
            .QuotationNumber = "0000000000"
            .QuoteDate = Now
            .FromText = "from here text"
            .DeliverTo = "to there text"
            .Terms = "3 years"
            .Status = "In Progress"
            .JobApprovalDate = Now
            .JobApprovedBy = 0
            .AssignedTo = 0
            .StartDate = Now
            .EndDate = Now
            .Remarks = "test remarks"
            .IsActiveFlag = True
            .PurgeFlag = False
            .CreateDate = Now
            .CreatedBy = 0
            .UpdateDate = Now
            .UpdatedBy = 0

        End With

        odata.SaveNewTSWork(oTSWorkEntity, 0)
        MessageBox.Show("success id=" + oTSWorkEntity.TSWorkID.ToString)
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        Dim odata As New CISData.TSWorkData
        Dim oTSWorkEntity As New CISEntity.TSWorkEntity

        With oTSWorkEntity
            .TSWorkID = 1
            .ClientServiceID = 1
            .PONumber = "12121212"
            .QuotationNumber = "0000000000"
            .QuoteDate = Now
            .FromText = "from here text"
            .DeliverTo = "to there text"
            .Terms = "3 years"
            .Status = "In Progress"
            .JobApprovalDate = Now
            .JobApprovedBy = 0
            .AssignedTo = 0
            .StartDate = Now
            .EndDate = Now
            .Remarks = "test remarks-update"
            .IsActiveFlag = True
            .PurgeFlag = False
            .CreateDate = Now
            .CreatedBy = 0
            .UpdateDate = Now
            .UpdatedBy = 0

        End With

        odata.SaveTSWork(oTSWorkEntity, 0)
        MessageBox.Show("success id=" + oTSWorkEntity.TSWorkID.ToString)
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        Dim odata As New CISData.TSWorkData
        odata.PurgeTSWork(1, 0)
        MessageBox.Show("purge okay")
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        Dim oData As New CISData.TSWorkData
        Dim oTSWorkEntity As New CISEntity.TSWorkEntity

        oTSWorkEntity = oData.GetTSWork(1)

        MessageBox.Show("okay! id =" + oTSWorkEntity.TSWorkID.ToString)
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        Dim oData As New CISData.TSWorkData
        Dim oTSWorkEntityList As New List(Of CISEntity.TSWorkEntity)

        oTSWorkEntityList = oData.GetTSWorkList("status = 'In Progress'")

        MessageBox.Show("okay! retrun count =" + oTSWorkEntityList.Count.ToString)
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        Dim oData As New CISData.QuotationData
        Dim oQuotationEntity As New CISEntity.QuotationEntity

        With oQuotationEntity
            .QuoteID = 0
            .TSWorkID = 1
            .QuotationNumber = "00000000"
            .ApprovalDate = Now
            .ApprovedBy = 0
            .Remarks = "New remarks"
            .IsActiveFlag = True
            .PurgeFlag = False
            .CreateDate = Now
            .CreatedBy = 1
            .UpdateDate = Now
            .UpdatedBy = 1
        End With

        oData.SaveNewQuotation(oQuotationEntity, 0)
        MessageBox.Show("okay! id=" + oQuotationEntity.QuoteID.ToString)

    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        Dim oData As New CISData.QuotationData
        Dim oQuotationEntity As New CISEntity.QuotationEntity

        With oQuotationEntity
            .QuoteID = 1
            .TSWorkID = 1
            .QuotationNumber = "00000000"
            .ApprovalDate = Now
            .ApprovedBy = 0
            .Remarks = "updated remarks"
            .IsActiveFlag = True
            .PurgeFlag = False
            .CreateDate = Now
            .CreatedBy = 1
            .UpdateDate = Now
            .UpdatedBy = 1
        End With

        oData.SaveQuotation(oQuotationEntity, 0)
        MessageBox.Show("okay! remarks=" + oQuotationEntity.Remarks)
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        Dim oData As New CISData.QuotationData
        oData.PurgeQuotation(1, 0)
        MessageBox.Show("purge okay!")
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        Dim oData As New CISData.QuotationData
        Dim oQuotationEntity As New CISEntity.QuotationEntity

        oQuotationEntity = oData.GetQuotation(1)
        MessageBox.Show("okay id=" + oQuotationEntity.QuoteID.ToString)
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        Dim oData As New CISData.QuotationData
        Dim oQuotationEntityList As New List(Of CISEntity.QuotationEntity)

        oQuotationEntityList = oData.GetQuotationList(" purgeflg = 0")
        MessageBox.Show("okay id=" + oQuotationEntityList.ToString)
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        Dim oData As New CISData.QuoteItemsData
        Dim oQuoteItemsEntity As New CISEntity.QuoteItemsEntity

        With oQuoteItemsEntity
            .QuoteItemID = 0
            .ItemCode = "item-00001"
            .ItemDescription = "first item description"
            .ItemQuantity = 1
            .ItemPer = "kilo"
            .ItemPrice = 2000.0
            .Amount = 2000.0
            .Remarks = "new test remarks"
            .SortNumber = 1
            .IsItemFlag = True
            .IsActiveFlag = True
            .PurgeFlag = False
            .CreateDate = Now
            .CreatedBy = 0
            .UpdateDate = Now
            .UpdatedBy = 0

        End With


        oData.SaveNewQuoteItems(oQuoteItemsEntity, 0)

        MessageBox.Show("okay id=" + oQuoteItemsEntity.QuoteItemID.ToString)
    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        Dim oData As New CISData.QuoteItemsData
        Dim oQuoteItemsEntity As New CISEntity.QuoteItemsEntity

        With oQuoteItemsEntity
            .QuoteItemID = 1
            .ItemCode = "item-00001"
            .ItemDescription = "-updatedfirst item description"
            .ItemQuantity = 1
            .ItemPer = "kilo"
            .ItemPrice = 2000.25
            .Amount = 2000.48
            .Remarks = "updated test remarks"
            .SortNumber = 1
            .IsItemFlag = True
            .IsActiveFlag = True
            .PurgeFlag = False
            .CreateDate = Now
            .CreatedBy = 0
            .UpdateDate = Now
            .UpdatedBy = 0

        End With


        oData.SaveQuoteItems(oQuoteItemsEntity, 0)

        MessageBox.Show("okay rem=" + oQuoteItemsEntity.Remarks)
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        Dim oData As New CISData.QuoteItemsData

        oData.PurgeQuoteItems(1, 0)
        MessageBox.Show("purged okay")
    End Sub

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
        Dim oData As New CISData.QuoteItemsData
        Dim o As New CISEntity.QuoteItemsEntity

        o = oData.GetQuoteItems(1)
        MessageBox.Show("okay id=" + o.QuoteItemID.ToString)
    End Sub

    Private Sub Button41_Click(sender As Object, e As EventArgs) Handles Button41.Click
        Dim oData As New CISData.QuoteItemsData
        Dim o As New List(Of CISEntity.QuoteItemsEntity)

        o = oData.GetList("ITEMCODE = 'item-00001'")
        MessageBox.Show("okay id=" + o.Count.ToString)
    End Sub

    Private Sub Button42_Click(sender As Object, e As EventArgs) Handles Button42.Click
        Dim oData As New CISData.ProfileData
        Dim o As New CISEntity.ProfileEntity
        With o
            .ProfileID = 0
            .EmployeeCode = "0000-123"
            .PhotoUrlPath = "testphoto.com\photo\1"
            .Name = "LLOYD LAAS"
            .Address = "test address"
            .DateHired = #12/07/2016#
            .FacultyGroup = "BBS"
            .Department = "IT"
            .Status = "Employed"
            .UserName = "devilisk"
            .Password = "P@$$w0rd"
            .IsAffiliateFlag = True
            .IsActiveFlag = True
            .PurgeFlag = False
            .CreateDate = Now
            .CreatedBy = 0
            .UpdateDate = Now
            .UpdatedBy = 0
        End With

        oData.SaveNewProfile(o, 0)
        MessageBox.Show("okay id = " + o.ProfileID.ToString)
    End Sub

    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click
        Dim oData As New CISData.ProfileData
        Dim o As New CISEntity.ProfileEntity
        With o
            .ProfileID = 1
            .EmployeeCode = "0000-123"
            .PhotoUrlPath = "testphoto.com\photo\1"
            .Name = "LLOYD LAAS"
            .Address = "updated test address"
            .DateHired = #12/07/2016#
            .FacultyGroup = "BBS"
            .Department = "IT"
            .Status = "Employed"
            .UserName = "devilisk"
            .Password = "P@$$w0rd"
            .IsAffiliateFlag = True
            .IsActiveFlag = True
            .PurgeFlag = False
            .CreateDate = Now
            .CreatedBy = 0
            .UpdateDate = Now
            .UpdatedBy = 0
        End With

        oData.SaveProfile(o, 0)
        MessageBox.Show("okay id = " + o.Address)
    End Sub
End Class
