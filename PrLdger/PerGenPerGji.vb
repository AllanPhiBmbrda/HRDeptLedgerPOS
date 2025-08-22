Imports System.ComponentModel

Public Class PerGenPerGji

    Private Sub RABtn01_Click(sender As Object, e As EventArgs) Handles IKBtn01.Click
        LoadDateExist()

        Select Case ApplyGajiGen
            Case True

                Try

                    IKProg01.Maximum = Nothing
                    IKProg01.Value = 0
                    IKBtn01.Enabled = False
                    OnClickTheWorker()
                    ' LoadDataK()
                    'SavePerincianGaji()
                    GetInt = 0

                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try

            Case False

                MessageBox.Show("Please Setup your Periode and Periode Range in [Date Setup] Module")
        End Select

        'LoadDataK()
        'SavePerincianGaji()
        'GetInt = 0

    End Sub
    Private Sub PerGenPerGji_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        LoadDB2()
        CheckPeriode()
    End Sub

    Sub CheckPeriode()
        Select Case IKCmb01.Text
            Case "Periode I"
                IKChk04.Checked = False
                IKChk05.Checked = False

            Case "Periode II"
                IKChk04.Checked = True
                IKChk05.Checked = True

        End Select
    End Sub

    Dim GetInt As Int32 = 0
    Dim NamaGot(100000) As String
    Dim EstGot(100000) As String
    Dim DeptGot(100000) As String
    Dim JabGot(100000) As String
    Dim KoDeptGot(100000) As String
    Dim KoJabGot(100000) As String

    Dim GJPokGot(100000) As Int64

    Dim TjKerjM(100000) As Int64
    Dim TjKeraM(100000) As Int64
    Dim TjJab(100000) As Int64

    Dim BPJSKerM(100000) As Int64
    Dim BPJSKesM(100000) As Int64

    Dim PotAtmM(100000) As Int64

    Dim ApplyGajiGen As Boolean = False
    Sub LoadDateExist()
        ApplyGajiGen = False
        SQL = Nothing
        SQL = SQL & "Select `psu_periode`, `psu_perioderng`  From pgj_periodesu "
        SQL = SQL & "Where psu_periode = ('" & IKCmb01.Text & "') "
        SQL = SQL & "and psu_perioderng = ('" & IKDp01.Value.ToString("MMM yyyy", CustomtoUS) & "') "
        OpenTbl(PLConn, PLTb7, SQL)
        If PLTb7.RecordCount > 0 Then
            ApplyGajiGen = True
        Else
            ApplyGajiGen = False
        End If
    End Sub
    Sub LoadDataK()
        GetInt = 0
        SQL = Nothing
        ' SQL = SQL & "Select `emp_nama`, `emp_noest`, `emp_dept`, `emp_jab`, `emp_aktif`, `emp_gjpokok`, `emp_tjmasker`, `emp_tjkera`, `emp_tjjabatan`, `emp_bpjstkerj`, `emp_bpjskeseh`, `emp_potatm` From pgj_empdatrev "
        SQL = SQL & "Select `rev_nama`, `rev_nik`, `rev_kobagian`, `rev_nabagian`, `rev_kojabatan`, `rev_jabatan`, `rev_gajpok`, `rev_tunjkera`, `rev_tunjjab`, `rev_bpjstkerja`, `rev_tunjmkerja`, `rev_bpjskese` From pgj_empdatrev "
        SQL = SQL & "Where rev_tglkeluar is null "
        OpenTbl(PLConn, PLTb1, SQL)
        If PLTb1.RecordCount <> 0 Then
            PLTb1.MoveFirst()
            Do While Not PLTb1.EOF

                NamaGot(GetInt) = IIf(IsDBNull(PLTb1("rev_nama").Value), "", PLTb1("rev_nama").Value)
                EstGot(GetInt) = IIf(IsDBNull(PLTb1("rev_nik").Value), "", PLTb1("rev_nik").Value)
                DeptGot(GetInt) = IIf(IsDBNull(PLTb1("rev_nabagian").Value), "", PLTb1("rev_nabagian").Value)
                JabGot(GetInt) = IIf(IsDBNull(PLTb1("rev_jabatan").Value), "", PLTb1("rev_jabatan").Value)

                KoDeptGot(GetInt) = IIf(IsDBNull(PLTb1("rev_kobagian").Value), "", PLTb1("rev_kobagian").Value)
                KoJabGot(GetInt) = IIf(IsDBNull(PLTb1("rev_kojabatan").Value), "", PLTb1("rev_kojabatan").Value)

                GJPokGot(GetInt) = IIf(IsDBNull(PLTb1("rev_gajpok").Value), 0, Val(PLTb1("rev_gajpok").Value))
                TjKerjM(GetInt) = IIf(IsDBNull(PLTb1("rev_tunjmkerja").Value), 0, Val(PLTb1("rev_tunjmkerja").Value))
                TjKeraM(GetInt) = IIf(IsDBNull(PLTb1("rev_tunjkera").Value), 0, Val(PLTb1("rev_tunjkera").Value))
                TjJab(GetInt) = IIf(IsDBNull(PLTb1("rev_tunjjab").Value), 0, Val(PLTb1("rev_tunjjab").Value))

                Select Case IKCmb01.Text
                    Case "Periode II"
                        BPJSKerM(GetInt) = IIf(IsDBNull(PLTb1("rev_bpjstkerja").Value), 0, Val(PLTb1("rev_bpjstkerja").Value))
                        BPJSKesM(GetInt) = IIf(IsDBNull(PLTb1("rev_bpjskese").Value), 0, Val(PLTb1("rev_bpjskese").Value))
                End Select

                'PotAtmM(GetInt) = IIf(IsDBNull(PLTb1("emp_potatm").Value), 0, PLTb1("emp_potatm").Value)

                GetInt += 1
                PLTb1.MoveNext()
            Loop
        End If
    End Sub

    Sub LoadTunjalain()
        GetInt = 0
        SQL = Nothing
        SQL = SQL & "Select `emp_TunjLain`, `emp_data`, `emp_connect`, `emp_nama`, `emp_noest`, `emp_dept`, `emp_jab`, `emp_aktif`, `emp_gjpokok`, `emp_tjmasker`, `emp_tjkera`, `emp_tjjabatan`, `emp_bpjstkerj`, `emp_bpjskeseh`, `emp_potatm` From pgj_empdat "
        SQL = SQL & "Where emp_aktif = ('" & "Yes" & "') "
        OpenTbl(PLConn, PLTb1, SQL)
        If PLTb1.RecordCount <> 0 Then
            PLTb1.MoveFirst()
            Do While Not PLTb1.EOF
                NamaGot(GetInt) = IIf(IsDBNull(PLTb1("emp_nama").Value), "", PLTb1("emp_nama").Value)
                EstGot(GetInt) = IIf(IsDBNull(PLTb1("emp_noest").Value), "", PLTb1("emp_noest").Value)
                DeptGot(GetInt) = IIf(IsDBNull(PLTb1("emp_dept").Value), "", PLTb1("emp_dept").Value)
                JabGot(GetInt) = IIf(IsDBNull(PLTb1("emp_jab").Value), "", PLTb1("emp_jab").Value)
                GJPokGot(GetInt) = IIf(IsDBNull(PLTb1("emp_gjpokok").Value), 0, PLTb1("emp_gjpokok").Value)

                TjKerjM(GetInt) = IIf(IsDBNull(PLTb1("emp_tjmasker").Value), 0, PLTb1("emp_tjmasker").Value)
                TjKeraM(GetInt) = IIf(IsDBNull(PLTb1("emp_tjkera").Value), 0, PLTb1("emp_tjkera").Value)
                TjJab(GetInt) = IIf(IsDBNull(PLTb1("emp_tjjabatan").Value), 0, PLTb1("emp_tjjabatan").Value)

                BPJSKerM(GetInt) = IIf(IsDBNull(PLTb1("emp_bpjstkerj").Value), 0, PLTb1("emp_bpjstkerj").Value)
                BPJSKesM(GetInt) = IIf(IsDBNull(PLTb1("emp_bpjskeseh").Value), 0, PLTb1("emp_bpjskeseh").Value)

                PotAtmM(GetInt) = IIf(PLTb1("emp_potatm").Value = Nothing, 0, PLTb1("emp_potatm").Value)

                GetInt += 1
                PLTb1.MoveNext()
            Loop
        End If
    End Sub

    Sub SavePerincianGaji()

        Dim DaSUMonth As String = IKDp01.Value.ToString("MMM", CustomtoUS)
        Dim DaSuYr As String = IKDp01.Value.ToString("yyyy", CustomtoUS)

        CheckDateIndoEnglish(DaSUMonth)

        IKProg01.Maximum = GetInt

        For i = 0 To GetInt
            SQL = Nothing
            SQL = SQL & "Select `pgj_ttname`, `pgj_ttest`, `pgj_bagian`, `pgj_jaba`, `pgj_gjpok`, `pgj_prrng`, `pgj_priode`, `pgj_bpjstkerj`, `pgj_bpjskese`, `pgj_tjjab`, `pgj_tjkera`, `pgj_tunmskerj`, `pgj_potatm`, `pgj_kojab`, `pgj_kobag` From pgj_trans_tot "
            SQL = SQL & "Where pgj_ttest = ('" & EstGot(i) & "') "
            SQL = SQL & "and pgj_prrng = ('" & PublicMonth & " " & DaSuYr & "') "
            SQL = SQL & "and pgj_priode = ('" & IKCmb01.Text & "') "
            OpenTbl(PLConn, PLTb3, SQL)
            If Not PLTb3.RecordCount <> 0 Then
                PLTb3.AddNew()
            End If

            PLTb3("pgj_prrng").Value = PublicMonth & " " & DaSuYr
            PLTb3("pgj_priode").Value = IKCmb01.Text
            PLTb3("pgj_ttname").Value = NamaGot(i)
            PLTb3("pgj_ttest").Value = EstGot(i)

            PLTb3("pgj_bagian").Value = DeptGot(i)
            PLTb3("pgj_jaba").Value = JabGot(i)

            PLTb3("pgj_kobag").Value = KoDeptGot(i)
            PLTb3("pgj_kojab").Value = KoJabGot(i)

            PLTb3("pgj_gjpok").Value = (GJPokGot(i) / 2).ToString("N0").ToString.Replace(",", Nothing)

            Select Case IKChk01.Checked
                Case True
                    PLTb3("pgj_tunmskerj").Value = TjKerjM(i)
            End Select

            Select Case IKChk02.Checked
                Case True
                    PLTb3("pgj_tjkera").Value = TjKeraM(i)
            End Select

            Select Case IKChk03.Checked
                Case True
                    PLTb3("pgj_tjjab").Value = TjJab(i)
            End Select

            Select Case IKChk04.Checked
                Case True
                    PLTb3("pgj_bpjstkerj").Value = BPJSKerM(i)
            End Select

            Select Case IKChk05.Checked
                Case True
                    PLTb3("pgj_bpjskese").Value = BPJSKesM(i)
            End Select

            'Select Case IKChk06.Checked
            '    Case True
            '        PLTb3("pgj_potatm").Value = PotAtmM(i)
            'End Select

            Select Case EstGot(i)
                Case Nothing, ""
                    Exit For
            End Select

            PLTb3.Update()
            IKProg01.Invoke(DirectCast(Sub() IKProg01.Value += 1, MethodInvoker))
        Next

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
        LoadDataK()
        SavePerincianGaji()
    End Sub
    Private Sub WorkerProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)

    End Sub
    Private Sub WorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        If e.Error IsNot Nothing Then
            'IKBtn01.Enabled = True
            ' MessageBox.Show(e.Error.ToString, Me.Text)
        Else
            IKBtn01.Enabled = True
            MessageBox.Show("Upload Done", Me.Text)
        End If
    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub IKCmb01_SelectedIndexChanged(sender As Object, e As EventArgs) Handles IKCmb01.SelectedIndexChanged
        CheckPeriode()
    End Sub

End Class