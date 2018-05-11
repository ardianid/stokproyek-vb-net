Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy

Imports DevExpress.XtraReports.UI

Public Class fpr_belinett2

    Public sql As String
    Public periode As String

    Private Sub loadfaktur()

        Dim cn As OleDbConnection = Nothing

        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim ds As DataSet = New ds_belibytotal
            ds = Clsmy.GetDataSet(sql, cn)

            dsinvoice_ku = New DataSet
            dsinvoice_ku = ds

            Dim ops As New System.Drawing.Printing.PrinterSettings

            Dim rinvoice As New r_belibytotal With {.DataSource = ds.Tables(0)}
            rinvoice.xperiode.Text = periode
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

    Private Sub fpr_invoice2_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        loadfaktur()
    End Sub


End Class