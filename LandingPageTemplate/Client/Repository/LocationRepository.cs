using LandingPageTemplate.Client.Helpers;
using LandingPageTemplate.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPageTemplate.Client.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IHttpService _httpService;
        private string url = "api/location"; //Write here controller name without suffix, this property indicate route to Controller

        public LocationRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task Create(Location model)
        {
            var response = await _httpService.Post(url, model);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task Update(Location model)
        {
            var response = await _httpService.Put(url, model);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<List<Location>> Get()
        {
            var response = await _httpService.Get<List<Location>>(url);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task<Location> GetById(int id)
        {
            var response = await _httpService.Get<Location>($"{url}/{id}");
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
