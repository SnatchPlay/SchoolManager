using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAL
{
    public class TeacherRepository:IRepository<Teacher>
    {
        List<Teacher> TeacherList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public TeacherRepository()
        {
            TeacherList = new List<Teacher>();
            ReadFromDB();
        }
        public void ReadFromDB()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [id],[person_id],[class_id],[specialization_id] FROM [Teachers]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Teacher tmp = new Teacher();
                        tmp.Id = (int)reader["id"];
                        tmp.PersonId = (int)reader["person_id"];
                        tmp.ClassId = (int)reader["class_id"];
                        tmp.SpecializationId = (int)reader["specialization_id"];
                        TeacherList.Add(tmp);
                    }
                }
            }

        }
        public void AddObj(Teacher tempObj)
        {
            TeacherList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [Teachers]([person_id],[class_id],[specialization_id])" +
                    "VALUES(@pid,@cid,@sid)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@pid", tempObj.PersonId);
                comm.Parameters.AddWithValue("@cid", tempObj.ClassId);
                comm.Parameters.AddWithValue("@sid", tempObj.SpecializationId);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            TeacherList.Clear();
            ReadFromDB();
        }
        public void RefreshList()
        {
            TeacherList.Clear();
            ReadFromDB();
        }

        public void DeleteObject(int id)
        {
            for (int i = 0; i < TeacherList.Count(); i++)
            {
                if (i == id)
                {
                    TeacherList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM Teachers WHERE id=@id";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@id", id);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<Teacher> GetEnteties()
        {
            return TeacherList;
        }

        public Teacher GetObj(int index)
        {
            return TeacherList[index];
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
