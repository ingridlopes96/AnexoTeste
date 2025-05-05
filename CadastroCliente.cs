using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexos
{
    class CadastroCliente
    {
        public int Id_cliente { get; set; }
        public string Nome { get; set; }
        public int Sexo { get; set; }
        public string Profissao { get; set; }
        public DateTime DataNasc { get; set; }
        public string EstadoCivil { get; set; }
        public int Rg { get; set; }
        public int Cpf { get; set; }
        public string Endereco { get; set; }
        public int NumeroCasa { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public int Telefone { get; set; }
        public int Celular { get; set; }
        public string Email { get; set; }



    }
}
