Option Strict On

Imports CISEntity
Imports CISData
Imports System.Web
Imports System.Data.SqlClient
Public Class TechReportModel

    Public Function Save(ByRef cisTechnicalReportEntity As CISEntity.TechnicalReportEntity, ByVal prflID As Long) As Boolean

        Dim dataTR As New CISData.TechReportData

        If cisTechnicalReportEntity.TechnicalReportID > 0 Then
            Return dataTR.Save(cisTechnicalReportEntity, prflID)
        Else
            Return dataTR.SaveNew(cisTechnicalReportEntity, prflID)
        End If
        Return Nothing
    End Function

    Public Function GetProfileName(ByVal prflID As Long) As String
        Dim oprflData As New CISData.ProfileData
        Dim prflEntity As New CISEntity.ProfileEntity
        prflEntity = oprflData.GetProfile(prflID)

        If Not IsNothing(prflEntity) Then
            Return prflEntity.Name
        Else
            Return Nothing
        End If

        Return Nothing

    End Function

    Public Function GetList(ByVal strWhereClause As String) As List(Of CISEntity.TechnicalReportEntity)
        Dim dataTR As New CISData.TechReportData
        Return dataTR.GetList(strWhereClause)
    End Function

    Public Function GetTechnicalReportEntity(ByVal ClientID As Long) As CISEntity.TechnicalReportEntity
        Dim dataTR As New CISData.TechReportData
        Return dataTR.GetTechnicalReportEntity(ClientID)
    End Function

    Public Function Purge(ByVal TECHREPID As Long, ByVal prflID As Long) As Boolean
        Dim dataTR As New CISData.TechReportData
        Return dataTR.Purge(TECHREPID, TECHREPID)
    End Function

    Public Function SearchTRbyClientService(ByVal ClientID As Long, ByVal ServiceID As Long) As DataTable
        Dim dataTR As New CISData.TechReportData
        Return dataTR.SearchTRbyClientService(ClientID, ServiceID)
    End Function

    Public Function SearchTRbyCompletedDateRange(ByVal fromDT As Date, ByVal ToDT As Date) As DataTable
        Dim dataTR As New CISData.TechReportData
        Return dataTR.SearchTRbyCompletedDateRange(fromDT, ToDT)
    End Function

    Public Function SearchTRbyStartDateRange(ByVal fromDT As Date, ByVal ToDT As Date) As DataTable
        Dim dataTR As New CISData.TechReportData
        Return dataTR.SearchTRbyStartDateRange(fromDT, ToDT)
    End Function

    Public Function SearchTRbyStatus(ByVal TRStatus As String) As DataTable
        Dim dataTR As New CISData.TechReportData
        Return dataTR.SearchTRbyStatus(TRStatus)
    End Function

    Public Function SearchTRbyTeam(ByVal TRTeam As String) As DataTable
        Dim dataTR As New CISData.TechReportData
        Return dataTR.SearchTRbyTeam(TRTeam)
    End Function

    Public Function GetTRStatusList() As DataTable
        Dim modMaster As New CISModel.MasterModel
        Return modMaster.GetTRStatusList
    End Function
    Public Function GetServiceListForSearch() As List(Of ServiceEntity)
        Dim dataService As New CISData.ServiceData
        Return dataService.GetServiceList("ISACTIVEFLG = 1 and PURGEFLG=0")
    End Function
    Public Function GetServiceListofClient(ByVal ClientID As Long) As List(Of ServiceEntity)
        Dim dataService As New CISData.ServiceData
        Dim whereSTR As String
        whereSTR = " ISACTIVEFLG = 1 and PURGEFLG=0 AND "
        whereSTR = whereSTR + " SERVICETBL.SVCID IN (SELECT SVCID FROM CLIENTSERVICETBL WHERE CLIENTID = " + ClientID.ToString + " )"

        Return dataService.GetServiceList(whereSTR)
    End Function

    Public Function GetServiceListWithBlank(ByVal ClientID As Long) As DataTable
        Dim WhereSTR As String
        Dim dataService As New CISData.ServiceData

        WhereSTR = " ISACTIVEFLG = 1 and PURGEFLG=0 AND "
        WhereSTR = WhereSTR + " SERVICETBL.SVCID IN (SELECT SVCID FROM CLIENTSERVICETBL WHERE CLIENTID = " + ClientID.ToString + " )"

        Return dataService.GetServiceListWithBlank(WhereSTR)
    End Function



    Public Function GetClientListForSearch() As List(Of ClientEntity)
        Dim dataClient As New CISData.ClientData
        Return dataClient.GetClientList("ISACTIVEFLG = 1 and PURGEFLG=0")
    End Function

    Public Function GetClientServiceParent(ByVal TRID As Long) As DataTable
        Dim dataTR As New CISData.TechReportData
        Return dataTR.GetClientServiceParent(TRID)
    End Function

    Public Function GetTechReportAffectedDevices(ByVal TRID As Long) As DataTable
        Dim dataDevice As New CISData.DeviceData
        Return dataDevice.GetDevicesNotInTechRep(TRID)
        dataDevice = Nothing

    End Function

    Public Function AddTechRepAffectedDevices(ByVal TRID As Long, ByVal DEVid As Long) As Long
        Dim dataDevice As New CISData.DeviceData
        Return dataDevice.AddAffectedDevice(DEVid, TRID)

    End Function

    Public Function PurgeTechRepAffectedDevices(ByVal AFFECTEDDEVICEID As Long) As Boolean
        Dim dataDevice As New CISData.DeviceData
        Return dataDevice.RemoveAffectedDevice(AFFECTEDDEVICEID)
        Return Nothing
        dataDevice = Nothing
    End Function




End Class
