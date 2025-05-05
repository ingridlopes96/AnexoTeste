using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anexos
{
    public partial class frmHome: Form
    {

        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {

        }

        public partial class frmStatusprocesso : Form
        {

        }

        public partial class frmAjuda : Form
        {

        }
        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            frmNovoCliente novoCliente = new frmNovoCliente();
            novoCliente.Show();
            
        }

        private void btnConsultarCliente_Click(object sender, EventArgs e)
        {
            FrmConsultarCliente consultarCliente = new FrmConsultarCliente();
            consultarCliente.Show();
            
        }

        private void btnStatusProcesso_Click(object sender, EventArgs e)
        {
            Form5 statusprocesso = new Form5();
            statusprocesso.Show();
        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            Form6 ajuda = new Form6();
            ajuda.Show();
        }
    }
}
