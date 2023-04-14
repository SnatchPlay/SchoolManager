using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAL.ADO
{
    public class SheduleRepository : IRepository<Shedule>
    {
        List<Shedule> SheduleList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public SheduleRepository()
        {
            SheduleList = new List<Shedule>();
            Read();
        }
        public void Read()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [day_num],[lesson_num],[class_id],[teacher_id],[lesson_id],[rowinserttime],[rowupdatetime] FROM [Shedule]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Shedule tmp = new Shedule();
                        tmp.DayNum = (int)reader["day_num"];
                        tmp.LessonNum = (int)reader["lesson_num"];
                        tmp.ClassId = (int)reader["class_id"];
                        tmp.TeacherId = (int)reader["teacher_id"];
                        tmp.LessonId = (int)reader["lesson_id"];
                        tmp.RowInsertTime = (DateTime)reader["rowinserttime"];
                        tmp.RowUpdateTime = (DateTime)reader["rowupdatetime"];
                        SheduleList.Add(tmp);
                    }
                }
            }

        }
        public void Create(Shedule tempObj)
        {
            SheduleList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [Shedule]([day_num],[lesson_num],[class_id],[teacher_id],[lesson_id])" +
                    "VALUES(@daynum,@lessonnum,@classid,@teacherid,@lessonid)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@daynum", tempObj.DayNum);
                comm.Parameters.AddWithValue("@lessonnum", tempObj.LessonNum);
                comm.Parameters.AddWithValue("@classid", tempObj.ClassId);
                comm.Parameters.AddWithValue("@teacherid", tempObj.TeacherId);
                comm.Parameters.AddWithValue("@lessonid", tempObj.LessonId);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            SheduleList.Clear();
            Read();
        }
        public void Refresh()
        {
            SheduleList.Clear();
            Read();
        }

        public void Delete(Func<Shedule, bool> filter)
        {
            Shedule ps = SheduleList.First(filter);
            SheduleList.Remove(ps);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM Shedule WHERE [day_num]=@daynum" +
                    " and [lesson_num]=@lnum and [class_id]=@classid and [teacher_id]=@teacherid and [lesson_id]=@lid";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@daynum", ps.DayNum);
                comm.Parameters.AddWithValue("@classid", ps.ClassId);
                comm.Parameters.AddWithValue("@teacherid", ps.TeacherId);
                comm.Parameters.AddWithValue("@lid", ps.LessonId);
                comm.Parameters.AddWithValue("@lnum", ps.LessonNum);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<Shedule> GetAll()
        {
            return SheduleList;
        }

        public Shedule Get(Func<Shedule, bool> filter)
        {
            return SheduleList.First(filter);
        }

        public void Update(Shedule obj)
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                var cmd = new SqlCommand("spUpdateShedule", connectionSql);
                cmd.CommandType = CommandType.StoredProcedure;
                connectionSql.Open();
                cmd.Parameters.AddWithValue("@Day_Num", obj.DayNum);
                cmd.Parameters.AddWithValue("@Lesson_Num", obj.LessonNum);
                cmd.Parameters.AddWithValue("@Class_Id", obj.ClassId);
                cmd.Parameters.AddWithValue("@Teacher_Id", obj.TeacherId);
                cmd.Parameters.AddWithValue("@Lesson_Id", obj.LessonId);
                cmd.ExecuteNonQuery();
                connectionSql.Close();
            }

        }
    }
}
