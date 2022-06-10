using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Models;
using PizzaAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAPI.Controllers
{
    [Route("api/Sauce")]
    [ApiController]
    public class SauceController : ControllerBase
    {
        private readonly ISauceServices _services;

        public SauceController(ISauceServices services)
        {
            _services = services;
        }

        // GET: api/<TodoItemController>
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _services.GetAll();
            return Ok(result);

        }

        // GET api/<TodoItemController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetItem(int id)
        {
            var item = await _services.GetById(id);

            if (item == null)
            {
                // Not Found
                return NotFound();
            }

            return Ok(item);
        }

        // POST api/<TodoItemController>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SauceBaseModel value)
        {
            if (value == null)
                return BadRequest("Item null");

            var id = await _services.CreateItem(value);

            return CreatedAtAction(nameof(GetItem), new { id = id }, id);

        }

        // PUT api/<TodoItemController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] SauceBaseModel value)
        {
            var sauceItem = await _services.GetById(id);

            if (sauceItem == null)
                return NotFound("Todo Item Not Found");

            try
            {
                await _services.UpdateItem(id, value);
            }
            catch (Exception e)
            {
                return NotFound("Todo Item Not Found");
            }

            return NoContent();
        }

        // DELETE api/<TodoItemController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var sauceItem = await _services.GetById(id);
            if (sauceItem == null)
                return NotFound("Todo Item Not Found");

            try
            {
                await _services.DeleteItem(id);
            }
            catch (Exception e)
            {
                return NotFound("Todo Item Not Found");
            }

            return NoContent();

        }
    }
}
