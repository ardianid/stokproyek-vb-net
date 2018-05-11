Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy
Imports DevExpress.XtraReports.UI
Public Class fpesan_beli

    Private bs1 As BindingSource
    Private ds As DataSet
    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView

    Private Sub opendata()

        Dim tglsebelum As String = DateAdd(DateInterval.Month, -2, Date.Now)

        Dim sql As String = String.Format("SELECT tr_pesanbeli.nobukti, tr_pesanbeli.tanggal, ms_penjual.nama as nama_toko, ms_penjual.alamat as alamat_toko, " & _
        "tr_pesanbeli.sdatang, tr_pesanbeli.sbatal " & _
        "FROM  tr_pesanbeli INNER JOIN ms_penjual ON tr_pesanbeli.kd_toko = ms_penjual.kode " & _
        "WHERE tr_pesanbeli.tanggal>='{0}' order by tr_pesanbeli.tanggal,tr_pesanbeli.nobukti", convert_date_to_eng(tglsebelum))

        Dim cn As OleDbConnection = Nothing

        grid1.DataSource = Nothing

        Try

            open_wait()

            dv1 = Nothing

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            ds = New DataSet()
            ds = Clsmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            bs1 = New BindingSource
            bs1.DataSource = dv1
            bn1.BindingSource = bs1

            grid1.DataSource = bs1

            close_wait()


        Catch ex As OleDb.OleDbException
            close_wait()
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally


            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try

    End Sub

    Private Sub cari()

        'bs1.DataSource = Nothing
        grid1.DataSource = Nothing
        Dim cn As OleDbConnection = Nothing

        Dim sql As String = ""
        Dim scbo As Integer = tcbofind.SelectedIndex

        sql = "SELECT tr_pesanbeli.nobukti, tr_pesanbeli.tanggal, ms_penjual.nama as nama_toko, ms_penjual.alamat as alamat_toko, " & _
        "tr_pesanbeli.sdatang, tr_pesanbeli.sbatal " & _
        "FROM  tr_pesanbeli INNER JOIN ms_penjual ON tr_pesanbeli.kd_toko = ms_penjual.kode"

        Select Case tcbofind.SelectedIndex
            Case 0 ' kode
                sql = String.Format("{0} where tr_pesanbeli.nobukti='{1}'", sql, tfind.Text.Trim)
            Case 1
                If Not IsDate(tfind.Text.Trim) Then
                    MsgBox("Koreksi Tanggal....", vbOKOnly + vbExclamation, "Informasi")
                    Return
                Else

                    If tfind.Text.Trim.Length < 10 Or tfind.Text.Trim.Length > 10 Then
                        MsgBox("Koreksi Tanggal....", vbOKOnly + vbExclamation, "Informasi")
                        Return
                    End If

                End If

                sql = String.Format("{0} where tr_pesanbeli.tanggal='{1}'", sql, convert_date_to_eng(tfind.Text.Trim))
            Case 2
                sql = String.Format("{0} where ms_penjual.nama like '%{1}%'", sql, tfind.Text.Trim)
            Case 3
                sql = String.Format("{0} where tr_pesanbeli.nobukti in (select nobukti from tr_pesanbeli2 inner join ms_barang on tr_pesanbeli2.kd_barang=ms_barang.kd_barang where ms_barang.nama_barang like '%{1}%')", sql, tfind.Text.Trim)
        End Select

        If Not IsDate(tfind.Text.Trim) Then

            Dim tglsebelum As String = DateAdd(DateInterval.Year, -5, Date.Now)

            sql = String.Format("{0} and tr_pesanbeli.tanggal>='{1}'", sql, convert_date_to_eng(tglsebelum))

        End If

        sql = String.Format(" {0} order by tr_pesanbeli.tanggal,tr_pesanbeli.nobukti", sql)

        Try

            open_wait()

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            ds = New DataSet()
            ds = Clsmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            bs1 = New BindingSource

            bs1.DataSource = dv1
            bn1.BindingSource = bs1

            grid1.DataSource = bs1

            close_wait()

        Catch ex As Exception
            close_wait()
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally
            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
        End Try

    End Sub

    Private Sub hapus()

        Dim alasan_batal As String = InputBox("Alasan Batal : ", "Konfirmasi")
        If alasan_batal.Trim.Equals("") Then
            MsgBox("Alasan Batal harus diisi...", vbOKOnly + vbInformation, "Informasi")
            Return
        End If

        Dim sql As String = String.Format("update tr_pesanbeli set sbatal=1,alasan_batal='{0}' where nobukti='{1}'", alasan_batal.ToUpper, dv1(Me.BindingContext(bs1).Position)("nobukti").ToString)

        Dim cn As OleDbConnection = Nothing
        Dim comd As OleDbCommand = Nothing

        Try

            open_wait()

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim sqltrans As OleDbTransaction = cn.BeginTransaction

            comd = New OleDbCommand(sql, cn, sqltrans)
            comd.ExecuteNonQuery()

            Clsmy.InsertToLog(cn, "btpesanbeli", 0, 0, 1, 0, dv1(Me.BindingContext(bs1).Position)("nobukti").ToString, dv1(Me.BindingContext(bs1).Position)("tanggal").ToString, sqltrans)

            sqltrans.Commit()

            close_wait()

            dv1(bs1.Position)("sbatal") = 1

            MsgBox("Data telah dibatalkan...", vbOKOnly + vbInformation, "Informasi")


        Catch ex As Exception
            close_wait()
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try


    End Sub

    Private Sub Get_Aksesform()

        Dim rows() As DataRow = dtmenu.Select(String.Format("NAMAFORM='{0}'", Me.Name.ToUpper.ToString))

        If Convert.ToInt16(rows(0)("t_add")) = 1 Then
            tsadd.Enabled = True
        Else
            tsadd.Enabled = False
        End If

        If Convert.ToInt16(rows(0)("t_edit")) = 1 Then
            tsedit.Enabled = True
        Else
            tsedit.Enabled = False
        End If

        If Convert.ToInt16(rows(0)("t_del")) = 1 Then
            tsdel.Enabled = True
        Else
            tsdel.Enabled = False
        End If

        If Convert.ToInt16(rows(0)("t_active")) = 1 Then
            tsview.Enabled = True
        Else
            tsview.Enabled = False
        End If

        Dim rows2() As DataRow = dtmenu2.Select(String.Format("NAMAFORM='{0}'", Me.Name.ToUpper.ToString))

        If rows2.Length > 0 Then
            tsprint.Enabled = True
            tsprint2.Enabled = True
        Else
            tsprint.Enabled = False
            tsprint2.Enabled = False
        End If

    End Sub

    Private Sub cek_batal(ByVal nobukti As String)

        Dim cn As OleDbConnection = Nothing

        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim sql As String = String.Format("select sbatal,sdatang from tr_pesanbeli where nobukti='{0}'", nobukti)
            Dim cmd As OleDbCommand = New OleDbCommand(sql, cn)
            Dim drd As OleDbDataReader = cmd.ExecuteReader

            If drd.Read Then
                If Not drd(0).ToString.Equals("") Then
                    dv1(bs1.Position)("sbatal") = drd("sbatal").ToString
                    dv1(bs1.Position)("sdatang") = drd("sdatang").ToString
                End If
            End If

            drd.Close()

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


    Private Sub fuser_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        tcbofind.SelectedIndex = 0

        Get_Aksesform()

        opendata()
    End Sub

    Private Sub tsfind_Click(sender As System.Object, e As System.EventArgs) Handles tsfind.Click
        cari()
    End Sub

    Private Sub tfind_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles tfind.KeyDown
        If e.KeyCode = 13 Then
            cari()
        End If
    End Sub

    Private Sub tsref_Click(sender As System.Object, e As System.EventArgs) Handles tsref.Click
        tfind.Text = ""
        opendata()
    End Sub

    Private Sub tsdel_Click(sender As System.Object, e As System.EventArgs) Handles tsdel.Click

        If IsNothing(dv1) Then
            Return
        End If

        If dv1.Count < 1 Then
            Exit Sub
        End If

        cek_batal(dv1(bs1.Position)("nobukti").ToString)

        If Integer.Parse(dv1(bs1.Position)("sdatang").ToString) = 1 Then
            MsgBox("Barang yang dipesan sudah datang, tidak dapat dibatalkan...", vbOKOnly + vbExclamation, "Informasi")
            Return
        End If

        If Integer.Parse(dv1(bs1.Position)("sbatal").ToString) = 1 Then
            MsgBox("Data telah dibatalkan..", vbOKOnly + vbExclamation, "Informasi")
            Return
        End If

        If MsgBox("Yakin akan dibatalkan ?", vbYesNo + vbQuestion, "Konfirmasi") = vbNo Then
            Exit Sub
        End If

        hapus()

    End Sub

    Private Sub tsadd_Click(sender As System.Object, e As System.EventArgs) Handles tsadd.Click
        Using fkar2 As New fpesan_beli2 With {.StartPosition = FormStartPosition.CenterParent, .dv = dv1, .addstat = True, .position = 0}
            fkar2.ShowDialog()
        End Using
    End Sub

    Private Sub tsedit_Click(sender As System.Object, e As System.EventArgs) Handles tsedit.Click

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count < 1 Then
            Exit Sub
        End If

        cek_batal(dv1(bs1.Position)("nobukti").ToString)

        If Integer.Parse(dv1(bs1.Position)("sdatang").ToString) = 1 Then
            MsgBox("Barang yang dipesan sudah datang, tidak dapat dirubah...", vbOKOnly + vbExclamation, "Informasi")
            Return
        End If

        If Integer.Parse(dv1(bs1.Position)("sbatal").ToString) = 1 Then
            MsgBox("Data telah dibatalkan..", vbOKOnly + vbExclamation, "Informasi")
            Return
        End If

        Using fkar2 As New fpesan_beli2 With {.StartPosition = FormStartPosition.CenterParent, .dv = dv1, .addstat = False, .position = bs1.Position}
            fkar2.ShowDialog()
        End Using

    End Sub

    Private Sub tsview_Click(sender As System.Object, e As System.EventArgs) Handles tsview.Click

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count < 1 Then
            Exit Sub
        End If

        Using fkar2 As New fpesan_beli2 With {.StartPosition = FormStartPosition.CenterParent, .dv = dv1, .addstat = False, .position = bs1.Position}
            fkar2.btadd.Enabled = False
            fkar2.btdel.Enabled = False
            fkar2.btsimpan.Enabled = False
            fkar2.ShowDialog()
        End Using

    End Sub

    Private Sub tsprint_Click(sender As System.Object, e As System.EventArgs) Handles tsprint.Click

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count < 1 Then
            Exit Sub
        End If

        cek_batal(dv1(bs1.Position)("nobukti").ToString)

        If Integer.Parse(dv1(bs1.Position)("sdatang").ToString) = 1 Then
            MsgBox("Barang yang dipesan sudah datang", vbOKOnly + vbExclamation, "Informasi")
            Return
        End If

        If dv1(bs1.Position)("sbatal").ToString.Equals("1") Then
            MsgBox("Faktur telah dibatalkan...", vbOKOnly + vbExclamation, "Informasi")
            Return
        End If



        Dim nobukti As String = dv1(bs1.Position)("nobukti").ToString

        Dim sql1 As String = String.Format("SELECT tr_pesanbeli.nobukti, tr_pesanbeli.tanggal, ms_penjual.kode AS kd_toko,ms_penjual.kode + ' - ' + ms_penjual.nama AS nama_toko, ms_penjual.alamat AS alamat_toko, tr_pesanbeli.note, " & _
        "ms_barang.kd_barang, ms_barang.nama_barang, tr_pesanbeli2.qty, tr_pesanbeli2.satuan " & _
        "FROM tr_pesanbeli INNER JOIN " & _
        "tr_pesanbeli2 ON tr_pesanbeli.nobukti = tr_pesanbeli2.nobukti INNER JOIN " & _
        "ms_barang ON tr_pesanbeli2.kd_barang = ms_barang.kd_barang INNER JOIN ms_penjual ON tr_pesanbeli.kd_toko = ms_penjual.kode " & _
        "where tr_pesanbeli.sbatal=0 and tr_pesanbeli.sdatang=0 and tr_pesanbeli.nobukti='{0}'", nobukti)

        Using fkar2 As New fpr_buktipesan With {.WindowState = FormWindowState.Maximized, .sql1 = sql1}
            fkar2.ShowDialog(Me)
        End Using

    End Sub

    Private Sub tsprint2_Click(sender As System.Object, e As System.EventArgs) Handles tsprint2.Click

        If IsNothing(dv1) Then
            Exit Sub
        End If

        If dv1.Count < 1 Then
            Exit Sub
        End If

        cek_batal(dv1(bs1.Position)("nobukti").ToString)

        If Integer.Parse(dv1(bs1.Position)("sdatang").ToString) = 1 Then
            MsgBox("Barang yang dipesan sudah datang", vbOKOnly + vbExclamation, "Informasi")
            Return
        End If

        If dv1(bs1.Position)("sbatal").ToString.Equals("1") Then
            MsgBox("Faktur telah dibatalkan...", vbOKOnly + vbExclamation, "Informasi")
            Return
        End If



        Dim nobukti As String = dv1(bs1.Position)("nobukti").ToString

        Dim sql1 As String = String.Format("SELECT tr_pesanbeli.nobukti, tr_pesanbeli.tanggal, ms_penjual.kode AS kd_toko,ms_penjual.kode + ' - ' + ms_penjual.nama AS nama_toko, ms_penjual.alamat AS alamat_toko, tr_pesanbeli.note, " & _
        "ms_barang.kd_barang, ms_barang.nama_barang, tr_pesanbeli2.qty, tr_pesanbeli2.satuan " & _
        "FROM tr_pesanbeli INNER JOIN " & _
        "tr_pesanbeli2 ON tr_pesanbeli.nobukti = tr_pesanbeli2.nobukti INNER JOIN " & _
        "ms_barang ON tr_pesanbeli2.kd_barang = ms_barang.kd_barang INNER JOIN ms_penjual ON tr_pesanbeli.kd_toko = ms_penjual.kode " & _
        "where tr_pesanbeli.sbatal=0 and tr_pesanbeli.sdatang=0 and tr_pesanbeli.nobukti='{0}'", nobukti)

        'Using fkar2 As New fpr_buktipesan With {.WindowState = FormWindowState.Maximized, .sql1 = sql1}
        '    fkar2.ShowDialog(Me)
        'End Using

        Dim cn As OleDbConnection = Nothing
        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim ds As DataSet = New ds_pesanbeli
            ds = Clsmy.GetDataSet(sql1, cn)

            dsinvoice_ku = New DataSet
            dsinvoice_ku = ds

            Dim ops As New System.Drawing.Printing.PrinterSettings

            Dim rinvoice As New r_buktipesan() With {.DataSource = ds.Tables(0)}
            rinvoice.xuser.Text = String.Format("User : {0} | Tgl : {1}", userprog, Date.Now)
            rinvoice.DataMember = rinvoice.DataMember

            rinvoice.PrinterName = ops.PrinterName
            rinvoice.CreateDocument(True)

            rinvoice.Print()

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
End Class