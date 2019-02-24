Imports System.Data.OleDb
Public Class All_Exam_Details
    Dim er, che As Integer
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim i, ctr As Integer
        If che = 1 Then
            che = 0
            ds.Clear()
            str = "select * from Class where CName = '" & ComboBox1.Text & "' ORDER BY CID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Class")
            ctr = ds.Tables("Class").Rows.Count - 1
            For i = 0 To ctr
                ComboBox2.Text = ds.Tables("Class").Rows(i)(0).ToString
            Next
            che = 1
        End If
        ds.Clear()
        DataGridView1.Rows.Clear()
        str = "select * from Exam where Class = '" & ComboBox1.Text & "' ORDER BY EID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Exam")
        ctr = ds.Tables("Exam").Rows.Count - 1
        For i = 0 To ctr
            DataGridView1.Rows.Add(ds.Tables("Exam").Rows(i)(0).ToString, ds.Tables("Exam").Rows(i)(1).ToString, ds.Tables("Exam").Rows(i)(2).ToString, ds.Tables("Exam").Rows(i)(4).ToString, ds.Tables("Exam").Rows(i)(5).ToString, ds.Tables("Exam").Rows(i)(6).ToString, ds.Tables("Exam").Rows(i)(7).ToString)
        Next
    End Sub

    Private Sub All_Exam_Details_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub

    Private Sub All_Exam_Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            ComboBox2.Items.Add(ds.Tables("Class").Rows(i)(0).ToString)
        Next

        ds.Clear()
        str = "select * from Exam ORDER BY EID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Exam")
        ctr = ds.Tables("Exam").Rows.Count - 1
        For i = 0 To ctr
            DataGridView1.Rows.Add(ds.Tables("Exam").Rows(i)(0).ToString, ds.Tables("Exam").Rows(i)(1).ToString, ds.Tables("Exam").Rows(i)(2).ToString, ds.Tables("Exam").Rows(i)(4).ToString, ds.Tables("Exam").Rows(i)(5).ToString, ds.Tables("Exam").Rows(i)(6).ToString, ds.Tables("Exam").Rows(i)(7).ToString)
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim i, ctr As Integer
        If che = 1 Then
            ds.Clear()
            str = "select * from Class where CID = '" & ComboBox2.Text & "' ORDER BY CID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Class")
            ctr = ds.Tables("Class").Rows.Count - 1
            For i = 0 To ctr
                ComboBox1.Text = ds.Tables("Class").Rows(i)(1).ToString
            Next
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ctr As Integer
        Dim er As Integer = 0
        Dim cla, clan As String
        cla = ""
        clan = ""
        PrintForm.MdiParent = Home
        If ComboBox1.Text = "Select" Or ComboBox1.Text = "" Then
            cla = "ALL"
            clan = "ALL"
        Else
            cla = ComboBox2.Text
            clan = ComboBox1.Text
        End If
        Dim co As Integer
        co = 0
        'Report
        If er = 0 Then
            Dim cr As New AllExamDetails
            ds.Clear()
            If cla = "ALL" Then
                Try
                    'Exam Detail
                    str = "select * from Exam ORDER BY EID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Exam")
                    ctr = ds.Tables("Exam").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Exam Detail Found.")
                    End If
                Catch ex As Exception
                    MsgBox("No Exam Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        cr.SetParameterValue("clasid", cla)
                        cr.SetParameterValue("classname", clan)
                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        'MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try
            Else
                Try
                    'Exam Detail
                    str = "select * from Exam where Class = '" & ComboBox1.Text & "' ORDER BY EID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Exam")
                    ctr = ds.Tables("Exam").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Exam Detail Found.")
                    End If
                Catch ex As Exception
                    MsgBox("No Exam Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        cr.SetParameterValue("clasid", cla)
                        cr.SetParameterValue("classname", clan)
                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        'MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try
            End If

        End If
    End Sub
End Class