using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaDot.Models;
using PizzaDot.Interfaces;
using PizzaDot.Services;
using Microsoft.AspNetCore.Authorization;

namespace PizzaDot.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PizzaController : Controller
    {
        private IPizza _pizza;

        public PizzaController(IPizza pizza)
        {
            _pizza = pizza;
        }

        [HttpGet]
        public IActionResult GetAllPizzas()
        {
            var pizzas = _pizza.GetAllPizza();
            return Ok(pizzas);
        }

        [HttpGet("{id}")]
        public IActionResult GetPizzaById(int id)
        {
            var pizza = _pizza.GetPizzaByID(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return Ok(pizza);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePizza(int id)
        {
            var result = _pizza.DeletePizza(id);
            if (result == 0)
            {
                return NotFound(); 
            }
            return Ok(new
            {
                Message = "Deleted Successfully!"
            }); 
        }

        [HttpPost]
        public IActionResult CreatePizza(Pizza pizza)
        {
            if (pizza == null)
                return BadRequest();

            var createdPizza = _pizza.CreatePizza(pizza);

            if (createdPizza == null)
                return StatusCode(500); 

            return Ok(new
            {
                Message = "Created Successfully!"
            });
        }

        // PUT: api/Pizza/5
        [HttpPut("{id}")]
        public IActionResult UpdatePizza(int id, Pizza pizza)
        {
            var updatedPizza = _pizza.UpdatePizza(id, pizza);
            if (updatedPizza == null)
                return NotFound(); 

            return Ok(new
            {
                Message = "Updated Successfully!"
            }); 
        }
    }
}
