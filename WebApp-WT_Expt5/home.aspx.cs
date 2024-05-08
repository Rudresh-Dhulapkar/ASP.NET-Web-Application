using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace WebApp_WT_Expt5
{
    public partial class home : System.Web.UI.Page
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
            string query = "SELECT * FROM News";

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

        protected void btnAddNews_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            DateTime publishDate;
            if (!DateTime.TryParse(txtPublishDate.Text.Trim(), out publishDate))
            {
                // Handle invalid date format
                return;
            }
            string source = txtSource.Text.Trim();

            string connectionString = "Server=localhost;Port=3306;Database=expt5;Uid=root;Pwd=;";
            string query = "INSERT INTO News (Title, Description, PublishDate, Source) VALUES (@Title, @Description, @PublishDate, @Source)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@PublishDate", publishDate);
                command.Parameters.AddWithValue("@Source", source);

                connection.Open();
                command.ExecuteNonQuery();
            }

            // Refresh GridView to display newly added data
            LoadNews();
        }
    }
}