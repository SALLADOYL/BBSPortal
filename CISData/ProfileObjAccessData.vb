Option Strict On

Imports System.Collections.Generic
Imports CISEntity.ClientEntity
Imports System
Imports System.Data.SqlClient
Public Class ProfileObjAccessData

    Public Function SaveNew(ByRef cisProfileObjectAccessEntity As CISEntity.ProfileObjectAccessEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @CreateDate = GETDATE(); INSERT INTO [dbo].[PROFILEOBJACCESSTBL] "
        strSQL = strSQL + " ([PROFILEID] "
        strSQL = strSQL + " ,[OBJACCESSID] "
        strSQL = strSQL + " ,[ROLEID] "
        strSQL = strSQL + " ,[PURGEFLG]) "
        strSQL = strSQL + " VALUES ("
        strSQL = strSQL + "'" + cisProfileObjectAccessEntity.ProfileID.ToString + "'" '[ClientCode]
        strSQL = strSQL + ",'" + cisProfileObjectAccessEntity.ObjectAccessID.ToString + "'" ',[NAME]
        strSQL = strSQL + ",'" + cisProfileObjectAccessEntity.RoleID.ToString + "'" ',[ADDRESS]



        If cisProfileObjectAccessEntity.PurgeFlag Then
            strSQL = strSQL + ",1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",0" ',[PURGEFLG]
        End If
        'strSQL = strSQL + ",@CreateDate" ',[CRTDT]
        'strSQL = strSQL + ",'" + cisClient.CreatedBy.ToString + "'" ',[CRTBY]
        'strSQL = strSQL + ",@CreateDate" ',[UPDDT]
        'strSQL = strSQL + ",'" + cisClient.UpdatedBy.ToString + "'" ',[UPDBY]
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
        cisProfileObjectAccessEntity.ProfileObjectAccessID = CType(objParams(0).Value, Long)
        'cisClient.CreateDate = CType(objParams(1).Value, DateTime)
        'cisClient.UpdateDate = CType(objParams(1).Value, DateTime)

        Return True
    End Function


    Public Function Save(ByRef CISProfileObjectAccessEntity As CISEntity.ProfileObjectAccessEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[PROFILEOBJACCESSTBL] "
        strSQL = strSQL + "Set [PROFILEID] = '" + CISProfileObjectAccessEntity.ProfileID.ToString + "'"
        strSQL = strSQL + " ,[OBJACCESSID] = '" + CISProfileObjectAccessEntity.ObjectAccessID.ToString + "'"
        strSQL = strSQL + ",[ROLEID] = '" + CISProfileObjectAccessEntity.RoleID.ToString + "'"

        If CISProfileObjectAccessEntity.PurgeFlag Then
            strSQL = strSQL + ",[PURGEFLG]=1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",[PURGEFLG]=0" ',[PURGEFLG]
        End If
        strSQL = strSQL + "WHERE [PRFLOBJACCID]=" + CISProfileObjectAccessEntity.ProfileObjectAccessID.ToString

        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NewUpdateDate", SqlDbType.DateTime)
        objParams(0).Value = Now
        objParams(0).Direction = ParameterDirection.InputOutput


        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        'cisClient.UpdatedBy = prflID
        'cisClient.UpdateDate = CType(objParams(0).Value, Date)

        Return True
    End Function

    Public Function Purge(ByVal PRFLOBJACCID As Long, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[PROFILEOBJACCESSTBL] "
        strSQL = strSQL + "Set [PURGEFLG]=1" ',[PURGEFLG]
        strSQL = strSQL + "WHERE [PRFLOBJACCID]=" + PRFLOBJACCID.ToString

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

    Public Function Delete(ByVal PRFLOBJACCID As Long, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "DELETE FROM [dbo].[PROFILEOBJACCESSTBL] "
        strSQL = strSQL + "WHERE [PRFLOBJACCID]=" + PRFLOBJACCID.ToString

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

    Public Function GetClient(ByVal PRFLOBJACCID As Long) As CISEntity.ProfileObjectAccessEntity
        Dim objProfileObjectAccessEntity As New CISEntity.ProfileObjectAccessEntity
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        strSQL = "SELECT * FROM PROFILEOBJACCESSTBL" &
                " WHERE " &
                " [PRFLOBJACCID]=" & PRFLOBJACCID.ToString

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    With objProfileObjectAccessEntity
                        .ProfileObjectAccessID = CType(curRow("PURGEFLG"), Long) 'PRFLOBJACCID
                        .ProfileID = CType(curRow("PROFILEID"), Long) ',PROFILEID
                        .ObjectAccessID = CType(curRow("OBJACCESSID"), Long) ',OBJACCESSID
                        .RoleID = CType(curRow("ROLEID"), Long) ',ROLEID

                        If CType(curRow("PURGEFLG"), Integer) <> 0 Then ',PURGEFLG
                            .PurgeFlag = True
                        Else
                            .PurgeFlag = False
                        End If


                    End With

                Next
                Return objProfileObjectAccessEntity
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
    End Function

    Public Function GetProfileIDNameByRole(ByVal RoleID As Long) As DataTable
        Dim strSQL As String = ""

        strSQL &= " SELECT "
        strSQL &= " PROFILETBL.PROFILEID, PROFILETBL.NAME "
        strSQL &= " FROM "
        strSQL &= " PROFILEOBJACCESSTBL INNER JOIN"
        strSQL &= " PROFILETBL ON PROFILEOBJACCESSTBL.PROFILEID = PROFILETBL.PROFILEID INNER JOIN "
        strSQL &= " ROLETBL ON PROFILEOBJACCESSTBL.ROLEID = ROLETBL.ROLEID "
        strSQL &= " WHERE "
        strSQL &= " PROFILEOBJACCESSTBL.PURGEFLG = 0 "
        strSQL &= " AND ROLETBL.ISACTIVEFLG=1 AND ROLETBL.PURGEFLG=0 "
        strSQL &= " AND ROLETBL.ROLEID=" + RoleID.ToString


        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)
    End Function

    Public Function GetList(ByVal strWhereClause As String) As List(Of CISEntity.ProfileObjectAccessEntity)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing
        Dim listProfileObjectAccessEntity As New List(Of CISEntity.ProfileObjectAccessEntity)

        strSQL = "SELECT * FROM PROFILEOBJACCESSTBL" &
                " WHERE " & strWhereClause


        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    Dim objProfileObjectAccessEntity As New CISEntity.ProfileObjectAccessEntity
                    With objProfileObjectAccessEntity
                        .ProfileObjectAccessID = CType(curRow("PURGEFLG"), Long) 'PRFLOBJACCID
                        .ProfileID = CType(curRow("PROFILEID"), Long) ',PROFILEID
                        .ObjectAccessID = CType(curRow("OBJACCESSID"), Long) ',OBJACCESSID
                        .RoleID = CType(curRow("ROLEID"), Long) ',ROLEID

                        If CType(curRow("PURGEFLG"), Integer) <> 0 Then ',PURGEFLG
                            .PurgeFlag = True
                        Else
                            .PurgeFlag = False
                        End If

                    End With
                    listProfileObjectAccessEntity.Add(objProfileObjectAccessEntity)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
        Return listProfileObjectAccessEntity
    End Function

End Class
