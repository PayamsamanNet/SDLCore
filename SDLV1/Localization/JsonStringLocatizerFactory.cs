using Microsoft.Extensions.Localization;

namespace SDLV1.Localization
{
    public class JsonStringLocatizerFactory : IStringLocalizerFactory
    {
        public IStringLocalizer Create(Type resourceSource)
        {
            return new JsonStringLocatizer();
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new JsonStringLocatizer();
        }
    }
}
