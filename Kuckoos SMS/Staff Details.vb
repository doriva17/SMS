Imports System.Data.OleDb
Public Class Staff_Details
    Dim che As Integer

    Private Sub Staff_Details_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub
    Private Sub Staff_Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'KuckoosDBDataSet.Staff' table. You can move, or remove it, as needed.       
        ds.Clear()

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        che = 1
        Module1.conn()
        cn.Open()
        Dim ctr, i As Integer

        ds.Clear()
        str = "select * from Payment ORDER BY PID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Payment")
        ctr = ds.Tables("Payment").Rows.Count - 1
        For i = 0 To ctr
            DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(11).ToString, ds.Tables("Payment").Rows(i)(12).ToString)
        Next

        ds.Clear()
        str = "select * from Staff ORDER BY EmpID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Staff")
        ctr = ds.Tables("Staff").Rows.Count - 1
        For i = 0 To ctr
            ComboBox1.Items.Add(ds.Tables("Staff").Rows(i)(0).ToString)
            ComboBox2.Items.Add(ds.Tables("Staff").Rows(i)(1).ToString)
        Next


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If che = 1 Then


            Dim ctr, i As Integer
            ds.Clear()
            str = "select * from Staff where EmpName = '" & ComboBox2.Text & "' ORDER BY EmpID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Staff")
            ctr = ds.Tables("Staff").Rows.Count - 1
            For i = 0 To ctr
                ComboBox1.Text = ds.Tables("Staff").Rows(i)(0).ToString
            Next
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Label11.Visible = False
        Label12.Visible = False
        TextBox7.Visible = False
        TextBox8.Visible = False
        che = 0
        Dim ctr, i As Integer
        ds.Clear()
        str = "select * from Staff where EmpID = '" & ComboBox1.Text & "' ORDER BY EmpID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Staff")
        ctr = ds.Tables("Staff").Rows.Count - 1
        For i = 0 To ctr
            TextBox1.Text = ds.Tables("Staff").Rows(i)(2).ToString
            TextBox2.Text = ds.Tables("Staff").Rows(i)(3).ToString
            TextBox3.Text = ds.Tables("Staff").Rows(i)(9).ToString
            TextBox4.Text = ds.Tables("Staff").Rows(i)(5).ToString
            TextBox5.Text = ds.Tables("Staff").Rows(i)(6).ToString
            TextBox6.Text = ds.Tables("Staff").Rows(i)(4).ToString
            TextBox9.Text = ds.Tables("Staff").Rows(i)(7).ToString
            ComboBox2.Text = ds.Tables("Staff").Rows(i)(1).ToString
            ComboBox3.Text = ds.Tables("Staff").Rows(i)(8).ToString
        Next

        DataGridView1.Rows.Clear()
        ds.Clear()
        str = "select * from Payment where EmpID = '" & ComboBox1.Text & "' ORDER BY PID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Payment")
        ctr = ds.Tables("Payment").Rows.Count - 1
        For i = 0 To ctr
            DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(11).ToString, ds.Tables("Payment").Rows(i)(12).ToString)
        Next

        If ComboBox3.Text = "TEACHING STAFF" Then
            Label11.Visible = True
            Label12.Visible = True
            TextBox7.Visible = True
            TextBox8.Visible = True
            TextBox7.Clear()
            TextBox8.Clear()

            'Class
            ds.Clear()
            str = "select * from StaffClass where SID = '" & ComboBox1.Text & "' ORDER BY SCID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "StaffClass")
            ctr = ds.Tables("StaffClass").Rows.Count - 1
            For i = 0 To ctr               
                TextBox8.Text = TextBox8.Text + ds.Tables("StaffClass").Rows(i)(2).ToString + ", "
            Next

            'Subject
            ds.Clear()
            str = "select * from StaffSubject where SID = '" & ComboBox1.Text & "' ORDER BY SSID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "StaffSubject")
            ctr = ds.Tables("StaffSubject").Rows.Count - 1
            For i = 0 To ctr
                TextBox7.Text = TextBox7.Text + ds.Tables("StaffSubject").Rows(i)(2).ToString + ", "
            Next
        End If

        che = 1
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If che = 1 Then
            ComboBox1.Items.Clear()
            ComboBox2.Items.Clear()
            Label11.Visible = False
            Label12.Visible = False
            TextBox7.Visible = False
            TextBox8.Visible = False
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox8.Clear()
            TextBox9.Clear()
            DataGridView1.Rows.Clear()

            Dim ctr, i As Integer
            ds.Clear()
            str = "select * from Staff where EmpType = '" & ComboBox3.Text & "' ORDER BY EmpID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Staff")
            ctr = ds.Tables("Staff").Rows.Count - 1
            For i = 0 To ctr
                ComboBox1.Items.Add(ds.Tables("Staff").Rows(i)(0).ToString)
                ComboBox2.Items.Add(ds.Tables("Staff").Rows(i)(1).ToString)
            Next

            ds.Clear()
            str = "select * from Payment where EmpType = '" & ComboBox3.Text & "' ORDER BY PID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Payment")
            ctr = ds.Tables("Payment").Rows.Count - 1
            For i = 0 To ctr
                DataGridView1.Rows.Add(ds.Tables("Payment").Rows(i)(0).ToString, ds.Tables("Payment").Rows(i)(1).ToString, ds.Tables("Payment").Rows(i)(6).ToString, ds.Tables("Payment").Rows(i)(7).ToString, ds.Tables("Payment").Rows(i)(9).ToString, ds.Tables("Payment").Rows(i)(10).ToString, ds.Tables("Payment").Rows(i)(14).ToString, ds.Tables("Payment").Rows(i)(11).ToString, ds.Tables("Payment").Rows(i)(12).ToString)
            Next

            ComboBox1.Text = "Select"
            ComboBox2.Text = "Select"

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim er As Integer = 0
        PrintForm.MdiParent = Home
        If ComboBox1.Text = "Select" Or ComboBox1.Text = "" Then
            MsgBox("Select Staff Id for Student Details.")
            er = 1
        End If
        Dim ctr, co As Integer
        co = 0
        If ComboBox3.Text = "TEACHING STAFF" Then
            'Teaching Staff Report
            If er = 0 Then
                Dim cr As New StaffDetails
                ds.Clear()
                Try
                    'Staff Detail
                    str = "select * from Staff where EmpID = '" & ComboBox1.Text & "' ORDER BY EmpID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Staff")
                    ctr = ds.Tables("Staff").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Staff Detail Found.")
                    End If

                    'Staff Payment Detail
                    str = "select * from Payment where EmpID = '" & ComboBox1.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count
                    
                    'Staff Subjects Detail
                    str = "select * from StaffSubject where SID = '" & ComboBox1.Text & "' ORDER BY SSID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "StaffSubject")
                    ctr = ds.Tables("StaffSubject").Rows.Count
                    
                    'Staff Class Detail
                    str = "select * from StaffClass where SID = '" & ComboBox1.Text & "' ORDER BY SCID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "StaffClass")
                    ctr = ds.Tables("StaffClass").Rows.Count                  
                Catch ex As Exception
                    MsgBox("No Staff Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try
            End If

        ElseIf ComboBox3.Text = "NON TEACHING STAFF" Then
            'Non Teaching Staff Report
            If er = 0 Then
                Dim cr As New StaaffDetailNon
                ds.Clear()
                Try
                    'Staff Detail
                    str = "select * from Staff where EmpID = '" & ComboBox1.Text & "' ORDER BY EmpID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Staff")
                    ctr = ds.Tables("Staff").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Staff Detail Found.")
                    End If

                    'Staff Payment Detail
                    str = "select * from Payment where EmpID = '" & ComboBox1.Text & "' ORDER BY PID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Payment")
                    ctr = ds.Tables("Payment").Rows.Count

                Catch ex As Exception
                    MsgBox("No Staff Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try
            End If
        End If
    End Sub
End Class