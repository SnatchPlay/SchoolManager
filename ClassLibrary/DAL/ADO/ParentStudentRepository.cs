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
    public class ParentStudentRepository : IRepository<ParentStudent>
    {
        List<ParentStudent> ParentStudentList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public ParentStudentRepository()
        {
            ParentStudentList = new List<ParentStudent>();
            Read();
        }

        public void Read()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [parent_id],[student_id],[rowinserttime],[rowupdatetime] FROM [ParentStudent]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        ParentStudent tmp = new ParentStudent();
                        tmp.ParentId = (int)reader["parent_id"];
                        tmp.StudentId = (int)reader["student_id"];
                        tmp.RowInsertTime = (DateTime)reader["rowinserttime"];
                        tmp.RowUpdateTime = (DateTime)reader["rowupdatetime"];
                        ParentStudentList.Add(tmp);
                    }
                }
            }
        }

        public void Create(ParentStudent tempObj)
        {
            ParentStudentList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [ParentStudent]([parent_id],[student_id])" +
                    "VALUES(@pid,@sid)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@pid", tempObj.ParentId);
                comm.Parameters.AddWithValue("@sid", tempObj.StudentId);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            ParentStudentList.Clear();
            Read();
        }

        public void Refresh()
        {
            ParentStudentList.Clear();
            Read();
        }

        public void Delete(Func<ParentStudent, bool> filter)
        {
            ParentStudent ps= ParentStudentList.First(filter);
            ParentStudentList.Remove(ps);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                var cmd = new SqlCommand("spDeleteParentStudent", connectionSql);
                cmd.CommandType = CommandType.StoredProcedure;
                connectionSql.Open();
                cmd.Parameters.AddWithValue("@pId", ps.ParentId);
                cmd.Parameters.AddWithValue("@sId", ps.StudentId);
                cmd.ExecuteNonQuery();
                connectionSql.Close();
            }
        }

        public List<ParentStudent> GetAll()
        {
            return ParentStudentList;
        }

        public ParentStudent Get(Func<ParentStudent, bool> filter)
        {
            return ParentStudentList.First(filter);
        }

        public void Update(ParentStudent obj)
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                var cmd = new SqlCommand("spUpdateParentStudent", connectionSql);
                cmd.CommandType = CommandType.StoredProcedure;
                connectionSql.Open();
                cmd.Parameters.AddWithValue("@pId", obj.ParentId);
                cmd.Parameters.AddWithValue("@sId", obj.StudentId);
                cmd.ExecuteNonQuery();
                connectionSql.Close();
            }
        }
    }
}
