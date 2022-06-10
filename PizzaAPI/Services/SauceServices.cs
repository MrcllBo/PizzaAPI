using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PizzaAPI.Data;
using PizzaAPI.Data.Entities;
using PizzaAPI.Models;
using PizzaAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAPI.Services
{
    public class SauceServices : ISauceServices
    {

        private readonly PizzaContext _context;
        private readonly IMapper _mapper;


        public SauceServices(PizzaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateItem(SauceBaseModel item)
        {
            var entity = _mapper.Map<Sauce>(item);
            _context.Sauce.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteItem(int id)
        {
            var item = _context.Sauce.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new Exception("Item Not Found");
            }

            _context.Sauce.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SauceModel>> GetAll()
        {
            var list = await _context.Sauce.ToListAsync();

            var listModel = new List<SauceModel>();

            foreach (var item in list)
            {
                listModel.Add(_mapper.Map<SauceModel>(item));
            }

            return listModel;
        }

        public async Task<SauceModel> GetById(int id)
        {
            var item = await _context.Sauce.FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<SauceModel>(item);
        }

        public async Task UpdateItem(int id, SauceBaseModel item)
        {
            var itemFound = await _context.Sauce.FirstOrDefaultAsync(x => x.Id == id);

            if (itemFound == null)
                throw new System.Exception("Item Not Found");

            itemFound.Name = item.Name;
            itemFound.IsVegan = item.IsVegan;
            _context.Sauce.Update(itemFound);
            await _context.SaveChangesAsync();
        }
    }
}
