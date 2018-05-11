Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy
Imports DevExpress.XtraReports.UI
Public Class fpakai2

    Public dv As DataView
    Public position As Integer
    Public addstat As Boolean

    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView

    Private tgl_old As String

    Private Sub kosongkan()

        tbukti.Text = "<< New >>"

        tperlu.Text = ""
        tjawab.Text = ""
        tket.Text = ""

        tkode_proyek.Text = ""
        tnama_proyek.Text = ""

        tkode_sub.Text = ""
        tnama_sub.Text = ""

        opengrid()

    End Sub

    Private Sub opengrid()

        Dim sql As String = String.Format("select tr_pakai2.noid,ms_barang.kd_barang,ms_barang.nama_barang,tr_pakai2.qty,tr_pakai2.satuan,tr_pakai2.qtykecil " & _
            "from tr_pakai2 inner join ms_barang on tr_pakai2.kd_barang=ms_barang.kd_barang where tr_pakai2.nobukti='{0}'", tbukti.Text.Trim)


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

        tbukti.Text = dv(position)("nobukti").ToString
        ttgl.EditValue = DateValue(dv(position)("tanggal").ToString)
        ttgl2.EditValue = DateValue(dv(position)("tgl_pakai").ToString)
        tperlu.Text = dv(position)("keperluan").ToString
        tjawab.Text = dv(position)("nama_pengambil").ToString
        tket.Text = dv(position)("note").ToString

        tkode_proyek.Text = dv(position)("kd_sub").ToString
        tnama_proyek.Text = dv(position)("nama_sub").ToString

        tkode_sub.Text = dv(position)("kd_group").ToString
        tnama_sub.Text = dv(position)("nama_group").ToString

        tgl_old = ttgl2.EditValue

        opengrid()

    End Sub

    Private Function cekbukti(ByVal cn As OleDbConnection, ByVal sqltrans As OleDbTransaction) As String

        Dim sql As String = ""

        Dim nobuktiawal As String = "PK."

        Dim tahun As String = Year(ttgl.EditValue)
        tahun = Microsoft.VisualBasic.Right(tahun, 2)
        Dim bulan As String = Month(ttgl.EditValue)

        If bulan.Length = 1 Then
            bulan = "0" & bulan
        End If



        sql = String.Format("select max(nobukti) from tr_pakai where  nobukti like '{0}%'", String.Format("{0}{1}{2}", nobuktiawal, tahun, bulan))


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
                Dim sqlin_faktur As String = String.Format("insert into tr_pakai(nobukti,tanggal,tgl_pakai,keperluan,nama_pengambil,note,kd_sub) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", _
                                                           tbukti.Text.Trim, convert_date_to_eng(ttgl.EditValue), convert_date_to_eng(ttgl2.EditValue), tperlu.Text.Trim, tjawab.Text.Trim, tket.Text.Trim, tkode_proyek.Text.Trim)


                cmd = New OleDbCommand(sqlin_faktur, cn, sqltrans)
                cmd.ExecuteNonQuery()

                Clsmy.InsertToLog(cn, "btpakai", 1, 0, 0, 0, tbukti.Text.Trim, ttgl.EditValue, sqltrans)



            Else

                '1. update faktur
                Dim sqlup_faktur As String = String.Format("update tr_pakai set tanggal='{0}',tgl_pakai='{1}',keperluan='{2}',nama_pengambil='{3}',note='{4}',kd_sub='{5}' where nobukti='{6}'", _
                                                          convert_date_to_eng(ttgl.EditValue), convert_date_to_eng(ttgl2.EditValue), tperlu.Text.Trim, tjawab.Text.Trim, tket.Text.Trim, tkode_proyek.Text.Trim, tbukti.Text.Trim)

                cmd = New OleDbCommand(sqlup_faktur, cn, sqltrans)
                cmd.ExecuteNonQuery()

                Clsmy.InsertToLog(cn, "btpakai", 0, 1, 0, 0, tbukti.Text.Trim, ttgl.EditValue, sqltrans)

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

            cek_tglhist(cn, sqltrans, dv1(i)("kd_barang").ToString)

            If dv1(i)("noid") <> 0 Then

                ''3. insert to hist stok
                Clsmy.Insert_HistBarang(cn, sqltrans, tbukti.Text.Trim, tgl_old, dv1(i)("kd_barang").ToString, dv1(i)("qtykecil").ToString, 0, "Pemakaian (Edit)")

                ''3. insert to hist stok
                Clsmy.Insert_HistBarang(cn, sqltrans, tbukti.Text.Trim, ttgl2.EditValue, dv1(i)("kd_barang").ToString, 0, dv1(i)("qtykecil").ToString, "Pemakaian (Edit)")

            End If

            If dv1(i)("noid") = 0 Then

                Dim sqlins As String = String.Format("insert into tr_pakai2 (nobukti,kd_barang,satuan,qty,qtykecil) values('{0}','{1}','{2}',{3},{4})", _
                                                     tbukti.Text.Trim, dv1(i)("kd_barang").ToString, dv1(i)("satuan").ToString, dv1(i)("qty").ToString, dv1(i)("qtykecil").ToString)

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
                Clsmy.Insert_HistBarang(cn, sqltrans, tbukti.Text.Trim, ttgl2.EditValue, dv1(i)("kd_barang").ToString, 0, dv1(i)("qtykecil").ToString, "Pemakaian")

            End If

        Next

        Return hasil

    End Function

    Private Sub cek_tglhist(ByVal cn As OleDbConnection, ByVal sqltrans As OleDbTransaction, ByVal kdbarang As String)

        Dim sql As String = String.Format("select tgl_keluar from ms_barang where kd_barang='{0}'", kdbarang)
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
            sqlup = String.Format("update ms_barang set tgl_keluar='{0}' where kd_barang='{1}'", convert_date_to_eng(ttgl.EditValue), kdbarang)

            Using cmdup As OleDbCommand = New OleDbCommand(sqlup, cn, sqltrans)
                cmdup.ExecuteNonQuery()
            End Using

        Else

            If DateValue(ttgl.EditValue) > DateValue(tglhasil) Then
                sqlup = String.Format("update ms_barang set tgl_keluar='{0}' where kd_barang='{1}'", convert_date_to_eng(ttgl.EditValue), kdbarang)

                Using cmdup As OleDbCommand = New OleDbCommand(sqlup, cn, sqltrans)
                    cmdup.ExecuteNonQuery()
                End Using

            End If

        End If

    End Sub

    Private Sub insertview()

        Dim orow As DataRowView = dv.AddNew
        orow("nobukti") = tbukti.Text.Trim
        orow("tanggal") = ttgl.Text.Trim
        orow("tgl_pakai") = ttgl2.Text.Trim
        orow("keperluan") = tperlu.Text.Trim
        orow("nama_pengambil") = tjawab.Text.Trim

        orow("kd_group") = tkode_sub.Text.Trim
        orow("nama_group") = tnama_sub.Text.Trim

        orow("kd_sub") = tkode_proyek.Text.Trim
        orow("nama_sub") = tnama_proyek.Text.Trim

        orow("sbatal") = 0

        dv.EndInit()

    End Sub

    Private Sub updateview()

        dv(position)("nobukti") = tbukti.Text.Trim
        dv(position)("tanggal") = ttgl.Text.Trim
        dv(position)("tgl_pakai") = ttgl2.Text.Trim
        dv(position)("keperluan") = tperlu.Text.Trim
        dv(position)("nama_pengambil") = tjawab.Text.Trim

        dv(position)("kd_group") = tkode_sub.Text.Trim
        dv(position)("nama_group") = tnama_sub.Text.Trim

        dv(position)("kd_sub") = tkode_proyek.Text.Trim
        dv(position)("nama_sub") = tnama_proyek.Text.Trim

    End Sub

    Private Sub load_print()

        Dim sql1 As String = String.Format("SELECT tr_pakai.nobukti, tr_pakai.tanggal, tr_pakai.tgl_pakai, tr_pakai.keperluan, tr_pakai.nama_pengambil, tr_pakai.note, tr_pakai2.kd_barang, ms_barang.nama_barang,tr_pakai2.satuan, tr_pakai2.qty,ms_proyek.nama_group,ms_subproyek.nama_sub " & _
            "FROM  tr_pakai INNER JOIN tr_pakai2 ON tr_pakai.nobukti = tr_pakai2.nobukti INNER JOIN ms_barang ON tr_pakai2.kd_barang = ms_barang.kd_barang  inner join ms_subproyek on tr_pakai.kd_sub=ms_subproyek.kd_sub inner join ms_proyek on ms_subproyek.kd_group=ms_proyek.kd_group " & _
            "WHERE tr_pakai.sbatal=0 and tr_pakai.nobukti='{0}'", tbukti.Text.Trim)

        Dim cn As OleDbConnection = Nothing
        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim ds As DataSet = New ds_buktiambil
            ds = Clsmy.GetDataSet(sql1, cn)

            dsinvoice_ku = New DataSet
            dsinvoice_ku = ds

            Dim ops As New System.Drawing.Printing.PrinterSettings

            Dim rinvoice As New r_buktiambil() With {.DataSource = ds.Tables(0)}
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


    Private Sub btadd_Click(sender As System.Object, e As System.EventArgs) Handles btadd.Click
        Using fkar2 As New fpakai3 With {.StartPosition = FormStartPosition.CenterParent, .dv = dv1, .addstat = True, .position = 0}
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

            Dim cn As OleDbConnection = Nothing

            Try

                cn = New OleDbConnection
                cn = Clsmy.open_conn

                Dim sqltrans As OleDbTransaction = cn.BeginTransaction

                Dim qtykecil As Integer = Integer.Parse(dv1(Me.BindingContext(dv1).Position)("qtykecil").ToString)
                Dim kdbar As String = dv1(Me.BindingContext(dv1).Position)("kd_barang").ToString

                If Integer.Parse(dv1(Me.BindingContext(dv1).Position)("noid").ToString) <> 0 Then

                    '2. update barang
                    Dim hasilplusmin As String = PlusMin_Barang(cn, sqltrans, qtykecil, kdbar, True)
                    If Not hasilplusmin.Equals("ok") Then
                        MsgBox(hasilplusmin, vbOKOnly + vbExclamation, "Informasi")
                        sqltrans.Rollback()
                        GoTo langsung
                    End If

                    If addstat = False Then

                        If DateValue(tgl_old) <> DateValue(ttgl.EditValue) Then
                            Clsmy.Insert_HistBarang(cn, sqltrans, tbukti.Text.Trim, tgl_old, kdbar, qtykecil, 0, "Pemakaian (Edit)")
                            Clsmy.Insert_HistBarang(cn, sqltrans, tbukti.Text.Trim, ttgl2.EditValue, kdbar, 0, qtykecil, "Pemakaian (Edit)")
                        End If

                    End If

                    '3. insert to hist stok
                    Clsmy.Insert_HistBarang(cn, sqltrans, tbukti.Text.Trim, ttgl2.EditValue, kdbar, qtykecil, 0, "Pemakaian (Edit)")

                End If
                

                Dim sql As String = String.Format("delete from tr_pakai2 where noid={0}", dv1(Me.BindingContext(dv1).Position)("noid").ToString)

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
            ttgl2.EditValue = Date.Now

            kosongkan()

        Else

            isi()

        End If

    End Sub

    Private Sub btsimpan_Click(sender As System.Object, e As System.EventArgs) Handles btsimpan.Click

        If tperlu.Text.Trim.Length = 0 Then
            MsgBox("Keperluan harus diisi...", vbOKOnly + vbInformation, "Informasi")
            tperlu.Focus()
            Return
        End If

        If tjawab.Text.Trim.Length = 0 Then
            MsgBox("Penanggung jawab harus diisi...", vbOKOnly + vbInformation, "Informasi")
            tjawab.Focus()
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

    Private Sub tkode_proyek_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tkode_proyek.KeyDown
        If e.KeyCode = Keys.F4 Then
            bts_proyek_Click(sender, Nothing)
        End If
    End Sub

    Private Sub tkode_proyek_LostFocus(sender As Object, e As System.EventArgs) Handles tkode_proyek.LostFocus
        If tnama_proyek.Text.Trim.Length = 0 Then
            tkode_sub.Text = ""
            tnama_sub.Text = ""
        End If
    End Sub

    Private Sub tkode_proyek_Validated(sender As System.Object, e As System.EventArgs) Handles tkode_proyek.Validated

        If tkode_proyek.Text.Trim.Length > 0 Then

            Dim cn As OleDbConnection = Nothing

            Dim sql As String = String.Format("select ms_proyek.kd_group,ms_proyek.nama_group,ms_subproyek.kd_sub,ms_subproyek.nama_sub from ms_subproyek inner join ms_proyek on ms_subproyek.kd_group=ms_proyek.kd_group where ms_subproyek.kd_sub='{0}'", tkode_proyek.Text.Trim)

            Try

                cn = New OleDbConnection
                cn = Clsmy.open_conn

                Dim cmd As OleDbCommand = New OleDbCommand(sql, cn)
                Dim drd As OleDbDataReader = cmd.ExecuteReader

                Dim ada As Boolean = False

                If drd.Read Then

                    If Not drd("kd_group").ToString.Equals("") Then
                        ada = True

                        tkode_proyek.Text = drd("kd_sub").ToString
                        tnama_proyek.Text = drd("nama_sub").ToString
                        tkode_sub.Text = drd("kd_group").ToString
                        tnama_sub.Text = drd("nama_group").ToString

                    End If

                End If
                drd.Close()

                If ada = False Then
                    tkode_proyek.Text = ""
                    tnama_proyek.Text = ""
                    tkode_sub.Text = ""
                    tnama_sub.Text = ""
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

        Else
            tnama_proyek.Text = ""
            tkode_sub.Text = ""
            tnama_sub.Text = ""
        End If

    End Sub

    Private Sub bts_proyek_Click(sender As System.Object, e As System.EventArgs) Handles bts_proyek.Click

        Dim fs As New fsproyeksub With {.StartPosition = FormStartPosition.CenterParent, .WindowState = FormWindowState.Normal}
        fs.ShowDialog(Me)

        tkode_proyek.EditValue = fs.get_KODE

        tkode_proyek_Validated(sender, Nothing)

    End Sub

End Class