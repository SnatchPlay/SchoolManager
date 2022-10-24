using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAL
{
    public class ClassRepository:IRepository<Class>
    {
        List<Class> ClassList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public ClassRepository()
        {
            ClassList = new List<Class>();
            ReadFromDB();
        }
        public void ReadFromDB()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [id],[name] FROM [Classes]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Class tmp = new Class();
                        tmp.ClassId = (int)reader["id"];
                        tmp.Name = (string)reader["name"];
                        ClassList.Add(tmp);
                    }
                }
            }

        }
        public void AddObj(Class tempObj)
        {
            ClassList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [Classes]([name])" +
                    "VALUES(@name)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@name", tempObj.Name);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            ClassList.Clear();
            ReadFromDB();
        }
        public void RefreshList()
        {
            ClassList.Clear();
            ReadFromDB();
        }

        public void DeleteObject(int id)
        {
            for (int i = 0; i < ClassList.Count(); i++)
            {
                if (i == id)
                {
                    ClassList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM Classes WHERE user_id=@id";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@id", id);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<Class> GetEnteties()
        {
            return ClassList;
        }

        public Class GetObj(int index)
        {
            return ClassList[index];
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
