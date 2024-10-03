using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prosoft.Company.Domain.Entities;
using Prosoft.Company.WF.Enums;

namespace Prosoft.Company.WF
{
    public partial class frmDadosCompany : Form
    {
        public CompanyModel Company { get; set; } = new CompanyModel();

        public ActionsType ActionType { get; set; } = ActionsType.Add;

        public frmDadosCompany()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Icone;
        }

        public void BindControl()
        {
            Company = Company ?? new CompanyModel();
            txtCnpj.DataBindings.Clear();
            txtCnpj.DataBindings.Add("Text", Company, "Cnpj", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCnpj.Enabled = ActionType == ActionsType.Add;

            txtNome.DataBindings.Clear();
            txtNome.DataBindings.Add("Text", Company, "Nome", true, DataSourceUpdateMode.OnPropertyChanged);

            txtEndereco.DataBindings.Clear();
            txtEndereco.DataBindings.Add("Text", Company, "Endereco", true, DataSourceUpdateMode.OnPropertyChanged);

            txtTelefone.DataBindings.Clear();
            txtTelefone.DataBindings.Add("Text", Company, "Telefone", true, DataSourceUpdateMode.OnPropertyChanged);

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", Company, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var result = ActionType == ActionsType.Add ?
                Program.AddCompanyUseCase.Execute(Company) :
                Program.UpdateCompanyUseCase.Execute(Company);

            if (!result.Sucesso)
            {
                MessageBox.Show($"Ocorreu um erro ao carregar empresas:{Environment.NewLine}{result.MensagemErro}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
