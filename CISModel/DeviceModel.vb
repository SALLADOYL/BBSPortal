Option Strict On

Imports CISEntity
Imports CISData
Imports System.Web
Imports System.Data.SqlClient
Public Class DeviceModel

    Public Function Save(ByRef entDevice As CISEntity.DeviceEntity, ByVal prflID As Long) As Boolean
        Dim dataDevice As New CISData.DeviceData

        If entDevice.DeviceID = 0 Then
            Return dataDevice.SaveNewDevice(entDevice, prflID)
        Else
            Return dataDevice.SaveDevice(entDevice, prflID)
        End If
        Return Nothing
    End Function

    Public Function SaveClientServiceDevice(ByRef cisClientServiceDeviceEntity As CISEntity.ClientServiceDeviceEntity, ByVal prflID As Long) As Boolean
        Dim dataClSvcDevice As New CISData.ClientServiceDeviceData
        If cisClientServiceDeviceEntity.ClientServiceDeviceID = 0 Then
            Return dataClSvcDevice.SaveNewClientServiceDevice(cisClientServiceDeviceEntity, prflID)
        Else
            Return dataClSvcDevice.SaveClientServiceDevice(cisClientServiceDeviceEntity, prflID)
        End If
        Return Nothing
    End Function

    Public Function PurgeClientServiceDevice(ByVal lngClSvcDevID As Long, ByVal prflID As Long) As Boolean
        Dim data As New CISData.ClientServiceDeviceData
        Return data.PurgeClientServiceDevice(lngClSvcDevID, prflID)
    End Function

    Public Function Purge(ByVal DevID As Long, ByVal prflID As Long) As Boolean
        Dim dataDevice As New CISData.DeviceData
        Return dataDevice.PurgeDevice(DevID, prflID)
    End Function

    Public Function GetDevice(ByVal devID As Long) As CISEntity.DeviceEntity
        Dim dataDevice As New CISData.DeviceData
        Return dataDevice.GetDevice(devID)
    End Function

    Public Function GetList(ByVal strWhereClause As String) As List(Of CISEntity.DeviceEntity)
        Dim dataDevice As New CISData.DeviceData
        Return dataDevice.GetDeviceList(strWhereClause)
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

    Public Function GetDeviceListByName(ByVal strDeviceName As String, ByVal isWildcard As Boolean, ByVal blnInstalledAtClient As Boolean) As DataTable
        Dim dataDevice As New CISData.DeviceData
        Return dataDevice.GetDeviceListByName(strDeviceName, isWildcard, blnInstalledAtClient)

    End Function

    Public Function GetDeviceListBySN(ByVal strDeviceSN As String, ByVal isWildcard As Boolean, ByVal blnInstalledAtClient As Boolean) As DataTable
        Dim dataDevice As New CISData.DeviceData
        Return dataDevice.GetDeviceListBySN(strDeviceSN, isWildcard, blnInstalledAtClient)

    End Function

    Public Function GetDeviceListByItemCode(ByVal strDeviceItemCode As String, ByVal isWildcard As Boolean, ByVal blnInstalledAtClient As Boolean) As DataTable
        Dim dataDevice As New CISData.DeviceData
        Return dataDevice.GetDeviceListByItemCode(strDeviceItemCode, isWildcard, blnInstalledAtClient)

    End Function

    Public Function GetDeviceClientInfo(ByVal DevID As Long) As DataTable
        Dim dataDevice As New CISData.DeviceData
        Return dataDevice.GetDeviceClientInfo(DevID)
    End Function

    Public Function GetDeviceNoteList(ByVal devID As Long) As DataTable
        Dim dataNotes As New CISData.NotesData
        Return dataNotes.GetDeviceNoteList(devID)
    End Function

    Public Function GetInstalledDevicesAtClientService(ByVal ClSvcID As Long) As DataTable
        Dim dataDevice As New CISData.DeviceData
        Return dataDevice.GetInstalledDevicesAtClientService(ClSvcID)
    End Function

    Public Function VerifyDeviceAndClientServiceAvailable(ByVal DeviceID As Long, ByVal ClientServiceID As Long) As Boolean
        Dim dataClSvcDev As New CISData.ClientServiceDeviceData
        Return dataClSvcDev.VerifyDeviceAndClientServiceAvailable(DeviceID, ClientServiceID)

    End Function

    Public Function GetDeviceTechReportList(ByVal DevID As Long) As DataTable
        Dim dataDevice As New CISData.DeviceData
        Return dataDevice.GetDeviceTechReportList(DevID)
    End Function

    Public Function SaveNote(ByRef cisNotesEntity As CISEntity.NotesEntity, ByVal prflID As Long) As Boolean
        Dim dataNote As New CISData.NotesData
        cisNotesEntity.ParentType = "DEV"
        If cisNotesEntity.NoteID = 0 Then
            Return dataNote.SaveNew(cisNotesEntity, prflID)
        ElseIf cisNotesEntity.NoteID > 0 Then
            Return dataNote.SaveNote(cisNotesEntity, prflID)
        End If
        Return False
    End Function

    Public Function DeleteNote(ByVal NoteID As Long, ByVal prflID As Long) As Boolean
        Dim dataNote As New CISData.NotesData
        Return dataNote.PurgeNote(NoteID, prflID)
    End Function

End Class
