using Consultas.dsConsultaTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Consultas
{
    public partial class frmPacienteHerdado : Consultas.frmBase
    {
        public frmPacienteHerdado()
        {
            InitializeComponent();
        }
        private void frmPacienteHerdado_Load(object sender, EventArgs e)
        {

        }
        public override bool Salvar()
        {
            bool bSalvar = false;
            dsConsultaTableAdapters.PacienteTableAdapter ta = new PacienteTableAdapter();
            if (sStatus == StatusCadastro.scInserindo) 
            {
                bSalvar = (ta.Insert(txtNome.Text, txtTelefone.Text) > 0);
            }
            else
            {
                bSalvar = (ta.Update(txtNome.Text, txtTelefone.Text, int.Parse(lblCodigo.Text)) > 0);
            }
            return bSalvar;
        }
        public override bool Excluir()
        {
            bool bExcluir = false;
            dsConsultaTableAdapters.PacienteTableAdapter ta = new PacienteTableAdapter();
            bExcluir = (ta.Delete(int.Parse(lblCodigo.Text)) > 0);

            return bExcluir;
        }
        public override void CarregarValores()
        {
            dsConsulta.PacienteDataTable dt = new dsConsulta.PacienteDataTable();
            PacienteTableAdapter ta = new PacienteTableAdapter();
            dt = ta.PesquisaID(_nCodGenerico);
            if (dt.Rows.Count > 0) 
            {
                lblCodigo.Text = dt.Rows[0]["IDPACIENTE"].ToString();
                txtNome.Text = dt.Rows[0]["NOMEPACIENTE"].ToString();
                txtTelefone.Text = dt.Rows[0]["TELEFONE"].ToString();

            }
        }
        public override bool Localizar()
        {
            bool bLocalizar = false;
            PesquisaPaciente frmPesquisa = new PesquisaPaciente();//era frmPesquisaPaciente no tutorial...
            if (frmPesquisa.ShowDialog() == DialogResult.OK) 
            {
                bLocalizar = (frmPesquisa.sCdCodigo != "");
                if (bLocalizar) 
                {
                    _nCodGenerico = int.Parse(frmPesquisa.sCdCodigo);
                }
            }
            return bLocalizar;
        }
    }    
}
