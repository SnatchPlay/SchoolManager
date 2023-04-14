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
    public class TeacherRepository : IRepository<Teacher>
    {
        List<Teacher> TeacherList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public TeacherRepository()
        {
            TeacherList = new List<Teacher>();
            Read();
        }
        public void Read()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [id],[person_id],[class_id],[specialization_id],[rowinserttime],[rowupdatetime] FROM [Teacher]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Teacher tmp = new Teacher();
                        tmp.Id = (int)reader["id"];
                        tmp.PersonId = (int)reader["person_id"];
                        tmp.ClassId = (int)reader["class_id"];
                        tmp.SpecializationId = (int)reader["specialization_id"];
                        tmp.RowInsertTime = (DateTime)reader["rowinserttime"];
                        tmp.RowUpdateTime = (DateTime)reader["rowupdatetime"];
                        TeacherList.Add(tmp);
                    }
                }
            }

        }
        public void Create(Teacher tempObj)
        {
            TeacherList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [Teacher]([person_id],[class_id],[specialization_id])" +
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
            Read();
        }
        public void Refresh()
        {
            TeacherList.Clear();
            Read();
        }

        public void Delete(Func<Teacher, bool> filter)
        {
            Teacher ps = TeacherList.First(filter);
            TeacherList.Remove(ps);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM Teacher WHERE id=@id";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@id", ps.Id);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<Teacher> GetAll()
        {
            return TeacherList;
        }

        public Teacher Get(Func<Teacher, bool> filter)
        {
            return TeacherList.First(filter);
        }

        public void Update(Teacher obj)
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                var cmd = new SqlCommand("spUpdateTeacher", connectionSql);
                cmd.CommandType = CommandType.StoredProcedure;
                connectionSql.Open();
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@Person_Id", obj.PersonId);
                cmd.Parameters.AddWithValue("@Class_Id", obj.ClassId);
                cmd.Parameters.AddWithValue("@Specialization_Id", obj.SpecializationId);
                cmd.ExecuteNonQuery();
                connectionSql.Close();
            }

        }
    }
}
