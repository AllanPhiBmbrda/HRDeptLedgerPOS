<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PerLmbSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PerLmbSummary))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LSBtn02 = New System.Windows.Forms.Button()
        Me.LSBtn01 = New System.Windows.Forms.Button()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.LSDp01 = New System.Windows.Forms.DateTimePicker()
        Me.LSGrid01 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.LSGrid01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LSBtn02)
        Me.GroupBox1.Controls.Add(Me.LSBtn01)
        Me.GroupBox1.Controls.Add(Me.Label44)
        Me.GroupBox1.Controls.Add(Me.LSDp01)
        Me.GroupBox1.Controls.Add(Me.LSGrid01)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1078, 588)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'LSBtn02
        '
        Me.LSBtn02.Location = New System.Drawing.Point(933, 39)
        Me.LSBtn02.Name = "LSBtn02"
        Me.LSBtn02.Size = New System.Drawing.Size(139, 23)
        Me.LSBtn02.TabIndex = 47
        Me.LSBtn02.Text = "Excel"
        Me.LSBtn02.UseVisualStyleBackColor = True
        '
        'LSBtn01
        '
        Me.LSBtn01.Location = New System.Drawing.Point(788, 39)
        Me.LSBtn01.Name = "LSBtn01"
        Me.LSBtn01.Size = New System.Drawing.Size(139, 23)
        Me.LSBtn01.TabIndex = 46
        Me.LSBtn01.Text = "Generate"
        Me.LSBtn01.UseVisualStyleBackColor = True
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.Firebrick
        Me.Label44.Location = New System.Drawing.Point(6, 19)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(99, 18)
        Me.Label44.TabIndex = 42
        Me.Label44.Text = "Periode Range :"
        '
        'LSDp01
        '
        Me.LSDp01.CustomFormat = "MMM yyyy"
        Me.LSDp01.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSDp01.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.LSDp01.Location = New System.Drawing.Point(12, 40)
        Me.LSDp01.Name = "LSDp01"
        Me.LSDp01.ShowUpDown = True
        Me.LSDp01.Size = New System.Drawing.Size(161, 23)
        Me.LSDp01.TabIndex = 40
        '
        'LSGrid01
        '
        Me.LSGrid01.AllowUserToAddRows = False
        Me.LSGrid01.AllowUserToDeleteRows = False
        Me.LSGrid01.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.LSGrid01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.LSGrid01.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LSGrid01.Location = New System.Drawing.Point(3, 69)
        Me.LSGrid01.Name = "LSGrid01"
        Me.LSGrid01.ReadOnly = True
        Me.LSGrid01.Size = New System.Drawing.Size(1072, 516)
        Me.LSGrid01.TabIndex = 0
        '
        'PerLmbSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 588)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "PerLmbSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lembur Summary"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.LSGrid01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LSGrid01 As System.Windows.Forms.DataGridView
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents LSDp01 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LSBtn01 As System.Windows.Forms.Button
    Friend WithEvents LSBtn02 As System.Windows.Forms.Button
End Class
