namespace Prosoft.Company.WF
{
    partial class frmDadosCompany
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tblFundo = new TableLayoutPanel();
            tblCampos = new TableLayoutPanel();
            lblCnpj = new Label();
            txtCnpj = new TextBox();
            lblNome = new Label();
            txtNome = new TextBox();
            lblEndereco = new Label();
            txtEndereco = new TextBox();
            lblTelefone = new Label();
            txtTelefone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            tblBotoes = new TableLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();
            tblFundo.SuspendLayout();
            tblCampos.SuspendLayout();
            tblBotoes.SuspendLayout();
            SuspendLayout();
            // 
            // tblFundo
            // 
            tblFundo.ColumnCount = 1;
            tblFundo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblFundo.Controls.Add(tblCampos, 0, 0);
            tblFundo.Controls.Add(tblBotoes, 0, 1);
            tblFundo.Dock = DockStyle.Fill;
            tblFundo.Location = new Point(0, 0);
            tblFundo.Name = "tblFundo";
            tblFundo.RowCount = 2;
            tblFundo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblFundo.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tblFundo.Size = new Size(497, 183);
            tblFundo.TabIndex = 0;
            // 
            // tblCampos
            // 
            tblCampos.ColumnCount = 2;
            tblCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tblCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblCampos.Controls.Add(lblCnpj, 0, 0);
            tblCampos.Controls.Add(txtCnpj, 1, 0);
            tblCampos.Controls.Add(lblNome, 0, 1);
            tblCampos.Controls.Add(txtNome, 1, 1);
            tblCampos.Controls.Add(lblEndereco, 0, 2);
            tblCampos.Controls.Add(txtEndereco, 1, 2);
            tblCampos.Controls.Add(lblTelefone, 0, 3);
            tblCampos.Controls.Add(txtTelefone, 1, 3);
            tblCampos.Controls.Add(lblEmail, 0, 4);
            tblCampos.Controls.Add(txtEmail, 1, 4);
            tblCampos.Dock = DockStyle.Fill;
            tblCampos.Location = new Point(3, 3);
            tblCampos.Name = "tblCampos";
            tblCampos.RowCount = 6;
            tblCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tblCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tblCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tblCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tblCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tblCampos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCampos.Size = new Size(491, 142);
            tblCampos.TabIndex = 0;
            // 
            // lblCnpj
            // 
            lblCnpj.AutoSize = true;
            lblCnpj.Dock = DockStyle.Fill;
            lblCnpj.Location = new Point(3, 0);
            lblCnpj.Name = "lblCnpj";
            lblCnpj.Size = new Size(84, 28);
            lblCnpj.TabIndex = 0;
            lblCnpj.Text = " CNPJ:";
            lblCnpj.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCnpj
            // 
            txtCnpj.Dock = DockStyle.Fill;
            txtCnpj.Location = new Point(93, 3);
            txtCnpj.Name = "txtCnpj";
            txtCnpj.Size = new Size(395, 21);
            txtCnpj.TabIndex = 1;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Dock = DockStyle.Fill;
            lblNome.Location = new Point(3, 28);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(84, 28);
            lblNome.TabIndex = 2;
            lblNome.Text = " Razão Social:";
            lblNome.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtNome
            // 
            txtNome.Dock = DockStyle.Fill;
            txtNome.Location = new Point(93, 31);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(395, 21);
            txtNome.TabIndex = 3;
            // 
            // lblEndereco
            // 
            lblEndereco.AutoSize = true;
            lblEndereco.Dock = DockStyle.Fill;
            lblEndereco.Location = new Point(3, 56);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.Size = new Size(84, 28);
            lblEndereco.TabIndex = 4;
            lblEndereco.Text = " Endereço:";
            lblEndereco.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEndereco
            // 
            txtEndereco.Dock = DockStyle.Fill;
            txtEndereco.Location = new Point(93, 59);
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(395, 21);
            txtEndereco.TabIndex = 5;
            // 
            // lblTelefone
            // 
            lblTelefone.AutoSize = true;
            lblTelefone.Dock = DockStyle.Fill;
            lblTelefone.Location = new Point(3, 84);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(84, 28);
            lblTelefone.TabIndex = 6;
            lblTelefone.Text = " Telefone:";
            lblTelefone.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTelefone
            // 
            txtTelefone.Dock = DockStyle.Fill;
            txtTelefone.Location = new Point(93, 87);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(395, 21);
            txtTelefone.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Dock = DockStyle.Fill;
            lblEmail.Location = new Point(3, 112);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(84, 28);
            lblEmail.TabIndex = 8;
            lblEmail.Text = " E-Mail:";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Location = new Point(93, 115);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(395, 21);
            txtEmail.TabIndex = 9;
            // 
            // tblBotoes
            // 
            tblBotoes.ColumnCount = 3;
            tblBotoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblBotoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tblBotoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tblBotoes.Controls.Add(btnSave, 1, 0);
            tblBotoes.Controls.Add(btnCancel, 2, 0);
            tblBotoes.Dock = DockStyle.Fill;
            tblBotoes.Location = new Point(3, 151);
            tblBotoes.Name = "tblBotoes";
            tblBotoes.RowCount = 1;
            tblBotoes.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblBotoes.Size = new Size(491, 29);
            tblBotoes.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Fill;
            btnSave.Location = new Point(334, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(74, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "&Salvar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Fill;
            btnCancel.Location = new Point(414, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(74, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "&Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmDadosCompany
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(497, 183);
            Controls.Add(tblFundo);
            Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDadosCompany";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Dados da Empresa";
            tblFundo.ResumeLayout(false);
            tblCampos.ResumeLayout(false);
            tblCampos.PerformLayout();
            tblBotoes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblFundo;
        private TableLayoutPanel tblCampos;
        private TableLayoutPanel tblBotoes;
        private Label lblCnpj;
        private TextBox txtCnpj;
        private Label lblNome;
        private TextBox txtNome;
        private Label lblEndereco;
        private TextBox txtEndereco;
        private Label lblTelefone;
        private TextBox txtTelefone;
        private Label lblEmail;
        private TextBox txtEmail;
        private Button btnSave;
        private Button btnCancel;
    }
}