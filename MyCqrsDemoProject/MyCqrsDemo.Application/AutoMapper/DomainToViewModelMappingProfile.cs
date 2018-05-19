using AutoMapper;
using MyCqrsDemo.Application.ViewModels;
using MyCqrsDemo.Domain.Models;

namespace MyCqrsDemo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}