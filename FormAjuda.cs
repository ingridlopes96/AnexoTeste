using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Anexos
{
    public partial class FormAjuda : Form
    {
        public FormAjuda()
        {
            InitializeComponent();
        }

        private void FormAjuda_Load(object sender, EventArgs e)
        {
            // Carrega todos os registros ao abrir a tela
            CarregarTodasPerguntas();
        }

        private void CarregarTodasPerguntas()
        {
            try
            {
                using (var conexao = Conexao.obterConexao())
                {
                    string query = "SELECT pergunta AS Pergunta, resposta AS Resposta FROM ajuda";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexao);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    //dataGridViewFAQ.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar perguntas: " + ex.Message);
            }
        }

        private void MostrarResposta(int id)
        {
            try
            {
                using (var conexao = Conexao.obterConexao())
                {
                    string query = "SELECT pergunta, resposta FROM ajuda WHERE id_ajuda = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string pergunta = reader["pergunta"].ToString();
                            string resposta = reader["resposta"].ToString();

                            lblDescricao.Text = $"{pergunta}\n\n{resposta}";
                        }
                        else
                        {
                            lblDescricao.Text = "Pergunta não encontrada.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar resposta: " + ex.Message);
            }
        }

        // Botões que chamam as perguntas específicas
        private void button1_Click(object sender, EventArgs e) => MostrarResposta(1);
        private void button2_Click(object sender, EventArgs e) => MostrarResposta(2);
        private void button3_Click(object sender, EventArgs e) => MostrarResposta(3);
        private void button4_Click(object sender, EventArgs e) => MostrarResposta(4);
        private void button5_Click(object sender, EventArgs e) => MostrarResposta(5);
        private void button6_Click(object sender, EventArgs e) => MostrarResposta(6);

        private void label1_Click(object sender, EventArgs e)
        {
            // Evento vazio, pode ser removido se não for usado
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Você pode implementar edição depois
        }
    }
}