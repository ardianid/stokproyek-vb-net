﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fsoutlet
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
        Me.tfind = New DevExpress.XtraEditors.TextEdit()
        Me.cb_criteria = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.grid1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ckode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cnama = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.tfind.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cb_criteria.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tfind
        '
        Me.tfind.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tfind.Location = New System.Drawing.Point(106, 2)
        Me.tfind.Name = "tfind"
        Me.tfind.Size = New System.Drawing.Size(547, 20)
        Me.tfind.TabIndex = 9
        '
        'cb_criteria
        '
        Me.cb_criteria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cb_criteria.Location = New System.Drawing.Point(1, 2)
        Me.cb_criteria.Name = "cb_criteria"
        Me.cb_criteria.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cb_criteria.Properties.Items.AddRange(New Object() {"Kode", "Nama", "Alamat"})
        Me.cb_criteria.Size = New System.Drawing.Size(102, 20)
        Me.cb_criteria.TabIndex = 8
        '
        'grid1
        '
        Me.grid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grid1.Location = New System.Drawing.Point(1, 28)
        Me.grid1.MainView = Me.GridView1
        Me.grid1.Name = "grid1"
        Me.grid1.Size = New System.Drawing.Size(652, 405)
        Me.grid1.TabIndex = 10
        Me.grid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ckode, Me.cnama, Me.GridColumn1})
        Me.GridView1.GridControl = Me.grid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ckode
        '
        Me.ckode.Caption = "Kode"
        Me.ckode.FieldName = "kd_toko"
        Me.ckode.Name = "ckode"
        Me.ckode.OptionsColumn.AllowEdit = False
        Me.ckode.Visible = True
        Me.ckode.VisibleIndex = 0
        Me.ckode.Width = 102
        '
        'cnama
        '
        Me.cnama.Caption = "Nama"
        Me.cnama.FieldName = "nama_toko"
        Me.cnama.Name = "cnama"
        Me.cnama.OptionsColumn.AllowEdit = False
        Me.cnama.Visible = True
        Me.cnama.VisibleIndex = 1
        Me.cnama.Width = 212
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Alamat"
        Me.GridColumn1.FieldName = "alamat_toko"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        Me.GridColumn1.Width = 339
        '
        'fsoutlet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 433)
        Me.Controls.Add(Me.grid1)
        Me.Controls.Add(Me.tfind)
        Me.Controls.Add(Me.cb_criteria)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fsoutlet"
        Me.Text = "Search Outlet"
        CType(Me.tfind.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cb_criteria.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tfind As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cb_criteria As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents grid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ckode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cnama As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
