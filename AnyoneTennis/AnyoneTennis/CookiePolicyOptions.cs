using Microsoft.AspNetCore.Http;

namespace AnyoneTennis
{
    internal class CookiePolicyOptions
    {
        public System.Func<object, bool> CheckConsentNeeded { get; internal set; }
        public SameSiteMode MinimumSameSitePolicy { get; internal set; }
    }
}