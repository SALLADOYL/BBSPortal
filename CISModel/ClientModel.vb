
Option Strict On

Imports CISEntity
Imports CISData
Imports System.Web
Imports System.Data.SqlClient
Public Class ClientModel

    Public Function GetClient(ByVal lngClientID As Long) As CISEntity.ClientEntity
        'Dim cisEnt As New CISEntity.ClientEntity
        Dim oDAta As New CISData.ClientData

        Return oDAta.GetClient(lngClientID)
    End Function

    Public Function GetClientList(ByVal clientID As Long) As List(Of CISEntity.ClientEntity)
        Dim oDAta As New CISData.ClientData

        Return oDAta.GetClientList("CLIENTID=" + clientID.ToString)
    End Function

    Public Function GetClientEntityListByName(ByVal strName As String, ByVal iswildcard As Boolean) As List(Of CISEntity.ClientEntity)
        Dim dataClient As New CISData.ClientData
        Return dataClient.GetClientListByName(strName, iswildcard)
    End Function

    Public Function GetClientEntityListByCode(ByVal strCode As String, ByVal iswildcard As Boolean) As List(Of CISEntity.ClientEntity)
        Dim dataClient As New CISData.ClientData
        Return dataClient.GetClientListByClientCode(strCode, iswildcard)
    End Function

    Public Function GetClientServices(ByVal lngClientID As Long) As List(Of CISEntity.ClientServiceEntity)
        Dim odata As New CISData.ClientServiceData
        Dim strWhere As String = "CLIENTID=" + lngClientID.ToString
        Return odata.GetClientServiceList(strWhere)

    End Function

    Public Function GetServiceInfoByClSvcID(ByVal lngClSvcID As Long) As CISEntity.ServiceEntity
        Dim odata As New CISData.ServiceData
        Dim listService As List(Of CISEntity.ServiceEntity)
        Dim strWhere As String = "SVCID IN (SELECT SVCID FROM CLIENTSERVICETBL WHERE CLIENTSVCID = " + lngClSvcID.ToString & ")"
        listService = odata.GetServiceList(strWhere)

        If listService.Count > 0 Then
            Return listService(0)
        Else
            Return Nothing
        End If

        Return Nothing

    End Function

    Public Function SaveClient(ByRef oClientEntity As CISEntity.ClientEntity, ByVal prflID As Long) As Boolean
        Dim odata As New CISData.ClientData
        If oClientEntity.ClientID = 0 Then
            Return odata.SaveNewClient(oClientEntity, prflID)
        Else
            Return odata.SaveClient(oClientEntity, prflID)
        End If
        Return False
    End Function

    Public Function SaveClientService(ByRef oClientServiceEntity As CISEntity.ClientServiceEntity, ByVal prflID As Long) As Boolean
        Dim oCSD As New CISData.ClientServiceData
        If oClientServiceEntity.ClientServiceID = 0 Then
            Return oCSD.SaveNewClientService(oClientServiceEntity, prflID)
        Else
            Return oCSD.SaveClientService(oClientServiceEntity, prflID)
        End If
        Return False
    End Function

    Public Function GetSubscribedServices(ByVal clientID As Long) As DataTable
        Dim oCSD As New CISData.ClientServiceData
        Return oCSD.GetSubscribedServices(clientID)
    End Function

    Public Function InsertClientServiceDevice(ByVal prflID As Long, ByVal lstDevicesAdd As List(Of CISEntity.ClientServiceDeviceEntity)) As Boolean
        Dim oClientServiceDeviceData As New CISData.ClientServiceDeviceData
        Return oClientServiceDeviceData.InsertClientServiceDevice(prflID, lstDevicesAdd)
    End Function

    Public Function PurgeClientServiceDevice(ByVal prflID As Long, ByVal lstDevicesPurge As List(Of CISEntity.ClientServiceDeviceEntity)) As Boolean
        Dim oClientServiceDeviceData As New CISData.ClientServiceDeviceData
        Return oClientServiceDeviceData.PurgeClientServiceDevice(prflID, lstDevicesPurge)
    End Function



    Public Function GetUnsubscribedServices(ByVal ClientID As Long) As DataTable
        Dim oclsvcData As New CISData.ClientServiceData

        Return oclsvcData.GetUnsubscribedServices(ClientID)

    End Function

    Public Function GetCurrentSubscribedServices(ByVal clientID As Long) As DataTable
        Dim oclsvcData As New CISData.ClientServiceData

        Return oclsvcData.GetSubscribedServices(clientID)

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

    Public Function GetClientAttachmentEntities(ByVal clientID As Long) As List(Of CISEntity.FileAttachEntity)
        Dim dataFile As New CISData.FileAttachData
        Return dataFile.GetList("ATTACHMENTTYPE = 'CL' AND PARENTID=" + clientID.ToString + " AND ISACTIVEFLG = 1 AND PURGEFLG =0")
    End Function

    Public Function GetClientAttachmentsList(ByVal clientID As Long) As DataTable
        Dim dataFile As New CISData.FileAttachData
        Return dataFile.GetClientAttachmentsList(clientID)

    End Function

    Public Function GetClientNoteEntities(ByVal clientID As Long) As List(Of CISEntity.NotesEntity)
        Dim dataFile As New CISData.NotesData

        Return dataFile.GetList("PARENTTYPE = 'CL' AND PARENTID=" + clientID.ToString + " AND ISACTIVEFLG = 1 AND PURGEFLG =0")
    End Function

    Public Function GetClientNoteList(ByVal clientID As Long) As DataTable
        Dim dataNote As New CISData.NotesData
        Return dataNote.GetClientNoteList(clientID)
    End Function

    Public Function GetClientServiceByClSvcID(ByVal CLSvcID As Long) As CISEntity.ClientServiceEntity
        Dim dataClientSvc As New CISData.ClientServiceData
        Return dataClientSvc.GetClientService(CLSvcID)

    End Function

    Public Function GetClientServiceByClientIDSvcID(ByVal ClientID As Long, ByVal ServiceID As Long) As CISEntity.ClientServiceEntity
        Dim dataClientSvc As New CISData.ClientServiceData
        Return dataClientSvc.GetClientService(ClientID, ServiceID)

    End Function

    Public Function GetClientServiceJobs(ByVal ClSvcID As Long) As List(Of CISEntity.TSWorkEntity)
        Dim dataWork As New CISData.TSWorkData
        Return dataWork.GetTSWorkList("TSWORKTBL.CLSVCID = " & ClSvcID.ToString + " AND ISACTIVEFLG = 1 AND PURGEFLG =0")
    End Function

    Public Function GetClientServiceTechReports(ByVal ClSvcID As Long) As DataTable
        Dim dataTR As New CISData.TechReportData
        Return dataTR.SearchTRbyClientService(ClSvcID)
    End Function

#Region "FILE/ATTACHMENT"
    Public Function UploadSaveNewAttachment(ByRef cisFile As CISEntity.FileAttachEntity, ByVal prflID As Long) As Long
        Dim dataFile As New CISData.FileAttachData
        dataFile.SaveNew(cisFile, prflID)
        dataFile = Nothing
        Return cisFile.FileID

    End Function

    Public Function FilePurge(ByVal FILEID As Long, ByVal prflID As Long) As Boolean
        Dim dataFile As New CISData.FileAttachData
        Return dataFile.Purge(FILEID, prflID)
    End Function
#End Region

#Region "NOTE"
    Public Function DeleteNote(ByVal NoteID As Long, ByVal prflID As Long) As Boolean
        Dim dataNote As New CISData.NotesData
        Return dataNote.PurgeNote(NoteID, prflID)
    End Function

    Public Function SaveNote(ByRef cisNotesEntity As CISEntity.NotesEntity, ByVal prflID As Long) As Boolean
        Dim dataNote As New CISData.NotesData
        If cisNotesEntity.NoteID = 0 Then
            Return dataNote.SaveNew(cisNotesEntity, prflID)
        ElseIf cisNotesEntity.NoteID > 0 Then
            Return dataNote.SaveNote(cisNotesEntity, prflID)
        End If
        Return False
    End Function
#End Region

End Class
