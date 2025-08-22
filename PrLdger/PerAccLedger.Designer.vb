<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PerAccLedger
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PerAccLedger))
        Me.group01 = New System.Windows.Forms.GroupBox()
        Me.GridAcc01 = New System.Windows.Forms.DataGridView()
        Me.AccBtn01 = New System.Windows.Forms.Button()
        Me.AccCmb01 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AccTbx03 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AccTbx02 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.AccTbx01 = New System.Windows.Forms.TextBox()
        Me.AccErrorPro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.group01.SuspendLayout()
        CType(Me.GridAcc01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccErrorPro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'group01
        '
        Me.group01.Controls.Add(Me.GridAcc01)
        Me.group01.Controls.Add(Me.AccBtn01)
        Me.group01.Controls.Add(Me.AccCmb01)
        Me.group01.Controls.Add(Me.Label3)
        Me.group01.Controls.Add(Me.Label2)
        Me.group01.Controls.Add(Me.AccTbx03)
        Me.group01.Controls.Add(Me.Label1)
        Me.group01.Controls.Add(Me.AccTbx02)
        Me.group01.Controls.Add(Me.Label4)
        Me.group01.Controls.Add(Me.AccTbx01)
        Me.group01.Dock = System.Windows.Forms.DockStyle.Fill
        Me.group01.Font = New System.Drawing.Font("Palatino Linotype", 8.25!)
        Me.group01.Location = New System.Drawing.Point(0, 0)
        Me.group01.Name = "group01"
        Me.group01.Size = New System.Drawing.Size(863, 212)
        Me.group01.TabIndex = 1
        Me.group01.TabStop = False
        '
        'GridAcc01
        '
        Me.GridAcc01.AllowUserToAddRows = False
        Me.GridAcc01.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.GridAcc01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridAcc01.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GridAcc01.Location = New System.Drawing.Point(351, 15)
        Me.GridAcc01.Name = "GridAcc01"
        Me.GridAcc01.ReadOnly = True
        Me.GridAcc01.Size = New System.Drawing.Size(508, 195)
        Me.GridAcc01.TabIndex = 41
        '
        'AccBtn01
        '
        Me.AccBtn01.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccBtn01.Location = New System.Drawing.Point(92, 188)
        Me.AccBtn01.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AccBtn01.Name = "AccBtn01"
        Me.AccBtn01.Size = New System.Drawing.Size(107, 22)
        Me.AccBtn01.TabIndex = 40
        Me.AccBtn01.Text = "Save"
        Me.AccBtn01.UseVisualStyleBackColor = True
        '
        'AccCmb01
        '
        Me.AccCmb01.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccCmb01.FormattingEnabled = True
        Me.AccCmb01.Items.AddRange(New Object() {"HIGH", "MID", "LOW"})
        Me.AccCmb01.Location = New System.Drawing.Point(92, 111)
        Me.AccCmb01.Name = "AccCmb01"
        Me.AccCmb01.Size = New System.Drawing.Size(223, 25)
        Me.AccCmb01.TabIndex = 37
        Me.AccCmb01.Text = "LOW"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label3.Location = New System.Drawing.Point(12, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 17)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Privilege :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label2.Location = New System.Drawing.Point(12, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 17)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Nama Asli :"
        '
        'AccTbx03
        '
        Me.AccTbx03.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccTbx03.Location = New System.Drawing.Point(92, 79)
        Me.AccTbx03.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AccTbx03.Name = "AccTbx03"
        Me.AccTbx03.Size = New System.Drawing.Size(223, 24)
        Me.AccTbx03.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label1.Location = New System.Drawing.Point(12, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Password :"
        '
        'AccTbx02
        '
        Me.AccTbx02.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccTbx02.Location = New System.Drawing.Point(92, 47)
        Me.AccTbx02.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AccTbx02.Name = "AccTbx02"
        Me.AccTbx02.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.AccTbx02.Size = New System.Drawing.Size(223, 24)
        Me.AccTbx02.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label4.Location = New System.Drawing.Point(12, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "User ID :"
        '
        'AccTbx01
        '
        Me.AccTbx01.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.AccTbx01.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccTbx01.Location = New System.Drawing.Point(92, 15)
        Me.AccTbx01.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AccTbx01.Name = "AccTbx01"
        Me.AccTbx01.Size = New System.Drawing.Size(223, 24)
        Me.AccTbx01.TabIndex = 6
        '
        'AccErrorPro
        '
        Me.AccErrorPro.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.AccErrorPro.ContainerControl = Me
        Me.AccErrorPro.Icon = CType(resources.GetObject("AccErrorPro.Icon"), System.Drawing.Icon)
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'PerAccLedger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 212)
        Me.Controls.Add(Me.group01)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "PerAccLedger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PerAccLedger"
        Me.group01.ResumeLayout(False)
        Me.group01.PerformLayout()
        CType(Me.GridAcc01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccErrorPro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents group01 As System.Windows.Forms.GroupBox
    Friend WithEvents GridAcc01 As System.Windows.Forms.DataGridView
    Friend WithEvents AccBtn01 As System.Windows.Forms.Button
    Friend WithEvents AccCmb01 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AccTbx03 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AccTbx02 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents AccTbx01 As System.Windows.Forms.TextBox
    Friend WithEvents AccErrorPro As System.Windows.Forms.ErrorProvider
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
