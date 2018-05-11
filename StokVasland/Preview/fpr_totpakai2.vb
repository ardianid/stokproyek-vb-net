Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy

Imports DevExpress.XtraReports.UI

Public Class fpr_totpakai2

    Public sql As String
    Public periode As String
    Public jnslap As Integer

    Private Sub loadfaktur()

        Dim cn As OleDbConnection = Nothing

        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim ds As DataSet = New ds_totpakai_byitem
            ds = Clsmy.GetDataSet(sql, cn)

            dsinvoice_ku = New DataSet
            dsinvoice_ku = ds

            Dim ops As New System.Drawing.Printing.PrinterSettings

            If jnslap = 0 Then

                Dim rinvoice As New r_totpakai_byitem With {.DataSource = ds.Tables(0)}
                rinvoice.xperiode.Text = periode
                rinvoice.xuser.Text = String.Format("User : {0} | Tgl : {1}", userprog, Date.Now)
                rinvoice.DataMember = rinvoice.DataMember

                rinvoice.PrinterName = ops.PrinterName
                rinvoice.CreateDocument(True)

                PrintControl1.PrintingSystem = rinvoice.PrintingSystem

            Else

                Dim rinvoice2 As New r_totpakai_byitem2 With {.DataSource = ds.Tables(0)}
                rinvoice2.xperiode.Text = periode
                rinvoice2.xuser.Text = String.Format("User : {0} | Tgl : {1}", userprog, Date.Now)
                rinvoice2.DataMember = rinvoice2.DataMember

                rinvoice2.PrinterName = ops.PrinterName
                rinvoice2.CreateDocument(True)

                PrintControl1.PrintingSystem = rinvoice2.PrintingSystem

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

    Private Sub fpr_invoice2_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        loadfaktur()
    End Sub


End Class