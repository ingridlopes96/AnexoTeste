using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anexos
{
    class Conexao
    {
        private const string ConnStr = "server=localhost;port=3307;user=root;password=senacJBQ;database=anexos";
        public static MySqlConnection obterConexao()
        {
            var conexao = new MySqlConnection(ConnStr);
            conexao.Open();

            return conexao;
        }
    }
}
