using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using SDLV1.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XAct;


namespace SDLV1.Configuration
{
    public static class ServicesLocalizationExtended
    {
       
        public static void RegisterLocalization(this IServiceCollection services)
        {
            services.AddLocalization();
            services.AddSingleton<IStringLocalizerFactory, JsonStringLocatizerFactory>();
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {
                        options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(JsonStringLocatizerFactory));
                    });

            services.Configure<RequestLocalizationOptions>(options =>
                {
                    var supprtedCultures = new[]
                    {
                        new CultureInfo("en-US"),
                        new CultureInfo("fa-IR"),
                        new CultureInfo("ar-EG"),
                        new CultureInfo("de-DE")
                    };
                    options.DefaultRequestCulture = new RequestCulture(culture: supprtedCultures[0], uiCulture: supprtedCultures[0]);
                    options.SupportedCultures = supprtedCultures;
                    options.SupportedUICultures = supprtedCultures;
                }
            );
        }
                
    }
}
