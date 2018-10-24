using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShortener.Engine.Services
{
    internal interface IAppSettingService
    {
        Uri GetHostBaseUri { get; }
        string GetConnectionString { get; }
    }

    internal class AppSettingService : IAppSettingService
    {
        private IOptions<LinkShortenerSetting> _options;
        private Uri _hostBaseUrl;

        public AppSettingService(IOptions<LinkShortenerSetting> options)
        {
            _options = options;
        }

        public Uri GetHostBaseUri
        {
            get
            {
                if (_hostBaseUrl != null)
                    return _hostBaseUrl;
                var value = _options.Value.HostbaseUrl;
                if (!UriValidator.IsValid(value))
                    throw new Exception("Invalid HostBaseUri in configuration file");
                return _hostBaseUrl = new Uri(value);
            }
        }

        public string GetConnectionString => _options.Value.LinkDbConnectionString;
    }
}
