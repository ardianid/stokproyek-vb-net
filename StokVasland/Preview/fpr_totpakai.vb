Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy

Public Class fpr_totpakai

    Private Sub tkode_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tkode.KeyDown
        If e.KeyCode = Keys.F4 Then
            bts_barang_Click(sender, Nothing)
        End If
    End Sub

    Private Sub tkode_LostFocus(sender As Object, e As System.EventArgs) Handles tkode.LostFocus
        If tkode.Text.Trim.Length = 0 Then
            tnama.Text = ""
        End If
    End Sub

    Private Sub tkode_Validated(sender As System.Object, e As System.EventArgs) Handles tkode.Validated
        If tkode.Text.Trim.Length > 0 Then

            Dim cn As OleDbConnection = Nothing
            Try

                cn = New OleDbConnection
                cn = Clsmy.open_conn

                Dim sql As String = String.Format("select kd_barang,nama_barang,satuan1,satuan2,qty1,qty2,hargabeli from ms_barang where kd_barang='{0}'", tkode.Text.Trim)
                Dim cmd As OleDbCommand = New OleDbCommand(sql, cn)
                Dim drd As OleDbDataReader = cmd.ExecuteReader

                Dim ada As Boolean = False

                If drd.Read Then
                    If Not drd("kd_barang").ToString.Equals("") Then

                        ada = True
                        tkode.Text = drd("kd_barang").ToString
                        tnama.Text = drd("nama_barang").ToString

                    End If
                End If
                drd.Close()

                If ada = False Then
                    tkode.Text = ""
                    tnama.Text = ""
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

        End If
    End Sub

    Private Sub bts_barang_Click(sender As System.Object, e As System.EventArgs) Handles bts_barang.Click

        Dim fs As New fsbarang With {.StartPosition = FormStartPosition.CenterParent, .WindowState = FormWindowState.Normal}
        fs.ShowDialog(Me)

        tkode.EditValue = fs.get_KODE

        tkode_Validated(sender, Nothing)

    End Sub

    Private Sub fpr_belibyitem_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        cblap.SelectedIndex = 0

        ttgl.EditValue = DateValue(Date.Now)
        ttgl2.EditValue = DateValue(Date.Now)

    End Sub

    Private Sub tkode_proyek_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tkode_proyek.KeyDown
        If e.KeyCode = Keys.F4 Then
            bts_proyek_Click(sender, Nothing)
        End If
    End Sub

    Private Sub tkode_proyek_Validated(sender As System.Object, e As System.EventArgs) Handles tkode_proyek.Validated

        If tkode_proyek.Text.Trim.Length > 0 Then

            Dim cn As OleDbConnection = Nothing

            ' Dim sql As String = String.Format("select ms_proyek.kd_group,ms_proyek.nama_group,ms_subproyek.kd_sub,ms_subproyek.nama_sub from ms_subproyek inner join ms_proyek on ms_subproyek.kd_group=ms_proyek.kd_group where ms_subproyek.kd_sub='{0}'", tkode_proyek.Text.Trim)
            Dim sql As String = String.Format("select * from ms_proyek where kd_group='{0}'", tkode_proyek.Text.Trim)

            Try

                cn = New OleDbConnection
                cn = Clsmy.open_conn

                Dim cmd As OleDbCommand = New OleDbCommand(sql, cn)
                Dim drd As OleDbDataReader = cmd.ExecuteReader

                Dim ada As Boolean = False

                If drd.Read Then

                    If Not drd("kd_group").ToString.Equals("") Then
                        ada = True

                        tkode_proyek.Text = drd("kd_group").ToString
                        tnama_proyek.Text = drd("nama_group").ToString
                        '  tkode_sub.Text = drd("kd_group").ToString
                        '  tnama_sub.Text = drd("nama_group").ToString

                    End If

                End If
                drd.Close()

                If ada = False Then
                    tkode_proyek.Text = ""
                    tnama_proyek.Text = ""
                    '  tkode_sub.Text = ""
                    ' tnama_sub.Text = ""
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
            ' tkode_sub.Text = ""
            'tnama_sub.Text = ""
        End If

    End Sub

    Private Sub bts_proyek_Click(sender As System.Object, e As System.EventArgs) Handles bts_proyek.Click

        Dim fs As New fsproyek With {.StartPosition = FormStartPosition.CenterParent, .WindowState = FormWindowState.Normal}
        fs.ShowDialog(Me)

        tkode_proyek.EditValue = fs.get_KODE

        tkode_proyek_Validated(sender, Nothing)

    End Sub


    Private Sub tkode_sub_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tkode_sub.KeyDown
        If e.KeyCode = Keys.F4 Then
            bts_sub_Click(sender, Nothing)
        End If
    End Sub

    Private Sub tkode_sub_Validated(sender As System.Object, e As System.EventArgs) Handles tkode_sub.Validated

        If tkode_sub.Text.Trim.Length > 0 Then

            Dim cn As OleDbConnection = Nothing

            Dim sql As String = String.Format("select ms_proyek.kd_group,ms_proyek.nama_group,ms_subproyek.kd_sub,ms_subproyek.nama_sub from ms_subproyek inner join ms_proyek on ms_subproyek.kd_group=ms_proyek.kd_group where ms_subproyek.kd_sub='{0}'", tkode_sub.Text.Trim)


            Try

                cn = New OleDbConnection
                cn = Clsmy.open_conn

                Dim cmd As OleDbCommand = New OleDbCommand(sql, cn)
                Dim drd As OleDbDataReader = cmd.ExecuteReader

                Dim ada As Boolean = False

                If drd.Read Then

                    If Not drd("kd_group").ToString.Equals("") Then
                        ada = True

                        tkode_sub.Text = drd("kd_sub").ToString
                        tnama_sub.Text = drd("nama_sub").ToString

                    End If

                End If
                drd.Close()

                If ada = False Then

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
            tnama_sub.Text = ""
        End If

    End Sub

    Private Sub bts_sub_Click(sender As System.Object, e As System.EventArgs) Handles bts_sub.Click

        Dim fs As New fsproyeksub With {.StartPosition = FormStartPosition.CenterParent, .WindowState = FormWindowState.Normal}
        fs.ShowDialog(Me)

        tkode_sub.EditValue = fs.get_KODE

        tkode_sub_Validated(sender, Nothing)

    End Sub


    Private Sub btload_Click(sender As System.Object, e As System.EventArgs) Handles btload.Click

        Dim sql As String = ""

        If cblap.SelectedIndex = 0 Then

            sql = String.Format("SELECT ms_barang.kd_barang, ms_barang.nama_barang, " & _
                "case when sum(tr_pakai2.qtykecil) >=  (ms_barang.qty1 * ms_barang.qty2)then " & _
                    "(SUM(tr_pakai2.qtykecil) - SUM(tr_pakai2.qtykecil) % (ms_barang.qty1 * ms_barang.qty2)) / (ms_barang.qty1 * ms_barang.qty2) " & _
                "else 0 end as qty1, " & _
                "case when sum(tr_pakai2.qtykecil) >=  (ms_barang.qty1 * ms_barang.qty2) then " & _
                    "(SUM(tr_pakai2.qtykecil)% (ms_barang.qty1 * ms_barang.qty2))  " & _
                "else sum(tr_pakai2.qtykecil) end as qty2,ms_barang.satuan1,ms_barang.satuan2,ms_proyek.nama_group " & _
                "FROM tr_pakai INNER JOIN tr_pakai2 ON tr_pakai.nobukti = tr_pakai2.nobukti INNER JOIN " & _
                "ms_barang ON tr_pakai2.kd_barang = ms_barang.kd_barang " & _
                "INNER JOIN ms_subproyek on tr_pakai.kd_sub=ms_subproyek.kd_sub inner join ms_proyek on ms_subproyek.kd_group=ms_proyek.kd_group " & _
                "WHERE tr_pakai.sbatal=0 and tr_pakai.tgl_pakai>='{0}' and tr_pakai.tgl_pakai<='{1}'", convert_date_to_eng(ttgl.EditValue), convert_date_to_eng(ttgl2.EditValue))

        Else

            sql = String.Format("SELECT ms_barang.kd_barang, ms_barang.nama_barang, " & _
                "case when sum(tr_pakai2.qtykecil) >=  (ms_barang.qty1 * ms_barang.qty2)then " & _
                    "(SUM(tr_pakai2.qtykecil) - SUM(tr_pakai2.qtykecil) % (ms_barang.qty1 * ms_barang.qty2)) / (ms_barang.qty1 * ms_barang.qty2) " & _
                "else 0 end as qty1, " & _
                "case when sum(tr_pakai2.qtykecil) >=  (ms_barang.qty1 * ms_barang.qty2) then " & _
                    "(SUM(tr_pakai2.qtykecil)% (ms_barang.qty1 * ms_barang.qty2))  " & _
                "else sum(tr_pakai2.qtykecil) end as qty2,ms_barang.satuan1,ms_barang.satuan2,ms_proyek.nama_group,ms_subproyek.nama_sub " & _
                "FROM tr_pakai INNER JOIN tr_pakai2 ON tr_pakai.nobukti = tr_pakai2.nobukti INNER JOIN " & _
                "ms_barang ON tr_pakai2.kd_barang = ms_barang.kd_barang " & _
                "INNER JOIN ms_subproyek on tr_pakai.kd_sub=ms_subproyek.kd_sub inner join ms_proyek on ms_subproyek.kd_group=ms_proyek.kd_group " & _
                "WHERE tr_pakai.sbatal=0 and tr_pakai.tgl_pakai>='{0}' and tr_pakai.tgl_pakai<='{1}'", convert_date_to_eng(ttgl.EditValue), convert_date_to_eng(ttgl2.EditValue))


        End If

        
        If tkode.Text.Trim.Length > 0 Then
            sql = String.Format(" {0} and ms_barang.kd_barang='{1}'", sql, tkode.Text.Trim)
        End If

        If tkode_proyek.Text.Trim.Length > 0 Then
            sql = String.Format(" {0} and ms_proyek.kd_group='{1}'", sql, tkode_proyek.Text.Trim)
        End If

        If tkode_sub.Text.Trim.Length > 0 Then
            sql = String.Format(" {0} and ms_subproyek.kd_sub='{1}'", sql, tkode_sub.Text.Trim)
        End If

        If cblap.SelectedIndex = 0 Then
            sql = String.Format(" {0} group by ms_barang.kd_barang, ms_barang.nama_barang,ms_barang.qty1,ms_barang.qty2,ms_barang.satuan1,ms_barang.satuan2,ms_proyek.nama_group", sql)
        Else
            sql = String.Format(" {0} group by ms_barang.kd_barang, ms_barang.nama_barang,ms_barang.qty1,ms_barang.qty2,ms_barang.satuan1,ms_barang.satuan2,ms_proyek.nama_group,ms_subproyek.nama_sub", sql)
        End If

        Dim periode As String = String.Format("Periode : {0} s.d {1}", ttgl.Text, ttgl2.Text)

        Using fkar2 As New fpr_totpakai2 With {.WindowState = FormWindowState.Maximized, .sql = sql, .periode = periode, .jnslap = cblap.SelectedIndex}
            fkar2.ShowDialog(Me)
        End Using

    End Sub

    Private Sub btkeluar_Click(sender As System.Object, e As System.EventArgs) Handles btkeluar.Click
        Me.Close()
    End Sub

End Class