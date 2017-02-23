Option Strict On
Imports System.Text
Imports System
Imports System.Collections.Generic

<Serializable()>
Public Class QuotationEntity

    'QUOTEID
    Private lngQuoteID As Long
    Public Property QuoteID As Long
        Get
            Return lngQuoteID
        End Get
        Set(value As Long)
            lngQuoteID = value
        End Set
    End Property

    'TSWORKID
    Private lngTSWorkID As Long
    Public Property TSWorkID As Long
        Get
            Return lngTSWorkID
        End Get
        Set(value As Long)
            lngTSWorkID = value
        End Set
    End Property

    'QUOTATIONNUMBER
    Private strQuotationNumber As String
    Public Property QuotationNumber As String
        Get
            Return strQuotationNumber
        End Get
        Set(value As String)
            strQuotationNumber = value
        End Set
    End Property

    'APPROVALDATE
    Private dtApprovalDate As DateTime
    Public Property ApprovalDate As DateTime
        Get
            Return dtApprovalDate
        End Get
        Set(value As DateTime)
            dtApprovalDate = value
        End Set
    End Property

    'APPROVEDBY
    Private lngApprovedBy As Long
    Public Property ApprovedBy As Long
        Get
            Return lngApprovedBy
        End Get
        Set(value As Long)
            lngApprovedBy = value
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
