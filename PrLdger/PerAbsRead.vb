
Public Class PerAbsRead

    Private Sub PerAbsRead_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadDB2()
        LoadRevStandard()
    End Sub

    Sub GridHeaderMode()
        With RAGrid01

            .Rows.Clear()
            .Columns.Clear()

            .Columns.Add("col0", "No. Est")
            .Columns.Add("col1", "Nama")
            .Columns.Add("col2", "Tipe")
            .Columns.Add("col3", "Sistem Gaji")
            .Columns.Add("col4", "Count")
            .Columns.Add("col5", "Ketidak Hadiran")
            For b = 0 To .Columns.Count - 1
                .Columns(b).Width = 200
            Next

        End With

    End Sub

    Dim ABEst As String
    Dim ABNama As String
    Dim ABValue As String
    Dim UMRStat As String

    Sub LoadRevStandard()
        SQL = Nothing
        SQL = SQL & "Select `st_aktif`, `st_pdumr`, `st_umr` From pgj_standard "
        SQL = SQL & "Where st_aktif = ('" & CInt(Int(True)) & "') "
        OpenTbl(PLConn, PLTb2, SQL)
        If PLTb2.RecordCount > 0 Then
            UMRStat = PLTb2("st_pdumr").Value()
        End If
    End Sub

    Dim GivTipe As String
    Dim GivSiGaji As String
    Dim GivGjPok As String
    Dim GivGjTjab As String

    Sub GamblingNumber()

        Dim LookData As Int32 = Nothing
        Dim GetID As Int32 = Nothing
        Dim RandomMe As Int32 = Nothing
        Dim CallMyItem As Int32 = Nothing

    End Sub

    Sub LookKHLTipe()

        SQL = Nothing
        SQL = SQL & "Select `rev_nik`, `rev_nama`, `rev_sistem`, `rev_tipe`, `rev_gajpok`, `rev_tunjjab` From pgj_empdatrev "
        SQL = SQL & "Where rev_nik = ('" & ABEst & "') "
        SQL = SQL & "and rev_nama = ('" & ABNama & "') "
        OpenTbl(PLConn, PLTb6, SQL)
        If PLTb3.RecordCount > 0 Then

            GivTipe = IIf(IsDBNull(PLTb6("rev_tipe").Value), "", PLTb6("rev_tipe").Value)
            GivSiGaji = IIf(IsDBNull(PLTb6("rev_sistem").Value), "", PLTb6("rev_sistem").Value)
            GivGjPok = IIf(IsDBNull(PLTb6("rev_gajpok").Value), "", PLTb6("rev_gajpok").Value)
            GivGjTjab = IIf(IsDBNull(PLTb6("rev_tunjjab").Value), "", PLTb6("rev_tunjjab").Value)

        End If
    End Sub

    Sub LoadAbsensi()

        GridHeaderMode()

        Dim DaSUMonth As String = RADt01.Value.ToString("MMM", CustomtoUS)
        Dim DaSuYr As String = RADt01.Value.ToString("yyyy", CustomtoUS)

        CheckDateIndoEnglish(DaSUMonth)

        SQL = Nothing
        SQL = SQL & "Select * From pgj_totabsensi "
        SQL = SQL & "Where ta_periode = ('" & RACmb01.Text & "') "
        SQL = SQL & "and ta_periorng = ('" & PublicMonth & " " & DaSuYr & "') "
        OpenTbl(PLConn, PLTb3, SQL)
        If PLTb3.RecordCount <> 0 Then
            PLTb3.MoveFirst()
            Do While Not PLTb3.EOF

                ABEst = IIf(IsDBNull(PLTb3("ta_est").Value), "", PLTb3("ta_est").Value)
                ABNama = IIf(IsDBNull(PLTb3("ta_name").Value), "", PLTb3("ta_name").Value)
                ABValue = IIf(IsDBNull(PLTb3("ta_value").Value), 0, PLTb3("ta_value").Value)

                LookKHLTipe()

                Dim KHadiran As Int32 = Val(ABValue) * Val(UMRStat) ' 

                RAGrid01.Invoke(DirectCast(Sub() RAGrid01.Rows.Add(ABEst, ABNama, GivTipe, GivSiGaji, ABValue, Val(KHadiran)), MethodInvoker))
                PLTb3.MoveNext()

                ABEst = Nothing
                ABValue = Nothing
                ABNama = Nothing
                GivTipe = Nothing
                GivSiGaji = Nothing

            Loop
        End If
    End Sub

    Dim LPJamVal As Int32
    Dim LPNilaiVal As Int32

    Sub SaveToMainReport()
        Dim DaSUMonth As String = RADt01.Value.ToString("MMM", CustomtoUS)
        Dim DaSuYr As String = RADt01.Value.ToString("yyyy", CustomtoUS)

        CheckDateIndoEnglish(DaSUMonth)

        For i = 0 To RAGrid01.Rows.Count - 1

            SQL = Nothing
            SQL = SQL & "Select * From pgj_trans_tot "
            SQL = SQL & "Where pgj_ttest = ('" & RAGrid01(0, i).Value.ToString & "') "
            SQL = SQL & "and pgj_prrng = ('" & PublicMonth & " " & DaSuYr & "') "
            SQL = SQL & "and pgj_priode = ('" & RACmb01.Text & "') "
            OpenTbl(PLConn, PLTb5, SQL)
            If PLTb5.RecordCount > 0 Then
                ' Calculate 
                Select Case RAGrid01(2, i).Value
                    Case "KHL"
                        Select Case RAGrid01(4, i).Value
                            Case 1
                                LPNilaiVal = (Val(GivGjTjab) + Val(GivGjPok)) / 173
                                PLTb5("pgj_lpnilai").Value = LPNilaiVal
                                PLTb5("pgj_lpjam").Value = RAGrid01(4, i).Value
                            Case 2
                                LPNilaiVal = (Val(GivGjTjab) + Val(GivGjPok)) / 173
                                PLTb5("pgj_lpnilai").Value = LPNilaiVal
                                PLTb5("pgj_lpjam").Value = RAGrid01(4, i).Value
                            Case Is >= 3
                                PLTb5("pgj_lpnilai").Value = "0"
                        End Select
                End Select

                ' Saving
                PLTb5("pgj_absen").Value = RAGrid01(4, i).Value
                PLTb5("pgj_kethad").Value = RAGrid01(5, i).Value
                PLTb5.Update()

                RAGrid01.Invoke(DirectCast(Sub() RAGrid01(6, i).Value = "Has been uploaded", MethodInvoker))
            Else
                RAGrid01.Invoke(DirectCast(Sub() RAGrid01(6, i).Value = "Data Not found", MethodInvoker))
            End If
        Next
    End Sub
    Private Sub RABtn01_Click(sender As Object, e As EventArgs) Handles RABtn01.Click
        Try
            LoadAbsensi()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub RABtn02_Click(sender As Object, e As EventArgs) Handles RABtn02.Click
        Try
            Select Case RAGrid01.Rows.Count
                Case Is <= 0
                Case Else
                    SaveToMainReport()
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub RACmb01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RACmb01.KeyPress
        e.Handled = True
    End Sub

End Class