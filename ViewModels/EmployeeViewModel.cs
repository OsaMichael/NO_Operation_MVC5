using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoOperation_MVC.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}