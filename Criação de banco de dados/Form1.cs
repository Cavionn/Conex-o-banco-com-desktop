using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace Criação_de_banco_de_dados
{
    public partial class Form1 : Form
    {
        private MySqlConnection Conexao;
        private string data_source = "datasource=localhost;username";
        public Form1()
        {
            InitializeComponent();

            
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                

                //-----------CRIAR CONEXAO MYSQL----------------

                Conexao = new MySqlConnection(data_source);

                //-----------EXECUTAR O COMANDO INSERT----------------

                string sql = "INSERT INTO contato (nome,email,telefone)" +
                "VALUES('" + txtNome.Text + "','" + txtEmail.Text + "','" + txtTelefone.Text + "')";

                MySqlCommand comando = new MySqlCommand(sql, Conexao);

                Conexao.Open();

                comando.ExecuteReader();

                MessageBox.Show("Deu certo !!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexao.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Tratamento de exeption
            try
            {
                string q = "'%" + txtBuscar.Text + "%'";

                MessageBox.Show(q);

                //-----------CRIAR CONEXAO MYSQL----------------

                Conexao = new MySqlConnection(data_source);

                string sql = "SELECT * " +
                                "FROM contato " +
                                "WHERE nome LIKE" + q + "OR email LIKE" + q;

                Conexao.Open();

                MessageBox.Show(sql);

                //-----------EXECUTAR O COMANDO INSERT----------------

                string sql = "INSERT INTO contato (nome,email,telefone)" +
                "VALUES('" + txtNome.Text + "','" + txtEmail.Text + "','" + txtTelefone.Text + "')";

                MySqlCommand comando = new MySqlCommand(sql, Conexao);

                Conexao.Open();

                comando.ExecuteReader();

                MessageBox.Show("Deu certo !!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexao.Close();
            }
        }
            //Mostrar Mensagem de erro
           
        }
    }

