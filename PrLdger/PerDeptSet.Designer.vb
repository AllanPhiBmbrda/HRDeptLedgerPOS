<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PerDeptSet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PerDeptSet))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DepTbx05 = New System.Windows.Forms.TextBox()
        Me.DepGrid01 = New System.Windows.Forms.DataGridView()
        Me.DepBtn01 = New System.Windows.Forms.Button()
        Me.DepTbx01 = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DepGrid02 = New System.Windows.Forms.DataGridView()
        Me.JabCM01 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DepTbx06 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DepTbx07 = New System.Windows.Forms.TextBox()
        Me.DepTbx02 = New System.Windows.Forms.ComboBox()
        Me.DepBtn02 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DepGrid01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DepGrid02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.JabCM01.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Palatino Linotype", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(676, 419)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(3, 18)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(670, 398)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.DepTbx05)
        Me.TabPage1.Controls.Add(Me.DepGrid01)
        Me.TabPage1.Controls.Add(Me.DepBtn01)
        Me.TabPage1.Controls.Add(Me.DepTbx01)
        Me.TabPage1.Controls.Add(Me.Label25)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(662, 368)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Department"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label3.Location = New System.Drawing.Point(6, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 17)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Dept. Kode :"
        '
        'DepTbx05
        '
        Me.DepTbx05.BackColor = System.Drawing.Color.White
        Me.DepTbx05.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DepTbx05.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepTbx05.Location = New System.Drawing.Point(9, 36)
        Me.DepTbx05.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DepTbx05.Name = "DepTbx05"
        Me.DepTbx05.Size = New System.Drawing.Size(128, 24)
        Me.DepTbx05.TabIndex = 69
        '
        'DepGrid01
        '
        Me.DepGrid01.AllowUserToAddRows = False
        Me.DepGrid01.AllowUserToDeleteRows = False
        Me.DepGrid01.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DepGrid01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DepGrid01.Location = New System.Drawing.Point(9, 67)
        Me.DepGrid01.Name = "DepGrid01"
        Me.DepGrid01.ReadOnly = True
        Me.DepGrid01.Size = New System.Drawing.Size(647, 262)
        Me.DepGrid01.TabIndex = 68
        '
        'DepBtn01
        '
        Me.DepBtn01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.DepBtn01.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepBtn01.Location = New System.Drawing.Point(9, 336)
        Me.DepBtn01.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DepBtn01.Name = "DepBtn01"
        Me.DepBtn01.Size = New System.Drawing.Size(228, 28)
        Me.DepBtn01.TabIndex = 66
        Me.DepBtn01.Text = "&Save"
        Me.DepBtn01.UseVisualStyleBackColor = True
        '
        'DepTbx01
        '
        Me.DepTbx01.BackColor = System.Drawing.Color.White
        Me.DepTbx01.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DepTbx01.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepTbx01.Location = New System.Drawing.Point(143, 36)
        Me.DepTbx01.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DepTbx01.Name = "DepTbx01"
        Me.DepTbx01.Size = New System.Drawing.Size(308, 24)
        Me.DepTbx01.TabIndex = 65
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label25.Location = New System.Drawing.Point(140, 15)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(82, 17)
        Me.Label25.TabIndex = 64
        Me.Label25.Text = "Department :"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage2.Controls.Add(Me.DepGrid02)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.DepTbx06)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.DepTbx07)
        Me.TabPage2.Controls.Add(Me.DepTbx02)
        Me.TabPage2.Controls.Add(Me.DepBtn02)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(662, 368)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Jabatan"
        '
        'DepGrid02
        '
        Me.DepGrid02.AllowUserToAddRows = False
        Me.DepGrid02.AllowUserToDeleteRows = False
        Me.DepGrid02.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DepGrid02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DepGrid02.ContextMenuStrip = Me.JabCM01
        Me.DepGrid02.Location = New System.Drawing.Point(9, 67)
        Me.DepGrid02.Name = "DepGrid02"
        Me.DepGrid02.ReadOnly = True
        Me.DepGrid02.Size = New System.Drawing.Size(644, 259)
        Me.DepGrid02.TabIndex = 75
        '
        'JabCM01
        '
        Me.JabCM01.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.JabCM01.Name = "ContextMenuStrip1"
        Me.JabCM01.Size = New System.Drawing.Size(108, 48)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label5.Location = New System.Drawing.Point(6, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 17)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "Kode Jabatan:"
        '
        'DepTbx06
        '
        Me.DepTbx06.BackColor = System.Drawing.Color.White
        Me.DepTbx06.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DepTbx06.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepTbx06.Location = New System.Drawing.Point(9, 34)
        Me.DepTbx06.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DepTbx06.Name = "DepTbx06"
        Me.DepTbx06.Size = New System.Drawing.Size(158, 24)
        Me.DepTbx06.TabIndex = 73
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label4.Location = New System.Drawing.Point(459, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 17)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Tunj Jabatan:"
        '
        'DepTbx07
        '
        Me.DepTbx07.BackColor = System.Drawing.Color.White
        Me.DepTbx07.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DepTbx07.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepTbx07.Location = New System.Drawing.Point(463, 33)
        Me.DepTbx07.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DepTbx07.Name = "DepTbx07"
        Me.DepTbx07.Size = New System.Drawing.Size(190, 24)
        Me.DepTbx07.TabIndex = 71
        '
        'DepTbx02
        '
        Me.DepTbx02.FormattingEnabled = True
        Me.DepTbx02.Location = New System.Drawing.Point(173, 33)
        Me.DepTbx02.Name = "DepTbx02"
        Me.DepTbx02.Size = New System.Drawing.Size(284, 25)
        Me.DepTbx02.TabIndex = 70
        '
        'DepBtn02
        '
        Me.DepBtn02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.DepBtn02.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepBtn02.Location = New System.Drawing.Point(9, 336)
        Me.DepBtn02.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DepBtn02.Name = "DepBtn02"
        Me.DepBtn02.Size = New System.Drawing.Size(228, 28)
        Me.DepBtn02.TabIndex = 68
        Me.DepBtn02.Text = "&Save"
        Me.DepBtn02.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label2.Location = New System.Drawing.Point(170, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Jabatan"
        '
        'PerDeptSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 419)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PerDeptSet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Department / Jabatan"
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DepGrid01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DepGrid02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.JabCM01.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DepGrid01 As System.Windows.Forms.DataGridView
    Friend WithEvents DepBtn01 As System.Windows.Forms.Button
    Friend WithEvents DepTbx01 As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DepTbx02 As System.Windows.Forms.ComboBox
    Friend WithEvents DepBtn02 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DepTbx05 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DepTbx07 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DepTbx06 As System.Windows.Forms.TextBox
    Friend WithEvents DepGrid02 As System.Windows.Forms.DataGridView
    Friend WithEvents JabCM01 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
