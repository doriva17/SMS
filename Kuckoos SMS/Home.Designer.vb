<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Home
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.StudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddStudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateStudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClassToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddClassToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClassDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StaffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddStaffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StaffDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExamToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddExamToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddExamMarksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExamDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllExamDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentMarksDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FeesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddFeesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FeesDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CollectFeesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FeesCollectionDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddSubjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubjectDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewTransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllTransactionDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccountSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateUserInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StaffPaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllPaymentDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StaffPaymentDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.AutoSize = False
        Me.MenuStrip.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StudentToolStripMenuItem, Me.ClassToolStripMenuItem, Me.StaffToolStripMenuItem, Me.ExamToolStripMenuItem, Me.FeesToolStripMenuItem, Me.SubjectToolStripMenuItem, Me.AccountsToolStripMenuItem, Me.UserToolStripMenuItem, Me.PaymentsToolStripMenuItem})
        Me.MenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip.Size = New System.Drawing.Size(737, 30)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'StudentToolStripMenuItem
        '
        Me.StudentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddStudentToolStripMenuItem, Me.StudentDetailsToolStripMenuItem, Me.UpdateStudentToolStripMenuItem})
        Me.StudentToolStripMenuItem.Name = "StudentToolStripMenuItem"
        Me.StudentToolStripMenuItem.Size = New System.Drawing.Size(63, 26)
        Me.StudentToolStripMenuItem.Text = "&Student"
        '
        'AddStudentToolStripMenuItem
        '
        Me.AddStudentToolStripMenuItem.Name = "AddStudentToolStripMenuItem"
        Me.AddStudentToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.AddStudentToolStripMenuItem.Text = "Add Student"
        '
        'StudentDetailsToolStripMenuItem
        '
        Me.StudentDetailsToolStripMenuItem.Name = "StudentDetailsToolStripMenuItem"
        Me.StudentDetailsToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.StudentDetailsToolStripMenuItem.Text = "Student Details"
        '
        'UpdateStudentToolStripMenuItem
        '
        Me.UpdateStudentToolStripMenuItem.Name = "UpdateStudentToolStripMenuItem"
        Me.UpdateStudentToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.UpdateStudentToolStripMenuItem.Text = "Update Student"
        '
        'ClassToolStripMenuItem
        '
        Me.ClassToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddClassToolStripMenuItem, Me.ClassDetailsToolStripMenuItem})
        Me.ClassToolStripMenuItem.Name = "ClassToolStripMenuItem"
        Me.ClassToolStripMenuItem.Size = New System.Drawing.Size(51, 26)
        Me.ClassToolStripMenuItem.Text = "&Class"
        '
        'AddClassToolStripMenuItem
        '
        Me.AddClassToolStripMenuItem.Name = "AddClassToolStripMenuItem"
        Me.AddClassToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.AddClassToolStripMenuItem.Text = "Add Class"
        '
        'ClassDetailsToolStripMenuItem
        '
        Me.ClassDetailsToolStripMenuItem.Name = "ClassDetailsToolStripMenuItem"
        Me.ClassDetailsToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.ClassDetailsToolStripMenuItem.Text = "Class Details"
        '
        'StaffToolStripMenuItem
        '
        Me.StaffToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddStaffToolStripMenuItem, Me.StaffDetailsToolStripMenuItem})
        Me.StaffToolStripMenuItem.Name = "StaffToolStripMenuItem"
        Me.StaffToolStripMenuItem.Size = New System.Drawing.Size(46, 26)
        Me.StaffToolStripMenuItem.Text = "&Staff"
        '
        'AddStaffToolStripMenuItem
        '
        Me.AddStaffToolStripMenuItem.Name = "AddStaffToolStripMenuItem"
        Me.AddStaffToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.AddStaffToolStripMenuItem.Text = "Add Staff"
        '
        'StaffDetailsToolStripMenuItem
        '
        Me.StaffDetailsToolStripMenuItem.Name = "StaffDetailsToolStripMenuItem"
        Me.StaffDetailsToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.StaffDetailsToolStripMenuItem.Text = "Staff Details"
        '
        'ExamToolStripMenuItem
        '
        Me.ExamToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddExamToolStripMenuItem, Me.AddExamMarksToolStripMenuItem, Me.ExamDetailsToolStripMenuItem, Me.AllExamDetailsToolStripMenuItem, Me.StudentMarksDetailsToolStripMenuItem})
        Me.ExamToolStripMenuItem.Name = "ExamToolStripMenuItem"
        Me.ExamToolStripMenuItem.Size = New System.Drawing.Size(51, 26)
        Me.ExamToolStripMenuItem.Text = "&Exam"
        '
        'AddExamToolStripMenuItem
        '
        Me.AddExamToolStripMenuItem.Name = "AddExamToolStripMenuItem"
        Me.AddExamToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AddExamToolStripMenuItem.Text = "Add Exam"
        '
        'AddExamMarksToolStripMenuItem
        '
        Me.AddExamMarksToolStripMenuItem.Name = "AddExamMarksToolStripMenuItem"
        Me.AddExamMarksToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AddExamMarksToolStripMenuItem.Text = "Add Exam Marks"
        '
        'ExamDetailsToolStripMenuItem
        '
        Me.ExamDetailsToolStripMenuItem.Name = "ExamDetailsToolStripMenuItem"
        Me.ExamDetailsToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ExamDetailsToolStripMenuItem.Text = "Exam Details"
        '
        'AllExamDetailsToolStripMenuItem
        '
        Me.AllExamDetailsToolStripMenuItem.Name = "AllExamDetailsToolStripMenuItem"
        Me.AllExamDetailsToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AllExamDetailsToolStripMenuItem.Text = "All Exam Details"
        '
        'StudentMarksDetailsToolStripMenuItem
        '
        Me.StudentMarksDetailsToolStripMenuItem.Name = "StudentMarksDetailsToolStripMenuItem"
        Me.StudentMarksDetailsToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.StudentMarksDetailsToolStripMenuItem.Text = "Student Mark Detail"
        '
        'FeesToolStripMenuItem
        '
        Me.FeesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddFeesToolStripMenuItem, Me.FeesDetailsToolStripMenuItem, Me.CollectFeesToolStripMenuItem, Me.FeesCollectionDetailsToolStripMenuItem})
        Me.FeesToolStripMenuItem.Name = "FeesToolStripMenuItem"
        Me.FeesToolStripMenuItem.Size = New System.Drawing.Size(46, 26)
        Me.FeesToolStripMenuItem.Text = "&Fees"
        '
        'AddFeesToolStripMenuItem
        '
        Me.AddFeesToolStripMenuItem.Name = "AddFeesToolStripMenuItem"
        Me.AddFeesToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.AddFeesToolStripMenuItem.Text = "Add Fees"
        '
        'FeesDetailsToolStripMenuItem
        '
        Me.FeesDetailsToolStripMenuItem.Name = "FeesDetailsToolStripMenuItem"
        Me.FeesDetailsToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.FeesDetailsToolStripMenuItem.Text = "Fees Details"
        '
        'CollectFeesToolStripMenuItem
        '
        Me.CollectFeesToolStripMenuItem.Name = "CollectFeesToolStripMenuItem"
        Me.CollectFeesToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.CollectFeesToolStripMenuItem.Text = "Collect Fees"
        '
        'FeesCollectionDetailsToolStripMenuItem
        '
        Me.FeesCollectionDetailsToolStripMenuItem.Name = "FeesCollectionDetailsToolStripMenuItem"
        Me.FeesCollectionDetailsToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.FeesCollectionDetailsToolStripMenuItem.Text = "Fees Collection Details"
        '
        'SubjectToolStripMenuItem
        '
        Me.SubjectToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddSubjectToolStripMenuItem, Me.SubjectDetailsToolStripMenuItem})
        Me.SubjectToolStripMenuItem.Name = "SubjectToolStripMenuItem"
        Me.SubjectToolStripMenuItem.Size = New System.Drawing.Size(62, 26)
        Me.SubjectToolStripMenuItem.Text = "&Subject"
        '
        'AddSubjectToolStripMenuItem
        '
        Me.AddSubjectToolStripMenuItem.Name = "AddSubjectToolStripMenuItem"
        Me.AddSubjectToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AddSubjectToolStripMenuItem.Text = "Add Subject"
        '
        'SubjectDetailsToolStripMenuItem
        '
        Me.SubjectDetailsToolStripMenuItem.Name = "SubjectDetailsToolStripMenuItem"
        Me.SubjectDetailsToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.SubjectDetailsToolStripMenuItem.Text = "Subject Details"
        '
        'AccountsToolStripMenuItem
        '
        Me.AccountsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewTransactionToolStripMenuItem, Me.TransactionDetailsToolStripMenuItem, Me.AllTransactionDetailToolStripMenuItem, Me.AccountSummaryToolStripMenuItem})
        Me.AccountsToolStripMenuItem.Name = "AccountsToolStripMenuItem"
        Me.AccountsToolStripMenuItem.Size = New System.Drawing.Size(73, 26)
        Me.AccountsToolStripMenuItem.Text = "&Accounts"
        '
        'NewTransactionToolStripMenuItem
        '
        Me.NewTransactionToolStripMenuItem.Name = "NewTransactionToolStripMenuItem"
        Me.NewTransactionToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.NewTransactionToolStripMenuItem.Text = "New Transaction"
        '
        'TransactionDetailsToolStripMenuItem
        '
        Me.TransactionDetailsToolStripMenuItem.Name = "TransactionDetailsToolStripMenuItem"
        Me.TransactionDetailsToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.TransactionDetailsToolStripMenuItem.Text = "Transaction Detail"
        '
        'AllTransactionDetailToolStripMenuItem
        '
        Me.AllTransactionDetailToolStripMenuItem.Name = "AllTransactionDetailToolStripMenuItem"
        Me.AllTransactionDetailToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.AllTransactionDetailToolStripMenuItem.Text = "All Transaction Detail"
        '
        'AccountSummaryToolStripMenuItem
        '
        Me.AccountSummaryToolStripMenuItem.Name = "AccountSummaryToolStripMenuItem"
        Me.AccountSummaryToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.AccountSummaryToolStripMenuItem.Text = "Account Summary"
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddUserToolStripMenuItem, Me.UpdateUserInfoToolStripMenuItem, Me.UserDetailsToolStripMenuItem, Me.DeleteUserToolStripMenuItem})
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(46, 26)
        Me.UserToolStripMenuItem.Text = "&User"
        '
        'AddUserToolStripMenuItem
        '
        Me.AddUserToolStripMenuItem.Name = "AddUserToolStripMenuItem"
        Me.AddUserToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.AddUserToolStripMenuItem.Text = "Add User"
        '
        'UpdateUserInfoToolStripMenuItem
        '
        Me.UpdateUserInfoToolStripMenuItem.Name = "UpdateUserInfoToolStripMenuItem"
        Me.UpdateUserInfoToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.UpdateUserInfoToolStripMenuItem.Text = "Update User Info"
        '
        'UserDetailsToolStripMenuItem
        '
        Me.UserDetailsToolStripMenuItem.Name = "UserDetailsToolStripMenuItem"
        Me.UserDetailsToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.UserDetailsToolStripMenuItem.Text = "User Details"
        '
        'DeleteUserToolStripMenuItem
        '
        Me.DeleteUserToolStripMenuItem.Name = "DeleteUserToolStripMenuItem"
        Me.DeleteUserToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.DeleteUserToolStripMenuItem.Text = "Delete User"
        '
        'PaymentsToolStripMenuItem
        '
        Me.PaymentsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StaffPaymentToolStripMenuItem, Me.AllPaymentDetailsToolStripMenuItem, Me.StaffPaymentDetailToolStripMenuItem})
        Me.PaymentsToolStripMenuItem.Name = "PaymentsToolStripMenuItem"
        Me.PaymentsToolStripMenuItem.Size = New System.Drawing.Size(76, 26)
        Me.PaymentsToolStripMenuItem.Text = "&Payments"
        '
        'StaffPaymentToolStripMenuItem
        '
        Me.StaffPaymentToolStripMenuItem.Name = "StaffPaymentToolStripMenuItem"
        Me.StaffPaymentToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.StaffPaymentToolStripMenuItem.Text = "Staff Payment"
        '
        'AllPaymentDetailsToolStripMenuItem
        '
        Me.AllPaymentDetailsToolStripMenuItem.Name = "AllPaymentDetailsToolStripMenuItem"
        Me.AllPaymentDetailsToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.AllPaymentDetailsToolStripMenuItem.Text = "All Payment Details"
        '
        'StaffPaymentDetailToolStripMenuItem
        '
        Me.StaffPaymentDetailToolStripMenuItem.Name = "StaffPaymentDetailToolStripMenuItem"
        Me.StaffPaymentDetailToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.StaffPaymentDetailToolStripMenuItem.Text = "Staff Payment Detail"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel, Me.ToolStripProgressBar1})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 424)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(737, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(88, 16)
        Me.ToolStripProgressBar1.Step = 1
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 2
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.Red
        Me.Button1.Location = New System.Drawing.Point(580, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(157, 30)
        Me.Button1.TabIndex = 9
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.Control
        Me.DateTimePicker1.CustomFormat = "hh:MM:ss tt"
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(644, 424)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(93, 22)
        Me.DateTimePicker1.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(594, 427)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Time :"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(451, 427)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Date :"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker2.CalendarMonthBackground = System.Drawing.SystemColors.Control
        Me.DateTimePicker2.CustomFormat = "dd/MM/yyyy"
        Me.DateTimePicker2.Enabled = False
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(501, 424)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(87, 22)
        Me.DateTimePicker2.TabIndex = 14
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.Kuckoos_SMS.My.Resources.Resources.Kuckoos
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(737, 446)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "Home"
        Me.Text = "Home"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents StudentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddStudentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StudentDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateStudentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StaffToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddStaffToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StaffDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExamToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddExamToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExamDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FeesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddFeesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FeesDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CollectFeesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FeesCollectionDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SubjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddSubjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SubjectDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClassToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddClassToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClassDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddUserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateUserInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DeleteUserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccountsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewTransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransactionDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllTransactionDetailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StaffPaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllPaymentDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StaffPaymentDetailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccountSummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddExamMarksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllExamDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StudentMarksDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
