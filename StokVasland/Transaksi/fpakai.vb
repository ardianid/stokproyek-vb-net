Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy

Imports DevExpress.XtraReports.UI

Public Class fpakai

    Private bs1 As BindingSource
    Private ds As DataSet
    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView

    Private Sub opendata()

        Dim tglsebelum As String = DateAdd(DateInterval.Month, -2, Date.Now)

        Dim sql As String = String.Format("select tr_pakai.nobukti,tr_pakai.tanggal,tr_pakai.tgl_pakai,tr_pakai.keperluan,tr_pakai.nama_pengambil, " & _
        "tr_pakai.note, tr_pakai.sbatal, ms_proyek.kd_group, ms_proyek.nama_group, ms_subproyek.kd_sub, ms_subproyek.nama_sub " & _
        "from tr_pakai inner join ms_subproyek on tr_pakai.kd_sub=ms_subproyek.kd_sub " & _
        "inner join ms_proyek on ms_subproyek.kd_group=ms_proyek.kd_group where tr_pakai.tanggal>='{0}'  order by tr_pakai.tanggal,tr_pakai.nobukti ", convert_date_to_eng(tglsebelum))

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

        sql = "select tr_pakai.nobukti,tr_pakai.tanggal,tr_pakai.tgl_pakai,tr_pakai.keperluan,tr_pakai.nama_pengambil, " & _
        "tr_pakai.note, tr_pakai.sbatal, ms_proyek.kd_group, ms_proyek.nama_group, ms_subproyek.kd_sub, ms_subproyek.nama_sub " & _
        "from tr_pakai inner join ms_subproyek on tr_pakai.kd_sub=ms_subproyek.kd_sub " & _
        "inner join ms_proyek on ms_subproyek.kd_group=ms_proyek.kd_group"

        Select Case tcbofind.SelectedIndex
            Case 0 ' kode
                sql = String.Format("{0} where tr_pakai.nobukti='{1}'", sql, tfind.Text.Trim)
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

                sql = String.Format("{0} where tr_pakai.tgl_pakai='{1}'", sql, convert_date_to_eng(tfind.Text.Trim))
            Case 2
                sql = String.Format("{0} where tr_pakai.keperluan like '%{1}%'", sql, tfind.Text.Trim)
            Case 3
                sql = String.Format("{0} where tr_pakai.nama_pengambil like '%{1}%'", sql, tfind.Text.Trim)
            Case 4
                sql = String.Format("{0} where tr_pakai.nobukti in (select nobukti from tr_pakai2 inner join ms_barang on tr_pakai2.kd_barang=ms_barang.kd_barang where ms_barang.nama_barang like '%{1}%')", sql, tfind.Text.Trim)
            Case 5
                sql = String.Format("{0} where ms_proyek.nama_group like '%{1}%'", sql, tfind.Text.Trim)
            Case 6
                sql = String.Format("{0} where ms_subproyek.nama_sub like '%{1}%'", sql, tfind.Text.Trim)
        End Select

        If Not IsDate(tfind.Text.Trim) Then

            Dim tglsebelum As String = DateAdd(DateInterval.Year, -5, Date.Now)

            sql = String.Format("{0} and tr_pakai.tanggal>='{1}'", sql, convert_date_to_eng(tglsebelum))

        End If

        sql = String.Format(" {0} order by tr_pakai.tanggal,tr_pakai.nobukti", sql)

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

        Dim sql As String = String.Format("update tr_pakai set sbatal=1,alasan_batal='{0}' where nobukti='{1}'", alasan_batal.ToUpper, dv1(Me.BindingContext(bs1).Position)("nobukti").ToString)

        Dim cn As OleDbConnection = Nothing
        Dim comd As OleDbCommand = Nothing

        Try

            open_wait()

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim sqltrans As OleDbTransaction = cn.BeginTransaction

            comd = New OleDbCommand(sql, cn, sqltrans)
            comd.ExecuteNonQuery()

            Clsmy.InsertToLog(cn, "btpakai", 0, 0, 1, 0, dv1(Me.BindingContext(bs1).Position)("nobukti").ToString, dv1(Me.BindingContext(bs1).Position)("tanggal").ToString, sqltrans)

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
        Dim tanggal As String = dv1(bs1.Position)("tgl_pakai").ToString

        Dim sql As String = String.Format("select * from tr_pakai2 where nobukti='{0}'", dv1(bs1.Position)("nobukti").ToString)
        Dim cmd As OleDbCommand = New OleDbCommand(sql, cn, sqltrans)
        Dim drd As OleDbDataReader = cmd.ExecuteReader

        If drd.HasRows Then
            While drd.Read

                Dim kdbarang As String = drd("kd_barang").ToString
                Dim qtykecil As String = drd("qtykecil").ToString

                If IsNumeric(drd("noid").ToString) Then

                    '2. update barang
                    Dim hasilplusmin As String = PlusMin_Barang(cn, sqltrans, qtykecil, kdbarang, True)
                    If Not hasilplusmin.Equals("ok") Then
                        MsgBox(hasilplusmin, vbOKOnly + vbExclamation, "Informasi")
                        hasil = False
                        close_wait()
                        Exit While

                    End If

                    ''3. insert to hist stok
                    Clsmy.Insert_HistBarang(cn, sqltrans, nobukti, tanggal, kdbarang, qtykecil, 0, "Pemakaian (Batal)")

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

            Dim sql As String = String.Format("select sbatal from tr_pakai where nobukti='{0}'", nobukti)
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
        Using fkar2 As New fpakai2 With {.StartPosition = FormStartPosition.CenterParent, .dv = dv1, .addstat = True, .position = 0}
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

        Using fkar2 As New fpakai2 With {.StartPosition = FormStartPosition.CenterParent, .dv = dv1, .addstat = False, .position = bs1.Position}
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

        Using fkar2 As New fpakai2 With {.StartPosition = FormStartPosition.CenterParent, .dv = dv1, .addstat = False, .position = bs1.Position}
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

        Dim sql1 As String = String.Format("SELECT tr_pakai.nobukti, tr_pakai.tanggal, tr_pakai.tgl_pakai, tr_pakai.keperluan, tr_pakai.nama_pengambil, tr_pakai.note, tr_pakai2.kd_barang, ms_barang.nama_barang,tr_pakai2.satuan, tr_pakai2.qty,ms_proyek.nama_group,ms_subproyek.nama_sub " & _
            "FROM  tr_pakai INNER JOIN tr_pakai2 ON tr_pakai.nobukti = tr_pakai2.nobukti INNER JOIN ms_barang ON tr_pakai2.kd_barang = ms_barang.kd_barang  inner join ms_subproyek on tr_pakai.kd_sub=ms_subproyek.kd_sub inner join ms_proyek on ms_subproyek.kd_group=ms_proyek.kd_group " & _
            "WHERE tr_pakai.sbatal=0 and tr_pakai.nobukti='{0}'", nobukti)

        Using fkar2 As New fpr_buktiambil With {.WindowState = FormWindowState.Maximized, .sql1 = sql1}
            fkar2.ShowDialog(Me)
        End Using

    End Sub


    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles tsprint2.Click

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

        Dim sql1 As String = String.Format("SELECT tr_pakai.nobukti, tr_pakai.tanggal, tr_pakai.tgl_pakai, tr_pakai.keperluan, tr_pakai.nama_pengambil, tr_pakai.note, tr_pakai2.kd_barang, ms_barang.nama_barang,tr_pakai2.satuan, tr_pakai2.qty,ms_proyek.nama_group,ms_subproyek.nama_sub " & _
            "FROM  tr_pakai INNER JOIN tr_pakai2 ON tr_pakai.nobukti = tr_pakai2.nobukti INNER JOIN ms_barang ON tr_pakai2.kd_barang = ms_barang.kd_barang  inner join ms_subproyek on tr_pakai.kd_sub=ms_subproyek.kd_sub inner join ms_proyek on ms_subproyek.kd_group=ms_proyek.kd_group " & _
            "WHERE tr_pakai.sbatal=0 and tr_pakai.nobukti='{0}'", nobukti)

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
End Class