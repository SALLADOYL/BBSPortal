Option Strict On

Imports System.Collections.Generic
Imports CISEntity.ClientEntity
Imports System
Imports System.Data.SqlClient
Public Class ClientData

    Public Function SaveNewClient(ByRef cisClient As CISEntity.ClientEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @CreateDate = GETDATE(); INSERT INTO [dbo].[CLIENTTBL] "
        strSQL = strSQL + " ([CLIENTCODE] "
        strSQL = strSQL + " ,[NAME] "
        strSQL = strSQL + " ,[ADDRESS] "
        strSQL = strSQL + " ,[INDUSTRY] "
        strSQL = strSQL + " ,[CONTACTNUMBER] "
        strSQL = strSQL + " ,[FAX] "
        strSQL = strSQL + " ,[WEBSITE] "
        strSQL = strSQL + " ,[EMAILADDRESS] "
        strSQL = strSQL + " ,[REMARKS] "
        strSQL = strSQL + " ,[ISACTIVEFLG] "
        strSQL = strSQL + " ,[PURGEFLG] "
        strSQL = strSQL + " ,[CRTDT] "
        strSQL = strSQL + " ,[CRTBY] "
        strSQL = strSQL + " ,[UPDDT] "
        strSQL = strSQL + " ,[UPDBY]) "
        strSQL = strSQL + " VALUES ("
        strSQL = strSQL + "'" + cisClient.ClientCode + "'" '[ClientCode]
        strSQL = strSQL + ",'" + cisClient.Name + "'" ',[NAME]
        strSQL = strSQL + ",'" + cisClient.Address + "'" ',[ADDRESS]
        strSQL = strSQL + ",'" + cisClient.Industry + "'" ',[INDUSTRY]
        strSQL = strSQL + ",'" + cisClient.ContactNumber + "'" ',[CONTACTNUMBER]
        strSQL = strSQL + ",'" + cisClient.Fax + "'" ',[FAX]
        strSQL = strSQL + ",'" + cisClient.Website + "'" ',[WEBSITE]
        strSQL = strSQL + ",'" + cisClient.EmailAddress + "'" ',[EMAILADDRESS]
        strSQL = strSQL + ",'" + cisClient.Remarks + "'" ',[REMARKS]
        If cisClient.IsActiveFlg Then
            strSQL = strSQL + ",1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",0" ',[ISACTIVEFLG]
        End If

        If cisClient.PurgeFlg Then
            strSQL = strSQL + ",1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",@CreateDate" ',[CRTDT]
        strSQL = strSQL + ",'" + cisClient.CreatedBy.ToString + "'" ',[CRTBY]
        strSQL = strSQL + ",@CreateDate" ',[UPDDT]
        strSQL = strSQL + ",'" + cisClient.UpdatedBy.ToString + "'" ',[UPDBY]
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
        cisClient.ClientID = CType(objParams(0).Value, Long)
        cisClient.CreateDate = CType(objParams(1).Value, DateTime)
        cisClient.UpdateDate = CType(objParams(1).Value, DateTime)

        Return True
    End Function

    Public Function SaveClient(ByRef cisClient As CISEntity.ClientEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[CLIENTTBL] "
        strSQL = strSQL + "Set [CLIENTCODE] = '" + cisClient.ClientCode + "'"
        strSQL = strSQL + " ,[NAME] = '" + cisClient.Name + "'"
        strSQL = strSQL + ",[ADDRESS] = '" + cisClient.Address + "'"
        strSQL = strSQL + ",[INDUSTRY] = '" + cisClient.Industry + "'"
        strSQL = strSQL + ",[CONTACTNUMBER] = '" + cisClient.ContactNumber + "'"
        strSQL = strSQL + ",[FAX] = '" + cisClient.Fax + "'"
        strSQL = strSQL + ",[WEBSITE] = '" + cisClient.Website + "'"
        strSQL = strSQL + ",[EMAILADDRESS] = '" + cisClient.EmailAddress + "'"
        strSQL = strSQL + ",[REMARKS] = '" + cisClient.Remarks + "'"
        If cisClient.IsActiveFlg Then
            strSQL = strSQL + ",[ISACTIVEFLG]=1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",[ISACTIVEFLG]=0" ',[ISACTIVEFLG]
        End If
        If cisClient.PurgeFlg Then
            strSQL = strSQL + ",[PURGEFLG]=1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",[PURGEFLG]=0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [CLIENTID]=" + cisClient.ClientID.ToString

        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NewUpdateDate", SqlDbType.DateTime)
        objParams(0).Value = Now
        objParams(0).Direction = ParameterDirection.InputOutput


        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        cisClient.UpdatedBy = prflID
        cisClient.UpdateDate = CType(objParams(0).Value, Date)

        Return True
    End Function

    Public Function PurgeClient(ByVal ClientID As Long, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[CLIENTTBL] "
        strSQL = strSQL + "Set [PURGEFLG]=1" ',[PURGEFLG]
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [CLIENTID]=" + ClientID.ToString

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

    Public Function GetClient(ByVal ClientID As Long) As CISEntity.ClientEntity
        Dim objClientEntity As New CISEntity.ClientEntity
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        strSQL = "SELECT * FROM CLIENTTBL" &
                " WHERE " &
                " [CLIENTID]=" & ClientID.ToString

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    With objClientEntity
                        .ClientID = CType(curRow("ClientID"), Long)
                        .ClientCode = CType(curRow("CLIENTCODE"), String) ',CLIENTCODE
                        .Name = CType(curRow("NAME"), String) ',NAME
                        .Address = CType(curRow("ADDRESS"), String) ',ADDRESS
                        .Industry = CType(curRow("INDUSTRY"), String) ',INDUSTRY
                        .ContactNumber = CType(curRow("CONTACTNUMBER"), String)  ',CONTACTNUMBER
                        .Fax = CType(curRow("FAX"), String) ',FAX
                        .Website = CType(curRow("WEBSITE"), String) ',WEBSITE
                        .EmailAddress = CType(curRow("EMAILADDRESS"), String) ',EMAILADDRESS
                        .Remarks = CType(curRow("REMARKS"), String) ',REMARKS
                        If CType(curRow("ISACTIVEFLG"), Integer) <> 0 Then ',ISACTIVEFLG
                            .IsActiveFlg = True
                        Else
                            .IsActiveFlg = False
                        End If

                        If CType(curRow("PURGEFLG"), Integer) <> 0 Then ',PURGEFLG
                            .PurgeFlg = True
                        Else
                            .PurgeFlg = False
                        End If
                        .CreateDate = CType(curRow("CRTDT"), DateTime) ',CRTDT
                        .CreatedBy = CType(curRow("CRTBY"), Long) ',CRTBY
                        .UpdateDate = CType(curRow("UPDDT"), DateTime) ',UPDDT
                        .UpdatedBy = CType(curRow("UPDBY"), Long) ',UPDBY
                        '. = CType(curRow("TMPSTMP"), String) ',TMPSTMP

                    End With

                Next
                Return objClientEntity
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
    End Function

    Public Function GetClientList(ByVal strWhereClause As String) As List(Of CISEntity.ClientEntity)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing
        Dim objClientEntityList As New List(Of CISEntity.ClientEntity)

        strSQL = "SELECT * FROM CLIENTTBL" &
                " WHERE " & strWhereClause


        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    Dim objClientEntity As New CISEntity.ClientEntity
                    With objClientEntity
                        .ClientID = CType(curRow("ClientID"), Long)
                        .ClientCode = CType(curRow("CLIENTCODE"), String) ',CLIENTCODE
                        .Name = CType(curRow("NAME"), String) ',NAME
                        .Address = CType(curRow("ADDRESS"), String) ',ADDRESS
                        .Industry = CType(curRow("INDUSTRY"), String) ',INDUSTRY
                        .ContactNumber = CType(curRow("CONTACTNUMBER"), String)  ',CONTACTNUMBER
                        .Fax = CType(curRow("FAX"), String) ',FAX
                        .Website = CType(curRow("WEBSITE"), String) ',WEBSITE
                        .EmailAddress = CType(curRow("EMAILADDRESS"), String) ',EMAILADDRESS
                        .Remarks = CType(curRow("REMARKS"), String) ',REMARKS
                        If CType(curRow("ISACTIVEFLG"), Integer) <> 0 Then ',ISACTIVEFLG
                            .IsActiveFlg = True
                        Else
                            .IsActiveFlg = False
                        End If

                        If CType(curRow("PURGEFLG"), Integer) <> 0 Then ',PURGEFLG
                            .PurgeFlg = True
                        Else
                            .PurgeFlg = False
                        End If
                        .CreateDate = CType(curRow("CRTDT"), DateTime) ',CRTDT
                        .CreatedBy = CType(curRow("CRTBY"), Long) ',CRTBY
                        .UpdateDate = CType(curRow("UPDDT"), DateTime) ',UPDDT
                        .UpdatedBy = CType(curRow("UPDBY"), Long) ',UPDBY
                        '. = CType(curRow("TMPSTMP"), String) ',TMPSTMP

                    End With
                    objClientEntityList.Add(objClientEntity)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
        Return objClientEntityList
    End Function

    Public Function GetClientListByName(ByVal strClientName As String, ByVal isWildCardSearch As Boolean) As List(Of CISEntity.ClientEntity)
        Dim oclientdata As New ClientData
        Dim objClientEntities As New List(Of CISEntity.ClientEntity)
        If isWildCardSearch Then
            objClientEntities = oclientdata.GetClientList("[NAME] like '%" + strClientName + "%'")
        Else
            objClientEntities = oclientdata.GetClientList("[NAME] = '" + strClientName + "'")
        End If
        Return objClientEntities
    End Function

    Public Function GetClientListByClientCode(ByVal strClientCode As String, ByVal isWildCardSearch As Boolean) As List(Of CISEntity.ClientEntity)
        Dim oclientdata As New ClientData
        Dim objClientEntities As New List(Of CISEntity.ClientEntity)
        If isWildCardSearch Then
            objClientEntities = oclientdata.GetClientList("[CLIENTCODE] like '%" + strClientCode + "%'")
        Else
            objClientEntities = oclientdata.GetClientList("[CLIENTCODE] = '" + strClientCode + "'")
        End If
        Return objClientEntities
    End Function
End Class
