Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy
Imports DevExpress.XtraReports.UI
Public Class fbeli2

    Public dv As DataView
    Public position As Integer
    Public addstat As Boolean

    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView

    Private nonota_old As String
    Private tgl_old As String

    Private Sub kosongkan()

        tbukti.Text = "<< New >>"

        tnota.Text = ""

        tkd_toko.Text = ""
        tnama_toko.Text = ""
        talamat_toko.Text = ""

        tpesan.Text = ""

        tnote.Text = ""

        opengrid()

        tdisc_per.EditValue = 0.0
        tdisc_rp.EditValue = 0
        tnetto.EditValue = 0

        tbrutto.EditValue = 0

    End Sub

    Private Sub opengrid()

        Dim sql As String = String.Format("select tr_beli2.noid,ms_barang.kd_barang,ms_barang.nama_barang,tr_beli2.qty,tr_beli2.satuan,tr_beli2.qtykecil,tr_beli2.harga,tr_beli2.disc_per,tr_beli2.disc_rp,tr_beli2.jumlah,tr_beli2.disc_per2,tr_beli2.disc_rp2 " & _
            "from tr_beli2 inner join ms_barang on tr_beli2.kd_barang=ms_barang.kd_barang where tr_beli2.nobukti='{0}'", tbukti.Text.Trim)


        Dim cn As OleDbConnection = Nothing
        Dim ds As DataSet

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

            grid1.DataSource = dv1

            totalnetto()

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

    Private Sub isi()

        Dim nobukti As String = dv(position)("nobukti").ToString

        Dim sql As String = String.Format("SELECT tr_beli.nobukti,tr_beli.nobukti_ps, tr_beli.no_nota, tr_beli.tanggal, tr_beli.tanggal_beli, ms_penjual.kode AS kd_toko, ms_penjual.nama AS nama_toko, " & _
            "ms_penjual.alamat AS alamat_toko, tr_beli.cr_bayar, tr_beli.note, tr_beli.disc_per, tr_beli.disc_rp, tr_beli.total, tr_beli.total_nett " & _
            "FROM tr_beli INNER JOIN ms_penjual ON tr_beli.kd_penjual = ms_penjual.kode WHERE tr_beli.nobukti='{0}'", nobukti)

        Dim cn As OleDbConnection = Nothing

        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim comd As OleDbCommand = New OleDbCommand(sql, cn)
            Dim dread As OleDbDataReader = comd.ExecuteReader
            Dim hasil As Boolean

            If dread.HasRows Then
                If dread.Read Then

                    If Not dread("nobukti").ToString.Equals("") Then

                        hasil = True

                        tbukti.EditValue = dread("nobukti").ToString
                        tnota.EditValue = dread("no_nota").ToString

                        tpesan.EditValue = dread("nobukti_ps").ToString

                        nonota_old = tnota.EditValue.ToString.Trim

                        ttgl.EditValue = DateValue(dread("tanggal").ToString)

                        ttgl2.EditValue = DateValue(dread("tanggal_beli").ToString)
                        tgl_old = ttgl2.EditValue

                        tkd_toko.EditValue = dread("kd_toko").ToString
                        tnama_toko.EditValue = dread("nama_toko").ToString
                        talamat_toko.EditValue = dread("alamat_toko").ToString

                        cbjenis.EditValue = dread("cr_bayar").ToString

                        tnote.EditValue = dread("note").ToString

                        opengrid()

                        tbrutto.EditValue = dread("total").ToString


                        tdisc_per.EditValue = dread("disc_per").ToString
                        tdisc_rp.EditValue = dread("disc_rp").ToString
                        tnetto.EditValue = dread("total_nett").ToString

                    Else
                        hasil = False
                    End If


                Else
                    hasil = False
                End If
            Else
                hasil = False
            End If

            If hasil = False Then

                tbukti.EditValue = ""
                tnota.Text = ""

                tkd_toko.EditValue = ""
                tnama_toko.EditValue = ""
                talamat_toko.EditValue = ""

                tbrutto.EditValue = 0
                tdisc_per.EditValue = 0
                tdisc_rp.EditValue = 0
                tnetto.EditValue = 0

                tnote.EditValue = ""

            End If

            dread.Close()

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

    Private Sub totalnetto()

        If IsNothing(dv1) Then

            tdisc_per.EditValue = 0.0
            tdisc_rp.EditValue = 0
            tnetto.EditValue = 0
            tbrutto.EditValue = 0

            Return
        End If

        If dv1.Count <= 0 Then

            tdisc_per.EditValue = 0.0
            tdisc_rp.EditValue = 0
            tnetto.EditValue = 0
            tbrutto.EditValue = 0

            Return
        End If

        Dim jumlah As Double = 0

        For i As Integer = 0 To dv1.Count - 1

            jumlah = jumlah + Double.Parse(dv1(i)("jumlah").ToString)

        Next

        tbrutto.EditValue = jumlah

        Dim diskon As Double = tdisc_rp.EditValue

        If diskon > 0 Then
            jumlah = jumlah - diskon
        End If

        tnetto.EditValue = jumlah

    End Sub

    Private Function cekbukti(ByVal cn As OleDbConnection, ByVal sqltrans As OleDbTransaction) As String

        Dim sql As String = ""

        Dim nobuktiawal As String = "BL."
        Dim tahun As String = Year(ttgl.EditValue)
        tahun = Microsoft.VisualBasic.Right(tahun, 2)
        Dim bulan As String = Month(ttgl.EditValue)

        If bulan.Length = 1 Then
            bulan = "0" & bulan
        End If

        sql = String.Format("select max(nobukti) from tr_beli where   nobukti like '{0}%'", String.Format("{0}{1}{2}", nobuktiawal, tahun, bulan))
        

        Dim cmd As OleDbCommand = New OleDbCommand(sql, cn, sqltrans)
        Dim drd As OleDbDataReader = cmd.ExecuteReader

        Dim nilai As Integer = 0

        If drd.HasRows Then
            If drd.Read Then

                If Not drd(0).ToString.Equals("") Then
                    nilai = Microsoft.VisualBasic.Right(drd(0).ToString, 4)
                End If

            End If
        End If

        nilai = nilai + 1
        Dim kbukti As String = nilai

        Select Case kbukti.Length
            Case 1
                kbukti = "000" & nilai
            Case 2
                kbukti = "00" & nilai
            Case 3
                kbukti = "0" & nilai
            Case Else
                kbukti = nilai
        End Select


        Return String.Format("{0}{1}{2}{3}", nobuktiawal, tahun, bulan, kbukti)

    End Function

    Private Function cek_no_nota(ByVal cn As OleDbConnection) As Boolean

        Dim sql As String = String.Format("select no_nota from tr_beli where sbatal=0 and no_nota='{0}'", tnota.Text.Trim)
        Dim cmd As OleDbCommand = New OleDbCommand(sql, cn)
        Dim drd As OleDbDataReader = cmd.ExecuteReader

        Dim hasil As Boolean = False
        If drd.Read Then
            If Not drd(0).ToString.Equals("") Then
                hasil = True
            End If
        End If

        drd.Close()

        Return hasil

    End Function

    Private Sub simpan()

        Dim cn As OleDbConnection = Nothing

        Try
            open_wait()

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            If addstat = True Then
                If cek_no_nota(cn) = True Then
                    close_wait()
                    MsgBox("No Nota sudah ada...", vbOKOnly + vbExclamation, "Informasi")
                    tnota.Focus()
                    Return
                End If
            End If

            Dim sqltrans As OleDbTransaction = cn.BeginTransaction

            Dim cmd As OleDbCommand

            If addstat Then

                Dim bukti As String = cekbukti(cn, sqltrans)
                tbukti.EditValue = bukti


                cektglorder(cn, sqltrans)

                '1 . update faktur
                Dim sqlin_faktur As String = String.Format("insert into tr_beli (nobukti,no_nota,tanggal,tanggal_beli,kd_penjual,cr_bayar,note,total,disc_per,disc_rp,total_nett,nobukti_ps) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},{8},{9},{10},'{11}')", _
                                                           tbukti.Text.Trim, tnota.Text.Trim, convert_date_to_eng(ttgl.EditValue), convert_date_to_eng(ttgl2.EditValue), tkd_toko.Text.Trim, cbjenis.EditValue, tnote.Text.Trim, _
                                                           Replace(tbrutto.EditValue, ",", "."), Replace(tdisc_per.EditValue, ",", "."), Replace(tdisc_rp.EditValue, ",", "."), Replace(tnetto.EditValue, ",", "."), tpesan.Text.Trim)


                cmd = New OleDbCommand(sqlin_faktur, cn, sqltrans)
                cmd.ExecuteNonQuery()

                Dim sql2 As String = String.Format("select shutang from ms_penjual where kode='{0}'", tkd_toko.Text.Trim)
                Dim cmd2 As OleDbCommand = New OleDbCommand(sql2, cn, sqltrans)
                Dim drd2 As OleDbDataReader = cmd2.ExecuteReader
                If drd2.Read Then
                    If Integer.Parse(drd2(0).ToString) = 1 Then

                        Dim sqlup As String = String.Format("update ms_penjual set hutang=hutang+{0} where kode='{1}'", tnetto.EditValue, tkd_toko.Text.Trim)
                        Using cmdup As OleDbCommand = New OleDbCommand(sqlup, cn, sqltrans)
                            cmdup.ExecuteNonQuery()
                        End Using

                    End If
                End If
                drd2.Close()

                Dim sqlup_ps As String = String.Format("update tr_pesanbeli set sdatang=1 where nobukti='{0}'", tpesan.Text.Trim)
                Using cmd_ps As OleDbCommand = New OleDbCommand(sqlup_ps, cn, sqltrans)
                    cmd_ps.ExecuteNonQuery()
                End Using


                Clsmy.InsertToLog(cn, "btbeli", 1, 0, 0, 0, tbukti.Text.Trim, ttgl.EditValue, sqltrans)



            Else

                cektglorder(cn, sqltrans)

                '2. update piutang toko
                Dim sqlct As String = String.Format("select tr_beli.total_nett,tr_beli.kd_penjual,ms_penjual.shutang from tr_beli inner join ms_penjual on tr_beli.kd_penjual=ms_penjual.kode where tr_beli.nobukti='{0}'", tbukti.Text.Trim)

                Dim cmdt As OleDbCommand = New OleDbCommand(sqlct, cn, sqltrans)
                Dim drdt As OleDbDataReader = cmdt.ExecuteReader

                If drdt.Read Then
                    If IsNumeric(drdt("total_nett").ToString) Then

                        Dim nett_sebelum As Double = drdt("total_nett").ToString
                        Dim kdtoko_old As String = drdt("kd_penjual").ToString

                        If Integer.Parse(drdt("shutang").ToString) = 1 Then

                            Dim sqluptoko As String = String.Format("update ms_penjual set hutang=hutang - {0} where kode='{1}'", Replace(nett_sebelum, ",", "."), kdtoko_old)
                            Dim sqluptoko2 As String = String.Format("update ms_penjual set hutang=hutang + {0} where kode='{1}'", Replace(tnetto.EditValue, ",", "."), tkd_toko.Text.Trim)

                            Dim cmdtk As OleDbCommand = New OleDbCommand(sqluptoko, cn, sqltrans)
                            cmdtk.ExecuteNonQuery()

                            Dim cmdtk2 As OleDbCommand = New OleDbCommand(sqluptoko2, cn, sqltrans)
                            cmdtk2.ExecuteNonQuery()

                        End If

                    End If
                End If
                drdt.Close()

                '1. update faktur
                Dim sqlup_faktur As String = String.Format("update tr_beli set no_nota='{0}',tanggal='{1}',tanggal_beli='{2}',kd_penjual='{3}',cr_bayar='{4}',note='{5}',total={6},disc_per={7},disc_rp={8},total_nett={9},nobukti_ps='{10}' where nobukti='{11}'", _
                                                           tnota.Text.Trim, convert_date_to_eng(ttgl.EditValue), convert_date_to_eng(ttgl2.EditValue), tkd_toko.Text.Trim, cbjenis.EditValue, tnote.Text.Trim, _
                                                           Replace(tbrutto.EditValue, ",", "."), Replace(tdisc_per.EditValue, ",", "."), Replace(tdisc_rp.EditValue, ",", "."), Replace(tnetto.EditValue, ",", "."), tpesan.Text.Trim, tbukti.Text.Trim)

                cmd = New OleDbCommand(sqlup_faktur, cn, sqltrans)
                cmd.ExecuteNonQuery()

                Dim sqlup_ps As String = String.Format("update tr_pesanbeli set sdatang=1 where nobukti='{0}'", tpesan.Text.Trim)
                Using cmd_ps As OleDbCommand = New OleDbCommand(sqlup_ps, cn, sqltrans)
                    cmd_ps.ExecuteNonQuery()
                End Using

                Clsmy.InsertToLog(cn, "btbeli", 0, 1, 0, 0, tbukti.Text.Trim, ttgl.EditValue, sqltrans)

            End If


            If simpan2(cn, sqltrans) = True Then

                If addstat = True Then
                    insertview()
                Else
                    updateview()
                End If

                sqltrans.Commit()

                close_wait()




                If addstat = True Then

                    If MsgBox("Akan langsung print bukti nota ?", vbYesNo + vbQuestion, "Konfirmasi") = MsgBoxResult.Yes Then
                        load_print()
                    End If

                    kosongkan()
                    tnota.Focus()

                Else
                    MsgBox("Data disimpan...", vbOKOnly + vbInformation, "Informasi")
                    Me.Close()
                End If

            End If

lanjut_aja:

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

    Private Function simpan2(ByVal cn As OleDbConnection, ByVal sqltrans As OleDbTransaction) As Boolean

        Dim hasil As Boolean = True

        For i As Integer = 0 To dv1.Count - 1

            cek_tglhist(cn, sqltrans, dv1(i)("kd_barang").ToString)

            If dv1(i)("noid") <> 0 Then

                ''3. insert to hist stok
                Clsmy.Insert_HistBarang(cn, sqltrans, tbukti.Text.Trim, tgl_old, dv1(i)("kd_barang").ToString, 0, dv1(i)("qtykecil").ToString, "Pembelian (Edit)")

                ''3. insert to hist stok
                Clsmy.Insert_HistBarang(cn, sqltrans, tbukti.Text.Trim, ttgl2.EditValue, dv1(i)("kd_barang").ToString, dv1(i)("qtykecil").ToString, 0, "Pembelian (Edit)")

            End If

            If dv1(i)("noid") = 0 Then

                Dim sqlins As String = String.Format("insert into tr_beli2 (nobukti,kd_barang,satuan,qty,qtykecil,harga,disc_per,disc_rp,jumlah,disc_per2,disc_rp2) values('{0}','{1}','{2}',{3},{4},{5},{6},{7},{8},{9},{10})", _
                                                     tbukti.Text.Trim, dv1(i)("kd_barang").ToString, dv1(i)("satuan").ToString, dv1(i)("qty").ToString, dv1(i)("qtykecil").ToString, Replace(dv1(i)("harga").ToString, ",", "."), Replace(dv1(i)("disc_per").ToString, ",", "."), Replace(dv1(i)("disc_rp").ToString, ",", "."), Replace(dv1(i)("jumlah").ToString, ",", "."), Replace(dv1(i)("disc_per2").ToString, ",", "."), Replace(dv1(i)("disc_rp2").ToString, ",", "."))

                Using cmdins As OleDbCommand = New OleDbCommand(sqlins, cn, sqltrans)
                    cmdins.ExecuteNonQuery()
                End Using

                '2. update barang
                Dim hasilplusmin As String = PlusMin_Barang(cn, sqltrans, dv1(i)("qtykecil").ToString, dv1(i)("kd_barang").ToString, True)
                If Not hasilplusmin.Equals("ok") Then
                    MsgBox(hasilplusmin, vbOKOnly + vbExclamation, "Informasi")
                    hasil = False
                    close_wait()
                    Exit For

                End If

                ''3. insert to hist stok
                Clsmy.Insert_HistBarang(cn, sqltrans, tbukti.Text.Trim, ttgl2.EditValue, dv1(i)("kd_barang").ToString, dv1(i)("qtykecil").ToString, 0, "Pembelian")

            End If

        Next

        Return hasil

    End Function

    Private Sub cektglorder(ByVal cn As OleDbConnection, ByVal sqltrans As OleDbTransaction)

        Dim sql As String = String.Format("select tgl_akhir from ms_penjual where kode='{0}'", tkd_toko.Text.Trim)
        Dim cmd As OleDbCommand = New OleDbCommand(sql, cn, sqltrans)
        Dim drd As OleDbDataReader = cmd.ExecuteReader

        If drd.Read Then

            Dim tglakhir As String = drd(0).ToString

            If Not IsDate(tglakhir) Then

                Dim sqlup As String = String.Format("update ms_penjual set tgl_akhir='{0}' where kode='{1}'", convert_date_to_eng(ttgl.EditValue), tkd_toko.Text.Trim)

                Dim cmdup As OleDbCommand = New OleDbCommand(sqlup, cn, sqltrans)
                cmdup.ExecuteNonQuery()

            End If

        End If

        drd.Close()

    End Sub

    Private Sub cek_tglhist(ByVal cn As OleDbConnection, ByVal sqltrans As OleDbTransaction, ByVal kdbarang As String)

        Dim sql As String = String.Format("select tgl_beli from ms_barang where kd_barang='{0}'", kdbarang)
        Dim cmd As OleDbCommand = New OleDbCommand(sql, cn, sqltrans)
        Dim drd As OleDbDataReader = cmd.ExecuteReader

        Dim hasil As Boolean = False
        Dim tglhasil As String = ""

        If drd.Read Then
            If IsDate(drd(0).ToString) Then
                hasil = True
                tglhasil = drd(0).ToString
            End If
        End If

        Dim sqlup As String = ""
        If hasil = False Then
            sqlup = String.Format("update ms_barang set tgl_beli='{0}' where kd_barang='{1}'", convert_date_to_eng(ttgl.EditValue), kdbarang)

            Using cmdup As OleDbCommand = New OleDbCommand(sqlup, cn, sqltrans)
                cmdup.ExecuteNonQuery()
            End Using

        Else

            If DateValue(ttgl.EditValue) > DateValue(tglhasil) Then
                sqlup = String.Format("update ms_barang set tgl_beli='{0}' where kd_barang='{1}'", convert_date_to_eng(ttgl.EditValue), kdbarang)

                Using cmdup As OleDbCommand = New OleDbCommand(sqlup, cn, sqltrans)
                    cmdup.ExecuteNonQuery()
                End Using

            End If

        End If

    End Sub

    Private Sub insertview()

        Dim orow As DataRowView = dv.AddNew
        orow("nobukti") = tbukti.Text.Trim
        orow("no_nota") = tnota.Text.Trim
        orow("nobukti_ps") = tpesan.Text.Trim
        orow("tanggal") = ttgl.Text.Trim
        orow("tanggal_beli") = ttgl2.Text.Trim
        orow("kd_toko") = tkd_toko.Text.Trim
        orow("nama_toko") = tnama_toko.Text.Trim
        orow("alamat_toko") = talamat_toko.Text.Trim
        orow("total_nett") = tnetto.EditValue

        orow("sbatal") = 0

        dv.EndInit()

    End Sub

    Private Sub updateview()

        '  dv(position)("nobukti") = tbukti.Text.Trim
        dv(position)("no_nota") = tnota.Text.Trim
        dv(position)("nobukti_ps") = tpesan.Text.Trim
        dv(position)("tanggal") = ttgl.Text.Trim
        dv(position)("tanggal_beli") = ttgl2.Text.Trim
        dv(position)("kd_toko") = tkd_toko.Text.Trim
        dv(position)("nama_toko") = tnama_toko.Text.Trim
        dv(position)("alamat_toko") = talamat_toko.Text.Trim
        dv(position)("total_nett") = tnetto.EditValue

    End Sub

    Private Sub load_print()

        Dim sql1 As String = String.Format("SELECT  tr_beli.nobukti, tr_beli.no_nota, tr_beli.tanggal_beli, ms_penjual.kode AS kd_toko,ms_penjual.kode + ' - ' + ms_penjual.nama AS nama_toko, ms_penjual.alamat AS alamat_toko, " & _
        "tr_beli.cr_bayar, tr_beli.note, tr_beli.disc_rp, tr_beli.total, tr_beli.total_nett, ms_barang.kd_barang, ms_barang.nama_barang, tr_beli2.qty, tr_beli2.satuan, " & _
        "tr_beli2.harga, tr_beli2.disc_rp AS disc_brg,tr_beli2.disc_rp2 AS disc_brg2, tr_beli2.jumlah " & _
        "FROM  tr_beli INNER JOIN tr_beli2 ON tr_beli.nobukti = tr_beli2.nobukti INNER JOIN " & _
        "ms_barang ON tr_beli2.kd_barang = ms_barang.kd_barang INNER JOIN ms_penjual ON tr_beli.kd_penjual = ms_penjual.kode " & _
        "WHERE tr_beli.sbatal=0 and tr_beli.nobukti='{0}'", tbukti.Text.Trim)

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

    Private Sub bts_toko_Click(sender As System.Object, e As System.EventArgs) Handles bts_toko.Click

        Dim fs As New fsoutlet With {.StartPosition = FormStartPosition.CenterParent, .WindowState = FormWindowState.Normal}
        fs.ShowDialog(Me)

        tkd_toko.EditValue = fs.get_KODE
        tnama_toko.EditValue = fs.get_NAMA
        talamat_toko.EditValue = fs.get_ALAMAT

        tkd_toko_EditValueChanged(sender, Nothing)

    End Sub

    Private Sub tkd_toko_EditValueChanged(sender As Object, e As System.EventArgs) Handles tkd_toko.Validated
        If tkd_toko.Text.Trim.Length > 0 Then

            Dim cn As OleDbConnection = Nothing
            Dim sql As String = String.Format("select kode as kd_toko,nama as nama_toko,alamat as alamat_toko from ms_penjual where kode='{0}'", tkd_toko.Text.Trim)

            Try

                cn = New OleDbConnection
                cn = Clsmy.open_conn

                Dim comd As OleDbCommand = New OleDbCommand(sql, cn)
                Dim dread As OleDbDataReader = comd.ExecuteReader

                If dread.HasRows Then
                    If dread.Read Then

                        tkd_toko.EditValue = dread("kd_toko").ToString
                        tnama_toko.EditValue = dread("nama_toko").ToString
                        talamat_toko.EditValue = dread("alamat_toko").ToString

                    Else
                        tkd_toko.EditValue = ""
                        tnama_toko.EditValue = ""
                        talamat_toko.Text = ""


                    End If
                Else
                    tkd_toko.EditValue = ""
                    tnama_toko.EditValue = ""
                    talamat_toko.Text = ""

                End If


                dread.Close()

            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            Finally


                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End If
            End Try

        End If
    End Sub

    Private Sub tkd_toko_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tkd_toko.KeyDown
        If e.KeyCode = Keys.F4 Then
            bts_toko_Click(sender, Nothing)
        End If
    End Sub

    Private Sub tkd_toko_LostFocus(sender As Object, e As System.EventArgs) Handles tkd_toko.LostFocus
        If tkd_toko.Text.Trim.Length = 0 Then
            tkd_toko.EditValue = ""
            tnama_toko.EditValue = ""
            talamat_toko.Text = ""
        End If
    End Sub

    Private Sub btadd_Click(sender As System.Object, e As System.EventArgs) Handles btadd.Click
        Using fkar2 As New fbeli3 With {.StartPosition = FormStartPosition.CenterParent, .dv = dv1, .addstat = True, .position = 0}
            fkar2.ShowDialog(Me)

            totalnetto()

        End Using
    End Sub

    Private Sub btdel_Click(sender As System.Object, e As System.EventArgs) Handles btdel.Click

        If IsNothing(dv1) Then
            Return
        End If

        If dv1.Count <= 0 Then
            Return
        End If

        If addstat = True Then

            Dim kdbar As String = dv1(Me.BindingContext(dv1).Position)("kd_barang").ToString


            dv1.Delete(Me.BindingContext(dv1).Position)

            totalnetto()


        Else

            If Integer.Parse(dv1(Me.BindingContext(dv1).Position)("noid").ToString) = 0 Then
                dv1.Delete(Me.BindingContext(dv1).Position)
                Return
            End If

            Dim cn As OleDbConnection = Nothing

            Try

                cn = New OleDbConnection
                cn = Clsmy.open_conn

                Dim sqltrans As OleDbTransaction = cn.BeginTransaction

                Dim qtykecil As Integer = Integer.Parse(dv1(Me.BindingContext(dv1).Position)("qtykecil").ToString)
                Dim kdbar As String = dv1(Me.BindingContext(dv1).Position)("kd_barang").ToString

                '2. update barang
                Dim hasilplusmin As String = PlusMin_Barang(cn, sqltrans, qtykecil, kdbar, False)
                If Not hasilplusmin.Equals("ok") Then
                    MsgBox(hasilplusmin, vbOKOnly + vbExclamation, "Informasi")
                    sqltrans.Rollback()
                    GoTo langsung
                End If

                If addstat = False Then

                    If DateValue(tgl_old) <> DateValue(ttgl.EditValue) Then
                        Clsmy.Insert_HistBarang(cn, sqltrans, tbukti.Text.Trim, tgl_old, kdbar, 0, qtykecil, "Pembelian (Edit)")
                        Clsmy.Insert_HistBarang(cn, sqltrans, tbukti.Text.Trim, ttgl2.EditValue, kdbar, qtykecil, 0, "Pembelian (Edit)")
                    End If

                End If

                '3. insert to hist stok
                Clsmy.Insert_HistBarang(cn, sqltrans, tbukti.Text.Trim, ttgl2.EditValue, kdbar, 0, qtykecil, "Pembelian (Edit)")


                Dim sql As String = String.Format("delete from tr_beli2 where noid={0}", dv1(Me.BindingContext(dv1).Position)("noid").ToString)

                Dim cmd As OleDbCommand = New OleDbCommand(sql, cn, sqltrans)
                cmd.ExecuteNonQuery()

                dv1.Delete(Me.BindingContext(dv1).Position)

                totalnetto()

                '2. update piutang toko
                Dim sqlct As String = String.Format("select tr_beli.total_nett,tr_beli.kd_penjual,ms_penjual.shutang from tr_beli inner join ms_penjual on tr_beli.kd_penjual=ms_penjual.kode where tr_beli.nobukti='{0}'", tbukti.Text.Trim)

                Dim cmdt As OleDbCommand = New OleDbCommand(sqlct, cn, sqltrans)
                Dim drdt As OleDbDataReader = cmdt.ExecuteReader

                If drdt.Read Then
                    If IsNumeric(drdt("total_nett").ToString) Then

                        Dim nett_sebelum As Double = drdt("total_nett").ToString
                        Dim kdtoko_old As String = drdt("kd_penjual").ToString

                        If Integer.Parse(drdt("shutang").ToString) = 1 Then

                            Dim sqluptoko As String = String.Format("update ms_penjual set hutang=hutang - {0} where kode='{1}'", Replace(nett_sebelum, ",", "."), kdtoko_old)
                            Dim sqluptoko2 As String = String.Format("update ms_penjual set hutang=hutang + {0} where kode='{1}'", Replace(tnetto.EditValue, ",", "."), tkd_toko.Text.Trim)

                            Dim cmdtk As OleDbCommand = New OleDbCommand(sqluptoko, cn, sqltrans)
                            cmdtk.ExecuteNonQuery()

                            Dim cmdtk2 As OleDbCommand = New OleDbCommand(sqluptoko2, cn, sqltrans)
                            cmdtk2.ExecuteNonQuery()

                        End If

                    End If
                End If
                drdt.Close()


                '1. update faktur
                Dim sqlup_faktur As String = String.Format("update tr_beli set disc_per={0},disc_rp={1},total={2},total_nett={3} where nobukti='{4}'", Replace(tdisc_per.EditValue, ",", "."), Replace(tdisc_rp.EditValue, ",", "."), Replace(tbrutto.EditValue, ",", "."), Replace(tnetto.EditValue, ",", "."), tbukti.Text.Trim)

                Using cmdupfaktur As OleDbCommand = New OleDbCommand(sqlup_faktur, cn, sqltrans)
                    cmdupfaktur.ExecuteNonQuery()
                End Using

                ' akhir update header ---------------------------------------------------

                sqltrans.Commit()

                MsgBox("Data dihapus...", vbOKOnly + vbInformation, "Informasi")

langsung:

            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
            Finally


                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                End If
            End Try

        End If

    End Sub

    Private Sub btclose_Click(sender As System.Object, e As System.EventArgs) Handles btclose.Click
        Me.Close()
    End Sub

    Private Sub ffaktur_to2_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated

            tnota.Focus()

    End Sub

    Private Sub ffaktur_to2_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If addstat = True Then


            ttgl.EditValue = Date.Now
            ttgl2.EditValue = Date.Now

            cbjenis.SelectedIndex = 1

            kosongkan()

            tpesan.Enabled = True
            bts_pesan.Enabled = True

        Else

            isi()

            tpesan.Enabled = False
            bts_pesan.Enabled = False

        End If

    End Sub

    Private Sub btsimpan_Click(sender As System.Object, e As System.EventArgs) Handles btsimpan.Click

        If tkd_toko.Text.Trim.Length = 0 Then
            MsgBox("Outlet harus diisi...", vbOKOnly + vbInformation, "Informasi")
            tkd_toko.Focus()
            Return
        End If

        If IsNothing(dv1) Then
            MsgBox("Tidak ada barang yang akan dibeli", vbOKOnly + vbInformation, "Informasi")
            Return
        End If

        If dv1.Count <= 0 Then
            MsgBox("Tidak ada barang yang akan dibeli", vbOKOnly + vbInformation, "Informasi")
            Return
        End If

        If Double.Parse(tnetto.EditValue) < 0 Then
            MsgBox("Netto tidak boleh minus...", vbOKOnly + vbInformation, "Informasi")
            Return
        End If

        If MsgBox("Yakin sudah benar.. ???", vbYesNo + vbQuestion, "Konfirmasi") = MsgBoxResult.No Then
            Return
        Else
            simpan()
        End If

    End Sub

    Private Sub tdisc_per_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles tdisc_per.Validated

        If tdisc_per.EditValue > 0 Then

            Dim brutto As Double = tbrutto.EditValue
            Dim disc As Double = tdisc_per.EditValue / 100
            Dim hasil As Double = brutto * disc

            tdisc_rp.EditValue = hasil
        Else
            tdisc_rp.EditValue = 0
        End If

        totalnetto()

    End Sub

    Private Sub tdisc_rp_Validated(sender As Object, e As System.EventArgs) Handles tdisc_rp.Validated

        If tdisc_rp.EditValue > 0 Then

            Dim brutto As Double = tbrutto.EditValue
            Dim disc As Double = tdisc_rp.EditValue
            Dim hasil As Double = (disc / brutto) * 100

            tdisc_per.EditValue = hasil
        Else
            tdisc_per.EditValue = 0.0
        End If

        totalnetto()

    End Sub

    Private Sub tbrutto_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles tbrutto.EditValueChanged
        tdisc_per_EditValueChanged(sender, Nothing)
        totalnetto()
    End Sub

    Private Sub tpesan_LostFocus(sender As Object, e As System.EventArgs) Handles tpesan.LostFocus
        If tkd_toko.Text.Trim.Length = 0 Then
            tpesan.Text = ""
        End If
    End Sub

    Private Sub tpesan_Validated(sender As System.Object, e As System.EventArgs) Handles tpesan.Validated

        If tpesan.Text.Trim.Length > 0 Then

            If tkd_toko.Text.Trim.Length = 0 Then
                Return
            End If

            Using fkar2 As New fbeli_bypesan With {.StartPosition = FormStartPosition.CenterParent, .dv = dv1, .nobukti_ps = tpesan.Text.Trim, .kdtoko = tkd_toko.Text.Trim}
                fkar2.ShowDialog(Me)

                totalnetto()

            End Using

        End If

    End Sub

    Private Sub bts_pesan_Click(sender As System.Object, e As System.EventArgs) Handles bts_pesan.Click

        If tkd_toko.Text.Trim.Length = 0 Then
            Return
        End If

        Dim fs As New fs_pemesanan With {.StartPosition = FormStartPosition.CenterParent, .WindowState = FormWindowState.Normal, .kd_toko = tkd_toko.Text.Trim}
        fs.ShowDialog(Me)

        tpesan.EditValue = fs.get_NOBUKTI
        tpesan_Validated(sender, Nothing)

    End Sub

End Class