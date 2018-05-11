Public Class r_hbarang2

    Dim saldoawal As Integer
    Dim pembelian As Integer
    Dim pemakaian As Integer
    Dim pengembalian As Integer
    Dim opname As Integer

    Private Sub XrLabel20_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles xrakhir.SummaryGetResult
        e.Result = saldoawal + pembelian + opname - pemakaian - pengembalian
        e.Handled = True
    End Sub

    Private Sub XrLabel20_SummaryReset(sender As System.Object, e As System.EventArgs) Handles xrakhir.SummaryReset
        saldoawal = 0
        pembelian = 0
        pemakaian = 0
        pengembalian = 0
        opname = 0
    End Sub

    Private Sub XrLabel20_SummaryRowChanged(sender As System.Object, e As System.EventArgs) Handles xrakhir.SummaryRowChanged
        saldoawal = saldoawal + Integer.Parse(GetCurrentColumnValue("sawal"))
        pembelian = pembelian + Integer.Parse(GetCurrentColumnValue("beli"))
        pemakaian = pemakaian + Integer.Parse(GetCurrentColumnValue("pakai"))
        pengembalian = pengembalian + Integer.Parse(GetCurrentColumnValue("kembali"))
        opname = opname + Integer.Parse(GetCurrentColumnValue("opname"))
    End Sub

End Class