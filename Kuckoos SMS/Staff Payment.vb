Imports System.Data.OleDb
Public Class Staff_Payment
    Dim che, er As Integer
    Dim SPF1, SPF2, SPF3, SPF4, SPF5, SPF6, SPF7, SPF8, SPF9, SPF10, SPF11, SPF12, SPF13, SPF14, SPF15, SPF16, SPF17 As String
    Private Sub Staff_Payment_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub
    Private Sub Staff_Payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds.Clear()

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        che = 0
        Module1.conn()
        cn.Open()
        che = 1
        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now.AddMonths(-1)
        DateTimePicker3.Value = DateTime.Now
        Dim ctr, i As Integer

        ds.Clear()
        str = "select * from Payment ORDER BY PID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Payment")
        ctr = ds.Tables("Payment").Rows.Count - 1
        For i = 0 To ctr
            DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ds.Tables("Payment").Rows(i)(11).ToString, ds.Tables("Payment").Rows(i)(12).ToString)
        Next

        ds.Clear()
        str = "select * from Payment"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Payment")
        Dim LastNo As Integer
        LastNo = ds.Tables("Payment").Rows.Count + 1
        If LastNo >= 0 Then
            TextBox1.Text = "PID" & LastNo
        Else
            TextBox1.Text = "PID" & 0
        End If

        ds.Clear()
        str = "select * from Staff ORDER BY EmpID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Staff")
        ctr = ds.Tables("Staff").Rows.Count - 1
        For i = 0 To ctr
            ComboBox2.Items.Add(ds.Tables("Staff").Rows(i)(0).ToString)
            ComboBox3.Items.Add(ds.Tables("Staff").Rows(i)(1).ToString)
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        che = 0
        Dim ctr, i As Integer
        ds.Clear()
        str = "select * from Staff where EmpID = '" & ComboBox2.Text & "' ORDER BY EmpID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Staff")
        ctr = ds.Tables("Staff").Rows.Count - 1
        For i = 0 To ctr
            ComboBox1.Text = ds.Tables("Staff").Rows(i)(8).ToString
            ComboBox3.Text = ds.Tables("Staff").Rows(i)(1).ToString
            TextBox2.Text = ds.Tables("Staff").Rows(i)(2).ToString
            TextBox3.Text = ds.Tables("Staff").Rows(i)(9).ToString
        Next
        DataGridView1.Rows.Clear()
        ds.Clear()
        str = "select * from Payment where EmpID = '" & ComboBox2.Text & "' ORDER BY PID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Payment")
        ctr = ds.Tables("Payment").Rows.Count - 1
        For i = 0 To ctr
            DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ds.Tables("Payment").Rows(i)(11).ToString, ds.Tables("Payment").Rows(i)(12).ToString)
        Next
        che = 1
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If che = 1 Then
            Dim ctr, i As Integer
            ds.Clear()
            str = "select * from Staff where EmpName = '" & ComboBox3.Text & "' ORDER BY EmpID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Staff")
            ctr = ds.Tables("Staff").Rows.Count - 1
            For i = 0 To ctr
                ComboBox2.Text = ds.Tables("Staff").Rows(i)(0).ToString
            Next
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim ctr, i As Integer
        If che = 1 Then
            DataGridView1.Rows.Clear()
            ds.Clear()
            str = "select * from Payment where EmpType = '" & ComboBox1.Text & "' ORDER BY PID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Payment")
            ctr = ds.Tables("Payment").Rows.Count - 1
            For i = 0 To ctr
                DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ds.Tables("Payment").Rows(i)(11).ToString, ds.Tables("Payment").Rows(i)(12).ToString)
            Next

            ComboBox2.Items.Clear()
            ComboBox3.Items.Clear()

            ds.Clear()
            str = "select * from Staff where EmpType = '" & ComboBox1.Text & "' ORDER BY EmpID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Staff")
            ctr = ds.Tables("Staff").Rows.Count - 1
            For i = 0 To ctr
                ComboBox2.Items.Add(ds.Tables("Staff").Rows(i)(0).ToString)
                ComboBox3.Items.Add(ds.Tables("Staff").Rows(i)(1).ToString)
            Next
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        'DateTimePicker3.Value = DateTime.Now.AddMonths(-1)

        TextBox4.Text = DateTimePicker3.Value.DayOfYear - DateTimePicker2.Value.DayOfYear

        Dim countsun As Integer = 0
        'Dim countsat As Integer = 0
        'Dim nonholiday As Integer = 0
        Dim totalDays = (DateTimePicker3.Value - DateTimePicker2.Value).Days
        For i = 0 To totalDays
            Dim Weekday As DayOfWeek = DateTimePicker2.Value.Date.AddDays(i).DayOfWeek
            'If Weekday = DayOfWeek.Saturday Then
            '    countsat += 1
            'End If
            If Weekday = DayOfWeek.Sunday Then
                countsun += 1
            End If
            'If Weekday <> DayOfWeek.Saturday AndAlso Weekday <> DayOfWeek.Sunday Then
            '    nonholiday += 1
            'End If
        Next
        TextBox5.Text = Val(TextBox4.Text) - countsun
        TextBox6.Text = TextBox5.Text
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim pe As Integer
        Dim tot As Integer
        Dim ded As Integer
        pe = Val(TextBox3.Text) / Val(TextBox5.Text)
        TextBox7.Text = pe

        If TextBox5.Text = TextBox6.Text Then
            TextBox9.Text = TextBox3.Text
            TextBox8.Text = "0"
        Else
            tot = Val(TextBox7.Text) * Val(TextBox6.Text)
            TextBox9.Text = tot
            ded = Val(TextBox3.Text) - Val(TextBox9.Text)
            TextBox8.Text = ded
        End If

    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        Dim pe As Integer
        Dim tot As Integer
        Dim ded As Integer
        pe = Val(TextBox3.Text) / Val(TextBox5.Text)
        TextBox7.Text = pe

        If TextBox5.Text = TextBox6.Text Then
            TextBox9.Text = TextBox3.Text
            TextBox8.Text = "0"
        Else
            tot = Val(TextBox7.Text) * Val(TextBox6.Text)
            TextBox9.Text = tot
            ded = Val(TextBox3.Text) - Val(TextBox9.Text)
            TextBox8.Text = ded
        End If
    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        TextBox12.Text = Val(TextBox8.Text) + Val(TextBox11.Text)
        'TextBox9.Text = Val(TextBox3.Text) - Val(TextBox8.Text) - Val(TextBox11.Text)
    End Sub

    Private Sub TextBox11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox11.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        TextBox12.Text = Val(TextBox8.Text) + Val(TextBox11.Text)
        'TextBox9.Text = Val(TextBox3.Text) - Val(TextBox8.Text) - Val(TextBox11.Text)
    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged
        TextBox9.Text = Val(TextBox3.Text) - Val(TextBox12.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        er = 0
        che = 0
        If TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox8.Text = "" Or TextBox11.Text = "" Or TextBox10.Text = "" Or ComboBox2.Text = "Select" Or ComboBox4.Text = "Select" Then
            er = 1
            MsgBox("Please Fill All The Detail's.")
        End If

        'Transaction ID
        ds.Clear()
        str = "select * from Account"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Account")
        Dim LastNo1 As Integer
        Dim tid As String
        LastNo1 = ds.Tables("Account").Rows.Count + 1
        If LastNo1 >= 0 Then
            tid = "TID" & LastNo1
        Else
            tid = "TID" & 0
        End If

        If er = 0 Then
            Try
                'Payment Table Insert Command
                cmd.Connection = cn
                cmd.CommandText = "insert into Payment(PID,PDate,EmpID,EmpName,EmpType,Sallary,DFrom,DTo,TDays,WDays,DPresent,Deduction,Amount,Description,PMode,OtherDed) values('" & TextBox1.Text & "','" & DateTimePicker1.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & ComboBox1.Text & "','" & TextBox3.Text & "','" & DateTimePicker2.Text & "','" & DateTimePicker3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox12.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "','" & ComboBox4.Text & "','" & TextBox11.Text & "')"
                cmd.ExecuteNonQuery()

                'Account Table Insert Command
                cmd.Connection = cn
                cmd.CommandText = "insert into Account(ID,Type,TDate,TFrom,TTo,Description,Mode,Amount) values('" & tid & "','" & "EXPENSE" & "','" & DateTimePicker1.Text & "','" & "KUCKOOS" & "','" & ComboBox3.Text & "','" & TextBox10.Text & "','" & ComboBox4.Text & "','" & TextBox9.Text & "')"
                cmd.ExecuteNonQuery()

                Dim result As Integer = MessageBox.Show("New Payment Completed. Want To Print The Payment Slip.", "Added", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
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
                    ComboBox1.Text = "Select"
                    ComboBox2.Text = "Select"
                    ComboBox3.Text = "Select Employee Name"
                    ComboBox4.Text = "Select"
                    DateTimePicker1.Value = DateTime.Now
                    DateTimePicker2.Value = DateTime.Now.AddMonths(-1)
                    DateTimePicker3.Value = DateTime.Now

                    Dim ctr, i As Integer
                    ds.Clear()
                    str = "select * from Payment ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count - 1
                    For i = 0 To ctr
                        DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ds.Tables("Payment").Rows(i)(11).ToString, ds.Tables("Payment").Rows(i)(12).ToString)
                    Next

                    ds.Clear()
                    str = "select * from Payment"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Payment")
                    Dim LastNo As Integer
                    LastNo = ds.Tables("Payment").Rows.Count + 1
                    If LastNo >= 0 Then
                        TextBox1.Text = "PID" & LastNo
                    Else
                        TextBox1.Text = "PID" & 0
                    End If
                ElseIf result = DialogResult.Yes Then


                    PrintForm.MdiParent = Home
                    Dim co As Integer
                    co = 0
                    'Report
                    Dim cr As New StaffPaymentReport

                    Try

                        'Staff Payment Detail
                        SPF1 = ComboBox1.Text
                        SPF2 = ComboBox2.Text
                        SPF3 = TextBox1.Text
                        SPF4 = ComboBox3.Text
                        SPF5 = TextBox3.Text
                        SPF6 = DateTimePicker1.Text
                        SPF7 = DateTimePicker2.Text
                        SPF8 = DateTimePicker3.Text
                        SPF9 = TextBox4.Text
                        SPF10 = TextBox5.Text
                        SPF11 = TextBox6.Text
                        SPF12 = TextBox8.Text
                        SPF13 = TextBox11.Text
                        SPF14 = TextBox12.Text
                        SPF15 = TextBox7.Text
                        SPF16 = TextBox9.Text
                        SPF17 = TextBox10.Text
                    Catch ex As Exception
                        MsgBox("No Staff Payment Detail Found. Please Select Payment ID.")
                    End Try
                    Try
                        If co = 0 Then
                            PrintForm.CrystalReportViewer1.RefreshReport()
                            cr.SetParameterValue("SPR1", SPF2)
                            cr.SetParameterValue("SPR2", SPF1)
                            cr.SetParameterValue("SPR3", SPF6)
                            cr.SetParameterValue("SPR4", SPF3)
                            cr.SetParameterValue("SPR5", SPF4)
                            cr.SetParameterValue("SPR6", SPF5)
                            cr.SetParameterValue("SPR7", SPF7)
                            cr.SetParameterValue("SPR8", SPF8)
                            cr.SetParameterValue("SPR9", SPF9)
                            cr.SetParameterValue("SPR10", SPF10)
                            cr.SetParameterValue("SPR11", SPF11)
                            cr.SetParameterValue("SPR12", SPF12)
                            cr.SetParameterValue("SPR13", SPF13)
                            cr.SetParameterValue("SPR14", SPF14)
                            cr.SetParameterValue("SPR15", SPF15)
                            cr.SetParameterValue("SPR16", SPF16)
                            cr.SetParameterValue("SPR17", SPF17)
                            PrintForm.CrystalReportViewer1.ReportSource = cr
                            PrintForm.Show()
                        Else
                            'MsgBox("Probleam in Preparing Print.")
                        End If
                    Catch ex As Exception
                        MsgBox("Unable To Create Report.")
                    End Try





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
                    ComboBox1.Text = "Select"
                    ComboBox2.Text = "Select"
                    ComboBox3.Text = "Select Employee Name"
                    ComboBox4.Text = "Select"
                    DateTimePicker1.Value = DateTime.Now
                    DateTimePicker2.Value = DateTime.Now.AddMonths(-1)
                    DateTimePicker3.Value = DateTime.Now

                    Dim ctr, i As Integer
                    ds.Clear()
                    str = "select * from Payment ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count - 1
                    For i = 0 To ctr
                        DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ds.Tables("Payment").Rows(i)(11).ToString, ds.Tables("Payment").Rows(i)(12).ToString)
                    Next

                    ds.Clear()
                    str = "select * from Payment"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Payment")
                    Dim LastNo As Integer
                    LastNo = ds.Tables("Payment").Rows.Count + 1
                    If LastNo >= 0 Then
                        TextBox1.Text = "PID" & LastNo
                    Else
                        TextBox1.Text = "PID" & 0
                    End If
                End If
            Catch ex As Exception
                MsgBox(" Transaction Not Added.")
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
                ComboBox1.Text = "Select"
                ComboBox2.Text = "Select"
                ComboBox3.Text = "Select Employee Name"
                ComboBox4.Text = "Select"
                DateTimePicker1.Value = DateTime.Now
                DateTimePicker2.Value = DateTime.Now.AddMonths(-1)
                DateTimePicker3.Value = DateTime.Now

                Dim ctr, i As Integer
                ds.Clear()
                str = "select * from Payment ORDER BY PID ASC"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.Fill(ds, "Payment")
                ctr = ds.Tables("Payment").Rows.Count - 1
                For i = 0 To ctr
                    DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ds.Tables("Payment").Rows(i)(11).ToString, ds.Tables("Payment").Rows(i)(12).ToString)
                Next

                ds.Clear()
                str = "select * from Payment"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.Fill(ds, "Payment")
                Dim LastNo As Integer
                LastNo = ds.Tables("Payment").Rows.Count + 1
                If LastNo >= 0 Then
                    TextBox1.Text = "PID" & LastNo
                Else
                    TextBox1.Text = "PID" & 0
                End If
            End Try
            'insert closed
        End If
        che = 1
    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.ValueChanged
        'DateTimePicker3.Value = DateTime.Now.AddMonths(-1)

        TextBox4.Text = DateTimePicker3.Value.DayOfYear - DateTimePicker2.Value.DayOfYear

        Dim countsun As Integer = 0
        'Dim countsat As Integer = 0
        'Dim nonholiday As Integer = 0
        Dim totalDays = (DateTimePicker3.Value - DateTimePicker2.Value).Days
        For i = 0 To totalDays
            Dim Weekday As DayOfWeek = DateTimePicker2.Value.Date.AddDays(i).DayOfWeek
            'If Weekday = DayOfWeek.Saturday Then
            '    countsat += 1
            'End If
            If Weekday = DayOfWeek.Sunday Then
                countsun += 1
            End If
            'If Weekday <> DayOfWeek.Saturday AndAlso Weekday <> DayOfWeek.Sunday Then
            '    nonholiday += 1
            'End If
        Next
        TextBox5.Text = Val(TextBox4.Text) - countsun
        TextBox6.Text = TextBox5.Text
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

    End Sub
End Class