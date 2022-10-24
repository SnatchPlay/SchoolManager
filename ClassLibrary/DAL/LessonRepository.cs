using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAL
{
    public class LessonRepository:IRepository<Lesson>
    {
        List<Lesson> LessonList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public LessonRepository()
        {
            LessonList = new List<Lesson>();
            ReadFromDB();
        }
        public void ReadFromDB()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [id],[title] FROM [Lessons]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Lesson tmp = new Lesson();
                        tmp.LessonId = (int)reader["id"];
                        tmp.LessonTitle = (string)reader["title"];
                        LessonList.Add(tmp);
                    }
                }
            }

        }
        public void AddObj(Lesson tempObj)
        {
            LessonList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [Lessons]([title])" +
                    "VALUES(@title)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@title", tempObj.LessonTitle);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            LessonList.Clear();
            ReadFromDB();
        }
        public void RefreshList()
        {
            LessonList.Clear();
            ReadFromDB();
        }

        public void DeleteObject(int id)
        {
            for (int i = 0; i < LessonList.Count(); i++)
            {
                if (i == id)
                {
                    LessonList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM Lessons WHERE id=@id";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@id", id);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<Lesson> GetEnteties()
        {
            return LessonList;
        }

        public Lesson GetObj(int index)
        {
            return LessonList[index];
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
