using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public bool Married  { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public bool IsDeleted { get; set; }
    }
}
