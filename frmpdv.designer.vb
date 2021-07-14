<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmpdv
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmpdv))
        Me.txtdescricao = New System.Windows.Forms.TextBox()
        Me.dgvproduto = New System.Windows.Forms.DataGridView()
        Me.n_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cod_barragrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.desc_prodgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qtde_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlrunit_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlrdesc_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlrtotal_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigo_prodgrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.un_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ncm_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cest_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cst_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aliqicms_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlricms_grid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExcluirItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtcest = New System.Windows.Forms.TextBox()
        Me.txtun = New System.Windows.Forms.TextBox()
        Me.txttotaldesc = New System.Windows.Forms.TextBox()
        Me.txtdesconto = New System.Windows.Forms.TextBox()
        Me.txtvlrunit = New System.Windows.Forms.TextBox()
        Me.txtqtde = New System.Windows.Forms.TextBox()
        Me.txtcodbarra = New System.Windows.Forms.TextBox()
        Me.barinfo = New System.Windows.Forms.StatusStrip()
        Me.lblinfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbloperador = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblorc = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatuscaixa = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtncm = New System.Windows.Forms.TextBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtvlricms = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtaliqicms = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtcst = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Timercad_caixa = New System.Windows.Forms.Timer(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblambi = New System.Windows.Forms.Label()
        Me.txtvlrtotal = New System.Windows.Forms.TextBox()
        Me.txtcod = New System.Windows.Forms.TextBox()
        Me.lblrv = New System.Windows.Forms.Label()
        Me.lblcont = New System.Windows.Forms.Label()
        Me.lblaut = New System.Windows.Forms.Label()
        CType(Me.dgvproduto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.barinfo.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtdescricao
        '
        Me.txtdescricao.BackColor = System.Drawing.Color.White
        Me.txtdescricao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtdescricao.Font = New System.Drawing.Font("Microsoft YaHei UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescricao.ForeColor = System.Drawing.Color.Blue
        Me.txtdescricao.Location = New System.Drawing.Point(28, 19)
        Me.txtdescricao.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtdescricao.Multiline = True
        Me.txtdescricao.Name = "txtdescricao"
        Me.txtdescricao.ReadOnly = True
        Me.txtdescricao.Size = New System.Drawing.Size(1000, 70)
        Me.txtdescricao.TabIndex = 1
        Me.txtdescricao.TabStop = False
        Me.txtdescricao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvproduto
        '
        Me.dgvproduto.AllowUserToAddRows = False
        Me.dgvproduto.AllowUserToDeleteRows = False
        Me.dgvproduto.AllowUserToResizeColumns = False
        Me.dgvproduto.AllowUserToResizeRows = False
        Me.dgvproduto.BackgroundColor = System.Drawing.Color.White
        Me.dgvproduto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvproduto.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvproduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvproduto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.n_grid, Me.cod_barragrid, Me.desc_prodgrid, Me.qtde_grid, Me.vlrunit_grid, Me.vlrdesc_grid, Me.vlrtotal_grid, Me.Column8, Me.codigo_prodgrid, Me.un_grid, Me.ncm_grid, Me.cest_grid, Me.cst_grid, Me.aliqicms_grid, Me.vlricms_grid})
        Me.dgvproduto.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvproduto.EnableHeadersVisualStyles = False
        Me.dgvproduto.GridColor = System.Drawing.Color.Lime
        Me.dgvproduto.Location = New System.Drawing.Point(437, 119)
        Me.dgvproduto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvproduto.Name = "dgvproduto"
        Me.dgvproduto.ReadOnly = True
        Me.dgvproduto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvproduto.RowHeadersVisible = False
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy
        Me.dgvproduto.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvproduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvproduto.Size = New System.Drawing.Size(593, 340)
        Me.dgvproduto.TabIndex = 2
        Me.dgvproduto.TabStop = False
        '
        'n_grid
        '
        Me.n_grid.HeaderText = "Item"
        Me.n_grid.Name = "n_grid"
        Me.n_grid.ReadOnly = True
        Me.n_grid.Visible = False
        Me.n_grid.Width = 30
        '
        'cod_barragrid
        '
        Me.cod_barragrid.HeaderText = "Codigo Barra"
        Me.cod_barragrid.Name = "cod_barragrid"
        Me.cod_barragrid.ReadOnly = True
        '
        'desc_prodgrid
        '
        Me.desc_prodgrid.HeaderText = "Descrição do Produto"
        Me.desc_prodgrid.Name = "desc_prodgrid"
        Me.desc_prodgrid.ReadOnly = True
        Me.desc_prodgrid.Width = 270
        '
        'qtde_grid
        '
        Me.qtde_grid.HeaderText = "Qtde"
        Me.qtde_grid.Name = "qtde_grid"
        Me.qtde_grid.ReadOnly = True
        Me.qtde_grid.Width = 60
        '
        'vlrunit_grid
        '
        Me.vlrunit_grid.HeaderText = "Valor Unitário"
        Me.vlrunit_grid.Name = "vlrunit_grid"
        Me.vlrunit_grid.ReadOnly = True
        Me.vlrunit_grid.Width = 70
        '
        'vlrdesc_grid
        '
        Me.vlrdesc_grid.HeaderText = "Valor Desconto"
        Me.vlrdesc_grid.Name = "vlrdesc_grid"
        Me.vlrdesc_grid.ReadOnly = True
        Me.vlrdesc_grid.Visible = False
        Me.vlrdesc_grid.Width = 70
        '
        'vlrtotal_grid
        '
        Me.vlrtotal_grid.HeaderText = "Valor Total"
        Me.vlrtotal_grid.Name = "vlrtotal_grid"
        Me.vlrtotal_grid.ReadOnly = True
        Me.vlrtotal_grid.Width = 70
        '
        'Column8
        '
        Me.Column8.HeaderText = "codigo_orc"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Visible = False
        '
        'codigo_prodgrid
        '
        Me.codigo_prodgrid.HeaderText = "codigo_prd"
        Me.codigo_prodgrid.Name = "codigo_prodgrid"
        Me.codigo_prodgrid.ReadOnly = True
        Me.codigo_prodgrid.Visible = False
        '
        'un_grid
        '
        Me.un_grid.HeaderText = "UN"
        Me.un_grid.Name = "un_grid"
        Me.un_grid.ReadOnly = True
        Me.un_grid.Visible = False
        '
        'ncm_grid
        '
        Me.ncm_grid.HeaderText = "NCM"
        Me.ncm_grid.Name = "ncm_grid"
        Me.ncm_grid.ReadOnly = True
        Me.ncm_grid.Visible = False
        '
        'cest_grid
        '
        Me.cest_grid.HeaderText = "CEST"
        Me.cest_grid.Name = "cest_grid"
        Me.cest_grid.ReadOnly = True
        Me.cest_grid.Visible = False
        '
        'cst_grid
        '
        Me.cst_grid.HeaderText = "cst"
        Me.cst_grid.Name = "cst_grid"
        Me.cst_grid.ReadOnly = True
        Me.cst_grid.Visible = False
        '
        'aliqicms_grid
        '
        Me.aliqicms_grid.HeaderText = "aliqicms"
        Me.aliqicms_grid.Name = "aliqicms_grid"
        Me.aliqicms_grid.ReadOnly = True
        Me.aliqicms_grid.Visible = False
        '
        'vlricms_grid
        '
        Me.vlricms_grid.HeaderText = "vlricms"
        Me.vlricms_grid.Name = "vlricms_grid"
        Me.vlricms_grid.ReadOnly = True
        Me.vlricms_grid.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExcluirItemToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(136, 26)
        '
        'ExcluirItemToolStripMenuItem
        '
        Me.ExcluirItemToolStripMenuItem.Name = "ExcluirItemToolStripMenuItem"
        Me.ExcluirItemToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ExcluirItemToolStripMenuItem.Text = "Excluir Item"
        '
        'txtcest
        '
        Me.txtcest.Location = New System.Drawing.Point(84, 21)
        Me.txtcest.Name = "txtcest"
        Me.txtcest.Size = New System.Drawing.Size(73, 20)
        Me.txtcest.TabIndex = 3
        '
        'txtun
        '
        Me.txtun.Location = New System.Drawing.Point(826, 69)
        Me.txtun.Name = "txtun"
        Me.txtun.Size = New System.Drawing.Size(40, 20)
        Me.txtun.TabIndex = 13
        Me.txtun.Visible = False
        '
        'txttotaldesc
        '
        Me.txttotaldesc.Location = New System.Drawing.Point(720, 69)
        Me.txttotaldesc.Name = "txttotaldesc"
        Me.txttotaldesc.Size = New System.Drawing.Size(100, 20)
        Me.txttotaldesc.TabIndex = 12
        Me.txttotaldesc.Text = "0,00"
        Me.txttotaldesc.Visible = False
        '
        'txtdesconto
        '
        Me.txtdesconto.BackColor = System.Drawing.Color.White
        Me.txtdesconto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtdesconto.Enabled = False
        Me.txtdesconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdesconto.ForeColor = System.Drawing.Color.Blue
        Me.txtdesconto.Location = New System.Drawing.Point(48, 396)
        Me.txtdesconto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtdesconto.Multiline = True
        Me.txtdesconto.Name = "txtdesconto"
        Me.txtdesconto.Size = New System.Drawing.Size(268, 42)
        Me.txtdesconto.TabIndex = 4
        Me.txtdesconto.Text = "0,00"
        Me.txtdesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtvlrunit
        '
        Me.txtvlrunit.BackColor = System.Drawing.Color.White
        Me.txtvlrunit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtvlrunit.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvlrunit.ForeColor = System.Drawing.Color.Blue
        Me.txtvlrunit.Location = New System.Drawing.Point(46, 315)
        Me.txtvlrunit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtvlrunit.Multiline = True
        Me.txtvlrunit.Name = "txtvlrunit"
        Me.txtvlrunit.ReadOnly = True
        Me.txtvlrunit.Size = New System.Drawing.Size(270, 42)
        Me.txtvlrunit.TabIndex = 3
        Me.txtvlrunit.TabStop = False
        Me.txtvlrunit.Text = "0,00"
        Me.txtvlrunit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtqtde
        '
        Me.txtqtde.BackColor = System.Drawing.Color.White
        Me.txtqtde.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtqtde.Enabled = False
        Me.txtqtde.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqtde.ForeColor = System.Drawing.Color.Blue
        Me.txtqtde.Location = New System.Drawing.Point(46, 235)
        Me.txtqtde.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtqtde.Multiline = True
        Me.txtqtde.Name = "txtqtde"
        Me.txtqtde.Size = New System.Drawing.Size(273, 41)
        Me.txtqtde.TabIndex = 2
        Me.txtqtde.Text = "0,000"
        Me.txtqtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtcodbarra
        '
        Me.txtcodbarra.BackColor = System.Drawing.Color.White
        Me.txtcodbarra.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtcodbarra.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcodbarra.ForeColor = System.Drawing.Color.Blue
        Me.txtcodbarra.Location = New System.Drawing.Point(46, 152)
        Me.txtcodbarra.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtcodbarra.MaxLength = 13
        Me.txtcodbarra.Name = "txtcodbarra"
        Me.txtcodbarra.Size = New System.Drawing.Size(273, 37)
        Me.txtcodbarra.TabIndex = 1
        Me.txtcodbarra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'barinfo
        '
        Me.barinfo.BackColor = System.Drawing.Color.Navy
        Me.barinfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblinfo, Me.lbloperador, Me.lblorc, Me.ToolStripStatuscaixa})
        Me.barinfo.Location = New System.Drawing.Point(0, 643)
        Me.barinfo.Name = "barinfo"
        Me.barinfo.Padding = New System.Windows.Forms.Padding(1, 0, 15, 0)
        Me.barinfo.Size = New System.Drawing.Size(1050, 22)
        Me.barinfo.TabIndex = 8
        Me.barinfo.Text = "aaaaaaa"
        '
        'lblinfo
        '
        Me.lblinfo.BackColor = System.Drawing.Color.Transparent
        Me.lblinfo.ForeColor = System.Drawing.Color.White
        Me.lblinfo.Margin = New System.Windows.Forms.Padding(5, 3, 0, 2)
        Me.lblinfo.Name = "lblinfo"
        Me.lblinfo.Size = New System.Drawing.Size(145, 17)
        Me.lblinfo.Text = "Emissor de Orçamento      "
        '
        'lbloperador
        '
        Me.lbloperador.ForeColor = System.Drawing.Color.White
        Me.lbloperador.Margin = New System.Windows.Forms.Padding(55, 3, 0, 2)
        Me.lbloperador.Name = "lbloperador"
        Me.lbloperador.Size = New System.Drawing.Size(120, 17)
        Me.lbloperador.Text = "ToolStripStatusLabel1"
        '
        'lblorc
        '
        Me.lblorc.ForeColor = System.Drawing.Color.White
        Me.lblorc.Margin = New System.Windows.Forms.Padding(55, 3, 0, 2)
        Me.lblorc.Name = "lblorc"
        Me.lblorc.Size = New System.Drawing.Size(10, 17)
        Me.lblorc.Text = "|"
        '
        'ToolStripStatuscaixa
        '
        Me.ToolStripStatuscaixa.ForeColor = System.Drawing.Color.White
        Me.ToolStripStatuscaixa.Name = "ToolStripStatuscaixa"
        Me.ToolStripStatuscaixa.Size = New System.Drawing.Size(120, 17)
        Me.ToolStripStatuscaixa.Text = "ToolStripStatusLabel1"
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipTitle = "Excluir item da Venda"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Red
        Me.Button2.Location = New System.Drawing.Point(864, 618)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(140, 22)
        Me.Button2.TabIndex = 15
        Me.Button2.TabStop = False
        Me.Button2.Text = "Finalizar Venda"
        Me.ToolTip1.SetToolTip(Me.Button2, "Clique aqui para finaliza a venda")
        Me.Button2.UseVisualStyleBackColor = False
        Me.Button2.Visible = False
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Red
        Me.Button1.Location = New System.Drawing.Point(32, 618)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(133, 22)
        Me.Button1.TabIndex = 14
        Me.Button1.TabStop = False
        Me.Button1.Text = "Pesquisar Produto"
        Me.ToolTip1.SetToolTip(Me.Button1, "Clique aqui para consultar o Produto")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'txtncm
        '
        Me.txtncm.Location = New System.Drawing.Point(3, 21)
        Me.txtncm.Name = "txtncm"
        Me.txtncm.Size = New System.Drawing.Size(75, 20)
        Me.txtncm.TabIndex = 15
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.Label10)
        Me.Panel9.Controls.Add(Me.txtvlricms)
        Me.Panel9.Controls.Add(Me.Label9)
        Me.Panel9.Controls.Add(Me.txtaliqicms)
        Me.Panel9.Controls.Add(Me.Label8)
        Me.Panel9.Controls.Add(Me.txtcst)
        Me.Panel9.Controls.Add(Me.Label7)
        Me.Panel9.Controls.Add(Me.Label2)
        Me.Panel9.Controls.Add(Me.txtcest)
        Me.Panel9.Controls.Add(Me.txtncm)
        Me.Panel9.Location = New System.Drawing.Point(455, 19)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(381, 44)
        Me.Panel9.TabIndex = 16
        Me.Panel9.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(306, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Valor ICMS"
        '
        'txtvlricms
        '
        Me.txtvlricms.Location = New System.Drawing.Point(309, 21)
        Me.txtvlricms.Name = "txtvlricms"
        Me.txtvlricms.Size = New System.Drawing.Size(67, 20)
        Me.txtvlricms.TabIndex = 22
        Me.txtvlricms.Text = "0.00"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(233, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Aliq.ICMS"
        '
        'txtaliqicms
        '
        Me.txtaliqicms.Location = New System.Drawing.Point(236, 21)
        Me.txtaliqicms.Name = "txtaliqicms"
        Me.txtaliqicms.Size = New System.Drawing.Size(67, 20)
        Me.txtaliqicms.TabIndex = 20
        Me.txtaliqicms.Text = "0.00"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(160, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "CST"
        '
        'txtcst
        '
        Me.txtcst.Location = New System.Drawing.Point(163, 21)
        Me.txtcst.Name = "txtcst"
        Me.txtcst.Size = New System.Drawing.Size(67, 20)
        Me.txtcst.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(81, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "CEST"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "NCM"
        '
        'PrintDocument1
        '
        '
        'Timercad_caixa
        '
        Me.Timercad_caixa.Interval = 1000
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(220, 618)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(105, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "F5 Pesquisa Produto"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(537, 618)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(130, 13)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "SPACE Forma pagamento"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(457, 618)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "ESC Voltar"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(331, 618)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "F4 Excluir Item venda"
        '
        'lblambi
        '
        Me.lblambi.AutoSize = True
        Me.lblambi.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblambi.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblambi.Location = New System.Drawing.Point(518, 480)
        Me.lblambi.Name = "lblambi"
        Me.lblambi.Size = New System.Drawing.Size(200, 20)
        Me.lblambi.TabIndex = 12
        Me.lblambi.Text = "Ambiente Homologação"
        Me.lblambi.Visible = False
        '
        'txtvlrtotal
        '
        Me.txtvlrtotal.BackColor = System.Drawing.Color.White
        Me.txtvlrtotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtvlrtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvlrtotal.ForeColor = System.Drawing.Color.Black
        Me.txtvlrtotal.Location = New System.Drawing.Point(756, 498)
        Me.txtvlrtotal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtvlrtotal.Multiline = True
        Me.txtvlrtotal.Name = "txtvlrtotal"
        Me.txtvlrtotal.ReadOnly = True
        Me.txtvlrtotal.Size = New System.Drawing.Size(257, 46)
        Me.txtvlrtotal.TabIndex = 6
        Me.txtvlrtotal.TabStop = False
        Me.txtvlrtotal.Text = "0,00"
        Me.txtvlrtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtcod
        '
        Me.txtcod.BackColor = System.Drawing.Color.Black
        Me.txtcod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcod.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcod.ForeColor = System.Drawing.Color.Yellow
        Me.txtcod.Location = New System.Drawing.Point(17, 23)
        Me.txtcod.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtcod.MaxLength = 13
        Me.txtcod.Name = "txtcod"
        Me.txtcod.Size = New System.Drawing.Size(76, 44)
        Me.txtcod.TabIndex = 11
        Me.txtcod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtcod.Visible = False
        '
        'lblrv
        '
        Me.lblrv.AutoSize = True
        Me.lblrv.BackColor = System.Drawing.Color.Navy
        Me.lblrv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrv.ForeColor = System.Drawing.Color.White
        Me.lblrv.Location = New System.Drawing.Point(691, 646)
        Me.lblrv.Name = "lblrv"
        Me.lblrv.Size = New System.Drawing.Size(21, 16)
        Me.lblrv.TabIndex = 22
        Me.lblrv.Text = "rv"
        Me.lblrv.Visible = False
        '
        'lblcont
        '
        Me.lblcont.AutoSize = True
        Me.lblcont.BackColor = System.Drawing.Color.Navy
        Me.lblcont.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcont.ForeColor = System.Drawing.Color.White
        Me.lblcont.Location = New System.Drawing.Point(29, 586)
        Me.lblcont.Name = "lblcont"
        Me.lblcont.Size = New System.Drawing.Size(39, 16)
        Me.lblcont.TabIndex = 23
        Me.lblcont.Text = "Cont"
        Me.lblcont.Visible = False
        '
        'lblaut
        '
        Me.lblaut.AutoSize = True
        Me.lblaut.BackColor = System.Drawing.Color.Navy
        Me.lblaut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblaut.ForeColor = System.Drawing.Color.White
        Me.lblaut.Location = New System.Drawing.Point(701, 586)
        Me.lblaut.Name = "lblaut"
        Me.lblaut.Size = New System.Drawing.Size(29, 16)
        Me.lblaut.TabIndex = 24
        Me.lblaut.Text = "aut"
        Me.lblaut.Visible = False
        '
        'frmpdv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SJP_PDV.My.Resources.Resources.pdv6
        Me.ClientSize = New System.Drawing.Size(1050, 665)
        Me.Controls.Add(Me.lblaut)
        Me.Controls.Add(Me.lblcont)
        Me.Controls.Add(Me.lblrv)
        Me.Controls.Add(Me.txtcodbarra)
        Me.Controls.Add(Me.txtqtde)
        Me.Controls.Add(Me.txtvlrunit)
        Me.Controls.Add(Me.txtdesconto)
        Me.Controls.Add(Me.dgvproduto)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblambi)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtcod)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.barinfo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtun)
        Me.Controls.Add(Me.txtvlrtotal)
        Me.Controls.Add(Me.txttotaldesc)
        Me.Controls.Add(Me.txtdescricao)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmpdv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tela de Venda"
        CType(Me.dgvproduto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.barinfo.ResumeLayout(False)
        Me.barinfo.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtdescricao As System.Windows.Forms.TextBox
    Friend WithEvents dgvproduto As System.Windows.Forms.DataGridView
    Friend WithEvents txtvlrtotal As System.Windows.Forms.TextBox
    Friend WithEvents txtdesconto As System.Windows.Forms.TextBox
    Friend WithEvents txtvlrunit As System.Windows.Forms.TextBox
    Friend WithEvents txtqtde As System.Windows.Forms.TextBox
    Friend WithEvents txtcodbarra As System.Windows.Forms.TextBox
    Friend WithEvents barinfo As System.Windows.Forms.StatusStrip
    Friend WithEvents lblinfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lbloperador As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblorc As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txttotaldesc As System.Windows.Forms.TextBox
    Friend WithEvents txtun As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtncm As System.Windows.Forms.TextBox
    Friend WithEvents txtcest As System.Windows.Forms.TextBox
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtvlricms As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtaliqicms As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtcst As System.Windows.Forms.TextBox
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents ToolStripStatuscaixa As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timercad_caixa As System.Windows.Forms.Timer
    Friend WithEvents lblambi As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExcluirItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtcod As System.Windows.Forms.TextBox
    Friend WithEvents n_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cod_barragrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desc_prodgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qtde_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlrunit_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlrdesc_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlrtotal_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codigo_prodgrid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents un_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ncm_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cest_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cst_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aliqicms_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vlricms_grid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblrv As System.Windows.Forms.Label
    Friend WithEvents lblcont As System.Windows.Forms.Label
    Friend WithEvents lblaut As System.Windows.Forms.Label
End Class
