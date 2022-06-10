using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzaAPI.Data;
using PizzaAPI.Data.Entities;
using PizzaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAPI.Services.Interfaces
{
    public class ToppingServices : IToppingServices
    {

        private readonly PizzaContext _context;
        private readonly IMapper _mapper;

        public ToppingServices(PizzaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateItem(ToppingBaseModel item)
        {
            var entity = _mapper.Map<Topping>(item);
            _context.Topping.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteItem(int id)
        {
            var item = _context.Topping.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new Exception("Item Not Found");
            }

            _context.Topping.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ToppingModel>> GetAll()
        {
            var list = await _context.Topping.ToListAsync();

            var listModel = new List<ToppingModel>();

            foreach (var item in list)
            {
                listModel.Add(_mapper.Map<ToppingModel>(item));
            }

            return listModel;
        }

        public async Task<ToppingModel> GetById(int id)
        {
            var item = await _context.Topping.FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<ToppingModel>(item);
        }

        public async Task UpdateItem(int id, ToppingBaseModel item)
        {
            var itemFound = await _context.Topping.FirstOrDefaultAsync(x => x.Id == id);

            if (itemFound == null)
                throw new System.Exception("Item Not Found");

            itemFound.Name = item.Name;
            itemFound.Calories = item.Calories;
            _context.Topping.Update(itemFound);
            await _context.SaveChangesAsync();
        }
    }
}
