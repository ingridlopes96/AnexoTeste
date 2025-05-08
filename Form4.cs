using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anexos
{
    public partial class FrmConsultarCliente: Form
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
            // Método para atualizar a fonte de dados do dataGridView3
            // Exemplo:
            dataGridView3.DataSource = ObterDadosAtualizados();
        }

        private DataTable ObterDadosAtualizados()
        {
            // Método para obter os dados atualizados do banco de dados ou outra fonte
            DataTable dt = new DataTable();
            // Preencha o DataTable com os dados atualizados
            return dt;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
             
                string cpfSelecionado = dataGridView3.Rows[e.RowIndex].Cells["cpf"].Value.ToString();
                // Passa o CPF selecionado para o formulário de edição
                //FormEditarCliente editarCliente = new FormEditarCliente();
                //editarCliente.SetCpf(cpfSelecionado);
                //editarCliente.Show();
            }
           
        }
    }
}

