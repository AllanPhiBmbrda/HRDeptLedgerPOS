Public Class PerHolSU

    Private Sub PerHolSU_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadDB2()
        LoadHariBesar()
    End Sub
    Sub HSGRidHeader()
        With HSGrid01
            .Rows.Clear()
            .Columns.Clear()

            .Columns.Add("col0", "Date")
            .Columns.Add("col1", "Hari Besar")
            .Columns(0).Width = 100
            .Columns(1).Width = 175

        End With
    End Sub

    Private Sub HSBtn01_Click(sender As Object, e As EventArgs) Handles HSBtn01.Click
        Select Case HSTbx01.Text
            Case Nothing, ""
                Exit Sub
        End Select

        Try
            SaveHolidate()
        Catch ex As Exception
        End Try

    End Sub

    Sub SaveHolidate()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_holidayset "
        SQL = SQL & "Where hol_date = ('" & HSDPik01.Value.ToString("yyyy-MM-dd", CustomtoUS) & "') "
        OpenTbl(PLConn, PLTb2, SQL)
        If Not PLTb2.RecordCount <> 0 Then
            PLTb2.AddNew()
        End If

        PLTb2("hol_name").Value() = HSTbx01.Text
        PLTb2("hol_date").Value() = HSDPik01.Value.ToString("yyyy-MM-dd")
        PLTb2.Update()
        LoadHariBesar()

    End Sub

    Dim SmaDate As Date

    Sub LoadHariBesar()
        HSGRidHeader()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_holidayset "
        OpenTbl(PLConn, PLTb1, SQL)
        If PLTb1.RecordCount > 0 Then
            PLTb1.MoveFirst()
            Do While Not PLTb1.EOF
                SmaDate = IIf(IsDBNull(PLTb1("hol_date").Value), "", PLTb1("hol_date").Value)
                HSGrid01.Rows.Add(SmaDate.ToString("dd MMM yyyy"), IIf(IsDBNull(PLTb1("hol_name").Value), "", PLTb1("hol_name").Value))
                PLTb1.MoveNext()
            Loop
        End If
    End Sub

    Sub ControlBesar()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_holidaymode"
        OpenTbl(PLConn, PLTb1, SQL)
    End Sub

    Private Sub HSBtn02_Click(sender As Object, e As EventArgs) Handles HSBtn02.Click
        SQL = Nothing
        SQL = SQL & "Select * From pgj_holidayset "
        SQL = SQL & "Where hol_date = ('" & HSDPik01.Value.ToString("yyyy-MM-dd", CustomtoUS) & "') "
        OpenTbl(PLConn, PLTb2, SQL)
        If PLTb2.RecordCount > 0 Then
            PLTb2.Delete()
            LoadHariBesar()
        End If
    End Sub

End Class