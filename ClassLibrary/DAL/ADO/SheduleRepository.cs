using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
                    comm.CommandText = "SELECT [day_num],[lesson_num],[class_id],[teacher_id],[lesson_id] FROM [Shedule]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Shedule tmp = new Shedule();
                        tmp.DayNum = (int)reader["day_num"];
                        tmp.LessonNum = (int)reader["lesson_num"];
                        tmp.ClassId = (int)reader["class_id"];
                        tmp.TeacherId = (int)reader["teacher_id"];
                        tmp.LessonId = (int)reader["lesson_id"];
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

        public void Delete(int id)
        {
            int daynum = 0, lessonum = 0, classid = 0, teacherid = 0, lessonid = 0;
            for (int i = 0; i < SheduleList.Count(); i++)
            {
                if (i == id)
                {
                    daynum = SheduleList[i].DayNum;
                    lessonum = SheduleList[i].LessonNum;
                    classid = SheduleList[i].ClassId;
                    teacherid = SheduleList[i].TeacherId;
                    lessonid = SheduleList[i].LessonId;
                    SheduleList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM Shedule WHERE [day_num]=@daynum" +
                    " and [lesson_num]=@lnum and [class_id]=@classid and [teacher_id]=@teacherid and [lesson_id]=@lid";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@daynum", daynum);
                comm.Parameters.AddWithValue("@classid", classid);
                comm.Parameters.AddWithValue("@teacherid", teacherid);
                comm.Parameters.AddWithValue("@lid", lessonid);
                comm.Parameters.AddWithValue("@lnum", lessonum);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<Shedule> GetAll()
        {
            return SheduleList;
        }

        public Shedule Get(int index)
        {
            return SheduleList[index];
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
