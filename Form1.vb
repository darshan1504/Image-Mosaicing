Imports Emgu.CV
Imports Emgu.Util
Imports Emgu.CV.Util
Imports Emgu.CV.Structure
Imports Emgu.CV.Stitching

Public Class Form1
    Dim capturez As Capture = New Capture
    Dim stitchz As Stitcher = New Stitcher(False) 'Always false
    Dim num As Integer = 0
    Dim total As Integer = 3 'Actually 4 images, since 0 is counted as well.
    Dim imagez(total) As Image(Of Bgr, Byte)
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Timer1.Start()
        imagez(num) = New Image(Of Bgr, Byte)(capturez.RetrieveBgrFrame.ToBitmap())
        'imagez(num) = capturez.RetrieveBgrFrame 'This won't work.

        If num = total Then
            Try
                Dim result As Image(Of Bgr, Byte) = stitchz.Stitch(imagez)
                PictureBox1.Image = result.ToBitmap
                Me.Text = "Yup"
            Catch ex As Exception
                Me.Text = "Nope"
            End Try
            num = 0
        Else
            num = num + 1
            Dim imagez As Image(Of Bgr, Byte) = capturez.QueryFrame() 'Instead of QueryFrame, you may need to do RetrieveBgrFrame depending on the version of EmguCV you download.

            If PictureBox3.Image Is Nothing Then
                PictureBox3.Image = imagez.ToBitmap()
            ElseIf PictureBox4.Image Is Nothing Then
                PictureBox4.Image = imagez.ToBitmap()
            ElseIf PictureBox5.Image Is Nothing Then
                PictureBox5.Image = imagez.ToBitmap()
           
            End If


        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        PictureBox2.Image = capturez.RetrieveBgrFrame.ToBitmap()

    End Sub
End Class
