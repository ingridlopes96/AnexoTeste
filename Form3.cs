using Microsoft.Win32.SafeHandles;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Anexos
{
    public partial class frmNovoCliente : Form
    {
        public frmNovoCliente()
        {
            InitializeComponent();
        }

        private void frmNovoCliente_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {

<<<<<<< HEAD
=======
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
        string.IsNullOrWhiteSpace(textBox2.Text) ||
        string.IsNullOrWhiteSpace(textBox3.Text) ||
        string.IsNullOrWhiteSpace(textBox4.Text) ||
        string.IsNullOrWhiteSpace(textBox5.Text) ||
        string.IsNullOrWhiteSpace(textBox6.Text) ||
        string.IsNullOrWhiteSpace(textBox8.Text) ||
        string.IsNullOrWhiteSpace(textBox9.Text) ||
        comboBox2.SelectedItem == null ||
        string.IsNullOrWhiteSpace(textBox10.Text) ||
        string.IsNullOrWhiteSpace(textBox11.Text) ||
        string.IsNullOrWhiteSpace(textBox12.Text) ||
        string.IsNullOrWhiteSpace(textBox13.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conexao = Conexao.obterConexao())

                {

                    
                    string query = "INSERT INTO cliente  (nome, " +
                        "profissao, " +
                        "data_nasc, " +
                        "rg, " +
                        "cpf, " +
                        "endereco," +
                        " numero_casa," +
                        "complemento," +
                        "bairro," +
                        "cidade," +
                        "estado," +
                        "cep," +
                        "telefone, " +
                        "celular, " +
                        "email) VALUES  (@nome," +
                        "@profissao," +
                        "@dataNascimento," +
                        "@rg," +
                        "@cpf," +
                        "@endereco," +
                        "@numero," +
                        "@complemento," +
                        "@bairro," +
                        "@cidade," +
                        "@estado," +
                        "@cep," +
                        "@telefone," +
                        "@celular," +
                        "@email );";
                    MySqlCommand cmd = new MySqlCommand(query, conexao);


                    cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                    cmd.Parameters.AddWithValue("@profissao", textBox2.Text);
                    cmd.Parameters.AddWithValue("@dataNascimento", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@rg", textBox3.Text);
                    cmd.Parameters.AddWithValue("@cpf", textBox4.Text);
                    cmd.Parameters.AddWithValue("@endereco", textBox5.Text);
                    cmd.Parameters.AddWithValue("@numero", textBox6.Text);
                    cmd.Parameters.AddWithValue("@complemento", textBox7.Text);
                    cmd.Parameters.AddWithValue("@bairro", textBox8.Text);
                    cmd.Parameters.AddWithValue("@cidade", textBox9.Text);
                    cmd.Parameters.AddWithValue("@estado", comboBox2.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@cep", textBox10.Text);                  
                    cmd.Parameters.AddWithValue("@telefone", textBox11.Text);                  
                    cmd.Parameters.AddWithValue("@celular", textBox12.Text);
                    cmd.Parameters.AddWithValue("@email", textBox13.Text);

                    // Executar
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cadastro realizado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Cadastro não realizado. Nenhuma linha afetada.");
                    }

                }
            }


            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
>>>>>>> origin/jefferson
        }
    }
}



