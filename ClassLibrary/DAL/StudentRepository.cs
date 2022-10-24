using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAL
{
    public class StudentRepository:IRepository<Student>
    {
        List<Student> StudentList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public StudentRepository()
        {
            StudentList = new List<Student>();
            ReadFromDB();
        }
        public void ReadFromDB()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [id],[person_id],[class_id] FROM [Students]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Student tmp = new Student();
                        tmp.StudentId = (int)reader["id"];
                        tmp.PersonId = (int)reader["person_id"];
                        tmp.ClassId = (int)reader["class_id"];
                        StudentList.Add(tmp);
                    }
                }
            }

        }
        public void AddObj(Student tempObj)
        {
            StudentList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [Students]([person_id],[class_id])" +
                    "VALUES(@pid,@cid)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@pid", tempObj.PersonId);
                comm.Parameters.AddWithValue("@cid", tempObj.ClassId);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            StudentList.Clear();
            ReadFromDB();
        }
        public void RefreshList()
        {
            StudentList.Clear();
            ReadFromDB();
        }

        public void DeleteObject(int id)
        {
            for (int i = 0; i < StudentList.Count(); i++)
            {
                if (i == id)
                {
                    StudentList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM Students WHERE id=@id";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@id", id);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<Student> GetEnteties()
        {
            return StudentList;
        }

        public Student GetObj(int index)
        {
            return StudentList[index];
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
