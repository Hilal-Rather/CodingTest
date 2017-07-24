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
        Settled GetsettledBetHistory(); // Task 1 part (a)
        UnSettled Unusual(); //Task 2 part (a) risky

        UnSettled HighlyUnusual(); //Task 2 part (b) HighlyUnusual
        UnSettled HighAmounts(); //Task 2 part (c) Amount > $1000


    }
}
