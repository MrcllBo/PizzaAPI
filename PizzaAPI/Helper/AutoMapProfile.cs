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

            //topping
            CreateMap<Topping, ToppingModel>().ReverseMap();
            CreateMap<Topping, ToppingBaseModel>().ReverseMap();

            //sauce
            CreateMap<Sauce, SauceModel>().ReverseMap();
            CreateMap<Sauce, SauceBaseModel>().ReverseMap();
        }
    }
}
