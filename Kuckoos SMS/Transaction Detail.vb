Imports System.Data.OleDb
Public Class Transaction_Detail
    Dim er As Integer
    Dim TRF1, TRF2, TRF3, TRF4, TRF5, TRF6, TRF7, TRF8 As String
    Private Sub Transaction_Detail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub

    Private Sub Transaction_Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds.Clear()
        DateTimePicker1.Value = DateTime.Now
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Module1.conn()
        cn.Open()
        er = 1
        Dim ctr, i As Integer
        ds.Clear()
        str = "select * from Account"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Account")
        ctr = ds.Tables("Account").Rows.Count - 1
        For i = 0 To ctr
            ComboBox2.Items.Add(ds.Tables("Account").Rows(i)(0).ToString)
        Next
        
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()

        If er = 1 Then
            ComboBox2.Items.Clear()
            ComboBox2.Text = "Select"

            Dim ctr, i As Integer
            ds.Clear()
            str = "select * from Account where Type = '" & ComboBox1.Text & "'"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Account")
            ctr = ds.Tables("Account").Rows.Count - 1
            For i = 0 To ctr
                ComboBox2.Items.Add(ds.Tables("Account").Rows(i)(0).ToString)
            Next
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If er = 1 Then
            ComboBox2.Items.Clear()
            ComboBox2.Text = "Select"

            Dim ctr, i As Integer
            ds.Clear()
            str = "select * from Account where TDate = '" & DateTimePicker1.Text & "'"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Account")
            ctr = ds.Tables("Account").Rows.Count - 1
            For i = 0 To ctr
                ComboBox2.Items.Add(ds.Tables("Account").Rows(i)(0).ToString)
            Next
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged       
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()

        er = 0
        Dim ctr, i As Integer
        ds.Clear()
        str = "select * from Account where ID = '" & ComboBox2.Text & "'"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Account")
        ctr = ds.Tables("Account").Rows.Count - 1
        For i = 0 To ctr
            ComboBox1.Text = ds.Tables("Account").Rows(i)(1).ToString
            DateTimePicker1.Text = ds.Tables("Account").Rows(i)(2).ToString
            TextBox1.Text = ds.Tables("Account").Rows(i)(3).ToString
            TextBox2.Text = ds.Tables("Account").Rows(i)(4).ToString
            TextBox3.Text = ds.Tables("Account").Rows(i)(6).ToString
            TextBox4.Text = ds.Tables("Account").Rows(i)(7).ToString
            TextBox5.Text = ds.Tables("Account").Rows(i)(5).ToString
        Next
        er = 1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim er As Integer = 0
        PrintForm.MdiParent = Home
        Dim co As Integer
        co = 0
        'Report
        If ComboBox2.Text = "" Or ComboBox2.Text = "Select" Then
            MsgBox("Please Select Transaction ID. First.")
            er = 1
        End If
        If er = 0 Then
            Dim cr As New TransactionDetail
            Try
                'Transaction Detail
                TRF1 = ComboBox2.Text
                TRF2 = ComboBox1.Text
                TRF3 = DateTimePicker1.Text
                TRF4 = TextBox1.Text
                TRF5 = TextBox2.Text
                TRF6 = TextBox3.Text
                TRF7 = TextBox4.Text
                TRF8 = TextBox5.Text
            Catch ex As Exception
                MsgBox("No Transaction Detail Found. Select Transaction Id.")
            End Try
            Try
                If co = 0 Then
                    'cr.SetDataSource(ds)
                    PrintForm.CrystalReportViewer1.RefreshReport()
                    cr.SetParameterValue("TRS1", TRF1)
                    cr.SetParameterValue("TRS2", TRF2)
                    cr.SetParameterValue("TRS3", TRF3)
                    cr.SetParameterValue("TRS4", TRF4)
                    cr.SetParameterValue("TRS5", TRF5)
                    cr.SetParameterValue("TRS6", TRF6)
                    cr.SetParameterValue("TRS7", TRF7)
                    cr.SetParameterValue("TRS8", TRF8)
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