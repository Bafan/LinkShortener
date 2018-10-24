using LinkShortener.Engine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LinkShortener.Engine
{
    public class UriValidator
    {
        public static bool IsValid(string uriString)
        {
            return Uri.IsWellFormedUriString(uriString,UriKind.Absolute);
        }
    }
}
