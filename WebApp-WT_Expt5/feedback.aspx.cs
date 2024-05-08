using System;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace WebApp_WT_Expt5
{
    public partial class feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadIssues();
            }
        }

        protected void btnAddIssue_Click(object sender, EventArgs e)
        {
            string issueName = txtIssueName.Text.Trim();
            if (!string.IsNullOrEmpty(issueName))
            {
                string connectionString = "Server=localhost;Port=3306;Database=expt5;Uid=root;Pwd=;";
                string query = "INSERT INTO Issues (Name, Status) VALUES (@Name, @Status)";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", issueName);
                    command.Parameters.AddWithValue("@Status", "Open");

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                LoadIssues();
                txtIssueName.Text = string.Empty;
            }
        }

        protected void btnMarkAsSolved_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int issueID = Convert.ToInt32(btn.CommandArgument);

            string connectionString = "Server=localhost;Port=3306;Database=expt5;Uid=root;Pwd=;";
            string query = "UPDATE Issues SET Status = 'Solved' WHERE ID = @ID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", issueID);

                connection.Open();
                command.ExecuteNonQuery();
            }

            LoadIssues();
        }

        private void LoadIssues()
        {
            string connectionString = "Server=localhost;Port=3306;Database=expt5;Uid=root;Pwd=;";
            string query = "SELECT * FROM Issues";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                rptIssues.DataSource = dataTable;
                rptIssues.DataBind();
            }
        }
    }
}
