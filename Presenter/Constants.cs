using System.Collections.Generic;
using System.Globalization;

namespace PraiseBase.Presenter
{
    public static class Constants
    {        
        static public List<CultureInfo> AvailableLanguages = new List<CultureInfo>();

        static Constants()
        {
            AvailableLanguages.Add(CultureInfo.CreateSpecificCulture("de-CH"));
            AvailableLanguages.Add(CultureInfo.CreateSpecificCulture("en-US"));
        }
    }
}
