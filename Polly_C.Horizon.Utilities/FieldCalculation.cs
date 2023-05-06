using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Utilities
{
    public static class FieldCalculation
    {
        public static int Age(DateTime dateOfBirth)
        {
            TimeSpan age = DateTime.Today - dateOfBirth;
            return (int)(age.TotalDays / 365);
        }
    }
}
