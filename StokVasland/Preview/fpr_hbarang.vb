Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class fpr_hbarang

    Dim crReportDocument As r_hbarang

    Dim dvg As DataView

    Private Sub load_print()

        Cursor = Cursors.WaitCursor

        Dim cn As OleDbConnection = Nothing

        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn()

            Dim sql As String = String.Format("SELECT hbarang_gudang.noid, hbarang_gudang.nobukti, hbarang_gudang.tanggal, ms_barang.kd_barang, ms_barang.nama_barang, hbarang_gudang.jmlin, " & _
                "hbarang_gudang.jmlout, hbarang_gudang.jenis, ms_barang.satuan1, ms_barang.satuan2,ms_barang.qty1, ms_barang.qty2 " & _
                "FROM  hbarang_gudang INNER JOIN ms_barang ON hbarang_gudang.kd_barang = ms_barang.kd_barang " & _
            "WHERE  hbarang_gudang.tanggal >='{0}' and hbarang_gudang.tanggal <='{1}' and hbarang_gudang.kd_barang='{2}'", convert_date_to_eng(ttgl.EditValue), convert_date_to_eng(ttgl2.EditValue), tbarang.EditValue)

            Dim ds As New DataSet
            ds = Clsmy.GetDataSet(sql, cn)

            Dim ds1 As New ds_hbarang
            ds1.Clear()
            ds1.Tables(0).Merge(ds.Tables(0))

            crReportDocument = New r_hbarang
            crReportDocument.SetDataSource(ds1)

            Dim jmlold As String = cek_jmlold(cn).ToString

            crReportDocument.SetParameterValue("tgl1", convert_date_to_ind(ttgl.EditValue))
            crReportDocument.SetParameterValue("tgl2", convert_date_to_ind(ttgl2.EditValue))
            crReportDocument.SetParameterValue("ajmlold2", jmlold)
            crReportDocument.SetParameterValue("userprint", String.Format("User : {0} | Tgl : {1}", userprog, Date.Now))

            CrystalReportViewer1.ReportSource = crReportDocument
            CrystalReportViewer1.Refresh()

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally

            Cursor = Cursors.Default

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
        End Try

    End Sub

    Private Function cek_jmlold(ByVal cn As OleDbConnection) As Integer

        Dim jmlold As Integer = 0

        Dim sql As String = String.Format("select sum(jmlin)- sum(jmlout) as jmlold from hbarang_gudang where tanggal <'{0}' and kd_barang='{1}'", convert_date_to_eng(ttgl.EditValue), tbarang.EditValue)
        Dim cmd As OleDbCommand = New OleDbCommand(sql, cn)
        Dim drd As OleDbDataReader = cmd.ExecuteReader

        If drd.Read Then
            If IsNumeric(drd(0).ToString) Then
                jmlold = Integer.Parse(drd(0).ToString)
            End If
        End If

        drd.Close()

        Return jmlold

    End Function

    Private Sub isi_barang()

        Const sql As String = "select kd_barang,nama_barang from ms_barang"

        Dim cn As OleDbConnection = Nothing
        Dim ds As DataSet


        Try

            cn = Clsmy.open_conn
            ds = New DataSet
            ds = Clsmy.GetDataSet(sql, cn)

            Dim dvm As DataViewManager = New DataViewManager(ds)
            dvg = dvm.CreateDataView(ds.Tables(0))

            tbarang.Properties.DataSource = dvg

            If dvg.Count > 0 Then
                tbarang.ItemIndex = 0
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try

    End Sub

    Private Sub fpr_rekapaktur_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        ttgl.EditValue = Date.Now
        ttgl2.EditValue = Date.Now

        isi_barang()

    End Sub

    Private Sub btload_Click(sender As System.Object, e As System.EventArgs) Handles btload.Click

        load_print()

    End Sub

    Private Sub tbarang_EditValueChanged(sender As Object, e As System.EventArgs) Handles tbarang.EditValueChanged

        tnamabarang.Text = dvg(tbarang.ItemIndex)("nama_barang").ToString

    End Sub


End Class