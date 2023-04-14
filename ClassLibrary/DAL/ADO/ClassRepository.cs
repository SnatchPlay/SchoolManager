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
    public class ClassRepository : IRepository<Class>
    {
        List<Class> ClassList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public ClassRepository()
        {
            ClassList = new List<Class>();
            Read();
        }
        public void Read()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [id],[name],[rowinserttime],[rowupdatetime] FROM [Class]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Class tmp = new Class();
                        tmp.Id = (int)reader["id"];
                        tmp.Name = (string)reader["name"];
                        tmp.RowInsertTime = (DateTime)reader["rowinserttime"];
                        tmp.RowUpdateTime = (DateTime)reader["rowupdatetime"];
                        ClassList.Add(tmp);
                    }
                }
            }

        }
        public void Create(Class tempObj)
        {
            ClassList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [Class]([name])" +
                    "VALUES(@name)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@name", tempObj.Name);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            ClassList.Clear();
            Read();
        }
        public void Refresh()
        {
            ClassList.Clear();
            Read();
        }

        public void Delete(Func<Class, bool> filter)
        {
            Class ps = ClassList.First(filter);
            ClassList.Remove(ps);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM Class WHERE id=@id";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@id", ps.Id);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<Class> GetAll()
        {
            return ClassList;
        }



        public void Update(Class obj)
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                var cmd = new SqlCommand("spUpdateClass", connectionSql);
                cmd.CommandType = CommandType.StoredProcedure;
                connectionSql.Open();
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.ExecuteNonQuery();
                connectionSql.Close();
            }

        }

        public Class Get(Func<Class, bool> filter)
        {
            return ClassList.First(filter);
        }
    }
}
