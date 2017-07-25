using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CodingTest.Models;

namespace CodingTest.DataAccess.Internal
{
    public class DataManager
    {
        internal CodingTestContext Context { get; set; }
        public DataManager()
        {
            Context = Builder.Builder.BuildTestContext();
        }
       

        private string _settledPath = @"/App_Data/TestAppData/Settled.csv";
        private string _unSettledPath = @"/App_Data/TestAppData/Unsettled.csv";

        public List<Settled> GetSettled()
        {

            var data = System.IO.File.ReadAllLines(HttpContext.Current.Server.MapPath(_settledPath)).Skip(1);

            var list = new List<Settled>();
            var enumerable = data as IList<string> ?? data.ToList();
            for (int i = 0; i < enumerable.Count(); i++)
            {
                var row = enumerable[i].Split(',');

                list.Add(
                    new Settled()
                    {

                        Customer = row[0],
                        Event = row[1],
                        Participant = row[2],
                        Stake = Convert.ToUInt32(row[3]),
                        Win = Convert.ToUInt32(row[4])

                    }
                );
                

            }
            return list;
        }

        public List<UnSettled> GetUnSettled()
        {
            var data = System.IO.File.ReadAllLines(HttpContext.Current.Server.MapPath(_unSettledPath)).Skip(1);

            var list = new List<UnSettled>();
            var enumerable = data as IList<string> ?? data.ToList();
            for (int i = 0; i < enumerable.Count(); i++)
            {
                var row = enumerable[i].Split(',');

                list.Add(
                    new UnSettled()
                    {

                        Customer = row[0],
                        Event = row[1],
                        Participant = row[2],
                        Stake = Convert.ToUInt32(row[3]),
                        ToWin = Convert.ToUInt32(row[4])

                    }
                );


            }
            return list;
        }

    }
}
