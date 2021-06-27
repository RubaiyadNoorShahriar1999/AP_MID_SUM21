using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace LabPerformance.Models.Database
{
    public class Students
    {
        public Students students { get; set; }
        SqlConnection conn;

        public Students(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void Insert(Student p)
        {
            string query = "Insert into Products values(@name,@id,@dob,@credit,@cgpa,@dept_id)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", p.Name);
            cmd.Parameters.AddWithValue("@id", p.ID);
            cmd.Parameters.AddWithValue("@dob", p.DOB);
            cmd.Parameters.AddWithValue("@credit", p.Credit);
            cmd.Parameters.AddWithValue("@cgpa", p.CGPA);
            cmd.Parameters.AddWithValue("@dept_id", p.Dept_ID);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<Student> GetAll()
        {
            List<Student> products = new List<Student>();
            string query = "select * from Students";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Student p = new Student()
                {
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    ID = reader.GetString(reader.GetOrdinal("ID")),
                    DOB = reader.GetString(reader.GetOrdinal("DOB")),
                    Credit = reader.GetInt32(reader.GetOrdinal("Credit")),
                    CGPA = reader.GetDouble(reader.GetOrdinal("CGPA")),
                    Dept_ID = reader.GetInt32(reader.GetOrdinal("Dept_ID")),
                };
                products.Add(p);
            }
            conn.Close();
            return products;
        }
        public Student Get(int id)
        {
            Student p = null;
            string query = $"select * from Products Where Id={id}";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                p = new Student()
                {
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    ID = reader.GetString(reader.GetOrdinal("ID")),
                    DOB = reader.GetString(reader.GetOrdinal("DOB")),
                    Credit = reader.GetInt32(reader.GetOrdinal("Credit")),
                    CGPA = reader.GetDouble(reader.GetOrdinal("CGPA")),
                    Dept_ID = reader.GetInt32(reader.GetOrdinal("Dept_ID")),
                };
            }
            conn.Close();
            return p;
        }
        public void Update(Student p)
        {
            string query = $"Update Products Set Name='{p.Name}', ID='{p.ID}' ,DOB='{p.DOB}', Credit={p.Credit},CGPA ={p.CGPA} ,Dept_ID = {p.Dept_ID} Where ID = {p.ID}";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        void Delete(Student p)
        {
        }
    }
}