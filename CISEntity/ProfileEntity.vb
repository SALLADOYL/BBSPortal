
Option Strict On
Imports System.Text
Imports System
Imports System.Collections.Generic

<Serializable()>
Public Class ProfileEntity
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

    'EMPLOYEECODE
    Private strEmployeeCode As String
    Public Property EmployeeCode As String
        Get
            Return strEmployeeCode
        End Get
        Set(value As String)
            strEmployeeCode = value
        End Set
    End Property

    'PHOTOURLPATH
    Private strPhotoURLPath As String
    Public Property PhotoUrlPath As String
        Get
            Return strPhotoURLPath
        End Get
        Set(value As String)
            strPhotoURLPath = value
        End Set
    End Property

    'NAME
    Private strName As String
    Public Property Name As String
        Get
            Return strName
        End Get
        Set(value As String)
            strName = value
        End Set
    End Property

    'ADDRESS
    Private strAddress As String
    Public Property Address As String
        Get
            Return strAddress
        End Get
        Set(value As String)
            strAddress = value
        End Set
    End Property

    'DATEHIRED
    Private dtDateHired As DateTime
    Public Property DateHired As DateTime
        Get
            Return dtDateHired
        End Get
        Set(value As DateTime)
            dtDateHired = value
        End Set
    End Property

    'FACULTYGROUP
    Private strFacultyGroup As String
    Public Property FacultyGroup As String
        Get
            Return strFacultyGroup
        End Get
        Set(value As String)
            strFacultyGroup = value
        End Set
    End Property

    'DEPARTMENT
    Private Property strDepartment As String
    Public Property Department As String
        Get
            Return strDepartment
        End Get
        Set(value As String)
            strDepartment = value
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

    'USERNAME
    Private strUserName As String
    Public Property UserName As String
        Get
            Return strUserName
        End Get
        Set(value As String)
            strUserName = value
        End Set
    End Property

    'PASSWORD
    Private strPassword As String
    Public Property Password As String
        Get
            Return strPassword
        End Get
        Set(value As String)
            strPassword = value
        End Set
    End Property

    ',WORKEMAIL
    Private strWorkEmail As String
    Public Property WorkEmail As String
        Get
            Return strWorkEmail
        End Get
        Set(value As String)
            strWorkEmail = value
        End Set
    End Property

    ',MOBILEPHONE
    Private strMobilePhone As String
    Public Property MobilePhone As String
        Get
            Return strMobilePhone
        End Get
        Set(value As String)
            strMobilePhone = value
        End Set
    End Property

    ',EXTENSION
    Private strExtension As String
    Public Property Extension As String
        Get
            Return strExtension
        End Get
        Set(value As String)
            strExtension = value

        End Set
    End Property

    ',BRANCH
    Private strBranch As String
    Public Property Branch As String
        Get
            Return strBranch
        End Get
        Set(value As String)
            strBranch = value
        End Set
    End Property
    ',DESIGNATION
    Private strDesignation As String
    Public Property Designation As String
        Get
            Return strDesignation
        End Get
        Set(value As String)
            strDesignation = value
        End Set
    End Property

    'ISAFFILIATEFLG
    Private boolIsAffiliateFlag As Boolean
    Public Property IsAffiliateFlag As Boolean
        Get
            Return boolIsAffiliateFlag
        End Get
        Set(value As Boolean)
            boolIsAffiliateFlag = value
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
