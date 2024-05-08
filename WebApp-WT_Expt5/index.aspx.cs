using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Web.UI;

namespace WebApp_WT_Expt5
{
    public partial class signup : Page
    {
        protected void btnSignup_Click(object sender, EventArgs e)
        {
            try
            {
                string conn = "datasource=127.0.0.1;port=3306;username=root;password=;database=expt5;";
                string query = "INSERT INTO users (name, email, pass) VALUES (@Name, @Email, @Pass)";

                MySqlConnection db = new MySqlConnection(conn);
                MySqlCommand cmd = new MySqlCommand(query, db);

               
                string name = txtUsername.Text.Trim();
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text.Trim();

                
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Pass", password);

                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();

                Response.Redirect("home.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}
