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

namespace Anexos
{
    public partial class PrimeiroAcesso : Form
    {
        public PrimeiroAcesso()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario1.Text;
            string senha = txtSenha1.Text;
            string senhaConfirmacao = txtConfirmaSenha1.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha todos os campos");
                return;
            }

            if (senha != senhaConfirmacao)
            {
                MessageBox.Show("As senhas não coincidem");
                return;
            }

            string senhaHash = Criptografia.GerarHash(senha);

            using (var conexao = Conexao.obterConexao())
            {
                string query = "INSERT INTO login (usuario, senha) VALUES (@usuario, @senha)";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@senha", senhaHash);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuário cadastrado com sucesso!");
                }

                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        MessageBox.Show("Usuário já cadastrado");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message);
                    }
                }
            }
        }
    }
}
