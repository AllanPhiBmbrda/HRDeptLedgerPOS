Public Class PerDateSU

    Private Sub DSCmb01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DSCmb01.KeyPress
        e.Handled = True
    End Sub

    Private Sub PerDateSU_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadDB2()
    End Sub

    Sub ItemCodeAsCode()

        Dim GetCode As Int32

        Select Case GetCode
            Case Is >= 100
                MessageBox.Show("Result is " & GetCode)
            Case Is >= 50
                MessageBox.Show("Result is " & GetCode)
            Case Is >= 20
                MessageBox.Show("Result is " & GetCode)
            Case Is >= 10
                MessageBox.Show("Result is " & GetCode)
            Case Is >= 1
                MessageBox.Show("Result is " & GetCode)
            Case Else
                MessageBox.Show("Result is Nothing")
        End Select

    End Sub


    Sub SaveDateSU()

        Dim DaSUMonth As String = DSDT01.Value.ToString("MMM", CustomtoUS)
        Dim DaSuYr As String = DSDT01.Value.ToString("yyyy", CustomtoUS)

        'DSDT01.Value.ToString("MMM yyyy", CustomtoUS)

        CheckDateIndoEnglish(DaSUMonth)

        SQL = Nothing
        SQL = SQL & "Select * From pgj_periodesu "
        SQL = SQL & "Where psu_periode = ('" & DSCmb01.Text & "') "
        SQL = SQL & "and psu_perioderng = ('" & PublicMonth & " " & DaSuYr & "') "
        OpenTbl(PLConn, PLTb1, SQL)
        If Not PLTb1.RecordCount <> 0 Then
            PLTb1.AddNew()
        End If

        PLTb1("psu_periode").Value() = DSCmb01.Text
        PLTb1("psu_perioderng").Value() = PublicMonth & " " & DaSuYr
        PLTb1("psu_awal").Value() = DSDT02.Value.ToString("yyyy-MM-dd", CustomtoUS)
        PLTb1("psu_akhir").Value() = DSDT03.Value.ToString("yyyy-MM-dd", CustomtoUS)
        PLTb1("psu_aktif").Value() = "Yes"
        PLTb1("psu_count").Value() = GetNumDays

        PLTb1.Update()
        MessageBox.Show("Successfully Saved", Me.Text)
        Me.Dispose()

    End Sub

    Sub SavetoAktifDate()
        SQL = Nothing
        SQL = SQL & "Select psu_aktif From pgj_periodesu "
        SQL = SQL & "Where psu_aktif = ('" & "Yes" & "') "
        OpenTbl(PLConn, PLTb3, SQL)
        If PLTb3.RecordCount > 0 Then
            PLTb3("psu_aktif").Value() = "No"
            PLTb3.Update()
        End If
    End Sub

    Dim GetSUDate As Date
    Dim GetSUDateLast As Date
    Dim SaveSUDate As Date
    Dim GetNumDays As Int32

    Sub SaveDateCtrl()

        GetSUDate = DSDT02.Value.ToString("yyyy-MM-dd", CustomtoUS)
        GetSUDateLast = DSDT03.Value.ToString("yyyy-MM-dd", CustomtoUS)
        GetNumDays = DateDiff(DateInterval.Day, GetSUDate, GetSUDateLast)

        Select Case GetNumDays
            Case Is < 0
                MessageBox.Show("Invalid Date Range")
            Case Else

                For i = 0 To GetNumDays

                    If i >= 16 Then
                        Exit For
                    End If

                    Dim DaSUMonth As String = DSDT01.Value.ToString("MMM", CustomtoUS)
                    Dim DaSuYr As String = DSDT01.Value.ToString("yyyy", CustomtoUS)

                    'DSDT01.Value.ToString("MMM yyyy", CustomtoUS)

                    CheckDateIndoEnglish(DaSUMonth)
                    SaveSUDate = GetSUDate.AddDays(i)

                    SQL = Nothing
                    SQL = SQL & "Select * From pgj_daycontrol "
                    SQL = SQL & "Where dc_periode = ('" & DSCmb01.Text & "') "
                    SQL = SQL & "and dc_perioderng = ('" & PublicMonth & " " & DaSuYr & "') "
                    SQL = SQL & "and dc_date = ('" & SaveSUDate.ToString("yyyy-MM-dd", CustomtoUS) & "') "
                    OpenTbl(PLConn, PLTb2, SQL)
                    If Not PLTb2.RecordCount <> 0 Then
                        PLTb2.AddNew()
                    End If

                    PLTb2("dc_periode").Value() = DSCmb01.Text
                    PLTb2("dc_perioderng").Value() = PublicMonth & " " & DaSuYr
                    PLTb2("dc_date").Value() = SaveSUDate.ToString("yyyy-MM-dd", CustomtoUS)
                    PLTb2("dc_count").Value() = (i + 1).ToString

                    Select Case SaveSUDate.ToString("dddd", CustomtoUS)
                        Case "Sunday"
                            PLTb2("dc_hb").Value = "Sun"
                        Case "Saturday"
                            PLTb2("dc_hb").Value = "Sat"
                        Case Else
                            PLTb2("dc_hb").Value = "None"
                    End Select
                    PLTb2.Update()

                Next
        End Select
    End Sub

    Sub DeleteDateCtrl()

        Dim DaSUMonth As String = DSDT01.Value.ToString("MMM", CustomtoUS)
        Dim DaSuYr As String = DSDT01.Value.ToString("yyyy", CustomtoUS)

        'DSDT01.Value.ToString("MMM yyyy", CustomtoUS)

        CheckDateIndoEnglish(DaSUMonth)

        For k = 1 To 16
            SQL = Nothing
            SQL = SQL & "Select * From pgj_daycontrol "
            SQL = SQL & "Where dc_periode = ('" & DSCmb01.Text & "') "
            SQL = SQL & "and dc_perioderng = ('" & PublicMonth & " " & DaSuYr & "') "
            SQL = SQL & "and dc_count= ('" & k.ToString & "') "
            OpenTbl(PLConn, PLTb3, SQL)
            If PLTb3.RecordCount > 0 Then
                PLTb3.Delete()
            End If
        Next

    End Sub

    Sub DeletePerDeSU()

        Dim DaSUMonth As String = DSDT01.Value.ToString("MMM", CustomtoUS)
        Dim DaSuYr As String = DSDT01.Value.ToString("yyyy", CustomtoUS)

        'DSDT01.Value.ToString("MMM yyyy", CustomtoUS)

        CheckDateIndoEnglish(DaSUMonth)

        SQL = Nothing
        SQL = SQL & "Select * From pgj_periodesu "
        SQL = SQL & "Where dc_periode = ('" & DSCmb01.Text & "') "
        SQL = SQL & "and dc_perioderng = ('" & PublicMonth & " " & DaSuYr & "') "
        OpenTbl(PLConn, PLTb4, SQL)
        If PLTb4.RecordCount > 0 Then
            PLTb4.Delete()
        End If

    End Sub
    Private Sub DTBtn01_Click(sender As Object, e As EventArgs) Handles DTBtn01.Click
        Try
            Select Case DSCmb01.Text
                Case Nothing, ""
                    MessageBox.Show("Please Check the Required Items")
                Case Else

                    Try
                        DeletePerDeSU()
                        DeleteDateCtrl()
                    Catch ex As Exception
                    End Try

                    SavetoAktifDate()
                    SaveDateCtrl()
                    SaveDateSU()

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DSDT02_ValueChanged(sender As Object, e As EventArgs) Handles DSDT02.ValueChanged
        Try
            Dim ChaDate As Date = DSDT02.Value.ToString("dd/MM/yyyy", CustomtoUS)
            DSDT03.Value = ChaDate.AddDays(15)
        Catch ex As Exception
        End Try
    End Sub

End Class