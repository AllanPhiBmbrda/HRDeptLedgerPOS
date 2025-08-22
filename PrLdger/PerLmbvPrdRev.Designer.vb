<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PerLmbvPrdRev
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PerLmbvPrdRev))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LPBtn02 = New System.Windows.Forms.Button()
        Me.LPBtn01 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.LPCmb01 = New System.Windows.Forms.ComboBox()
        Me.LPDp01 = New System.Windows.Forms.DateTimePicker()
        Me.LPGrid01 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.LPGrid01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LPBtn02)
        Me.GroupBox1.Controls.Add(Me.LPBtn01)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label44)
        Me.GroupBox1.Controls.Add(Me.LPCmb01)
        Me.GroupBox1.Controls.Add(Me.LPDp01)
        Me.GroupBox1.Controls.Add(Me.LPGrid01)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1071, 554)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'LPBtn02
        '
        Me.LPBtn02.Location = New System.Drawing.Point(578, 34)
        Me.LPBtn02.Name = "LPBtn02"
        Me.LPBtn02.Size = New System.Drawing.Size(152, 23)
        Me.LPBtn02.TabIndex = 53
        Me.LPBtn02.Text = "Upload"
        Me.LPBtn02.UseVisualStyleBackColor = True
        '
        'LPBtn01
        '
        Me.LPBtn01.Location = New System.Drawing.Point(420, 35)
        Me.LPBtn01.Name = "LPBtn01"
        Me.LPBtn01.Size = New System.Drawing.Size(152, 23)
        Me.LPBtn01.TabIndex = 52
        Me.LPBtn01.Text = "Search"
        Me.LPBtn01.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Firebrick
        Me.Label3.Location = New System.Drawing.Point(173, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 18)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Periode :"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.Firebrick
        Me.Label44.Location = New System.Drawing.Point(3, 17)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(99, 18)
        Me.Label44.TabIndex = 50
        Me.Label44.Text = "Periode Range :"
        '
        'LPCmb01
        '
        Me.LPCmb01.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LPCmb01.FormattingEnabled = True
        Me.LPCmb01.Items.AddRange(New Object() {"Periode I", "Periode II"})
        Me.LPCmb01.Location = New System.Drawing.Point(173, 35)
        Me.LPCmb01.Name = "LPCmb01"
        Me.LPCmb01.Size = New System.Drawing.Size(158, 23)
        Me.LPCmb01.TabIndex = 49
        Me.LPCmb01.Text = "Periode I"
        '
        'LPDp01
        '
        Me.LPDp01.CustomFormat = "MMM yyyy"
        Me.LPDp01.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LPDp01.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.LPDp01.Location = New System.Drawing.Point(6, 35)
        Me.LPDp01.Name = "LPDp01"
        Me.LPDp01.ShowUpDown = True
        Me.LPDp01.Size = New System.Drawing.Size(161, 23)
        Me.LPDp01.TabIndex = 48
        '
        'LPGrid01
        '
        Me.LPGrid01.AllowUserToAddRows = False
        Me.LPGrid01.AllowUserToDeleteRows = False
        Me.LPGrid01.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.LPGrid01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.LPGrid01.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LPGrid01.Location = New System.Drawing.Point(3, 64)
        Me.LPGrid01.Name = "LPGrid01"
        Me.LPGrid01.ReadOnly = True
        Me.LPGrid01.Size = New System.Drawing.Size(1065, 487)
        Me.LPGrid01.TabIndex = 0
        '
        'PerLmbvPrdRev
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1071, 554)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PerLmbvPrdRev"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Read Lembur Produksi"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.LPGrid01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LPGrid01 As System.Windows.Forms.DataGridView
    Friend WithEvents LPBtn01 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents LPCmb01 As System.Windows.Forms.ComboBox
    Friend WithEvents LPDp01 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LPBtn02 As System.Windows.Forms.Button
End Class
