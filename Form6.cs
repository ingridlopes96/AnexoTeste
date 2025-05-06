using MySqlX.XDevAPI;
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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
         private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string termo = btnajuda.Text.ToLower();
            var resultados = dados.Where(d => d.ToLower().Contains(termo)).ToList();

            lstResultados.Items.Clear();

            if (resultados.Any())
            {
                foreach (var item in resultados)
                {
                    lstResultados.Items.Add(item);
                }
            }
            else
            {
                lstResultados.Items.Add("Nenhum resultado encontrado.");
            }
        }
    }
    }
}
