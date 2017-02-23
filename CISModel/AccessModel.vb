Option Strict On

Imports CISEntity
Imports CISData
Imports System.Web

Public Class AccessModel

    Public Function AuthLoginUsernamePassword(ByVal strUsername As String, ByVal strPassword As String) As Long
        Dim oData As New CISData.ProfileData
        Dim listProfile As New List(Of CISEntity.ProfileEntity)

        Dim STRWHERE As String = " USERNAME = '" + strUsername + "' AND PASSWORD = '" + strPassword + "' AND ISACTIVEFLG = 1 "
        STRWHERE = STRWHERE + " And PURGEFLG = 0 And ISAFFILIATEFLG = 1"

        listProfile = oData.GetList(STRWHERE)
        If Not IsNothing(listProfile) AndAlso listProfile.Count > 0 Then
            'username pasword matched

            Return listProfile(0).ProfileID
        Else
            Return Nothing
        End If

        Return Nothing

        oData = Nothing
        listProfile = Nothing

    End Function

    Public Sub GetUserProfileObjects(ByVal prflID As Long, ByRef oProfileEntity As CISEntity.ProfileEntity, ByRef oProfileObjectAccessEntity As List(Of CISEntity.ProfileObjectAccessEntity))
        Dim oData As New CISData.ProfileData
        Dim oProfileObjAccessData As New CISData.ProfileObjAccessData
        Dim strWhere As String = "PROFILEID='" + prflID.ToString + "' and PURGEFLG=0"

        oProfileEntity = oData.GetProfile(prflID)
        oProfileObjectAccessEntity = oProfileObjAccessData.GetList(strWhere)

        oData = Nothing
        oProfileObjAccessData = Nothing
    End Sub




End Class
