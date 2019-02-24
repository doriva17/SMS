Imports System.Data.OleDb
Public Class Add_Exam_Marks
    Dim er, che As Integer
    Dim sid, cid, sbid, emid As String

    Private Sub Add_Exam_Marks_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub
    Private Sub Add_Exam_Marks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Module1.conn()
        cn.Open()
        che = 1
        er = 0
        ds.Clear()
        Dim i, ctr As Integer
        str = "select * from Class ORDER BY CID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Class")
        ctr = ds.Tables("Class").Rows.Count - 1
        For i = 0 To ctr
            ComboBox1.Items.Add(ds.Tables("Class").Rows(i)(1).ToString)
        Next

        ds.Clear()
        str = "select * from Exam ORDER BY EID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Exam")
        ctr = ds.Tables("Exam").Rows.Count - 1
        For i = 0 To ctr
            ComboBox2.Items.Add(ds.Tables("Exam").Rows(i)(0).ToString)
            ComboBox3.Items.Add(ds.Tables("Exam").Rows(i)(1).ToString)
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim i, ctr As Integer
        If che = 1 Then
            che = 0
            ComboBox2.Items.Clear()
            ComboBox3.Items.Clear()
            ComboBox2.Text = "Select"
            ComboBox3.Text = "Select"

            ds.Clear()
            str = "select * from Exam where Class = '" & ComboBox1.Text & "' ORDER BY EID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Exam")
            ctr = ds.Tables("Exam").Rows.Count - 1
            For i = 0 To ctr
                ComboBox2.Items.Add(ds.Tables("Exam").Rows(i)(0).ToString)
                ComboBox3.Items.Add(ds.Tables("Exam").Rows(i)(1).ToString)              
            Next
            che = 1
        End If

        ds.Clear()
        str = "select * from Class where CName = '" & ComboBox1.Text & "' ORDER BY CID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Class")
        ctr = ds.Tables("Class").Rows.Count - 1
        For i = 0 To ctr
            cid = ds.Tables("Class").Rows(i)(0).ToString
        Next

        ComboBox4.Items.Clear()
        ComboBox5.Items.Clear()
        ds.Clear()
        str = "select * from Student where AdmitedTo = '" & ComboBox1.Text & "' ORDER BY RegNo ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Student")
        ctr = ds.Tables("Student").Rows.Count - 1
        For i = 0 To ctr
            ComboBox4.Items.Add(ds.Tables("Student").Rows(i)(19).ToString)
            ComboBox5.Items.Add(ds.Tables("Student").Rows(i)(1).ToString)
        Next

        
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim i, ctr As Integer
        If che = 1 Then
            che = 0

            ds.Clear()
            str = "select * from Exam where EID = '" & ComboBox2.Text & "' ORDER BY EID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Exam")
            ctr = ds.Tables("Exam").Rows.Count - 1
            For i = 0 To ctr
                ComboBox3.Text = ds.Tables("Exam").Rows(i)(1).ToString
                ComboBox1.Text = ds.Tables("Exam").Rows(i)(3).ToString
            Next
            che = 1
        End If
        DataGridView1.Columns.Clear()
        DataGridView1.Rows.Clear()
        ComboBox6.Items.Clear()
        ComboBox6.Text = "Select"
        DataGridView1.Columns.Add("SID", "S. ID.")
        DataGridView1.Columns.Add("RollNo", "Roll No.")
        DataGridView1.Columns.Add("Name", "Name")

        ds.Clear()
        str = "select * from ExamSubject where EID = '" & ComboBox2.Text & "' ORDER BY ESID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "ExamSubject")
        ctr = ds.Tables("ExamSubject").Rows.Count - 1
        For i = 0 To ctr
            DataGridView1.Columns.Add("Subject" & i, ds.Tables("ExamSubject").Rows(i)(2).ToString)
            DataGridView1.Columns.Add("SubjectResult" & i, "Result")
            ComboBox6.Items.Add(ds.Tables("ExamSubject").Rows(i)(2).ToString)
        Next


        DataGridView1.Rows.Clear()
        ds.Clear()
        str = "select * from Student where AdmitedTo = '" & ComboBox1.Text & "' ORDER BY RegNo ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Student")
        ctr = ds.Tables("Student").Rows.Count - 1
        For i = 0 To ctr
            DataGridView1.Rows.Add(ds.Tables("Student").Rows(i)(0).ToString, ds.Tables("Student").Rows(i)(19).ToString, ds.Tables("Student").Rows(i)(1).ToString)
        Next

        Dim co As Integer = 3
        ds.Clear()
        str = "select * from ExamMarks where EID = '" & ComboBox2.Text & "' ORDER BY EMID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "ExamMarks")
        ctr = ds.Tables("ExamMarks").Rows.Count - 1
        For i = 0 To DataGridView1.Rows.Count - 1
            co = 3
            For j = 0 To ctr
                If DataGridView1.Rows(i).Cells(0).Value = ds.Tables("ExamMarks").Rows(j)(3).ToString Then
                    DataGridView1.Rows(i).Cells(co).Value = ds.Tables("ExamMarks").Rows(j)(8).ToString
                    DataGridView1.Rows(i).Cells(co + 1).Value = ds.Tables("ExamMarks").Rows(j)(9).ToString
                    co = co + 2
                End If
            Next
        Next

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Dim i, ctr As Integer
        If che = 1 Then
            che = 0

            ds.Clear()
            str = "select * from Exam where EName = '" & ComboBox3.Text & "' ORDER BY EID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Exam")
            ctr = ds.Tables("Exam").Rows.Count - 1
            For i = 0 To ctr
                ComboBox2.Text = ds.Tables("Exam").Rows(i)(0).ToString
                ComboBox1.Text = ds.Tables("Exam").Rows(i)(3).ToString
            Next
            che = 1
        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim i, ctr As Integer
        If che = 1 Then
            che = 0

            ds.Clear()
            str = "select * from Student where RollNo = '" & ComboBox4.Text & "' and AdmitedTo = '" & ComboBox1.Text & "' ORDER BY RegNo ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Student")
            ctr = ds.Tables("Student").Rows.Count - 1
            For i = 0 To ctr
                ComboBox4.Text = ds.Tables("Student").Rows(i)(19).ToString
                ComboBox5.Text = ds.Tables("Student").Rows(i)(1).ToString
                sid = ds.Tables("Student").Rows(i)(0).ToString
            Next
            che = 1
        End If
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        Dim i, ctr As Integer
        If che = 1 Then
            che = 0

            ds.Clear()
            str = "select * from Student where StudName = '" & ComboBox5.Text & "' and AdmitedTo = '" & ComboBox1.Text & "' ORDER BY RegNo ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Student")
            ctr = ds.Tables("Student").Rows.Count - 1
            For i = 0 To ctr
                ComboBox4.Text = ds.Tables("Student").Rows(i)(19).ToString
                ComboBox5.Text = ds.Tables("Student").Rows(i)(1).ToString
                sid = ds.Tables("Student").Rows(i)(0).ToString
            Next
            che = 1
        End If
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        TextBox3.Clear()
        TextBox4.Clear()

        Dim ctr, i As Integer
        ds.Clear()
        str = "select * from Subject where SName = '" & ComboBox6.Text & "' ORDER BY SID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Subject")
        ctr = ds.Tables("Subject").Rows.Count - 1
        For i = 0 To ctr
            sbid = ds.Tables("Subject").Rows(i)(0).ToString
        Next
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If Val(TextBox3.Text) >= Val(TextBox2.Text) And Val(TextBox3.Text) <= Val(TextBox1.Text) Then
            TextBox4.Text = "PASS"
        Else
            TextBox4.Text = "FAILED"
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        er = 0
        Dim i, ctr As Integer
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            er = 1
            MsgBox("Please fill all the field.")
        End If
        If ComboBox1.Text = "Select" Or ComboBox2.Text = "Select" Or ComboBox3.Text = "Select" Or ComboBox4.Text = "Select" Or ComboBox5.Text = "Select" Or ComboBox6.Text = "Select" Then
            er = 1
            MsgBox("Please Select the record.")
        End If

        ds.Clear()
        str = "select * from ExamMarks where EID = '" & ComboBox2.Text & "' and SID = '" & sid & "' and SName = '" & ComboBox6.Text & "'"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "ExamMarks")
        ctr = ds.Tables("ExamMarks").Rows.Count
        If ctr > 0 Then
            er = 1
            MsgBox("Exam Marks Of " & ComboBox6.Text & " For " & ComboBox5.Text & " Student Allredy Added.")
        End If

        ds.Clear()
        str = "select * from ExamMarks"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "ExamMarks")
        Dim LastNo As Integer
        LastNo = ds.Tables("ExamMarks").Rows.Count + 1
        If LastNo >= 0 Then
            emid = "EMID" & LastNo
        Else
            emid = "EMID" & 0
        End If

        If er = 0 Then
            Try
                cmd.Connection = cn
                cmd.CommandText = "insert into ExamMarks(EMID,EID,CID,SID,SBID,SName,MMarks,LMarks,OMarks,Result,RollNo,StudName) values('" & emid & "','" & ComboBox2.Text & "','" & cid & "','" & sid & "','" & sbid & "','" & ComboBox6.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox4.Text & "','" & ComboBox5.Text & "')"
                cmd.ExecuteNonQuery()

                TextBox3.Clear()
                ComboBox6.Text = "Select"

                DataGridView1.Rows.Clear()
                ds.Clear()
                str = "select * from Student where AdmitedTo = '" & ComboBox1.Text & "' ORDER BY RegNo ASC"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.Fill(ds, "Student")
                ctr = ds.Tables("Student").Rows.Count - 1
                For i = 0 To ctr
                    DataGridView1.Rows.Add(ds.Tables("Student").Rows(i)(0).ToString, ds.Tables("Student").Rows(i)(19).ToString, ds.Tables("Student").Rows(i)(1).ToString)
                Next

                Dim co As Integer = 3
                ds.Clear()
                str = "select * from ExamMarks where EID = '" & ComboBox2.Text & "' ORDER BY EMID ASC"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.Fill(ds, "ExamMarks")
                ctr = ds.Tables("ExamMarks").Rows.Count - 1
                For i = 0 To DataGridView1.Rows.Count - 1
                    co = 3
                    For j = 0 To ctr
                        If DataGridView1.Rows(i).Cells(0).Value = ds.Tables("ExamMarks").Rows(j)(3).ToString Then
                            DataGridView1.Rows(i).Cells(co).Value = ds.Tables("ExamMarks").Rows(j)(8).ToString
                            DataGridView1.Rows(i).Cells(co + 1).Value = ds.Tables("ExamMarks").Rows(j)(9).ToString
                            co = co + 2
                        End If
                    Next
                Next
            Catch ex As Exception
                MsgBox(" Exam Marks Not Added.")
               
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class