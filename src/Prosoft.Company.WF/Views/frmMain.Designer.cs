namespace Prosoft.Company.WF
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var dataGridViewCellStyle6 = new DataGridViewCellStyle();
            var dataGridViewCellStyle7 = new DataGridViewCellStyle();
            var dataGridViewCellStyle8 = new DataGridViewCellStyle();
            var dataGridViewCellStyle9 = new DataGridViewCellStyle();
            var dataGridViewCellStyle10 = new DataGridViewCellStyle();
            tblFundo = new TableLayoutPanel();
            tblCabecario = new TableLayoutPanel();
            btnAdd = new Button();
            tblRodape = new TableLayoutPanel();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnExit = new Button();
            dtgEmpresas = new DataGridView();
            Cnpj = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            Endereco = new DataGridViewTextBoxColumn();
            Telefone = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            tblFundo.SuspendLayout();
            tblCabecario.SuspendLayout();
            tblRodape.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgEmpresas).BeginInit();
            SuspendLayout();
            // 
            // tblFundo
            // 
            tblFundo.ColumnCount = 1;
            tblFundo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblFundo.Controls.Add(tblCabecario, 0, 0);
            tblFundo.Controls.Add(tblRodape, 0, 2);
            tblFundo.Controls.Add(dtgEmpresas, 0, 1);
            tblFundo.Dock = DockStyle.Fill;
            tblFundo.Location = new Point(0, 0);
            tblFundo.Name = "tblFundo";
            tblFundo.RowCount = 3;
            tblFundo.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tblFundo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblFundo.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tblFundo.Size = new Size(1052, 592);
            tblFundo.TabIndex = 0;
            // 
            // tblCabecario
            // 
            tblCabecario.ColumnCount = 2;
            tblCabecario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblCabecario.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tblCabecario.Controls.Add(btnAdd, 1, 0);
            tblCabecario.Dock = DockStyle.Fill;
            tblCabecario.Location = new Point(3, 3);
            tblCabecario.Name = "tblCabecario";
            tblCabecario.RowCount = 1;
            tblCabecario.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCabecario.Size = new Size(1046, 29);
            tblCabecario.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.Location = new Point(969, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(74, 23);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "&Adicionar";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // tblRodape
            // 
            tblRodape.ColumnCount = 4;
            tblRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tblRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tblRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tblRodape.Controls.Add(btnUpdate, 1, 0);
            tblRodape.Controls.Add(btnDelete, 2, 0);
            tblRodape.Controls.Add(btnExit, 3, 0);
            tblRodape.Dock = DockStyle.Fill;
            tblRodape.Location = new Point(3, 560);
            tblRodape.Name = "tblRodape";
            tblRodape.RowCount = 1;
            tblRodape.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblRodape.Size = new Size(1046, 29);
            tblRodape.TabIndex = 1;
            // 
            // btnUpdate
            // 
            btnUpdate.Dock = DockStyle.Fill;
            btnUpdate.Location = new Point(809, 3);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(74, 23);
            btnUpdate.TabIndex = 0;
            btnUpdate.Text = "A&lterar";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Location = new Point(889, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(74, 23);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "&Excluir";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnExit
            // 
            btnExit.Dock = DockStyle.Fill;
            btnExit.Location = new Point(969, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(74, 23);
            btnExit.TabIndex = 2;
            btnExit.Text = "&Sair";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // dtgEmpresas
            // 
            dtgEmpresas.AllowUserToAddRows = false;
            dtgEmpresas.AllowUserToDeleteRows = false;
            dtgEmpresas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgEmpresas.Columns.AddRange(new DataGridViewColumn[] { Cnpj, Nome, Endereco, Telefone, Email });
            dtgEmpresas.Dock = DockStyle.Fill;
            dtgEmpresas.Location = new Point(3, 38);
            dtgEmpresas.MultiSelect = false;
            dtgEmpresas.Name = "dtgEmpresas";
            dtgEmpresas.ReadOnly = true;
            dtgEmpresas.RowHeadersVisible = false;
            dtgEmpresas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dtgEmpresas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgEmpresas.ShowCellErrors = false;
            dtgEmpresas.ShowCellToolTips = false;
            dtgEmpresas.ShowEditingIcon = false;
            dtgEmpresas.ShowRowErrors = false;
            dtgEmpresas.Size = new Size(1046, 516);
            dtgEmpresas.TabIndex = 2;
            dtgEmpresas.CellDoubleClick += dtgEmpresas_CellDoubleClick;
            // 
            // Cnpj
            // 
            Cnpj.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Cnpj.DataPropertyName = "Cnpj";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Cnpj.DefaultCellStyle = dataGridViewCellStyle6;
            Cnpj.HeaderText = "CNPJ";
            Cnpj.MinimumWidth = 120;
            Cnpj.Name = "Cnpj";
            Cnpj.ReadOnly = true;
            Cnpj.Width = 120;
            // 
            // Nome
            // 
            Nome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Nome.DataPropertyName = "Nome";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            Nome.DefaultCellStyle = dataGridViewCellStyle7;
            Nome.HeaderText = "Razão Social";
            Nome.Name = "Nome";
            Nome.ReadOnly = true;
            // 
            // Endereco
            // 
            Endereco.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Endereco.DataPropertyName = "Endereco";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            Endereco.DefaultCellStyle = dataGridViewCellStyle8;
            Endereco.HeaderText = "Endereço";
            Endereco.Name = "Endereco";
            Endereco.ReadOnly = true;
            // 
            // Telefone
            // 
            Telefone.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Telefone.DataPropertyName = "Telefone";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Telefone.DefaultCellStyle = dataGridViewCellStyle9;
            Telefone.HeaderText = "Telefone";
            Telefone.MinimumWidth = 120;
            Telefone.Name = "Telefone";
            Telefone.ReadOnly = true;
            Telefone.Width = 120;
            // 
            // Email
            // 
            Email.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Email.DataPropertyName = "Email";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            Email.DefaultCellStyle = dataGridViewCellStyle10;
            Email.HeaderText = "E-Mail";
            Email.Name = "Email";
            Email.ReadOnly = true;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(1052, 592);
            Controls.Add(tblFundo);
            Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Empresas";
            tblFundo.ResumeLayout(false);
            tblCabecario.ResumeLayout(false);
            tblRodape.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgEmpresas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblFundo;
        private TableLayoutPanel tblCabecario;
        private Button btnAdd;
        private TableLayoutPanel tblRodape;
        private DataGridView dtgEmpresas;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnExit;
        private DataGridViewTextBoxColumn Cnpj;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Endereco;
        private DataGridViewTextBoxColumn Telefone;
        private DataGridViewTextBoxColumn Email;
    }
}
