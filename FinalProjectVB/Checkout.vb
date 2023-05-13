Imports System.Text.RegularExpressions

Public Class Checkout
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Data.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Product.Show()
    End Sub

    Private Sub NameTxt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles nameTxt.Validating
        If String.IsNullOrEmpty(nameTxt.Text) Then
            e.Cancel = True
            ErrorProvider1.SetError(nameTxt, "Please Enter A Name.")
        Else
            ErrorProvider1.SetError(nameTxt, "")
        End If
    End Sub

    Private Sub CityTxt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cityTxt.Validating
        If String.IsNullOrEmpty(cityTxt.Text) Then
            e.Cancel = True
            ErrorProvider1.SetError(cityTxt, "Please Enter a City.")
        Else
            ErrorProvider1.SetError(cityTxt, "")
        End If
    End Sub

    Private Sub ZipTxt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles zipTxt.Validating
        If Not IsValidZipCode(zipTxt.Text) Then
            e.Cancel = True
            ErrorProvider1.SetError(zipTxt, "Please Enter A Zip Code.")
        Else
            ErrorProvider1.SetError(zipTxt, "")
        End If
    End Sub

    Private Function IsValidZipCode(zipCode As String) As Boolean
        zipCode = Regex.Replace(zipCode, "[^\d]", "")
        If zipCode.Length <> 5 AndAlso zipCode.Length <> 9 Then
            Return False
        End If

        If zipCode.Length = 5 Then
            Return Regex.IsMatch(zipCode, "^\d{5}$")
        Else
            Return Regex.IsMatch(zipCode, "^\d{5}-\d{4}$")
        End If
    End Function






    Private Sub CardNumberTxt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cardNumberTxt.Validating
        If Not IsValidCreditCard(cardNumberTxt.Text) Then
            e.Cancel = True
            ErrorProvider1.SetError(cardNumberTxt, "Please Enter a Valid Credit Card Number.")
        Else
            ErrorProvider1.SetError(cardNumberTxt, "")

        End If
    End Sub
    Private Function IsValidCreditCard(cardNumber As String) As Boolean
        cardNumber = cardNumber.Replace(" ", "").Replace("-", "")

        If cardNumber.Length < 13 OrElse cardNumber.Length > 16 Then
            Return False
        End If

        Dim sum As Integer = 0
        Dim alternate As Boolean = False
        For i As Integer = cardNumber.Length - 1 To 0 Step -1
            Dim digit As Integer = Integer.Parse(cardNumber(i))
            If alternate Then
                digit *= 2
                If digit > 9 Then
                    digit -= 9
                End If
            End If
            sum += digit
            alternate = Not alternate
        Next
        Return sum Mod 10 = 0
    End Function

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        stateTxt.Items.AddRange({"Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado",
                              "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois",
                              "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland",
                              "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana",
                              "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York",
                              "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania",
                              "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah",
                              "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming"})
    End Sub


    Private Sub DateTimePicker1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles expDatePicker.Validating
        Dim expDate As Date = expDatePicker.Value.Date
        If expDate < Today.Date Then
            e.Cancel = True
            ErrorProvider1.SetError(expDatePicker, "The expiration date cannot be in the past.")
        Else
            ErrorProvider1.SetError(expDatePicker, "")
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class