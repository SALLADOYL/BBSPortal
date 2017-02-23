Option Strict On

Imports System.Collections.Generic
Imports CISEntity.ClientEntity
Imports System
Imports System.Data.SqlClient
Public Class ServiceData
    Public Function SaveNewService(ByRef cisService As CISEntity.ServiceEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @CreateDate = GETDATE(); INSERT INTO [dbo].[SERVICETBL] "
        strSQL = strSQL + " ([SERVIENAME] " ',SERVIENAME
        strSQL = strSQL + ",SVCPERMALINK "
        strSQL = strSQL + ",SVCDESC "
        strSQL = strSQL + ",ISACTIVEFLG"
        strSQL = strSQL + " ,PURGEFLG"
        strSQL = strSQL + ",CRTDT"
        strSQL = strSQL + ",CRTBY"
        strSQL = strSQL + ",UPDDT"
        strSQL = strSQL + ",UPDBY)"
        strSQL = strSQL + " VALUES ("
        strSQL = strSQL + "'" + cisService.ServiceName + "'" '[SERVIENAME]

        strSQL = strSQL + ",'" + cisService.ServicePermalink + "'" ',[SVCPERMALINK]
        strSQL = strSQL + ",'" + cisService.ServiceDescription + "'" ',[SVCPERMALINK]
        If cisService.IsActiveFlag Then
            strSQL = strSQL + ",1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",0" ',[ISACTIVEFLG]
        End If

        If cisService.PurgeFlag Then
            strSQL = strSQL + ",1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",@CreateDate" ',[CRTDT]
        strSQL = strSQL + ",'" + cisService.CreatedBy.ToString + "'" ',[CRTBY]
        strSQL = strSQL + ",@CreateDate" ',[UPDDT]
        strSQL = strSQL + ",'" + cisService.UpdatedBy.ToString + "'" ',[UPDBY]
        strSQL = strSQL & "); SET @NewServiceID = SCOPE_IDENTITY() ;"

        Dim objParams(1) As SqlParameter
        objParams(0) = New SqlParameter("@NewServiceID", SqlDbType.BigInt)
        objParams(0).Value = 0
        objParams(0).Direction = ParameterDirection.InputOutput
        objParams(1) = New SqlParameter("@CreateDate", SqlDbType.DateTime)
        objParams(1).Value = Now
        objParams(1).Direction = ParameterDirection.InputOutput


        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        ''retrieve new ServiceID
        cisService.ServiceID = CType(objParams(0).Value, Long)
        cisService.CreateDate = CType(objParams(1).Value, DateTime)
        cisService.UpdateDate = CType(objParams(1).Value, DateTime)

        Return True
    End Function

    Public Function SaveService(ByRef cisService As CISEntity.ServiceEntity, ByVal prflID As Long) As Boolean
        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[SERVICETBL] "
        strSQL = strSQL + "Set [SERVIENAME] = '" + cisService.ServiceName + "'"
        strSQL = strSQL + " ,[SVCPERMALINK] = '" + cisService.ServicePermalink + "'"
        strSQL = strSQL + " ,[SVCDESC] = '" + cisService.ServiceDescription + "'"

        If cisService.IsActiveFlag Then
            strSQL = strSQL + ",[ISACTIVEFLG]=1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",[ISACTIVEFLG]=0" ',[ISACTIVEFLG]
        End If
        If cisService.PurgeFlag Then
            strSQL = strSQL + ",[PURGEFLG]=1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",[PURGEFLG]=0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [SVCID]=" + cisService.ServiceID.ToString

        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NewUpdateDate", SqlDbType.DateTime)
        objParams(0).Value = Now
        objParams(0).Direction = ParameterDirection.InputOutput


        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        cisService.UpdatedBy = prflID
        cisService.UpdateDate = CType(objParams(0).Value, Date)

        Return True
    End Function

    Public Function PurgeService(ByVal ServiceID As Long, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[SERVICETBL] "
        strSQL = strSQL + "Set [PURGEFLG]=1" ',[PURGEFLG]
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [SVCID]=" + ServiceID.ToString

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

    Public Function GetService(ByVal ServiceID As Long) As CISEntity.ServiceEntity
        Dim objServiceEntity As New CISEntity.ServiceEntity
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        strSQL = "SELECT * FROM SERVICETBL" &
                " WHERE " &
                " [SVCID]=" & ServiceID.ToString

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    With objServiceEntity
                        .ServiceID = CType(curRow("SVCID"), Long)
                        .ServiceName = CType(curRow("SERVIENAME"), String)
                        .ServicePermalink = CType(curRow("SVCPERMALINK"), String)
                        .ServiceDescription = CType(curRow("SVCDESC"), String)
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
                        '.TimeStamp = CType(curRow("TMPSTMP"), String) ',TMPSTMP

                    End With

                Next
                Return objServiceEntity
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
    End Function

    Public Function GetServiceListWithBlank(ByVal strWhere As String) As DataTable
        Dim strSQL As String
        strSQL = "SELECT '' AS SERVICENAME, 0 AS SERVICEID "
        strSQL = strSQL + " UNION SELECT "
        strSQL = strSQL + " SERVIENAME AS SERVICENAME, SVCID as SERVICEID "
        strSQL = strSQL + " FROM SERVICETBL "
        strSQL = strSQL + " WHERE " + strWhere


        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function


    Public Function GetServiceList(ByVal strWhereClause As String) As List(Of CISEntity.ServiceEntity)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing
        Dim objServiceEntityList As New List(Of CISEntity.ServiceEntity)

        strSQL = "SELECT * FROM SERVICETBL" &
                " WHERE " & strWhereClause

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    Dim objServiceEntity As New CISEntity.ServiceEntity
                    With objServiceEntity
                        .ServiceID = CType(curRow("SVCID"), Long)
                        .ServiceName = CType(curRow("SERVIENAME"), String)
                        .ServicePermalink = CType(curRow("SVCPERMALINK"), String)
                        .ServiceDescription = CType(curRow("SVCDESC"), String)
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
                    End With
                    objServiceEntityList.Add(objServiceEntity)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
        Return objServiceEntityList
    End Function
End Class
