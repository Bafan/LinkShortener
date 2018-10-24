using LinkShortener.Engine.DataAccess;
using LinkShortener.Engine.Database;
using LinkShortener.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace LinkShortener.Engine.Services
{
    public interface ILinkShortenerService
    {
        Uri OriginToShortener(string uriString);
        Uri ShortenerToOrigin(string uriString);
    }

    internal class LinkShortenerService: ILinkShortenerService
    {
        private ILinkEncoderService _encoder;
        private ILinksDataAccessService _context;
        private IAppSettingService _appSetting;

        public LinkShortenerService(ILinkEncoderService encoder, ILinksDataAccessService context, IAppSettingService appSetting)
        {
            _encoder = encoder;
            _context = context;
            _appSetting=appSetting;

        }
        public Uri OriginToShortener(string uriString)
        {
            ValidateUri(uriString);

            var link = _context.AddLink(new Link() { Origin = uriString });
            var result = _encoder.SeedToShorten(link.ID);
            _context.UpdateShortenLink(link.ID, result);
            return new Uri(_appSetting.GetHostBaseUri, result);
        }

        public Uri ShortenerToOrigin(string uriString)
        {
            ValidateUri(uriString);
            
            if (!Regex.IsMatch(uriString, $"^{_appSetting.GetHostBaseUri.AbsoluteUri}.*"))
                throw new Exception("Invalid domain name in url");

            Uri uri = new Uri(uriString);            
            var result = _encoder.ShortenToSeed(uri.GetComponents(UriComponents.Path, UriFormat.UriEscaped));
            var link = _context.GetById(result);
            if (link == null)
                throw new Exception("There is no corresponed record for this link");
            return new Uri(link.Origin);
        }

        private void ValidateUri(string uriString)
        {
            if (!UriValidator.IsValid(uriString))
                throw new Exception("Invalid Uri");
        }
    }
}