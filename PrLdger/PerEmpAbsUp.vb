Imports System.IO
Imports System.Threading
Imports System.ComponentModel
Imports System.Globalization
Imports OfficeOpenXml
Imports OfficeOpenXml.Style

Public Class PerEmpAbsUp

    Dim UADatNam As String
    Dim UADatEst As String
    Dim UADatKH As String
    Dim UADatSubKH As String
    Dim UADatHo As String
    Dim UADatET As String
    Dim UADatRem As String

    Dim OpenMyPath As String
    Dim XlArrC1(10000) As String
    Dim XlArrC2(10000) As String
    Dim XlArrC3(10000) As String
    Dim XlArrC4(10000) As String
    Dim XlArrC5(10000) As String
    Dim XlArrC6(10000) As String
    Dim XlArrC7(10000) As String
    Dim XlArrC8(10000) As String
    Dim XlArrC9(10000) As String
    Dim XlArrC10(10000) As String
    Dim XlArrC11(10000) As String
    Dim XlArrC12(10000) As String
    Dim XlArrC13(10000) As String
    Dim XlArrC14(10000) As String
    Dim XlArrC15(10000) As String
    Dim XlArrC16(10000) As String
    Dim XlArrC17(10000) As String
    Dim XlArrC18(10000) As String
    Dim XlArrC19(10000) As String
    Dim XlArrC20(10000) As String
    Dim XlArrC21(10000) As String
    Dim XlArrC22(10000) As String
    Dim XlArrC23(10000) As String
    Dim XlArrC24(10000) As String
    Dim XlArrC25(10000) As String
    Dim XlArrC26(10000) As String
    Dim XlArrC27(10000) As String
    Dim XlArrC28(10000) As String
    Dim XlArrC29(10000) As String


    Dim UAEst As String
    Dim UANama As String
    Dim UAKH As String
    Dim UASubKH As String
    Dim UAAbs As String
    Dim UAET As String
    Dim UARemark As String
    Dim HolidateSw As String
    Dim LinkName As String

    ' In Revise version


    Dim RevUpAcNum As String
    Dim RevUpNama As String
    Dim RevUpDate As String
    Dim RevUpTimeTbl As String
    Dim RevUpOnDuty As String
    Dim RevUpOffDuty As String
    Dim RevUpClockIn As String
    Dim RevUpClockOut As String
    Dim RevUpNormal As String
    Dim RevUpRealTime As String
    Dim RevUpLate As String
    Dim RevUpEarly As String
    Dim RevUpAbsent As String
    Dim RevUpOTTime As String
    Dim RevUpWorkTime As String
    Dim RevUpException As String
    Dim RevUpMustCIN As String
    Dim RevUpMustOUT As String
    Dim RevUpDept As String
    Dim RevUpNDays As String
    Dim RevUpWkEnd As String
    Dim RevUpHolday As String
    Dim RevUpATT As String
    Dim RevUpNDaysOT As String
    Dim RevUpWkEndOT As String
    Dim RevUpHoldayOT As String

    Private Sub PerEmpTransUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadDB2()
    End Sub

    Sub LoadExcelTrans()

    End Sub

    Private Sub UABtn01_Click(sender As Object, e As EventArgs) Handles UABtn01.Click
        'UABtn04.enabled = False
        ' UAGridMode()
        RevUAGridMode() '  Revise As Of July 16 2017

        Dim LinkFileName As New OpenFileDialog
        LinkFileName.InitialDirectory = Application.StartupPath + "\UploadFormat\"
        LinkFileName.Filter = " Excel File |*.xlsx"
        If LinkFileName.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            LinkName = LinkFileName.FileName
            UATbx01.Text = LinkFileName.FileName
        End If
    End Sub

    Sub UAGridMode()
        With UAGrid01
            .Rows.Clear()
            .Columns.Clear()
            .Columns.Add("col0", "Num")
            .Columns.Add("col1", "No. Est")
            .Columns.Add("col2", "Nama")
            .Columns.Add("col3", "KHT/KHL")
            .Columns.Add("col4", "Sub KHL")
            .Columns.Add("col5", "Count")
            .Columns.Add("col5", "Remark")
            .Columns(6).Width = 300
        End With
    End Sub

    Sub RevUAGridMode()
        With UAGrid01
            .Rows.Clear()
            .Columns.Clear()
            .Columns.Add("col0", "AC Num")
            .Columns.Add("col1", "Nama")
            .Columns.Add("col2", "Date")
            .Columns.Add("col3", "Time Table")
            .Columns.Add("col4", "On Duty")
            .Columns.Add("col5", "Off Duty")
            .Columns.Add("col6", "Clock IN")
            .Columns.Add("col7", "Clock Out")
            .Columns.Add("col8", "Normal")
            .Columns.Add("col9", "Real Time")
            .Columns.Add("col10", "Late")
            .Columns.Add("col11", "Early")
            .Columns.Add("col12", "Absent")
            .Columns.Add("col13", "OT Time")
            .Columns.Add("col14", "Work Time")
            .Columns.Add("col15", "Exception")
            .Columns.Add("col16", "Must C/In")
            .Columns.Add("col17", "Must C/Out")
            .Columns.Add("col18", "Department")
            .Columns.Add("col19", "NDays")
            .Columns.Add("col20", "WeekEnd")
            .Columns.Add("col21", "Holiday")
            .Columns.Add("col22", "ATT Time")
            .Columns.Add("col23", "NDays OT")
            .Columns.Add("col24", "Weekends OT")
            .Columns.Add("col25", "Holiday OT")
            .Columns.Add("col26", "Remark")

            For d = 0 To .Columns.Count - 1
                .Columns(d).Width = 200
            Next

        End With
    End Sub

    Sub LoaHolidayMode()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_holidayset "
        OpenTbl(PLConn, PLTb1, SQL)
        If PLTb1.RecordCount > 0 Then
            Dim GetDate As Date = IIf(IsDBNull(PLTb1("hol_date").Value), "", PLTb1("hol_date").Value)
        End If
    End Sub

    Private Sub UATbx01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UATbx01.KeyPress
        e.Handled = True
    End Sub

    Private Sub UABtn02_Click(sender As Object, e As EventArgs) Handles UABtn02.Click
        ' UABtn04.Enabled = False
        RevUAGridMode()

        Try
            ' ReadMode()
            RevReadMode() '  As of July 16 2017

        Catch ex As Exception
        End Try
    End Sub

    Sub ReadMode()
        Dim xlRow As Long, xlCtr As Long

        Dim NewFile As New FileInfo(LinkName)

        Using ExcelModPkg = New ExcelPackage(NewFile)

            Dim ExcelWSh As ExcelWorksheet = ExcelModPkg.Workbook.Worksheets.First()
            xlCtr = 0

            For xlRow = 2 To 10000

                If ExcelWSh.Cells(xlRow, 4).Value = "END" Or ExcelWSh.Cells(xlRow, 3).Value = Nothing Then

                    Exit For

                Else
                    xlCtr += 1
                    XlArrC2(xlCtr) = ExcelWSh.Cells(xlRow, 2).Value ' 2
                    XlArrC3(xlCtr) = ExcelWSh.Cells(xlRow, 3).Value ' 3
                    XlArrC4(xlCtr) = ExcelWSh.Cells(xlRow, 4).Value ' 4
                    XlArrC5(xlCtr) = ExcelWSh.Cells(xlRow, 5).Value ' 5
                    XlArrC6(xlCtr) = ExcelWSh.Cells(xlRow, 6).Value ' 6
                    XlArrC7(xlCtr) = ExcelWSh.Cells(xlRow, 7).Value ' 7

                End If
            Next xlRow

            For xlRow = 1 To xlCtr
                UAEst = XlArrC2(xlRow)
                UANama = XlArrC3(xlRow)
                UAKH = XlArrC4(xlRow)
                UASubKH = XlArrC5(xlRow)
                UAAbs = XlArrC6(xlRow)
                UAGrid01.Invoke(DirectCast(Sub() UAGrid01.Rows.Add("", UAEst, UANama, UAKH, UASubKH, UAAbs), MethodInvoker))
                ExcelModPkg.Dispose()
            Next xlRow
        End Using

    End Sub
    Sub RevReadMode()
        Dim xlRow As Long, xlCtr As Long

        Dim NewFile As New FileInfo(LinkName)

        Using ExcelModPkg = New ExcelPackage(NewFile)

            Dim ExcelWSh As ExcelWorksheet = ExcelModPkg.Workbook.Worksheets.First()
            xlCtr = 0

            For xlRow = 2 To 10000

                If ExcelWSh.Cells(xlRow, 1).Value = "END" Or ExcelWSh.Cells(xlRow, 1).Value = Nothing Then

                    Exit For

                Else
                    xlCtr += 1

                    XlArrC1(xlCtr) = ExcelWSh.Cells(xlRow, 1).Value  '1
                    XlArrC2(xlCtr) = ExcelWSh.Cells(xlRow, 2).Value ' 2
                    XlArrC3(xlCtr) = ExcelWSh.Cells(xlRow, 3).Value ' 3
                    XlArrC4(xlCtr) = ExcelWSh.Cells(xlRow, 4).Value ' 4
                    XlArrC5(xlCtr) = ExcelWSh.Cells(xlRow, 5).Value ' 5
                    XlArrC6(xlCtr) = ExcelWSh.Cells(xlRow, 6).Value ' 6
                    XlArrC7(xlCtr) = ExcelWSh.Cells(xlRow, 7).Value ' 7
                    XlArrC8(xlCtr) = ExcelWSh.Cells(xlRow, 8).Value  '8
                    XlArrC9(xlCtr) = ExcelWSh.Cells(xlRow, 9).Value ' 9
                    XlArrC10(xlCtr) = ExcelWSh.Cells(xlRow, 10).Value ' 10
                    XlArrC11(xlCtr) = ExcelWSh.Cells(xlRow, 11).Value ' 11
                    XlArrC12(xlCtr) = ExcelWSh.Cells(xlRow, 12).Value ' 12
                    XlArrC13(xlCtr) = ExcelWSh.Cells(xlRow, 13).Value ' 13
                    XlArrC14(xlCtr) = ExcelWSh.Cells(xlRow, 14).Value ' 14
                    XlArrC15(xlCtr) = ExcelWSh.Cells(xlRow, 15).Value  '15
                    XlArrC16(xlCtr) = ExcelWSh.Cells(xlRow, 16).Value ' 16
                    XlArrC17(xlCtr) = ExcelWSh.Cells(xlRow, 17).Value ' 17
                    XlArrC18(xlCtr) = ExcelWSh.Cells(xlRow, 18).Value ' 18
                    XlArrC19(xlCtr) = ExcelWSh.Cells(xlRow, 19).Value ' 19
                    XlArrC20(xlCtr) = ExcelWSh.Cells(xlRow, 20).Value ' 20
                    XlArrC21(xlCtr) = ExcelWSh.Cells(xlRow, 21).Value ' 21
                    XlArrC22(xlCtr) = ExcelWSh.Cells(xlRow, 22).Value ' 22
                    XlArrC23(xlCtr) = ExcelWSh.Cells(xlRow, 23).Value ' 23
                    XlArrC24(xlCtr) = ExcelWSh.Cells(xlRow, 24).Value ' 24
                    XlArrC25(xlCtr) = ExcelWSh.Cells(xlRow, 25).Value ' 25
                    XlArrC26(xlCtr) = ExcelWSh.Cells(xlRow, 26).Value ' 26

                End If
            Next xlRow

            For xlRow = 1 To xlCtr


                'RevUpAcNum = XlArrC1(xlRow)
                'RevUpNama = XlArrC2(xlRow)
                'RevUpDate = XlArrC3(xlRow)
                'RevUpTimeTbl = XlArrC4(xlRow)
                'RevUpOnDuty = XlArrC5(xlRow)
                'RevUpOffDuty = XlArrC6(xlRow)
                'RevUpClockIn = XlArrC7(xlRow)
                'RevUpClockOut = XlArrC8(xlRow)
                'RevUpNormal = XlArrC9(xlRow)
                'RevUpRealTime = XlArrC10(xlRow)
                'RevUpLate = XlArrC11(xlRow)
                'RevUpEarly = XlArrC12(xlRow)
                'RevUpAbsent = XlArrC13(xlRow)
                'RevUpOTTime = XlArrC14(xlRow)
                'RevUpWorkTime = XlArrC15(xlRow)
                'RevUpException = XlArrC16(xlRow)
                'RevUpMustCIN = XlArrC17(xlRow)
                'RevUpMustOUT = XlArrC18(xlRow)
                'RevUpDept = XlArrC19(xlRow)
                'RevUpNDays = XlArrC20(xlRow)
                'RevUpWkEnd = XlArrC21(xlRow)
                'RevUpHolday = XlArrC22(xlRow)
                'RevUpATT = XlArrC23(xlRow)
                'RevUpNDaysOT = XlArrC24(xlRow)
                'RevUpWkEndOT = XlArrC25(xlRow)
                'RevUpHoldayOT = XlArrC26(xlRow)

                Dim ExChaDate As Date = Date.Parse(XlArrC3(xlRow))

                UAGrid01.Invoke(DirectCast(Sub() UAGrid01.Rows.Add(XlArrC1(xlRow), _
                                                                               XlArrC2(xlRow), _
                                                                               ExChaDate.ToString("dd MMM yyyy"), _
                                                                               XlArrC4(xlRow), _
                                                                               XlArrC5(xlRow), _
                                                                               XlArrC6(xlRow), _
                                                                               XlArrC7(xlRow), _
                                                                               XlArrC8(xlRow), _
                                                                               XlArrC9(xlRow), _
                                                                               XlArrC10(xlRow), _
                                                                               XlArrC11(xlRow), _
                                                                               XlArrC12(xlRow), _
                                                                               XlArrC13(xlRow), _
                                                                               XlArrC14(xlRow), _
                                                                               XlArrC15(xlRow), _
                                                                               XlArrC16(xlRow), _
                                                                               XlArrC17(xlRow), _
                                                                               XlArrC18(xlRow), _
                                                                               XlArrC19(xlRow), _
                                                                               XlArrC20(xlRow), _
                                                                               XlArrC21(xlRow), _
                                                                               XlArrC22(xlRow), _
                                                                               XlArrC23(xlRow), _
                                                                               XlArrC24(xlRow), _
                                                                               XlArrC25(xlRow), _
                                                                               XlArrC26(xlRow)), MethodInvoker))
                ExcelModPkg.Dispose()
            Next xlRow
        End Using
        Label1.Text = "Count : " & UAGrid01.Rows.Count.ToString
    End Sub

    Dim KHMain As String
    Dim KHSub As String
    Dim JabMain As String
    Dim Gpokokmain As String
    Dim TJabMain As String
    Dim NamaMain As String

    Dim DateCnt As String
    Dim DateHB As String
    Dim DatePRng As String
    Dim DatePde As String

    Sub LookDateAsHB()
        DateCnt = Nothing
        DateHB = Nothing
        DatePRng = Nothing
        DatePde = Nothing

        SQL = Nothing
        SQL = SQL & "Select * From pgj_daycontrol "
        SQL = SQL & "Where dc_date = ('" & UADt01.Value.ToString("yyyy-MM-dd", CustomtoUS) & "') "
        OpenTbl(PLConn, PLTb2, SQL)
        If PLTb2.RecordCount > 0 Then
            DateCnt = IIf(IsDBNull(PLTb2("dc_count").Value), "", PLTb2("dc_count").Value)
            'DateHB = IIf(IsDBNull(PLTb2("dc_hb").Value), "", PLTb2("dc_hb").Value)
            DatePRng = IIf(IsDBNull(PLTb2("dc_perioderng").Value), "", PLTb2("dc_perioderng").Value)
            DatePde = IIf(IsDBNull(PLTb2("dc_periode").Value), "", PLTb2("dc_periode").Value)
        End If
    End Sub

    Dim DateLook4HB As Date
    Dim LmbNama As String
    Dim LmbNik As String

    Dim LCntA As Int32 = 0
    Dim LCntB As Int32 = 0

    Sub LoadDayPerLmbPrd()

        SQL = Nothing
        SQL = SQL & "Select * From pgj_daycontrol "
        SQL = SQL & "Where dc_date = ('" & DateLook4HB.ToString("yyyy-MM-dd", CustomtoUS) & "') "
        OpenTbl(PLConn, PLTb7, SQL)
        If PLTb7.RecordCount > 0 Then
            DateCnt = IIf(IsDBNull(PLTb2("dc_count").Value), 0, PLTb2("dc_count").Value)
            Select Case DateCnt
                Case Is >= 8
                    LCntB += 1
                Case Is >= 1
                    LCntA += 1
            End Select
        End If

        ' Saving

    End Sub


    Sub SavingLmbPrd()

        SQL = Nothing
        SQL = SQL & "Select * From pgj_lemprdtb "
        SQL = SQL & "Where lmprd_est = ('" & LmbNik & "') "
        SQL = SQL & "and lmprd_periode = ('" & UACmb01.Text & "') "
        SQL = SQL & "and lmprd_perrng = ('" & UADt01.Value.ToString("MMM yyyy", CustomtoUS) & "') "
        OpenTbl(PLConn, PLTb10, SQL)
        If Not PLTb10.RecordCount <> 0 Then
            PLTb10.AddNew()
        End If

        PLTb10("lmprd_est").Value() = LmbNik
        PLTb10("lmprd_nama").Value() = LmbNama
        PLTb10("lmprd_perrng").Value() = UACmb01.Text
        PLTb10("lmprd_periode").Value() = UADt01.Value.ToString("MMM yyyy", CustomtoUS)
        PLTb10("lmprd_absenA").Value() = LCntA
        PLTb10("lmprd_absenB").Value() = LCntB
        PLTb10.Update()


    End Sub

    Sub ProcessLmbPrd()

        'With UAGrid01
        '    .Columns.Clear()
        '    .Columns.Add("col0", "Nik")
        '    .Columns.Add("col1", "Nama")
        '    .Columns.Add("col2", "AC")
        '    .Columns.Add("col3", "Cnt 1")
        '    .Columns.Add("col4", "Cnt 2")
        'End With
        Dim DaSUMonth As String = UADt01.Value.ToString("MMM", CustomtoUS)
        Dim DaSuYr As String = UADt01.Value.ToString("yyyy", CustomtoUS)
        CheckDateIndoEnglish(DaSUMonth)

        SQL = Nothing
        SQL = SQL & "Select `rev_nama`, `rev_nik`, `rev_acnum`, `rev_sistem`, `rev_tglkeluar` From pgj_empdatrev "
        SQL = SQL & "Where rev_tglkeluar is null "
        SQL = SQL & "and rev_sistem = ('" & "Harian Lepas Produksi" & "') "
        OpenTbl(PLConn, PLTb3, SQL)
        If PLTb3.RecordCount > 0 Then
            PLTb3.MoveFirst()
            Do While Not PLTb3.EOF

                Dim LmbNik As String = If(IsDBNull(PLTb3("rev_nik").Value), "", PLTb3("rev_nik").Value)
                Dim LmbAcNum As String = If(IsDBNull(PLTb3("rev_acnum").Value), "", PLTb3("rev_acnum").Value)
                Dim LmbNama As String = If(IsDBNull(PLTb3("rev_nama").Value), "", PLTb3("rev_nama").Value)

                SQL = Nothing
                SQL = SQL & "Select `pgj_abname`, `pgj_abAC`, `pgj_date`, `pgj_periode`, `pgj_perrng` From pgj_absensi "
                SQL = SQL & "Where pgj_abAC = ('" & LmbAcNum & "') "
                SQL = SQL & "and pgj_abname = ('" & LmbNama & "') "
                SQL = SQL & "and pgj_periode = ('" & UACmb01.Text & "') "
                SQL = SQL & "and pgj_perrng = ('" & PublicMonth & " " & DaSuYr & "') "
                OpenTbl(PLConn, PLTb6, SQL)
                If PLTb6.RecordCount > 0 Then
                    PLTb6.MoveFirst()
                    Do While Not PLTb6.EOF

                        DateLook4HB = If(IsDBNull(PLTb6("pgj_date").Value), "", PLTb6("pgj_date").Value)

                        SQL = Nothing
                        SQL = SQL & "Select * From pgj_daycontrol "
                        SQL = SQL & "Where dc_date = ('" & DateLook4HB.ToString("yyyy-MM-dd", CustomtoUS) & "') "
                        OpenTbl(PLConn, PLTb7, SQL)
                        If PLTb7.RecordCount > 0 Then
                            Dim DateCrCnt As Int32 = IIf(IsDBNull(PLTb7("dc_count").Value), 0, Val(PLTb7("dc_count").Value))
                            Select Case DateCrCnt
                                Case Is >= 8
                                    LCntB += 1
                                Case Is >= 1
                                    LCntA += 1
                            End Select
                        End If

                        PLTb6.MoveNext()
                    Loop
                End If

                SQL = Nothing
                SQL = SQL & "Select * From pgj_lemprdtb "
                SQL = SQL & "Where lmprd_est = ('" & LmbNik & "') "
                SQL = SQL & "and lmprd_periode = ('" & UACmb01.Text & "') "
                SQL = SQL & "and lmprd_perrng = ('" & PublicMonth & " " & DaSuYr & "') "
                OpenTbl(PLConn, PLTb10, SQL)
                If Not PLTb10.RecordCount <> 0 Then
                    PLTb10.AddNew()
                End If

                PLTb10("lmprd_est").Value() = LmbNik
                PLTb10("lmprd_nama").Value() = LmbNama
                PLTb10("lmprd_perrng").Value() = PublicMonth & " " & DaSuYr
                PLTb10("lmprd_periode").Value() = UACmb01.Text
                PLTb10("lmprd_absenA").Value() = LCntA
                PLTb10("lmprd_absenB").Value() = LCntB
                PLTb10.Update()

                '   UAGrid01.Rows.Add(LmbNik, LmbNama, LmbAcNum, LCntA, LCntB)
                LCntB = 0
                LCntA = 0

                PLTb3.MoveNext()

            Loop

            MessageBox.Show("Done")

        End If

    End Sub

    Sub GenerateValue()
        Dim u As Int32 = 0
        For k = 0 To UAGrid01.Rows.Count - 1
            SQL = Nothing
            SQL = SQL & "Select * From pgj_empdatrev "
            SQL = SQL & "Where rev_acnum = ('" & UAGrid01(0, k).Value.ToString & "') "
            OpenTbl(PLConn, PLTb3, SQL)
            If PLTb3.RecordCount > 0 Then

                KHMain = IIf(IsDBNull(PLTb3("emp_khtkhl").Value), "", PLTb3("emp_khtkhl").Value)
                KHSub = IIf(IsDBNull(PLTb3("emp_exkhtkhl").Value), "", PLTb3("emp_exkhtkhl").Value)
                JabMain = IIf(IsDBNull(PLTb3("emp_jab").Value), "", PLTb3("emp_jab").Value)
                Gpokokmain = IIf(IsDBNull(PLTb3("emp_gjpokok").Value), "", PLTb3("emp_gjpokok").Value)
                TJabMain = IIf(IsDBNull(PLTb3("emp_tjjabatan").Value), "", PLTb3("emp_tjjabatan").Value)
                NamaMain = IIf(IsDBNull(PLTb3("emp_nama").Value), "", PLTb3("emp_nama").Value)

            Else
                UAGrid01.Invoke(DirectCast(Sub() UAGrid01(6, k).Value = "Nomor EST tidak ada", MethodInvoker))
            End If


            u += 1
            UAGrid01.Invoke(DirectCast(Sub() UAGrid01(0, k).Value = u.ToString, MethodInvoker))
            UAGrid01.Invoke(DirectCast(Sub() UAGrid01(3, k).Value = KHMain, MethodInvoker))
            UAGrid01.Invoke(DirectCast(Sub() UAGrid01(4, k).Value = KHSub, MethodInvoker))

            KHMain = ""
            KHSub = ""

        Next
    End Sub
    Private Sub UABtn03_Click(sender As Object, e As EventArgs) Handles UABtn03.Click

        'LookDateAsHB()
        'Select Case DateCnt
        '    Case "", Nothing, Is <= 0
        '        MessageBox.Show("Your Date is not Registered" & vbCrLf & "/Tanggal Belum Terdaftar")
        '    Case Else
        'Try
        '    ' GenerateValue()
        '    GenerateDataFromEmp()
        '    UABtn04.Enabled = True
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)

        'End Try
        'End Select

        Try
            LoadPeriodeNumberDays()
            GenerateDataFromEmp()

        Catch ex As Exception
            MessageBox.Show("~~~~~~~~~~~~~~~~~~~~~" & ex.ToString & "~~~~~~~~~~~~~~~~~~~~")
        End Try

    End Sub

    Sub Look4DayCtrlValidity()

        SQL = Nothing
        SQL = SQL & "Select * From pgj_lemprdtb "
        SQL = SQL & "Where lmprd_est = ('" & LmbNik & "') "
        SQL = SQL & "and lmprd_periode = ('" & UACmb01.Text & "') "
        SQL = SQL & "and lmprd_perrng = ('" & UADt01.Value.ToString("MMM yyyy", CustomtoUS) & "') "
        OpenTbl(PLConn, PLTb10, SQL)
        If PLTb10.RecordCount > 0 Then

        End If
    End Sub

    Sub SaveMyAbsensi()

        Dim DaSUMonth As String = UADt01.Value.ToString("MMM", CustomtoUS)
        Dim DaSuYr As String = UADt01.Value.ToString("yyyy", CustomtoUS)
        CheckDateIndoEnglish(DaSUMonth)



        If UAGrid01.Rows.Count > 0 Then
            For s = 0 To UAGrid01.Rows.Count - 1
                Select Case UAGrid01(2, s).Value

                    Case Nothing
                        UAGrid01.Invoke(DirectCast(Sub() UAGrid01(26, s).Value = "Tidak Ada Tanggal nya", MethodInvoker))

                    Case Else
                        Dim DateUp As Date = Date.Parse(UAGrid01(2, s).Value)

                        SQL = Nothing
                        SQL = SQL & "Select * From pgj_absensi "
                        SQL = SQL & "Where pgj_abAC = ('" & UAGrid01(0, s).Value.ToString & "') "
                        SQL = SQL & "and pgj_date = ('" & DateUp.ToString("yyyy-MM-dd", CustomtoUS) & "') "
                        SQL = SQL & "and pgj_periode = ('" & UACmb01.Text & "') "
                        SQL = SQL & "and pgj_perrng = ('" & PublicMonth & " " & DaSuYr & "') "
                        OpenTbl(PLConn, PLTb1, SQL)
                        If Not PLTb1.RecordCount <> 0 Then
                            PLTb1.AddNew()
                        End If

                        ' Check for Periode Day

                        SQL = Nothing
                        SQL = SQL & "Select * From pgj_daycontrol "
                        SQL = SQL & "Where dc_date = ('" & DateUp.ToString("yyyy-MM-dd", CustomtoUS) & "') "
                        SQL = SQL & "and dc_periode = ('" & UACmb01.Text & "') "
                        SQL = SQL & "and dc_perioderng = ('" & PublicMonth & " " & DaSuYr & "') "
                        OpenTbl(PLConn, PLTb6, SQL)
                        If PLTb6.RecordCount > 0 Then

                            PLTb1("pgj_periode").Value() = UACmb01.Text
                            PLTb1("pgj_perrng").Value() = PublicMonth & " " & DaSuYr

                            PLTb1("pgj_abAC").Value() = UAGrid01(0, s).Value.ToString
                            PLTb1("pgj_abname").Value() = UAGrid01(1, s).Value.ToString

                            PLTb1("pgj_date").Value() = DateUp.ToString("dd MM yyyy", CustomtoUS)

                            PLTb1("pgj_abShift").Value() = UAGrid01(3, s).Value.ToString
                            PLTb1("pgj_OnDuty").Value() = UAGrid01(4, s).Value.ToString
                            PLTb1("pgj_OffDuty").Value() = UAGrid01(5, s).Value.ToString
                            PLTb1("pgj_ClockIn").Value() = UAGrid01(6, s).Value.ToString
                            PLTb1("pgj_ClockOut").Value() = UAGrid01(7, s).Value.ToString
                            PLTb1("pgj_normal").Value() = UAGrid01(8, s).Value.ToString
                            PLTb1("pgj_realtime").Value() = UAGrid01(9, s).Value.ToString
                            PLTb1("pgj_late").Value() = UAGrid01(10, s).Value.ToString
                            PLTb1("pgj_early").Value() = UAGrid01(11, s).Value.ToString
                            PLTb1("pgj_absent").Value() = UAGrid01(12, s).Value.ToString
                            PLTb1("pgj_ottime").Value() = UAGrid01(13, s).Value.ToString
                            PLTb1("pgj_worktime").Value() = UAGrid01(14, s).Value.ToString
                            PLTb1("pgj_exception").Value() = UAGrid01(15, s).Value.ToString
                            PLTb1("pgj_mustin").Value() = UAGrid01(16, s).Value.ToString
                            PLTb1("pgj_mustout").Value() = UAGrid01(17, s).Value.ToString
                            PLTb1("pgj_department").Value() = UAGrid01(18, s).Value.ToString
                            PLTb1("pgj_Ndays").Value() = UAGrid01(19, s).Value.ToString
                            PLTb1("pgj_wkend").Value() = UAGrid01(20, s).Value.ToString
                            PLTb1("pgj_holday").Value() = UAGrid01(21, s).Value.ToString
                            PLTb1("pgj_atttime").Value() = UAGrid01(22, s).Value.ToString
                            PLTb1("pgj_NDaysOT").Value() = UAGrid01(23, s).Value.ToString
                            PLTb1("pgj_wkendOT").Value() = UAGrid01(24, s).Value.ToString
                            PLTb1("pgj_holdayOT").Value() = UAGrid01(25, s).Value.ToString
                            PLTb1.Update()

                            UAGrid01.Invoke(DirectCast(Sub() UAGrid01(26, s).Value = "Sudah Simpan", MethodInvoker))

                        Else
                            UAGrid01.Invoke(DirectCast(Sub() UAGrid01(26, s).Value = "Data from Periode is Not Registered", MethodInvoker))
                        End If

                End Select

            Next
        End If
    End Sub

    Sub SaveTotAbs()

        If UAGrid01.Rows.Count > 0 Then
            For s = 0 To UAGrid01.Rows.Count - 1

                Select Case UAGrid01(6, s).Value
                    Case "", Nothing
                        SQL = Nothing
                        SQL = SQL & "Select * From pgj_totabsensi "
                        SQL = SQL & "Where ta_est = ('" & UAGrid01(1, s).Value.ToString & "') "
                        SQL = SQL & "and ta_periode = ('" & "" & "') "
                        SQL = SQL & "and ta_periorng = ('" & "" & " ') "
                        OpenTbl(PLConn, PLTb1, SQL)
                        If Not PLTb1.RecordCount <> 0 Then
                            PLTb1.AddNew()
                        End If

                        PLTb1("ta_est").Value() = UAGrid01(1, s).Value.ToString
                        PLTb1("ta_name").Value() = UAGrid01(2, s).Value.ToString
                        PLTb1("ta_value").Value() = UAGrid01(5, s).Value.ToString
                        PLTb1("ta_periode").Value() = UACmb01.Text
                        PLTb1("ta_periorng").Value() = UADt01.Value.ToString("MMM yyyy", CustomtoUS)
                        PLTb1.Update()

                        UAGrid01.Invoke(DirectCast(Sub() UAGrid01(6, s).Value = "Sudah Simpan", MethodInvoker))
                End Select
            Next
        End If
    End Sub

    Sub GenerateDataFromEmp()

        Dim DaSUMonth As String = UADt01.Value.ToString("MMM", CustomtoUS)
        Dim DaSuYr As String = UADt01.Value.ToString("yyyy", CustomtoUS)
        CheckDateIndoEnglish(DaSUMonth)

        ' Looking Data from Employee List
        SQL = Nothing
        SQL = SQL & "Select `rev_nama`, `rev_nik`, `rev_acnum`, `rev_tglkeluar` From pgj_empdatrev "
        SQL = SQL & "Where rev_tglkeluar is null "
        OpenTbl(PLConn, PLTb3, SQL)
        If PLTb3.RecordCount > 0 Then
            PLTb3.MoveFirst()
            Do While Not PLTb3.EOF

                Dim GDFacnum As String = If(IsDBNull(PLTb3("rev_acnum").Value), "", PLTb3("rev_acnum").Value)
                Dim GDFnik As String = If(IsDBNull(PLTb3("rev_nik").Value), "", PLTb3("rev_nik").Value)
                Dim GDFnama As String = If(IsDBNull(PLTb3("rev_nama").Value), "", PLTb3("rev_nama").Value)

                ' Looking Data from Absensi
                SQL = Nothing
                SQL = SQL & "Select `pgj_abAC`, `pgj_abname`, `pgj_periode`, `pgj_perrng`, `pgj_periode` From pgj_absensi "
                SQL = SQL & "Where pgj_abAC = ('" & GDFacnum & "') "
                SQL = SQL & "And pgj_periode = ('" & UACmb01.Text & "') "
                SQL = SQL & "And pgj_perrng = ('" & PublicMonth & " " & DaSuYr & "') "
                OpenTbl(PLConn, PLTb4, SQL)
                If PLTb4.RecordCount > 0 Then

                    ' Saving Number of Present for Absensi

                    SQL = Nothing
                    SQL = SQL & "Select * From pgj_totabsensi "
                    SQL = SQL & "Where ta_est = ('" & GDFnik & "') "
                    SQL = SQL & "and ta_name = ('" & GDFnama & "') "
                    SQL = SQL & "and ta_periode = ('" & UACmb01.Text & "') "
                    SQL = SQL & "and ta_periorng = ('" & PublicMonth & " " & DaSuYr & "') "

                    OpenTbl(PLConn, PLTb5, SQL)
                    If Not PLTb5.RecordCount <> 0 Then
                        PLTb5.AddNew()
                    End If

                    PLTb5("ta_est").Value() = GDFnik
                    PLTb5("ta_name").Value() = GDFnama
                    PLTb5("ta_periode").Value() = UACmb01.Text
                    PLTb5("ta_periorng").Value() = PublicMonth & " " & DaSuYr

                    Dim getMyCount As Int32 = 0

                    getMyCount = (GetCountDays - PLTb4.RecordCount)

                    If getMyCount <= 0 Then
                        PLTb5("ta_value").Value() = 0
                    Else
                        PLTb5("ta_value").Value() = getMyCount.ToString
                    End If
                    PLTb5.Update()

                End If

                PLTb3.MoveNext()
            Loop
        End If
        MessageBox.Show("Done")

    End Sub

    Dim GetCountDays As Int32 = 0
    Sub LoadPeriodeNumberDays()

        Dim DaSUMonth As String = UADt01.Value.ToString("MMM", CustomtoUS)
        Dim DaSuYr As String = UADt01.Value.ToString("yyyy", CustomtoUS)
        CheckDateIndoEnglish(DaSUMonth)

        GetCountDays = 0
        SQL = Nothing
        SQL = SQL & "Select * From pgj_periodesu "
        SQL = SQL & "Where psu_periode = ('" & UACmb01.Text & "') "
        SQL = SQL & "and psu_perioderng = ('" & PublicMonth & " " & DaSuYr & "') "
        OpenTbl(PLConn, PLTb1, SQL)
        If PLTb1.RecordCount > 0 Then
            GetCountDays = If(IsDBNull(PLTb1("psu_count").Value()), 0, Val(PLTb1("psu_count").Value()))
        End If

    End Sub

    Private Sub UACmb01_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub UABtn04_Click(sender As Object, e As EventArgs) Handles UABtn04.Click
        'SaveTotAbs()
        If UAGrid01.Rows.Count >= 1 Then
            SaveMyAbsensi()
        End If
    End Sub

    Private Sub UACmb01_KeyPress1(sender As Object, e As KeyPressEventArgs) Handles UACmb01.KeyPress
        e.Handled = True
    End Sub

    Private Sub UABtn05_Click(sender As Object, e As EventArgs) Handles UABtn05.Click

        Try
            ProcessLmbPrd()
        Catch ex As Exception
            MessageBox.Show(" ~~~~~~~~~~~~~~~ " & ex.ToString & " ~~~~~~~~~~~~~~~~~~~~~~~ ")
        End Try

    End Sub
End Class