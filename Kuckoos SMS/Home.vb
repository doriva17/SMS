Imports System.Windows.Forms

Public Class Home

    Private Sub Home_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub Home_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        
    End Sub
    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now
        Timer1.Start()

    End Sub

    Private Sub StudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentToolStripMenuItem.Click

    End Sub

    Private Sub MenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As Integer = MsgBox("Do You Really Want To Logout The Application.?", MsgBoxStyle.YesNo)
        If result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then
            Timer1.Stop()
            Login.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub AddStudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddStudentToolStripMenuItem.Click
        StudRegister.MdiParent = Me
        StudRegister.Show()
    End Sub

    Private Sub AddStaffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddStaffToolStripMenuItem.Click
        Add_Staff.MdiParent = Me
        Add_Staff.Show()
    End Sub

    Private Sub AddExamToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddExamToolStripMenuItem.Click
        Add_Exam.MdiParent = Me
        Add_Exam.Show()
    End Sub

    Private Sub AddFeesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddFeesToolStripMenuItem.Click
        Fees_Add.MdiParent = Me
        Fees_Add.Show()
    End Sub

    Private Sub CollectFeesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CollectFeesToolStripMenuItem.Click
        Fees_Collect.MdiParent = Me
        Fees_Collect.Show()
    End Sub

    Private Sub AddSubjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddSubjectToolStripMenuItem.Click
        Add_Subject.MdiParent = Me
        Add_Subject.Show()
    End Sub

    Private Sub AddClassToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddClassToolStripMenuItem.Click
        Add_Class.MdiParent = Me
        Add_Class.Show()
    End Sub

    Private Sub AddUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddUserToolStripMenuItem.Click
        Add_User.MdiParent = Me
        Add_User.Show()
    End Sub

    Private Sub UpdateUserInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateUserInfoToolStripMenuItem.Click
        Update_User.MdiParent = Me
        Update_User.Show()
    End Sub

    Private Sub UserDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserDetailsToolStripMenuItem.Click
        Details_User.MdiParent = Me
        Details_User.Show()
    End Sub

    Private Sub DeleteUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteUserToolStripMenuItem.Click
        Delete_User.MdiParent = Me
        Delete_User.Show()
    End Sub

    Private Sub FeesDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FeesDetailsToolStripMenuItem.Click
        Fees_Details.MdiParent = Me
        Fees_Details.Show()
    End Sub

    Private Sub StudentDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentDetailsToolStripMenuItem.Click
        Stud_Details.MdiParent = Me
        Stud_Details.Show()
    End Sub

    Private Sub ClassDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClassDetailsToolStripMenuItem.Click
        Class_Details.MdiParent = Me
        Class_Details.Show()
    End Sub

    Private Sub SubjectDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubjectDetailsToolStripMenuItem.Click
        Subject_Details.MdiParent = Me
        Subject_Details.Show()
    End Sub

    Private Sub FeesCollectionDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FeesCollectionDetailsToolStripMenuItem.Click
        Fees_Collection_Details.MdiParent = Me
        Fees_Collection_Details.Show()
    End Sub

    Private Sub UpdateStudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateStudentToolStripMenuItem.Click
        Stud_Update.MdiParent = Me
        Stud_Update.Show()
    End Sub

    Private Sub StaffDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StaffDetailsToolStripMenuItem.Click
        Staff_Details.MdiParent = Me
        Staff_Details.Show()
    End Sub

    Private Sub StaffPaymentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StaffPaymentToolStripMenuItem.Click
        Staff_Payment.MdiParent = Me
        Staff_Payment.Show()
    End Sub

    Private Sub NewTransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewTransactionToolStripMenuItem.Click
        Add_Transaction.MdiParent = Me
        Add_Transaction.Show()
    End Sub

    Private Sub AllTransactionDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllTransactionDetailToolStripMenuItem.Click
        All_Transaction_Details.MdiParent = Me
        All_Transaction_Details.Show()
    End Sub

    Private Sub AccountSummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountSummaryToolStripMenuItem.Click
        Account.MdiParent = Me
        Account.Show()
    End Sub

    Private Sub TransactionDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransactionDetailsToolStripMenuItem.Click
        Transaction_Detail.MdiParent = Me
        Transaction_Detail.Show()
    End Sub

    Private Sub AllPaymentDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllPaymentDetailsToolStripMenuItem.Click
        All_Payment_Details.MdiParent = Me
        All_Payment_Details.Show()
    End Sub

    Private Sub StaffPaymentDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StaffPaymentDetailToolStripMenuItem.Click
        Staff_Payment_Detail.MdiParent = Me
        Staff_Payment_Detail.Show()
    End Sub


    Private Sub AddExamMarksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddExamMarksToolStripMenuItem.Click
        Add_Exam_Marks.MdiParent = Me
        Add_Exam_Marks.Show()
    End Sub

    Private Sub ExamDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExamDetailsToolStripMenuItem.Click
        Exam_Detail.MdiParent = Me
        Exam_Detail.Show()
    End Sub

    Private Sub AllExamDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllExamDetailsToolStripMenuItem.Click
        All_Exam_Details.MdiParent = Me
        All_Exam_Details.Show()
    End Sub

    

    Private Sub PaymentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaymentsToolStripMenuItem.Click

    End Sub

    Private Sub StudentMarksDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentMarksDetailsToolStripMenuItem.Click
        Student_Mark_Detail.MdiParent = Me
        Student_Mark_Detail.Show()
    End Sub

    
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now
    End Sub
End Class
