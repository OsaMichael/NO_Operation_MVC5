using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoOperation_MVC.Models
{
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<LGA> LGAs { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}