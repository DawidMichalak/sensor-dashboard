using AutoMapper;
using SensorDashboard.Domain.Models;

namespace SensorDashboard.Infrastructure.Persistence.Models
{
    public class DbModelsMappingProfile : Profile
    {
        public DbModelsMappingProfile()
        {
            CreateMap<DashboardConfigurationDb, DashboardConfiguration>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
            CreateMap<DashboardConfiguration, DashboardConfigurationDb>();
            CreateMap<ConfigurationItemDb, ConfigurationItem>().ReverseMap();
        }
    }
}
