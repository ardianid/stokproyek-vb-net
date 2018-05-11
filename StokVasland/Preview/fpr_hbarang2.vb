Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy

Imports DevExpress.XtraReports.UI

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class fpr_hbarang2

    Dim crReportDocument As r_hbarang2

    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView

    Private dvmanager2 As Data.DataViewManager
    Private dv2 As Data.DataView

    Private Sub load_barang()

        Dim cn As OleDbConnection = Nothing
        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim sql As String = "select kd_barang,nama_barang,0 as act from ms_barang"

            Dim ds As DataSet
            ds = New DataSet()
            ds = Clsmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            grid1.DataSource = dv1

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

    Private Sub load_kelompok()

        Dim cn As OleDbConnection = Nothing
        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim sql As String = "select 0 as act,nama_kelompok from ms_kelompok"

            Dim ds As DataSet
            ds = New DataSet()
            ds = Clsmy.GetDataSet(sql, cn)

            dvmanager2 = New DataViewManager(ds)
            dv2 = dvmanager.CreateDataView(ds.Tables(0))

            grid2.DataSource = dv2

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

    'Private Sub loadfaktur(ByVal sql As String)

    '    Dim cn As OleDbConnection = Nothing

    '    Try

    '        cn = New OleDbConnection
    '        cn = Clsmy.open_conn

    '        Dim ds As DataSet = New ds_hbarang2
    '        ds = Clsmy.GetDataSet(sql, cn)

    '        'dsinvoice_ku = New DataSet
    '        'dsinvoice_ku = ds

    '        Dim ops As New System.Drawing.Printing.PrinterSettings

    '        Dim rinvoice As New r_hbarang2() With {.DataSource = ds.Tables(0)}
    '        rinvoice.luser.Text = String.Format("User : {0} | Tgl : {1}", userprog, Date.Now)
    '        rinvoice.DataMember = rinvoice.DataMember

    '        rinvoice.PrinterName = ops.PrinterName
    '        rinvoice.CreateDocument(True)

    '        PrintControl1.PrintingSystem = rinvoice.PrintingSystem

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
    '    Finally


    '        If Not cn Is Nothing Then
    '            If cn.State = ConnectionState.Open Then
    '                cn.Close()
    '            End If
    '        End If
    '    End Try

    'End Sub

    Private Sub loadfaktur(ByVal sql As String)

        Dim cn As OleDbConnection = Nothing
        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim ds As New DataSet
            ds = Clsmy.GetDataSet(sql, cn)

            Dim ds1 As New ds_hbarang2
            ds1.Clear()
            ds1.Tables(0).Merge(ds.Tables(0))

            crReportDocument = New r_hbarang2
            crReportDocument.SetDataSource(ds1)

            Dim periode As String = String.Format("Periode : {0} s.d {1}", convert_date_to_ind(ttgl.EditValue), convert_date_to_ind(ttgl2.EditValue))

            crReportDocument.SetParameterValue("periode", periode)
            crReportDocument.SetParameterValue("userprint", String.Format("User : {0} | Tgl : {1}", userprog, Date.Now))

            crv1.ReportSource = crReportDocument
            crv1.Refresh()

        Catch ex As Exception
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

    Private Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton1.Click

        'Dim sql As String = String.Format("select b.kelompok,b.kd_barang,b.nama_barang,0 as sawal,sum(a.beli)/(b.qty1 * b.qty2) as beli, " & _
        '"sum(a.pakai)/(b.qty1 * b.qty2) as pakai, " & _
        '"sum(a.kembali)/(b.qty1 * b.qty2) as kembali,sum(a.opname)/(b.qty1 * b.qty2) as opname,0 as sakhir " & _
        '"from v_hist_stok2 a inner join ms_barang b on a.kd_barang=b.kd_barang where " & _
        '"a.tanggal>='{0}' and a.tanggal<='{1}'", convert_date_to_eng(ttgl.EditValue), convert_date_to_eng(ttgl2.EditValue))

        'Dim sql1 As String = String.Format("select b.kelompok,a.kd_barang,b.nama_barang,(sum(a.jmlin)- sum(a.jmlout))/(b.qty1 * b.qty2) as awal " & _
        '                                   ",0,0,0,0,0 from hbarang_gudang a inner join ms_barang b on a.kd_barang=b.kd_barang where " & _
        '                                   "a.tanggal<'{0}'", convert_date_to_eng(ttgl.EditValue))

        Dim sql As String = String.Format("select b.kelompok,b.kd_barang,b.nama_barang,0 as sawal,sum(a.beli) as beli, " & _
        "sum(a.pakai) as pakai, " & _
        "sum(a.kembali) as kembali,sum(a.opname) as opname,0 as sakhir,b.qty1, b.qty2 " & _
        "from v_hist_stok2 a inner join ms_barang b on a.kd_barang=b.kd_barang where " & _
        "a.tanggal>='{0}' and a.tanggal<='{1}'", convert_date_to_eng(ttgl.EditValue), convert_date_to_eng(ttgl2.EditValue))

        Dim sql1 As String = String.Format("select b.kelompok,a.kd_barang,b.nama_barang,(sum(a.jmlin)- sum(a.jmlout)) as awal " & _
                                           ",0,0,0,0,0,b.qty1, b.qty2 from hbarang_gudang a inner join ms_barang b on a.kd_barang=b.kd_barang where " & _
                                           "a.tanggal<'{0}'", convert_date_to_eng(ttgl.EditValue))

        Dim sqlf As String = ""
        Dim sqlf0 As String = ""
        Dim c As Integer = 0

        If XtraTabControl1.SelectedTabPageIndex = 0 Then

            sqlf0 = " and b.kd_barang in ( "
            sqlf0 = " and a.kd_barang in ( "

            For i As Integer = 0 To dv1.Count - 1

                If Integer.Parse(dv1(i)("act").ToString) = 1 Then
                    If c = 0 Then
                        sqlf = String.Format("'{0}'", dv1(i)("kd_barang").ToString)
                    Else
                        sqlf = String.Format("{0},'{1}'", sqlf.Trim, dv1(i)("kd_barang").ToString)
                    End If
                    c = c + 1
                End If

            Next

        Else

            sqlf0 = " and b.kelompok in ( "
            sqlf0 = " and b.kelompok in ( "

            For i As Integer = 0 To dv2.Count - 1

                If Integer.Parse(dv2(i)("act").ToString) = 1 Then
                    If c = 0 Then
                        sqlf = String.Format("'{0}'", dv2(i)("nama_kelompok").ToString)
                    Else
                        sqlf = String.Format("{0},'{1}'", sqlf.Trim, dv2(i)("nama_kelompok").ToString)
                    End If
                    c = c + 1
                End If

            Next

        End If

        If c > 0 Then
            sql = String.Format("{0} {1} {2})", sql, sqlf0, sqlf)
            sql1 = String.Format("{0} {1} {2})", sql1, sqlf0, sqlf)
        End If

        sql = String.Format(" {0} group by b.kelompok,b.kd_barang,b.nama_barang,b.qty1,b.qty2", sql)
        sql1 = String.Format(" {0} group by b.kelompok,a.kd_barang,b.nama_barang,b.qty1,b.qty2 ", sql1)

        sql = String.Format(" {0} having sum(a.beli) > 0 or sum(a.pakai) > 0 or " & _
        "sum(a.kembali) > 0 or sum(a.opname) > 0", sql)
        sql1 = String.Format(" {0} having (sum(a.jmlin)- sum(a.jmlout)) > 0", sql1)

        Dim sqlbenernya As String = String.Format("{0} union all {1}", sql, sql1)

        loadfaktur(sqlbenernya)

    End Sub

    Private Sub fpr_hbarang2_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        ttgl.Focus()
    End Sub

    Private Sub fpr_invoice2_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        load_barang()
        load_kelompok()

        ttgl.EditValue = DateValue(Date.Now)
        ttgl2.EditValue = DateValue(Date.Now)

        XtraTabControl1.SelectedTabPageIndex = 0

        CheckEdit1.Text = "Check All"

    End Sub

End Class