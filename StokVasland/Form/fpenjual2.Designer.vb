<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fpenjual2
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
        Me.btclose = New DevExpress.XtraEditors.SimpleButton()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.tket = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.tnama = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.tkode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.talamat = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.ttelp = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.ctanya = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.tket.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.talamat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttelp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ctanya.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btclose
        '
        Me.btclose.Location = New System.Drawing.Point(297, 217)
        Me.btclose.Name = "btclose"
        Me.btclose.Size = New System.Drawing.Size(75, 23)
        Me.btclose.TabIndex = 7
        Me.btclose.Text = "&Keluar"
        '
        'btsimpan
        '
        Me.btsimpan.Location = New System.Drawing.Point(216, 217)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(75, 23)
        Me.btsimpan.TabIndex = 6
        Me.btsimpan.Text = "&Simpan"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(32, 140)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl4.TabIndex = 23
        Me.LabelControl4.Text = "Ket :"
        '
        'tket
        '
        Me.tket.Location = New System.Drawing.Point(64, 137)
        Me.tket.Name = "tket"
        Me.tket.Size = New System.Drawing.Size(308, 42)
        Me.tket.TabIndex = 4
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(15, 93)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl3.TabIndex = 21
        Me.LabelControl3.Text = "Alamat :"
        '
        'tnama
        '
        Me.tnama.Location = New System.Drawing.Point(64, 38)
        Me.tnama.Name = "tnama"
        Me.tnama.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tnama.Size = New System.Drawing.Size(308, 20)
        Me.tnama.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(21, 41)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl2.TabIndex = 19
        Me.LabelControl2.Text = "Nama :"
        '
        'tkode
        '
        Me.tkode.Location = New System.Drawing.Point(64, 12)
        Me.tkode.Name = "tkode"
        Me.tkode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tkode.Size = New System.Drawing.Size(78, 20)
        Me.tkode.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(24, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl1.TabIndex = 17
        Me.LabelControl1.Text = "Kode :"
        '
        'talamat
        '
        Me.talamat.Location = New System.Drawing.Point(64, 90)
        Me.talamat.Name = "talamat"
        Me.talamat.Size = New System.Drawing.Size(308, 41)
        Me.talamat.TabIndex = 3
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 67)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl5.TabIndex = 26
        Me.LabelControl5.Text = "No Telp :"
        '
        'ttelp
        '
        Me.ttelp.Location = New System.Drawing.Point(64, 64)
        Me.ttelp.Name = "ttelp"
        Me.ttelp.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ttelp.Size = New System.Drawing.Size(308, 20)
        Me.ttelp.TabIndex = 2
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(24, 194)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(259, 13)
        Me.LabelControl6.TabIndex = 27
        Me.LabelControl6.Text = "Apakah transaksi pembelian akan menambah hutang ?"
        Me.LabelControl6.Visible = False
        '
        'ctanya
        '
        Me.ctanya.Location = New System.Drawing.Point(289, 192)
        Me.ctanya.Name = "ctanya"
        Me.ctanya.Properties.Caption = "Tidak"
        Me.ctanya.Size = New System.Drawing.Size(75, 19)
        Me.ctanya.TabIndex = 5
        Me.ctanya.Visible = False
        '
        'fpenjual2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 254)
        Me.Controls.Add(Me.ctanya)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.ttelp)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.btclose)
        Me.Controls.Add(Me.btsimpan)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.tket)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.tnama)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.tkode)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.talamat)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fpenjual2"
        Me.Text = "Toko"
        CType(Me.tket.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.talamat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttelp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ctanya.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btclose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tket As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tnama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tkode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents talamat As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ttelp As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ctanya As DevExpress.XtraEditors.CheckEdit
End Class
