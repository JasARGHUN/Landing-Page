using LandingPageTemplate.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPageTemplate.Client.Repository
{
    public interface ISocialLinkRepository
    {
        Task Create(SocialLinks model);
        Task Delete(int id);
        Task<List<SocialLinks>> Get();
        Task<SocialLinks> GetById(int id);
        Task Update(SocialLinks model);
    }
}
