<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class futama
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(futama))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.mfile = New DevExpress.XtraBars.BarSubItem()
        Me.btnuser = New DevExpress.XtraBars.BarButtonItem()
        Me.NO_sm_rubahpwd = New DevExpress.XtraBars.BarButtonItem()
        Me.NO_sm_logoff = New DevExpress.XtraBars.BarButtonItem()
        Me.mmaster = New DevExpress.XtraBars.BarSubItem()
        Me.btpenjual = New DevExpress.XtraBars.BarButtonItem()
        Me.btkelompok = New DevExpress.XtraBars.BarButtonItem()
        Me.btbarang = New DevExpress.XtraBars.BarButtonItem()
        Me.btproyek = New DevExpress.XtraBars.BarButtonItem()
        Me.btproyeksub = New DevExpress.XtraBars.BarButtonItem()
        Me.btperusahaan = New DevExpress.XtraBars.BarButtonItem()
        Me.mtrans = New DevExpress.XtraBars.BarSubItem()
        Me.btpesanbeli = New DevExpress.XtraBars.BarButtonItem()
        Me.btbeli = New DevExpress.XtraBars.BarButtonItem()
        Me.btpakai = New DevExpress.XtraBars.BarButtonItem()
        Me.btretur = New DevExpress.XtraBars.BarButtonItem()
        Me.btopname = New DevExpress.XtraBars.BarButtonItem()
        Me.NO_mslaporan = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.bar_tgl = New DevExpress.XtraBars.BarStaticItem()
        Me.bar_jam = New DevExpress.XtraBars.BarStaticItem()
        Me.bar_user = New DevExpress.XtraBars.BarStaticItem()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btmesin = New DevExpress.XtraBars.BarButtonItem()
        Me.btformula = New DevExpress.XtraBars.BarButtonItem()
        Me.sm_produksi = New DevExpress.XtraBars.BarButtonItem()
        Me.sm_bayarhut = New DevExpress.XtraBars.BarButtonItem()
        Me.sm_bayarpiut = New DevExpress.XtraBars.BarButtonItem()
        Me.BarStaticItem1 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarLargeButtonItem1 = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.BarStaticItem2 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem3 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarHeaderItem1 = New DevExpress.XtraBars.BarHeaderItem()
        Me.BarLargeButtonItem2 = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.XtraTabbedMdiManager1 = New DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(Me.components)
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NO_sm_laptran = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2, Me.Bar3, Me.Bar1})
        Me.BarManager1.Categories.AddRange(New DevExpress.XtraBars.BarManagerCategory() {New DevExpress.XtraBars.BarManagerCategory("Menu1", New System.Guid("bcb5f241-7d09-4d0f-bf30-b05de12cd184")), New DevExpress.XtraBars.BarManagerCategory("menu2", New System.Guid("17480772-4925-45a2-8439-eaba59fed3a2"))})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Images = Me.ImageList1
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.mfile, Me.mmaster, Me.mtrans, Me.NO_sm_logoff, Me.btnuser, Me.NO_sm_rubahpwd, Me.btmesin, Me.btpenjual, Me.btbarang, Me.btformula, Me.btbeli, Me.btpakai, Me.sm_produksi, Me.sm_bayarhut, Me.sm_bayarpiut, Me.bar_tgl, Me.bar_jam, Me.bar_user, Me.NO_mslaporan, Me.btopname, Me.btkelompok, Me.btpesanbeli, Me.btproyek, Me.btproyeksub, Me.btretur, Me.BarStaticItem1, Me.BarLargeButtonItem1, Me.BarStaticItem2, Me.BarStaticItem3, Me.BarHeaderItem1, Me.BarLargeButtonItem2, Me.btperusahaan})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 48
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.mfile), New DevExpress.XtraBars.LinkPersistInfo(Me.mmaster), New DevExpress.XtraBars.LinkPersistInfo(Me.mtrans)})
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'mfile
        '
        Me.mfile.Caption = "&File"
        Me.mfile.CategoryGuid = New System.Guid("bcb5f241-7d09-4d0f-bf30-b05de12cd184")
        Me.mfile.Id = 10
        Me.mfile.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnuser), New DevExpress.XtraBars.LinkPersistInfo(Me.NO_sm_rubahpwd), New DevExpress.XtraBars.LinkPersistInfo(Me.NO_sm_logoff, True)})
        Me.mfile.Name = "mfile"
        '
        'btnuser
        '
        Me.btnuser.Caption = "&User"
        Me.btnuser.Id = 17
        Me.btnuser.ImageIndex = 0
        Me.btnuser.Name = "btnuser"
        '
        'NO_sm_rubahpwd
        '
        Me.NO_sm_rubahpwd.Caption = "&Rubah Password"
        Me.NO_sm_rubahpwd.Id = 18
        Me.NO_sm_rubahpwd.ImageIndex = 8
        Me.NO_sm_rubahpwd.Name = "NO_sm_rubahpwd"
        '
        'NO_sm_logoff
        '
        Me.NO_sm_logoff.Caption = "&Log Off"
        Me.NO_sm_logoff.Id = 16
        Me.NO_sm_logoff.ImageIndex = 7
        Me.NO_sm_logoff.Name = "NO_sm_logoff"
        '
        'mmaster
        '
        Me.mmaster.Caption = "&Master"
        Me.mmaster.CategoryGuid = New System.Guid("bcb5f241-7d09-4d0f-bf30-b05de12cd184")
        Me.mmaster.Id = 12
        Me.mmaster.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btpenjual, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btkelompok, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btbarang), New DevExpress.XtraBars.LinkPersistInfo(Me.btproyek, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btproyeksub), New DevExpress.XtraBars.LinkPersistInfo(Me.btperusahaan, True)})
        Me.mmaster.Name = "mmaster"
        '
        'btpenjual
        '
        Me.btpenjual.Caption = "&Penjual"
        Me.btpenjual.Id = 20
        Me.btpenjual.ImageIndex = 6
        Me.btpenjual.Name = "btpenjual"
        '
        'btkelompok
        '
        Me.btkelompok.Caption = "&Kelompok Barang"
        Me.btkelompok.Id = 36
        Me.btkelompok.ImageIndex = 10
        Me.btkelompok.Name = "btkelompok"
        '
        'btbarang
        '
        Me.btbarang.Caption = "&Barang"
        Me.btbarang.Id = 22
        Me.btbarang.ImageIndex = 1
        Me.btbarang.Name = "btbarang"
        '
        'btproyek
        '
        Me.btproyek.Caption = "Pr&oyek"
        Me.btproyek.Id = 38
        Me.btproyek.ImageIndex = 12
        Me.btproyek.Name = "btproyek"
        '
        'btproyeksub
        '
        Me.btproyeksub.Caption = "&Sub Proyek"
        Me.btproyeksub.Id = 39
        Me.btproyeksub.ImageIndex = 13
        Me.btproyeksub.Name = "btproyeksub"
        '
        'btperusahaan
        '
        Me.btperusahaan.Caption = "Pe&rusahaan"
        Me.btperusahaan.Id = 47
        Me.btperusahaan.ImageIndex = 15
        Me.btperusahaan.Name = "btperusahaan"
        '
        'mtrans
        '
        Me.mtrans.Caption = "&Transaksi"
        Me.mtrans.CategoryGuid = New System.Guid("bcb5f241-7d09-4d0f-bf30-b05de12cd184")
        Me.mtrans.Id = 14
        Me.mtrans.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btpesanbeli, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btbeli), New DevExpress.XtraBars.LinkPersistInfo(Me.btpakai), New DevExpress.XtraBars.LinkPersistInfo(Me.btretur), New DevExpress.XtraBars.LinkPersistInfo(Me.btopname), New DevExpress.XtraBars.LinkPersistInfo(Me.NO_mslaporan, True)})
        Me.mtrans.Name = "mtrans"
        '
        'btpesanbeli
        '
        Me.btpesanbeli.Caption = "Pe&sanan Pembelian"
        Me.btpesanbeli.Id = 37
        Me.btpesanbeli.ImageIndex = 11
        Me.btpesanbeli.Name = "btpesanbeli"
        '
        'btbeli
        '
        Me.btbeli.Caption = "&Pembelian"
        Me.btbeli.Id = 25
        Me.btbeli.ImageIndex = 2
        Me.btbeli.Name = "btbeli"
        '
        'btpakai
        '
        Me.btpakai.Caption = "Pe&makaian"
        Me.btpakai.Id = 26
        Me.btpakai.ImageIndex = 4
        Me.btpakai.Name = "btpakai"
        '
        'btretur
        '
        Me.btretur.Caption = "&Pengembalian Barang"
        Me.btretur.Id = 40
        Me.btretur.ImageIndex = 14
        Me.btretur.Name = "btretur"
        '
        'btopname
        '
        Me.btopname.Caption = "&Opname"
        Me.btopname.Id = 35
        Me.btopname.ImageIndex = 9
        Me.btopname.Name = "btopname"
        '
        'NO_mslaporan
        '
        Me.NO_mslaporan.Caption = "&Laporan"
        Me.NO_mslaporan.Id = 34
        Me.NO_mslaporan.ImageIndex = 5
        Me.NO_mslaporan.Name = "NO_mslaporan"
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bar_tgl), New DevExpress.XtraBars.LinkPersistInfo(Me.bar_jam), New DevExpress.XtraBars.LinkPersistInfo(Me.bar_user)})
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Status bar"
        '
        'bar_tgl
        '
        Me.bar_tgl.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None
        Me.bar_tgl.Caption = "Tanggal :"
        Me.bar_tgl.CategoryGuid = New System.Guid("17480772-4925-45a2-8439-eaba59fed3a2")
        Me.bar_tgl.Id = 31
        Me.bar_tgl.Name = "bar_tgl"
        Me.bar_tgl.TextAlignment = System.Drawing.StringAlignment.Center
        Me.bar_tgl.Width = 100
        '
        'bar_jam
        '
        Me.bar_jam.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None
        Me.bar_jam.Caption = "Jam :"
        Me.bar_jam.CategoryGuid = New System.Guid("17480772-4925-45a2-8439-eaba59fed3a2")
        Me.bar_jam.Id = 32
        Me.bar_jam.Name = "bar_jam"
        Me.bar_jam.TextAlignment = System.Drawing.StringAlignment.Center
        Me.bar_jam.Width = 75
        '
        'bar_user
        '
        Me.bar_user.Caption = "User :"
        Me.bar_user.CategoryGuid = New System.Guid("17480772-4925-45a2-8439-eaba59fed3a2")
        Me.bar_user.Id = 33
        Me.bar_user.Name = "bar_user"
        Me.bar_user.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'Bar1
        '
        Me.Bar1.BarName = "Custom 3"
        Me.Bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 1
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.FloatLocation = New System.Drawing.Point(255, 367)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btpenjual), New DevExpress.XtraBars.LinkPersistInfo(Me.btbarang), New DevExpress.XtraBars.LinkPersistInfo(Me.btbeli)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.Text = "Custom 3"
        Me.Bar1.Visible = False
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(845, 67)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 400)
        Me.barDockControlBottom.Size = New System.Drawing.Size(845, 25)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 67)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 333)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(845, 67)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 333)
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1388230741_kontact_contacts.png")
        Me.ImageList1.Images.SetKeyName(1, "1388397910_Warehouse_icon_3D_rev.png")
        Me.ImageList1.Images.SetKeyName(2, "1389451426_purchase_order.png")
        Me.ImageList1.Images.SetKeyName(3, "1390486138_ark2.png")
        Me.ImageList1.Images.SetKeyName(4, "1390486141_upload.png")
        Me.ImageList1.Images.SetKeyName(5, "1390486294_invoice.png")
        Me.ImageList1.Images.SetKeyName(6, "1388230640_people-y.png")
        Me.ImageList1.Images.SetKeyName(7, "1390569433_switch.png")
        Me.ImageList1.Images.SetKeyName(8, "1396352665_key_go.png")
        Me.ImageList1.Images.SetKeyName(9, "1388487024_Menu Item.png")
        Me.ImageList1.Images.SetKeyName(10, "1376855536_qip_not_available.png")
        Me.ImageList1.Images.SetKeyName(11, "1391615179_date_task.png")
        Me.ImageList1.Images.SetKeyName(12, "1407912432_Database_copy_DynamoDB_Items.png")
        Me.ImageList1.Images.SetKeyName(13, "1407914921_diagram_v2-10.png")
        Me.ImageList1.Images.SetKeyName(14, "1389877675_591248-out.png")
        Me.ImageList1.Images.SetKeyName(15, "1388231516_Home.png")
        '
        'btmesin
        '
        Me.btmesin.Caption = "&Mesin"
        Me.btmesin.Id = 19
        Me.btmesin.Name = "btmesin"
        '
        'btformula
        '
        Me.btformula.Caption = "&Formula"
        Me.btformula.Id = 23
        Me.btformula.Name = "btformula"
        '
        'sm_produksi
        '
        Me.sm_produksi.Caption = "Pro&duksi"
        Me.sm_produksi.Id = 27
        Me.sm_produksi.Name = "sm_produksi"
        '
        'sm_bayarhut
        '
        Me.sm_bayarhut.Caption = "Bayar &Hutang"
        Me.sm_bayarhut.Id = 28
        Me.sm_bayarhut.Name = "sm_bayarhut"
        '
        'sm_bayarpiut
        '
        Me.sm_bayarpiut.Caption = "Bayar &Piutang"
        Me.sm_bayarpiut.Id = 29
        Me.sm_bayarpiut.Name = "sm_bayarpiut"
        '
        'BarStaticItem1
        '
        Me.BarStaticItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.BarStaticItem1.Caption = "BarStaticItem1"
        Me.BarStaticItem1.Glyph = CType(resources.GetObject("BarStaticItem1.Glyph"), System.Drawing.Image)
        Me.BarStaticItem1.Id = 41
        Me.BarStaticItem1.Name = "BarStaticItem1"
        Me.BarStaticItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption
        Me.BarStaticItem1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'BarLargeButtonItem1
        '
        Me.BarLargeButtonItem1.Caption = "BarLargeButtonItem1"
        Me.BarLargeButtonItem1.Id = 42
        Me.BarLargeButtonItem1.Name = "BarLargeButtonItem1"
        '
        'BarStaticItem2
        '
        Me.BarStaticItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.BarStaticItem2.Caption = "BarStaticItem2"
        Me.BarStaticItem2.Glyph = CType(resources.GetObject("BarStaticItem2.Glyph"), System.Drawing.Image)
        Me.BarStaticItem2.Id = 43
        Me.BarStaticItem2.Name = "BarStaticItem2"
        Me.BarStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'BarStaticItem3
        '
        Me.BarStaticItem3.Caption = "BarStaticItem3"
        Me.BarStaticItem3.Id = 44
        Me.BarStaticItem3.Name = "BarStaticItem3"
        Me.BarStaticItem3.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'BarHeaderItem1
        '
        Me.BarHeaderItem1.Caption = "BarHeaderItem1"
        Me.BarHeaderItem1.Id = 45
        Me.BarHeaderItem1.Name = "BarHeaderItem1"
        '
        'BarLargeButtonItem2
        '
        Me.BarLargeButtonItem2.Caption = "BarLargeButtonItem2"
        Me.BarLargeButtonItem2.Id = 46
        Me.BarLargeButtonItem2.Name = "BarLargeButtonItem2"
        '
        'XtraTabbedMdiManager1
        '
        Me.XtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover
        Me.XtraTabbedMdiManager1.MdiParent = Me
        '
        'DefaultLookAndFeel1
        '
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'NO_sm_laptran
        '
        Me.NO_sm_laptran.Caption = "&Laporan"
        Me.NO_sm_laptran.Id = 30
        Me.NO_sm_laptran.Name = "NO_sm_laptran"
        '
        'futama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 425)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "futama"
        Me.Text = "Stock - Vastland"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents XtraTabbedMdiManager1 As DevExpress.XtraTabbedMdi.XtraTabbedMdiManager
    Friend WithEvents mfile As DevExpress.XtraBars.BarSubItem
    Friend WithEvents NO_sm_logoff As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mmaster As DevExpress.XtraBars.BarSubItem
    Friend WithEvents mtrans As DevExpress.XtraBars.BarSubItem
    Friend WithEvents btnuser As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents NO_sm_rubahpwd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btmesin As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btpenjual As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btbarang As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btformula As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents sm_produksi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btbeli As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btpakai As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents sm_bayarhut As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents sm_bayarpiut As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bar_tgl As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bar_jam As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bar_user As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents NO_mslaporan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents NO_sm_laptran As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btopname As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btkelompok As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btpesanbeli As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btproyek As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btproyeksub As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btretur As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarStaticItem1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarLargeButtonItem1 As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents BarStaticItem2 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarStaticItem3 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarHeaderItem1 As DevExpress.XtraBars.BarHeaderItem
    Friend WithEvents BarLargeButtonItem2 As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btperusahaan As DevExpress.XtraBars.BarButtonItem
End Class
