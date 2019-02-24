Imports System.Data.OleDb
Public Class Fees_Collect
    Dim cond As Integer
    Dim FCF1, FCF2, FCF3, FCF4, FCF5, FCF6, FCF7, FCF8, FCF9, FCF10, FCF11, FCF12 As String
    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Fees_Collect_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub

    Private Sub Fees_Collect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds.Clear()

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Module1.conn()
        cn.Open()

        DateTimePicker1.Value = DateTime.Now
        cond = 0
        'cn.Open()
        str = "select * from FeesCollection"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "FeesCollection")
        Dim LastNo As Integer
        LastNo = ds.Tables("FeesCollection").Rows.Count + 1
        If LastNo >= 0 Then
            TextBox1.Text = "FID" & LastNo
        Else
            TextBox1.Text = "FID" & 0
        End If
        ''cn.Close()
        ds.Clear()
        Dim i, ctr As Integer
        ''cn.Open()
        str = "select * from Class"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Class")
        ctr = ds.Tables("Class").Rows.Count - 1
        For i = 0 To ctr
            ComboBox1.Items.Add(ds.Tables("Class").Rows(i)(1).ToString)
        Next
        ''cn.Close()
        ds.Clear()
        ''cn.Open()
        str = "select * from Student"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Student")
        ctr = ds.Tables("Student").Rows.Count - 1
        For i = 0 To ctr
            ComboBox2.Items.Add(ds.Tables("Student").Rows(i)(0).ToString)
            ComboBox3.Items.Add(ds.Tables("Student").Rows(i)(1).ToString)
        Next
        ''cn.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        Dim i, ctr, ctr1 As Integer
        

        If cond = 0 Then
            cond = 1
            ds.Clear()
            ''cn.Open()
            str = "select * from Student where RegNo = '" & ComboBox2.Text & "'"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Student")
            ctr = ds.Tables("Student").Rows.Count - 1
            For i = 0 To ctr
                ComboBox3.Text = ds.Tables("Student").Rows(i)(1).ToString
                ComboBox1.Text = ds.Tables("Student").Rows(i)(18).ToString
            Next
            ' 'cn.Close()
            cond = 0
        End If
        
        DataGridView1.Rows.Clear()
        TextBox3.Text = 0
        ds.Clear()
        str = "select * from FeesCollection"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "FeesCollection")
        ctr = ds.Tables("FeesCollection").Rows.Count - 1
        For i = 0 To ctr
            If ComboBox2.Text = ds.Tables("FeesCollection").Rows(i)(2).ToString Then
                DataGridView1.Rows.Add(New String() {ds.Tables("FeesCollection").Rows(i)(0).ToString, ds.Tables("FeesCollection").Rows(i)(1).ToString, ds.Tables("FeesCollection").Rows(i)(7).ToString, ds.Tables("FeesCollection").Rows(i)(6).ToString, ds.Tables("FeesCollection").Rows(i)(8).ToString})
                TextBox3.Text = ds.Tables("FeesCollection").Rows(i)(5).ToString
            End If
        Next

        ds.Clear()
        Dim su As Integer = 0
        str = "select * from Fees where Class = '" & ComboBox1.Text & "'"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Fees")
        ctr = ds.Tables("Fees").Rows.Count - 1
        For i = 0 To ctr
            su = su + Val(ds.Tables("Fees").Rows(i)(3).ToString)
        Next
        TextBox2.Text = su - Val(TextBox3.Text)

        Dim asum As Integer = 0
        Dim chu As Integer = 0
        ds.Clear()
        ComboBox4.Items.Clear()
        ComboBox4.Text = "Select"
        ''cn.Open()
        str = "select * from Fees where Class = '" & ComboBox1.Text & "'"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Fees")
        ctr = ds.Tables("Fees").Rows.Count - 1
        For i = 0 To ctr
            chu = 0
            ds1.Clear()
            str = "select * from FeesCollection where ForPaid = '" & ds.Tables("Fees").Rows(i)(2).ToString & "' And PartPay = '" & "NO" & "'"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds1, "FeesCollection")
            ctr1 = ds1.Tables("FeesCollection").Rows.Count
            If ctr1 > 0 Then
                chu = 1
            End If
            If chu = 0 Then
                ds1.Clear()
                str = "select * from FeesCollection where ForPaid = '" & ds.Tables("Fees").Rows(i)(2).ToString & "' And PartPay = '" & "YES" & "'"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.Fill(ds1, "FeesCollection")
                ctr1 = ds1.Tables("FeesCollection").Rows.Count - 1
                For j = 0 To ctr1
                    asum = asum + Val(ds1.Tables("FeesCollection").Rows(i)(6).ToString)
                Next
            End If
            If asum = ds.Tables("Fees").Rows(i)(3).ToString Then
                chu = 1
            End If
            If chu = 1 Then
            Else
                ComboBox4.Items.Add(ds.Tables("Fees").Rows(i)(2).ToString)
            End If
        Next
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'Dim ite As String
        Dim i, ctr As Integer
        ds.Clear()
        ComboBox4.Items.Clear()
        ComboBox4.Text = "Select"
        ''cn.Open()
        str = "select * from Fees where Class = '" & ComboBox1.Text & "'"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Fees")
        ctr = ds.Tables("Fees").Rows.Count - 1
        For i = 0 To ctr
            ComboBox4.Items.Add(ds.Tables("Fees").Rows(i)(2).ToString)
        Next
        ''cn.Close()


        If cond = 0 Then
            cond = 1
            ds.Clear()
            ComboBox2.Items.Clear()
            ComboBox3.Items.Clear()
            ComboBox2.Text = "Select"
            ComboBox3.Text = "Select"
            ''cn.Open()
            str = "select * from Student where AdmitedTo ='" & ComboBox1.Text & "'"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Student")
            ctr = ds.Tables("Student").Rows.Count - 1
            For i = 0 To ctr
                ComboBox2.Items.Add(ds.Tables("Student").Rows(i)(0).ToString)
                ComboBox3.Items.Add(ds.Tables("Student").Rows(i)(1).ToString)
            Next
            ' 'cn.Close()
            cond = 0
        End If

        

        With DataGridView1
            For indexDGV As Integer = 0 To .Rows.Count - 1 Step 1
                For indexCBO As Integer = ComboBox4.Items.Count - 1 To 0 Step -1

                    If .Rows(indexDGV).Cells(2).Value.Equals(ComboBox4.Items(indexCBO).ToString()) Then
                        If .Rows(indexDGV).Cells(4).Value.Equals("NO") Then
                            ComboBox4.Items.RemoveAt(indexCBO)
                            Exit For
                        End If


                    End If

                Next
            Next
        End With

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Dim i, ctr As Integer
        
            ds.Clear()
            ''cn.Open()
            str = "select * from Student where StudName = '" & ComboBox3.Text & "'"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Student")
            ctr = ds.Tables("Student").Rows.Count - 1
            For i = 0 To ctr
                ComboBox2.Text = ds.Tables("Student").Rows(i)(0).ToString
            Next

            ''cn.Close()


    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim i, ctr, his As Integer
        Dim tb4 As Integer = 0

        his = 0
        ds.Clear()
        str = "select * from FeesCollection"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "FeesCollection")
        ctr = ds.Tables("FeesCollection").Rows.Count - 1
        If ds.Tables("FeesCollection").Rows.Count > 0 Then
            ds.Clear()
            str = "select * from Fees where FeesFor = '" & ComboBox4.Text & "'"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Fees")
            ctr = ds.Tables("Fees").Rows.Count - 1
            For i = 0 To ctr
                TextBox5.Text = ds.Tables("Fees").Rows(i)(4).ToString
                TextBox6.Text = ds.Tables("Fees").Rows(i)(3).ToString
            Next

            If TextBox5.Text = "NO" Then
                TextBox4.ReadOnly = True

                ds.Clear()
                str = "select * from Fees where FeesFor = '" & ComboBox4.Text & "'"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.Fill(ds, "Fees")
                ctr = ds.Tables("Fees").Rows.Count - 1
                For i = 0 To ctr
                    TextBox4.Text = ds.Tables("Fees").Rows(i)(3).ToString
                Next

            Else
                TextBox4.ReadOnly = False
                ds.Clear()
                str = "select * from FeesCollection where RegNo = '" & ComboBox2.Text & "' and PartPay = '" & "YES" & "'"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.Fill(ds, "FeesCollection")
                ctr = ds.Tables("FeesCollection").Rows.Count - 1
                For i = 0 To ctr
                    tb4 = tb4 + Val(ds.Tables("FeesCollection").Rows(i)(6).ToString)
                Next
                TextBox4.Text = Val(TextBox6.Text) - tb4
            End If
        Else
            ds.Clear()
            str = "select * from Fees where FeesFor = '" & ComboBox4.Text & "'"
            cmd = New OleDbCommand(str, cn)
            da.SelectCommand = cmd
            da.Fill(ds, "Fees")
            ctr = ds.Tables("Fees").Rows.Count - 1
            For i = 0 To ctr
                TextBox5.Text = ds.Tables("Fees").Rows(i)(4).ToString
                TextBox6.Text = ds.Tables("Fees").Rows(i)(3).ToString
            Next
            TextBox4.Text = TextBox3.Text
            If TextBox5.Text = "NO" Then
                TextBox4.ReadOnly = True
                TextBox4.Text = TextBox6.Text
            Else
                TextBox4.ReadOnly = False
                TextBox4.Text = TextBox6.Text
            End If
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim er As Integer = 0
        Dim pay As Integer = 0
        If ComboBox1.Text = "Select" Or ComboBox2.Text = "Select" Or ComboBox3.Text = "Select" Or ComboBox4.Text = "" Or TextBox4.Text = "" Then
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

        'insert
        If er = 0 Then
            pay = Val(TextBox3.Text) + Val(TextBox4.Text)
            Try
                cmd.Connection = cn
                cmd.CommandText = "insert into FeesCollection(FID,FCDate,RegNo,Class,StudName,Paid,Amount,ForPaid,PartPay) values('" & TextBox1.Text & "','" & DateTimePicker1.Text & "','" & ComboBox2.Text & "','" & ComboBox1.Text & "','" & ComboBox3.Text & "','" & pay & "','" & TextBox4.Text & "','" & ComboBox4.Text & "','" & TextBox5.Text & "')"
                cmd.ExecuteNonQuery()
                'MsgBox("New Class Added.")
                'Account Table Insert Command
                cmd.Connection = cn
                cmd.CommandText = "insert into Account(ID,Type,TDate,TFrom,TTo,Description,Mode,Amount) values('" & tid & "','" & "INCOME" & "','" & DateTimePicker1.Text & "','" & ComboBox3.Text & "','" & "KUCKOOS" & "','" & ComboBox4.Text & "','" & ComboBox5.Text & "','" & TextBox4.Text & "')"
                cmd.ExecuteNonQuery()

                Dim result As Integer = MessageBox.Show("New Fees Collection Entry. Want To Add Another One.", "Added", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Me.Close()
                ElseIf result = DialogResult.Yes Then
                    ds.Clear()
                    cond = 0
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    TextBox5.Clear()
                    TextBox6.Clear()
                    ComboBox1.Items.Clear()
                    ComboBox2.Items.Clear()
                    ComboBox3.Items.Clear()
                    ComboBox4.Items.Clear()
                    ComboBox1.ResetText()
                    ComboBox2.ResetText()
                    ComboBox3.ResetText()
                    ComboBox4.ResetText()
                    DataGridView1.Rows.Clear()

                    ds.Clear()
                    str = "select * from FeesCollection"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "FeesCollection")
                    Dim LastNo As Integer
                    LastNo = ds.Tables("FeesCollection").Rows.Count + 1
                    If LastNo >= 0 Then
                        TextBox1.Text = "FID" & LastNo
                    Else
                        TextBox1.Text = "FID" & 0
                    End If
                    ''cn.Close()

                    ds.Clear()
                    Dim i, ctr As Integer
                    ''cn.Open()
                    str = "select * from Class"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Class")
                    ctr = ds.Tables("Class").Rows.Count - 1
                    For i = 0 To ctr
                        ComboBox1.Items.Add(ds.Tables("Class").Rows(i)(1).ToString)
                    Next
                    ''cn.Close()

                    ds.Clear()
                    ''cn.Open()
                    str = "select * from Student"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Student")
                    ctr = ds.Tables("Student").Rows.Count - 1
                    For i = 0 To ctr
                        ComboBox2.Items.Add(ds.Tables("Student").Rows(i)(0).ToString)
                        ComboBox3.Items.Add(ds.Tables("Student").Rows(i)(1).ToString)
                    Next
                    ''cn.Close()                

                End If
            Catch ex As Exception
                MsgBox(" Fees Collection Failed.")
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                ComboBox1.ResetText()
                ComboBox2.ResetText()
                ComboBox3.ResetText()
                ComboBox4.ResetText()
            End Try
            'insert closed
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim er As Integer = 0
        Dim pay As Integer = 0
        If ComboBox1.Text = "Select" Or ComboBox2.Text = "Select" Or ComboBox3.Text = "Select" Or ComboBox4.Text = "" Or TextBox4.Text = "" Then
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

        'insert
        If er = 0 Then
            pay = Val(TextBox3.Text) + Val(TextBox4.Text)
            Try
                cmd.Connection = cn
                cmd.CommandText = "insert into FeesCollection(FID,FCDate,RegNo,Class,StudName,Paid,Amount,ForPaid,PartPay) values('" & TextBox1.Text & "','" & DateTimePicker1.Text & "','" & ComboBox2.Text & "','" & ComboBox1.Text & "','" & ComboBox3.Text & "','" & pay & "','" & TextBox4.Text & "','" & ComboBox4.Text & "', '" & TextBox5.Text & "')"
                cmd.ExecuteNonQuery()
                cmd.Connection = cn
                cmd.CommandText = "insert into Account(ID,Type,TDate,TFrom,TTo,Description,Mode,Amount) values('" & tid & "','" & "INCOME" & "','" & DateTimePicker1.Text & "','" & ComboBox3.Text & "','" & "KUCKOOS" & "','" & ComboBox4.Text & "','" & ComboBox5.Text & "','" & TextBox4.Text & "')"
                cmd.ExecuteNonQuery()

                'Dim result As Integer = MessageBox.Show("New Fees Collection Entry. Want To Add Another One.", "Added", MessageBoxButtons.YesNo)
                'If result = DialogResult.No Then
                '    Me.Close()
                'ElseIf result = DialogResult.Yes Then



                'Print
                PrintForm.MdiParent = Home
                Dim co As Integer
                co = 0
                'Report
                Dim cr As New FeesCollectionSlip
                Try
                    'Fees Collection Detail
                    FCF1 = TextBox1.Text
                    FCF2 = ComboBox1.Text
                    FCF3 = DateTimePicker1.Text
                    FCF4 = ComboBox2.Text
                    FCF5 = ComboBox3.Text
                    FCF6 = ComboBox4.Text
                    FCF7 = TextBox6.Text
                    FCF8 = TextBox5.Text
                    FCF9 = ComboBox5.Text
                    FCF10 = TextBox4.Text
                    FCF11 = Val(TextBox3.Text) + Val(TextBox4.Text)
                    FCF12 = Val(TextBox2.Text) - Val(TextBox4.Text)
                Catch ex As Exception
                    MsgBox("No Fees Collection Detail Found. Fill All Details.")
                End Try
                Try
                    If co = 0 Then
                        'cr.SetDataSource(ds)
                        PrintForm.CrystalReportViewer1.RefreshReport()
                        cr.SetParameterValue("FCR1", FCF1)
                        cr.SetParameterValue("FCR2", FCF2)
                        cr.SetParameterValue("FCR3", FCF3)
                        cr.SetParameterValue("FCR4", FCF4)
                        cr.SetParameterValue("FCR5", FCF5)
                        cr.SetParameterValue("FCR6", FCF6)
                        cr.SetParameterValue("FCR7", FCF7)
                        cr.SetParameterValue("FCR8", FCF8)
                        cr.SetParameterValue("FCR9", FCF9)
                        cr.SetParameterValue("FCR10", FCF10)
                        cr.SetParameterValue("FCR11", FCF11)
                        cr.SetParameterValue("FCR12", FCF12)
                        PrintForm.CrystalReportViewer1.ReportSource = cr
                        PrintForm.Show()
                    Else
                        'MsgBox("Probleam in Preparing Print.")
                    End If
                Catch ex As Exception
                    MsgBox("Unable To Create Report.")
                End Try




                ds.Clear()
                cond = 0
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                ComboBox1.Items.Clear()
                ComboBox2.Items.Clear()
                ComboBox3.Items.Clear()
                ComboBox4.Items.Clear()
                ComboBox1.ResetText()
                ComboBox2.ResetText()
                ComboBox3.ResetText()
                ComboBox4.ResetText()
                DataGridView1.Rows.Clear()

                ds.Clear()
                str = "select * from FeesCollection"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.Fill(ds, "FeesCollection")
                Dim LastNo As Integer
                LastNo = ds.Tables("FeesCollection").Rows.Count + 1
                If LastNo >= 0 Then
                    TextBox1.Text = "FID" & LastNo
                Else
                    TextBox1.Text = "FID" & 0
                End If
                ''cn.Close()

                ds.Clear()
                Dim i, ctr As Integer
                ''cn.Open()
                str = "select * from Class"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.Fill(ds, "Class")
                ctr = ds.Tables("Class").Rows.Count - 1
                For i = 0 To ctr
                    ComboBox1.Items.Add(ds.Tables("Class").Rows(i)(1).ToString)
                Next
                ''cn.Close()

                ds.Clear()
                ''cn.Open()
                str = "select * from Student"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.Fill(ds, "Student")
                ctr = ds.Tables("Student").Rows.Count - 1
                For i = 0 To ctr
                    ComboBox2.Items.Add(ds.Tables("Student").Rows(i)(0).ToString)
                    ComboBox3.Items.Add(ds.Tables("Student").Rows(i)(1).ToString)
                Next
                ''cn.Close()                

                'End If
            Catch ex As Exception
                MsgBox(" Fees Collection Failed.")
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                ComboBox1.ResetText()
                ComboBox2.ResetText()
                ComboBox3.ResetText()
                ComboBox4.ResetText()
            End Try
            'insert closed
        End If
    End Sub
End Class