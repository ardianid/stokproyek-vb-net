<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fpesan_beli3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fpesan_beli3))
        Me.btclose = New DevExpress.XtraEditors.SimpleButton()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.tsat = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.tjml = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.bts_barang = New DevExpress.XtraEditors.SimpleButton()
        Me.tnama = New DevExpress.XtraEditors.TextEdit()
        Me.tkode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.tsat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tjml.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btclose
        '
        Me.btclose.Location = New System.Drawing.Point(286, 124)
        Me.btclose.Name = "btclose"
        Me.btclose.Size = New System.Drawing.Size(67, 23)
        Me.btclose.TabIndex = 198
        Me.btclose.Text = "&Keluar"
        '
        'btsimpan
        '
        Me.btsimpan.Location = New System.Drawing.Point(213, 124)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(67, 23)
        Me.btsimpan.TabIndex = 197
        Me.btsimpan.Text = "&Simpan"
        '
        'tsat
        '
        Me.tsat.Location = New System.Drawing.Point(68, 61)
        Me.tsat.Name = "tsat"
        Me.tsat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.tsat.Size = New System.Drawing.Size(254, 20)
        Me.tsat.TabIndex = 196
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(21, 64)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl4.TabIndex = 203
        Me.LabelControl4.Text = "Satuan :"
        '
        'tjml
        '
        Me.tjml.EditValue = "0"
        Me.tjml.Location = New System.Drawing.Point(68, 38)
        Me.tjml.Name = "tjml"
        Me.tjml.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tjml.Properties.Appearance.Options.UseFont = True
        Me.tjml.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tjml.Properties.Mask.EditMask = "n0"
        Me.tjml.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.tjml.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.tjml.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tjml.Size = New System.Drawing.Size(254, 20)
        Me.tjml.TabIndex = 195
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(40, 41)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl3.TabIndex = 202
        Me.LabelControl3.Text = "Jml :"
        '
        'bts_barang
        '
        Me.bts_barang.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bts_barang.Appearance.Options.UseFont = True
        Me.bts_barang.Image = CType(resources.GetObject("bts_barang.Image"), System.Drawing.Image)
        Me.bts_barang.Location = New System.Drawing.Point(328, 11)
        Me.bts_barang.Name = "bts_barang"
        Me.bts_barang.Size = New System.Drawing.Size(25, 21)
        Me.bts_barang.TabIndex = 199
        '
        'tnama
        '
        Me.tnama.Enabled = False
        Me.tnama.Location = New System.Drawing.Point(117, 12)
        Me.tnama.Name = "tnama"
        Me.tnama.Size = New System.Drawing.Size(205, 20)
        Me.tnama.TabIndex = 201
        '
        'tkode
        '
        Me.tkode.Location = New System.Drawing.Point(68, 12)
        Me.tkode.Name = "tkode"
        Me.tkode.Size = New System.Drawing.Size(45, 20)
        Me.tkode.TabIndex = 194
        '
        'LabelControl15
        '
        Me.LabelControl15.Location = New System.Drawing.Point(21, 15)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl15.TabIndex = 200
        Me.LabelControl15.Text = "Barang :"
        '
        'fpesan_beli3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 156)
        Me.Controls.Add(Me.btclose)
        Me.Controls.Add(Me.btsimpan)
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
        Me.Name = "fpesan_beli3"
        Me.Text = "Pesanan Pembelian"
        CType(Me.tsat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tjml.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btclose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tsat As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tjml As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents bts_barang As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tnama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tkode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
End Class
