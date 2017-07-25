using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingTest.Models;

namespace CodingTestRepository.Contract
{
    public interface IServices
    {
        List<Settled> GetsettledBetHistory(); // Task 1 part (a)
        List<UnSettled> GetUnsettledBetHistory();//Task 2 part (a) risky
        List<UnSettled> Unusual(string customerId); //Task 2 part (b) risky

        List<UnSettled> HighlyUnusual(string customerId); //Task 2 part (c) HighlyUnusual
            
        List<UnSettled> HighAmounts(); //Task 2 part (d) Amount > $1000


    }
}
