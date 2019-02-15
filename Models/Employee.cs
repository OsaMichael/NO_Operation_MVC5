using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoOperation_MVC.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int? StateId { get; set; }
        public int? LGAId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual State State { get; set; }
        public virtual LGA LGa { get; set; }

        //public Employee(Employee employee)
        //{
        //    this.Address = employee.Address;
        //    this.Email = employee.Email;
        //    this.LastName = employee.LastName;
        //    this.FirstName = employee.FirstName;
        //    this.Id = employee.Id;     
        //}


    }
}