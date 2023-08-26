using AutoMapper;
using Base.Models;
using Services.ViewModel;

namespace Home_Demo_API.AutoMapper
{
    public class AppProfile:Profile
    {
        public AppProfile()
        {
            CreateMap<CreateCompanyViewModel,Company>().ReverseMap();
            CreateMap<CreateEmoloyeeViewModel,Employee>().ReverseMap();
            CreateMap<CreateStaffEmployeeViewModel,StaffEmoloyee>().ReverseMap();
            CreateMap<CreateStaffViewModel,Staff>().ReverseMap();
        }
    }
}
