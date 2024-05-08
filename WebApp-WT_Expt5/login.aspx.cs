using MySql.Data.MySqlClient;
using System;
using System.Web.UI;

namespace WebApp_WT_Expt5
{
    public partial class login : Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=expt5;";
                string query = "SELECT name FROM users WHERE email = @Email AND pass = @Password";

                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        command.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            string name = result.ToString();
                            // Store the name in a session variable
                            Session["UserName"] = name;
                            // Redirect to html_assignments.aspx
                            Response.Redirect("home.aspx");
                        }
                        else
                        {
                            Response.Write("Invalid email or password.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}
