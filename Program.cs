using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PerSon
{
    class Program
    {
        static void Main(string[] args)
        {
        x1:
            Method mt = new Method();
            Show();
            Console.Write("Enter id from upper");
            int id = int.Parse(Console.ReadLine());
            Console.Clear();
            Person p = mt.Select(id);
            Console.WriteLine($"id\tname\tlastname\tmiddlename\tbirthdate");
            Console.WriteLine($"{p.id}\t{p.FirstName}\t{p.LastName}\t{p.MiddleName}\t{p.BirthDate}");
            Console.WriteLine("1-for delete\n2-for update\t3-for create");
            int ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    {
                        mt.Delete(id);
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Enter Name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter LastName");
                        string lastname = Console.ReadLine();
                        Console.WriteLine("Enter MiddleName");
                        string middlename = Console.ReadLine();
                        Console.WriteLine("Enter BirthDate(dd-MM-yyyy)");
                        DateTime BirthDate = DateTime.Parse(Console.ReadLine());
                        mt.Update(id, name, lastname, middlename, BirthDate);
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine("Enter Name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter LastName");
                        string lastname = Console.ReadLine();
                        Console.WriteLine("Enter MiddleName");
                        string middlename = Console.ReadLine();
                        Console.WriteLine("Enter BirthDate(dd-MM-yyyy)");
                        DateTime BirthDate = DateTime.Parse(Console.ReadLine());
                        mt.Add(name, lastname, middlename, BirthDate);
                    }
                    break;
            }
            Console.WriteLine("Do you want to try it again?Y/N");
            string chs = Console.ReadLine().ToLower();
            if (chs == "y")
            {
                goto x1;
            }
        }
        static void Show()
        {
            List<Person> l = new List<Person>();
            Method mt = new Method();
            l = mt.ShowAll();
            Console.WriteLine($"id\tname\tlastname\tmiddlename\tbirthdate");
            foreach (var r in l)
            {
                Console.WriteLine($"{r.id}\t{r.FirstName}\t{r.LastName}\t{r.MiddleName}\t{r.BirthDate}");
            }
        }
    }
}
