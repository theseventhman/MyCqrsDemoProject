using AutoMapper;
using MyCqrsDemo.Application.ViewModels;
using MyCqrsDemo.Domain.Models;

namespace MyCqrsDemo.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>();
        }
    }
}