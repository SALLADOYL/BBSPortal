Option Strict On

Imports System.Collections.Generic
Imports CISEntity.ClientEntity
Imports System
Imports System.Data.SqlClient
Public Class NotesData

    Public Function SaveNew(ByRef cisNotesEntity As CISEntity.NotesEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String

        'NOTEID
        ',PARENTTYPE
        ',PARENTID
        ',NOTEDATE
        ',NOTETEXT

        strSQL = "SET @CreateDate = GETDATE(); INSERT INTO [dbo].[NOTESTBL] "
        strSQL = strSQL + " ([PARENTTYPE] "
        strSQL = strSQL + " ,[PARENTID] "
        strSQL = strSQL + " ,[NOTEDATE] "
        strSQL = strSQL + " ,[NOTETEXT] "
        strSQL = strSQL + " ,[ISACTIVEFLG] "
        strSQL = strSQL + " ,[PURGEFLG] "
        strSQL = strSQL + " ,[CRTDT] "
        strSQL = strSQL + " ,[CRTBY] "
        strSQL = strSQL + " ,[UPDDT] "
        strSQL = strSQL + " ,[UPDBY]) "
        strSQL = strSQL + " VALUES ("
        strSQL = strSQL + "'" + cisNotesEntity.ParentType + "'" '[]
        strSQL = strSQL + ",'" + cisNotesEntity.ParentID.ToString + "'" ',
        strSQL = strSQL + ",'" + cisNotesEntity.NoteDate.ToString("MM/dd/yyyy HH:mm:ss") + "'" ',
        strSQL = strSQL + ",'" + cisNotesEntity.NoteText + "'" ',
        If cisNotesEntity.IsActiveFlag Then
            strSQL = strSQL + ",1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",0" ',[ISACTIVEFLG]
        End If

        If cisNotesEntity.PurgeFlag Then
            strSQL = strSQL + ",1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",@CreateDate" ',[CRTDT]
        strSQL = strSQL + ",'" + cisNotesEntity.CreatedBy.ToString + "'" ',[CRTBY]
        strSQL = strSQL + ",@CreateDate" ',[UPDDT]
        strSQL = strSQL + ",'" + cisNotesEntity.UpdatedBy.ToString + "'" ',[UPDBY]
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

        ''retrieve new clientID
        cisNotesEntity.NoteID = CType(objParams(0).Value, Long)
        cisNotesEntity.CreateDate = CType(objParams(1).Value, DateTime)
        cisNotesEntity.UpdateDate = CType(objParams(1).Value, DateTime)

        Return True
    End Function

    Public Function SaveNote(ByRef cisNotesEntity As CISEntity.NotesEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String

        ',PARENTTYPE
        ',PARENTID
        ',NOTEDATE
        ',NOTETEXT

        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[NOTESTBL] "
        strSQL = strSQL + "Set [PARENTTYPE] = '" + cisNotesEntity.ParentType + "'"
        strSQL = strSQL + " ,[NOTEDATE] = '" + cisNotesEntity.NoteDate.ToString("MM/dd/yyyy HH:mm:ss") + "'"
        strSQL = strSQL + ",[NOTETEXT] = '" + cisNotesEntity.NoteText + "'"
        If cisNotesEntity.IsActiveFlag Then
            strSQL = strSQL + ",[ISACTIVEFLG]=1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",[ISACTIVEFLG]=0" ',[ISACTIVEFLG]
        End If
        If cisNotesEntity.PurgeFlag Then
            strSQL = strSQL + ",[PURGEFLG]=1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",[PURGEFLG]=0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [NOTEID]=" + cisNotesEntity.NoteID.ToString

        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NewUpdateDate", SqlDbType.DateTime)
        objParams(0).Value = Now
        objParams(0).Direction = ParameterDirection.InputOutput


        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        cisNotesEntity.UpdatedBy = prflID
        cisNotesEntity.UpdateDate = CType(objParams(0).Value, Date)

        Return True
    End Function

    Public Function PurgeNote(ByVal NoteID As Long, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[NOTESTBL] "
        strSQL = strSQL + "Set [PURGEFLG]=1" ',[PURGEFLG]
        strSQL = strSQL + ",[ISACTIVEFLG] = 0" '[ISACTIVEFLG]
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [NoteID]=" + NoteID.ToString

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

    Public Function GetNote(ByVal NoteID As Long) As CISEntity.NotesEntity
        Dim objNotesEntity As New CISEntity.NotesEntity
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        strSQL = "SELECT * FROM NOTESTBL" &
                " WHERE " &
                " [NOTEID]=" & NoteID.ToString

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    With objNotesEntity

                        .NoteID = CType(curRow("NoteID"), Long)
                        .ParentType = CType(curRow("PARENTTYPE"), String) ',
                        .ParentID = CType(curRow("PARENTID"), Long) ',
                        .NoteDate = CType(curRow("NOTEDATE"), DateTime) ',
                        .NoteText = CType(curRow("NOTETEXT"), String) ',
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
                Return objNotesEntity
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
    End Function

    Public Function GetList(ByVal strWhereClause As String) As List(Of CISEntity.NotesEntity)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing
        Dim listNotesEntity As New List(Of CISEntity.NotesEntity)

        strSQL = "SELECT * FROM NOTESTBL" &
                " WHERE " & strWhereClause


        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    Dim objNotesEntity As New CISEntity.NotesEntity
                    With objNotesEntity
                        .NoteID = CType(curRow("NoteID"), Long)
                        .ParentType = CType(curRow("PARENTTYPE"), String) ',
                        .ParentID = CType(curRow("PARENTID"), Long) ',
                        .NoteDate = CType(curRow("NOTEDATE"), DateTime) ',
                        .NoteText = CType(curRow("NOTETEXT"), String) ',
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
                    listNotesEntity.Add(objNotesEntity)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
        Return listNotesEntity
    End Function

    Public Function GetClientNoteList(ByVal ClientID As Long) As DataTable
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        strSQL = "SELECT * FROM dbo.NOTESTBL"
        strSQL = strSQL + " WHERE"
        strSQL = strSQL + " (PARENTTYPE = 'CL')"
        strSQL = strSQL + " AND (PARENTID = " + ClientID.ToString + ")"
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

    Public Function GetDeviceNoteList(ByVal DeviceID As Long) As DataTable
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        strSQL = "SELECT * FROM dbo.NOTESTBL"
        strSQL = strSQL + " WHERE"
        strSQL = strSQL + " (PARENTTYPE = 'DEV')"
        strSQL = strSQL + " AND (PARENTID = " + DeviceID.ToString + ")"
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
