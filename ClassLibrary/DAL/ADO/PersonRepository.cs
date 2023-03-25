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
    public class PersonRepository : IRepository<Person>
    {
        List<Person> PersonList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public PersonRepository()
        {
            PersonList = new List<Person>();
            Read();
        }
        public void Read()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [id],[name],[surname],[lastname],[birth_date],[user_id],[rowinserttime],[rowupdatetime] FROM [Person]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Person tmp = new Person();
                        tmp.Id = (int)reader["id"];
                        tmp.Name = (string)reader["name"];
                        tmp.Surname = (string)reader["surname"];
                        tmp.Lastname = (string)reader["lastname"];
                        tmp.BirthDate = (DateTime)reader["birth_date"];
                        tmp.UserId = (int)reader["user_id"];
                        tmp.RowInsertTime = (DateTime)reader["rowinserttime"];
                        tmp.RowUpdateTime = (DateTime)reader["rowupdatetime"];
                        PersonList.Add(tmp);
                    }
                }
            }

        }
        public void Create(Person tempObj)
        {
            PersonList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [Person]([name],[surname],[lastname],[birth_date],[user_id])" +
                    "VALUES(@name,@surname,@lastname,@birthdate,@userid)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@name", tempObj.Name);
                comm.Parameters.AddWithValue("@surname", tempObj.Surname);
                comm.Parameters.AddWithValue("@lastname", tempObj.Lastname);
                comm.Parameters.AddWithValue("@birth_date", tempObj.BirthDate.ToString("yyyy-MM-dd"));
                comm.Parameters.AddWithValue("@user_id", tempObj.UserId);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            PersonList.Clear();
            Read();
        }
        public void Refresh()
        {
            PersonList.Clear();
            Read();
        }

        public void Delete(int id)
        {
            for (int i = 0; i < PersonList.Count(); i++)
            {
                if (PersonList[i].Id == id)
                {
                    PersonList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "DELETE FROM Person WHERE id=@id";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@id", id);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<Person> GetAll()
        {
            return PersonList;
        }

        public Person Get(int index)
        {
            return PersonList[index];
        }

        public void Update(Person obj)
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                var cmd = new SqlCommand("spUpdatePerson", connectionSql);
                cmd.CommandType = CommandType.StoredProcedure;
                connectionSql.Open();
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Surname", obj.Surname);
                cmd.Parameters.AddWithValue("@Lastname", obj.Lastname);
                cmd.Parameters.AddWithValue("@Birth", obj.BirthDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@User_Id", obj.UserId);
                cmd.ExecuteNonQuery();
                connectionSql.Close();
            }

        }
    }
}
