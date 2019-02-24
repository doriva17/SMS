Imports System.Data.OleDb
Imports System.IO
Public Class StudRegister
    Dim er, pho As Integer

    Dim Photos1() As Byte
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub StudRegister_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub

    Private Sub StudRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds.Clear()
        pho = 0
        DateTimePicker1.Value = DateTime.Now
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Module1.conn()
        cn.Open()
        er = 0
        'cn.Open()
        str = "select * from Student"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Student")
        Dim LastNo As Integer
        LastNo = ds.Tables("Student").Rows.Count + 1
        If LastNo >= 0 Then
            TextBox1.Text = "SID" & LastNo
        Else
            TextBox1.Text = "SID" & 0
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
            ComboBox4.Items.Add(ds.Tables("Class").Rows(i)(1).ToString)
        Next
        'cn.Close()
    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox11.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        TextBox3.Text = DateTime.Now.Year - DateTimePicker2.Value.Year
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox5.Clear()
        TextBox5.Text = TextBox4.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'cn.Open()
        er = 0
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or TextBox11.Text = "" Or TextBox12.Text = "" Or TextBox13.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or TextBox14.Text = "" Then
            er = 1
            If Val(TextBox3.Text) < 3 Then
                MsgBox("Please Fill All The Detail's. Please Select Birth Date.")
            Else
                MsgBox("Please Fill All The Detail's.")
            End If
        End If

        ds.Clear()
        str = "select * from Student"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Student")
        Dim LastNo As Integer
        Dim ph As String
        LastNo = ds.Tables("Student").Rows.Count + 1
        If LastNo >= 0 Then
            ph = "PH" & LastNo
        Else
            ph = "PH" & 0
        End If

        'insert
        If er = 0 Then
            Try
                cmd.Connection = cn
                cmd.CommandText = "insert into Student(RegNo,StudName,DateAdd,DOB,Age,Gender,PrAddress,PeAddress,FName,FMobile,FOccupation,MName,MMobile,MOccupation,Nationality,Area,BPlace,Religion,AdmitedTo,RollNo) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & DateTimePicker1.Text & "','" & DateTimePicker2.Text & "','" & TextBox3.Text & "','" & ComboBox2.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox8.Text & "','" & TextBox7.Text & "', '" & TextBox9.Text & "', '" & TextBox11.Text & "', '" & TextBox10.Text & "', '" & ComboBox3.Text & "', '" & ComboBox1.Text & "', '" & TextBox12.Text & "', '" & TextBox13.Text & "', '" & ComboBox4.Text & "', '" & TextBox14.Text & "')"
                cmd.ExecuteNonQuery()

                If pho = 1 Then


                    'Photo Saving
                    cmd = New OleDbCommand
                    cmd.CommandText = " insert into Photo values (@PID, @SID, @SName, @StudImage) "
                    cmd.Parameters.AddWithValue("@PID", ph)
                    cmd.Parameters.AddWithValue("@SID", TextBox1.Text)
                    cmd.Parameters.AddWithValue("@SName", TextBox2.Text)
                    Photos1 = File.ReadAllBytes(OpenFileDialog1.FileName)
                    cmd.Parameters.AddWithValue("@StudImage", Photos1)
                    cmd.Connection = cn
                    cmd.ExecuteNonQuery()
                End If
                'MsgBox("New Class Added.")
                Dim result As Integer = MessageBox.Show("New Student Added. Want To Add Another One.", "Added", MessageBoxButtons.YesNo)
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
                    TextBox7.Clear()
                    TextBox8.Clear()
                    TextBox9.Clear()
                    TextBox10.Clear()
                    TextBox11.Clear()
                    TextBox12.Clear()
                    TextBox13.Clear()
                    TextBox14.Clear()
                    ComboBox1.ResetText()
                    ComboBox2.ResetText()
                    ComboBox3.ResetText()
                    ComboBox4.ResetText()


                    str = "select * from Student"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Student")
                    LastNo = ds.Tables("Student").Rows.Count + 1
                    If LastNo >= 0 Then
                        TextBox1.Text = "SID" & LastNo
                    Else
                        TextBox1.Text = "SID" & 0
                    End If
                End If
            Catch ex As Exception
                MsgBox(" Student Not Added.")
                ds.Clear()
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                TextBox7.Clear()
                TextBox8.Clear()
                TextBox9.Clear()
                TextBox10.Clear()
                TextBox11.Clear()
                TextBox12.Clear()
                TextBox13.Clear()
                TextBox14.Clear()
                ComboBox1.ResetText()
                ComboBox2.ResetText()
                ComboBox3.ResetText()
                ComboBox4.ResetText()


                str = "select * from Student"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.Fill(ds, "Student")
                LastNo = ds.Tables("Student").Rows.Count + 1
                If LastNo >= 0 Then
                    TextBox1.Text = "SID" & LastNo
                Else
                    TextBox1.Text = "SID" & 0
                End If
            End Try
            'insert closed
        End If
        'cn.Close()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        ds.Clear()

        str = "select * from Student where AdmitedTo = '" & ComboBox4.Text & "'"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Student")
        Dim LastNo As Integer
        LastNo = ds.Tables("Student").Rows.Count + 1
        If LastNo >= 0 Then
            TextBox14.Text = LastNo
        Else
            TextBox14.Text = 0
        End If
        TextBox14.ReadOnly = False
    End Sub

    Private Sub TextBox14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox14.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged
        ds.Clear()
        str = "select * from Student where RollNo = '" & TextBox14.Text & "' and AdmitedTo = '" & ComboBox4.Text & "'"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Student")
        Dim LastNo As Integer
        LastNo = ds.Tables("Student").Rows.Count

        If LastNo > 0 Then
            er = 1
            MsgBox("Roll no allready exists.")
            TextBox14.Clear()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            PictureBox1.Load(OpenFileDialog1.FileName)

            pho = 1
        End If
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        'PictureBox1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class
