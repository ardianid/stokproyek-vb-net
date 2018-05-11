Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy

Public Class fs_pemesanan

    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView

    Public kd_toko As String

    Private Sub cari()

        Dim sql As String = ""

        sql = String.Format("SELECT tr_pesanbeli.nobukti, tr_pesanbeli.tanggal, ms_penjual.kode AS kd_toko, ms_penjual.nama AS nama_toko " & _
        "FROM tr_pesanbeli INNER JOIN ms_penjual ON tr_pesanbeli.kd_toko = ms_penjual.kode " & _
        "WHERE tr_pesanbeli.sdatang=0 and tr_pesanbeli.sbatal=0 and tr_pesanbeli.kd_toko='{0}'", kd_toko)

        If Not tfind.Text.Trim.Equals("") Then

            Select Case cb_criteria.SelectedIndex
                Case 0

                    sql = String.Format("{0} and  tr_pesanbeli.nobukti like '%{1}%'", sql, tfind.Text.Trim)

                Case 1

                    sql = String.Format("{0} and  ms_penjual.nama like '%{1}%'", sql, tfind.Text.Trim)

            End Select

        End If

        Dim cn As OleDbConnection = Nothing
        Dim ds As DataSet

        grid1.DataSource = Nothing

        Try

            '  open_wait()

            dv1 = Nothing

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            ds = New DataSet()
            ds = Clsmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            grid1.DataSource = dv1

            '     close_wait()

        Catch ex As OleDb.OleDbException
            '  close_wait()
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally


            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try


    End Sub

    Public ReadOnly Property get_NOBUKTI As String
        Get

            If IsNothing(dv1) Then
                Return ""
                Exit Property
            End If

            If dv1.Count <= 0 Then
                Return ""
                Exit Property
            End If
            Return dv1(Me.BindingContext(dv1).Position)("nobukti").ToString
        End Get
    End Property

    Private Sub tfind_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tfind.KeyDown
        If e.KeyCode = 13 Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub grid1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles grid1.DoubleClick
        Me.Close()
    End Sub

    Private Sub grid1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles grid1.KeyDown
        If e.KeyCode = Keys.Escape Or e.KeyCode = Keys.Enter Then
            Me.Close()
        End If
    End Sub

    Private Sub fskec_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        tfind.Focus()
        tfind.Select(tfind.Text.Length, 0)
    End Sub

    Private Sub fskec_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then

            Me.Close()
        End If
    End Sub

    Private Sub fskec_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        cb_criteria.SelectedIndex = 0


        tfind.Text = ""

        cari()

    End Sub

    Private Sub tfind_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles tfind.KeyUp
        cari()
    End Sub


End Class