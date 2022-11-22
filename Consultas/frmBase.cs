using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultas
{
    public partial class frmBase : Form
    {
        public enum StatusCadastro 
        {
            scInserindo, 
            scNavegando,
            scEditando
        }
        public StatusCadastro sStatus;
        public int _nCodGenerico;
        public frmBase()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                Close();
            }
        }
        private void LimparControles() 
        {
            foreach (Control ctr in this.Controls) 
            {
                if (ctr is TextBox)
                    (ctr as TextBox).Text = "";

                if (ctr is ComboBox)
                    (ctr as ComboBox).SelectedIndex = -1;

                if (ctr is ListBox)
                    (ctr as ListBox).SelectedIndex = -1;

                if (ctr is RadioButton)
                    (ctr as RadioButton).Checked = false;

                if (ctr is CheckBox)
                    (ctr as CheckBox).Checked = false;

                if (ctr is CheckedListBox)
                {
                    foreach (ListControl item in (ctr as CheckedListBox).Items) 
                        item.SelectedIndex = -1;
                }
            }
        }
        public virtual bool Salvar() 
        {
            return false;
        }
        public virtual bool Excluir()
        {
            return false;
        }
        public virtual bool Localizar()
        {
            return false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Excluir())
            {
                LimparControles();
                MessageBox.Show("Registro excluído com sucesso", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Registro não salvo, por favor, verifique os erros", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Salvar())
            {
                sStatus = StatusCadastro.scNavegando;
                LimparControles();
                MessageBox.Show("Registro salvo com sucesso", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show("Registro não excluído, por favor, verifique os erros", "Erro",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            sStatus = StatusCadastro.scInserindo;
            LimparControles();
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            if (Localizar()) 
            {
                sStatus = StatusCadastro.scEditando;
                HabilitarDesabilitarControles(true);
                CarregarValores();
            }

        }
        public virtual void CarregarValores() 
        {
            //nao entendi
        }
        private void HabilitarDesabilitarControles(bool bValue) 
        {
            foreach (Control ctr in this.Controls) 
            {
                if (ctr is ToolStrip)
                    continue;
                ctr.Enabled = bValue;
            }
            btnNovo.Enabled = (sStatus == StatusCadastro.scNavegando);

            btnSalvar.Enabled = (sStatus == StatusCadastro.scNavegando || sStatus == StatusCadastro.scInserindo);

            btnExcluir.Enabled = (sStatus == StatusCadastro.scEditando);

            btnLocalizar.Enabled = (sStatus == StatusCadastro.scNavegando);

            btnFechar.Enabled = true;
        }

        private void frmBase_Load(object sender, EventArgs e)
        {
            sStatus = StatusCadastro.scNavegando;
            LimparControles();
            HabilitarDesabilitarControles(false);
        }
    }
}
