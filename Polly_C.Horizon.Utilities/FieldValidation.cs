using Polly_C.Horizon.Models.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Polly_C.Horizon.Utilities
{
    public static class FieldValidation
    {
        public static bool IsValidSAIDNumber(string SAIDNumber)
        {
            if (string.IsNullOrEmpty(SAIDNumber)) { return false; }
            else
            {
                return Regex.IsMatch(SAIDNumber, @"^[0-9]{13}$");
            }
        }
    }
}
