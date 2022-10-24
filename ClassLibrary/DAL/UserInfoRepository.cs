using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAL
{
    public class UserInfoRepository:IRepository<UserInfo>
    {
        List<UserInfo> UserInfoList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public UserInfoRepository()
        {
            UserInfoList = new List<UserInfo>();
            ReadFromDB();
        }
        public void ReadFromDB()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [id],[login],[password],[role],[salt] FROM [UserInfo]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        UserInfo tmp = new UserInfo();
                        tmp.UserId = (int)reader["id"];
                        tmp.Login = (string)reader["login"];
                        tmp.Password = (byte[])reader["password"];
                        tmp.RoleId = (int)reader["role"];
                        tmp.Salt = (Guid)reader["salt"];
                        UserInfoList.Add(tmp);
                    }
                }
            }

        }
        public void AddObj(UserInfo tempObj)
        {
            UserInfoList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [UserInfo]([login],[password],[role],[salt])" +
                    "VALUES(@login,@pass,@role,@salt)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@login", tempObj.Login);
                comm.Parameters.AddWithValue("@pass", "0x"+ BitConverter.ToString(tempObj.Password).Replace("-", "").ToLower());
                comm.Parameters.AddWithValue("@role", tempObj.RoleId);
                comm.Parameters.AddWithValue("@salt", tempObj.Salt);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            UserInfoList.Clear();
            ReadFromDB();
        }
        public void RefreshList()
        {
            UserInfoList.Clear();
            ReadFromDB();
        }

        public void DeleteObject(int id)
        {
            for (int i = 0; i < UserInfoList.Count(); i++)
            {
                if (i == id)
                {
                    UserInfoList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM UserInfo WHERE id=@id";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@id", id);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<UserInfo> GetEnteties()
        {
            return UserInfoList;
        }

        public UserInfo GetObj(int index)
        {
            return UserInfoList[index];
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
