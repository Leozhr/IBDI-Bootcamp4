using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IBDI_Bootcamp4.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        readonly SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ls_sql"].ConnectionString);

        // Função para carregar dados na tabela.
        void getTable()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                using (SqlCommand cmd = new SqlCommand("sp_load", connect))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        gvusers.DataSource = dataTable;
                        gvusers.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                // Lidar com exceções, por exemplo, registrar ou mostrar uma mensagem de erro.
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Chama a função para carregar a tabela quando a página é carregada.
            getTable();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            // Redireciona para a página de criação de produto.
            Response.Redirect("~/Pages/CRUD.aspx?op=Create");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtém o ID da linha selecionada para atualização.
                Button btnSelect = (Button)sender;
                GridViewRow selectedRow = (GridViewRow)btnSelect.NamingContainer;
                string id = selectedRow.Cells[1].Text;

                if (int.TryParse(id, out int parsedId))
                {
                    // Redireciona para a página de atualização com o ID correto.
                    Response.Redirect($"~/Pages/CRUD.aspx?id={parsedId}&op=Update");
                }
                else
                {
                    // Lidar com o caso em que a conversão de "id" falha.
                    // Pode ser útil exibir uma mensagem de erro ou fazer log.
                }
            }
            catch (Exception ex)
            {
                // Lidar com exceções aqui, por exemplo, registrar ou mostrar uma mensagem de erro.
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtém a linha selecionada para exclusão.
                Button btnDelete = (Button)sender;
                GridViewRow selectedRow = (GridViewRow)btnDelete.NamingContainer;

                if (selectedRow != null)
                {
                    // Obtém o ID da linha selecionada para exclusão.
                    string id = selectedRow.Cells[1].Text;

                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }

                    using (SqlCommand cmd = new SqlCommand("sp_delete", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                        cmd.ExecuteNonQuery();
                    }

                    // Redireciona de volta para a página principal após a exclusão.
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    // Lidar com a situação em que não é possível identificar a linha selecionada.
                    // Pode ser útil exibir uma mensagem de erro ou fazer log.
                }
            }
            catch (Exception ex)
            {
                // Lidar com exceções, por exemplo, registrar ou mostrar uma mensagem de erro.
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }
    }
}