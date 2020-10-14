using LandingPageTemplate.Client.Helpers;
using LandingPageTemplate.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPageTemplate.Client.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IHttpService _httpService;
        private string url = "api/company"; //Write here controller name without suffix, this property indicate route to Controller

        public CompanyRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task Create(Company model)
        {
            var response = await _httpService.Post(url, model);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<Company> GetById(int id)
        {
            return await _httpService.GetHelper<Company>($"{url}/{id}");
        }

        public async Task<List<Company>> GetItems()
        {
            var response = await _httpService.Get<List<Company>>(url);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task Update(Company model)
        {
            var response = await _httpService.Put(url, model);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
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
