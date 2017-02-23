Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CISEntity
Imports CISData

<TestClass()> Public Class UnitTest1



#Region "ClientData TEst"
    <TestMethod()> Public Sub NormalNewClient()

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
        Assert.IsTrue(oclientdata.SaveNewClient(oclient, 0), "test insert failed")
    End Sub
#End Region
End Class