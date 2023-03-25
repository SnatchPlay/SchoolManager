using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAL.ADO
{
    public class UserRoleRepository : IRepository<UserRole>
    {
        List<UserRole> UserRoleList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public UserRoleRepository()
        {
            UserRoleList = new List<UserRole>();
            Read();
        }
        public void Read()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [id],[role_name],[rowinserttime],[rowupdatetime] FROM [UserRole]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        UserRole tmp = new UserRole();
                        tmp.Id = (int)reader["id"];
                        tmp.RoleName = (string)reader["role_name"];
                        tmp.RowInsertTime = (DateTime)reader["rowinserttime"];
                        tmp.RowUpdateTime = (DateTime)reader["rowupdatetime"];
                        UserRoleList.Add(tmp);
                    }
                }
            }

        }
        public void Create(UserRole tempObj)
        {
            UserRoleList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [UserRole]([role_name])" +
                    "VALUES(@title)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@title", tempObj.RoleName);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            UserRoleList.Clear();
            Read();
        }
        public void Refresh()
        {
            UserRoleList.Clear();
            Read();
        }

        public void Delete(int id)
        {
            for (int i = 0; i < UserRoleList.Count(); i++)
            {
                if (UserRoleList[i].Id == id)
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



        public List<UserRole> GetAll()
        {
            return UserRoleList;
        }

        public UserRole Get(int index)
        {
            return UserRoleList[index];
        }

        public void Update(UserRole obj)
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                var cmd = new SqlCommand("spUpdateUserRole", connectionSql);
                cmd.CommandType = CommandType.StoredProcedure;
                connectionSql.Open();
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@Name", obj.RoleName);
                cmd.ExecuteNonQuery();
                connectionSql.Close();
            }

        }
    }
}
