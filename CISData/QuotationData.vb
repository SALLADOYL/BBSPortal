Option Strict On

Imports System.Collections.Generic
Imports CISEntity.ClientEntity
Imports System
Imports System.Data.SqlClient
Public Class QuotationData

    Public Function SaveNewQuotation(ByRef cisQuotationEntity As CISEntity.QuotationEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @CreateDate = GETDATE(); INSERT INTO [dbo].[QUOTATIONTBL] "
        strSQL = strSQL + " ([TSWORKID] "
        strSQL = strSQL + " ,[QUOTATIONNUMBER] "
        strSQL = strSQL + " ,[APPROVALDATE] "
        strSQL = strSQL + " ,[APPROVEDBY] "
        strSQL = strSQL + " ,[REMARKS] "
        strSQL = strSQL + " ,[ISACTIVEFLG] "
        strSQL = strSQL + " ,[PURGEFLG] "
        strSQL = strSQL + " ,[CRTDT] "
        strSQL = strSQL + " ,[CRTBY] "
        strSQL = strSQL + " ,[UPDDT] "
        strSQL = strSQL + " ,[UPDBY]) "
        strSQL = strSQL + " VALUES ("
        strSQL = strSQL + "'" + cisQuotationEntity.TSWorkID.ToString + "'" '[TSWORKID]
        strSQL = strSQL + ",'" + cisQuotationEntity.QuotationNumber + "'" '[QUOTATIONNUMBER]
        strSQL = strSQL + ",'" + cisQuotationEntity.ApprovalDate.ToString("MM/dd/yyyy HH:mm:ss") + "'" ',[APPROVALDATE]
        strSQL = strSQL + ",'" + cisQuotationEntity.ApprovedBy.ToString + "'" ',[APPROVEDBY]

        strSQL = strSQL + ",'" + cisQuotationEntity.Remarks + "'" ',[REMARKS]
        If cisQuotationEntity.IsActiveFlag Then
            strSQL = strSQL + ",1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",0" ',[ISACTIVEFLG]
        End If

        If cisQuotationEntity.PurgeFlag Then
            strSQL = strSQL + ",1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",@CreateDate" ',[CRTDT]
        strSQL = strSQL + ",'" + cisQuotationEntity.CreatedBy.ToString + "'" ',[CRTBY]
        strSQL = strSQL + ",@CreateDate" ',[UPDDT]
        strSQL = strSQL + ",'" + cisQuotationEntity.UpdatedBy.ToString + "'" ',[UPDBY]
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
        cisQuotationEntity.QuoteID = CType(objParams(0).Value, Long)
        cisQuotationEntity.CreateDate = CType(objParams(1).Value, DateTime)
        cisQuotationEntity.UpdateDate = CType(objParams(1).Value, DateTime)

        Return True
    End Function

    Public Function SaveQuotation(ByRef cisQuotationEntity As CISEntity.QuotationEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[QUOTATIONTBL] "
        strSQL = strSQL + "Set [TSWORKID] = '" + cisQuotationEntity.TSWorkID.ToString + "'"
        strSQL = strSQL + " ,[QUOTATIONNUMBER] = '" + cisQuotationEntity.QuotationNumber + "'"
        strSQL = strSQL + ",[APPROVALDATE] = '" + cisQuotationEntity.ApprovalDate.ToString("MM/dd/yyyy HH:mm:ss") + "'"
        strSQL = strSQL + ",[APPROVEDBY] = '" + cisQuotationEntity.ApprovedBy.ToString + "'"

        strSQL = strSQL + ",[REMARKS] = '" + cisQuotationEntity.Remarks + "'"
        If cisQuotationEntity.IsActiveFlag Then
            strSQL = strSQL + ",[ISACTIVEFLG]=1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",[ISACTIVEFLG]=0" ',[ISACTIVEFLG]
        End If
        If cisQuotationEntity.PurgeFlag Then
            strSQL = strSQL + ",[PURGEFLG]=1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",[PURGEFLG]=0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [QUOTEID]=" + cisQuotationEntity.QuoteID.ToString

        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NewUpdateDate", SqlDbType.DateTime)
        objParams(0).Value = Now
        objParams(0).Direction = ParameterDirection.InputOutput


        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        cisQuotationEntity.UpdatedBy = prflID
        cisQuotationEntity.UpdateDate = CType(objParams(0).Value, Date)

        Return True
    End Function

    Public Function PurgeQuotation(ByVal QUOTEID As Long, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[QUOTATIONTBL] "
        strSQL = strSQL + "Set [PURGEFLG]=1" ',[PURGEFLG]
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [QUOTEID]=" + QUOTEID.ToString

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

    Public Function GetQuotation(ByVal QUOTEID As Long) As CISEntity.QuotationEntity
        Dim objQuotationEntity As New CISEntity.QuotationEntity
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        strSQL = "SELECT * FROM QUOTATIONTBL" &
                " WHERE " &
                " [QUOTEID]=" & QUOTEID.ToString

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    With objQuotationEntity
                        .QuoteID = CType(curRow("QUOTEID"), Long)
                        .TSWorkID = CType(curRow("TSWORKID"), Long)
                        .QuotationNumber = CType(curRow("QUOTATIONNUMBER"), String)
                        .ApprovalDate = CType(curRow("APPROVALDATE"), DateTime)
                        .ApprovedBy = CType(curRow("APPROVEDBY"), Long)
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
                Return objQuotationEntity
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
    End Function

    Public Function GetQuotationList(ByVal strWhereClause As String) As List(Of CISEntity.QuotationEntity)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing
        Dim objQuotationEntityList As New List(Of CISEntity.QuotationEntity)

        strSQL = "SELECT * FROM [QUOTATIONTBL]" &
                " WHERE " & strWhereClause


        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    Dim objQuotationEntity As New CISEntity.QuotationEntity
                    With objQuotationEntity
                        .QuoteID = CType(curRow("QUOTEID"), Long)
                        .TSWorkID = CType(curRow("TSWORKID"), Long)
                        .QuotationNumber = CType(curRow("QUOTATIONNUMBER"), String)
                        .ApprovalDate = CType(curRow("APPROVALDATE"), DateTime)
                        .ApprovedBy = CType(curRow("APPROVEDBY"), Long)
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
                    objQuotationEntityList.Add(objQuotationEntity)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
        Return objQuotationEntityList
    End Function

End Class
