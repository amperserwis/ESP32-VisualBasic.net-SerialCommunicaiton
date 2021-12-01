'this code create by nur ahmad'
'Youtube channel : Digitalneering'
'visit my youtube channel for detail to do'

Imports System.IO.Ports

Public Class Form1
    Dim myPort As Array
    Dim feedback As String
    Dim feedbackpotentio As String
    Dim dataseparate As String() 'spliting data

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        myPort = IO.Ports.SerialPort.GetPortNames()
        For i = 0 To UBound(myPort)
            ComboBox1.Items.Add(myPort(i))
        Next
        ComboBox1.Text = ComboBox1.SelectedItem



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'connect'
        Timer1.Start()
        SerialPort1.PortName = ComboBox1.Text
        SerialPort1.Open()
        If (SerialPort1.IsOpen) Then

            Button3.Enabled = False
            Button4.Enabled = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'disconnect'
        SerialPort1.Close()
        Button4.Enabled = False
        Button3.Enabled = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SerialPort1.Write("Led 1")
        SerialPort1.DiscardOutBuffer()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SerialPort1.Write("Led 2")
        SerialPort1.DiscardOutBuffer()
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived

        If (SerialPort1.IsOpen) Then
            feedback = SerialPort1.ReadLine()

        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Try
            dataseparate = feedback.Split(","",")
            Label2.Text = dataseparate(0)
            Label5.Text = dataseparate(1)
        Catch ex As Exception
        End Try
    End Sub
End Class
