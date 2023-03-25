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
    public class LessonRepository : IRepository<Lesson>
    {
        List<Lesson> LessonList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public LessonRepository()
        {
            LessonList = new List<Lesson>();
            Read();
        }
        public void Read()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [id],[title],[rowinserttime],[rowupdatetime] FROM [Lesson]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Lesson tmp = new Lesson();
                        tmp.Id = (int)reader["id"];
                        tmp.Title = (string)reader["title"];
                        tmp.RowInsertTime = (DateTime)reader["rowinserttime"];
                        tmp.RowUpdateTime = (DateTime)reader["rowupdatetime"];
                        LessonList.Add(tmp);
                    }
                }
            }

        }
        public void Create(Lesson tempObj)
        {
            LessonList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [Lesson]([title])" +
                    "VALUES(@title)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@title", tempObj.Title);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            LessonList.Clear();
            Read();
        }
        public void Refresh()
        {
            LessonList.Clear();
            Read();
        }

        public void Delete(int id)
        {
            for (int i = 0; i < LessonList.Count(); i++)
            {
                if (LessonList[i].Id == id)
                {
                    LessonList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM Lesson WHERE id=@id";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@id", id);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<Lesson> GetAll()
        {
            return LessonList;
        }

        public Lesson Get(int index)
        {
            return LessonList[index];
        }

        public void Update(Lesson obj)
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                var cmd = new SqlCommand("spUpdateLesson", connectionSql);
                cmd.CommandType = CommandType.StoredProcedure;
                connectionSql.Open();
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@Name", obj.Title);
                cmd.ExecuteNonQuery();
                connectionSql.Close();
            }

        }
    }
}
