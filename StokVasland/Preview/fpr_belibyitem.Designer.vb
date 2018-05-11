<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fpr_belibyitem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fpr_belibyitem))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.ttgl = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.ttgl2 = New DevExpress.XtraEditors.DateEdit()
        Me.bts_toko = New DevExpress.XtraEditors.SimpleButton()
        Me.tnama_toko = New DevExpress.XtraEditors.TextEdit()
        Me.tkd_toko = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.bts_barang = New DevExpress.XtraEditors.SimpleButton()
        Me.tnama = New DevExpress.XtraEditors.TextEdit()
        Me.tkode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.btload = New DevExpress.XtraEditors.SimpleButton()
        Me.btkeluar = New DevExpress.XtraEditors.SimpleButton()
        Me.RadioGroup1 = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.ttgl.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnama_toko.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkd_toko.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(24, 21)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Tgl Beli :"
        '
        'ttgl
        '
        Me.ttgl.EditValue = Nothing
        Me.ttgl.Location = New System.Drawing.Point(70, 18)
        Me.ttgl.Name = "ttgl"
        Me.ttgl.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ttgl.Properties.Mask.EditMask = ""
        Me.ttgl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.ttgl.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ttgl.Size = New System.Drawing.Size(113, 20)
        Me.ttgl.TabIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(189, 21)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(15, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "s.d"
        '
        'ttgl2
        '
        Me.ttgl2.EditValue = Nothing
        Me.ttgl2.Location = New System.Drawing.Point(211, 18)
        Me.ttgl2.Name = "ttgl2"
        Me.ttgl2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ttgl2.Properties.Mask.EditMask = ""
        Me.ttgl2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.ttgl2.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ttgl2.Size = New System.Drawing.Size(113, 20)
        Me.ttgl2.TabIndex = 1
        '
        'bts_toko
        '
        Me.bts_toko.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bts_toko.Appearance.Options.UseFont = True
        Me.bts_toko.Image = CType(resources.GetObject("bts_toko.Image"), System.Drawing.Image)
        Me.bts_toko.Location = New System.Drawing.Point(330, 44)
        Me.bts_toko.Name = "bts_toko"
        Me.bts_toko.Size = New System.Drawing.Size(25, 21)
        Me.bts_toko.TabIndex = 179
        '
        'tnama_toko
        '
        Me.tnama_toko.Enabled = False
        Me.tnama_toko.Location = New System.Drawing.Point(116, 44)
        Me.tnama_toko.Name = "tnama_toko"
        Me.tnama_toko.Size = New System.Drawing.Size(208, 20)
        Me.tnama_toko.TabIndex = 178
        '
        'tkd_toko
        '
        Me.tkd_toko.Location = New System.Drawing.Point(70, 44)
        Me.tkd_toko.Name = "tkd_toko"
        Me.tkd_toko.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tkd_toko.Size = New System.Drawing.Size(44, 20)
        Me.tkd_toko.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(27, 47)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl3.TabIndex = 177
        Me.LabelControl3.Text = "Outlet :"
        '
        'bts_barang
        '
        Me.bts_barang.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bts_barang.Appearance.Options.UseFont = True
        Me.bts_barang.Image = CType(resources.GetObject("bts_barang.Image"), System.Drawing.Image)
        Me.bts_barang.Location = New System.Drawing.Point(330, 69)
        Me.bts_barang.Name = "bts_barang"
        Me.bts_barang.Size = New System.Drawing.Size(25, 21)
        Me.bts_barang.TabIndex = 185
        '
        'tnama
        '
        Me.tnama.Enabled = False
        Me.tnama.Location = New System.Drawing.Point(116, 70)
        Me.tnama.Name = "tnama"
        Me.tnama.Size = New System.Drawing.Size(208, 20)
        Me.tnama.TabIndex = 184
        '
        'tkode
        '
        Me.tkode.Location = New System.Drawing.Point(70, 70)
        Me.tkode.Name = "tkode"
        Me.tkode.Size = New System.Drawing.Size(45, 20)
        Me.tkode.TabIndex = 3
        '
        'LabelControl15
        '
        Me.LabelControl15.Location = New System.Drawing.Point(23, 73)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl15.TabIndex = 183
        Me.LabelControl15.Text = "Barang :"
        '
        'btload
        '
        Me.btload.Location = New System.Drawing.Point(221, 148)
        Me.btload.Name = "btload"
        Me.btload.Size = New System.Drawing.Size(64, 27)
        Me.btload.TabIndex = 5
        Me.btload.Text = "&Load"
        '
        'btkeluar
        '
        Me.btkeluar.Location = New System.Drawing.Point(291, 148)
        Me.btkeluar.Name = "btkeluar"
        Me.btkeluar.Size = New System.Drawing.Size(64, 27)
        Me.btkeluar.TabIndex = 6
        Me.btkeluar.Text = "&Keluar"
        '
        'RadioGroup1
        '
        Me.RadioGroup1.Location = New System.Drawing.Point(70, 96)
        Me.RadioGroup1.Name = "RadioGroup1"
        Me.RadioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.RadioGroup1.Properties.Appearance.Options.UseBackColor = True
        Me.RadioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.RadioGroup1.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Hanya &Barang"), New DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Barang && &Harga")})
        Me.RadioGroup1.Size = New System.Drawing.Size(254, 24)
        Me.RadioGroup1.TabIndex = 4
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(13, 99)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl4.TabIndex = 189
        Me.LabelControl4.Text = "Jenis Lap :"
        '
        'fpr_belibyitem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 185)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.RadioGroup1)
        Me.Controls.Add(Me.btkeluar)
        Me.Controls.Add(Me.btload)
        Me.Controls.Add(Me.bts_barang)
        Me.Controls.Add(Me.tnama)
        Me.Controls.Add(Me.tkode)
        Me.Controls.Add(Me.LabelControl15)
        Me.Controls.Add(Me.bts_toko)
        Me.Controls.Add(Me.tnama_toko)
        Me.Controls.Add(Me.tkd_toko)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.ttgl2)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.ttgl)
        Me.Controls.Add(Me.LabelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fpr_belibyitem"
        Me.Text = "Laporan Pembelian Per Barang"
        CType(Me.ttgl.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnama_toko.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkd_toko.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ttgl As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ttgl2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents bts_toko As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tnama_toko As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tkd_toko As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents bts_barang As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tnama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tkode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btload As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btkeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RadioGroup1 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
End Class
