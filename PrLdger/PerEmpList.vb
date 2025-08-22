Public Class PerEmpList

    Private Sub PerEmpList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadDB2()
    End Sub

    Sub PLLGridHeader()
        With PLLGrid01
            .Rows.Clear()
            .Columns.Clear()

            Select Case PLLChkBox01.Checked

                Case True

                Case False
                    .Columns.Add("col0", "No. EST")
                    .Columns.Add("col1", "NAMA")
                    .Columns.Add("col2", "No. KTP")
                    .Columns.Add("col3", "KHT / KHT")
                    .Columns.Add("col4", "SUB KHL")
                    .Columns.Add("col5", "Masuk Kerja")
                    .Columns.Add("col6", "Efektik Kerja")
                    .Columns.Add("col7", "Bagian / Dept. ")
                    .Columns.Add("col8", "Jabatan")
                    .Columns.Add("col9", "GJ Pokok")
                    .Columns.Add("col10", "TJ. Jabatan")
                    .Columns.Add("col11", "TJ. Masa Kerja")
                    .Columns.Add("col12", "TJ. Kerajinan")
                    .Columns.Add("col13", "BPJS T.Kerja")
                    .Columns.Add("col14", "BPJS Kesehatan")
                    For y = 0 To .Columns.Count - 1
                        .Columns(y).Width = 150
                    Next
            End Select
        End With
    End Sub
    Sub LoadEmpData()

        PLLGridHeader()

        Dim NamaG As String
        Dim EstG As String
        Dim KHG As String
        Dim KHSubG As String
        Dim JabG As String
        Dim GJPokG As String
        Dim TJabG As String
        Dim MKerG As Date
        Dim EKerG As Date
        Dim DeptG As String
        Dim KTPG As String

        Dim TJKerj As String
        Dim BPTKerj As String
        Dim BPKese As String

        SQL = Nothing
        SQL = SQL & "Select * From pgj_empdat "
        SQL = SQL & "Where emp_noest like ('" & PLLTbx01.Text + "%" & "') "
        SQL = SQL & "and emp_aktif = ('" & "Yes" & "') "
        SQL = SQL & "or emp_nama like ('" & PLLTbx01.Text + "%" & "') "
        SQL = SQL & "and emp_aktif = ('" & "Yes" & "') "
        OpenTbl(PLConn, PLTb3, SQL)
        If PLTb3.RecordCount <> 0 Then
            PLTb3.MoveFirst()
            Do While Not PLTb3.EOF

                KHG = IIf(IsDBNull(PLTb3("emp_khtkhl").Value), "", PLTb3("emp_khtkhl").Value)
                ' KHSubG = IIf(IsDBNull(PLTb3("emp_exkhtkhl").Value), "", PLTb3("emp_exkhtkhl").Value)
                KTPG = IIf(IsDBNull(PLTb3("emp_noktp").Value), "", PLTb3("emp_noktp").Value)
                JabG = IIf(IsDBNull(PLTb3("emp_jab").Value), "", PLTb3("emp_jab").Value)
                DeptG = IIf(IsDBNull(PLTb3("emp_dept").Value), "", PLTb3("emp_dept").Value)
                NamaG = IIf(IsDBNull(PLTb3("emp_nama").Value), "", PLTb3("emp_nama").Value)
                EstG = IIf(IsDBNull(PLTb3("emp_noest").Value), "", PLTb3("emp_noest").Value)
                MKerG = IIf(IsDBNull(PLTb3("emp_mskerja").Value), Today, PLTb3("emp_mskerja").Value)
                EKerG = IIf(IsDBNull(PLTb3("emp_efkerja").Value), Today, PLTb3("emp_efkerja").Value)
                TJKerj = IIf(IsDBNull(PLTb3("emp_tjkera").Value), "", PLTb3("emp_tjkera").Value)
                GJPokG = IIf(IsDBNull(PLTb3("emp_gjpokok").Value), "", PLTb3("emp_gjpokok").Value)
                TJabG = IIf(IsDBNull(PLTb3("emp_tjjabatan").Value), "", PLTb3("emp_tjjabatan").Value)
                BPTKerj = IIf(IsDBNull(PLTb3("emp_bpjstkerj").Value), "", PLTb3("emp_bpjstkerj").Value)
                BPKese = IIf(IsDBNull(PLTb3("emp_bpjskeseh").Value), "", PLTb3("emp_bpjskeseh").Value)

                Dim Date01 As String = Nothing
                Dim Date02 As String = Nothing

                Dim Date03 As String = Nothing
                Dim DateGot(1000) As String

                For i = 0 To 1000
                    DateGot(i) = "HighRisk" & i.ToString
                Next

                For B = 0 To 1000
                    DateGot(B) = "Read to Risk" & B.ToString
                Next

                Select Case MKerG
                    Case Today
                    Case Else
                        Date01 = MKerG.ToString("dd MMM yyyy")
                End Select

                Select Case EKerG
                    Case Today
                    Case Else
                        Date01 = EKerG.ToString("dd MMM yyyy")
                End Select

                PLLGrid01.Invoke(DirectCast(Sub() PLLGrid01.Rows.Add(EstG, NamaG, KTPG, KHG, KHSubG, Date01, Date02, DeptG, JabG, GJPokG, TJabG, "", TJKerj, BPTKerj, BPKese), MethodInvoker))
                PLTb3.MoveNext()
            Loop
        End If
    End Sub

    Private Sub PLLBtn01_Click(sender As Object, e As EventArgs) Handles PLLBtn01.Click
        Try
            LoadEmpData()
        Catch ex As Exception
        End Try
    End Sub

    Sub DeletePersonnel()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_empdat "
        SQL = SQL & "Where emp_noest = ('" & PLLGrid01.CurrentRow.Cells(0).Value.ToString & "') "
        SQL = SQL & "and emp_nama = ('" & PLLGrid01.CurrentRow.Cells(1).Value.ToString & "') "
        OpenTbl(PLConn, PLTb4, SQL)
        If PLTb4.RecordCount > 0 Then
            PLTb4.Delete()
        End If
    End Sub
    Private Sub CMenu01_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CMenu01.Opening
        Select Case PLLGrid01.Rows.Count
            Case Is <> 0
            Case Else
                e.Cancel = True
        End Select
    End Sub

    Dim GetRow As Int32
    Private Sub PLLGrid01_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles PLLGrid01.CellMouseDown
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub
        PLLGrid01.CurrentCell = PLLGrid01(e.ColumnIndex, e.RowIndex)
        GetRow = e.RowIndex
    End Sub

    Private Sub DeleteThisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteThisToolStripMenuItem.Click
        If PLLGrid01.RowCount <> 0 Then
            Dim R As Integer = MessageBox.Show("Are you sure to DELETE this [ " & PLLGrid01.CurrentRow.Cells(1).Value.ToString & " ]?", "DELETE MODE", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If R = DialogResult.Yes Then
                If PLLGrid01.Rows.Count <> 0 Then
                    DeletePersonnel()
                    PLLGrid01.Rows.RemoveAt(GetRow)
                End If
            End If
        End If
    End Sub

    Sub OutEmpmode()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_empdat "
        SQL = SQL & "Where emp_noest = ('" & PLLGrid01.CurrentRow.Cells(0).Value.ToString & "') "
        SQL = SQL & "and emp_nama = ('" & PLLGrid01.CurrentRow.Cells(1).Value.ToString & "') "
        OpenTbl(PLConn, PLTb4, SQL)
        If PLTb4.RecordCount > 0 Then
            PLTb4("emp_aktif").Value = "No"
            PLTb4.Update()
        End If
    End Sub
    Private Sub OutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutToolStripMenuItem.Click
        If PLLGrid01.RowCount <> 0 Then
            Dim R As Integer = MessageBox.Show("Are you sure to OUT/RESIGN this [ " & PLLGrid01.CurrentRow.Cells(1).Value.ToString & " ]?", "RESIGN MODE", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If R = DialogResult.Yes Then
                If PLLGrid01.Rows.Count <> 0 Then
                    OutEmpmode()
                    PLLGrid01.Rows.RemoveAt(GetRow)
                End If
            End If
        End If
    End Sub
    
End Class