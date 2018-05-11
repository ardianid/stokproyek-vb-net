<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fopname3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fopname3))
        Me.bts_barang = New DevExpress.XtraEditors.SimpleButton()
        Me.tnama = New DevExpress.XtraEditors.TextEdit()
        Me.tkode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.tsat1 = New DevExpress.XtraEditors.TextEdit()
        Me.tsat2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.tk1 = New DevExpress.XtraEditors.TextEdit()
        Me.tk2 = New DevExpress.XtraEditors.TextEdit()
        Me.tr1 = New DevExpress.XtraEditors.TextEdit()
        Me.tr2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.ts2 = New DevExpress.XtraEditors.TextEdit()
        Me.ts1 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.btclose = New DevExpress.XtraEditors.SimpleButton()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tsat1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tsat2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tk1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tk2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tr1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tr2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ts2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ts1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bts_barang
        '
        Me.bts_barang.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bts_barang.Appearance.Options.UseFont = True
        Me.bts_barang.Image = CType(resources.GetObject("bts_barang.Image"), System.Drawing.Image)
        Me.bts_barang.Location = New System.Drawing.Point(330, 11)
        Me.bts_barang.Name = "bts_barang"
        Me.bts_barang.Size = New System.Drawing.Size(25, 21)
        Me.bts_barang.TabIndex = 192
        '
        'tnama
        '
        Me.tnama.Enabled = False
        Me.tnama.Location = New System.Drawing.Point(125, 12)
        Me.tnama.Name = "tnama"
        Me.tnama.Size = New System.Drawing.Size(201, 20)
        Me.tnama.TabIndex = 194
        '
        'tkode
        '
        Me.tkode.Location = New System.Drawing.Point(76, 12)
        Me.tkode.Name = "tkode"
        Me.tkode.Size = New System.Drawing.Size(45, 20)
        Me.tkode.TabIndex = 0
        '
        'LabelControl15
        '
        Me.LabelControl15.Location = New System.Drawing.Point(29, 15)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl15.TabIndex = 193
        Me.LabelControl15.Text = "Barang :"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(29, 41)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl1.TabIndex = 195
        Me.LabelControl1.Text = "Satuan :"
        '
        'tsat1
        '
        Me.tsat1.Location = New System.Drawing.Point(76, 38)
        Me.tsat1.Name = "tsat1"
        Me.tsat1.Properties.ReadOnly = True
        Me.tsat1.Size = New System.Drawing.Size(122, 20)
        Me.tsat1.TabIndex = 196
        Me.tsat1.TabStop = False
        '
        'tsat2
        '
        Me.tsat2.Location = New System.Drawing.Point(204, 38)
        Me.tsat2.Name = "tsat2"
        Me.tsat2.Properties.ReadOnly = True
        Me.tsat2.Size = New System.Drawing.Size(122, 20)
        Me.tsat2.TabIndex = 197
        Me.tsat2.TabStop = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(19, 67)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl2.TabIndex = 198
        Me.LabelControl2.Text = "Jml Komp :"
        '
        'tk1
        '
        Me.tk1.EditValue = "0"
        Me.tk1.Location = New System.Drawing.Point(76, 64)
        Me.tk1.Name = "tk1"
        Me.tk1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tk1.Properties.Appearance.Options.UseFont = True
        Me.tk1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tk1.Properties.Mask.EditMask = "n0"
        Me.tk1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tk1.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tk1.Properties.ReadOnly = True
        Me.tk1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tk1.Size = New System.Drawing.Size(122, 20)
        Me.tk1.TabIndex = 199
        Me.tk1.TabStop = False
        '
        'tk2
        '
        Me.tk2.EditValue = "0"
        Me.tk2.Location = New System.Drawing.Point(204, 64)
        Me.tk2.Name = "tk2"
        Me.tk2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tk2.Properties.Appearance.Options.UseFont = True
        Me.tk2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tk2.Properties.Mask.EditMask = "n0"
        Me.tk2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tk2.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tk2.Properties.ReadOnly = True
        Me.tk2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tk2.Size = New System.Drawing.Size(122, 20)
        Me.tk2.TabIndex = 200
        Me.tk2.TabStop = False
        '
        'tr1
        '
        Me.tr1.EditValue = "0"
        Me.tr1.Location = New System.Drawing.Point(76, 90)
        Me.tr1.Name = "tr1"
        Me.tr1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tr1.Properties.Appearance.Options.UseFont = True
        Me.tr1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tr1.Properties.Mask.EditMask = "n0"
        Me.tr1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tr1.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tr1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tr1.Size = New System.Drawing.Size(122, 20)
        Me.tr1.TabIndex = 1
        '
        'tr2
        '
        Me.tr2.EditValue = "0"
        Me.tr2.Location = New System.Drawing.Point(204, 90)
        Me.tr2.Name = "tr2"
        Me.tr2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tr2.Properties.Appearance.Options.UseFont = True
        Me.tr2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tr2.Properties.Mask.EditMask = "n0"
        Me.tr2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tr2.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tr2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tr2.Size = New System.Drawing.Size(122, 20)
        Me.tr2.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(25, 93)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl3.TabIndex = 203
        Me.LabelControl3.Text = "Jml Fisik :"
        '
        'ts2
        '
        Me.ts2.EditValue = "0"
        Me.ts2.Location = New System.Drawing.Point(204, 116)
        Me.ts2.Name = "ts2"
        Me.ts2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ts2.Properties.Appearance.Options.UseFont = True
        Me.ts2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ts2.Properties.Mask.EditMask = "n0"
        Me.ts2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.ts2.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.ts2.Properties.ReadOnly = True
        Me.ts2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ts2.Size = New System.Drawing.Size(122, 20)
        Me.ts2.TabIndex = 206
        Me.ts2.TabStop = False
        '
        'ts1
        '
        Me.ts1.EditValue = "0"
        Me.ts1.Location = New System.Drawing.Point(76, 116)
        Me.ts1.Name = "ts1"
        Me.ts1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ts1.Properties.Appearance.Options.UseFont = True
        Me.ts1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ts1.Properties.Mask.EditMask = "n0"
        Me.ts1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.ts1.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.ts1.Properties.ReadOnly = True
        Me.ts1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ts1.Size = New System.Drawing.Size(122, 20)
        Me.ts1.TabIndex = 205
        Me.ts1.TabStop = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(34, 119)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl4.TabIndex = 204
        Me.LabelControl4.Text = "Selisih :"
        '
        'btclose
        '
        Me.btclose.Location = New System.Drawing.Point(288, 162)
        Me.btclose.Name = "btclose"
        Me.btclose.Size = New System.Drawing.Size(67, 23)
        Me.btclose.TabIndex = 4
        Me.btclose.Text = "&Keluar"
        '
        'btsimpan
        '
        Me.btsimpan.Location = New System.Drawing.Point(215, 162)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(67, 23)
        Me.btsimpan.TabIndex = 3
        Me.btsimpan.Text = "&Simpan"
        '
        'fopname3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 196)
        Me.Controls.Add(Me.btclose)
        Me.Controls.Add(Me.btsimpan)
        Me.Controls.Add(Me.ts2)
        Me.Controls.Add(Me.ts1)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.tr2)
        Me.Controls.Add(Me.tr1)
        Me.Controls.Add(Me.tk2)
        Me.Controls.Add(Me.tk1)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.tsat2)
        Me.Controls.Add(Me.tsat1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.bts_barang)
        Me.Controls.Add(Me.tnama)
        Me.Controls.Add(Me.tkode)
        Me.Controls.Add(Me.LabelControl15)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fopname3"
        Me.Text = "Opname"
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tsat1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tsat2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tk1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tk2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tr1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tr2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ts2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ts1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bts_barang As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tnama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tkode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tsat1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tsat2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tk1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tk2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tr1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tr2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ts2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ts1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btclose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
End Class
