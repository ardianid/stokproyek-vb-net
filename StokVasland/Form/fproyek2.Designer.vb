<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fproyek2
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
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.btclose = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.tnama = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.tket = New DevExpress.XtraEditors.MemoEdit()
        Me.tkode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tket.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btsimpan
        '
        Me.btsimpan.Location = New System.Drawing.Point(205, 159)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(75, 23)
        Me.btsimpan.TabIndex = 3
        Me.btsimpan.Text = "&Simpan"
        '
        'btclose
        '
        Me.btclose.Location = New System.Drawing.Point(286, 159)
        Me.btclose.Name = "btclose"
        Me.btclose.Size = New System.Drawing.Size(75, 23)
        Me.btclose.TabIndex = 4
        Me.btclose.Text = "&Keluar"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(36, 70)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl1.TabIndex = 17
        Me.LabelControl1.Text = "Ket :"
        '
        'tnama
        '
        Me.tnama.Location = New System.Drawing.Point(65, 41)
        Me.tnama.Name = "tnama"
        Me.tnama.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tnama.Size = New System.Drawing.Size(296, 20)
        Me.tnama.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(25, 44)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl2.TabIndex = 16
        Me.LabelControl2.Text = "Nama :"
        '
        'tket
        '
        Me.tket.Location = New System.Drawing.Point(65, 67)
        Me.tket.Name = "tket"
        Me.tket.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tket.Size = New System.Drawing.Size(296, 62)
        Me.tket.TabIndex = 2
        '
        'tkode
        '
        Me.tkode.Location = New System.Drawing.Point(65, 12)
        Me.tkode.Name = "tkode"
        Me.tkode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tkode.Size = New System.Drawing.Size(296, 20)
        Me.tkode.TabIndex = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(25, 15)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl3.TabIndex = 19
        Me.LabelControl3.Text = "Kode :"
        '
        'fproyek2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 193)
        Me.Controls.Add(Me.tkode)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.btsimpan)
        Me.Controls.Add(Me.btclose)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.tnama)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.tket)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fproyek2"
        Me.Text = "Proyek"
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tket.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btclose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tnama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tket As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents tkode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
End Class
