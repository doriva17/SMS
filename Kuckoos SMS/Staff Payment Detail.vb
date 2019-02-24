Imports System.Data.OleDb
Public Class Staff_Payment_Detail
    Dim che As Integer
    Dim SPF1, SPF2, SPF3, SPF4, SPF5, SPF6, SPF7, SPF8, SPF9, SPF10, SPF11, SPF12, SPF13, SPF14, SPF15, SPF16, SPF17 As String
    Private Sub Staff_Payment_Detail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub
    Private Sub Staff_Payment_Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds.Clear()

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        che = 1
        Module1.conn()
        cn.Open()
        Dim ctr, i, ded As Integer

        ds.Clear()
        str = "select * from Payment ORDER BY PID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Payment")
        ctr = ds.Tables("Payment").Rows.Count - 1
        For i = 0 To ctr
            ded = Val(ds.Tables("Payment").Rows(i)(11).ToString) + Val(ds.Tables("Payment").Rows(i)(15).ToString)
            ComboBox3.Items.Add(ds.Tables("Payment").Rows(i)(0).ToString)
            DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(11).ToString, ds.Tables("Payment").Rows(i)(12).ToString)
        Next

        ds.Clear()
        str = "select * from Staff ORDER BY EmpID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Staff")
        ctr = ds.Tables("Staff").Rows.Count - 1
        For i = 0 To ctr
            ComboBox2.Items.Add(ds.Tables("Staff").Rows(i)(0).ToString)
            ComboBox4.Items.Add(ds.Tables("Staff").Rows(i)(1).ToString)
        Next

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
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

        che = 0
        Dim ctr, i, pe As Integer
        ds.Clear()
        str = "select * from Payment where PID = '" & ComboBox3.Text & "' ORDER BY EmpID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Payment")
        ctr = ds.Tables("Payment").Rows.Count - 1
        For i = 0 To ctr
            ComboBox1.Text = ds.Tables("Payment").Rows(i)(4).ToString
            ComboBox2.Text = ds.Tables("Payment").Rows(i)(2).ToString
            ComboBox4.Text = ds.Tables("Payment").Rows(i)(3).ToString
            TextBox1.Text = ds.Tables("Payment").Rows(i)(5).ToString
            TextBox2.Text = ds.Tables("Payment").Rows(i)(1).ToString
            TextBox3.Text = ds.Tables("Payment").Rows(i)(6).ToString
            TextBox4.Text = ds.Tables("Payment").Rows(i)(7).ToString
            TextBox5.Text = ds.Tables("Payment").Rows(i)(8).ToString
            TextBox6.Text = ds.Tables("Payment").Rows(i)(9).ToString
            TextBox7.Text = ds.Tables("Payment").Rows(i)(10).ToString

            TextBox9.Text = ds.Tables("Payment").Rows(i)(15).ToString
            TextBox12.Text = ds.Tables("Payment").Rows(i)(12).ToString
            TextBox13.Text = ds.Tables("Payment").Rows(i)(13).ToString
            TextBox10.Text = ds.Tables("Payment").Rows(i)(11).ToString
        Next

        TextBox8.Text = Val(TextBox10.Text) - Val(TextBox9.Text)
        pe = Val(TextBox1.Text) / Val(TextBox6.Text)
        TextBox11.Text = pe
        che = 1
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
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

        Dim ctr, i, ded As Integer
        If che = 1 Then
            DataGridView1.Rows.Clear()
            ds.Clear()
            str = "select * from Payment where EmpType = '" & ComboBox1.Text & "' ORDER BY PID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Payment")
            ctr = ds.Tables("Payment").Rows.Count - 1
            For i = 0 To ctr
                ded = Val(ds.Tables("Payment").Rows(i)(11).ToString) + Val(ds.Tables("Payment").Rows(i)(15).ToString)
                DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(11).ToString, ds.Tables("Payment").Rows(i)(12).ToString)
            Next

            ComboBox2.Items.Clear()
            ComboBox3.Items.Clear()
            ComboBox4.Items.Clear()
            ComboBox2.Text = "Select"
            ComboBox3.Text = "Select"
            ComboBox4.Text = "Select"

            ds.Clear()
            str = "select * from Staff where EmpType = '" & ComboBox1.Text & "' ORDER BY EmpID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Staff")
            ctr = ds.Tables("Staff").Rows.Count - 1
            For i = 0 To ctr
                ComboBox2.Items.Add(ds.Tables("Staff").Rows(i)(0).ToString)
                ComboBox4.Items.Add(ds.Tables("Staff").Rows(i)(1).ToString)
            Next

            ds.Clear()
            str = "select * from Payment where EmpType = '" & ComboBox1.Text & "' ORDER BY PID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Payment")
            ctr = ds.Tables("Payment").Rows.Count - 1
            For i = 0 To ctr
                ComboBox3.Items.Add(ds.Tables("Payment").Rows(i)(0).ToString)
            Next
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
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

        Dim ctr, i, ded As Integer
        If che = 1 Then
            che = 0
            DataGridView1.Rows.Clear()
            ds.Clear()
            str = "select * from Payment where EmpID = '" & ComboBox2.Text & "' ORDER BY PID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Payment")
            ctr = ds.Tables("Payment").Rows.Count - 1
            For i = 0 To ctr
                ded = Val(ds.Tables("Payment").Rows(i)(11).ToString) + Val(ds.Tables("Payment").Rows(i)(15).ToString)
                DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(11).ToString, ds.Tables("Payment").Rows(i)(12).ToString)
            Next

            ds.Clear()
            str = "select * from Staff where EmpID = '" & ComboBox2.Text & "' ORDER BY EmpID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Staff")
            ctr = ds.Tables("Staff").Rows.Count - 1
            For i = 0 To ctr
                ComboBox1.Text = ds.Tables("Staff").Rows(i)(8).ToString
                ComboBox4.Text = ds.Tables("Staff").Rows(i)(1).ToString
            Next
            ComboBox3.Items.Clear()
            ComboBox3.Text = "Select"
            ds.Clear()
            str = "select * from Payment where EmpID = '" & ComboBox2.Text & "' ORDER BY PID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Payment")
            ctr = ds.Tables("Payment").Rows.Count - 1
            For i = 0 To ctr
                ComboBox3.Items.Add(ds.Tables("Payment").Rows(i)(0).ToString)
            Next
            che = 1
        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim ctr, i As Integer
        If che = 1 Then
            
            ds.Clear()
            str = "select * from Staff where EmpName = '" & ComboBox4.Text & "' ORDER BY EmpID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Staff")
            ctr = ds.Tables("Staff").Rows.Count - 1
            For i = 0 To ctr
                ComboBox2.Text = ds.Tables("Staff").Rows(i)(0).ToString
            Next
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim er As Integer = 0
        PrintForm.MdiParent = Home
        Dim co As Integer
        co = 0
        'Report
        If ComboBox3.Text = "" Or ComboBox3.Text = "Select" Then
            MsgBox("Please Select Payment ID. Before Proceding.")
            er = 1
        End If
        If er = 0 Then
            Dim cr As New StaffPaymentReport
            Try
                'Staff Payment Detail
                SPF1 = ComboBox1.Text
                SPF2 = ComboBox2.Text
                SPF3 = ComboBox3.Text
                SPF4 = ComboBox4.Text
                SPF5 = TextBox1.Text
                SPF6 = TextBox2.Text
                SPF7 = TextBox3.Text
                SPF8 = TextBox4.Text
                SPF9 = TextBox5.Text
                SPF10 = TextBox6.Text
                SPF11 = TextBox7.Text
                SPF12 = TextBox8.Text
                SPF13 = TextBox9.Text
                SPF14 = TextBox10.Text
                SPF15 = TextBox11.Text
                SPF16 = TextBox12.Text
                SPF17 = TextBox13.Text
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
        End If
    End Sub
End Class