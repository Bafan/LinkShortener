using Microsoft.Extensions.Options;
using System;

namespace LinkShortener.Engine.Services
{
    #region Application Setting Interface
    internal interface IAppSettingService
    {
        Uri GetHostBaseUri { get; }
        string GetConnectionString { get; }
    }
    #endregion

    #region Application Setting Implementation
    internal class AppSettingService : IAppSettingService
    {
        #region Private Members
        private IOptions<LinkShortenerSetting> _options;
        private Uri _hostBaseUrl;
        #endregion

        #region Constructor
        public AppSettingService(IOptions<LinkShortenerSetting> options)
        {
            _options = options;
        }
        #endregion

        #region Public Members
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
        #endregion
    }  
    #endregion
}
