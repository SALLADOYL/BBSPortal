
Option Strict On
Imports System.Text
Imports System
Imports System.Collections.Generic

<Serializable()>
Public Class ProfileObjectAccessEntity
    'PRFLOBJACCID
    Private lngProfileObjectAccessID As Long
    Public Property ProfileObjectAccessID As Long
        Get
            Return lngProfileObjectAccessID
        End Get
        Set(value As Long)
            lngProfileObjectAccessID = value
        End Set
    End Property

    'PROFILEID
    Private lngProfileID As Long
    Public Property ProfileID As Long
        Get
            Return lngProfileID
        End Get
        Set(value As Long)
            lngProfileID = value
        End Set
    End Property

    'OBJACCESSID
    Private lngObjectAccessID As Long
    Public Property ObjectAccessID As Long
        Get
            Return lngObjectAccessID
        End Get
        Set(value As Long)
            lngObjectAccessID = value
        End Set
    End Property

    'ROLEID
    Private lngRoleID As Long
    Public Property RoleID As Long
        Get
            Return lngRoleID
        End Get
        Set(value As Long)
            lngRoleID = value
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
End Class
