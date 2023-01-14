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
    public class TaskClassRepository : IRepository<TaskClass>
    {
        List<TaskClass> TaskClassList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public TaskClassRepository()
        {
            TaskClassList = new List<TaskClass>();
            Read();
        }
        public void Read()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [id],[student_id],[lesson_id],[description],[deadline],[closedtime],[status] FROM [Task]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        TaskClass tmp = new TaskClass();
                        tmp.Id = (int)reader["id"];
                        tmp.StudentId = (int)reader["student_id"];
                        tmp.LessonId = (int)reader["lesson_id"];
                        tmp.Description = (string)reader["description"];
                        tmp.DeadLine = (DateTime)reader["deadline"];
                        tmp.ClosedTime = (DateTime)reader["closedtime"];
                        tmp.Status = (bool)reader["status"];

                        TaskClassList.Add(tmp);
                    }
                }
            }

        }
        public void Create(TaskClass tempObj)
        {
            TaskClassList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [Task]([student_id],[lesson_id],[description],[deadline],[closedtime],[status])" +
                    "VALUES(@sid,@lid,@desc,@deadline,@closedtime,@status)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@sid", tempObj.StudentId);
                comm.Parameters.AddWithValue("@lid", tempObj.LessonId);
                comm.Parameters.AddWithValue("@desc", tempObj.Description);
                comm.Parameters.AddWithValue("@deadline", tempObj.DeadLine.ToString("yyyy-MM-dd"));
                comm.Parameters.AddWithValue("@closedtime", tempObj.ClosedTime.ToString("yyyy-MM-dd"));
                comm.Parameters.AddWithValue("@status", tempObj.Status);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            TaskClassList.Clear();
            Read();
        }
        public void Refresh()
        {
            TaskClassList.Clear();
            Read();
        }

        public void Delete(int id)
        {
            for (int i = 0; i < TaskClassList.Count(); i++)
            {
                if (TaskClassList[i].Id == id)
                {
 
                    TaskClassList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM Task WHERE [id]=@Id";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@Id", id);

                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<TaskClass> GetAll()
        {
            return TaskClassList;
        }

        public TaskClass Get(int index)
        {
            return TaskClassList[index];
        }

        public void Update(TaskClass obj)
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                var cmd = new SqlCommand("spUpdateTask", connectionSql);
                cmd.CommandType = CommandType.StoredProcedure;
                connectionSql.Open();
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@Student_Id", obj.StudentId);
                cmd.Parameters.AddWithValue("@Lesson_Id", obj.LessonId);
                cmd.Parameters.AddWithValue("@Description", obj.Description);
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@Deadline", obj.DeadLine.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Closedtime", obj.ClosedTime.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Status", obj.Status);
                cmd.ExecuteNonQuery();
                connectionSql.Close();
            }

        }
    }
}
