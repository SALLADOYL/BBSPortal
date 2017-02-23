Option Strict On

Imports System.Collections.Generic
Imports CISEntity.ClientEntity
Imports System
Imports System.Data.SqlClient
Public Class TechReportData

    Public Function SaveNew(ByRef cisTechnicalReportEntity As CISEntity.TechnicalReportEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @CreateDate = GETDATE(); INSERT INTO [dbo].[TECHREPORTTBL] "
        strSQL = strSQL + " ([TSWORKID] "
        strSQL = strSQL + " ,[TEAM] "
        strSQL = strSQL + " ,[PERFORMEDBY] "
        strSQL = strSQL + " ,[SEARCHTAGS] "
        strSQL = strSQL + " ,[INVESTIGATIONDETAILS] "
        strSQL = strSQL + " ,[ISSUECAUSE] "
        strSQL = strSQL + " ,[RESOLUTIONDETAILS] "
        strSQL = strSQL + " ,[PROPOSEDDETAILS] "
        strSQL = strSQL + " ,[CLIENTSVCID] " ',CLIENTSVCID
        strSQL = strSQL + " ,[STATUS] " ',STATUS
        strSQL = strSQL + " ,[STARTDT] " ',STARTDT
        strSQL = strSQL + " ,[COMPLETEDT] " ',COMPLETEDT
        strSQL = strSQL + " ,[REMARKS] "
        strSQL = strSQL + " ,[ISACTIVEFLG] "
        strSQL = strSQL + " ,[PURGEFLG] "
        strSQL = strSQL + " ,[CRTDT] "
        strSQL = strSQL + " ,[CRTBY] "
        strSQL = strSQL + " ,[UPDDT] "
        strSQL = strSQL + " ,[UPDBY]) "
        strSQL = strSQL + " VALUES ("
        strSQL = strSQL + "'" + cisTechnicalReportEntity.TSWorkID.ToString + "'" '[]
        strSQL = strSQL + ",'" + cisTechnicalReportEntity.Team + "'" ',[]
        strSQL = strSQL + ",'" + cisTechnicalReportEntity.PerformedBy.ToString + "'" ',[]
        strSQL = strSQL + ",'" + cisTechnicalReportEntity.SearchTags + "'" ',[]
        strSQL = strSQL + ",'" + cisTechnicalReportEntity.InvestigationDetails + "'" ',[]
        strSQL = strSQL + ",'" + cisTechnicalReportEntity.IssueCause + "'" ',[]
        strSQL = strSQL + ",'" + cisTechnicalReportEntity.ResolutionDetails + "'" ',[]
        strSQL = strSQL + ",'" + cisTechnicalReportEntity.ProposedDetails + "'" ',[]
        strSQL = strSQL + ",'" + cisTechnicalReportEntity.ClientServiceID.ToString + "'" ',[CLIENTSVCID]
        strSQL = strSQL + ",'" + cisTechnicalReportEntity.Status + "'" ',[STATUS]
        strSQL = strSQL + ",'" + cisTechnicalReportEntity.StartDate.ToString + "'" ',[STARTDT]
        strSQL = strSQL + ",'" + cisTechnicalReportEntity.CompletionDate.ToString + "'" ',[COMPLETEDT]
        If cisTechnicalReportEntity.IsActiveFlag Then
            strSQL = strSQL + ",1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",0" ',[ISACTIVEFLG]
        End If

        If cisTechnicalReportEntity.PurgeFlag Then
            strSQL = strSQL + ",1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",@CreateDate" ',[CRTDT]
        strSQL = strSQL + ",'" + cisTechnicalReportEntity.CreatedBy.ToString + "'" ',[CRTBY]
        strSQL = strSQL + ",@CreateDate" ',[UPDDT]
        strSQL = strSQL + ",'" + cisTechnicalReportEntity.UpdatedBy.ToString + "'" ',[UPDBY]
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
        cisTechnicalReportEntity.TechnicalReportID = CType(objParams(0).Value, Long)
        cisTechnicalReportEntity.CreateDate = CType(objParams(1).Value, DateTime)
        cisTechnicalReportEntity.UpdateDate = CType(objParams(1).Value, DateTime)

        Return True
    End Function

    Public Function Save(ByRef cisTechnicalReportEntity As CISEntity.TechnicalReportEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[TECHREPORTTBL] "
        strSQL = strSQL + "Set [TSWORKID] = '" + cisTechnicalReportEntity.TSWorkID.ToString + "'"
        strSQL = strSQL + " ,[TEAM] = '" + cisTechnicalReportEntity.Team + "'"
        strSQL = strSQL + ",[PERFORMEDBY] = '" + cisTechnicalReportEntity.PerformedBy.ToString + "'"
        strSQL = strSQL + ",[SEARCHTAGS] = '" + cisTechnicalReportEntity.SearchTags + "'"
        strSQL = strSQL + ",[INVESTIGATIONDETAILS] = '" + cisTechnicalReportEntity.InvestigationDetails + "'"
        strSQL = strSQL + ",[ISSUECAUSE] = '" + cisTechnicalReportEntity.IssueCause + "'"
        strSQL = strSQL + ",[RESOLUTIONDETAILS] = '" + cisTechnicalReportEntity.ResolutionDetails + "'"
        strSQL = strSQL + ",[PROPOSEDDETAILS] = '" + cisTechnicalReportEntity.ProposedDetails + "'"
        strSQL = strSQL + ",[CLIENTSVCID] = '" + cisTechnicalReportEntity.ClientServiceID.ToString + "'"
        strSQL = strSQL + ",[STATUS] = '" + cisTechnicalReportEntity.Status + "'"
        strSQL = strSQL + ",[STARTDT] = '" + cisTechnicalReportEntity.StartDate.ToString + "'"
        strSQL = strSQL + ",[COMPLETEDT] = '" + cisTechnicalReportEntity.CompletionDate.ToString + "'"
        strSQL = strSQL + ",[REMARKS] = '" + cisTechnicalReportEntity.Remarks + "'"
        If cisTechnicalReportEntity.IsActiveFlag Then
            strSQL = strSQL + ",[ISACTIVEFLG]=1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",[ISACTIVEFLG]=0" ',[ISACTIVEFLG]
        End If
        If cisTechnicalReportEntity.PurgeFlag Then
            strSQL = strSQL + ",[PURGEFLG]=1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",[PURGEFLG]=0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [TECHREPID]=" + cisTechnicalReportEntity.TechnicalReportID.ToString

        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NewUpdateDate", SqlDbType.DateTime)
        objParams(0).Value = Now
        objParams(0).Direction = ParameterDirection.InputOutput


        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        cisTechnicalReportEntity.UpdatedBy = prflID
        cisTechnicalReportEntity.UpdateDate = CType(objParams(0).Value, Date)

        Return True
    End Function

    Public Function Purge(ByVal TECHREPID As Long, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[TECHREPORTTBL] "
        strSQL = strSQL + "Set [PURGEFLG]=1" ',[PURGEFLG]
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [TECHREPID]=" + TECHREPID.ToString

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

    Public Function GetTechnicalReportEntity(ByVal TRID As Long) As CISEntity.TechnicalReportEntity
        Dim objTechnicalReportEntity As New CISEntity.TechnicalReportEntity
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        strSQL = "SELECT * FROM TECHREPORTTBL" &
                " WHERE " &
                " [TECHREPID]=" & TRID.ToString

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    With objTechnicalReportEntity

                        .TechnicalReportID = CType(curRow("TECHREPID"), Long)
                        .ClientServiceID = CType(curRow("CLIENTSVCID"), Long) ',CLIENTSVCID
                        .TSWorkID = CType(curRow("TSWORKID"), Long) ',TSWORKID
                        .Team = CType(curRow("TEAM"), String) ',TEAM
                        .PerformedBy = CType(curRow("PERFORMEDBY"), Long) ',PERFORMEDBY
                        .SearchTags = CType(curRow("SEARCHTAGS"), String) ',SEARCHTAGS
                        .InvestigationDetails = CType(curRow("INVESTIGATIONDETAILS"), String)  ',INVESTIGATIONDETAILS
                        .IssueCause = CType(curRow("ISSUECAUSE"), String) ',ISSUECAUSE
                        .ResolutionDetails = CType(curRow("RESOLUTIONDETAILS"), String) ',RESOLUTIONDETAILS
                        .ProposedDetails = CType(curRow("PROPOSEDDETAILS"), String) ',PROPOSEDDETAILS
                        .Status = CType(curRow("STATUS"), String) ',STATUS
                        .StartDate = CType(curRow("STARTDT"), DateTime) ',STARTDT
                        .CompletionDate = CType(curRow("COMPLETEDT"), DateTime) ',COMPLETEDT
                        .Remarks = CType(curRow("REMARKS"), String) ',REMARKS
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
                Return objTechnicalReportEntity
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
    End Function

    Public Function GetList(ByVal strWhereClause As String) As List(Of CISEntity.TechnicalReportEntity)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing
        Dim listTechnicalReportEntity As New List(Of CISEntity.TechnicalReportEntity)

        strSQL = "SELECT * FROM TECHREPORTTBL" &
                " WHERE " & strWhereClause


        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    Dim objTechnicalReportEntity As New CISEntity.TechnicalReportEntity
                    With objTechnicalReportEntity
                        .TechnicalReportID = CType(curRow("TECHREPID"), Long)
                        .ClientServiceID = CType(curRow("CLIENTSVCID"), Long) ',CLIENTSVCID
                        .TSWorkID = CType(curRow("TSWORKID"), Long) ',TSWORKID
                        .Team = CType(curRow("TEAM"), String) ',TEAM
                        .PerformedBy = CType(curRow("PERFORMEDBY"), Long) ',PERFORMEDBY
                        .SearchTags = CType(curRow("SEARCHTAGS"), String) ',SEARCHTAGS
                        .InvestigationDetails = CType(curRow("INVESTIGATIONDETAILS"), String)  ',INVESTIGATIONDETAILS
                        .IssueCause = CType(curRow("ISSUECAUSE"), String) ',ISSUECAUSE
                        .ResolutionDetails = CType(curRow("RESOLUTIONDETAILS"), String) ',RESOLUTIONDETAILS
                        .ProposedDetails = CType(curRow("PROPOSEDDETAILS"), String) ',PROPOSEDDETAILS

                        .Status = CType(curRow("STATUS"), String) ',STATUS
                        .StartDate = CType(curRow("STARTDT"), DateTime) ',STARTDT
                        .CompletionDate = CType(curRow("COMPLETEDT"), DateTime) ',COMPLETEDT
                        .Remarks = CType(curRow("REMARKS"), String) ',REMARKS
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
                    listTechnicalReportEntity.Add(objTechnicalReportEntity)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
        Return listTechnicalReportEntity
    End Function
    Public Function SearchTRbyStartDateRange(ByVal fromDT As Date, ByVal ToDT As Date) As DataTable
        Dim strSQL As String

        strSQL = " SELECT "
        strSQL = strSQL + " TECHREPORTTBL.TECHREPID, CLIENTTBL.NAME AS CLIENTNAME,  "
        strSQL = strSQL + " SERVICETBL.SERVIENAME AS SERVICENAME, TECHREPORTTBL.STATUS AS TRSTATUS "
        strSQL = strSQL + " , TSWORKTBL.PONUMBER, TECHREPORTTBL.STARTDT, TECHREPORTTBL.TEAM AS TRTEAM "
        strSQL = strSQL + " FROM "
        strSQL = strSQL + " TECHREPORTTBL INNER JOIN SERVICETBL "
        strSQL = strSQL + " INNER JOIN CLIENTSERVICETBL INNER JOIN "
        strSQL = strSQL + " CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID ON SERVICETBL.SVCID = CLIENTSERVICETBL.SVCID ON "
        strSQL = strSQL + " TECHREPORTTBL.CLIENTSVCID = CLIENTSERVICETBL.CLIENTSVCID LEFT OUTER JOIN "
        strSQL = strSQL + " TSWORKTBL ON TECHREPORTTBL.TSWORKID = TSWORKTBL.TSWORKID "
        strSQL = strSQL + " WHERE TECHREPORTTBL.STARTDT BETWEEN '" + fromDT.ToShortDateString + "' AND '" + ToDT.ToShortDateString + "'"

        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function

    Public Function SearchTRbyCompletedDateRange(ByVal fromDT As Date, ByVal ToDT As Date) As DataTable
        Dim strSQL As String

        strSQL = " SELECT "
        strSQL = strSQL + " TECHREPORTTBL.TECHREPID, CLIENTTBL.NAME AS CLIENTNAME,  "
        strSQL = strSQL + " SERVICETBL.SERVIENAME AS SERVICENAME, TECHREPORTTBL.STATUS AS TRSTATUS "
        strSQL = strSQL + " , TSWORKTBL.PONUMBER, TECHREPORTTBL.STARTDT, TECHREPORTTBL.TEAM AS TRTEAM "
        strSQL = strSQL + " FROM "
        strSQL = strSQL + " TECHREPORTTBL INNER JOIN SERVICETBL "
        strSQL = strSQL + " INNER JOIN CLIENTSERVICETBL INNER JOIN "
        strSQL = strSQL + " CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID ON SERVICETBL.SVCID = CLIENTSERVICETBL.SVCID ON "
        strSQL = strSQL + " TECHREPORTTBL.CLIENTSVCID = CLIENTSERVICETBL.CLIENTSVCID LEFT OUTER JOIN "
        strSQL = strSQL + " TSWORKTBL ON TECHREPORTTBL.TSWORKID = TSWORKTBL.TSWORKID "
        strSQL = strSQL + " WHERE TECHREPORTTBL.COMPLETEDT BETWEEN '" + fromDT.ToShortDateString + "' AND '" + ToDT.ToShortDateString + "'"

        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function

    Public Function SearchTRbyStatus(ByVal TRStatus As String) As DataTable
        Dim strSQL As String

        strSQL = " SELECT "
        strSQL = strSQL + " TECHREPORTTBL.TECHREPID, CLIENTTBL.NAME AS CLIENTNAME,  "
        strSQL = strSQL + " SERVICETBL.SERVIENAME AS SERVICENAME, TECHREPORTTBL.STATUS AS TRSTATUS "
        strSQL = strSQL + " , TSWORKTBL.PONUMBER, TECHREPORTTBL.STARTDT, TECHREPORTTBL.TEAM AS TRTEAM "
        strSQL = strSQL + " FROM "
        strSQL = strSQL + " TECHREPORTTBL INNER JOIN SERVICETBL "
        strSQL = strSQL + " INNER JOIN CLIENTSERVICETBL INNER JOIN "
        strSQL = strSQL + " CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID ON SERVICETBL.SVCID = CLIENTSERVICETBL.SVCID ON "
        strSQL = strSQL + " TECHREPORTTBL.CLIENTSVCID = CLIENTSERVICETBL.CLIENTSVCID LEFT OUTER JOIN "
        strSQL = strSQL + " TSWORKTBL ON TECHREPORTTBL.TSWORKID = TSWORKTBL.TSWORKID "
        strSQL = strSQL + " WHERE TECHREPORTTBL.STATUS = '" + TRStatus + "'"

        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function

    Public Function SearchTRbyTeam(ByVal TRTeam As String) As DataTable
        Dim strSQL As String

        strSQL = " SELECT "
        strSQL = strSQL + " TECHREPORTTBL.TECHREPID, CLIENTTBL.NAME AS CLIENTNAME,  "
        strSQL = strSQL + " SERVICETBL.SERVIENAME AS SERVICENAME, TECHREPORTTBL.STATUS AS TRSTATUS "
        strSQL = strSQL + " , TSWORKTBL.PONUMBER, TECHREPORTTBL.STARTDT , TECHREPORTTBL.TEAM AS TRTEAM"
        strSQL = strSQL + " FROM "
        strSQL = strSQL + " TECHREPORTTBL INNER JOIN SERVICETBL "
        strSQL = strSQL + " INNER JOIN CLIENTSERVICETBL INNER JOIN "
        strSQL = strSQL + " CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID ON SERVICETBL.SVCID = CLIENTSERVICETBL.SVCID ON "
        strSQL = strSQL + " TECHREPORTTBL.CLIENTSVCID = CLIENTSERVICETBL.CLIENTSVCID LEFT OUTER JOIN "
        strSQL = strSQL + " TSWORKTBL ON TECHREPORTTBL.TSWORKID = TSWORKTBL.TSWORKID "
        strSQL = strSQL + " WHERE TECHREPORTTBL.TEAM = '" + TRTeam + "'"

        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function

    Public Function SearchTRbyClientService(ByVal ClientID As Long, ByVal ServiceID As Long) As DataTable

        Dim strSQL As String

        '--SELECT
        '--TECHREPORTTBL.TECHREPID, CLIENTTBL.NAME AS CLIENTNAME, 
        '--SERVICETBL.SERVIENAME AS SERVICENAME, TECHREPORTTBL.STATUS AS TRSTATUS
        '--, TSWORKTBL.PONUMBER, TECHREPORTTBL.STARTDT
        '--FROM 
        '--TECHREPORTTBL INNER JOIN SERVICETBL 
        '--INNER JOIN CLIENTSERVICETBL INNER JOIN
        '--CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID ON SERVICETBL.SVCID = CLIENTSERVICETBL.SVCID ON 
        '--TECHREPORTTBL.CLIENTSVCID = CLIENTSERVICETBL.CLIENTSVCID LEFT OUTER JOIN
        '--TSWORKTBL ON TECHREPORTTBL.TSWORKID = TSWORKTBL.TSWORKID

        strSQL = " SELECT "
        strSQL = strSQL + " TECHREPORTTBL.TECHREPID, CLIENTTBL.NAME AS CLIENTNAME,  "
        strSQL = strSQL + " SERVICETBL.SERVIENAME AS SERVICENAME, TECHREPORTTBL.STATUS AS TRSTATUS "
        strSQL = strSQL + " , TSWORKTBL.PONUMBER, TECHREPORTTBL.STARTDT , TECHREPORTTBL.TEAM AS TRTEAM"
        strSQL = strSQL + " FROM "
        strSQL = strSQL + " TECHREPORTTBL INNER JOIN SERVICETBL "
        strSQL = strSQL + " INNER JOIN CLIENTSERVICETBL INNER JOIN "
        strSQL = strSQL + " CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID ON SERVICETBL.SVCID = CLIENTSERVICETBL.SVCID ON "
        strSQL = strSQL + " TECHREPORTTBL.CLIENTSVCID = CLIENTSERVICETBL.CLIENTSVCID LEFT OUTER JOIN "
        strSQL = strSQL + " TSWORKTBL ON TECHREPORTTBL.TSWORKID = TSWORKTBL.TSWORKID "
        strSQL = strSQL + " WHERE CLIENTTBL.CLIENTID = " + ClientID.ToString + " AND SERVICETBL.SVCID  = " + ServiceID.ToString + " "
        '--OR TECHREPORTTBL.STARTDT BETWEEN '' AND ''
        '--OR TECHREPORTTBL.COMPLETEDT BETWEEN '' AND ''
        '--OR TECHREPORTTBL.STATUS = ''
        '--OR TECHREPORTTBL.TEAM = 
        'strSQL = strSQL + " WHERE [TECHREPID]= " + lngTechRepID.ToString


        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function

    Public Function SearchTRbyClientService(ByVal ClSvcID As Long) As DataTable

        Dim strSQL As String

        '--SELECT
        '--TECHREPORTTBL.TECHREPID, CLIENTTBL.NAME AS CLIENTNAME, 
        '--SERVICETBL.SERVIENAME AS SERVICENAME, TECHREPORTTBL.STATUS AS TRSTATUS
        '--, TSWORKTBL.PONUMBER, TECHREPORTTBL.STARTDT
        '--FROM 
        '--TECHREPORTTBL INNER JOIN SERVICETBL 
        '--INNER JOIN CLIENTSERVICETBL INNER JOIN
        '--CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID ON SERVICETBL.SVCID = CLIENTSERVICETBL.SVCID ON 
        '--TECHREPORTTBL.CLIENTSVCID = CLIENTSERVICETBL.CLIENTSVCID LEFT OUTER JOIN
        '--TSWORKTBL ON TECHREPORTTBL.TSWORKID = TSWORKTBL.TSWORKID

        strSQL = " SELECT "
        strSQL = strSQL + " TECHREPORTTBL.TECHREPID, TSWORKTBL.SERVICEJOBNUMBER "
        strSQL = strSQL + " ,TECHREPORTTBL.STATUS AS STATUS "
        strSQL = strSQL + " ,TECHREPORTTBL.STARTDT , TECHREPORTTBL.TEAM AS TEAM"
        strSQL = strSQL + " FROM "
        strSQL = strSQL + " TECHREPORTTBL INNER JOIN SERVICETBL "
        strSQL = strSQL + " INNER JOIN CLIENTSERVICETBL INNER JOIN "
        strSQL = strSQL + " CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID ON SERVICETBL.SVCID = CLIENTSERVICETBL.SVCID ON "
        strSQL = strSQL + " TECHREPORTTBL.CLIENTSVCID = CLIENTSERVICETBL.CLIENTSVCID LEFT OUTER JOIN "
        strSQL = strSQL + " TSWORKTBL ON TECHREPORTTBL.TSWORKID = TSWORKTBL.TSWORKID "
        strSQL = strSQL + " WHERE TECHREPORTTBL.CLIENTSVCID = " + ClSvcID.ToString
        '--OR TECHREPORTTBL.STARTDT BETWEEN '' AND ''
        '--OR TECHREPORTTBL.COMPLETEDT BETWEEN '' AND ''
        '--OR TECHREPORTTBL.STATUS = ''
        '--OR TECHREPORTTBL.TEAM = 
        'strSQL = strSQL + " WHERE [TECHREPID]= " + lngTechRepID.ToString


        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function

    Public Function GetClientServiceParent(ByVal TRID As Long) As DataTable
        Dim strSQL As String

        'SELECT        
        'TECHREPORTTBL.TECHREPID, CLIENTTBL.CLIENTID, CLIENTTBL.CLIENTCODE, 
        'SERVICETBL.SERVIENAME As SERVICENAME, CLIENTSERVICETBL.CLIENTSVCID, TECHREPORTTBL.TSWORKID
        'FROM
        'CLIENTSERVICETBL INNER JOIN
        'CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID INNER JOIN
        'SERVICETBL ON CLIENTSERVICETBL.SVCID = SERVICETBL.SVCID INNER JOIN
        'TECHREPORTTBL ON CLIENTSERVICETBL.CLIENTSVCID = TECHREPORTTBL.CLIENTSVCID LEFT OUTER JOIN
        'TSWORKTBL ON TECHREPORTTBL.TSWORKID = TSWORKTBL.TSWORKID
        '--WHERE TECHREPORTTBL.TECHREPID = 1

        strSQL = " SELECT "
        strSQL = strSQL + " TECHREPORTTBL.TECHREPID, CLIENTTBL.CLIENTID, CLIENTTBL.CLIENTCODE,   "
        strSQL = strSQL + " SERVICETBL.SERVIENAME As SERVICENAME, CLIENTSERVICETBL.CLIENTSVCID, TECHREPORTTBL.TSWORKID "
        strSQL = strSQL + " FROM "
        strSQL = strSQL + " CLIENTSERVICETBL INNER JOIN "
        strSQL = strSQL + " CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID INNER JOIN "
        strSQL = strSQL + " SERVICETBL ON CLIENTSERVICETBL.SVCID = SERVICETBL.SVCID INNER JOIN "
        strSQL = strSQL + " TECHREPORTTBL ON CLIENTSERVICETBL.CLIENTSVCID = TECHREPORTTBL.CLIENTSVCID LEFT OUTER JOIN "
        strSQL = strSQL + " TSWORKTBL ON TECHREPORTTBL.TSWORKID = TSWORKTBL.TSWORKID "
        strSQL = strSQL + " WHERE TECHREPORTTBL.TECHREPID = '" + TRID.ToString + "'"

        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function

End Class
