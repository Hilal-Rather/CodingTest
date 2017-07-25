using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingTest.DataAccess.Internal;
using CodingTest.Models;
using CodingTestRepository.Contract;

namespace CodingTestRepository
{
    public class Repository : IServices
    {
        private DataManager _Manager;
        private List<Settled> _settled;
        private List<UnSettled> _unSettled;
        public Repository()
        {
            _Manager = new DataManager();
            _settled = _Manager.GetSettled();
            _unSettled = _Manager.GetUnSettled();
        }

        public List<Settled> GetsettledBetHistory()
        {
            return _settled.Where(_ => _.Win > 60).ToList();
        }

        public List<UnSettled> GetUnsettledBetHistory()
        {
            return _unSettled.Where(_ => _.ToWin > 60).ToList();
        }

        public List<UnSettled> Unusual(string CustomerId)
        {
            var Customer = _settled.FirstOrDefault(_ => _.Customer == CustomerId);
            if (Customer != null)
            {
                return CalculateUnusual(CustomerId);
            }
            return null;
        }

        private List<UnSettled> CalculateUnusual(string customerId, int multiplier = 10)
        {
            var settledentries = _settled.Where(_ => _.Customer == customerId);
            var enumerable = settledentries as IList<Settled> ?? settledentries.ToList();

            var unSettledentries = _unSettled.Where(_ => _.Customer == customerId);

            var average = enumerable.Sum(_ => _.Win) / enumerable.Count();
            average = average * multiplier;
            return unSettledentries.Where(_ => _.Stake > average).ToList();
        }


        public List<UnSettled> HighlyUnusual(string CustomerId)
        {

            var Customer = _settled.FirstOrDefault(_ => _.Customer == CustomerId);
            if (Customer != null)
            {
                return CalculateUnusual(CustomerId, 30);
            }
            return null;
        }

        public List<UnSettled> HighAmounts()
        {
            return _unSettled.Where(_ => _.ToWin >= 1000).ToList();
        }
    }
}
