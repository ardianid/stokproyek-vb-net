Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy

Public Class fproyeksub2

    Public dv As DataView
    Public position As Integer
    Public addstat As Boolean

    Private Sub kosongkan()
        tkode.Text = ""
        tnama.Text = ""

        ' tkelompok.ItemIndex = 0

    End Sub

    Private Sub isi()

        tkode.EditValue = dv(position)("kd_sub").ToString
        tnama.EditValue = dv(position)("nama_sub").ToString

        tkelompok.EditValue = dv(position)("kd_group").ToString

    End Sub

    Private Sub isi_kelompok()

        Dim cn As OleDbConnection = Nothing

        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn

            Dim sql As String = "select kd_group,nama_group from ms_proyek"
            Dim dsgroup As DataSet = New DataSet()
            dsgroup = Clsmy.GetDataSet(sql, cn)

            tkelompok.Properties.DataSource = dsgroup.Tables(0)

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End If
        End Try

    End Sub

    Private Sub simpan()

        Dim cn As OleDbConnection = Nothing

        Try

            cn = New OleDbConnection
            cn = Clsmy.open_conn


            Dim sqlc As String = String.Format("select kd_sub from ms_subproyek where kd_sub='{0}'", tkode.Text.Trim)
            Dim sql_insert As String = String.Format("insert into ms_subproyek (kd_sub,nama_sub,kd_group) values('{0}','{1}','{2}')", tkode.Text.Trim, tnama.EditValue, _
                                                     tkelompok.EditValue)

            Dim sql_update As String = String.Format("update ms_subproyek set nama_sub='{0}',kd_group='{1}' where kd_sub='{2}'", tnama.EditValue, _
                                                     tkelompok.EditValue, tkode.Text.Trim)


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

                            Clsmy.InsertToLog(cn, "btproyeksub", 1, 0, 0, 0, tkode.Text.Trim, tnama.Text.Trim, sqltrans)

                            insertview()
                        Else

                            MsgBox("Kode/Nama sudah ada ...", vbOKOnly + vbExclamation, "Informasi")
                            tkode.Focus()
                            Return
                        End If
                    Else
                        comd = New OleDbCommand(sql_insert, cn, sqltrans)
                        comd.ExecuteNonQuery()

                        Clsmy.InsertToLog(cn, "btproyeksub", 1, 0, 0, 0, tkode.Text.Trim, tnama.Text.Trim, sqltrans)

                        insertview()
                    End If
                Else
                    comd = New OleDbCommand(sql_insert, cn, sqltrans)
                    comd.ExecuteNonQuery()

                    Clsmy.InsertToLog(cn, "btproyeksub", 1, 0, 0, 0, tkode.Text.Trim, tnama.Text.Trim, sqltrans)

                    insertview()
                End If

                dread.Close()


            Else

                ' jika rubah

                comd = New OleDbCommand(sql_update, cn, sqltrans)
                comd.ExecuteNonQuery()

                Clsmy.InsertToLog(cn, "btproyeksub", 0, 1, 0, 0, tkode.Text.Trim, tnama.Text.Trim, sqltrans)

                updateview()

            End If

            '-------------------------

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

        dv(position)("kd_sub") = tkode.Text.Trim
        dv(position)("nama_sub") = tnama.EditValue
        dv(position)("kd_group") = tkelompok.EditValue
        dv(position)("nama_group") = tkelompok.Text.Trim

    End Sub

    Private Sub insertview()

        Dim orow As DataRowView = dv.AddNew
        orow("kd_sub") = tkode.Text.Trim
        orow("nama_sub") = tnama.EditValue
        orow("kd_group") = tkelompok.EditValue
        orow("nama_group") = tkelompok.Text.Trim


        dv.EndInit()

    End Sub

    Private Sub btsimpan_Click(sender As System.Object, e As System.EventArgs) Handles btsimpan.Click


        If tkode.Text.Trim.Length = 0 Then
            MsgBox("Kode tidak boleh kosong...", vbOKOnly + vbExclamation, "Informasi")
            tkode.Focus()
            Return
        End If

        If tnama.Text.Trim.Length = 0 Then
            MsgBox("Nama barang tidak boleh kosong...", vbOKOnly + vbExclamation, "Informasi")
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

        isi_kelompok()
        tkelompok.ItemIndex = 0

        If addstat = True Then

            tkode.Enabled = True
            kosongkan()

        Else
            tkode.Enabled = False
            isi()

        End If

    End Sub


End Class