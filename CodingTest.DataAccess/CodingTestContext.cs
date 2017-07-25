using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CodingTest.DataAccess.Properties;
using Newtonsoft.Json;

namespace CodingTest.DataAccess
{
    internal sealed class CodingTestContext
    {



        internal CodingTestContext()
        {
        }

        internal CodingTestContext Init()
        {
            Connection.Settled = Settings.Default.Settled;
            Connection.Unsettled = Settings.Default.Unsettled;
            return this;
        }


    }

    public static  class Connection
    { 
        public static string Settled { get; set; }
        public static string Unsettled { get; set; }
    }
}
