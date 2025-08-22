Public Class PerDeptSet

    Sub SaveDep()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_deptlist "
        SQL = SQL & "Where dep_depkode = ('" & DepTbx05.Text & "') "
        OpenTbl(PLConn, PLTb1, SQL)
        If Not PLTb1.RecordCount <> 0 Then
            PLTb1.AddNew()
        End If

        PLTb1("dep_depname").Value() = DepTbx01.Text
        PLTb1("dep_depkode").Value() = DepTbx05.Text
        PLTb1.Update()
        DepTbx01.Text = Nothing
        DepTbx05.Text = Nothing
        MessageBoxSuc("Successfully Saved", Me.Text)
    End Sub

    Sub DelDep()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_deptlist "
        SQL = SQL & "Where dep_depname = ('" & DepGrid01.CurrentRow.Cells(1).Value.ToString & "') "
        OpenTbl(PLConn, PLTb1, SQL)
        If PLTb1.RecordCount > 0 Then
            PLTb1.Delete()
            MessageBoxSuc("Successfully Deleted", Me.Text)
        End If
        LoadDept()

    End Sub
    Sub SaveJab()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_jablist "
        SQL = SQL & "Where pgj_jabkode = ('" & DepTbx06.Text & "') "
        SQL = SQL & "And pgj_jabname = ('" & DepTbx02.Text & "') "
        OpenTbl(PLConn, PLTb1, SQL)
        If Not PLTb1.RecordCount <> 0 Then
            PLTb1.AddNew()
        End If

        ' PLTb1("pgj_deplink").Value() = DepCmb01.Text
        PLTb1("pgj_jabname").Value() = DepTbx02.Text
        PLTb1("pgj_jabkode").Value() = DepTbx06.Text
        PLTb1("pgj_tunjab").Value() = DepTbx07.Text

        PLTb1.Update()
        MessageBoxSuc("Successfully Saved", Me.Text)
        DepTbx02.Text = Nothing
    End Sub

    Sub DelJab()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_jablist "
        SQL = SQL & "Where pgj_jabkode = ('" & DepGrid01.CurrentRow.Cells(0).Value.ToString & "') "
        SQL = SQL & "And pgj_jabname = ('" & DepGrid01.CurrentRow.Cells(1).Value.ToString & "') "
        OpenTbl(PLConn, PLTb1, SQL)
        If PLTb1.RecordCount > 0 Then
            PLTb1.Delete()
        End If

        DepTbx02.Text = Nothing
        MessageBoxSuc(PLTb1.RecordCount.ToString & " Item has been Deleted", Me.Text)
    End Sub

    Sub GridHeader01()
        With DepGrid01
            .Rows.Clear()
            .Columns.Clear()
            .Columns.Add("col0", "Kode Department")
            .Columns.Add("col1", "DEPARTMENT")
            .Columns(0).Width = 100
            .Columns(1).Width = 300
        End With
    End Sub

    Sub LoadDept()
        GridHeader01()
        'Dim DeptHist As New AutoCompleteStringCollection
        'DepCmb01.Items.Clear()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_deptlist "
        OpenTbl(PLConn, PLTb1, SQL)
        If PLTb1.RecordCount <> 0 Then
            PLTb1.MoveFirst()
            Do While Not PLTb1.EOF
                Dim StringUp As String = IIf(IsDBNull(PLTb1("dep_depname").Value), "", PLTb1("dep_depname").Value)
                Dim StringUp2 As String = IIf(IsDBNull(PLTb1("dep_depkode").Value), "", PLTb1("dep_depkode").Value)
                DepGrid01.Rows.Add(StringUp2.ToUpper, StringUp.ToUpper)
                ' DepCmb01.Items.Add(StringUp.ToUpper)
                ' DeptHist.Add(StringUp.ToUpper)
                PLTb1.MoveNext()
            Loop
        End If

        'DepCmb01.AutoCompleteMode = AutoCompleteMode.Suggest
        'DepCmb01.AutoCompleteSource = AutoCompleteSource.CustomSource
        'DepCmb01.AutoCompleteCustomSource = DeptHist

        'GridHeader01()
        'Dim DeptHist As New AutoCompleteStringCollection
        'DepCmb01.Items.Clear()
        'SQL = Nothing
        'SQL = SQL & "Select * From p_deplist "
        'OpenTbl(PCConn, PCTb7, SQL)
        'If PCTb7.RecordCount <> 0 Then
        '    PCTb7.MoveFirst()
        '    Do While Not PCTb7.EOF
        '        Dim StringUp As String = PCTb7("p_deptname").Value
        '        DepGrid01.Rows.Add(StringUp.ToUpper)
        '        DepCmb01.Items.Add(StringUp.ToUpper)
        '        DeptHist.Add(StringUp.ToUpper)
        '        PCTb7.MoveNext()
        '    Loop
        'End If
        'DepCmb01.AutoCompleteMode = AutoCompleteMode.Suggest
        'DepCmb01.AutoCompleteSource = AutoCompleteSource.CustomSource
        'DepCmb01.AutoCompleteCustomSource = DeptHist

    End Sub

    Sub GridHeader02()
        With DepGrid02
            .Rows.Clear()
            .Columns.Clear()

            .Columns.Add("col0", "Jab Kode")
            .Columns.Add("col1", "Jab Nama")
            .Columns.Add("col2", "Tunjangan Jabatan")

            For c = 0 To .Columns.Count - 1
                .Columns(c).Width = 150
            Next

        
        End With
    End Sub


    Sub ReLoadAllJabatan()
        SQL = Nothing
        SQL = SQL & "Select `rev_kojabatan`, `rev_jabatan`, `rev_tunjjab` From pgj_empdatrev "
        SQL = SQL & "Where rev_kojabatan = ('" & DepTbx06.Text & "') "
        SQL = SQL & "And rev_jabatan = ('" & DepTbx02.Text & "') "
        OpenTbl(PLConn, PLTb2, SQL)
        If PLTb2.RecordCount > 0 Then
            PLTb2.MoveFirst()
            Do While Not PLTb2.EOF
                PLTb2("rev_tunjjab").Value() = DepTbx07.Text
                PLTb2.Update()
                PLTb2.MoveNext()
            Loop
        End If
    End Sub

    Sub LoadJabMode()
        GridHeader02()
        'Dim JabHist As New AutoCompleteStringCollection
        'DepTbx02.Items.Clear()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_jablist "
        SQL = SQL & "Order By pgj_jabkode Asc "
        ' SQL = SQL & "Where pgj_deplink = ('" & DepCmb01.Text & "') "
        OpenTbl(PLConn, PLTb2, SQL)
        If PLTb2.RecordCount <> 0 Then
            PLTb2.MoveFirst()
            Do While Not PLTb2.EOF
                Dim getjabkode As String = IIf(IsDBNull(PLTb2("pgj_jabkode").Value), "", PLTb2("pgj_jabkode").Value)
                Dim getjab As String = IIf(IsDBNull(PLTb2("pgj_jabname").Value), "", PLTb2("pgj_jabname").Value)
                Dim gettunkab As String = IIf(IsDBNull(PLTb2("pgj_tunjab").Value), "", PLTb2("pgj_tunjab").Value)
                DepGrid02.Rows.Add(getjabkode.ToUpper, getjab.ToUpper, gettunkab.ToUpper)
                '    DepTbx02.Items.Add()
                '   JabHist.Add(StringUp.ToUpper)
                PLTb2.MoveNext()
            Loop
        End If

        'DepTbx02.AutoCompleteMode = AutoCompleteMode.Suggest
        'DepTbx02.AutoCompleteSource = AutoCompleteSource.CustomSource
        'DepTbx02.AutoCompleteCustomSource = JabHist

        'Dim JabHist As New AutoCompleteStringCollection
        'DepTbx02.Items.Clear()
        'SQL = Nothing
        'SQL = SQL & "Select * From p_jablist "
        'SQL = SQL & "Where p_deplink = ('" & DepCmb01.Text & "') "
        'OpenTbl(PCConn, PCTb8, SQL)
        'If PCTb8.RecordCount <> 0 Then
        '    PCTb8.MoveFirst()
        '    Do While Not PCTb8.EOF
        '        Dim StringUp As String = PCTb8("p_jabname").Value
        '        DepTbx02.Items.Add(StringUp.ToUpper)
        '        JabHist.Add(StringUp.ToUpper)
        '        PCTb8.MoveNext()
        '    Loop
        'End If
        'DepTbx02.AutoCompleteMode = AutoCompleteMode.Suggest
        'DepTbx02.AutoCompleteSource = AutoCompleteSource.CustomSource
        'DepTbx02.AutoCompleteCustomSource = JabHist
    End Sub
    Private Sub PerDeptJab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadDB2()
        LoadDept()
        LoadJabMode()
    End Sub
    Private Sub DepBtn01_Click(sender As Object, e As EventArgs) Handles DepBtn01.Click
        'If DepTbx01.Text = Nothing Or DepTbx01.TextLength <= 5 Then
        '    MessageBoxPrb("Please Insert your New Department Item", Me.Text)
        'Else
        '    SaveDep()
        '    LoadDept()
        'End If

        Select Case Nothing
            Case DepTbx01.Text
                MessageBoxPrb("Please Insert your New Department", Me.Text)
            Case DepTbx05.Text
                MessageBoxPrb("Please Insert your New Department Code", Me.Text)
            Case Else
                SaveDep()
                LoadDept()
        End Select
    End Sub
    Private Sub DepBtn02_Click(sender As Object, e As EventArgs) Handles DepBtn02.Click
        If DepTbx02.Text = Nothing Or DepTbx02.Text = Nothing Then
            MessageBoxPrb("Please Select Department/ Type your New Position(Jabatan)", Me.Text)
        Else
            SaveJab()
            Try
                ReLoadAllJabatan()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            LoadJabMode()
        End If
    End Sub

    Private Sub DepBtn03_Click(sender As Object, e As EventArgs)
        If DepTbx01.Text = Nothing Or DepTbx01.TextLength <= 5 Then
            MessageBoxPrb("Please Select Department/ Type your New Position(Jabatan)", Me.Text)
        Else
            DelDep()
            LoadDept()
        End If
    End Sub

    Private Sub DepTbx01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DepTbx01.KeyPress
        If e.KeyChar.ToString = ChrW(Keys.Enter) Then
            DepBtn01.PerformClick()
            e.Handled = True
        End If
    End Sub

    Private Sub DepTbx02_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar.ToString = ChrW(Keys.Enter) Then
            DepBtn02.PerformClick()
            e.Handled = True
        End If
    End Sub

    Private Sub DepGrid01_DoubleClick(sender As Object, e As EventArgs) Handles DepGrid01.DoubleClick
        If DepGrid01.RowCount <> 0 Then
            If PurUser.PerPR = "ADMIN" Or PurUser.PerPR = "LAKAN" Or PurUser.PerPR = "HIGH" Then
                Dim R As Integer = MessageBox.Show("Are you sure to DELETE this " & DepGrid01.CurrentRow.Cells(1).Value.ToString & "?", "DELETE MODE", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If R = DialogResult.Yes Then
                    DelDep()
                End If
            Else
                MessageBoxPrb("[" + PurUser.PerUID + "] : Access Denied", "Invalid Access")
            End If
        End If
    End Sub

    Private Sub DepCmb01_SelectedIndexChanged(sender As Object, e As EventArgs)
        LoadJabMode()
    End Sub

    Private Sub DepTbx02_KeyPress1(sender As Object, e As KeyPressEventArgs) Handles DepTbx02.KeyPress
        If Char.IsLetter(e.KeyChar) Then

            e.KeyChar = Char.ToUpper(e.KeyChar)

        End If
    End Sub
    Dim GetRow As Int32
    Private Sub DepGrid02_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DepGrid02.CellMouseDown
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub
        DepGrid02.CurrentCell = DepGrid02(e.ColumnIndex, e.RowIndex)
        GetRow = e.RowIndex
    End Sub

    Private Sub DepGrid02_DoubleClick(sender As Object, e As EventArgs) Handles DepGrid02.DoubleClick

    End Sub

    Private Sub DepTbx07_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DepTbx07.KeyPress
        If Not InValid3.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
    End Sub


    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim R As Integer = MessageBox.Show("Are you sure to DELETE this " & DepGrid02.CurrentRow.Cells(1).Value.ToString & "?", "DELETE MODE", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If R = DialogResult.Yes Then
            If DepGrid02.Rows.Count <> 0 Then
                DelJab()
                LoadJabMode()
            End If
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        DepTbx06.Text = DepGrid02.CurrentRow.Cells(0).Value.ToString
        DepTbx02.Text = DepGrid02.CurrentRow.Cells(1).Value.ToString
        DepTbx07.Text = DepGrid02.CurrentRow.Cells(2).Value.ToString
    End Sub

    Private Sub JabCM01_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles JabCM01.Opening
        Select Case DepGrid02.Rows.Count
            Case Is <> 0
            Case Else
                e.Cancel = True
        End Select
    End Sub
End Class