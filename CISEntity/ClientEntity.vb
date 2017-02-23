Option Strict On
Imports System.Text
Imports System
Imports System.Collections.Generic

<Serializable()>
Public Class ClientEntity

    Private lngClientID As Long
    Private strClientCode As String
    Private strName As String
    Private strAddress As String
    Private strIndustry As String
    Private strContactNumber As String
    Private strFax As String
    Private strWebSite As String
    Private strEmailAddress As String
    Private strRemarks As String
    Private boolIsActiveFlg As Boolean
    Private boolPurgeFlg As Boolean
    Private dtCreateDate As DateTime
    Private lngCreatedBy As Long
    Private dtUpdateDate As DateTime
    Private lngUpdatedBy As Long
    Private tmpTimeStamp As String

    Public Property ClientID As Long
        Get
            Return lngClientID
        End Get
        Set(value As Long)
            lngClientID = value
        End Set
    End Property

    Public Property ClientCode As String
        Get
            Return strClientCode
        End Get
        Set(value As String)
            strClientCode = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return strName
        End Get
        Set(value As String)
            strName = value

        End Set
    End Property

    Public Property Address As String
        Get
            Return strAddress

        End Get
        Set(value As String)
            strAddress = value

        End Set
    End Property

    'Private strIndustry As String
    Public Property Industry As String
        Get
            Return strIndustry
        End Get
        Set(value As String)
            strIndustry = value
        End Set
    End Property

    'Private strContactNumber As String
    Public Property ContactNumber As String
        Get
            Return strContactNumber
        End Get
        Set(value As String)
            strContactNumber = value
        End Set
    End Property
    'Private strFax As String
    Public Property Fax As String
        Get
            Return strFax
        End Get
        Set(value As String)
            strFax = value
        End Set
    End Property

    'Private strWebSite As String
    Public Property Website As String
        Get
            Return strWebSite
        End Get
        Set(value As String)
            strWebSite = value
        End Set
    End Property
    'Private strEmailAddress As String
    Public Property EmailAddress As String
        Get
            Return strEmailAddress

        End Get
        Set(value As String)
            strEmailAddress = value
        End Set
    End Property
    'Private strRemarks As String
    Public Property Remarks As String
        Get
            Return strRemarks
        End Get
        Set(value As String)
            strRemarks = value

        End Set
    End Property
    'Private boolIsActiveFlg As Boolean
    Public Property IsActiveFlg As Boolean
        Get
            Return boolIsActiveFlg
        End Get
        Set(value As Boolean)
            boolIsActiveFlg = value
        End Set
    End Property
    'Private boolPurgeFlg As Boolean
    Public Property PurgeFlg As Boolean
        Get
            Return boolPurgeFlg
        End Get
        Set(value As Boolean)
            value = boolPurgeFlg
        End Set
    End Property
    'Private dtCreateDate As DateTime
    Public Property CreateDate As DateTime
        Get
            Return dtCreateDate
        End Get
        Set(value As DateTime)
            dtCreateDate = value
        End Set
    End Property
    'Private lngCreatedBy As Long
    Public Property CreatedBy As Long
        Get
            Return lngCreatedBy
        End Get
        Set(value As Long)
            lngCreatedBy = value
        End Set
    End Property
    'Private dtUpdateDate As DateTime
    Public Property UpdateDate As DateTime
        Get
            Return dtUpdateDate

        End Get
        Set(value As DateTime)
            dtUpdateDate = value

        End Set
    End Property
    'Private lngUpdatedBy As Long
    Public Property UpdatedBy As Long
        Get
            Return lngUpdatedBy
        End Get
        Set(value As Long)
            lngUpdatedBy = value

        End Set
    End Property
    'Private tmpTimeStamp As String



End Class
