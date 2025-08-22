Imports System.IO
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.ComponentModel


Public Class PerEmpListRev

    Private Sub PerEmpListRev_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadDB2()

        'Try
        '    LoadDataEmployee()
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        'End Try

        GridHeader01()
        LoadDataEmployee()
        LoadRevDept()
        LoadRevJabatan()
        LoadRevStandard()

    End Sub

    Sub LoadMasaKerja()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_standard "
        SQL = SQL & "Where st_aktif = ('" & "1" & "') "
        OpenTbl(PLConn, PLTb9, SQL)
        If PLTb9.RecordCount > 0 Then

            Select Case YearCount
                Case Is >= 10
                    ELRInTbx24.Text = IIf(IsDBNull(PLTb9("st_Fgr").Value), 0, PLTb9("st_Fgr").Value)
                Case Is >= 6
                    ELRInTbx24.Text = IIf(IsDBNull(PLTb9("st_Egr").Value), 0, PLTb9("st_Egr").Value)
                Case Is >= 4
                    ELRInTbx24.Text = IIf(IsDBNull(PLTb9("st_Dgr").Value), 0, PLTb9("st_Dgr").Value)
                Case Is >= 3
                    ELRInTbx24.Text = IIf(IsDBNull(PLTb9("st_Cgr").Value), 0, PLTb9("st_Cgr").Value)
                Case Is >= 2
                    ELRInTbx24.Text = IIf(IsDBNull(PLTb9("st_Bgr").Value), 0, PLTb9("st_Bgr").Value)
                Case Is >= 1
                    ELRInTbx24.Text = IIf(IsDBNull(PLTb9("st_Agr").Value), 0, PLTb9("st_Agr").Value)
                Case 0
                    ELRInTbx24.Text = "0"
            End Select

        End If

    End Sub
    Dim YearCount As Long = Nothing
    Sub CountTahun(YrSrvDt As Date)
        YearCount = Nothing

        Dim BdayYearDate As Date = Today
        Dim years As Integer = 0, months As Integer = 0, days As Integer = 0
        Dim toDate As Date = DateTime.Now

        '   Dim DaysCount As String = DateYearDate.Subtract(BdayDate).Days.ToString

        Do Until toDate.AddYears(-1) < YrSrvDt
            years += 1
            toDate = toDate.AddYears(-1)
        Loop

        Do Until toDate.AddMonths(-1) < YrSrvDt
            months += 1
            toDate = toDate.AddMonths(-1)
        Loop

        Do Until toDate.AddDays(-1) < YrSrvDt
            days += 1
            toDate = toDate.AddDays(-1)
        Loop

        YearCount = years
    End Sub

    Sub GridHeader01()

        With PELRGrid01
            .Rows.Clear()
            .Columns.Clear()

            .Columns.Add("col0", "NIK") ' done
            .Columns.Add("col1", "Nama") ' done
            .Columns.Add("col2", "Tempat Lahir") ' done
            .Columns.Add("col3", "Tgl. Lahir") ' done
            .Columns.Add("col4", "J.Kelamin") ' done
            .Columns.Add("col5", "Agama") ' done
            .Columns.Add("col6", "Alamat") ' done
            .Columns.Add("col7", "Telepon") ' done
            .Columns.Add("col8", "Status") ' done
            .Columns.Add("col9", "Anak") ' done
            .Columns.Add("col10", "Pendidikan") ' done
            .Columns.Add("col11", "No. KTP") ' done
            .Columns.Add("col12", "TGL. Msk Kerja") ' done
            .Columns.Add("col13", "TGL. Efektif") ' done
            .Columns.Add("col14", "TGL. Keluar") ' done
            .Columns.Add("col15", "Bagian") ' done
            .Columns.Add("col16", "Nama Bagian") ' done
            .Columns.Add("col17", "Kode Jabatan") ' done
            .Columns.Add("col18", "Jabatan") ' done
            .Columns.Add("col19", "Sistem") ' done
            .Columns.Add("col20", "Gaji Pokok") ' done
            .Columns.Add("col21", "Tunj. Jabatan") ' done
            .Columns.Add("col22", "Tunj. Kerajinan") ' done
            .Columns.Add("col23", "Tunj. Lain Lain") ' done
            .Columns.Add("col24", "Ikut T.Kerja") ' done
            .Columns.Add("col25", "BPJS T.Kerja") ' done    
            .Columns.Add("col26", "Ikut Kesehatan") ' done
            .Columns.Add("col27", "BPJS Kesehatan") ' done
            .Columns.Add("col28", "Tgl Mutasi") ' done
            .Columns.Add("col29", "Mutasi Ke") ' done
            .Columns.Add("col30", "TGL. Pelatihan") ' done
            .Columns.Add("col31", "Pelatihan") ' done
            .Columns.Add("col32", "Pernyatahan") ' done
            .Columns.Add("col33", "AC No.") ' done
            .Columns.Add("col34", "Tipe") ' done
            .Columns.Add("col35", "Kategori") ' done
            .Columns.Add("col36", "NPWP") ' done
            .Columns.Add("col37", "SP1") ' done
            .Columns.Add("col38", "SP2") ' done
            .Columns.Add("col39", "SP3") ' done

            For U = 0 To .Columns.Count - 1
                .Columns(U).Width = 150
            Next

        End With
    End Sub

    Sub LoadRevDept()

        Dim RevDeptKodeHis As New AutoCompleteStringCollection
        Dim RevDeptNamaHis As New AutoCompleteStringCollection

        PELRInCmb04.Items.Clear()
        PELRInCmb05.Items.Clear()

        SQL = Nothing
        SQL = SQL & "Select * From pgj_deptlist "
        OpenTbl(PLConn, PLTb1, SQL)
        If PLTb1.RecordCount <> 0 Then
            PLTb1.MoveFirst()
            Do While Not PLTb1.EOF

                Dim StringUp As String = IIf(IsDBNull(PLTb1("dep_depname").Value), "", PLTb1("dep_depname").Value)
                Dim StringUp2 As String = IIf(IsDBNull(PLTb1("dep_depkode").Value), "", PLTb1("dep_depkode").Value)

                RevDeptKodeHis.Add(StringUp2.ToUpper)
                RevDeptNamaHis.Add(StringUp.ToUpper)

                PELRInCmb04.Items.Add(StringUp2.ToUpper)
                PELRInCmb05.Items.Add(StringUp.ToUpper)

                PLTb1.MoveNext()
            Loop
        End If

        PELRInCmb04.AutoCompleteMode = AutoCompleteMode.Suggest
        PELRInCmb04.AutoCompleteSource = AutoCompleteSource.CustomSource
        PELRInCmb04.AutoCompleteCustomSource = RevDeptKodeHis

        PELRInCmb05.AutoCompleteMode = AutoCompleteMode.Suggest
        PELRInCmb05.AutoCompleteSource = AutoCompleteSource.CustomSource
        PELRInCmb05.AutoCompleteCustomSource = RevDeptNamaHis

    End Sub

    Sub SelectingDeptKode()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_deptlist "
        SQL = SQL & "Where dep_depkode = ('" & PELRInCmb04.Text & "') "
        OpenTbl(PLConn, PLTb3, SQL)
        If PLTb3.RecordCount > 0 Then
            PELRInCmb05.Text = IIf(IsDBNull(PLTb3("dep_depname").Value), "", PLTb3("dep_depname").Value.ToString.ToUpper)
        End If
    End Sub

    Sub SelectingDeptNama()

        SQL = Nothing
        SQL = SQL & "Select * From pgj_deptlist "
        SQL = SQL & "Where dep_depname = ('" & PELRInCmb05.Text & "') "
        OpenTbl(PLConn, PLTb3, SQL)
        If PLTb3.RecordCount > 0 Then
            PELRInCmb04.Text = IIf(IsDBNull(PLTb3("dep_depkode").Value), "", PLTb3("dep_depkode").Value.ToString.ToUpper)
        End If

    End Sub

    Sub LoadRevJabatan()

        Dim RevJabKodeHis As New AutoCompleteStringCollection
        Dim RevJabNamaHis As New AutoCompleteStringCollection

        PELRInCmb06.Items.Clear()
        PELRInCmb07.Items.Clear()

        SQL = Nothing
        SQL = SQL & "Select * From pgj_jablist "
        OpenTbl(PLConn, PLTb4, SQL)
        If PLTb4.RecordCount <> 0 Then
            PLTb4.MoveFirst()
            Do While Not PLTb4.EOF
                Dim getjabkode As String = IIf(IsDBNull(PLTb4("pgj_jabkode").Value), "", PLTb4("pgj_jabkode").Value)
                Dim getjab As String = IIf(IsDBNull(PLTb4("pgj_jabname").Value), "", PLTb4("pgj_jabname").Value)

                RevJabKodeHis.Add(getjabkode.ToUpper)
                RevJabNamaHis.Add(getjab.ToUpper)

                PELRInCmb06.Items.Add(getjabkode.ToUpper)
                PELRInCmb07.Items.Add(getjab.ToUpper)
                PLTb4.MoveNext()
            Loop
        End If

        PELRInCmb06.AutoCompleteMode = AutoCompleteMode.Suggest
        PELRInCmb06.AutoCompleteSource = AutoCompleteSource.CustomSource
        PELRInCmb06.AutoCompleteCustomSource = RevJabKodeHis

        PELRInCmb07.AutoCompleteMode = AutoCompleteMode.Suggest
        PELRInCmb07.AutoCompleteSource = AutoCompleteSource.CustomSource
        PELRInCmb07.AutoCompleteCustomSource = RevJabNamaHis

    End Sub

    Sub SelectingJabKode()

        SQL = Nothing
        SQL = SQL & "Select * From pgj_jablist "
        SQL = SQL & "Where pgj_jabkode = ('" & PELRInCmb06.Text & "') "
        OpenTbl(PLConn, PLTb3, SQL)
        If PLTb3.RecordCount > 0 Then
            PELRInCmb07.Text = IIf(IsDBNull(PLTb3("pgj_jabname").Value), "", PLTb3("pgj_jabname").Value.ToString.ToUpper)
            ELRInTbx17.Text = IIf(IsDBNull(PLTb3("pgj_tunjab").Value), "", PLTb3("pgj_tunjab").Value.ToString.ToUpper)
        End If

    End Sub

    Sub SelectingJabNama()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_jablist "
        SQL = SQL & "Where pgj_jabname = ('" & PELRInCmb07.Text & "') "
        OpenTbl(PLConn, PLTb3, SQL)
        If PLTb3.RecordCount > 0 Then
            PELRInCmb06.Text = IIf(IsDBNull(PLTb3("pgj_jabkode").Value), "", PLTb3("pgj_jabkode").Value.ToString.ToUpper)
            ELRInTbx17.Text = IIf(IsDBNull(PLTb3("pgj_tunjab").Value), "", PLTb3("pgj_tunjab").Value.ToString.ToUpper)
        End If
    End Sub

    Private Sub PELRCmb01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PELRCmb01.KeyPress
        e.Handled = True
    End Sub

    Sub SaveDataEmployee()

        SQL = Nothing
        SQL = SQL & "Select * From Sub SaveEmp()"
        SQL = Nothing
        SQL = SQL & "Select * From pgj_empdatrev "
        SQL = SQL & "Where rev_nik = ('" & PELRInTbx01.Text & "') "
        SQL = SQL & "And rev_nama = ('" & PELRInTbx02.Text.Replace("'", "/") & "') "
        OpenTbl(PLConn, PLTb1, SQL)
        If Not PLTb1.RecordCount <> 0 Then
            PLTb1.AddNew()
        End If

        ' Text Boxes

        PLTb1("rev_nik").Value() = PELRInTbx01.Text
        PLTb1("rev_nama").Value() = PELRInTbx02.Text
        PLTb1("rev_templahir").Value() = PELRInTbx03.Text
        PLTb1("rev_alamat").Value() = PELRInTbx05.Text
        PLTb1("rev_telepon").Value() = ELRInTbx23.Text
        PLTb1("rev_anak").Value() = PELRInTbx06.Text
        PLTb1("rev_pendidikan").Value() = PELRInTbx07.Text
        PLTb1("rev_noktp").Value() = PELRInTbx09.Text
        PLTb1("rev_gajpok").Value() = ELRInTbx20.Text
        PLTb1("rev_tunjjab").Value() = ELRInTbx17.Text
        PLTb1("rev_tunjkera").Value() = ELRInTbx18.Text
        PLTb1("rev_tunjlain").Value() = ELRInTbx19.Text
        PLTb1("rev_tunjmkerja").Value() = ELRInTbx24.Text

        PLTb1("rev_bpjstkerja").Value() = ELRInTbx21.Text
        PLTb1("rev_bpjskese").Value() = ELRInTbx22.Text
        PLTb1("rev_mutasike").Value() = PELRInTbx11.Text
        PLTb1("rev_pela").Value() = PELRInTbx12.Text
        PLTb1("rev_pernya").Value() = PELRInTbx10.Text
        PLTb1("rev_acnum").Value() = PELRInTbx08.Text
        PLTb1("rev_tipe").Value() = ""
        PLTb1("rev_kategori").Value() = ""
        PLTb1("rev_npwp").Value() = PELRInTbx13.Text
        PLTb1("rev_sp1").Value() = ELRInTbx14.Text
        PLTb1("rev_sp2").Value() = ELRInTbx15.Text
        PLTb1("rev_sp3").Value() = ELRInTbx16.Text

        ' Combobox

        PLTb1("rev_jenkel").Value() = PELRInCmb01.Text
        PLTb1("rev_agama").Value() = PELRInCmb02.Text
        PLTb1("rev_status").Value() = PELRInCmb03.Text
        PLTb1("rev_kobagian").Value() = PELRInCmb04.Text
        PLTb1("rev_nabagian").Value() = PELRInCmb05.Text
        PLTb1("rev_kojabatan").Value() = PELRInCmb06.Text
        PLTb1("rev_jabatan").Value() = PELRInCmb07.Text
        PLTb1("rev_sistem").Value() = PELRInCmb08.Text
        PLTb1("rev_ikuttker").Value() = PELRInCmb09.Text
        PLTb1("rev_ikutkese").Value() = PELRInCmb10.Text
        PLTb1("rev_kategori").Value() = PELRInCmb11.Text
        PLTb1("rev_tipe").Value() = PELRInCmb12.Text
        ' Datepicker

        PLTb1("rev_tgllahir").Value() = ELRInDp01.Text
        PLTb1("rev_tglmkerja").Value() = ELRInDp02.Text
        PLTb1("rev_tglefektif").Value() = ELRInDp03.Text

        Select Case PELRInChk01.Checked
            Case True
                PLTb1("rev_tglkeluar").Value() = DBNull.Value
            Case False
                Dim DateTGKel As Date = ELRInDp04.Value
                PLTb1("rev_tglkeluar").Value() = DateTGKel.ToString("dd MM yyyy")
        End Select

        Select Case PELRInTbx11.Text.Length
            Case Is >= 5
                Dim DateTglMut As Date = ELRInDp05.Value
                PLTb1("rev_tglmutasi").Value() = DateTglMut.ToString("dd MM yyyy")
            Case Else
                PLTb1("rev_tglmutasi").Value() = DBNull.Value
        End Select

        Select Case PELRInTbx12.Text.Length
            Case Is >= 5
                Dim DateTglPela As Date = ELRInDp06.Value
                PLTb1("rev_tglpela").Value() = DateTglPela.ToString("dd MM yyyy")
            Case Else
                PLTb1("rev_tglpela").Value() = DBNull.Value
        End Select

        ' Checkbox

        PLTb1.Update()
        LoadDataEmployee()
        CleanData()
        MessageBox.Show("Successfully Saved", Me.Text)

    End Sub

    Sub LoadDataEmployee()
        'GridHeader01()

        PELRGrid01.Rows.Clear()

        SQL = Nothing
        SQL = SQL & "Select * From pgj_empdatrev "
        Select Case PELRCmb01.Text
            Case "Yes"
                SQL = SQL & "Where rev_tglkeluar is null "
            Case "No"
                SQL = SQL & "Where not rev_tglkeluar is null "
        End Select
        OpenTbl(PLConn, PLTb2, SQL)
        If PLTb2.RecordCount > 0 Then
            PLTb2.MoveFirst()
            Do While Not PLTb2.EOF
                Dim LoNik As String = IIf(IsDBNull(PLTb2("rev_nik").Value), "", PLTb2("rev_nik").Value)
                Dim LoNama As String = IIf(IsDBNull(PLTb2("rev_nama").Value), "", PLTb2("rev_nama").Value)
                Dim LoTelahir As String = IIf(IsDBNull(PLTb2("rev_templahir").Value), "", PLTb2("rev_templahir").Value)

                Dim LoTglLahir As Date = IIf(IsDBNull(PLTb2("rev_tgllahir").Value), Nothing, PLTb2("rev_tgllahir").Value) ' Check
                Dim LoAgama As String = IIf(IsDBNull(PLTb2("rev_agama").Value), "", PLTb2("rev_agama").Value)

                Dim LoAlam As String = IIf(IsDBNull(PLTb2("rev_alamat").Value), "", PLTb2("rev_alamat").Value)
                Dim LoTelpon As String = IIf(IsDBNull(PLTb2("rev_telepon").Value), "", PLTb2("rev_telepon").Value)
                Dim LoStat As String = IIf(IsDBNull(PLTb2("rev_status").Value), "", PLTb2("rev_status").Value)
                Dim LoAnak As String = IIf(IsDBNull(PLTb2("rev_anak").Value), "", PLTb2("rev_anak").Value)
                Dim LoPend As String = IIf(IsDBNull(PLTb2("rev_pendidikan").Value), "", PLTb2("rev_pendidikan").Value)
                Dim LoNoKtp As String = IIf(IsDBNull(PLTb2("rev_noktp").Value), "", PLTb2("rev_noktp").Value)

                Dim LoTglMkerja As Date = IIf(IsDBNull(PLTb2("rev_tglmkerja").Value), Nothing, PLTb2("rev_tglmkerja").Value) ' Check
                Dim LoTglEfe As Date = IIf(IsDBNull(PLTb2("rev_tglefektif").Value), Nothing, PLTb2("rev_tglefektif").Value) ' Check
                Dim LoTglKelu As Date = IIf(IsDBNull(PLTb2("rev_tglkeluar").Value), Nothing, PLTb2("rev_tglkeluar").Value) ' Check

                Dim LoJenKel As String = IIf(IsDBNull(PLTb2("rev_jenkel").Value), "", PLTb2("rev_jenkel").Value)
                Dim LoKoBag As String = IIf(IsDBNull(PLTb2("rev_kobagian").Value), "", PLTb2("rev_kobagian").Value)
                Dim LoNaBag As String = IIf(IsDBNull(PLTb2("rev_nabagian").Value), "", PLTb2("rev_nabagian").Value)
                Dim LoKoJab As String = IIf(IsDBNull(PLTb2("rev_kojabatan").Value), "", PLTb2("rev_kojabatan").Value)
                Dim LoNaJab As String = IIf(IsDBNull(PLTb2("rev_jabatan").Value), "", PLTb2("rev_jabatan").Value)
                Dim LoSist As String = IIf(IsDBNull(PLTb2("rev_sistem").Value), "", PLTb2("rev_sistem").Value)
                Dim LoGajPok As String = IIf(IsDBNull(PLTb2("rev_gajpok").Value), "", PLTb2("rev_gajpok").Value)
                Dim LoTuJab As String = IIf(IsDBNull(PLTb2("rev_tunjjab").Value), "", PLTb2("rev_tunjjab").Value)
                Dim LoTuKer As String = IIf(IsDBNull(PLTb2("rev_tunjkera").Value), "", PLTb2("rev_tunjkera").Value)
                Dim LoTuLain As String = IIf(IsDBNull(PLTb2("rev_tunjlain").Value), "", PLTb2("rev_tunjlain").Value)
                Dim LoIkTker As String = IIf(IsDBNull(PLTb2("rev_ikuttker").Value), "", PLTb2("rev_ikuttker").Value)
                Dim LoBpker As String = IIf(IsDBNull(PLTb2("rev_bpjstkerja").Value), "", PLTb2("rev_bpjstkerja").Value)
                Dim LoIkKese As String = IIf(IsDBNull(PLTb2("rev_ikutkese").Value), "", PLTb2("rev_ikutkese").Value)
                Dim LoBpKese As String = IIf(IsDBNull(PLTb2("rev_bpjskese").Value), "", PLTb2("rev_bpjskese").Value)

                Dim LoTglMuta As Date = IIf(IsDBNull(PLTb2("rev_tglmutasi").Value), Nothing, PLTb2("rev_tglmutasi").Value) ' Check
                Dim LoMuke As String = IIf(IsDBNull(PLTb2("rev_mutasike").Value), "", PLTb2("rev_mutasike").Value)
                Dim LoTglPela As Date = IIf(IsDBNull(PLTb2("rev_tglpela").Value), Nothing, PLTb2("rev_tglpela").Value) ' Check

                Dim LoPela As String = IIf(IsDBNull(PLTb2("rev_pela").Value), "", PLTb2("rev_pela").Value)
                Dim LoPernya As String = IIf(IsDBNull(PLTb2("rev_pernya").Value), "", PLTb2("rev_pernya").Value)
                Dim LoACnum As String = IIf(IsDBNull(PLTb2("rev_acnum").Value), "", PLTb2("rev_acnum").Value)
                Dim LoTipe As String = IIf(IsDBNull(PLTb2("rev_tipe").Value), "", PLTb2("rev_tipe").Value)
                Dim LoNpwp As String = IIf(IsDBNull(PLTb2("rev_npwp").Value), "", PLTb2("rev_npwp").Value)
                Dim LoKate As String = IIf(IsDBNull(PLTb2("rev_kategori").Value), "", PLTb2("rev_kategori").Value)
                Dim LoSp1 As String = IIf(IsDBNull(PLTb2("rev_sp1").Value), "", PLTb2("rev_sp1").Value)
                Dim LoSp2 As String = IIf(IsDBNull(PLTb2("rev_sp2").Value), "", PLTb2("rev_sp2").Value)
                Dim LoSp3 As String = IIf(IsDBNull(PLTb2("rev_sp3").Value), "", PLTb2("rev_sp3").Value)

                PELRGrid01.Invoke(DirectCast(Sub() PELRGrid01.Rows.Add(LoNik, LoNama, LoTelahir, IIf(LoTglLahir = Nothing, Nothing, LoTglLahir.ToString("dd MMM yyyy")), LoJenKel, LoAgama, LoAlam, _
                             LoTelpon, LoStat, LoAnak, LoPend, LoNoKtp, IIf(LoTglMkerja = Nothing, Nothing, LoTglMkerja.ToString("dd MMM yyyy")), IIf(LoTglEfe = Nothing, Nothing, LoTglEfe.ToString("dd MMM yyyy")), IIf(LoTglKelu = Nothing, Nothing, LoTglKelu.ToString("dd MMM yyyy")), LoKoBag, _
                             LoNaBag, LoKoJab, LoNaJab, LoSist, LoGajPok, LoTuJab, LoTuKer, LoTuLain, LoIkTker, LoBpker, _
                             LoIkKese, LoBpKese, IIf(LoTglMuta = Nothing, Nothing, LoTglMuta.ToString("dd MMM yyyy")), LoMuke, IIf(LoTglPela = Nothing, Nothing, LoTglPela.ToString("dd MMM yyyy")), LoPela, LoPernya, _
                             LoACnum, LoTipe, LoKate, LoNpwp, LoSp1, LoSp2, LoSp3), MethodInvoker))

                PLTb2.MoveNext()
            Loop
        End If
    End Sub

    Sub ByTypingOnSearchNik(ByVal Looknik As String)
        'GridHeader01()

        PELRGrid01.Rows.Clear()

        SQL = Nothing
        SQL = SQL & "Select * From pgj_empdatrev "
        SQL = SQL & "Where rev_nik like ('" & Looknik.Replace(" ", "%") & "%" & "') "
        SQL = SQL & "And rev_nama like ('" & PELRInTbx02.Text.Replace("'", "/") & "%" & "') "
        Select Case PELRCmb01.Text
            Case "Yes"
                SQL = SQL & "And rev_tglkeluar is null "
            Case "No"
                SQL = SQL & "And not rev_tglkeluar is null "
        End Select
        Select Case PELRTbx02.Text
            Case Nothing, ""
            Case Else
                SQL = SQL & "Limit 15 "
        End Select

        OpenTbl(PLConn, PLTb2, SQL)
        If PLTb2.RecordCount > 0 Then
            PLTb2.MoveFirst()

            Do While Not PLTb2.EOF
                Dim LoNik As String = IIf(IsDBNull(PLTb2("rev_nik").Value), "", PLTb2("rev_nik").Value)
                Dim LoNama As String = IIf(IsDBNull(PLTb2("rev_nama").Value), "", PLTb2("rev_nama").Value)
                Dim LoTelahir As String = IIf(IsDBNull(PLTb2("rev_templahir").Value), "", PLTb2("rev_templahir").Value)

                Dim LoTglLahir As Date = IIf(IsDBNull(PLTb2("rev_tgllahir").Value), Nothing, PLTb2("rev_tgllahir").Value) ' Check

                Dim LoAgama As String = IIf(IsDBNull(PLTb2("rev_agama").Value), "", PLTb2("rev_agama").Value)

                Dim LoAlam As String = IIf(IsDBNull(PLTb2("rev_alamat").Value), "", PLTb2("rev_alamat").Value)
                Dim LoTelpon As String = IIf(IsDBNull(PLTb2("rev_telepon").Value), "", PLTb2("rev_telepon").Value)
                Dim LoStat As String = IIf(IsDBNull(PLTb2("rev_status").Value), "", PLTb2("rev_status").Value)
                Dim LoAnak As String = IIf(IsDBNull(PLTb2("rev_anak").Value), "", PLTb2("rev_anak").Value)
                Dim LoPend As String = IIf(IsDBNull(PLTb2("rev_pendidikan").Value), "", PLTb2("rev_pendidikan").Value)
                Dim LoNoKtp As String = IIf(IsDBNull(PLTb2("rev_noktp").Value), "", PLTb2("rev_noktp").Value)

                Dim LoTglMkerja As Date = IIf(IsDBNull(PLTb2("rev_tglmkerja").Value), Nothing, PLTb2("rev_tglmkerja").Value) ' Check
                Dim LoTglEfe As Date = IIf(IsDBNull(PLTb2("rev_tglefektif").Value), Nothing, PLTb2("rev_tglefektif").Value) ' Check
                Dim LoTglKelu As Date = IIf(IsDBNull(PLTb2("rev_tglkeluar").Value), Nothing, PLTb2("rev_tglkeluar").Value) ' Check

                Dim LoJenKel As String = IIf(IsDBNull(PLTb2("rev_jenkel").Value), "", PLTb2("rev_jenkel").Value)
                Dim LoKoBag As String = IIf(IsDBNull(PLTb2("rev_kobagian").Value), "", PLTb2("rev_kobagian").Value)
                Dim LoNaBag As String = IIf(IsDBNull(PLTb2("rev_nabagian").Value), "", PLTb2("rev_nabagian").Value)
                Dim LoKoJab As String = IIf(IsDBNull(PLTb2("rev_kojabatan").Value), "", PLTb2("rev_kojabatan").Value)
                Dim LoNaJab As String = IIf(IsDBNull(PLTb2("rev_jabatan").Value), "", PLTb2("rev_jabatan").Value)
                Dim LoSist As String = IIf(IsDBNull(PLTb2("rev_sistem").Value), "", PLTb2("rev_sistem").Value)
                Dim LoGajPok As String = IIf(IsDBNull(PLTb2("rev_gajpok").Value), "", PLTb2("rev_gajpok").Value)
                Dim LoTuJab As String = IIf(IsDBNull(PLTb2("rev_tunjjab").Value), "", PLTb2("rev_tunjjab").Value)
                Dim LoTuKer As String = IIf(IsDBNull(PLTb2("rev_tunjkera").Value), "", PLTb2("rev_tunjkera").Value)
                Dim LoTuLain As String = IIf(IsDBNull(PLTb2("rev_tunjlain").Value), "", PLTb2("rev_tunjlain").Value)
                Dim LoIkTker As String = IIf(IsDBNull(PLTb2("rev_ikuttker").Value), "", PLTb2("rev_ikuttker").Value)
                Dim LoBpker As String = IIf(IsDBNull(PLTb2("rev_bpjstkerja").Value), "", PLTb2("rev_bpjstkerja").Value)
                Dim LoIkKese As String = IIf(IsDBNull(PLTb2("rev_ikutkese").Value), "", PLTb2("rev_ikutkese").Value)
                Dim LoBpKese As String = IIf(IsDBNull(PLTb2("rev_bpjskese").Value), "", PLTb2("rev_bpjskese").Value)

                Dim LoTglMuta As Date = IIf(IsDBNull(PLTb2("rev_tglmutasi").Value), Nothing, PLTb2("rev_tglmutasi").Value) ' Check
                Dim LoMuke As String = IIf(IsDBNull(PLTb2("rev_mutasike").Value), "", PLTb2("rev_mutasike").Value)
                Dim LoTglPela As Date = IIf(IsDBNull(PLTb2("rev_tglpela").Value), Nothing, PLTb2("rev_tglpela").Value) ' Check

                Dim LoPela As String = IIf(IsDBNull(PLTb2("rev_pela").Value), "", PLTb2("rev_pela").Value)
                Dim LoPernya As String = IIf(IsDBNull(PLTb2("rev_pernya").Value), "", PLTb2("rev_pernya").Value)
                Dim LoACnum As String = IIf(IsDBNull(PLTb2("rev_acnum").Value), "", PLTb2("rev_acnum").Value)
                Dim LoTipe As String = IIf(IsDBNull(PLTb2("rev_tipe").Value), "", PLTb2("rev_tipe").Value)
                Dim LoNpwp As String = IIf(IsDBNull(PLTb2("rev_npwp").Value), "", PLTb2("rev_npwp").Value)
                Dim LoKate As String = IIf(IsDBNull(PLTb2("rev_kategori").Value), "", PLTb2("rev_kategori").Value)

                Dim LoSp1 As String = IIf(IsDBNull(PLTb2("rev_sp1").Value), "", PLTb2("rev_sp1").Value)
                Dim LoSp2 As String = IIf(IsDBNull(PLTb2("rev_sp2").Value), "", PLTb2("rev_sp2").Value)
                Dim LoSp3 As String = IIf(IsDBNull(PLTb2("rev_sp3").Value), "", PLTb2("rev_sp3").Value)

                PELRGrid01.Invoke(DirectCast(Sub() PELRGrid01.Rows.Add(LoNik, LoNama, LoTelahir, IIf(LoTglLahir = Nothing, Nothing, LoTglLahir.ToString("dd MMM yyyy")), LoJenKel, LoAgama, LoAlam, _
                                   LoTelpon, LoStat, LoAnak, LoPend, LoNoKtp, IIf(LoTglMkerja = Nothing, Nothing, LoTglMkerja.ToString("dd MMM yyyy")), IIf(LoTglEfe = Nothing, Nothing, LoTglEfe.ToString("dd MMM yyyy")), IIf(LoTglKelu = Nothing, Nothing, LoTglKelu.ToString("dd MMM yyyy")), LoKoBag, _
                                   LoNaBag, LoKoJab, LoNaJab, LoSist, LoGajPok, LoTuJab, LoTuKer, LoTuLain, LoIkTker, LoBpker, _
                                   LoIkKese, LoBpKese, IIf(LoTglMuta = Nothing, Nothing, LoTglMuta.ToString("dd MMM yyyy")), LoMuke, IIf(LoTglPela = Nothing, Nothing, LoTglPela.ToString("dd MMM yyyy")), LoPela, LoPernya, _
                                   LoACnum, LoTipe, LoKate, LoNpwp, LoSp1, LoSp2, LoSp3), MethodInvoker))

                PLTb2.MoveNext()
            Loop
        End If
    End Sub

    Sub ByTypingOnSearchNama(ByVal LookNama As String)
        'GridHeader01()

        PELRGrid01.Rows.Clear()

        SQL = Nothing
        SQL = SQL & "Select * From pgj_empdatrev "
        SQL = SQL & "Where rev_nik like ('" & PELRTbx01.Text.Replace(" ", "%") & "%" & "') "
        SQL = SQL & "And rev_nama like ('" & LookNama.Replace("'", "/") & "%" & "') "
        Select Case PELRCmb01.Text
            Case "Yes"
                SQL = SQL & "And rev_tglkeluar is null "
            Case "No"
                SQL = SQL & "And not rev_tglkeluar is null "
        End Select
        Select Case PELRTbx02.Text
            Case Nothing, ""
            Case Else
                SQL = SQL & "Limit 15 "
        End Select

        OpenTbl(PLConn, PLTb2, SQL)
        If PLTb2.RecordCount > 0 Then
            PLTb2.MoveFirst()
            Do While Not PLTb2.EOF
                Dim LoNik As String = IIf(IsDBNull(PLTb2("rev_nik").Value), "", PLTb2("rev_nik").Value)
                Dim LoNama As String = IIf(IsDBNull(PLTb2("rev_nama").Value), "", PLTb2("rev_nama").Value)
                Dim LoTelahir As String = IIf(IsDBNull(PLTb2("rev_templahir").Value), "", PLTb2("rev_templahir").Value)

                Dim LoTglLahir As Date = IIf(IsDBNull(PLTb2("rev_tgllahir").Value), Nothing, PLTb2("rev_tgllahir").Value) ' Check

                Dim LoAgama As String = IIf(IsDBNull(PLTb2("rev_agama").Value), "", PLTb2("rev_agama").Value)

                Dim LoAlam As String = IIf(IsDBNull(PLTb2("rev_alamat").Value), "", PLTb2("rev_alamat").Value)
                Dim LoTelpon As String = IIf(IsDBNull(PLTb2("rev_telepon").Value), "", PLTb2("rev_telepon").Value)
                Dim LoStat As String = IIf(IsDBNull(PLTb2("rev_status").Value), "", PLTb2("rev_status").Value)
                Dim LoAnak As String = IIf(IsDBNull(PLTb2("rev_anak").Value), "", PLTb2("rev_anak").Value)
                Dim LoPend As String = IIf(IsDBNull(PLTb2("rev_pendidikan").Value), "", PLTb2("rev_pendidikan").Value)
                Dim LoNoKtp As String = IIf(IsDBNull(PLTb2("rev_noktp").Value), "", PLTb2("rev_noktp").Value)

                Dim LoTglMkerja As Date = IIf(IsDBNull(PLTb2("rev_tglmkerja").Value), Nothing, PLTb2("rev_tglmkerja").Value) ' Check
                Dim LoTglEfe As Date = IIf(IsDBNull(PLTb2("rev_tglefektif").Value), Nothing, PLTb2("rev_tglefektif").Value) ' Check
                Dim LoTglKelu As Date = IIf(IsDBNull(PLTb2("rev_tglkeluar").Value), Nothing, PLTb2("rev_tglkeluar").Value) ' Check

                Dim LoJenKel As String = IIf(IsDBNull(PLTb2("rev_jenkel").Value), "", PLTb2("rev_jenkel").Value)
                Dim LoKoBag As String = IIf(IsDBNull(PLTb2("rev_kobagian").Value), "", PLTb2("rev_kobagian").Value)
                Dim LoNaBag As String = IIf(IsDBNull(PLTb2("rev_nabagian").Value), "", PLTb2("rev_nabagian").Value)
                Dim LoKoJab As String = IIf(IsDBNull(PLTb2("rev_kojabatan").Value), "", PLTb2("rev_kojabatan").Value)
                Dim LoNaJab As String = IIf(IsDBNull(PLTb2("rev_jabatan").Value), "", PLTb2("rev_jabatan").Value)
                Dim LoSist As String = IIf(IsDBNull(PLTb2("rev_sistem").Value), "", PLTb2("rev_sistem").Value)
                Dim LoGajPok As String = IIf(IsDBNull(PLTb2("rev_gajpok").Value), "", PLTb2("rev_gajpok").Value)
                Dim LoTuJab As String = IIf(IsDBNull(PLTb2("rev_tunjjab").Value), "", PLTb2("rev_tunjjab").Value)
                Dim LoTuKer As String = IIf(IsDBNull(PLTb2("rev_tunjkera").Value), "", PLTb2("rev_tunjkera").Value)
                Dim LoTuLain As String = IIf(IsDBNull(PLTb2("rev_tunjlain").Value), "", PLTb2("rev_tunjlain").Value)
                Dim LoIkTker As String = IIf(IsDBNull(PLTb2("rev_ikuttker").Value), "", PLTb2("rev_ikuttker").Value)
                Dim LoBpker As String = IIf(IsDBNull(PLTb2("rev_bpjstkerja").Value), "", PLTb2("rev_bpjstkerja").Value)
                Dim LoIkKese As String = IIf(IsDBNull(PLTb2("rev_ikutkese").Value), "", PLTb2("rev_ikutkese").Value)
                Dim LoBpKese As String = IIf(IsDBNull(PLTb2("rev_bpjskese").Value), "", PLTb2("rev_bpjskese").Value)

                Dim LoTglMuta As Date = IIf(IsDBNull(PLTb2("rev_tglmutasi").Value), Nothing, PLTb2("rev_tglmutasi").Value) ' Check
                Dim LoMuke As String = IIf(IsDBNull(PLTb2("rev_mutasike").Value), "", PLTb2("rev_mutasike").Value)
                Dim LoTglPela As Date = IIf(IsDBNull(PLTb2("rev_tglpela").Value), Nothing, PLTb2("rev_tglpela").Value) ' Check

                Dim LoPela As String = IIf(IsDBNull(PLTb2("rev_pela").Value), "", PLTb2("rev_pela").Value)
                Dim LoPernya As String = IIf(IsDBNull(PLTb2("rev_pernya").Value), "", PLTb2("rev_pernya").Value)
                Dim LoACnum As String = IIf(IsDBNull(PLTb2("rev_acnum").Value), "", PLTb2("rev_acnum").Value)
                Dim LoTipe As String = IIf(IsDBNull(PLTb2("rev_tipe").Value), "", PLTb2("rev_tipe").Value)
                Dim LoNpwp As String = IIf(IsDBNull(PLTb2("rev_npwp").Value), "", PLTb2("rev_npwp").Value)
                Dim LoKate As String = IIf(IsDBNull(PLTb2("rev_kategori").Value), "", PLTb2("rev_kategori").Value)
                Dim LoSp1 As String = IIf(IsDBNull(PLTb2("rev_sp1").Value), "", PLTb2("rev_sp1").Value)
                Dim LoSp2 As String = IIf(IsDBNull(PLTb2("rev_sp2").Value), "", PLTb2("rev_sp2").Value)
                Dim LoSp3 As String = IIf(IsDBNull(PLTb2("rev_sp3").Value), "", PLTb2("rev_sp3").Value)

                PELRGrid01.Invoke(DirectCast(Sub() PELRGrid01.Rows.Add(LoNik, LoNama, LoTelahir, IIf(LoTglLahir = Nothing, Nothing, LoTglLahir.ToString("dd MMM yyyy")), LoJenKel, LoAgama, LoAlam, _
                                   LoTelpon, LoStat, LoAnak, LoPend, LoNoKtp, IIf(LoTglMkerja = Nothing, Nothing, LoTglMkerja.ToString("dd MMM yyyy")), IIf(LoTglEfe = Nothing, Nothing, LoTglEfe.ToString("dd MMM yyyy")), IIf(LoTglKelu = Nothing, Nothing, LoTglKelu.ToString("dd MMM yyyy")), LoKoBag, _
                                   LoNaBag, LoKoJab, LoNaJab, LoSist, LoGajPok, LoTuJab, LoTuKer, LoTuLain, LoIkTker, LoBpker, _
                                   LoIkKese, LoBpKese, IIf(LoTglMuta = Nothing, Nothing, LoTglMuta.ToString("dd MMM yyyy")), LoMuke, IIf(LoTglPela = Nothing, Nothing, LoTglPela.ToString("dd MMM yyyy")), LoPela, LoPernya, _
                                   LoACnum, LoTipe, LoKate, LoNpwp, LoSp1, LoSp2, LoSp3), MethodInvoker))
                PLTb2.MoveNext()
            Loop
        End If
    End Sub

    Private Sub PELRInBtn01_Click(sender As Object, e As EventArgs) Handles PELRInBtn01.Click

        Select Case PELRInTbx01.Text
            Case Nothing
                MessageBox.Show("Tidak adah No. Nik")
                Exit Sub
        End Select

        Select Case PELRInTbx02.Text
            Case Nothing
                MessageBox.Show("Tidak adah Nama nya")
                Exit Sub
        End Select
        Try
            SaveDataEmployee()
            LoadRevStandard()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub PELRTbx01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PELRTbx01.KeyPress
        ByTypingOnSearchNik(PELRTbx01.Text)
    End Sub

    Private Sub PELRTbx02_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PELRTbx02.KeyPress
        ByTypingOnSearchNama(PELRTbx02.Text)
    End Sub
    Private Sub PELRInCmb04_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PELRInCmb04.SelectedIndexChanged
        PELRInCmb05.Text = Nothing
        SelectingDeptKode()
    End Sub

    Private Sub PELRInCmb01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PELRInCmb01.KeyPress
        e.Handled = True
    End Sub
    Private Sub PELRInCmb02_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PELRInCmb02.KeyPress
        e.Handled = True
    End Sub

    Private Sub PELRInCmb03_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PELRInCmb03.KeyPress
        e.Handled = True
    End Sub
    Private Sub PELRInCmb05_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PELRInCmb05.SelectedIndexChanged
        SelectingDeptNama()
    End Sub
    Private Sub PELRInCmb06_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PELRInCmb06.SelectedIndexChanged
        SelectingJabKode()
    End Sub
    Private Sub PELRInCmb07_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PELRInCmb07.SelectedIndexChanged
        SelectingJabNama()
    End Sub

    Private Sub ELRInDp02_ValueChanged(sender As Object, e As EventArgs) Handles ELRInDp02.ValueChanged
        ELRInDp03.Text = ELRInDp02.Text
    End Sub

    Private Sub PELRInChk01_CheckedChanged(sender As Object, e As EventArgs) Handles PELRInChk01.CheckedChanged
        Select Case PELRInChk01.Checked
            Case True
                ELRInDp04.Enabled = False
            Case False
                ELRInDp04.Enabled = True
        End Select
    End Sub

    Private Sub PELRInCmb10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PELRInCmb10.KeyPress
        e.Handled = True
    End Sub

    Private Sub PELRInCmb09_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PELRInCmb09.KeyPress
        e.Handled = True
    End Sub
    Dim GetRow As Int32
    Private Sub PELRGrid01_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles PELRGrid01.CellMouseDown
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub
        PELRGrid01.CurrentCell = PELRGrid01(e.ColumnIndex, e.RowIndex)
        GetRow = e.RowIndex
    End Sub

    Sub RevEditingEmp()

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If PELRGrid01.Rows.Count > 0 Then
            Dim RevDelNik = PELRGrid01.CurrentRow.Cells(0).Value.ToString ' Est
            Dim RevDelNama = PELRGrid01.CurrentRow.Cells(1).Value.ToString ' Nama
            Select Case MsgBox("Do you want to Delete this " & RevDelNik & " : " & RevDelNama & " ??", MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes

                    ' Deletign my Employee
                    SQL = Nothing
                    SQL = SQL & "Select * From pgj_empdatrev "
                    SQL = SQL & "Where rev_nik = ('" & RevDelNik & "') "
                    SQL = SQL & "And rev_nama = ('" & RevDelNama.Replace("'", "/") & "') "
                    OpenTbl(PLConn, PLTb8, SQL)
                    If PLTb8.RecordCount > 0 Then
                        PLTb8.Delete()
                    End If
                    LoadDataEmployee()

            End Select
        End If
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click
        PELRInTbx01.Focus()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

        TabControl1.SelectTab(1)
        If PELRGrid01.Rows.Count > 0 Then
            With PELRGrid01

                ELRInDp01.Text = Today.ToString
                ELRInDp02.Text = Today.ToString
                ELRInDp03.Text = Today.ToString
                ELRInDp04.Text = Today.ToString
                ELRInDp05.Text = Today.ToString
                ELRInDp06.Text = Today.ToString

                ' Textbox
                PELRInTbx01.Text = .CurrentRow.Cells(0).Value.ToString
                PELRInTbx02.Text = .CurrentRow.Cells(1).Value.ToString
                PELRInTbx03.Text = .CurrentRow.Cells(2).Value.ToString
                PELRInTbx05.Text = .CurrentRow.Cells(6).Value.ToString
                ELRInTbx23.Text = .CurrentRow.Cells(7).Value.ToString
                PELRInTbx06.Text = .CurrentRow.Cells(9).Value.ToString
                PELRInTbx07.Text = .CurrentRow.Cells(10).Value.ToString
                PELRInTbx09.Text = .CurrentRow.Cells(11).Value.ToString
                ELRInTbx20.Text = .CurrentRow.Cells(20).Value.ToString
                ELRInTbx17.Text = .CurrentRow.Cells(21).Value.ToString
                ELRInTbx18.Text = .CurrentRow.Cells(22).Value.ToString
                ELRInTbx19.Text = .CurrentRow.Cells(23).Value.ToString
                ELRInTbx21.Text = .CurrentRow.Cells(25).Value.ToString
                ELRInTbx22.Text = .CurrentRow.Cells(27).Value.ToString
                PELRInTbx11.Text = .CurrentRow.Cells(29).Value.ToString
                PELRInTbx12.Text = .CurrentRow.Cells(31).Value.ToString
                PELRInTbx10.Text = .CurrentRow.Cells(32).Value.ToString
                PELRInTbx08.Text = .CurrentRow.Cells(33).Value.ToString
                ELRInTbx14.Text = .CurrentRow.Cells(37).Value.ToString
                ELRInTbx15.Text = .CurrentRow.Cells(38).Value.ToString
                ELRInTbx16.Text = .CurrentRow.Cells(39).Value.ToString

                PELRInTbx13.Text = .CurrentRow.Cells(36).Value.ToString
                ELRInTbx14.Text = .CurrentRow.Cells(37).Value.ToString
                ELRInTbx15.Text = .CurrentRow.Cells(38).Value.ToString
                ELRInTbx16.Text = .CurrentRow.Cells(39).Value.ToString

                '  Combo box

                PELRInCmb01.Text = .CurrentRow.Cells(4).Value.ToString
                PELRInCmb02.Text = .CurrentRow.Cells(5).Value.ToString
                PELRInCmb03.Text = .CurrentRow.Cells(8).Value.ToString
                PELRInCmb04.Text = .CurrentRow.Cells(15).Value.ToString
                PELRInCmb05.Text = .CurrentRow.Cells(16).Value.ToString
                PELRInCmb06.Text = .CurrentRow.Cells(17).Value.ToString
                PELRInCmb07.Text = .CurrentRow.Cells(18).Value.ToString
                PELRInCmb08.Text = .CurrentRow.Cells(19).Value.ToString
                PELRInCmb09.Text = .CurrentRow.Cells(24).Value.ToString
                PELRInCmb10.Text = .CurrentRow.Cells(26).Value.ToString
                PELRInCmb11.Text = .CurrentRow.Cells(35).Value.ToString
                PELRInCmb12.Text = .CurrentRow.Cells(34).Value.ToString

                ' Datepicker

                ELRInDp01.Text = .CurrentRow.Cells(3).Value
                ELRInDp02.Text = .CurrentRow.Cells(12).Value
                ELRInDp03.Text = .CurrentRow.Cells(13).Value

                Select Case .CurrentRow.Cells(14).Value
                    Case Nothing
                        PELRInChk01.Checked = True
                    Case Else
                        PELRInChk01.Checked = False
                        ELRInDp04.Text = .CurrentRow.Cells(14).Value
                End Select

                ELRInDp05.Text = .CurrentRow.Cells(28).Value
                ELRInDp06.Text = .CurrentRow.Cells(30).Value

            End With
        End If
    End Sub

    Sub CleanData()
        PELRInTbx01.Text = Nothing
        PELRInTbx02.Text = Nothing
        PELRInTbx03.Text = Nothing
        PELRInTbx05.Text = Nothing
        ELRInTbx23.Text = Nothing
        PELRInTbx06.Text = Nothing
        PELRInTbx07.Text = Nothing
        PELRInTbx09.Text = Nothing
        ELRInTbx20.Text = Nothing
        ELRInTbx17.Text = Nothing
        ELRInTbx18.Text = Nothing
        ELRInTbx19.Text = Nothing
        ELRInTbx21.Text = Nothing
        ELRInTbx22.Text = Nothing
        PELRInTbx11.Text = Nothing
        PELRInTbx12.Text = Nothing
        PELRInTbx10.Text = Nothing
        PELRInTbx08.Text = Nothing
        ELRInTbx14.Text = Nothing
        ELRInTbx15.Text = Nothing
        ELRInTbx16.Text = Nothing
        PELRInTbx13.Text = Nothing
        ELRInTbx14.Text = Nothing
        ELRInTbx15.Text = Nothing
        ELRInTbx16.Text = Nothing
        ELRInTbx24.Text = Nothing
        '  Combo box
        PELRInCmb01.Text = Nothing
        PELRInCmb02.Text = Nothing
        PELRInCmb03.Text = Nothing
        PELRInCmb04.Text = Nothing
        PELRInCmb05.Text = Nothing
        PELRInCmb06.Text = Nothing
        PELRInCmb07.Text = Nothing
        PELRInCmb08.Text = Nothing
        PELRInCmb09.Text = Nothing
        PELRInCmb10.Text = Nothing
        PELRInCmb11.Text = Nothing
        PELRInCmb12.Text = Nothing

        ' Datepicker

        ELRInDp01.Text = Today.ToString
        ELRInDp02.Text = Today.ToString
        ELRInDp03.Text = Today.ToString

        ELRInDp04.Text = Today.ToString
        ELRInDp05.Text = Today.ToString
        ELRInDp06.Text = Today.ToString
    End Sub

    Private Sub PELRInCmb11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PELRInCmb11.KeyPress
        e.Handled = True
    End Sub

    Private Sub PELRInCmb12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PELRInCmb12.KeyPress
        e.Handled = True
    End Sub
    Private Sub ELRInTbx24_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ELRInTbx24.KeyPress
        e.Handled = True
    End Sub

    Sub LoadRevStandard()

        SQL = Nothing
        SQL = SQL & "Select `st_aktif`, `st_pdumr`, `st_umr` From pgj_standard "
        SQL = SQL & "Where st_aktif = ('" & CInt(Int(True)) & "') "
        OpenTbl(PLConn, PLTb2, SQL)
        If PLTb2.RecordCount > 0 Then

            ELRInTbx20.Text = PLTb2("st_umr").Value()
        End If
    End Sub

    Private Sub PELRInCmb08_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PELRInCmb08.KeyPress
        e.Handled = True
    End Sub

#Region "Excel Mode"

    Sub ExportExcel()

        Dim NewFile As New FileInfo(SaveName)
        If NewFile.Exists Then
            NewFile.Delete()
        End If

        Using ExcelModPkg = New ExcelPackage(NewFile)

            Dim ExcelNewWSH As ExcelWorksheet = ExcelModPkg.Workbook.Worksheets.Add("ALL")

            ExcelNewWSH.PrinterSettings.PaperSize = ePaperSize.Legal
            ExcelNewWSH.PrinterSettings.Orientation = eOrientation.Landscape

            With ExcelNewWSH.Cells("A1:AN1")
                .Merge = True
                .Value = "PT. UNIVERSAL GLOVES"
                .Style.Font.Bold = True
                .Style.Font.Size = 12
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Font.Name = "CALIBRI"
            End With

            With ExcelNewWSH.Cells("A2:AN2")
                .Merge = True
                .Value = "JL. Pertahanan No. 17 Patumbak 20361 Deli Serdang  - Indonesia"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
            End With

            With ExcelNewWSH.Cells("A3:AN3")
                .Merge = True
                .Value = "Data Karyawan"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
            End With

            With ExcelNewWSH.Cells("A4:AN4")
                .Merge = True
                .Value = ""
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
            End With

            With ExcelNewWSH.Cells("A6")
                .Value = "Nik"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)
            End With

            With ExcelNewWSH.Cells("B6")
                .Value = "Nama"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)
            End With

            With ExcelNewWSH.Cells("C6")
                .Value = "Tempat Lahir"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)
            End With

            With ExcelNewWSH.Cells("D6")
                .Value = "Tgl. Lahir"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)
            End With

            With ExcelNewWSH.Cells("E6")
                .Value = "Jenis Kelamin"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)
            End With

            With ExcelNewWSH.Cells("F6")
                .Value = "Agama"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)
            End With

            With ExcelNewWSH.Cells("G6")
                .Value = "Alamat"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)
            End With

            With ExcelNewWSH.Cells("H6")
                .Value = "Telepon"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)
            End With

            With ExcelNewWSH.Cells("I6")
                .Value = "Status"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)
            End With

            With ExcelNewWSH.Cells("J6")

                .Value = "Anak"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("K6")

                .Value = "Pendidikan"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("L6")

                .Value = "No. KTP"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("M6")

                .Value = "TGL. Masuk Kerja"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("N6")

                .Value = "TGL.Efektif"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("O6")

                .Value = "TGL. Keluar "
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("P6")

                .Value = "Kode Bagian"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("Q6")

                .Value = "Nama Bagian"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("R6")

                .Value = "Kode Jabatan"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("S6")

                .Value = "Jabatan"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("T6")

                .Value = "Sistem Gaji"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("U6")

                .Value = "Gaji Pokok"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("V6")

                .Value = "Tunj. Jabatan"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("W6")

                .Value = "Tunj. Kerajinan"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)
            End With

            With ExcelNewWSH.Cells("X6")

                .Value = "Tunj. Lain Lain"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("Y6")

                .Value = "Ikut T.Kerja"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("Z6")

                .Value = "BPJS T.Kerja"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("AA6")

                .Value = "Ikut Kesehatan"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("AB6")

                .Value = "BPJS Kesehatan"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("AC6")

                .Value = "Tgl Mutasi"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("AD6")

                .Value = "Mutasi Ke"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("AE6")

                .Value = "TGL. Pelatihan"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("AF6")

                .Value = "Pelatihan"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("AG6")

                .Value = "Pernyatahan"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("AH6")

                .Value = "AC No."
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("AI6")

                .Value = "Tipe"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("AJ6")

                .Value = "Kategori"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("AK6")

                .Value = "NPWP"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("AL6")

                .Value = "SP 1"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("AM6")

                .Value = "SP 2"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            With ExcelNewWSH.Cells("AN6")

                .Value = "SP 3"
                .Style.Font.Bold = True
                .Style.Font.Size = 10
                .Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                .Style.Border.BorderAround(ExcelBorderStyle.Thin)

            End With

            For KI = 0 To PELRGrid01.Rows.Count - 1

                With ExcelNewWSH.Cells("A" & (KI + 7).ToString)

                    .Value = PELRGrid01(0, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("B" & (KI + 7).ToString)

                    .Value = PELRGrid01(1, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("C" & (KI + 7).ToString)

                    .Value = PELRGrid01(2, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("D" & (KI + 7).ToString)

                    .Value = PELRGrid01(3, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("E" & (KI + 7).ToString)

                    .Value = PELRGrid01(4, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("F" & (KI + 7).ToString)

                    .Value = PELRGrid01(5, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("G" & (KI + 7).ToString)

                    .Value = PELRGrid01(6, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("H" & (KI + 7).ToString)

                    .Value = PELRGrid01(7, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("I" & (KI + 7).ToString)

                    .Value = PELRGrid01(8, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("J" & (KI + 7).ToString)

                    .Value = PELRGrid01(9, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("K" & (KI + 7).ToString)

                    .Value = PELRGrid01(10, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("L" & (KI + 7).ToString)

                    .Value = PELRGrid01(11, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("M" & (KI + 7).ToString)

                    .Value = PELRGrid01(12, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("N" & (KI + 7).ToString)

                    .Value = PELRGrid01(13, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("O" & (KI + 7).ToString)

                    .Value = PELRGrid01(14, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("P" & (KI + 7).ToString)

                    .Value = PELRGrid01(15, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("Q" & (KI + 7).ToString)

                    .Value = PELRGrid01(16, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("R" & (KI + 7).ToString)

                    .Value = PELRGrid01(17, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("S" & (KI + 7).ToString)

                    .Value = PELRGrid01(18, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)

                End With

                With ExcelNewWSH.Cells("T" & (KI + 7).ToString)

                    .Value = PELRGrid01(19, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("U" & (KI + 7).ToString)
                    .Value = PELRGrid01(20, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("V" & (KI + 7).ToString)
                    .Value = PELRGrid01(21, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("W" & (KI + 7).ToString)

                    .Value = PELRGrid01(22, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("X" & (KI + 7).ToString)

                    .Value = PELRGrid01(23, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("Y" & (KI + 7).ToString)

                    .Value = PELRGrid01(24, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("Z" & (KI + 7).ToString)

                    .Value = PELRGrid01(25, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("AA" & (KI + 7).ToString)

                    .Value = PELRGrid01(26, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("AB" & (KI + 7).ToString)

                    .Value = PELRGrid01(27, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("AC" & (KI + 7).ToString)

                    .Value = PELRGrid01(28, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("AD" & (KI + 7).ToString)

                    .Value = PELRGrid01(29, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("AE" & (KI + 7).ToString)

                    .Value = PELRGrid01(30, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("AF" & (KI + 7).ToString)

                    .Value = PELRGrid01(31, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("AG" & (KI + 7).ToString)

                    .Value = PELRGrid01(32, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("AH" & (KI + 7).ToString)

                    .Value = PELRGrid01(33, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("AI" & (KI + 7).ToString)

                    .Value = PELRGrid01(34, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("AJ" & (KI + 7).ToString)

                    .Value = PELRGrid01(35, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("AK" & (KI + 7).ToString)

                    .Value = PELRGrid01(36, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("AL" & (KI + 7).ToString)

                    .Value = PELRGrid01(37, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

                With ExcelNewWSH.Cells("AM" & (KI + 7).ToString)

                    .Value = PELRGrid01(38, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With


                With ExcelNewWSH.Cells("AN" & (KI + 7).ToString)

                    .Value = PELRGrid01(39, KI).Value
                    .Style.Font.Bold = False
                    .Style.Font.Size = 10
                    .Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                    .Style.Border.BorderAround(ExcelBorderStyle.Thin)
                End With

            Next

            For AF = 1 To 30
                ExcelNewWSH.Column(AF).AutoFit()
            Next

            ExcelModPkg.Save()
            Dim LookMe As New ProcessStartInfo(SaveName)
            Process.Start(LookMe)

        End Using

        ' Create Work Sheet

    End Sub

    Dim SaveName As String
    Sub SaveFileLink()

        Dim SaveFileName As New SaveFileDialog
        SaveFileName.Filter = "Excel File (*.xlsx)|*.xlsx"
        SaveFileName.FilterIndex = 1
        If SaveFileName.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            SaveName = SaveFileName.FileName
        End If

    End Sub
#End Region

    Private Sub PELRInBtn03_Click(sender As Object, e As EventArgs) Handles PELRInBtn03.Click
        Select Case PELRGrid01.Rows.Count

            Case Is >= 1
                SaveFileLink()

                Select Case SaveName
                    Case Nothing, ""
                    Case Else
                        PELRInBtn04.Enabled = False
                        PELRInBtn03.Enabled = False
                        LoadingPt.Enabled = True
                        LoadingPt.Visible = True
                        OnClickTheWorker2()
                End Select

        End Select

    End Sub

    Private Sub PELRCM01_Opening(sender As Object, e As CancelEventArgs) Handles PELRCM01.Opening
        Select Case PELRGrid01.Rows.Count
            Case Is <> 0
            Case Else
                e.Cancel = True
        End Select
    End Sub

    Private Sub ELRInDp03_ValueChanged(sender As Object, e As EventArgs) Handles ELRInDp03.ValueChanged
        CountTahun(ELRInDp03.Value)
        Label45.Text = "Year of Srv. : " & YearCount.ToString
        Select Case PELRInCmb08.Text
            Case "Harian Lepas", "Harian Tetap", "Harian Lepas Produksi"
                ELRInTbx24.Text = "0"
            Case Else
                LoadMasaKerja()
        End Select

    End Sub

    Private Sub PELRInBtn04_Click(sender As Object, e As EventArgs) Handles PELRInBtn04.Click

        Select Case PELRGrid01.Rows.Count
            Case Is >= 1
                PELRInBtn04.Enabled = False
                PELRInBtn03.Enabled = False
                LoadingPt.Enabled = True
                LoadingPt.Visible = True
                ' UpdateTunjangan()
                OnClickTheWorker()
        End Select

    End Sub
    Sub UpdateTunjangan()
        ' To Update All Tunjangan for it Requirement
        Try

            For C = 0 To PELRGrid01.Rows.Count - 1

                SQL = Nothing
                SQL = SQL & "Select `rev_nik`, `rev_tglefektif`, `rev_kojabatan`, `rev_tunjjab`, `rev_tunjmkerja` From pgj_empdatrev "
                SQL = SQL & "Where rev_nik = ('" & PELRGrid01(0, C).Value.ToString & "') "
                OpenTbl(PLConn, PLTb3, SQL)
                If PLTb3.RecordCount > 0 Then

                    Dim MyKodeJab As String = PELRGrid01(17, C).Value.ToString

                    YearCount = Nothing

                    Dim CntYrServ As Date = PELRGrid01(13, C).Value

                    '   Dim DaysCount As String = DateYearDate.Subtract(BdayDate).Days.ToString

                    CountTahun(CntYrServ)

                    Dim TunMsKerVal As Int32 = 0

                    SQL = Nothing
                    SQL = SQL & "Select * From pgj_standard "
                    SQL = SQL & "Where st_aktif = ('" & "1" & "') "
                    OpenTbl(PLConn, PLTb9, SQL)
                    If PLTb9.RecordCount > 0 Then
                        Select Case YearCount
                            Case Is >= 10
                                TunMsKerVal = IIf(IsDBNull(PLTb9("st_Fgr").Value), 0, PLTb9("st_Fgr").Value)
                            Case Is >= 6
                                TunMsKerVal = IIf(IsDBNull(PLTb9("st_Egr").Value), 0, PLTb9("st_Egr").Value)
                            Case Is >= 4
                                TunMsKerVal = IIf(IsDBNull(PLTb9("st_Dgr").Value), 0, PLTb9("st_Dgr").Value)
                            Case Is >= 3
                                TunMsKerVal = IIf(IsDBNull(PLTb9("st_Cgr").Value), 0, PLTb9("st_Cgr").Value)
                            Case Is >= 2
                                TunMsKerVal = IIf(IsDBNull(PLTb9("st_Bgr").Value), 0, PLTb9("st_Bgr").Value)
                            Case Is >= 1
                                TunMsKerVal = IIf(IsDBNull(PLTb9("st_Agr").Value), 0, PLTb9("st_Agr").Value)
                        End Select
                    End If

                    Dim TunJabVal As Int32 = 0

                    SQL = Nothing
                    SQL = SQL & "Select * From pgj_jablist "
                    SQL = SQL & "Where pgj_jabkode = ('" & MyKodeJab & "') "
                    OpenTbl(PLConn, PLTb4, SQL)
                    If PLTb4.RecordCount > 0 Then
                        TunJabVal = IIf(IsDBNull(PLTb4("pgj_tunjab").Value), 0, PLTb4("pgj_tunjab").Value.ToString)
                    End If

                    PLTb3("rev_tunjjab").Value = TunJabVal

                    Select Case PELRGrid01(19, C).Value.ToString
                        Case "Harian Lepas", "Harian Tetap", "Harian Lepas Produksi"
                            PLTb3("rev_tunjmkerja").Value = "0"
                        Case Else
                            PLTb3("rev_tunjmkerja").Value = TunMsKerVal
                    End Select

                    PLTb3.Update()

                End If
            Next

            MessageBox.Show("Done")

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

#Region "BGW Mode"
    Private BGWorkMode() As BackgroundWorker
    Private i = 0
    Sub OnClickTheWorker()
        i += 1
        ReDim BGWorkMode(i)
        BGWorkMode(i) = New BackgroundWorker
        BGWorkMode(i).WorkerReportsProgress = True
        BGWorkMode(i).WorkerSupportsCancellation = True
        AddHandler BGWorkMode(i).DoWork, AddressOf WorkerDoWork
        AddHandler BGWorkMode(i).ProgressChanged, AddressOf WorkerProgressChanged
        AddHandler BGWorkMode(i).RunWorkerCompleted, AddressOf WorkerCompleted
        BGWorkMode(i).RunWorkerAsync()
    End Sub
    Private Sub WorkerDoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        UpdateTunjangan()
    End Sub
    Private Sub WorkerProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)

    End Sub
    Private Sub WorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        LoadingPt.Enabled = False
        LoadingPt.Visible = False
        PELRInBtn04.Enabled = True
        PELRInBtn03.Enabled = True
    End Sub

    Sub OnClickTheWorker2()
        i += 1
        ReDim BGWorkMode(i)
        BGWorkMode(i) = New BackgroundWorker
        BGWorkMode(i).WorkerReportsProgress = True
        BGWorkMode(i).WorkerSupportsCancellation = True
        AddHandler BGWorkMode(i).DoWork, AddressOf WorkerDoWork2
        AddHandler BGWorkMode(i).ProgressChanged, AddressOf WorkerProgressChanged2
        AddHandler BGWorkMode(i).RunWorkerCompleted, AddressOf WorkerCompleted2
        BGWorkMode(i).RunWorkerAsync()
    End Sub
    Private Sub WorkerDoWork2(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        ExportExcel()
    End Sub
    Private Sub WorkerProgressChanged2(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)

    End Sub
    Private Sub WorkerCompleted2(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        LoadingPt.Enabled = False
        LoadingPt.Visible = False
        PELRInBtn04.Enabled = True
        PELRInBtn03.Enabled = True
    End Sub

#End Region

    Private Sub PELRInBtn02_Click(sender As Object, e As EventArgs) Handles PELRInBtn02.Click
        CleanData()
    End Sub


    Private Sub ELRInTbx17_TextChanged(sender As Object, e As EventArgs) Handles ELRInTbx17.TextChanged

    End Sub

    Private Sub ELRInTbx24_TextChanged(sender As Object, e As EventArgs) Handles ELRInTbx24.TextChanged

    End Sub

    Private Sub ELRInTbx21_TextChanged(sender As Object, e As EventArgs) Handles ELRInTbx21.TextChanged

    End Sub

    Private Sub PELRInTbx02_TextChanged(sender As Object, e As EventArgs) Handles PELRInTbx02.TextChanged

    End Sub
End Class