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
    public partial class frmPesquisaBase : Form
    {
        public string sCdCodigo;
        public frmPesquisaBase()
        {
            InitializeComponent();
            sCdCodigo = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPesquisaBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                Close();
                DialogResult = DialogResult.Cancel;
            }
            if (e.KeyCode == Keys.Enter)
            {
                Close();
                DialogResult = DialogResult.Cancel;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (sCdCodigo == "") 
            {
                if (lstPesquisa.Focused) 
                {
                    sCdCodigo = lstPesquisa.SelectedItems[0].Text;
                }
            }
        }
        private void lstPesquisa_SelectedIndexChanged(object sender, EventArgs e) 
        {
            try
            {
                sCdCodigo = lstPesquisa.SelectedItems[0].Text;
            }
            catch
            {

            }
        }

        private void lstPesquisa_DoubleClick(object sender, EventArgs e)
        {
           
            try
            {
                sCdCodigo = lstPesquisa.SelectedItems[0].Text;
                Close();
                DialogResult = DialogResult.OK;
            }
            catch
            {
                //PAREI NA PARTE 6
            }
        }
        public virtual void Pesquisar() 
        {
        
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();

            lblMensagem.Text = "Encontrado(s): \""+ lstPesquisa.Items.Count + "\" registros com a palavra \"" + txtPesquisar.Text + "\"";

            btnOK.Enabled = lstPesquisa.Items.Count > 0;
            if (btnOK.Enabled) 
            {
                lstPesquisa.Focus();
            }
        }
        public void CarregarItens(DataTable dt) 
        {
            lstPesquisa.Items.Clear();
            foreach (DataRow dr in dt.Rows) 
            {
                ListViewItem item = new ListViewItem();
                item.Text = dr[0].ToString();
                item.SubItems.Add(dr[1].ToString());
                lstPesquisa.Items.Add(item);
            }
        }

        private void rdtCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisar.Focus();
        }

        private void rbtDescricao_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisar.Focus();
        }
    }
}
