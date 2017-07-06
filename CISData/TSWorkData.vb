Option Strict On

Imports System.Collections.Generic
Imports CISEntity.ClientEntity
Imports System
Imports System.Data.SqlClient
Public Class TSWorkData
    Public Function SaveNewTSWork(ByRef cisTSWorkEntity As CISEntity.TSWorkEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @CreateDate = GETDATE(); INSERT INTO [dbo].[TSWORKTBL] "
        strSQL = strSQL + " ([CLSVCID] "
        strSQL = strSQL + " ,[SERVICEJOBNUMBER] " ',[SERVICEJOBNUMBER]
        strSQL = strSQL + " ,[PONUMBER] " ',PONUMBER
        strSQL = strSQL + " ,[QUOTATIONNUMBER] " ',QUOTATIONNUMBER
        strSQL = strSQL + " ,[QUOTEDATE] " ',QUOTEDATE
        strSQL = strSQL + " ,[FROMTEXT] " ',FROMTEXT
        strSQL = strSQL + " ,[DELIVERTO] " ',DELIVERTO
        strSQL = strSQL + " ,[TERMS] " ',TERMS
        strSQL = strSQL + " ,[STATUS] " ',STATUS
        strSQL = strSQL + " ,[JOBCREATEDBY] " ',[JOBCREATEDBY]
        'strSQL = strSQL + " ,[JOBAPPROVALDATE] " ',JOBAPPROVALDATE
        strSQL = strSQL + " ,[JOBAPPROVEDBY] " ',JOBAPPROVEDBY
        'strSQL = strSQL + " ,[ASSIGNEDTO] " ',ASSIGNEDTO
        strSQL = strSQL + " ,[STARTDATE] " ',STARTDATE
        strSQL = strSQL + " ,[ENDDATE] " ',ENDDATE
        strSQL = strSQL + " ,[REMARKS] "
        strSQL = strSQL + " ,[CLIENTSIGNEDBY] " '[CLIENTSIGNEDBY]
        strSQL = strSQL + " ,[ISACTIVEFLG] "
        strSQL = strSQL + " ,[PURGEFLG] "
        strSQL = strSQL + " ,[CRTDT] "
        strSQL = strSQL + " ,[CRTBY] "
        strSQL = strSQL + " ,[UPDDT] "
        strSQL = strSQL + " ,[UPDBY]) "
        strSQL = strSQL + " VALUES ("
        strSQL = strSQL + "'" + cisTSWorkEntity.ClientServiceID.ToString + "'" '[CLSVCID]
        strSQL = strSQL + ",'" + cisTSWorkEntity.ServiceJobNumber + "'" ',,[SERVICEJOBNUMBER]
        strSQL = strSQL + ",'" + cisTSWorkEntity.PONumber + "'" ',,PONUMBER
        strSQL = strSQL + ",'" + cisTSWorkEntity.QuotationNumber + "'" ',QUOTATIONNUMBER
        strSQL = strSQL + ",'" + cisTSWorkEntity.QuoteDate.ToString("MM/dd/yyyy HH:mm:ss") + "'" ',QUOTEDATE
        strSQL = strSQL + ",'" + cisTSWorkEntity.FromText + "'" ',FROMTEXT
        strSQL = strSQL + ",'" + cisTSWorkEntity.DeliverTo + "'" ',DELIVERTO
        strSQL = strSQL + ",'" + cisTSWorkEntity.Terms + "'" ',TERMS
        strSQL = strSQL + ",'" + cisTSWorkEntity.Status + "'" ',STATUS
        strSQL = strSQL + ",'" + cisTSWorkEntity.JobCreatedBy.ToString + "'" ',[JOBCREATEDBY]
        'strSQL = strSQL + ",'" + cisTSWorkEntity.JobApprovalDate.ToString + "'" ',JOBAPPROVALDATE
        strSQL = strSQL + ",'" + cisTSWorkEntity.JobApprovedBy.ToString + "'" ',JOBAPPROVEDBY
        'strSQL = strSQL + ",'" + cisTSWorkEntity.AssignedTo.ToString + "'" ',ASSIGNEDTO
        strSQL = strSQL + ",'" + cisTSWorkEntity.StartDate.ToString("MM/dd/yyyy HH:mm:ss") + "'" ',STARTDATE
        strSQL = strSQL + ",'" + cisTSWorkEntity.EndDate.ToString("MM/dd/yyyy HH:mm:ss") + "'" ',ENDDATE

        strSQL = strSQL + ",'" + cisTSWorkEntity.Remarks + "'" ',[REMARKS]
        strSQL = strSQL + ",'" + cisTSWorkEntity.ClientSignedBy + "'" ',[[CLIENTSIGNEDBY]]
        If cisTSWorkEntity.IsActiveFlag Then
            strSQL = strSQL + ",1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",0" ',[ISACTIVEFLG]
        End If

        If cisTSWorkEntity.PurgeFlag Then
            strSQL = strSQL + ",1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",@CreateDate" ',[CRTDT]
        strSQL = strSQL + ",'" + cisTSWorkEntity.CreatedBy.ToString + "'" ',[CRTBY]
        strSQL = strSQL + ",@CreateDate" ',[UPDDT]
        strSQL = strSQL + ",'" + cisTSWorkEntity.UpdatedBy.ToString + "'" ',[UPDBY]
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
        cisTSWorkEntity.TSWorkID = CType(objParams(0).Value, Long)
        cisTSWorkEntity.CreateDate = CType(objParams(1).Value, DateTime)
        cisTSWorkEntity.UpdateDate = CType(objParams(1).Value, DateTime)

        Return True
    End Function


    Public Function SaveTSWork(ByRef cisTSWorkEntity As CISEntity.TSWorkEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[TSWORKTBL] "
        strSQL = strSQL + "Set [CLSVCID] = '" + cisTSWorkEntity.TSWorkID.ToString + "'"
        strSQL = strSQL + " ,[SERVICEJOBNUMBER] = '" + cisTSWorkEntity.ServiceJobNumber + "'" '[SERVICEJOBNUMBER]
        strSQL = strSQL + " ,[PONUMBER] = '" + cisTSWorkEntity.PONumber + "'"
        strSQL = strSQL + ",[QUOTATIONNUMBER] = '" + cisTSWorkEntity.QuotationNumber + "'"
        strSQL = strSQL + ",[QUOTEDATE] = '" + cisTSWorkEntity.QuoteDate.ToString("MM/dd/yyyy HH:mm:ss") + "'"
        strSQL = strSQL + ",[FROMTEXT] = '" + cisTSWorkEntity.FromText + "'"
        strSQL = strSQL + ",[DELIVERTO] = '" + cisTSWorkEntity.DeliverTo + "'"
        strSQL = strSQL + ",[TERMS] = '" + cisTSWorkEntity.Terms + "'"
        strSQL = strSQL + ",[STATUS] = '" + cisTSWorkEntity.Status + "'"
        strSQL = strSQL + ",[JOBCREATEDBY] = '" + cisTSWorkEntity.JobCreatedBy.ToString + "'" '[JOBCREATEDBY]
        'strSQL = strSQL + ",[JOBAPPROVALDATE] = '" + cisTSWorkEntity.JobApprovalDate.ToString("MM/dd/yyyy HH:mm:ss") + "'"
        strSQL = strSQL + ",[JOBAPPROVEDBY] = '" + cisTSWorkEntity.JobApprovedBy.ToString + "'"
        'strSQL = strSQL + ",[ASSIGNEDTO] = '" + cisTSWorkEntity.AssignedTo.ToString + "'"
        strSQL = strSQL + ",[STARTDATE] = '" + cisTSWorkEntity.StartDate.ToString("MM/dd/yyyy HH:mm:ss") + "'"
        strSQL = strSQL + ",[ENDDATE] = '" + cisTSWorkEntity.EndDate.ToString("MM/dd/yyyy HH:mm:ss") + "'"

        strSQL = strSQL + ",[REMARKS] = '" + cisTSWorkEntity.Remarks + "'"
        strSQL = strSQL + ",[CLIENTSIGNEDBY] = '" + cisTSWorkEntity.ClientSignedBy + "'" '[CLIENTSIGNEDBY]
        If cisTSWorkEntity.IsActiveFlag Then
            strSQL = strSQL + ",[ISACTIVEFLG]=1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",[ISACTIVEFLG]=0" ',[ISACTIVEFLG]
        End If
        If cisTSWorkEntity.PurgeFlag Then
            strSQL = strSQL + ",[PURGEFLG]=1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",[PURGEFLG]=0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [TSWORKID]=" + cisTSWorkEntity.TSWorkID.ToString

        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NewUpdateDate", SqlDbType.DateTime)
        objParams(0).Value = Now
        objParams(0).Direction = ParameterDirection.InputOutput


        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        cisTSWorkEntity.UpdatedBy = prflID
        cisTSWorkEntity.UpdateDate = CType(objParams(0).Value, Date)

        Return True
    End Function

    Public Function PurgeTSWork(ByVal TSWorkID As Long, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[TSWORKTBL] "
        strSQL = strSQL + "Set [ISACTIVEFLG]=0, [PURGEFLG]=1" ',[PURGEFLG]
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [TSWORKID]=" + TSWorkID.ToString

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

    Public Function GetTSWork(ByVal TSWorkID As Long) As CISEntity.TSWorkEntity
        Dim objTSWorkEntity As New CISEntity.TSWorkEntity
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        strSQL = "SELECT * FROM TSWORKTBL" &
                " WHERE " &
                " [TSWORKID]=" & TSWorkID.ToString

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    With objTSWorkEntity
                        .TSWorkID = CType(curRow("TSWORKID"), Long) 'TSWORKID
                        .ClientServiceID = CType(curRow("CLSVCID"), Long) ',CLSVCID
                        .ServiceJobNumber = CType(curRow("SERVICEJOBNUMBER"), String) ',[SERVICEJOBNUMBER]
                        .PONumber = CType(curRow("PONUMBER"), String) ',PONUMBER
                        .QuotationNumber = CType(curRow("QUOTATIONNUMBER"), String) ',QUOTATIONNUMBER
                        .QuoteDate = CType(curRow("QUOTEDATE"), DateTime) ',QUOTEDATE
                        .FromText = CType(curRow("FROMTEXT"), String) ',FROMTEXT
                        .DeliverTo = CType(curRow("DELIVERTO"), String) ',DELIVERTO
                        .Terms = CType(curRow("TERMS"), String) ',TERMS
                        .Status = CType(curRow("STATUS"), String) ',STATUS
                        .JobCreatedBy = CType(curRow("JOBCREATEDBY"), Long) ',[JOBCREATEDBY]
                        '.JobApprovalDate = CType(curRow("JOBAPPROVALDATE"), DateTime) ',JOBAPPROVALDATE
                        .JobApprovedBy = CType(curRow("JOBAPPROVEDBY"), Long) ',JOBAPPROVEDBY
                        '.AssignedTo = CType(curRow("ASSIGNEDTO"), Long) ',ASSIGNEDTO
                        .StartDate = CType(curRow("STARTDATE"), DateTime) ',STARTDATE
                        .EndDate = CType(curRow("ENDDATE"), DateTime) ',ENDDATE
                        .Remarks = CType(curRow("REMARKS"), String) ',REMARKS
                        .ClientSignedBy = CType(curRow("CLIENTSIGNEDBY"), String) ',[CLIENTSIGNEDBY]
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
                Return objTSWorkEntity
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
    End Function


    Public Function GetTSWorkList(ByVal strWhereClause As String) As List(Of CISEntity.TSWorkEntity)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing
        Dim objTSWorkEntityList As New List(Of CISEntity.TSWorkEntity)

        strSQL = "SELECT * FROM TSWORKTBL" &
                " WHERE " & strWhereClause


        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    Dim objTSWorkEntity As New CISEntity.TSWorkEntity
                    With objTSWorkEntity
                        .TSWorkID = CType(curRow("TSWORKID"), Long) 'TSWORKID
                        .ClientServiceID = CType(curRow("CLSVCID"), Long) ',CLSVCID
                        .ServiceJobNumber = CType(curRow("SERVICEJOBNUMBER"), String) ',[SERVICEJOBNUMBER]
                        .PONumber = CType(curRow("PONUMBER"), String) ',PONUMBER
                        .QuotationNumber = CType(curRow("QUOTATIONNUMBER"), String) ',QUOTATIONNUMBER
                        .QuoteDate = CType(curRow("QUOTEDATE"), DateTime) ',QUOTEDATE
                        .FromText = CType(curRow("FROMTEXT"), String) ',FROMTEXT
                        .DeliverTo = CType(curRow("DELIVERTO"), String) ',DELIVERTO
                        .Terms = CType(curRow("TERMS"), String) ',TERMS
                        .Status = CType(curRow("STATUS"), String) ',STATUS
                        .JobCreatedBy = CType(curRow("JOBCREATEDBY"), Long) ',[JOBCREATEDBY]
                        '.JobApprovalDate = CType(curRow("JOBAPPROVALDATE"), DateTime) ',JOBAPPROVALDATE
                        .JobApprovedBy = CType(curRow("JOBAPPROVEDBY"), Long) ',JOBAPPROVEDBY
                        '.AssignedTo = CType(curRow("ASSIGNEDTO"), Long) ',ASSIGNEDTO
                        .StartDate = CType(curRow("STARTDATE"), DateTime) ',STARTDATE
                        .EndDate = CType(curRow("ENDDATE"), DateTime) ',ENDDATE
                        .Remarks = CType(curRow("REMARKS"), String) ',REMARKS
                        .ClientSignedBy = CType(curRow("CLIENTSIGNEDBY"), String) ',[CLIENTSIGNEDBY]
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
                    objTSWorkEntityList.Add(objTSWorkEntity)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
        Return objTSWorkEntityList
    End Function

    Public Function GetPONumberListByWork(ByVal TSWorkID As Long) As DataTable
        Dim strSQL As String
        strSQL = "SELECT 0 AS TSWORKID, '' AS PONUMBER "
        strSQL = strSQL + " UNION SELECT "
        strSQL = strSQL + " TSWORKID, PONUMBER "
        strSQL = strSQL + " FROM TSWORKTBL "
        strSQL = strSQL + " WHERE TSWORKTBL.CLSVCID =" + TSWorkID.ToString


        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function

    Public Function GetPONumberListByClientID(ByVal ClientID As Long) As DataTable
        ''SELECT        
        'TSWORKTBL.PONUMBER, TSWORKTBL.TSWORKID
        'FROM
        'CLIENTTBL INNER JOIN
        'CLIENTSERVICETBL ON CLIENTTBL.CLIENTID = CLIENTSERVICETBL.CLIENTID INNER JOIN
        'TSWORKTBL ON CLIENTSERVICETBL.CLIENTSVCID = TSWORKTBL.CLSVCID
        'WHERE V = 0

        Dim strSQL As String
        strSQL = "SELECT '' AS PONUMBER, 0 AS TSWORKID "
        strSQL = strSQL + " UNION SELECT "
        strSQL = strSQL + " TSWORKTBL.PONUMBER, TSWORKTBL.TSWORKID "
        strSQL = strSQL + " FROM "
        strSQL = strSQL + " CLIENTTBL INNER JOIN "
        strSQL = strSQL + " CLIENTSERVICETBL ON CLIENTTBL.CLIENTID = CLIENTSERVICETBL.CLIENTID INNER JOIN "
        strSQL = strSQL + " TSWORKTBL ON CLIENTSERVICETBL.CLIENTSVCID = TSWORKTBL.CLSVCID "
        strSQL = strSQL + " WHERE CLIENTTBL.CLIENTID =" + ClientID.ToString


        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function

    Public Function GetServiceJob(ByVal ClSvcID As Long) As DataTable
        Dim strSQL As String
        strSQL = "SELECT "
        strSQL = strSQL + " TSWORKTBL.PONUMBER, TSWORKTBL.TSWORKID "
        strSQL = strSQL + " FROM "
        strSQL = strSQL + " CLIENTTBL INNER JOIN "
        strSQL = strSQL + " CLIENTSERVICETBL ON CLIENTTBL.CLIENTID = CLIENTSERVICETBL.CLIENTID INNER JOIN "
        strSQL = strSQL + " TSWORKTBL ON CLIENTSERVICETBL.CLIENTSVCID = TSWORKTBL.CLSVCID "
        strSQL = strSQL + " WHERE CLIENTTBL.CLIENTID =" + ClSvcID.ToString


        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)
    End Function


    Public Function SearchByClientServiceID(ByVal ClientSvcID As Long) As DataTable
        'SELECT        
        'TSWORKTBL.TSWORKID AS TSWORKID,
        'CLIENTTBL.NAME As CLIENTNAME, 
        'SERVICETBL.SERVIENAME AS SERVICE,
        'TSWORKTBL.PONUMBER As PONUMBER, 
        'TSWORKTBL.QUOTATIONNUMBER AS QUOTATIONNUMBER,
        'TSWORKTBL.STATUS As STATUS, 
        'TSWORKTBL.QUOTEDATE AS QUOTEDATE
        'FROM
        'CLIENTSERVICETBL INNER JOIN
        'CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID INNER JOIN
        'SERVICETBL ON CLIENTSERVICETBL.SVCID = SERVICETBL.SVCID INNER JOIN
        'TSWORKTBL ON CLIENTSERVICETBL.CLIENTSVCID = TSWORKTBL.CLSVCID
        'WHERE CLIENTSERVICETBL.ISACTIVE = 1 And CLIENTSERVICETBL.PURGEFLG = 0

        Dim strSQL As String
        strSQL = " SELECT "
        strSQL = strSQL + " TSWORKTBL.TSWORKID AS TSWORKID, "
        strSQL = strSQL + " CLIENTTBL.NAME As CLIENTNAME, "
        strSQL = strSQL + " SERVICETBL.SERVIENAME AS SERVICE, "
        strSQL = strSQL + " TSWORKTBL.PONUMBER As PONUMBER, "
        strSQL = strSQL + " TSWORKTBL.QUOTATIONNUMBER AS QUOTATIONNUMBER, "
        strSQL = strSQL + " TSWORKTBL.STATUS As STATUS, "
        strSQL = strSQL + " TSWORKTBL.QUOTEDATE AS QUOTEDATE "
        strSQL = strSQL + " FROM "
        strSQL = strSQL + " CLIENTSERVICETBL INNER JOIN "
        strSQL = strSQL + " CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID INNER JOIN "
        strSQL = strSQL + " SERVICETBL ON CLIENTSERVICETBL.SVCID = SERVICETBL.SVCID INNER JOIN "
        strSQL = strSQL + " TSWORKTBL ON CLIENTSERVICETBL.CLIENTSVCID = TSWORKTBL.CLSVCID "
        strSQL = strSQL + " WHERE CLIENTSERVICETBL.ISACTIVE = 1 And CLIENTSERVICETBL.PURGEFLG = 0"
        strSQL = strSQL + " AND CLIENTSERVICETBL.CLIENTSVCID = " & ClientSvcID.ToString

        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function

    Public Function SearchClientIDAndServiceID(ByVal ClientID As Long, ByVal ServiceID As Long) As DataTable
        'SELECT        
        'TSWORKTBL.TSWORKID AS TSWORKID,
        'CLIENTTBL.NAME As CLIENTNAME, 
        'SERVICETBL.SERVIENAME AS SERVICE,
        'TSWORKTBL.PONUMBER As PONUMBER, 
        'TSWORKTBL.QUOTATIONNUMBER AS QUOTATIONNUMBER,
        'TSWORKTBL.STATUS As STATUS, 
        'TSWORKTBL.QUOTEDATE AS QUOTEDATE
        'FROM
        'CLIENTSERVICETBL INNER JOIN
        'CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID INNER JOIN
        'SERVICETBL ON CLIENTSERVICETBL.SVCID = SERVICETBL.SVCID INNER JOIN
        'TSWORKTBL ON CLIENTSERVICETBL.CLIENTSVCID = TSWORKTBL.CLSVCID
        'WHERE CLIENTSERVICETBL.ISACTIVE = 1 And CLIENTSERVICETBL.PURGEFLG = 0

        Dim strSQL As String
        strSQL = " SELECT "
        strSQL = strSQL + " TSWORKTBL.TSWORKID AS TSWORKID, "
        strSQL = strSQL + " CLIENTTBL.NAME As CLIENTNAME, "
        strSQL = strSQL + " SERVICETBL.SERVIENAME AS SERVICE, "
        strSQL = strSQL + " TSWORKTBL.PONUMBER As PONUMBER, "
        strSQL = strSQL + " TSWORKTBL.QUOTATIONNUMBER AS QUOTATIONNUMBER, "
        strSQL = strSQL + " TSWORKTBL.STATUS As STATUS, "
        strSQL = strSQL + " TSWORKTBL.QUOTEDATE AS QUOTEDATE "
        strSQL = strSQL + " FROM "
        strSQL = strSQL + " CLIENTSERVICETBL INNER JOIN "
        strSQL = strSQL + " CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID INNER JOIN "
        strSQL = strSQL + " SERVICETBL ON CLIENTSERVICETBL.SVCID = SERVICETBL.SVCID INNER JOIN "
        strSQL = strSQL + " TSWORKTBL ON CLIENTSERVICETBL.CLIENTSVCID = TSWORKTBL.CLSVCID "
        strSQL = strSQL + " WHERE CLIENTSERVICETBL.ISACTIVE = 1 And CLIENTSERVICETBL.PURGEFLG = 0"
        strSQL = strSQL + " AND CLIENTTBL.CLIENTID = " + ClientID.ToString
        strSQL = strSQL + " AND SERVICETBL.SVCID = " + ServiceID.ToString

        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function

    Public Function SearchByPONumber(ByVal PONumber As String) As DataTable

        Dim strSQL As String
        strSQL = " SELECT "
        strSQL = strSQL + " TSWORKTBL.TSWORKID AS TSWORKID, "
        strSQL = strSQL + " CLIENTTBL.NAME As CLIENTNAME, "
        strSQL = strSQL + " SERVICETBL.SERVIENAME AS SERVICE, "
        strSQL = strSQL + " TSWORKTBL.PONUMBER As PONUMBER, "
        strSQL = strSQL + " TSWORKTBL.QUOTATIONNUMBER AS QUOTATIONNUMBER, "
        strSQL = strSQL + " TSWORKTBL.STATUS As STATUS, "
        strSQL = strSQL + " TSWORKTBL.QUOTEDATE AS QUOTEDATE "
        strSQL = strSQL + " FROM "
        strSQL = strSQL + " CLIENTSERVICETBL INNER JOIN "
        strSQL = strSQL + " CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID INNER JOIN "
        strSQL = strSQL + " SERVICETBL ON CLIENTSERVICETBL.SVCID = SERVICETBL.SVCID INNER JOIN "
        strSQL = strSQL + " TSWORKTBL ON CLIENTSERVICETBL.CLIENTSVCID = TSWORKTBL.CLSVCID "
        strSQL = strSQL + " WHERE CLIENTSERVICETBL.ISACTIVE = 1 And CLIENTSERVICETBL.PURGEFLG = 0"
        strSQL = strSQL + " AND TSWORKTBL.PONUMBER LIKE '%" + PONumber + "%'"
        strSQL &= " ISACTIVEFLG=1 AND "

        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function

    Public Function SearchByQuotationNumber(ByVal QuotationNumber As String) As DataTable

        Dim strSQL As String
        strSQL = " SELECT "
        strSQL = strSQL + " TSWORKTBL.TSWORKID AS TSWORKID, "
        strSQL = strSQL + " CLIENTTBL.NAME As CLIENTNAME, "
        strSQL = strSQL + " SERVICETBL.SERVIENAME AS SERVICE, "
        strSQL = strSQL + " TSWORKTBL.PONUMBER As PONUMBER, "
        strSQL = strSQL + " TSWORKTBL.QUOTATIONNUMBER AS QUOTATIONNUMBER, "
        strSQL = strSQL + " TSWORKTBL.STATUS As STATUS, "
        strSQL = strSQL + " TSWORKTBL.QUOTEDATE AS QUOTEDATE "
        strSQL = strSQL + " FROM "
        strSQL = strSQL + " CLIENTSERVICETBL INNER JOIN "
        strSQL = strSQL + " CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID INNER JOIN "
        strSQL = strSQL + " SERVICETBL ON CLIENTSERVICETBL.SVCID = SERVICETBL.SVCID INNER JOIN "
        strSQL = strSQL + " TSWORKTBL ON CLIENTSERVICETBL.CLIENTSVCID = TSWORKTBL.CLSVCID "
        strSQL = strSQL + " WHERE CLIENTSERVICETBL.ISACTIVE = 1 And CLIENTSERVICETBL.PURGEFLG = 0"
        strSQL = strSQL + " AND TSWORKTBL.QUOTATIONNUMBER LIKE '%" + QuotationNumber + "%'"

        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function

    Public Function SearchByQuotationDate(ByVal DateFrom As Date, ByVal DateTo As Date) As DataTable

        Dim strSQL As String
        strSQL = " SELECT "
        strSQL = strSQL + " TSWORKTBL.TSWORKID AS TSWORKID, "
        strSQL = strSQL + " CLIENTTBL.NAME As CLIENTNAME, "
        strSQL = strSQL + " SERVICETBL.SERVIENAME AS SERVICE, "
        strSQL = strSQL + " TSWORKTBL.PONUMBER As PONUMBER, "
        strSQL = strSQL + " TSWORKTBL.QUOTATIONNUMBER AS QUOTATIONNUMBER, "
        strSQL = strSQL + " TSWORKTBL.STATUS As STATUS, "
        strSQL = strSQL + " TSWORKTBL.QUOTEDATE AS QUOTEDATE "
        strSQL = strSQL + " FROM "
        strSQL = strSQL + " CLIENTSERVICETBL INNER JOIN "
        strSQL = strSQL + " CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID INNER JOIN "
        strSQL = strSQL + " SERVICETBL ON CLIENTSERVICETBL.SVCID = SERVICETBL.SVCID INNER JOIN "
        strSQL = strSQL + " TSWORKTBL ON CLIENTSERVICETBL.CLIENTSVCID = TSWORKTBL.CLSVCID "
        strSQL = strSQL + " WHERE CLIENTSERVICETBL.ISACTIVE = 1 And CLIENTSERVICETBL.PURGEFLG = 0"
        strSQL = strSQL + " AND (TSWORKTBL.QUOTEDATE BETWEEN '" + DateFrom.ToString("MM/dd/yyyy") + "'"
        strSQL = strSQL + " AND  '" + DateTo.ToString("MM/dd/yyyy") + "')"

        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function
End Class
