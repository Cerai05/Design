<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CashierForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CashierForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.exitbtn = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Totaltxt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblTable = New System.Windows.Forms.Label()
        Me.lblinvoice = New System.Windows.Forms.Label()
        Me.lblcounter = New System.Windows.Forms.Label()
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.tenderbtn = New System.Windows.Forms.Button()
        Me.discountbtn = New System.Windows.Forms.Button()
        Me.quantitybtn = New System.Windows.Forms.Button()
        Me.temporarybtn = New System.Windows.Forms.Button()
        Me.statusbtn = New System.Windows.Forms.Button()
        Me.invoicebtn = New System.Windows.Forms.Button()
        Me.dailybtn = New System.Windows.Forms.Button()
        Me.turnoverbtn = New System.Windows.Forms.Button()
        Me.yearlybtn = New System.Windows.Forms.Button()
        Me.monthlybtn = New System.Windows.Forms.Button()
        Me.logoutbtn = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.voidbtn = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.searchbtn = New System.Windows.Forms.Button()
        Me.searchtxt = New System.Windows.Forms.TextBox()
        Me.lvTables = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvcategory = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvorder = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvPizza = New System.Windows.Forms.ListView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.exitbtn)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1403, 28)
        Me.Panel1.TabIndex = 0
        '
        'exitbtn
        '
        Me.exitbtn.BackColor = System.Drawing.Color.ForestGreen
        Me.exitbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.exitbtn.FlatAppearance.BorderSize = 0
        Me.exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.exitbtn.Image = CType(resources.GetObject("exitbtn.Image"), System.Drawing.Image)
        Me.exitbtn.Location = New System.Drawing.Point(1364, -1)
        Me.exitbtn.Name = "exitbtn"
        Me.exitbtn.Size = New System.Drawing.Size(35, 28)
        Me.exitbtn.TabIndex = 33
        Me.exitbtn.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1230, 23)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "HERBS N' SLICE"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 789)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1403, 24)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 28)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1, 761)
        Me.Panel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(1402, 28)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1, 761)
        Me.Panel4.TabIndex = 3
        '
        'Totaltxt
        '
        Me.Totaltxt.BackColor = System.Drawing.Color.Black
        Me.Totaltxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Totaltxt.Font = New System.Drawing.Font("Tahoma", 55.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Totaltxt.ForeColor = System.Drawing.Color.Ivory
        Me.Totaltxt.Location = New System.Drawing.Point(0, 28)
        Me.Totaltxt.Multiline = True
        Me.Totaltxt.Name = "Totaltxt"
        Me.Totaltxt.ReadOnly = True
        Me.Totaltxt.Size = New System.Drawing.Size(686, 101)
        Me.Totaltxt.TabIndex = 4
        Me.Totaltxt.Text = "₱ 0.00"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(4, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Invoice No.:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(4, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Table No.:"
        '
        'lblTime
        '
        Me.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTime.Font = New System.Drawing.Font("Tahoma", 43.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.Location = New System.Drawing.Point(685, 28)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(427, 101)
        Me.lblTime.TabIndex = 7
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbldate
        '
        Me.lbldate.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldate.Location = New System.Drawing.Point(692, 104)
        Me.lbldate.Name = "lbldate"
        Me.lbldate.Size = New System.Drawing.Size(415, 23)
        Me.lbldate.TabIndex = 8
        Me.lbldate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.lblTable)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.lblinvoice)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Location = New System.Drawing.Point(1113, 28)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(189, 76)
        Me.Panel5.TabIndex = 9
        '
        'lblTable
        '
        Me.lblTable.AutoSize = True
        Me.lblTable.BackColor = System.Drawing.Color.White
        Me.lblTable.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTable.ForeColor = System.Drawing.Color.Black
        Me.lblTable.Location = New System.Drawing.Point(75, 45)
        Me.lblTable.Name = "lblTable"
        Me.lblTable.Size = New System.Drawing.Size(0, 20)
        Me.lblTable.TabIndex = 34
        '
        'lblinvoice
        '
        Me.lblinvoice.AutoSize = True
        Me.lblinvoice.BackColor = System.Drawing.Color.White
        Me.lblinvoice.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinvoice.ForeColor = System.Drawing.Color.Black
        Me.lblinvoice.Location = New System.Drawing.Point(27, 24)
        Me.lblinvoice.Name = "lblinvoice"
        Me.lblinvoice.Size = New System.Drawing.Size(0, 20)
        Me.lblinvoice.TabIndex = 33
        '
        'lblcounter
        '
        Me.lblcounter.BackColor = System.Drawing.Color.Black
        Me.lblcounter.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcounter.ForeColor = System.Drawing.Color.Ivory
        Me.lblcounter.Location = New System.Drawing.Point(1113, 102)
        Me.lblcounter.Name = "lblcounter"
        Me.lblcounter.Size = New System.Drawing.Size(189, 27)
        Me.lblcounter.TabIndex = 10
        Me.lblcounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picImage
        '
        Me.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picImage.Location = New System.Drawing.Point(1302, 28)
        Me.picImage.Name = "picImage"
        Me.picImage.Size = New System.Drawing.Size(100, 101)
        Me.picImage.TabIndex = 11
        Me.picImage.TabStop = False
        '
        'tenderbtn
        '
        Me.tenderbtn.BackColor = System.Drawing.Color.Gainsboro
        Me.tenderbtn.Enabled = False
        Me.tenderbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tenderbtn.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tenderbtn.ForeColor = System.Drawing.Color.Black
        Me.tenderbtn.Image = CType(resources.GetObject("tenderbtn.Image"), System.Drawing.Image)
        Me.tenderbtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tenderbtn.Location = New System.Drawing.Point(0, 651)
        Me.tenderbtn.Name = "tenderbtn"
        Me.tenderbtn.Size = New System.Drawing.Size(106, 135)
        Me.tenderbtn.TabIndex = 12
        Me.tenderbtn.Text = "Cash" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tender" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.tenderbtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tenderbtn.UseVisualStyleBackColor = False
        '
        'discountbtn
        '
        Me.discountbtn.BackColor = System.Drawing.Color.Gainsboro
        Me.discountbtn.Enabled = False
        Me.discountbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.discountbtn.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.discountbtn.ForeColor = System.Drawing.Color.Black
        Me.discountbtn.Image = CType(resources.GetObject("discountbtn.Image"), System.Drawing.Image)
        Me.discountbtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.discountbtn.Location = New System.Drawing.Point(108, 651)
        Me.discountbtn.Name = "discountbtn"
        Me.discountbtn.Size = New System.Drawing.Size(106, 135)
        Me.discountbtn.TabIndex = 13
        Me.discountbtn.Text = "Item" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Discounts"
        Me.discountbtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.discountbtn.UseVisualStyleBackColor = False
        '
        'quantitybtn
        '
        Me.quantitybtn.BackColor = System.Drawing.Color.Gainsboro
        Me.quantitybtn.Enabled = False
        Me.quantitybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.quantitybtn.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quantitybtn.ForeColor = System.Drawing.Color.Black
        Me.quantitybtn.Image = CType(resources.GetObject("quantitybtn.Image"), System.Drawing.Image)
        Me.quantitybtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.quantitybtn.Location = New System.Drawing.Point(324, 651)
        Me.quantitybtn.Name = "quantitybtn"
        Me.quantitybtn.Size = New System.Drawing.Size(106, 135)
        Me.quantitybtn.TabIndex = 15
        Me.quantitybtn.Text = "Change" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Quantity"
        Me.quantitybtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.quantitybtn.UseVisualStyleBackColor = False
        '
        'temporarybtn
        '
        Me.temporarybtn.BackColor = System.Drawing.Color.Gainsboro
        Me.temporarybtn.Enabled = False
        Me.temporarybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.temporarybtn.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.temporarybtn.ForeColor = System.Drawing.Color.Black
        Me.temporarybtn.Image = CType(resources.GetObject("temporarybtn.Image"), System.Drawing.Image)
        Me.temporarybtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.temporarybtn.Location = New System.Drawing.Point(216, 651)
        Me.temporarybtn.Name = "temporarybtn"
        Me.temporarybtn.Size = New System.Drawing.Size(106, 135)
        Me.temporarybtn.TabIndex = 14
        Me.temporarybtn.Text = "Show" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Temporary Bill"
        Me.temporarybtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.temporarybtn.UseVisualStyleBackColor = False
        '
        'statusbtn
        '
        Me.statusbtn.BackColor = System.Drawing.Color.Gainsboro
        Me.statusbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.statusbtn.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusbtn.ForeColor = System.Drawing.Color.Black
        Me.statusbtn.Image = CType(resources.GetObject("statusbtn.Image"), System.Drawing.Image)
        Me.statusbtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.statusbtn.Location = New System.Drawing.Point(540, 651)
        Me.statusbtn.Name = "statusbtn"
        Me.statusbtn.Size = New System.Drawing.Size(106, 135)
        Me.statusbtn.TabIndex = 17
        Me.statusbtn.Text = "Change" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Status"
        Me.statusbtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.statusbtn.UseVisualStyleBackColor = False
        '
        'invoicebtn
        '
        Me.invoicebtn.BackColor = System.Drawing.Color.Gainsboro
        Me.invoicebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.invoicebtn.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.invoicebtn.ForeColor = System.Drawing.Color.Black
        Me.invoicebtn.Image = CType(resources.GetObject("invoicebtn.Image"), System.Drawing.Image)
        Me.invoicebtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.invoicebtn.Location = New System.Drawing.Point(432, 651)
        Me.invoicebtn.Name = "invoicebtn"
        Me.invoicebtn.Size = New System.Drawing.Size(106, 135)
        Me.invoicebtn.TabIndex = 16
        Me.invoicebtn.Text = "Re-Print" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Invoice No."
        Me.invoicebtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.invoicebtn.UseVisualStyleBackColor = False
        '
        'dailybtn
        '
        Me.dailybtn.BackColor = System.Drawing.Color.Gainsboro
        Me.dailybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.dailybtn.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dailybtn.ForeColor = System.Drawing.Color.Black
        Me.dailybtn.Image = CType(resources.GetObject("dailybtn.Image"), System.Drawing.Image)
        Me.dailybtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.dailybtn.Location = New System.Drawing.Point(756, 651)
        Me.dailybtn.Name = "dailybtn"
        Me.dailybtn.Size = New System.Drawing.Size(106, 135)
        Me.dailybtn.TabIndex = 19
        Me.dailybtn.Text = "Re-Print" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Daily Sales"
        Me.dailybtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.dailybtn.UseVisualStyleBackColor = False
        '
        'turnoverbtn
        '
        Me.turnoverbtn.BackColor = System.Drawing.Color.Gainsboro
        Me.turnoverbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.turnoverbtn.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.turnoverbtn.ForeColor = System.Drawing.Color.Black
        Me.turnoverbtn.Image = CType(resources.GetObject("turnoverbtn.Image"), System.Drawing.Image)
        Me.turnoverbtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.turnoverbtn.Location = New System.Drawing.Point(648, 651)
        Me.turnoverbtn.Name = "turnoverbtn"
        Me.turnoverbtn.Size = New System.Drawing.Size(106, 135)
        Me.turnoverbtn.TabIndex = 18
        Me.turnoverbtn.Text = "Cashier" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Turnovers"
        Me.turnoverbtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.turnoverbtn.UseVisualStyleBackColor = False
        '
        'yearlybtn
        '
        Me.yearlybtn.BackColor = System.Drawing.Color.Gainsboro
        Me.yearlybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.yearlybtn.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.yearlybtn.ForeColor = System.Drawing.Color.Black
        Me.yearlybtn.Image = CType(resources.GetObject("yearlybtn.Image"), System.Drawing.Image)
        Me.yearlybtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.yearlybtn.Location = New System.Drawing.Point(972, 651)
        Me.yearlybtn.Name = "yearlybtn"
        Me.yearlybtn.Size = New System.Drawing.Size(106, 135)
        Me.yearlybtn.TabIndex = 21
        Me.yearlybtn.Text = "Re-Print" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Yearly Sales"
        Me.yearlybtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.yearlybtn.UseVisualStyleBackColor = False
        '
        'monthlybtn
        '
        Me.monthlybtn.BackColor = System.Drawing.Color.Gainsboro
        Me.monthlybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.monthlybtn.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.monthlybtn.ForeColor = System.Drawing.Color.Black
        Me.monthlybtn.Image = CType(resources.GetObject("monthlybtn.Image"), System.Drawing.Image)
        Me.monthlybtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.monthlybtn.Location = New System.Drawing.Point(864, 651)
        Me.monthlybtn.Name = "monthlybtn"
        Me.monthlybtn.Size = New System.Drawing.Size(106, 135)
        Me.monthlybtn.TabIndex = 20
        Me.monthlybtn.Text = "Re-Print" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Monthly Sales"
        Me.monthlybtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.monthlybtn.UseVisualStyleBackColor = False
        '
        'logoutbtn
        '
        Me.logoutbtn.BackColor = System.Drawing.Color.Gainsboro
        Me.logoutbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.logoutbtn.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logoutbtn.ForeColor = System.Drawing.Color.Black
        Me.logoutbtn.Image = CType(resources.GetObject("logoutbtn.Image"), System.Drawing.Image)
        Me.logoutbtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.logoutbtn.Location = New System.Drawing.Point(1188, 651)
        Me.logoutbtn.Name = "logoutbtn"
        Me.logoutbtn.Size = New System.Drawing.Size(106, 135)
        Me.logoutbtn.TabIndex = 23
        Me.logoutbtn.Text = "Logout" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sign out"
        Me.logoutbtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.logoutbtn.UseVisualStyleBackColor = False
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.Gainsboro
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button12.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.ForeColor = System.Drawing.Color.Black
        Me.Button12.Image = CType(resources.GetObject("Button12.Image"), System.Drawing.Image)
        Me.Button12.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button12.Location = New System.Drawing.Point(1080, 651)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(106, 135)
        Me.Button12.TabIndex = 22
        Me.Button12.Text = "Button12"
        Me.Button12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button12.UseVisualStyleBackColor = False
        '
        'voidbtn
        '
        Me.voidbtn.BackColor = System.Drawing.Color.Gainsboro
        Me.voidbtn.Enabled = False
        Me.voidbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.voidbtn.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.voidbtn.ForeColor = System.Drawing.Color.Black
        Me.voidbtn.Image = CType(resources.GetObject("voidbtn.Image"), System.Drawing.Image)
        Me.voidbtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.voidbtn.Location = New System.Drawing.Point(1296, 651)
        Me.voidbtn.Name = "voidbtn"
        Me.voidbtn.Size = New System.Drawing.Size(106, 135)
        Me.voidbtn.TabIndex = 25
        Me.voidbtn.Text = "Void/Remove" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Items"
        Me.voidbtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.voidbtn.UseVisualStyleBackColor = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Location = New System.Drawing.Point(1, 130)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(376, 30)
        Me.Panel6.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Ivory
        Me.Label3.Location = New System.Drawing.Point(-2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(377, 26)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Customer Order"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'searchbtn
        '
        Me.searchbtn.BackColor = System.Drawing.Color.Transparent
        Me.searchbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.searchbtn.FlatAppearance.BorderSize = 0
        Me.searchbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.searchbtn.Image = CType(resources.GetObject("searchbtn.Image"), System.Drawing.Image)
        Me.searchbtn.Location = New System.Drawing.Point(377, 129)
        Me.searchbtn.Name = "searchbtn"
        Me.searchbtn.Size = New System.Drawing.Size(30, 31)
        Me.searchbtn.TabIndex = 27
        Me.searchbtn.UseVisualStyleBackColor = False
        '
        'searchtxt
        '
        Me.searchtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.searchtxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.searchtxt.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.searchtxt.ForeColor = System.Drawing.Color.Black
        Me.searchtxt.Location = New System.Drawing.Point(408, 131)
        Me.searchtxt.Name = "searchtxt"
        Me.searchtxt.Size = New System.Drawing.Size(704, 30)
        Me.searchtxt.TabIndex = 1
        '
        'lvTables
        '
        Me.lvTables.BackColor = System.Drawing.Color.White
        Me.lvTables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvTables.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvTables.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvTables.ForeColor = System.Drawing.Color.Black
        Me.lvTables.FullRowSelect = True
        Me.lvTables.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvTables.Location = New System.Drawing.Point(1113, 130)
        Me.lvTables.Name = "lvTables"
        Me.lvTables.Size = New System.Drawing.Size(119, 520)
        Me.lvTables.TabIndex = 29
        Me.lvTables.UseCompatibleStateImageBehavior = False
        Me.lvTables.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Table No."
        Me.ColumnHeader1.Width = 176
        '
        'lvcategory
        '
        Me.lvcategory.BackColor = System.Drawing.Color.White
        Me.lvcategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvcategory.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
        Me.lvcategory.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvcategory.ForeColor = System.Drawing.Color.Black
        Me.lvcategory.FullRowSelect = True
        Me.lvcategory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvcategory.Location = New System.Drawing.Point(1233, 130)
        Me.lvcategory.Name = "lvcategory"
        Me.lvcategory.Size = New System.Drawing.Size(169, 520)
        Me.lvcategory.TabIndex = 30
        Me.lvcategory.UseCompatibleStateImageBehavior = False
        Me.lvcategory.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = ""
        Me.ColumnHeader3.Width = 110
        '
        'lvorder
        '
        Me.lvorder.BackColor = System.Drawing.Color.White
        Me.lvorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvorder.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.lvorder.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvorder.ForeColor = System.Drawing.Color.Black
        Me.lvorder.FullRowSelect = True
        Me.lvorder.HideSelection = False
        Me.lvorder.Location = New System.Drawing.Point(0, 162)
        Me.lvorder.Name = "lvorder"
        Me.lvorder.Size = New System.Drawing.Size(377, 487)
        Me.lvorder.TabIndex = 31
        Me.lvorder.UseCompatibleStateImageBehavior = False
        Me.lvorder.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Qty."
        Me.ColumnHeader7.Width = 50
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Description"
        Me.ColumnHeader8.Width = 174
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Price"
        Me.ColumnHeader9.Width = 70
        '
        'lvPizza
        '
        Me.lvPizza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvPizza.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPizza.Location = New System.Drawing.Point(378, 162)
        Me.lvPizza.Name = "lvPizza"
        Me.lvPizza.OwnerDraw = True
        Me.lvPizza.ShowItemToolTips = True
        Me.lvPizza.Size = New System.Drawing.Size(734, 487)
        Me.lvPizza.TabIndex = 32
        Me.lvPizza.UseCompatibleStateImageBehavior = False
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 1
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 1
        Me.ToolTip1.ReshowDelay = 0
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 20
        '
        'CashierForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1403, 813)
        Me.Controls.Add(Me.lbldate)
        Me.Controls.Add(Me.lvPizza)
        Me.Controls.Add(Me.lvorder)
        Me.Controls.Add(Me.lvcategory)
        Me.Controls.Add(Me.lvTables)
        Me.Controls.Add(Me.searchtxt)
        Me.Controls.Add(Me.searchbtn)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.voidbtn)
        Me.Controls.Add(Me.logoutbtn)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.yearlybtn)
        Me.Controls.Add(Me.monthlybtn)
        Me.Controls.Add(Me.dailybtn)
        Me.Controls.Add(Me.turnoverbtn)
        Me.Controls.Add(Me.statusbtn)
        Me.Controls.Add(Me.invoicebtn)
        Me.Controls.Add(Me.quantitybtn)
        Me.Controls.Add(Me.temporarybtn)
        Me.Controls.Add(Me.discountbtn)
        Me.Controls.Add(Me.tenderbtn)
        Me.Controls.Add(Me.picImage)
        Me.Controls.Add(Me.lblcounter)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.Totaltxt)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CashierForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Totaltxt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents lbldate As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblcounter As Label
    Friend WithEvents picImage As PictureBox
    Friend WithEvents tenderbtn As Button
    Friend WithEvents discountbtn As Button
    Friend WithEvents quantitybtn As Button
    Friend WithEvents temporarybtn As Button
    Friend WithEvents statusbtn As Button
    Friend WithEvents invoicebtn As Button
    Friend WithEvents dailybtn As Button
    Friend WithEvents turnoverbtn As Button
    Friend WithEvents yearlybtn As Button
    Friend WithEvents monthlybtn As Button
    Friend WithEvents logoutbtn As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents voidbtn As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents searchbtn As Button
    Friend WithEvents searchtxt As TextBox
    Friend WithEvents lvTables As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents lvcategory As ListView
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents lvorder As ListView
    Friend WithEvents lvPizza As ListView
    Friend WithEvents Label4 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents exitbtn As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblinvoice As Label
    Friend WithEvents lblTable As Label
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
End Class
