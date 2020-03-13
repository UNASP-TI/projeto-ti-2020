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

namespace Projeto_3TI
{
    public partial class Produto_has_fornecedor : Form
    {
        public Produto_has_fornecedor()
        {
            InitializeComponent();
        }

        private void btn_carregarDados_Click(object sender, EventArgs e)
        {
            string connectionString = @"server=localhost;userid=root;password=;database=projeto_3ti";
            MySqlConnection connection = null;
            MySqlDataReader reader = null;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                string stm = "select p.nome, p.preco_custo, p.preco_venda ,f.NomeFornecedor,f.ContatoFornecedor from produto_has_fornecedor as pf " +
                "inner join produto as p on p.id = pf.IdProduto "+
                "inner join fornecedor as f on f.IdFornecedor = pf.IdFornecedor";


                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = new MySqlCommand(stm, connection);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (connection != null)
                    connection.Close();
            }
        }
    }
}
