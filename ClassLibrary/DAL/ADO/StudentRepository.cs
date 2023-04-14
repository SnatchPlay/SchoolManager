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
    public class StudentRepository : IRepository<Student>
    {
        List<Student> StudentList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public StudentRepository()
        {
            StudentList = new List<Student>();
            Read();
        }
        public void Read()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [id],[person_id],[class_id],[rowinserttime],[rowupdatetime] FROM [Student]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Student tmp = new Student();
                        tmp.Id = (int)reader["id"];
                        tmp.PersonId = (int)reader["person_id"];
                        tmp.ClassId = (int)reader["class_id"];
                        tmp.RowInsertTime = (DateTime)reader["rowinserttime"];
                        tmp.RowUpdateTime = (DateTime)reader["rowupdatetime"];
                        StudentList.Add(tmp);
                    }
                }
            }

        }
        public void Create(Student tempObj)
        {
            StudentList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [Student]([person_id],[class_id])" +
                    "VALUES(@pid,@cid)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@pid", tempObj.PersonId);
                comm.Parameters.AddWithValue("@cid", tempObj.ClassId);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            StudentList.Clear();
            Read();
        }
        public void Refresh()
        {
            StudentList.Clear();
            Read();
        }

        public void Delete(Func<Student, bool> filter)
        {
            Student ps = StudentList.First(filter);
            StudentList.Remove(ps);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM Student WHERE id=@id";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@id", ps.Id);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<Student> GetAll()
        {
            return StudentList;
        }

        public Student Get(Func<Student, bool> filter)
        {
            return StudentList.First(filter);
        }

        public void Update(Student obj)
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                var cmd = new SqlCommand("spUpdateStudent", connectionSql);
                cmd.CommandType = CommandType.StoredProcedure;
                connectionSql.Open();
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@Person_id", obj.PersonId);
                cmd.Parameters.AddWithValue("@Class_id", obj.ClassId);
                cmd.ExecuteNonQuery();
                connectionSql.Close();
            }

        }
    }
}
