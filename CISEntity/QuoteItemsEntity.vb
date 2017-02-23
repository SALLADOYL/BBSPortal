
Option Strict On
Imports System.Text
Imports System
Imports System.Collections.Generic

<Serializable()>
Public Class QuoteItemsEntity
    'QUOTEPARTID
    Private lngQuoteItemID As Long
    Public Property QuoteItemID As Long
        Get
            Return lngQuoteItemID
        End Get
        Set(value As Long)
            lngQuoteItemID = value
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

    'ITEMDESC
    Private strItemDescription As String
    Public Property ItemDescription As String
        Get
            Return strItemDescription
        End Get
        Set(value As String)
            strItemDescription = value
        End Set
    End Property

    'ITEMQTY
    Private intItemQty As Integer
    Public Property ItemQuantity As Integer
        Get
            Return intItemQty
        End Get
        Set(value As Integer)
            intItemQty = value
        End Set
    End Property

    'ITEMPER
    Private strItemPer As String
    Public Property ItemPer As String
        Get
            Return strItemPer
        End Get
        Set(value As String)
            strItemPer = value
        End Set
    End Property

    'ITEMPRICE
    Private dblItemPrice As Double
    Public Property ItemPrice As Double
        Get
            Return dblItemPrice

        End Get
        Set(value As Double)
            dblItemPrice = value
        End Set
    End Property

    'AMOUNT
    Private dblAmount As Double
    Public Property Amount As Double
        Get
            Return dblAmount
        End Get
        Set(value As Double)
            dblAmount = value
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

    'SORTNUM
    Private intSortNumber As Integer
    Public Property SortNumber As Integer
        Get
            Return intSortNumber
        End Get
        Set(value As Integer)
            intSortNumber = value
        End Set
    End Property

    'ISITEMFLAG
    Private boolIsItemFlag As Boolean
    Public Property IsItemFlag As Boolean
        Get
            Return boolIsItemFlag
        End Get
        Set(value As Boolean)
            boolIsItemFlag = value
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
