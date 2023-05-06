using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Utilities
{
    public static class FieldMasking
    {
        public static string MaskNumber(string number, int unmaskedLength=4)
        {
            if (string.IsNullOrEmpty(number) || number.Length <= unmaskedLength)
                return number;

            return number.Substring(0, number.Length - unmaskedLength).PadRight(number.Length, 'x');
        }
    }
}
