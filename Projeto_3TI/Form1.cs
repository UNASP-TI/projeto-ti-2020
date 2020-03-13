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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"server=localhost;userid=root;password=;database=projeto_3ti";

            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO produto(Nome, preco_custo, preco_venda) VALUES(@Name,@preco_custo,@preco_venda)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Name", txtNome.Text);
                cmd.Parameters.AddWithValue("@preco_custo", txtPrecoCusto.Text);
                cmd.Parameters.AddWithValue("@preco_venda", txtPrecoVenda.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Produto cadastrado!");

                txtNome.Text = "";
                txtNome.Focus();

            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
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
                string stm = "SELECT * FROM produto";
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var _grid = dataGridView1.CurrentRow;

           txtId.Text = _grid.Cells["id"].Value.ToString();
           txtNome.Text = _grid.Cells["nome"].Value.ToString();
           txtPrecoCusto.Text = _grid.Cells["preco_custo"].Value.ToString();
           txtPrecoVenda.Text = _grid.Cells["preco_venda"].Value.ToString();


            //preco_custo , preco_venda
            //txtIdade.Text = _grid.Cells["Idade"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"server=localhost;userid=root;password=;database=projeto_3ti";

            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE produto SET nome=@Name, preco_custo=@preco_custo, preco_venda=@preco_venda WHERE id=@id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", txtId.Text);
                cmd.Parameters.AddWithValue("@Name", txtNome.Text);
                cmd.Parameters.AddWithValue("@preco_custo", txtPrecoCusto.Text);
                cmd.Parameters.AddWithValue("@preco_venda", txtPrecoVenda.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Produto atualizado!");

                txtNome.Text = "";
                txtNome.Focus();

            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }

        private void bt_deletar_Click(object sender, EventArgs e)
        {
            string connectionString = @"server=localhost;userid=root;password=;database=projeto_3ti";

            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "DELETE produto WHERE id=@id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", txtId.Text);
             

                cmd.ExecuteNonQuery();
                MessageBox.Show("Produto Deletado!");

                txtNome.Text = "";
                txtNome.Focus();

            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }

        private void produtohasfornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
           new Produto_has_fornecedor().Show();
        }
    }
}
