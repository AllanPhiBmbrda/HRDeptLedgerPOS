Public Class PerAbsInput

    Dim DatePrRNG As String
    Dim DatePrde As String

    Private Sub PerAbsInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadDB2()
    End Sub

    Sub AbGridHeader()
        With ABGrid01
            .Rows.Clear()
            .Columns.Clear()
            .Columns.Add("col0", "No Est")
            .Columns.Add("col1", "Nama")
            .Columns(1).Width = 200
        End With
    End Sub

    Sub LoadDateCnt()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_daycontrol "
        SQL = SQL & "Where dc_date = ('" & AbDp01.Value.ToString("yyyy-MM-dd") & "') "
        OpenTbl(PLConn, PLTb5, SQL)
        If PLTb5.RecordCount > 0 Then
            DatePrRNG = IIf(IsDBNull(PLTb5("dc_perioderng").Value), "", PLTb5("dc_perioderng").Value)
            DatePrde = IIf(IsDBNull(PLTb5("dc_periode").Value), "", PLTb5("dc_periode").Value)
        Else
            DatePrRNG = Nothing
            DatePrde = Nothing
        End If
    End Sub

    Sub SaveAbsensi()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_absensi "
        SQL = SQL & "Where pgj_abest = ('" & AbTbx01.Text & "') "
        SQL = SQL & "and pgj_abname = ('" & AbTbx02.Text & "') "
        SQL = SQL & "and pgj_date = ('" & AbDp01.Value.ToString("yyyy-MM-dd") & "') "
        OpenTbl(PLConn, PLTb4, SQL)
        If Not PLTb4.RecordCount > 0 Then
            PLTb4.AddNew()
        End If
        
        PLTb4("pgj_abest").Value = AbTbx01.Text
        PLTb4("pgj_abname").Value = AbTbx02.Text
        PLTb4("pgj_date").Value = AbDp01.Value.ToString("yyyy-MM-dd")
        PLTb4("pgj_periode").Value = DatePrde
        PLTb4("pgj_perrng").Value = DatePrRNG
        PLTb4.Update()
    End Sub
    Sub SaveTotalAbs()
        Dim CntAdd As Int32 = 0

        SQL = Nothing
        SQL = SQL & "Select * From pgj_totabsensi "
        SQL = SQL & "Where ta_est = ('" & AbTbx01.Text & "') "
        SQL = SQL & "and ta_periorng = ('" & DatePrRNG & "') "
        SQL = SQL & "and ta_periode = ('" & DatePrde & "') "
        OpenTbl(PLConn, PLTb5, SQL)
        If Not PLTb5.RecordCount > 0 Then
            PLTb5.AddNew()
        ElseIf PLTb5.RecordCount > 0 Then
            CntAdd = Val(PLTb5("ta_value").Value)
        End If

        PLTb5("ta_est").Value = AbTbx01.Text
        PLTb5("ta_name").Value = AbTbx02.Text
        PLTb5("ta_periode").Value = DatePrde
        PLTb5("ta_periorng").Value = DatePrRNG
        PLTb5("ta_value").Value = CntAdd + 1
        PLTb5.Update()

    End Sub
    Sub TbxClearMode()
        AbTbx01.Clear()
        AbTbx02.Clear()
    End Sub

    Private Sub AbTbx02_KeyPress(sender As Object, e As KeyPressEventArgs) Handles AbTbx02.KeyPress
        e.Handled = True
    End Sub

    Private Sub DTBtn01_Click(sender As Object, e As EventArgs) Handles DTBtn01.Click
        LoadDateCnt()
        Try
            Select Case DatePrRNG
                Case Nothing, ""
                    MessageBox.Show("Your Date is Not Registered / Data Tanggal belum terdaftar")
                    Exit Sub
            End Select
            Select Case AbTbx02.Text
                Case Nothing, ""
                    Exit Sub
            End Select
            SaveAbsensi()
            SaveTotalAbs()
        Catch ex As Exception
        End Try
    End Sub

    Sub LoadEmpMode()
        AbGridHeader()
        SQL = Nothing
        SQL = SQL & "Select emp_nama, emp_noest From pgj_empdat "
        SQL = SQL & "Where emp_noest like ('" & AbTbx01.Text + "%" & "') "

        SQL = SQL & "or emp_nama like ('" & AbTbx01.Text + "%" & "') "
        OpenTbl(PLConn, PLTb1, SQL)
        If PLTb1.RecordCount <> 0 Then
            PLTb1.MoveFirst()
            Do While Not PLTb1.EOF
                ABGrid01.Rows.Add(IIf(IsDBNull(PLTb1("emp_noest").Value), "", PLTb1("emp_noest").Value), IIf(IsDBNull(PLTb1("emp_nama").Value), "", PLTb1("emp_nama").Value))
                PLTb1.MoveNext()
            Loop
        End If
    End Sub

    Private Sub AbTbx01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles AbTbx01.KeyPress
        AbTbx02.Clear()
        Label4.Text = "Typing . . . . "
        If e.KeyChar.ToString = ChrW(Keys.Enter) Then
            ABGrid01.Visible = True
            LoadEmpMode()
            ABGrid01.Focus()
        End If
    End Sub

    Private Sub ABGrid01_KeyDown(sender As Object, e As KeyEventArgs) Handles ABGrid01.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ABGrid01.Rows.Count > 0 Then
                AbTbx01.Text = ABGrid01.CurrentRow.Cells(0).Value.ToString ' Est
                AbTbx02.Text = ABGrid01.CurrentRow.Cells(1).Value.ToString ' Nama
                ABGrid01.Visible = False
            End If
        End If

        If e.KeyCode = Keys.Escape Then
            AbTbx01.Focus()
            Label4.Text = "Typing . . . . "
        End If
    End Sub
    Private Sub AbTbx01_LostFocus(sender As Object, e As EventArgs) Handles AbTbx01.LostFocus
        Label4.Text = "Idle"
    End Sub

    Private Sub AbTbx01_TextChanged(sender As Object, e As EventArgs) Handles AbTbx01.TextChanged
    End Sub

    Private Sub ABGrid01_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ABGrid01.CellContentClick
    End Sub

End Class