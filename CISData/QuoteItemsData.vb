Option Strict On

Imports System.Collections.Generic
Imports CISEntity.ClientEntity
Imports System
Imports System.Data.SqlClient
Public Class QuoteItemsData

    Public Function SaveNewQuoteItems(ByRef cisQuoteItemsEntity As CISEntity.QuoteItemsEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @CreateDate = GETDATE(); INSERT INTO [dbo].[QUOTEITEMSTBL] "
        strSQL = strSQL + " ([ITEMCODE] "
        strSQL = strSQL + " ,[ITEMDESC] "
        strSQL = strSQL + " ,[ITEMQTY] " ',ITEMQTY
        strSQL = strSQL + " ,[ITEMPER] " ',ITEMPER
        strSQL = strSQL + " ,[ITEMPRICE] " ',ITEMPRICE
        strSQL = strSQL + " ,[AMOUNT] " ',AMOUNT
        strSQL = strSQL + " ,[SORTNUM] " ',SORTNUM
        strSQL = strSQL + " ,[ISITEMFLG] " ',ISITEMFLG
        strSQL = strSQL + " ,[REMARKS] "
        strSQL = strSQL + " ,[ISACTIVEFLG] "
        strSQL = strSQL + " ,[PURGEFLG] "
        strSQL = strSQL + " ,[CRTDT] "
        strSQL = strSQL + " ,[CRTBY] "
        strSQL = strSQL + " ,[UPDDT] "
        strSQL = strSQL + " ,[UPDBY]) "
        strSQL = strSQL + " VALUES ("
        strSQL = strSQL + "'" + cisQuoteItemsEntity.ItemCode + "'" '
        strSQL = strSQL + ",'" + cisQuoteItemsEntity.ItemDescription.ToString + "'" ',',ITEMDESC
        strSQL = strSQL + ",'" + cisQuoteItemsEntity.ItemQuantity.ToString + "'" ',',ITEMQTY
        strSQL = strSQL + ",'" + cisQuoteItemsEntity.ItemPer + "'" ',',ITEMPER
        strSQL = strSQL + ",'" + cisQuoteItemsEntity.ItemPrice.ToString + "'" ',',ITEMPRICE
        strSQL = strSQL + ",'" + cisQuoteItemsEntity.Amount.ToString + "'" ',',AMOUNT
        strSQL = strSQL + ",'" + cisQuoteItemsEntity.SortNumber.ToString + "'" ',',SORTNUM
        If cisQuoteItemsEntity.IsItemFlag Then
            strSQL = strSQL + ",1" ',[ISITEMFLG]
        Else
            strSQL = strSQL + ",0" ',[ISITEMFLG]
        End If

        strSQL = strSQL + ",'" + cisQuoteItemsEntity.Remarks + "'" ',[REMARKS]
        If cisQuoteItemsEntity.IsActiveFlag Then
            strSQL = strSQL + ",1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",0" ',[ISACTIVEFLG]
        End If

        If cisQuoteItemsEntity.PurgeFlag Then
            strSQL = strSQL + ",1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",@CreateDate" ',[CRTDT]
        strSQL = strSQL + ",'" + cisQuoteItemsEntity.CreatedBy.ToString + "'" ',[CRTBY]
        strSQL = strSQL + ",@CreateDate" ',[UPDDT]
        strSQL = strSQL + ",'" + cisQuoteItemsEntity.UpdatedBy.ToString + "'" ',[UPDBY]
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
        cisQuoteItemsEntity.QuoteItemID = CType(objParams(0).Value, Long)
        cisQuoteItemsEntity.CreateDate = CType(objParams(1).Value, DateTime)
        cisQuoteItemsEntity.UpdateDate = CType(objParams(1).Value, DateTime)

        Return True
    End Function

    Public Function SaveQuoteItems(ByRef cisQuoteItemsEntity As CISEntity.QuoteItemsEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[QUOTEITEMSTBL] "
        strSQL = strSQL + "Set [ITEMCODE] = '" + cisQuoteItemsEntity.ItemCode + "'"
        strSQL = strSQL + " ,[ITEMDESC] = '" + cisQuoteItemsEntity.ItemDescription + "'"
        strSQL = strSQL + " ,[ITEMQTY] = '" + cisQuoteItemsEntity.ItemQuantity.ToString + "'" '  ,ITEMQTY
        strSQL = strSQL + " ,[ITEMPER] = '" + cisQuoteItemsEntity.ItemPer + "'" ',ITEMPER
        strSQL = strSQL + " ,[ITEMPRICE] = '" + cisQuoteItemsEntity.ItemPrice.ToString + "'" ',ITEMPRICE
        strSQL = strSQL + " ,[AMOUNT] = '" + cisQuoteItemsEntity.Amount.ToString + "'" ',AMOUNT
        strSQL = strSQL + " ,[SORTNUM] = '" + cisQuoteItemsEntity.SortNumber.ToString + "'" ',SORTNUM
        If cisQuoteItemsEntity.IsItemFlag Then
            strSQL = strSQL + ",[ISITEMFLG]=1" ',[ISITEMFLG]
        Else
            strSQL = strSQL + ",[ISITEMFLG]=0" ',[ISITEMFLG]
        End If
        strSQL = strSQL + ",[REMARKS] = '" + cisQuoteItemsEntity.Remarks + "'"
        If cisQuoteItemsEntity.IsActiveFlag Then
            strSQL = strSQL + ",[ISACTIVEFLG]=1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",[ISACTIVEFLG]=0" ',[ISACTIVEFLG]
        End If
        If cisQuoteItemsEntity.PurgeFlag Then
            strSQL = strSQL + ",[PURGEFLG]=1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",[PURGEFLG]=0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [QUOTEITEMID]=" + cisQuoteItemsEntity.QuoteItemID.ToString

        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NewUpdateDate", SqlDbType.DateTime)
        objParams(0).Value = Now
        objParams(0).Direction = ParameterDirection.InputOutput


        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        cisQuoteItemsEntity.UpdatedBy = prflID
        cisQuoteItemsEntity.UpdateDate = CType(objParams(0).Value, Date)

        Return True
    End Function

    Public Function PurgeQuoteItems(ByVal QUOTEITEMID As Long, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[QUOTEITEMSTBL] "
        strSQL = strSQL + "Set [PURGEFLG]=1" ',[PURGEFLG]
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [QUOTEITEMID]=" + QUOTEITEMID.ToString

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

    Public Function GetQuoteItems(ByVal QUOTEITEMID As Long) As CISEntity.QuoteItemsEntity
        Dim objQuoteItemsEntity As New CISEntity.QuoteItemsEntity
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        strSQL = "SELECT * FROM QUOTEITEMSTBL" &
                " WHERE " &
                " [QUOTEITEMID]=" & QUOTEITEMID.ToString

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    With objQuoteItemsEntity
                        .QuoteItemID = CType(curRow("QUOTEITEMID"), Long) ' QUOTEITEMID
                        .ItemCode = CType(curRow("ITEMCODE"), String) ',ITEMCODE
                        .ItemDescription = CType(curRow("ITEMDESC"), String) ',ITEMDESC
                        .ItemQuantity = CType(curRow("ITEMQTY"), Integer) ',ITEMQTY
                        .ItemPer = CType(curRow("ITEMPER"), String) ',ITEMPER
                        .ItemPrice = CType(curRow("ITEMPRICE"), Double) ',ITEMPRICE
                        .ItemPrice = CType(curRow("AMOUNT"), Double) ',AMOUNT
                        .SortNumber = CType(curRow("SORTNUM"), Integer) ',SORTNUM
                        If CType(curRow("ISITEMFLG"), Integer) <> 0 Then ',ISITEMFLG
                            .IsActiveFlag = True
                        Else
                            .IsActiveFlag = False
                        End If

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
                Return objQuoteItemsEntity
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
    End Function

    Public Function GetList(ByVal strWhereClause As String) As List(Of CISEntity.QuoteItemsEntity)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing
        Dim QuoteItemsEntityList As New List(Of CISEntity.QuoteItemsEntity)

        strSQL = "SELECT * FROM QUOTEITEMSTBL" &
                " WHERE " & strWhereClause


        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    Dim objQuoteItemsEntity As New CISEntity.QuoteItemsEntity
                    With objQuoteItemsEntity
                        .QuoteItemID = CType(curRow("QUOTEITEMID"), Long) ' QUOTEITEMID
                        .ItemCode = CType(curRow("ITEMCODE"), String) ',ITEMCODE
                        .ItemDescription = CType(curRow("ITEMDESC"), String) ',ITEMDESC
                        .ItemQuantity = CType(curRow("ITEMQTY"), Integer) ',ITEMQTY
                        .ItemPer = CType(curRow("ITEMPER"), String) ',ITEMPER
                        .ItemPrice = CType(curRow("ITEMPRICE"), Double) ',ITEMPRICE
                        .ItemPrice = CType(curRow("AMOUNT"), Double) ',AMOUNT
                        .SortNumber = CType(curRow("SORTNUM"), Integer) ',SORTNUM
                        If CType(curRow("ISITEMFLG"), Integer) <> 0 Then ',ISITEMFLG
                            .IsActiveFlag = True
                        Else
                            .IsActiveFlag = False
                        End If

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
                    QuoteItemsEntityList.Add(objQuoteItemsEntity)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
        Return QuoteItemsEntityList
    End Function

End Class
