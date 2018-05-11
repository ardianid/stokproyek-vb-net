Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy

Public Class fbarang2

    Public dv As DataView
    Public position As Integer
    Public addstat As Boolean

    Dim qty1old As Integer = 0
    Dim qty2old As Integer = 0

    Private Sub kosongkan()
        tkode.Text = ""
        tnama.Text = ""

        tkelompok.SelectedIndex = 0
        cbeli.Checked = True

        tqty1.EditValue = 0
        tqty2.EditValue = 0

        tsat1.EditValue = ""
        tsat2.EditValue = ""

        cjual.Checked = True
        cbeli.Checked = True

        thargajual.EditValue = 0
        thargabeli.EditValue = 0

        tberat1.EditValue = 0.0
        tberat2.EditValue = 0.0

    End Sub

    Private Sub isi()

        tkode.EditValue = dv(position)("kd_barang").ToString
        tnama.EditValue = dv(position)("nama_barang").ToString

        tkelompok.Text = dv(position)("kelompok").ToString

        tqty1.EditValue = dv(position)("qty1").ToString
        tqty2.EditValue = dv(position)("qty2").ToString

        qty1old = tqty1.EditValue
        qty2old = tqty2.EditValue

        tsat1.EditValue = dv(position)("satuan1").ToString
        tsat2.EditValue = dv(position)("satuan2").ToString

        If Decimal.Parse(dv(position)("berat1").ToString) = 0 Then
            tberat1.EditValue = 0.0
        Else
            tberat1.EditValue = dv(position)("berat1").ToString
        End If

        If Decimal.Parse(dv(position)("berat2").ToString) = 0 Then
            tberat2.EditValue = 0.0
        Else
            tberat2.EditValue = dv(position)("berat2").ToString
        End If

        Dim sjual, sbeli As String
        sjual = dv(position)("sjual").ToString
        sbeli = dv(position)("sbeli").ToString

        If sjual.Equals("1") Then
            cjual.Checked = True
        Else
            cjual.Checked = False
        End If


        If sbeli.Equals("1") Then
            cbeli.Checked = True
        Else
            cbeli.Checked = False
        End If

        Dim hargabeli, hargajual As String
        hargabeli = dv(position)("hargabeli").ToString
        hargajual = dv(position)("hargajual").ToString
       

        If hargabeli.Equals("") Then
            thargabeli.EditValue = 0
        Else
            thargabeli.EditValue = hargabeli
        End If

        If hargajual.Equals("") Then
            thargajual.EditValue = 0
        Else
            thargajual.EditValue = hargajual
        End If

    End Sub

    Private Sub isi_kelompok()

        Dim cn As OleDbConnection = Nothing

        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim sql As String = "select nama_kelompok from ms_kelompok"
            Dim cmd As OleDbCommand = New OleDbCommand(sql, cn)
            Dim drd As OleDbDataReader = cmd.ExecuteReader

            tkelompok.Properties.Items.Clear()

            If drd.HasRows Then
                While drd.Read
                    tkelompok.Properties.Items.Add(drd(0).ToString)
                End While
            End If
            drd.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
        End Try

    End Sub

    Private Sub hitung_berat23()

        Dim berat1 As Decimal = tberat1.EditValue

        If berat1 = 0 Then
            tberat2.EditValue = 0.0
            Return
        End If

        Dim qty2 As Double = tqty2.EditValue

        If qty2 = 0 Then
            tberat2.EditValue = 0
            Return
        End If


        Dim berat2 As Decimal = 0.0
        
        berat2 = berat1 / qty2
        tberat2.EditValue = berat2

    End Sub

    Private Function cek_inout() As Boolean

        Dim hasil As Boolean = False

        Dim sql As String = String.Format("select count(nobukti) as jml from hbarang_gudang where kd_barang='{0}'", tkode.Text.Trim)

        Dim cn As OleDbConnection = Nothing
        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim cmd As OleDbCommand = New OleDbCommand(sql, cn)
            Dim drd As OleDbDataReader = cmd.ExecuteReader

            If drd.Read Then
                If IsNumeric(drd(0).ToString) Then
                    If Integer.Parse(drd(0).ToString) > 0 Then
                        hasil = True
                    End If
                End If
            End If
            drd.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
        End Try


        Return hasil
    End Function

    Private Function cek_pemesanan() As Boolean

        Dim hasil As Boolean = False

        Dim sql As String = String.Format("select COUNT(nobukti) as jml from tr_pesanbeli2 where kd_barang='{0}'", tkode.Text.Trim)

        Dim cn As OleDbConnection = Nothing
        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim cmd As OleDbCommand = New OleDbCommand(sql, cn)
            Dim drd As OleDbDataReader = cmd.ExecuteReader

            If drd.Read Then
                If IsNumeric(drd(0).ToString) Then
                    If Integer.Parse(drd(0).ToString) > 0 Then
                        hasil = True
                    End If
                End If
            End If
            drd.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
        End Try


        Return hasil
    End Function

    Private Sub simpan()

        If addstat = False Then
            If cek_inout() = True Then

                If qty1old <> tqty1.EditValue Then
                    MsgBox("Qty1 tidak dapat dirubah karna sudah ada transaksi sebelumnya...", vbOKOnly + vbInformation, "Informasi")
                    tqty1.Focus()
                    Return
                End If

                If qty2old <> tqty2.EditValue Then
                    MsgBox("Qty2 tidak dapat dirubah karna sudah ada transaksi sebelumnya...", vbOKOnly + vbInformation, "Informasi")
                    tqty2.Focus()
                    Return
                End If

            End If
        End If

        If addstat = False Then

            If cek_pemesanan() = True Then

                If qty1old <> tqty1.EditValue Then
                    MsgBox("Qty1 tidak dapat dirubah karna sudah ada transaksi pemesanan sebelumnya...", vbOKOnly + vbInformation, "Informasi")
                    tqty1.Focus()
                    Return
                End If

                If qty2old <> tqty2.EditValue Then
                    MsgBox("Qty2 tidak dapat dirubah karna sudah ada transaksi pemesanan sebelumnya...", vbOKOnly + vbInformation, "Informasi")
                    tqty2.Focus()
                    Return
                End If

            End If

        End If

        Dim cn As OleDbConnection = Nothing

        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim kjual, kbeli As Integer

            If cjual.Checked = True Then
                kjual = 1
            Else
                kjual = 0
            End If

            If cbeli.Checked = True Then
                kbeli = 1
            Else
                kbeli = 0
            End If

            
            Dim sqlc As String = String.Format("select kd_barang from ms_barang where kd_barang='{0}'", tkode.Text.Trim)
            Dim sql_insert As String = String.Format("insert into ms_barang (kd_barang,nama_barang,kelompok,satuan1,satuan2,qty1,qty2,sbeli,sjual,hargabeli,hargajual,berat1,berat2) values('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},{8},{9},{10},{11},{12})", tkode.Text.Trim, tnama.EditValue, _
                                                     tkelompok.Text.Trim, tsat1.Text.Trim, tsat2.Text.Trim, Replace(tqty1.EditValue, ",", "."), Replace(tqty2.EditValue, ",", "."), kbeli, kjual, Replace(thargabeli.EditValue, ",", "."), Replace(thargajual.EditValue, ",", "."), Replace(tberat1.EditValue, ",", "."), Replace(tberat2.EditValue, ",", "."))

            Dim sql_update As String = String.Format("update ms_barang set nama_barang='{0}',kelompok='{1}',satuan1='{2}',satuan2='{3}',qty1={4},qty2={5},sbeli={6},sjual={7},hargabeli={8},hargajual={9},berat1={10},berat2={11} where kd_barang='{12}'", tnama.EditValue, _
                                                     tkelompok.Text.Trim, tsat1.Text.Trim, tsat2.Text.Trim, Replace(tqty1.EditValue, ",", "."), Replace(tqty2.EditValue, ",", "."), kbeli, kjual, Replace(thargabeli.EditValue, ",", "."), Replace(thargajual.EditValue, ",", "."), Replace(tberat1.EditValue, ",", "."), Replace(tberat2.EditValue, ",", "."), tkode.Text.Trim)


            Dim sqltrans As OleDbTransaction = cn.BeginTransaction

            Dim comd As OleDbCommand

            If addstat = True Then

                Dim cmdc As OleDbCommand = New OleDbCommand(sqlc, cn, sqltrans)
                Dim dread As OleDbDataReader = cmdc.ExecuteReader

                If dread.HasRows Then
                    If dread.Read Then

                        Dim kdka As String = dread(0).ToString

                        If kdka.Trim.Length = 0 Then
                            comd = New OleDbCommand(sql_insert, cn, sqltrans)
                            comd.ExecuteNonQuery()

                            Clsmy.InsertToLog(cn, "btbarang", 1, 0, 0, 0, tkode.Text.Trim, tnama.Text.Trim, sqltrans)

                            insertview()
                        Else

                            MsgBox("Kode/Nama sudah ada ...", vbOKOnly + vbExclamation, "Informasi")
                            tkode.Focus()
                            Return
                        End If
                    Else
                        comd = New OleDbCommand(sql_insert, cn, sqltrans)
                        comd.ExecuteNonQuery()

                        Clsmy.InsertToLog(cn, "btbarang", 1, 0, 0, 0, tkode.Text.Trim, tnama.Text.Trim, sqltrans)

                        insertview()
                    End If
                Else
                    comd = New OleDbCommand(sql_insert, cn, sqltrans)
                    comd.ExecuteNonQuery()

                    Clsmy.InsertToLog(cn, "btbarang", 1, 0, 0, 0, tkode.Text.Trim, tnama.Text.Trim, sqltrans)

                    insertview()
                End If

                dread.Close()


            Else

                ' jika rubah

                comd = New OleDbCommand(sql_update, cn, sqltrans)
                comd.ExecuteNonQuery()

                Clsmy.InsertToLog(cn, "btbarang", 0, 1, 0, 0, tkode.Text.Trim, tnama.Text.Trim, sqltrans)

                updateview()

            End If

            '-------------------------

            sqltrans.Commit()
            MsgBox("Data telah disimpan...", vbOKOnly + vbInformation, "Informasi")

            If addstat = True Then
                kosongkan()
                tkode.Focus()
            Else
                Me.Close()
            End If


        Catch ex As Exception
            close_wait()
            MsgBox(ex.ToString)
        Finally

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
        End Try


    End Sub

    Private Sub updateview()

        dv(position)("kd_barang") = tkode.Text.Trim
        dv(position)("nama_barang") = tnama.EditValue
        dv(position)("kelompok") = tkelompok.EditValue

        dv(position)("qty1") = tqty1.EditValue
        dv(position)("qty2") = tqty2.EditValue

        dv(position)("satuan1") = tsat1.Text.Trim
        dv(position)("satuan2") = tsat2.Text.Trim

        dv(position)("berat1") = tberat1.EditValue
        dv(position)("berat2") = tberat2.EditValue

        If cjual.Checked = True Then
            dv(position)("sjual") = 1
        Else
            dv(position)("sjual") = 0
        End If

        If cbeli.Checked = True Then
            dv(position)("sbeli") = 1
        Else
            dv(position)("sbeli") = 0
        End If

        dv(position)("hargabeli") = thargabeli.EditValue
        dv(position)("hargajual") = thargajual.EditValue

    End Sub

    Private Sub insertview()

        Dim orow As DataRowView = dv.AddNew
        orow("kd_barang") = tkode.Text.Trim
        orow("nama_barang") = tnama.EditValue
        orow("kelompok") = tkelompok.EditValue

        orow("qty1") = tqty1.EditValue
        orow("qty2") = tqty2.EditValue

        orow("satuan1") = tsat1.Text.Trim
        orow("satuan2") = tsat2.Text.Trim

        orow("berat1") = tberat1.EditValue
        orow("berat2") = tberat2.EditValue

        If cjual.Checked = True Then
            orow("sjual") = 1
        Else
            orow("sjual") = 0
        End If

        If cbeli.Checked = True Then
            orow("sbeli") = 1
        Else
            orow("sbeli") = 0
        End If

        orow("hargabeli") = thargabeli.EditValue
        orow("hargajual") = thargajual.EditValue


        dv.EndInit()

    End Sub

    Private Sub btsimpan_Click(sender As System.Object, e As System.EventArgs) Handles btsimpan.Click


        If tkode.Text.Trim.Length = 0 Then
            MsgBox("Kode tidak boleh kosong...", vbOKOnly + vbExclamation, "Informasi")
            tkode.Focus()
            Return
        End If

        If tnama.Text.Trim.Length = 0 Then
            MsgBox("Nama barang tidak boleh kosong...", vbOKOnly + vbExclamation, "Informasi")
            tnama.Focus()
            Return
        End If

        If tqty1.EditValue = 0 Or tqty2.EditValue = 0 Then
            MsgBox("Qty min 1 !!!", vbOKOnly + vbInformation, "Informasi")
            tqty1.Focus()
        End If

        simpan()

    End Sub

    Private Sub btclose_Click(sender As System.Object, e As System.EventArgs) Handles btclose.Click
        Me.Close()
    End Sub

    Private Sub fkab2_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If addstat = True Then
            tkode.Focus()
        Else
            tnama.Focus()
        End If
    End Sub

    Private Sub fkab2_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        isi_kelompok()
        tkelompok.SelectedIndex = 0
        cbeli.Checked = True

        If addstat = True Then

            tkode.Enabled = True
            kosongkan()

        Else
            tkode.Enabled = False
            isi()

        End If

    End Sub

    Private Sub cjual_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cjual.CheckedChanged
        If cjual.Checked = True Then
            cjual.Text = "Ya"
            thargajual.Enabled = True
        Else
            cjual.Text = "Tidak"
            thargajual.Enabled = False
            thargajual.EditValue = 0
        End If
    End Sub

    Private Sub cbeli_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbeli.CheckedChanged
        If cbeli.Checked = True Then
            cbeli.Text = "Ya"
            thargabeli.Enabled = True
        Else
            cbeli.Text = "Tidak"
            thargabeli.Enabled = False
            thargabeli.EditValue = 0
        End If
    End Sub

    Private Sub tberat1_Validated(sender As System.Object, e As System.EventArgs) Handles tberat1.Validated
        hitung_berat23()
    End Sub

    Private Sub tqty2_Validated(sender As System.Object, e As System.EventArgs) Handles tqty2.Validated
        If tqty1.EditValue > 0 And tberat1.EditValue > 0 Then
            hitung_berat23()
        End If
    End Sub

End Class