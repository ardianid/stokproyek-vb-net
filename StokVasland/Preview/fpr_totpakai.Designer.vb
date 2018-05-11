<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fpr_totpakai
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fpr_totpakai))
        Me.bts_barang = New DevExpress.XtraEditors.SimpleButton()
        Me.tnama = New DevExpress.XtraEditors.TextEdit()
        Me.tkode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.ttgl2 = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.ttgl = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btkeluar = New DevExpress.XtraEditors.SimpleButton()
        Me.btload = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.bts_proyek = New DevExpress.XtraEditors.SimpleButton()
        Me.tnama_proyek = New DevExpress.XtraEditors.TextEdit()
        Me.tkode_proyek = New DevExpress.XtraEditors.TextEdit()
        Me.bts_sub = New DevExpress.XtraEditors.SimpleButton()
        Me.tkode_sub = New DevExpress.XtraEditors.TextEdit()
        Me.tnama_sub = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl20 = New DevExpress.XtraEditors.LabelControl()
        Me.cblap = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttgl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnama_proyek.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkode_proyek.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tkode_sub.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tnama_sub.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cblap.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bts_barang
        '
        Me.bts_barang.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bts_barang.Appearance.Options.UseFont = True
        Me.bts_barang.Image = CType(resources.GetObject("bts_barang.Image"), System.Drawing.Image)
        Me.bts_barang.Location = New System.Drawing.Point(343, 50)
        Me.bts_barang.Name = "bts_barang"
        Me.bts_barang.Size = New System.Drawing.Size(25, 21)
        Me.bts_barang.TabIndex = 3
        '
        'tnama
        '
        Me.tnama.Enabled = False
        Me.tnama.Location = New System.Drawing.Point(129, 51)
        Me.tnama.Name = "tnama"
        Me.tnama.Size = New System.Drawing.Size(208, 20)
        Me.tnama.TabIndex = 196
        '
        'tkode
        '
        Me.tkode.Location = New System.Drawing.Point(83, 51)
        Me.tkode.Name = "tkode"
        Me.tkode.Size = New System.Drawing.Size(45, 20)
        Me.tkode.TabIndex = 2
        '
        'LabelControl15
        '
        Me.LabelControl15.Location = New System.Drawing.Point(36, 54)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl15.TabIndex = 195
        Me.LabelControl15.Text = "Barang :"
        '
        'ttgl2
        '
        Me.ttgl2.EditValue = Nothing
        Me.ttgl2.Location = New System.Drawing.Point(224, 25)
        Me.ttgl2.Name = "ttgl2"
        Me.ttgl2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ttgl2.Properties.Mask.EditMask = ""
        Me.ttgl2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.ttgl2.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ttgl2.Size = New System.Drawing.Size(113, 20)
        Me.ttgl2.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(202, 28)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(15, 13)
        Me.LabelControl2.TabIndex = 194
        Me.LabelControl2.Text = "s.d"
        '
        'ttgl
        '
        Me.ttgl.EditValue = Nothing
        Me.ttgl.Location = New System.Drawing.Point(83, 25)
        Me.ttgl.Name = "ttgl"
        Me.ttgl.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ttgl.Properties.Mask.EditMask = ""
        Me.ttgl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.ttgl.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ttgl.Size = New System.Drawing.Size(113, 20)
        Me.ttgl.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(28, 28)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl1.TabIndex = 193
        Me.LabelControl1.Text = "Tgl Ambil :"
        '
        'btkeluar
        '
        Me.btkeluar.Location = New System.Drawing.Point(304, 181)
        Me.btkeluar.Name = "btkeluar"
        Me.btkeluar.Size = New System.Drawing.Size(64, 27)
        Me.btkeluar.TabIndex = 12
        Me.btkeluar.Text = "&Keluar"
        '
        'btload
        '
        Me.btload.Location = New System.Drawing.Point(234, 181)
        Me.btload.Name = "btload"
        Me.btload.Size = New System.Drawing.Size(64, 27)
        Me.btload.TabIndex = 11
        Me.btload.Text = "&Load"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(37, 80)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl5.TabIndex = 201
        Me.LabelControl5.Text = "Proyek :"
        '
        'bts_proyek
        '
        Me.bts_proyek.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bts_proyek.Appearance.Options.UseFont = True
        Me.bts_proyek.Image = CType(resources.GetObject("bts_proyek.Image"), System.Drawing.Image)
        Me.bts_proyek.Location = New System.Drawing.Point(343, 76)
        Me.bts_proyek.Name = "bts_proyek"
        Me.bts_proyek.Size = New System.Drawing.Size(25, 21)
        Me.bts_proyek.TabIndex = 5
        '
        'tnama_proyek
        '
        Me.tnama_proyek.Enabled = False
        Me.tnama_proyek.Location = New System.Drawing.Point(129, 77)
        Me.tnama_proyek.Name = "tnama_proyek"
        Me.tnama_proyek.Size = New System.Drawing.Size(208, 20)
        Me.tnama_proyek.TabIndex = 200
        '
        'tkode_proyek
        '
        Me.tkode_proyek.Location = New System.Drawing.Point(83, 77)
        Me.tkode_proyek.Name = "tkode_proyek"
        Me.tkode_proyek.Size = New System.Drawing.Size(45, 20)
        Me.tkode_proyek.TabIndex = 4
        '
        'bts_sub
        '
        Me.bts_sub.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bts_sub.Appearance.Options.UseFont = True
        Me.bts_sub.Image = CType(resources.GetObject("bts_sub.Image"), System.Drawing.Image)
        Me.bts_sub.Location = New System.Drawing.Point(343, 102)
        Me.bts_sub.Name = "bts_sub"
        Me.bts_sub.Size = New System.Drawing.Size(25, 21)
        Me.bts_sub.TabIndex = 7
        '
        'tkode_sub
        '
        Me.tkode_sub.Location = New System.Drawing.Point(83, 103)
        Me.tkode_sub.Name = "tkode_sub"
        Me.tkode_sub.Size = New System.Drawing.Size(45, 20)
        Me.tkode_sub.TabIndex = 6
        '
        'tnama_sub
        '
        Me.tnama_sub.Enabled = False
        Me.tnama_sub.Location = New System.Drawing.Point(129, 103)
        Me.tnama_sub.Name = "tnama_sub"
        Me.tnama_sub.Size = New System.Drawing.Size(208, 20)
        Me.tnama_sub.TabIndex = 209
        '
        'LabelControl20
        '
        Me.LabelControl20.Location = New System.Drawing.Point(16, 106)
        Me.LabelControl20.Name = "LabelControl20"
        Me.LabelControl20.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl20.TabIndex = 208
        Me.LabelControl20.Text = "Sub Proyek :"
        '
        'cblap
        '
        Me.cblap.Location = New System.Drawing.Point(83, 129)
        Me.cblap.Name = "cblap"
        Me.cblap.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cblap.Properties.Items.AddRange(New Object() {"PER PROYEK", "PER PROYEK & SUB PROYEK"})
        Me.cblap.Size = New System.Drawing.Size(254, 20)
        Me.cblap.TabIndex = 10
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(26, 132)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl6.TabIndex = 212
        Me.LabelControl6.Text = "Jenis Lap :"
        '
        'fpr_totpakai
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 217)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.bts_sub)
        Me.Controls.Add(Me.tkode_sub)
        Me.Controls.Add(Me.tnama_sub)
        Me.Controls.Add(Me.LabelControl20)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.bts_proyek)
        Me.Controls.Add(Me.tnama_proyek)
        Me.Controls.Add(Me.tkode_proyek)
        Me.Controls.Add(Me.btkeluar)
        Me.Controls.Add(Me.btload)
        Me.Controls.Add(Me.bts_barang)
        Me.Controls.Add(Me.tnama)
        Me.Controls.Add(Me.tkode)
        Me.Controls.Add(Me.LabelControl15)
        Me.Controls.Add(Me.ttgl2)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.ttgl)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.cblap)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fpr_totpakai"
        Me.Text = "Lap Total Pemakaian Per Barang"
        CType(Me.tnama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttgl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnama_proyek.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkode_proyek.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tkode_sub.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tnama_sub.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cblap.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bts_barang As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tnama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tkode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ttgl2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ttgl As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btkeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btload As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents bts_proyek As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tnama_proyek As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tkode_proyek As DevExpress.XtraEditors.TextEdit
    Friend WithEvents bts_sub As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tkode_sub As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tnama_sub As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl20 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cblap As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
End Class
