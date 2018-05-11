Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy

Imports DevExpress.XtraReports.UI

Public Class fpr_formopname

    Public sql1 As String

    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView

    Private dvmanager2 As Data.DataViewManager
    Private dv2 As Data.DataView

    Private sscek As Integer = 0

    Private Sub loadfaktur()

        Dim cn As OleDbConnection = Nothing

        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim ds As DataSet = New ds_formopname
            ds = Clsmy.GetDataSet(sql1, cn)

            dsinvoice_ku = New DataSet
            dsinvoice_ku = ds

            Dim ops As New System.Drawing.Printing.PrinterSettings

            Dim rinvoice As New r_formopname() With {.DataSource = ds.Tables(0)}
            rinvoice.xuser.Text = String.Format("User : {0} | Tgl : {1}", userprog, Date.Now)
            rinvoice.DataMember = rinvoice.DataMember

            rinvoice.PrinterName = ops.PrinterName
            rinvoice.CreateDocument(True)

            PrintControl1.PrintingSystem = rinvoice.PrintingSystem

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

    Private Sub load_barang()

        Dim cn As OleDbConnection = Nothing
        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim sql As String = "select kd_barang,nama_barang,0 as act from ms_barang"

            Dim ds As DataSet
            ds = New DataSet()
            ds = Clsmy.GetDataSet(sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))
            
            grid1.DataSource = dv1

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

    Private Sub load_kelompok()

        Dim cn As OleDbConnection = Nothing
        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim sql As String = "select 0 as act,nama_kelompok from ms_kelompok"

            Dim ds As DataSet
            ds = New DataSet()
            ds = Clsmy.GetDataSet(sql, cn)

            dvmanager2 = New DataViewManager(ds)
            dv2 = dvmanager.CreateDataView(ds.Tables(0))

            grid2.DataSource = dv2

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


    Private Sub fpr_invoice2_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        load_barang()
        load_kelompok()

        XtraTabControl1.SelectedTabPageIndex = 0

        CheckEdit1.Text = "Check All"

    End Sub

    Private Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton1.Click

        If CheckEdit1.Checked = True Then
            sql1 = "select kd_barang,nama_barang,0 as act from ms_barang"
        Else

            sql1 = "select kd_barang,nama_barang,0 as act from ms_barang where "


            Dim sqlf As String = ""
            Dim c As Integer = 0

            If XtraTabControl1.SelectedTabPageIndex = 0 Then

                sql1 = String.Format(" {0} kd_barang in ( ", sql1)
                For i As Integer = 0 To dv1.Count - 1

                    If Integer.Parse(dv1(i)("act").ToString) = 1 Then
                        If c = 0 Then
                            sqlf = String.Format("'{0}'", dv1(i)("kd_barang").ToString)
                        Else
                            sqlf = String.Format("{0},'{1}'", sqlf.Trim, dv1(i)("kd_barang").ToString)
                        End If
                        c = c + 1
                    End If

                Next

            Else

                sql1 = String.Format(" {0} kelompok in ( ", sql1)
                For i As Integer = 0 To dv2.Count - 1

                    If Integer.Parse(dv2(i)("act").ToString) = 1 Then
                        If c = 0 Then
                            sqlf = String.Format("'{0}'", dv2(i)("nama_kelompok").ToString)
                        Else
                            sqlf = String.Format("{0},'{1}'", sqlf.Trim, dv2(i)("nama_kelompok").ToString)
                        End If
                        c = c + 1
                    End If

                Next

            End If

            If sqlf.Trim.Length = 0 Then
                Exit Sub
            End If

            sql1 = String.Format("{0}{1})", sql1, sqlf)

        End If

        loadfaktur()

    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckEdit1.CheckedChanged

        Dim hsil As Integer = 0

        If CheckEdit1.Checked = True Then
            CheckEdit1.Text = "&Uncheck All"
            hsil = 1
        Else
            CheckEdit1.Text = "&Check All"
            hsil = 0
        End If

        If sscek = 1 Then
            Return
        End If

        If XtraTabControl1.SelectedTabPageIndex = 0 Then

            For i As Integer = 0 To dv1.Count - 1
                dv1(i)("act") = hsil
            Next

        Else

            For i As Integer = 0 To dv2.Count - 1
                dv2(i)("act") = hsil
            Next

        End If

        

    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column.FieldName = "act" Then
            sscek = 1
            CheckEdit1.Checked = False
            sscek = 0
        End If
    End Sub

    Private Sub GridView2_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        If e.Column.FieldName = "act" Then
            sscek = 1
            CheckEdit1.Checked = False
            sscek = 0
        End If
    End Sub

End Class