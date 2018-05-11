Imports DevExpress.XtraBars
Imports System.Data.OleDb
Imports StokVasland.Clsmy
Imports DevExpress.Skins

Public Class futama

    Private Sub disable_bar()

        FillItemBranch(Bar2.ItemLinks)

        Bar2.Visible = False

    End Sub

    Private Sub FillItemBranch(ByVal links As DevExpress.XtraBars.BarItemLinkCollection)
        For Each link As DevExpress.XtraBars.BarItemLink In links
            If TypeOf link.Item Is DevExpress.XtraBars.BarButtonItem Then
                link.Item.Visibility = BarItemVisibility.Never
            End If
            If TypeOf link.Item Is DevExpress.XtraBars.BarSubItem Then
                FillItemBranch(CType(link.Item, DevExpress.XtraBars.BarSubItem).ItemLinks)
            End If
        Next
    End Sub

    Public Sub LoadOtherForm(ByVal fname As Form)

        open_wait()
        Cursor = Cursors.WaitCursor


        fname.MdiParent = Me
        fname.Show()


        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub btnuser_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnuser.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        fuser.MdiParent = Me
        fuser.Show()

        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub futama_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub futama_Load(sender As Object, e As EventArgs) Handles Me.Load

        disable_bar()

        bar_tgl.Caption = DateValue(Date.Now)

        Try
            Dim cn As OleDbConnection

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            cn.Close()
            cn.Dispose()



            LoadLOgin()



        Catch ex As Exception

            fsettdbase.MdiParent = Me
            fsettdbase.Show()

            'If ex.Message.ToString.Equals("Object reference not set to an instance of an object.") Then
            '    MsgBox("ok")
            'End If

        End Try

    End Sub

    Public Sub LoadLOgin()
        Dim fmlogin As New login With {.MdiParent = Me, .WindowState = FormWindowState.Maximized}
        fmlogin.Show()
    End Sub

    Private Sub NO_logof_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NO_sm_logoff.ItemClick

        For Each f As Form In Me.MdiChildren
            f.Close()
        Next

        disable_bar()

        userprog = ""
        pwd = ""
        initial_user = ""

        bar_user.Caption = "User : "

        Dim fmlogin As New login With {.MdiParent = Me, .WindowState = FormWindowState.Maximized}
        fmlogin.Show()

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        bar_jam.Caption = Format(Now, "hh:mm:ss tt")
    End Sub

    Private Sub NO_ch_pwd_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NO_sm_rubahpwd.ItemClick
        frubah_pwd.ShowDialog(Me)
    End Sub

    Private Sub btpenjual_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btpenjual.ItemClick
        open_wait()
        Cursor = Cursors.WaitCursor


        fpenjual.MdiParent = Me
        fpenjual.Show()


        Cursor = Cursors.Default
        close_wait()
    End Sub

    Private Sub btbarang_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btbarang.ItemClick
        open_wait()
        Cursor = Cursors.WaitCursor


        fbarang.MdiParent = Me
        fbarang.Show()


        Cursor = Cursors.Default
        close_wait()
    End Sub

    Private Sub btbeli_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btbeli.ItemClick
        open_wait()
        Cursor = Cursors.WaitCursor


        fbeli.MdiParent = Me
        fbeli.Show()


        Cursor = Cursors.Default
        close_wait()
    End Sub

    Private Sub btpakai_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btpakai.ItemClick
        open_wait()
        Cursor = Cursors.WaitCursor


        fpakai.MdiParent = Me
        fpakai.Show()


        Cursor = Cursors.Default
        close_wait()
    End Sub

    Private Sub NO_mslaporan_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NO_mslaporan.ItemClick
        open_wait()
        Cursor = Cursors.WaitCursor


        freport.MdiParent = Me
        freport.Show()


        Cursor = Cursors.Default
        close_wait()
    End Sub

    Private Sub btopname_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btopname.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor


        fopname.MdiParent = Me
        fopname.Show()


        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub btkelompok_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btkelompok.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor


        fkelompok.MdiParent = Me
        fkelompok.Show()


        Cursor = Cursors.Default
        close_wait()

    End Sub

    Private Sub btpesanbeli_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btpesanbeli.ItemClick
        open_wait()
        Cursor = Cursors.WaitCursor


        fpesan_beli.MdiParent = Me
        fpesan_beli.Show()


        Cursor = Cursors.Default
        close_wait()
    End Sub

    Private Sub btproyek_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btproyek.ItemClick
        open_wait()
        Cursor = Cursors.WaitCursor


        fproyek.MdiParent = Me
        fproyek.Show()


        Cursor = Cursors.Default
        close_wait()
    End Sub

    Private Sub btproyeksub_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btproyeksub.ItemClick
        open_wait()
        Cursor = Cursors.WaitCursor


        fproyeksub.MdiParent = Me
        fproyeksub.Show()


        Cursor = Cursors.Default
        close_wait()
    End Sub

    Private Sub btretur_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btretur.ItemClick
        open_wait()
        Cursor = Cursors.WaitCursor


        fretur.MdiParent = Me
        fretur.Show()


        Cursor = Cursors.Default
        close_wait()
    End Sub


    Private Sub btperusahaan_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btperusahaan.ItemClick

        open_wait()
        Cursor = Cursors.WaitCursor

        fperusahaan.ShowDialog()


        Cursor = Cursors.Default
        close_wait()

    End Sub

End Class