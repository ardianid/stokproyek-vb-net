Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy

Public Class fpesan_beli3

    Public dv As DataView
    Public position As Integer
    Public addstat As Boolean

    Private vqty1, vqty2, vqty3 As Integer
    Private vharga2, vharga3 As Double
    Private kqty As Integer

    Private Sub kosongkan()

        tkode.Text = ""
        tnama.Text = ""

        tjml.EditValue = 0
        tsat.Properties.Items.Clear()

        vqty1 = 0
        vqty2 = 0
        vqty3 = 0


    End Sub

    Private Sub kalkulasi()

        If tjml.EditValue = 0 Then
            Return
        End If


        Dim jml As String = tjml.EditValue
        Dim jml1 As Integer
        If Not jml.Equals("") Then
            jml1 = Integer.Parse(jml)
        Else
            jml1 = 0
        End If

        Dim xharga As Double = 0 'tharga.EditValue
        Dim disc_rp As Double
        Dim xjumlah As Double = jml1

        If xharga > 0 Then

            vharga2 = xharga / vqty2
            vharga3 = vharga2 / vqty3

            disc_rp = 0 'tdisc_rp.EditValue

            Select Case tsat.SelectedIndex
                Case 0
                    xjumlah = (xharga * xjumlah) - disc_rp
                    kqty = (vqty1 * vqty2 * vqty3) * jml1
                Case 1
                    xjumlah = (vharga2 * xjumlah) - disc_rp
                    kqty = (vqty3) * jml1
                Case 2
                    xjumlah = (vharga3 * xjumlah) - disc_rp
                    kqty = jml1
            End Select

            ' tjumlah.EditValue = xjumlah

        Else

            Select Case tsat.SelectedIndex
                Case 0
                    kqty = (vqty1 * vqty2 * vqty3) * jml1
                Case 1
                    kqty = (vqty3) * jml1
                Case 2
                    kqty = jml1
            End Select

            vharga2 = 0
            vharga3 = 0

            ' tjumlah.EditValue = 0

        End If

    End Sub

    Private Sub insertview()

        Dim dta As DataTable = dv.ToTable

        Dim rows() As DataRow = dta.Select(String.Format("kd_barang='{0}' and satuan='{1}'", tkode.EditValue, tsat.EditValue))

        If rows.Length > 0 Then
            MsgBox("Barang sudah ada dalam daftar...", vbOKOnly + vbInformation, "Informasi")
            tkode.Focus()
            Return
        End If

        Dim orow As DataRowView = dv.AddNew
        orow("noid") = 0
        orow("kd_barang") = tkode.EditValue
        orow("nama_barang") = tnama.Text.Trim
        orow("qty") = tjml.EditValue
        orow("satuan") = tsat.EditValue
        orow("qtykecil") = kqty


        dv.EndInit()

        kosongkan()
        tkode.Focus()

    End Sub

    Private Sub tkode_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tkode.KeyDown
        If e.KeyCode = Keys.F4 Then
            bts_barang_Click(sender, Nothing)
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

                        tsat.Properties.Items.Clear()
                        tsat.Properties.Items.Add(drd("satuan1").ToString)
                        tsat.Properties.Items.Add(drd("satuan2").ToString)

                        tsat.SelectedIndex = 0

                        vqty1 = Integer.Parse(drd("qty1").ToString)
                        vqty2 = Integer.Parse(drd("qty2").ToString)
                        vqty3 = 1

                        If tjml.EditValue > 0 Then
                            tjml_EditValueChanged(Nothing, Nothing)
                        End If

                    End If
                End If
                drd.Close()

                If ada = False Then
                    tkode.Text = ""
                    tnama.Text = ""
                    tsat.Properties.Items.Clear()
                    vqty1 = 0
                    vqty2 = 0
                    vqty3 = 0
                    '  tharga.EditValue = 0
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

    Private Sub tjml_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles tjml.EditValueChanged
        kalkulasi()
    End Sub

    Private Sub btclose_Click(sender As System.Object, e As System.EventArgs) Handles btclose.Click
        Me.Close()
    End Sub

    Private Sub ffaktur_to3_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        tkode.Focus()
    End Sub

    Private Sub btsimpan_Click(sender As System.Object, e As System.EventArgs) Handles btsimpan.Click

        If tkode.EditValue = "" Then
            MsgBox("Barang harus diisi...", vbOKOnly + vbInformation, "Informasi")
            tkode.Focus()
            Return
        End If

        If tsat.EditValue = "" Then
            MsgBox("Satuan harus diisi...", vbOKOnly + vbInformation, "Informasi")
            tsat.Focus()
            Return
        End If

        If addstat = True Then
            insertview()
        Else

        End If

    End Sub

    Private Sub tsat_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tsat.SelectedIndexChanged
        kalkulasi()
    End Sub


End Class