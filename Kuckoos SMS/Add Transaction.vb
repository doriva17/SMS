Imports System.Data.OleDb
Public Class Add_Transaction
    Dim er As Integer
    Dim TRF1, TRF2, TRF3, TRF4, TRF5, TRF6, TRF7, TRF8 As String
    Dim rd As String
    Private Sub Add_Transaction_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        cn.Close()
    End Sub

    Private Sub Add_Transaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds.Clear()
        DateTimePicker1.Value = DateTime.Now
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Module1.conn()
        cn.Open()
        er = 0
        str = "select * from Account"
        cmd = New OleDbCommand(str, cn)
        da.SelectCommand = cmd
        da.Fill(ds, "Account")
        Dim LastNo As Integer
        LastNo = ds.Tables("Account").Rows.Count + 1
        If LastNo >= 0 Then
            TextBox1.Text = "TID" & LastNo
        Else
            TextBox1.Text = "TID" & 0
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        er = 0
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or ComboBox1.Text = "Select" Then
            er = 1
            MsgBox("Please Fill All The Detail's.")
        End If
        If RadioButton1.Checked = True Then
            rd = "INCOME"
        End If
        If RadioButton2.Checked = True Then
            rd = "EXPENSE"
        End If

        If er = 0 Then
            Try
                cmd.Connection = cn
                cmd.CommandText = "insert into Account(ID,Type,TDate,TFrom,TTo,Description,Mode,Amount) values('" & TextBox1.Text & "','" & rd & "','" & DateTimePicker1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "','" & TextBox5.Text & "')"
                cmd.ExecuteNonQuery()

                Dim result As Integer = MessageBox.Show("New Transaction Added. Want To Print The Transaction Slip.", "Added", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    ds.Clear()
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    TextBox5.Clear()
                    ComboBox1.ResetText()
                ElseIf result = DialogResult.Yes Then

                    PrintForm.MdiParent = Home
                    Dim co As Integer
                    co = 0
                    'Report                   

                    Dim cr As New TransactionDetail
                    Try
                        'Transaction Detail
                        TRF1 = TextBox1.Text
                        TRF2 = rd
                        TRF3 = DateTimePicker1.Text
                        TRF4 = TextBox2.Text
                        TRF5 = TextBox3.Text
                        TRF6 = ComboBox1.Text
                        TRF7 = TextBox5.Text
                        TRF8 = TextBox4.Text
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




                    ds.Clear()
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    TextBox5.Clear()
                    ComboBox1.ResetText()

                    ds.Clear()
                    str = "select * from Account"
                    cmd = New OleDbCommand(str, cn)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Account")
                    Dim LastNo As Integer
                    LastNo = ds.Tables("Account").Rows.Count + 1
                    If LastNo >= 0 Then
                        TextBox1.Text = "TID" & LastNo
                    Else
                        TextBox1.Text = "TID" & 0
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
                ComboBox1.ResetText()

                ds.Clear()
                str = "select * from Account"
                cmd = New OleDbCommand(str, cn)
                da.SelectCommand = cmd
                da.Fill(ds, "Account")
                Dim LastNo As Integer
                LastNo = ds.Tables("Account").Rows.Count + 1
                If LastNo >= 0 Then
                    TextBox1.Text = "TID" & LastNo
                Else
                    TextBox1.Text = "TID" & 0
                End If
            End Try
            'insert closed
        End If
    End Sub
End Class