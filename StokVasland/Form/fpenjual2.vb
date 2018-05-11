﻿Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy

Public Class fpenjual2

    Public dv As DataView
    Public position As Integer
    Public addstat As Boolean

    Private Sub kosongkan()
        tkode.Text = ""
        tnama.Text = ""
        ttelp.Text = ""
        talamat.Text = ""
        tket.Text = ""

        ctanya.Checked = False

    End Sub

    Private Sub isi()
        tkode.EditValue = dv(position)("kode").ToString
        tnama.EditValue = dv(position)("nama").ToString
        ttelp.EditValue = dv(position)("notelp").ToString
        talamat.EditValue = dv(position)("alamat").ToString
        tket.EditValue = dv(position)("note").ToString

        Dim stathut As Integer = Integer.Parse(dv(position)("shutang").ToString)

        If stathut = 1 Then
            ctanya.Checked = True
        Else
            ctanya.Checked = False
        End If


    End Sub

    Private Sub simpan()

        Dim cn As OleDbConnection = Nothing

        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim cstat As Integer = 0
            If ctanya.Checked = True Then
                cstat = 1
            End If

            Dim sqlc As String = String.Format("select kode from ms_penjual where kode='{0}'", tkode.Text.Trim)
            Dim sql_insert As String = String.Format("insert into ms_penjual (kode,nama,alamat,note,notelp,shutang) values('{0}','{1}','{2}','{3}','{4}',{5})", tkode.Text.Trim, tnama.Text.Trim, talamat.Text.Trim, tket.Text.Trim, ttelp.Text.Trim, cstat)
            Dim sql_update As String = String.Format("update ms_penjual set nama='{0}',alamat='{1}',note='{2}',notelp='{3}',shutang={4} where kode='{5}'", tnama.Text.Trim, talamat.Text.Trim, tket.Text.Trim, ttelp.Text.Trim, cstat, tkode.Text.Trim)

            Dim sqltrans As OleDbTransaction = cn.BeginTransaction

            Dim comd As OleDbCommand

            If addstat = True Then

                Dim cmdc As OleDbCommand = New OleDbCommand(sqlc, cn, sqltrans)
                Dim dread As OleDbDataReader = cmdc.ExecuteReader

                If dread.HasRows Then
                    If dread.Read Then

                        Dim kdka As String = dread(0).ToString

                        If kdka.Trim.Length = 0 Then
                            comd = New OleDbCommand(sql_insert, cn, sqltrans)
                            comd.ExecuteNonQuery()

                            Clsmy.InsertToLog(cn, "btpenjual", 1, 0, 0, 0, tkode.Text.Trim, tnama.Text.Trim, sqltrans)

                            insertview()
                        Else

                            MsgBox("Kode sudah ada ...", vbOKOnly + vbExclamation, "Informasi")
                            tkode.Focus()
                            Return
                        End If
                    Else
                        comd = New OleDbCommand(sql_insert, cn, sqltrans)
                        comd.ExecuteNonQuery()

                        Clsmy.InsertToLog(cn, "btpenjual", 1, 0, 0, 0, tkode.Text.Trim, tnama.Text.Trim, sqltrans)

                        insertview()
                    End If
                Else
                    comd = New OleDbCommand(sql_insert, cn, sqltrans)
                    comd.ExecuteNonQuery()

                    Clsmy.InsertToLog(cn, "btpenjual", 1, 0, 0, 0, tkode.Text.Trim, tnama.Text.Trim, sqltrans)

                    insertview()
                End If

                dread.Close()


            Else
                comd = New OleDbCommand(sql_update, cn, sqltrans)
                comd.ExecuteNonQuery()

                Clsmy.InsertToLog(cn, "btpenjual", 0, 1, 0, 0, tkode.Text.Trim, tnama.Text.Trim, sqltrans)

                updateview()

            End If

            sqltrans.Commit()
            MsgBox("Data telah disimpan...", vbOKOnly + vbInformation, "Informasi")

            If addstat = True Then
                kosongkan()
                tkode.Focus()
            Else
                Me.Close()
            End If


        Catch ex As Exception
            close_wait()
            MsgBox(ex.ToString)
        Finally

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
        End Try


    End Sub

    Private Sub updateview()

        dv(position)("kode") = tkode.Text.Trim
        dv(position)("nama") = tnama.Text.Trim
        dv(position)("alamat") = talamat.Text.Trim
        dv(position)("note") = tket.Text.Trim
        dv(position)("notelp") = ttelp.Text.Trim
        dv(position)("shutang") = IIf(ctanya.Checked = True, 1, 0)

    End Sub

    Private Sub insertview()

        Dim orow As DataRowView = dv.AddNew
        orow("kode") = tkode.Text.Trim
        orow("nama") = tnama.Text.Trim
        orow("alamat") = talamat.Text.Trim
        orow("note") = tket.Text.Trim
        orow("notelp") = ttelp.Text.Trim
        orow("shutang") = IIf(ctanya.Checked = True, 1, 0)
        orow("hutang") = 0

        dv.EndInit()

    End Sub

    Private Sub btsimpan_Click(sender As System.Object, e As System.EventArgs) Handles btsimpan.Click

        If tkode.Text.Trim.Length = 0 Then
            MsgBox("Kode tidak boleh kosong...", vbOKOnly + vbExclamation, "Informasi")
            tkode.Focus()
            Return
        End If

        If tnama.Text.Trim.Length = 0 Then
            MsgBox("Nama tidak boleh kosong...", vbOKOnly + vbExclamation, "Informasi")
            tnama.Focus()
            Return
        End If

        simpan()

    End Sub

    Private Sub btclose_Click(sender As System.Object, e As System.EventArgs) Handles btclose.Click
        Me.Close()
    End Sub

    Private Sub fkab2_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If addstat = True Then
            tkode.Focus()
        Else
            tnama.Focus()
        End If
    End Sub

    Private Sub fkab2_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If addstat = True Then

            tkode.Enabled = True
            kosongkan()
        Else
            tkode.Enabled = False
            isi()
        End If

    End Sub

    Private Sub ctanya_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ctanya.CheckedChanged
        If ctanya.Checked = True Then
            ctanya.Text = "Ya"
        Else
            ctanya.Text = "Tidak"
        End If
    End Sub

End Class