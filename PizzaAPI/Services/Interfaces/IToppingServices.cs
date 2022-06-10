using PizzaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAPI.Services.Interfaces
{
    public interface IToppingServices
    {
        public Task<List<ToppingModel>> GetAll();
        public Task<int> CreateItem(ToppingBaseModel item);


        public Task<ToppingModel> GetById(int id);
        public Task UpdateItem(int id, ToppingBaseModel item);
        public Task DeleteItem(int id);
    }
}
