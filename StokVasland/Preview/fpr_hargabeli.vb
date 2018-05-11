Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy

Imports DevExpress.XtraReports.UI

Public Class fpr_hargabeli

    Private Sub load_kelompok()

        Dim cn As OleDbConnection = Nothing
        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim sql As String = "select nama_kelompok from ms_kelompok"

            Dim ds As DataSet
            ds = New DataSet()
            ds = Clsmy.GetDataSet(sql, cn)

            Dim dt As DataTable = ds.Tables(0)

            Dim orow As DataRow = dt.NewRow
            orow(0) = "All"
            dt.Rows.InsertAt(orow, 0)

            tkelompok.Properties.DataSource = dt

            tkelompok.ItemIndex = 0

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

    Private Sub load_barang()

        Dim cn As OleDbConnection = Nothing
        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim sql As String = "select kd_barang,nama_barang from ms_barang order by nama_barang"

            Dim ds As DataSet
            ds = New DataSet()
            ds = Clsmy.GetDataSet(sql, cn)

            Dim dt As DataTable = ds.Tables(0)

            Dim orow As DataRow = dt.NewRow
            orow(0) = "All"
            orow(1) = "All"
            dt.Rows.InsertAt(orow, 0)

            tbarang.Properties.DataSource = dt

            tbarang.ItemIndex = 0

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

    Private Sub fpr_hargabeli_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tkelompok.Focus()
    End Sub

    Private Sub fpr_hargabeli_Load(sender As Object, e As EventArgs) Handles Me.Load

        ttgl.EditValue = DateValue(Date.Now)

        load_kelompok()
        load_barang()

    End Sub

    Private Sub loadfaktur(ByVal sql As String)

        Dim cn As OleDbConnection = Nothing

        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim ds As DataSet = New ds_hargabeli
            ds = Clsmy.GetDataSet(sql, cn)

            dsinvoice_ku = New DataSet
            dsinvoice_ku = ds

            Dim ops As New System.Drawing.Printing.PrinterSettings

            Dim rinvoice As New r_hargabeli() With {.DataSource = ds.Tables(0)}
            rinvoice.luser.Text = String.Format("User : {0} | Tgl : {1}", userprog, Date.Now)
            rinvoice.DataMember = rinvoice.DataMember

            rinvoice.PrinterName = ops.PrinterName
            rinvoice.CreateDocument(True)

            PrintControl1.PrintingSystem = rinvoice.PrintingSystem

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

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Dim sql As String = String.Format("select kd_barang,nama_barang,kelompok,satuan1, " & _
        "harga_beli=( " & _
        "select top 1 tr_beli2.harga from tr_beli inner join tr_beli2 on tr_beli.nobukti=tr_beli2.nobukti " & _
        "where tr_beli2.kd_barang=ms_barang.kd_barang and tr_beli.sbatal=0 and tr_beli2.harga<>0  " & _
        "and tr_beli.tanggal_beli <='{0}' " & _
        "order by tr_beli.tanggal_beli desc), " & _
        "tanggal_terakhir=( " & _
        "select top 1 tr_beli.tanggal_beli from tr_beli inner join tr_beli2 on tr_beli.nobukti=tr_beli2.nobukti " & _
        "where tr_beli2.kd_barang=ms_barang.kd_barang and tr_beli.sbatal=0 and tr_beli2.harga<>0 " & _
        "and tr_beli.tanggal_beli <='{0}' " & _
        "order by tr_beli.tanggal_beli desc) " & _
        "from ms_barang", convert_date_to_eng(ttgl.EditValue))

        If tkelompok.EditValue = "All" Then
        Else
            sql = String.Format("{0} where kelompok='{1}'", sql, tkelompok.EditValue)
        End If

        If tbarang.EditValue = "All" Then
        Else

            If tkelompok.EditValue = "All" Then
                sql = String.Format("{0} where kd_barang='{1}'", sql, tbarang.EditValue)
            Else
                sql = String.Format("{0} and kd_barang='{1}'", sql, tbarang.EditValue)
            End If

        End If

        loadfaktur(sql)


    End Sub

End Class