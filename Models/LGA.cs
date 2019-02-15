using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoOperation_MVC.Models
{
    public class LGA
    {
        public int LGAId { get; set; }
        public string LGAName { get; set; }
        public int StateId { get; set; }

        public virtual State State { get; set; }
    }
}