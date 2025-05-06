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
                    string query = "SELECT id_cliente, nome, cpf FROM cadastro_cliente WHERE cpf LIKE @cpf";
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

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao pesquisar: {ex.Message}\n\nDetalhes:\n{ex.StackTrace}");
            }
        }

    }
}
