using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IBDI_Bootcamp4.Pages
{
    public partial class CRUD : System.Web.UI.Page
    {
        readonly SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ls_sql"].ConnectionString);
        public static string checkID = "-1";
        public static string Option = "";

        // Função para carregar dados com base no 'id' fornecido na URL.
        void getData()
        {
            try
            {
                connect.Open();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter("sp_read", connect))
                {
                    dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@ID", checkID);

                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    DataTable dataTable = dataSet.Tables[0];

                    DataRow dataRow = dataTable.Rows[0];

                    // Preenche os campos da interface do usuário com os dados recuperados.
                    TableName.Text = dataRow["Produto"].ToString();
                    TablePrice.Text = dataRow["Valor"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            finally
            {
                connect.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica se a página está sendo carregada pela primeira vez (não é um postback).
            if (!Page.IsPostBack)
            {
                // Verifica se um parâmetro "id" foi passado na URL.
                if (Request.QueryString["id"] != null)
                {
                    checkID = Request.QueryString["id"].ToString();
                    getData();
                }

                // Verifica se um parâmetro "op" foi passado na URL.
                if (Request.QueryString["op"] != null)
                {
                    Option = Request.QueryString["op"].ToString();

                    // Configura a interface do usuário com base na operação ('Create', 'Update', 'Delete').
                    switch (Option)
                    {
                        case "Create":
                            this.title.Text = "Adicionar um Novo Produto";
                            this.BtnCreate.Visible = true;
                            break;

                        case "Update":
                            this.title.Text = "Editar Produto";
                            this.BtnUpdate.Visible = true;
                            break;

                        case "Delete":
                            this.title.Text = "Deletar Produto";
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtém o nome do produto e verifica se não está vazio.
                string produto = TableName.Text;
                if (string.IsNullOrEmpty(produto))
                {
                    lblerror.Text = "Nome do produto é obrigatório.";
                    lblerror.Visible = true;
                    return;
                }

                // Obtém o valor do produto e verifica se é um número válido.
                int valor;
                if (!int.TryParse(TablePrice.Text, out valor))
                {
                    lblerror.Text = "Valor do produto é obrigatório.";
                    lblerror.Visible = true;
                    return;
                }

                lblerror.Visible = false;

                // Insere os dados no banco de dados.
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ls_sql"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_create", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Produto", SqlDbType.VarChar).Value = produto;
                        cmd.Parameters.Add("@Valor", SqlDbType.VarChar).Value = "R$" + valor + ",00";

                        cmd.ExecuteNonQuery();
                    }
                }

                // Redireciona para a página "Index.aspx" após a criação bem-sucedida.
                Response.Redirect("Index.aspx");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                lblerror.Text = "Algo deu errado, tente novamente mais tarde.";
                lblerror.Visible = true;
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int checkID;
                // Verifica se o parâmetro "ID" na QueryString pode ser convertido em um número inteiro.
                if (!int.TryParse(Request.QueryString["ID"], out checkID))
                {
                    lblerror.Text = "ID do produto inválido.";
                    lblerror.Visible = true;
                    return;
                }

                // Obtém o nome do produto e verifica se não está vazio.
                string produto = TableName.Text.Trim();
                if (string.IsNullOrEmpty(produto))
                {
                    lblerror.Text = "Nome do produto é obrigatório.";
                    lblerror.Visible = true;
                    return;
                }

                int valor;
                // Verifica se o valor do produto pode ser convertido em um número inteiro.
                if (!int.TryParse(TablePrice.Text, out valor))
                {
                    lblerror.Text = "Valor do produto é obrigatório.";
                    lblerror.Visible = true;
                    return;
                }

                lblerror.Visible = false;

                using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ls_sql"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_update", connect))
                    {
                        connect.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = checkID;
                        cmd.Parameters.Add("@Produto", SqlDbType.VarChar).Value = produto;
                        cmd.Parameters.Add("@Valor", SqlDbType.VarChar).Value = "R$" + valor + ",00";

                        cmd.ExecuteNonQuery();
                    }
                }

                // Redireciona para a página "Index.aspx" após a atualização bem-sucedida.
                Response.Redirect("Index.aspx");
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro e registra a exceção no console.
                lblerror.Text = "Algo deu errado, tente novamente mais tarde.";
                lblerror.Visible = true;
                Console.WriteLine(ex);
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int checkID;
                // Verifica se o parâmetro "ID" na QueryString pode ser convertido em um número inteiro.
                if (!int.TryParse(Request.QueryString["ID"], out checkID))
                {
                    lblerror.Text = "ID do produto inválido.";
                    lblerror.Visible = true;
                    return;
                }

                using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ls_sql"].ConnectionString))
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_delete", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = checkID;
                        cmd.ExecuteNonQuery();
                    }
                }

                // Redireciona para a página "Index.aspx" após a exclusão bem-sucedida.
                Response.Redirect("Index.aspx");
            }
            catch (Exception ex)
            {
                // Registra a exceção no console.
                Console.WriteLine(ex);
            }
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            // Oculta a mensagem de erro e redireciona para a página "Index.aspx".
            lblerror.Visible = false;
            Response.Redirect("Index.aspx");
        }
    }
}