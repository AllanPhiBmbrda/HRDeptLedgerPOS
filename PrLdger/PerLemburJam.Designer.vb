<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PerLemburJam
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PerLemburJam))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PLJamDp02 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PLJamDp01 = New System.Windows.Forms.DateTimePicker()
        Me.PLJamGrid01 = New System.Windows.Forms.DataGridView()
        Me.PLJamBtn02 = New System.Windows.Forms.Button()
        Me.PLJamBtn01 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PLJamGrid01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.PLJamDp02)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.PLJamDp01)
        Me.GroupBox1.Controls.Add(Me.PLJamGrid01)
        Me.GroupBox1.Controls.Add(Me.PLJamBtn02)
        Me.GroupBox1.Controls.Add(Me.PLJamBtn01)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1078, 588)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Firebrick
        Me.Label1.Location = New System.Drawing.Point(227, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 18)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "s/d :"
        '
        'PLJamDp02
        '
        Me.PLJamDp02.CustomFormat = "dd MMM yyyy"
        Me.PLJamDp02.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PLJamDp02.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.PLJamDp02.Location = New System.Drawing.Point(274, 17)
        Me.PLJamDp02.Name = "PLJamDp02"
        Me.PLJamDp02.Size = New System.Drawing.Size(163, 22)
        Me.PLJamDp02.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Firebrick
        Me.Label2.Location = New System.Drawing.Point(3, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 18)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Date: "
        '
        'PLJamDp01
        '
        Me.PLJamDp01.CustomFormat = "dd MMM yyyy"
        Me.PLJamDp01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PLJamDp01.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.PLJamDp01.Location = New System.Drawing.Point(58, 17)
        Me.PLJamDp01.Name = "PLJamDp01"
        Me.PLJamDp01.Size = New System.Drawing.Size(163, 22)
        Me.PLJamDp01.TabIndex = 34
        '
        'PLJamGrid01
        '
        Me.PLJamGrid01.AllowUserToAddRows = False
        Me.PLJamGrid01.AllowUserToDeleteRows = False
        Me.PLJamGrid01.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.PLJamGrid01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PLJamGrid01.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PLJamGrid01.Location = New System.Drawing.Point(3, 49)
        Me.PLJamGrid01.Name = "PLJamGrid01"
        Me.PLJamGrid01.ReadOnly = True
        Me.PLJamGrid01.Size = New System.Drawing.Size(1072, 536)
        Me.PLJamGrid01.TabIndex = 32
        '
        'PLJamBtn02
        '
        Me.PLJamBtn02.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PLJamBtn02.Location = New System.Drawing.Point(943, 14)
        Me.PLJamBtn02.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PLJamBtn02.Name = "PLJamBtn02"
        Me.PLJamBtn02.Size = New System.Drawing.Size(129, 25)
        Me.PLJamBtn02.TabIndex = 31
        Me.PLJamBtn02.Text = "Excel"
        Me.PLJamBtn02.UseVisualStyleBackColor = True
        '
        'PLJamBtn01
        '
        Me.PLJamBtn01.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PLJamBtn01.Location = New System.Drawing.Point(808, 14)
        Me.PLJamBtn01.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PLJamBtn01.Name = "PLJamBtn01"
        Me.PLJamBtn01.Size = New System.Drawing.Size(129, 25)
        Me.PLJamBtn01.TabIndex = 30
        Me.PLJamBtn01.Text = "Search"
        Me.PLJamBtn01.UseVisualStyleBackColor = True
        '
        'PerLemburJam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 588)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "PerLemburJam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Per Lembur Jam"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PLJamGrid01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PLJamBtn02 As System.Windows.Forms.Button
    Friend WithEvents PLJamBtn01 As System.Windows.Forms.Button
    Friend WithEvents PLJamGrid01 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PLJamDp01 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PLJamDp02 As System.Windows.Forms.DateTimePicker
End Class
