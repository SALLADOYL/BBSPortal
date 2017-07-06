
Option Strict On

Imports CISEntity
Imports CISData
Imports System.Web
Imports System.Data.SqlClient
Public Class ServiceJobModel
    Public Function GetServiceJob(ByVal WorkID As Long) As CISEntity.TSWorkEntity
        Dim dataWork As New CISData.TSWorkData
        Return dataWork.GetTSWork(WorkID)
    End Function

    Public Function GetServiceJobList(ByVal strWhereClause As String) As List(Of CISEntity.TSWorkEntity)
        Dim dataWork As New CISData.TSWorkData
        Return dataWork.GetTSWorkList(strWhereClause)
    End Function

    'Public Function GetProfileName(ByVal ProfileID As Long) As String
    '    Dim dataProfile As New CISData.ProfileData
    '    Return dataProfile.GetProfileName(ProfileID)
    'End Function

    'Public Function PurgeClientServiceDevice(ByVal lngClSvcDevID As Long, ByVal prflID As Long) As Boolean
    '    Dim data As New CISData.ClientServiceDeviceData
    '    Return data.PurgeClientServiceDevice(lngClSvcDevID, prflID)
    'End Function


    Public Function Save(ByRef cisTSWorkEntity As CISEntity.TSWorkEntity, ByVal prflID As Long) As Boolean
        Dim dataWork As New CISData.TSWorkData
        If cisTSWorkEntity.TSWorkID = 0 Then
            Return dataWork.SaveNewTSWork(cisTSWorkEntity, prflID)
        Else
            Return dataWork.SaveTSWork(cisTSWorkEntity, prflID)
        End If
        dataWork = Nothing
        Return False
    End Function

    Public Function PurgeTSWork(ByVal TSWorkID As Long, ByVal prflID As Long) As Boolean
        Dim dataWork As New CISData.TSWorkData
        Return dataWork.PurgeTSWork(TSWorkID, prflID)
    End Function


    Public Function GetServiceListWithBlank(ByVal ClientID As Long) As DataTable
        Dim WhereSTR As String
        Dim dataService As New CISData.ServiceData

        WhereSTR = " ISACTIVEFLG = 1 and PURGEFLG=0 AND "
        WhereSTR = WhereSTR + " SERVICETBL.SVCID IN (SELECT SVCID FROM CLIENTSERVICETBL WHERE CLIENTID = " + ClientID.ToString + " )"

        Return dataService.GetServiceListWithBlank(WhereSTR)
    End Function

    Public Function GetClientServiceParent(ByVal SJID As Long) As DataTable
        Dim strSQL As String = ""

        strSQL &= " SELECT "
        strSQL &= " CLIENTSERVICETBL.CLIENTSVCID, CLIENTTBL.CLIENTID "
        strSQL &= " FROM "
        strSQL &= " CLIENTSERVICETBL INNER JOIN"
        strSQL &= " CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID INNER JOIN "
        strSQL &= " SERVICETBL ON CLIENTSERVICETBL.SVCID = SERVICETBL.SVCID INNER JOIN "
        strSQL &= " TSWORKTBL ON CLIENTSERVICETBL.CLIENTSVCID = TSWORKTBL.CLSVCID "
        strSQL &= " WHERE TSWORKTBL.TSWORKID=" + SJID.ToString + " AND CLIENTSERVICETBL.ISACTIVE=1 AND CLIENTSERVICETBL.PURGEFLG=0"


        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function

    Public Function GetSJApproverListProfileIDName() As DataTable
        Dim dataPrflAccess As New CISData.ProfileObjAccessData
        Dim lngSJApproverRole As Long = 2
        Return dataPrflAccess.GetProfileIDNameByRole(lngSJApproverRole)
    End Function

    Public Function GetSJCreatorListProfileIDName() As DataTable
        Dim dataPrflAccess As New CISData.ProfileObjAccessData
        Dim lngSJCreatedByRole As Long = 1
        Return dataPrflAccess.GetProfileIDNameByRole(lngSJCreatedByRole)
    End Function

    Public Function GetServiceJobStatusList() As DataTable
        Dim mdlMaster As New CISModel.MasterModel
        Return mdlMaster.GetServiceJobStatusList
    End Function

    Public Function GetClientListForSearch() As List(Of ClientEntity)
        Dim dataClient As New CISData.ClientData
        Return dataClient.GetClientList("ISACTIVEFLG = 1 and PURGEFLG=0")
    End Function

    Public Function GetServiceListForSearch() As List(Of ServiceEntity)
        Dim dataService As New CISData.ServiceData
        Return dataService.GetServiceList("ISACTIVEFLG = 1 and PURGEFLG=0")
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

    Public Function GetServiceJobAttachmentsList(ByVal ServiceJobID As Long) As DataTable
        Dim dataFile As New CISData.FileAttachData
        Return dataFile.GetServiceJobAttachmentsList(ServiceJobID)
    End Function

    Public Function SearchServiceJobbyClientService(ByVal ClientID As Long, ByVal ServiceID As Long) As DataTable
        Dim dataSJ As New CISData.ServiceData
        Return dataSJ.SearchServiceJobbyClientService(ClientID, ServiceID)
    End Function

    Public Function SearchServiceJobbyPOnumber(ByVal PONumber As String) As DataTable

        Dim dataSJ As New CISData.ServiceData
        Return dataSJ.SearchServiceJobbyPOnumber(PONumber)

    End Function

    Public Function SearchServiceJobbySJnumber(ByVal ServiceJobNumber As String) As DataTable
        Dim dataSJ As New CISData.ServiceData
        Return dataSJ.SearchServiceJobbySJnumber(ServiceJobNumber)
    End Function

    Public Function SearchServiceJobbyQuotationNumber(ByVal QuotationNumber As String) As DataTable

        Dim dataSJ As New CISData.ServiceData
        Return dataSJ.SearchServiceJobbyQuotationNumber(QuotationNumber)

    End Function

    Public Function SearchServiceJobbyQuotationDates(ByVal dateFrom As Date, ByVal dateTo As Date) As DataTable

        Dim dataSJ As New CISData.ServiceData
        Return dataSJ.SearchServiceJobbyQuotationDates(dateFrom, dateTo)

    End Function

End Class
