using LandingPageTemplate.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPageTemplate.Client.Repository
{
    public interface IBlockRepository
    {
        Task Create(Block model);
        Task Delete(int id);
        Task<Block> GetById(int id);
        Task<List<Block>> GetItems();
        Task Update(Block model);
    }
}
