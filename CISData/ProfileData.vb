Option Strict On

Imports System.Collections.Generic
Imports CISEntity.ClientEntity
Imports System
Imports System.Data.SqlClient
Public Class ProfileData
    Public Function SaveNewProfile(ByRef cisProfileEntity As CISEntity.ProfileEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @CreateDate = GETDATE(); INSERT INTO [dbo].[PROFILETBL] "
        strSQL = strSQL + " ([EMPLOYEECODE] "

        strSQL = strSQL + " ,[PHOTOURLPATH] " ',PHOTOURLPATH
        strSQL = strSQL + " ,[NAME] " ',NAME
        strSQL = strSQL + " ,[ADDRESS] " ',ADDRESS
        'strSQL = strSQL + " ,[DATEHIRED] " ',DATEHIRED
        strSQL = strSQL + " ,[FACULTYGROUP] " ',FACULTYGROUP
        strSQL = strSQL + " ,[DEPARTMENT] " ',DEPARTMENT
        strSQL = strSQL + " ,[STATUS] " ',STATUS
        strSQL = strSQL + " ,[USERNAME] " ',USERNAME
        strSQL = strSQL + " ,[PASSWORD] " ',PASSWORD
        strSQL = strSQL + " ,[WORKEMAIL] " ',WORKEMAIL
        strSQL = strSQL + " ,[MOBILEPHONE] " ',MOBILEPHONE
        strSQL = strSQL + " ,[EXTENSION] " ',EXTENSION
        strSQL = strSQL + " ,[BRANCH] " ',BRANCH
        strSQL = strSQL + " ,[DESIGNATION] " ',DESIGNATION
        strSQL = strSQL + " ,[ISAFFILIATEFLG] " ',ISAFFILIATEFLG
        strSQL = strSQL + " ,[ISACTIVEFLG] "
        strSQL = strSQL + " ,[PURGEFLG] "
        strSQL = strSQL + " ,[CRTDT] "
        strSQL = strSQL + " ,[CRTBY] "
        strSQL = strSQL + " ,[UPDDT] "
        strSQL = strSQL + " ,[UPDBY]) "
        strSQL = strSQL + " VALUES ("
        strSQL = strSQL + "'" + cisProfileEntity.EmployeeCode + "'"
        strSQL = strSQL + ",''" 'PhotoUrlPath
        strSQL = strSQL + ",'" + cisProfileEntity.Name + "'" ',NAME
        strSQL = strSQL + ",'" + cisProfileEntity.Address + "'" ',ADDRESS
        'strSQL = strSQL + ",'" + cisProfileEntity.DateHired.ToString + "'" ',DATEHIRED
        strSQL = strSQL + ",'" + cisProfileEntity.FacultyGroup + "'" ',FACULTYGROUP
        strSQL = strSQL + ",'" + cisProfileEntity.Department + "'" ',DEPARTMENT
        strSQL = strSQL + ",'" + cisProfileEntity.Status + "'" ',STATUS
        strSQL = strSQL + ",'" + cisProfileEntity.EmployeeCode + "'" ',USERNAME / BY DEFAULT THE EMPLOYEECODE WILL BE THE TEMPORARY USERNAME UPON CREATION
        strSQL = strSQL + ",'Passw0rd'" ',PASSWORD / upon creation, set default common password
        strSQL = strSQL + ",'" + cisProfileEntity.WorkEmail + "'" ',WORKEMAIL
        strSQL = strSQL + ",'" + cisProfileEntity.MobilePhone + "'" ',MOBILEPHONE
        strSQL = strSQL + ",'" + cisProfileEntity.Extension + "'" ',EXTENSION
        strSQL = strSQL + ",'" + cisProfileEntity.Branch + "'" ',BRANCH
        strSQL = strSQL + ",'" + cisProfileEntity.Designation + "'" ',DESIGNATION
        If cisProfileEntity.IsAffiliateFlag Then
            strSQL = strSQL + ",1" ',[ISAFFILIATEFLG]
        Else
            strSQL = strSQL + ",0" ',[ISAFFILIATEFLG]
        End If ',
        If cisProfileEntity.IsActiveFlag Then
            strSQL = strSQL + ",1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",0" ',[ISACTIVEFLG]
        End If

        If cisProfileEntity.PurgeFlag Then
            strSQL = strSQL + ",1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",@CreateDate" ',[CRTDT]
        strSQL = strSQL + ",'" + prflID.ToString + "'" ',[CRTBY]
        strSQL = strSQL + ",@CreateDate" ',[UPDDT]
        strSQL = strSQL + ",'" + prflID.ToString + "'" ',[UPDBY]
        strSQL = strSQL & "); SET @NewID = SCOPE_IDENTITY();"

        Dim objParams(1) As SqlParameter
        objParams(0) = New SqlParameter("@NewID", SqlDbType.BigInt)
        objParams(0).Value = 0
        objParams(0).Direction = ParameterDirection.InputOutput
        objParams(1) = New SqlParameter("@CreateDate", SqlDbType.DateTime)
        objParams(1).Value = Now
        objParams(1).Direction = ParameterDirection.InputOutput


        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        ''retrieve new id
        cisProfileEntity.ProfileID = CType(objParams(0).Value, Long)
        cisProfileEntity.CreateDate = CType(objParams(1).Value, DateTime)
        cisProfileEntity.UpdateDate = CType(objParams(1).Value, DateTime)

        Return True
    End Function

    Public Function SaveProfile(ByRef cisProfileEntity As CISEntity.ProfileEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[PROFILETBL] "
        strSQL = strSQL + "Set [EMPLOYEECODE] = '" + cisProfileEntity.EmployeeCode + "'"
        'strSQL = strSQL + " ,[PHOTOURLPATH] = '" + cisProfileEntity.PhotoUrlPath + "'" ',PHOTOURLPATH
        strSQL = strSQL + " ,[NAME] = '" + cisProfileEntity.Name + "'" ',NAME
        strSQL = strSQL + " ,[ADDRESS] = '" + cisProfileEntity.Address + "'" ',ADDRESS
        'strSQL = strSQL + " ,[DATEHIRED] = '" + cisProfileEntity.DateHired.ToString + "'" ',DATEHIRED
        strSQL = strSQL + " ,[FACULTYGROUP] = '" + cisProfileEntity.FacultyGroup + "'" ',FACULTYGROUP
        strSQL = strSQL + " ,[DEPARTMENT] = '" + cisProfileEntity.Department + "'" ',DEPARTMENT
        strSQL = strSQL + " ,[STATUS] = '" + cisProfileEntity.Status + "'" ',STATUS
        'strSQL = strSQL + " ,[USERNAME] = '" + cisProfileEntity.UserName + "'" ',USERNAME
        'strSQL = strSQL + " ,[PASSWORD] = '" + cisProfileEntity.Password + "'" ',PASSWORD
        strSQL = strSQL + " ,[WORKEMAIL] = '" + cisProfileEntity.WorkEmail + "'" ',WORKEMAIL
        strSQL = strSQL + " ,[MOBILEPHONE] = '" + cisProfileEntity.MobilePhone + "'" ',MOBILEPHONE
        strSQL = strSQL + " ,[EXTENSION] = '" + cisProfileEntity.Extension + "'" ',EXTENSION
        strSQL = strSQL + " ,[BRANCH] = '" + cisProfileEntity.Branch + "'" ',BRANCH
        strSQL = strSQL + " ,[DESIGNATION] = '" + cisProfileEntity.Designation + "'" ',DESIGNATION
        If cisProfileEntity.IsAffiliateFlag Then
            strSQL = strSQL + " ,[ISAFFILIATEFLG]=1" ',[ISAFFILIATEFLG]
        Else
            strSQL = strSQL + " ,[ISAFFILIATEFLG]=0" ',[ISAFFILIATEFLG]
        End If ',ISAFFILIATEFLG

        If cisProfileEntity.IsActiveFlag Then
            strSQL = strSQL + " ,[ISACTIVEFLG]=1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + " ,[ISACTIVEFLG]=0" ',[ISACTIVEFLG]
        End If
        If cisProfileEntity.PurgeFlag Then
            strSQL = strSQL + " ,[PURGEFLG]=1" ',[PURGEFLG]
        Else
            strSQL = strSQL + " ,[PURGEFLG]=0" ',[PURGEFLG]
        End If
        strSQL = strSQL + " ,[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + " ,[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + " WHERE [PROFILEID]=" + cisProfileEntity.ProfileID.ToString

        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NewUpdateDate", SqlDbType.DateTime)
        objParams(0).Value = Now
        objParams(0).Direction = ParameterDirection.InputOutput


        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        cisProfileEntity.UpdatedBy = prflID
        cisProfileEntity.UpdateDate = CType(objParams(0).Value, Date)

        Return True
    End Function

    Public Function SaveProfilePhoto(ByVal ProfileID As Long, ByVal WebSavedImage As String, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[PROFILETBL] "
        strSQL = strSQL + "Set [PHOTOURLPATH]='" + WebSavedImage + "'" ',[PHOTOURLPATH]
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [PROFILEID]=" + ProfileID.ToString

        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NewUpdateDate", SqlDbType.DateTime)
        objParams(0).Value = Now
        objParams(0).Direction = ParameterDirection.InputOutput

        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        Return True
    End Function

    Public Function SaveProfileUsrnamePwd(ByVal ProfileID As Long, ByVal usrName As String, ByVal pwd As String, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[PROFILETBL] "
        strSQL = strSQL + "Set [USERNAME]='" + usrName + "'" ',[USERNAME]
        strSQL = strSQL + ",[PASSWORD] = '" + pwd + "'" '[PASSWORD]
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [PROFILEID]=" + ProfileID.ToString

        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NewUpdateDate", SqlDbType.DateTime)
        objParams(0).Value = Now
        objParams(0).Direction = ParameterDirection.InputOutput

        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        Return True
    End Function

    Public Function PurgeProfile(ByVal ProfileID As Long, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[PROFILETBL] "
        strSQL = strSQL + "Set [PURGEFLG]=1" ',[PURGEFLG]
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [PROFILEID]=" + ProfileID.ToString

        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NewUpdateDate", SqlDbType.DateTime)
        objParams(0).Value = Now
        objParams(0).Direction = ParameterDirection.InputOutput


        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        Return True
    End Function

    Public Function GetProfileName(ByVal ProfileID As Long) As String
        Return GetProfile(ProfileID).Name

    End Function

    Public Function GetProfile(ByVal ProfileID As Long) As CISEntity.ProfileEntity
        Dim objProfileEntity As New CISEntity.ProfileEntity
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        strSQL = "SELECT * FROM PROFILETBL" &
                " WHERE " &
                " [ProfileID]=" & ProfileID.ToString

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    With objProfileEntity
                        '.ClientID = CType(curRow("ClientID"), Long)
                        '.ClientCode = CType(curRow("CLIENTCODE"), String) ',CLIENTCODE
                        .ProfileID = CType(curRow("ProfileID"), Long) 'ProfileID
                        .EmployeeCode = CType(curRow("EMPLOYEECODE"), String)  ',EMPLOYEECODE
                        .PhotoUrlPath = CType(curRow("PHOTOURLPATH"), String) ',PHOTOURLPATH
                        .Name = CType(curRow("NAME"), String) ',NAME
                        .Address = CType(curRow("ADDRESS"), String) ',ADDRESS
                        ' .DateHired = CType(curRow("DATEHIRED"), DateTime) ',DATEHIRED
                        .FacultyGroup = CType(curRow("FACULTYGROUP"), String) ',FACULTYGROUP
                        .Department = CType(curRow("DEPARTMENT"), String) ',DEPARTMENT
                        .Status = CType(curRow("STATUS"), String) ',STATUS
                        .UserName = CType(curRow("USERNAME"), String) ',USERNAME
                        .Password = CType(curRow("PASSWORD"), String) ',PASSWORD
                        .WorkEmail = CType(curRow("WORKEMAIL"), String) ',WORKEMAIL
                        .MobilePhone = CType(curRow("MOBILEPHONE"), String) ',MOBILEPHONE
                        .Extension = CType(curRow("EXTENSION"), String) ',EXTENSION
                        .Branch = CType(curRow("BRANCH"), String) ',BRANCH
                        .Designation = CType(curRow("DESIGNATION"), String) ',DESIGNATION
                        If CType(curRow("ISAFFILIATEFLG"), Integer) <> 0 Then ',ISAFFILIATEFLG
                            .IsAffiliateFlag = True
                        Else
                            .IsAffiliateFlag = False
                        End If  ',ISAFFILIATEFLG

                        If CType(curRow("ISACTIVEFLG"), Integer) <> 0 Then ',ISACTIVEFLG
                            .IsActiveFlag = True
                        Else
                            .IsActiveFlag = False
                        End If

                        If CType(curRow("PURGEFLG"), Integer) <> 0 Then ',PURGEFLG
                            .PurgeFlag = True
                        Else
                            .PurgeFlag = False
                        End If
                        .CreateDate = CType(curRow("CRTDT"), DateTime) ',CRTDT
                        .CreatedBy = CType(curRow("CRTBY"), Long) ',CRTBY
                        .UpdateDate = CType(curRow("UPDDT"), DateTime) ',UPDDT
                        .UpdatedBy = CType(curRow("UPDBY"), Long) ',UPDBY
                        '. = CType(curRow("TMPSTMP"), String) ',TMPSTMP

                    End With

                Next
                Return objProfileEntity
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
    End Function

    Public Function GetEmployeesListWithBlank() As List(Of CISEntity.ProfileEntity)
        Dim entListProfiles As New List(Of CISEntity.ProfileEntity)
        Dim dataProfile As New CISData.ProfileData
        Dim BLANKProfile As New CISEntity.ProfileEntity
        BLANKProfile.ProfileID = 0
        BLANKProfile.Name = ""
        entListProfiles.Add(BLANKProfile)
        entListProfiles.AddRange(dataProfile.GetList("[ISACTIVEFLG] = 1 AND [PURGEFLG]=0 AND [ISAFFILIATEFLG]=1"))
        Return entListProfiles
    End Function

    Public Function GetList(ByVal strWhereClause As String) As List(Of CISEntity.ProfileEntity)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing
        Dim objList As New List(Of CISEntity.ProfileEntity)

        strSQL = "SELECT * FROM PROFILETBL" &
                " WHERE " & strWhereClause


        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    Dim objProfileEntity As New CISEntity.ProfileEntity
                    With objProfileEntity
                        '.ClientID = CType(curRow("ClientID"), Long)
                        '.ClientCode = CType(curRow("CLIENTCODE"), String) ',CLIENTCODE
                        .ProfileID = CType(curRow("ProfileID"), Long) 'ProfileID
                        .EmployeeCode = CType(curRow("EMPLOYEECODE"), String)  ',EMPLOYEECODE
                        .PhotoUrlPath = CType(curRow("PHOTOURLPATH"), String) ',PHOTOURLPATH
                        .Name = CType(curRow("NAME"), String) ',NAME
                        .Address = CType(curRow("ADDRESS"), String) ',ADDRESS
                        '.DateHired = CType(curRow("DATEHIRED"), DateTime) ',DATEHIRED
                        .FacultyGroup = CType(curRow("FACULTYGROUP"), String) ',FACULTYGROUP
                        .Department = CType(curRow("DEPARTMENT"), String) ',DEPARTMENT
                        .Status = CType(curRow("STATUS"), String) ',STATUS
                        .UserName = CType(curRow("USERNAME"), String) ',USERNAME
                        .Password = CType(curRow("PASSWORD"), String) ',PASSWORD
                        .WorkEmail = CType(curRow("WORKEMAIL"), String) ',WORKEMAIL
                        .MobilePhone = CType(curRow("MOBILEPHONE"), String) ',MOBILEPHONE
                        .Extension = CType(curRow("EXTENSION"), String) ',EXTENSION
                        .Branch = CType(curRow("BRANCH"), String) ',BRANCH
                        .Designation = CType(curRow("DESIGNATION"), String) ',DESIGNATION
                        If CType(curRow("ISAFFILIATEFLG"), Integer) <> 0 Then ',ISAFFILIATEFLG
                            .IsAffiliateFlag = True
                        Else
                            .IsAffiliateFlag = False
                        End If  ',ISAFFILIATEFLG

                        If CType(curRow("ISACTIVEFLG"), Integer) <> 0 Then ',ISACTIVEFLG
                            .IsActiveFlag = True
                        Else
                            .IsActiveFlag = False
                        End If

                        If CType(curRow("PURGEFLG"), Integer) <> 0 Then ',PURGEFLG
                            .PurgeFlag = True
                        Else
                            .PurgeFlag = False
                        End If
                        .CreateDate = CType(curRow("CRTDT"), DateTime) ',CRTDT
                        .CreatedBy = CType(curRow("CRTBY"), Long) ',CRTBY
                        .UpdateDate = CType(curRow("UPDDT"), DateTime) ',UPDDT
                        .UpdatedBy = CType(curRow("UPDBY"), Long) ',UPDBY
                        '. = CType(curRow("TMPSTMP"), String) ',TMPSTMP

                    End With
                    objList.Add(objProfileEntity)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
        Return objList
    End Function
End Class
