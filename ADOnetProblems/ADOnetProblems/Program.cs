﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");

            EmployeeRepo repo = new EmployeeRepo();
            try
            {
                Console.WriteLine("Choose option or press 0 for exit\n1:Retrieve Data\n2:Add Data\n3:Update Basic_Salary\n4:Delete Data" +
                    "\n5:Retrive employee with date Range\n6:Find Sum Avg Max Min Count group by gender");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        repo.GetAllEmployees();
                        break;
                    case 2:
                        EmployeeModel model = new EmployeeModel
                        {
                            Name = "Pant",
                            Startdate = DateTime.Now,
                            Gender = 'M',
                            Phone = 912423,
                            Department = "DC",
                            Address = "Delhi",
                            Basic_Pay = 30000.00,
                            Deductions = 1000.00,
                            Taxable_Pay = 29000.00,
                            Income_Tax = 1000.00,
                            Net_Pay = 28000,
                        };
                        repo.AddEmployee(model);
                        repo.GetAllEmployees();
                        break;
                    case 3:
                        EmployeeModel model1 = new EmployeeModel();
                        Console.WriteLine("Enter id of employee whose data you want to update");
                        model1.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter name");
                        model1.Name = Console.ReadLine();
                        Console.WriteLine("Enter new BasicPay");
                        model1.Basic_Pay = Convert.ToDouble(Console.ReadLine());
                        repo.UpdateEmployee(model1);
                        repo.GetAllEmployees();
                        break;
                    case 4:
                        EmployeeModel model2 = new EmployeeModel();
                        Console.WriteLine("Enter id of employee whose data you want to delete");
                        model2.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter name");
                        model2.Name = Console.ReadLine();
                        repo.DeleteEmployee(model2);
                        repo.GetAllEmployees();
                        break;
                    case 5:
                        string query = "select * from employee_payroll where StartDate between cast ('2018-01-01' as date) and GETDATE()";
                        repo.GetEmployeesWithDataAdapter(query);
                        break;
                    case 6:
                        string sumquery = "select sum(Basic_Pay) as sumsalary,Gender from employee_payroll group by Gender";
                        string avgquery = "select avg(Basic_Pay) as avgsalary,Gender from employee_payroll group by Gender";
                        string maxquery = "select max(Basic_Pay) as maxsalary,Gender from employee_payroll group by Gender";
                        string minquery = "select min(Basic_Pay) as minsalary,Gender from employee_payroll group by Gender";
                        string countquery = "select count(Name) as EmployeeCount,Gender from employee_payroll group by Gender";
                        Console.WriteLine("Sum");
                        repo.GetSumOfSalary(sumquery);
                        Console.WriteLine("Avg");
                        repo.GetAvgOfSalary(avgquery);
                        Console.WriteLine("Max");
                        repo.GetMaxOfSalary(maxquery);
                        Console.WriteLine("Min");
                        repo.GetMinOfSalary(minquery);
                        Console.WriteLine("Count");
                        repo.GetCount(countquery);
                        break;
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}


//UC_5
//method to retrive employee based on date Range

/* 
Welcome
Choose option or press 0 for exit
1:Retrieve Data
2:Add Data
3:Update Basic_Salary
4:Delete Data
5:Retrive employee with date Range
5
4, Smrithi, 05-03-2018 00:00:00, F, 1234569874, Bangalore, , 40000, 0, 0, 0, 40000
5, Mithai, 02-08-2020 00:00:00, F, 1234567890, Bangalore, , 50000, 0, 0, 0, 50000
8, Pant, 20-07-2022 00:00:00, M, 912423, Delhi, DC, 67856, 1000, 29000, 1000, 28000
9, Pant, 21-07-2022 00:00:00, M, 912423, Delhi, DC, 56879, 1000, 29000, 1000, 28000

*/