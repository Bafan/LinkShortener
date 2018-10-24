using LinkShortener.Engine.DataAccess;
using LinkShortener.Engine.Database;
using LinkShortener.Engine.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkShortener.Engine
{
    public static class EngineInitializer
    {
        public static void Initialize(IServiceCollection service)
        {
            service.AddTransient<ILinksDataAccessService, LinksDataAccessService>();
            service.AddTransient<LinkShortenerContext, LinkShortenerContext>();
            service.AddTransient<ILinkEncoderService, LinkEncoderService>();
            service.AddTransient<ILinkShortenerService, LinkShortenerService>();
            service.AddSingleton<IAppSettingService, AppSettingService>();
        }
    }
}
