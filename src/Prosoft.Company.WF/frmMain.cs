using Prosoft.Company.Domain.Entities;

namespace Prosoft.Company.WF
{
    public partial class frmMain : Form
    {
        private IList<CompanyModel> _companies;

        public frmMain()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Icone;
            _companies = new List<CompanyModel>();
            LoadData();
        }

        private void LoadData()
        {
            var result = Program.GetAllCompanyUseCase.Execute();
            if (!result.Sucesso)
            {
                MessageBox.Show($"Ocorreu um erro ao carregar empresas:{Environment.NewLine}{result.MensagemErro}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _companies = result.Empresas.ToList();
            dtgEmpresas.AutoGenerateColumns = false;
            dtgEmpresas.DataSource = _companies;
        }

        private void UpdateData()
        {
            if (dtgEmpresas.SelectedRows.Count <= 0)
            {
                return;
            }

            var company = (CompanyModel)dtgEmpresas.SelectedRows[0].DataBoundItem;

            frmDadosCompany form = new frmDadosCompany()
            {
                ActionType = ActionsType.Update,
                Company = company,
                Text = $"Alterar Empresa CNPJ:{company.Cnpj}",
            };
            form.BindControl();

            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDadosCompany form = new frmDadosCompany()
            {
                ActionType = ActionsType.Add,
                Company = new CompanyModel(),
                Text = "Adicionar Empresa",
            };
            form.BindControl();

            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void dtgEmpresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtgEmpresas.SelectedRows.Count <= 0)
            {
                return;
            }

            var company = (CompanyModel)dtgEmpresas.SelectedRows[0].DataBoundItem;

            var result = Program.DeleteCompanyUseCase.Execute(company.Id);
            if (!result.Sucesso)
            {
                MessageBox.Show($"Ocorreu um erro ao carregar empresas:{Environment.NewLine}{result.MensagemErro}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            LoadData();
        }
    }
}
