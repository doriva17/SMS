Imports System.Data.OleDb
Public Class Add_Staff

    Private Sub Add_Staff_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub

    Private Sub Add_Staff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds.Clear()

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Module1.conn()
        cn.Open()

        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now

        'cn.Open()
        str = "select * from Staff"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Staff")
        Dim LastNo As Integer
        LastNo = ds.Tables("Staff").Rows.Count + 1
        If LastNo >= 0 Then
            TextBox1.Text = "STF" & LastNo
        Else
            TextBox1.Text = "STF" & 0
        End If
        'cn.Close()

        Dim ctr As Integer
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

        'cn.Open()
        str = "select * from Class"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Class")
        ctr = ds.Tables("Class").Rows.Count - 1
        For i = 0 To ctr
            CheckedListBox2.Items.Add(ds.Tables("Class").Rows(i)(1).ToString)
        Next
        'cn.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            CheckedListBox1.Visible = True
            CheckedListBox2.Visible = True
            Label11.Visible = True
            Label12.Visible = True
        ElseIf ComboBox1.SelectedIndex = 1 Then
            CheckedListBox1.Visible = False
            CheckedListBox2.Visible = False
            Label11.Visible = False
            Label12.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'cn.Open()
        Dim er As Integer = 0
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Then
            er = 1
            If TextBox5.Text < 3 Then
                MsgBox("Please Fill All The Detail's. Please Select Birth Date.")
            Else
                MsgBox("Please Fill All The Detail's.")
            End If
        End If

        Dim x, y As String
        'Subject ID
        ds.Clear()
        str = "select * from StaffSubject"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "StaffSubject")
        Dim LastNo1 As Integer
        LastNo1 = ds.Tables("StaffSubject").Rows.Count + 1
        If LastNo1 >= 0 Then
            x = "SSID" & LastNo1
        Else
            x = "SSID" & 0
        End If

        'Class ID
        ds.Clear()
        str = "select * from StaffClass"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "StaffClass")
        Dim LastNo2 As Integer
        LastNo2 = ds.Tables("StaffClass").Rows.Count + 1
        If LastNo2 >= 0 Then
            y = "SCID" & LastNo2
        Else
            y = "SCID" & 0
        End If

        'Checklistbox1
        Dim x1 As Integer
        Dim sb As String = ""
        Dim cl As String = ""

        If CheckedListBox1.CheckedItems.Count <> 0 Then
            For x1 = 0 To CheckedListBox1.CheckedItems.Count - 1
                sb = sb & CheckedListBox1.CheckedItems(x1).ToString & " ,"
            Next x1
        End If
        'Checklistbox2
        If CheckedListBox2.CheckedItems.Count <> 0 Then
            For x1 = 0 To CheckedListBox2.CheckedItems.Count - 1
                cl = cl & CheckedListBox2.CheckedItems(x1).ToString & " ,"
            Next x1
        End If

        'insert
        If er = 0 Then
            Try

                If ComboBox1.Text = "TEACHING STAFF" Then
                    'For Staff Subjects
                    For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                        If CheckedListBox1.GetItemCheckState(i) = CheckState.Checked Then
                            If LastNo1 >= 0 Then
                                x = "SSID" & LastNo1
                            Else
                                x = "SSID" & 0
                            End If
                            cmd.Connection = cn
                            cmd.CommandText = "insert into StaffSubject(SSID,SID,Subject) values('" & x & "','" & TextBox1.Text & "','" & CheckedListBox1.CheckedItems(i).ToString & "')"
                            cmd.ExecuteNonQuery()
                            LastNo1 = LastNo1 + 1
                        End If
                    Next

                    'For Staff Class
                    For i = 0 To CheckedListBox2.CheckedItems.Count - 1

                        If CheckedListBox2.GetItemCheckState(i) = CheckState.Checked Then
                            If LastNo2 >= 0 Then
                                y = "SCID" & LastNo2
                            Else
                                y = "SCID" & 0
                            End If
                            cmd.Connection = cn
                            cmd.CommandText = "insert into StaffClass(SCID,SID,Class) values('" & y & "','" & TextBox1.Text & "','" & CheckedListBox2.CheckedItems(i).ToString & "')"
                            cmd.ExecuteNonQuery()
                            LastNo2 = LastNo2 + 1
                        End If
                    Next
                End If

                cmd.Connection = cn
                cmd.CommandText = "insert into Staff(EmpID,EmpName,JoinDate,Mobile,Address,DOB,Age,Gender,EmpType,Sallery,Class,Subject) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & DateTimePicker1.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & DateTimePicker1.Text & "','" & TextBox5.Text & "','" & ComboBox2.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & cl & "', '" & sb & "')"
                cmd.ExecuteNonQuery()
                'MsgBox("New Class Added.")
                Dim result As Integer = MessageBox.Show("New Staff Member Added. Want To Add Another One.", "Added", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Me.Close()
                ElseIf result = DialogResult.Yes Then
                    ds.Clear()
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    TextBox5.Clear()
                    TextBox6.Clear()
                    ComboBox1.ResetText()
                    ComboBox2.ResetText()
                    CheckedListBox1.Visible = False
                    CheckedListBox2.Visible = False
                    Label11.Visible = False
                    Label12.Visible = False

                    str = "select * from Staff"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Staff")
                    Dim LastNo As Integer
                    LastNo = ds.Tables("Staff").Rows.Count + 1
                    If LastNo >= 0 Then
                        TextBox1.Text = "STF" & LastNo
                    Else
                        TextBox1.Text = "STF" & 0
                    End If
                End If
            Catch ex As Exception
                MsgBox(" Staff Member Not Added.")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                ComboBox1.ResetText()
                ComboBox2.ResetText()
                CheckedListBox1.Visible = False
                CheckedListBox2.Visible = False
                Label11.Visible = False
                Label12.Visible = False
            End Try
            'insert closed
        End If
        'cn.Close()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        TextBox5.Text = DateTime.Now.Year - DateTimePicker2.Value.Year
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

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub
End Class