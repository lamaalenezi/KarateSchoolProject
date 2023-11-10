using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateSchoolProject
{
    public partial class Instructor1 : System.Web.UI.Page
    {
        private DbManager _dbManager = new DbManager();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }

            // Get the logged-in member's username.
            string username = (string)Session["username"];// User.Identity.Name;

            if(String.IsNullOrEmpty(username))
            {
                Response.Redirect("Login.aspx");
            }


            if (!IsPostBack)
            {

                

                Master.loggedUser = username;

                var member = _dbManager.getUserInstroctor(username);
                var instructor_name =  member.InstructorFirstName + " " + member.InstructorLastName;
                lblInstructorName.Text = instructor_name;

                // Load data into the GridView.
                BindData(username);
            }



        }

      

        private void BindData(string username)
        {
            DataTable data = _dbManager.GetSectionDataForInstructor(username);

            if (data.Rows.Count > 0)
            {
                gvSection.DataSource = data;
                gvSection.DataBind();

            }

        }


     
    }
}