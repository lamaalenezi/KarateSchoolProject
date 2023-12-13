using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateSchoolProject
{
    public partial class Login : System.Web.UI.Page
    {
        private DbManager dbManager = new DbManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var user = dbManager.getUser(username);
            if (user != null && user.UserPassword == password)
            {
                // Successful login: Redirect to a page.
                FormsAuthentication.SetAuthCookie(user.UserName, true);
                Session["username"] = username;
                
                if (user.UserType == UserType.Member)
                {

                    Response.Redirect("Member.aspx");
                }

                else if (user.UserType == UserType.Instructor)
                {

                    Response.Redirect("Instructor.aspx");
                }
                else if (user.UserType == UserType.Administrator)
                {
                    Response.Redirect("Administrator.aspx");
                }
                

            }
            else
            {
                // Failed login: Display an error message or handle it accordingly.
                lblErrorMessage.Text = "Invalid username or password.";
            }


        }
    }
}