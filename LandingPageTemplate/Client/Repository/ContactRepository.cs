using LandingPageTemplate.Client.Helpers;
using LandingPageTemplate.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandingPageTemplate.Client.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly IHttpService _httpService;
        private string url = "api/contact"; //Write here controller name without suffix, this property indicate route to Controller

        public ContactRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task Create(Contact model)
        {
            var response = await _httpService.Post(url, model);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task Update(Contact model)
        {
            var response = await _httpService.Put(url, model);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<List<Contact>> Get()
        {
            var response = await _httpService.Get<List<Contact>>(url);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task<Contact> GetById(int id)
        {
            var response = await _httpService.Get<Contact>($"{url}/{id}");
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
