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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // Carrega os dados automaticamente ao abrir o formulário
            txtConsulta2.Text = ""; // Limpa o campo de pesquisa
            btnStatusProcesso.PerformClick(); // Simula clique no botão de pesquisa
        }

        private void btnStatusProcesso_Click(object sender, EventArgs e)
        {
            string consultaCliente = txtConsulta2.Text.Trim();

            if (string.IsNullOrEmpty(consultaCliente))
            {
                MessageBox.Show("Digite um termo para pesquisa!");
                return;
            }

            try
            {
                using (var conexao = Conexao.obterConexao())
                {
                    // Consulta com JOIN entre cliente e status_processo usando id_cliente
                    string query = @"
                        SELECT 
                            c.id_cliente,
                            c.nome,
                            c.cpf,
                            s.status
                        FROM cliente c
                        LEFT JOIN status_processo s ON c.id_cliente = s.id_cliente
                        WHERE c.cpf LIKE @cpf OR c.nome LIKE @cpf";

                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@cpf", "%" + consultaCliente + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Configura a DataGridView para permitir edição
                    dataGridView2.AutoGenerateColumns = false;
                    dataGridView2.DataSource = dt;

                    // Configurar colunas manualmente
                    ConfigurarColunasGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao pesquisar: {ex.Message}\n\nDetalhes:\n{ex.StackTrace}");
            }
        }

        private void ConfigurarColunasGrid()
        {
            dataGridView2.Columns.Clear();

            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "id_cliente",
                HeaderText = "ID Cliente",
                ReadOnly = true
            });

            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "nome",
                HeaderText = "Nome",
                ReadOnly = true
            });

            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "cpf",
                HeaderText = "CPF",
                ReadOnly = true
            });

            // Coluna editável para o status
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "status",
                HeaderText = "Status do Processo"
            });
        }

        private void btnAtualizarStatus_Click(object sender, EventArgs e)
        {
            SalvarAlteracoesStatus();
        }

        private void SalvarAlteracoesStatus()
        {
            var dt = dataGridView2.DataSource as DataTable;
            if (dt == null) return;

            foreach (DataRow row in dt.Rows)
            {
                if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
                {
                    int idCliente = Convert.ToInt32(row["id_cliente"]);
                    string novoStatus = row["status"]?.ToString() ?? "";

                    try
                    {
                        using (var conexao = Conexao.obterConexao())
                        {
                            string queryVerifica = "SELECT COUNT(*) FROM status_processo WHERE id_cliente = @id_cliente";
                            MySqlCommand cmdVerifica = new MySqlCommand(queryVerifica, conexao);
                            cmdVerifica.Parameters.AddWithValue("@id_cliente", idCliente);
                            int count = Convert.ToInt32(cmdVerifica.ExecuteScalar());

                            if (count > 0)
                            {
                                // Atualiza status existente
                                string queryUpdate = "UPDATE status_processo SET status = @status WHERE id_cliente = @id_cliente";
                                MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, conexao);
                                cmdUpdate.Parameters.AddWithValue("@status", novoStatus);
                                cmdUpdate.Parameters.AddWithValue("@id_cliente", idCliente);
                                cmdUpdate.ExecuteNonQuery();
                            }
                            else
                            {
                                // Insere novo registro se não existir
                                string queryInsert = "INSERT INTO status_processo (id_cliente, status) VALUES (@id_cliente, @status)";
                                MySqlCommand cmdInsert = new MySqlCommand(queryInsert, conexao);
                                cmdInsert.Parameters.AddWithValue("@id_cliente", idCliente);
                                cmdInsert.Parameters.AddWithValue("@status", novoStatus);
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar status do ID Cliente {idCliente}: {ex.Message}");
                    }
                }
            }

            MessageBox.Show("Status salvos com sucesso!");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cellValue = dataGridView2.Rows[e.RowIndex].Cells["id_cliente"].Value;
                if (cellValue != null)
                {
                    string cpfSelecionado = cellValue.ToString();
                    MessageBox.Show(cpfSelecionado);
                    ObterStatusProcesso(cpfSelecionado);
                }
                else
                {
                    MessageBox.Show("Valor da célula é nulo.");
                }
            }

        }

        private void ObterStatusProcesso(string cpf)
        {
            try
            {
                using (var conexao = Conexao.obterConexao())
                {
                    string query = "SELECT status FROM status_processo WHERE id_cliente = (SELECT id_cliente FROM cliente WHERE id_cliente = @cpf)";
                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    var status = cmd.ExecuteScalar();
                    if (status != null)
                    {
                        MessageBox.Show($"Status do processo: {status.ToString()}");
                    }
                    else
                    {
                        MessageBox.Show("Nenhum processo encontrado para este CPF.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter status do processo: {ex.Message}");
            }
        }
    }
}