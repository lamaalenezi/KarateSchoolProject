using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace KarateSchoolProject
{
    public class DbManager
    {
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

       
        public NetUser getUser(string username)
        {
            using (var _db = new KarateSchoolDBDataContext(connectionString))
            {
                var user = _db.NetUsers.FirstOrDefault(u => u.UserName == username);
                return user;
            }
        }

        public Member getUserMember(string username)
        {
            using (var _db = new KarateSchoolDBDataContext(connectionString))
            {
                var user = getUser(username);
                var member = _db.Members.FirstOrDefault(m => m.Member_UserID == user.UserID);
                return member;
            }
        }


        public Instructor getUserInstroctor(string username)
        {
            using (var _db = new KarateSchoolDBDataContext(connectionString))
            {
                var user = getUser(username);
                var member = _db.Instructors.FirstOrDefault(m => m.InstructorID == user.UserID);
                return member;
            }


        }
        public DataTable GetSectionData(string username, bool isMember)
        {
            DataTable dataTable = new DataTable();

            using (var _db = new KarateSchoolDBDataContext(connectionString))
            {
                List<SectionModelMember> sections;
                var user = getUser(username);
                sections = _db.Sections
                    .Where(s => s.Member_ID == user.UserID)
                    .Join(
                        _db.Instructors,
                        section => section.Instructor_ID,
                        instructor => instructor.InstructorID,
                        (section, instructor) => new SectionModelMember
                        {
                            InstructorName = $"{instructor.InstructorFirstName} {instructor.InstructorLastName}",
                            SectionFee = section.SectionFee,
                            SectionStartDate = section.SectionStartDate,
                            SectionName = section.SectionName,
                        }
                        )
                    .ToList();
                // else sections =_db.Sections.Where(s => s.Instructor_ID==user.UserID).ToList();

                // Convert the LINQ result to a DataTable.
                dataTable.Columns.Add("SectionName");
                dataTable.Columns.Add("SectionStartDate");
                dataTable.Columns.Add("InstructorName");
                dataTable.Columns.Add("SectionFee");

                foreach (var section in sections)
                {
                    DataRow row = dataTable.NewRow();
                    row["SectionName"] = section.SectionName;
                    row["SectionStartDate"] = section.SectionStartDate;
                    row["InstructorName"] = section.InstructorName;
                    row["SectionFee"] = section.SectionFee;
                    dataTable.Rows.Add(row);
                }

                
            }

            return dataTable;
        }


        public DataTable GetSectionDataForInstructor(string username)
        {
            DataTable dataTable = new DataTable();

            using (var _db = new KarateSchoolDBDataContext(connectionString))
            {
                List<SectionModelInstructor> sections;
                var user = getUser(username);
                sections = _db.Sections
                    .Where(s => s.Instructor_ID == user.UserID)
                    .Join(
                        _db.Members,
                        section => section.Member_ID,
                        member => member.Member_UserID,
                        (section, member) => new SectionModelInstructor
                        {
                            MemberName = $"{member.MemberFirstName} {member.MemberLastName}",
                            SectionName = section.SectionName
                        }
                        )
                    .ToList();
                // else sections =_db.Sections.Where(s => s.Instructor_ID==user.UserID).ToList();

                // Convert the LINQ result to a DataTable.
                dataTable.Columns.Add("SectionName");
                dataTable.Columns.Add("MemberName");

                foreach (var section in sections)
                {
                    DataRow row = dataTable.NewRow();
                    row["SectionName"] = section.SectionName;
                    row["MemberName"] = section.MemberName;
                    dataTable.Rows.Add(row);
                }


            }

            return dataTable;
        }

    }

    public partial class SectionModelInstructor
    {
        public string SectionName { get;set; }
        public string MemberName { get;set;
        }
    }

    public partial class SectionModelMember
    {
        public string SectionName { get; set; }
        public decimal SectionFee { get; set; }
        public DateTime SectionStartDate { get; set; }
        public string InstructorName
        {
            get; set;
        }
    }

}