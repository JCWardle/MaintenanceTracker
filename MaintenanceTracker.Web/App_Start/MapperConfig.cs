using AutoMapper;
using MaintenanceTracker.Domain.Model;
using MaintenanceTracker.Web.ViewModels;

namespace MaintenanceTracker.Web.App_Start
{
    public static class MapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<RegisterViewModel, User>()
                .ForMember(u => u.Password, opt => opt.Ignore())
                .ForMember(u => u.Salt, opt => opt.Ignore())
                .ForMember(u => u.Id, opt => opt.Ignore())
                .ForMember(u => u.Vehicles, opt => opt.Ignore());
        }
    }
}