<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fbeli3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fbeli3))
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.tkode = New DevExpress.XtraEditors.TextEdit()
        Me.tnama = New DevExpress.XtraEditors.TextEdit()
        Me.bts_barang = New DevExpress.XtraEditors.SimpleButton()
        Me.tdisc_per = New DevExpress.XtraEditors.TextEdit()
        Me.tharga = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.btclose = New DevExpress.XtraEditors.SimpleButton()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.tjumlah = New DevExpress.XtraEditors.TextEdit()
        Me.tdisc_rp = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.tsat = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.tjml = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.tdisc_per2 = New DevExpress.XtraEditors.TextEdit()
        Me.tdisc_rp2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdisc_per.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tharga.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tjumlah.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdisc_rp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tsat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tjml.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdisc_per2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdisc_rp2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl15
        '
        Me.LabelControl15.Location = New System.Drawing.Point(31, 15)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl15.TabIndex = 167
        Me.LabelControl15.Text = "Barang :"
        '
        'tkode
        '
        Me.tkode.Location = New System.Drawing.Point(78, 12)
        Me.tkode.Name = "tkode"
        Me.tkode.Size = New System.Drawing.Size(45, 20)
        Me.tkode.TabIndex = 0
        '
        'tnama
        '
        Me.tnama.Enabled = False
        Me.tnama.Location = New System.Drawing.Point(127, 12)
        Me.tnama.Name = "tnama"
        Me.tnama.Size = New System.Drawing.Size(205, 20)
        Me.tnama.TabIndex = 169
        '
        'bts_barang
        '
        Me.bts_barang.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bts_barang.Appearance.Options.UseFont = True
        Me.bts_barang.Image = CType(resources.GetObject("bts_barang.Image"), System.Drawing.Image)
        Me.bts_barang.Location = New System.Drawing.Point(338, 11)
        Me.bts_barang.Name = "bts_barang"
        Me.bts_barang.Size = New System.Drawing.Size(25, 21)
        Me.bts_barang.TabIndex = 176
        '
        'tdisc_per
        '
        Me.tdisc_per.EditValue = "0"
        Me.tdisc_per.Location = New System.Drawing.Point(78, 108)
        Me.tdisc_per.Name = "tdisc_per"
        Me.tdisc_per.Properties.Mask.EditMask = "n"
        Me.tdisc_per.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tdisc_per.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tdisc_per.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tdisc_per.Size = New System.Drawing.Size(45, 20)
        Me.tdisc_per.TabIndex = 4
        '
        'tharga
        '
        Me.tharga.EditValue = "0"
        Me.tharga.Location = New System.Drawing.Point(78, 84)
        Me.tharga.Name = "tharga"
        Me.tharga.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tharga.Properties.Appearance.Options.UseFont = True
        Me.tharga.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tharga.Properties.Mask.EditMask = "n0"
        Me.tharga.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tharga.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tharga.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tharga.Size = New System.Drawing.Size(254, 20)
        Me.tharga.TabIndex = 3
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(36, 87)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl8.TabIndex = 190
        Me.LabelControl8.Text = "Harga :"
        '
        'btclose
        '
        Me.btclose.Location = New System.Drawing.Point(296, 197)
        Me.btclose.Name = "btclose"
        Me.btclose.Size = New System.Drawing.Size(67, 23)
        Me.btclose.TabIndex = 10
        Me.btclose.Text = "&Keluar"
        '
        'btsimpan
        '
        Me.btsimpan.Location = New System.Drawing.Point(223, 197)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(67, 23)
        Me.btsimpan.TabIndex = 9
        Me.btsimpan.Text = "&Simpan"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(32, 160)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl6.TabIndex = 189
        Me.LabelControl6.Text = "Jumlah :"
        '
        'tjumlah
        '
        Me.tjumlah.EditValue = "0"
        Me.tjumlah.Location = New System.Drawing.Point(78, 157)
        Me.tjumlah.Name = "tjumlah"
        Me.tjumlah.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tjumlah.Properties.Appearance.Options.UseFont = True
        Me.tjumlah.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tjumlah.Properties.Mask.EditMask = "n0"
        Me.tjumlah.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tjumlah.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tjumlah.Properties.ReadOnly = True
        Me.tjumlah.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tjumlah.Size = New System.Drawing.Size(254, 20)
        Me.tjumlah.TabIndex = 8
        '
        'tdisc_rp
        '
        Me.tdisc_rp.EditValue = "0"
        Me.tdisc_rp.Location = New System.Drawing.Point(142, 108)
        Me.tdisc_rp.Name = "tdisc_rp"
        Me.tdisc_rp.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tdisc_rp.Properties.Appearance.Options.UseFont = True
        Me.tdisc_rp.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tdisc_rp.Properties.Mask.EditMask = "n0"
        Me.tdisc_rp.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tdisc_rp.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tdisc_rp.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tdisc_rp.Size = New System.Drawing.Size(190, 20)
        Me.tdisc_rp.TabIndex = 5
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Location = New System.Drawing.Point(126, 112)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(13, 13)
        Me.LabelControl12.TabIndex = 187
        Me.LabelControl12.Text = "%"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(39, 111)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl5.TabIndex = 186
        Me.LabelControl5.Text = "Disc I :"
        '
        'tsat
        '
        Me.tsat.Location = New System.Drawing.Point(78, 61)
        Me.tsat.Name = "tsat"
        Me.tsat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.tsat.Size = New System.Drawing.Size(254, 20)
        Me.tsat.TabIndex = 2
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(31, 64)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl4.TabIndex = 185
        Me.LabelControl4.Text = "Satuan :"
        '
        'tjml
        '
        Me.tjml.EditValue = "0"
        Me.tjml.Location = New System.Drawing.Point(78, 38)
        Me.tjml.Name = "tjml"
        Me.tjml.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tjml.Properties.Appearance.Options.UseFont = True
        Me.tjml.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tjml.Properties.Mask.EditMask = "n0"
        Me.tjml.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tjml.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tjml.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tjml.Size = New System.Drawing.Size(254, 20)
        Me.tjml.TabIndex = 1
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(50, 41)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl3.TabIndex = 179
        Me.LabelControl3.Text = "Jml :"
        '
        'tdisc_per2
        '
        Me.tdisc_per2.EditValue = "0"
        Me.tdisc_per2.Location = New System.Drawing.Point(78, 134)
        Me.tdisc_per2.Name = "tdisc_per2"
        Me.tdisc_per2.Properties.Mask.EditMask = "n"
        Me.tdisc_per2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tdisc_per2.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tdisc_per2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tdisc_per2.Size = New System.Drawing.Size(45, 20)
        Me.tdisc_per2.TabIndex = 6
        '
        'tdisc_rp2
        '
        Me.tdisc_rp2.EditValue = "0"
        Me.tdisc_rp2.Location = New System.Drawing.Point(142, 134)
        Me.tdisc_rp2.Name = "tdisc_rp2"
        Me.tdisc_rp2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tdisc_rp2.Properties.Appearance.Options.UseFont = True
        Me.tdisc_rp2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tdisc_rp2.Properties.Mask.EditMask = "n0"
        Me.tdisc_rp2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tdisc_rp2.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tdisc_rp2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tdisc_rp2.Size = New System.Drawing.Size(190, 20)
        Me.tdisc_rp2.TabIndex = 7
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(126, 138)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(13, 13)
        Me.LabelControl1.TabIndex = 194
        Me.LabelControl1.Text = "%"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(35, 137)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl2.TabIndex = 193
        Me.LabelControl2.Text = "Disc II :"
        '
        'fbeli3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 232)
        Me.Controls.Add(Me.tdisc_per2)
        Me.Controls.Add(Me.tdisc_rp2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.tdisc_per)
        Me.Controls.Add(Me.tharga)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.btclose)
        Me.Controls.Add(Me.btsimpan)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.tjumlah)
        Me.Controls.Add(Me.tdisc_rp)
        Me.Controls.Add(Me.LabelControl12)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.tsat)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.tjml)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.bts_barang)
        Me.Controls.Add(Me.tnama)
        Me.Controls.Add(Me.tkode)
        Me.Controls.Add(Me.LabelControl15)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fbeli3"
        Me.Text = "Pembelian"
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdisc_per.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tharga.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tjumlah.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdisc_rp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tsat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tjml.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdisc_per2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdisc_rp2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tkode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tnama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents bts_barang As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tdisc_per As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tharga As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btclose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tjumlah As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tdisc_rp As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tsat As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tjml As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tdisc_per2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tdisc_rp2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
End Class
