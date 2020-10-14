using LandingPageTemplate.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPageTemplate.Client.Repository
{
    public interface ILocationRepository
    {
        Task Create(Location model);
        Task Delete(int id);
        Task<List<Location>> Get();
        Task<Location> GetById(int id);
        Task Update(Location model);
    }
}
