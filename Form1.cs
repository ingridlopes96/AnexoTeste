using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Anexos
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            string usuario = txtLogin.Text;
            string senha = txtSenha.Text;

            string senhaHash = Criptografia.GerarHash(senha);

            using (var conexao = Conexao.obterConexao())
            {
                string query = "SELECT * FROM login WHERE usuario = @usuario AND senha = @senha";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@senha", senhaHash);

                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    MessageBox.Show("Login realizado com sucesso!");
                    frmHome home = new frmHome();
                    home.Show();
                }
                else
                {
                    MessageBox.Show("Usuario ou senha invalidos");
                }
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PrimeiroAcesso primeiroAcesso = new PrimeiroAcesso();
            primeiroAcesso.Show();
            this.Hide(); // Esconde o formulário de login

        }
    }
}
