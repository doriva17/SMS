Imports System.Data.OleDb
Public Class Account
    Dim AS1, AS2, AS3, AS4, AS5, AS6, AS7, AS8, AS9, AS10, AS11, AS12, AS13, AS14, AS15, AS16, AS17 As String
    Dim er As Integer

    Private Sub Account_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub
    Private Sub Account_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = DateTime.Now.AddMonths(-1)
        DateTimePicker2.Value = DateTime.Now

        ds.Clear()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Module1.conn()
        cn.Open()
        er = 1
        Dim ctr, i As Integer
        Dim inc, exp, bal, tra, cas, casp, bak, bakp, stp, fes As Integer
        bal = 0
        inc = 0
        exp = 0
        tra = 0
        cas = 0
        casp = 0
        bak = 0
        bakp = 0
        stp = 0
        fes = 0

        'Income for Balance
        ds.Clear()
        str = "select * from Account where Type = '" & "INCOME" & "'"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Account")
        ctr = ds.Tables("Account").Rows.Count - 1
        For i = 0 To ctr
            inc = inc + Val(ds.Tables("Account").Rows(i)(7).ToString)
        Next

        'Expense for balance
        ds.Clear()
        str = "select * from Account where Type = '" & "EXPENSE" & "'"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Account")
        ctr = ds.Tables("Account").Rows.Count - 1
        For i = 0 To ctr
            exp = exp + Val(ds.Tables("Account").Rows(i)(7).ToString)
        Next

        'Cash Balance
        ds.Clear()
        str = "select * from Account where Type = '" & "INCOME" & "' and Mode = '" & "CASH" & "'"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Account")
        ctr = ds.Tables("Account").Rows.Count - 1
        For i = 0 To ctr
            cas = cas + Val(ds.Tables("Account").Rows(i)(7).ToString)
        Next

        'Cash Spend
        ds.Clear()
        str = "select * from Account where Type = '" & "EXPENSE" & "' and Mode = '" & "CASH" & "'"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Account")
        ctr = ds.Tables("Account").Rows.Count - 1
        For i = 0 To ctr
            casp = casp + Val(ds.Tables("Account").Rows(i)(7).ToString)
        Next

        'Income Bank
        ds.Clear()
        str = "select * from Account where Type = '" & "INCOME" & "' and Mode <> '" & "CASH" & "'"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Account")
        ctr = ds.Tables("Account").Rows.Count - 1
        For i = 0 To ctr
            bak = bak + Val(ds.Tables("Account").Rows(i)(7).ToString)
        Next

        'Expense Bank
        ds.Clear()
        str = "select * from Account where Type = '" & "EXPENSE" & "' and Mode <> '" & "CASH" & "'"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Account")
        ctr = ds.Tables("Account").Rows.Count - 1
        For i = 0 To ctr
            bakp = bakp + Val(ds.Tables("Account").Rows(i)(7).ToString)
        Next

        'Staff PAyment
        ds.Clear()
        str = "select * from Payment"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Payment")
        ctr = ds.Tables("Payment").Rows.Count - 1
        For i = 0 To ctr
            stp = stp + Val(ds.Tables("Payment").Rows(i)(12).ToString)
        Next

        'Fees Colected
        ds.Clear()
        str = "select * from FeesCollection"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "FeesCollection")
        ctr = ds.Tables("FeesCollection").Rows.Count - 1
        For i = 0 To ctr
            fes = fes + Val(ds.Tables("FeesCollection").Rows(i)(6).ToString)
        Next

        'Total Transaction
        ds.Clear()
        str = "select * from Account"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Account")
        ctr = ds.Tables("Account").Rows.Count
        tra = ctr


        TextBox1.Text = inc - exp
        TextBox2.Text = cas - casp
        TextBox3.Text = bak - bakp
        TextBox11.Text = tra
        TextBox12.Text = exp
        TextBox13.Text = inc
        TextBox14.Text = stp
        TextBox15.Text = exp - stp
        TextBox16.Text = fes
        TextBox17.Text = inc - fes


        'Total Transaction Last 30 Days
        ds.Clear()
        tra = 0
        str = "select * from Account where TDate BETWEEN '" & DateTimePicker1.Value.DayOfYear & "' AND '" & DateTimePicker2.Value.DayOfYear & "' ORDER BY ID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Account")
        ctr = ds.Tables("Account").Rows.Count - 1
        For i = 0 To ctr
            tra = tra + 1
        Next

        'Expense for last 30 Days
        ds.Clear()
        str = "select * from Account where Type = '" & "EXPENSE" & "' and TDate BETWEEN '" & DateTimePicker1.Text & "'  AND '" & DateTimePicker2.Text & "' ORDER BY ID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Account")
        ctr = ds.Tables("Account").Rows.Count - 1
        For i = 0 To ctr
            exp = exp + Val(ds.Tables("Account").Rows(i)(7).ToString)
        Next

        'Income for last 30 Days
        ds.Clear()
        str = "select * from Account where Type = '" & "INCOME" & "' and TDate BETWEEN '" & DateTimePicker1.Text & "'  AND '" & DateTimePicker2.Text & "' ORDER BY ID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Account")
        ctr = ds.Tables("Account").Rows.Count - 1
        For i = 0 To ctr
            inc = inc + Val(ds.Tables("Account").Rows(i)(7).ToString)
        Next

        'Staff PAyment last 30 Days
        ds.Clear()
        str = "select * from Payment where PDate BETWEEN '" & DateTimePicker1.Text & "'  AND '" & DateTimePicker2.Text & "' ORDER BY PID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Payment")
        ctr = ds.Tables("Payment").Rows.Count - 1
        For i = 0 To ctr
            stp = stp + Val(ds.Tables("Payment").Rows(i)(12).ToString)
        Next

        'Fees Colected last 30 Days
        ds.Clear()
        str = "select * from FeesCollection where FCDate BETWEEN '" & DateTimePicker1.Text & "'  AND '" & DateTimePicker2.Text & "' ORDER BY FID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "FeesCollection")
        ctr = ds.Tables("FeesCollection").Rows.Count - 1
        For i = 0 To ctr
            fes = fes + Val(ds.Tables("FeesCollection").Rows(i)(6).ToString)
        Next

        TextBox4.Text = tra
        TextBox5.Text = exp
        TextBox6.Text = inc
        TextBox7.Text = stp
        TextBox8.Text = exp - stp
        TextBox9.Text = fes
        TextBox10.Text = inc - fes
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
              
        Dim er As Integer = 0
        PrintForm.MdiParent = Home
        Dim co As Integer
        co = 0
        'Report
        If er = 0 Then
            Dim cr As New AccountReport
            Try
                'All Account Detail
                AS1 = TextBox2.Text
                AS2 = TextBox3.Text
                AS3 = TextBox1.Text
                AS4 = TextBox4.Text
                AS5 = TextBox9.Text
                AS6 = TextBox7.Text
                AS7 = TextBox10.Text
                AS8 = TextBox8.Text
                AS9 = TextBox6.Text
                AS10 = TextBox5.Text
                AS11 = TextBox11.Text
                AS12 = TextBox16.Text
                AS13 = TextBox14.Text
                AS14 = TextBox17.Text
                AS15 = TextBox15.Text
                AS16 = TextBox13.Text
                AS17 = TextBox12.Text
            Catch ex As Exception
                MsgBox("No Acount Detail Found.")
            End Try
            Try
                If co = 0 Then
                    'cr.SetDataSource(ds)
                    PrintForm.CrystalReportViewer1.RefreshReport()
                    cr.SetParameterValue("AS1", AS1)
                    cr.SetParameterValue("AS2", AS2)
                    cr.SetParameterValue("AS3", AS3)
                    cr.SetParameterValue("AS4", AS4)
                    cr.SetParameterValue("AS5", AS5)
                    cr.SetParameterValue("AS6", AS6)
                    cr.SetParameterValue("AS7", AS7)
                    cr.SetParameterValue("AS8", AS8)
                    cr.SetParameterValue("AS9", AS9)
                    cr.SetParameterValue("AS10", AS10)
                    cr.SetParameterValue("AS11", AS11)
                    cr.SetParameterValue("AS12", AS12)
                    cr.SetParameterValue("AS13", AS13)
                    cr.SetParameterValue("AS14", AS14)
                    cr.SetParameterValue("AS15", AS15)
                    cr.SetParameterValue("AS16", AS16)
                    cr.SetParameterValue("AS17", AS17)
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