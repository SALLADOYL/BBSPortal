Public Class _default8
    Inherits System.Web.UI.Page

    Private Sub PopulateServiceJobModal(ByVal ServiceJobID As Long)
        Dim entSvcJob As New CISEntity.TSWorkEntity
        Dim modSvcJob As New CISModel.ServiceJobModel

        entSvcJob = modSvcJob.GetServiceJob(ServiceJobID)

        With entSvcJob
            Me.txtTSWORKID.Text = .TSWorkID.ToString
            Me.txtServiceJobNo.Text = .ServiceJobNumber
            Me.txtQuotationNumber.Text = .QuotationNumber
            Me.txtPONumber.Text = .PONumber
            Me.txtQuoteDate.Text = .QuoteDate.ToShortDateString
            Me.txtDeliverTo.Text = .DeliverTo
            Me.ddJobCreatedBy.SelectedValue = .JobCreatedBy
            Me.ddWorkStatus.SelectedValue = .Status
            Me.ddSignedBy.SelectedValue = .ClientSignedBy
            Me.ddApprovedBy.SelectedValue = .JobApprovedBy
            Me.txtRemarks.Text = .Remarks

        End With

        entSvcJob = Nothing
        modSvcJob = Nothing
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class