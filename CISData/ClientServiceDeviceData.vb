Option Strict On

Imports System.Collections.Generic
Imports CISEntity.ClientEntity
Imports System
Imports System.Data.SqlClient
Public Class ClientServiceDeviceData
    Public Function SaveNewClientServiceDevice(ByRef cisClientServiceDeviceEntity As CISEntity.ClientServiceDeviceEntity, ByVal prflID As Long) As Boolean
        Dim strSQL As String
        strSQL = "SET @CreateDate = GETDATE(); INSERT INTO [dbo].[CLIENTSERVICEDEVICETBL] "
        strSQL = strSQL + " ([DEVID] "
        strSQL = strSQL + "  ,[CLIENTSVCID] "
        strSQL = strSQL + "  ,[STATUS] "
        strSQL = strSQL + " ,[REMARKS] "
        strSQL = strSQL + " ,[ISACTIVEFLG] "
        strSQL = strSQL + " ,[PURGEFLG] "
        strSQL = strSQL + " ,[CRTDT] "
        strSQL = strSQL + " ,[CRTBY] "
        strSQL = strSQL + " ,[UPDDT] "
        strSQL = strSQL + " ,[UPDBY]) "
        strSQL = strSQL + " VALUES ("
        strSQL = strSQL + "'" + cisClientServiceDeviceEntity.DeviceID.ToString + "'"
        strSQL = strSQL + "," + cisClientServiceDeviceEntity.ClientServiceID.ToString + ""
        strSQL = strSQL + ",'" + cisClientServiceDeviceEntity.Status + "'"
        strSQL = strSQL + ",'" + cisClientServiceDeviceEntity.Remarks + "'" ',[REMARKS]
        If cisClientServiceDeviceEntity.IsActiveFlag Then
            strSQL = strSQL + ",1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",0" ',[ISACTIVEFLG]
        End If

        If cisClientServiceDeviceEntity.PurgeFlag Then
            strSQL = strSQL + ",1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",@CreateDate" ',[CRTDT]
        strSQL = strSQL + ",'" + prflID.ToString + "'" ',[CRTBY]
        strSQL = strSQL + ",@CreateDate" ',[UPDDT]
        strSQL = strSQL + ",'" + prflID.ToString + "'" ',[UPDBY]
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
        cisClientServiceDeviceEntity.ClientServiceDeviceID = CType(objParams(0).Value, Long)
        cisClientServiceDeviceEntity.CreateDate = CType(objParams(1).Value, DateTime)
        cisClientServiceDeviceEntity.UpdateDate = CType(objParams(1).Value, DateTime)

        Return True

    End Function

    Public Function InsertClientServiceDevice(ByVal prfleID As Long, ByVal lstDevicesAdd As List(Of CISEntity.ClientServiceDeviceEntity)) As Boolean

        For Each deviceAdd In lstDevicesAdd
            If deviceAdd.ClientServiceDeviceID = 0 Then
                'insert is good
                SaveNewClientServiceDevice(deviceAdd, prfleID)
            End If
        Next

        Return True
    End Function

    Public Function PurgeClientServiceDevice(ByVal prfleID As Long, ByVal lstDevicesPurge As List(Of CISEntity.ClientServiceDeviceEntity)) As Boolean
        For Each device In lstDevicesPurge
            If device.PurgeFlag AndAlso device.ClientServiceDeviceID > 0 Then
                PurgeClientServiceDevice(device.ClientServiceDeviceID, prfleID)
            End If
        Next

        Return True

    End Function

    Public Function SaveClientServiceDevice(ByRef cisClientServiceDeviceEntity As CISEntity.ClientServiceDeviceEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[CLIENTSERVICEDEVICETBL] "
        strSQL = strSQL + "Set [DEVID] = '" + cisClientServiceDeviceEntity.DeviceID.ToString + "'"
        strSQL = strSQL + " ,[CLIENTSVCID] = " + cisClientServiceDeviceEntity.ClientServiceID.ToString + ""
        strSQL = strSQL + " ,[STATUS] = '" + cisClientServiceDeviceEntity.Status + "'"
        strSQL = strSQL + ",[REMARKS] = '" + cisClientServiceDeviceEntity.Remarks + "'"
        If cisClientServiceDeviceEntity.IsActiveFlag Then
            strSQL = strSQL + ",[ISACTIVEFLG]=1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",[ISACTIVEFLG]=0" ',[ISACTIVEFLG]
        End If
        If cisClientServiceDeviceEntity.PurgeFlag Then
            strSQL = strSQL + ",[PURGEFLG]=1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",[PURGEFLG]=0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [CLSVCDEVID]=" + cisClientServiceDeviceEntity.ClientServiceDeviceID.ToString

        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NewUpdateDate", SqlDbType.DateTime)
        objParams(0).Value = Now
        objParams(0).Direction = ParameterDirection.InputOutput


        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        cisClientServiceDeviceEntity.UpdatedBy = prflID
        cisClientServiceDeviceEntity.UpdateDate = CType(objParams(0).Value, Date)

        Return True
    End Function

    Public Function PurgeClientServiceDevice(ByVal CliendServiceDeviceID As Long, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[CLIENTSERVICEDEVICETBL] "
        strSQL = strSQL + "Set [PURGEFLG]=1, ISACTIVEFLG=0" ',[PURGEFLG]
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [CLSVCDEVID]=" + CliendServiceDeviceID.ToString

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

    Public Function GetClientServiceDevice(ByVal ClientServiceDeviceID As Long) As CISEntity.ClientServiceDeviceEntity
        Dim objClientServiceDevice As New CISEntity.ClientServiceDeviceEntity
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        strSQL = "SELECT * FROM CLIENTSERVICEDEVICETBL" &
                " WHERE " &
                " [CLSVCDEVID]=" & ClientServiceDeviceID.ToString

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    With objClientServiceDevice
                        .ClientServiceDeviceID = CType(curRow("CLSVCDEVID"), Long)
                        .DeviceID = CType(curRow("DEVID"), Long) ',CLIENTCODE
                        .Status = CType(curRow("STATUS"), String) ',NAME
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
                Return objClientServiceDevice
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
    End Function

    Public Function GetClientServiceDeviceList(ByVal strWhereClause As String) As List(Of CISEntity.ClientServiceDeviceEntity)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing
        Dim objClientServiceDeviceEntityList As New List(Of CISEntity.ClientServiceDeviceEntity)

        strSQL = "SELECT * FROM CLIENTSERVICEDEVICETBL" &
                " WHERE " & strWhereClause


        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    Dim ClientServiceDeviceEntity As New CISEntity.ClientServiceDeviceEntity
                    With ClientServiceDeviceEntity
                        .ClientServiceDeviceID = CType(curRow("CLSVCDEVID"), Long)
                        .DeviceID = CType(curRow("DEVID"), Long) ',CLIENTCODE
                        .Status = CType(curRow("STATUS"), String) ',NAME
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
                    objClientServiceDeviceEntityList.Add(ClientServiceDeviceEntity)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
        Return objClientServiceDeviceEntityList
    End Function


    Public Function GetClientServiceDeviceTable(ByVal strWhereClause As String) As DataTable
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        strSQL = "SELECT * FROM CLIENTSERVICEDEVICETBL" &
                " WHERE " & strWhereClause

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)
            Return dt

        Else
            Return Nothing
        End If

        dt.Dispose()
        ds.Dispose()

    End Function

    Public Function VerifyDeviceAndClientServiceAvailable(ByVal DeviceID As Long, ByVal ClientServiceID As Long) As Boolean


        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        'strSQL = " SELECT "
        'strSQL = strSQL + " CLIENTSERVICEDEVICETBL.CLSVCDEVID "
        'strSQL = strSQL + " FROM "
        'strSQL = strSQL + " SERVICETBL INNER JOIN "
        'strSQL = strSQL + " CLIENTTBL INNER JOIN "
        'strSQL = strSQL + " CLIENTSERVICETBL ON CLIENTTBL.CLIENTID = CLIENTSERVICETBL.CLIENTID "
        'strSQL = strSQL + " ON SERVICETBL.SVCID = CLIENTSERVICETBL.SVCID INNER JOIN "
        'strSQL = strSQL + " DEVICETBL INNER JOIN "
        'strSQL = strSQL + " CLIENTSERVICEDEVICETBL ON DEVICETBL.DEVID = CLIENTSERVICEDEVICETBL.DEVID "
        'strSQL = strSQL + " ON CLIENTSERVICETBL.CLIENTSVCID = CLIENTSERVICEDEVICETBL.CLIENTSVCID "
        'strSQL = strSQL + " WHERE "
        ''(CLIENTSERVICETBL.CLIENTSVCID = " + ClientServiceID.ToString + " AND CLIENTSERVICETBL.ISACTIVE=1 AND CLIENTSERVICETBL.PURGEFLG = 0) AND"
        'strSQL = strSQL + " (DEVICETBL.DEVID = " + DeviceID.ToString + " AND DEVICETBL.ISACTIVE=1 AND DEVICETBL.PURGEFLG = 0) "

        strSQL = "SELECT [CLSVCDEVID], [DEVID] "
        strSQL = strSQL + "From [CLIENTSERVICEDEVICETBL] "
        strSQL = strSQL + "WHERE DEVID = " + DeviceID.ToString + " And [ISACTIVEFLG]=1 AND  [PURGEFLG]=0 "

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                Return False

            ElseIf dt.Rows.Count = 0 Then
                Return True
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If



        dt.Dispose()
        ds.Dispose()
    End Function
End Class
