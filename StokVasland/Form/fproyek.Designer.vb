﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fproyek
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fproyek))
        Me.grid1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ckode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.bn1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsadd = New System.Windows.Forms.ToolStripButton()
        Me.tsedit = New System.Windows.Forms.ToolStripButton()
        Me.tsdel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsref = New System.Windows.Forms.ToolStripButton()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bn1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bn1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grid1
        '
        Me.grid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid1.Location = New System.Drawing.Point(0, 36)
        Me.grid1.MainView = Me.GridView1
        Me.grid1.Name = "grid1"
        Me.grid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit3})
        Me.grid1.Size = New System.Drawing.Size(751, 315)
        Me.grid1.TabIndex = 139
        Me.grid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ckode, Me.GridColumn1, Me.GridColumn2})
        Me.GridView1.GridControl = Me.grid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ckode
        '
        Me.ckode.Caption = "Nama"
        Me.ckode.FieldName = "nama_group"
        Me.ckode.Name = "ckode"
        Me.ckode.OptionsColumn.AllowEdit = False
        Me.ckode.Visible = True
        Me.ckode.VisibleIndex = 1
        Me.ckode.Width = 238
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Ket"
        Me.GridColumn1.FieldName = "ket"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        Me.GridColumn1.Width = 439
        '
        'RepositoryItemCheckEdit3
        '
        Me.RepositoryItemCheckEdit3.AutoHeight = False
        Me.RepositoryItemCheckEdit3.DisplayValueChecked = "1"
        Me.RepositoryItemCheckEdit3.DisplayValueUnchecked = "0"
        Me.RepositoryItemCheckEdit3.Name = "RepositoryItemCheckEdit3"
        Me.RepositoryItemCheckEdit3.ValueChecked = 1
        Me.RepositoryItemCheckEdit3.ValueUnchecked = 0
        '
        'bn1
        '
        Me.bn1.AddNewItem = Nothing
        Me.bn1.CountItem = Me.ToolStripLabel2
        Me.bn1.DeleteItem = Nothing
        Me.bn1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bn1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.bn1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripSeparator2, Me.ToolStripTextBox1, Me.ToolStripLabel2, Me.ToolStripSeparator3, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripSeparator4, Me.tsadd, Me.tsedit, Me.tsdel, Me.ToolStripSeparator1, Me.tsref})
        Me.bn1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.bn1.Location = New System.Drawing.Point(0, 0)
        Me.bn1.MoveFirstItem = Me.ToolStripButton2
        Me.bn1.MoveLastItem = Me.ToolStripButton5
        Me.bn1.MoveNextItem = Me.ToolStripButton4
        Me.bn1.MovePreviousItem = Me.ToolStripButton3
        Me.bn1.Name = "bn1"
        Me.bn1.PositionItem = Me.ToolStripTextBox1
        Me.bn1.Size = New System.Drawing.Size(751, 36)
        Me.bn1.TabIndex = 138
        Me.bn1.Text = "BindingNavigator1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(36, 33)
        Me.ToolStripLabel2.Text = "of {0}"
        Me.ToolStripLabel2.ToolTipText = "Total number of items"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 33)
        Me.ToolStripButton2.Tag = "True"
        Me.ToolStripButton2.Text = "Move first"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 33)
        Me.ToolStripButton3.Tag = "True"
        Me.ToolStripButton3.Text = "Move previous"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 36)
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.AccessibleName = "Position"
        Me.ToolStripTextBox1.AutoSize = False
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(58, 21)
        Me.ToolStripTextBox1.Text = "0"
        Me.ToolStripTextBox1.ToolTipText = "Current position"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 36)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 33)
        Me.ToolStripButton4.Tag = "True"
        Me.ToolStripButton4.Text = "Move next"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 33)
        Me.ToolStripButton5.Tag = "True"
        Me.ToolStripButton5.Text = "Move last"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 36)
        '
        'tsadd
        '
        Me.tsadd.AutoSize = False
        Me.tsadd.ForeColor = System.Drawing.Color.Black
        Me.tsadd.Image = CType(resources.GetObject("tsadd.Image"), System.Drawing.Image)
        Me.tsadd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsadd.Name = "tsadd"
        Me.tsadd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tsadd.Size = New System.Drawing.Size(49, 33)
        Me.tsadd.Text = "&Tambah"
        Me.tsadd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsadd.ToolTipText = "Tambah data"
        '
        'tsedit
        '
        Me.tsedit.AutoSize = False
        Me.tsedit.ForeColor = System.Drawing.Color.Black
        Me.tsedit.Image = CType(resources.GetObject("tsedit.Image"), System.Drawing.Image)
        Me.tsedit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsedit.Name = "tsedit"
        Me.tsedit.Size = New System.Drawing.Size(49, 33)
        Me.tsedit.Text = "&Edit"
        Me.tsedit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsedit.ToolTipText = "Rubah data"
        '
        'tsdel
        '
        Me.tsdel.AutoSize = False
        Me.tsdel.ForeColor = System.Drawing.Color.Black
        Me.tsdel.Image = CType(resources.GetObject("tsdel.Image"), System.Drawing.Image)
        Me.tsdel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsdel.Name = "tsdel"
        Me.tsdel.Size = New System.Drawing.Size(49, 33)
        Me.tsdel.Text = "&Hapus"
        Me.tsdel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsdel.ToolTipText = "Hapus data"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 36)
        '
        'tsref
        '
        Me.tsref.AutoSize = False
        Me.tsref.ForeColor = System.Drawing.Color.Black
        Me.tsref.Image = CType(resources.GetObject("tsref.Image"), System.Drawing.Image)
        Me.tsref.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsref.Name = "tsref"
        Me.tsref.Size = New System.Drawing.Size(49, 33)
        Me.tsref.Text = "&Refresh"
        Me.tsref.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsref.ToolTipText = "Refresh Data"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Kode"
        Me.GridColumn2.FieldName = "kd_group"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 56
        '
        'fproyek
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 351)
        Me.Controls.Add(Me.grid1)
        Me.Controls.Add(Me.bn1)
        Me.Name = "fproyek"
        Me.Text = "Proyek"
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bn1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bn1.ResumeLayout(False)
        Me.bn1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ckode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents bn1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsadd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsdel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsref As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsedit As System.Windows.Forms.ToolStripButton
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
End Class
