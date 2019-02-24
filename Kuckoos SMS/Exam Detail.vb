Imports System.Data.OleDb
Public Class Exam_Detail
    Dim er, che As Integer
    Dim EDF1, EDF2, EDF3, EDF4, EDF5, EDF6, EDF7, EDF8, EDF9 As String

    Private Sub Exam_Detail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub
    Private Sub Exam_Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim i, ctr As Integer

        If che = 1 Then
            che = 0

            TextBox1.Clear()
            TextBox2.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            ds.Clear()
            str = "select * from Exam where EID = '" & ComboBox2.Text & "' ORDER BY EID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Exam")
            ctr = ds.Tables("Exam").Rows.Count - 1
            For i = 0 To ctr
                TextBox1.Text = ds.Tables("Exam").Rows(i)(2).ToString
                TextBox2.Text = ds.Tables("Exam").Rows(i)(4).ToString
                TextBox4.Text = ds.Tables("Exam").Rows(i)(5).ToString
                TextBox5.Text = ds.Tables("Exam").Rows(i)(6).ToString
                ComboBox3.Text = ds.Tables("Exam").Rows(i)(1).ToString
                ComboBox1.Text = ds.Tables("Exam").Rows(i)(3).ToString
               
            Next
            che = 1
        End If



        DataGridView1.Columns.Clear()
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Add("SID", "S. ID.")
        DataGridView1.Columns.Add("RollNo", "Roll No.")
        DataGridView1.Columns.Add("Name", "Name")

        TextBox6.Clear()
        ds.Clear()
        str = "select * from ExamSubject where EID = '" & ComboBox2.Text & "' ORDER BY ESID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "ExamSubject")
        ctr = ds.Tables("ExamSubject").Rows.Count - 1
        For i = 0 To ctr
            DataGridView1.Columns.Add("Subject" & i, ds.Tables("ExamSubject").Rows(i)(2).ToString)
            DataGridView1.Columns.Add("SubjectResult" & i, "Result")
            TextBox6.Text = TextBox6.Text & ds.Tables("ExamSubject").Rows(i)(2).ToString & ", "
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
        TextBox3.Clear()
        ds.Clear()
        str = "select * from Class where CName = '" & ComboBox1.Text & "' ORDER BY CID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Class")
        ctr = ds.Tables("Class").Rows.Count - 1
        For i = 0 To ctr
            TextBox3.Text = ds.Tables("Class").Rows(i)(0).ToString
        Next
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Dim i, ctr As Integer

        If che = 1 Then
            ds.Clear()
            str = "select * from Exam where EName = '" & ComboBox3.Text & "' ORDER BY EID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Exam")
            ctr = ds.Tables("Exam").Rows.Count - 1
            For i = 0 To ctr
                ComboBox2.Text = ds.Tables("Exam").Rows(i)(0).ToString
            Next            
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim er As Integer = 0
        PrintForm.MdiParent = Home
        Dim co, ctr As Integer
        co = 0
        'Report
        If ComboBox2.Text = "" Or ComboBox2.Text = "Select" Then
            MsgBox("Please Select Exam ID. First.")
            er = 1
        End If
        If er = 0 Then
            Dim cr As New ExamDetail
            Try
                'Exam Detail
                EDF1 = ComboBox2.Text
                EDF2 = ComboBox3.Text
                EDF3 = TextBox3.Text
                EDF4 = ComboBox1.Text
                EDF5 = TextBox1.Text
                EDF6 = TextBox2.Text
                EDF7 = TextBox4.Text
                EDF8 = TextBox5.Text
                EDF9 = TextBox6.Text

                'Exam Detail
                ds.Clear()
                str = "select * from ExamMarks where EID = '" & ComboBox2.Text & "' ORDER BY EMID ASC"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.SelectCommand.ExecuteNonQuery()
                da.Fill(ds, "ExamMarks")
                ctr = ds.Tables("ExamMarks").Rows.Count               

            Catch ex As Exception
                MsgBox("No Exam Detail Found. Select Exam Id.")
            End Try

            Try
                If co = 0 Then
                    cr.SetDataSource(ds)
                    PrintForm.CrystalReportViewer1.RefreshReport()
                    cr.SetParameterValue("EDR1", EDF1)
                    cr.SetParameterValue("EDR2", EDF2)
                    cr.SetParameterValue("EDR3", EDF3)
                    cr.SetParameterValue("EDR4", EDF4)
                    cr.SetParameterValue("EDR5", EDF5)
                    cr.SetParameterValue("EDR6", EDF6)
                    cr.SetParameterValue("EDR7", EDF7)
                    cr.SetParameterValue("EDR8", EDF8)
                    cr.SetParameterValue("EDR9", EDF9)
                    PrintForm.CrystalReportViewer1.ReportSource = cr
                    PrintForm.Show()
                Else
                    'MsgBox("Probleam in Preparing Print.")
                End If
            Catch ex As Exception
                MsgBox("Unable To Create Report.")
            End Try
        End If
    End Sub
End Class