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

                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow dataRow = dataTable.Rows[0];

                        string productName = dataRow["Produto"].ToString();
                        string rawValue = dataRow["Valor"].ToString();

                        string formattedValue = rawValue.Replace("R$", "").Replace(",00", "").Trim();

                        TableName.Text = productName;
                        TablePrice.Text = formattedValue;
                    }
                    else
                    {
                        String error = "viewToast('Ocorreu um erro, tente novamente mais tarde.');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "toast", error, true);
                    }
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
            if (!Page.IsPostBack)
            {
                InitializePageControls();
            }
        }

        private void InitializePageControls()
        {
            if (Request.QueryString["id"] != null)
            {
                checkID = Request.QueryString["id"].ToString();
                getData();
            }

            if (Request.QueryString["op"] != null)
            {
                Option = Request.QueryString["op"].ToString();

                switch (Option)
                {
                    case "Create":
                        SetPageTitleAndButton("Adicionar um Novo Produto", BtnCreate);
                        break;

                    case "Update":
                        SetPageTitleAndButton("Editar Produto", BtnUpdate);
                        break;
                }
            }
        }

        private void SetPageTitleAndButton(string titleText, Button button)
        {
            title.Text = titleText;
            button.Visible = true;
        }

        private bool ValidateProduct(string produto, string valor)
        {
            if (string.IsNullOrEmpty(produto))
            {
                String error = "viewToast('Nome do produto é obrigatório.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toast", error, true);
                return false;
            }
            else if (produto.Length > 15)
            {
                String error = "viewToast('O nome do produto não pode ter mais de 15 caracteres.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toast", error, true);
                return false;
            }
            else if (string.IsNullOrEmpty(valor))
            {
                String error = "viewToast('Valor do produto é inválido.');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toast", error, true);
                return false;
            }

            return true;
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            string productName = TableName.Text;
            string productValue = TablePrice.Text;

            if (!ValidateProduct(productName, productValue))
            {
                return;
            }

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            productName = textInfo.ToTitleCase(productName);

            ProductManager productManager = new ProductManager();
            productManager.CreateProduct(productName, productValue);

            Response.Redirect("Index.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string productName = TableName.Text;
            string productValue = TablePrice.Text;

            if (!ValidateProduct(productName, productValue))
            {
                return;
            }

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            productName = textInfo.ToTitleCase(productName);

            ProductManager productManager = new ProductManager();
            productManager.UpdateProduct(Convert.ToInt32(checkID), productName, productValue);

            Response.Redirect("Index.aspx");
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}