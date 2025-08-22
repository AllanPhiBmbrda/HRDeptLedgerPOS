<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PerEmpList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PerEmpList))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PLLChkBox01 = New System.Windows.Forms.CheckBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.PLLBtn01 = New System.Windows.Forms.Button()
        Me.PLLTbx01 = New System.Windows.Forms.TextBox()
        Me.PLLGrid01 = New System.Windows.Forms.DataGridView()
        Me.CMenu01 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteThisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PLLGrid01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenu01.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.PLLChkBox01)
        Me.GroupBox1.Controls.Add(Me.Label44)
        Me.GroupBox1.Controls.Add(Me.PLLBtn01)
        Me.GroupBox1.Controls.Add(Me.PLLTbx01)
        Me.GroupBox1.Controls.Add(Me.PLLGrid01)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1146, 580)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Firebrick
        Me.Label1.Location = New System.Drawing.Point(6, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 18)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Nik"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(173, 35)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(412, 25)
        Me.TextBox1.TabIndex = 25
        '
        'PLLChkBox01
        '
        Me.PLLChkBox01.AutoSize = True
        Me.PLLChkBox01.Location = New System.Drawing.Point(827, 35)
        Me.PLLChkBox01.Name = "PLLChkBox01"
        Me.PLLChkBox01.Size = New System.Drawing.Size(127, 19)
        Me.PLLChkBox01.TabIndex = 24
        Me.PLLChkBox01.Text = "ALL INFORMATION "
        Me.PLLChkBox01.UseVisualStyleBackColor = True
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.Firebrick
        Me.Label44.Location = New System.Drawing.Point(170, 13)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(48, 18)
        Me.Label44.TabIndex = 23
        Me.Label44.Text = "Nama:"
        '
        'PLLBtn01
        '
        Me.PLLBtn01.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PLLBtn01.Location = New System.Drawing.Point(710, 35)
        Me.PLLBtn01.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PLLBtn01.Name = "PLLBtn01"
        Me.PLLBtn01.Size = New System.Drawing.Size(111, 22)
        Me.PLLBtn01.TabIndex = 22
        Me.PLLBtn01.Text = "Search"
        Me.PLLBtn01.UseVisualStyleBackColor = True
        '
        'PLLTbx01
        '
        Me.PLLTbx01.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PLLTbx01.Location = New System.Drawing.Point(3, 36)
        Me.PLLTbx01.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PLLTbx01.Name = "PLLTbx01"
        Me.PLLTbx01.Size = New System.Drawing.Size(164, 25)
        Me.PLLTbx01.TabIndex = 21
        '
        'PLLGrid01
        '
        Me.PLLGrid01.AllowUserToAddRows = False
        Me.PLLGrid01.AllowUserToDeleteRows = False
        Me.PLLGrid01.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.PLLGrid01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PLLGrid01.ContextMenuStrip = Me.CMenu01
        Me.PLLGrid01.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PLLGrid01.Location = New System.Drawing.Point(3, 68)
        Me.PLLGrid01.Name = "PLLGrid01"
        Me.PLLGrid01.ReadOnly = True
        Me.PLLGrid01.Size = New System.Drawing.Size(1140, 509)
        Me.PLLGrid01.TabIndex = 1
        '
        'CMenu01
        '
        Me.CMenu01.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteThisToolStripMenuItem, Me.OutToolStripMenuItem})
        Me.CMenu01.Name = "CMenu01"
        Me.CMenu01.Size = New System.Drawing.Size(108, 48)
        '
        'DeleteThisToolStripMenuItem
        '
        Me.DeleteThisToolStripMenuItem.Name = "DeleteThisToolStripMenuItem"
        Me.DeleteThisToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteThisToolStripMenuItem.Text = "Delete"
        '
        'OutToolStripMenuItem
        '
        Me.OutToolStripMenuItem.Name = "OutToolStripMenuItem"
        Me.OutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.OutToolStripMenuItem.Text = "Out"
        '
        'PerEmpList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1146, 580)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PerEmpList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Personalia List [Ledger]"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PLLGrid01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu01.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PLLGrid01 As System.Windows.Forms.DataGridView
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents PLLTbx01 As System.Windows.Forms.TextBox
    Friend WithEvents PLLChkBox01 As System.Windows.Forms.CheckBox
    Friend WithEvents CMenu01 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteThisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents PLLBtn01 As System.Windows.Forms.Button
End Class
