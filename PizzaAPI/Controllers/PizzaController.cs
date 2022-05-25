using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Models;
using PizzaAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaAPI.Controllers
{
    [Route("api/Pizzas")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaServices _services;

        public PizzaController(IPizzaServices services)
        {
            _services = services;
        }


        // GET: api/Pizzas
        /// <summary>
        /// Get Pizza Items List
        /// </summary>
        /// <returns>Pizza Items List</returns>
        /// <response code="200"></response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaModel>>> GetTodoItem()
        {
            try
            {
                var result = await _services.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
