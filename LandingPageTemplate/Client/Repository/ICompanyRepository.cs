using LandingPageTemplate.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandingPageTemplate.Client.Repository
{
    public interface ICompanyRepository
    {
        Task Create(Company model);
        Task Delete(int id);
        Task<Company> GetById(int id);
        Task<List<Company>> GetItems();
        Task Update(Company model);
    }
}
