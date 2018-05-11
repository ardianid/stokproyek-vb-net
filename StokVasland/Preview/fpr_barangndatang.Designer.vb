<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fpr_barangndatang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fpr_barangndatang))
        Me.bts_barang = New DevExpress.XtraEditors.SimpleButton()
        Me.tnama = New DevExpress.XtraEditors.TextEdit()
        Me.tkode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.bts_toko = New DevExpress.XtraEditors.SimpleButton()
        Me.tnama_toko = New DevExpress.XtraEditors.TextEdit()
        Me.tkd_toko = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.btkeluar = New DevExpress.XtraEditors.SimpleButton()
        Me.btload = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnama_toko.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkd_toko.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bts_barang
        '
        Me.bts_barang.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bts_barang.Appearance.Options.UseFont = True
        Me.bts_barang.Image = CType(resources.GetObject("bts_barang.Image"), System.Drawing.Image)
        Me.bts_barang.Location = New System.Drawing.Point(333, 46)
        Me.bts_barang.Name = "bts_barang"
        Me.bts_barang.Size = New System.Drawing.Size(25, 21)
        Me.bts_barang.TabIndex = 193
        '
        'tnama
        '
        Me.tnama.Enabled = False
        Me.tnama.Location = New System.Drawing.Point(119, 47)
        Me.tnama.Name = "tnama"
        Me.tnama.Size = New System.Drawing.Size(208, 20)
        Me.tnama.TabIndex = 192
        '
        'tkode
        '
        Me.tkode.Location = New System.Drawing.Point(73, 47)
        Me.tkode.Name = "tkode"
        Me.tkode.Size = New System.Drawing.Size(45, 20)
        Me.tkode.TabIndex = 1
        '
        'LabelControl15
        '
        Me.LabelControl15.Location = New System.Drawing.Point(26, 50)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl15.TabIndex = 191
        Me.LabelControl15.Text = "Barang :"
        '
        'bts_toko
        '
        Me.bts_toko.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bts_toko.Appearance.Options.UseFont = True
        Me.bts_toko.Image = CType(resources.GetObject("bts_toko.Image"), System.Drawing.Image)
        Me.bts_toko.Location = New System.Drawing.Point(333, 21)
        Me.bts_toko.Name = "bts_toko"
        Me.bts_toko.Size = New System.Drawing.Size(25, 21)
        Me.bts_toko.TabIndex = 190
        '
        'tnama_toko
        '
        Me.tnama_toko.Enabled = False
        Me.tnama_toko.Location = New System.Drawing.Point(119, 21)
        Me.tnama_toko.Name = "tnama_toko"
        Me.tnama_toko.Size = New System.Drawing.Size(208, 20)
        Me.tnama_toko.TabIndex = 189
        '
        'tkd_toko
        '
        Me.tkd_toko.Location = New System.Drawing.Point(73, 21)
        Me.tkd_toko.Name = "tkd_toko"
        Me.tkd_toko.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tkd_toko.Size = New System.Drawing.Size(44, 20)
        Me.tkd_toko.TabIndex = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(30, 24)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl3.TabIndex = 188
        Me.LabelControl3.Text = "Outlet :"
        '
        'btkeluar
        '
        Me.btkeluar.Location = New System.Drawing.Point(294, 105)
        Me.btkeluar.Name = "btkeluar"
        Me.btkeluar.Size = New System.Drawing.Size(64, 27)
        Me.btkeluar.TabIndex = 3
        Me.btkeluar.Text = "&Keluar"
        '
        'btload
        '
        Me.btload.Location = New System.Drawing.Point(224, 105)
        Me.btload.Name = "btload"
        Me.btload.Size = New System.Drawing.Size(64, 27)
        Me.btload.TabIndex = 2
        Me.btload.Text = "&Load"
        '
        'fpr_barangndatang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 147)
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
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fpr_barangndatang"
        Me.Text = "Pemesanan Belum Datang"
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnama_toko.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkd_toko.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bts_barang As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tnama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tkode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents bts_toko As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tnama_toko As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tkd_toko As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btkeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btload As DevExpress.XtraEditors.SimpleButton
End Class
