using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaAPI.Models;

namespace PizzaAPI.Services.Interfaces
{
    public interface IPizzaServices
    {
        public Task<List<PizzaModel>> GetAll();        
    }
}
