﻿
Imports System.Windows

Public Class Product

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Checkout.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim openFileDialog1 As New OpenFileDialog With {
            .Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.BMP;*.JPG;*.JPEG;*.PNG",
            .FilterIndex = 1,
            .RestoreDirectory = True
        }
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Purchase.PictureBox1.Image = Image.FromFile(openFileDialog1.FileName)
            Purchase.Show()
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim openFileDialog1 As New OpenFileDialog With {
            .Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.BMP;*.JPG;*.JPEG;*.PNG",
            .FilterIndex = 1,
            .RestoreDirectory = True
        }
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Purchase.PictureBox1.Image = Image.FromFile(openFileDialog1.FileName)
            Purchase.Show()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim openFileDialog1 As New OpenFileDialog With {
            .Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.BMP;*.JPG;*.JPEG;*.PNG",
            .FilterIndex = 1,
            .RestoreDirectory = True
        }
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Purchase.PictureBox1.Image = Image.FromFile(openFileDialog1.FileName)
            Purchase.Show()
        End If
    End Sub
End Class