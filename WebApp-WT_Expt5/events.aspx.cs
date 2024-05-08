using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebApp_WT_Expt5
{
    public partial class Events : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNews(); // Call method to load news data
            }
        }

        private void LoadNews()
        {
            string connectionString = "Server=localhost;Port=3306;Database=expt5;Uid=root;Pwd=;";
            string query = "SELECT * FROM events";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                GridView1.DataSource = dataTable; // Assuming you have a GridView control named GridView1
                GridView1.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                string connectionString = "Server=localhost;Port=3306;Database=expt5;Uid=root;Pwd=;";
                string query = "SELECT * FROM News WHERE Title LIKE @SearchKeyword OR Description LIKE @SearchKeyword";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }
            }
        }
    }
}
