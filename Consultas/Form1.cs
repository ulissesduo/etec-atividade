using Consultas.dsConsultaTableAdapters;
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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            dsConsulta.MedicoDataTable dt = new dsConsulta.MedicoDataTable();
            MedicoTableAdapter ta = new MedicoTableAdapter();
            ta.PesquisaID(dt, 1);
            dt.Rows[1]["IDMEDICO"].ToString();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            PesquisaPaciente frmPaciente = new PesquisaPaciente();
            frmPaciente.ShowDialog();
        }
    }
}
