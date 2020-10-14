using AutoMapper;
using LandingPageTemplate.Shared.Models;

namespace LandingPageTemplate.Server.Helpers
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            //These codes using in all controllers in BlazorProject.Server
            CreateMap<Block, Block>().ForMember(x => x.Image, options => options.Ignore());
            CreateMap<SocialLinks, SocialLinks>().ForMember(x => x.SocialImage, options => options.Ignore());
            CreateMap<Company, Company>().ForMember(x => x.Logo, options => options.Ignore());
            CreateMap<Company, Company>().ForMember(x => x.Image, options => options.Ignore());
        }
    }
}
