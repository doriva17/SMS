Imports System.Data.OleDb
Public Class Fees_Details
    Dim che As Integer
    Private Sub Fees_Details_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub

    Private Sub Fees_Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds.Clear()

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        che = 0
        Module1.conn()
        cn.Open()

        Dim ctr, i As Integer
        'cn.Open()
        str = "select * from Fees ORDER BY FID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Fees")
        ctr = ds.Tables("Fees").Rows.Count - 1
        For i = 0 To ctr
            DataGridView1.Rows.Add(ds.Tables("Fees").Rows(i)(0).ToString, ds.Tables("Fees").Rows(i)(1).ToString, ds.Tables("Fees").Rows(i)(2).ToString, ds.Tables("Fees").Rows(i)(3).ToString, ds.Tables("Fees").Rows(i)(4).ToString, ds.Tables("Fees").Rows(i)(5).ToString, ds.Tables("Fees").Rows(i)(6).ToString)
        Next
        'cn.Close()

        ds.Clear()
        'cn.Open()
        str = "select * from Class ORDER BY CID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Class")
        ctr = ds.Tables("Class").Rows.Count - 1
        For i = 0 To ctr
            ComboBox4.Items.Add(ds.Tables("Class").Rows(i)(1).ToString)
        Next
        'cn.Close()

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
      
        ComboBox4.Items.Clear()
        ComboBox3.Text = "Select"
        ComboBox4.Text = "Select"
        DataGridView1.Rows.Clear()
        ds.Clear()
        che = 0
        Dim ctr, i As Integer
        'cn.Open()
        str = "select * from Fees ORDER BY FID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Fees")
        ctr = ds.Tables("Fees").Rows.Count - 1
        For i = 0 To ctr
            DataGridView1.Rows.Add(ds.Tables("Fees").Rows(i)(0).ToString, ds.Tables("Fees").Rows(i)(1).ToString, ds.Tables("Fees").Rows(i)(2).ToString, ds.Tables("Fees").Rows(i)(3).ToString, ds.Tables("Fees").Rows(i)(4).ToString, ds.Tables("Fees").Rows(i)(5).ToString, ds.Tables("Fees").Rows(i)(6).ToString)
        Next
        'cn.Close()

        ds.Clear()
        'cn.Open()
        str = "select * from Class ORDER BY CID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Class")
        ctr = ds.Tables("Class").Rows.Count - 1
        For i = 0 To ctr
            ComboBox4.Items.Add(ds.Tables("Class").Rows(i)(1).ToString)
        Next
        'cn.Close()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        
        ds.Clear()
        DataGridView1.Rows.Clear()
        'If che = 0 Or che = 4 Or che = 3 Then
        '    che = 3
        ComboBox4.Text = "Select"
        'End If
        Dim ctr, i As Integer
        'cn.Open()
        str = "select * from Fees where PartPayment = '" & ComboBox3.Text & "' ORDER BY FID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Fees")
        ctr = ds.Tables("Fees").Rows.Count - 1
        For i = 0 To ctr
            DataGridView1.Rows.Add(ds.Tables("Fees").Rows(i)(0).ToString, ds.Tables("Fees").Rows(i)(1).ToString, ds.Tables("Fees").Rows(i)(2).ToString, ds.Tables("Fees").Rows(i)(3).ToString, ds.Tables("Fees").Rows(i)(4).ToString, ds.Tables("Fees").Rows(i)(5).ToString, ds.Tables("Fees").Rows(i)(6).ToString)
        Next
        'cn.Close()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
       
        ComboBox3.Text = "Select"

        ds.Clear()
        DataGridView1.Rows.Clear()
       
        Dim ctr, i As Integer
        'cn.Open()
        str = "select * from Fees where Class = '" & ComboBox4.Text & "' ORDER BY FID ASC"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Fees")
        ctr = ds.Tables("Fees").Rows.Count - 1
        For i = 0 To ctr
            DataGridView1.Rows.Add(ds.Tables("Fees").Rows(i)(0).ToString, ds.Tables("Fees").Rows(i)(1).ToString, ds.Tables("Fees").Rows(i)(2).ToString, ds.Tables("Fees").Rows(i)(3).ToString, ds.Tables("Fees").Rows(i)(4).ToString, ds.Tables("Fees").Rows(i)(5).ToString, ds.Tables("Fees").Rows(i)(6).ToString)
        Next
        
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ctr As Integer
        Dim er As Integer = 0
        Dim cla, clan, par As String
        cla = ""
        clan = ""
        par = ""
        PrintForm.MdiParent = Home
        If ComboBox4.Text = "Select" Or ComboBox4.Text = "" Then
            cla = "ALL"
            clan = "ALL"
        Else
            ds.Clear()
            'cn.Open()
            str = "select * from Class where CName = '" & ComboBox4.Text & "' ORDER BY CID ASC"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Class")
            ctr = ds.Tables("Class").Rows.Count - 1
            For i = 0 To ctr
                cla = ds.Tables("Class").Rows(i)(0).ToString
            Next

            clan = ComboBox4.Text
        End If
        If ComboBox3.Text = "Select" Or ComboBox3.Text = "" Then
            par = "ALL"
        Else
            par = ComboBox3.Text
        End If
        Dim co As Integer
        co = 0
        'Report
        If er = 0 Then
            Dim cr As New FeesDetails
            ds.Clear()
            If cla = "ALL" And par = "ALL" Then
                Try
                    'Exam Detail All
                    str = "select * from Fees ORDER BY FID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Fees")
                    ctr = ds.Tables("Fees").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Fees Detail Found.")
                    End If
                Catch ex As Exception
                    MsgBox("No Fees Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        cr.SetParameterValue("clasid", cla)
                        cr.SetParameterValue("classname", clan)
                        cr.SetParameterValue("ppay", par)
                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        'MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try
            ElseIf cla <> "ALL" And par = "ALL" Then
                Try
                    'Exam Detail
                    str = "select * from Fees where Class = '" & ComboBox4.Text & "' ORDER BY FID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Fees")
                    ctr = ds.Tables("Fees").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Fees Detail Found.")
                    End If
                Catch ex As Exception
                    MsgBox("No Fees Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        cr.SetParameterValue("clasid", cla)
                        cr.SetParameterValue("classname", clan)
                        cr.SetParameterValue("ppay", par)
                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        'MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try
            ElseIf cla = "ALL" And par <> "ALL" Then
                Try
                    'Exam Detail
                    str = "select * from Fees where PartPayment = '" & ComboBox3.Text & "' ORDER BY FID ASC"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.SelectCommand.ExecuteNonQuery()
                    da.Fill(ds, "Fees")
                    ctr = ds.Tables("Fees").Rows.Count
                    If ctr = 0 Then
                        co = 1
                        MsgBox("No Fees Detail Found.")
                    End If
                Catch ex As Exception
                    MsgBox("No Fees Detail Found.")
                End Try
                Try
                    If co = 0 Then
                        cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        cr.SetParameterValue("clasid", cla)
                        cr.SetParameterValue("classname", clan)
                        cr.SetParameterValue("ppay", par)
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

    Private Sub Fees_Details_MdiChildActivate(sender As Object, e As EventArgs) Handles Me.MdiChildActivate

    End Sub
End Class