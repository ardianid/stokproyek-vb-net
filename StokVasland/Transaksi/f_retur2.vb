Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy
Imports DevExpress.XtraReports.UI

Public Class f_retur2

    Public dv As DataView
    Public position As Integer
    Public addstat As Boolean

    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView

    Private tgl_old As String

    Private Sub kosongkan()

        tbukti.Text = "<< New >>"

        tkd_toko.Text = ""
        tnama_toko.Text = ""
        talamat_toko.Text = ""

        talasan.Text = ""

        tket.Text = ""
        talasan.Text = ""

        opengrid()

        tbrutto.EditValue = 0

    End Sub

    Private Sub opengrid()

        Dim sql As String = String.Format("select tr_retur2.noid,ms_barang.kd_barang,ms_barang.nama_barang,tr_retur2.qty,tr_retur2.satuan,tr_retur2.qtykecil,tr_retur2.harga,tr_retur2.disc_per,tr_retur2.disc_rp,tr_retur2.jumlah " & _
            "from tr_retur2 inner join ms_barang on tr_retur2.kd_barang=ms_barang.kd_barang where tr_retur2.nobukti='{0}'", tbukti.Text.Trim)


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

        Dim sql As String = String.Format("SELECT tr_retur.nobukti,tr_retur.nobukti_beli, tr_retur.tanggal, ms_penjual.kode AS kd_toko, ms_penjual.nama AS nama_toko, " & _
            "ms_penjual.alamat AS alamat_toko, tr_retur.note, tr_retur.total " & _
            "FROM tr_retur INNER JOIN ms_penjual ON tr_retur.kd_toko = ms_penjual.kode WHERE tr_retur.nobukti='{0}'", nobukti)

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
                        tbeli.EditValue = dread("nobukti_beli").ToString

                        ttgl.EditValue = DateValue(dread("tanggal").ToString)

                        tgl_old = ttgl.EditValue

                        tkd_toko.EditValue = dread("kd_toko").ToString
                        tnama_toko.EditValue = dread("nama_toko").ToString
                        talamat_toko.EditValue = dread("alamat_toko").ToString

                        tket.EditValue = dread("note").ToString

                        opengrid()

                        tbrutto.EditValue = dread("total").ToString

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
                tbeli.Text = ""

                tkd_toko.EditValue = ""
                tnama_toko.EditValue = ""
                talamat_toko.EditValue = ""

                tbrutto.EditValue = 0

                tket.Text = ""
                talasan.Text = ""


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

            tbrutto.EditValue = 0

            Return
        End If

        If dv1.Count <= 0 Then

            tbrutto.EditValue = 0

            Return
        End If

        Dim jumlah As Double = 0

        For i As Integer = 0 To dv1.Count - 1

            jumlah = jumlah + Double.Parse(dv1(i)("jumlah").ToString)

        Next

        tbrutto.EditValue = jumlah

    End Sub

    Private Function cekbukti(ByVal cn As OleDbConnection, ByVal sqltrans As OleDbTransaction) As String

        Dim sql As String = ""

        Dim nobuktiawal As String = "PB."

        sql = String.Format("select max(nobukti) from tr_retur where  YEAR(tanggal)='{0}' and MONTH(tanggal)='{1}' and nobukti like '{2}%'", Year(ttgl.EditValue), Month(ttgl.EditValue), nobuktiawal)


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

        Dim tahun As String = Year(ttgl.EditValue)
        tahun = Microsoft.VisualBasic.Right(tahun, 2)
        Dim bulan As String = Month(ttgl.EditValue)

        If bulan.Length = 1 Then
            bulan = "0" & bulan
        End If

        Return String.Format("{0}{1}{2}{3}", nobuktiawal, tahun, bulan, kbukti)

    End Function

    Private Function cek_no_beli(ByVal cn As OleDbConnection) As Boolean

        Dim sql As String = String.Format("select nobukti from tr_beli where sbatal=0 and nobukti='{0}'", tbeli.Text.Trim)
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
                If tbeli.Text.Trim.Length > 0 Then

                    If cek_no_beli(cn) = False Then
                        close_wait()
                        MsgBox("No Bukti Beli tidak ditemukan...", vbOKOnly + vbExclamation, "Informasi")
                        tbeli.Focus()
                        Return
                    End If
                End If

            End If

            Dim sqltrans As OleDbTransaction = cn.BeginTransaction

            Dim cmd As OleDbCommand

            If addstat Then

                Dim bukti As String = cekbukti(cn, sqltrans)
                tbukti.EditValue = bukti

                '1 . update faktur
                Dim sqlin_faktur As String = String.Format("insert into tr_retur (nobukti,tanggal,kd_toko,alasan,note,nobukti_beli,total) values('{0}','{1}','{2}','{3}','{4}','{5}',{6})", _
                                                           tbukti.Text.Trim, convert_date_to_eng(ttgl.EditValue), tkd_toko.Text.Trim, talasan.Text.Trim, tket.Text.Trim, tbeli.Text.Trim, Replace(tbrutto.EditValue, ",", "."))

                cmd = New OleDbCommand(sqlin_faktur, cn, sqltrans)
                cmd.ExecuteNonQuery()

                Dim sql2 As String = String.Format("select shutang from ms_penjual where kode='{0}'", tkd_toko.Text.Trim)
                Dim cmd2 As OleDbCommand = New OleDbCommand(sql2, cn, sqltrans)
                Dim drd2 As OleDbDataReader = cmd2.ExecuteReader
                If drd2.Read Then
                    If Integer.Parse(drd2(0).ToString) = 1 Then

                        Dim sqlup As String = String.Format("update ms_penjual set hutang=hutang-{0} where kode='{1}'", tbrutto.EditValue, tkd_toko.Text.Trim)
                        Using cmdup As OleDbCommand = New OleDbCommand(sqlup, cn, sqltrans)
                            cmdup.ExecuteNonQuery()
                        End Using

                    End If
                End If
                drd2.Close()

                Clsmy.InsertToLog(cn, "btretur", 1, 0, 0, 0, tbukti.Text.Trim, ttgl.EditValue, sqltrans)

            Else

                '2. update piutang toko
                Dim sqlct As String = String.Format("select tr_retur.total,tr_retur.kd_toko as kd_penjual,ms_penjual.shutang from tr_retur inner join ms_penjual on tr_retur.kd_toko=ms_penjual.kode where tr_retur.nobukti='{0}'", tbukti.Text.Trim)

                Dim cmdt As OleDbCommand = New OleDbCommand(sqlct, cn, sqltrans)
                Dim drdt As OleDbDataReader = cmdt.ExecuteReader

                If drdt.Read Then
                    If IsNumeric(drdt("total").ToString) Then

                        Dim nett_sebelum As Double = drdt("total").ToString
                        Dim kdtoko_old As String = drdt("kd_penjual").ToString

                        If Integer.Parse(drdt("shutang").ToString) = 1 Then

                            Dim sqluptoko As String = String.Format("update ms_penjual set hutang=hutang + {0} where kode='{1}'", Replace(nett_sebelum, ",", "."), kdtoko_old)
                            Dim sqluptoko2 As String = String.Format("update ms_penjual set hutang=hutang - {0} where kode='{1}'", Replace(tbrutto.EditValue, ",", "."), tkd_toko.Text.Trim)

                            Dim cmdtk As OleDbCommand = New OleDbCommand(sqluptoko, cn, sqltrans)
                            cmdtk.ExecuteNonQuery()

                            Dim cmdtk2 As OleDbCommand = New OleDbCommand(sqluptoko2, cn, sqltrans)
                            cmdtk2.ExecuteNonQuery()

                        End If

                    End If
                End If
                drdt.Close()

                '1. update faktur
                Dim sqlup_faktur As String = String.Format("update tr_retur set tanggal='{0}',kd_toko='{1}',alasan='{2}',note='{3}',nobukti_beli='{4}',total={5} where nobukti='{6}'", _
                            convert_date_to_eng(ttgl.EditValue), tkd_toko.Text.Trim, talasan.Text.Trim, tket.Text.Trim, tbeli.Text.Trim, Replace(tbrutto.EditValue, ",", "."), tbukti.Text.Trim)


                cmd = New OleDbCommand(sqlup_faktur, cn, sqltrans)
                cmd.ExecuteNonQuery()

                Clsmy.InsertToLog(cn, "btretur", 0, 1, 0, 0, tbukti.Text.Trim, ttgl.EditValue, sqltrans)

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
                    tkd_toko.Focus()

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

            If dv1(i)("noid") <> 0 Then

                ''3. insert to hist stok
                Clsmy.Insert_HistBarang(cn, sqltrans, tbukti.Text.Trim, tgl_old, dv1(i)("kd_barang").ToString, dv1(i)("qtykecil").ToString, 0, "Pengembalian (Edit)")

                ''3. insert to hist stok
                Clsmy.Insert_HistBarang(cn, sqltrans, tbukti.Text.Trim, ttgl.EditValue, dv1(i)("kd_barang").ToString, 0, dv1(i)("qtykecil").ToString, "Pengembalian (Edit)")

            End If

            If dv1(i)("noid") = 0 Then

                Dim sqlins As String = String.Format("insert into tr_retur2 (nobukti,kd_barang,satuan,qty,qtykecil,harga,disc_per,disc_rp,jumlah) values('{0}','{1}','{2}',{3},{4},{5},{6},{7},{8})", _
                                                     tbukti.Text.Trim, dv1(i)("kd_barang").ToString, dv1(i)("satuan").ToString, dv1(i)("qty").ToString, dv1(i)("qtykecil").ToString, Replace(dv1(i)("harga").ToString, ",", "."), Replace(dv1(i)("disc_per").ToString, ",", "."), Replace(dv1(i)("disc_rp").ToString, ",", "."), Replace(dv1(i)("jumlah").ToString, ",", "."))

                Using cmdins As OleDbCommand = New OleDbCommand(sqlins, cn, sqltrans)
                    cmdins.ExecuteNonQuery()
                End Using

                '2. update barang
                Dim hasilplusmin As String = PlusMin_Barang(cn, sqltrans, dv1(i)("qtykecil").ToString, dv1(i)("kd_barang").ToString, False)
                If Not hasilplusmin.Equals("ok") Then
                    MsgBox(hasilplusmin, vbOKOnly + vbExclamation, "Informasi")
                    hasil = False
                    close_wait()
                    Exit For

                End If

                ''3. insert to hist stok
                Clsmy.Insert_HistBarang(cn, sqltrans, tbukti.Text.Trim, ttgl.EditValue, dv1(i)("kd_barang").ToString, 0, dv1(i)("qtykecil").ToString, "Pengembalian")

            End If

        Next

        Return hasil

    End Function

    Private Sub insertview()

        Dim orow As DataRowView = dv.AddNew
        orow("nobukti") = tbukti.Text.Trim
        orow("nobukti_beli") = tbeli.Text.Trim
        orow("tanggal") = ttgl.Text.Trim
        orow("kd_toko") = tkd_toko.Text.Trim
        orow("nama_toko") = tnama_toko.Text.Trim
        orow("alamat_toko") = talamat_toko.Text.Trim
        orow("total") = tbrutto.EditValue

        orow("sbatal") = 0

        dv.EndInit()

    End Sub

    Private Sub updateview()

        '  dv(position)("nobukti") = tbukti.Text.Trim
        dv(position)("nobukti_beli") = tbeli.Text.Trim
        dv(position)("tanggal") = ttgl.Text.Trim
        dv(position)("kd_toko") = tkd_toko.Text.Trim
        dv(position)("nama_toko") = tnama_toko.Text.Trim
        dv(position)("alamat_toko") = talamat_toko.Text.Trim
        dv(position)("total") = tbrutto.EditValue

    End Sub

    Private Sub load_print()

        Dim sql1 As String = String.Format("SELECT tr_retur.nobukti, tr_retur.tanggal, ms_penjual.kode+ ' - ' +ms_penjual.nama as nama_toko,ms_penjual.alamat as alamat_toko, ms_barang.kd_barang, ms_barang.nama_barang, tr_retur2.qty, tr_retur2.satuan, " & _
        "tr_retur2.harga, tr_retur2.disc_rp, tr_retur2.jumlah, tr_retur.alasan, tr_retur.note, tr_retur.total, tr_retur.nobukti_beli " & _
        "FROM tr_retur INNER JOIN tr_retur2 ON tr_retur.nobukti = tr_retur2.nobukti INNER JOIN " & _
        "ms_barang ON tr_retur2.kd_barang = ms_barang.kd_barang INNER JOIN ms_penjual ON tr_retur.kd_toko = ms_penjual.kode WHERE tr_retur.nobukti='{0}'", tbukti.Text.Trim)


        Dim cn As OleDbConnection = Nothing
        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim ds As DataSet = New ds_buktiretur
            ds = Clsmy.GetDataSet(sql1, cn)

            dsinvoice_ku = New DataSet
            dsinvoice_ku = ds

            Dim ops As New System.Drawing.Printing.PrinterSettings

            Dim rinvoice As New r_buktiretur() With {.DataSource = ds.Tables(0)}
            rinvoice.xuser.Text = String.Format("User : {0} | Tgl : {1}", userprog, Date.Now)
            rinvoice.DataMember = rinvoice.DataMember

            rinvoice.PrinterName = ops.PrinterName
            'rinvoice.PaperKind = Printing.PaperKind.Custom

            rinvoice.CreateDocument(True)
            ' rinvoice.PrintingSystem.ContinuousPageNumbering = True
            rinvoice.Print()
            ' Print(0, Chr(12))



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
        Using fkar2 As New f_retur3 With {.StartPosition = FormStartPosition.CenterParent, .dv = dv1, .addstat = True, .position = 0}
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
                Dim hasilplusmin As String = PlusMin_Barang(cn, sqltrans, qtykecil, kdbar, True)
                If Not hasilplusmin.Equals("ok") Then
                    MsgBox(hasilplusmin, vbOKOnly + vbExclamation, "Informasi")
                    sqltrans.Rollback()
                    GoTo langsung
                End If

                If addstat = False Then

                    If DateValue(tgl_old) <> DateValue(ttgl.EditValue) Then
                        Clsmy.Insert_HistBarang(cn, sqltrans, tbukti.Text.Trim, tgl_old, kdbar, qtykecil, 0, "Penngembalian (Edit)")
                        Clsmy.Insert_HistBarang(cn, sqltrans, tbukti.Text.Trim, ttgl.EditValue, kdbar, 0, qtykecil, "Pengembalian (Edit)")
                    End If

                End If

                '3. insert to hist stok
                Clsmy.Insert_HistBarang(cn, sqltrans, tbukti.Text.Trim, ttgl.EditValue, kdbar, qtykecil, 0, "Pengembalian (Edit)")

                Dim sql As String = String.Format("delete from tr_retur2 where noid={0}", dv1(Me.BindingContext(dv1).Position)("noid").ToString)

                Dim cmd As OleDbCommand = New OleDbCommand(sql, cn, sqltrans)
                cmd.ExecuteNonQuery()

                dv1.Delete(Me.BindingContext(dv1).Position)

                totalnetto()

                '2. update piutang toko
                Dim sqlct As String = String.Format("select tr_retur.total,tr_retur.kd_toko as kd_penjual,ms_penjual.shutang from tr_retur inner join ms_penjual on tr_retur.kd_toko=ms_penjual.kode where tr_retur.nobukti='{0}'", tbukti.Text.Trim)

                Dim cmdt As OleDbCommand = New OleDbCommand(sqlct, cn, sqltrans)
                Dim drdt As OleDbDataReader = cmdt.ExecuteReader

                If drdt.Read Then
                    If IsNumeric(drdt("total").ToString) Then

                        Dim nett_sebelum As Double = drdt("total").ToString
                        Dim kdtoko_old As String = drdt("kd_penjual").ToString

                        If Integer.Parse(drdt("shutang").ToString) = 1 Then

                            Dim sqluptoko As String = String.Format("update ms_penjual set hutang=hutang + {0} where kode='{1}'", Replace(nett_sebelum, ",", "."), kdtoko_old)
                            Dim sqluptoko2 As String = String.Format("update ms_penjual set hutang=hutang - {0} where kode='{1}'", Replace(tbrutto.EditValue, ",", "."), tkd_toko.Text.Trim)

                            Dim cmdtk As OleDbCommand = New OleDbCommand(sqluptoko, cn, sqltrans)
                            cmdtk.ExecuteNonQuery()

                            Dim cmdtk2 As OleDbCommand = New OleDbCommand(sqluptoko2, cn, sqltrans)
                            cmdtk2.ExecuteNonQuery()

                        End If

                    End If
                End If
                drdt.Close()

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

        tkd_toko.Focus()

    End Sub

    Private Sub ffaktur_to2_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If addstat = True Then


            ttgl.EditValue = Date.Now

            kosongkan()

        Else

            isi()

            tkd_toko.Enabled = False
            bts_toko.Enabled = False


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

        If Double.Parse(tbrutto.EditValue) < 0 Then
            MsgBox("Netto tidak boleh minus...", vbOKOnly + vbInformation, "Informasi")
            Return
        End If

        If talasan.Text.Trim.Length = 0 Then
            MsgBox("Alasan tidak boleh kosong..", vbOKOnly + vbInformation, "Informasi")
            talasan.Focus()
            Return
        End If

        If MsgBox("Yakin sudah benar.. ???", vbYesNo + vbQuestion, "Konfirmasi") = MsgBoxResult.No Then
            Return
        Else
            simpan()
        End If

    End Sub


End Class