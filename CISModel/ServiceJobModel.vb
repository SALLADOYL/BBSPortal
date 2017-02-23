
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

    Public Function GetProfileName(ByVal ProfileID As Long) As String
        Dim dataProfile As New CISData.ProfileData
        Return dataProfile.GetProfileName(ProfileID)
    End Function

    Public Function PurgeClientServiceDevice(ByVal lngClSvcDevID As Long, ByVal prflID As Long) As Boolean
        Dim data As New CISData.ClientServiceDeviceData
        Return data.PurgeClientServiceDevice(lngClSvcDevID, prflID)
    End Function


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

    'Public Function UploadSaveNewAttachment(ByRef cisFile As CISEntity.FileAttachEntity, ByVal prflID As Long) As Long
    '    Dim dataFile As New CISData.FileAttachData
    '    dataFile.SaveNew(cisFile, prflID)
    '    dataFile = Nothing
    '    Return cisFile.FileID

    'End Function

    'Public Function Purge(ByVal FILEID As Long, ByVal prflID As Long) As Boolean
    '    Dim dataFile As New CISData.FileAttachData
    '    Return dataFile.Purge(FILEID, prflID)
    'End Function






End Class
