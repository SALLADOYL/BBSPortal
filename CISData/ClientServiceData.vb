Option Strict On

Imports System.Collections.Generic
Imports CISEntity.ClientEntity
Imports System
Imports System.Data.SqlClient
Public Class ClientServiceData

    Public Function SaveNewClientService(ByRef cisClientService As CISEntity.ClientServiceEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "INSERT INTO [dbo].[CLIENTSERVICETBL] "
        'strSQL = strSQL + " ([CLIENTCODE] "
        strSQL = strSQL + " ([CLIENTID] "
        strSQL = strSQL + " ,[SVCID] "
        strSQL = strSQL + " ,[ISACTIVE] "
        strSQL = strSQL + " ,[PURGEFLG]) "
        strSQL = strSQL + " VALUES ("
        'strSQL = strSQL + "'" + cisClient.ClientCode + "'" '[ClientCode]
        strSQL = strSQL + "'" + cisClientService.ClientID.ToString + "'" ',[NAME]
        strSQL = strSQL + ",'" + cisClientService.ServiceID.ToString + "'" ',[ADDRESS]
        If cisClientService.IsActiveFlag Then
            strSQL = strSQL + ",1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",0" ',[ISACTIVEFLG]
        End If

        If cisClientService.PurgeFlag Then
            strSQL = strSQL + ",1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",0" ',[PURGEFLG]
        End If
        strSQL = strSQL & "); SET @NEWCLIENTSVCID = SCOPE_IDENTITY();"

        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NEWCLIENTSVCID", SqlDbType.BigInt)
        objParams(0).Value = 0
        objParams(0).Direction = ParameterDirection.InputOutput

        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        ''retrieve new clientID
        cisClientService.ClientID = CType(objParams(0).Value, Long)


        Return True
    End Function

    Public Function SaveClientService(ByRef cisClientService As CISEntity.ClientServiceEntity, ByVal prflID As Long) As Boolean
        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[CLIENTSERVICETBL] "
        strSQL = strSQL + "Set [CLIENTID] = '" + cisClientService.ClientID.ToString + "'"
        strSQL = strSQL + " ,[SVCID] = '" + cisClientService.ServiceID.ToString + "'"
        If cisClientService.IsActiveFlag Then
            strSQL = strSQL + " ,[ISACTIVE]=1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + " ,[ISACTIVE]=0" ',[ISACTIVEFLG]
        End If
        If cisClientService.PurgeFlag Then
            strSQL = strSQL + " ,[PURGEFLG]=1" ',[PURGEFLG]
        Else
            strSQL = strSQL + " ,[PURGEFLG]=0" ',[PURGEFLG]
        End If
        strSQL = strSQL + " WHERE [CLIENTSVCID]=" + cisClientService.ClientServiceID.ToString

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

    Public Function PurgeClientService(ByVal CLIENTSVCID As Long, ByVal prflID As Long) As Boolean
        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[CLIENTSERVICETBL] "
        strSQL = strSQL + "Set  [PURGEFLG]=1" ',[PURGEFLG]

        strSQL = strSQL + " WHERE [CLIENTSVCID]=" + CLIENTSVCID.ToString

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

    Public Function GetClientService(ByVal ClientServiceID As Long) As CISEntity.ClientServiceEntity
        Dim objClientServiceEntity As New CISEntity.ClientServiceEntity
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        strSQL = "SELECT * FROM CLIENTSERVICETBL" &
                " WHERE " &
                " [CLIENTSVCID]=" & ClientServiceID.ToString

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    With objClientServiceEntity
                        .ClientServiceID = CType(curRow("CLIENTSVCID"), Long)
                        .ClientID = CType(curRow("CLIENTID"), Long)
                        .ServiceID = CType(curRow("SVCID"), Long)

                        If CType(curRow("ISACTIVE"), Integer) <> 0 Then ',ISACTIVEFLG
                            .IsActiveFlag = True
                        Else
                            .IsActiveFlag = False
                        End If

                        If CType(curRow("PURGEFLG"), Integer) <> 0 Then ',PURGEFLG
                            .PurgeFlag = True
                        Else
                            .PurgeFlag = False
                        End If
                    End With

                Next
                Return objClientServiceEntity
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
    End Function

    Public Function GetClientService(ByVal ClientID As Long, ByVal ServiceID As Long) As CISEntity.ClientServiceEntity
        Dim objClientServiceEntity As New CISEntity.ClientServiceEntity
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        strSQL = "SELECT * FROM CLIENTSERVICETBL" &
                " WHERE " &
                " CLIENTID=" & ClientID.ToString & " AND SVCID=" & ServiceID.ToString

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    With objClientServiceEntity
                        .ClientServiceID = CType(curRow("CLIENTSVCID"), Long)
                        .ClientID = CType(curRow("CLIENTID"), Long)
                        .ServiceID = CType(curRow("SVCID"), Long)

                        If CType(curRow("ISACTIVE"), Integer) <> 0 Then ',ISACTIVEFLG
                            .IsActiveFlag = True
                        Else
                            .IsActiveFlag = False
                        End If

                        If CType(curRow("PURGEFLG"), Integer) <> 0 Then ',PURGEFLG
                            .PurgeFlag = True
                        Else
                            .PurgeFlag = False
                        End If
                    End With

                Next
                Return objClientServiceEntity
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
    End Function

    Public Function GetClientServiceList(ByVal StrWhereClause As String) As List(Of CISEntity.ClientServiceEntity)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing
        Dim objClientServiceEntityList As New List(Of CISEntity.ClientServiceEntity)

        strSQL = "SELECT * FROM CLIENTSERVICETBL" &
                " WHERE " & StrWhereClause

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)
        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    Dim objClientServiceEntity As New CISEntity.ClientServiceEntity
                    With objClientServiceEntity
                        .ClientServiceID = CType(curRow("CLIENTSVCID"), Long)
                        .ClientID = CType(curRow("CLIENTID"), Long)
                        .ServiceID = CType(curRow("SVCID"), Long)

                        If CType(curRow("ISACTIVE"), Integer) <> 0 Then ',ISACTIVEFLG
                            .IsActiveFlag = True
                        Else
                            .IsActiveFlag = False
                        End If

                        If CType(curRow("PURGEFLG"), Integer) <> 0 Then ',PURGEFLG
                            .PurgeFlag = True
                        Else
                            .PurgeFlag = False
                        End If
                    End With
                    objClientServiceEntityList.Add(objClientServiceEntity)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
        Return objClientServiceEntityList
    End Function

    Public Function GetSubscribedServices(ByVal clientID As Long) As DataTable
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing
        Dim objClientServiceEntityList As New List(Of CISEntity.ClientServiceEntity)

        strSQL = " SELECT CLIENTTBL.NAME, CLIENTSERVICETBL.SVCID, SERVICETBL.SERVIENAME, CLIENTSERVICETBL.CLIENTSVCID "
        strSQL = strSQL + " FROM CLIENTTBL INNER JOIN"
        strSQL = strSQL + " CLIENTSERVICETBL ON CLIENTTBL.CLIENTID = CLIENTSERVICETBL.CLIENTID INNER JOIN"
        strSQL = strSQL + " SERVICETBL ON CLIENTSERVICETBL.SVCID = SERVICETBL.SVCID"
        strSQL = strSQL + " WHERE"
        strSQL = strSQL + " (SERVICETBL.ISACTIVEFLG = 1)"
        strSQL = strSQL + " AND (CLIENTTBL.ISACTIVEFLG = 1)"
        strSQL = strSQL + " AND (CLIENTTBL.CLIENTID=" + clientID.ToString + ")"

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)
        If ds.Tables.Count > 0 Then
            Return ds.Tables(0)
        Else
            Return Nothing
        End If
        Return Nothing
    End Function

    Public Function GetUnsubscribedServices(ByVal ClientID As Long) As DataTable
        'SELECT * FROM SERVICETBL
        'WHERE
        'IsActiveFlg = 1
        'And PURGEFLG = 0
        'And [SVCID] Not IN (SELECT [SVCID] FROM [CLIENTSERVICETBL] WHERE ISACTIVE=1 And PURGEFLG=0 And CLIENTID=4)

        Dim strSQL As String
        strSQL = "SELECT '' AS SERVICENAME, 0 AS SERVICEID "
        strSQL = strSQL + " UNION SELECT "
        strSQL = strSQL + " SERVIENAME AS SERVICENAME, SVCID as SERVICEID "
        strSQL = strSQL + " FROM SERVICETBL "
        strSQL = strSQL + " WHERE IsActiveFlg = 1 And PURGEFLG = 0 "
        strSQL = strSQL + " And [SVCID] Not IN (SELECT [SVCID] FROM [CLIENTSERVICETBL] WHERE ISACTIVE=1 And PURGEFLG=0 And CLIENTID=" + ClientID.ToString + ")"
        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)
    End Function
End Class
