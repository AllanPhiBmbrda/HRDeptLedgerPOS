Public Class PerLogin
    Private Sub LoginTbx01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles LoginTbx01.KeyPress
        If Not InValid4.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
        If e.KeyChar.ToString = ChrW(Keys.Enter) Then
            LoginTbx02.Focus()
        End If
    End Sub
    Private Sub LoginTbx02_KeyPress(sender As Object, e As KeyPressEventArgs) Handles LoginTbx02.KeyPress
        If Not InValid4.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
        If e.KeyChar.ToString = ChrW(Keys.Enter) Then
            AccountLogin()
        End If
    End Sub
    Sub unLockMenu()
        PerLedgMain.TransactionToolStripMenuItem.Enabled = True
        PerLedgMain.ReportToolStripMenuItem.Enabled = True
        PerLedgMain.UtilityToolStripMenuItem.Enabled = True
        PerLedgMain.MasterToolStripMenuItem1.Enabled = True
    End Sub
    Sub AccountLogin()
        SQL = Nothing
        SQL = SQL & "Select * From pgj_acc "
        SQL = SQL & "Where pgj_usern = ('" & LoginTbx01.Text & "') "
        SQL = SQL & "and pgj_pass = ('" & LoginTbx02.Text.Trim & "') "
        OpenTbl(PLConn, PLTb2, SQL)
        If PLTb2.RecordCount > 0 Then
            With PurUser
                .PerRN = PLTb2("pgj_nama").Value
                .PerUID = PLTb2("pgj_usern").Value
                .PerPR = PLTb2("pgj_level").Value
            End With
            unLockMenu()
            PerLedgMain.ToolStripStatusLabel2.Text = PurUser.PerRN
            PerLedgMain.LoginToolStripMenuItem.Visible = False
            Me.Dispose()
        Else
            MessageBoxPrb("User ID and Password is not valid ", Me.Text + " : Invalid Login")
            LoginTbx02.Clear()
        End If
    End Sub

    Private Sub LoginBtn01_Click(sender As Object, e As EventArgs) Handles LoginBtn01.Click
        AccountLogin()
    End Sub
    Private Sub PerLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDB()
        Me.TopMost = True
    End Sub

End Class