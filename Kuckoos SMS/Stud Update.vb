Imports System.Data.OleDb
Imports System.IO
Public Class Stud_Update
    Dim er, ph, imc, cond As Integer
    Dim Photos1() As Byte
    Dim dr As OleDbDataReader

    Private Sub Stud_Update_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub
    Private Sub Stud_Update_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds.Clear()
        ph = 1
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Module1.conn()
        cn.Open()
        er = 0
        imc = 0
        Dim ctr As Integer

        str = "select * from Student"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Student")
        ctr = ds.Tables("Student").Rows.Count - 1
        For i = 0 To ctr
            ComboBox5.Items.Add(ds.Tables("Student").Rows(i)(0).ToString)
        Next
        'cn.Close()

        str = "select * from Class"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Class")
        ctr = ds.Tables("Class").Rows.Count - 1
        For i = 0 To ctr
            ComboBox4.Items.Add(ds.Tables("Class").Rows(i)(1).ToString)
        Next

        For i = 0 To 100
            File.Delete("photo" & i & ".jpg")
        Next


       
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        Dim ctr, i As Integer
        cond = 1
        ds.Clear()
        str = "select * from Student where RegNo = '" & ComboBox5.Text & "'"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Student")
        ctr = ds.Tables("Student").Rows.Count - 1
        For i = 0 To ctr
            DateTimePicker1.Value = ds.Tables("Student").Rows(i)(2).ToString
            DateTimePicker2.Value = ds.Tables("Student").Rows(i)(3).ToString
            ComboBox1.Text = ds.Tables("Student").Rows(i)(15).ToString
            ComboBox2.Text = ds.Tables("Student").Rows(i)(5).ToString
            ComboBox3.Text = ds.Tables("Student").Rows(i)(14).ToString
            ComboBox4.Text = ds.Tables("Student").Rows(i)(18).ToString
            TextBox2.Text = ds.Tables("Student").Rows(i)(1).ToString
            TextBox3.Text = ds.Tables("Student").Rows(i)(4).ToString
            TextBox4.Text = ds.Tables("Student").Rows(i)(6).ToString
            TextBox5.Text = ds.Tables("Student").Rows(i)(7).ToString
            TextBox6.Text = ds.Tables("Student").Rows(i)(8).ToString
            TextBox7.Text = ds.Tables("Student").Rows(i)(10).ToString
            TextBox8.Text = ds.Tables("Student").Rows(i)(9).ToString
            TextBox9.Text = ds.Tables("Student").Rows(i)(11).ToString
            TextBox10.Text = ds.Tables("Student").Rows(i)(13).ToString
            TextBox11.Text = ds.Tables("Student").Rows(i)(12).ToString
            TextBox12.Text = ds.Tables("Student").Rows(i)(16).ToString
            TextBox13.Text = ds.Tables("Student").Rows(i)(17).ToString
            TextBox14.Text = ds.Tables("Student").Rows(i)(19).ToString
        Next

        str = "select * from Photo where SID = '" & ComboBox5.Text & "'"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Photo")
        ctr = ds.Tables("Photo").Rows.Count
        If ctr > 0 Then
        Else
            imc = 1
        End If

        PictureBox1.Image = PictureBox1.InitialImage

        'Select Student Photo
        cmd = New OleDbCommand
        cmd.CommandText = "select SID,SName,StudImage from Photo where SID = " & ComboBox5.Text & ""
        cmd.Parameters.AddWithValue("@SID", ComboBox5.Text)
        cmd.Connection = cn
        dr = cmd.ExecuteReader
        Dim pho As String

        pho = "photo" & ph & ".jpg"
        If dr.Read() Then
            Photos1 = dr(2)
            File.WriteAllBytes(pho, Photos1)
            PictureBox1.Load(pho)
            ph = ph + 1

        End If
        cond = 0
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        TextBox3.Text = DateTime.Now.Year - DateTimePicker2.Value.Year
    End Sub

    Private Sub TextBox14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox14.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged
       
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox5.Clear()
        TextBox5.Text = TextBox4.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim er As Integer = 0

        
        ds.Clear()
        str = "select * from Student where RollNo = '" & TextBox14.Text & "' and AdmitedTo = '" & ComboBox4.Text & "'"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Student")
        Dim LastNo As Integer
        LastNo = ds.Tables("Student").Rows.Count

        If LastNo > 1 Then
            er = 1
            MsgBox("Roll no allready exists.")
            TextBox14.Clear()
        End If

        If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or TextBox11.Text = "" Or TextBox12.Text = "" Or TextBox13.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or TextBox14.Text = "" Then
            er = 1
            If Val(TextBox3.Text) < 3 Then
                MsgBox("Please Fill All The Detail's. Please Select Birth Date.")
            Else
                MsgBox("Please Fill All The Detail's.")
            End If
        End If
        'insert
        If er = 0 Then
            Try



                cmd.Connection = cn
                cmd.CommandText = "Update Student set StudName = '" & TextBox2.Text & "',DateAdd = '" & DateTimePicker1.Text & "', DOB = '" & DateTimePicker2.Text & "', Age = '" & TextBox3.Text & "', Gender = '" & ComboBox2.Text & "', PrAddress = '" & TextBox4.Text & "', PeAddress = '" & TextBox5.Text & "', FName = '" & TextBox6.Text & "', FMobile = '" & TextBox8.Text & "', FOccupation = '" & TextBox7.Text & "', MName = '" & TextBox9.Text & "', MMobile = '" & TextBox11.Text & "', MOccupation = '" & TextBox10.Text & "', Nationality = '" & ComboBox3.Text & "', Area = '" & ComboBox1.Text & "', BPlace = '" & TextBox12.Text & "', Religion = '" & TextBox13.Text & "', AdmitedTo = '" & ComboBox4.Text & "', RollNo = '" & TextBox14.Text & "' where RegNo = '" & ComboBox5.Text & "'"
                cmd.ExecuteNonQuery()

                Dim result As Integer = MessageBox.Show("Student Information Updated. Do You Want To Update Another One.", "Update", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Me.Close()
                ElseIf result = DialogResult.Yes Then
                    ds.Clear()

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
                    ComboBox1.Text = "Select"
                    ComboBox2.Text = "Select"
                    ComboBox3.Text = "Select"
                    ComboBox4.Text = "Select"
                    ComboBox5.Text = "Select"
                End If

            Catch ex As Exception
                MsgBox(" Student Not Updated.")

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
            End Try
            'insert closed
        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim ctr, i As Integer

        If cond = 0 Then
            'cond = 2
            ComboBox5.Items.Clear()
            ComboBox5.Text = "Select"

            ds.Clear()
            str = "select * from Student where AdmitedTo = '" & ComboBox4.Text & "'"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Student")
            ctr = ds.Tables("Student").Rows.Count - 1
            For i = 0 To ctr
                ComboBox5.Items.Add(ds.Tables("Student").Rows(i)(0).ToString)
            Next
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            PictureBox1.Load(OpenFileDialog1.FileName)
        End If
        If imc = 1 Then
            'Photo Saving
            cmd = New OleDbCommand
            cmd.CommandText = " insert into Photo values (@SID, @SName, @StudImage) "
            cmd.Parameters.AddWithValue("@SID", ComboBox5.Text)
            cmd.Parameters.AddWithValue("@SName", TextBox2.Text)
            Photos1 = File.ReadAllBytes(OpenFileDialog1.FileName)
            cmd.Parameters.AddWithValue("@StudImage", Photos1)
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
        Else
            'Photo Updating
            cmd = New OleDbCommand
            cmd.CommandText = "Update Photo set StudImage = @StudImage where SID = '" & ComboBox5.Text & "'"
            Photos1 = File.ReadAllBytes(OpenFileDialog1.FileName)
            cmd.Parameters.AddWithValue("@StudImage", Photos1)
            cmd.Connection = cn
            cmd.ExecuteNonQuery()

        End If
    End Sub
End Class