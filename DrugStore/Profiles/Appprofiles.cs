using AutoMapper;
using DrugStore.Controllers.Models;
using DrugStore.Controllers.Models.DTO;

namespace DrugStore.Profiles
{
    public class Appprofiles:Profile
    {
        public Appprofiles()
        {
            CreateMap<AddUserDTO, User>().ReverseMap();
            CreateMap<LogInUserDTO, User>().ReverseMap();
        }
    }
}
