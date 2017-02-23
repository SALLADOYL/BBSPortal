Option Strict On

Imports System.Collections.Generic
Imports CISEntity.ClientEntity
Imports System
Imports System.Data.SqlClient
Public Class DeviceData
    Public Function SaveNewDevice(ByRef cisDevice As CISEntity.DeviceEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @CreateDate = GETDATE(); INSERT INTO [dbo].[DEVICETBL] "
        strSQL = strSQL + " ([ITEMCODE] "
        strSQL = strSQL + " ,[DEVICENAME] "
        strSQL = strSQL + " ,[DEVICETYPE] "
        strSQL = strSQL + " ,[SERIALNUMBER] "
        strSQL = strSQL + " ,[DEVICESPECS] "

        strSQL = strSQL + " ,[STATUS] "
        strSQL = strSQL + " ,[MANUFACTUREDATE] "
        strSQL = strSQL + " ,[RECEIVEDATE] "
        strSQL = strSQL + " ,[ISAVAILABLE] "

        strSQL = strSQL + " ,[IPADDRESS] " ',IPADDRESS
        strSQL = strSQL + " ,[BRANDTYPE] " ',BRANDTYPE
        strSQL = strSQL + " ,[MODEL] " ',MODEL
        strSQL = strSQL + " ,[HOSTNAME] "   ',HOSTNAME
        strSQL = strSQL + " ,[USERNAME] "   ',USERNAME
        strSQL = strSQL + " ,[PASSWORD] "  ',PASSWORD
        strSQL = strSQL + " ,[MAC] " ',MAC
        strSQL = strSQL + " ,[FIRMWAREVERSION] "  ',FIRMWAREVERSION
        strSQL = strSQL + " ,[DEFAULTIPADDRESS] "   ',DEFAULTIPADDRESS
        strSQL = strSQL + " ,[STREAM1RESOLUTION] " ',STREAM1RESOLUTION
        strSQL = strSQL + " ,[STREAM1FPS] " ',STTREAM1FPS

        strSQL = strSQL + " ,[REMARKS] "
        strSQL = strSQL + " ,[ISACTIVEFLG] "
        strSQL = strSQL + " ,[PURGEFLG] "
        strSQL = strSQL + " ,[CRTDT] "
        strSQL = strSQL + " ,[CRTBY] "
        strSQL = strSQL + " ,[UPDDT] "
        strSQL = strSQL + " ,[UPDBY]) "
        strSQL = strSQL + " VALUES ("
        strSQL = strSQL + "'" + cisDevice.ItemCode + "'"
        strSQL = strSQL + ",'" + cisDevice.DeviceName + "'" ',
        strSQL = strSQL + ",'" + cisDevice.DeviceType + "'" ',
        strSQL = strSQL + ",'" + cisDevice.SerialNumber + "'" ',
        strSQL = strSQL + ",'" + cisDevice.DeviceSpecifications + "'" ',
        strSQL = strSQL + ",'" + cisDevice.Status + "'" ',
        strSQL = strSQL + ",'" + cisDevice.ManufactureDate.ToString + "'" ',

        strSQL = strSQL + ",'" + cisDevice.ReceiveDate.ToString + "'" ',
        If cisDevice.IsAvailable Then
            strSQL = strSQL + ",1" ',[ISAVAILABLE]
        Else
            strSQL = strSQL + ",0" ',[ISAVAILABLE]
        End If

        strSQL = strSQL + ",'" + cisDevice.IPAddress + "'" ',IPADDRESS
        strSQL = strSQL + ",'" + cisDevice.BrandType + "'" ',BRANDTYPE
        strSQL = strSQL + ",'" + cisDevice.Model + "'" ',MODEL
        strSQL = strSQL + ",'" + cisDevice.HostName + "'" ',HOSTNAME
        strSQL = strSQL + ",'" + cisDevice.UserName + "'" ',USERNAME
        strSQL = strSQL + ",'" + cisDevice.Password + "'" ',PASSWORD
        strSQL = strSQL + ",'" + cisDevice.MACAddress + "'" ',MAC
        strSQL = strSQL + ",'" + cisDevice.FirmwareVersion + "'" ',FIRMWAREVERSION
        strSQL = strSQL + ",'" + cisDevice.DefaultIPAddress + "'" ',DEFAULTIPADDRESS
        strSQL = strSQL + ",'" + cisDevice.Stream1Resolution + "'" ',STREAM1RESOLUTION
        strSQL = strSQL + ",'" + cisDevice.Stream1FPS + "'"  ',STREAM1FPS

        strSQL = strSQL + ",'" + cisDevice.Remarks + "'" ',[REMARKS]
        If cisDevice.IsActiveFlag Then
            strSQL = strSQL + ",1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",0" ',[ISACTIVEFLG]
        End If

        If cisDevice.PurgeFlag Then
            strSQL = strSQL + ",1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",@CreateDate" ',[CRTDT]
        strSQL = strSQL + ",'" + cisDevice.CreatedBy.ToString + "'" ',[CRTBY]
        strSQL = strSQL + ",@CreateDate" ',[UPDDT]
        strSQL = strSQL + ",'" + cisDevice.UpdatedBy.ToString + "'" ',[UPDBY]
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
        cisDevice.DeviceID = CType(objParams(0).Value, Long)
        cisDevice.CreateDate = CType(objParams(1).Value, DateTime)
        cisDevice.UpdateDate = CType(objParams(1).Value, DateTime)

        Return True
    End Function

    Public Function SaveDevice(ByRef cisDeviceEntity As CISEntity.DeviceEntity, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[DEVICETBL] "
        strSQL = strSQL + "Set [ITEMCODE] = '" + cisDeviceEntity.ItemCode + "'"
        strSQL = strSQL + " ,[DEVICENAME] = '" + cisDeviceEntity.DeviceName + "'"
        strSQL = strSQL + ",[DEVICETYPE] = '" + cisDeviceEntity.DeviceType + "'"
        strSQL = strSQL + ",[SERIALNUMBER] = '" + cisDeviceEntity.SerialNumber + "'"
        strSQL = strSQL + ",[DEVICESPECS] = '" + cisDeviceEntity.DeviceSpecifications + "'"
        strSQL = strSQL + ",[STATUS] = '" + cisDeviceEntity.Status + "'"
        strSQL = strSQL + ",[MANUFACTUREDATE] = '" + cisDeviceEntity.ManufactureDate.ToString + "'"
        strSQL = strSQL + ",[RECEIVEDATE] = '" + cisDeviceEntity.ReceiveDate.ToString + "'"
        If cisDeviceEntity.IsAvailable Then
            strSQL = strSQL + ",[ISAVAILABLE]=1" ',[ISAVAILABLE]
        Else
            strSQL = strSQL + ",[ISAVAILABLE]=0" ',[ISAVAILABLE]
        End If

        strSQL = strSQL + ",[IPADDRESS] = '" + cisDeviceEntity.IPAddress + "'" ',IPADDRESS
        strSQL = strSQL + ",[BRANDTYPE] = '" + cisDeviceEntity.BrandType + "'" ',BRANDTYPE
        strSQL = strSQL + ",[MODEL] = '" + cisDeviceEntity.Model + "'" ',MODEL
        strSQL = strSQL + ",[HOSTNAME] = '" + cisDeviceEntity.HostName + "'" ',HOSTNAME
        strSQL = strSQL + ",[USERNAME] = '" + cisDeviceEntity.UserName + "'" ',USERNAME
        strSQL = strSQL + ",[PASSWORD] = '" + cisDeviceEntity.Password + "'" ',PASSWORD
        strSQL = strSQL + ",[MAC] = '" + cisDeviceEntity.MACAddress + "'" ',MAC
        strSQL = strSQL + ",[FIRMWAREVERSION] = '" + cisDeviceEntity.FirmwareVersion + "'" ',FIRMWAREVERSION
        strSQL = strSQL + ",[DEFAULTIPADDRESS] = '" + cisDeviceEntity.DefaultIPAddress + "'" ',DEFAULTIPADDRESS
        strSQL = strSQL + ",[STREAM1RESOLUTION] = '" + cisDeviceEntity.Stream1Resolution + "'" ',STREAM1RESOLUTION
        strSQL = strSQL + ",[STREAM1FPS] = '" + cisDeviceEntity.Stream1FPS + "'" ',STTREAM1FPS

        strSQL = strSQL + ",[REMARKS] = '" + cisDeviceEntity.Remarks + "'"
        If cisDeviceEntity.IsActiveFlag Then
            strSQL = strSQL + ",[ISACTIVEFLG]=1" ',[ISACTIVEFLG]
        Else
            strSQL = strSQL + ",[ISACTIVEFLG]=0" ',[ISACTIVEFLG]
        End If
        If cisDeviceEntity.PurgeFlag Then
            strSQL = strSQL + ",[PURGEFLG]=1" ',[PURGEFLG]
        Else
            strSQL = strSQL + ",[PURGEFLG]=0" ',[PURGEFLG]
        End If
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [DEVID]=" + cisDeviceEntity.DeviceID.ToString

        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NewUpdateDate", SqlDbType.DateTime)
        objParams(0).Value = Now
        objParams(0).Direction = ParameterDirection.InputOutput


        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        cisDeviceEntity.UpdatedBy = prflID
        cisDeviceEntity.UpdateDate = CType(objParams(0).Value, Date)

        Return True
    End Function

    Public Function PurgeDevice(ByVal DeviceID As Long, ByVal prflID As Long) As Boolean

        Dim strSQL As String
        strSQL = "SET @NewUpdateDate = GETDATE();"
        strSQL = strSQL + "UPDATE [dbo].[DEVICETBL] "
        strSQL = strSQL + "Set [PURGEFLG]=1" ',[PURGEFLG]
        strSQL = strSQL + ",[UPDDT] = @NewUpdateDate"
        strSQL = strSQL + ",[UPDBY] = '" + prflID.ToString + "'"
        strSQL = strSQL + "WHERE [DEVID]=" + DeviceID.ToString

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

    Public Function GetDevice(ByVal DeviceID As Long) As CISEntity.DeviceEntity
        Dim objDeviceEntity As New CISEntity.DeviceEntity
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing

        strSQL = "SELECT * FROM DEVICETBL" &
                " WHERE " &
                " [DEVID]=" & DeviceID.ToString

        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    With objDeviceEntity
                        .DeviceID = CType(curRow("DEVID"), Long) 'DEVID
                        .ItemCode = CType(curRow("ITEMCODE"), String) ',ITEMCODE
                        .DeviceName = CType(curRow("DEVICENAME"), String) ',DEVICENAME
                        .DeviceType = CType(curRow("DEVICETYPE"), String) ',DEVICETYPE
                        .SerialNumber = CType(curRow("SERIALNUMBER"), String) ',SERIALNUMBER
                        .DeviceSpecifications = CType(curRow("DEVICESPECS"), String) ',DEVICESPECS
                        .Status = CType(curRow("STATUS"), String) ',STATUS
                        .ManufactureDate = CType(curRow("MANUFACTUREDATE"), DateTime) ',MANUFACTUREDATE
                        .ReceiveDate = CType(curRow("RECEIVEDATE"), DateTime) ',RECEIVEDATE

                        If CType(curRow("ISAVAILABLE"), Integer) <> 0 Then ',ISAVAILABLE
                            .IsActiveFlag = True
                        Else
                            .IsActiveFlag = False
                        End If

                        .IPAddress = CType(curRow("IPADDRESS"), String) ',IPADDRESS
                        .BrandType = CType(curRow("BRANDTYPE"), String) ',BRANDTYPE
                        .Model = CType(curRow("MODEL"), String) ',MODEL
                        .HostName = CType(curRow("HOSTNAME"), String) ',HOSTNAME
                        .UserName = CType(curRow("USERNAME"), String)    ',USERNAME
                        .Password = CType(curRow("PASSWORD"), String) ',PASSWORD
                        .MACAddress = CType(curRow("MAC"), String)  ',MAC
                        .FirmwareVersion = CType(curRow("FIRMWAREVERSION"), String) ',FIRMWAREVERSION
                        .DefaultIPAddress = CType(curRow("DEFAULTIPADDRESS"), String)  ',DEFAULTIPADDRESS
                        .Stream1Resolution = CType(curRow("STREAM1RESOLUTION"), String) ',STREAM1RESOLUTION
                        .Stream1FPS = CType(curRow("STREAM1FPS"), String)  ',STREAM1FPS

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
                Return objDeviceEntity
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
    End Function

    Public Function GetDeviceList(ByVal strWhereClause As String) As List(Of CISEntity.DeviceEntity)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing
        Dim objDeviceEntityList As New List(Of CISEntity.DeviceEntity)

        strSQL = "SELECT * FROM DEVICETBL" &
                " WHERE " & strWhereClause


        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    Dim objDeviceEntity As New CISEntity.DeviceEntity
                    With objDeviceEntity
                        .DeviceID = CType(curRow("DEVID"), Long) 'DEVID
                        .ItemCode = CType(curRow("ITEMCODE"), String) ',ITEMCODE
                        .DeviceName = CType(curRow("DEVICENAME"), String) ',DEVICENAME
                        .DeviceType = CType(curRow("DEVICETYPE"), String) ',DEVICETYPE
                        .SerialNumber = CType(curRow("SERIALNUMBER"), String) ',SERIALNUMBER
                        .DeviceSpecifications = CType(curRow("DEVICESPECS"), String) ',DEVICESPECS
                        .Status = CType(curRow("STATUS"), String) ',STATUS
                        .ManufactureDate = CType(curRow("MANUFACTUREDATE"), DateTime) ',MANUFACTUREDATE
                        .ReceiveDate = CType(curRow("RECEIVEDATE"), DateTime) ',RECEIVEDATE

                        If CType(curRow("ISAVAILABLE"), Integer) <> 0 Then ',ISAVAILABLE
                            .IsActiveFlag = True
                        Else
                            .IsActiveFlag = False
                        End If

                        .IPAddress = CType(curRow("IPADDRESS"), String) ',IPADDRESS
                        .BrandType = CType(curRow("BRANDTYPE"), String) ',BRANDTYPE
                        .Model = CType(curRow("MODEL"), String) ',MODEL
                        .HostName = CType(curRow("HOSTNAME"), String) ',HOSTNAME
                        .UserName = CType(curRow("USERNAME"), String)    ',USERNAME
                        .Password = CType(curRow("PASSWORD"), String) ',PASSWORD
                        .MACAddress = CType(curRow("MAC"), String)  ',MAC
                        .FirmwareVersion = CType(curRow("FIRMWAREVERSION"), String) ',FIRMWAREVERSION
                        .DefaultIPAddress = CType(curRow("DEFAULTIPADDRESS"), String)  ',DEFAULTIPADDRESS
                        .Stream1Resolution = CType(curRow("STREAM1RESOLUTION"), String) ',STREAM1RESOLUTION
                        .Stream1FPS = CType(curRow("STREAM1FPS"), String)  ',STREAM1FPS

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
                    objDeviceEntityList.Add(objDeviceEntity)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
        Return objDeviceEntityList
    End Function

    Public Function GetDeviceListByName(ByVal strDeviceName As String, ByVal isWildcard As Boolean, ByVal blnInstalledAtClient As Boolean) As DataTable

        Dim strSQL As String

        If blnInstalledAtClient Then
            'Select 
            'DEVICETBL.DEVID, DEVICETBL.ITEMCODE, DEVICETBL.DEVICENAME, DEVICETBL.DEVICETYPE, 
            'DEVICETBL.SERIALNUMBER, DEVICETBL.STATUS, CLIENTTBL.NAME, SERVICETBL.SERVIENAME
            'FROM
            'CLIENTTBL INNER JOIN SERVICETBL INNER JOIN CLIENTSERVICETBL 
            'On SERVICETBL.SVCID = CLIENTSERVICETBL.SVCID ON CLIENTTBL.CLIENTID = CLIENTSERVICETBL.CLIENTID 
            'INNER Join DEVICETBL INNER JOIN CLIENTSERVICEDEVICETBL ON DEVICETBL.DEVID = CLIENTSERVICEDEVICETBL.DEVID 
            'On CLIENTSERVICETBL.CLIENTSVCID = CLIENTSERVICEDEVICETBL.CLIENTSVCID
            'WHERE DEVICENAME Like '%11%'

            strSQL = " Select"
            strSQL = strSQL + " DEVICETBL.DEVID, DEVICETBL.ITEMCODE, DEVICETBL.DEVICENAME, DEVICETBL.DEVICETYPE, "
            strSQL = strSQL + " DEVICETBL.SERIALNUMBER, DEVICETBL.STATUS, CLIENTTBL.NAME, SERVICETBL.SERVIENAME"
            strSQL = strSQL + " FROM"
            strSQL = strSQL + " CLIENTTBL INNER JOIN SERVICETBL INNER JOIN CLIENTSERVICETBL "
            strSQL = strSQL + " On SERVICETBL.SVCID = CLIENTSERVICETBL.SVCID ON CLIENTTBL.CLIENTID = CLIENTSERVICETBL.CLIENTID "
            strSQL = strSQL + " INNER Join DEVICETBL INNER JOIN CLIENTSERVICEDEVICETBL ON DEVICETBL.DEVID = CLIENTSERVICEDEVICETBL.DEVID "
            strSQL = strSQL + " On CLIENTSERVICETBL.CLIENTSVCID = CLIENTSERVICEDEVICETBL.CLIENTSVCID"
            'strSQL = strSQL + " WHERE DEVICENAME Like '%11%'"

            If isWildcard Then
                strSQL = strSQL + " WHERE DEVICENAME Like '%" + strDeviceName + "%' AND ISAVAILABLE=0 "
            Else
                strSQL = strSQL + " WHERE DEVICENAME = '" + strDeviceName + "' AND ISAVAILABLE=0 "
            End If
            strSQL &= " AND CLIENTSERVICEDEVICETBL.ISACTIVEFLG= 1 AND CLIENTSERVICEDEVICETBL.PURGEFLG=0"
        Else

            strSQL = " Select"
            strSQL = strSQL + " DEVICETBL.DEVID, DEVICETBL.ITEMCODE, DEVICETBL.DEVICENAME, DEVICETBL.DEVICETYPE, DEVICETBL.SERIALNUMBER, "
            strSQL = strSQL + " DEVICETBL.STATUS, '' as NAME, '' as SERVIENAME"
            strSQL = strSQL + " FROM DEVICETBL"

            If isWildcard Then
                strSQL = strSQL + " WHERE DEVICENAME Like '%" + strDeviceName + "%' AND ISAVAILABLE=1  AND ISACTIVEFLG=1 AND PURGEFLG=0"
            Else
                strSQL = strSQL + " WHERE DEVICENAME = '" + strDeviceName + "' AND ISAVAILABLE=1  AND ISACTIVEFLG=1 AND PURGEFLG=0"
            End If
            strSQL = strSQL + " And [DEVID] Not in (SELECT DISTINCT [DEVID] FROM [CLIENTSERVICEDEVICETBL] WHERE [ISACTIVEFLG]=1 AND  [PURGEFLG]=0)"

        End If

        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)



    End Function

    Public Function GetDeviceListBySN(ByVal strDeviceSN As String, ByVal isWildcard As Boolean, ByVal blnInstalledAtClient As Boolean) As DataTable


        Dim strSQL As String

        If blnInstalledAtClient Then
            'Select 
            'DEVICETBL.DEVID, DEVICETBL.ITEMCODE, DEVICETBL.DEVICENAME, DEVICETBL.DEVICETYPE, 
            'DEVICETBL.SERIALNUMBER, DEVICETBL.STATUS, CLIENTTBL.NAME, SERVICETBL.SERVIENAME
            'FROM
            'CLIENTTBL INNER JOIN SERVICETBL INNER JOIN CLIENTSERVICETBL 
            'On SERVICETBL.SVCID = CLIENTSERVICETBL.SVCID ON CLIENTTBL.CLIENTID = CLIENTSERVICETBL.CLIENTID 
            'INNER Join DEVICETBL INNER JOIN CLIENTSERVICEDEVICETBL ON DEVICETBL.DEVID = CLIENTSERVICEDEVICETBL.DEVID 
            'On CLIENTSERVICETBL.CLIENTSVCID = CLIENTSERVICEDEVICETBL.CLIENTSVCID
            'WHERE SERIALNUMBER Like '%11%'

            strSQL = " Select"
            strSQL = strSQL + " DEVICETBL.DEVID, DEVICETBL.ITEMCODE, DEVICETBL.DEVICENAME, DEVICETBL.DEVICETYPE, "
            strSQL = strSQL + " DEVICETBL.SERIALNUMBER, DEVICETBL.STATUS, CLIENTTBL.NAME, SERVICETBL.SERVIENAME"
            strSQL = strSQL + " FROM"
            strSQL = strSQL + " CLIENTTBL INNER JOIN SERVICETBL INNER JOIN CLIENTSERVICETBL "
            strSQL = strSQL + " On SERVICETBL.SVCID = CLIENTSERVICETBL.SVCID ON CLIENTTBL.CLIENTID = CLIENTSERVICETBL.CLIENTID "
            strSQL = strSQL + " INNER Join DEVICETBL INNER JOIN CLIENTSERVICEDEVICETBL ON DEVICETBL.DEVID = CLIENTSERVICEDEVICETBL.DEVID "
            strSQL = strSQL + " On CLIENTSERVICETBL.CLIENTSVCID = CLIENTSERVICEDEVICETBL.CLIENTSVCID"
            'strSQL = strSQL + " WHERE SERIALNUMBER Like '%11%'"

            If isWildcard Then
                strSQL = strSQL + " WHERE SERIALNUMBER Like '%" + strDeviceSN + "%' AND ISAVAILABLE=0 "
            Else
                strSQL = strSQL + " WHERE SERIALNUMBER = '" + strDeviceSN + "' AND ISAVAILABLE=0 "
            End If
            strSQL &= " AND CLIENTSERVICEDEVICETBL.ISACTIVEFLG= 1 AND CLIENTSERVICEDEVICETBL.PURGEFLG=0"
        Else
            ' Select
            ' DEVICETBL.DEVID, DEVICETBL.ITEMCODE, DEVICETBL.DEVICENAME, DEVICETBL.DEVICETYPE, DEVICETBL.SERIALNUMBER, 
            'DEVICETBL.STATUS, '' as NAME, '' as SERVIENAME
            ' FROM            
            ' DEVICETBL
            ' WHERE ITEMCODE Like '%%'
            ' And [DEVID] Not in (SELECT DISTINCT [DEVID] FROM [CLIENTSERVICEDEVICETBL])

            strSQL = " Select"
            strSQL = strSQL + " DEVICETBL.DEVID, DEVICETBL.ITEMCODE, DEVICETBL.DEVICENAME, DEVICETBL.DEVICETYPE, DEVICETBL.SERIALNUMBER, "
            strSQL = strSQL + " DEVICETBL.STATUS, '' as NAME, '' as SERVIENAME"
            strSQL = strSQL + " FROM DEVICETBL"


            If isWildcard Then
                strSQL = strSQL + " WHERE SERIALNUMBER Like '%" + strDeviceSN + "%' AND ISAVAILABLE=1 AND ISACTIVEFLG=1 AND PURGEFLG=0"
            Else
                strSQL = strSQL + " WHERE SERIALNUMBER = '" + strDeviceSN + "' AND ISAVAILABLE=1 AND ISACTIVEFLG=1 AND PURGEFLG=0"
            End If

            strSQL = strSQL + " And [DEVID] Not in (SELECT DISTINCT [DEVID] FROM [CLIENTSERVICEDEVICETBL] WHERE [ISACTIVEFLG]=1 AND  [PURGEFLG]=0)"

        End If

        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)



    End Function

    Public Function GetDeviceListByItemCode(ByVal strDeviceItemCode As String, ByVal isWildcard As Boolean, ByVal blnInstalledAtClient As Boolean) As DataTable


        Dim strSQL As String
        If blnInstalledAtClient Then
            'Select 
            'DEVICETBL.DEVID, DEVICETBL.ITEMCODE, DEVICETBL.DEVICENAME, DEVICETBL.DEVICETYPE, 
            'DEVICETBL.SERIALNUMBER, DEVICETBL.STATUS, CLIENTTBL.NAME, SERVICETBL.SERVIENAME
            'FROM
            'CLIENTTBL INNER JOIN SERVICETBL INNER JOIN CLIENTSERVICETBL 
            'On SERVICETBL.SVCID = CLIENTSERVICETBL.SVCID ON CLIENTTBL.CLIENTID = CLIENTSERVICETBL.CLIENTID 
            'INNER Join DEVICETBL INNER JOIN CLIENTSERVICEDEVICETBL ON DEVICETBL.DEVID = CLIENTSERVICEDEVICETBL.DEVID 
            'On CLIENTSERVICETBL.CLIENTSVCID = CLIENTSERVICEDEVICETBL.CLIENTSVCID
            'WHERE ITEMCODE Like '%11%'
            strSQL = " Select"
            strSQL = strSQL + " DEVICETBL.DEVID, DEVICETBL.ITEMCODE, DEVICETBL.DEVICENAME, DEVICETBL.DEVICETYPE, "
            strSQL = strSQL + " DEVICETBL.SERIALNUMBER, DEVICETBL.STATUS, CLIENTTBL.NAME, SERVICETBL.SERVIENAME"
            strSQL = strSQL + " FROM"
            strSQL = strSQL + " CLIENTTBL INNER JOIN SERVICETBL INNER JOIN CLIENTSERVICETBL "
            strSQL = strSQL + " On SERVICETBL.SVCID = CLIENTSERVICETBL.SVCID ON CLIENTTBL.CLIENTID = CLIENTSERVICETBL.CLIENTID "
            strSQL = strSQL + " INNER Join DEVICETBL INNER JOIN CLIENTSERVICEDEVICETBL ON DEVICETBL.DEVID = CLIENTSERVICEDEVICETBL.DEVID "
            strSQL = strSQL + " On CLIENTSERVICETBL.CLIENTSVCID = CLIENTSERVICEDEVICETBL.CLIENTSVCID"
            'strSQL = strSQL + " WHERE ITEMCODE Like '%11%'"

            If isWildcard Then
                strSQL = strSQL + " WHERE ITEMCODE Like '%" + strDeviceItemCode + "%' AND ISAVAILABLE=0 "
            Else
                strSQL = strSQL + " WHERE ITEMCODE = '" + strDeviceItemCode + "'  AND ISAVAILABLE=0 "
            End If

            strSQL &= " AND CLIENTSERVICEDEVICETBL.ISACTIVEFLG= 1 AND CLIENTSERVICEDEVICETBL.PURGEFLG=0"
        Else
            strSQL = " Select"
            strSQL = strSQL + " DEVICETBL.DEVID, DEVICETBL.ITEMCODE, DEVICETBL.DEVICENAME, DEVICETBL.DEVICETYPE, DEVICETBL.SERIALNUMBER, "
            strSQL = strSQL + " DEVICETBL.STATUS, '' as NAME, '' as SERVIENAME"

            strSQL = strSQL + " FROM DEVICETBL"
            If isWildcard Then
                strSQL = strSQL + " WHERE ITEMCODE Like '%" + strDeviceItemCode + "%'  AND ISAVAILABLE=1 AND ISACTIVEFLG=1 AND PURGEFLG=0"
            Else
                strSQL = strSQL + " WHERE ITEMCODE = '" + strDeviceItemCode + "'  AND ISAVAILABLE=1 AND ISACTIVEFLG=1 AND PURGEFLG=0"
            End If

            strSQL = strSQL + " And [DEVID] Not in (SELECT DISTINCT [DEVID] FROM [CLIENTSERVICEDEVICETBL] WHERE [ISACTIVEFLG]=1 AND  [PURGEFLG]=0)"


        End If

        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function

    Public Function GetDeviceClientInfo(ByVal DevID As Long) As DataTable
        Dim objCommon As New CISData.CommonClass
        Dim strSQL As String

        ' SELECT        
        ' CLIENTSERVICEDEVICETBL.CLIENTSVCID, CLIENTSERVICETBL.CLIENTID, SERVICETBL.SERVIENAME
        ', CLIENTTBL.CLIENTCODE, CLIENTTBL.NAME AS CLIENTNAME
        ' FROM DEVICETBL 
        ' INNER JOIN CLIENTSERVICEDEVICETBL ON DEVICETBL.DEVID = CLIENTSERVICEDEVICETBL.DEVID 
        ' INNER JOIN CLIENTSERVICETBL ON CLIENTSERVICEDEVICETBL.CLIENTSVCID = CLIENTSERVICETBL.CLIENTSVCID 
        ' INNER JOIN CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID 
        ' INNER JOIN SERVICETBL ON CLIENTSERVICETBL.SVCID = SERVICETBL.SVCID
        ' WHERE DEVICETBL.DEVID = 1

        strSQL = " SELECT"
        strSQL = strSQL + " CLIENTSERVICEDEVICETBL.CLIENTSVCID, CLIENTSERVICETBL.CLIENTID, SERVICETBL.SERVIENAME"
        strSQL = strSQL + " , CLIENTTBL.CLIENTCODE, CLIENTTBL.NAME AS CLIENTNAME"
        strSQL = strSQL + " FROM DEVICETBL "
        strSQL = strSQL + " INNER JOIN CLIENTSERVICEDEVICETBL ON DEVICETBL.DEVID = CLIENTSERVICEDEVICETBL.DEVID "
        strSQL = strSQL + "INNER JOIN CLIENTSERVICETBL ON CLIENTSERVICEDEVICETBL.CLIENTSVCID = CLIENTSERVICETBL.CLIENTSVCID "
        strSQL = strSQL + " INNER JOIN CLIENTTBL ON CLIENTSERVICETBL.CLIENTID = CLIENTTBL.CLIENTID "
        strSQL = strSQL + " INNER JOIN SERVICETBL ON CLIENTSERVICETBL.SVCID = SERVICETBL.SVCID"
        strSQL = strSQL + " WHERE DEVICETBL.DEVID = " + DevID.ToString
        strSQL &= " AND CLIENTSERVICEDEVICETBL.ISACTIVEFLG= 1 AND CLIENTSERVICEDEVICETBL.PURGEFLG=0 "

        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function

    Public Function GetDeviceTechReportList(ByVal DevID As Long) As DataTable
        Dim objCommon As New CISData.CommonClass
        Dim strSQL As String = ""

        strSQL &= " SELECT "
        strSQL &= " AFFECTEDDEVICETBL.AFFECTEDDEVICEID, "
        strSQL &= " AFFECTEDDEVICETBL.TECHREPID, "
        strSQL &= " TECHREPORTTBL.STARTDT, "
        strSQL &= " TECHREPORTTBL.STATUS, TECHREPORTTBL.TEAM "
        strSQL &= " FROM "
        strSQL &= " AFFECTEDDEVICETBL INNER JOIN TECHREPORTTBL "
        strSQL &= " ON AFFECTEDDEVICETBL.TECHREPID = TECHREPORTTBL.TECHREPID INNER JOIN DEVICETBL "
        strSQL &= " ON AFFECTEDDEVICETBL.DEVID = DEVICETBL.DEVID "
        strSQL &= " WHERE AFFECTEDDEVICETBL.DEVID = " + DevID.ToString + " AND TECHREPORTTBL.ISACTIVEFLG=1 "
        strSQL &= " AND TECHREPORTTBL.PURGEFLG=0"
        strSQL &= " AND DEVICETBL.ISACTIVEFLG=1 "
        strSQL &= " AND DEVICETBL.PURGEFLG=0 "

        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)
    End Function

    Public Function AddAffectedDevice(ByVal DeviceID As Long, ByVal TechRepID As Long) As Long
        Dim strSQL As String
        'AFFECTEDDEVICEID
        ',DEVID
        ',TECHREPID

        strSQL = "INSERT INTO [dbo].[AFFECTEDDEVICETBL] "
        strSQL = strSQL + " ([DEVID] "
        strSQL = strSQL + " ,[TECHREPID]) "
        strSQL = strSQL + " VALUES ("
        strSQL = strSQL + "'" + DeviceID.ToString + "'"
        strSQL = strSQL + ",'" + TechRepID.ToString + "'); SET @NewID = SCOPE_IDENTITY();"

        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NewID", SqlDbType.BigInt)
        objParams(0).Value = 0
        objParams(0).Direction = ParameterDirection.InputOutput



        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        ''RETURN new id

        Return CType(objParams(0).Value, Long)
    End Function

    Public Function RemoveAffectedDevice(ByVal DeviceID As Long, ByVal TechRepID As Long) As Boolean
        Dim strSQL As String
        'AFFECTEDDEVICEID
        ',DEVID
        ',TECHREPID

        strSQL = "DELETE FROM [dbo].[AFFECTEDDEVICETBL] "
        strSQL = strSQL + " WHERE "
        strSQL = strSQL + "[DEVID]='" + DeviceID.ToString + "'"
        strSQL = strSQL + " AND [TECHREPID]='" + TechRepID.ToString + "';"

        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NewID", SqlDbType.BigInt)
        objParams(0).Value = 0
        objParams(0).Direction = ParameterDirection.Input

        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        Return True
    End Function

    Public Function RemoveAffectedDevice(ByVal AFFECTEDDEVICEID As Long) As Boolean
        Dim strSQL As String
        'AFFECTEDDEVICEID
        ',DEVID
        ',TECHREPID

        strSQL = "DELETE FROM [dbo].[AFFECTEDDEVICETBL] "
        strSQL = strSQL + " WHERE "
        strSQL = strSQL + "[AFFECTEDDEVICEID]=" + AFFECTEDDEVICEID.ToString


        Dim objParams(0) As SqlParameter
        objParams(0) = New SqlParameter("@NewID", SqlDbType.BigInt)
        objParams(0).Value = 0
        objParams(0).Direction = ParameterDirection.Input

        Dim objCommon As New CommonClass
        Dim objData As New SQLHelper
        Dim intRet As Integer = 0

        intRet = SQLHelper.ExecuteNonQuery(objCommon.GetConnString, CommandType.Text, strSQL, objParams)

        Return True
    End Function

    Public Function GetTechReportAffectedDevices(ByVal lngTechRepID As Long) As DataTable


        Dim strSQL As String
        'AFFECTEDDEVICEID
        ',DEVID
        ',TECHREPID

        strSQL = " SELECT * FROM dbo.[AFFECTEDDEVICETBL] "
        strSQL = strSQL + " WHERE [TECHREPID]= " + lngTechRepID.ToString


        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)

    End Function

    Public Function GetInstalledDevicesAtClientService(ByVal ClSvcID As Long) As DataTable
        Dim strsql As String

        strsql = "SELECT "
        strsql = strsql & " CLIENTSERVICEDEVICETBL.CLSVCDEVID,CLIENTSERVICEDEVICETBL.DEVID, DEVICETBL.ITEMCODE, "
        strsql = strsql & " DEVICETBL.DEVICENAME, DEVICETBL.DEVICETYPE, DEVICETBL.STATUS "
        strsql = strsql & " FROM "
        strsql = strsql & " CLIENTSERVICEDEVICETBL INNER JOIN "
        strsql = strsql & " DEVICETBL On CLIENTSERVICEDEVICETBL.DEVID = DEVICETBL.DEVID "
        strsql = strsql & " WHERE CLIENTSERVICEDEVICETBL.CLIENTSVCID = " & ClSvcID.ToString
        strsql &= " AND CLIENTSERVICEDEVICETBL.ISACTIVEFLG = 1 AND CLIENTSERVICEDEVICETBL.PURGEFLG=0"

        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strsql)
    End Function

    Public Function GetInstalledDevicesAtClientService0Records() As DataTable
        Dim strsql As String

        strsql = "SELECT "
        strsql = strsql & " CLIENTSERVICEDEVICETBL.CLSVCDEVID, DEVICETBL.ITEMCODE, "
        strsql = strsql & " DEVICETBL.DEVICENAME, DEVICETBL.DEVICETYPE, DEVICETBL.STATUS "
        strsql = strsql & " FROM "
        strsql = strsql & " CLIENTSERVICEDEVICETBL INNER JOIN "
        strsql = strsql & " DEVICETBL On CLIENTSERVICEDEVICETBL.DEVID = DEVICETBL.DEVID "
        strsql = strsql & " WHERE CLIENTSERVICEDEVICETBL.CLIENTSVCID = 0 "
        'strsql &= " AND CLIENTSERVICEDEVICETBL.ISACTIVEFLG = 1 AND CLIENTSERVICEDEVICETBL.PURGEFLG=0"

        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strsql)
    End Function

    Public Function GetAffectedDeviceListByTechRepID(ByVal lngTechRepID As Long) As List(Of CISEntity.DeviceEntity)
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim objCommon As New CommonClass
        Dim strSQL As String = Nothing
        Dim objDeviceEntityList As New List(Of CISEntity.DeviceEntity)

        strSQL = "SELECT * FROM DEVICETBL " &
                " WHERE DEVID IN (SELECT DISTINCT DEVID FROM AFFECTEDDEVICETBL WHERE TECHREPID = " + lngTechRepID.ToString + ")"


        ds = SQLHelper.ExecuteDataSet(objCommon.GetConnString, CommandType.Text, strSQL)

        If ds.Tables.Count > 0 Then
            dt = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim curRow As DataRow
                For Each curRow In dt.Rows
                    Dim objDeviceEntity As New CISEntity.DeviceEntity
                    With objDeviceEntity
                        .DeviceID = CType(curRow("DEVID"), Long) 'DEVID
                        .ItemCode = CType(curRow("ITEMCODE"), String) ',ITEMCODE
                        .DeviceName = CType(curRow("DEVICENAME"), String) ',DEVICENAME
                        .DeviceType = CType(curRow("DEVICETYPE"), String) ',DEVICETYPE
                        .SerialNumber = CType(curRow("SERIALNUMBER"), String) ',SERIALNUMBER
                        .DeviceSpecifications = CType(curRow("DEVICESPECS"), String) ',DEVICESPECS
                        .Status = CType(curRow("STATUS"), String) ',STATUS
                        .ManufactureDate = CType(curRow("MANUFACTUREDATE"), DateTime) ',MANUFACTUREDATE
                        .ReceiveDate = CType(curRow("RECEIVEDATE"), DateTime) ',RECEIVEDATE

                        If CType(curRow("ISAVAILABLE"), Integer) <> 0 Then ',ISAVAILABLE
                            .IsActiveFlag = True
                        Else
                            .IsActiveFlag = False
                        End If

                        .IPAddress = CType(curRow("IPADDRESS"), String) ',IPADDRESS
                        .BrandType = CType(curRow("BRANDTYPE"), String) ',BRANDTYPE
                        .Model = CType(curRow("MODEL"), String) ',MODEL
                        .HostName = CType(curRow("HOSTNAME"), String) ',HOSTNAME
                        .UserName = CType(curRow("USERNAME"), String)    ',USERNAME
                        .Password = CType(curRow("PASSWORD"), String) ',PASSWORD
                        .MACAddress = CType(curRow("MAC"), String)  ',MAC
                        .FirmwareVersion = CType(curRow("FIRMWAREVERSION"), String) ',FIRMWAREVERSION
                        .DefaultIPAddress = CType(curRow("DEFAULTIPADDRESS"), String)  ',DEFAULTIPADDRESS
                        .Stream1Resolution = CType(curRow("STREAM1RESOLUTION"), String) ',STREAM1RESOLUTION
                        .Stream1FPS = CType(curRow("STREAM1FPS"), String)  ',STREAM1FPS

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
                    objDeviceEntityList.Add(objDeviceEntity)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        dt.Dispose()
        ds.Dispose()
        Return objDeviceEntityList
    End Function


    Public Function GetDevicesNotInTechRep(ByVal TechRepID As Long) As DataTable
        Dim strsql As String = ""

        strsql &= " SELECT "
        strsql &= " DEVICETBL.DEVID, "
        strsql &= " DEVICETBL.ITEMCODE, "
        strsql &= " DEVICETBL.DEVICETYPE, "
        strsql &= " DEVICETBL.DEVICENAME, "
        strsql &= " DEVICETBL.STATUS "
        strsql &= " FROM SERVICETBL INNER JOIN CLIENTSERVICETBL "
        strsql &= " ON SERVICETBL.SVCID = CLIENTSERVICETBL.SVCID INNER JOIN TECHREPORTTBL INNER JOIN CLIENTSERVICEDEVICETBL "
        strsql &= " ON TECHREPORTTBL.CLIENTSVCID = CLIENTSERVICEDEVICETBL.CLIENTSVCID INNER JOIN DEVICETBL "
        strsql &= " ON CLIENTSERVICEDEVICETBL.DEVID = DEVICETBL.DEVID "
        strsql &= " ON CLIENTSERVICETBL.CLIENTSVCID = CLIENTSERVICEDEVICETBL.CLIENTSVCID "
        strsql &= " WHERE "
        strsql &= " (TECHREPORTTBL.TECHREPID IN (" + TechRepID.ToString + ") AND TECHREPORTTBL.ISACTIVEFLG= 1 AND TECHREPORTTBL.PURGEFLG=0) "
        strsql &= " AND (DEVICETBL.ISACTIVEFLG= 1 AND DEVICETBL.PURGEFLG=0) "
        strsql &= " AND (CLIENTSERVICETBL.ISACTIVE = 1) AND  (CLIENTSERVICETBL.PURGEFLG = 0) "
        strsql &= " AND CLIENTSERVICEDEVICETBL.ISACTIVEFLG=1 AND CLIENTSERVICEDEVICETBL.PURGEFLG=0"
        strsql &= " AND (DEVICETBL.DEVID NOT IN (SELECT AFFECTEDDEVICETBL.DEVID  FROM AFFECTEDDEVICETBL WHERE AFFECTEDDEVICETBL.TECHREPID = " + TechRepID.ToString + " )) "

        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strsql)
    End Function

    Public Function GetTRAffectedDeviceList(ByVal TechRepID As Long) As DataTable
        Dim strSQL As String

        strSQL = " SELECT "
        strSQL = strSQL + " AFFECTEDDEVICETBL.AFFECTEDDEVICEID, DEVICETBL.ITEMCODE, DEVICETBL.DEVICENAME, DEVICETBL.STATUS"
        strSQL = strSQL + " FROM"
        strSQL = strSQL + " DEVICETBL INNER JOIN"
        strSQL = strSQL + " AFFECTEDDEVICETBL ON DEVICETBL.DEVID = AFFECTEDDEVICETBL.DEVID"
        strSQL = strSQL + " WHERE AFFECTEDDEVICETBL.TECHREPID = " + TechRepID.ToString


        Dim objCommon As New CISData.CommonClass
        Return SQLHelper.ExecuteTable(objCommon.GetConnString, CommandType.Text, strSQL)
    End Function

End Class

