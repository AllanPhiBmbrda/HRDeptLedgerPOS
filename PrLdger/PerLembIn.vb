Public Class PerLembIn

    Dim DatePrRNG As String
    Dim DatePrde As String
    Dim hourH As Int32
    Dim minM As Int32
    Dim YearY As Int32
    Dim MonM As Int32
    Dim DayD As Int32

    Dim GetMeGp As String '  Get my Gaji Pokok
    Dim GetMeTJ As String '  Get Tunjangan Jabatan

    Dim HoliOK As Boolean = False

    Sub AbGridHeader()
        With LbGrid01
            .Rows.Clear()
            .Columns.Clear()
            .Columns.Add("col0", "No Est")
            .Columns.Add("col1", "Nama")
            .Columns.Add("col2", "Gaji Pokok")
            .Columns.Add("col3", "Tunj. Jabatan")
            .Columns.Add("col4", "Effektif Kerja")
            .Columns(1).Width = 200
        End With
    End Sub

    Sub LoadDateCnt()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_daycontrol "
        SQL = SQL & "Where dc_date = ('" & LeDp01.Value.ToString("yyyy-MM-dd") & "') "
        OpenTbl(PLConn, PLTb5, SQL)
        If PLTb5.RecordCount > 0 Then
            DatePrRNG = IIf(IsDBNull(PLTb5("dc_perioderng").Value), "", PLTb5("dc_perioderng").Value)
            DatePrde = IIf(IsDBNull(PLTb5("dc_periode").Value), "", PLTb5("dc_periode").Value)
        Else
            DatePrRNG = Nothing
            DatePrde = Nothing
        End If
    End Sub

    Sub SaveLembur()
        Select Case GetOT
            Case Nothing, Is <= 0
                Label4.Text = "Incomplete /  Tidak Simpan"
            Case Else

                SQL = Nothing
                SQL = SQL & "Select * From pgj_lembur "
                SQL = SQL & "Where lem_est = ('" & LbTbx01.Text & "') "
                SQL = SQL & "and lem_nama = ('" & LbTbx02.Text & "') "
                SQL = SQL & "and lem_date = ('" & LeDp01.Value.ToString("yyyy-MM-dd") & "') "
                OpenTbl(PLConn, PLTb7, SQL)
                If Not PLTb7.RecordCount <> 0 Then
                    PLTb7.AddNew()
                End If

                PLTb7("lem_est").Value = LbTbx01.Text
                PLTb7("lem_nama").Value = LbTbx02.Text
                PLTb7("lem_jam").Value = GetOT
                PLTb7("lem_min").Value = minM.ToString

                PLTb7("lem_prdrng").Value = DatePrRNG
                PLTb7("lem_prde").Value = DatePrde

                PLTb7("pgj_salvalue").Value = FinalValueR.ToString
                PLTb7("lem_date").Value = LeDp01.Value.ToString("yyyy-MM-dd")

                PLTb7.Update()
                Label4.Text = "Done / Sudah Simpan"
                TbxClearMode()
        End Select
    End Sub

    Sub TbxClearMode()
        LbTbx01.Clear()
        LbTbx02.Clear()
    End Sub

    Sub LoadEmpMode()
        AbGridHeader()

        SQL = Nothing
        SQL = SQL & "Select `rev_nama`, `rev_nik`, `rev_gajpok`, `rev_tunjjab`, `rev_tglefektif`, `rev_kojabatan` From pgj_empdatrev "
        SQL = SQL & "Where rev_nik like ('" & LbTbx01.Text + "%" & "') "
        SQL = SQL & "or rev_nama like ('" & LbTbx01.Text + "%" & "') "
        OpenTbl(PLConn, PLTb1, SQL)

        If PLTb1.RecordCount <> 0 Then
            PLTb1.MoveFirst()
            Do While Not PLTb1.EOF

                Dim EfDate As Date = IIf(IsDBNull(PLTb1("rev_tglefektif").Value), Today, PLTb1("rev_tglefektif").Value)
                LbGrid01.Rows.Add(IIf(IsDBNull(PLTb1("rev_nik").Value), "", PLTb1("rev_nik").Value), IIf(IsDBNull(PLTb1("rev_nama").Value), "", PLTb1("rev_nama").Value), IIf(IsDBNull(PLTb1("rev_gajpok").Value), 0, PLTb1("rev_gajpok").Value), IIf(IsDBNull(PLTb1("rev_tunjjab").Value), 0, PLTb1("rev_tunjjab").Value), EfDate.ToString("dd MMM yyyy"))
                PLTb1.MoveNext()
            Loop
        End If
    End Sub

    Sub GetHourDiff()

        Dim DateC3 As DateTime = LeDp02.Value.ToString
        Dim toDate As DateTime = LeDp03.Value.ToString

        Do Until toDate.AddYears(-1) < DateC3
            YearY += 1
            toDate = toDate.AddYears(-1)
        Loop

        Do Until toDate.AddMonths(-1) < DateC3
            MonM += 1
            toDate = toDate.AddMonths(-1)
        Loop

        Do Until toDate.AddDays(-1) < DateC3
            DayD += 1
            toDate = toDate.AddDays(-1)
        Loop

        Do Until toDate.AddHours(-1) < DateC3
            hourH += 1
            toDate = toDate.AddHours(-1)
        Loop

        Do Until toDate.AddMinutes(-1) < DateC3
            minM += 1
            toDate = toDate.AddMinutes(-1)
        Loop
    End Sub
    Sub CheckHoliday()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_holidayset "
        SQL = SQL & "Where hol_date like ('" & LeDp01.Value.ToString("yyyy-MM-dd") & "') "
        OpenTbl(PLConn, PLTb5, SQL)
        If PLTb5.RecordCount > 0 Then
            HoliOK = True
        Else
            HoliOK = False
        End If
    End Sub
    Private Sub LbTbx01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles LbTbx01.KeyPress
        LbTbx02.Clear()
        Label4.Text = "Typing . . . . "

        LbGrid01.Visible = True
        LoadEmpMode()

        If e.KeyChar.ToString = ChrW(Keys.Enter) Then
            'LbGrid01.Visible = True
            'LoadEmpMode()
            LbGrid01.Focus()
        End If
    End Sub

    Dim BetHalf As String
    Dim TotalValueR As String
    Dim FinalValueR As Int32
    Dim GetOT As Int32
    Sub CalcValue()
        GetOT = 0
        FinalValueR = 0
        TotalValueR = 0
        hourH = 0
        minM = 0

        GetHourDiff()

        Dim DateHBget As String = LeDp01.Value.ToString("dddd", CustomtoUS)

        Select Case HoliOK '  For a day that a Holiday 

            Case True
                Select Case DateHBget ' For Saturday Calculation
                    Case "Sat"
                        GetOT = hourH - 5
                        If GetOT >= 1 Then
                            For ik = 1 To GetOT
                                If ik >= 2 Then
                                    TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ)) / 173) * 4
                                Else
                                    TotalValueR = (Val(GetMeGp) / 173) * 3
                                End If
                                FinalValueR += Val(TotalValueR)
                            Next
                        End If
                    Case Else
                        GetOT = hourH - 7
                        If GetOT >= 1 Then
                            For ik = 1 To GetOT
                                If ik >= 2 Then
                                    TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ)) / 173) * 4
                                Else
                                    TotalValueR = (Val(GetMeGp) / 173) * 3
                                End If
                                FinalValueR += Val(TotalValueR)
                            Next
                        End If
                End Select
            Case False
                Select Case DateHBget ' For Saturday calculation
                    Case "Sat"
                        GetOT = hourH - 5
                        If GetOT >= 1 Then
                            For ik = 1 To GetOT
                                If ik >= 2 Then
                                    ' TotalValueR = (Val(GetMeGp) / 173) * 2
                                    TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ)) / 173) * 4
                                Else
                                    ' TotalValueR = (Val(GetMeGp) / 173) * 1.5
                                    TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ)) / 173) * 1.5
                                End If
                                FinalValueR += Val(TotalValueR)
                            Next
                        End If
                    Case Else
                        Select Case LeChk01.Checked '  For Day that Saturday is not a HALFDAY
                            Case True
                                GetOT = hourH - 5
                                If GetOT >= 1 Then
                                    For ik = 1 To GetOT
                                        If ik >= 2 Then
                                            'TotalValueR = (Val(GetMeGp) / 173) * 2
                                            TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ)) / 173) * 2
                                        Else
                                            ' TotalValueR = (Val(GetMeGp) / 173) * 1.5
                                            TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ)) / 173) * 1.5
                                        End If
                                        FinalValueR += Val(TotalValueR)
                                    Next
                                End If
                            Case False
                                GetOT = hourH - 7
                                If GetOT >= 1 Then
                                    For ik = 1 To GetOT
                                        If ik >= 2 Then
                                            'TotalValueR = (Val(GetMeGp) / 173) * 2
                                            TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ)) / 173) * 2
                                        Else
                                            '    TotalValueR = (Val(GetMeGp) / 173) * 1.5
                                            TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ)) / 173) * 1.5
                                        End If
                                        FinalValueR += Val(TotalValueR)
                                    Next
                                End If
                        End Select
                End Select
        End Select

        If FinalValueR <= 0 Then
            FinalValueR = 0
        End If

    End Sub

    Private Sub LbBtn01_Click(sender As Object, e As EventArgs) Handles LbBtn01.Click

        'LoadDateCnt()
        'Try
        '    Select Case DatePrRNG
        '        Case Nothing, ""
        '            MessageBox.Show("Your Date is Not Registered / Data Tanggal belum terdaftar")
        '            Exit Sub
        '    End Select
        '    Select Case LbTbx02.Text
        '        Case Nothing, ""
        '            Exit Sub
        '    End Select
        '    CheckHoliday()
        '    CalcValue()
        '    SaveLembur()
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString & " : " & vbNewLine & "Please Look for the problem")
        'End Try

        Try
            Dim AddMyDay As Date = LeDp03.Text
            LeDp03.Text = AddMyDay.Date.AddMinutes(1)
            LoadDateCnt()
            Select Case DatePrRNG
                Case Nothing, ""
                    MessageBox.Show("Your Date is Not Registered / Data Tanggal belum terdaftar")
                    Exit Sub
            End Select

            Select Case LbTbx02.Text
                Case Nothing, ""
                    Exit Sub
            End Select

            CountTahun()
            LemLoadMasaKerja()

            CheckHoliday()
            RevCalcValue()
            RevSavelembur()

        Catch ex As Exception
            MessageBox.Show(ex.Message & " " & ex.ToString)
        End Try

    End Sub

    Dim ForHour As String
    Dim ForMin As String

    Sub RevSavelembur()

        Dim currentHour As Integer
        Dim currentMinute As Integer

        Dim getMyTime As Date = LeDp02.Value

        currentHour = getMyTime.Hour
        currentMinute = getMyTime.Minute

        Select Case GetOT
            Case Nothing, Is <= 0
                Label4.Text = "Incomplete /  Tidak Simpan"
            Case Else

                SQL = Nothing
                SQL = SQL & "Select * From prj_revlembur "
                SQL = SQL & "Where prj_revnik = ('" & LbTbx01.Text & "') "
                SQL = SQL & "and prj_revnama = ('" & LbTbx02.Text & "') "
                SQL = SQL & "and prj_revdate = ('" & LeDp01.Value.ToString("yyyy-MM-dd") & "') "
                OpenTbl(PLConn, PLTb7, SQL)
                If Not PLTb7.RecordCount <> 0 Then
                    PLTb7.AddNew()
                End If

                PLTb7("prj_revnik").Value = LbTbx01.Text
                PLTb7("prj_revnama").Value = LbTbx02.Text
                PLTb7("prj_revprng").Value = DatePrRNG
                PLTb7("prj_revrpiode").Value = DatePrde

                Select Case currentHour
                    Case Is >= 23
                        PLTb7("prj_revjam3").Value = ForHour.ToString & "." & ForMin.ToString
                        PLTb7("prj_revalue3").Value = FinalValueR.ToString
                    Case Is >= 16
                        PLTb7("prj_revjam2").Value = ForHour.ToString & "." & ForMin.ToString
                        PLTb7("prj_revalue2").Value = FinalValueR.ToString
                    Case Is >= 6
                        PLTb7("prj_revjam1").Value = ForHour.ToString & "." & ForMin.ToString
                        PLTb7("prj_revalue1").Value = FinalValueR.ToString
                End Select

                PLTb7("prj_revdate").Value = LeDp01.Value.ToString("yyyy-MM-dd")

                PLTb7.Update()
                Label4.Text = "Done / Sudah Simpan"
                TbxClearMode()

        End Select
        ForHour = Nothing
        ForMin = Nothing
    End Sub

    Sub RevCalcValue()
        GetOT = 0
        FinalValueR = 0
        TotalValueR = 0
        hourH = 0
        minM = 0

        GetHourDiff()

        Dim DateHBget As String = LeDp01.Value.ToString("dddd", CustomtoUS)

        Select Case HoliOK '  For a day that a Holiday 
            Case True
                Select Case DateHBget ' For Saturday Calculation
                    Case "Sat"
                        GetOT = (hourH + 5) - 5
                        If GetOT >= 1 Then
                            For ik = 1 To GetOT
                                If ik >= 2 Then
                                    ' TotalValueR = (Val(GetMeGp) / 173) * 4
                                    TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ) + getTunjMs) / 173) * 4
                                Else
                                    ' TotalValueR = (Val(GetMeGp) / 173) * 3
                                    TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ) + getTunjMs) / 173) * 3
                                End If
                                FinalValueR += Val(TotalValueR)
                            Next
                        End If
                    Case Else
                        GetOT = (hourH + 7) - 7
                        If GetOT >= 1 Then
                            For ik = 1 To GetOT
                                If ik >= 2 Then
                                    ' TotalValueR = (Val(GetMeGp) / 173) * 4
                                    TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ) + getTunjMs) / 173) * 4
                                Else
                                    '  TotalValueR = (Val(GetMeGp) / 173) * 3
                                    TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ) + getTunjMs) / 173) * 3
                                End If
                                FinalValueR += Val(TotalValueR)
                            Next
                        End If
                End Select
            Case False
                Select Case DateHBget ' For Saturday calculation
                    Case "Sat"
                        GetOT = (hourH + 5) - 5
                        If GetOT >= 1 Then
                            For ik = 1 To GetOT
                                If ik >= 2 Then
                                    '   TotalValueR = (Val(GetMeGp) / 173) * 2
                                    TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ) + getTunjMs) / 173) * 2
                                Else
                                    ' TotalValueR = (Val(GetMeGp) / 173) * 1.5
                                    TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ) + getTunjMs) / 173) * 1.5
                                End If
                                FinalValueR += Val(TotalValueR)
                            Next
                        End If
                    Case Else
                        Select Case LeChk01.Checked '  For Day that Saturday is not a HALFDAY
                            Case True
                                GetOT = (hourH + 5) - 5
                                If GetOT >= 1 Then
                                    For ik = 1 To GetOT
                                        If ik >= 2 Then
                                            ' TotalValueR = (Val(GetMeGp) / 173) * 2
                                            TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ) + getTunjMs) / 173) * 2
                                        Else
                                            '  TotalValueR = (Val(GetMeGp) / 173) * 1.5
                                            TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ) + getTunjMs) / 173) * 1.5
                                        End If
                                        FinalValueR += Val(TotalValueR)
                                    Next
                                End If
                            Case False
                                GetOT = (hourH + 7) - 7
                                If GetOT >= 1 Then
                                    For ik = 1 To GetOT
                                        If ik >= 2 Then
                                            '  TotalValueR = (Val(GetMeGp) / 173) * 2
                                            TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ) + getTunjMs) / 173) * 2
                                        Else
                                            TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ) + getTunjMs) / 173) * 1.5
                                            'TotalValueR = (Val(GetMeGp) / 173) * 1.5
                                        End If
                                        FinalValueR += Val(TotalValueR)
                                    Next
                                End If
                        End Select
                End Select
        End Select

        Select Case minM
            Case Is >= 30
                Select Case GetOT
                    Case Is = 1
                        '    TotalValueR = (Val(GetMeGp) / 173) * 2
                        TotalValueR = ((Val(GetMeGp) + Val(GetMeTJ + getTunjMs)) / 173) * 2
                End Select
                BetHalf = ((Val(TotalValueR) / 2))
                FinalValueR = FinalValueR + Val(BetHalf)
        End Select

        ForHour = GetOT.ToString
        ForMin = minM.ToString

        '    MessageBox.Show(FinalValueR.ToString)
        If FinalValueR <= 0 Then
            FinalValueR = 0
        End If

    End Sub

    Private Sub LbTbx02_KeyPress(sender As Object, e As KeyPressEventArgs) Handles LbTbx02.KeyPress
        e.Handled = True
    End Sub

    Private Sub LbTbx01_LostFocus(sender As Object, e As EventArgs) Handles LbTbx01.LostFocus
        Label4.Text = "Idle"
    End Sub

    Private Sub LbGrid01_DoubleClick(sender As Object, e As EventArgs) Handles LbGrid01.DoubleClick
        If LbGrid01.Rows.Count > 0 Then
            LbTbx01.Text = LbGrid01.CurrentRow.Cells(0).Value.ToString ' Est
            LbTbx02.Text = LbGrid01.CurrentRow.Cells(1).Value.ToString ' Nama
            GetMeGp = LbGrid01.CurrentRow.Cells(2).Value.ToString
            GetMeTJ = LbGrid01.CurrentRow.Cells(3).Value.ToString
            LeDp04.Text = LbGrid01.CurrentRow.Cells(4).Value.ToString
            LbGrid01.Visible = False
        End If
    End Sub
    Private Sub LbGrid01_KeyDown(sender As Object, e As KeyEventArgs) Handles LbGrid01.KeyDown
        If e.KeyCode = Keys.Enter Then

            If LbGrid01.Rows.Count > 0 Then
                LbTbx01.Text = LbGrid01.CurrentRow.Cells(0).Value.ToString ' Est
                LbTbx02.Text = LbGrid01.CurrentRow.Cells(1).Value.ToString ' Nama
                GetMeGp = LbGrid01.CurrentRow.Cells(2).Value.ToString
                GetMeTJ = LbGrid01.CurrentRow.Cells(3).Value.ToString
                LbGrid01.Visible = False
            End If
        End If
        If e.KeyCode = Keys.Escape Then
            LbTbx01.Focus()
            Label4.Text = "Typing . . . . "
        End If

    End Sub

    Private Sub LeDp01_ValueChanged(sender As Object, e As EventArgs) Handles LeDp01.ValueChanged
        'Dim GetMeDate As Date = LeDp01.Value

        'Select Case GetMeDate.ToString("dddd")
        '    Case "Saturday", "Sabtu"
        '        LeChk01.Checked = True
        '    Case Else
        '        LeChk01.Checked = False
        'End Select

    End Sub

    Dim getTunjMs As Int64

    Sub LemLoadMasaKerja()
        getTunjMs = 0

        SQL = Nothing
        SQL = SQL & "Select * From pgj_standard "
        SQL = SQL & "Where st_aktif = ('" & "1" & "') "
        OpenTbl(PLConn, PLTb9, SQL)
        If PLTb9.RecordCount > 0 Then

            Select Case YearCount
                Case Is > 10
                    getTunjMs = IIf(IsDBNull(PLTb9("st_Fgr").Value), 0, PLTb9("st_Fgr").Value)
                Case Is >= 6
                    getTunjMs = IIf(IsDBNull(PLTb9("st_Egr").Value), 0, PLTb9("st_Egr").Value)
                Case Is >= 4
                    getTunjMs = IIf(IsDBNull(PLTb9("st_Dgr").Value), 0, PLTb9("st_Dgr").Value)
                Case Is >= 3
                    getTunjMs = IIf(IsDBNull(PLTb9("st_Cgr").Value), 0, PLTb9("st_Cgr").Value)
                Case Is >= 2
                    getTunjMs = IIf(IsDBNull(PLTb9("st_Bgr").Value), 0, PLTb9("st_Bgr").Value)
                Case Is >= 1
                    getTunjMs = IIf(IsDBNull(PLTb9("st_Agr").Value), 0, PLTb9("st_Agr").Value)
            End Select

        End If

    End Sub

    Dim YearCount As Long = Nothing
    Sub CountTahun()
        YearCount = Nothing

        Dim BdayDate As Date = LeDp04.Value
        Dim BdayYearDate As Date = Today
        Dim years As Integer = 0, months As Integer = 0, days As Integer = 0
        Dim toDate As Date = DateTime.Now

        '   Dim DaysCount As String = DateYearDate.Subtract(BdayDate).Days.ToString

        Do Until toDate.AddYears(-1) < BdayDate
            years += 1
            toDate = toDate.AddYears(-1)
        Loop

        Do Until toDate.AddMonths(-1) < BdayDate
            months += 1
            toDate = toDate.AddMonths(-1)
        Loop

        Do Until toDate.AddDays(-1) < BdayDate
            days += 1
            toDate = toDate.AddDays(-1)
        Loop

        YearCount = years
    End Sub

    Private Sub LeDp02_ValueChanged(sender As Object, e As EventArgs) Handles LeDp02.ValueChanged
        LeDp03.Text = LeDp02.Text
    End Sub

    Private Sub PerLembIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadDB2()
    End Sub

End Class