using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace practical1.Models
{
   
    public class eventmodel
    {
        public int eventcode { get; set; }
        public string title { get; set; }
        public string typeofevent { get; set; }
        public int estimatecost { get; set; }
        public int actualcost { get; set; }
        public DateTime dateofevent { get; set; }
    }
}