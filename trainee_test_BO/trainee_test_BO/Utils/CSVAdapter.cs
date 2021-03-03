using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace trainee_test_BO.API
{
    public static class CSVAdapter
    {
        public static ICollection<Employee> GetFromCSV(IFormFile file)
        {
            var employees = new List<Employee>();
            using (var sreader = new StreamReader(file.OpenReadStream()))
            {    
                string[] headers = sreader.ReadLine().Split(',');     
                while (!sreader.EndOfStream)                          
                {
                    string[] rows = sreader.ReadLine().Split(',');
                    employees.Add(new Employee()
                    {
                        Name = rows[0],
                        Birthday = DateTime.Parse(rows[1]),
                        Married = bool.Parse(rows[2]),
                        Phone = rows[3],
                        Salary = decimal.Parse(rows[4])
                    });

                }
            }
            return employees;
        }
    }
}
