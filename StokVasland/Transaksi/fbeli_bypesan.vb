Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy

Public Class fbeli_bypesan

    Public dv As DataView
    Public nobukti_ps As String
    Public kdtoko As String

    Private dvmanager As Data.DataViewManager
    Private dv1 As Data.DataView

    Private vqty1, vqty2, vqty3 As Integer
    Private vharga2, vharga3 As Double
    Private kqty As Integer

    Private Sub load_data()

        grid1.DataSource = Nothing
        dv1 = Nothing

        Dim cn As OleDbConnection = Nothing

        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim sql As String = String.Format("select ms_barang.kd_barang,ms_barang.nama_barang,tr_pesanbeli2.qty,tr_pesanbeli2.satuan,tr_pesanbeli2.qtykecil,ms_barang.hargabeli as harga,ms_barang.qty1,ms_barang.qty2,tr_pesanbeli2.qty as qtyd,tr_pesanbeli2.qtykecil as qtydkecil,ms_barang.satuan1,ms_barang.satuan2,0.0 as disc_per,0 as disc_rp,0.0 as disc_per2,0 as disc_rp2, " & _
            "case when tr_pesanbeli2.satuan=ms_barang.satuan1 and ms_barang.hargabeli > 0 then " & _
                "tr_pesanbeli2.qty * ms_barang.hargabeli " & _
                "else " & _
                "(ms_barang.hargabeli / (ms_barang.qty1 * ms_barang.qty2)) * tr_pesanbeli2.qty " & _
            "end as jumlah,0 as qty1_dt,0 as qty2_dt " & _
            "from tr_pesanbeli2 inner join ms_barang on tr_pesanbeli2.kd_barang=ms_barang.kd_barang inner join tr_pesanbeli on tr_pesanbeli.nobukti=tr_pesanbeli2.nobukti " & _
            "where tr_pesanbeli.nobukti='{0}' and tr_pesanbeli.kd_toko='{1}'", nobukti_ps, kdtoko)

            Dim ds As DataSet
            ds = New DataSet()
            ds = Clsmy.GetDataSet(Sql, cn)

            dvmanager = New DataViewManager(ds)
            dv1 = dvmanager.CreateDataView(ds.Tables(0))

            grid1.DataSource = dv1

            cek_datang(cn)

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

    Private Sub cek_datang(ByVal cn As OleDbConnection)

        If IsNothing(dv1) Then
            Return
        End If

        If dv1.Count <= 0 Then
            Return
        End If

        Dim sql As String = ""

        Dim qt1 As Integer = 0
        Dim qt2 As Integer = 0

        For i As Integer = 0 To dv1.Count - 1

            sql = String.Format("select ms_barang.kd_barang, " & _
            "case when  (SUM(tr_beli2.qtykecil) % (ms_barang.qty1 * ms_barang.qty2)) >=0 then " & _
            "(SUM(tr_beli2.qtykecil)/(ms_barang.qty1 * ms_barang.qty2)) - ((SUM(tr_beli2.qtykecil) % (ms_barang.qty1 * ms_barang.qty2))) else " & _
            "0 end as qty1, " & _
            "case when  (SUM(tr_beli2.qtykecil) % (ms_barang.qty1 * ms_barang.qty2)) >=0 then " & _
            "0 else (SUM(tr_beli2.qtykecil) % (ms_barang.qty1 * ms_barang.qty2)) end as qty2 " & _
            "from tr_beli2 inner join tr_beli on tr_beli.nobukti=tr_beli2.nobukti " & _
            "inner join ms_barang on tr_beli2.kd_barang=ms_barang.kd_barang " & _
            "where tr_beli.sbatal=0 and tr_beli.nobukti_ps='{0}' and tr_beli2.kd_barang='{1}' " & _
            "group by ms_barang.kd_barang,ms_barang.qty1,ms_barang.qty2", nobukti_ps, dv1(i)("kd_barang").ToString)

            Dim cmd As OleDbCommand = New OleDbCommand(sql, cn)
            Dim drd As OleDbDataReader = cmd.ExecuteReader

            qt1 = 0
            qt2 = 0

            If drd.Read Then
                If Not drd(0).ToString.Equals("") Then

                    qt1 = Integer.Parse(drd("qty1").ToString)
                    qt2 = Integer.Parse(drd("qty2").ToString)

                End If
            End If
            drd.Close()

            dv1(i)("qty1_dt") = qt1
            dv1(i)("qty2_dt") = qt2

        Next


    End Sub

    Private Sub fbeli_bypesan_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        BandedGridView1.Focus()
    End Sub

    Private Sub fbeli_bypesan_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        load_data()
    End Sub

    Private Sub kalkulasi()

        Dim jmld As Integer = 0

        Dim qty1 As Integer = 0
        Dim qty2 As Integer = 0

        Dim discrp As Double = 0
        Dim discrp2 As Double = 0

        Dim hargar As Double = 0

        Dim satuan1 As String = ""
        Dim satuan2 As String = ""
        Dim satuan As String = ""

        satuan1 = dv1(BindingContext(dv1).Position)("satuan1").ToString
        satuan2 = dv1(BindingContext(dv1).Position)("satuan2").ToString

        satuan = dv1(BindingContext(dv1).Position)("satuan").ToString

        jmld = Integer.Parse(dv1(BindingContext(dv1).Position)("qtyd").ToString)

        hargar = Double.Parse(dv1(BindingContext(dv1).Position)("harga").ToString)

        qty1 = Integer.Parse(dv1(BindingContext(dv1).Position)("qty1").ToString)
        qty2 = Integer.Parse(dv1(BindingContext(dv1).Position)("qty2").ToString)

        discrp = Double.Parse(dv1(BindingContext(dv1).Position)("disc_rp").ToString)
        discrp2 = Double.Parse(dv1(BindingContext(dv1).Position)("disc_rp2").ToString)


        If jmld = 0 Then

            dv1(BindingContext(dv1).Position)("harga") = 0
            dv1(BindingContext(dv1).Position)("disc_per") = 0.0
            dv1(BindingContext(dv1).Position)("disc_rp") = 0
            dv1(BindingContext(dv1).Position)("jumlah") = 0

            dv1(BindingContext(dv1).Position)("disc_per2") = 0.0
            dv1(BindingContext(dv1).Position)("disc_rp2") = 0

            dv1(BindingContext(dv1).Position)("qtydkecil") = 0

            Return
        End If


        Dim jml As String = jmld
        Dim jml1 As Integer
        If Not jml.Equals("") Then
            jml1 = Integer.Parse(jml)
        Else
            jml1 = 0
        End If

        Dim xharga As Double = hargar
        Dim disc_rp As Double
        Dim disc_rp2 As Double
        Dim xjumlah As Double = jml1

        If xharga > 0 Then

            vharga2 = xharga / qty2
            vharga3 = vharga2 / 0

            disc_rp = discrp
            disc_rp2 = discrp2

            If satuan.Equals(satuan1) Then
                xjumlah = (xharga * xjumlah) - disc_rp - disc_rp2
                kqty = (qty1 * qty2) * jml1
            ElseIf satuan.Equals(satuan2) Then
                xjumlah = (vharga2 * xjumlah) - disc_rp - disc_rp2
                kqty = jml1
            Else
                xjumlah = (vharga3 * xjumlah) - disc_rp - disc_rp2
                kqty = jml1
            End If


        Else

            If satuan.Equals(satuan1) Then
                kqty = (qty1 * qty2) * jml1
            ElseIf satuan.Equals(satuan2) Then
                kqty = jml1
            Else
                kqty = jml1
            End If

            vharga2 = 0
            vharga3 = 0

            xjumlah = 0

        End If

        dv1(BindingContext(dv1).Position)("jumlah") = xjumlah
        dv1(BindingContext(dv1).Position)("qtydkecil") = kqty

    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BandedGridView1.CellValueChanged

        If IsNothing(dv1) Then
            Return
        End If

        If dv1.Count <= 0 Then
            Return
        End If

        If e.Column.FieldName = "qtyd" Then

            dv1(BindingContext(dv1).Position)("disc_per") = 0.0
            dv1(BindingContext(dv1).Position)("disc_per2") = 0.0
            dv1(BindingContext(dv1).Position)("disc_rp") = 0
            dv1(BindingContext(dv1).Position)("disc_rp2") = 0

            kalkulasi()
        ElseIf e.Column.FieldName = "harga" Then

            dv1(BindingContext(dv1).Position)("disc_per") = 0.0
            dv1(BindingContext(dv1).Position)("disc_per2") = 0.0
            dv1(BindingContext(dv1).Position)("disc_rp") = 0
            dv1(BindingContext(dv1).Position)("disc_rp2") = 0

            kalkulasi()
        ElseIf e.Column.FieldName = "disc_per" Then

            Dim jmld As Integer = 0

            Dim qty1 As Integer = 0
            Dim qty2 As Integer = 0

            Dim hargar As Double = 0

            Dim satuan1 As String = ""
            Dim satuan2 As String = ""
            Dim satuan As String = ""

            satuan1 = dv1(BindingContext(dv1).Position)("satuan1").ToString
            satuan2 = dv1(BindingContext(dv1).Position)("satuan2").ToString

            satuan = dv1(BindingContext(dv1).Position)("satuan").ToString

            qty1 = Integer.Parse(dv1(BindingContext(dv1).Position)("qty1").ToString)
            qty2 = Integer.Parse(dv1(BindingContext(dv1).Position)("qty2").ToString)

            jmld = Integer.Parse(dv1(BindingContext(dv1).Position)("qtyd").ToString)

            hargar = Double.Parse(dv1(BindingContext(dv1).Position)("harga").ToString)

            Dim totharga As Double = 0
            Dim disc_jd As Double = 0

            If satuan.Equals(satuan1) Then
                totharga = jmld * hargar
                disc_jd = totharga * (e.Value / 100)
            ElseIf satuan.Equals(satuan2) Then
                totharga = hargar / (qty1 * qty2)
                totharga = totharga * jmld
                disc_jd = totharga * (e.Value / 100)
            End If

            dv1(BindingContext(dv1).Position)("disc_rp") = disc_jd

            dv1(BindingContext(dv1).Position)("disc_per2") = 0.0
            dv1(BindingContext(dv1).Position)("disc_rp2") = 0

            kalkulasi()

        ElseIf e.Column.FieldName = "disc_per2" Then

            Dim jmld As Integer = 0

            Dim qty1 As Integer = 0
            Dim qty2 As Integer = 0

            Dim hargar As Double = 0

            Dim satuan1 As String = ""
            Dim satuan2 As String = ""
            Dim satuan As String = ""

            satuan1 = dv1(BindingContext(dv1).Position)("satuan1").ToString
            satuan2 = dv1(BindingContext(dv1).Position)("satuan2").ToString

            satuan = dv1(BindingContext(dv1).Position)("satuan").ToString

            qty1 = Integer.Parse(dv1(BindingContext(dv1).Position)("qty1").ToString)
            qty2 = Integer.Parse(dv1(BindingContext(dv1).Position)("qty2").ToString)

            jmld = Integer.Parse(dv1(BindingContext(dv1).Position)("qtyd").ToString)

            hargar = Double.Parse(dv1(BindingContext(dv1).Position)("harga").ToString)

            Dim totharga As Double = 0
            Dim disc_jd As Double = 0

            If satuan.Equals(satuan1) Then
                totharga = jmld * hargar
                totharga = totharga - Double.Parse(dv1(BindingContext(dv1).Position)("disc_rp").ToString)
                disc_jd = totharga * (e.Value / 100)
            ElseIf satuan.Equals(satuan2) Then
                totharga = hargar / (qty1 * qty2)
                totharga = totharga * jmld
                totharga = totharga - Double.Parse(dv1(BindingContext(dv1).Position)("disc_rp").ToString)
                disc_jd = totharga * (e.Value / 100)
            End If

            dv1(BindingContext(dv1).Position)("disc_rp2") = disc_jd
            kalkulasi()

        ElseIf e.Column.FieldName = "disc_rp" Then

            Dim jmld As Integer = 0

            Dim qty1 As Integer = 0
            Dim qty2 As Integer = 0

            Dim hargar As Double = 0

            Dim satuan1 As String = ""
            Dim satuan2 As String = ""
            Dim satuan As String = ""

            satuan1 = dv1(BindingContext(dv1).Position)("satuan1").ToString
            satuan2 = dv1(BindingContext(dv1).Position)("satuan2").ToString

            satuan = dv1(BindingContext(dv1).Position)("satuan").ToString

            qty1 = Integer.Parse(dv1(BindingContext(dv1).Position)("qty1").ToString)
            qty2 = Integer.Parse(dv1(BindingContext(dv1).Position)("qty2").ToString)

            jmld = Integer.Parse(dv1(BindingContext(dv1).Position)("qtyd").ToString)

            hargar = Double.Parse(dv1(BindingContext(dv1).Position)("harga").ToString)

            Dim totharga As Double = 0
            Dim disc_jd As Double = 0

            If satuan.Equals(satuan1) Then
                totharga = jmld * hargar
                disc_jd = (e.Value / totharga) * 100
            ElseIf satuan.Equals(satuan2) Then
                totharga = hargar / (qty1 * qty2)
                totharga = totharga * jmld
                disc_jd = (e.Value / totharga) * 100
            End If

            dv1(BindingContext(dv1).Position)("disc_per") = disc_jd

            dv1(BindingContext(dv1).Position)("disc_per2") = 0.0
            dv1(BindingContext(dv1).Position)("disc_rp2") = 0

            kalkulasi()

        ElseIf e.Column.FieldName = "disc_rp2" Then

            Dim jmld As Integer = 0

            Dim qty1 As Integer = 0
            Dim qty2 As Integer = 0

            Dim hargar As Double = 0

            Dim satuan1 As String = ""
            Dim satuan2 As String = ""
            Dim satuan As String = ""

            satuan1 = dv1(BindingContext(dv1).Position)("satuan1").ToString
            satuan2 = dv1(BindingContext(dv1).Position)("satuan2").ToString

            satuan = dv1(BindingContext(dv1).Position)("satuan").ToString

            qty1 = Integer.Parse(dv1(BindingContext(dv1).Position)("qty1").ToString)
            qty2 = Integer.Parse(dv1(BindingContext(dv1).Position)("qty2").ToString)

            jmld = Integer.Parse(dv1(BindingContext(dv1).Position)("qtyd").ToString)

            hargar = Double.Parse(dv1(BindingContext(dv1).Position)("harga").ToString)

            Dim totharga As Double = 0
            Dim disc_jd As Double = 0

            If satuan.Equals(satuan1) Then
                totharga = jmld * hargar
                totharga = totharga - Double.Parse(dv1(BindingContext(dv1).Position)("disc_rp").ToString)
                disc_jd = (e.Value / totharga) * 100
            ElseIf satuan.Equals(satuan2) Then
                totharga = hargar / (qty1 * qty2)
                totharga = totharga * jmld
                totharga = totharga - Double.Parse(dv1(BindingContext(dv1).Position)("disc_rp").ToString)
                disc_jd = (e.Value / totharga) * 100
            End If

            dv1(BindingContext(dv1).Position)("disc_per2") = disc_jd
            kalkulasi()
        End If

    End Sub

    Private Sub insertview()

        dv.Table.Clear()

        For i As Integer = 0 To dv1.Count - 1

            Dim orow As DataRowView = dv.AddNew

            orow("noid") = 0
            orow("kd_barang") = dv1(i)("kd_barang").ToString
            orow("nama_barang") = dv1(i)("nama_barang").ToString
            orow("qty") = dv1(i)("qtyd").ToString
            orow("satuan") = dv1(i)("satuan").ToString
            orow("harga") = dv1(i)("harga").ToString
            orow("disc_per") = dv1(i)("disc_per").ToString
            orow("disc_rp") = dv1(i)("disc_rp").ToString
            orow("disc_per2") = dv1(i)("disc_per2").ToString
            orow("disc_rp2") = dv1(i)("disc_rp2").ToString
            orow("jumlah") = dv1(i)("jumlah").ToString
            orow("qtykecil") = dv1(i)("qtydkecil").ToString

            dv.EndInit()

        Next

        Me.Close()

    End Sub


    Private Sub btclose_Click(sender As System.Object, e As System.EventArgs) Handles btclose.Click
        Me.Close()
    End Sub

    Private Sub btsimpan_Click(sender As System.Object, e As System.EventArgs) Handles btsimpan.Click
        insertview()
    End Sub


End Class