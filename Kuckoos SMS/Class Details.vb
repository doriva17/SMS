Imports System.Data.OleDb
Public Class Class_Details
    Dim cond As Integer
    Private Sub Class_Details_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub

    Private Sub Class_Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds.Clear()

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Module1.conn()
        cond = 0
        cn.Open()
        Dim ctr, i As Integer

        ds.Clear()
        str = "select * from Class"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Class")
        ctr = ds.Tables("Class").Rows.Count - 1
        For i = 0 To ctr
            ComboBox1.Items.Add(ds.Tables("Class").Rows(i)(0).ToString)
        Next

        ds.Clear()
        str = "select * from Class"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Class")
        ctr = ds.Tables("Class").Rows.Count - 1
        For i = 0 To ctr
            ComboBox2.Items.Add(ds.Tables("Class").Rows(i)(1).ToString)
        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim ctr, i As Integer
        
            TextBox1.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            DataGridView1.Rows.Clear()


            ds.Clear()
            str = "select * from Class where CID = '" & ComboBox1.Text & "'"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Class")
            ctr = ds.Tables("Class").Rows.Count - 1
            For i = 0 To ctr
                ComboBox2.Text = ds.Tables("Class").Rows(i)(1).ToString
                TextBox1.Text = ds.Tables("Class").Rows(i)(3).ToString
                TextBox4.Text = ds.Tables("Class").Rows(i)(4).ToString
                TextBox5.Text = ds.Tables("Class").Rows(i)(2).ToString
            Next



        ds.Clear()
        str = "select * from Student where AdmitedTo = '" & ComboBox2.Text & "'"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Student")
        ctr = ds.Tables("Student").Rows.Count - 1
        For i = 0 To ctr
            DataGridView1.Rows.Add(ds.Tables("Student").Rows(i)(0).ToString, ds.Tables("Student").Rows(i)(19).ToString, ds.Tables("Student").Rows(i)(1).ToString, ds.Tables("Student").Rows(i)(5).ToString, ds.Tables("Student").Rows(i)(2).ToString)
        Next
        TextBox6.Text = ctr + 1
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim ctr, i As Integer
  
            ds.Clear()
            str = "select * from Class where CName = '" & ComboBox2.Text & "'"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Class")
            ctr = ds.Tables("Class").Rows.Count - 1
            For i = 0 To ctr
                ComboBox1.Text = ds.Tables("Class").Rows(i)(0).ToString              
            Next

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox1.Text = "Select"
        ComboBox2.Text = "Select"
        TextBox1.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        DataGridView1.Rows.Clear()
        cond = 0

        Dim ctr, i As Integer
        ds.Clear()
        str = "select * from Class"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Class")
        ctr = ds.Tables("Class").Rows.Count - 1
        For i = 0 To ctr
            ComboBox1.Items.Add(ds.Tables("Class").Rows(i)(0).ToString)
        Next

        ds.Clear()
        str = "select * from Class"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Class")
        ctr = ds.Tables("Class").Rows.Count - 1
        For i = 0 To ctr
            ComboBox2.Items.Add(ds.Tables("Class").Rows(i)(1).ToString)
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim er As Integer = 0
        PrintForm.MdiParent = Home
        If ComboBox1.Text = "Select" Or ComboBox1.Text = "" Then
            MsgBox("Select Class Id for Student Details.")
            er = 1
        End If
        Dim ctr, co As Integer
        co = 0
        'Report
        If er = 0 Then
            Dim cr As New ClassDetail
            ds.Clear()
            Try
                'Staff Detail
                str = "select * from Class where CID = '" & ComboBox1.Text & "' ORDER BY CID ASC"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.SelectCommand.ExecuteNonQuery()
                da.Fill(ds, "Class")
                ctr = ds.Tables("Class").Rows.Count
                If ctr = 0 Then
                    co = 1
                    MsgBox("No Class Detail Found.")
                End If

                'Student Detail
                str = "select * from Student where AdmitedTo = '" & ComboBox2.Text & "' ORDER BY RegNo ASC"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.SelectCommand.ExecuteNonQuery()
                da.Fill(ds, "Student")
                ctr = ds.Tables("Student").Rows.Count
            Catch ex As Exception
                MsgBox("No Class Detail Found.")
            End Try
            Try
                If co = 0 Then
                    cr.SetDataSource(ds)
                    PrintForm.CrystalReportViewer1.RefreshReport()
                    cr.SetParameterValue("stud", TextBox6.Text)
                    PrintForm.CrystalReportViewer1.ReportSource = cr
                    PrintForm.Show()
                Else
                    MsgBox("Probleam in Preparing Print.")
                End If
            Catch ex As Exception
                MsgBox("Unable To Create Report.")
            End Try
        End If


    End Sub
End Class