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

    Public Function SaveProfilePhoto(ByVal ProfileID As Long, ByVal WebSavedImage As String, ByVal prflID As Long) As Boolean
        Dim prflData As New CISData.ProfileData
        Return prflData.SaveProfilePhoto(ProfileID, WebSavedImage, prflID)
    End Function

    Public Function SaveProfileUsrnamePwd(ByVal ProfileID As Long, ByVal usrName As String, ByVal pwd As String, ByVal prflID As Long) As Boolean
        Dim prflData As New CISData.ProfileData
        Return prflData.SaveProfileUsrnamePwd(ProfileID, usrName, pwd, prflID)
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

    Public Function ValidateUsernameIsUnique(ByVal profileID As Long, ByVal strUsername As String) As Boolean
        Dim prflData As New CISData.ProfileData
        Dim retList As New List(Of CISEntity.ProfileEntity)
        Dim strwhere As String = ""
        strwhere &= " PROFILETBL.PROFILEID NOT IN ( " + profileID.ToString + ")"
        strwhere &= " AND PROFILETBL.USERNAME = '" + strUsername + "'"
        strwhere &= " AND PROFILETBL.ISACTIVEFLG=1"
        strwhere &= " AND PROFILETBL.PURGEFLG = 0"

        retList = prflData.GetList(strwhere)

        If Not IsNothing(retList) AndAlso retList.Count > 0 Then
            Return False
        Else
            Return True
        End If
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



#Region "Role"
    Public Function GetAllRoleList() As List(Of CISEntity.RoleEntity)
        Dim dtRole As New CISData.RoleData
        Dim strWhereClause As String = ""
        strWhereClause &= " ROLETBL.ISACTIVEFLG=1 AND ROLETBL.PURGEFLG=0 "
        strWhereClause &= " ORDER BY ROLETBL.NAME ASC "
        Return dtRole.GetList(strWhereClause)
    End Function

    Public Function GetProfileNotEnrolledtoRole(ByVal roleID As Long) As List(Of CISEntity.ProfileEntity)
        Dim dtProfile As New CISData.ProfileData
        Dim strWhere As String = ""
        strWhere &= " PROFILETBL.ISACTIVEFLG=1 And PROFILETBL.PURGEFLG=0 "
        strWhere &= " And PROFILETBL.ISAFFILIATEFLG = 1 "
        strWhere &= " And PROFILETBL.PROFILEID Not IN ( "
        strWhere &= " SELECT PROFILEOBJACCESSTBL.PROFILEID FROM PROFILEOBJACCESSTBL WHERE PROFILEOBJACCESSTBL.ROLEID = " & roleID.ToString & ")"
        Return dtProfile.GetList(strWhere)
    End Function

    Public Function GetRole(ByVal ROLEID As Long) As CISEntity.RoleEntity
        Dim dtRole As New CISData.RoleData
        Return dtRole.GetRole(ROLEID)
    End Function

    Public Function GetRoleUsers(ByVal Roleid As Long) As DataTable
        Dim dtRole As New CISData.RoleData
        Return dtRole.GetRoleUsers(Roleid)
    End Function


    Public Function DeleteRoleAccess(ByVal PRFLOBJACCID As Long) As Boolean
        Dim dtPrflAccess As New CISData.ProfileObjAccessData
        Return dtPrflAccess.Delete(PRFLOBJACCID, 0)

    End Function

    Public Function SaveNewProfileAccess(ByRef cisProfileObjectAccessEntity As CISEntity.ProfileObjectAccessEntity, ByVal prflID As Long) As Boolean
        Dim dtPrflAccess As New CISData.ProfileObjAccessData
        Return dtPrflAccess.SaveNew(cisProfileObjectAccessEntity, prflID)
    End Function


#End Region

End Class
