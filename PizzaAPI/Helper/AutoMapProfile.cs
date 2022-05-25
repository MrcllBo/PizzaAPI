using AutoMapper;
using PizzaAPI.Data.Entities;
using PizzaAPI.Models;

namespace PizzaAPI.Helper
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            CreateMap<PizzaModel, Pizza>().ReverseMap();
        }
    }
}
