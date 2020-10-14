using LandingPageTemplate.Shared.Models;
using System.Threading.Tasks;

namespace LandingPageTemplate.Client.Repository
{
    public interface IAccountsRepository
    {
        Task<UserToken> Login(UserInfo userInfo);
        Task<UserToken> Register(UserInfo userInfo);
        Task<UserToken> RenewToken();
    }
}
