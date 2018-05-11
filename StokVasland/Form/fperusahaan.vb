Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy
Public Class fperusahaan

    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView

    Private Sub opengrid()

        Dim sql As String = "select * from ms_usaha"

        Dim cn As OleDbConnection = Nothing
        Dim ds As DataSet

        grid1.DataSource = Nothing

        Try

            dv1 = Nothing

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            ds = New DataSet()
            ds = Clsmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            grid1.DataSource = dv1


        Catch ex As OleDb.OleDbException

            MsgBox(ex.ToString, MsgBoxStyle.Information, "Informasi")
        Finally


            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If

        End Try

    End Sub

    Private Sub simpan_(ByVal nopos As Integer)

        Dim cn As OleDbConnection = Nothing
        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim sql As String = ""


            sql = String.Format("insert into ms_usaha (nama_usaha) values('{0}');SELECT SCOPE_IDENTITY()", dv1(nopos)("nama_usaha").ToString)
            Dim cmd As OleDbCommand = New OleDbCommand(sql, cn)
            Dim a As Object = cmd.ExecuteScalar

            If IsNumeric(a.ToString) Then
                dv1(nopos)("noid") = a.ToString
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

    End Sub

    Private Sub update_(ByVal nopos As Integer)

        Dim cn As OleDbConnection = Nothing
        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim sql As String = ""


            sql = String.Format("update_ ms_usaha set nama_usaha='{0}' where noid={1}", dv1(nopos)("nama_usaha").ToString, dv1(nopos)("noid").ToString)
            Dim cmd As OleDbCommand = New OleDbCommand(sql, cn)
            cmd.ExecuteNonQuery()

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

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged

        If IsNothing(dv1) Then
            Return
        End If

        If dv1.Count <= 0 Then
            Return
        End If

        Dim nopos As Integer = Me.BindingContext(dv1).Position

        If Not IsNumeric(dv1(nopos)("noid").ToString) Then

            simpan_(nopos)

        Else

            update_(nopos)

        End If

    End Sub

    Private Sub hapus()

        If IsNothing(dv1) Then
            Return
        End If

        If dv1.Count <= 0 Then
            Return
        End If

        Dim cn As OleDbConnection = Nothing
        Try

            cn = New OleDbConnection
            cn = ClsMy.open_conn

            Dim sql As String = String.Format("delete from ms_usaha where noid={0}", dv1(Me.BindingContext(dv1).Position)("noid").ToString)
            Using cmd = New OleDbCommand(sql, cn)
                cmd.ExecuteNonQuery()
            End Using

            dv1.Delete(Me.BindingContext(dv1).Position)

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

    Private Sub f_nohps_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        grid1.Focus()
    End Sub

    Private Sub f_nohps_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub f_nohps_Load(sender As Object, e As EventArgs) Handles Me.Load
        opengrid()
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown

        If IsNothing(dv1) Then
            Return
        End If

        If dv1.Count <= 0 Then
            Return
        End If

        If e.KeyCode = Keys.Delete Then
            hapus()
        End If

    End Sub

    Private Sub grid1_KeyDown(sender As Object, e As KeyEventArgs) Handles grid1.KeyDown

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

    End Sub


End Class