Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy
Imports DevExpress.XtraReports.UI
Public Class fbeli

    Private bs1 As BindingSource
    Private ds As DataSet
    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView

    Private Sub opendata()

        Dim tglsebelum As String = DateAdd(DateInterval.Month, -2, Date.Now)

        Dim sql As String = String.Format("SELECT tr_beli.nobukti, tr_beli.no_nota,tr_beli.nobukti_ps, tr_beli.tanggal, tr_beli.tanggal_beli,ms_penjual.kode as kd_toko, ms_penjual.nama AS nama_toko, ms_penjual.alamat AS alamat_toko, tr_beli.total_nett,tr_beli.sbatal,tr_beli.sbatal " & _
        "FROM  tr_beli INNER JOIN ms_penjual ON tr_beli.kd_penjual = ms_penjual.kode where tr_beli.tanggal>='{0}'  order by tr_beli.tanggal,tr_beli.nobukti ", convert_date_to_eng(tglsebelum))

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

        sql = "SELECT tr_beli.nobukti, tr_beli.no_nota,tr_beli.nobukti_ps, tr_beli.tanggal, tr_beli.tanggal_beli,ms_penjual.kode as kd_toko, ms_penjual.nama AS nama_toko, ms_penjual.alamat AS alamat_toko, tr_beli.total_nett,tr_beli.sbatal,tr_beli.sbatal " & _
        "FROM  tr_beli INNER JOIN ms_penjual ON tr_beli.kd_penjual = ms_penjual.kode"

        Select Case tcbofind.SelectedIndex
            Case 0 ' kode
                sql = String.Format("{0} where tr_beli.nobukti='{1}'", sql, tfind.Text.Trim)
            Case 1 ' nama
                sql = String.Format("{0} where tr_beli.no_nota like '%{1}%'", sql, tfind.Text.Trim)
            Case 2
                If Not IsDate(tfind.Text.Trim) Then
                    MsgBox("Koreksi Tanggal....", vbOKOnly + vbExclamation, "Informasi")
                    Return
                Else

                    If tfind.Text.Trim.Length < 10 Or tfind.Text.Trim.Length > 10 Then
                        MsgBox("Koreksi Tanggal....", vbOKOnly + vbExclamation, "Informasi")
                        Return
                    End If

                End If

                sql = String.Format("{0} where tr_beli.tanggal_beli='{1}'", sql, convert_date_to_eng(tfind.Text.Trim))
            Case 3
                sql = String.Format("{0} where ms_penjual.nama like '%{1}%'", sql, tfind.Text.Trim)
            Case 4
                sql = String.Format("{0} where tr_beli.nobukti in (select nobukti from tr_beli2 inner join ms_barang on tr_beli2.kd_barang=ms_barang.kd_barang where ms_barang.nama_barang like '%{1}%')", sql, tfind.Text.Trim)
        End Select

        If Not IsDate(tfind.Text.Trim) Then

            Dim tglsebelum As String = DateAdd(DateInterval.Year, -5, Date.Now)

            sql = String.Format("{0} and tr_beli.tanggal>='{1}'", sql, convert_date_to_eng(tglsebelum))

        End If

        sql = String.Format(" {0} order by tr_beli.tanggal,tr_beli.nobukti", sql)

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

        Dim sql As String = String.Format("update tr_beli set sbatal=1,alasan_batal='{0}' where nobukti='{1}'", alasan_batal.ToUpper, dv1(Me.BindingContext(bs1).Position)("nobukti").ToString)
        Dim sqlup_pesan As String = String.Format("update tr_pesanbeli set sdatang=0 where nobukti='{0}'", dv1(Me.BindingContext(bs1).Position)("nobukti_ps").ToString)

        Dim cn As OleDbConnection = Nothing
        Dim comd As OleDbCommand = Nothing

        Try

            open_wait()

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim sqltrans As OleDbTransaction = cn.BeginTransaction

            Dim sql2 As String = String.Format("select shutang from ms_penjual where kode='{0}'", dv1(Me.BindingContext(bs1).Position)("kd_toko").ToString)
            Dim cmd2 As OleDbCommand = New OleDbCommand(sql2, cn, sqltrans)
            Dim drd2 As OleDbDataReader = cmd2.ExecuteReader
            If drd2.Read Then
                If Integer.Parse(drd2(0).ToString) = 1 Then

                    Dim sqlup As String = String.Format("update ms_penjual set hutang=hutang-{0} where kode='{1}'", Replace(dv1(Me.BindingContext(bs1).Position)("total_nett").ToString, ",", "."), dv1(Me.BindingContext(bs1).Position)("kd_toko").ToString)
                    Using cmdup As OleDbCommand = New OleDbCommand(sqlup, cn, sqltrans)
                        cmdup.ExecuteNonQuery()
                    End Using

                End If
            End If
            drd2.Close()

            comd = New OleDbCommand(sql, cn, sqltrans)
            comd.ExecuteNonQuery()


            If dv1(Me.BindingContext(bs1).Position)("nobukti_ps").ToString.Length > 0 Then

                Using cmdup_ps As OleDbCommand = New OleDbCommand(sqlup_pesan, cn, sqltrans)
                    cmdup_ps.ExecuteNonQuery()
                End Using

            End If

            Clsmy.InsertToLog(cn, "btbeli", 0, 0, 1, 0, dv1(Me.BindingContext(bs1).Position)("nobukti").ToString, dv1(Me.BindingContext(bs1).Position)("tanggal").ToString, sqltrans)

            If hapus2(cn, sqltrans) = True Then
                sqltrans.Commit()

                close_wait()

                dv1(bs1.Position)("sbatal") = 1

                MsgBox("Data telah dibatalkan...", vbOKOnly + vbInformation, "Informasi")
            End If



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

    Private Function hapus2(ByVal cn As OleDbConnection, ByVal sqltrans As OleDbTransaction) As Boolean

        Dim hasil As Boolean = True

        Dim nobukti As String = dv1(bs1.Position)("nobukti").ToString
        Dim tanggal As String = dv1(bs1.Position)("tanggal_beli").ToString

        Dim sql As String = String.Format("select * from tr_beli2 where nobukti='{0}'", dv1(bs1.Position)("nobukti").ToString)
        Dim cmd As OleDbCommand = New OleDbCommand(sql, cn, sqltrans)
        Dim drd As OleDbDataReader = cmd.ExecuteReader

        If drd.HasRows Then
            While drd.Read

                Dim kdbarang As String = drd("kd_barang").ToString
                Dim qtykecil As String = drd("qtykecil").ToString

                If IsNumeric(drd("noid").ToString) Then

                    '2. update barang
                    Dim hasilplusmin As String = PlusMin_Barang(cn, sqltrans, qtykecil, kdbarang, False)
                    If Not hasilplusmin.Equals("ok") Then
                        MsgBox(hasilplusmin, vbOKOnly + vbExclamation, "Informasi")
                        hasil = False
                        close_wait()
                        Exit While

                    End If

                    ''3. insert to hist stok
                    Clsmy.Insert_HistBarang(cn, sqltrans, nobukti, tanggal, kdbarang, 0, qtykecil, "Pembelian (Batal)")

                End If

            End While
        End If

        Return hasil

    End Function

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

            Dim sql As String = String.Format("select sbatal from tr_beli where nobukti='{0}'", nobukti)
            Dim cmd As OleDbCommand = New OleDbCommand(sql, cn)
            Dim drd As OleDbDataReader = cmd.ExecuteReader

            If drd.Read Then
                If Not drd(0).ToString.Equals("") Then
                    dv1(bs1.Position)("sbatal") = drd("sbatal").ToString
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
        Using fkar2 As New fbeli2 With {.StartPosition = FormStartPosition.CenterParent, .dv = dv1, .addstat = True, .position = 0}
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

        If Integer.Parse(dv1(bs1.Position)("sbatal").ToString) = 1 Then
            MsgBox("Data telah dibatalkan..", vbOKOnly + vbExclamation, "Informasi")
            Return
        End If

        Using fkar2 As New fbeli2 With {.StartPosition = FormStartPosition.CenterParent, .dv = dv1, .addstat = False, .position = bs1.Position}
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

        Using fkar2 As New fbeli2 With {.StartPosition = FormStartPosition.CenterParent, .dv = dv1, .addstat = False, .position = bs1.Position}
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

        If dv1(bs1.Position)("sbatal").ToString.Equals("1") Then
            MsgBox("Faktur telah dibatalkan...", vbOKOnly + vbExclamation, "Informasi")
            Return
        End If

        Dim nobukti As String = dv1(bs1.Position)("nobukti").ToString

        Dim sql1 As String = String.Format("SELECT  tr_beli.nobukti, tr_beli.no_nota, tr_beli.tanggal_beli, ms_penjual.kode AS kd_toko,ms_penjual.kode + ' - ' + ms_penjual.nama AS nama_toko, ms_penjual.alamat AS alamat_toko, " & _
        "tr_beli.cr_bayar, tr_beli.note, tr_beli.disc_rp, tr_beli.total, tr_beli.total_nett, ms_barang.kd_barang, ms_barang.nama_barang, tr_beli2.qty, tr_beli2.satuan, " & _
        "tr_beli2.harga, tr_beli2.disc_rp AS disc_brg,tr_beli2.disc_rp2 AS disc_brg2, tr_beli2.jumlah " & _
        "FROM  tr_beli INNER JOIN tr_beli2 ON tr_beli.nobukti = tr_beli2.nobukti INNER JOIN " & _
        "ms_barang ON tr_beli2.kd_barang = ms_barang.kd_barang INNER JOIN ms_penjual ON tr_beli.kd_penjual = ms_penjual.kode " & _
        "WHERE tr_beli.sbatal=0 and tr_beli.nobukti='{0}'", nobukti)

        Using fkar2 As New fpr_buktibeli With {.WindowState = FormWindowState.Maximized, .sql1 = sql1}
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

        If dv1(bs1.Position)("sbatal").ToString.Equals("1") Then
            MsgBox("Faktur telah dibatalkan...", vbOKOnly + vbExclamation, "Informasi")
            Return
        End If

        Dim nobukti As String = dv1(bs1.Position)("nobukti").ToString

        Dim sql1 As String = String.Format("SELECT  tr_beli.nobukti, tr_beli.no_nota, tr_beli.tanggal_beli, ms_penjual.kode AS kd_toko,ms_penjual.kode + ' - ' + ms_penjual.nama AS nama_toko, ms_penjual.alamat AS alamat_toko, " & _
        "tr_beli.cr_bayar, tr_beli.note, tr_beli.disc_rp, tr_beli.total, tr_beli.total_nett, ms_barang.kd_barang, ms_barang.nama_barang, tr_beli2.qty, tr_beli2.satuan, " & _
        "tr_beli2.harga, tr_beli2.disc_rp AS disc_brg,tr_beli2.disc_rp2 AS disc_brg2, tr_beli2.jumlah " & _
        "FROM  tr_beli INNER JOIN tr_beli2 ON tr_beli.nobukti = tr_beli2.nobukti INNER JOIN " & _
        "ms_barang ON tr_beli2.kd_barang = ms_barang.kd_barang INNER JOIN ms_penjual ON tr_beli.kd_penjual = ms_penjual.kode " & _
        "WHERE tr_beli.sbatal=0 and tr_beli.nobukti='{0}'", nobukti)

        Dim cn As OleDbConnection = Nothing
        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim ds As DataSet = New ds_buktibeli
            ds = Clsmy.GetDataSet(sql1, cn)

            dsinvoice_ku = New DataSet
            dsinvoice_ku = ds

            Dim ops As New System.Drawing.Printing.PrinterSettings

            Dim rinvoice As New r_buktibeli() With {.DataSource = ds.Tables(0)}
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