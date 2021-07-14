<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmopcaopag
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvpag = New System.Windows.Forms.DataGridView()
        Me.txtdinheiro = New System.Windows.Forms.TextBox()
        Me.txttroco = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.desc_fingrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cod_fingrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipo_fingrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvpag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvpag
        '
        Me.dgvpag.AllowUserToAddRows = False
        Me.dgvpag.AllowUserToDeleteRows = False
        Me.dgvpag.AllowUserToResizeColumns = False
        Me.dgvpag.AllowUserToResizeRows = False
        Me.dgvpag.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvpag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvpag.ColumnHeadersVisible = False
        Me.dgvpag.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.desc_fingrid, Me.cod_fingrid, Me.tipo_fingrid})
        Me.dgvpag.EnableHeadersVisualStyles = False
        Me.dgvpag.GridColor = System.Drawing.Color.Red
        Me.dgvpag.Location = New System.Drawing.Point(2, 0)
        Me.dgvpag.Name = "dgvpag"
        Me.dgvpag.ReadOnly = True
        Me.dgvpag.RowHeadersVisible = False
        Me.dgvpag.Size = New System.Drawing.Size(355, 345)
        Me.dgvpag.TabIndex = 0
        '
        'txtdinheiro
        '
        Me.txtdinheiro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtdinheiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdinheiro.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdinheiro.Location = New System.Drawing.Point(2, 379)
        Me.txtdinheiro.Name = "txtdinheiro"
        Me.txtdinheiro.Size = New System.Drawing.Size(186, 49)
        Me.txtdinheiro.TabIndex = 1
        Me.txtdinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txttroco
        '
        Me.txttroco.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txttroco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttroco.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttroco.Location = New System.Drawing.Point(194, 379)
        Me.txttroco.Name = "txttroco"
        Me.txttroco.ReadOnly = True
        Me.txttroco.Size = New System.Drawing.Size(161, 49)
        Me.txttroco.TabIndex = 2
        Me.txttroco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(-4, 348)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 31)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "DINHEIRO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(188, 348)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 31)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "TROCO"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(252, 60)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Gray
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(74, 435)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(200, 44)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Confirmar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'desc_fingrid
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.desc_fingrid.DefaultCellStyle = DataGridViewCellStyle1
        Me.desc_fingrid.HeaderText = "Column1"
        Me.desc_fingrid.Name = "desc_fingrid"
        Me.desc_fingrid.ReadOnly = True
        Me.desc_fingrid.Width = 350
        '
        'cod_fingrid
        '
        Me.cod_fingrid.HeaderText = "codigo"
        Me.cod_fingrid.Name = "cod_fingrid"
        Me.cod_fingrid.ReadOnly = True
        '
        'tipo_fingrid
        '
        Me.tipo_fingrid.HeaderText = "tipo fin"
        Me.tipo_fingrid.Name = "tipo_fingrid"
        Me.tipo_fingrid.ReadOnly = True
        Me.tipo_fingrid.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tipo_fingrid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tipo_fingrid.Visible = False
        '
        'frmopcaopag
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 429)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txttroco)
        Me.Controls.Add(Me.txtdinheiro)
        Me.Controls.Add(Me.dgvpag)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmopcaopag"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Forma de Pagamento"
        CType(Me.dgvpag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvpag As System.Windows.Forms.DataGridView
    Friend WithEvents txtdinheiro As System.Windows.Forms.TextBox
    Friend WithEvents txttroco As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents desc_fingrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cod_fingrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo_fingrid As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
