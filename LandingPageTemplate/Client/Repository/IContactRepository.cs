using LandingPageTemplate.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPageTemplate.Client.Repository
{
    public interface IContactRepository
    {
        Task Create(Contact model);
        Task Delete(int id);
        Task<List<Contact>> Get();
        Task<Contact> GetById(int id);
        Task Update(Contact model);
    }
}
