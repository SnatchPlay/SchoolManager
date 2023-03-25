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
    public class SpecializationRepository : IRepository<Specialization>
    {
        List<Specialization> SpecializationList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public SpecializationRepository()
        {
            SpecializationList = new List<Specialization>();
            Read();
        }
        public void Read()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [id],[name],[rowinserttime],[rowupdatetime] FROM [Specialization]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Specialization tmp = new Specialization();
                        tmp.Id = (int)reader["id"];
                        tmp.Name = (string)reader["name"];
                        tmp.RowInsertTime = (DateTime)reader["rowinserttime"];
                        tmp.RowUpdateTime = (DateTime)reader["rowupdatetime"];
                        SpecializationList.Add(tmp);
                    }
                }
            }

        }
        public void Create(Specialization tempObj)
        {
            SpecializationList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [Specialization]([name])" +
                    "VALUES(@title)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@title", tempObj.Name);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            SpecializationList.Clear();
            Read();
        }
        public void Refresh()
        {
            SpecializationList.Clear();
            Read();
        }

        public void Delete(int id)
        {
            for (int i = 0; i < SpecializationList.Count(); i++)
            {
                if (SpecializationList[i].Id == id)
                {
                    SpecializationList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM Specialization WHERE id=@id";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@id", id);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<Specialization> GetAll()
        {
            return SpecializationList;
        }

        public Specialization Get(int index)
        {
            return SpecializationList[index];
        }

        public void Update(Specialization obj)
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                var cmd = new SqlCommand("spUpdateSpecialization", connectionSql);
                cmd.CommandType = CommandType.StoredProcedure;
                connectionSql.Open();
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.ExecuteNonQuery();
                connectionSql.Close();
            }

        }
    }
}
