using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.DataAccess.Builder
{
    internal sealed class Builder
    {
        public static CodingTestContext BuildTestContext()
        {
            return new CodingTestContext().Init();
        }
    }
}
