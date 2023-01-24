using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using SDLV1.Resources;
using System.Globalization;
using System.Reflection;


namespace SDLV1.Configuration
{
    public static class ServicesLocalizationExtended
    {
       
        public static void RegisterLocalization(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddSingleton<LocalizationService>();
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = new AssemblyName(typeof(ApplicationResource).GetTypeInfo().Assembly.FullName);
                        return factory.Create("ApplicationResource", assemblyName.Name);
                    };
                       
                });

            services.Configure<RequestLocalizationOptions>(options =>
                {
                    var supprtedCultures = new[]
                    {
                        new CultureInfo("en"),
                        new CultureInfo("fa")
                        
                    };
                    options.DefaultRequestCulture = new RequestCulture(culture: supprtedCultures[0], uiCulture: supprtedCultures[0]);
                    options.SupportedCultures = supprtedCultures;
                    options.SupportedUICultures = supprtedCultures;
                }
            );
        }
                
    }
}
