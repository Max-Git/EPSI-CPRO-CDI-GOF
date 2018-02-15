using System;
using System.Collections.Generic;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Avec visitor");

            List<Employee> employees = new List<Employee>();
            Employee toto = new Employee(){
                FullName = "Toto Titi",
                VacationDays = 2,
                Salary=1500,
                Position="Consultant"
                };
            Employee tata = new Employee(){
                FullName = "Tata Tutu", 
                VacationDays = 5,
                Salary=2000,
                Position="PDG"
                };

            employees.Add(toto);
            employees.Add(tata);

            foreach (Employee item in employees)
            {
                item.Display();
            }
            
            foreach (Employee item in employees)
            {
                item.Accept(new AddVacationVisitor());
                item.Accept(new IncreaseSalaryVisitor());
                item.Display();
            }
        }
    }

    public interface IVisitable{
        void Accept(IVisitor visitor);
    }

    public interface IVisitor
    {
        void Visit(IVisitable visitableElement);
    }

    public class Employee : IVisitable
    {
        public int Salary { get; set; }

        public string Position { get; set; }
        
        

        public string FullName { get; set; }
        public int VacationDays { get; set; }

        public void Accept(IVisitor visitor)
        {
           visitor.Visit(this); 
        }

        public void Display()
        {
            Console.WriteLine("Jours de vacances de {0} =  {1}", FullName, VacationDays);
            
            Console.WriteLine("Salaire de {0} qui est {1} = {2}", FullName, Position, Salary);
        }
    }

    public class AddVacationVisitor : IVisitor
    {
        public void Visit(IVisitable visitableElement)
        {
            Employee employee = visitableElement as Employee;
            employee.VacationDays+=30;
        }
    }

    public class IncreaseSalaryVisitor : IVisitor
    {
        public void Visit(IVisitable visitableElement)
        {
            Employee employee = visitableElement as Employee;
            switch (employee.Position)
            {
                case "PDG":
                    employee.Salary+=1500;
                    break;    
                default:
                    employee.Salary-=250;
                    break;
            }
        }
    }


}
