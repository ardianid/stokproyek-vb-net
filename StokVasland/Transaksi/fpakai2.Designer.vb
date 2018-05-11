<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fpakai2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fpakai2))
        Me.tbukti = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.ttgl2 = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.ttgl = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.tperlu = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.tjawab = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
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
        Me.LabelControl20 = New DevExpress.XtraEditors.LabelControl()
        Me.bts_proyek = New DevExpress.XtraEditors.SimpleButton()
        Me.tnama_proyek = New DevExpress.XtraEditors.TextEdit()
        Me.tkode_proyek = New DevExpress.XtraEditors.TextEdit()
        Me.tnama_sub = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.tket = New DevExpress.XtraEditors.MemoEdit()
        Me.tkode_sub = New DevExpress.XtraEditors.TextEdit()
        CType(Me.tbukti.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tperlu.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tjawab.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.r_barang1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.r_barang2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.r_satuan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnama_proyek.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkode_proyek.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnama_sub.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tket.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkode_sub.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbukti
        '
        Me.tbukti.Location = New System.Drawing.Point(83, 12)
        Me.tbukti.Name = "tbukti"
        Me.tbukti.Properties.ReadOnly = True
        Me.tbukti.Size = New System.Drawing.Size(116, 20)
        Me.tbukti.TabIndex = 167
        '
        'LabelControl15
        '
        Me.LabelControl15.Location = New System.Drawing.Point(31, 15)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl15.TabIndex = 168
        Me.LabelControl15.Text = "No Bukti :"
        '
        'ttgl2
        '
        Me.ttgl2.EditValue = Nothing
        Me.ttgl2.Location = New System.Drawing.Point(83, 64)
        Me.ttgl2.Name = "ttgl2"
        Me.ttgl2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ttgl2.Properties.Mask.EditMask = ""
        Me.ttgl2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.ttgl2.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ttgl2.Size = New System.Drawing.Size(116, 20)
        Me.ttgl2.TabIndex = 1
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(28, 67)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl5.TabIndex = 175
        Me.LabelControl5.Text = "Tgl Ambil :"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(32, 41)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl4.TabIndex = 174
        Me.LabelControl4.Text = "Tanggal :"
        '
        'ttgl
        '
        Me.ttgl.EditValue = Nothing
        Me.ttgl.Location = New System.Drawing.Point(83, 38)
        Me.ttgl.Name = "ttgl"
        Me.ttgl.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ttgl.Properties.Mask.EditMask = ""
        Me.ttgl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.ttgl.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ttgl.Size = New System.Drawing.Size(116, 20)
        Me.ttgl.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(408, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl1.TabIndex = 176
        Me.LabelControl1.Text = "Keperluan :"
        '
        'tperlu
        '
        Me.tperlu.Location = New System.Drawing.Point(469, 12)
        Me.tperlu.Name = "tperlu"
        Me.tperlu.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tperlu.Size = New System.Drawing.Size(254, 20)
        Me.tperlu.TabIndex = 4
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(416, 41)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl2.TabIndex = 178
        Me.LabelControl2.Text = "P Jawab :"
        '
        'tjawab
        '
        Me.tjawab.Location = New System.Drawing.Point(469, 38)
        Me.tjawab.Name = "tjawab"
        Me.tjawab.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tjawab.Size = New System.Drawing.Size(254, 20)
        Me.tjawab.TabIndex = 5
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(400, 67)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl3.TabIndex = 180
        Me.LabelControl3.Text = "Keterangan :"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Location = New System.Drawing.Point(11, 141)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(724, 259)
        Me.XtraTabControl1.TabIndex = 7
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.grid1)
        Me.XtraTabPage1.Controls.Add(Me.btadd)
        Me.XtraTabPage1.Controls.Add(Me.btdel)
        Me.XtraTabPage1.Controls.Add(Me.btedit)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(718, 231)
        Me.XtraTabPage1.Text = "Barang"
        '
        'grid1
        '
        Me.grid1.Location = New System.Drawing.Point(5, 3)
        Me.grid1.MainView = Me.GridView1
        Me.grid1.Name = "grid1"
        Me.grid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.r_barang1, Me.r_barang2, Me.r_satuan})
        Me.grid1.Size = New System.Drawing.Size(708, 195)
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
        Me.GridColumn1.Width = 56
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Nama"
        Me.GridColumn2.FieldName = "nama_barang"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 354
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
        Me.GridColumn3.Width = 74
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Satuan"
        Me.GridColumn5.FieldName = "satuan"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 95
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
        Me.btadd.Location = New System.Drawing.Point(5, 203)
        Me.btadd.Name = "btadd"
        Me.btadd.Size = New System.Drawing.Size(66, 20)
        Me.btadd.TabIndex = 1
        Me.btadd.Text = "&Tambah"
        Me.btadd.ToolTip = "Tambah Barang"
        '
        'btdel
        '
        Me.btdel.Image = CType(resources.GetObject("btdel.Image"), System.Drawing.Image)
        Me.btdel.Location = New System.Drawing.Point(77, 203)
        Me.btdel.Name = "btdel"
        Me.btdel.Size = New System.Drawing.Size(66, 20)
        Me.btdel.TabIndex = 2
        Me.btdel.Text = "&Hapus"
        Me.btdel.ToolTip = "Hapus Barang"
        '
        'btedit
        '
        Me.btedit.Image = CType(resources.GetObject("btedit.Image"), System.Drawing.Image)
        Me.btedit.Location = New System.Drawing.Point(754, 196)
        Me.btedit.Name = "btedit"
        Me.btedit.Size = New System.Drawing.Size(66, 20)
        Me.btedit.TabIndex = 192
        Me.btedit.Text = "&Edit"
        Me.btedit.ToolTip = "Edit Barang"
        Me.btedit.Visible = False
        '
        'btclose
        '
        Me.btclose.Location = New System.Drawing.Point(660, 402)
        Me.btclose.Name = "btclose"
        Me.btclose.Size = New System.Drawing.Size(70, 30)
        Me.btclose.TabIndex = 9
        Me.btclose.Text = "&Keluar"
        '
        'btsimpan
        '
        Me.btsimpan.Location = New System.Drawing.Point(584, 402)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(70, 30)
        Me.btsimpan.TabIndex = 8
        Me.btsimpan.Text = "&Simpan"
        '
        'LabelControl20
        '
        Me.LabelControl20.Location = New System.Drawing.Point(37, 118)
        Me.LabelControl20.Name = "LabelControl20"
        Me.LabelControl20.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl20.TabIndex = 182
        Me.LabelControl20.Text = "Proyek :"
        '
        'bts_proyek
        '
        Me.bts_proyek.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bts_proyek.Appearance.Options.UseFont = True
        Me.bts_proyek.Image = CType(resources.GetObject("bts_proyek.Image"), System.Drawing.Image)
        Me.bts_proyek.Location = New System.Drawing.Point(343, 89)
        Me.bts_proyek.Name = "bts_proyek"
        Me.bts_proyek.Size = New System.Drawing.Size(25, 21)
        Me.bts_proyek.TabIndex = 192
        '
        'tnama_proyek
        '
        Me.tnama_proyek.Enabled = False
        Me.tnama_proyek.Location = New System.Drawing.Point(132, 90)
        Me.tnama_proyek.Name = "tnama_proyek"
        Me.tnama_proyek.Size = New System.Drawing.Size(205, 20)
        Me.tnama_proyek.TabIndex = 193
        '
        'tkode_proyek
        '
        Me.tkode_proyek.Location = New System.Drawing.Point(83, 90)
        Me.tkode_proyek.Name = "tkode_proyek"
        Me.tkode_proyek.Size = New System.Drawing.Size(45, 20)
        Me.tkode_proyek.TabIndex = 2
        '
        'tnama_sub
        '
        Me.tnama_sub.Enabled = False
        Me.tnama_sub.Location = New System.Drawing.Point(132, 115)
        Me.tnama_sub.Name = "tnama_sub"
        Me.tnama_sub.Size = New System.Drawing.Size(205, 20)
        Me.tnama_sub.TabIndex = 197
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(16, 93)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl6.TabIndex = 194
        Me.LabelControl6.Text = "Sub Proyek :"
        '
        'tket
        '
        Me.tket.Location = New System.Drawing.Point(469, 64)
        Me.tket.Name = "tket"
        Me.tket.Size = New System.Drawing.Size(254, 71)
        Me.tket.TabIndex = 6
        '
        'tkode_sub
        '
        Me.tkode_sub.Enabled = False
        Me.tkode_sub.Location = New System.Drawing.Point(83, 115)
        Me.tkode_sub.Name = "tkode_sub"
        Me.tkode_sub.Size = New System.Drawing.Size(45, 20)
        Me.tkode_sub.TabIndex = 198
        '
        'fpakai2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 439)
        Me.Controls.Add(Me.tkode_sub)
        Me.Controls.Add(Me.tnama_sub)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.bts_proyek)
        Me.Controls.Add(Me.tnama_proyek)
        Me.Controls.Add(Me.tkode_proyek)
        Me.Controls.Add(Me.LabelControl20)
        Me.Controls.Add(Me.btclose)
        Me.Controls.Add(Me.btsimpan)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.tjawab)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.tperlu)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.ttgl2)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.ttgl)
        Me.Controls.Add(Me.tbukti)
        Me.Controls.Add(Me.LabelControl15)
        Me.Controls.Add(Me.tket)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fpakai2"
        Me.Text = "Pemakaian"
        CType(Me.tbukti.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tperlu.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tjawab.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.r_barang1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.r_barang2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.r_satuan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnama_proyek.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkode_proyek.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnama_sub.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tket.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkode_sub.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbukti As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ttgl2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ttgl As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tperlu As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tjawab As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
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
    Friend WithEvents LabelControl20 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents bts_proyek As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tnama_proyek As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tkode_proyek As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tnama_sub As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tket As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents tkode_sub As DevExpress.XtraEditors.TextEdit
End Class
