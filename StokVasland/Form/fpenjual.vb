﻿Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy

Public Class fpenjual

    Private bs1 As BindingSource
    Private ds As DataSet
    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView

    Private Sub opendata()

        Const sql As String = "select top 500 * from ms_penjual"
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

        sql = "select * from ms_penjual where "

        Select Case tcbofind.SelectedIndex
            Case 0 ' kode
                sql = String.Format("{0} kode='{1}'", sql, tfind.Text.Trim)
            Case 1 ' nama
                sql = String.Format("{0} nama like '%{1}%'", sql, tfind.Text.Trim)
            Case 2
                sql = String.Format("{0} alamat like '%{1}%'", sql, tfind.Text.Trim)
        End Select

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

        Dim sql As String = String.Format("delete from ms_penjual where kode='{0}'", dv1(Me.BindingContext(bs1).Position)("kode").ToString)

        Dim cn As OleDbConnection = Nothing
        Dim comd As OleDbCommand = Nothing

        Try

            open_wait()

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim sqltrans As OleDbTransaction = cn.BeginTransaction

            comd = New OleDbCommand(sql, cn, sqltrans)
            comd.ExecuteNonQuery()

            Clsmy.InsertToLog(cn, "btpenjual", 0, 0, 1, 0, dv1(Me.BindingContext(bs1).Position)("kode").ToString, dv1(Me.BindingContext(bs1).Position)("nama").ToString, sqltrans)

            sqltrans.Commit()

            close_wait()

            MsgBox("Data telah dihapus...", vbOKOnly + vbInformation, "Informasi")

            opendata()

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
        tsfind.Text = ""
        opendata()
    End Sub

    Private Sub tsdel_Click(sender As System.Object, e As System.EventArgs) Handles tsdel.Click

        If dv1.Count < 1 Then
            Exit Sub
        End If

        If MsgBox("Yakin akan dihapus ?", vbYesNo + vbQuestion, "Konfirmasi") = vbNo Then
            Exit Sub
        End If

        hapus()

    End Sub

    Private Sub tsadd_Click(sender As System.Object, e As System.EventArgs) Handles tsadd.Click
        Using fkar2 As New fpenjual2 With {.StartPosition = FormStartPosition.CenterParent, .dv = dv1, .addstat = True, .position = 0}
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

        Using fkar2 As New fpenjual2 With {.StartPosition = FormStartPosition.CenterParent, .dv = dv1, .addstat = False, .position = bs1.Position}
            fkar2.ShowDialog()
        End Using

    End Sub

End Class