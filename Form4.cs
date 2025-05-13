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
    public partial class FrmConsultarCliente : Form
    {
        private object dgvResultados;

        public FrmConsultarCliente()
        {
            InitializeComponent();
        }

        private void btnConsultaCliente_Click_1(object sender, EventArgs e)
        {
            string consultaCliente = txtConsulta.Text.Trim();

            if (string.IsNullOrEmpty(consultaCliente))
            {
                MessageBox.Show("Digite um termo para pesquisa!");
                return;
            }

            try
            {
                using (var conexao = Conexao.obterConexao())
                {
                    string query = "SELECT id_cliente, nome, profissao, data_nasc, rg, endereco, numero_casa, complemento, bairro, cidade, estado, cep, telefone, celular, email FROM cliente WHERE cpf LIKE @cpf ";
                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@cpf", "%" + consultaCliente + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Tratamento para valores de data/hora nulos ou inválidos
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.DataType == typeof(DateTime) && row[col] == DBNull.Value)
                            {
                                row[col] = DateTime.MinValue; // Ou qualquer valor padrão que você prefira
                            }
                        }
                    }

                    dataGridView3.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao pesquisar: {ex.Message}\n\nDetalhes:\n{ex.StackTrace}");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {


            if (dataGridView3 != null && dataGridView3.CurrentRow != null)
            {
                string idSelecionado = dataGridView3.CurrentRow.Cells["id_cliente"].Value.ToString();
                FormEditarCliente editarCliente = new FormEditarCliente(idSelecionado);
                editarCliente.ShowDialog(); // Use ShowDialog to wait for the form to close before continuing

                // Atualize a fonte de dados após a edição
                AtualizarDataGridView();
            }
        }

        private void AtualizarDataGridView()
        {
            try
            {
                using (var conexao = Conexao.obterConexao())
                {
                    string query = "SELECT id_cliente, nome, profissao, data_nasc, rg, endereco, numero_casa, complemento, bairro, cidade, estado, cep, telefone, celular, email FROM cliente";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexao);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView3.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar dados: " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente para excluir.");
                return;
            }

            var resultado = MessageBox.Show("Tem certeza que deseja excluir este cliente?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No) return;

            string idCliente = dataGridView3.SelectedRows[0].Cells["id_cliente"].Value.ToString();

            try
            {
                using (var conexao = Conexao.obterConexao())
                {
                    string query = "DELETE FROM cliente WHERE id_cliente = @id_cliente";
                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cliente excluído com sucesso.");
                        AtualizarDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Cliente não encontrado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir cliente: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string cpfSelecionado = dataGridView3.Rows[e.RowIndex].Cells["cpf"].Value.ToString();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}