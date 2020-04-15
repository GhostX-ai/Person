using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace PerSon
{
    public class Method
    {
        private string conStr = @"data source=GHOSTX-PC;initial catalog=TestDB;integrated security=true";
        public Person Select(int id)
        {
            Person p = new Person();
            SqlConnection cn = new SqlConnection(conStr);
            cn.Open();
            List<Person> li = new List<Person>();
            if (cn.State == ConnectionState.Open)
            {
                string cmt = $"select * from Person where id={id}";
                SqlCommand cm = new SqlCommand(cmt, cn);
                SqlDataReader sr = cm.ExecuteReader();
                while (sr.Read())
                {
                    p = new Person()
                    {
                        id = int.Parse(sr.GetValue("id").ToString()),
                        FirstName = sr.GetValue("FirstName").ToString(),
                        LastName = sr.GetValue("LastName").ToString(),
                        MiddleName = sr.GetValue("MiddleName").ToString(),
                        BirthDate = DateTime.Parse(sr.GetValue("BirthDate").ToString())
                    };
                }
            }
            return p;
        }
        public List<Person> ShowAll()
        {
            SqlConnection cn = new SqlConnection(conStr);
            cn.Open();
            List<Person> li = new List<Person>();
            if (cn.State == ConnectionState.Open)
            {
                string cmt = $"select * from Person";
                SqlCommand cm = new SqlCommand(cmt, cn);
                SqlDataReader sr = cm.ExecuteReader();
                while (sr.Read())
                {
                    li.Add(new Person()
                    {
                        id = int.Parse(sr.GetValue("id").ToString()),
                        FirstName = sr.GetValue("FirstName").ToString(),
                        LastName = sr.GetValue("LastName").ToString(),
                        MiddleName = sr.GetValue("MiddleName").ToString(),
                        BirthDate = DateTime.Parse(sr.GetValue("BirthDate").ToString())
                    });
                }
            }
            return li;
        }
        public void Add(string FirstName, string LastName, string MiddleName, DateTime BirthDate)
        {
            SqlConnection cn = new SqlConnection(conStr);
            cn.Open();
            if (cn.State == ConnectionState.Open)
            {
                string cmt = $"insert into Person(LastName,FirstName,MiddleName,BirthDate) values('{LastName}','{FirstName}','MiddleName','{BirthDate}')";
                SqlCommand cm = new SqlCommand(cmt, cn);
                cm.ExecuteNonQuery();
                ShowAll();
            }
        }
        public void Update(int id, string FirstName, string LastName, string MiddleName, DateTime BirthDate)
        {
            SqlConnection cn = new SqlConnection(conStr);
            cn.Open();
            if (cn.State == ConnectionState.Open)
            {
                string cmt = $"update Person set FirstName = '{FirstName}', LastName = '{LastName}',MiddleName='{MiddleName}' where id = {id}";
                SqlCommand cm = new SqlCommand(cmt, cn);
                cm.ExecuteNonQuery();
                ShowAll();
            }
        }
        public void Delete(int id)
        {
            SqlConnection cn = new SqlConnection(conStr);
            cn.Open();
            if (cn.State == ConnectionState.Open)
            {
                string cmt = $"delete from Person where id = {id}";
                SqlCommand cm = new SqlCommand(cmt, cn);
                cm.ExecuteNonQuery();
                ShowAll();
            }
        }
    }
    public class Person
    {
        public int id { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}