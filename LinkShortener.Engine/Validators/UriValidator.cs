using System;

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
