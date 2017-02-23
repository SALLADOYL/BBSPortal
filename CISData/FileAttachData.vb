Option Strict On

Imports System.Collections.Generic
Imports CISEntity.ClientEntity
Imports System
Imports System.Data.SqlClient
Public Class FileAttachData

    Public Function SaveNew(ByRef cisFileAttachEntity As CISEntity.FileAttachEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @CreateDate = GETDATE(); INSERT INTO [dbo].[FILEATTACHTBL] "
        strSQL = strSQL + " ([ATTACHMENTTYPE] "
        strSQL = strSQL + " ,[PARENTID] "
        strSQL = strSQL + " ,[FILEPATH] "
        strSQL = strSQL + " ,[REMARKS] "
        strSQL = strSQL + " ,[ISACTIVEFLG] "
        strSQL = strSQL + " ,[PURGEFLG] "
        strSQL = strSQL + " ,[CRTDT] "
        strSQL = strSQL + " ,[CRTBY] "
        strSQL = strSQL + " ,[UPDDT] "
        strSQL = strSQL + " ,[UPDBY]) "
        strSQL = strSQL + " VALUES ("
        strSQL = strSQL + "'" + cisFileAttachEntity.AttachmentType + "'" '[ClientCode]
        strSQL = strSQL + ",'" + cisFileAttachEntity.ParentID.ToString + "'" ',[NAME]
        strSQL = strSQL + ",'" + cisFileAttachEntity.FilePath + "'" ',[ADDRESS]
        strSQL = strSQL + ",'" + cisFileAttachEntity.Remarks + "'" ',[REMARKS]
        If cisFileAttachEntity.IsActiveFlag Then
            strSQL = strSQL + ",1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",0" ',[ISACTIVEFLG]
        End If

        If cisFileAttachEntity.PurgeFlag Then
            strSQL = strSQL + ",1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",@CreateDate" ',[CRTDT]
        strSQL = strSQL + ",'" + cisFileAttachEntity.CreatedBy.ToString + "'" ',[CRTBY]
        strSQL = strSQL + ",@CreateDate" ',[UPDDT]
        strSQL = strSQL + ",'" + cisFileAttachEntity.UpdatedBy.ToString + "'" ',[UPDBY]
        strSQL = strSQL & "); SET @NewID = SCOPE_IDENTITY(); "
        '<TYPE>-FILEID-FILENAME
        'strSQL = strSQL & " UPDATE [dbo].[FILEATTACHTBL] SET [FILEPATH] ='" + cisFileAttachEntity.AttachmentType + "'"

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
        cisFileAttachEntity.FileID = CType(objParams(0).Value, Long)
        cisFileAttachEntity.CreateDate = CType(objParams(1).Value, DateTime)
        cisFileAttachEntity.UpdateDate = CType(objParams(1).Value, DateTime)

        Return True
    End Function

    Public Function Save(ByRef cisFileAttachEntity As CISEntity.FileAttachEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[FILEATTACHTBL] "
        strSQL = strSQL + "Set [ATTACHMENTTYPE] = '" + cisFileAttachEntity.AttachmentType + "'"
        strSQL = strSQL + " ,[PARENTID] = '" + cisFileAttachEntity.ParentID.ToString + "'"
        strSQL = strSQL + ",[FILEPATH] = '" + cisFileAttachEntity.FilePath + "'"
        strSQL = strSQL + ",[REMARKS] = '" + cisFileAttachEntity.Remarks + "'"
        If cisFileAttachEntity.IsActiveFlag Then
            strSQL = strSQL + ",[ISACTIVEFLG]=1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",[ISACTIVEFLG]=0" ',[ISACTIVEFLG]
        End If
        If cisFileAttachEntity.PurgeFlag Then
            strSQL = strSQL + ",[PURGEFLG]=1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",[PURGEFLG]=0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [FILEID]=" + cisFileAttachEntity.FileID.ToString

        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NewUpdateDate", SqlDbType.DateTime)
        objParams(0).Value = Now
        objParams(0).Direction = ParameterDirection.InputOutput


        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        cisFileAttachEntity.UpdatedBy = prflID
        cisFileAttachEntity.UpdateDate = CType(objParams(0).Value, Date)

        Return True
    End Function

    Public Function Purge(ByVal FILEID As Long, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[FILEATTACHTBL] "
        strSQL = strSQL + "Set [PURGEFLG]=1" ',[PURGEFLG]
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [FILEID]=" + FILEID.ToString

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

    Public Function GetFileAttach(ByVal FILEID As Long) As CISEntity.FileAttachEntity
        Dim objFileAttachEntity As New CISEntity.FileAttachEntity
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        strSQL = "SELECT * FROM FILEATTACHTBL" &
                " WHERE " &
                " [FILEID]=" & FILEID.ToString

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    With objFileAttachEntity
                        .FileID = CType(curRow("FILEID"), Long)
                        .AttachmentType = CType(curRow("ATTACHMENTTYPE"), String) ',ATTACHMENTTYPE
                        .ParentID = CType(curRow("PARENTID"), Long) ',PARENTID
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
                Return objFileAttachEntity
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
    End Function

    Public Function GetList(ByVal strWhereClause As String) As List(Of CISEntity.FileAttachEntity)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing
        Dim listFileAttachEntity As New List(Of CISEntity.FileAttachEntity)

        strSQL = "SELECT * FROM FILEATTACHTBL" &
                " WHERE " & strWhereClause


        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    Dim objFileAttachEntity As New CISEntity.FileAttachEntity
                    With objFileAttachEntity
                        .FileID = CType(curRow("FILEID"), Long)
                        .AttachmentType = CType(curRow("ATTACHMENTTYPE"), String) ',ATTACHMENTTYPE
                        .ParentID = CType(curRow("PARENTID"), Long) ',PARENTID
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
                    listFileAttachEntity.Add(objFileAttachEntity)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
        Return listFileAttachEntity
    End Function

    Public Function GetClientAttachmentsList(ByVal clientID As Long) As DataTable
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        strSQL = "SELECT * FROM dbo.FILEATTACHTBL"
        strSQL = strSQL + " WHERE"
        strSQL = strSQL + " (ATTACHMENTTYPE = 'CL')"
        strSQL = strSQL + " AND (PARENTID = " + clientID.ToString + ")"
        strSQL = strSQL + " AND (ISACTIVEFLG = 1)"
        strSQL = strSQL + " AND (PURGEFLG = 0)"

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)
        If ds.Tables.Count > 0 Then
            Return ds.Tables(0)
        Else
            Return Nothing
        End If
        Return Nothing
    End Function


End Class
