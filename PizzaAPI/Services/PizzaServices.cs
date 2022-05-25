using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzaAPI.Data;
using PizzaAPI.Data.Entities;
using PizzaAPI.Models;
using PizzaAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaAPI.Services
{
    public class PizzaServices : IPizzaServices
    {
        private readonly PizzaContext _context;
        private readonly IMapper _mapper;

        public PizzaServices(PizzaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PizzaModel>> GetAll()
        {
            var pizzas = await _context.Pizza.ToListAsync();            
            return _mapper.Map<List<Pizza>, List<PizzaModel>>(pizzas);
        }
        
    }
}
