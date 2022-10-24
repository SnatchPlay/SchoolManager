using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAL
{
    public class TaskClassRepository:IRepository<TaskClass>
    {
        List<TaskClass> TaskClassList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public TaskClassRepository()
        {
            TaskClassList = new List<TaskClass>();
            ReadFromDB();
        }
        public void ReadFromDB()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [student_id],[lesson_id],[description],[deadline],[closedtime],[status] FROM [Tasks]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        TaskClass tmp = new TaskClass();
                        tmp.StudentId= (int)reader["student_id"];
                        tmp.LessonId = (int)reader["lesson_id"];
                        tmp.Description = (string)reader["description"];
                        tmp.DeadLine = (DateTime)reader["deadline"];
                        tmp.CloseTime = (DateTime)reader["closedtime"];
                        tmp.Status=(bool)reader["status"];
                        
                        TaskClassList.Add(tmp);
                    }
                }
            }

        }
        public void AddObj(TaskClass tempObj)
        {
            TaskClassList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [Tasks]([student_id],[lesson_id],[description],[deadline],[closedtime],[status])" +
                    "VALUES(@sid,@lid,@desc,@deadline,@closedtime,@status)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@sid", tempObj.StudentId);
                comm.Parameters.AddWithValue("@lid", tempObj.LessonId);
                comm.Parameters.AddWithValue("@desc", tempObj.Description);
                comm.Parameters.AddWithValue("@deadline", tempObj.DeadLine.ToString("yyyy-MM-dd"));
                comm.Parameters.AddWithValue("@closedtime", tempObj.CloseTime.ToString("yyyy-MM-dd"));
                comm.Parameters.AddWithValue("@status", tempObj.Status);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            TaskClassList.Clear();
            ReadFromDB();
        }
        public void RefreshList()
        {
            TaskClassList.Clear();
            ReadFromDB();
        }

        public void DeleteObject(int id)
        {
            int student_id = 0,  lessonid = 0;
            string deadline = DateTime.Today.ToString("yyyy - MM - dd");
            for (int i = 0; i < TaskClassList.Count(); i++)
            {
                if (i == id)
                {
                    student_id = TaskClassList[i].StudentId;
                    deadline = TaskClassList[i].DeadLine.ToString("yyyy-MM-dd");
                    lessonid = TaskClassList[i].LessonId;
                    TaskClassList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM Tasks WHERE [student_id]=@sid" +
                    " and [lesson_id]=@lid and [deadline]=@deadline ";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@sid", student_id);
                comm.Parameters.AddWithValue("@deadline", deadline);
                comm.Parameters.AddWithValue("@lid", lessonid);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<TaskClass> GetEnteties()
        {
            return TaskClassList;
        }

        public TaskClass GetObj(int index)
        {
            return TaskClassList[index];
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
