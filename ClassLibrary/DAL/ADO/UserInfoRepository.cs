﻿using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAL.ADO
{
    public class UserInfoRepository : IRepository<UserInfo>
    {
        List<UserInfo> UserInfoList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public UserInfoRepository()
        {
            UserInfoList = new List<UserInfo>();
            Read();
        }
        public void Read()
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
                        tmp.Id = (int)reader["id"];
                        tmp.Login = (string)reader["login"];
                        tmp.Password = (byte[])reader["password"];
                        tmp.Role = (int)reader["role"];
                        tmp.Salt = (Guid)reader["salt"];
                        UserInfoList.Add(tmp);
                    }
                }
            }

        }
        public void Create(UserInfo tempObj)
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
                comm.Parameters.AddWithValue("@pass", "0x" + BitConverter.ToString(tempObj.Password).Replace("-", "").ToLower());
                comm.Parameters.AddWithValue("@role", tempObj.Role);
                comm.Parameters.AddWithValue("@salt", tempObj.Salt);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            UserInfoList.Clear();
            Read();
        }
        public void Refresh()
        {
            UserInfoList.Clear();
            Read();
        }

        public void Delete(int id)
        {
            for (int i = 0; i < UserInfoList.Count(); i++)
            {
                if (UserInfoList[i].Id == id)
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



        public List<UserInfo> GetAll()
        {
            return UserInfoList;
        }

        public UserInfo Get(int index)
        {
            return UserInfoList[index];
        }

        public void Update(UserInfo obj)
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                var cmd = new SqlCommand("spUpdateUserInfo", connectionSql);
                cmd.CommandType = CommandType.StoredProcedure;
                connectionSql.Open();
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@Login", obj.Login);
                cmd.Parameters.AddWithValue("@Password", "0x" + BitConverter.ToString(obj.Password).Replace("-", "").ToLower());
                cmd.Parameters.AddWithValue("@Role", obj.Role);
                cmd.Parameters.AddWithValue("@Salt", obj.Salt);
                cmd.ExecuteNonQuery();
                connectionSql.Close();
            }

        }
    }
}