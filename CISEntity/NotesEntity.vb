Option Strict On
Imports System.Text
Imports System
Imports System.Collections.Generic

<Serializable()>
Public Class NotesEntity
    'NOTEID
    Private lngNoteID As Long
    Public Property NoteID As Long
        Get
            Return lngNoteID
        End Get
        Set(value As Long)
            lngNoteID = value
        End Set
    End Property

    'PARENTTYPE
    Private strParentType As String
    Public Property ParentType As String
        Get
            Return strParentType
        End Get
        Set(value As String)
            strParentType = value
        End Set
    End Property

    'PARENTID
    Private lngParentID As Long
    Public Property ParentID As Long
        Get
            Return lngParentID
        End Get
        Set(value As Long)
            lngParentID = value
        End Set
    End Property

    'Date
    Private dtNoteDate As DateTime
    Public Property NoteDate As DateTime
        Get
            Return dtNoteDate
        End Get
        Set(value As DateTime)
            dtNoteDate = value
        End Set
    End Property

    'NOTETEXT
    Private strNoteText As String
    Public Property NoteText As String
        Get
            Return strNoteText
        End Get
        Set(value As String)
            strNoteText = value
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
