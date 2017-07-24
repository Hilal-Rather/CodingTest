using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.Models
{
    public abstract class BaseClass
    {
        public string  Customer { get; set; }
        public string Event { get; set; }
        public string Participant { get; set; }
        public string Stake { get; set; }
    }
}
