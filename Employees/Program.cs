﻿namespace Employees
{
    class Employee
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Salary { get; private set; }

        public Employee(int id, string name, int age, int salary)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Salary = salary;
        }
    }
    internal class Program
    {
        static List<Employee> employees = new List<Employee>();

        static void ReadFromFile()
        {
            string[] rawFileData = File.ReadAllLines("tulajdonsagok_100sor.txt");

            foreach (var item in rawFileData)
            {
                string[] splitItem = item.Split(";");

                employees.Add(new Employee(Convert.ToInt32(splitItem[0]), splitItem[1], Convert.ToInt32(splitItem[2]), Convert.ToInt32(splitItem[3])));
            }
        }

        static void DisplayByHighestSalary()
        {
            int maxSalary = employees.Max(x => x.Salary);

            foreach (var item in employees)
            {
                if (item.Salary == maxSalary)
                {
                    Console.WriteLine($"Név: {item.Name}\nAzonosító: {item.Id}");
                }
            }
        }

        static void DisplayNearPension()
        {
            foreach (var item in employees)
            {
                if (65 - item.Age == 10)
                {
                    Console.WriteLine($"Név: {item.Name}\nKor: {item.Age}");
                }
            }
        }

        static void Main()
        {
            // 1. - 2. Feladat
            ReadFromFile();

            // 3. Feladat
            foreach (var item in employees)
            {
                Console.WriteLine(item.Name);
            }

            // 4. Feladat
            Console.WriteLine("\nLegjobban kereső(k): ");
            DisplayByHighestSalary();

            // 5. Feladat
            Console.WriteLine("\nNyugdíjhoz közel álló alkalmazottak: ");
            DisplayNearPension();

            // 6. Feladat
            Console.WriteLine($"\n{employees.Where(x => x.Salary > 50000).ToList().Count} db alkalmazott keres 50.000 felett.");
        }
    }
}
