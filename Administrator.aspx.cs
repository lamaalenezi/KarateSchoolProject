using Microsoft.Ajax.Utilities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Web.UI.WebControls;
namespace KarateSchoolProject
{
    public partial class Administrator : System.Web.UI.Page
    {
        //sydney's connection string
        private static string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\sdeat\\OneDrive\\Desktop\\skool\\2023-2024\\213\\as5\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection conn = new SqlConnection(connString);
        private KarateSchoolDBDataContext dbcon = new KarateSchoolDBDataContext(connString);


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }

            string username = (string)Session["username"];// User.Identity.Name;

            if (String.IsNullOrEmpty(username))
            {
                Response.Redirect("Login.aspx");
            }

            
        }


        protected void AssignMemberBtn_Click(object sender, EventArgs e)
        {
            

                using (conn)
                {
                    string memID = MemberGridView.SelectedValue.ToString();
                    conn.Open();

                    // Check if MemberID is used in the sections table
                    string checkQuery = "SELECT COUNT(*) FROM Sections WHERE Member_UserID = @Member_UserID";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, conn))
                {
                    checkCommand.Parameters.AddWithValue("@Member_UserID", memID);

                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count > 0)
                    {
                        if (SectionDropDownList.ToString() == "Karate Age-Uke")
                        {
                            string deleteQuery = "DELETE FROM YourTableName WHERE MemberID = @MemberID";
                            using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, conn))
                            {
                                deleteCommand.Parameters.AddWithValue("@MemberID", memID);

                                deleteCommand.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {

                    }


                }
                }
        }

        protected void MemberGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        protected void AddInstructorBtn_Click1(object sender, EventArgs e)
        {
            conn.Open();

            using (conn)
            {
                Random rand = new Random();

                    string query = "INSERT INTO Instructor ([InstructorID], [InstructorFirstName], [InstructorLastName], [InstructorPhoneNumber]) " +
                                    "VALUES (" + rand.Next(0, 99).ToString("D2") + ", '" + TxtInstrFirstName.Text + "', '"
                                    + TxtInstrLastName.Text + "', '" + TxtInstrPhoneNum.Text + "');";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
            }
        }

        protected void AddMemberBtn_Click1(object sender, EventArgs e)
        {
            conn.Open();

            using (conn)
            {
                Random rand = new Random();

                string query = "INSERT INTO Member (Member_ID, MemberFirstName, MemberLastName, MemberDateJoined, MemberPhoneNumber, MemberEmail) " +
                                "VALUES (" + rand.Next(0, 99).ToString("D2") + ", '" + TxtMemberFirstName.Text + "', '"
                                + TxtMemberLastName.Text + "', '" + CalMemberDateJoined.SelectedDate.ToString() + "', " 
                                + TxtMemberPhoneNum.Text + ", '" + TxtMemberEmail.Text + "');";

                SqlCommand cmd = new SqlCommand (query, conn);
                cmd.ExecuteNonQuery();
                conn.Close ();
            }
        }

        protected void SectionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void MemberGridView_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void MemberGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MemberGridView.Rows[e.RowIndex];
            int memberID = Convert.ToInt32(MemberGridView.DataKeys[e.RowIndex].Value); 

           
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                
                string query = "DELETE FROM Member WHERE Member_UserID = @Member_UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Member_UserID", memberID);

                    
                    command.ExecuteNonQuery();
                }
            }
            KarateSchool.DataBind();
        }

        protected void InstructorGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MemberGridView.Rows[e.RowIndex];
            int instrID = Convert.ToInt32(MemberGridView.DataKeys[e.RowIndex].Value);

            
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                
                string query = "DELETE FROM Instructor WHERE InstructorID = @InstructorID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InstructorID", instrID); 
                    command.ExecuteNonQuery();
                }
            }
            KarateSchool.DataBind();
        }
    }
}