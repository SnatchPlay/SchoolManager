using ClassLibrary.Models;
using System.Data.SqlClient;

namespace ClassLibrary.DAL
{
    public class JournalRepository : IRepository<Journal>
    {
        List<Journal> JournalList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public JournalRepository()
        {
            JournalList = new List<Journal>();
            ReadFromDB();
        }
        public void ReadFromDB()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [student_id],[day_num],[lesson_id] FROM [Journal]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Journal tmp = new Journal();
                        tmp.StudentId = (int)reader["student_id"];
                        tmp.DayNum = (int)reader["day_num"];
                        tmp.LessonId = (int)reader["lesson_id"];
                        JournalList.Add(tmp);
                    }
                }
            }

        }
        public void AddObj(Journal tempObj)
        {
            JournalList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [Journal]([student_id],[day_num],[lesson_id])" +
                    "VALUES(@studentid,@daynum,@lessonid)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@studentid", tempObj.StudentId);
                comm.Parameters.AddWithValue("@daynum", tempObj.DayNum);
                comm.Parameters.AddWithValue("@lessonid", tempObj.LessonId);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            JournalList.Clear();
            ReadFromDB();
        }
        public void RefreshList()
        {
            JournalList.Clear();
            ReadFromDB();
        }

        public void DeleteObject(int id)
        {
            int daynum=0, studentid=0, lessonid=0;
            for (int i = 0; i < JournalList.Count(); i++)
            {
                if (i == id)
                {
                    daynum = JournalList[i].DayNum;
                    studentid = JournalList[i].StudentId;
                    lessonid = JournalList[i].LessonId;
                    JournalList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM Journal WHERE [student_id]=@stid and [day_num]=@daynum and [lesson_id]=@lnum";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@stid", studentid);
                comm.Parameters.AddWithValue("@daynum", daynum);
                comm.Parameters.AddWithValue("@lnum", lessonid);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<Journal> GetEnteties()
        {
            return JournalList;
        }

        public Journal GetObj(int index)
        {
            return JournalList[index];
        }

        public void UpdateField(string Table, string Field, string NewValue, int id)
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "UPDATE @Table SET @Field =@NewValue WHERE id=@ID";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@Table", Table);
                comm.Parameters.AddWithValue("@Field", Field);
                comm.Parameters.AddWithValue("@NewValue", NewValue);
                comm.Parameters.AddWithValue("@ID", id);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }

        }
    }
}
