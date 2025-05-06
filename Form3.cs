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


            string Nomecompleto = textBox1.Text;
            string profissao = textBox2.Text;
            //string rg = textBox3.Text;
            string cpf = textBox4.Text;
            string endereco = textBox5.Text;
            string numero = textBox6.Text;
            string complemento = textBox7.Text;
            string bairro = textBox8.Text;
            string cidade = textBox9.Text;
            string cep = textBox10.Text;
            string telefone = textBox11.Text;
            string estado = comboBox2.Text;
            string celular = textBox12.Text;
            string email = textBox13.Text;



            using (var conexao = Conexao.obterConexao())
            {
                string query = "INSERT INTO cadastro_cliente (nome,  profissao, data_nasc, estado_civil,  endereco, numero_casa, complemento, bairro, cidade, estado, cep, telefone, celular, email) " +
        "VALUES (@nome,  @profissao, @dataNascimento, @estadoCivil,   @endereco, @numero, @complemento, @bairro, @cidade, @estado, @cep, @telefone, @celular, @email)";

                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@nome", textBox1);
                cmd.Parameters.AddWithValue("@profissao", textBox2);
                cmd.Parameters.AddWithValue("@dataNascimento", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@estadoCivil", comboBox1.Text);
                //cmd.Parameters.AddWithValue("@rg",textBox3);
                //cmd.Parameters.AddWithValue("@cpf", textBox4);
                cmd.Parameters.AddWithValue("@endereco", textBox5);
                cmd.Parameters.AddWithValue("@numero", Convert.ToInt32(textBox6.Text));
                cmd.Parameters.AddWithValue("@complemento", textBox7);
                cmd.Parameters.AddWithValue("@bairro", textBox8);
                cmd.Parameters.AddWithValue("@cidade", textBox9);
                cmd.Parameters.AddWithValue("@estado", comboBox2);
                cmd.Parameters.AddWithValue("@cep", Convert.ToInt32(textBox10.Text));
                cmd.Parameters.AddWithValue("@telefone", Convert.ToInt32(textBox11.Text));
                cmd.Parameters.AddWithValue("@celular", Convert.ToInt32(textBox12.Text));
                cmd.Parameters.AddWithValue("@email", textBox13);



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
    }
}



