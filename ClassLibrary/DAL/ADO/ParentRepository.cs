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
    public class ParentRepository : IRepository<Parent>
    {
        List<Parent> ParentList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public ParentRepository()
        {
            ParentList = new List<Parent>();
            Read();
        }
        public void Read()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [id],[person_id],[rowinserttime],[rowupdatetime] FROM [Parent]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Parent tmp = new Parent();
                        tmp.Id = (int)reader["id"];
                        tmp.PersonId = (int)reader["person_id"];
                        tmp.RowInsertTime = (DateTime)reader["rowinserttime"];
                        tmp.RowUpdateTime = (DateTime)reader["rowupdatetime"];
                        ParentList.Add(tmp);
                    }
                }
            }

        }
        public void Create(Parent tempObj)
        {
            ParentList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [Parent]([person_id])" +
                    "VALUES(@pid)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@pid", tempObj.PersonId);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            ParentList.Clear();
            Read();
        }
        public void Refresh()
        {
            ParentList.Clear();
            Read();
        }

        public void Delete(Func<Parent, bool> filter)
        {
            Parent ps = ParentList.First(filter);
            ParentList.Remove(ps);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM Parent WHERE id=@id";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@id", ps.Id);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<Parent> GetAll()
        {
            return ParentList;
        }

        public Parent Get(Func<Parent, bool> filter)
        {
            return ParentList.First(filter);
        }

        public void Update(Parent obj)
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                var cmd = new SqlCommand("spUpdateParent", connectionSql);
                cmd.CommandType = CommandType.StoredProcedure;
                connectionSql.Open();
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@Person_id", obj.PersonId);
                cmd.ExecuteNonQuery();
                connectionSql.Close();
            }

        }
    }
}
