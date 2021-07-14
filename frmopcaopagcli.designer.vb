<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmopcaopagcli
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmopcaopagcli))
        Me.Panelpesquisa = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvpesquisa = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cnpj_dest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtnomep = New System.Windows.Forms.TextBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.txtlimeteret = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panelpesquisa.SuspendLayout()
        CType(Me.dgvpesquisa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panelpesquisa
        '
        Me.Panelpesquisa.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panelpesquisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panelpesquisa.Controls.Add(Me.Button1)
        Me.Panelpesquisa.Controls.Add(Me.dgvpesquisa)
        Me.Panelpesquisa.Location = New System.Drawing.Point(2, 51)
        Me.Panelpesquisa.Name = "Panelpesquisa"
        Me.Panelpesquisa.Size = New System.Drawing.Size(541, 272)
        Me.Panelpesquisa.TabIndex = 101
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(155, 202)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(291, 36)
        Me.Button1.TabIndex = 103
        Me.Button1.TabStop = False
        Me.Button1.Text = "&Confirma venda"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'dgvpesquisa
        '
        Me.dgvpesquisa.AllowUserToAddRows = False
        Me.dgvpesquisa.AllowUserToDeleteRows = False
        Me.dgvpesquisa.AllowUserToResizeColumns = False
        Me.dgvpesquisa.AllowUserToResizeRows = False
        Me.dgvpesquisa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvpesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvpesquisa.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.cnpj_dest, Me.Column1})
        Me.dgvpesquisa.EnableHeadersVisualStyles = False
        Me.dgvpesquisa.GridColor = System.Drawing.Color.Blue
        Me.dgvpesquisa.Location = New System.Drawing.Point(3, 3)
        Me.dgvpesquisa.Name = "dgvpesquisa"
        Me.dgvpesquisa.ReadOnly = True
        Me.dgvpesquisa.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvpesquisa.RowHeadersWidth = 24
        Me.dgvpesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvpesquisa.Size = New System.Drawing.Size(533, 264)
        Me.dgvpesquisa.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Código"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 70
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nome do Cliente"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 310
        '
        'cnpj_dest
        '
        Me.cnpj_dest.HeaderText = "CFP/CNPJ"
        Me.cnpj_dest.Name = "cnpj_dest"
        Me.cnpj_dest.ReadOnly = True
        Me.cnpj_dest.Width = 110
        '
        'Column1
        '
        Me.Column1.HeaderText = "liberado_cli"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(0, 9)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(123, 16)
        Me.Label24.TabIndex = 4
        Me.Label24.Text = "Nome do Cliente"
        '
        'txtnomep
        '
        Me.txtnomep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnomep.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnomep.Location = New System.Drawing.Point(2, 25)
        Me.txtnomep.Name = "txtnomep"
        Me.txtnomep.Size = New System.Drawing.Size(541, 20)
        Me.txtnomep.TabIndex = 0
        '
        'txtlimeteret
        '
        Me.txtlimeteret.Location = New System.Drawing.Point(51, 363)
        Me.txtlimeteret.Name = "txtlimeteret"
        Me.txtlimeteret.Size = New System.Drawing.Size(100, 20)
        Me.txtlimeteret.TabIndex = 116
        Me.txtlimeteret.TabStop = False
        Me.txtlimeteret.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 347)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "Saldo apos a venda"
        Me.Label1.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'frmopcaopagcli
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(549, 325)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtnomep)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtlimeteret)
        Me.Controls.Add(Me.Panelpesquisa)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmopcaopagcli"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pesquisa de Cliente"
        Me.Panelpesquisa.ResumeLayout(False)
        CType(Me.dgvpesquisa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panelpesquisa As System.Windows.Forms.Panel
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtnomep As System.Windows.Forms.TextBox
    Friend WithEvents dgvpesquisa As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents txtlimeteret As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cnpj_dest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
