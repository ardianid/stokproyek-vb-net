Imports DevExpress.XtraSplashScreen
Imports System.Globalization

Imports System.Windows.Forms
Imports System.Reflection

Imports System.Data
Imports System.Data.OleDb
Imports StokVasland.Clsmy

Module Mdlmy

    Public userprog, pwd As String
    Public initial_user As String
    Public dtmenu As DataTable
    Public dtmenu2 As DataTable

    Public tglperiod1, tglperiod2 As String

    Public dsinvoice_ku As DataSet

    '    Private Dlg As DevExpress.Utils.WaitDialogForm = Nothing

    Public Class ObjectFinder
        Public Shared Function CreateObjectInstance(ByVal objectName As String) As Object
            ' Creates and returns an instance of any object in the assembly by its type name.

            Dim obj As Object

            Try
                If objectName.LastIndexOf(".") = -1 Then
                    'Appends the root namespace if not specified.
                    objectName = String.Format("{0}.{1}", [Assembly].GetEntryAssembly.GetName.Name, objectName)
                End If

                obj = [Assembly].GetEntryAssembly.CreateInstance(objectName)

            Catch ex As Exception
                obj = Nothing
            End Try
            Return obj

        End Function

        Public Shared Function CreateForm(ByVal formName As String) As Form
            ' Return the instance of the form by specifying its name.
            Return DirectCast(CreateObjectInstance(formName), Form)
        End Function

    End Class

    Public Sub open_wait()

        SplashScreenManager.ShowForm(futama, GetType(waitf), True, True, False)
        ' SplashScreenManager.Default.SetWaitFormDescription("lagi ngetest")

        '  Dlg = New DevExpress.Utils.WaitDialogForm("Loading Components...")
    End Sub

    Public Sub open_wait(ByVal capt As String)

        SplashScreenManager.ShowForm(futama, GetType(waitf), True, True, False)
        SplashScreenManager.Default.SetWaitFormDescription(capt)

        '  Dlg = New DevExpress.Utils.WaitDialogForm("Loading Components...")
    End Sub

    Public Sub SetWaitDialog(ByVal capt As String)

        ' SplashScreenManager.ShowForm(futama, GetType(waitf), True, True, False)
        SplashScreenManager.Default.SetWaitFormDescription(capt)

        '  Dlg = New DevExpress.Utils.WaitDialogForm("Loading Components...")
    End Sub

    Public Sub open_wait2(ByVal formm As Form)
        SplashScreenManager.ShowForm(formm, GetType(waitf), True, True, False)
    End Sub

    Public Sub close_wait()
        SplashScreenManager.CloseForm(False)
    End Sub

    Public Function convert_date_to_eng(ByVal valdate As String) As String

        If valdate = "" Then
            Return ""
        End If

        valdate = CType(valdate, DateTime).ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US"))

        Return valdate

    End Function

    Public Function convert_datetime_to_eng(ByVal valdate As String) As String

        If valdate = "" Then
            Return ""
        End If

        valdate = CType(valdate, DateTime).ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US"))

        Return valdate

    End Function

    Public Function convert_date_to_ind(ByVal valdate As String) As String

        If valdate = "" Then
            Return ""
        End If

        valdate = CType(valdate, Date).ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("id-ID"))

        Return valdate

    End Function

    Public Function PlusMin_Barang(ByVal cn As OleDbConnection, ByVal sqltrans As OleDbTransaction, ByVal qtykecil As Integer, _
                                   ByVal kdbar As String, ByVal additem As Boolean) As String

        Dim cmdcek_brang As OleDbCommand
        Dim drd_barang As OleDbDataReader

        Dim sqlcekbarang As String = String.Format("select b.jmlstok1,b.jmlstok2, b.kd_barang,b.jmlstok,b.qty1,b.qty2,1 as qty3 from ms_barang b where b.kd_barang='{0}'", kdbar)
        cmdcek_brang = New OleDbCommand(sqlcekbarang, cn, sqltrans)
        drd_barang = cmdcek_brang.ExecuteReader

        Dim konferror As String = ""

        If drd_barang.HasRows Then
            If drd_barang.Read Then
                If Not drd_barang("kd_barang").ToString.Equals("") Then

                    Dim jmlstok As Integer = Integer.Parse(drd_barang("jmlstok").ToString)

                    Dim qty1 As Integer = Integer.Parse(drd_barang("qty1").ToString)
                    Dim qty2 As Integer = Integer.Parse(drd_barang("qty2").ToString)
                    Dim qty3 As Integer = Integer.Parse(drd_barang("qty3").ToString)


                    Dim jstok1 As Integer = Integer.Parse(drd_barang("jmlstok1").ToString)
                    Dim jstok2 As Integer = Integer.Parse(drd_barang("jmlstok2").ToString)

                    If jstok1 = 0 And jstok2 = 0 And jmlstok > 0 Then
                        konferror = kdbar & " tidak sesuai antara stok (1-2)=(0)"
                        GoTo langsung_out
                    End If

                    Dim jml1, jml2, jml3 As Integer

                    Dim totqty As Integer = qty1 * qty2 * qty3

                    If additem = True Then

                        jmlstok = jmlstok + qtykecil

                    Else

                        If jmlstok < qtykecil Then
                            konferror = kdbar & " melebihi stok yang ada..."
                        End If

                        jmlstok = jmlstok - qtykecil

                    End If

                    ' by gudang

                    If jmlstok >= totqty Then

                        Dim sisa As Integer = jmlstok Mod totqty

                        jml1 = (jmlstok - sisa) / totqty

                        If sisa > qty2 Then
                            jml2 = sisa
                            sisa = sisa Mod qty2

                            jml2 = (jml2 - sisa) / qty2
                            jml3 = sisa

                        Else
                            jml2 = sisa
                            jml3 = 0
                        End If
                    Else
                        jml1 = 0
                        jml2 = jmlstok
                        jml3 = 0
                    End If


                    If konferror.Equals("") Then

                        Dim sqlup As String = String.Format("update ms_barang set jmlstok1={0},jmlstok2={1},jmlstok={2} where kd_barang='{3}'", jml1, jml2, jmlstok, kdbar)

                        Using cmd2 As OleDbCommand = New OleDbCommand(sqlup, cn, sqltrans)
                            cmd2.ExecuteNonQuery()
                        End Using

                        konferror = "ok"

                    End If

                Else

                    konferror = kdbar & " tidak ditemukan..."

                End If
            Else
                konferror = kdbar & " tidak ditemukan..."
            End If
        Else
            konferror = kdbar & " tidak ditemukan..."
        End If

langsung_out:

        drd_barang.Close()

        Return konferror

    End Function

    Public Function PlusMin_Barang_Adj(ByVal cn As OleDbConnection, ByVal sqltrans As OleDbTransaction, ByVal qtykecil As Integer, ByVal qtyselisih As Integer, _
                               ByVal kdbar As String, ByVal additem As Boolean) As String

        Dim cmdcek_brang As OleDbCommand
        Dim drd_barang As OleDbDataReader

        Dim sqlcekbarang As String = String.Format("select b.kd_barang,b.jmlstok,b.qty1,b.qty2,1 as qty3 from ms_barang b where b.kd_barang='{0}'", kdbar)
        cmdcek_brang = New OleDbCommand(sqlcekbarang, cn, sqltrans)
        drd_barang = cmdcek_brang.ExecuteReader

        Dim konferror As String = ""

        If drd_barang.HasRows Then
            If drd_barang.Read Then
                If Not drd_barang("kd_barang").ToString.Equals("") Then


                    Dim jmlstok As Integer = Integer.Parse(drd_barang("jmlstok").ToString)
                    Dim jmlstok1 As Integer = 0

                    Dim qty1 As Integer = Integer.Parse(drd_barang("qty1").ToString)
                    Dim qty2 As Integer = Integer.Parse(drd_barang("qty2").ToString)
                    Dim qty3 As Integer = Integer.Parse(drd_barang("qty3").ToString)

                     Dim jml1, jml2, jml3 As Integer

                    Dim totqty As Integer = qty1 * qty2 * qty3

                    If additem = True Then

                        '   jmlstok1 = jmlstok - qtykecil
                        jmlstok = jmlstok + qtyselisih

                    Else

                        'If jmlstok < qtykecil Then
                        '    konferror = kdbar & " melebihi stok yang ada..."
                        'End If

                        jmlstok = jmlstok - qtyselisih


                    End If

                    ' by item

                    If jmlstok >= totqty Then

                        Dim sisa As Integer = jmlstok Mod totqty

                        jml1 = (jmlstok - sisa) / totqty

                        If sisa > qty2 Then
                            jml2 = sisa
                            sisa = sisa Mod qty2

                            jml2 = (jml2 - sisa) / qty2
                            jml3 = sisa

                        Else
                            jml2 = sisa
                            jml3 = 0
                        End If
                    End If

                    ' end by item                   


                    If konferror.Equals("") Then

                        Dim sqlup As String = String.Format("update ms_barang set jmlstok1={0},jmlstok2={1},jmlstok={2} where kd_barang='{3}'", jml1, jml2, jmlstok, kdbar)

                        Using cmd2 As OleDbCommand = New OleDbCommand(sqlup, cn, sqltrans)
                            cmd2.ExecuteNonQuery()
                        End Using

                        konferror = "ok"

                    End If

                    konferror = "ok"



                Else

                    konferror = kdbar & " tidak ditemukan..."

                End If
            Else
                konferror = kdbar & " tidak ditemukan..."
            End If
        Else
            konferror = kdbar & " tidak ditemukan..."
        End If

        drd_barang.Close()

        Return konferror

    End Function


End Module
