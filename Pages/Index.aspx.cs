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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
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
                HandleException(ex);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        private void HandleException(Exception ex)
        {
            Console.WriteLine("Ocorreu um erro: " + ex.Message);
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/CRUD.aspx?op=Create");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnSelect = (Button)sender;
                GridViewRow selectedRow = (GridViewRow)btnSelect.NamingContainer;
                string id = selectedRow.Cells[1].Text;

                if (int.TryParse(id, out int parsedId))
                {
                    Response.Redirect($"~/Pages/CRUD.aspx?id={parsedId}&op=Update");
                }
                else
                {
                    String error = "viewToast('Este produto está atualmente indisponível.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "toast", error, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnDelete = (Button)sender;
                GridViewRow selectedRow = (GridViewRow)btnDelete.NamingContainer;

                if (selectedRow != null)
                {
                    string id = selectedRow.Cells[1].Text;

                    int productId = int.Parse(id);
                    ProductManager productManager = new ProductManager();
                    productManager.DeleteProduct(productId);

                    Response.Redirect("Index.aspx");
                }
                else
                {
                    String error = "viewToast('Ocorreu um erro, tente novamente mais tarde.');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "toast", error, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }
    }
}