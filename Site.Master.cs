using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateSchoolProject
{
    public partial class SiteMaster : MasterPage
    {
     
        public string loggedUser
        {
            set
            {
                lblUsername.Text = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void btnSignout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session["username"] = null;

            // Redirect to the login page
            Response.Redirect("Login.aspx");
        }

      
    }
}