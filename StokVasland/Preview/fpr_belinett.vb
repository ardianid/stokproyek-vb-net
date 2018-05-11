Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy

Public Class fpr_belinett

    Private Sub bts_toko_Click(sender As System.Object, e As System.EventArgs) Handles bts_toko.Click

        Dim fs As New fsoutlet With {.StartPosition = FormStartPosition.CenterParent, .WindowState = FormWindowState.Normal}
        fs.ShowDialog(Me)

        tkd_toko.EditValue = fs.get_KODE
        tnama_toko.EditValue = fs.get_NAMA

        'tkd_toko_EditValueChanged(sender, Nothing)

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

                    Else
                        tkd_toko.EditValue = ""
                        tnama_toko.EditValue = ""


                    End If
                Else
                    tkd_toko.EditValue = ""
                    tnama_toko.EditValue = ""

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
        End If
    End Sub

    Private Sub fpr_belibyitem_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        ttgl.EditValue = DateValue(Date.Now)
        ttgl2.EditValue = DateValue(Date.Now)

    End Sub

    Private Sub btload_Click(sender As System.Object, e As System.EventArgs) Handles btload.Click

        Dim sql As String = String.Format("SELECT tr_beli.nobukti, tr_beli.no_nota, tr_beli.tanggal_beli, ms_penjual.kode AS kd_toko, ms_penjual.nama AS nama_toko, tr_beli.cr_bayar, tr_beli.total, tr_beli.disc_rp, tr_beli.total_nett " & _
        "FROM tr_beli INNER JOIN ms_penjual ON tr_beli.kd_penjual = ms_penjual.kode " & _
        "WHERE tr_beli.sbatal=0 and tr_beli.tanggal_beli>='{0}' and tr_beli.tanggal_beli<='{1}'", convert_date_to_eng(ttgl.EditValue), convert_date_to_eng(ttgl2.EditValue))

        If tkd_toko.Text.Trim.Length > 0 Then
            sql = String.Format(" {0} and ms_penjual.kode='{1}'", sql, tkd_toko.Text.Trim)
        End If

        Dim periode As String = String.Format("Periode : {0} s.d {1}", ttgl.Text, ttgl2.Text)

        Using fkar2 As New fpr_belinett2 With {.WindowState = FormWindowState.Maximized, .sql = sql, .periode = periode}
            fkar2.ShowDialog(Me)
        End Using

    End Sub

    Private Sub btkeluar_Click(sender As System.Object, e As System.EventArgs) Handles btkeluar.Click
        Me.Close()
    End Sub


End Class