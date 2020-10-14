using LandingPageTemplate.Client.Helpers;
using LandingPageTemplate.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPageTemplate.Client.Repository
{
    public class BlockRepository : IBlockRepository
    {
        private readonly IHttpService _httpService;
        private string url = "api/block"; //Write here controller name without suffix, this property indicate route to Controller

        public BlockRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task Create(Block model)
        {
            var response = await _httpService.Post(url, model);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<Block> GetById(int id)
        {
            return await _httpService.GetHelper<Block>($"{url}/{id}");
        }

        public async Task<List<Block>> GetItems()
        {
            var response = await _httpService.Get<List<Block>>(url);

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task Update(Block model)
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
