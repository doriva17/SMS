Imports System.Data.OleDb
Public Class All_Transaction_Details
    Dim type, fromd, tod As String
    Dim che As Integer
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        type = ComboBox1.Text
        If che = 1 Then
            che = 0

            DataGridView1.Rows.Clear()
            Dim ctr, i As Integer
            If ComboBox1.Text = "ALL" Then
                ds.Clear()
                str = "select * from Account ORDER BY ID ASC"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.Fill(ds, "Account")
                ctr = ds.Tables("Account").Rows.Count - 1
                For i = 0 To ctr
                    DataGridView1.Rows.Add(ds.Tables("Account").Rows(i)(0).ToString, ds.Tables("Account").Rows(i)(1).ToString, ds.Tables("Account").Rows(i)(2).ToString, ds.Tables("Account").Rows(i)(3).ToString, ds.Tables("Account").Rows(i)(4).ToString, ds.Tables("Account").Rows(i)(6).ToString, ds.Tables("Account").Rows(i)(7).ToString)
                Next
            Else
                ds.Clear()
                str = "select * from Account where Type = '" & ComboBox1.Text & "' ORDER BY ID ASC"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.Fill(ds, "Account")
                ctr = ds.Tables("Account").Rows.Count - 1
                For i = 0 To ctr
                    DataGridView1.Rows.Add(ds.Tables("Account").Rows(i)(0).ToString, ds.Tables("Account").Rows(i)(1).ToString, ds.Tables("Account").Rows(i)(2).ToString, ds.Tables("Account").Rows(i)(3).ToString, ds.Tables("Account").Rows(i)(4).ToString, ds.Tables("Account").Rows(i)(6).ToString, ds.Tables("Account").Rows(i)(7).ToString)
                Next
            End If
            
            che = 1
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ctr As Integer
        Dim er As Integer = 0

        
        PrintForm.MdiParent = Home       
        Dim co As Integer
        co = 0
        'Report
        If er = 0 Then
            Dim cr As New AllTransactionDetail
            ds.Clear()
            If type = "ALL" And fromd = "N/A" And tod = "N/A" Then
                Try
                    'All Transaction
                    str = "select * from Account ORDER BY ID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Account")
                    ctr = ds.Tables("Account").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Account Detail Found.")
                    End If
                Catch ex As Exception
                    MsgBox("No Accounts Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        cr.SetParameterValue("type", type)
                        cr.SetParameterValue("from", fromd)
                        cr.SetParameterValue("to", tod)
                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        'MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try
            ElseIf type <> "ALL" And fromd = "N/A" And tod = "N/A" Then
                Try
                    'Tranaction Detail By Type
                    str = "select * from Account where Type = '" & ComboBox1.Text & "' ORDER BY ID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Account")
                    ctr = ds.Tables("Account").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Account Detail Found.")
                    End If
                Catch ex As Exception
                    MsgBox("No Account Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        cr.SetParameterValue("type", type)
                        cr.SetParameterValue("from", fromd)
                        cr.SetParameterValue("to", tod)
                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        'MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try
            ElseIf type = "ALL" And fromd <> "N/A" And tod <> "N/A" Then
                Try
                    'Transaction Deail By Date
                    str = "select * from Account where TDate BETWEEN '" & DateTimePicker1.Text & "'  AND '" & DateTimePicker2.Text & "' ORDER BY ID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Account")
                    ctr = ds.Tables("Account").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Account Detail Found.")
                    End If
                Catch ex As Exception
                    MsgBox("No Account Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        cr.SetParameterValue("type", type)
                        cr.SetParameterValue("from", fromd)
                        cr.SetParameterValue("to", tod)
                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        'MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try

            ElseIf type <> "ALL" And fromd <> "N/A" And tod <> "N/A" Then
                Try
                    'Transaction Details By Date and Type
                    str = "select * from Account where Type = '" & ComboBox1.Text & "' And TDate BETWEEN '" & DateTimePicker1.Text & "'  AND '" & DateTimePicker2.Text & "' ORDER BY ID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Account")
                    ctr = ds.Tables("Account").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Account Detail Found.")
                    End If
                Catch ex As Exception
                    MsgBox("No Account Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        cr.SetParameterValue("type", type)
                        cr.SetParameterValue("from", fromd)
                        cr.SetParameterValue("to", tod)
                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        'MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try
            End If
            type = ComboBox1.Text
            fromd = "N/A"
            tod = "N/A"

        End If
    End Sub

    Private Sub All_Transaction_Details_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub

    Private Sub All_Transaction_Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        
        che = 0
        Module1.conn()
        cn.Open()
        Dim ctr, i As Integer
        DateTimePicker1.Value = DateTime.Now.AddMonths(-1)
        DateTimePicker2.Value = DateTime.Now
        
        ds.Clear()
        str = "select * from Account ORDER BY ID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Account")
        ctr = ds.Tables("Account").Rows.Count - 1
        For i = 0 To ctr
            DataGridView1.Rows.Add(ds.Tables("Account").Rows(i)(0).ToString, ds.Tables("Account").Rows(i)(1).ToString, ds.Tables("Account").Rows(i)(2).ToString, ds.Tables("Account").Rows(i)(3).ToString, ds.Tables("Account").Rows(i)(4).ToString, ds.Tables("Account").Rows(i)(6).ToString, ds.Tables("Account").Rows(i)(7).ToString)
        Next
        type = "ALL"
        fromd = "N/A"
        tod = "N/A"
        che = 1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        DateTimePicker2.Enabled = True
        fromd = DateTimePicker1.Text
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        DateTimePicker2.Enabled = False
        tod = DateTimePicker2.Text
        If DateTimePicker1.Value >= DateTimePicker2.Value Then
            MsgBox("From date must be less then To date.")
            DateTimePicker1.Value = DateTime.Now.AddMonths(-1)
            DateTimePicker2.Enabled = False
        End If
        If che = 1 Then
            che = 0
            'ComboBox1.Text = "Select"
            DataGridView1.Rows.Clear()
            Dim ctr, i As Integer

            If ComboBox1.Text = "Select" Or ComboBox1.Text = "ALL" Then
                ds.Clear()
                str = "select * from Account where TDate BETWEEN '" & DateTimePicker1.Text & "'  AND '" & DateTimePicker2.Text & "' ORDER BY ID ASC"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.Fill(ds, "Account")
                ctr = ds.Tables("Account").Rows.Count - 1
                For i = 0 To ctr
                    DataGridView1.Rows.Add(ds.Tables("Account").Rows(i)(0).ToString, ds.Tables("Account").Rows(i)(1).ToString, ds.Tables("Account").Rows(i)(2).ToString, ds.Tables("Account").Rows(i)(3).ToString, ds.Tables("Account").Rows(i)(4).ToString, ds.Tables("Account").Rows(i)(6).ToString, ds.Tables("Account").Rows(i)(7).ToString)
                Next
            Else
                ds.Clear()
                str = "select * from Account where Type = '" & ComboBox1.Text & "' And TDate BETWEEN '" & DateTimePicker1.Text & "'  AND '" & DateTimePicker2.Text & "' ORDER BY ID ASC"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.Fill(ds, "Account")
                ctr = ds.Tables("Account").Rows.Count - 1
                For i = 0 To ctr
                    DataGridView1.Rows.Add(ds.Tables("Account").Rows(i)(0).ToString, ds.Tables("Account").Rows(i)(1).ToString, ds.Tables("Account").Rows(i)(2).ToString, ds.Tables("Account").Rows(i)(3).ToString, ds.Tables("Account").Rows(i)(4).ToString, ds.Tables("Account").Rows(i)(6).ToString, ds.Tables("Account").Rows(i)(7).ToString)
                Next
            End If
            che = 1
        End If
    End Sub
End Class