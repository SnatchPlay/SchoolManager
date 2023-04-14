using ClassLibrary.Models;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace ClassLibrary.DAL.ADO
{
    public class JournalRepository : IRepository<Journal>
    {
        List<Journal> JournalList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public JournalRepository()
        {
            JournalList = new List<Journal>();
            Read();
        }
        public void Read()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [id],[student_id],[day_num],[lesson_id],[mark],[rowinserttime],[rowupdatetime] FROM [Journal]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Journal tmp = new Journal();
                        tmp.Id = (int)reader["id"];
                        tmp.StudentId = (int)reader["student_id"];
                        tmp.DayNum = (int)reader["day_num"];
                        tmp.LessonId = (int)reader["lesson_id"];
                        tmp.Mark = (int)reader["mark"];
                        tmp.RowInsertTime = (DateTime)reader["rowinserttime"];
                        tmp.RowUpdateTime = (DateTime)reader["rowupdatetime"];
                        JournalList.Add(tmp);
                    }
                }
            }

        }
        public void Create(Journal tempObj)
        {
            JournalList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [Journal]([student_id],[day_num],[lesson_id],[mark])" +
                    "VALUES(@studentid,@daynum,@lessonid,@mark)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@studentid", tempObj.StudentId);
                comm.Parameters.AddWithValue("@daynum", tempObj.DayNum);
                comm.Parameters.AddWithValue("@lessonid", tempObj.LessonId);
                comm.Parameters.AddWithValue("@mark", tempObj.Mark);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            JournalList.Clear();
            Read();
        }
        public void Refresh()
        {
            JournalList.Clear();
            Read();
        }

        public void Delete(Func<Journal, bool> filter)
        {
            Journal ps = JournalList.First(filter);
            JournalList.Remove(ps);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM Journal WHERE id=@Id";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@Id", ps.Id);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<Journal> GetAll()
        {
            return JournalList;
        }

        public Journal Get(Func<Journal, bool> filter)
        {
            return JournalList.First(filter);
        }

        public void Update(Journal obj)
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                var cmd = new SqlCommand("spUpdateJournal", connectionSql);
                cmd.CommandType = CommandType.StoredProcedure;
                connectionSql.Open();
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@Day_Num", obj.DayNum);
                cmd.Parameters.AddWithValue("@Student_Id", obj.StudentId);
                cmd.Parameters.AddWithValue("@Lesson_Id", obj.LessonId);
                cmd.Parameters.AddWithValue("@Mark", obj.Mark);
                cmd.ExecuteNonQuery();
                connectionSql.Close();
            }

        }
    }
}
