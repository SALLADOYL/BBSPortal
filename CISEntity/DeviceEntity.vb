Option Strict On
Imports System.Text
Imports System
Imports System.Collections.Generic

<Serializable()>
Public Class DeviceEntity

    'DEVID
    Private lngDeviceID As Long
    Public Property DeviceID As Long
        Get
            Return lngDeviceID
        End Get
        Set(value As Long)
            lngDeviceID = value
        End Set
    End Property

    'ITEMCODE
    Private strItemCode As String
    Public Property ItemCode As String
        Get
            Return strItemCode
        End Get
        Set(value As String)
            strItemCode = value
        End Set
    End Property

    Private strDeviceName As String
    Public Property DeviceName As String
        Get
            Return strDeviceName
        End Get
        Set(value As String)
            strDeviceName = value
        End Set
    End Property

    'DEVICETYPE
    Private strDeviceType As String
    Public Property DeviceType As String
        Get
            Return strDeviceType
        End Get
        Set(value As String)
            strDeviceType = value
        End Set

    End Property

    'SERIALNUMBER
    Private strSerialNumber As String
    Public Property SerialNumber As String
        Get
            Return strSerialNumber
        End Get
        Set(value As String)
            strSerialNumber = value
        End Set
    End Property

    'DEVICESPECS
    Private strDeviceSpecifications As String
    Public Property DeviceSpecifications As String
        Get
            Return strDeviceSpecifications
        End Get
        Set(value As String)
            strDeviceSpecifications = value
        End Set
    End Property

    'STATUS
    Private strStatus As String
    Public Property Status As String
        Get
            Return strStatus
        End Get
        Set(value As String)
            strStatus = value
        End Set
    End Property

    'MANUFACTUREDATE
    Private dtManufactureDate As DateTime
    Public Property ManufactureDate As DateTime
        Get
            Return dtManufactureDate
        End Get
        Set(value As DateTime)
            dtManufactureDate = value
        End Set
    End Property

    'RECEIVEDATE
    Private dtReceiveDate As DateTime
    Public Property ReceiveDate As DateTime
        Get
            Return dtReceiveDate
        End Get
        Set(value As DateTime)
            dtReceiveDate = value
        End Set
    End Property

    'ISAVAILABLE
    Private boolIsAvailable As Boolean
    Public Property IsAvailable As Boolean
        Get
            Return boolIsAvailable
        End Get
        Set(value As Boolean)
            boolIsAvailable = value
        End Set
    End Property


    ',IPADDRESS
    Private strIPADDRESS As String
    Public Property IPAddress As String
        Get
            Return strIPADDRESS
        End Get
        Set(value As String)
            strIPADDRESS = value
        End Set
    End Property

    ',BRANDTYPE
    Private strBRANDTYPE As String
    Public Property BrandType As String
        Get
            Return strBRANDTYPE
        End Get
        Set(value As String)
            strBRANDTYPE = value
        End Set
    End Property

    ',MODEL
    Private strMODEL As String
    Public Property Model As String
        Get
            Return strMODEL
        End Get
        Set(value As String)
            strMODEL = value
        End Set
    End Property

    ',HOSTNAME
    Private strHOSTNAME As String
    Public Property HostName As String
        Get
            Return strHOSTNAME
        End Get
        Set(value As String)
            strHOSTNAME = value
        End Set
    End Property

    ',USERNAME
    Private strUSERNAME As String
    Public Property UserName As String
        Get
            Return strUSERNAME

        End Get
        Set(value As String)
            strUSERNAME = value
        End Set
    End Property

    ',PASSWORD
    Private strPASSWORD As String
    Public Property Password As String
        Get
            Return strPASSWORD
        End Get
        Set(value As String)
            strPASSWORD = value
        End Set
    End Property

    ',MAC
    Private strMAC As String
    Public Property MACAddress As String
        Get
            Return strMAC
        End Get
        Set(value As String)
            strMAC = value
        End Set
    End Property

    ',FIRMWAREVERSION
    Private strFIRMWAREVERSION As String
    Public Property FirmwareVersion As String
        Get
            Return strFIRMWAREVERSION
        End Get
        Set(value As String)
            strFIRMWAREVERSION = value
        End Set
    End Property

    ',DEFAULTIPADDRESS
    Private strDEFAULTIPADDRESS As String
    Public Property DefaultIPAddress As String
        Get
            Return strDEFAULTIPADDRESS
        End Get
        Set(value As String)
            strDEFAULTIPADDRESS = value
        End Set
    End Property

    ',STREAM1RESOLUTION
    Private strSTREAM1RESOLUTION As String
    Public Property Stream1Resolution As String
        Get
            Return strSTREAM1RESOLUTION
        End Get
        Set(value As String)
            strSTREAM1RESOLUTION = value
        End Set
    End Property

    ',STTREAM1FPS
    Private strSTTREAM1FPS As String
    Public Property Stream1FPS As String
        Get
            Return strSTTREAM1FPS
        End Get
        Set(value As String)
            strSTTREAM1FPS = value
        End Set
    End Property

    'REMARKS
    Private strRemarks As String
    Public Property Remarks As String
        Get
            Return strRemarks
        End Get
        Set(value As String)
            strRemarks = value
        End Set
    End Property

    'ISACTIVE
    Private boolIsActiveFlag As Boolean
    Public Property IsActiveFlag As Boolean
        Get
            Return boolIsActiveFlag
        End Get
        Set(value As Boolean)
            boolIsActiveFlag = value
        End Set
    End Property

    'PURGEFLG
    Private boolPurgeFlag As Boolean
    Public Property PurgeFlag As Boolean
        Get
            Return boolPurgeFlag

        End Get
        Set(value As Boolean)
            boolPurgeFlag = value
        End Set
    End Property

    'CRTDT
    Private dtCreateDate As DateTime
    Public Property CreateDate As DateTime
        Get
            Return dtCreateDate

        End Get
        Set(value As DateTime)
            dtCreateDate = value
        End Set
    End Property

    'CRTBY
    Private lngCreatedBy As Long
    Public Property CreatedBy As Long
        Get
            Return lngCreatedBy
        End Get
        Set(value As Long)
            lngCreatedBy = value
        End Set
    End Property

    'UPDDT
    Private dtUpdateDate As DateTime
    Public Property UpdateDate As DateTime
        Get
            Return dtUpdateDate
        End Get
        Set(value As DateTime)
            dtUpdateDate = value
        End Set
    End Property

    'UPDBY
    Private lngUpdatedBy As Long
    Public Property UpdatedBy As Long
        Get
            Return lngUpdatedBy
        End Get
        Set(value As Long)
            lngUpdatedBy = value
        End Set
    End Property

    'TMPSTMP
    Private strTimeStamp As String
    Public Property TimeStamp As String
        Get
            Return strTimeStamp
        End Get
        Set(value As String)
            strTimeStamp = value
        End Set
    End Property

End Class


