<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fproyeksub2
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
        Me.LabelControl20 = New DevExpress.XtraEditors.LabelControl()
        Me.tkode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.tnama = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.tkelompok = New DevExpress.XtraEditors.LookUpEdit()
        Me.btsimpan = New DevExpress.XtraEditors.SimpleButton()
        Me.btclose = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkelompok.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl20
        '
        Me.LabelControl20.Location = New System.Drawing.Point(22, 67)
        Me.LabelControl20.Name = "LabelControl20"
        Me.LabelControl20.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl20.TabIndex = 38
        Me.LabelControl20.Text = "Proyek :"
        '
        'tkode
        '
        Me.tkode.Location = New System.Drawing.Point(68, 12)
        Me.tkode.Name = "tkode"
        Me.tkode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tkode.Size = New System.Drawing.Size(96, 20)
        Me.tkode.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(31, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl1.TabIndex = 41
        Me.LabelControl1.Text = "Kode :"
        '
        'tnama
        '
        Me.tnama.Location = New System.Drawing.Point(68, 38)
        Me.tnama.Name = "tnama"
        Me.tnama.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tnama.Size = New System.Drawing.Size(296, 20)
        Me.tnama.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(28, 41)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl2.TabIndex = 42
        Me.LabelControl2.Text = "Nama :"
        '
        'tkelompok
        '
        Me.tkelompok.Location = New System.Drawing.Point(68, 64)
        Me.tkelompok.Name = "tkelompok"
        Me.tkelompok.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.tkelompok.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tkelompok.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("kd_group", 6, "Kode"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nama_group", "Nama")})
        Me.tkelompok.Properties.DisplayMember = "nama_group"
        Me.tkelompok.Properties.NullText = ""
        Me.tkelompok.Properties.PopupSizeable = False
        Me.tkelompok.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.tkelompok.Properties.ValueMember = "kd_group"
        Me.tkelompok.Size = New System.Drawing.Size(296, 20)
        Me.tkelompok.TabIndex = 2
        '
        'btsimpan
        '
        Me.btsimpan.Location = New System.Drawing.Point(208, 116)
        Me.btsimpan.Name = "btsimpan"
        Me.btsimpan.Size = New System.Drawing.Size(75, 23)
        Me.btsimpan.TabIndex = 3
        Me.btsimpan.Text = "&Simpan"
        '
        'btclose
        '
        Me.btclose.Location = New System.Drawing.Point(289, 116)
        Me.btclose.Name = "btclose"
        Me.btclose.Size = New System.Drawing.Size(75, 23)
        Me.btclose.TabIndex = 4
        Me.btclose.Text = "&Keluar"
        '
        'fproyeksub2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 158)
        Me.Controls.Add(Me.btsimpan)
        Me.Controls.Add(Me.btclose)
        Me.Controls.Add(Me.tkode)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.tnama)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl20)
        Me.Controls.Add(Me.tkelompok)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fproyeksub2"
        Me.Text = "Sub Proyek"
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkelompok.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl20 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tkode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tnama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tkelompok As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btsimpan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btclose As DevExpress.XtraEditors.SimpleButton
End Class
