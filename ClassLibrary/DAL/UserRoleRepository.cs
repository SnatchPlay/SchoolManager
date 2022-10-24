using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAL
{
    public class UserRoleRepository:IRepository<UserRole>
    {
        List<UserRole> UserRoleList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public UserRoleRepository()
        {
            UserRoleList = new List<UserRole>();
            ReadFromDB();
        }
        public void ReadFromDB()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [id],[role_name] FROM [UserRole]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        UserRole tmp = new UserRole();
                        tmp.UserRoleId = (int)reader["id"];
                        tmp.Title = (string)reader["role_name"];
                        UserRoleList.Add(tmp);
                    }
                }
            }

        }
        public void AddObj(UserRole tempObj)
        {
            UserRoleList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [UserRole]([name])" +
                    "VALUES(@title)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@title", tempObj.Title);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            UserRoleList.Clear();
            ReadFromDB();
        }
        public void RefreshList()
        {
            UserRoleList.Clear();
            ReadFromDB();
        }

        public void DeleteObject(int id)
        {
            for (int i = 0; i < UserRoleList.Count(); i++)
            {
                if (i == id)
                {
                    UserRoleList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM UserRole WHERE id=@id";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@id", id);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<UserRole> GetEnteties()
        {
            return UserRoleList;
        }

        public UserRole GetObj(int index)
        {
            return UserRoleList[index];
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
