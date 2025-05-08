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
    public partial class FormEditarCliente: Form
    {
        private string id;

        public FormEditarCliente(string id)
        {
            InitializeComponent();
            this.id = id;
            textBox4.ReadOnly = true; // Não permite editar CPF
            textBox4.BackColor = SystemColors.Control; // Muda a cor de fundo para cinza

            CarregarDadosCliente();

        }

        private void FormEditarCliente_Load(object sender, EventArgs e)
        {
            CarregarDadosCliente();
        }

        private void CarregarDadosCliente()
        {
            try
            {
                using (var conexao = Conexao.obterConexao())
                {
                    string query = "SELECT nome, profissao, data_nasc, rg, cpf, endereco, numero_casa, complemento, bairro, cidade, estado, cep, telefone, celular, email FROM cliente WHERE id_cliente = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        textBox1.Text = reader["nome"].ToString();    
                        textBox4.Text = reader["cpf"].ToString();      
                        textBox4.ReadOnly = true;                    
                        textBox4.BackColor = SystemColors.Control;

                        textBox2.Text = reader["profissao"].ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(reader["data_nasc"]);
                        textBox3.Text = reader["rg"].ToString();
                        textBox5.Text = reader["endereco"].ToString();
                        textBox6.Text = reader["numero_casa"].ToString();
                        textBox7.Text = reader["complemento"].ToString();
                        textBox8.Text = reader["bairro"].ToString();
                        textBox9.Text = reader["cidade"].ToString();
                        comboBox2.SelectedItem = reader["estado"].ToString();
                        textBox10.Text = reader["cep"].ToString();
                        textBox11.Text = reader["telefone"].ToString();
                        textBox12.Text = reader["celular"].ToString();
                        textBox13.Text = reader["email"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Cliente não encontrado.");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }
        private void btnSalvarEdicao_Click(object sender, EventArgs e)
        {
            string novoNome = textBox1.Text.Trim();
            string novoCpf = textBox4.Text.Trim();

            if (string.IsNullOrEmpty(novoNome))
            {
                MessageBox.Show("Preencha o nome corretamente.");
                return;
            }

            try
            {
                using (var conexao = Conexao.obterConexao())
                {
                    string query = @"UPDATE cliente 
                             SET nome = @nome, 
                                 profissao = @profissao, 
                                 data_nasc = @data_nasc, 
                                 rg = @rg, 
                                 endereco = @endereco, 
                                 numero_casa = @numero_casa, 
                                 complemento = @complemento, 
                                 bairro = @bairro, 
                                 cidade = @cidade, 
                                 estado = @estado, 
                                 cep = @cep, 
                                 telefone = @telefone, 
                                 celular = @celular, 
                                 email = @email 
                             WHERE cpf = @cpf";

                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@nome", novoNome);
                    cmd.Parameters.AddWithValue("@cpf", novoCpf);
                    cmd.Parameters.AddWithValue("@profissao", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@data_nasc", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@rg", textBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@endereco", textBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@numero_casa", textBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@complemento", textBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@bairro", textBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@cidade", textBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@estado", comboBox2.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@cep", textBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefone", textBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@celular", textBox12.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", textBox13.Text.Trim());

                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        MessageBox.Show("Dados atualizados com sucesso!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nenhum registro foi atualizado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }

        private void btnSalvarEdicao_Click_1(object sender, EventArgs e)
        {
            {
                string novoNome = textBox1.Text.Trim();
                string novoCpf = textBox4.Text.Trim();

                if (string.IsNullOrEmpty(novoNome))
                {
                    MessageBox.Show("Preencha o nome corretamente.");
                    return;
                }

                try
                {
                    using (var conexao = Conexao.obterConexao())
                    {
                        string query = @"UPDATE cliente 
                             SET nome = @nome, 
                                 profissao = @profissao, 
                                 data_nasc = @data_nasc, 
                                 rg = @rg, 
                                 endereco = @endereco, 
                                 numero_casa = @numero_casa, 
                                 complemento = @complemento, 
                                 bairro = @bairro, 
                                 cidade = @cidade, 
                                 estado = @estado, 
                                 cep = @cep, 
                                 telefone = @telefone, 
                                 celular = @celular, 
                                 email = @email 
                             WHERE cpf = @cpf";

                        MySqlCommand cmd = new MySqlCommand(query, conexao);
                        cmd.Parameters.AddWithValue("@nome", novoNome);
                        cmd.Parameters.AddWithValue("@cpf", novoCpf);
                        cmd.Parameters.AddWithValue("@profissao", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@data_nasc", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@rg", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@endereco", textBox5.Text.Trim());
                        cmd.Parameters.AddWithValue("@numero_casa", textBox6.Text.Trim());
                        cmd.Parameters.AddWithValue("@complemento", textBox7.Text.Trim());
                        cmd.Parameters.AddWithValue("@bairro", textBox8.Text.Trim());
                        cmd.Parameters.AddWithValue("@cidade", textBox9.Text.Trim());
                        cmd.Parameters.AddWithValue("@estado", comboBox2.SelectedItem?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@cep", textBox10.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefone", textBox11.Text.Trim());
                        cmd.Parameters.AddWithValue("@celular", textBox12.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", textBox13.Text.Trim());

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Dados atualizados com sucesso!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Nenhum registro foi atualizado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar: " + ex.Message);
                }
            }
        }
    }
}

