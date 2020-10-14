using System;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPageTemplate.Client.Helpers
{
    public static class IHttpServiceExtensionMethods
    {
        public static async Task<T> GetHelper<T>(this IHttpService _httpService, string url)
        {
            var response = await _httpService.Get<T>(url);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }
    }
}
