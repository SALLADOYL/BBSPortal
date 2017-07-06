Option Strict On
Imports System.Text
Imports System
Imports System.Collections.Generic

<Serializable()>
Public Class ClientServiceEntity
    Private lngClientServiceID As Long 'CLIENTSVCID
    Public Property ClientServiceID As Long
        Get
            Return lngClientServiceID
        End Get
        Set(value As Long)
            lngClientServiceID = value
        End Set
    End Property
    Private lngClientID As Long 'CLIENTID
    Public Property ClientID As Long
        Get
            Return lngClientID
        End Get
        Set(value As Long)
            lngClientID = value
        End Set
    End Property
    Private lngServiceID As Long 'SVCID
    Public Property ServiceID As Long
        Get
            Return lngServiceID
        End Get
        Set(value As Long)
            lngServiceID = value
        End Set
    End Property
    Private boolIsActiveFlag As Boolean 'ISACTIVE
    Public Property IsActiveFlag As Boolean
        Get
            Return boolIsActiveFlag
        End Get
        Set(value As Boolean)
            boolIsActiveFlag = value
        End Set
    End Property
    Private boolPurgeFlag As Boolean 'PURGEFLG
    Public Property PurgeFlag As Boolean

        Get
            Return boolPurgeFlag
        End Get
        Set(value As Boolean)
            boolPurgeFlag = value
        End Set
    End Property

    Private dtCreateDate As DateTime
    Private lngCreatedBy As Long
    Private dtUpdateDate As DateTime
    Private lngUpdatedBy As Long
    Private tmpTimeStamp As String

    Public Property CreateDate As DateTime
        Get
            Return dtCreateDate
        End Get
        Set(value As DateTime)
            dtCreateDate = value
        End Set
    End Property

    Public Property CreatedBy As Long
        Get
            Return lngCreatedBy
        End Get
        Set(value As Long)
            lngCreatedBy = value
        End Set
    End Property

    Public Property UpdateDate As DateTime
        Get
            Return dtUpdateDate

        End Get
        Set(value As DateTime)
            dtUpdateDate = value

        End Set
    End Property

    Public Property UpdatedBy As Long
        Get
            Return lngUpdatedBy
        End Get
        Set(value As Long)
            lngUpdatedBy = value

        End Set
    End Property

End Class
