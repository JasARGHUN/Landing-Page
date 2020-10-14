using LandingPageTemplate.Client.Helpers;
using LandingPageTemplate.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandingPageTemplate.Client.Repository
{
    public class SocialLinkRepository : ISocialLinkRepository
    {
        private readonly IHttpService _httpService;
        private string url = "api/sociallink"; //Write here controller name without suffix, this property indicate route to Controller

        public SocialLinkRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task Create(SocialLinks model)
        {
            var response = await _httpService.Post(url, model);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task Update(SocialLinks model)
        {
            var response = await _httpService.Put(url, model);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<List<SocialLinks>> Get()
        {
            var response = await _httpService.Get<List<SocialLinks>>(url);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task<SocialLinks> GetById(int id)
        {
            var response = await _httpService.Get<SocialLinks>($"{url}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task Delete(int id)
        {
            var response = await _httpService.Delete($"{url}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
