Imports System.Threading

Public Class PerAbsensiEdit

    Private Sub PerAbsensiEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadDB2()
        LoadAbsensiTot()
    End Sub

    Sub GridHeaderMode()
        With PAEGrid01
            .Rows.Clear()
            .Columns.Clear()

            .Columns.Add("col0", "Nik / No.Est")
            .Columns.Add("col1", "Nama")
            .Columns.Add("col2", "Number of Day")

            For k = 0 To .Columns.Count - 1
                .Columns(k).Width = 250
            Next
        End With
    End Sub

    Sub LoadAbsensiTot()

        Dim DaSUMonth As String = PAEDP01.Value.ToString("MMM", CustomtoUS)
        Dim DaSuYr As String = PAEDP01.Value.ToString("yyyy", CustomtoUS)

        CheckDateIndoEnglish(DaSUMonth)

        GridHeaderMode()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_totabsensi "

        Select Case PAETbx04.Text
            Case Nothing, ""
                SQL = SQL & "Where ta_periode = ('" & PAECmb01.Text & "') "
                SQL = SQL & "and ta_periorng = ('" & PublicMonth & " " & DaSuYr & "') "
            Case Else
                SQL = SQL & "Where ta_periode = ('" & PAECmb01.Text & "') "
                SQL = SQL & "and ta_periorng = ('" & PublicMonth & " " & DaSuYr & "') "
                SQL = SQL & "and ta_est like ('" & PAETbx04.Text.Replace(" ", "%") & "%" & "') "
                SQL = SQL & "or ta_name like ('" & PAETbx04.Text.Replace("'", "/") & "%" & "') "
                SQL = SQL & "and ta_periode = ('" & PAECmb01.Text & "') "
                SQL = SQL & "and ta_periorng = ('" & PublicMonth & " " & DaSuYr & "') "
        End Select

        OpenTbl(PLConn, PLTb3, SQL)
        If PLTb3.RecordCount <> 0 Then
            PLTb3.MoveFirst()
            Do While Not PLTb3.EOF
                PAEGrid01.Invoke(DirectCast(Sub() PAEGrid01.Rows.Add(IIf(IsDBNull(PLTb3("ta_est").Value), "", PLTb3("ta_est").Value), _
                                                    IIf(IsDBNull(PLTb3("ta_name").Value), "", PLTb3("ta_name").Value), _
                                                     IIf(IsDBNull(PLTb3("ta_value").Value), "", PLTb3("ta_value").Value)), MethodInvoker))
                PLTb3.MoveNext()
            Loop
        End If

    End Sub

    Sub SaveAbsensiTot()
        Dim DaSUMonth As String = PAEDP01.Value.ToString("MMM", CustomtoUS)
        Dim DaSuYr As String = PAEDP01.Value.ToString("yyyy", CustomtoUS)

        CheckDateIndoEnglish(DaSUMonth)

        SQL = Nothing
        SQL = SQL & "Select * From pgj_totabsensi "
        SQL = SQL & "Where ta_periode = ('" & PAECmb01.Text & "') "
        SQL = SQL & "and ta_periorng = ('" & PublicMonth & " " & DaSuYr & "') "
        SQL = SQL & "and ta_est = ('" & PAETbx01.Text & "') "
        OpenTbl(PLConn, PLTb4, SQL)
        If PLTb4.RecordCount > 0 Then
            PLTb4("ta_value").Value = PAETbx03.Text
            PLTb4.Update()
        End If

        PAETbx03.Clear()
        PAETbx02.Clear()
        PAETbx01.Clear()

        LoadAbsensiTot()
        MessageBox.Show("Done")
    End Sub

    Private Sub PAETbx01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PAETbx01.KeyPress
        e.Handled = True
    End Sub

    Private Sub PAETbx02_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PAETbx02.KeyPress
        e.Handled = True
    End Sub

    Private Sub PAECmb01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PAECmb01.KeyPress
        e.Handled = True
    End Sub

    Private Sub PAEBtn01_Click(sender As Object, e As EventArgs) Handles PAEBtn01.Click
        Try
            SaveAbsensiTot()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub PAETbx04_KeyDown(sender As Object, e As KeyEventArgs) Handles PAETbx04.KeyDown
        Select Case PAEGrid01.Rows.Count
            Case Is >= 1
                Select Case e.KeyCode
                    Case Keys.Down, Keys.Up
                        PAEGrid01.Focus()
                End Select
        End Select
    End Sub


    Private Sub PAEGrid01_KeyDown(sender As Object, e As KeyEventArgs) Handles PAEGrid01.KeyDown

        'Try
        '    Select Case e.KeyCode

        '        Case Keys.Down, Keys.Enter
        '            Dim i = PAEGrid01.CurrentRow.Index
        '            i += 1
        '            PAETbx01.Text = PAEGrid01.Item(0, i).Value
        '            PAETbx02.Text = PAEGrid01.Item(1, i).Value
        '            PAETbx03.Text = PAEGrid01.Item(2, i).Value

        '        Case Keys.Up

        '            Dim i = PAEGrid01.CurrentRow.Index
        '            i -= 1
        '            PAETbx01.Text = PAEGrid01.Item(0, i).Value
        '            PAETbx02.Text = PAEGrid01.Item(1, i).Value
        '            PAETbx03.Text = PAEGrid01.Item(2, i).Value

        '            'PAETbx01.Text = PAEGrid01.CurrentRow.Cells(0).Value.ToString
        '            'PAETbx02.Text = PAEGrid01.CurrentRow.Cells(1).Value.ToString
        '            'PAETbx03.Text = PAEGrid01.CurrentRow.Cells(2).Value.ToString

        '    End Select
        'Catch ex As Exception

        'End Try
  
    End Sub

    Private Sub PAETbx03_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PAETbx03.KeyPress
        If Not InValid2.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
    End Sub


    Private Sub PAEGrid01_KeyUp(sender As Object, e As KeyEventArgs) Handles PAEGrid01.KeyUp
        PAETbx01.Text = PAEGrid01.CurrentRow.Cells(0).Value.ToString
        PAETbx02.Text = PAEGrid01.CurrentRow.Cells(1).Value.ToString
        PAETbx03.Text = PAEGrid01.CurrentRow.Cells(2).Value.ToString
    End Sub

    Private Sub PAETbx04_KeyUp(sender As Object, e As KeyEventArgs) Handles PAETbx04.KeyUp
        Select Case PAETbx04.Text.Length
            Case Is >= 1
                LoadAbsensiTot()
        End Select
    End Sub


End Class