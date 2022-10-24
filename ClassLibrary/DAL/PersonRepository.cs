using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAL
{
    public class PersonRepository:IRepository<Person>
    {
        List<Person> PersonList;
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public PersonRepository()
        {
            PersonList = new List<Person>();
            ReadFromDB();
        }
        public void ReadFromDB()
        {
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "SELECT [id],[name],[surname],[lastname],[birth_date],[user_id] FROM [Person]";

                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Person tmp = new Person();
                        tmp.PersonId=(int)reader["id"];
                        tmp.Name=(string)reader["name"];
                        tmp.Surname = (string)reader["surname"];
                        tmp.Lastname = (string)reader["lastname"];
                        tmp.BirthDate=(DateTime)reader["birth_date"];
                        tmp.UserId=(int)reader["user_id"];
                        PersonList.Add(tmp);
                    }
                }
            }

        }
        public void AddObj(Person tempObj)
        {
            PersonList.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                connectionSql.Open();
                string CommandText = "INSERT INTO [Person]([name],[surname],[lastname],[birth_date],[user_id])" +
                    "VALUES(@name,@surname,@lastname,@birthdate,@userid)";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@name",tempObj.Name);
                comm.Parameters.AddWithValue("@surname", tempObj.Surname);
                comm.Parameters.AddWithValue("@lastname", tempObj.Lastname);
                comm.Parameters.AddWithValue("@birth_date", tempObj.BirthDate.ToString("yyyy-MM-dd"));
                comm.Parameters.AddWithValue("@user_id", tempObj.UserId);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
            PersonList.Clear();
            ReadFromDB();
        }
        public void RefreshList()
        {
            PersonList.Clear();
            ReadFromDB();
        }

        public void DeleteObject(int id)
        {
            for (int i = 0; i < PersonList.Count(); i++)
            {
                if (i == id)
                {
                    PersonList.RemoveAt(i);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {

                connectionSql.Open();
                string CommandText = "DELETE FROM Person WHERE user_id=@id";
                SqlCommand comm = new SqlCommand(CommandText, connectionSql);
                comm.Parameters.AddWithValue("@id", id);
                comm.ExecuteNonQuery();
                connectionSql.Close();
            }
        }



        public List<Person> GetEnteties()
        {
            return PersonList;
        }

        public Person GetObj(int index)
        {
            return PersonList[index];
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
