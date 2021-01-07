using AutoMapper;
using LastTask.Models.Products;
using LastTask.Models.Request;
using LastTask.Models.Response;
using System.Collections.Generic;

namespace LastTask.Extensions
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ComputerResponse, Computer>().ReverseMap();
            CreateMap<ComputerRequest, Computer>().ReverseMap();
            CreateMap<IEnumerable<ComputerResponse>, IEnumerable<Computer>>();

            CreateMap<LaptopResponse, Laptop>().ReverseMap();
            CreateMap<LaptopRequest, Laptop>().ReverseMap();
            CreateMap<IEnumerable<LaptopResponse>, IEnumerable<Laptop>>();

            CreateMap<SmartphoneResponse, Smartphone>().ReverseMap();
            CreateMap<SmartphoneRequest, Smartphone>().ReverseMap();
            CreateMap<IEnumerable<SmartphoneResponse>, IEnumerable<Smartphone>>();

            CreateMap<TelevisorResponse, Televisor>().ReverseMap();
            CreateMap<TelevisorRequest, Televisor>().ReverseMap();
            CreateMap<IEnumerable<TelevisorResponse>, IEnumerable<Televisor>>();
        }
    }
}
