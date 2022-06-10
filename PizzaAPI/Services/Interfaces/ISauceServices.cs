using PizzaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAPI.Services.Interfaces
{
    public interface ISauceServices
    {
        public Task<List<SauceModel>> GetAll();
        public Task<int> CreateItem(SauceBaseModel item);


        public Task<SauceModel> GetById(int id);
        public Task UpdateItem(int id, SauceBaseModel item);
        public Task DeleteItem(int id);

    }
}
