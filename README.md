Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing

Public Class CashierForm
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" & Application.StartupPath & "\mydb.accdb;")
    Dim cmd As New OleDbCommand
    Dim adapter As OleDbDataAdapter
    Dim reader As OleDbDataReader
    Private _saleId As Integer


    Sub ShowDup_HistorySales()
        Try
            If con.State <> ConnectionState.Open Then
                con.Open()
            End If

            query = "SELECT * FROM sales WHERE Product = ? AND InvoiceNo = ? AND TableNo = ? ORDER BY Product ASC"
            Using cmd As New OleDbCommand(query, con)
                cmd.Parameters.AddWithValue("?", Product)
                cmd.Parameters.AddWithValue("?", lblinvoice.Text)
                cmd.Parameters.AddWithValue("?", lblTable.Text)

                Using reader = cmd.ExecuteReader()
                    If reader.HasRows Then
                        While reader.Read()
                            ' Here you are overwriting myId and Qty with last record's values
                            ' Change logic if you want first or specific record
                            myId = Convert.ToInt32(reader("ID"))
                            Qty = Convert.ToInt32(reader("Qty"))
                        End While
                    Else
                        ' No matching record found — handle accordingly
                        myId = 0
                        Qty = 0
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading duplicate sales history: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Sub Colored()
        For Each item As ListViewItem In lvTables.Items
            Dim valText As String = item.SubItems(1).Text.Trim()

            ' Remove currency symbol and extra spaces
            valText = valText.Replace("₱", "").Replace(",", "").Trim()

            Dim valDecimal As Decimal

            ' Default color (no value or invalid number)
            item.BackColor = Color.White
            item.ForeColor = Color.Black

            ' Debugging output to check the value being processed
            ' MsgBox("Table: " & item.SubItems(0).Text & " - Value: " & valText)

            ' Only apply color if the text is a valid number
            If Decimal.TryParse(valText, valDecimal) Then
                ' Check if the value is greater than zero
                If valDecimal > 0D Then
                    item.BackColor = Color.Yellow
                ElseIf valDecimal < 0D Then
                    ' If the value is negative, do not change the color
                    item.BackColor = Color.White ' Optional: explicitly set to default color
                End If
            End If
        Next
    End Sub

    Sub GrandTotal()
        Dim GT As Decimal = 0 ' Initialize grand total
        For Each item As ListViewItem In lvorder.Items
            ' Ensure you are accessing the correct subitem for the price
            Dim price As Decimal
            If Decimal.TryParse(item.SubItems(2).Text, price) Then ' Assuming price is in the third subitem (index 2)
                GT += price * Convert.ToInt32(item.SubItems(0).Text) ' Assuming quantity is in the fourth subitem (index 3)
            End If
        Next
        Totaltxt.Text = "₱ " & Decimal.Round(GT, 2).ToString("#,##0.00")
        CommaGrandTotal = Decimal.Round(GT, 2).ToString("#,##0.00")
        NoCommaGrandtotal = Decimal.Round(GT, 2).ToString("f2")
    End Sub

    Sub STotalBill()
        Try
            If con.State <> ConnectionState.Open Then
                con.Open()
            End If

            query = "SELECT TotalBill FROM Tables WHERE TableNo = @TableNo"
            cmd = New OleDbCommand(query, con)
            cmd.Parameters.AddWithValue("@TableNo", lblTable.Text.Trim()) ' Use parameterized query

            reader = cmd.ExecuteReader()

            If reader.Read() Then
                ' Check for DBNull before assigning
                If Not IsDBNull(reader("TotalBill")) Then
                    TB = Convert.ToDecimal(reader("TotalBill")) ' Ensure TB is of the correct type
                Else
                    TB = 0 ' Or handle as needed if TotalBill is null
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then
                reader.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            cmd.Dispose()
        End Try
    End Sub

    Public Sub customer()
        lvorder.Items.Clear()

        Try
            con.Open()
            Dim cmd As New OleDbCommand("SELECT ID, Product, Qty, Price, InvoiceNo FROM sales", con)
            'cmd.Parameters.Add("?", OleDbType.VarChar).Value = lblTable.Text ' Explicitly specify the type

            Dim rdr As OleDbDataReader = cmd.ExecuteReader()

            While rdr.Read()
                Dim item As New ListViewItem(rdr("Qty").ToString())
                item.SubItems.Add(rdr("Product").ToString())
                item.SubItems.Add(rdr("Price").ToString())
                item.SubItems.Add(rdr("ID").ToString())
                item.SubItems.Add(rdr("InvoiceNo").ToString())
                lvorder.Items.Add(item)
            End While
            rdr.Close()

        Catch ex As Exception
            MsgBox("Failed to load orders: " & ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Sub searcht()
        If String.IsNullOrWhiteSpace(searchtxt.Text) Then
            searchtxt.Text = "SEARCH"
            searchtxt.ForeColor = Color.Gray
        End If
    End Sub

    Sub ShowImage()
        Try
            If con.State <> ConnectionState.Open Then
                con.Open()
            End If
            lvPizza.Items.Clear()
            Dim imglist As New ImageList With {
                .ColorDepth = ColorDepth.Depth32Bit,
                .ImageSize = New System.Drawing.Size(130, 116)
            }
            lvPizza.LargeImageList = imglist

            Dim query As String = "SELECT * FROM Products WHERE Status = 'Available' ORDER BY Product ASC"
            Dim dt_image As New DataTable()
            cmd.Connection = con
            cmd.CommandText = query

            adapter = New OleDbDataAdapter(cmd)
            adapter.Fill(dt_image)

            For Each dr As DataRow In dt_image.Rows
                Dim img_buffer = TryCast(dr("myImage"), Byte())
                If img_buffer IsNot Nothing AndAlso img_buffer.Length > 0 Then
                    Using img_stream As New MemoryStream(img_buffer)
                        imglist.Images.Add(dr("ID").ToString(), New Bitmap(img_stream))
                    End Using
                End If

                Dim productName As String = dr("Product").ToString().Trim()

                Dim LVI As New ListViewItem
                LVI.ToolTipText = dr("Category").ToString()
                LVI.Text = productName & vbCrLf & "₱ " & dr("Price").ToString()
                LVI.Name = productName ' Ensure Name is product name trimmed
                LVI.ImageKey = dr("ID").ToString()
                lvPizza.Items.Add(LVI)
            Next

            ' Alternate row coloring
            For i As Integer = 0 To lvPizza.Items.Count - 1
                If i Mod 2 = 0 Then
                    lvPizza.Items(i).BackColor = Color.SaddleBrown
                    lvPizza.Items(i).ForeColor = Color.White
                Else
                    lvPizza.Items(i).BackColor = Color.DarkOrange
                    lvPizza.Items(i).ForeColor = Color.Black
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    'Sub ShowImage()
    '    Try
    '        con.Open()
    '        lvPizza.Items.Clear()
    '        Dim imglist As New ImageList
    '        imglist.ColorDepth = ColorDepth.Depth32Bit
    '        lvPizza.LargeImageList = imglist
    '        lvPizza.LargeImageList.ImageSize = New System.Drawing.Size(130, 116)
    '        Dim query As String = "SELECT * FROM Products WHERE Status = 'Available' ORDER BY Product ASC"
    '        Dim dt_image As New DataTable
    '        cmd.Connection = con
    '        cmd.CommandText = query

    '        ' Initialize the adapter
    '        adapter = New OleDbDataAdapter(cmd) ' Initialize the adapter here
    '        adapter.Fill(dt_image)

    '        For Each dr As DataRow In dt_image.Rows
    '            Dim img_buffer = CType(dr("myImage"), Byte())
    '            Dim img_stream As New MemoryStream(img_buffer, True)
    '            img_stream.Write(img_buffer, 0, img_buffer.Length)
    '            imglist.Images.Add(dr("ID").ToString(), New Bitmap(img_stream))
    '            img_stream.Close()

    '            Dim LVI As New ListViewItem
    '            LVI.ToolTipText = dr("Category").ToString()
    '            LVI.Text = dr("Product").ToString() & vbCrLf & "₱ " & dr("Price").ToString()
    '            LVI.Name = dr("Product").ToString()
    '            LVI.ImageKey = dr("ID").ToString()
    '            lvPizza.Items.Add(LVI)

    '        Next

    '        For i As Integer = 0 To lvPizza.Items.Count - 1
    '            If i Mod 2 = 0 Then
    '                lvPizza.Items(i).BackColor = Color.SaddleBrown
    '                lvPizza.Items(i).ForeColor = Color.White
    '            Else
    '                lvPizza.Items(i).BackColor = Color.DarkOrange
    '                lvPizza.Items(i).ForeColor = Color.Black
    '            End If
    '        Next
    '    Catch ex As Exception
    '        MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        If con.State = ConnectionState.Open Then
    '            con.Close() ' Ensure the connection is closed
    '        End If
    '    End Try
    'End Sub

    Sub search(ByVal searchProduct As String)
        Try
            If con.State <> ConnectionState.Open Then
                con.Open()
            End If

            lvPizza.Items.Clear()
            Dim imglist As New ImageList With {
                .ColorDepth = ColorDepth.Depth32Bit,
                .ImageSize = New System.Drawing.Size(130, 116)
            }
            lvPizza.LargeImageList = imglist

            ' Validate searchProduct content before querying
            If String.IsNullOrWhiteSpace(searchProduct) Then
                MessageBox.Show("Please enter a valid search term.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim query As String = "SELECT * FROM Products WHERE Product LIKE ? AND Status = 'Available' ORDER BY Product ASC"
            cmd.Connection = con
            cmd.CommandText = query
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("?", searchProduct.Trim() & "%") ' Use parameterized LIKE query

            Dim dt_images As New DataTable()
            adapter = New OleDbDataAdapter(cmd)
            adapter.Fill(dt_images)

            For Each dr As DataRow In dt_images.Rows
                Dim img_buffer = TryCast(dr("myImage"), Byte())
                If img_buffer IsNot Nothing AndAlso img_buffer.Length > 0 Then
                    Using img_mstream As New MemoryStream(img_buffer)
                        imglist.Images.Add(dr("ID").ToString(), New Bitmap(img_mstream))
                    End Using
                End If

                Dim productName As String = dr("Product").ToString().Trim()

                Dim LVI As New ListViewItem
                LVI.ToolTipText = dr("Category").ToString()
                LVI.Text = productName & vbCrLf & "₱ " & dr("Price").ToString()
                LVI.Name = productName ' Use trimmed product name consistently
                LVI.ImageKey = dr("ID").ToString()
                lvPizza.Items.Add(LVI)
            Next

            ' Alternate row coloring
            For i As Integer = 0 To lvPizza.Items.Count - 1
                If i Mod 2 = 0 Then
                    lvPizza.Items(i).BackColor = Color.SaddleBrown
                    lvPizza.Items(i).ForeColor = Color.White
                Else
                    lvPizza.Items(i).BackColor = Color.DarkOrange
                    lvPizza.Items(i).ForeColor = Color.Black
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    'Sub search(ByVal searchProduct As String)
    '    Try
    '        If con Is Nothing Then
    '            con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" & Application.StartupPath & "\mydb.accdb;")
    '        End If

    '        If cmd Is Nothing Then
    '            cmd = New OleDbCommand()
    '        End If

    '        If adapter Is Nothing Then
    '            adapter = New OleDbDataAdapter()
    '        End If

    '        lvPizza.Items.Clear()
    '            Dim imglist As New ImageList
    '        imglist.ColorDepth = ColorDepth.Depth32Bit
    '        lvPizza.LargeImageList = imglist
    '        lvPizza.LargeImageList.ImageSize = New System.Drawing.Size(130, 116)

    '        ' Validate searchProduct
    '        If String.IsNullOrWhiteSpace(searchProduct) Then
    '            MessageBox.Show("Please enter a valid search term.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Return
    '        End If

    '        query = "SELECT * FROM Products WHERE Product LIKE'" & searchProduct & "%' AND Status = 'Available' ORDER BY Product ASC"
    '        Dim dt_images As New DataTable
    '        cmd.Connection = con
    '        cmd.CommandText = query

    '        adapter.SelectCommand = cmd
    '        adapter.Fill(dt_images)

    '        For Each dr As DataRow In dt_images.Rows
    '            Dim img_buffer = CType(dr("myImage"), Byte())
    '            If img_buffer IsNot Nothing AndAlso img_buffer.Length > 0 Then
    '                Using img_mstream As New MemoryStream(img_buffer)
    '                    imglist.Images.Add(dr("ID").ToString(), New Bitmap(img_mstream))
    '                End Using
    '            End If

    '            Dim LVI As New ListViewItem
    '            LVI.ToolTipText = dr("Category").ToString()
    '            LVI.Text = dr("Product").ToString() & vbCrLf & "₱ " & dr("Price").ToString()
    '            LVI.Name = dr("Product").ToString()
    '            LVI.ImageKey = dr("ID").ToString()
    '            lvPizza.Items.Add(LVI)
    '        Next

    '        For i As Integer = 0 To lvPizza.Items.Count - 1
    '            If i Mod 2 = 0 Then
    '                lvPizza.Items(i).BackColor = Color.SaddleBrown
    '                lvPizza.Items(i).ForeColor = Color.White
    '            Else
    '                lvPizza.Items(i).BackColor = Color.DarkOrange
    '                lvPizza.Items(i).ForeColor = Color.Black
    '            End If
    '        Next

    '    Catch ex As Exception
    '        MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        If con.State = ConnectionState.Open Then
    '            con.Close()
    '        End If
    '    End Try
    'End Sub

    Sub cashier()
        Try
            con.Open()
            cmd = New OleDbCommand("SELECT * FROM users WHERE Role='Cashier'", con)
            reader = cmd.ExecuteReader()

            If reader.Read() Then
                lblcounter.Text = reader("FirstName").ToString()
            End If

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Sub showCategory()
        Try
            con.Open()
            lvcategory.Items.Clear()

            Dim query As String = "SELECT * FROM category ORDER BY Categories ASC"
            cmd = New OleDbCommand(query, con)
            reader = cmd.ExecuteReader()

            While reader.Read()
                With lvcategory.Items.Add(reader("Categories").ToString())

                End With
            End While

        Catch ex As Exception
            MessageBox.Show("An error occurred while loading categories: " & ex.Message)
        Finally
            If Not reader Is Nothing AndAlso Not reader.IsClosed Then reader.Close()
            If Not con Is Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
            If Not cmd Is Nothing Then cmd.Dispose()
        End Try
    End Sub

    Private Sub CashierForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            con.Open()
            Dim arrImage() As Byte
            Dim query As String = "SELECT *, (LastName & ', ' & FirstName & '.') AS LFM FROM users WHERE Uname ='" & username & "' AND Role = 'Cashier'"
            cmd = New OleDbCommand(query, con)

            reader = cmd.ExecuteReader()

            If reader.HasRows Then
                While reader.Read()
                    role = reader("Role").ToString()

                    ' Check for NULL image
                    If Not IsDBNull(reader("myImage")) Then
                        arrImage = CType(reader("myImage"), Byte())
                        Dim mstream As New System.IO.MemoryStream(arrImage)
                        picImage.Image = Image.FromStream(mstream)
                    Else
                        picImage.Image = Nothing ' or a default image
                    End If
                End While
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurred while loading user image: " & ex.Message)
        Finally
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then reader.Close()
            If con.State = ConnectionState.Open Then con.Close()
        End Try

        Call showCategory()
        Call cashier()
        Call ShowImage()
        Call searcht()
        Dim YearandMonth_no As String = Date.Now.ToString("yyyyMM")
        Dim Day_no As String = Date.Now.ToString("dd")
        autoInvoiceNo = InvoiceNo()
        autoInvoiceNo = InvoiceNo.ToString.PadLeft(4, "0"c)
        lblinvoice.Text = YearandMonth_no & "-" & Day_no & "" & counter & "-" & InvoiceNo()

    End Sub


    Private Sub exitbtn_Click(sender As Object, e As EventArgs) Handles exitbtn.Click
        If MsgBox("Are you sure you want to close this Application?", vbYesNo + vbQuestion, "Confirmation") = vbYes Then
            Application.Exit()
        Else
            searchtxt.Focus()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim myDate As Date = DateAndTime.Now
        lblTime.Text = Format(DateTime.Now, "hh:mm:ss")
        lbldate.Text = myDate.ToString("MMMM dd, yyyy") & "|" & myDate.ToString("ddd")
    End Sub

    Private Sub logoutbtn_Click(sender As Object, e As EventArgs) Handles logoutbtn.Click
        Dim msg1 As Integer
        msg1 = MsgBox("Are you sure you want to Logout?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
        If msg1 = MsgBoxResult.Yes Then
            Me.Hide()
            Form1.Show()
            'Form1.unametxt.Focus()
        End If
    End Sub

    Private Sub searchtxt_GotFocus(sender As Object, e As EventArgs) Handles searchtxt.GotFocus
        If searchtxt.Text = "SEARCH" Then
            searchtxt.Text = ""
            searchtxt.ForeColor = Color.Black
        End If
    End Sub

    Private Sub searchtxt_LostFocus(sender As Object, e As EventArgs) Handles searchtxt.LostFocus
        Call searcht()
    End Sub

    Function InvoiceNo() As String
        Dim autoInvoiceNo As Integer = 1 ' Default value
        Dim query As String = "SELECT max(InvoiceNo) AS InvoiceNo FROM Invoice"

        Try
            Using con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" & Application.StartupPath & "\mydb.accdb;")
                con.Open()
                Using cmd As New OleDbCommand(query, con)
                    Using reader As OleDbDataReader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            While reader.Read()
                                ' Check if the value is DBNull and handle it
                                If Not IsDBNull(reader("InvoiceNo")) Then
                                    autoInvoiceNo = CInt(reader("InvoiceNo")) + 1
                                End If
                            End While
                        End If
                    End Using
                End Using
            End Using
        Catch ex As OleDbException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return String.Empty ' Return an empty string or handle as needed
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return String.Empty ' Return an empty string or handle as needed
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try

        Return autoInvoiceNo.ToString() ' Return as string
    End Function
    Private Sub lvorder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvorder.SelectedIndexChanged
        ' Check if any item is selected
        If lvorder.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = lvorder.SelectedItems(0)

            ' Assuming the ID is in the fourth subitem (index 3) and price in the third subitem (index 2)
            'NPriceU = selectedItem.SubItems(2).Text
            'saleId = selectedItem.SubItems(3).Text
            NPriceU = selectedItem.SubItems(2).Text
            saleId = selectedItem.SubItems(3).Text

            ' Optional: Validate that the values are not empty or invalid
            If String.IsNullOrWhiteSpace(saleId) OrElse String.IsNullOrWhiteSpace(NPriceU) Then
                MsgBox("Selected item does not contain valid data.", MsgBoxStyle.Exclamation, "Invalid Selection")
                Return
            End If

            ' Validate that saleId can be converted to an integer
            Dim saleIdInteger As Integer
            If Not Integer.TryParse(saleId, saleIdInteger) Then
                MsgBox("Invalid Sale ID format.", MsgBoxStyle.Exclamation, "Error")
                Return
            End If

            ' Optional: Validate that NPriceU can be converted to a decimal
            Dim NPriceUDecimal As Decimal
            If Not Decimal.TryParse(NPriceU.Replace("₱", "").Replace(",", "").Trim(), NPriceUDecimal) Then
                MsgBox("Invalid Price format.", MsgBoxStyle.Exclamation, "Error")
                Return
            End If

            ' Enable buttons
            voidbtn.Enabled = True
            quantitybtn.Enabled = True
            temporarybtn.Enabled = True
            discountbtn.Enabled = True
            tenderbtn.Enabled = True
        Else
            ' If no item is selected, disable buttons
            voidbtn.Enabled = False
            quantitybtn.Enabled = False
            temporarybtn.Enabled = False
            discountbtn.Enabled = False
            tenderbtn.Enabled = False
        End If
    End Sub

    Private Sub lvPizza_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles lvPizza.DrawItem
        Dim g As Graphics = e.Graphics
        Dim itemBounds As Rectangle = e.Bounds

        ' Clear item background (highlight if selected)
        If (e.State And ListViewItemStates.Selected) = ListViewItemStates.Selected Then
            g.FillRectangle(SystemBrushes.Highlight, itemBounds)
        Else
            g.FillRectangle(New SolidBrush(If(e.ItemIndex Mod 2 = 0, Color.DarkOrange, Color.SaddleBrown)), itemBounds)
        End If

        ' Draw image from LargeImageList with a margin
        Dim imgSize As Size = lvPizza.LargeImageList.ImageSize
        Dim imgX As Integer = itemBounds.X + (itemBounds.Width - imgSize.Width) \ 2
        Dim imgY As Integer = itemBounds.Y + 5 ' top padding

        Dim img As Image = lvPizza.LargeImageList.Images(e.Item.ImageKey)

        If img IsNot Nothing Then
            g.DrawImage(img, New Rectangle(imgX, imgY, imgSize.Width, imgSize.Height))
            ' Draw black border around image
            Dim borderRect As New Rectangle(imgX - 1, imgY - 1, imgSize.Width + 2, imgSize.Height + 2)
            g.DrawRectangle(Pens.Black, borderRect)
        End If

        ' Draw text centered below image with padding
        Dim textRect As New Rectangle(itemBounds.X + 3, imgY + imgSize.Height + 3, itemBounds.Width - 6, itemBounds.Height - imgSize.Height - 8)
        Dim textFormat As New StringFormat With {
        .Alignment = StringAlignment.Center,
        .LineAlignment = StringAlignment.Near,
        .Trimming = StringTrimming.EllipsisCharacter
    }

        ' Use selected text color if selected, else black or white based on background
        Dim textColor As Brush = If((e.State And ListViewItemStates.Selected) = ListViewItemStates.Selected,
                                SystemBrushes.HighlightText,
                                Brushes.Black)

        g.DrawString(e.Item.Text, e.Item.Font, textColor, textRect, textFormat)

        ' Draw focus rectangle if focused and not selected
        If (e.State And ListViewItemStates.Focused) = ListViewItemStates.Focused AndAlso (e.State And ListViewItemStates.Selected) <> ListViewItemStates.Selected Then
            ControlPaint.DrawFocusRectangle(g, itemBounds)
        End If
    End Sub

    Private Sub searchtxt_TextChanged(sender As Object, e As EventArgs) Handles searchtxt.TextChanged

    End Sub

    Private Sub searchbtn_Click(sender As Object, e As EventArgs) Handles searchbtn.Click
        search(searchtxt.Text)
    End Sub

    Private Sub lvPizza_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvPizza.ItemSelectionChanged
        If e.IsSelected Then ' Check if the item is selected
            Try
                If con.State <> ConnectionState.Open Then
                    con.Open()
                End If

                Dim query As String = "SELECT * FROM Products WHERE Product = ?"
                Using cmd As New OleDbCommand(query, con)
                    ' Trim and normalize product name for search
                    Dim productName As String = e.Item.Text.Trim()
                    cmd.Parameters.Add("?", OleDbType.VarChar).Value = productName

                    Using reader As OleDbDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Assuming Product and Price are class-level variables
                            Product = reader("Product").ToString()
                            Price = Convert.ToDecimal(reader("Price"))
                        Else
                            MsgBox("Product not found.", MsgBoxStyle.Exclamation, "Error")
                        End If
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                If con.State = ConnectionState.Open Then con.Close()
            End Try
        End If
    End Sub

    'Private Sub lvPizza_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvPizza.ItemSelectionChanged
    '    If e.IsSelected Then ' Check if the item is selected
    '        Try
    '            con.Open()
    '            Dim query As String = "SELECT * FROM Products WHERE Product = @Product"
    '            Using cmd As New OleDbCommand(query, con)
    '                Use e.Item.Text to get the selected item's text
    '                Dim productName As String = e.Item.Text.Trim()
    '                Debug.WriteLine("Searching for product: " & productName)
    '                cmd.Parameters.Add("@Product", OleDbType.VarChar).Value = productName

    '                Using reader As OleDbDataReader = cmd.ExecuteReader()
    '                    If reader.Read() Then
    '                        Assuming Product And Price are class-level variables
    '                        Product = reader("Product").ToString()
    '                        Price = Convert.ToDecimal(reader("Price"))
    '                    Else
    '                        MsgBox("Product not found.", MsgBoxStyle.Exclamation, "Error")
    '                    End If
    '                End Using
    '            End Using

    '        Catch ex As Exception
    '            MessageBox.Show("Error: " & ex.Message)
    '        Finally
    '            If con.State = ConnectionState.Open Then con.Close()
    '        End Try
    '    End If
    'End Sub

    'Private Sub lvPizza_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvPizza.ItemSelectionChanged
    '    If e.IsSelected Then ' Check if the item is selected
    '        Try
    '            con.Open()
    '            Dim query As String = "SELECT * FROM Products WHERE Product = @Product"
    '            Using cmd As New OleDbCommand(query, con)
    '                ' Use e.Item.Text to get the selected item's text
    '                cmd.Parameters.Add("@Product", OleDbType.VarChar).Value = e.Item.Text

    '                Using reader As OleDbDataReader = cmd.ExecuteReader()
    '                    If reader.Read() Then
    '                        ' Assuming Product and Price are class-level variables
    '                        Product = reader("Product").ToString()
    '                        Price = Convert.ToDecimal(reader("Price"))
    '                    Else
    '                        Debug.WriteLine("Searching for product: " & e.Item.Text)
    '                        MsgBox("Product not found.", MsgBoxStyle.Exclamation, "Error")
    '                    End If
    '                End Using
    '            End Using

    '        Catch ex As Exception

    '            MessageBox.Show("Error: " & ex.Message)
    '        Finally
    '            If con.State = ConnectionState.Open Then con.Close()
    '        End Try
    '    End If
    'End Sub


    Private Sub lvcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvcategory.SelectedIndexChanged

        If lvcategory.FocusedItem IsNot Nothing AndAlso lvcategory.FocusedItem.SubItems.Count > 0 Then
            Try
                ' Safely parse saleId from SubItems(0) if it exists
                _saleId = myId

                Dim selectedCategory As String = lvcategory.FocusedItem.Text.Trim()

                voidbtn.Enabled = False
                quantitybtn.Enabled = False

                If selectedCategory.ToUpper() = "ALL PRODUCTS" Then
                    ' Show all products
                    ShowImage()
                Else
                    ' Show filtered products
                    ShowProductsByCategory(selectedCategory)
                End If

            Catch ex As Exception
                MsgBox("Invalid Sale ID format. Please ensure the list contains a valid ID.", MsgBoxStyle.Critical, "Data Error")
            End Try
        End If
    End Sub

    Private Sub ShowProductsByCategory(categoryName As String)
        Try
            If con.State <> ConnectionState.Open Then
                con.Open()
            End If
            lvPizza.Items.Clear()
            Dim imglist As New ImageList With {
                .ColorDepth = ColorDepth.Depth32Bit,
                .ImageSize = New Size(130, 116)
            }
            lvPizza.LargeImageList = imglist

            Dim query As String = "SELECT * FROM Products WHERE Category = ? AND Status = 'Available' ORDER BY Product ASC"
            Dim dt_images As New DataTable()

            cmd.Connection = con
            cmd.CommandText = query
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("?", categoryName.Trim())

            adapter = New OleDbDataAdapter(cmd)
            adapter.Fill(dt_images)

            For Each dr As DataRow In dt_images.Rows
                Dim img_buffer = TryCast(dr("myImage"), Byte())
                If img_buffer IsNot Nothing AndAlso img_buffer.Length > 0 Then
                    Using img_mstream As New MemoryStream(img_buffer)
                        imglist.Images.Add(dr("ID").ToString(), New Bitmap(img_mstream))
                    End Using
                End If

                Dim productName As String = dr("Product").ToString().Trim()

                Dim lvi As New ListViewItem(productName)
                lvi.Tag = dr("Price") ' Store price for later usage
                lvi.ImageKey = dr("ID").ToString()
                lvPizza.Items.Add(lvi)
            Next

            ' Alternate row coloring
            For i As Integer = 0 To lvPizza.Items.Count - 1
                If i Mod 2 = 0 Then
                    lvPizza.Items(i).BackColor = Color.SaddleBrown
                    lvPizza.Items(i).ForeColor = Color.White
                Else
                    lvPizza.Items(i).BackColor = Color.DarkOrange
                    lvPizza.Items(i).ForeColor = Color.Black
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub


    'Private Sub ShowProductsByCategory(categoryName As String)
    '    Try
    '        con.Open()
    '        lvPizza.Items.Clear()
    '        Dim imglist As New ImageList With {
    '        .ColorDepth = ColorDepth.Depth32Bit,
    '        .ImageSize = New Size(130, 116)
    '    }
    '        lvPizza.LargeImageList = imglist

    '        ' SQL query without syntax errors and trimmed category
    '        Dim query As String = "SELECT * FROM Products WHERE Category = ? AND Status = 'Available' ORDER BY Product ASC"
    '        Dim dt_images As New DataTable()

    '        cmd.Connection = con
    '        cmd.CommandText = query
    '        cmd.Parameters.Clear()
    '        cmd.Parameters.AddWithValue("?", categoryName.Trim())

    '        adapter.SelectCommand = cmd
    '        adapter.Fill(dt_images)

    '        For Each dr As DataRow In dt_images.Rows
    '            Dim img_buffer = TryCast(dr("myImage"), Byte())

    '            If img_buffer IsNot Nothing AndAlso img_buffer.Length > 0 Then
    '                Using img_mstream As New MemoryStream(img_buffer)
    '                    imglist.Images.Add(dr("ID").ToString(), New Bitmap(img_mstream))
    '                End Using
    '            End If
    '            Dim lvi As New ListViewItem(dr("Product").ToString())
    '            lvi.Tag = dr("Price") ' Store price here safely
    '            lvi.ImageKey = dr("ID").ToString()
    '            lvPizza.Items.Add(lvi)
    '        Next

    '        For i As Integer = 0 To lvPizza.Items.Count - 1
    '            If i Mod 2 = 0 Then
    '                lvPizza.Items(i).BackColor = Color.SaddleBrown
    '                lvPizza.Items(i).ForeColor = Color.White
    '            Else
    '                lvPizza.Items(i).BackColor = Color.DarkOrange
    '                lvPizza.Items(i).ForeColor = Color.Black
    '            End If
    '        Next

    '    Catch ex As Exception
    '        MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        If con.State = ConnectionState.Open Then con.Close()
    '    End Try
    'End Sub

    Private Sub lvPizza_MouseClick(sender As Object, e As MouseEventArgs) Handles lvPizza.MouseClick

        Dim selectedItem As ListViewItem = lvPizza.FocusedItem

        If selectedItem Is Nothing Then
            MsgBox("Please select a product.", MsgBoxStyle.Exclamation, "No Product")
            Return
        End If

        Dim Product As String = selectedItem.Text.Trim()
        Dim Price As Decimal
        If selectedItem.Tag IsNot Nothing AndAlso Decimal.TryParse(selectedItem.Tag.ToString(), Price) Then
            ' Use Price
        Else
            MsgBox("Invalid or missing price data for selected item.", MsgBoxStyle.Critical, "Error")
            Return
        End If



        ' Check if the selected item has at least 2 subitems
        If selectedItem.SubItems.Count < 1 Then
            MsgBox("Price not found for this item.", MsgBoxStyle.Critical, "Missing Price")
            Return
        End If

        'Dim Product As String = selectedItem.SubItems(0).Text.Trim()
        'Dim Price As Decimal = 0D

        ' Parse the price from the second subitem
        Dim PriceText As String = selectedItem.SubItems(1).Text.Trim().Replace("₱", "").Replace(",", "").Trim()
        If Not Decimal.TryParse(PriceText, Price) Then
            MsgBox("Invalid price format: '" & PriceText & "'.", MsgBoxStyle.Exclamation, "Parsing Error")
            Return
        End If

        Dim Qty As Integer = 1 ' Assuming a default quantity of 1

        Try
            con.Open() ' Open the connection

            Dim checkQuery As String = "SELECT Qty FROM sales WHERE InvoiceNo = @InvoiceNo AND Product = @Product"
            Using checkCmd As New OleDbCommand(checkQuery, con)
                checkCmd.Parameters.AddWithValue("@InvoiceNo", lblinvoice.Text)
                checkCmd.Parameters.AddWithValue("@Product", Product)
                'checkCmd.Parameters.AddWithValue("@TableNo", lblTable.Text)

                ' Use DataReader to read the existing quantity
                Using reader As OleDbDataReader = checkCmd.ExecuteReader()
                    If reader.Read() Then
                        ' If a record is found, get the existing quantity
                        Dim existingQty As Integer = Convert.ToInt32(reader("Qty"))

                        ' Update existing record
                        Dim newQty As Integer = existingQty + Qty
                        Dim updateQuery As String = "UPDATE sales SET Qty = @Qty WHERE InvoiceNo = @InvoiceNo AND Product = @Product "
                        Using updateCmd As New OleDbCommand(updateQuery, con)
                            updateCmd.Parameters.AddWithValue("@Qty", newQty)
                            updateCmd.Parameters.AddWithValue("@InvoiceNo", lblinvoice.Text)
                            updateCmd.Parameters.AddWithValue("@Product", Product)
                            'updateCmd.Parameters.AddWithValue("@TableNo", lblTable.Text)
                            updateCmd.ExecuteNonQuery() ' Execute the update command
                        End Using
                    Else
                        ' No existing record found, insert new record
                        Dim insertQuery As String = "INSERT INTO sales (InvoiceNo, Product, Price, Qty) VALUES (@InvoiceNo, @Product, @Price, @Qty)"
                        Using insertCmd As New OleDbCommand(insertQuery, con)
                            With insertCmd.Parameters
                                .AddWithValue("@InvoiceNo", lblinvoice.Text)
                                .AddWithValue("@Product", Product)
                                .AddWithValue("@Price", Price)
                                .AddWithValue("@Qty", Qty)
                                '.AddWithValue("@TableNo", lblTable.Text)
                            End With
                            insertCmd.ExecuteNonQuery() ' Execute the insert command
                        End Using
                    End If
                End Using
            End Using

            ' Call the method to recalculate and update total bill
            CalculateTotalBill()

            ' Refresh UI
            customer()
            'showtables()
            Colored()
            GrandTotal()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
        Finally
            If con.State = ConnectionState.Open Then
                con.Close() ' Ensure the connection is closed
            End If
        End Try
    End Sub

    Function dupProd_InvoiceNo_TableNo(ByVal prod As String, ByVal INo As String, ByVal TbN As String) As Boolean
        Dim exists As Boolean = False ' Initialize the return value
        Dim query As String = "Select COUNT(*) FROM sales WHERE Product = @Product And InvoiceNo = @InvoiceNo And TableNo = @TableNo"

        Try
            If con.State <> ConnectionState.Open Then
                con.Open() ' Ensure the connection is open
            End If

            Using cmd As New OleDbCommand(query, con)
                ' Use parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@Product", prod)
                cmd.Parameters.AddWithValue("@InvoiceNo", INo)
                cmd.Parameters.AddWithValue("@TableNo", TbN)

                ' Execute the command and check if any records exist
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                exists = (count > 0) ' If count is greater than 0, the product exists
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Ensure the connection is closed
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try

        Return exists
    End Function

    Sub CalculateTotalBill()
        Dim total As Decimal = 0
        Dim query As String = "SELECT SUM(Price * Qty) FROM sales WHERE InvoiceNo = @InvoiceNo AND TableNo = @TableNo"

        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Using cmd As New OleDbCommand(query, con)
                cmd.Parameters.AddWithValue("@InvoiceNo", lblinvoice.Text)
                cmd.Parameters.AddWithValue("@TableNo", lblTable.Text)

                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    total = Convert.ToDecimal(result)
                End If
            End Using

            Dim totalBillUpdateQuery As String = "UPDATE Tables SET TotalBill = @TotalBill WHERE TableNo = @TableNo"
            Using totalBillCmd As New OleDbCommand(totalBillUpdateQuery, con)
                totalBillCmd.Parameters.AddWithValue("@TotalBill", total)
                totalBillCmd.Parameters.AddWithValue("@TableNo", lblTable.Text)
                totalBillCmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            MsgBox("Error calculating total bill: " & ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub Totaltxt_TextChanged(sender As Object, e As EventArgs) Handles Totaltxt.TextChanged

    End Sub

    Private Sub voidbtn_Click(sender As Object, e As EventArgs) Handles voidbtn.Click

        If String.IsNullOrWhiteSpace(myTableNo) OrElse String.IsNullOrWhiteSpace(saleId) Then
                MsgBox("Please select a table and an item to void.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim vf As New VoidForm(CInt(saleId), myTableNo)
        vf.unametxt.Text = ""
        vf.pwordtxt.Text = ""
        vf.ShowDialog()
    End Sub


End Class
