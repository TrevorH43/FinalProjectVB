Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox

Public Class Product
    Public Property Name As String
    Public Property Price As Decimal
    Public Property Quantity As Integer
    Public Property Image As Image

    Dim cart As New List(Of Product)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form1.Show()
    End Sub


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim productGS As New Product With {.Name = "German Shepard", .Price = 400.0}
        Dim productBH As New Product With {.Name = "Basset Hound", .Price = 350.0}
        Dim productGR As New Product With {.Name = "Golden Retriever", .Price = 375.0}
        cart.Add(productGS)
        cart.Add(productBH)
        cart.Add(productGR)
        For Each product In cart
            Dim nameLabel As New Label With {.Text = product.Name}
            Dim priceLabel As New Label With {.Text = product.Price.ToString("c")}
            Dim quantityTextBox As New TextBox With {.Text = "0"}
            Dim imagePictureBox As New PictureBox With {.Image = product.Image, .SizeMode = PictureBoxSizeMode.StretchImage, .Width = 100, .Height = 100}
            AddHandler imagePictureBox.Click, AddressOf ImagePictureBox_Click
            FlowLayoutPanel1.Controls.Add(imagePictureBox)
            FlowLayoutPanel1.SetFlowBreak(imagePictureBox, True)
            FlowLayoutPanel1.Controls.Add(quantityTextBox)
        Next
    End Sub
    Private Sub ImagePictureBox_Click(sender As Object, e As EventArgs)
        PictureBox1.Image = CType(sender, PictureBox).Image
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        For i = 0 To FlowLayoutPanel1.Controls.Count - 1 Step 4
            Dim product As Product = cart(i / 4)
            Dim quantityTextBox As TextBox = CType(FlowLayoutPanel1.Controls(i + 3), TextBox)
            Dim quantity As Integer = Integer.Parse(quantityTextBox.Text)
            product.Quantity = quantity
        Next
        DataGridView1.DataSource = cart
        DataGridView1.Refresh()
    End Sub
    Private Sub DataGridView1_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete
        Dim total As Decimal = cart.Sum(Function(p) p.Price * p.Quantity)
        Label1.Text = "Total: " & total.ToString("c")
    End Sub




End Class