using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Anexos
{
    public partial class Upload: Form
    {
        private string conexao = "server=localhost;user=root;password=senacJBQ;database=upload_db;port=3307";
        public Upload()
        {
            InitializeComponent();

        }

        private void Upload_Load(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {

            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                string sql = "SELECT id, nome_arquivo FROM arquivos";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvArquivos.DataSource = dt;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                string caminho = dialogo.FileName;
                string nomeArquivo = Path.GetFileName(caminho);
                string tipoArquivo = Path.GetExtension(caminho);

                byte[] dadosArquivo = File.ReadAllBytes(caminho);

                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    string sql = "INSERT INTO arquivos (nome_arquivo, tipo_arquivo, dados_arquivo) VALUES (@nome, @tipo, @dados)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@nome", nomeArquivo);
                    cmd.Parameters.AddWithValue("@tipo", tipoArquivo);
                    cmd.Parameters.AddWithValue("@dados", dadosArquivo);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Arquivo enviado com sucesso!");
                }
            }
        }
        private void dgvArquivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BaixarArquivoPorId(Convert.ToInt32(dgvArquivos.Rows[e.RowIndex].Cells[0].Value), true);
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {

            if (dgvArquivos.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvArquivos.SelectedRows[0].Cells[0].Value);
                BaixarArquivoPorId(id, false);
            }
            else
            {
                MessageBox.Show("Selecione um arquivo na tabela.");
            }
        }

        // Correção importante para suportar arquivos grandes como PDF
        private void BaixarArquivoPorId(int id, bool salvarNoDesktop)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                string sql = "SELECT nome_arquivo, dados_arquivo FROM arquivos WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string nome = reader.GetString("nome_arquivo");
                        long tamanho = reader.GetBytes(1, 0, null, 0, 0);
                        byte[] dados = new byte[tamanho];
                        reader.GetBytes(1, 0, dados, 0, (int)tamanho);

                        string caminho;
                        if (salvarNoDesktop)
                        {
                            caminho = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nome);
                        }
                        else
                        {
                            using (SaveFileDialog salvar = new SaveFileDialog())
                            {
                                salvar.FileName = nome;
                                if (salvar.ShowDialog() != DialogResult.OK)
                                    return;

                                caminho = salvar.FileName;
                            }
                        }

                        File.WriteAllBytes(caminho, dados);
                        MessageBox.Show("Arquivo salvo com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Arquivo não encontrado.");
                    }
                }
            }
        }

       
    }
}

