Option Strict On
Imports System.Text
Imports System
Imports System.Collections.Generic

<Serializable()>
Public Class TechnicalReportEntity
    'TECHREPID
    Private lngTechnicalReportID As Long
    Public Property TechnicalReportID As Long
        Get
            Return lngTechnicalReportID
        End Get
        Set(value As Long)
            lngTechnicalReportID = value
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

    '[CLIENTSVCID]
    Private lngClientServiceID As Long
    Public Property ClientServiceID As Long
        Get
            Return lngClientServiceID
        End Get
        Set(value As Long)
            lngClientServiceID = value
        End Set
    End Property

    '[STARTDT] [datetime] NULL,
    Private dtStartdt As DateTime
    Public Property StartDate As DateTime
        Get
            Return dtStartdt
        End Get
        Set(value As DateTime)
            dtStartdt = value
        End Set
    End Property

    '[COMPLETEDT] [datetime] NULL,
    Private dtCompleteDt As DateTime
    Public Property CompletionDate As DateTime
        Get
            Return dtCompleteDt
        End Get
        Set(value As DateTime)
            dtCompleteDt = value
        End Set
    End Property

    ',STATUS
    Private strStatus As String
    Public Property Status As String
        Get
            Return strStatus
        End Get
        Set(value As String)
            strStatus = value
        End Set
    End Property

    'TEAM
    Private strTeam As String
    Public Property Team As String
        Get
            Return strTeam

        End Get
        Set(value As String)
            strTeam = value
        End Set
    End Property

    'PERFORMEDBY
    Private lngPerformedBy As Long
    Public Property PerformedBy As Long
        Get
            Return lngPerformedBy
        End Get
        Set(value As Long)
            lngPerformedBy = value
        End Set
    End Property

    'SEARCHTAGS
    Private strSearchTags As String
    Public Property SearchTags As String
        Get
            Return strSearchTags
        End Get
        Set(value As String)
            strSearchTags = value
        End Set
    End Property

    'INVESTIGATIONDETAILS
    Private strInvestigationDetails As String
    Public Property InvestigationDetails As String
        Get
            Return strInvestigationDetails
        End Get
        Set(value As String)
            strInvestigationDetails = value
        End Set
    End Property

    'ISSUECAUSE
    Private strIssueCause As String
    Public Property IssueCause As String
        Get
            Return strIssueCause
        End Get
        Set(value As String)
            strIssueCause = value
        End Set
    End Property

    'RESOLUTIONDETAILS
    Private strResolutionDetails As String
    Public Property ResolutionDetails As String
        Get
            Return strResolutionDetails
        End Get
        Set(value As String)
            strResolutionDetails = value
        End Set
    End Property

    'PROPOSEDDETAILS
    Private strProposedDetails As String
    Public Property ProposedDetails As String
        Get
            Return strProposedDetails
        End Get
        Set(value As String)
            strProposedDetails = value
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
