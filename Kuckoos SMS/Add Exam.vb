Imports System.Data.OleDb
Public Class Add_Exam

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Add_Exam_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub

    Private Sub Add_Exam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds.Clear()

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Module1.conn()
        cn.Open()

        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now
        DateTimePicker3.Value = DateTime.Now
        'cn.Open()
        str = "select * from Exam"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Exam")

        Dim LastNo As Integer
        LastNo = ds.Tables("Exam").Rows.Count + 1
        If LastNo >= 0 Then
            TextBox1.Text = "EXM" & LastNo
        Else
            TextBox1.Text = "EXM" & 0
        End If
        'cn.Close()


        Dim ctr As Integer
        'cn.Open()
        str = "select * from Class"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Class")
        ctr = ds.Tables("Class").Rows.Count - 1
        For i = 0 To ctr
            ComboBox1.Items.Add(ds.Tables("Class").Rows(i)(1).ToString)
        Next
        'cn.Close()

        CheckedListBox1.Items.Clear()
        'cn.Open()
        str = "select * from Subject"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Subject")
        ctr = ds.Tables("Subject").Rows.Count - 1
        For i = 0 To ctr
            CheckedListBox1.Items.Add(ds.Tables("Subject").Rows(i)(1).ToString)
        Next
        'cn.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'cn.Open()
        Dim er As Integer = 0
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Or CheckedListBox1.CheckedItems.Count = 0 Then
            er = 1
            MsgBox("Please Fill All The Detail's.")
        End If

        Dim x As String
        Dim x1 As Integer
        Dim s As String = ""
        'Determine if there are any items checked.  
        If CheckedListBox1.CheckedItems.Count <> 0 Then
            ' If so, loop through all checked items and print results.  

            For x1 = 0 To CheckedListBox1.CheckedItems.Count - 1
                s = s & CheckedListBox1.CheckedItems(x1).ToString & ", "
            Next x1
            'MessageBox.Show(s)
        End If
        ds.Clear()
        str = "select * from ExamSubject"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "ExamSubject")
        Dim LastNo1 As Integer
        LastNo1 = ds.Tables("ExamSubject").Rows.Count + 1
        If LastNo1 >= 0 Then
            x = "ESID" & LastNo1
        Else
            x = "ESID" & 0
        End If


        'insert
        If er = 0 Then
            Try
                'If CheckedListBox1.CheckedItems.Count <> 0 Then
                For i = 0 To CheckedListBox1.CheckedItems.Count - 1

                    If CheckedListBox1.GetItemCheckState(i) = CheckState.Checked Then
                        If LastNo1 >= 0 Then
                            x = "ESID" & LastNo1
                        Else
                            x = "ESID" & 0
                        End If
                        cmd.Connection = cn
                        cmd.CommandText = "insert into ExamSubject(ESID,EID,Subject) values('" & x & "','" & TextBox1.Text & "','" & CheckedListBox1.CheckedItems(i).ToString & "')"
                        cmd.ExecuteNonQuery()
                        LastNo1 = LastNo1 + 1
                    End If
                Next
                'End If

                cmd.Connection = cn
                cmd.CommandText = "insert into Exam(EID,EName,DateAdded,Class,StartDate,EndDate,Duration,Subjects) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & DateTimePicker1.Text & "','" & ComboBox1.Text & "',  '" & DateTimePicker2.Text & "','" & DateTimePicker3.Text & "','" & TextBox3.Text & "', '" & s & "')"
                cmd.ExecuteNonQuery()
                'MsgBox("New Class Added.")
                Dim result As Integer = MessageBox.Show("New Exam Added. Want To Add Another One.", "Added", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Me.Close()
                ElseIf result = DialogResult.Yes Then
                    ds.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    ComboBox1.Items.Clear()
                    DateTimePicker1.Value = DateTime.Now
                    DateTimePicker2.Value = DateTime.Now
                    DateTimePicker3.Value = DateTime.Now
                    CheckedListBox1.Items.Clear()

                    str = "select * from Exam"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Exam")
                    Dim LastNo As Integer
                    LastNo = ds.Tables("Exam").Rows.Count + 1
                    If LastNo >= 0 Then
                        TextBox1.Text = "EXM" & LastNo
                    Else
                        TextBox1.Text = "EXM" & 0
                    End If

                    Dim ctr As Integer
                    str = "select * from Class"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Class")
                    ctr = ds.Tables("Class").Rows.Count - 1
                    For i = 0 To ctr
                        ComboBox1.Items.Add(ds.Tables("Class").Rows(i)(0).ToString & " - " & ds.Tables("Class").Rows(i)(1).ToString)
                    Next

                    str = "select * from Subject"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Subject")
                    ctr = ds.Tables("Subject").Rows.Count - 1
                    For i = 0 To ctr
                        CheckedListBox1.Items.Add(ds.Tables("Subject").Rows(i)(1).ToString)
                    Next

                End If
            Catch ex As Exception
                MsgBox(" Exam Not Added.")
                TextBox2.Clear()
                TextBox3.Clear()
                ComboBox1.ResetText()
                CheckedListBox1.Refresh()
            End Try
            'insert Closed
        End If
        'cn.Close()
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim ctr As Integer
        'cn.Open()
        str = "select * from Class where CName = '" & ComboBox1.Text & "'"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Class")
        ctr = ds.Tables("Class").Rows.Count - 1
        For i = 0 To ctr
            TextBox4.Text = ds.Tables("Class").Rows(i)(0).ToString
        Next
        'cn.Close()
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox1.SelectedIndexChanged

    End Sub
End Class