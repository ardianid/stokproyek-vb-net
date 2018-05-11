<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fpesan_beli2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fpesan_beli2))
        Me.talamat_toko = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.bts_toko = New DevExpress.XtraEditors.SimpleButton()
        Me.tnama_toko = New DevExpress.XtraEditors.TextEdit()
        Me.tkd_toko = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.tbukti = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.ttgl = New DevExpress.XtraEditors.DateEdit()
        Me.tnote = New DevExpress.XtraEditors.MemoEdit()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.grid1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.r_barang1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.r_barang2 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.r_satuan = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.btadd = New DevExpress.XtraEditors.SimpleButton()
        Me.btdel = New DevExpress.XtraEditors.SimpleButton()
        Me.btedit = New DevExpress.XtraEditors.SimpleButton()
        Me.btclose = New DevExpress.XtraEditors.SimpleButton()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.talamat_toko.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnama_toko.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkd_toko.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbukti.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.r_barang1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.r_barang2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.r_satuan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'talamat_toko
        '
        Me.talamat_toko.Location = New System.Drawing.Point(310, 36)
        Me.talamat_toko.Name = "talamat_toko"
        Me.talamat_toko.Properties.ReadOnly = True
        Me.talamat_toko.Size = New System.Drawing.Size(280, 35)
        Me.talamat_toko.TabIndex = 184
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(264, 41)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl3.TabIndex = 185
        Me.LabelControl3.Text = "Alamat :"
        '
        'bts_toko
        '
        Me.bts_toko.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bts_toko.Appearance.Options.UseFont = True
        Me.bts_toko.Image = CType(resources.GetObject("bts_toko.Image"), System.Drawing.Image)
        Me.bts_toko.Location = New System.Drawing.Point(565, 12)
        Me.bts_toko.Name = "bts_toko"
        Me.bts_toko.Size = New System.Drawing.Size(25, 21)
        Me.bts_toko.TabIndex = 183
        '
        'tnama_toko
        '
        Me.tnama_toko.Enabled = False
        Me.tnama_toko.Location = New System.Drawing.Point(356, 12)
        Me.tnama_toko.Name = "tnama_toko"
        Me.tnama_toko.Size = New System.Drawing.Size(203, 20)
        Me.tnama_toko.TabIndex = 182
        '
        'tkd_toko
        '
        Me.tkd_toko.Location = New System.Drawing.Point(310, 12)
        Me.tkd_toko.Name = "tkd_toko"
        Me.tkd_toko.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tkd_toko.Size = New System.Drawing.Size(44, 20)
        Me.tkd_toko.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(267, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl2.TabIndex = 181
        Me.LabelControl2.Text = "Outlet :"
        '
        'tbukti
        '
        Me.tbukti.Location = New System.Drawing.Point(65, 12)
        Me.tbukti.Name = "tbukti"
        Me.tbukti.Properties.ReadOnly = True
        Me.tbukti.Size = New System.Drawing.Size(116, 20)
        Me.tbukti.TabIndex = 179
        '
        'LabelControl15
        '
        Me.LabelControl15.Location = New System.Drawing.Point(13, 15)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl15.TabIndex = 180
        Me.LabelControl15.Text = "No Bukti :"
        '
        'LabelControl14
        '
        Me.LabelControl14.Location = New System.Drawing.Point(29, 284)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl14.TabIndex = 189
        Me.LabelControl14.Text = "Ket :"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(14, 41)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl4.TabIndex = 188
        Me.LabelControl4.Text = "Tanggal :"
        '
        'ttgl
        '
        Me.ttgl.EditValue = Nothing
        Me.ttgl.Location = New System.Drawing.Point(65, 38)
        Me.ttgl.Name = "ttgl"
        Me.ttgl.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ttgl.Properties.Mask.EditMask = ""
        Me.ttgl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.ttgl.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ttgl.Size = New System.Drawing.Size(116, 20)
        Me.ttgl.TabIndex = 0
        '
        'tnote
        '
        Me.tnote.Location = New System.Drawing.Point(65, 281)
        Me.tnote.Name = "tnote"
        Me.tnote.Size = New System.Drawing.Size(263, 42)
        Me.tnote.TabIndex = 3
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Location = New System.Drawing.Point(12, 77)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(583, 198)
        Me.XtraTabControl1.TabIndex = 2
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.grid1)
        Me.XtraTabPage1.Controls.Add(Me.btadd)
        Me.XtraTabPage1.Controls.Add(Me.btdel)
        Me.XtraTabPage1.Controls.Add(Me.btedit)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(577, 170)
        Me.XtraTabPage1.Text = "Barang"
        '
        'grid1
        '
        Me.grid1.Location = New System.Drawing.Point(2, 2)
        Me.grid1.MainView = Me.GridView1
        Me.grid1.Name = "grid1"
        Me.grid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.r_barang1, Me.r_barang2, Me.r_satuan})
        Me.grid1.Size = New System.Drawing.Size(597, 139)
        Me.grid1.TabIndex = 182
        Me.grid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn5})
        Me.GridView1.GridControl = Me.grid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Kode"
        Me.GridColumn1.FieldName = "kd_barang"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 50
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Nama"
        Me.GridColumn2.FieldName = "nama_barang"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 198
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn3.Caption = "Jml"
        Me.GridColumn3.DisplayFormat.FormatString = "n0"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.FieldName = "qty"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 42
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Satuan"
        Me.GridColumn5.FieldName = "satuan"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 51
        '
        'r_barang1
        '
        Me.r_barang1.AutoHeight = False
        Me.r_barang1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.r_barang1.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("kd_barang", 7, "Kode"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nama_barang", "Nama")})
        Me.r_barang1.DisplayMember = "kd_barang"
        Me.r_barang1.Name = "r_barang1"
        Me.r_barang1.ShowFooter = False
        Me.r_barang1.ShowHeader = False
        Me.r_barang1.ShowLines = False
        Me.r_barang1.ValueMember = "kd_barang"
        '
        'r_barang2
        '
        Me.r_barang2.AutoHeight = False
        Me.r_barang2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.r_barang2.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nama_barang", "Nama")})
        Me.r_barang2.DisplayMember = "nama_barang"
        Me.r_barang2.Name = "r_barang2"
        Me.r_barang2.ShowFooter = False
        Me.r_barang2.ShowHeader = False
        Me.r_barang2.ShowLines = False
        Me.r_barang2.ValueMember = "nama_barang"
        '
        'r_satuan
        '
        Me.r_satuan.AutoHeight = False
        Me.r_satuan.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.r_satuan.Name = "r_satuan"
        '
        'btadd
        '
        Me.btadd.Image = CType(resources.GetObject("btadd.Image"), System.Drawing.Image)
        Me.btadd.Location = New System.Drawing.Point(3, 147)
        Me.btadd.Name = "btadd"
        Me.btadd.Size = New System.Drawing.Size(66, 20)
        Me.btadd.TabIndex = 0
        Me.btadd.Text = "&Tambah"
        Me.btadd.ToolTip = "Tambah Barang"
        '
        'btdel
        '
        Me.btdel.Image = CType(resources.GetObject("btdel.Image"), System.Drawing.Image)
        Me.btdel.Location = New System.Drawing.Point(75, 147)
        Me.btdel.Name = "btdel"
        Me.btdel.Size = New System.Drawing.Size(66, 20)
        Me.btdel.TabIndex = 1
        Me.btdel.Text = "&Hapus"
        Me.btdel.ToolTip = "Hapus Barang"
        '
        'btedit
        '
        Me.btedit.Image = CType(resources.GetObject("btedit.Image"), System.Drawing.Image)
        Me.btedit.Location = New System.Drawing.Point(532, 147)
        Me.btedit.Name = "btedit"
        Me.btedit.Size = New System.Drawing.Size(66, 20)
        Me.btedit.TabIndex = 192
        Me.btedit.Text = "&Edit"
        Me.btedit.ToolTip = "Edit Barang"
        Me.btedit.Visible = False
        '
        'btclose
        '
        Me.btclose.Location = New System.Drawing.Point(520, 290)
        Me.btclose.Name = "btclose"
        Me.btclose.Size = New System.Drawing.Size(70, 33)
        Me.btclose.TabIndex = 5
        Me.btclose.Text = "&Keluar"
        '
        'btsimpan
        '
        Me.btsimpan.Location = New System.Drawing.Point(444, 290)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(70, 33)
        Me.btsimpan.TabIndex = 4
        Me.btsimpan.Text = "&Simpan"
        '
        'fpesan_beli2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 334)
        Me.Controls.Add(Me.btclose)
        Me.Controls.Add(Me.btsimpan)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.LabelControl14)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.ttgl)
        Me.Controls.Add(Me.talamat_toko)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.bts_toko)
        Me.Controls.Add(Me.tnama_toko)
        Me.Controls.Add(Me.tkd_toko)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.tbukti)
        Me.Controls.Add(Me.LabelControl15)
        Me.Controls.Add(Me.tnote)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fpesan_beli2"
        Me.Text = "Pesanan Pembelian"
        CType(Me.talamat_toko.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnama_toko.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkd_toko.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbukti.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.r_barang1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.r_barang2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.r_satuan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents talamat_toko As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents bts_toko As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tnama_toko As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tkd_toko As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbukti As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ttgl As DevExpress.XtraEditors.DateEdit
    Friend WithEvents tnote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents grid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents r_barang1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents r_barang2 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents r_satuan As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents btadd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btdel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btedit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btclose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
End Class
