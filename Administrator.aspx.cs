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
            using (conn) { 
            Member memberSelect = InstructorGridView.SelectedValue as Member;
            string memID = memberSelect.Member_UserID.ToString();

                
            //if already assigned a section
            string query = "SELECT [Member_ID] FROM Section WHERE [Member_ID]=" + memID;

            //if assigning new
            string query2 = "INSERT INTO Section (SectionName, SectionStartDate, Member_ID, Instructor_ID, SectionFee)" +
                             "VALUES ('Karate Age-Uke', '11/12/2023 12:00:00 AM', " + memID + ", 2, 500.0000);";
            SqlCommand cmd = new SqlCommand(query2, conn);

                conn.Close();
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
            MemberGridView.DeleteRow(e.RowIndex);
            
        }
    }
}