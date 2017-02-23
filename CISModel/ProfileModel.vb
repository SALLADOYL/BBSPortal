Option Strict On

Imports CISEntity
Imports CISData
Imports System.Web
Imports System.Data.SqlClient
Public Class ProfileModel

    Public Function Save(ByRef cisProfileEntity As CISEntity.ProfileEntity, ByVal prflID As Long) As Boolean
        Dim prflData As New CISData.ProfileData

        If cisProfileEntity.ProfileID = 0 Then
            Return prflData.SaveNewProfile(cisProfileEntity, prflID)
        Else
            Return prflData.SaveProfile(cisProfileEntity, prflID)
        End If

        Return Nothing
    End Function

    Public Function GetEmployeesListWithBlank() As List(Of CISEntity.ProfileEntity)
        Dim prflData As New CISData.ProfileData
        Return prflData.GetEmployeesListWithBlank
    End Function

    Public Function Purge(ByVal profileID As Long, ByVal prflID As Long) As Boolean
        Dim prflData As New CISData.ProfileData
        Return prflData.PurgeProfile(profileID, prflID)
    End Function

    Public Function GetProfile(ByVal ProfileID As Long) As CISEntity.ProfileEntity
        Dim prflData As New CISData.ProfileData
        Return prflData.GetProfile(ProfileID)
    End Function

    Public Function GetList(ByVal strWhereClause As String) As List(Of CISEntity.ProfileEntity)
        Dim prflData As New CISData.ProfileData
        Return prflData.GetList(strWhereClause)
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

    Public Function GetProfileListByName(ByVal strProfileName As String, ByVal isWildCardSearch As Boolean) As List(Of CISEntity.ProfileEntity)
        Dim dataProfile As New CISData.ProfileData
        Dim entProfileList As New List(Of CISEntity.ProfileEntity)

        If isWildCardSearch Then
            entProfileList = dataProfile.GetList("[NAME] like '%" + strProfileName + "%'")
        Else
            entProfileList = dataProfile.GetList("[NAME] = '" + strProfileName + "'")
        End If

        Return entProfileList

    End Function

    Public Function GetProfileListByCode(ByVal strProfileCode As String, ByVal isWildCardSearch As Boolean) As List(Of CISEntity.ProfileEntity)
        Dim dataProfile As New CISData.ProfileData
        Dim entProfileList As New List(Of CISEntity.ProfileEntity)

        If isWildCardSearch Then
            entProfileList = dataProfile.GetList("[EMPLOYEECODE] like '%" + strProfileCode + "%'")
        Else
            entProfileList = dataProfile.GetList("[EMPLOYEECODE] = '" + strProfileCode + "'")
        End If

        Return entProfileList

    End Function

    Public Function GetProfileListByID(ByVal lngID As Long) As List(Of CISEntity.ProfileEntity)
        Dim dataProfile As New CISData.ProfileData
        Dim entProfileList As New List(Of CISEntity.ProfileEntity)

        entProfileList = dataProfile.GetList("[PROFILEID] = '" + lngID.ToString + "'")

        Return entProfileList

    End Function

End Class
