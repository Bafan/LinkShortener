using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Engine.Services
{
    internal interface ILinkEncoderService
    {
        string SeedToShorten(int seedId);

        int ShortenToSeed(string shorten);
    }

    internal class LinkEncoderService: ILinkEncoderService
    {
        private const string VALID_CHARS = "abcdefghijklmnopqrstuvwxyz0123456789";
        private const int BASE = 62;

        public string SeedToShorten(int seedId)
        {
            if (seedId == 0)
                throw new Exception("Invalid seed ID");

            StringBuilder sb = new StringBuilder();

            while (seedId > 0)
            {
                sb.Insert(0, VALID_CHARS[seedId % BASE]);                
                seedId = seedId / BASE;
            }

            return sb.ToString();
        }

        public int ShortenToSeed(string shorten)
        {
            var accumulator = 0;
            foreach (var c in shorten)
            {
                accumulator = (accumulator * BASE) + VALID_CHARS.IndexOf(c);
            }
            return accumulator;
        }
    }
}
