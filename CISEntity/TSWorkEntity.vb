Option Strict On
Imports System.Text
Imports System
Imports System.Collections.Generic

<Serializable()>
Public Class TSWorkEntity
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

    'CLSVCID
    Private lngClientServiceID As Long
    Public Property ClientServiceID As Long
        Get
            Return lngClientServiceID
        End Get
        Set(value As Long)
            lngClientServiceID = value
        End Set
    End Property

    '[SERVICEJOBNUMBER]
    Private lngServiceJobNumber As String
    Public Property ServiceJobNumber As String
        Get
            Return lngServiceJobNumber
        End Get
        Set(value As String)
            lngServiceJobNumber = value
        End Set
    End Property

    'PONUMBER
    Private strPONumber As String
    Public Property PONumber As String
        Get
            Return strPONumber
        End Get
        Set(value As String)
            strPONumber = value
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

    'QUOTEDATE
    Private dtQuoteDate As DateTime
    Public Property QuoteDate As DateTime
        Get
            Return dtQuoteDate
        End Get
        Set(value As DateTime)
            dtQuoteDate = value
        End Set
    End Property

    'FROMTEXT
    Private strFromText As String
    Public Property FromText As String
        Get
            Return strFromText
        End Get
        Set(value As String)
            strFromText = value
        End Set
    End Property

    'DELIVERTO
    Private strDeliverTo As String
    Public Property DeliverTo As String
        Get
            Return strDeliverTo
        End Get
        Set(value As String)
            strDeliverTo = value
        End Set
    End Property

    'TERMS
    Private strTerms As String
    Public Property Terms As String
        Get
            Return strTerms
        End Get
        Set(value As String)
            strTerms = value
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

    '[JOBCREATEDBY]
    Private lngJobCreatedBy As Long
    Public Property JobCreatedBy As Long
        Get
            Return lngJobCreatedBy
        End Get
        Set(value As Long)
            lngJobCreatedBy = value
        End Set
    End Property

    'JOBAPPROVALDATE
    Private dtJobApprovalDate As DateTime
    Public Property JobApprovalDate As DateTime
        Get
            Return dtJobApprovalDate
        End Get
        Set(value As DateTime)
            dtJobApprovalDate = value
        End Set
    End Property

    'JOBAPPROVEDBY
    Private lngJobApprovedBy As Long
    Public Property JobApprovedBy As Long
        Get
            Return lngJobApprovedBy
        End Get
        Set(value As Long)
            lngJobApprovedBy = value
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

    '[CLIENTSIGNEDBY]
    Private lngClientSignedBy As Long
    Public Property ClientSignedBy As Long
        Get
            Return lngClientSignedBy
        End Get
        Set(value As Long)
            lngClientSignedBy = value
        End Set
    End Property

    'ASSIGNEDTO
    'Private lngAssignedTo As Long
    'Public Property AssignedTo As Long
    '    Get
    '        Return lngAssignedTo
    '    End Get
    '    Set(value As Long)
    '        lngAssignedTo = value
    '    End Set
    'End Property

    'STARTDATE
    Private dtStartDate As DateTime
    Public Property StartDate As DateTime
        Get
            Return dtStartDate
        End Get
        Set(value As DateTime)
            dtStartDate = value
        End Set
    End Property

    'ENDDATE
    Private dtEndDate As DateTime
    Public Property EndDate As DateTime
        Get
            Return dtEndDate
        End Get
        Set(value As DateTime)
            dtEndDate = value
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
