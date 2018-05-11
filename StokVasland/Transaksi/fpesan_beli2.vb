Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy
Imports DevExpress.XtraReports.UI
Public Class fpesan_beli2

    Public dv As DataView
    Public position As Integer
    Public addstat As Boolean

    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView

    Private Sub kosongkan()

        tbukti.Text = "<< New >>"

        tkd_toko.Text = ""
        tnama_toko.Text = ""
        talamat_toko.Text = ""

        tnote.Text = ""

        opengrid()

    End Sub

    Private Sub opengrid()

        Dim sql As String = String.Format("SELECT tr_pesanbeli2.noid, ms_barang.kd_barang, ms_barang.nama_barang, tr_pesanbeli2.qty,tr_pesanbeli2.qtykecil, tr_pesanbeli2.satuan " & _
        "FROM tr_pesanbeli2 INNER JOIN ms_barang ON tr_pesanbeli2.kd_barang = ms_barang.kd_barang " & _
        "WHERE tr_pesanbeli2.nobukti='{0}'", tbukti.Text.Trim)


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

        Dim sql As String = String.Format("SELECT tr_pesanbeli.nobukti, tr_pesanbeli.tanggal, ms_penjual.kode AS kd_toko, ms_penjual.nama AS nama_toko, ms_penjual.alamat AS alamat_toko, tr_pesanbeli.note " & _
        "FROM tr_pesanbeli INNER JOIN ms_penjual ON tr_pesanbeli.kd_toko = ms_penjual.kode " & _
        "WHERE tr_pesanbeli.nobukti='{0}'", nobukti)

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

                        ttgl.EditValue = DateValue(dread("tanggal").ToString)

                        tkd_toko.EditValue = dread("kd_toko").ToString
                        tnama_toko.EditValue = dread("nama_toko").ToString
                        talamat_toko.EditValue = dread("alamat_toko").ToString

                        tnote.EditValue = dread("note").ToString

                        opengrid()

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

                tkd_toko.EditValue = ""
                tnama_toko.EditValue = ""
                talamat_toko.EditValue = ""

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

    Private Function cekbukti(ByVal cn As OleDbConnection, ByVal sqltrans As OleDbTransaction) As String

        Dim sql As String = ""

        Dim nobuktiawal As String = "PB."

        sql = String.Format("select max(nobukti) from tr_pesanbeli where  YEAR(tanggal)='{0}' and MONTH(tanggal)='{1}' and nobukti like '{2}%'", Year(ttgl.EditValue), Month(ttgl.EditValue), nobuktiawal)

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

    Private Sub simpan()

        Dim cn As OleDbConnection = Nothing

        Try
            open_wait()

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim sqltrans As OleDbTransaction = cn.BeginTransaction

            Dim cmd As OleDbCommand

            If addstat Then

                Dim bukti As String = cekbukti(cn, sqltrans)
                tbukti.EditValue = bukti

                '1 . update faktur
                Dim sqlin_faktur As String = String.Format("insert into tr_pesanbeli (nobukti,tanggal,kd_toko,note) values('{0}','{1}','{2}','{3}')", _
                                                           tbukti.Text.Trim, convert_date_to_eng(ttgl.EditValue), tkd_toko.Text.Trim, tnote.Text.Trim)

                cmd = New OleDbCommand(sqlin_faktur, cn, sqltrans)
                cmd.ExecuteNonQuery()

                Clsmy.InsertToLog(cn, "btpesanbeli", 1, 0, 0, 0, tbukti.Text.Trim, ttgl.EditValue, sqltrans)


            Else

                '1. update faktur
                Dim sqlup_faktur As String = String.Format("update tr_pesanbeli set tanggal='{0}',kd_toko='{1}',note='{2}' where nobukti='{3}'", _
                                                           convert_date_to_eng(ttgl.EditValue), tkd_toko.Text.Trim, tnote.Text.Trim, tbukti.Text.Trim)

                cmd = New OleDbCommand(sqlup_faktur, cn, sqltrans)
                cmd.ExecuteNonQuery()

                Clsmy.InsertToLog(cn, "btpesanbeli", 0, 1, 0, 0, tbukti.Text.Trim, ttgl.EditValue, sqltrans)

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
                    ttgl.Focus()

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

            If dv1(i)("noid") = 0 Then

                Dim sqlins As String = String.Format("insert into tr_pesanbeli2 (nobukti,kd_barang,satuan,qty,qtykecil) values('{0}','{1}','{2}',{3},{4})", _
                                                     tbukti.Text.Trim, dv1(i)("kd_barang").ToString, dv1(i)("satuan").ToString, dv1(i)("qty").ToString, dv1(i)("qtykecil").ToString)

                Using cmdins As OleDbCommand = New OleDbCommand(sqlins, cn, sqltrans)
                    cmdins.ExecuteNonQuery()
                End Using

            End If

        Next

        Return hasil

    End Function

    Private Sub insertview()

        Dim orow As DataRowView = dv.AddNew
        orow("nobukti") = tbukti.Text.Trim
        orow("tanggal") = ttgl.Text.Trim
        orow("nama_toko") = tnama_toko.Text.Trim
        orow("alamat_toko") = talamat_toko.Text.Trim

        orow("sdatang") = 0
        orow("sbatal") = 0

        dv.EndInit()

    End Sub

    Private Sub updateview()

        dv(position)("tanggal") = ttgl.Text.Trim
        dv(position)("nama_toko") = tnama_toko.Text.Trim
        dv(position)("alamat_toko") = talamat_toko.Text.Trim

    End Sub

    Private Sub load_print()

        Dim sql1 As String = String.Format("SELECT tr_pesanbeli.nobukti, tr_pesanbeli.tanggal, ms_penjual.kode AS kd_toko,ms_penjual.kode + ' - ' + ms_penjual.nama AS nama_toko, ms_penjual.alamat AS alamat_toko, tr_pesanbeli.note, " & _
       "ms_barang.kd_barang, ms_barang.nama_barang, tr_pesanbeli2.qty, tr_pesanbeli2.satuan " & _
       "FROM tr_pesanbeli INNER JOIN " & _
       "tr_pesanbeli2 ON tr_pesanbeli.nobukti = tr_pesanbeli2.nobukti INNER JOIN " & _
       "ms_barang ON tr_pesanbeli2.kd_barang = ms_barang.kd_barang INNER JOIN ms_penjual ON tr_pesanbeli.kd_toko = ms_penjual.kode " & _
       "where tr_pesanbeli.sbatal=0 and tr_pesanbeli.sdatang=0 and tr_pesanbeli.nobukti='{0}'", tbukti.Text.Trim)

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
        Using fkar2 As New fpesan_beli3 With {.StartPosition = FormStartPosition.CenterParent, .dv = dv1, .addstat = True, .position = 0}
            fkar2.ShowDialog(Me)
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

                Dim sql As String = String.Format("delete from tr_pesanbeli2 where noid={0}", dv1(Me.BindingContext(dv1).Position)("noid").ToString)

                Dim cmd As OleDbCommand = New OleDbCommand(sql, cn, sqltrans)
                cmd.ExecuteNonQuery()

                dv1.Delete(Me.BindingContext(dv1).Position)

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

        ttgl.Focus()

    End Sub

    Private Sub ffaktur_to2_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If addstat = True Then


            ttgl.EditValue = Date.Now

            kosongkan()

        Else

            isi()

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

        If MsgBox("Yakin sudah benar.. ???", vbYesNo + vbQuestion, "Konfirmasi") = MsgBoxResult.No Then
            Return
        Else
            simpan()
        End If

    End Sub


End Class