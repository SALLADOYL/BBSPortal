Option Strict On
Imports System.Text
Imports System
Imports System.Collections.Generic

<Serializable()>
Public Class ServiceEntity
    Private lngServiceID As Long 'SVCID
    Public Property ServiceID As Long
        Get
            Return lngServiceID
        End Get
        Set(value As Long)
            lngServiceID = value
        End Set
    End Property
    'SERVICE NAME
    Private strServiceName As String
    Public Property ServiceName As String
        Get
            Return strServiceName

        End Get
        Set(value As String)
            strServiceName = value
        End Set
    End Property
    'SVCPERMALINK
    Private strServicePermalink As String
    Public Property ServicePermalink As String
        Get
            Return strServicePermalink
        End Get
        Set(value As String)
            strServicePermalink = value
        End Set
    End Property
    'SVCDESC
    Private strServiceDescription As String
    Public Property ServiceDescription As String
        Get
            Return strServiceDescription
        End Get
        Set(value As String)
            strServiceDescription = value
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
