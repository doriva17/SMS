Public Class Loading

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Label1.Text = ProgressBar1.Value.ToString() + " %" + " "
        'If ProgressBar1.Value >= 100 Then
        '    Timer1.Enabled = False
        '    Login.Show()
        '    Me.Hide()
        'End If
        If ProgressBar1.Value < 10 And ProgressBar1.Value > 0 Then
            Label2.Text = "Loding Database."
        ElseIf ProgressBar1.Value < 15 And ProgressBar1.Value > 10 Then
            Label2.Text = "Loding Database.."
        ElseIf ProgressBar1.Value < 20 And ProgressBar1.Value > 15 Then
            Label2.Text = "Loding Database..."
        ElseIf ProgressBar1.Value < 30 And ProgressBar1.Value > 20 Then
            Label2.ForeColor = Color.Blue
            Label2.Text = "Loding User Interface."
        ElseIf ProgressBar1.Value < 40 And ProgressBar1.Value > 30 Then
            Label2.ForeColor = Color.Brown
            Label2.Text = "Loding User Security."
        ElseIf ProgressBar1.Value < 50 And ProgressBar1.Value > 40 Then
            Label2.ForeColor = Color.Orange
            Label2.Text = "Loding Student Module."
        ElseIf ProgressBar1.Value < 60 And ProgressBar1.Value > 50 Then
            Label2.ForeColor = Color.Orange
            Label2.Text = "Loding Staff Module."
        ElseIf ProgressBar1.Value < 70 And ProgressBar1.Value > 60 Then
            Label2.ForeColor = Color.Orange
            Label2.Text = "Loding Acounts and Fees Module."
        ElseIf ProgressBar1.Value < 80 And ProgressBar1.Value > 70 Then
            Label2.ForeColor = Color.Orange
            Label2.Text = "Loding Exam Module."
        ElseIf ProgressBar1.Value < 90 And ProgressBar1.Value > 80 Then
            Label2.ForeColor = Color.Purple
            Label2.Text = "Preparing Login Screen."
        ElseIf ProgressBar1.Value < 100 And ProgressBar1.Value > 90 Then
            Label2.ForeColor = Color.Red
            Label2.Text = "All-most done."
        End If
        ProgressBar1.BackColor = Color.White
        If ProgressBar1.Value = 100% Then
            Timer1.Enabled = False
            Login.Show()
            Me.Hide()
        Else
            ProgressBar1.Value = ProgressBar1.Value + 1
        End If

    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub Loading_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class