Imports System.Data.OleDb
Public Class All_Payment_Details
    Dim type, mode, fromd, tod As String
    Dim che As Integer

    Private Sub All_Payment_Details_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub
    Private Sub All_Payment_Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        che = 0
        Module1.conn()
        cn.Open()
        Dim ctr, i, ded As Integer
        DateTimePicker1.Value = DateTime.Now.AddMonths(-1)
        DateTimePicker2.Value = DateTime.Now


        ds.Clear()
        str = "select * from Payment ORDER BY PID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Payment")
        ctr = ds.Tables("Payment").Rows.Count - 1
        For i = 0 To ctr
            ded = Val(ds.Tables("Payment").Rows(i)(11).ToString) + Val(ds.Tables("Payment").Rows(i)(15).ToString)
            DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(2).ToString, ds.Tables("Payment").Rows(i)(3).ToString, ds.Tables("Payment").Rows(i)(4).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(5).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ded, ds.Tables("Payment").Rows(i)(12).ToString)
        Next

        type = "ALL"
        mode = "ALL"
        fromd = "N/A"
        tod = "N/A"
        che = 1
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        mode = ComboBox1.Text

        If che = 1 Then
            che = 0
            'ComboBox2.Text = "Select"
            DataGridView1.Rows.Clear()
            Dim ctr, i, ded As Integer

            If ComboBox1.Text = "Select" Or ComboBox1.Text = "ALL" Then
                If ComboBox2.Text = "Select" Or ComboBox2.Text = "ALL" Then
                    ds.Clear()
                    str = "select * from Payment ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count - 1
                    For i = 0 To ctr
                        ded = Val(ds.Tables("Payment").Rows(i)(11).ToString) + Val(ds.Tables("Payment").Rows(i)(15).ToString)
                        DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(2).ToString, ds.Tables("Payment").Rows(i)(3).ToString, ds.Tables("Payment").Rows(i)(4).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(5).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ded, ds.Tables("Payment").Rows(i)(12).ToString)
                    Next
                Else
                    ds.Clear()
                    str = "select * from Payment where EmpType = '" & ComboBox2.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count - 1
                    For i = 0 To ctr
                        ded = Val(ds.Tables("Payment").Rows(i)(11).ToString) + Val(ds.Tables("Payment").Rows(i)(15).ToString)
                        DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(2).ToString, ds.Tables("Payment").Rows(i)(3).ToString, ds.Tables("Payment").Rows(i)(4).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(5).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ded, ds.Tables("Payment").Rows(i)(12).ToString)
                    Next
                End If
            Else
                If ComboBox2.Text = "Select" Or ComboBox2.Text = "ALL" Then
                    ds.Clear()
                    str = "select * from Payment where PMode = '" & ComboBox1.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count - 1
                    For i = 0 To ctr
                        ded = Val(ds.Tables("Payment").Rows(i)(11).ToString) + Val(ds.Tables("Payment").Rows(i)(15).ToString)
                        DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(2).ToString, ds.Tables("Payment").Rows(i)(3).ToString, ds.Tables("Payment").Rows(i)(4).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(5).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ded, ds.Tables("Payment").Rows(i)(12).ToString)
                    Next
                Else
                    ds.Clear()
                    str = "select * from Payment where PMode = '" & ComboBox1.Text & "' and EmpType = '" & ComboBox2.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count - 1
                    For i = 0 To ctr
                        ded = Val(ds.Tables("Payment").Rows(i)(11).ToString) + Val(ds.Tables("Payment").Rows(i)(15).ToString)
                        DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(2).ToString, ds.Tables("Payment").Rows(i)(3).ToString, ds.Tables("Payment").Rows(i)(4).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(5).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ded, ds.Tables("Payment").Rows(i)(12).ToString)
                    Next
                End If
            End If
            che = 1
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        type = ComboBox2.Text

        If che = 1 Then
            che = 0
            'ComboBox1.Text = "Select"
            DataGridView1.Rows.Clear()
            Dim ctr, i, ded As Integer

            If ComboBox2.Text = "Select" Or ComboBox2.Text = "ALL" Then
                If ComboBox1.Text = "Select" Or ComboBox1.Text = "ALL" Then
                    ds.Clear()
                    str = "select * from Payment ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count - 1
                    For i = 0 To ctr
                        ded = Val(ds.Tables("Payment").Rows(i)(11).ToString) + Val(ds.Tables("Payment").Rows(i)(15).ToString)
                        DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(2).ToString, ds.Tables("Payment").Rows(i)(3).ToString, ds.Tables("Payment").Rows(i)(4).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(5).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ded, ds.Tables("Payment").Rows(i)(12).ToString)
                    Next
                Else
                    ds.Clear()
                    str = "select * from Payment where PMode = '" & ComboBox1.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count - 1
                    For i = 0 To ctr
                        ded = Val(ds.Tables("Payment").Rows(i)(11).ToString) + Val(ds.Tables("Payment").Rows(i)(15).ToString)
                        DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(2).ToString, ds.Tables("Payment").Rows(i)(3).ToString, ds.Tables("Payment").Rows(i)(4).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(5).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ded, ds.Tables("Payment").Rows(i)(12).ToString)
                    Next
                End If
            Else
                If ComboBox1.Text = "Select" Or ComboBox1.Text = "ALL" Then
                    ds.Clear()
                    str = "select * from Payment where EmpType = '" & ComboBox2.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count - 1
                    For i = 0 To ctr
                        ded = Val(ds.Tables("Payment").Rows(i)(11).ToString) + Val(ds.Tables("Payment").Rows(i)(15).ToString)
                        DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(2).ToString, ds.Tables("Payment").Rows(i)(3).ToString, ds.Tables("Payment").Rows(i)(4).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(5).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ded, ds.Tables("Payment").Rows(i)(12).ToString)
                    Next
                Else
                    ds.Clear()
                    str = "select * from Payment where PMode = '" & ComboBox1.Text & "' and EmpType = '" & ComboBox2.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count - 1
                    For i = 0 To ctr
                        ded = Val(ds.Tables("Payment").Rows(i)(11).ToString) + Val(ds.Tables("Payment").Rows(i)(15).ToString)
                        DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(2).ToString, ds.Tables("Payment").Rows(i)(3).ToString, ds.Tables("Payment").Rows(i)(4).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(5).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ded, ds.Tables("Payment").Rows(i)(12).ToString)
                    Next
                End If
            End If
            che = 1
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        DateTimePicker2.Enabled = True
        fromd = DateTimePicker1.Text
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        tod = DateTimePicker2.Text
        DateTimePicker2.Enabled = False
        If DateTimePicker1.Value >= DateTimePicker2.Value Then
            MsgBox("From date must be less then To date.")
            DateTimePicker1.Value = DateTime.Now
            DateTimePicker2.Enabled = False
        End If
        If che = 1 Then
            che = 0
            'ComboBox1.Text = "Select"
            'ComboBox2.Text = "Select"
            DataGridView1.Rows.Clear()
            Dim ctr, i, ded As Integer
            'ds.Clear()
            'str = "select * from Payment where PDate BETWEEN '" & DateTimePicker1.Text & "'  AND '" & DateTimePicker2.Text & "' ORDER BY PID ASC"
            'cmd = New OleDbCommand(str, cn)
            'da.SelectCommand = cmd
            'da.Fill(ds, "Payment")
            'ctr = ds.Tables("Payment").Rows.Count - 1
            'For i = 0 To ctr
            '    ded = Val(ds.Tables("Payment").Rows(i)(11).ToString) + Val(ds.Tables("Payment").Rows(i)(15).ToString)
            '    DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(2).ToString, ds.Tables("Payment").Rows(i)(3).ToString, ds.Tables("Payment").Rows(i)(4).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(5).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ded, ds.Tables("Payment").Rows(i)(12).ToString)
            'Next
            If ComboBox2.Text = "Select" Or ComboBox2.Text = "ALL" Then
                If ComboBox1.Text = "Select" Or ComboBox1.Text = "ALL" Then
                    ds.Clear()
                    str = "select * from Payment where PDate BETWEEN '" & DateTimePicker1.Text & "'  AND '" & DateTimePicker2.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count - 1
                    For i = 0 To ctr
                        ded = Val(ds.Tables("Payment").Rows(i)(11).ToString) + Val(ds.Tables("Payment").Rows(i)(15).ToString)
                        DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(2).ToString, ds.Tables("Payment").Rows(i)(3).ToString, ds.Tables("Payment").Rows(i)(4).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(5).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ded, ds.Tables("Payment").Rows(i)(12).ToString)
                    Next
                Else
                    ds.Clear()
                    str = "select * from Payment where PMode = '" & ComboBox1.Text & "' And PDate BETWEEN '" & DateTimePicker1.Text & "'  AND '" & DateTimePicker2.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count - 1
                    For i = 0 To ctr
                        ded = Val(ds.Tables("Payment").Rows(i)(11).ToString) + Val(ds.Tables("Payment").Rows(i)(15).ToString)
                        DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(2).ToString, ds.Tables("Payment").Rows(i)(3).ToString, ds.Tables("Payment").Rows(i)(4).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(5).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ded, ds.Tables("Payment").Rows(i)(12).ToString)
                    Next
                End If
            Else
                If ComboBox1.Text = "Select" Or ComboBox1.Text = "ALL" Then
                    ds.Clear()
                    str = "select * from Payment where EmpType = '" & ComboBox2.Text & "' And PDate BETWEEN '" & DateTimePicker1.Text & "'  AND '" & DateTimePicker2.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count - 1
                    For i = 0 To ctr
                        ded = Val(ds.Tables("Payment").Rows(i)(11).ToString) + Val(ds.Tables("Payment").Rows(i)(15).ToString)
                        DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(2).ToString, ds.Tables("Payment").Rows(i)(3).ToString, ds.Tables("Payment").Rows(i)(4).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(5).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ded, ds.Tables("Payment").Rows(i)(12).ToString)
                    Next
                Else
                    ds.Clear()
                    str = "select * from Payment where PMode = '" & ComboBox1.Text & "' and EmpType = '" & ComboBox2.Text & "' And PDate BETWEEN '" & DateTimePicker1.Text & "'  AND '" & DateTimePicker2.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count - 1
                    For i = 0 To ctr
                        ded = Val(ds.Tables("Payment").Rows(i)(11).ToString) + Val(ds.Tables("Payment").Rows(i)(15).ToString)
                        DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(2).ToString, ds.Tables("Payment").Rows(i)(3).ToString, ds.Tables("Payment").Rows(i)(4).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(5).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ded, ds.Tables("Payment").Rows(i)(12).ToString)
                    Next
                End If
            End If
            che = 1
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ctr As Integer
        Dim er As Integer = 0


        PrintForm.MdiParent = Home
        Dim co As Integer
        co = 0
        'Report
        If er = 0 Then
            Dim cr As New AllPaymentReport
            ds.Clear()
            If mode = "ALL" And type = "ALL" And fromd = "N/A" And tod = "N/A" Then
                Try
                    'All Payment
                    str = "select * from Payment ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Payment Detail Found.")
                    End If
                Catch ex As Exception
                    MsgBox("No Payment Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        cr.SetParameterValue("etype", type)
                        cr.SetParameterValue("pmode", mode)
                        cr.SetParameterValue("fromd", fromd)
                        cr.SetParameterValue("tod", tod)
                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        'MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try
            ElseIf mode <> "ALL" And type = "ALL" And fromd = "N/A" And tod = "N/A" Then
                Try
                    'Payment Detail By Mode
                    str = "select * from Payment where PMode = '" & ComboBox1.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Payment Detail Found.")
                    End If
                Catch ex As Exception
                    MsgBox("No Payment Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        cr.SetParameterValue("etype", type)
                        cr.SetParameterValue("pmode", mode)
                        cr.SetParameterValue("fromd", fromd)
                        cr.SetParameterValue("tod", tod)

                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        'MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try
            ElseIf mode = "ALL" And type <> "ALL" And fromd = "N/A" And tod = "N/A" Then
                Try
                    'Payment Deail By Type
                    str = "select * from Payment where EmpType = '" & ComboBox2.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Payment Detail Found.")
                    End If
                Catch ex As Exception
                    MsgBox("No Payment Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        cr.SetParameterValue("etype", type)
                        cr.SetParameterValue("pmode", mode)
                        cr.SetParameterValue("fromd", fromd)
                        cr.SetParameterValue("tod", tod)
                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        'MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try

            ElseIf mode <> "ALL" And type <> "ALL" And fromd = "N/A" And tod = "N/A" Then
                Try
                    'Payment Details By Mode and Type
                    str = "select * from Payment where PMode = '" & ComboBox1.Text & "' And EmpType = '" & ComboBox2.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Payment Detail Found.")
                    End If
                Catch ex As Exception
                    MsgBox("No Payment Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        cr.SetParameterValue("etype", type)
                        cr.SetParameterValue("pmode", mode)
                        cr.SetParameterValue("fromd", fromd)
                        cr.SetParameterValue("tod", tod)
                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        'MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try

            ElseIf mode = "ALL" And type = "ALL" And fromd <> "N/A" And tod <> "N/A" Then
                Try
                    'Payment Details By Date
                    str = "select * from Payment where PDate BETWEEN '" & DateTimePicker1.Text & "'  AND '" & DateTimePicker2.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Payment Detail Found.")
                    End If
                Catch ex As Exception
                    MsgBox("No Payment Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        cr.SetParameterValue("etype", type)
                        cr.SetParameterValue("pmode", mode)
                        cr.SetParameterValue("fromd", fromd)
                        cr.SetParameterValue("tod", tod)
                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        'MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try

            ElseIf mode <> "ALL" And type = "ALL" And fromd <> "N/A" And tod <> "N/A" Then
                Try
                    'Payment Details By Date and Mode
                    str = "select * from Payment where PMode = '" & ComboBox1.Text & "' And PDate BETWEEN '" & DateTimePicker1.Text & "'  AND '" & DateTimePicker2.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Payment Detail Found.")
                    End If
                Catch ex As Exception
                    MsgBox("No Payment Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        cr.SetParameterValue("etype", type)
                        cr.SetParameterValue("pmode", mode)
                        cr.SetParameterValue("fromd", fromd)
                        cr.SetParameterValue("tod", tod)
                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        'MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try

            ElseIf mode = "ALL" And type <> "ALL" And fromd <> "N/A" And tod <> "N/A" Then
                Try
                    'Payment Details By Date and Type
                    str = "select * from Payment where EmpType = '" & ComboBox2.Text & "' And PDate BETWEEN '" & DateTimePicker1.Text & "'  AND '" & DateTimePicker2.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Payment Detail Found.")
                    End If
                Catch ex As Exception
                    MsgBox("No Payment Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        cr.SetParameterValue("etype", type)
                        cr.SetParameterValue("pmode", mode)
                        cr.SetParameterValue("fromd", fromd)
                        cr.SetParameterValue("tod", tod)
                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        'MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try

            ElseIf mode <> "ALL" And type <> "ALL" And fromd <> "N/A" And tod <> "N/A" Then
                Try
                    'Payment Details By Date and Type and Mode
                    str = "select * from Payment where PMode = '" & ComboBox1.Text & "' And EmpType = '" & ComboBox2.Text & "' And PDate BETWEEN '" & DateTimePicker1.Text & "'  AND '" & DateTimePicker2.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Payment Detail Found.")
                    End If
                Catch ex As Exception
                    MsgBox("No Payment Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        cr.SetParameterValue("etype", type)
                        cr.SetParameterValue("pmode", mode)
                        cr.SetParameterValue("fromd", fromd)
                        cr.SetParameterValue("tod", tod)
                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        'MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try

            End If

           
            type = ComboBox2.Text
            mode = ComboBox1.Text
            fromd = "N/A"
            tod = "N/A"
        End If
    End Sub
End Class