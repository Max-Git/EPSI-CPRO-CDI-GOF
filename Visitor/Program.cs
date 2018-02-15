using System;
using System.Collections.Generic;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sans Visitor :( ");

            List<Employee> employees = new List<Employee>();
            Employee toto = new Employee(){FullName = "Toto Titi", VacationDays = 2};
            Employee tata = new Employee(){FullName = "Tata Tutu", VacationDays = 5};

            employees.Add(toto);
            employees.Add(tata);

            foreach (Employee item in employees)
            {
                item.Display();
            }
            
        }
    }

    public class Employee
    {
        public string FullName { get; set; }
        public int VacationDays { get; set; }
        
        public void Display()
        {
            Console.WriteLine("Jours de vacances de {0} =  {1}", FullName, VacationDays);
        }
    }
   
}
