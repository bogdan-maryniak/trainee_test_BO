using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [StringLength(32, MinimumLength = 3)]
        [RegularExpression(@"^([a-zA-ZА-ЯЁа-яё0-9_ \.\&\'\-]+)$", ErrorMessage = "Invalid Name")]
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public bool Married  { get; set; }

        [RegularExpression(@"^([+]?[\s0-9]+)?(\d{3}|[(]?[0-9]+[)])?([-]?[\s]?[0-9])+$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public bool IsDeleted { get; set; }
    }
}
