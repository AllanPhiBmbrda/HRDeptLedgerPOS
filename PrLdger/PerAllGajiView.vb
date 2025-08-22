Imports System.Threading


Public Class PerAllGajiView

    Private Sub PerAllGajiView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        EDTbx02.Focus()
        LoadDB()
        LoadDB2()
        GridHeaderMode()
        LoadDataNow()

    End Sub

    Sub GridHeaderMode()

        With EDGrid01
            .Rows.Clear()
            .Columns.Clear()

            .Columns.Add("col0", "No")
            .Columns.Add("col1", "No. Est")
            .Columns.Add("col2", "Nama")
            .Columns.Add("col3", "Gaji 1/2b ")
            .Columns.Add("col4", "Absen")
            .Columns.Add("col5", "Pot. ATM")
            .Columns.Add("col6", "Tj. Lain ")
            .Columns.Add("col7", "L. Prd Jam")
            .Columns.Add("col8", "L. Prd Nilai")
            .Columns.Add("col9", "Total Gaji")
            .Columns.Add("col10", "Jam Lmb")
            .Columns.Add("col11", "Ttl Lembur")
            .Columns.Add("col12", "Tj. MsKerja")
            .Columns.Add("col13", "Tj. Kerajinan")
            .Columns.Add("col14", "Tj. Jabatan")
            .Columns.Add("col15", " ")
            .Columns.Add("col16", "Ketidak Hadiran")
            .Columns.Add("col17", "BPJS  T. Kerja")
            .Columns.Add("col18", "BPJS  Kesihatan")
            .Columns.Add("col19", "GAJI NETTO")
            .Columns.Add("col20", "Bagian")
            .Columns.Add("col21", "Jabatan")

            For b = 1 To .Columns.Count - 1
                .Columns(b).Width = 200
            Next

        End With

    End Sub

    Dim GetDTransTot(30) As String

    Sub LoadDataNow()

        Dim DaSUMonth As String = EDDp01.Value.ToString("MMM", CustomtoUS)
        Dim DaSuYr As String = EDDp01.Value.ToString("yyyy", CustomtoUS)

        CheckDateIndoEnglish(DaSUMonth)

        EDGrid01.Rows.Clear()
        Dim Cnt As Integer

        SQL = Nothing
        SQL = SQL & "Select * From pgj_trans_tot "

        Select Case EDDp02.Text
            Case Nothing, ""

                SQL = SQL & "Where pgj_prrng = ('" & PublicMonth & " " & DaSuYr & "') "
                SQL = SQL & "and pgj_priode = ('" & EDDp02.Text & "') "

            Case Else

                SQL = SQL & "Where pgj_prrng = ('" & PublicMonth & " " & DaSuYr & "') "
                SQL = SQL & "and pgj_priode = ('" & EDDp02.Text & "') "
                SQL = SQL & "and pgj_ttest like ('" & EDTbx02.Text.Replace(" ", "%") & "%" & "') "
                SQL = SQL & "or pgj_prrng = ('" & PublicMonth & " " & DaSuYr & "') "
                SQL = SQL & "and pgj_priode = ('" & EDDp02.Text & "') "
                SQL = SQL & "and pgj_ttname like ('" & EDTbx02.Text.Replace(" ", "%") & "%" & "') "

        End Select

        OpenTbl(PLConn, PLTb2, SQL)
        If PLTb2.RecordCount > 0 Then
            PLTb2.MoveFirst()
            Do While Not PLTb2.EOF

                GetDTransTot(0) = IIf(IsDBNull(PLTb2("pgj_ttest").Value), "", PLTb2("pgj_ttest").Value)
                GetDTransTot(1) = IIf(IsDBNull(PLTb2("pgj_ttname").Value), "", PLTb2("pgj_ttname").Value)
                GetDTransTot(2) = IIf(IsDBNull(PLTb2("pgj_gjpok").Value), "", PLTb2("pgj_gjpok").Value)
                GetDTransTot(3) = IIf(IsDBNull(PLTb2("pgj_absen").Value), 0, PLTb2("pgj_absen").Value.ToString.Replace(",", ""))
                GetDTransTot(4) = IIf(IsDBNull(PLTb2("pgj_potatm").Value), 0, PLTb2("pgj_potatm").Value.ToString.Replace(",", ""))
                GetDTransTot(5) = IIf(IsDBNull(PLTb2("pgj_tunlain").Value), 0, PLTb2("pgj_tunlain").Value.ToString.Replace(",", ""))
                GetDTransTot(6) = IIf(IsDBNull(PLTb2("pgj_lpjam").Value), 0, PLTb2("pgj_lpjam").Value.ToString.Replace(",", ""))
                GetDTransTot(7) = IIf(IsDBNull(PLTb2("pgj_lpnilai").Value), 0, PLTb2("pgj_lpnilai").Value.ToString.Replace(",", ""))
                'GetDTransTot(8) = IIf(IsDBNull(PLTb2("pgj_totgj").Value), "", PLTb2("pgj_totgj").Value)
                GetDTransTot(9) = IIf(IsDBNull(PLTb2("pgj_jamlmb").Value), 0, PLTb2("pgj_jamlmb").Value.ToString.Replace(",", ""))
                GetDTransTot(10) = IIf(IsDBNull(PLTb2("pgj_ttllemb").Value), 0, PLTb2("pgj_ttllemb").Value.ToString.Replace(",", ""))
                GetDTransTot(11) = IIf(IsDBNull(PLTb2("pgj_tunmskerj").Value), 0, PLTb2("pgj_tunmskerj").Value.ToString.Replace(",", ""))
                GetDTransTot(12) = IIf(IsDBNull(PLTb2("pgj_tjkera").Value), 0, PLTb2("pgj_tjkera").Value.ToString.Replace(",", ""))
                GetDTransTot(13) = IIf(IsDBNull(PLTb2("pgj_tjjab").Value), 0, PLTb2("pgj_tjjab").Value.ToString.Replace(",", ""))
                GetDTransTot(14) = IIf(IsDBNull(PLTb2("pgj_kethad").Value), 0, PLTb2("pgj_kethad").Value.ToString.Replace(",", ""))
                GetDTransTot(15) = IIf(IsDBNull(PLTb2("pgj_bpjstkerj").Value), 0, PLTb2("pgj_bpjstkerj").Value.ToString.Replace(",", ""))
                GetDTransTot(16) = IIf(IsDBNull(PLTb2("pgj_bpjskese").Value), 0, PLTb2("pgj_bpjskese").Value.ToString.Replace(",", ""))
                'GetDTransTot(17) = IIf(IsDBNull(PLTb2("pgj_gjinetto").Value), "", PLTb2("pgj_gjinetto").Value)
                GetDTransTot(17) = IIf(IsDBNull(PLTb2("pgj_bagian").Value), 0, PLTb2("pgj_bagian").Value.ToString.Replace(",", ""))
                GetDTransTot(18) = IIf(IsDBNull(PLTb2("pgj_jaba").Value), 0, PLTb2("pgj_jaba").Value.ToString.Replace(",", ""))

                Cnt += 1

                        EDGrid01.Invoke(DirectCast(Sub() EDGrid01.Rows.Add(Cnt.ToString, GetDTransTot(0), _
                                                                     GetDTransTot(1), _
                                                                     Val(GetDTransTot(2)).ToString("N0", CustomtoUS).Replace(",", Nothing), _
                                                                     GetDTransTot(3), _
                                                                     GetDTransTot(4), _
                                                                     GetDTransTot(5), _
                                                                     GetDTransTot(6), _
                                                                     GetDTransTot(7), _
                                                                     "", _
                                                                     GetDTransTot(9), _
                                                                     GetDTransTot(10), _
                                                                     GetDTransTot(11), _
                                                                     GetDTransTot(12), _
                                                                     GetDTransTot(13), _
                                                                     "", _
                                                                     IIf(GetDTransTot(14) = Nothing, Nothing, Val(GetDTransTot(14)).ToString), _
                                                                     GetDTransTot(15), _
                                                                     GetDTransTot(16), _
                                                                    "", _
                                                                      GetDTransTot(17), _
                                                                    GetDTransTot(18)), MethodInvoker))

                Dim GetTotal As Int64 = (Val(GetDTransTot(2).Replace(",", Nothing)) + Val(GetDTransTot(7).Replace(",", Nothing)) + Val(GetDTransTot(5).Replace(",", Nothing))) - Val(GetDTransTot(4).Replace(",", Nothing))
                Dim GetTotal2 As Int64 = (GetTotal + Val(GetDTransTot(10).Replace(",", Nothing)) + Val(GetDTransTot(11).Replace(",", Nothing)) + Val(GetDTransTot(12).Replace(",", Nothing)) + Val(GetDTransTot(13).Replace(",", Nothing))) - (Val(GetDTransTot(14).Replace(",", Nothing)) + Val(GetDTransTot(15).Replace(",", Nothing)) + Val(GetDTransTot(16).Replace(",", Nothing)))

                GetTotal2 = CustomRound(GetTotal2)

                EDGrid01.Invoke(DirectCast(Sub() EDGrid01(9, (Cnt - 1)).Value = GetTotal.ToString("N0", CustomtoUS).Replace(",", Nothing), MethodInvoker))
                EDGrid01.Invoke(DirectCast(Sub() EDGrid01(19, (Cnt - 1)).Value = GetTotal2.ToString("N0", CustomtoUS).Replace(",", Nothing), MethodInvoker))

                For g = 0 To 19
                    GetDTransTot(g) = Nothing
                Next
                PLTb2.MoveNext()
            Loop
        End If
    End Sub

    Private Sub EDTbx01_KeyDown(sender As Object, e As KeyEventArgs)
        Select Case EDGrid01.Rows.Count
            Case Is >= 1
                Select Case e.KeyCode
                    Case Keys.Down, Keys.Up
                        EDGrid01.Focus()
                End Select
        End Select
    End Sub
 
    Dim GetRow As Int32
    Private Sub EDGrid01_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles EDGrid01.CellMouseDown
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub
        EDGrid01.CurrentCell = EDGrid01(e.ColumnIndex, e.RowIndex)
        GetRow = e.RowIndex
    End Sub

    'Sub SavDataUbah()
    '    Try

    '        SQL = Nothing
    '        SQL = SQL & "Select * From pgj_trans_tot "
    '        SQL = SQL & "Where pgj_ttest = ('" & EDInTbx02.Text & "') "
    '        SQL = SQL & "And pgj_ttname = ('" & EDInTbx03.Text.Replace("'", "/") & "') "
    '        SQL = SQL & "and pgj_prrng = ('" & EDDp01.Value.ToString("MMM yyyy", CustomtoUS) & "') "
    '        SQL = SQL & "and pgj_priode = ('" & EDDp02.Text & "') "
    '        OpenTbl(PLConn, PLTb8, SQL)
    '        If Not PLTb8.RecordCount <> 0 Then
    '            PLTb8.AddNew()
    '        End If

    '        PLTb8("pgj_gjpok").Value() = EDInTbx04.Text
    '        PLTb8("pgj_absen").Value() = EDInTbx05.Text
    '        PLTb8("pgj_potatm").Value() = EDInTbx06.Text
    '        PLTb8("pgj_tunlain").Value() = EDInTbx07.Text
    '        PLTb8("pgj_lpjam").Value() = EDInTbx08.Text
    '        PLTb8("pgj_lpnilai").Value() = EDInTbx09.Text
    '        PLTb8("pgj_totgj").Value() = EDInTbx10.Text
    '        PLTb8("pgj_jamlmb").Value() = EDInTbx11.Text
    '        PLTb8("pgj_ttllemb").Value() = EDInTbx12.Text
    '        PLTb8("pgj_tunmskerj").Value() = EDInTbx13.Text
    '        PLTb8("pgj_tjkera").Value() = EDInTbx14.Text
    '        PLTb8("pgj_tjjab").Value() = EDInTbx15.Text
    '        PLTb8("pgj_kethad").Value() = EDInTbx16.Text
    '        PLTb8("pgj_bpjstkerj").Value() = EDInTbx17.Text
    '        PLTb8("pgj_bpjskese").Value() = EDInTbx18.Text
    '        PLTb8("pgj_gjinetto").Value() = EDInTbx19.Text

    '        PLTb8.Update()
    '        ClearTbxNow()
    '        MessageBox.Show("Successfully Saved", Me.Text)

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message & " ~~~~~~~~~~~~~~~~~ " & ex.ToString)
    '    End Try

    'End Sub

    Sub SavDataUbah2()

        Dim DaSUMonth As String = EDDp01.Value.ToString("MMM", CustomtoUS)
        Dim DaSuYr As String = EDDp01.Value.ToString("yyyy", CustomtoUS)

        CheckDateIndoEnglish(DaSUMonth)
        Try
            SQL = Nothing
            SQL = SQL & "Select * From pgj_trans_tot "
            SQL = SQL & "Where pgj_ttest = ('" & EDTbxCo02.Text & "') "
            SQL = SQL & "And pgj_ttname = ('" & EDTbxCo03.Text.Replace("'", "/") & "') "
            SQL = SQL & "and pgj_prrng = ('" & PublicMonth & " " & DaSuYr & "') "
            SQL = SQL & "and pgj_priode = ('" & EDDp02.Text & "') "
            OpenTbl(PLConn, PLTb8, SQL)
            If Not PLTb8.RecordCount <> 0 Then
                PLTb8.AddNew()
            End If

            PLTb8("pgj_gjpok").Value() = EDTbxCo04.Text
            PLTb8("pgj_absen").Value() = EDTbxCo05.Text
            PLTb8("pgj_potatm").Value() = EDTbxCo06.Text
            PLTb8("pgj_tunlain").Value() = EDTbxCo07.Text
            PLTb8("pgj_lpjam").Value() = EDTbxCo08.Text
            PLTb8("pgj_lpnilai").Value() = EDTbxCo09.Text
            PLTb8("pgj_totgj").Value() = EDTbxCo10.Text
            PLTb8("pgj_jamlmb").Value() = EDTbxCo11.Text
            PLTb8("pgj_ttllemb").Value() = EDTbxCo12.Text
            PLTb8("pgj_tunmskerj").Value() = EDTbxCo13.Text
            PLTb8("pgj_tjkera").Value() = EDTbxCo14.Text
            PLTb8("pgj_tjjab").Value() = EDTbxCo15.Text
            PLTb8("pgj_kethad").Value() = EDTbxCo16.Text
            PLTb8("pgj_bpjstkerj").Value() = EDTbxCo17.Text
            PLTb8("pgj_bpjskese").Value() = EDTbxCo18.Text
            PLTb8("pgj_gjinetto").Value() = EDTbxCo19.Text

            PLTb8.Update()
            ClearTbxNow2()
            MessageBox.Show("Successfully Saved", Me.Text)

        Catch ex As Exception
            MessageBox.Show(ex.Message & " ~~~~~~~~~~~~~~~~~ " & ex.ToString)
        End Try

    End Sub

    'Sub CalculateMode()

    '    Dim FrStgTot As Int64 = Val(EDInTbx04.Text) + Val(EDInTbx07.Text) + Val(EDInTbx09.Text)
    '    FrStgTot = FrStgTot - Val(EDInTbx06.Text)
    '    Dim SndtgTot As Int64 = Val(EDInTbx12.Text) + Val(EDInTbx13.Text) + Val(EDInTbx14.Text) + Val(EDInTbx15.Text)
    '    SndtgTot = FrStgTot + SndtgTot
    '    SndtgTot = SndtgTot - (Val(EDInTbx16.Text) + Val(EDInTbx17.Text) + Val(EDInTbx18.Text))

    '    SndtgTot = CustomRound(SndtgTot)

    '    EDInTbx19.Text = SndtgTot.ToString
    '    EDInTbx10.Text = FrStgTot.ToString
    'End Sub

    Sub CalculateMode2()

        Dim FrStgTot As Int64 = Val(EDTbxCo04.Text) + Val(EDTbxCo07.Text) + Val(EDTbxCo09.Text)
        FrStgTot = FrStgTot - Val(EDTbxCo06.Text)
        Dim SndtgTot As Int64 = Val(EDTbxCo12.Text) + Val(EDTbxCo13.Text) + Val(EDTbxCo14.Text) + Val(EDTbxCo15.Text)
        SndtgTot = FrStgTot + SndtgTot
        SndtgTot = SndtgTot - (Val(EDTbxCo16.Text) + Val(EDTbxCo17.Text) + Val(EDTbxCo18.Text))
        SndtgTot += SndtgTot

        EDTbxCo19.Text = SndtgTot.ToString
        EDTbxCo10.Text = FrStgTot.ToString

    End Sub

    Private Sub EDInTbx01_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub EDInTbx02_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub EDInTbx03_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub EDCM01_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles EDCM01.Opening
        Select Case EDGrid01.Rows.Count
            Case Is <> 0
            Case Else
                e.Cancel = True
        End Select
    End Sub

    Private Sub EDInBtn01_Click(sender As Object, e As EventArgs)
        Try
            'CalculateMode()
            'SavDataUbah()
        Catch ex As Exception
            MessageBox.Show(" ~~~~~~~~~~~~~~~~~~ " & ex.ToString & " ~~~~~~~~~~~~~~~~~~~~~~~~ ")
        End Try
    End Sub

    Private Sub EDInTbx10_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub EDInTbx13_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub EDInTbx14_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub EDInTbx15_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub EDInTbx16_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub EDInTbx19_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Sub ClearTbxNow()

    End Sub

    Sub ClearTbxNow2()

        EDTbxCo01.Clear()
        EDTbxCo02.Clear()
        EDTbxCo03.Clear()
        EDTbxCo04.Clear()
        EDTbxCo05.Clear()
        EDTbxCo06.Clear()
        EDTbxCo07.Clear()
        EDTbxCo08.Clear()
        EDTbxCo09.Clear()
        EDTbxCo10.Clear()
        EDTbxCo11.Clear()
        EDTbxCo12.Clear()
        EDTbxCo13.Clear()
        EDTbxCo14.Clear()
        EDTbxCo15.Clear()
        EDTbxCo16.Clear()
        EDTbxCo17.Clear()
        EDTbxCo18.Clear()
        EDTbxCo19.Clear()

    End Sub

    Private Sub EDInBtn02_Click(sender As Object, e As EventArgs)
        ClearTbxNow()
    End Sub

    Private Sub EDTbxCo01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EDTbxCo01.KeyPress
        e.Handled = True
    End Sub

    Private Sub EDTbxCo02_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EDTbxCo02.KeyPress
        e.Handled = True
    End Sub

    Private Sub EDTbxCo03_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EDTbxCo03.KeyPress
        e.Handled = True
    End Sub

    Private Sub EDTbxCo10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EDTbxCo10.KeyPress
        e.Handled = True
    End Sub

    Private Sub EDTbxCo20_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EDTbxCo19.KeyPress
        e.Handled = True
    End Sub

    Private Sub EDTbxCo13_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EDTbxCo13.KeyPress
        e.Handled = True
    End Sub
    Private Sub EDTbxCo12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EDTbxCo12.KeyPress
        e.Handled = True
    End Sub

    Private Sub EDTbxCo14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EDTbxCo14.KeyPress
        e.Handled = True
    End Sub

    Private Sub EDTbxCo15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EDTbxCo15.KeyPress
        e.Handled = True
    End Sub

    Private Sub EDGrid01_KeyDown(sender As Object, e As KeyEventArgs) Handles EDGrid01.KeyDown

        'Try
        '    Select Case e.KeyCode

        '        Case Keys.Down, Keys.Enter
        '            Dim i = EDGrid01.CurrentRow.Index
        '            i += 1
        '            EDTbxCo01.Text = EDGrid01.Item(0, i).Value
        '            EDTbxCo02.Text = EDGrid01.Item(1, i).Value
        '            EDTbxCo03.Text = EDGrid01.Item(2, i).Value
        '            EDTbxCo04.Text = EDGrid01.Item(3, i).Value
        '            EDTbxCo05.Text = EDGrid01.Item(4, i).Value
        '            EDTbxCo06.Text = EDGrid01.Item(5, i).Value
        '            EDTbxCo07.Text = EDGrid01.Item(6, i).Value
        '            EDTbxCo08.Text = EDGrid01.Item(7, i).Value
        '            EDTbxCo09.Text = EDGrid01.Item(8, i).Value
        '            EDTbxCo10.Text = EDGrid01.Item(9, i).Value
        '            EDTbxCo11.Text = EDGrid01.Item(10, i).Value
        '            EDTbxCo12.Text = EDGrid01.Item(11, i).Value
        '            EDTbxCo13.Text = EDGrid01.Item(12, i).Value
        '            EDTbxCo14.Text = EDGrid01.Item(13, i).Value
        '            EDTbxCo15.Text = EDGrid01.Item(14, i).Value
        '            EDTbxCo16.Text = EDGrid01.Item(16, i).Value
        '            EDTbxCo17.Text = EDGrid01.Item(17, i).Value
        '            EDTbxCo18.Text = EDGrid01.Item(18, i).Value
        '            EDTbxCo19.Text = EDGrid01.Item(19, i).Value

        '        Case Keys.Up
        '            Dim i = EDGrid01.CurrentRow.Index
        '            i -= 1


        '            EDTbxCo01.Text = EDGrid01.Item(0, i).Value
        '            EDTbxCo02.Text = EDGrid01.Item(1, i).Value
        '            EDTbxCo03.Text = EDGrid01.Item(2, i).Value
        '            EDTbxCo04.Text = EDGrid01.Item(3, i).Value
        '            EDTbxCo05.Text = EDGrid01.Item(4, i).Value
        '            EDTbxCo06.Text = EDGrid01.Item(5, i).Value
        '            EDTbxCo07.Text = EDGrid01.Item(6, i).Value
        '            EDTbxCo08.Text = EDGrid01.Item(7, i).Value
        '            EDTbxCo09.Text = EDGrid01.Item(8, i).Value
        '            EDTbxCo10.Text = EDGrid01.Item(9, i).Value
        '            EDTbxCo11.Text = EDGrid01.Item(10, i).Value
        '            EDTbxCo12.Text = EDGrid01.Item(11, i).Value
        '            EDTbxCo13.Text = EDGrid01.Item(12, i).Value
        '            EDTbxCo14.Text = EDGrid01.Item(13, i).Value
        '            EDTbxCo15.Text = EDGrid01.Item(14, i).Value
        '            EDTbxCo16.Text = EDGrid01.Item(16, i).Value
        '            EDTbxCo17.Text = EDGrid01.Item(17, i).Value
        '            EDTbxCo18.Text = EDGrid01.Item(18, i).Value
        '            EDTbxCo19.Text = EDGrid01.Item(19, i).Value

        '            'EDTbxCo01.Text = EDGrid01.CurrentRow.Cells(0).Value.ToString
        '            'EDTbxCo02.Text = EDGrid01.CurrentRow.Cells(1).Value.ToString
        '            'EDTbxCo03.Text = EDGrid01.CurrentRow.Cells(2).Value.ToString
        '            'EDTbxCo04.Text = EDGrid01.CurrentRow.Cells(3).Value.ToString
        '            'EDTbxCo05.Text = EDGrid01.CurrentRow.Cells(4).Value.ToString
        '            'EDTbxCo06.Text = EDGrid01.CurrentRow.Cells(5).Value.ToString
        '            'EDTbxCo07.Text = EDGrid01.CurrentRow.Cells(6).Value.ToString
        '            'EDTbxCo08.Text = EDGrid01.CurrentRow.Cells(7).Value.ToString
        '            'EDTbxCo09.Text = EDGrid01.CurrentRow.Cells(8).Value.ToString
        '            'EDTbxCo10.Text = EDGrid01.CurrentRow.Cells(9).Value.ToString
        '            'EDTbxCo11.Text = EDGrid01.CurrentRow.Cells(10).Value.ToString
        '            'EDTbxCo12.Text = EDGrid01.CurrentRow.Cells(11).Value.ToString
        '            'EDTbxCo13.Text = EDGrid01.CurrentRow.Cells(12).Value.ToString
        '            'EDTbxCo14.Text = EDGrid01.CurrentRow.Cells(13).Value.ToString
        '            'EDTbxCo15.Text = EDGrid01.CurrentRow.Cells(14).Value.ToString
        '            'EDTbxCo16.Text = EDGrid01.CurrentRow.Cells(16).Value.ToString
        '            'EDTbxCo17.Text = EDGrid01.CurrentRow.Cells(17).Value.ToString
        '            'EDTbxCo18.Text = EDGrid01.CurrentRow.Cells(18).Value.ToString
        '            'EDTbxCo19.Text = EDGrid01.CurrentRow.Cells(19).Value.ToString

        '    End Select
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub EDInBtn03_Click(sender As Object, e As EventArgs) Handles EDInBtn03.Click
        Try
            CalculateMode2()
            SavDataUbah2()
        Catch ex As Exception
            MessageBox.Show(" ~~~~~~~~~~~~~~~~~~ " & ex.ToString & " ~~~~~~~~~~~~~~~~~~~~~~~~ ")
        End Try
    End Sub

    Private Sub EDGrid01_KeyUp(sender As Object, e As KeyEventArgs) Handles EDGrid01.KeyUp
        EDTbxCo01.Text = EDGrid01.CurrentRow.Cells(0).Value.ToString
        EDTbxCo02.Text = EDGrid01.CurrentRow.Cells(1).Value.ToString
        EDTbxCo03.Text = EDGrid01.CurrentRow.Cells(2).Value.ToString
        EDTbxCo04.Text = EDGrid01.CurrentRow.Cells(3).Value.ToString
        EDTbxCo05.Text = EDGrid01.CurrentRow.Cells(4).Value.ToString
        EDTbxCo06.Text = EDGrid01.CurrentRow.Cells(5).Value.ToString
        EDTbxCo07.Text = EDGrid01.CurrentRow.Cells(6).Value.ToString
        EDTbxCo08.Text = EDGrid01.CurrentRow.Cells(7).Value.ToString
        EDTbxCo09.Text = EDGrid01.CurrentRow.Cells(8).Value.ToString
        EDTbxCo10.Text = EDGrid01.CurrentRow.Cells(9).Value.ToString
        EDTbxCo11.Text = EDGrid01.CurrentRow.Cells(10).Value.ToString
        EDTbxCo12.Text = EDGrid01.CurrentRow.Cells(11).Value.ToString
        EDTbxCo13.Text = EDGrid01.CurrentRow.Cells(12).Value.ToString
        EDTbxCo14.Text = EDGrid01.CurrentRow.Cells(13).Value.ToString
        EDTbxCo15.Text = EDGrid01.CurrentRow.Cells(14).Value.ToString
        EDTbxCo16.Text = EDGrid01.CurrentRow.Cells(16).Value.ToString
        EDTbxCo17.Text = EDGrid01.CurrentRow.Cells(17).Value.ToString
        EDTbxCo18.Text = EDGrid01.CurrentRow.Cells(18).Value.ToString
        EDTbxCo19.Text = EDGrid01.CurrentRow.Cells(19).Value.ToString
    End Sub

    Private Sub EDTbx02_KeyUp(sender As Object, e As KeyEventArgs) Handles EDTbx02.KeyUp
        Select Case EDTbx02.Text.Length
            Case Is >= 1
                LoadDataNow()
        End Select

        Select Case EDGrid01.Rows.Count
            Case Is >= 1
                Select Case e.KeyCode
                    Case Keys.Down, Keys.Up
                        EDGrid01.Focus()
                End Select
        End Select
    End Sub


End Class